Imports System.Data
Imports System.Globalization

Public Class ModifyAppointment
    Private db As New DBHandler()
    Private _appointmentID As Integer = -1

    ' Helper class PatientItem (same as AddAppointment)
    Private Class PatientItem
        Public Property Name As String
        Public Property ID As String
        Public Overrides Function ToString() As String
            Return Name & " (ID: " & ID & ")"
        End Function
    End Class

    ' Helper class DoctorItem (same as AddAppointment)
    Private Class DoctorItem
        Public Property Name As String
        Public Property ID As String
        Public Overrides Function ToString() As String
            Return Name & " (ID: " & ID & ")"
        End Function
    End Class

    ' Properties that mirror AddAppointment
    Public Property SelectedPatient As String
    Public Property SelectedDoctor As String
    Public Property SelectedDate As String
    Public Property SelectedTime As String
    Public Property SelectedNotes As String
    Public Property SelectedPatientID As String
    Public Property SelectedDoctorVID As String

    ' Keep schedule structure as in AddAppointment
    Private currentDoctorSchedule As New Dictionary(Of DayOfWeek, List(Of Tuple(Of TimeSpan, TimeSpan)))

    ' === FORM LOAD ===
    Private Sub ModifyAppointment_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Load doctors into dropdown as DoctorItem objects (same as AddAppointment)
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
            Else
                doctorDropDown.Items.Add("No doctors found")
            End If
        Catch ex As Exception
            doctorDropDown.Items.Add("Error loading doctors: " & ex.Message)
        End Try
        doctorDropDown.DropDownStyle = ComboBoxStyle.DropDownList

        ' Configure date/time pickers same as AddAppointment
        DateVal.Format = DateTimePickerFormat.Short
        TimeVal.Format = DateTimePickerFormat.Custom
        TimeVal.CustomFormat = "hh:mm tt"
        TimeVal.ShowUpDown = True

        ' By default disable until doctor selected (patient is uneditable)
        DateVal.Enabled = False
        TimeVal.Enabled = False
    End Sub

    ' === LOAD APPOINTMENT DATA ===
    ' Called from UcAppointment when Modify is clicked.
    ' noteText param renamed to avoid conflicts with the Notes control.
    Public Sub LoadAppointmentData(appID As Integer, patientName As String, patientID As String, doctorName As String, doctorVID As String, appDate As String, appTime As String, noteText As String)
        _appointmentID = appID

        ' Set patient info (uneditable)
        SelectedPatient = patientName
        SelectedPatientID = patientID
        patientDropDown.Items.Clear()
        patientDropDown.Items.Add(New PatientItem With {.Name = patientName, .ID = patientID})
        patientDropDown.SelectedIndex = 0
        patientDropDown.Enabled = False

        ' Select doctor if present in dropdown (match by Verified ID first then name)
        SelectedDoctor = doctorName
        SelectedDoctorVID = doctorVID
        For i As Integer = 0 To doctorDropDown.Items.Count - 1
            If TypeOf doctorDropDown.Items(i) Is DoctorItem Then
                Dim d As DoctorItem = CType(doctorDropDown.Items(i), DoctorItem)
                If d.ID = doctorVID OrElse d.Name = doctorName Then
                    doctorDropDown.SelectedIndex = i
                    Exit For
                End If
            End If
        Next

        ' Setup date/time/notes fields
        If Not String.IsNullOrWhiteSpace(appDate) Then
            Dim parsedDate As Date
            If Date.TryParse(appDate, parsedDate) Then
                DateVal.Value = parsedDate.Date
            Else
                Try
                    DateVal.Value = Date.ParseExact(appDate, "MMddyyyy", CultureInfo.InvariantCulture)
                Catch
                    ' leave default if parsing fails
                End Try
            End If
        End If

        If Not String.IsNullOrWhiteSpace(appTime) Then
            Dim parsedTime As DateTime
            If DateTime.TryParseExact(appTime, "hh:mm tt", CultureInfo.InvariantCulture, Globalization.DateTimeStyles.None, parsedTime) _
               OrElse DateTime.TryParseExact(appTime, "HH:mm", CultureInfo.InvariantCulture, Globalization.DateTimeStyles.None, parsedTime) _
               OrElse DateTime.TryParse(appTime, parsedTime) Then
                TimeVal.Value = parsedTime
            End If
        End If

        Notes.Text = noteText
    End Sub

    ' === DOCTOR SELECTION CHANGE ===
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

    ' === PARSE DOCTOR SCHEDULE (copied from AddAppointment) ===
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
            Dim originalEndTime As TimeSpan

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

            If Not TimeSpan.TryParse(components(1), startTime) OrElse Not TimeSpan.TryParse(components(2), originalEndTime) Then Continue For

            If Not currentDoctorSchedule.ContainsKey(day) Then
                currentDoctorSchedule.Add(day, New List(Of Tuple(Of TimeSpan, TimeSpan)))
            End If

            If originalEndTime < startTime Then ' Overnight shift
                currentDoctorSchedule(day).Add(New Tuple(Of TimeSpan, TimeSpan)(startTime, New TimeSpan(END_OF_DAY)))
                Dim nextDay As DayOfWeek = If(day = DayOfWeek.Saturday, DayOfWeek.Sunday, day + 1)
                If Not currentDoctorSchedule.ContainsKey(nextDay) Then
                    currentDoctorSchedule.Add(nextDay, New List(Of Tuple(Of TimeSpan, TimeSpan)))
                End If
                currentDoctorSchedule(nextDay).Add(New Tuple(Of TimeSpan, TimeSpan)(TimeSpan.Zero, originalEndTime))
            Else
                currentDoctorSchedule(day).Add(New Tuple(Of TimeSpan, TimeSpan)(startTime, originalEndTime))
            End If
        Next
    End Sub

    ' === SAVE BUTTON ===
    Private Sub Save_Click(sender As Object, e As EventArgs) Handles Save.Click
        ' Validate doctor
        If doctorDropDown.SelectedIndex = -1 OrElse Not TypeOf doctorDropDown.SelectedItem Is DoctorItem Then
            MessageBox.Show("Please select a valid doctor.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Notes required (mirrors AddAppointment validation)
        If String.IsNullOrWhiteSpace(Notes.Text) Then
            MessageBox.Show("Please add a note or reason for the appointment.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Gather selection info
        Dim selectedDoctorItem As DoctorItem = CType(doctorDropDown.SelectedItem, DoctorItem)
        Dim selectedDateAsDate As Date = DateVal.Value.Date
        Dim selectedDayOfWeek As DayOfWeek = selectedDateAsDate.DayOfWeek
        Dim selectedTimeAsTimeSpan As TimeSpan = TimeVal.Value.TimeOfDay

        ' Schedule checks (same logic as AddAppointment)
        If currentDoctorSchedule.Count = 0 Then
            MessageBox.Show("This doctor does not have a schedule set and cannot be booked.", "Schedule Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        If Not currentDoctorSchedule.ContainsKey(selectedDayOfWeek) Then
            MessageBox.Show($"This doctor is not available on {selectedDayOfWeek}s. Please select a different day.", "Schedule Conflict", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim validSlots As List(Of Tuple(Of TimeSpan, TimeSpan)) = currentDoctorSchedule(selectedDayOfWeek)
        Dim isTimeValid As Boolean = False
        Const END_OF_DAY As Long = TimeSpan.TicksPerDay - 1

        For Each slot As Tuple(Of TimeSpan, TimeSpan) In validSlots
            Dim startTime As TimeSpan = slot.Item1
            Dim endTimeForCalc As TimeSpan = slot.Item2

            If selectedTimeAsTimeSpan >= startTime Then
                If endTimeForCalc.Ticks = END_OF_DAY Then
                    If selectedTimeAsTimeSpan.Ticks <= END_OF_DAY Then
                        isTimeValid = True : Exit For
                    End If
                ElseIf selectedTimeAsTimeSpan <= endTimeForCalc Then
                    isTimeValid = True : Exit For
                End If
            End If
        Next

        If Not isTimeValid Then
            MessageBox.Show($"Selected time is outside the doctor's schedule on {selectedDayOfWeek}.", "Schedule Conflict", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Fill properties for possible outside use
        SelectedPatient = CType(patientDropDown.Items(0), PatientItem).Name
        SelectedPatientID = CType(patientDropDown.Items(0), PatientItem).ID
        SelectedDoctor = selectedDoctorItem.Name
        SelectedDoctorVID = selectedDoctorItem.ID
        SelectedDate = DateVal.Value.ToString("MMddyyyy")
        SelectedTime = TimeVal.Value.ToString("HH:mm")
        SelectedNotes = Notes.Text

        Try
            ' Use the new DBHandler.UpdateAppointment method added above.
            ' Passing consultFee = 0 to keep same behavior as AddAppointment example (adjust if you store an actual fee)
            Dim rowsAffected As Integer = db.UpdateAppointment(_appointmentID, SelectedPatient, SelectedPatientID, SelectedDoctor, SelectedDoctorVID, SelectedDate, SelectedTime, "On-Going", SelectedNotes, 0D)

            If rowsAffected > 0 Then
                MessageBox.Show("Appointment updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.DialogResult = DialogResult.OK
                Me.Close()
            Else
                MessageBox.Show("Failed to update appointment.", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show("An error occurred while updating the appointment: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' === CANCEL BUTTON ===
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub
End Class
