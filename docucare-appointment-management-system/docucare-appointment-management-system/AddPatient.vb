Imports System.Security.Cryptography.X509Certificates

Public Class AddPatient
    ' --- Database Handler Instance ---
    Private db As New DBHandler()

    Private Sub AddPatient_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' --- Setup Gender ComboBox ---
        Gender.Items.Clear()
        Gender.Items.AddRange({"Select Gender", "Male", "Female"})
        Gender.SelectedIndex = 0
        Gender.DropDownStyle = ComboBoxStyle.DropDownList

        ' --- Setup Blood Type ComboBox ---
        BloodType.Items.Clear()
        BloodType.Items.AddRange({
            "Select Blood Type", "Unknown", "A+", "A-", "B+", "B-", "AB+", "AB-", "O+", "O-"
        })
        BloodType.SelectedIndex = 0
        BloodType.DropDownStyle = ComboBoxStyle.DropDownList

        ' --- Setup Emergency Contact Relationship ---
        EmContactRel.Items.Clear()
        EmContactRel.Items.AddRange({
            "Select Relation", "Parent", "Sibling", "Spouse", "Child", "Relative", "Friend", "Guardian", "Other"
        })
        EmContactRel.SelectedIndex = 0
        EmContactRel.DropDownStyle = ComboBoxStyle.DropDownList
    End Sub

    ' --- Text Input Restrictions ---
    Private Sub FirstName_TextChanged(sender As Object, e As EventArgs) Handles FirstName.TextChanged
        CleanTextOnly(DirectCast(sender, TextBox))
    End Sub

    Private Sub LastName_TextChanged(sender As Object, e As EventArgs) Handles LastName.TextChanged
        CleanTextOnly(DirectCast(sender, TextBox))
    End Sub

    Private Sub EmContactName_TextChanged(sender As Object, e As EventArgs) Handles EmContactName.TextChanged
        CleanTextOnly(DirectCast(sender, TextBox))
    End Sub

    Private Sub CleanTextOnly(tb As TextBox)
        tb.Text = System.Text.RegularExpressions.Regex.Replace(tb.Text, "[^a-zA-Z\s]", "")
        tb.SelectionStart = tb.Text.Length
    End Sub

    Private Sub Age_TextChanged(sender As Object, e As EventArgs) Handles Age.TextChanged
        KeepNumbersOnly(DirectCast(sender, TextBox), 3)
    End Sub

    Private Sub ContactNum_TextChanged(sender As Object, e As EventArgs) Handles ContactNum.TextChanged
        KeepNumbersOnly(DirectCast(sender, TextBox), 11)
    End Sub

    Private Sub EmergencyContact_TextChanged(sender As Object, e As EventArgs) Handles EmergencyContact.TextChanged
        KeepNumbersOnly(DirectCast(sender, TextBox), 11)
    End Sub

    Private Sub Height_TextChanged(sender As Object, e As EventArgs) Handles Height.TextChanged
        KeepNumbersOnly(DirectCast(sender, TextBox), 3)
    End Sub

    Private Sub Weight_TextChanged(sender As Object, e As EventArgs) Handles Weight.TextChanged
        KeepNumbersOnly(DirectCast(sender, TextBox), 3)
    End Sub

    Private Sub KeepNumbersOnly(tb As TextBox, maxLength As Integer)
        tb.Text = System.Text.RegularExpressions.Regex.Replace(tb.Text, "[^\d]", "")
        If tb.Text.Length > maxLength Then
            tb.Text = tb.Text.Substring(0, maxLength)
        End If
        tb.SelectionStart = tb.Text.Length
    End Sub

    ' --- SAVE BUTTON ---
    Private Sub Save_Click(sender As Object, e As EventArgs) Handles Save.Click
        ' === VALIDATION SECTION ===
        If String.IsNullOrWhiteSpace(FirstName.Text) Then ShowWarn("First Name is required.", FirstName) : Exit Sub
        If String.IsNullOrWhiteSpace(LastName.Text) Then ShowWarn("Last Name is required.", LastName) : Exit Sub
        If String.IsNullOrWhiteSpace(Age.Text) Then ShowWarn("Age is required.", Age) : Exit Sub
        If Val(Age.Text) <= 0 Then ShowWarn("Age must be greater than 0.", Age) : Exit Sub
        If Gender.SelectedIndex <= 0 Then ShowWarn("Please select a gender.", Gender) : Exit Sub
        If BloodType.SelectedIndex <= 0 Then ShowWarn("Please select a blood type.", BloodType) : Exit Sub
        If String.IsNullOrWhiteSpace(ContactNum.Text) Then ShowWarn("Contact number is required.", ContactNum) : Exit Sub
        If ContactNum.Text.Length < 11 Then ShowWarn("Contact number must be 11 digits.", ContactNum) : Exit Sub
        If String.IsNullOrWhiteSpace(Height.Text) Then ShowWarn("Height is required.", Height) : Exit Sub
        If Height.Text.Length < 3 Then ShowWarn("Invalid height. Must be 3 digits.", Height) : Exit Sub
        If String.IsNullOrWhiteSpace(Weight.Text) Then ShowWarn("Weight is required.", Weight) : Exit Sub
        If Weight.Text.Length < 2 Then ShowWarn("Invalid weight. Must be at least 2 digits.", Weight) : Exit Sub
        If String.IsNullOrWhiteSpace(EmergencyContact.Text) Then ShowWarn("Emergency contact is required.", EmergencyContact) : Exit Sub
        If EmergencyContact.Text.Length < 11 Then ShowWarn("Emergency contact must be 11 digits.", EmergencyContact) : Exit Sub
        If String.IsNullOrWhiteSpace(EmContactName.Text) Then ShowWarn("Emergency contact name is required.", EmContactName) : Exit Sub
        If EmContactRel.SelectedIndex <= 0 Then ShowWarn("Please select the relationship.", EmContactRel) : Exit Sub

        ' === DATABASE SECTION ===
        Dim pID As String = db.GetNextPatientID()
        If String.IsNullOrEmpty(pID) Then
            MessageBox.Show("Could not generate a new Patient ID. Please check database connection.", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        Dim fullName As String = FirstName.Text & " " & LastName.Text
        Dim pAge As Integer = CInt(Age.Text)
        Dim pSex As String = Gender.SelectedItem.ToString()
        Dim pContact As String = ContactNum.Text
        Dim pEmContact As String = EmergencyContact.Text
        Dim pBloodType As String = BloodType.SelectedItem.ToString()
        Dim pAllergies As String = If(String.IsNullOrWhiteSpace(Allergies.Text), "N/A", Allergies.Text)
        Dim pMedConditions As String = If(String.IsNullOrWhiteSpace(MedicalConditions.Text), "N/A", MedicalConditions.Text)
        Dim heightVal As String = Height.Text
        Dim weightVal As String = Weight.Text
        Dim pEmContactName As String = EmContactName.Text
        Dim pEmContactRel As String = EmContactRel.SelectedItem.ToString()

        ' --- INSERT PATIENT ---
        If db.InsertPatient(
            pID,
            fullName,
            pAge,
            pSex,
            pContact,
            pEmContact,
            pEmContactName,
            pEmContactRel,
            pBloodType,
            pAllergies,
            pMedConditions,
            heightVal,
            weightVal
        ) Then

            MessageBox.Show($"Patient saved successfully!{vbCrLf}New Patient ID: {pID}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

            ' Update UcPatientRecords dynamically if loaded
            For Each ctrl As Control In UcMainMenu.MainContentPanel.Controls
                If TypeOf ctrl Is UcPatientRecords Then
                    DirectCast(ctrl, UcPatientRecords).AddPatientCard(
                    pID,
                    FirstName.Text,
                    LastName.Text,
                    Age.Text,
                    heightVal,
                    weightVal,
                    pSex,
                    pContact,
                    pEmContact,
                    pEmContactName,           ' ✅ Add this
                    pEmContactRel,            ' ✅ Add this
                    pBloodType,
                    pAllergies,
                    pMedConditions
                    )

                    Exit For
                End If
            Next

            Me.Close()
        Else
            MessageBox.Show("Failed to save patient to database.", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub ShowWarn(msg As String, ctrl As Control)
        MessageBox.Show(msg, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        ctrl.Focus()
    End Sub

    ' --- CANCEL BUTTON ---
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim result As DialogResult = MessageBox.Show(
            "Are you sure you want to cancel? Any unsaved information will be lost.",
            "Cancel",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Warning
        )
        If result = DialogResult.Yes Then
            Me.Close()
        End If
    End Sub

    Private Sub Gender_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Gender.SelectedIndexChanged

    End Sub
End Class
