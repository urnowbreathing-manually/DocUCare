Imports System.Net.Security

Public Class UcAuthForm
    Private MainContentPanel As Panel
    Private dbHandler As DBHandler

    ' Constructor receives parent panel
    Public Sub New(parent As Panel)
        InitializeComponent()
        MainContentPanel = parent
        dbHandler = New DBHandler()
    End Sub

    Private Sub LoginBtn_Click(sender As Object, e As EventArgs) Handles LoginBtn.Click
        DataStore.currentUser = {"", "", "", ""}

        ' Error handling
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

        ' Account Verification using DBHandler
        If dbHandler.AuthenticateUser(UserName.Text, Password.Text, VerifiedID.Text) Then
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
        ' Move cursor to the end
        tb.SelectionStart = tb.Text.Length
    End Sub

    ' Clean up resources when form is disposed
    Protected Overrides Sub Finalize()
        If dbHandler IsNot Nothing Then
            dbHandler.Dispose()
        End If
        MyBase.Finalize()
    End Sub
End Class