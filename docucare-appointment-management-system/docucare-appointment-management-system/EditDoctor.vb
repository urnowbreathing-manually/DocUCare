Imports System.Data
Imports System.Text.RegularExpressions

Public Class EditDoctor
    Private dataRow As DataRow
    Private db As New DBHandler()

    Public Sub New(row As DataRow)
        InitializeComponent()
        dataRow = row
        DisableAllDateTimePickers(Me)
        LoadDoctorData()
        LoadSchedule(dataRow("Schedule").ToString())
    End Sub

    ' --- Disable DateTimePickers initially ---
    Private Sub DisableAllDateTimePickers(parent As Control)
        For Each ctrl As Control In parent.Controls
            If TypeOf ctrl Is DateTimePicker Then
                Dim dtp As DateTimePicker = CType(ctrl, DateTimePicker)
                dtp.Format = DateTimePickerFormat.Custom
                dtp.CustomFormat = "hh:mm tt"
                dtp.ShowUpDown = True
                dtp.Enabled = False
            End If
            If ctrl.HasChildren Then DisableAllDateTimePickers(ctrl)
        Next
    End Sub

    ' --- Load basic doctor info ---
    Private Sub LoadDoctorData()
        Dim nameParts = dataRow("Personnel_Name").ToString().Split(" "c)
        FirstName.Text = nameParts(0)
        If nameParts.Length > 1 Then LastName.Text = nameParts(1)

        VerificationID.Text = dataRow("Verified_ID").ToString()
        If dataRow.Table.Columns.Contains("ContactNo") Then ContactNum.Text = dataRow("ContactNo").ToString()
        If dataRow.Table.Columns.Contains("Password") Then
            Password.Text = dataRow("Password").ToString()
            ConfirmPassword.Text = dataRow("Password").ToString()
        End If
    End Sub

    ' --- Load schedule string into checkboxes and pickers ---
    Private Sub LoadSchedule(schedule As String)
        If schedule = "" OrElse schedule = "No schedule set." Then Exit Sub

        Dim days = schedule.Split("|"c)
        For Each day In days
            Dim parts = day.Split("-"c)
            If parts.Length <> 3 Then Continue For

            Dim dayCode = parts(0)
            Dim startTime = parts(1)
            Dim endTime = parts(2)

            Select Case dayCode
                Case "MON"
                    checkMonday.Checked = True
                    MondayStart.Value = DateTime.ParseExact(startTime, "HH:mm", Nothing)
                    MondayEnd.Value = DateTime.ParseExact(endTime, "HH:mm", Nothing)
                Case "TUE"
                    checkTue.Checked = True
                    TueStart.Value = DateTime.ParseExact(startTime, "HH:mm", Nothing)
                    TueEnd.Value = DateTime.ParseExact(endTime, "HH:mm", Nothing)
                Case "WED"
                    checkWed.Checked = True
                    WedStart.Value = DateTime.ParseExact(startTime, "HH:mm", Nothing)
                    WedEnd.Value = DateTime.ParseExact(endTime, "HH:mm", Nothing)
                Case "THU"
                    checkThu.Checked = True
                    ThuStart.Value = DateTime.ParseExact(startTime, "HH:mm", Nothing)
                    ThuEnd.Value = DateTime.ParseExact(endTime, "HH:mm", Nothing)
                Case "FRI"
                    checkFri.Checked = True
                    FriStart.Value = DateTime.ParseExact(startTime, "HH:mm", Nothing)
                    FridEnd.Value = DateTime.ParseExact(endTime, "HH:mm", Nothing)
                Case "SAT"
                    checkSat.Checked = True
                    SatStart.Value = DateTime.ParseExact(startTime, "HH:mm", Nothing)
                    SatEnd.Value = DateTime.ParseExact(endTime, "HH:mm", Nothing)
                Case "SUN"
                    checkSun.Checked = True
                    SunStart.Value = DateTime.ParseExact(startTime, "HH:mm", Nothing)
                    SunEnd.Value = DateTime.ParseExact(endTime, "HH:mm", Nothing)
            End Select
        Next
    End Sub

    ' --- Save button ---
    Private Sub SaveBtn_Click(sender As Object, e As EventArgs) Handles SaveBtn.Click
        ' --- VALIDATION ---
        Dim missingFields As New List(Of String)
        If String.IsNullOrWhiteSpace(FirstName.Text) Then missingFields.Add("First Name")
        If String.IsNullOrWhiteSpace(LastName.Text) Then missingFields.Add("Last Name")
        If String.IsNullOrWhiteSpace(VerificationID.Text) Then missingFields.Add("Verification ID")
        If String.IsNullOrWhiteSpace(Password.Text) Then missingFields.Add("Password")
        If String.IsNullOrWhiteSpace(ConfirmPassword.Text) Then missingFields.Add("Confirm Password")

        ' Ensure at least one day selected
        If Not (checkMonday.Checked Or checkTue.Checked Or checkWed.Checked Or checkThu.Checked Or checkFri.Checked Or checkSat.Checked Or checkSun.Checked) Then
            missingFields.Add("At least one day of schedule must be selected")
        End If

        If missingFields.Count > 0 Then
            MessageBox.Show("Please fill in the following required fields:" & vbCrLf &
                        String.Join(vbCrLf, missingFields),
                        "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If Password.Text <> ConfirmPassword.Text Then
            MessageBox.Show("Passwords do not match.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        ' --- CLEAN INPUTS ---
        FirstName.Text = Regex.Replace(FirstName.Text, "[^a-zA-Z\s]", "")
        LastName.Text = Regex.Replace(LastName.Text, "[^a-zA-Z\s]", "")

        ' --- BUILD SCHEDULE STRING ---
        Dim scheduleStr As New List(Of String)
        Dim dbFormat As String = "HH:mm"
        If checkMonday.Checked Then scheduleStr.Add($"MON-{MondayStart.Value.ToString(dbFormat)}-{MondayEnd.Value.ToString(dbFormat)}")
        If checkTue.Checked Then scheduleStr.Add($"TUE-{TueStart.Value.ToString(dbFormat)}-{TueEnd.Value.ToString(dbFormat)}")
        If checkWed.Checked Then scheduleStr.Add($"WED-{WedStart.Value.ToString(dbFormat)}-{WedEnd.Value.ToString(dbFormat)}")
        If checkThu.Checked Then scheduleStr.Add($"THU-{ThuStart.Value.ToString(dbFormat)}-{ThuEnd.Value.ToString(dbFormat)}")
        If checkFri.Checked Then scheduleStr.Add($"FRI-{FriStart.Value.ToString(dbFormat)}-{FridEnd.Value.ToString(dbFormat)}")
        If checkSat.Checked Then scheduleStr.Add($"SAT-{SatStart.Value.ToString(dbFormat)}-{SatEnd.Value.ToString(dbFormat)}")
        If checkSun.Checked Then scheduleStr.Add($"SUN-{SunStart.Value.ToString(dbFormat)}-{SunEnd.Value.ToString(dbFormat)}")
        Dim scheduleFinal = String.Join("|", scheduleStr)

        ' --- BUILD SQL & PARAMETERS ---
        Dim fullName = FirstName.Text & " " & LastName.Text
        Dim updateQuery As String = "UPDATE personneltable SET Personnel_Name=@name, Verified_ID=@vid, Schedule=@sched"
        Dim parameters As New Dictionary(Of String, Object) From {
            {"@name", fullName},
            {"@vid", VerificationID.Text},
            {"@sched", scheduleFinal},
            {"@id", dataRow("ID")}
        }

        ' Optional fields
        If dataRow.Table.Columns.Contains("Password") Then updateQuery &= ", Password=@pass" : parameters.Add("@pass", Password.Text)
        If dataRow.Table.Columns.Contains("ContactNo") Then updateQuery &= ", ContactNo=@contact" : parameters.Add("@contact", If(ContactNum.Text, ""))

        updateQuery &= " WHERE ID=@id"

        ' --- EXECUTE ---
        If db.ExecuteNonQueryWithParameters(updateQuery, parameters) Then
            ' Update local DataRow
            dataRow("Personnel_Name") = fullName
            dataRow("Verified_ID") = VerificationID.Text
            dataRow("Schedule") = scheduleFinal
            If dataRow.Table.Columns.Contains("Password") Then dataRow("Password") = Password.Text
            If dataRow.Table.Columns.Contains("ContactNo") Then dataRow("ContactNo") = If(ContactNum.Text, "")

            MessageBox.Show("Doctor info updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Close()
        Else
            MessageBox.Show("Failed to update doctor. DB error or Verification ID exists.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    ' --- Cancel ---
    Private Sub Cancel_Click(sender As Object, e As EventArgs) Handles Cancel.Click
        Me.Close()
    End Sub

    ' --- Text Validations ---
    Private Sub ContactNum_TextChanged(sender As Object, e As EventArgs) Handles ContactNum.TextChanged
        Dim caret = ContactNum.SelectionStart
        ContactNum.Text = Regex.Replace(ContactNum.Text, "[^\d]", "")
        If ContactNum.Text.Length > 11 Then ContactNum.Text = ContactNum.Text.Substring(0, 11)
        ContactNum.SelectionStart = Math.Min(caret, ContactNum.Text.Length)
    End Sub

    Private Sub FirstName_TextChanged(sender As Object, e As EventArgs) Handles FirstName.TextChanged
        Dim caret = FirstName.SelectionStart
        FirstName.Text = Regex.Replace(FirstName.Text, "[^a-zA-Z\s]", "")
        FirstName.SelectionStart = Math.Min(caret, FirstName.Text.Length)
    End Sub

    Private Sub LastName_TextChanged(sender As Object, e As EventArgs) Handles LastName.TextChanged
        Dim caret = LastName.SelectionStart
        LastName.Text = Regex.Replace(LastName.Text, "[^a-zA-Z\s]", "")
        LastName.SelectionStart = Math.Min(caret, LastName.Text.Length)
    End Sub

    ' --- Enable pickers when checkbox changes ---
    Private Sub checkMonday_CheckedChanged(sender As Object, e As EventArgs) Handles checkMonday.CheckedChanged
        MondayStart.Enabled = checkMonday.Checked
        MondayEnd.Enabled = checkMonday.Checked
    End Sub
    Private Sub checkTue_CheckedChanged(sender As Object, e As EventArgs) Handles checkTue.CheckedChanged
        TueStart.Enabled = checkTue.Checked
        TueEnd.Enabled = checkTue.Checked
    End Sub
    Private Sub checkWed_CheckedChanged(sender As Object, e As EventArgs) Handles checkWed.CheckedChanged
        WedStart.Enabled = checkWed.Checked
        WedEnd.Enabled = checkWed.Checked
    End Sub
    Private Sub checkThu_CheckedChanged(sender As Object, e As EventArgs) Handles checkThu.CheckedChanged
        ThuStart.Enabled = checkThu.Checked
        ThuEnd.Enabled = checkThu.Checked
    End Sub
    Private Sub checkFri_CheckedChanged(sender As Object, e As EventArgs) Handles checkFri.CheckedChanged
        FriStart.Enabled = checkFri.Checked
        FridEnd.Enabled = checkFri.Checked
    End Sub
    Private Sub checkSat_CheckedChanged(sender As Object, e As EventArgs) Handles checkSat.CheckedChanged
        SatStart.Enabled = checkSat.Checked
        SatEnd.Enabled = checkSat.Checked
    End Sub
    Private Sub checkSun_CheckedChanged(sender As Object, e As EventArgs) Handles checkSun.CheckedChanged
        SunStart.Enabled = checkSun.Checked
        SunEnd.Enabled = checkSun.Checked
    End Sub

End Class
