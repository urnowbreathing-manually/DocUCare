Public Class CreateStaff
    ' --- ADDED ---
    ' Create a single instance of the DBHandler
    Private db As New DBHandler()
    ' --- END ADDED ---

    Private Sub CreateStaff_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Optional: Any initialization code can go here
    End Sub

    ' --- MODIFIED Save (CreateStaffBtn) ---
    Private Sub CreateStaffBtn_Click(sender As Object, e As EventArgs) Handles CreateStaffBtn.Click
        ' Validate all textboxes are filled
        If String.IsNullOrWhiteSpace(FirstName.Text) OrElse
           String.IsNullOrWhiteSpace(LastName.Text) OrElse
           String.IsNullOrWhiteSpace(Password.Text) OrElse
           String.IsNullOrWhiteSpace(ConfirmPassword.Text) OrElse
           String.IsNullOrWhiteSpace(VerificationID.Text) Then

            MessageBox.Show("Please fill in all required fields before continuing.",
                            "Missing Information",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning)
            Exit Sub
        End If

        ' Check password match
        If Password.Text <> ConfirmPassword.Text Then
            MessageBox.Show("Passwords do not match. Please re-enter.",
                            "Password Error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error)
            Exit Sub
        End If

        ' --- REPLACED DUMMY SAVE WITH DATABASE LOGIC ---

        ' Get all form values
        Dim fullName As String = FirstName.Text & " " & LastName.Text
        Dim vID As String = VerificationID.Text
        Dim pass As String = Password.Text
        Dim role As String = "staff" ' Hardcode role for this form

        ' Call the DBHandler InsertStaff function
        If db.InsertStaff(fullName, vID, pass, role) Then
            MessageBox.Show("Staff account created successfully and saved to database.",
                            "Success",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information)
            Me.Close()
        Else
            MessageBox.Show("Failed to save staff account to database. The Verification ID might already exist.",
                            "Database Error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error)
        End If
        ' --- END REPLACEMENT ---
    End Sub

    Private Sub Cancel_Click(sender As Object, e As EventArgs) Handles Cancel.Click
        Dim result As DialogResult = MessageBox.Show(
            "Are you sure you want to cancel? Any unsaved information will be lost.",
            "Cancel Creation",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Warning
        )

        If result = DialogResult.Yes Then
            Me.Close()
        End If
    End Sub

    ' Optional: Empty text changed handlers (if you want to add validation later)
    Private Sub FirstName_TextChanged(sender As Object, e As EventArgs) Handles FirstName.TextChanged
    End Sub

    Private Sub LastName_TextChanged(sender As Object, e As EventArgs) Handles LastName.TextChanged
    End Sub

    Private Sub Password_TextChanged(sender As Object, e As EventArgs) Handles Password.TextChanged
    End Sub

    Private Sub ConfirmPassword_TextChanged(sender As Object, e As EventArgs) Handles ConfirmPassword.TextChanged
    End Sub

    Private Sub VerificationID_TextChanged(sender As Object, e As EventArgs) Handles VerificationID.TextChanged
    End Sub
End Class