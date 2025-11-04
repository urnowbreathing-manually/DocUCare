Imports System.Data.SqlClient

Public Class ConsulationFee
    Private AppointmentID As Integer
    Private db As New DBHandler()

    ' Constructor – receives values from UcAppointment
    Public Sub New(apptId As Integer, patientName As String, apptDate As String, apptTime As String)
        InitializeComponent()
        AppointmentID = apptId
        PatientNamePlaceholder.Text = patientName
        DatePlaceholder.Text = apptDate
        TimePlaceHolder.Text = apptTime
    End Sub

    ' Save button: mark appointment as completed (no database insert)
    Private Sub Btn_SaveFee_Click(sender As Object, e As EventArgs) Handles Btn_SaveFee.Click
        ' Validate staff name
        If staffName.Text.Trim() = "" Then
            MessageBox.Show("Please enter the staff name.", "Missing Field", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Validate consultation fee
        Dim fee As Decimal
        If Not Decimal.TryParse(FeeTextBox.Text.Trim(), fee) Then
            MessageBox.Show("Please enter a valid consultation fee.", "Invalid Fee", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Try
            ' Update appointment status and consultation fee
            Dim query As String = "UPDATE appointments SET status = 'Completed', consult_fee = @fee WHERE appointment_id = @id"
            Dim parameters As New Dictionary(Of String, Object) From {
            {"@id", AppointmentID},
            {"@fee", fee}
        }

            Dim result As Integer = db.ExecuteNonQueryWithParameters(query, parameters)

            If result > 0 Then
                MessageBox.Show("Consultation marked as completed and fee saved!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.DialogResult = DialogResult.OK
                Me.Close()
            Else
                MessageBox.Show("No rows were updated. Please check the appointment ID.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If

        Catch ex As Exception
            MessageBox.Show("Error updating status and fee: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub



    ' Cancel button
    Private Sub Btn_Cancel_Click(sender As Object, e As EventArgs) Handles Btn_Cancel.Click
        Me.Close()
    End Sub

    Private Sub FeeTextBox_TextChanged(sender As Object, e As EventArgs) Handles FeeTextBox.TextChanged

    End Sub
End Class
