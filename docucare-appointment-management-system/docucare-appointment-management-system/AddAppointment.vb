Imports System.Data
Imports System.Globalization
Imports System.Linq

Public Class AddAppointment
    Private db As New DBHandler()
    Private currentDoctorSchedule As New Dictionary(Of DayOfWeek, List(Of Tuple(Of TimeSpan, TimeSpan)))
    Private allPatients As New List(Of PatientItem)

    ' Helper class PatientItem
    Private Class PatientItem
        Public Property Name As String
        Public Property ID As String
        Public Overrides Function ToString() As String
            Return Name
        End Function
    End Class

    ' Helper class DoctorItem
    Private Class DoctorItem
        Public Property Name As String
        Public Property ID As String
        Public Overrides Function ToString() As String
            Return Name & " (ID: " & ID & ")"
        End Function
    End Class

    ' Properties
    Public Property SelectedPatient As String
    Public Property SelectedDoctor As String
    Public Property SelectedDate As String
    Public Property SelectedTime As String
    Public Property SelectedNotes As String
    Public Property SelectedPatientID As String
    Public Property SelectedDoctorVID As String
    Public Property NewAppointmentID As Integer = -1

    ' ---------------- FORM LOAD ----------------
    Private Sub AddAppointment_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Load Patients
        patientDropDown.Items.Clear()
        allPatients.Clear()
        Try
            Dim patientData As DataTable = db.GetAllPatients()
            If patientData IsNot Nothing AndAlso patientData.Rows.Count > 0 Then
                For Each row As DataRow In patientData.Rows
                    Dim item As New PatientItem With {
                        .Name = row("patient_name").ToString(),
                        .ID = row("patient_id").ToString()
                    }
                    allPatients.Add(item)
                    patientDropDown.Items.Add(item)
                Next
            End If
        Catch ex As Exception
            MessageBox.Show("Error loading patients: " & ex.Message)
        End Try

        ' Make patientDropDown editable with suggestion (no forced auto-complete)
        patientDropDown.DropDownStyle = ComboBoxStyle.DropDown
        patientDropDown.AutoCompleteMode = AutoCompleteMode.None
        patientDropDown.AutoCompleteSource = AutoCompleteSource.None

        ' Load Doctors
        doctorDropDown.Items.Clear()
        Try
            Dim doctorData As DataTable = db.GetAllDoctors()
            If doctorData IsNot Nothing AndAlso doctorData.Rows.Count > 0 Then
                For Each row As DataRow In doctorData.Rows
                    doctorDropDown.Items.Add(New DoctorItem With {
                        .Name = row("Personnel_Name").ToString(),
                        .ID = row("Verified_ID").ToString()
                    })
                Next
            End If
        Catch ex As Exception
            MessageBox.Show("Error loading doctors: " & ex.Message)
        End Try
        doctorDropDown.DropDownStyle = ComboBoxStyle.DropDownList

        ' Set up pickers
        DateVal.Format = DateTimePickerFormat.Short
        TimeVal.Format = DateTimePickerFormat.Custom
        TimeVal.CustomFormat = "hh:mm tt"
        TimeVal.ShowUpDown = True

        ' 🚫 Prevent selecting past dates
        DateVal.MinDate = DateTime.Today

        DateVal.Enabled = False
        TimeVal.Enabled = False
        patientDropDown.SelectedIndex = -1
        doctorDropDown.SelectedIndex = -1
    End Sub

    ' ---------------- PATIENT DROPDOWN SUGGESTION ----------------
    Private Sub patientDropDown_TextUpdate(sender As Object, e As EventArgs) Handles patientDropDown.TextUpdate
        Dim combo As ComboBox = DirectCast(sender, ComboBox)
        Dim text As String = combo.Text.Trim().ToLower()

        Dim currentText As String = combo.Text
        Dim cursorPos As Integer = combo.SelectionStart

        Dim filtered = allPatients.
        Where(Function(p) p.Name.ToLower().Contains(text)).
        Take(20).
        ToList()

        combo.BeginUpdate()
        combo.Items.Clear()
        For Each p In filtered
            combo.Items.Add(p)
        Next
        combo.EndUpdate()

        combo.DroppedDown = filtered.Count > 0
        combo.Text = currentText
        combo.SelectionStart = cursorPos
        combo.SelectionLength = 0
        Cursor.Current = Cursors.Default
    End Sub

    Private Sub patientDropDown_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles patientDropDown.Validating
        Dim inputName As String = patientDropDown.Text.Trim().ToLower()
        Dim match = allPatients.FirstOrDefault(Function(p) p.Name.ToLower() = inputName)
        If match Is Nothing AndAlso inputName <> "" Then
            MessageBox.Show("Please select a valid patient from the list.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            e.Cancel = True
        End If
    End Sub

    ' ---------------- DOCTOR SCHEDULE HANDLING ----------------
    Private Sub doctorDropDown_SelectedIndexChanged(sender As Object, e As EventArgs) Handles doctorDropDown.SelectedIndexChanged
        If doctorDropDown.SelectedIndex = -1 OrElse Not TypeOf doctorDropDown.SelectedItem Is DoctorItem Then
            DateVal.Enabled = False
            TimeVal.Enabled = False
            currentDoctorSchedule.Clear()
            Return
        End If

        Dim selectedDoctorItem As DoctorItem = CType(doctorDropDown.SelectedItem, DoctorItem)
        Dim scheduleString As String = db.GetDoctorScheduleByName(selectedDoctorItem.Name)
        ParseDoctorSchedule(scheduleString)
        DateVal.Enabled = True
        TimeVal.Enabled = True
    End Sub

    Private Sub ParseDoctorSchedule(scheduleString As String)
        currentDoctorSchedule.Clear()
        If String.IsNullOrWhiteSpace(scheduleString) OrElse
           scheduleString.Equals("No schedule set.", StringComparison.OrdinalIgnoreCase) OrElse
           scheduleString.Equals("Not Found", StringComparison.OrdinalIgnoreCase) OrElse
           scheduleString.Equals("Error", StringComparison.OrdinalIgnoreCase) Then
            Return
        End If

        Dim parts() As String = scheduleString.Split("|"c)
        Const END_OF_DAY As Long = TimeSpan.TicksPerDay - 1

        For Each part As String In parts
            Dim components() As String = part.Split("-"c)
            If components.Length <> 3 Then Continue For

            Dim dayAbbr As String = components(0)
            Dim day As DayOfWeek
            Dim startTime As TimeSpan
            Dim endTime As TimeSpan

            Select Case dayAbbr.ToUpper()
                Case "MON" : day = DayOfWeek.Monday
                Case "TUE" : day = DayOfWeek.Tuesday
                Case "WED" : day = DayOfWeek.Wednesday
                Case "THU" : day = DayOfWeek.Thursday
                Case "FRI" : day = DayOfWeek.Friday
                Case "SAT" : day = DayOfWeek.Saturday
                Case "SUN" : day = DayOfWeek.Sunday
                Case Else : Continue For
            End Select

            If Not TimeSpan.TryParse(components(1), startTime) OrElse Not TimeSpan.TryParse(components(2), endTime) Then Continue For

            If Not currentDoctorSchedule.ContainsKey(day) Then
                currentDoctorSchedule(day) = New List(Of Tuple(Of TimeSpan, TimeSpan))
            End If

            If endTime < startTime Then
                currentDoctorSchedule(day).Add(New Tuple(Of TimeSpan, TimeSpan)(startTime, New TimeSpan(END_OF_DAY)))
                Dim nextDay As DayOfWeek = If(day = DayOfWeek.Saturday, DayOfWeek.Sunday, day + 1)
                If Not currentDoctorSchedule.ContainsKey(nextDay) Then
                    currentDoctorSchedule(nextDay) = New List(Of Tuple(Of TimeSpan, TimeSpan))
                End If
                currentDoctorSchedule(nextDay).Add(New Tuple(Of TimeSpan, TimeSpan)(TimeSpan.Zero, endTime))
            Else
                currentDoctorSchedule(day).Add(New Tuple(Of TimeSpan, TimeSpan)(startTime, endTime))
            End If
        Next
    End Sub

    ' ---------------- SAVE BUTTON ----------------
    Private Sub Save_Click(sender As Object, e As EventArgs) Handles Save.Click
        ' 🚫 Block saving past dates (safety check)
        If DateVal.Value.Date < DateTime.Today Then
            MessageBox.Show("You cannot schedule an appointment in the past.", "Invalid Date", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If patientDropDown.SelectedItem Is Nothing OrElse Not TypeOf patientDropDown.SelectedItem Is PatientItem Then
            MessageBox.Show("Please select a valid patient.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        If doctorDropDown.SelectedItem Is Nothing OrElse Not TypeOf doctorDropDown.SelectedItem Is DoctorItem Then
            MessageBox.Show("Please select a valid doctor.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        If String.IsNullOrWhiteSpace(Notes.Text) Then
            MessageBox.Show("Please add a note or reason for the appointment.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim selectedPatientItem As PatientItem = CType(patientDropDown.SelectedItem, PatientItem)
        Dim selectedDoctorItem As DoctorItem = CType(doctorDropDown.SelectedItem, DoctorItem)

        SelectedPatient = selectedPatientItem.Name
        SelectedPatientID = selectedPatientItem.ID
        SelectedDoctor = selectedDoctorItem.Name
        SelectedDoctorVID = selectedDoctorItem.ID
        SelectedDate = DateVal.Value.ToString("MMddyyyy")
        SelectedTime = TimeVal.Value.ToString("HH:mm")
        SelectedNotes = Notes.Text

        Try
            Me.NewAppointmentID = db.InsertAppointment(SelectedPatient, SelectedPatientID, SelectedDoctor, SelectedDoctorVID, SelectedDate, SelectedTime, "Queued", SelectedNotes, 0)
            If Me.NewAppointmentID > 0 Then
                MessageBox.Show("Appointment saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.DialogResult = DialogResult.OK
                Me.Close()
            Else
                MessageBox.Show("Failed to save appointment.", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show("Error while saving appointment: " & ex.Message)
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub
End Class
