Imports System.Globalization ' --- ADDED THIS LINE ---

Public Class ConsultationForm
    ' --- ADDED ---
    Private db As New DBHandler()
    ' --- END ADDED ---

    ' Public properties to receive appointment data
    Public Property PatientName As String
    Public Property DoctorName As String
    Public Property AppointmentDate As String ' Receives "MMddyyyy" (e.g., "10222025")
    Public Property AppointmentTime As String ' Receives "hh:mm tt" (e.g., "02:30 PM")
    Public Property Notes As String ' This is the "Reason" from the appointment

    ' --- ADDED PROPERTIES ---
    ' These must be set when you open this form
    Public Property PatientID As String
    Public Property DoctorVID As String
    Public Property AppointmentID As Integer
    ' --- END ADDED ---

    Private Sub ConsultationForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Automatically fill textboxes when the form opens
        lblPatient.Text = "Patient Name: " & PatientName
        lblDoctor.Text = "Assigned Doctor: " & DoctorName

        ' --- MODIFIED TO DISPLAY DATE/TIME FRIENDLY ---
        Try
            ' Parse the "MMddyyyy" date and reformat it for display
            lblDate.Text = "Date: " & Date.ParseExact(AppointmentDate, "MMddyyyy", CultureInfo.InvariantCulture).ToShortDateString()
        Catch ex As Exception
            lblDate.Text = "Date: " & AppointmentDate ' Fallback
        End Try

        lblTime.Text = "Time: " & AppointmentTime ' Already in 12-hour format
        ' --- END MODIFICATION ---

        lblNotes.Text = "Reason: " & Notes
    End Sub


    ' --- MODIFIED Save Consultation ---
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

        ' --- REPLACED DUMMY SAVE WITH DATABASE LOGIC ---


        ' Get values for DB
        Dim pSymptoms As String = Symptoms.Text
        Dim pDiagnosis As String = Diagnosis.Text
        Dim pPrescription As String = If(String.IsNullOrWhiteSpace(DrugPrescriptionNotes.Text), "N/A", DrugPrescriptionNotes.Text)

        ' Convert Date/Time from the labels back to correct types
        Dim pDate As Date
        Dim pTime As TimeSpan
        Try
            ' --- FIXED PARSING LOGIC ---
            ' Parse the exact formats we know we are receiving
            pDate = Date.ParseExact(Me.AppointmentDate, "MMddyyyy", CultureInfo.InvariantCulture)
            pTime = DateTime.ParseExact(Me.AppointmentTime, "hh:mm tt", CultureInfo.InvariantCulture).TimeOfDay
            ' --- END FIX ---
        Catch ex As Exception
            MessageBox.Show("Error parsing appointment date/time: " & ex.Message, "Data Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End Try

        ' Verify we have the required IDs
        If Me.AppointmentID <= 0 Or String.IsNullOrWhiteSpace(PatientID) Or String.IsNullOrWhiteSpace(DoctorVID) Then
            MessageBox.Show("Critical data missing (AppointmentID, PatientID, or DoctorVID). Cannot save.", "Data Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return

        End If

        ' Call the DBHandler InsertConsultation function
        If db.InsertConsultation(
            Me.PatientName,
            Me.PatientID,
            pSymptoms,
            pDiagnosis,
            pPrescription,
            Me.DoctorName,
            Me.DoctorVID,
            pDate,
            pTime,
            Me.Notes,       ' This is the "Notes_From_Appointments" field
            Me.AppointmentID
        ) Then
            MessageBox.Show("Consultation Saved to Database", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)


            ' As a final step, update the original appointment status to "Completed"
            db.UpdateAppointmentStatus(Me.AppointmentID, "Completed")

            Me.Close()
        Else
            MessageBox.Show("Failed to save consultation to database.", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
        ' --- END REPLACEMENT ---
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