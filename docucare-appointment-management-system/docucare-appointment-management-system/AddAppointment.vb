Imports System.Data
Imports System.Globalization

Public Class AddAppointment
    Private db As New DBHandler()
    Private currentDoctorSchedule As New Dictionary(Of DayOfWeek, List(Of Tuple(Of TimeSpan, TimeSpan)))

    ' Helper class PatientItem
    Private Class PatientItem
        Public Property Name As String
        Public Property ID As String
        Public Overrides Function ToString() As String
            Return Name & " (ID: " & ID & ")"
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

    ' FORM LOAD
    Private Sub AddAppointment_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Load Patients
        patientDropDown.Items.Clear()
        Try
            Dim patientData As DataTable = db.GetAllPatients()
            If patientData IsNot Nothing AndAlso patientData.Rows.Count > 0 Then
                For Each row As DataRow In patientData.Rows
                    patientDropDown.Items.Add(New PatientItem With {
                         .Name = row("patient_name").ToString(),
                         .ID = row("patient_id").ToString()
                    })
                Next
            Else
                patientDropDown.Items.Add("No patients found")
            End If
        Catch ex As Exception
            patientDropDown.Items.Add("Error loading patients: " & ex.Message)
        End Try
        patientDropDown.DropDownStyle = ComboBoxStyle.DropDownList

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
            Else
                doctorDropDown.Items.Add("No doctors found")
            End If
        Catch ex As Exception
            doctorDropDown.Items.Add("Error loading doctors: " & ex.Message)
        End Try
        doctorDropDown.DropDownStyle = ComboBoxStyle.DropDownList

        ' Set up pickers
        DateVal.Format = DateTimePickerFormat.Short
        TimeVal.Format = DateTimePickerFormat.Custom
        TimeVal.CustomFormat = "hh:mm tt"
        TimeVal.ShowUpDown = True

        ' Disable until doctor selected
        DateVal.Enabled = False
        TimeVal.Enabled = False
        patientDropDown.SelectedIndex = -1
        doctorDropDown.SelectedIndex = -1
    End Sub

    ' Doctor Selection Changed
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

    ' Parse Schedule
    Private Sub ParseDoctorSchedule(scheduleString As String)
        currentDoctorSchedule.Clear()
        If String.IsNullOrWhiteSpace(scheduleString) OrElse scheduleString.Equals("No schedule set.", StringComparison.OrdinalIgnoreCase) OrElse scheduleString.Equals("Not Found", StringComparison.OrdinalIgnoreCase) OrElse scheduleString.Equals("Error", StringComparison.OrdinalIgnoreCase) Then
            Return
        End If

        Dim parts() As String = scheduleString.Split("|"c)
        Const END_OF_DAY As Long = TimeSpan.TicksPerDay - 1 ' Represents 23:59:59.99...

        For Each part As String In parts
            Dim components() As String = part.Split("-"c)
            If components.Length <> 3 Then Continue For

            Dim dayAbbr As String = components(0)
            Dim day As DayOfWeek
            Dim startTime As TimeSpan
            Dim originalEndTime As TimeSpan ' The actual time string from schedule

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
                ' Part 1: Start time to logical end of day (23:59:59...)
                currentDoctorSchedule(day).Add(New Tuple(Of TimeSpan, TimeSpan)(startTime, New TimeSpan(END_OF_DAY)))

                Dim nextDay As DayOfWeek = If(day = DayOfWeek.Saturday, DayOfWeek.Sunday, day + 1)
                If Not currentDoctorSchedule.ContainsKey(nextDay) Then
                    currentDoctorSchedule.Add(nextDay, New List(Of Tuple(Of TimeSpan, TimeSpan)))
                End If
                ' Part 2: Logical start of next day (00:00:00) to Original End time
                currentDoctorSchedule(nextDay).Add(New Tuple(Of TimeSpan, TimeSpan)(TimeSpan.Zero, originalEndTime))
            Else ' Normal shift
                currentDoctorSchedule(day).Add(New Tuple(Of TimeSpan, TimeSpan)(startTime, originalEndTime))
            End If
        Next
    End Sub

    ' SAVE BUTTON
    Private Sub Save_Click(sender As Object, e As EventArgs) Handles Save.Click
        ' Validation
        If patientDropDown.SelectedIndex = -1 OrElse Not TypeOf patientDropDown.SelectedItem Is PatientItem Then
            MessageBox.Show("Please select a valid patient.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning) : Return
        End If
        If doctorDropDown.SelectedIndex = -1 OrElse Not TypeOf doctorDropDown.SelectedItem Is DoctorItem Then
            MessageBox.Show("Please select a valid doctor.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning) : Return
        End If
        If String.IsNullOrWhiteSpace(Notes.Text) Then
            MessageBox.Show("Please add a note or reason for the appointment.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning) : Return
        End If

        Dim selectedPatientItem As PatientItem = CType(patientDropDown.SelectedItem, PatientItem)
        Dim selectedDoctorItem As DoctorItem = CType(doctorDropDown.SelectedItem, DoctorItem)

        ' Schedule Validation
        Dim selectedDateAsDate As Date = DateVal.Value.Date
        Dim selectedDayOfWeek As DayOfWeek = selectedDateAsDate.DayOfWeek
        Dim selectedTimeAsTimeSpan As TimeSpan = TimeVal.Value.TimeOfDay

        If currentDoctorSchedule.Count = 0 Then
            MessageBox.Show("This doctor does not have a schedule set and cannot be booked.", "Schedule Error", MessageBoxButtons.OK, MessageBoxIcon.Error) : Return
        End If

        If Not currentDoctorSchedule.ContainsKey(selectedDayOfWeek) Then
            MessageBox.Show($"This doctor is not available on {selectedDayOfWeek}s. Please select a different day.", "Schedule Conflict", MessageBoxButtons.OK, MessageBoxIcon.Warning) : Return
        End If

        Dim validSlots As List(Of Tuple(Of TimeSpan, TimeSpan)) = currentDoctorSchedule(selectedDayOfWeek)
        Dim isTimeValid As Boolean = False
        Const END_OF_DAY As Long = TimeSpan.TicksPerDay - 1

        For Each slot As Tuple(Of TimeSpan, TimeSpan) In validSlots
            Dim startTime As TimeSpan = slot.Item1
            Dim endTimeForCalc As TimeSpan = slot.Item2 ' This is the logical end time (might be END_OF_DAY)

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
            ' --- CORRECTED ERROR MESSAGE BUILDING ---
            Dim displaySlots As New List(Of String)
            ' Fetch the original schedule string again specifically for display
            Dim scheduleStringForDisplay As String = db.GetDoctorScheduleByName(selectedDoctorItem.Name) ' Assumes selectedDoctorItem is available here

            If Not String.IsNullOrWhiteSpace(scheduleStringForDisplay) AndAlso Not scheduleStringForDisplay.StartsWith("No schedule") AndAlso Not scheduleStringForDisplay.StartsWith("Error") Then
                Dim parts() As String = scheduleStringForDisplay.Split("|"c)

                For Each part As String In parts
                    Dim components() As String = part.Split("-"c)
                    If components.Length = 3 Then
                        Dim dayAbbr As String = components(0)
                        Dim startTimeStr As String = components(1)
                        Dim endTimeStr As String = components(2)
                        Dim dayOfWeekPart As DayOfWeek

                        ' Convert abbreviation to DayOfWeek
                        Select Case dayAbbr.ToUpper()
                            Case "MON" : dayOfWeekPart = DayOfWeek.Monday
                            Case "TUE" : dayOfWeekPart = DayOfWeek.Tuesday
                            Case "WED" : dayOfWeekPart = DayOfWeek.Wednesday
                            Case "THU" : dayOfWeekPart = DayOfWeek.Thursday
                            Case "FRI" : dayOfWeekPart = DayOfWeek.Friday
                            Case "SAT" : dayOfWeekPart = DayOfWeek.Saturday
                            Case "SUN" : dayOfWeekPart = DayOfWeek.Sunday
                            Case Else : Continue For ' Skip if invalid day
                        End Select

                        ' Check if this schedule part contributes to the selected day's availability
                        Dim startTimeOrig As TimeSpan
                        Dim endTimeOrig As TimeSpan
                        If TimeSpan.TryParse(startTimeStr, startTimeOrig) AndAlso TimeSpan.TryParse(endTimeStr, endTimeOrig) Then
                            Dim isOvernight As Boolean = endTimeOrig < startTimeOrig
                            Dim previousDay As DayOfWeek = If(selectedDayOfWeek = DayOfWeek.Sunday, DayOfWeek.Saturday, selectedDayOfWeek - 1)

                            ' Is this part relevant for the selected day's message?
                            If dayOfWeekPart = selectedDayOfWeek Then
                                ' Format the original times from the string component
                                Dim startStr = (New DateTime(startTimeOrig.Ticks)).ToString("hh:mm tt")
                                Dim endStr = (New DateTime(endTimeOrig.Ticks)).ToString("hh:mm tt")
                                displaySlots.Add($"from {startStr} to {endStr}")

                            ElseIf isOvernight AndAlso dayOfWeekPart = previousDay Then
                                ' If it's an overnight shift from the PREVIOUS day,
                                ' only the part AFTER midnight is relevant to the SELECTED day.
                                Dim endStr = (New DateTime(endTimeOrig.Ticks)).ToString("hh:mm tt")
                                ' Show it as starting from midnight for the selected day
                                displaySlots.Add($"from 12:00 AM to {endStr}")
                            End If
                        End If
                    End If
                Next
            End If

            Dim finalMessage As String
            If displaySlots.Count > 0 Then
                finalMessage = $"The selected time is outside the doctor's availability on {selectedDayOfWeek}s." & vbCrLf &
                               $"Available slots for {selectedDayOfWeek}: {String.Join(" or ", displaySlots)}"
            Else
                finalMessage = $"This doctor is not available on {selectedDayOfWeek}s, or schedule data is missing/invalid." ' More informative fallback
            End If
            MessageBox.Show(finalMessage, "Schedule Conflict", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            ' --- END CORRECTED ERROR MESSAGE BUILDING ---
            Return ' Exit the Sub after showing the error
        End If

        ' Store and Save
        SelectedPatient = selectedPatientItem.Name
        SelectedPatientID = selectedPatientItem.ID
        SelectedDoctor = selectedDoctorItem.Name
        SelectedDoctorVID = selectedDoctorItem.ID
        SelectedDate = DateVal.Value.ToString("MMddyyyy") ' Format for VARCHAR(8)
        SelectedTime = TimeVal.Value.ToString("HH:mm")    ' Format for VARCHAR(10)
        SelectedNotes = Notes.Text

        Try
            Me.NewAppointmentID = db.InsertAppointment(SelectedPatient, SelectedPatientID, SelectedDoctor, SelectedDoctorVID, SelectedDate, SelectedTime, "On-Going", SelectedNotes, 0)
            If Me.NewAppointmentID > 0 Then
                MessageBox.Show("Appointment saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.DialogResult = DialogResult.OK
                Me.Close()
            Else
                MessageBox.Show("Failed to save appointment (InsertAppointment returned <= 0).", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show("An error occurred while saving the appointment: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' Cancel Button
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub
End Class