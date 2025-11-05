Imports System.Data
Imports System.Globalization

Public Class ReschedAppointment
    Private db As New DBHandler()
    Private currentDoctorSchedule As New Dictionary(Of DayOfWeek, List(Of Tuple(Of TimeSpan, TimeSpan)))

    ' --- Properties passed from UcAppointment ---
    Public Property AppointmentID As Integer
    Public Property PatientName As String
    Public Property DoctorName As String
    Public Property AppointmentDate As String
    Public Property AppointmentTime As String
    Public Property NotesText As String

    ' --- FORM LOAD ---
    Private Sub ReschedAppointment_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Fill placeholders
        patientDropDown.Text = PatientName
        doctorDropDown.Text = DoctorName
        patientDropDown.Enabled = False
        doctorDropDown.Enabled = False

        ' Setup pickers
        DateVal.Format = DateTimePickerFormat.Short
        DateVal.MinDate = DateTime.Today
        TimeVal.Format = DateTimePickerFormat.Custom
        TimeVal.CustomFormat = "hh:mm tt"
        TimeVal.ShowUpDown = True

        ' Parse date
        Try
            If Not String.IsNullOrWhiteSpace(AppointmentDate) Then
                DateVal.Value = DateTime.ParseExact(AppointmentDate, "MMddyyyy", CultureInfo.InvariantCulture)
                If DateVal.Value < DateTime.Today Then
                    DateVal.Value = DateTime.Today
                End If
            Else
                DateVal.Value = DateTime.Today
            End If
        Catch
            DateVal.Value = DateTime.Today
        End Try

        ' Parse time
        Try
            If Not String.IsNullOrWhiteSpace(AppointmentTime) Then
                TimeVal.Value = DateTime.Parse(AppointmentTime, CultureInfo.InvariantCulture)
            Else
                TimeVal.Value = DateTime.Now
            End If
        Catch
            TimeVal.Value = DateTime.Now
        End Try

        Notes.Text = NotesText

        ' --- Load doctor schedule ---
        Try
            Dim scheduleString As String = db.GetDoctorScheduleByName(DoctorName)
            ParseDoctorSchedule(scheduleString)
        Catch ex As Exception
            MessageBox.Show("Error loading doctor schedule: " & ex.Message)
        End Try
    End Sub

    ' --- PARSE DOCTOR SCHEDULE ---
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

    ' --- VALIDATE DOCTOR AVAILABILITY ---
    Private Function IsDoctorAvailable(dateVal As DateTime, timeVal As DateTime) As Boolean
        Dim day As DayOfWeek = dateVal.DayOfWeek
        Dim timeOfDay As TimeSpan = timeVal.TimeOfDay

        If Not currentDoctorSchedule.ContainsKey(day) Then
            Return False
        End If

        For Each interval In currentDoctorSchedule(day)
            If timeOfDay >= interval.Item1 AndAlso timeOfDay <= interval.Item2 Then
                Return True
            End If
        Next

        Return False
    End Function

    ' --- SAVE CHANGES ---
    Private Sub Save_Click(sender As Object, e As EventArgs) Handles Save.Click
        ' 🚫 Prevent past reschedules
        If DateVal.Value.Date < DateTime.Today Then
            MessageBox.Show("You cannot reschedule to a past date.", "Invalid Date", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim newDate As String = DateVal.Value.ToString("MMddyyyy")
        Dim newTime As String = TimeVal.Value.ToString("HH:mm:ss")
        Dim newNotes As String = Notes.Text.Trim()

        If String.IsNullOrWhiteSpace(newNotes) Then
            MessageBox.Show("Please enter a note before saving.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' ✅ Doctor availability check
        If Not IsDoctorAvailable(DateVal.Value, TimeVal.Value) Then
            MessageBox.Show("This doctor is not available at the selected date and time.", "Schedule Conflict", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        Try
            Dim query As String =
                "UPDATE appointments SET " &
                "`date` = '" & newDate & "', " &
                "`time` = '" & newTime & "', " &
                "`notes` = '" & newNotes.Replace("'", "''") & "' " &
                "WHERE appointment_id = " & AppointmentID

            Dim rowsAffected As Integer = db.ExecuteNonQuery(query)

            If rowsAffected > 0 Then
                MessageBox.Show("Appointment successfully rescheduled.", "Reschedule", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.DialogResult = DialogResult.OK
                Me.Close()
            Else
                MessageBox.Show("No changes were made or appointment not found.", "Reschedule", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
        Catch ex As Exception
            MessageBox.Show("Error rescheduling appointment: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class
