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
                BloodType_Lbl.Text = "Blood Type: N/A"
                Allergies_Lbl.Text = "Allergies: N/A"
                MedCond_Lbl.Text = "Medical Conditions: N/A"
                Return
            End If

            Dim parts() As String = UcMainMenu.patientInfo.Split("|"c)

            ' Expected format: patient_id(0), firstName(1), lastName(2), age(3), height(4), weight(5), gender(6), contact(7), emContact(8), blood(9), allergies(10), medCond(11)
            Dim patientID = SafeField(parts, 0)
            Dim firstName = SafeField(parts, 1)
            Dim lastName = SafeField(parts, 2)
            Dim age = SafeField(parts, 3)
            Dim height = SafeField(parts, 4)
            Dim weight = SafeField(parts, 5)
            Dim gender = SafeField(parts, 6)
            Dim contact = SafeField(parts, 7)
            Dim emContact = SafeField(parts, 8)
            Dim blood = SafeField(parts, 9)
            Dim allergies = SafeField(parts, 10)
            Dim medCond = SafeField(parts, 11)

            ' Format full name as "Last, First" if last name exists
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
        Try
            Dim parts() As String = UcMainMenu.patientInfo.Split("|"c)
            Dim patientID As String = If(parts.Length > 0, parts(0), "")

            Dim editForm As New EditPatientInfo()

            ' Populate editor with current values (indexes shifted because patientID is at 0)
            editForm.PatientID = patientID
            editForm.TxtFirstName = If(parts.Length > 1, parts(1), "")
            editForm.TxtLastName = If(parts.Length > 2, parts(2), "")
            editForm.TxtAge = If(parts.Length > 3, parts(3), "")
            editForm.TxtHeight = If(parts.Length > 4, parts(4), "")
            editForm.TxtWeight = If(parts.Length > 5, parts(5), "")
            editForm.TxtGender = If(parts.Length > 6, parts(6), "")
            editForm.TxtContactNum = If(parts.Length > 7, parts(7), "")
            editForm.TxtEmergencyContact = If(parts.Length > 8, parts(8), "")
            editForm.TxtBloodType = If(parts.Length > 9, parts(9), "")
            editForm.TxtAllergies = If(parts.Length > 10, parts(10), "")
            editForm.TxtMedicalConditions = If(parts.Length > 11, parts(11), "")

            ' Show dialog
            If editForm.ShowDialog() = DialogResult.OK Then
                ' Persist changes to DB using DBHandler.UpdatePatient
                Dim combinedName As String = (editForm.TxtFirstName & " " & editForm.TxtLastName).Trim()

                ' Parse age to integer (safe)
                Dim parsedAge As Integer = 0
                Integer.TryParse(editForm.TxtAge, parsedAge)

                ' Call update
                Dim updated As Boolean = db.UpdatePatient(
                    editForm.PatientID,
                    combinedName,
                    parsedAge,
                    editForm.TxtGender,
                    editForm.TxtContactNum,
                    editForm.TxtEmergencyContact,
                    editForm.TxtBloodType,
                    editForm.TxtAllergies,
                    editForm.TxtMedicalConditions,
                    editForm.TxtHeight,
                    editForm.TxtWeight
                )

                If updated Then
                    ' Update global patientInfo string in same order
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
                        editForm.TxtBloodType,
                        editForm.TxtAllergies,
                        editForm.TxtMedicalConditions
                    })

                    ' Reflect changes on UI
                    FullName_Lbl.Text = "Full Name: " & (If(String.IsNullOrWhiteSpace(editForm.TxtLastName), editForm.TxtFirstName, editForm.TxtLastName & ", " & editForm.TxtFirstName))
                    Age_Lbl.Text = "Age: " & editForm.TxtAge
                    Height_Lbl.Text = "Height: " & editForm.TxtHeight
                    Weight_Lbl.Text = "Weight: " & editForm.TxtWeight
                    Gender_Lbl.Text = "Gender: " & editForm.TxtGender
                    ContactNo_Lbl.Text = "Contact No.: " & editForm.TxtContactNum
                    EmContactNo_Lbl.Text = "Emergency Contact No.: " & editForm.TxtEmergencyContact
                    BloodType_Lbl.Text = "Blood Type: " & editForm.TxtBloodType
                    Allergies_Lbl.Text = "Allergies: " & editForm.TxtAllergies
                    MedCond_Lbl.Text = "Medical Conditions: " & editForm.TxtMedicalConditions

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
        Me.Close()
    End Sub
End Class
