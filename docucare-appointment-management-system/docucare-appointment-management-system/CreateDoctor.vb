Imports System.Threading

Public Class CreateDoctor
    ' --- ADDED ---
    ' Create a single instance of the DBHandler
    Private db As New DBHandler()
    ' --- END ADDED ---

    Private Sub CreateDoctor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Apply time format + disable all pickers by default
        DisableAllDateTimePickers(Me)
    End Sub

    ' Recursive function to apply settings even if controls are inside panels or table layouts
    ' --- MODIFIED ---
    Private Sub DisableAllDateTimePickers(parent As Control)
        For Each ctrl As Control In parent.Controls
            If TypeOf ctrl Is DateTimePicker Then
                Dim dtp As DateTimePicker = CType(ctrl, DateTimePicker)
                dtp.Format = DateTimePickerFormat.Custom
                ' --- CHANGED to 24-hour format ---
                dtp.CustomFormat = "HH:mm" ' 24-hour format
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
        ' --- ADDED ---
        ' This assumes you added a TextBox named VerificationID
        If String.IsNullOrWhiteSpace(VerificationID.Text) Then missingFields.Add("Verification ID")
        ' --- END ADDED ---
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

        ' --- MODIFIED ---
        ' Build schedule summary in the new format
        Dim scheduleSummary As String = GetScheduleSummary()
        ' --- END MODIFICATION ---

        ' --- REPLACED DUMMY SAVE WITH DATABASE LOGIC ---

        ' Get all form values
        Dim fullName As String = FirstName.Text & " " & LastName.Text
        ' This next line requires you to add the TextBox named 'VerificationID'
        Dim vID As String = VerificationID.Text
        Dim pass As String = Password.Text
        Dim role As String = "doctor"
        Dim contact As String = 0

        ' **BUG WARNING:** Your DBHandler.InsertDoctor uses 'Integer' for ContactNo,
        ' but your form allows 11 digits, which will crash an Integer (max 10 digits).
        ' I am using TryParse to prevent a crash, but this field may not save correctly.
        ' You should change 'contactNo As Integer' to 'contactNo As String' or 'contactNo As Long'
        ' in your DBHandler.vb file to fix this.
        If Not Integer.TryParse(ContactNum.Text, contact) Then
            MessageBox.Show("Warning: Contact Number is too long to save as an Integer. Storing 0." & vbCrLf &
                            "Please update DBHandler's InsertDoctor method to use 'Long' or 'String' for ContactNo.",
                            "Data Type Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If

        ' Call the DBHandler InsertDoctor function
        If db.InsertDoctor(fullName, vID, pass, role, contact, scheduleSummary) Then
            MessageBox.Show("Doctor Account Saved to Database", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            ClearAllFields()
            Me.Close()
        Else
            MessageBox.Show("Failed to save doctor to database. The Verification ID might already exist.", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
        ' --- END REPLACEMENT ---

    End Sub

    ' ----- Utility: Build Schedule Summary -----
    ' --- MODIFIED ---
    Private Function GetScheduleSummary() As String
        Dim result As New List(Of String)
        Dim format As String = "HH:mm"

        ' Use .Value.ToString(format) to get 24-hour "HH:mm" format
        If checkMonday.Checked Then result.Add($"MON-{MondayStart.Value.ToString(format)}-{MondayEnd.Value.ToString(format)}")
        If checkTue.Checked Then result.Add($"TUE-{TueStart.Value.ToString(format)}-{TueEnd.Value.ToString(format)}")
        If checkWed.Checked Then result.Add($"WED-{WedStart.Value.ToString(format)}-{WedEnd.Value.ToString(format)}")
        If checkThu.Checked Then result.Add($"THU-{ThuStart.Value.ToString(format)}-{ThuEnd.Value.ToString(format)}")
        If checkFri.Checked Then result.Add($"FRI-{FriStart.Value.ToString(format)}-{FridEnd.Value.ToString(format)}")
        If checkSat.Checked Then result.Add($"SAT-{SatStart.Value.ToString(format)}-{SatEnd.Value.ToString(format)}")
        If checkSun.Checked Then result.Add($"SUN-{SunStart.Value.ToString(format)}-{SunEnd.Value.ToString(format)}")

        If result.Count = 0 Then
            Return "No schedule set."
        Else
            ' Join with a pipe "|" instead of a new line
            Return String.Join("|", result)
        End If
    End Function
    ' --- END MODIFICATION ---

    ' ----- Utility: Clear all fields after pseudo-save -----
    Private Sub ClearAllFields()
        FirstName.Clear()
        LastName.Clear()
        ' --- ADDED ---
        ' Assumes you added a TextBox named VerificationID
        If Me.Controls.ContainsKey("VerificationID") Then
            Me.Controls("VerificationID").Text = ""
        End If
        ' --- END ADDED ---
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