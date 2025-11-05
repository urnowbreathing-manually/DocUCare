Imports System.Data
Imports System.Globalization
Imports System.Linq

Public Class UcAppointment
    Inherits UserControl

    Private MainContentPanel As Panel
    Private db As New DBHandler()
    Private allAppointments As New List(Of AppointmentData)
    Private filteredAppointments As New List(Of AppointmentData)

    Private Class AppointmentData
        Public Property AppointmentID As Integer
        Public Property Patient As String
        Public Property Doctor As String
        Public Property [Date] As String
        Public Property Time As String
        Public Property Notes As String
        Public Property PatientID As String
        Public Property DoctorVID As String
        Public Property Status As String
    End Class

    Public Sub New(parent As Panel)
        InitializeComponent()
        MainContentPanel = parent
    End Sub

    Private Sub UcAppointment_Load(sender As Object, e As EventArgs) Handles Me.Load
        AppointmentList.AutoScroll = True
        AppointmentList.FlowDirection = FlowDirection.TopDown
        AppointmentList.WrapContents = False
        AppointmentList.BackColor = Color.WhiteSmoke
        AppointmentList.BorderStyle = BorderStyle.FixedSingle
        AppointmentList.Padding = New Padding(10)

        sortComboBox.Items.Clear()
        sortComboBox.Items.AddRange({
            "Appointment ID (Asc)",
            "Appointment ID (Desc)",
            "Patient Name (A–Z)",
            "Patient Name (Z–A)",
            "Date (Asc)",
            "Date (Desc)",
            "Time (Asc)",
            "Time (Desc)",
            "Status (Queued First)",
            "Status (Pending First)",
            "Status (Completed First)"
        })
        sortComboBox.SelectedIndex = 0
        sortComboBox.DropDownStyle = ComboBoxStyle.DropDownList

        LoadAppointmentsFromDB()

        Select Case DataStore.currentUser(3).ToLower()
            Case "admin", "staff"
                addAppointmentBtn.Show()
            Case "doctor"
                addAppointmentBtn.Hide()
        End Select
    End Sub

    Private Sub LoadAppointmentsFromDB()
        Try
            AppointmentList.Controls.Clear()
            allAppointments.Clear()
            Dim dt As DataTable = db.GetAllAppointments()
            If dt Is Nothing OrElse dt.Rows.Count = 0 Then
                AppointmentList.Controls.Add(New Label() With {.Text = "No appointments found.", .Font = New Font("Segoe UI", 12), .AutoSize = True})
                Return
            End If
            For Each row As DataRow In dt.Rows
                Dim app As New AppointmentData With {
                    .AppointmentID = row.Field(Of Integer)("appointment_id"),
                    .Patient = row.Field(Of String)("patient_name"),
                    .Doctor = row.Field(Of String)("doctor_name"),
                    .Date = row.Field(Of String)("date"),
                    .Time = row.Field(Of String)("time"),
                    .Notes = row.Field(Of String)("notes"),
                    .PatientID = row.Field(Of String)("patient_id"),
                    .DoctorVID = row.Field(Of String)("Verified_ID"),
                    .Status = row.Field(Of String)("status")
                }
                allAppointments.Add(app)
            Next
            filteredAppointments = allAppointments.ToList()
            DisplayAppointments(filteredAppointments)
        Catch ex As Exception
            MessageBox.Show("Failed to load appointments: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub DisplayAppointments(list As List(Of AppointmentData))
        AppointmentList.Controls.Clear()
        If list.Count = 0 Then
            AppointmentList.Controls.Add(New Label() With {.Text = "No matching appointments found.", .Font = New Font("Segoe UI", 11), .AutoSize = True})
            Return
        End If

        For Each a In list
            Dim instance As New Appointment_Instance()
            instance.Appointment_ID_Placeholder.Text = a.AppointmentID.ToString()
            instance.Patient_Name_Placeholder.Text = a.Patient
            instance.Doctor_Name_Placeholder.Text = a.Doctor
            instance.Date_Placeholder.Text = a.Date
            instance.Time_Placeholder.Text = TryFormatTime(a.Time)
            instance.Status_Placeholder.Text = a.Status

            instance.Btn_Consult.Tag = a
            instance.Btn_Payment.Tag = a
            instance.Btn_Cancel.Tag = a
            instance.Btn_Resched.Tag = a

            RemoveHandler instance.Btn_Consult.Click, AddressOf ConsultHandler
            RemoveHandler instance.Btn_Payment.Click, AddressOf PaymentHandler
            RemoveHandler instance.Btn_Cancel.Click, AddressOf CancelHandler
            RemoveHandler instance.Btn_Resched.Click, AddressOf ReschedHandler

            AddHandler instance.Btn_Consult.Click, AddressOf ConsultHandler
            AddHandler instance.Btn_Payment.Click, AddressOf PaymentHandler
            AddHandler instance.Btn_Cancel.Click, AddressOf CancelHandler
            AddHandler instance.Btn_Resched.Click, AddressOf ReschedHandler

            Select Case DataStore.currentUser(3).ToLower()
                Case "admin", "staff"
                    instance.Btn_Consult.Hide()
                Case "doctor"
                    instance.Btn_Payment.Hide()
                    instance.Btn_Resched.Hide()
                    instance.Btn_Cancel.Hide()
            End Select

            Select Case a.Status
                Case "Queued"
                    instance.Btn_Payment.BackColor = Color.DarkSalmon
                    instance.Btn_Payment.Enabled = False
                Case "Pending"
                    instance.Btn_Consult.BackColor = Color.DarkSalmon
                    instance.Btn_Consult.Enabled = False
                    instance.Btn_Resched.BackColor = Color.Salmon
                    instance.Btn_Resched.Enabled = False
                    instance.Btn_Cancel.BackColor = Color.Salmon
                    instance.Btn_Cancel.Enabled = False
                Case "Completed"
                    instance.Btn_Payment.BackColor = Color.DarkSalmon
                    instance.Btn_Payment.Enabled = False
                    instance.Btn_Consult.BackColor = Color.DarkSalmon
                    instance.Btn_Consult.Enabled = False
                    instance.Btn_Resched.BackColor = Color.Salmon
                    instance.Btn_Resched.Enabled = False
                    instance.Btn_Cancel.BackColor = Color.Salmon
                    instance.Btn_Cancel.Enabled = False
            End Select

            AppointmentList.Controls.Add(instance)
        Next
    End Sub

    Private Function TryFormatTime(t As String) As String
        Try
            Return DateTime.ParseExact(t, "HH:mm", CultureInfo.InvariantCulture).ToString("hh:mm tt")
        Catch
            Return t
        End Try
    End Function

    Private Sub addAppointmentBtn_Click(sender As Object, e As EventArgs) Handles addAppointmentBtn.Click
        Dim form As New AddAppointment()
        If form.ShowDialog() = DialogResult.OK Then LoadAppointmentsFromDB()
    End Sub

    Private Sub ApplySearchAndSort()
        Dim patientQuery As String = searchPatient.Text.Trim().ToLower()
        Dim doctorQuery As String = searchDoctor.Text.Trim().ToLower()
        filteredAppointments = allAppointments.Where(Function(a) a.Patient.ToLower().Contains(patientQuery) AndAlso a.Doctor.ToLower().Contains(doctorQuery)).ToList()
        ApplySorting()
        DisplayAppointments(filteredAppointments)
    End Sub

    Private Sub searchPatient_TextChanged(sender As Object, e As EventArgs) Handles searchPatient.TextChanged
        ApplySearchAndSort()
    End Sub

    Private Sub searchDoctor_TextChanged(sender As Object, e As EventArgs) Handles searchDoctor.TextChanged
        ApplySearchAndSort()
    End Sub

    Private Sub sortComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles sortComboBox.SelectedIndexChanged
        ApplySearchAndSort()
    End Sub

    Private Sub ApplySorting()
        Dim selected As String = sortComboBox.SelectedItem.ToString()
        Select Case selected
            Case "Appointment ID (Asc)"
                filteredAppointments = filteredAppointments.OrderBy(Function(a) a.AppointmentID).ToList()
            Case "Appointment ID (Desc)"
                filteredAppointments = filteredAppointments.OrderByDescending(Function(a) a.AppointmentID).ToList()
            Case "Patient Name (A–Z)"
                filteredAppointments = filteredAppointments.OrderBy(Function(a) a.Patient).ToList()
            Case "Patient Name (Z–A)"
                filteredAppointments = filteredAppointments.OrderByDescending(Function(a) a.Patient).ToList()
            Case "Date (Asc)"
                filteredAppointments = filteredAppointments.OrderBy(Function(a) SafeParseDate(a.Date)).ToList()
            Case "Date (Desc)"
                filteredAppointments = filteredAppointments.OrderByDescending(Function(a) SafeParseDate(a.Date)).ToList()
            Case "Time (Asc)"
                filteredAppointments = filteredAppointments.OrderBy(Function(a) SafeParseTime(a.Time)).ToList()
            Case "Time (Desc)"
                filteredAppointments = filteredAppointments.OrderByDescending(Function(a) SafeParseTime(a.Time)).ToList()
            Case "Status (Queued First)"
                filteredAppointments = filteredAppointments.OrderBy(Function(a) StatusOrder(a.Status, {"Queued", "Pending", "Completed"})).ToList()
            Case "Status (Pending First)"
                filteredAppointments = filteredAppointments.OrderBy(Function(a) StatusOrder(a.Status, {"Pending", "Queued", "Completed"})).ToList()
            Case "Status (Completed First)"
                filteredAppointments = filteredAppointments.OrderBy(Function(a) StatusOrder(a.Status, {"Completed", "Pending", "Queued"})).ToList()
        End Select
    End Sub

    Private Function SafeParseDate(s As String) As Date
        Try
            Return Date.Parse(s)
        Catch
            Return Date.MinValue
        End Try
    End Function

    Private Function SafeParseTime(s As String) As DateTime
        Try
            Return DateTime.Parse(s)
        Catch
            Return Date.MinValue
        End Try
    End Function

    Private Function StatusOrder(status As String, order() As String) As Integer
        Dim idx As Integer = Array.IndexOf(order, status)
        If idx >= 0 Then Return idx Else Return order.Length
    End Function

    Private Sub ConsultHandler(sender As Object, e As EventArgs)
        Dim btn As Button = DirectCast(sender, Button)
        Dim data As AppointmentData = DirectCast(btn.Tag, AppointmentData)
        Dim appointmentDate As Date
        Try
            appointmentDate = Date.Parse(data.Date)
        Catch
            appointmentDate = Date.Now
        End Try
        If Date.Now.Date < appointmentDate Then
            Dim result As DialogResult = MessageBox.Show($"This appointment is scheduled for {appointmentDate.ToShortDateString()}. Do you want to consult early?", "Consult Early", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If result = DialogResult.No Then Return
        End If
        Dim form As New ConsultationForm() With {
            .PatientName = data.Patient,
            .DoctorName = data.Doctor,
            .AppointmentDate = data.Date,
            .AppointmentTime = data.Time,
            .Notes = data.Notes,
            .AppointmentID = data.AppointmentID,
            .PatientID = data.PatientID,
            .DoctorVID = data.DoctorVID
        }
        AddHandler form.FormClosed, Sub() LoadAppointmentsFromDB()
        form.ShowDialog()
    End Sub

    Private Sub PaymentHandler(sender As Object, e As EventArgs)
        Dim btn As Button = DirectCast(sender, Button)
        Dim data As AppointmentData = DirectCast(btn.Tag, AppointmentData)
        Dim form As New ConsulationFee(data.AppointmentID, data.Patient, data.Date, data.Time)
        AddHandler form.FormClosed, Sub() LoadAppointmentsFromDB()
        form.ShowDialog()
    End Sub

    Private Sub ReschedHandler(sender As Object, e As EventArgs)
        Dim btn As Button = DirectCast(sender, Button)
        Dim data As AppointmentData = DirectCast(btn.Tag, AppointmentData)
        Dim form As New ReschedAppointment() With {
            .AppointmentID = data.AppointmentID,
            .PatientName = data.Patient,
            .DoctorName = data.Doctor,
            .AppointmentDate = data.Date,
            .AppointmentTime = data.Time,
            .NotesText = data.Notes
        }
        AddHandler form.FormClosed, Sub() LoadAppointmentsFromDB()
        form.ShowDialog()
    End Sub

    Private Sub CancelHandler(sender As Object, e As EventArgs)
        Dim btn As Button = DirectCast(sender, Button)
        Dim data As AppointmentData = DirectCast(btn.Tag, AppointmentData)
        Dim result As DialogResult = MessageBox.Show($"Are you sure you want to cancel the appointment of {data.Patient} (ID: {data.AppointmentID})?", "Cancel Appointment", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
        If result = DialogResult.Yes Then
            Try
                Dim query As String = $"DELETE FROM appointments WHERE appointment_id = {data.AppointmentID}"
                Dim rowsAffected As Integer = db.ExecuteNonQuery(query)
                If rowsAffected > 0 Then
                    MessageBox.Show("Appointment successfully cancelled!", "Cancel Appointment", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    LoadAppointmentsFromDB()
                Else
                    MessageBox.Show("Failed to cancel appointment. It may have been removed already.", "Cancel Appointment", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Catch ex As Exception
                MessageBox.Show("Error cancelling appointment: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Private Sub NavbarMenu_Click(sender As Object, e As EventArgs) Handles NavbarMenu.Click
        MainContentPanel.Controls.Clear()
        Dim addMainMenu As New UcMainMenu(MainContentPanel)
        addMainMenu.Dock = DockStyle.Fill
        MainContentPanel.Controls.Add(addMainMenu)
    End Sub
End Class
