Imports System.Data
Imports System.Globalization

Public Class UcAppointment
    Inherits UserControl

    Private MainContentPanel As Panel
    Private db As New DBHandler() ' Database handler instance

    ' --- MODIFIED: Added properties for the IDs ---
    Private Class AppointmentData
        Public Property Patient As String
        Public Property Doctor As String
        Public Property [Date] As String
        Public Property Time As String
        Public Property Notes As String
        ' --- NEW ---
        Public Property AppointmentID As Integer
        Public Property PatientID As String
        Public Property DoctorVID As String
    End Class
    ' --- END MODIFICATION ---

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

        Select Case DataStore.currentUser(3)
            Case "Admin"
                addAppointmentBtn.Show()
            Case "Doctor"
                addAppointmentBtn.Hide()
            Case "Staff"
                addAppointmentBtn.Show()
        End Select

    End Sub

    ' --- MODIFIED: This function is now fixed ---
    Private Sub LoadAppointmentsFromDB()
        Try
            AppointmentList.Controls.Clear() ' Clear existing

            ' This assumes you have a function named "GetAllAppointments" in your DBHandler
            Dim dt As DataTable = db.GetAllAppointments()

            If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                For Each row As DataRow In dt.Rows


                    ' --- FIXED: Reading all required data including IDs ---
                    Dim patientName As String = row.Field(Of String)("patient_name")
                    Dim doctorName As String = row.Field(Of String)("doctor_name")
                    Dim appDate As String = row.Field(Of String)("date") ' Read as String
                    Dim appTime24 As String = row.Field(Of String)("time") ' Read the 24-hour string
                    Dim appNotes As String = row.Field(Of String)("notes")

                    ' --- NEW: Read the IDs from the database row ---
                    Dim apptID As Integer = row.Field(Of Integer)("appointment_id")
                    Dim patID As String = row.Field(Of String)("patient_id")
                    Dim docVID As String = row.Field(Of String)("Verified_ID")
                    ' --- END NEW ---

                    ' --- Convert 24-hour string to 12-hour string for display ---
                    Dim appTime12 As String
                    Try
                        ' Parse the "HH:mm" string and format it as "hh:mm tt" (e.g., "02:30 PM")
                        appTime12 = DateTime.ParseExact(appTime24, "HH:mm", CultureInfo.InvariantCulture).ToString("hh:mm tt")
                    Catch ex As Exception
                        appTime12 = appTime24 ' Fallback to raw data if parsing fails
                    End Try
                    ' --- END ---

                    ' Call your existing function with the correct (12-hour) data AND the new IDs
                    AddAppointmentToList(patientName, doctorName, appDate, appTime12, appNotes, apptID, patID, docVID)
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
            ' This will now show the specific error
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
            ' --- MODIFIED: Pass the new IDs from the form ---
            AddAppointmentToList(
                form.SelectedPatient,
                form.SelectedDoctor,
                form.SelectedDate,
                form.SelectedTime,
                form.SelectedNotes,
                form.NewAppointmentID,  ' Pass the new Appointment ID
                form.SelectedPatientID, ' Pass the Patient ID
                form.SelectedDoctorVID  ' Pass the Doctor VID
            )
            ' --- END MODIFICATION ---

            ' We reload from DB in case AddAppointment saves it
            ' If AddAppointment doesn't save to DB, this is still safe.
            LoadAppointmentsFromDB()
        End If
    End Sub

    ' --- MODIFIED: Updated signature to accept new IDs ---
    Private Sub AddAppointmentToList(patient As String, doctor As String, [date] As String, time As String, notes As String, apptID As Integer, patID As String, docVID As String)
        Dim Appointment_Instance As New Appointment_Instance()

        ' Role specific controls
        If currentUser(3) = "Admin" Then
            Appointment_Instance.Btn_Consult.Hide()
        ElseIf currentUser(3) = "Doctor" Then
            Appointment_Instance.Btn_Payment.Hide()
            Appointment_Instance.Btn_Resched.Hide()
            Appointment_Instance.Btn_Cancel.Hide()
        ElseIf currentUser(3) = "Staff" Then
            Appointment_Instance.Btn_Consult.Hide()
        End If

        ' Patient info placeholders
        Appointment_Instance.Patient_Name_Placeholder.Text = patient
        Appointment_Instance.Doctor_Name_Placeholder.Text = doctor
        Appointment_Instance.Date_Placeholder.Text = [date]
        Appointment_Instance.Time_Placeholder.Text = time

        ' --- MODIFIED: Create AppointmentData object and assign all data to Tag ---
        Dim info As New AppointmentData With {
            .Patient = patient,
            .Doctor = doctor,
            .Date = [date],
            .Time = time,
            .Notes = notes,
            .AppointmentID = apptID, ' Store the ID
            .PatientID = patID,     ' Store the ID
            .DoctorVID = docVID     ' Store the ID
        }

        Appointment_Instance.Btn_Consult.Tag = info
        Appointment_Instance.Btn_Payment.Tag = info
        Appointment_Instance.Btn_Resched.Tag = info
        Appointment_Instance.Btn_Cancel.Tag = info

        ' Check if a "No appointments" label is present and remove it
        If AppointmentList.Controls.Count = 1 AndAlso TypeOf AppointmentList.Controls(0) Is Label Then
            AppointmentList.Controls.Clear()
        End If

        AppointmentList.Controls.Add(Appointment_Instance)

    End Sub

    ' --- MODIFIED: Handle Consult button click ---
    Public Shared Sub ConsultationForm_Show(sender As Object, e As EventArgs)
        Dim btn As Button = DirectCast(sender, Button)
        Dim data As AppointmentData = DirectCast(btn.Tag, AppointmentData) ' Get all data

        Dim appointmentDate As Date
        Try
            ' Try parsing the date assuming "MMddyyyy" format
            appointmentDate = Date.ParseExact(data.Date, "MMddyyyy", CultureInfo.InvariantCulture)
        Catch ex As Exception
            ' Fallback to standard parsing if "MMddyyyy" fails
            appointmentDate = Date.Parse(data.Date)
        End Try

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

        ' --- MODIFIED: Create Consultation Form and pass ALL data, including IDs ---
        Dim form As New ConsultationForm()
        ' Pass display info
        form.PatientName = data.Patient
        form.DoctorName = data.Doctor
        form.AppointmentDate = data.Date
        form.AppointmentTime = data.Time
        form.Notes = data.Notes

        ' --- NEW: Pass the IDs ---
        form.AppointmentID = data.AppointmentID
        form.PatientID = data.PatientID
        form.DoctorVID = data.DoctorVID
        ' --- END NEW ---

        form.ShowDialog()
        ' --- END MODIFICATION ---
    End Sub

    Public Shared Sub ConsultationFee_Show()
        Dim form As New ConsulationFee()
        form.ShowDialog()
    End Sub

    Public Shared Sub CancelAppointment(sender As Object, e As EventArgs)
        Dim btn As Button = DirectCast(sender, Button)
        Dim data As AppointmentData = DirectCast(btn.Tag, AppointmentData) ' Get all data

        Dim result As DialogResult = MessageBox.Show("Confirm cancel appointment of " & data.Patient & "?", "Cancel Appointment", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)

        If result = DialogResult.Yes Then
            MessageBox.Show("Appointment successfully cancelled!", "Cancel Appointment", MessageBoxButtons.OK, MessageBoxIcon.Information)

            'db.DeleteAppointment(data.AppointmentID, data.Patient)
        End If

    End Sub

End Class