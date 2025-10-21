Public Class MainForm
    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.StartPosition = FormStartPosition.CenterScreen
    End Sub

    Private Sub MainContentPanel_Paint(sender As Object, e As PaintEventArgs) Handles MainContentPanel.Paint
        MainContentPanel.Dock = DockStyle.Fill
        Dim authForm As New UcAuthForm(MainContentPanel)
        MainContentPanel.Controls.Add(authForm)
    End Sub


End Class