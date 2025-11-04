Imports System.Data
Imports System.Globalization
Imports System.Linq

Public Class UcAppointment
    Inherits UserControl

    Private MainContentPanel As Panel
    Private db As New DBHandler()
    Private allAppointments As New List(Of AppointmentData)
    Private filteredAppointments As New List(Of AppointmentData)

    ' --- CLASS: Appointment Data ---
    Private Class AppointmentData
        Public Property AppointmentID As Integer
        Public Property Patient As String
        Public Property Doctor As String
        Public Property [Date] As String
        Public Property Time As String
        Public Property Notes As String
        Public Property PatientID As String
        Public Property DoctorVID As String
    End Class

    ' --- CONSTRUCTOR ---
    Public Sub New(parent As Panel)
        InitializeComponent()
        MainContentPanel = parent
    End Sub

    ' --- LOAD EVENT ---
    Private Sub UcAppointment_Load(sender As Object, e As EventArgs) Handles Me.Load
        AppointmentList.AutoScroll = True
        AppointmentList.FlowDirection = FlowDirection.TopDown
        AppointmentList.WrapContents = False
        AppointmentList.BackColor = Color.WhiteSmoke
        AppointmentList.BorderStyle = BorderStyle.FixedSingle
        AppointmentList.Padding = New Padding(10)

        ' Populate sort options
        sortComboBox.Items.Clear()
        sortComboBox.Items.AddRange({
            "Appointment ID (Asc)",
            "Appointment ID (Desc)",
            "Patient Name (A–Z)",
            "Patient Name (Z–A)",
            "Date (Asc)",
            "Date (Desc)",
            "Time (Asc)",
            "Time (Desc)"
        })
        sortComboBox.SelectedIndex = 0
        sortComboBox.DropDownStyle = ComboBoxStyle.DropDownList

        LoadAppointmentsFromDB()

        Select Case DataStore.currentUser(3).ToLower()
            Case "admin"
                addAppointmentBtn.Show()
            Case "doctor"
                addAppointmentBtn.Hide()
            Case "staff"
                addAppointmentBtn.Show()
        End Select
    End Sub

    ' --- LOAD APPOINTMENTS ---
    Private Sub LoadAppointmentsFromDB()
        Try
            AppointmentList.Controls.Clear()
            allAppointments.Clear()

            Dim dt As DataTable = db.GetAllAppointments()
            If dt Is Nothing OrElse dt.Rows.Count = 0 Then
                AppointmentList.Controls.Add(New Label() With {
                    .Text = "No appointments found.",
                    .Font = New Font("Segoe UI", 12),
                    .AutoSize = True
                })
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
                    .DoctorVID = row.Field(Of String)("Verified_ID")
                }
                allAppointments.Add(app)
            Next

            filteredAppointments = allAppointments.ToList()
            DisplayAppointments(filteredAppointments)
        Catch ex As Exception
            MessageBox.Show("Failed to load appointments: " & ex.Message,
                            "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' --- DISPLAY APPOINTMENTS ---
    Private Sub DisplayAppointments(list As List(Of AppointmentData))
        AppointmentList.Controls.Clear()

        If list.Count = 0 Then
            AppointmentList.Controls.Add(New Label() With {
                .Text = "No matching appointments found.",
                .Font = New Font("Segoe UI", 11),
                .AutoSize = True
            })
            Return
        End If

        For Each a In list
            Dim instance As New Appointment_Instance()
            instance.Appointment_ID_Placeholder.Text = a.AppointmentID.ToString()
            instance.Patient_Name_Placeholder.Text = a.Patient
            instance.Doctor_Name_Placeholder.Text = a.Doctor
            instance.Date_Placeholder.Text = a.Date
            instance.Time_Placeholder.Text = TryFormatTime(a.Time)

            ' Attach full data object to the Consult button
            instance.Btn_Consult.Tag = a

            ' 🔹 Attach event handler for Consult click
            AddHandler instance.Btn_Consult.Click, AddressOf Consult

            AppointmentList.Controls.Add(instance)
        Next
    End Sub

    ' --- TIME FORMATTER ---
    Private Function TryFormatTime(t As String) As String
        Try
            Return DateTime.ParseExact(t, "HH:mm", CultureInfo.InvariantCulture).ToString("hh:mm tt")
        Catch
            Return t
        End Try
    End Function

    ' --- ADD APPOINTMENT ---
    Private Sub addAppointmentBtn_Click(sender As Object, e As EventArgs) Handles addAppointmentBtn.Click
        Dim form As New AddAppointment()
        If form.ShowDialog() = DialogResult.OK Then
            LoadAppointmentsFromDB()
        End If
    End Sub

    ' --- SEARCH + SORT COMBINED ---
    Private Sub ApplySearchAndSort()
        Dim patientQuery As String = searchPatient.Text.Trim().ToLower()
        Dim doctorQuery As String = searchDoctor.Text.Trim().ToLower()

        filteredAppointments = allAppointments.
            Where(Function(a) a.Patient.ToLower().Contains(patientQuery) AndAlso
                              a.Doctor.ToLower().Contains(doctorQuery)).
            ToList()

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

    ' --- SORT LOGIC ---
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
                filteredAppointments = filteredAppointments.OrderBy(Function(a)
                                                                        Try
                                                                            Return Date.ParseExact(a.Date, "MMddyyyy", CultureInfo.InvariantCulture)
                                                                        Catch
                                                                            Return Date.MinValue
                                                                        End Try
                                                                    End Function).ToList()

            Case "Date (Desc)"
                filteredAppointments = filteredAppointments.OrderByDescending(Function(a)
                                                                                  Try
                                                                                      Return Date.ParseExact(a.Date, "MMddyyyy", CultureInfo.InvariantCulture)
                                                                                  Catch
                                                                                      Return Date.MinValue
                                                                                  End Try
                                                                              End Function).ToList()

            Case "Time (Asc)"
                filteredAppointments = filteredAppointments.OrderBy(Function(a)
                                                                        Try
                                                                            Return DateTime.ParseExact(a.Time, "HH:mm", CultureInfo.InvariantCulture)
                                                                        Catch
                                                                            Return Date.MinValue
                                                                        End Try
                                                                    End Function).ToList()

            Case "Time (Desc)"
                filteredAppointments = filteredAppointments.OrderByDescending(Function(a)
                                                                                  Try
                                                                                      Return DateTime.ParseExact(a.Time, "HH:mm", CultureInfo.InvariantCulture)
                                                                                  Catch
                                                                                      Return Date.MinValue
                                                                                  End Try
                                                                              End Function).ToList()
        End Select
    End Sub

    ' --- CONSULT LOGIC (FROM ORIGINAL CODE) ---
    Public Shared Sub Consult(sender As Object, e As EventArgs)
        Dim btn As Button = DirectCast(sender, Button)
        Dim data As AppointmentData = DirectCast(btn.Tag, AppointmentData)

        Dim appointmentDate As Date
        Try
            appointmentDate = Date.ParseExact(data.Date, "MMddyyyy", CultureInfo.InvariantCulture)
        Catch ex As Exception
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

        ' --- OPEN CONSULTATION FORM ---
        Dim form As New ConsultationForm()
        form.PatientName = data.Patient
        form.DoctorName = data.Doctor
        form.AppointmentDate = data.Date
        form.AppointmentTime = data.Time
        form.Notes = data.Notes
        form.AppointmentID = data.AppointmentID
        form.PatientID = data.PatientID
        form.DoctorVID = data.DoctorVID

        form.ShowDialog()
    End Sub
End Class
