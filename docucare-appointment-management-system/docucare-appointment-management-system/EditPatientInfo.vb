Public Class EditPatientInfo
    ' Patient primary key (property only — NOT a UI textbox)
    Public Property PatientID As String

    ' Values passed from caller (properties only)
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
    Public Property TxtEmContactName As String
    Public Property TxtEmContactRelationship As String

    Private db As New DBHandler()

    Private Sub EditPatientInfo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Populate combo boxes to match AddPatient
        Gender.Items.Clear()
        Gender.Items.AddRange(New String() {"Select Gender", "Male", "Female", "Other"})
        Gender.DropDownStyle = ComboBoxStyle.DropDownList
        Gender.SelectedIndex = 0

        BloodType.Items.Clear()
        BloodType.Items.AddRange(New String() {"Select Blood Type", "Unknown", "A+", "A-", "B+", "B-", "AB+", "AB-", "O+", "O-"})
        BloodType.DropDownStyle = ComboBoxStyle.DropDownList
        BloodType.SelectedIndex = 0

        EmContactRel.Items.Clear()
        EmContactRel.Items.AddRange(New String() {"Select Relation", "Parent", "Sibling", "Spouse", "Child", "Relative", "Friend", "Guardian", "Other"})
        EmContactRel.DropDownStyle = ComboBoxStyle.DropDownList
        EmContactRel.SelectedIndex = 0

        ' --- Pre-fill UI controls from the properties (these are NOT database writes yet) ---
        FirstName.Text = TxtFirstName
        LastName.Text = TxtLastName
        Age.Text = TxtAge
        Height.Text = TxtHeight
        Weight.Text = TxtWeight
        Allergies.Text = TxtAllergies
        MedicalConditions.Text = TxtMedicalConditions
        ContactNum.Text = TxtContactNum
        EmergencyContact.Text = TxtEmergencyContact
        EmContactName.Text = TxtEmContactName

        ' Set gender selection if present
        If Not String.IsNullOrWhiteSpace(TxtGender) Then
            Dim gi As Integer = Gender.FindStringExact(TxtGender)
            If gi >= 0 Then Gender.SelectedIndex = gi
        End If

        ' Set blood type selection if present (fix truncated "unkno" -> "Unknown")
        If Not String.IsNullOrWhiteSpace(TxtBloodType) Then
            Dim normalized As String = TxtBloodType.Trim()
            If normalized.Length <= 4 AndAlso normalized.ToLower().StartsWith("unk") Then
                normalized = "Unknown"
            End If
            Dim bi As Integer = BloodType.FindStringExact(normalized)
            If bi >= 0 Then
                BloodType.SelectedIndex = bi
            Else
                BloodType.SelectedIndex = 0
            End If
        End If

        ' Set emergency contact relationship selection if present
        If Not String.IsNullOrWhiteSpace(TxtEmContactRelationship) Then
            Dim ri As Integer = EmContactRel.FindStringExact(TxtEmContactRelationship)
            If ri >= 0 Then EmContactRel.SelectedIndex = ri
        End If
    End Sub

    ' ------ Live input cleaning (same rules as AddPatient) ------
    Private Sub FirstName_TextChanged(sender As Object, e As EventArgs) Handles FirstName.TextChanged
        Dim tb As TextBox = DirectCast(sender, TextBox)
        tb.Text = System.Text.RegularExpressions.Regex.Replace(tb.Text, "[^a-zA-Z\s]", "")
        tb.SelectionStart = tb.Text.Length
    End Sub

    Private Sub LastName_TextChanged(sender As Object, e As EventArgs) Handles LastName.TextChanged
        Dim tb As TextBox = DirectCast(sender, TextBox)
        tb.Text = System.Text.RegularExpressions.Regex.Replace(tb.Text, "[^a-zA-Z\s]", "")
        tb.SelectionStart = tb.Text.Length
    End Sub

    Private Sub Age_TextChanged(sender As Object, e As EventArgs) Handles Age.TextChanged
        Dim tb As TextBox = DirectCast(sender, TextBox)
        tb.Text = System.Text.RegularExpressions.Regex.Replace(tb.Text, "[^\d]", "")
        If tb.Text.Length > 3 Then tb.Text = tb.Text.Substring(0, 3)
        tb.SelectionStart = tb.Text.Length
    End Sub

    Private Sub ContactNum_TextChanged(sender As Object, e As EventArgs) Handles ContactNum.TextChanged
        Dim tb As TextBox = DirectCast(sender, TextBox)
        tb.Text = System.Text.RegularExpressions.Regex.Replace(tb.Text, "[^\d]", "")
        If tb.Text.Length > 11 Then tb.Text = tb.Text.Substring(0, 11)
        tb.SelectionStart = tb.Text.Length
    End Sub

    ' ✅ Height & Weight now allow decimals like 170.5 or 65.75
    Private Sub Height_TextChanged(sender As Object, e As EventArgs) Handles Height.TextChanged
        KeepDecimalNumbers(DirectCast(sender, TextBox), 3, 2)
    End Sub

    Private Sub Weight_TextChanged(sender As Object, e As EventArgs) Handles Weight.TextChanged
        KeepDecimalNumbers(DirectCast(sender, TextBox), 3, 2)
    End Sub

    Private Sub EmergencyContact_TextChanged(sender As Object, e As EventArgs) Handles EmergencyContact.TextChanged
        Dim tb As TextBox = DirectCast(sender, TextBox)
        tb.Text = System.Text.RegularExpressions.Regex.Replace(tb.Text, "[^\d]", "")
        If tb.Text.Length > 11 Then tb.Text = tb.Text.Substring(0, 11)
        tb.SelectionStart = tb.Text.Length
    End Sub

    Private Sub EmContactName_TextChanged(sender As Object, e As EventArgs) Handles EmContactName.TextChanged
        Dim tb As TextBox = DirectCast(sender, TextBox)
        tb.Text = System.Text.RegularExpressions.Regex.Replace(tb.Text, "[^a-zA-Z\s]", "")
        tb.SelectionStart = tb.Text.Length
    End Sub

    ' ------ Validation + Save ------
    Private Sub Save_Click(sender As Object, e As EventArgs) Handles Save.Click
        If String.IsNullOrWhiteSpace(FirstName.Text) Then ShowWarn("First Name is required.", FirstName) : Exit Sub
        If String.IsNullOrWhiteSpace(LastName.Text) Then ShowWarn("Last Name is required.", LastName) : Exit Sub
        If String.IsNullOrWhiteSpace(Age.Text) Then ShowWarn("Age is required.", Age) : Exit Sub
        If Val(Age.Text) <= 0 Then ShowWarn("Age must be greater than 0.", Age) : Exit Sub
        If Gender.SelectedIndex <= 0 Then ShowWarn("Please select a gender.", Gender) : Exit Sub
        If BloodType.SelectedIndex <= 0 Then ShowWarn("Please select a blood type.", BloodType) : Exit Sub
        If String.IsNullOrWhiteSpace(ContactNum.Text) Then ShowWarn("Contact no. is required.", ContactNum) : Exit Sub
        If ContactNum.Text.Length < 11 Then ShowWarn("Contact Number must be 11 digits.", ContactNum) : Exit Sub
        If String.IsNullOrWhiteSpace(Height.Text) Then ShowWarn("Height is required.", Height) : Exit Sub
        If Val(Height.Text) <= 0 Then ShowWarn("Invalid Height input.", Height) : Exit Sub
        If String.IsNullOrWhiteSpace(Weight.Text) Then ShowWarn("Weight is required.", Weight) : Exit Sub
        If Val(Weight.Text) <= 0 Then ShowWarn("Invalid Weight input.", Weight) : Exit Sub
        If String.IsNullOrWhiteSpace(EmergencyContact.Text) Then ShowWarn("Emergency Contact no. is required.", EmergencyContact) : Exit Sub
        If EmergencyContact.Text.Length < 11 Then ShowWarn("Emergency Contact Number must be 11 digits.", EmergencyContact) : Exit Sub
        If String.IsNullOrWhiteSpace(EmContactName.Text) Then ShowWarn("Emergency contact name is required.", EmContactName) : Exit Sub
        If EmContactRel.SelectedIndex <= 0 Then ShowWarn("Please select the emergency contact's relationship.", EmContactRel) : Exit Sub

        If String.IsNullOrWhiteSpace(PatientID) Then
            MessageBox.Show("Missing PatientID — cannot save.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        ' Prepare fields
        Dim combinedName As String = (FirstName.Text.Trim() & " " & LastName.Text.Trim()).Trim()
        Dim parsedAge As Integer = 0
        Integer.TryParse(Age.Text.Trim(), parsedAge)
        Dim sexVal As String = If(Gender.SelectedIndex > 0, Gender.SelectedItem.ToString(), "")
        Dim emContactVal As String = EmergencyContact.Text.Trim()
        Dim emContactNameVal As String = EmContactName.Text.Trim()
        Dim emContactRelVal As String = If(EmContactRel.SelectedIndex > 0, EmContactRel.SelectedItem.ToString(), "")
        Dim bloodVal As String = If(BloodType.SelectedIndex > 0, BloodType.SelectedItem.ToString(), "")
        Dim allergiesVal As String = If(String.IsNullOrWhiteSpace(Allergies.Text), "N/A", Allergies.Text.Trim())
        Dim medCondVal As String = If(String.IsNullOrWhiteSpace(MedicalConditions.Text), "N/A", MedicalConditions.Text.Trim())
        Dim heightVal As String = Height.Text.Trim()
        Dim weightVal As String = Weight.Text.Trim()
        Dim contactVal As String = ContactNum.Text.Trim()

        Dim updated As Boolean = db.UpdatePatient(
            PatientID,
            combinedName,
            parsedAge,
            sexVal,
            contactVal,
            emContactVal,
            emContactNameVal,
            emContactRelVal,
            bloodVal,
            allergiesVal,
            medCondVal,
            heightVal,
            weightVal
        )

        If updated Then
            TxtFirstName = FirstName.Text.Trim()
            TxtLastName = LastName.Text.Trim()
            TxtAge = Age.Text.Trim()
            TxtGender = sexVal
            TxtHeight = heightVal
            TxtWeight = weightVal
            TxtBloodType = bloodVal
            TxtAllergies = allergiesVal
            TxtMedicalConditions = medCondVal
            TxtContactNum = contactVal
            TxtEmergencyContact = emContactVal
            TxtEmContactName = emContactNameVal
            TxtEmContactRelationship = emContactRelVal

            Me.DialogResult = DialogResult.OK
            Me.Close()
        Else
            MessageBox.Show("Failed to update patient. Please try again.", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        Dim res = MessageBox.Show("Discard changes?", "Cancel", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
        If res = DialogResult.Yes Then
            Me.DialogResult = DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub ShowWarn(msg As String, ctrl As Control)
        MessageBox.Show(msg, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        ctrl.Focus()
    End Sub

    ' ✅ Helper: Allows decimal input with max digits before/after the dot
    Private Sub KeepDecimalNumbers(tb As TextBox, maxDigitsBefore As Integer, maxDigitsAfter As Integer)
        Dim text As String = tb.Text
        Dim caret As Integer = tb.SelectionStart
        Dim cleaned As String = ""
        Dim dotFound As Boolean = False

        For Each c As Char In text
            If Char.IsDigit(c) Then
                cleaned &= c
            ElseIf c = "."c AndAlso Not dotFound Then
                cleaned &= c
                dotFound = True
            End If
        Next

        Dim parts() As String = cleaned.Split("."c)
        Dim beforeDot As String = parts(0)
        Dim afterDot As String = If(parts.Length > 1, parts(1), "")

        If beforeDot.Length > maxDigitsBefore Then beforeDot = beforeDot.Substring(0, maxDigitsBefore)
        If afterDot.Length > maxDigitsAfter Then afterDot = afterDot.Substring(0, maxDigitsAfter)

        cleaned = beforeDot
        If dotFound Then cleaned &= "." & afterDot

        If tb.Text <> cleaned Then
            tb.Text = cleaned
            tb.SelectionStart = Math.Min(caret, tb.Text.Length)
        End If
    End Sub
End Class
