Imports System.Net.Security

Public Class UcAuthForm
    Private MainContentPanel As Panel
    Private dbHandler As DBHandler
    Private passwordVisible As Boolean = False ' Track show/hide state

    Public Sub New(parent As Panel)
        InitializeComponent()
        MainContentPanel = parent
        dbHandler = New DBHandler()

        ' Initialize password as hidden
        Password.PasswordChar = "●"
        PasswordToggleLabel.Text = "Show"
        PasswordToggleLabel.Visible = False ' Hidden by default
        PasswordToggleLabel.Cursor = Cursors.Hand
    End Sub

    Private Sub Btn_Debug_Click(sender As Object, e As EventArgs) Handles Btn_Debug.Click
        Dim result As DialogResult = MessageBox.Show("Login As?" & vbCrLf & "       Yes: Admin" & vbCrLf & "       No: Doctor" & vbCrLf & " Cancel: Staff", "Quick Login", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information)
        Select Case result
            Case DialogResult.Yes
                UserName.Text = "Wion M. Quintela"
                Password.Text = "adminpass"
                VerifiedID.Text = "00001-AD"
                LoginBtn_Click(sender, e)
            Case DialogResult.No
                UserName.Text = "Andrei I. Zantua"
                Password.Text = "doctor4post"
                VerifiedID.Text = "00002-DR"
                LoginBtn_Click(sender, e)
            Case DialogResult.Cancel
                UserName.Text = "Kael Rivera"
                Password.Text = "staff789"
                VerifiedID.Text = "00001-ST"
                LoginBtn_Click(sender, e)
        End Select
    End Sub

    Private Sub LoginBtn_Click(sender As Object, e As EventArgs) Handles LoginBtn.Click
        ' Clear any previous user session
        CurrentUserSession.FullName = ""
        CurrentUserSession.Role = ""

        If String.IsNullOrWhiteSpace(UserName.Text) Then
            MessageBox.Show("Username is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            UserName.Focus()
            Exit Sub
        End If

        If String.IsNullOrWhiteSpace(Password.Text) Then
            MessageBox.Show("Password is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Password.Focus()
            Exit Sub
        End If

        If String.IsNullOrWhiteSpace(VerifiedID.Text) Then
            MessageBox.Show("Verified ID is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            VerifiedID.Focus()
            Exit Sub
        End If

        If dbHandler.AuthenticateUser(UserName.Text, Password.Text, VerifiedID.Text) Then

            ' ⭐ SUCCESS: Save user info to the global session
            CurrentUserSession.FullName = UserName.Text
            CurrentUserSession.Role = CurrentUserSession.GetRoleFromID(VerifiedID.Text)

            MessageBox.Show("Login successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            MainContentPanel.Controls.Clear()
            Dim addMainMenu As New UcMainMenu(MainContentPanel)
            addMainMenu.Dock = DockStyle.Fill
            MainContentPanel.Controls.Add(addMainMenu)
        Else
            MessageBox.Show("Incorrect Name/Password/Verified ID", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            UserName.Focus()
        End If
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles UserName.TextChanged
        Dim tb As TextBox = DirectCast(sender, TextBox)
        tb.SelectionStart = tb.Text.Length
    End Sub

    ' ✅ Toggle password visibility when label is clicked
    Private Sub PasswordToggleLabel_Click(sender As Object, e As EventArgs) Handles PasswordToggleLabel.Click
        passwordVisible = Not passwordVisible

        If passwordVisible Then
            Password.PasswordChar = ControlChars.NullChar
            PasswordToggleLabel.Text = "HIDE"
        Else
            Password.PasswordChar = "●"
            PasswordToggleLabel.Text = "SHOW"
        End If
    End Sub

    ' ✅ Automatically hide password again when input is deleted
    Private Sub Password_TextChanged(sender As Object, e As EventArgs) Handles Password.TextChanged
        PasswordToggleLabel.Visible = Password.TextLength > 0

        ' If password field becomes empty, reset visibility
        If Password.TextLength = 0 AndAlso passwordVisible Then
            passwordVisible = False
            Password.PasswordChar = "●"
            PasswordToggleLabel.Text = "SHOW"
        End If
    End Sub

    Protected Overrides Sub Finalize()
        If dbHandler IsNot Nothing Then
            dbHandler.Dispose()
        End If
        MyBase.Finalize()
    End Sub

    Private Sub UcAuthForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Password.PasswordChar = "●"
        PasswordToggleLabel.Text = "SHOW"
        PasswordToggleLabel.Visible = False
    End Sub

End Class