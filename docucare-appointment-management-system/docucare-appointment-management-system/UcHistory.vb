Imports System.Data
Imports System.Globalization
Imports System.Linq
Public Class UcHistory
    Inherits UserControl

    Private MainContentPanel As Panel
    Private db As New DBHandler()
    Private allHistory As New List(Of HistoryData)
    Private filteredHistory As New List(Of HistoryData)

    Private Class HistoryData
        Public Property AppointmentID As Integer
        Public Property Patient As String
        Public Property Doctor As String
        Public Property [Date] As String
        Public Property Time As String
        Public Property Notes As String
        Public Property PatientID As String
        Public Property DoctorVID As String
        Public Property Status As String
        Public Property Consult_Fee As Decimal
    End Class


    ' Constructor receives parent panel
    Public Sub New(parent As Panel)
        InitializeComponent()
        MainContentPanel = parent
    End Sub

    Private Sub UcHistory_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        HistoryList.AutoScroll = True
        HistoryList.FlowDirection = FlowDirection.TopDown
        HistoryList.WrapContents = False
        HistoryList.BackColor = Color.WhiteSmoke
        HistoryList.BorderStyle = BorderStyle.FixedSingle
        HistoryList.Padding = New Padding(10)

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

        Select Case DataStore.currentUser(3).ToLower()
            Case "admin", "staff"
                Label2.Show()
                searchDoctor.Show()
            Case "doctor"
                Label2.Hide()
                searchDoctor.Hide()
        End Select

        LoadHistoryFromDB()
    End Sub

    Private Sub LoadHistoryFromDB()
        Try
            HistoryList.Controls.Clear()
            allHistory.Clear()

            Dim dt As DataTable
            'MsgBox(currentUser(3))
            If currentUser(3) = "Doctor" Then
                dt = db.GetHistoryByDoctor(currentUser(0))
            Else
                dt = db.GetAllHistory()
            End If

            If dt Is Nothing OrElse dt.Rows.Count = 0 Then
                HistoryList.Controls.Add(New Label() With {.Text = "No appointments found.", .Font = New Font("Segoe UI", 12), .AutoSize = True})
                Return
            End If
            For Each row As DataRow In dt.Rows
                Dim app As New HistoryData With {
                    .AppointmentID = row.Field(Of Integer)("appointment_id"),
                    .Patient = row.Field(Of String)("patient_name"),
                    .Doctor = row.Field(Of String)("doctor_name"),
                    .Date = row.Field(Of String)("date"),
                    .Time = row.Field(Of String)("time"),
                    .Notes = row.Field(Of String)("notes"),
                    .PatientID = row.Field(Of String)("patient_id"),
                    .DoctorVID = row.Field(Of String)("Verified_ID"),
                    .Status = row.Field(Of String)("status"),
                    .Consult_Fee = row.Field(Of Decimal)("Consult_Fee")
                }
                allHistory.Add(app)
            Next
            filteredHistory = allHistory.ToList()
            DisplayHistory(filteredHistory)
        Catch ex As Exception
            MessageBox.Show("Failed to load History: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub DisplayHistory(list As List(Of HistoryData))
        HistoryList.Controls.Clear()
        If list.Count = 0 Then
            HistoryList.Controls.Add(New Label() With {.Text = "No matching appointments found.", .Font = New Font("Segoe UI", 11), .AutoSize = True})
            Return
        End If

        For Each a In list
            Dim instance As New History_Instance()
            instance.Patient_Name_Placeholder.Text = a.Patient
            instance.Doctor_Name_Placeholder.Text = a.Doctor
            instance.Date_Placeholder.Text = a.Date
            instance.Consult_Fee_Placeholder.Text = a.Consult_Fee

            HistoryList.Controls.Add(instance)
        Next
    End Sub

    Private Function TryFormatTime(t As String) As String
        Try
            Return DateTime.ParseExact(t, "HH:mm", CultureInfo.InvariantCulture).ToString("hh:mm tt")
        Catch
            Return t
        End Try
    End Function

    Private Sub ApplySearchAndSort()
        Dim patientQuery As String = searchPatient.Text.Trim().ToLower()
        Dim doctorQuery As String = searchDoctor.Text.Trim().ToLower()
        filteredHistory = allHistory.Where(Function(a) a.Patient.ToLower().Contains(patientQuery) AndAlso a.Doctor.ToLower().Contains(doctorQuery)).ToList()
        ApplySorting()
        DisplayHistory(filteredHistory)
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
                filteredHistory = filteredHistory.OrderBy(Function(a) a.AppointmentID).ToList()
            Case "Appointment ID (Desc)"
                filteredHistory = filteredHistory.OrderByDescending(Function(a) a.AppointmentID).ToList()
            Case "Patient Name (A–Z)"
                filteredHistory = filteredHistory.OrderBy(Function(a) a.Patient).ToList()
            Case "Patient Name (Z–A)"
                filteredHistory = filteredHistory.OrderByDescending(Function(a) a.Patient).ToList()
            Case "Date (Asc)"
                filteredHistory = filteredHistory.OrderBy(Function(a) SafeParseDate(a.Date)).ToList()
            Case "Date (Desc)"
                filteredHistory = filteredHistory.OrderByDescending(Function(a) SafeParseDate(a.Date)).ToList()
            Case "Time (Asc)"
                filteredHistory = filteredHistory.OrderBy(Function(a) SafeParseTime(a.Time)).ToList()
            Case "Time (Desc)"
                filteredHistory = filteredHistory.OrderByDescending(Function(a) SafeParseTime(a.Time)).ToList()
            Case "Status (Queued First)"
                filteredHistory = filteredHistory.OrderBy(Function(a) StatusOrder(a.Status, {"Queued", "Pending", "Completed"})).ToList()
            Case "Status (Pending First)"
                filteredHistory = filteredHistory.OrderBy(Function(a) StatusOrder(a.Status, {"Pending", "Queued", "Completed"})).ToList()
            Case "Status (Completed First)"
                filteredHistory = filteredHistory.OrderBy(Function(a) StatusOrder(a.Status, {"Completed", "Pending", "Queued"})).ToList()
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

    Private Sub NavbarMenu_Click(sender As Object, e As EventArgs) Handles NavbarMenu.Click
        MainContentPanel.Controls.Clear()
        Dim addMainMenu As New UcMainMenu(MainContentPanel)
        addMainMenu.Dock = DockStyle.Fill
        MainContentPanel.Controls.Add(addMainMenu)
    End Sub


End Class
