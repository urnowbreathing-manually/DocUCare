Public Class PatientInfo
    Private db As New DBHandler()
    Private allowEdit As Boolean = True

    ' Called by AddAppointment before showing
    Public Sub HideEditButton()
        allowEdit = False
    End Sub

    Private Function SafeField(split() As String, idx As Integer) As String
        If split Is Nothing OrElse idx < 0 OrElse idx >= split.Length Then
            Return String.Empty
        End If
        Return split(idx)
    End Function

    Private Sub PatientInfo_Load(sender As Object, e As EventArgs) Handles Me.Load
        RefreshUiFromMainMenu()

        ' Hide Edit button if called from AddAppointment
        If Not allowEdit Then
            EditPatientBtn.Hide()
        ElseIf currentUser(3) = "Doctor" Then
            EditPatientBtn.Hide()
        End If
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

            ' Split the data passed from AddAppointment or UcMainMenu
            Dim parts() As String = UcMainMenu.patientInfo.Split("|"c)

            ' Match order with database columns
            Dim patientID = SafeField(parts, 0)
            Dim patientName = SafeField(parts, 1)
            Dim age = SafeField(parts, 2)
            Dim gender = SafeField(parts, 3)
            Dim contact = SafeField(parts, 4)
            Dim emContact = SafeField(parts, 5)
            Dim emContactName = SafeField(parts, 6)
            Dim emContactRel = SafeField(parts, 7)
            Dim blood = SafeField(parts, 8)
            Dim allergies = SafeField(parts, 9)
            Dim medCond = SafeField(parts, 10)
            Dim height = SafeField(parts, 11)
            Dim weight = SafeField(parts, 12)

            ' Assign values to UI labels
            FullName_Lbl.Text = "Full Name: " & (If(String.IsNullOrWhiteSpace(patientName), "N/A", patientName))
            Age_Lbl.Text = "Age: " & (If(String.IsNullOrWhiteSpace(age), "N/A", age))
            Gender_Lbl.Text = "Gender: " & (If(String.IsNullOrWhiteSpace(gender), "N/A", gender))
            ContactNo_Lbl.Text = "Contact No.: " & (If(String.IsNullOrWhiteSpace(contact), "N/A", contact))
            EmContactNo_Lbl.Text = "Emergency Contact No.: " & (If(String.IsNullOrWhiteSpace(emContact), "N/A", emContact))
            EmContactName_Lbl.Text = "Emergency Contact Name: " & (If(String.IsNullOrWhiteSpace(emContactName), "N/A", emContactName))
            EmContactRel_Lbl.Text = "Emergency Contact Relationship: " & (If(String.IsNullOrWhiteSpace(emContactRel), "N/A", emContactRel))
            BloodType_Lbl.Text = "Blood Type: " & (If(String.IsNullOrWhiteSpace(blood), "Unknown", blood))
            Allergies_Lbl.Text = "Allergies: " & (If(String.IsNullOrWhiteSpace(allergies), "N/A", allergies))
            MedCond_Lbl.Text = "Medical Conditions: " & (If(String.IsNullOrWhiteSpace(medCond), "N/A", medCond))
            Height_Lbl.Text = "Height: " & (If(String.IsNullOrWhiteSpace(height), "N/A", height))
            Weight_Lbl.Text = "Weight: " & (If(String.IsNullOrWhiteSpace(weight), "N/A", weight))

        Catch ex As Exception
            MessageBox.Show("Error loading patient info: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub CloseBtn_Click(sender As Object, e As EventArgs) Handles CloseBtn.Click
        Me.Close()
    End Sub
End Class
