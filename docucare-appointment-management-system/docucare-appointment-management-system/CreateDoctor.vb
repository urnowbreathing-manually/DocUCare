Imports System.Threading

Public Class CreateDoctor

    Private Sub CreateDoctor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Apply time format + disable all pickers by default
        DisableAllDateTimePickers(Me)
    End Sub

    ' Recursive function to apply settings even if controls are inside panels or table layouts
    Private Sub DisableAllDateTimePickers(parent As Control)
        For Each ctrl As Control In parent.Controls
            If TypeOf ctrl Is DateTimePicker Then
                Dim dtp As DateTimePicker = CType(ctrl, DateTimePicker)
                dtp.Format = DateTimePickerFormat.Custom
                dtp.CustomFormat = "hh:mm tt" ' 12-hour with AM/PM
                dtp.ShowUpDown = True         ' clock-style time only
                dtp.Enabled = False           ' disable by default
            End If

            ' Check nested containers (Panel, GroupBox, TableLayoutPanel, etc.)
            If ctrl.HasChildren Then
                DisableAllDateTimePickers(ctrl)
            End If
        Next
    End Sub

    ' ----- Checkbox Event Handlers -----
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

    ' ----- Cancel Button -----
    Private Sub Cancel_Click(sender As Object, e As EventArgs) Handles Cancel.Click
        Dim result As DialogResult = MessageBox.Show(
            "Are you sure you want to cancel? Any unsaved information will be lost.",
            "Exit Application",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Warning
        )

        If result = DialogResult.Yes Then
            Me.Close()
        End If
    End Sub

    ' ----- Pseudo Save (Login Button) -----
    Private Sub LoginBtn_Click(sender As Object, e As EventArgs) Handles CreateDoctorBtn.Click
        ' Validate all required textboxes
        Dim missingFields As New List(Of String)

        If String.IsNullOrWhiteSpace(FirstName.Text) Then missingFields.Add("First Name")
        If String.IsNullOrWhiteSpace(LastName.Text) Then missingFields.Add("Last Name")
        If String.IsNullOrWhiteSpace(ContactNum.Text) Then missingFields.Add("Contact Number")
        If String.IsNullOrWhiteSpace(Password.Text) Then missingFields.Add("Password")
        If String.IsNullOrWhiteSpace(ConfirmPassword.Text) Then missingFields.Add("Confirm Password")

        ' Check if passwords match
        If Password.Text <> ConfirmPassword.Text Then
            MessageBox.Show("Passwords do not match.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        ' If missing fields exist
        If missingFields.Count > 0 Then
            Dim message As String = "Please fill in the following required fields:" & vbCrLf &
                                    String.Join(vbCrLf, missingFields)
            MessageBox.Show(message, "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        ' Build schedule summary
        Dim scheduleSummary As String = GetScheduleSummary()

        ' Pseudo Save Message
        Dim info As String =
            $"Doctor Information:" & vbCrLf &
            $"First Name: {FirstName.Text}" & vbCrLf &
            $"Last Name: {LastName.Text}" & vbCrLf &
            $"Contact No: {ContactNum.Text}" & vbCrLf &
            $"Password: {Password.Text}" & vbCrLf & vbCrLf &
            $"Schedule:" & vbCrLf & scheduleSummary

        MessageBox.Show(info, "Doctor Account Saved", MessageBoxButtons.OK, MessageBoxIcon.Information)

        ' Optional: clear all inputs
        ClearAllFields()
        Me.Close()
    End Sub

    ' ----- Utility: Build Schedule Summary -----
    Private Function GetScheduleSummary() As String
        Dim result As New List(Of String)

        If checkMonday.Checked Then result.Add($"Monday: {MondayStart.Text} - {MondayEnd.Text}")
        If checkTue.Checked Then result.Add($"Tuesday: {TueStart.Text} - {TueEnd.Text}")
        If checkWed.Checked Then result.Add($"Wednesday: {WedStart.Text} - {WedEnd.Text}")
        If checkThu.Checked Then result.Add($"Thursday: {ThuStart.Text} - {ThuEnd.Text}")
        If checkFri.Checked Then result.Add($"Friday: {FriStart.Text} - {FridEnd.Text}")
        If checkSat.Checked Then result.Add($"Saturday: {SatStart.Text} - {SatEnd.Text}")
        If checkSun.Checked Then result.Add($"Sunday: {SunStart.Text} - {SunEnd.Text}")

        If result.Count = 0 Then
            Return "No schedule set."
        Else
            Return String.Join(vbCrLf, result)
        End If
    End Function

    ' ----- Utility: Clear all fields after pseudo-save -----
    Private Sub ClearAllFields()
        FirstName.Clear()
        LastName.Clear()
        ContactNum.Clear()
        Password.Clear()
        ConfirmPassword.Clear()

        ' Uncheck all schedule boxes
        checkMonday.Checked = False
        checkTue.Checked = False
        checkWed.Checked = False
        checkThu.Checked = False
        checkFri.Checked = False
        checkSat.Checked = False
        checkSun.Checked = False
    End Sub

    Private Sub ContactNum_TextChanged(sender As Object, e As EventArgs) Handles ContactNum.TextChanged
        Dim tb As TextBox = DirectCast(sender, TextBox)

        ' Keep only digits
        tb.Text = System.Text.RegularExpressions.Regex.Replace(tb.Text, "[^\d]", "")

        ' Limit to 11 digits (PH mobile format)
        If tb.Text.Length > 11 Then
            tb.Text = tb.Text.Substring(0, 11)
        End If

        ' Keep cursor at the end
        tb.SelectionStart = tb.Text.Length
    End Sub
End Class
