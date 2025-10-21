Public Class UcMainMenu
    Inherits UserControl
    Public Shared patientInfo As String = ""

    Public Shared MainContentPanel As Panel
    ' Constructor receives parent panel
    Public Sub New(parent As Panel)
        InitializeComponent()
        MainContentPanel = parent
    End Sub
    Private Sub UcMainMenu_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        WelcomeText.Text = "Welcome, " + DataStore.currentUser(0) + " - " + DataStore.currentUser(3)
        ' Get current username (lowercase for consistency)
        Dim currentUser As String = DataStore.currentUser(3).ToLower()


        If currentUser = "admin" Then
            NewDoctorBtn.Visible = True
            NewStaffBtn.Visible = True
        ElseIf currentUser = "doctor" Then
            AddPatientBtn.Visible = False
            NewDoctorBtn.Visible = False
            NewStaffBtn.Visible = False
        ElseIf currentUser = "staff" Then
            NewDoctorBtn.Visible = False
            NewStaffBtn.Visible = False
        End If
        'StartupAnimation() ' Disabled for now, no animation or sound
    End Sub

    'Private Sub StartupAnimation()
    '    Startup_Fade.Show(Me)
    '    Startup_Fade.Location = Me.Location
    '    Startup_Fade.Location = New Point(Startup_Fade.Location.X + 8, Startup_Fade.Location.Y)
    '    FadeTimer.Interval = 25
    '
    '    Dim path As String = My.Application.Info.DirectoryPath
    '    path = path.Replace("docucare-appointment-management-system\docucare-appointment-management-system\bin\Debug", "Assets\open.wav")
    '    My.Computer.Audio.Play(path)
    '
    '    FadeTimer.Start()
    'End Sub

    'Private Sub FadeTimer_Tick(sender As System.Object, e As System.EventArgs) Handles FadeTimer.Tick
    '    If Startup_Fade.Opacity = 0 Then
    '        Startup_Fade.Hide()
    '        Startup_Fade.Close()
    '        FadeTimer.Stop()
    '    Else
    '        Startup_Fade.Opacity -= 0.01
    '    End If
    'End Sub

    Private Sub MM_NewBtn_Click(sender As Object, e As EventArgs) Handles AddPatientBtn.Click
        MainContentPanel.Controls.Clear()
        Dim patientRecords As New UcPatientRecords(MainContentPanel)
        patientRecords.Dock = DockStyle.Fill
        MainContentPanel.Controls.Add(patientRecords)
        AddPatient.Show()
    End Sub

    Private Sub MM_Panel_Paint(sender As Object, e As PaintEventArgs) Handles MM_Panel.Paint
        ' Optional custom drawing
    End Sub

    Private Sub MM_QuitBtn_Click(sender As Object, e As EventArgs) Handles MM_QuitBtn.Click
        ' Confirm before exiting
        Dim result As DialogResult = MessageBox.Show(
            "Are you sure you want to quit?",
            "Exit Application",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question
        )

        If result = DialogResult.Yes Then
            Application.Exit()
        End If
    End Sub

    Private Sub PatientRecordsBtn_Click(sender As Object, e As EventArgs) Handles PatientRecordsBtn.Click
        MainContentPanel.Controls.Clear()
        Dim patientRecords As New UcPatientRecords(MainContentPanel)
        patientRecords.Dock = DockStyle.Fill
        MainContentPanel.Controls.Add(patientRecords)
    End Sub

    Private Sub AppointmentBtn_Click(sender As Object, e As EventArgs) Handles AppointmentBtn.Click
        MainContentPanel.Controls.Clear()
        Dim appointment As New UcAppointment(MainContentPanel)
        appointment.Dock = DockStyle.Fill
        MainContentPanel.Controls.Add(appointment)
    End Sub

    Private Sub HistoryBtn_Click(sender As Object, e As EventArgs) Handles HistoryBtn.Click
        MainContentPanel.Controls.Clear()
        Dim history As New UcHistory(MainContentPanel)
        history.Dock = DockStyle.Fill
        MainContentPanel.Controls.Add(history)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim result As DialogResult = MessageBox.Show(
        "Are you sure you want to logout?",
        "Exit Application",
        MessageBoxButtons.YesNo,
        MessageBoxIcon.Question
    )
        If result = DialogResult.Yes Then
            'go back to auth form
            MainContentPanel.Controls.Clear()
            Dim userAuth As New UcAuthForm(MainContentPanel)
            userAuth.Dock = DockStyle.Fill
            MainContentPanel.Controls.Add(userAuth)
        End If

    End Sub

    Private Sub NewDoctor_Click(sender As Object, e As EventArgs) Handles NewDoctorBtn.Click
        'test
        'go to create doctor form
        Dim form As New CreateDoctor()
        form.ShowDialog() ' blocks parent until closed
    End Sub

    Private Sub NewStaff_Click(sender As Object, e As EventArgs) Handles NewStaffBtn.Click
        Dim form As New CreateStaff()
        form.ShowDialog() ' blocks parent until closed
    End Sub

    Private Sub WelcomeText_Click(sender As Object, e As EventArgs) Handles WelcomeText.Click

    End Sub
End Class
