Imports System.Threading

Public Class CreateDoctor
    ' Create a single instance of the DBHandler
    Private db As New DBHandler()

    Private Sub CreateDoctor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Apply time format + disable all pickers by default
        DisableAllDateTimePickers(Me)
    End Sub

    ' --- MODIFIED ---
    ' Recursive function to apply settings even if controls are inside panels or table layouts
    Private Sub DisableAllDateTimePickers(parent As Control)
        For Each ctrl As Control In parent.Controls
            If TypeOf ctrl Is DateTimePicker Then
                Dim dtp As DateTimePicker = CType(ctrl, DateTimePicker)
                dtp.Format = DateTimePickerFormat.Custom

                ' --- CHANGED to 12-hour format for USER DISPLAY ---
                dtp.CustomFormat = "hh:mm tt" ' 12-hour AM/PM format
                dtp.ShowUpDown = True         ' clock-style time only
                dtp.Enabled = False           ' disable by default
            End If

            ' Check nested containers (Panel, GroupBox, TableLayoutPanel, etc.)
            If ctrl.HasChildren Then
                DisableAllDateTimePickers(ctrl)
            End If
        Next
    End Sub
    ' --- END MODIFICATION ---

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

    ' ----- MODIFIED Save (CreateDoctorBtn) -----
    Private Sub LoginBtn_Click(sender As Object, e As EventArgs) Handles CreateDoctorBtn.Click
        ' Validate all required textboxes
        Dim missingFields As New List(Of String)

        If String.IsNullOrWhiteSpace(FirstName.Text) Then missingFields.Add("First Name")
        If String.IsNullOrWhiteSpace(LastName.Text) Then missingFields.Add("Last Name")
        If String.IsNullOrWhiteSpace(VerificationID.Text) Then missingFields.Add("Verification ID")
        If String.IsNullOrWhiteSpace(ContactNum.Text) Then missingFields.Add("Contact Number")
        If String.IsNullOrWhiteSpace(Password.Text) Then missingFields.Add("Password")
        If String.IsNullOrWhiteSpace(ConfirmPassword.Text) Then missingFields.Add("Confirm Password")

        ' Check if passwords match
        If Password.Text <> ConfirmPassword.Text Then
            MessageBox.Show("Passwords do not match.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        If checkMonday.Checked = False And checkTue.Checked = False And checkWed.Checked = False And checkThu.Checked = False And checkFri.Checked = False And checkSat.Checked = False And checkSun.Checked = False Then
            missingFields.Add("No Schedule Selected")
        End If

        ' If missing fields exist
        If missingFields.Count > 0 Then
            Dim message As String = "Please fill in the following required fields:" & vbCrLf &
                                    String.Join(vbCrLf, missingFields)
            MessageBox.Show(message, "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        ' Build schedule summary in 24-HOUR format for the database
        Dim scheduleSummary As String = GetScheduleSummary()

        ' Get all form values to match the personneltable schema
        Dim fullName As String = FirstName.Text & " " & LastName.Text ' For Personnel_Name
        Dim vID As String = VerificationID.Text                     ' For Verified_ID
        Dim pass As String = Password.Text                          ' For Password
        Dim role As String = "doctor"                               ' For Role
        Dim contact As String = ContactNum.Text                     ' For ContactNo (VARCHAR(15))

        ' Call the DBHandler InsertDoctor function
        ' (Assumes InsertDoctor signature is: (name, vID, pass, role, contact, schedule))
        If db.InsertDoctor(fullName, vID, pass, role, contact, scheduleSummary) Then
            MessageBox.Show("Doctor Account Saved to Database", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            ClearAllFields()
            Me.Close()
        Else
            MessageBox.Show("Failed to save doctor to database. The Verification ID might already exist.", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    ' ----- Utility: Build Schedule Summary -----
    ' --- MODIFIED ---
    Private Function GetScheduleSummary() As String
        Dim result As New List(Of String)

        ' --- CHANGED to 24-hour format for DATABASE ---
        Dim dbFormat As String = "HH:mm" ' 24-hour format

        ' Use .Value.ToString(dbFormat) to get 24-hour "HH:mm" format
        If checkMonday.Checked Then result.Add($"MON-{MondayStart.Value.ToString(dbFormat)}-{MondayEnd.Value.ToString(dbFormat)}")
        If checkTue.Checked Then result.Add($"TUE-{TueStart.Value.ToString(dbFormat)}-{TueEnd.Value.ToString(dbFormat)}")
        If checkWed.Checked Then result.Add($"WED-{WedStart.Value.ToString(dbFormat)}-{WedEnd.Value.ToString(dbFormat)}")
        If checkThu.Checked Then result.Add($"THU-{ThuStart.Value.ToString(dbFormat)}-{ThuEnd.Value.ToString(dbFormat)}")
        If checkFri.Checked Then result.Add($"FRI-{FriStart.Value.ToString(dbFormat)}-{FridEnd.Value.ToString(dbFormat)}")
        If checkSat.Checked Then result.Add($"SAT-{SatStart.Value.ToString(dbFormat)}-{SatEnd.Value.ToString(dbFormat)}")
        If checkSun.Checked Then result.Add($"SUN-{SunStart.Value.ToString(dbFormat)}-{SunEnd.Value.ToString(dbFormat)}")

        If result.Count = 0 Then
            Return "No schedule set."
        Else
            ' Join with a pipe "|"
            Return String.Join("|", result)
        End If
    End Function
    ' --- END MODIFICATION ---

    ' ----- Utility: Clear all fields after save -----
    Private Sub ClearAllFields()
        FirstName.Clear()
        LastName.Clear()
        VerificationID.Clear()
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

    ' ----- Utility: Force Contact Number to be digits only -----
    Private Sub KeepNumbersOnly(tb As TextBox, maxLength As Integer)
        Dim caret As Integer = tb.SelectionStart
        tb.Text = System.Text.RegularExpressions.Regex.Replace(tb.Text, "[^\d]", "")
        If tb.Text.Length > maxLength Then
            tb.Text = tb.Text.Substring(0, maxLength)
        End If
        tb.SelectionStart = Math.Min(caret, tb.Text.Length)
    End Sub
    Private Sub ContactNum_TextChanged(sender As Object, e As EventArgs) Handles ContactNum.TextChanged
        KeepNumbersOnly(DirectCast(sender, TextBox), 11)
    End Sub

    Private Sub CleanTextOnly(tb As TextBox)
        tb.Text = System.Text.RegularExpressions.Regex.Replace(tb.Text, "[^a-zA-Z\s]", "")
        tb.SelectionStart = tb.Text.Length
    End Sub

    Private Sub FirstName_TextChanged(sender As Object, e As EventArgs) Handles FirstName.TextChanged
        CleanTextOnly(DirectCast(sender, TextBox))
    End Sub

    Private Sub LastName_TextChanged(sender As Object, e As EventArgs) Handles LastName.TextChanged
        CleanTextOnly(DirectCast(sender, TextBox))
    End Sub

    Private Sub TableLayoutPanel1_Paint(sender As Object, e As PaintEventArgs) Handles TableLayoutPanel1.Paint

    End Sub

    Private Sub MondayStart_ValueChanged(sender As Object, e As EventArgs) Handles MondayStart.ValueChanged

    End Sub
End Class