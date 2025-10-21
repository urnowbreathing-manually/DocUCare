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

    Private Sub patientLayout_Paint(sender As Object, e As PaintEventArgs) Handles patientLayout.Paint

    End Sub

    Public Sub AddPatientCard(firstName As String, lastName As String)
        ' === Create main card ===
        Dim card As New Panel()
        card.Width = 220
        card.Height = 100
        card.BackColor = Color.AliceBlue
        card.BorderStyle = BorderStyle.FixedSingle
        card.Margin = New Padding(10)

        ' === Label for patient name ===
        Dim lbl As New Label()
        lbl.Text = $"{firstName} {lastName}"
        lbl.Font = New Font("Segoe UI", 10, FontStyle.Bold)
        lbl.Dock = DockStyle.Top
        lbl.Height = 40
        lbl.TextAlign = ContentAlignment.MiddleCenter

        ' === View button ===
        Dim btnView As New Button()
        btnView.Text = "View"
        btnView.Dock = DockStyle.Bottom
        btnView.Height = 30
        btnView.Tag = $"{firstName}|{lastName}"  ' store data to identify patient later

        ' === Add event handler for view button ===
        AddHandler btnView.Click, AddressOf ViewPatient_Click

        ' === Add controls to card ===
        card.Controls.Add(lbl)
        card.Controls.Add(btnView)

        ' === Add card to FlowLayoutPanel ===
        patientLayout.Controls.Add(card)
    End Sub
    Private Sub ViewPatient_Click(sender As Object, e As EventArgs)
        Dim btn As Button = CType(sender, Button)
        Dim parts() As String = btn.Tag.ToString().Split("|"c)

        ' Auto-fill missing parts to avoid index error
        ReDim Preserve parts(10)

        Dim firstName As String = parts(0)
        Dim lastName As String = parts(1)
        Dim age As String = parts(2)
        Dim height As String = parts(3)
        Dim weight As String = parts(4)
        Dim gender As String = parts(5)
        Dim contact As String = parts(6)
        Dim emergencyContact As String = parts(7)
        Dim bloodType As String = parts(8)
        Dim allergies As String = parts(9)
        Dim medicalConditions As String = parts(10)

        UcMainMenu.patientInfo = String.Join("|", parts)

        Dim infoForm As New PatientInfo()
        infoForm.ShowDialog()
    End Sub




    Private Sub addPatientBtn_Click(sender As Object, e As EventArgs) Handles addPatientBtn.Click
        ' Open AddPatient form (non-modal, optional)
        Dim addForm As New AddPatient()
        addForm.ShowDialog()
    End Sub

    Private Sub UcPatientRecords_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
