Public Class PatientInfo
    Private db As New DBHandler()

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
                EmContactName_Lbl.Text = "Emergency Contact Name: N/A"
                EmContactRel_Lbl.Text = "Emergency Contact Relationship: N/A"
                BloodType_Lbl.Text = "Blood Type: N/A"
                Allergies_Lbl.Text = "Allergies: N/A"
                MedCond_Lbl.Text = "Medical Conditions: N/A"
                Return
            End If

            Dim parts() As String = UcMainMenu.patientInfo.Split("|"c)

            ' Expecting order (indexes):
            ' 0 = patient_id
            ' 1 = firstName
            ' 2 = lastName
            ' 3 = age
            ' 4 = height
            ' 5 = weight
            ' 6 = gender
            ' 7 = contact
            ' 8 = emContact (number)
            ' 9 = emContactName
            ' 10 = emContactRelationship
            ' 11 = blood
            ' 12 = allergies
            ' 13 = medCond

            Dim patientID = SafeField(parts, 0)
            Dim firstName = SafeField(parts, 1)
            Dim lastName = SafeField(parts, 2)
            Dim age = SafeField(parts, 3)
            Dim height = SafeField(parts, 4)
            Dim weight = SafeField(parts, 5)
            Dim gender = SafeField(parts, 6)
            Dim contact = SafeField(parts, 7)
            Dim emContact = SafeField(parts, 8)
            Dim emContactName = SafeField(parts, 9)
            Dim emContactRel = SafeField(parts, 10)
            Dim blood = SafeField(parts, 11)
            Dim allergies = SafeField(parts, 12)
            Dim medCond = SafeField(parts, 13)

            ' 🔍 Debug MessageBox to verify data
            'MessageBox.Show(
            '    $"ID: {patientID}" & vbCrLf &
            '    $"First Name: {firstName}" & vbCrLf &
            '    $"Last Name: {lastName}" & vbCrLf &
            '    $"Age: {age}" & vbCrLf &
            '    $"Height: {height}" & vbCrLf &
            '    $"Weight: {weight}" & vbCrLf &
            '    $"Gender: {gender}" & vbCrLf &
            '    $"Contact: {contact}" & vbCrLf &
            '    $"Emergency Contact No: {emContact}" & vbCrLf &
            '    $"Emergency Contact Name: {emContactName}" & vbCrLf &
            '    $"Emergency Contact Relationship: {emContactRel}" & vbCrLf &
            '    $"Blood Type: {blood}" & vbCrLf &
            '    $"Allergies: {allergies}" & vbCrLf &
            '    $"Medical Conditions: {medCond}",
            '    "DEBUG: PatientInfo Values",
            '    MessageBoxButtons.OK,
            '    MessageBoxIcon.Information
            ')

            ' ✅ Update labels after verifying data
            FullName_Lbl.Text = "Full Name: " & (If(String.IsNullOrWhiteSpace(lastName), firstName, lastName & ", " & firstName))
            Age_Lbl.Text = "Age: " & (If(String.IsNullOrWhiteSpace(age), "N/A", age))
            Height_Lbl.Text = "Height: " & (If(String.IsNullOrWhiteSpace(height), "N/A", height))
            Weight_Lbl.Text = "Weight: " & (If(String.IsNullOrWhiteSpace(weight), "N/A", weight))
            Gender_Lbl.Text = "Gender: " & (If(String.IsNullOrWhiteSpace(gender), "N/A", gender))
            ContactNo_Lbl.Text = "Contact No.: " & (If(String.IsNullOrWhiteSpace(contact), "N/A", contact))
            EmContactNo_Lbl.Text = "Emergency Contact No.: " & (If(String.IsNullOrWhiteSpace(emContact), "N/A", emContact))
            EmContactName_Lbl.Text = "Emergency Contact Name: " & (If(String.IsNullOrWhiteSpace(emContactName), "N/A", emContactName))
            EmContactRel_Lbl.Text = "Emergency Contact Relationship: " & (If(String.IsNullOrWhiteSpace(emContactRel), "N/A", emContactRel))
            BloodType_Lbl.Text = "Blood Type: " & (If(String.IsNullOrWhiteSpace(blood), "Unknown", blood))
            Allergies_Lbl.Text = "Allergies: " & (If(String.IsNullOrWhiteSpace(allergies), "N/A", allergies))
            MedCond_Lbl.Text = "Medical Conditions: " & (If(String.IsNullOrWhiteSpace(medCond), "N/A", medCond))
        Catch ex As Exception
            MessageBox.Show("Error loading patient info: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub EditPatientBtn_Click(sender As Object, e As EventArgs) Handles EditPatientBtn.Click
        Try
            Dim parts() As String = UcMainMenu.patientInfo.Split("|"c)
            Dim patientID As String = If(parts.Length > 0, parts(0), "")

            Dim editForm As New EditPatientInfo()

            ' Populate editor properties (matching our expected order)
            editForm.PatientID = patientID
            editForm.TxtFirstName = If(parts.Length > 1, parts(1), "")
            editForm.TxtLastName = If(parts.Length > 2, parts(2), "")
            editForm.TxtAge = If(parts.Length > 3, parts(3), "")
            editForm.TxtHeight = If(parts.Length > 4, parts(4), "")
            editForm.TxtWeight = If(parts.Length > 5, parts(5), "")
            editForm.TxtGender = If(parts.Length > 6, parts(6), "")
            editForm.TxtContactNum = If(parts.Length > 7, parts(7), "")
            editForm.TxtEmergencyContact = If(parts.Length > 8, parts(8), "")
            editForm.TxtEmContactName = If(parts.Length > 9, parts(9), "")
            editForm.TxtEmContactRelationship = If(parts.Length > 10, parts(10), "")
            editForm.TxtBloodType = If(parts.Length > 11, parts(11), "")
            editForm.TxtAllergies = If(parts.Length > 12, parts(12), "")
            editForm.TxtMedicalConditions = If(parts.Length > 13, parts(13), "")

            If editForm.ShowDialog() = DialogResult.OK Then
                Dim combinedName As String = (editForm.TxtFirstName & " " & editForm.TxtLastName).Trim()
                Dim parsedAge As Integer = 0
                Integer.TryParse(editForm.TxtAge, parsedAge)

                Dim updated As Boolean = db.UpdatePatient(
                    editForm.PatientID,
                    combinedName,
                    parsedAge,
                    editForm.TxtGender,
                    editForm.TxtContactNum,
                    editForm.TxtEmergencyContact,
                    editForm.TxtEmContactName,
                    editForm.TxtEmContactRelationship,
                    editForm.TxtBloodType,
                    editForm.TxtAllergies,
                    editForm.TxtMedicalConditions,
                    editForm.TxtHeight,
                    editForm.TxtWeight
                )

                If updated Then
                    UcMainMenu.patientInfo = String.Join("|", New String() {
                        editForm.PatientID,
                        editForm.TxtFirstName,
                        editForm.TxtLastName,
                        editForm.TxtAge,
                        editForm.TxtHeight,
                        editForm.TxtWeight,
                        editForm.TxtGender,
                        editForm.TxtContactNum,
                        editForm.TxtEmergencyContact,
                        editForm.TxtEmContactName,
                        editForm.TxtEmContactRelationship,
                        editForm.TxtBloodType,
                        editForm.TxtAllergies,
                        editForm.TxtMedicalConditions
                    })

                    RefreshUiFromMainMenu()
                    MessageBox.Show("Patient updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    MessageBox.Show("Failed to update patient. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Error editing patient: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Close_Click(sender As Object, e As EventArgs) Handles CloseBtn.Click
        Me.Dispose()
    End Sub

    Private Sub EmContactName_Lbl_Click(sender As Object, e As EventArgs) Handles EmContactName_Lbl.Click
    End Sub
End Class
