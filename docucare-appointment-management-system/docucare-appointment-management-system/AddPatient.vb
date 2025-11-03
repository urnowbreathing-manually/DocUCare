Imports System.Security.Cryptography.X509Certificates
Imports System.Globalization

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

    ' --- Numeric TextBoxes (integers) ---
    Private Sub ContactNum_TextChanged(sender As Object, e As EventArgs) Handles ContactNum.TextChanged
        KeepNumbersOnly(DirectCast(sender, TextBox), 11)
    End Sub

    Private Sub EmergencyContact_TextChanged(sender As Object, e As EventArgs) Handles EmergencyContact.TextChanged
        KeepNumbersOnly(DirectCast(sender, TextBox), 11)
    End Sub

    Private Sub Height_TextChanged(sender As Object, e As EventArgs) Handles Height.TextChanged
        KeepDecimalNumbers(DirectCast(sender, TextBox), 3, 2)
    End Sub

    ' --- Decimal TextBoxes (age, weight) ---
    Private Sub Age_TextChanged(sender As Object, e As EventArgs) Handles Age.TextChanged
        ' allow up to 3 digits before decimal and up to 2 after
        KeepDecimalNumbers(DirectCast(sender, TextBox), 3, 2)
    End Sub

    Private Sub Weight_TextChanged(sender As Object, e As EventArgs) Handles Weight.TextChanged
        ' allow up to 3 digits before decimal and up to 2 after
        KeepDecimalNumbers(DirectCast(sender, TextBox), 3, 2)
    End Sub

    ' --- Utility for whole numbers ---
    Private Sub KeepNumbersOnly(tb As TextBox, maxLength As Integer)
        Dim caret As Integer = tb.SelectionStart
        tb.Text = System.Text.RegularExpressions.Regex.Replace(tb.Text, "[^\d]", "")
        If tb.Text.Length > maxLength Then
            tb.Text = tb.Text.Substring(0, maxLength)
        End If
        tb.SelectionStart = Math.Min(caret, tb.Text.Length)
    End Sub

    ' --- Utility for decimals: enforces max digits before and after decimal ---
    Private Sub KeepDecimalNumbers(tb As TextBox, maxDigitsBefore As Integer, maxDigitsAfter As Integer)
        Dim text As String = tb.Text
        Dim caret As Integer = tb.SelectionStart

        ' Keep only digits and the first decimal point
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

        ' Split parts around decimal
        Dim parts() As String = cleaned.Split("."c)
        Dim beforeDot As String = parts(0)
        Dim afterDot As String = If(parts.Length > 1, parts(1), "")

        ' Limit digits before and after decimal
        If beforeDot.Length > maxDigitsBefore Then
            beforeDot = beforeDot.Substring(0, maxDigitsBefore)
        End If
        If afterDot.Length > maxDigitsAfter Then
            afterDot = afterDot.Substring(0, maxDigitsAfter)
        End If

        ' Rebuild cleaned string
        cleaned = beforeDot
        If dotFound Then cleaned &= "." & afterDot

        ' Update textbox if changed
        If tb.Text <> cleaned Then
            tb.Text = cleaned
            tb.SelectionStart = Math.Min(caret, tb.Text.Length)
        End If
    End Sub


    ' --- SAVE BUTTON ---
    Private Sub Save_Click(sender As Object, e As EventArgs) Handles Save.Click
        ' === VALIDATION SECTION ===
        If String.IsNullOrWhiteSpace(FirstName.Text) Then ShowWarn("First Name is required.", FirstName) : Exit Sub
        If String.IsNullOrWhiteSpace(LastName.Text) Then ShowWarn("Last Name is required.", LastName) : Exit Sub

        ' Age validation (decimal allowed, up to 3 digits before, 2 after)
        Dim ageDecimal As Decimal
        If String.IsNullOrWhiteSpace(Age.Text) Then
            ShowWarn("Age is required.", Age) : Exit Sub
        ElseIf Not Decimal.TryParse(Age.Text, NumberStyles.Number, CultureInfo.InvariantCulture, ageDecimal) Then
            ShowWarn("Age must be a number (format xxx or xxx.xx).", Age) : Exit Sub
        ElseIf ageDecimal <= 0D Then
            ShowWarn("Age must be greater than 0.", Age) : Exit Sub
        ElseIf ageDecimal >= 130D Then
            ShowWarn("Age seems too large.", Age) : Exit Sub
        End If

        If Gender.SelectedIndex <= 0 Then ShowWarn("Please select a gender.", Gender) : Exit Sub
        If BloodType.SelectedIndex <= 0 Then ShowWarn("Please select a blood type.", BloodType) : Exit Sub

        If String.IsNullOrWhiteSpace(ContactNum.Text) Then ShowWarn("Contact number is required.", ContactNum) : Exit Sub
        If ContactNum.Text.Length < 11 Then ShowWarn("Contact number must be 11 digits.", ContactNum) : Exit Sub

        If String.IsNullOrWhiteSpace(Height.Text) Then ShowWarn("Height is required.", Height) : Exit Sub
        If Height.Text.Length < 3 Then ShowWarn("Invalid height. Must be 3 digits.", Height) : Exit Sub

        ' Weight validation (decimal allowed)
        Dim weightDecimal As Decimal
        If String.IsNullOrWhiteSpace(Weight.Text) Then
            ShowWarn("Weight is required.", Weight) : Exit Sub
        ElseIf Not Decimal.TryParse(Weight.Text, NumberStyles.Number, CultureInfo.InvariantCulture, weightDecimal) Then
            ShowWarn("Weight must be a number (format xxx or xxx.xx).", Weight) : Exit Sub
        ElseIf weightDecimal <= 0D Then
            ShowWarn("Weight must be greater than 0.", Weight) : Exit Sub
        End If

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

        Dim fullName As String = FirstName.Text.Trim() & " " & LastName.Text.Trim()
        Dim pAge As Decimal = Math.Round(ageDecimal, 2)
        Dim pSex As String = Gender.SelectedItem.ToString()
        Dim pContact As String = ContactNum.Text.Trim()
        Dim pEmContact As String = EmergencyContact.Text.Trim()
        Dim pBloodType As String = BloodType.SelectedItem.ToString()
        Dim pAllergies As String = If(String.IsNullOrWhiteSpace(Allergies.Text), "N/A", Allergies.Text.Trim())
        Dim pMedConditions As String = If(String.IsNullOrWhiteSpace(MedicalConditions.Text), "N/A", MedicalConditions.Text.Trim())
        Dim heightVal As String = Height.Text.Trim()

        ' Format weight and age to exactly two decimals for storage & display (xxx.xx)
        Dim weightValStr As String = Math.Round(weightDecimal, 2).ToString("0.00", CultureInfo.InvariantCulture)
        Dim ageValStr As String = pAge.ToString("0.00", CultureInfo.InvariantCulture)

        Dim pEmContactName As String = EmContactName.Text.Trim()
        Dim pEmContactRel As String = EmContactRel.SelectedItem.ToString()

        ' --- INSERT PATIENT ---
        ' Note: ensure your DBHandler.InsertPatient signature supports decimals/strings for age/weight.
        ' If your InsertPatient expects Integer for age you must update DBHandler accordingly.
        If db.InsertPatient(
            pID,
            fullName,
            pAge,                    ' decimal age - DB handler must accept numeric types
            pSex,
            pContact,
            pEmContact,
            pEmContactName,
            pEmContactRel,
            pBloodType,
            pAllergies,
            pMedConditions,
            heightVal,
            weightValStr
        ) Then

            MessageBox.Show($"Patient saved successfully!{vbCrLf}New Patient ID: {pID}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

            ' Update UcPatientRecords dynamically if loaded
            For Each ctrl As Control In UcMainMenu.MainContentPanel.Controls
                If TypeOf ctrl Is UcPatientRecords Then
                    ' pass the formatted age/weight strings to the UI
                    DirectCast(ctrl, UcPatientRecords).AddPatientCard(
                        pID,
                        FirstName.Text.Trim(),
                        LastName.Text.Trim(),
                        ageValStr,            ' age with 2 decimals
                        heightVal,
                        weightValStr,         ' weight with 2 decimals
                        pSex,
                        pContact,
                        pEmContact,
                        pEmContactName,
                        pEmContactRel,
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
        ' Nothing yet
    End Sub
End Class
