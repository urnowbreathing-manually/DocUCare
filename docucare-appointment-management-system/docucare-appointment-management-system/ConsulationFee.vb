Imports System.Data.SqlClient

Public Class ConsulationFee
    Private AppointmentID As Integer
    Private db As New DBHandler()
    Private staffFullNameAndRole As String = "" ' To store the staff name

    ' Constructor – receives values from UcAppointment
    Public Sub New(apptId As Integer, patientName As String, apptDate As String, apptTime As String)
        InitializeComponent()
        AppointmentID = apptId
        PatientNamePlaceholder.Text = patientName
        DatePlaceholder.Text = apptDate
        TimePlaceHolder.Text = apptTime
    End Sub

    ' ⭐ Automatically set the staff name when the form loads
    Private Sub ConsulationFee_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Get the formatted name from our global session
        staffFullNameAndRole = $"{CurrentUserSession.FullName} - {CurrentUserSession.Role}"

        ' Set the text of the staffName control
        ' (This assumes you changed staffName from a TextBox to a Label in the designer)
        staffName.Text = staffFullNameAndRole
    End Sub

    ' Save button: mark appointment as completed
    Private Sub Btn_SaveFee_Click(sender As Object, e As EventArgs) Handles Btn_SaveFee.Click

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

    ' ⭐ NEW: This function validates key presses for the FeeTextBox
    Private Sub FeeTextBox_KeyPress(sender As Object, e As KeyPressEventArgs) Handles FeeTextBox.KeyPress
        ' Allow the backspace key
        If e.KeyChar = ChrW(Keys.Back) Then
            Return
        End If

        ' Allow only one decimal point
        If e.KeyChar = "." Then
            If FeeTextBox.Text.Contains(".") Then
                e.Handled = True ' Block the keypress
            End If
            Return
        End If

        ' Allow only digits
        If Not Char.IsDigit(e.KeyChar) Then
            e.Handled = True ' Block all other keys
        End If
    End Sub
End Class