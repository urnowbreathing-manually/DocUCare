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

    Public Sub AddPatientCard(firstName As String, lastName As String,
                              age As String, height As String, weight As String,
                              gender As String, contact As String, emergencyContact As String,
                              bloodType As String, allergies As String, medicalConditions As String)

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

        ' Store all info in Tag (so PatientInfo can read it)
        btnView.Tag = String.Join("|", New String() {
            firstName, lastName, age, height, weight, gender,
            contact, emergencyContact, bloodType, allergies, medicalConditions
        })

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

        If parts.Length < 11 Then
            MessageBox.Show("Incomplete patient data. Please re-add the patient.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        UcMainMenu.patientInfo = String.Join("|", parts)
        Dim infoForm As New PatientInfo()
        infoForm.ShowDialog()
    End Sub

    Private Sub addPatientBtn_Click(sender As Object, e As EventArgs) Handles addPatientBtn.Click
        Dim addForm As New AddPatient()
        addForm.ShowDialog()
    End Sub
End Class
