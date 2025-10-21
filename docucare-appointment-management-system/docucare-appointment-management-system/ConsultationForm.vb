Public Class ConsultationForm
    ' Public properties to receive appointment data
    Public Property PatientName As String
    Public Property DoctorName As String
    Public Property AppointmentDate As String
    Public Property AppointmentTime As String
    Public Property Notes As String

    Private Sub ConsultationForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Automatically fill textboxes when the form opens
        lblPatient.Text = "Patient Name: " & PatientName
        lblDoctor.Text = "Assigned Doctor: " & DoctorName
        lblDate.Text = "Date: " & AppointmentDate
        lblTime.Text = "Time: " & AppointmentTime
        lblNotes.Text = "Reason: " & Notes
    End Sub


    ' Save Consultation
    Private Sub CreateConsultation_Click(sender As Object, e As EventArgs) Handles CreateConsultation.Click
        If String.IsNullOrWhiteSpace(Symptoms.Text) Then
            MessageBox.Show("Please enter symptoms.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Symptoms.Focus()
            Return
        End If

        If String.IsNullOrWhiteSpace(Diagnosis.Text) Then
            MessageBox.Show("Please enter a diagnosis.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Diagnosis.Focus()
            Return
        End If

        ' Build summary
        Dim summary As String = "=== Consultation Summary ===" & Environment.NewLine & Environment.NewLine
        summary &= "Symptoms: " & Symptoms.Text & Environment.NewLine
        summary &= "Diagnosis: " & Diagnosis.Text & Environment.NewLine
        summary &= Environment.NewLine & "Prescriptions:" & Environment.NewLine


        summary &= Environment.NewLine & "Additional Notes: " &
                   If(String.IsNullOrWhiteSpace(DrugPrescriptionNotes.Text), "None", DrugPrescriptionNotes.Text) & Environment.NewLine

        MessageBox.Show(summary, "Consultation Saved", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Me.Close()
    End Sub

    ' Cancel button
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim result As DialogResult = MessageBox.Show(
           "Are you sure you want to cancel? Any unsaved information will be lost.",
           "Cancel Consultation",
           MessageBoxButtons.YesNo,
           MessageBoxIcon.Warning
       )
        If result = DialogResult.Yes Then
            Me.Close()
        End If
    End Sub

    Private Sub FlowPanelPrescriptions_Paint(sender As Object, e As PaintEventArgs)

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles lblPatient.Click

    End Sub

    Private Sub Label11_Click(sender As Object, e As EventArgs) Handles lblNotes.Click

    End Sub

    Private Sub DrugPrescriptionNotes_TextChanged(sender As Object, e As EventArgs) Handles DrugPrescriptionNotes.TextChanged

    End Sub
End Class
