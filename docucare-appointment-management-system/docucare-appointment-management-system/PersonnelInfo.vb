Imports System.Data

Public Class PersonnelInfo
    Private dataRow As DataRow
    Private refreshCallback As Action

    Public Sub New(row As DataRow, refreshGrid As Action)
        InitializeComponent()
        dataRow = row
        refreshCallback = refreshGrid
        LoadInfo()
    End Sub

    Private Sub LoadInfo()
        FullName_Lbl.Text = "Full Name: " & dataRow("Personnel_Name").ToString()
        VerifiedID_Lbl.Text = "Verified ID: " & dataRow("Verified_ID").ToString()
        ContactNo_Lbl.Text = "Contact No: " & dataRow("ContactNo").ToString()
        Role_Lbl.Text = "Role: " & dataRow("Role").ToString()
        Schedule_Lbl.Text = "Schedule: " & dataRow("Schedule").ToString()
    End Sub

    Private Sub EditPatientBtn_Click(sender As Object, e As EventArgs) Handles EditPatientBtn.Click
        Dim role = dataRow("Role").ToString().ToLower()

        If role = "doctor" Then
            Dim editForm As New EditDoctor(dataRow)
            editForm.ShowDialog()
        ElseIf role = "staff" Then
            Dim editForm As New EditStaff(dataRow)
            editForm.ShowDialog()
        End If

        ' Refresh info after edit
        LoadInfo()
        refreshCallback?.Invoke()
    End Sub


    Private Sub CloseBtn_Click(sender As Object, e As EventArgs) Handles CloseBtn.Click
        Me.Close()
    End Sub

    Private Sub PersonnelInfo_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub PatientInfoPanel_Paint(sender As Object, e As PaintEventArgs) Handles PatientInfoPanel.Paint

    End Sub
End Class
