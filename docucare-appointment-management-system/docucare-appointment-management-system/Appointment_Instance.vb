Public Class Appointment_Instance
    ' Dim UcAppointment As UcAppointment

    ' Consult Button
    Private Sub Btn_Consult_Click(sender As Object, e As EventArgs) Handles Btn_Consult.Click
        UcAppointment.ConsultationForm_Show(sender, e)
    End Sub

    ' Payment Button
    Private Sub Btn_Payment_Click(sender As Object, e As EventArgs) Handles Btn_Payment.Click
        UcAppointment.ConsultationFee_Show()
    End Sub

    ' Resched Button
    Private Sub Btn_Resched_Click(sender As Object, e As EventArgs) Handles Btn_Resched.Click

    End Sub

    ' Cancel Button
    Private Sub Btn_Cancel_Click(sender As Object, e As EventArgs) Handles Btn_Cancel.Click
        UcAppointment.CancelAppointment(sender, e)

    End Sub


End Class
