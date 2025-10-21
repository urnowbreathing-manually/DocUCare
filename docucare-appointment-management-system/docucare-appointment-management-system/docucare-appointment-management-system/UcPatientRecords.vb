Public Class UcPatientRecords
    Private MainContentPanel As Panel
    ' Constructor receives parent panel
    Public Sub New(parent As Panel)
        InitializeComponent()
        MainContentPanel = parent
    End Sub

    Private Sub NavbarMenu_Click(sender As Object, e As EventArgs) Handles NavbarMenu.Click
        MainContentPanel.Controls.Clear()
        Dim addMainMenu As New UcMainMenu(MainContentPanel)
        addMainMenu.Dock = DockStyle.Fill
        MainContentPanel.Controls.Add(addMainMenu)
    End Sub

    Private Sub PatientInfoPanel_Paint(sender As Object, e As PaintEventArgs) Handles PatientInfoPanel.Paint

    End Sub
End Class
