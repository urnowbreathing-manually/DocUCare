Imports System.Data

Public Class UcAppointment
    Inherits UserControl

    Private MainContentPanel As Panel
    Private db As New DBHandler() ' Database handler instance

    ' Class to hold appointment data
    Private Class AppointmentData
        Public Property Patient As String
        Public Property Doctor As String
        Public Property [Date] As String
        Public Property Time As String
        Public Property Notes As String
    End Class

    ' Constructor receives parent panel
    Public Sub New(parent As Panel)
        InitializeComponent()
        MainContentPanel = parent
    End Sub

    Private Sub UcAppointment_Load(sender As Object, e As EventArgs) Handles Me.Load
        ' Configure FlowLayoutPanel for appointments
        AppointmentList.AutoScroll = True
        AppointmentList.FlowDirection = FlowDirection.TopDown
        AppointmentList.WrapContents = False
        AppointmentList.BackColor = Color.WhiteSmoke
        AppointmentList.BorderStyle = BorderStyle.FixedSingle
        AppointmentList.Padding = New Padding(10)

        ' Load appointments from DB
        LoadAppointmentsFromDB()
    End Sub

    ' --- MODIFIED: This function is now fixed ---
    Private Sub LoadAppointmentsFromDB()
        Try
            AppointmentList.Controls.Clear() ' Clear existing
            ' This assumes you have a function named "GetAllAppointments" in your DBHandler
            Dim dt As DataTable = db.GetAllAppointments()

            If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                For Each row As DataRow In dt.Rows

                    ' --- FIXED: Using correct column names and data types from your database ---
                    Dim patientName As String = row.Field(Of String)("patient_name")
                    Dim doctorName As String = row.Field(Of String)("doctor_name")
                    Dim appDate As String = row.Field(Of String)("date") ' Read as String
                    Dim appTime As String = row.Field(Of String)("time")
                    Dim appNotes As String = row.Field(Of String)("notes")
                    ' --- END FIX ---

                    ' Call your existing function with the correct data
                    AddAppointmentToList(patientName, doctorName, appDate, appTime, appNotes)
                Next
            Else
                ' Optional: Display a message if no appointments
                Dim noAppsLabel As New Label()
                noAppsLabel.Text = "No appointments found."
                noAppsLabel.Font = New Font("Segoe UI", 12)
                noAppsLabel.AutoSize = True
                AppointmentList.Controls.Add(noAppsLabel)
            End If
        Catch ex As Exception
            ' This will now show the specific error (e.g., "Column 'patient' not found")
            MessageBox.Show("Failed to load appointments: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    ' --- END MODIFICATION ---

    Private Sub NavbarMenu_Click(sender As Object, e As EventArgs) Handles NavbarMenu.Click
        MainContentPanel.Controls.Clear()
        Dim addMainMenu As New UcMainMenu(MainContentPanel)
        addMainMenu.Dock = DockStyle.Fill
        MainContentPanel.Controls.Add(addMainMenu)
    End Sub

    Private Sub addAppointmentBtn_Click(sender As Object, e As EventArgs) Handles addAppointmentBtn.Click
        Dim form As New AddAppointment()

        If form.ShowDialog() = DialogResult.OK Then
            ' This part adds the card when you create one
            AddAppointmentToList(
                form.SelectedPatient,
                form.SelectedDoctor,
                form.SelectedDate,
                form.SelectedTime,
                form.SelectedNotes
            )
            ' We reload from DB in case AddAppointment saves it
            ' If AddAppointment doesn't save to DB, this is still safe.
            LoadAppointmentsFromDB()
        End If
    End Sub

    ' This function is correct as-is
    Private Sub AddAppointmentToList(patient As String, doctor As String, [date] As String, time As String, notes As String)
        Dim appointmentPanel As New Panel()
        appointmentPanel.Width = AppointmentList.Width - 40
        appointmentPanel.Height = 120
        appointmentPanel.Margin = New Padding(10)
        appointmentPanel.Padding = New Padding(15)
        appointmentPanel.BackColor = Color.White
        appointmentPanel.BorderStyle = BorderStyle.FixedSingle

        ' Layout container for info + button
        Dim layout As New TableLayoutPanel()
        layout.Dock = DockStyle.Fill
        layout.ColumnCount = 2
        layout.RowCount = 1
        layout.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 75))
        layout.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 25))
        layout.RowStyles.Add(New RowStyle(SizeType.Percent, 100))
        layout.Padding = New Padding(5)

        ' Inner table for text details
        Dim tbl As New TableLayoutPanel()
        tbl.Dock = DockStyle.Fill
        tbl.ColumnCount = 2
        tbl.RowCount = 5
        tbl.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 35))
        tbl.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 65))
        For i = 1 To 5
            tbl.RowStyles.Add(New RowStyle(SizeType.Absolute, 20))
        Next

        tbl.Controls.Add(New Label() With {.Text = "Patient:", .Font = New Font("Segoe UI", 9, FontStyle.Bold), .AutoSize = True}, 0, 0)
        tbl.Controls.Add(New Label() With {.Text = patient, .AutoSize = True}, 1, 0)

        tbl.Controls.Add(New Label() With {.Text = "Doctor:", .Font = New Font("Segoe UI", 9, FontStyle.Bold), .AutoSize = True}, 0, 1)
        tbl.Controls.Add(New Label() With {.Text = doctor, .AutoSize = True}, 1, 1)

        tbl.Controls.Add(New Label() With {.Text = "Date:", .Font = New Font("Segoe UI", 9, FontStyle.Bold), .AutoSize = True}, 0, 2)
        tbl.Controls.Add(New Label() With {.Text = [date], .AutoSize = True}, 1, 2)

        tbl.Controls.Add(New Label() With {.Text = "Time:", .Font = New Font("Segoe UI", 9, FontStyle.Bold), .AutoSize = True}, 0, 3)
        tbl.Controls.Add(New Label() With {.Text = time, .AutoSize = True}, 1, 3)

        tbl.Controls.Add(New Label() With {.Text = "Notes:", .Font = New Font("Segoe UI", 9, FontStyle.Bold), .AutoSize = True}, 0, 4)
        tbl.Controls.Add(New Label() With {.Text = notes, .AutoSize = True}, 1, 4)

        ' Create AppointmentData object and assign to Tag
        Dim info As New AppointmentData With {
            .Patient = patient,
            .Doctor = doctor,
            .Date = [date],
            .Time = time,
            .Notes = notes
        }

        ' Green "Consult" button
        Dim btnConsult As New Button()
        btnConsult.Text = "Consult"
        btnConsult.BackColor = Color.Blue
        btnConsult.ForeColor = Color.White
        btnConsult.Font = New Font("Microsoft Sans Serif", 9.75, FontStyle.Bold)
        btnConsult.FlatStyle = FlatStyle.Standard
        btnConsult.FlatAppearance.BorderSize = 0
        btnConsult.Dock = DockStyle.Fill
        btnConsult.Margin = New Padding(10)
        btnConsult.Tag = info

        AddHandler btnConsult.Click, AddressOf ConsultButton_Click

        ' Add controls
        layout.Controls.Add(tbl, 0, 0)
        layout.Controls.Add(btnConsult, 1, 0)
        appointmentPanel.Controls.Add(layout)

        ' Check if a "No appointments" label is present and remove it
        If AppointmentList.Controls.Count = 1 AndAlso TypeOf AppointmentList.Controls(0) Is Label Then
            AppointmentList.Controls.Clear()
        End If

        AppointmentList.Controls.Add(appointmentPanel)
    End Sub

    ' Handle Consult button click
    ' This part remains the same.
    Private Sub ConsultButton_Click(sender As Object, e As EventArgs)
        Dim btn As Button = DirectCast(sender, Button)
        Dim data As AppointmentData = DirectCast(btn.Tag, AppointmentData)
        Dim appointmentDate As Date = Date.Parse(data.Date) ' This line might fail if the varchar(8) is not a standard date format
        Dim today As Date = Date.Now.Date

        If today < appointmentDate Then
            Dim result As DialogResult = MessageBox.Show(
                $"This appointment is scheduled for {appointmentDate.ToShortDateString()}. Do you want to consult early?",
                "Consult Early",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            )

            If result = DialogResult.No Then Return
        End If

        ' Create Consultation Form and pass appointment data
        Dim form As New ConsultationForm()
        form.PatientName = data.Patient
        form.DoctorName = data.Doctor
        form.AppointmentDate = data.Date
        form.AppointmentTime = data.Time
        form.Notes = data.Notes

        form.ShowDialog()
    End Sub

End Class