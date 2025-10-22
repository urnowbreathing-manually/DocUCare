Public Class EditPatientInfo
    ' Public property to hold primary key (patient_id)
    Public Property PatientID As String

    Public Property TxtFirstName As String
    Public Property TxtLastName As String
    Public Property TxtAge As String
    Public Property TxtGender As String
    Public Property TxtHeight As String
    Public Property TxtWeight As String
    Public Property TxtBloodType As String
    Public Property TxtAllergies As String
    Public Property TxtMedicalConditions As String
    Public Property TxtContactNum As String
    Public Property TxtEmergencyContact As String

    Private Sub EditPatientInfo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        FirstName.Text = TxtFirstName
        LastName.Text = TxtLastName
        Age.Text = TxtAge
        Gender.Text = TxtGender
        Height.Text = TxtHeight
        Weight.Text = TxtWeight
        BloodType.Text = TxtBloodType
        Allergies.Text = TxtAllergies
        MedicalConditions.Text = TxtMedicalConditions
        ContactNum.Text = TxtContactNum
        EmergencyContact.Text = TxtEmergencyContact
    End Sub

    Private Sub Save_Click(sender As Object, e As EventArgs) Handles Save.Click
        ' Basic validation placeholder (add more as needed)
        TxtFirstName = FirstName.Text.Trim()
        TxtLastName = LastName.Text.Trim()
        TxtAge = Age.Text.Trim()
        TxtGender = Gender.Text.Trim()
        TxtHeight = Height.Text.Trim()
        TxtWeight = Weight.Text.Trim()
        TxtBloodType = BloodType.Text.Trim()
        TxtAllergies = Allergies.Text.Trim()
        TxtMedicalConditions = MedicalConditions.Text.Trim()
        TxtContactNum = ContactNum.Text.Trim()
        TxtEmergencyContact = EmergencyContact.Text.Trim()

        ' Optionally validate PatientID exists
        If String.IsNullOrWhiteSpace(PatientID) Then
            MessageBox.Show("Cannot save patient: missing Patient ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub
End Class
