Public Class PatientInfo
    Private Function SafeField(split() As String, idx As Integer) As String
        If split Is Nothing OrElse idx < 0 OrElse idx >= split.Length Then
            Return String.Empty
        End If
        Return split(idx)
    End Function

    Private Sub UcPatientInfo_Load(sender As Object, e As EventArgs) Handles Me.Load
        RefreshUiFromMainMenu()
    End Sub

    Public Sub RefreshUiFromMainMenu()
        Try
            If String.IsNullOrWhiteSpace(UcMainMenu.patientInfo) Then

                FullName_Lbl.Text = "Full Name: N/A"
                Age_Lbl.Text = "Age: N/A"
                Height_Lbl.Text = "Height: N/A"
                Weight_Lbl.Text = "Weight: N/A"
                Gender_Lbl.Text = "Gender: N/A"
                ContactNo_Lbl.Text = "Contact No.: N/A"
                EmContactNo_Lbl.Text = "Emergency Contact No.: N/A"
                BloodType_Lbl.Text = "Blood Type: N/A"
                Allergies_Lbl.Text = "Allergies: N/A"
                MedCond_Lbl.Text = "Medical Conditions: N/A"
                Return
            End If

            Dim parts() As String = UcMainMenu.patientInfo.Split("|"c)

            Dim firstName = SafeField(parts, 0)
            Dim lastName = SafeField(parts, 1)
            Dim age = SafeField(parts, 2)
            Dim height = SafeField(parts, 3)
            Dim weight = SafeField(parts, 4)
            Dim gender = SafeField(parts, 5)
            Dim contact = SafeField(parts, 6)
            Dim emContact = SafeField(parts, 7)
            Dim blood = SafeField(parts, 8)
            Dim allergies = SafeField(parts, 9)
            Dim medCond = SafeField(parts, 10)

            FullName_Lbl.Text = "Full Name: " & (If(String.IsNullOrWhiteSpace(lastName), firstName, lastName & ", " & firstName))
            Age_Lbl.Text = "Age: " & (If(String.IsNullOrWhiteSpace(age), "N/A", age))
            Height_Lbl.Text = "Height: " & (If(String.IsNullOrWhiteSpace(height), "N/A", height))
            Weight_Lbl.Text = "Weight: " & (If(String.IsNullOrWhiteSpace(weight), "N/A", weight))
            Gender_Lbl.Text = "Gender: " & (If(String.IsNullOrWhiteSpace(gender), "N/A", gender))
            ContactNo_Lbl.Text = "Contact No.: " & (If(String.IsNullOrWhiteSpace(contact), "N/A", contact))
            EmContactNo_Lbl.Text = "Emergency Contact No.: " & (If(String.IsNullOrWhiteSpace(emContact), "N/A", emContact))
            BloodType_Lbl.Text = "Blood Type: " & (If(String.IsNullOrWhiteSpace(blood), "Unknown", blood))
            Allergies_Lbl.Text = "Allergies: " & (If(String.IsNullOrWhiteSpace(allergies), "N/A", allergies))
            MedCond_Lbl.Text = "Medical Conditions: " & (If(String.IsNullOrWhiteSpace(medCond), "N/A", medCond))

        Catch ex As Exception
            MessageBox.Show("Error loading patient info: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub EditPatientBtn_Click(sender As Object, e As EventArgs) Handles EditPatientBtn.Click
        Dim parts() As String = UcMainMenu.patientInfo.Split("|")
        Dim editForm As New EditPatientInfo()

        ' 
        editForm.TxtFirstName = If(parts.Length > 0, parts(0), "")
        editForm.TxtLastName = If(parts.Length > 1, parts(1), "")
        editForm.TxtAge = If(parts.Length > 2, parts(2), "")
        editForm.TxtHeight = If(parts.Length > 3, parts(3), "")
        editForm.TxtWeight = If(parts.Length > 4, parts(4), "")
        editForm.TxtGender = If(parts.Length > 5, parts(5), "")
        editForm.TxtContactNum = If(parts.Length > 6, parts(6), "")
        editForm.TxtEmergencyContact = If(parts.Length > 7, parts(7), "")
        editForm.TxtBloodType = If(parts.Length > 8, parts(8), "")
        editForm.TxtAllergies = If(parts.Length > 9, parts(9), "")
        editForm.TxtMedicalConditions = If(parts.Length > 10, parts(10), "")

        ' Show dialog
        If editForm.ShowDialog() = DialogResult.OK Then
            ' Save back to patientInfo string
            UcMainMenu.patientInfo = String.Join("|", New String() {
                editForm.TxtFirstName,
                editForm.TxtLastName,
                editForm.TxtAge,
                editForm.TxtHeight,
                editForm.TxtWeight,
                editForm.TxtGender,
                editForm.TxtContactNum,
                editForm.TxtEmergencyContact,
                editForm.TxtBloodType,
                editForm.TxtAllergies,
                editForm.TxtMedicalConditions
            })

            ' 🔹 Updated lanels after save
            FullName_Lbl.Text = "Full Name: " & editForm.TxtFirstName & ", " & editForm.TxtLastName
            Age_Lbl.Text = "Age: " & editForm.TxtAge
            Height_Lbl.Text = "Height: " & editForm.TxtHeight
            Weight_Lbl.Text = "Weight: " & editForm.TxtWeight
            Gender_Lbl.Text = "Gender: " & editForm.TxtGender
            ContactNo_Lbl.Text = "Contact No.: " & editForm.TxtContactNum
            EmContactNo_Lbl.Text = "Emergency Contact No.: " & editForm.TxtEmergencyContact
            BloodType_Lbl.Text = "Blood Type: " & editForm.TxtBloodType
            Allergies_Lbl.Text = "Allergies: " & editForm.TxtAllergies
            MedCond_Lbl.Text = "Medical Conditions: " & editForm.TxtMedicalConditions
        End If
    End Sub
    Private Sub Close_Click(sender As Object, e As EventArgs) Handles CloseBtn.Click
        Me.Close()
    End Sub
End Class
