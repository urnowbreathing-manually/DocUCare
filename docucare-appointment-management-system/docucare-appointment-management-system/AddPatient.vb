Imports System.Security.Cryptography.X509Certificates

Public Class AddPatient


    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Gender.Items.Clear()
        Gender.Items.Add("Male")
        Gender.Items.Add("Female")
        Gender.Items.Insert(0, "Select Gender")
        Gender.SelectedIndex = 0

        ' Make it dropdown only (no typing random text)
        Gender.DropDownStyle = ComboBoxStyle.DropDownList

        BloodType.Items.Clear()
        BloodType.Items.Add("Unknown")
        BloodType.Items.Add("A+")
        BloodType.Items.Add("A-")
        BloodType.Items.Add("B+")
        BloodType.Items.Add("B-")
        BloodType.Items.Add("AB+")
        BloodType.Items.Add("AB-")
        BloodType.Items.Add("O+")
        BloodType.Items.Add("O-")
        BloodType.Items.Insert(0, "Select Blood Type")
        BloodType.SelectedIndex = 0
        ' Make it dropdown only (no typing random text)
        BloodType.DropDownStyle = ComboBoxStyle.DropDownList
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub FirstName_TextChanged(sender As Object, e As EventArgs) Handles FirstName.TextChanged
        Dim tb As TextBox = DirectCast(sender, TextBox)

        ' Remove anything that's not a letter or space
        tb.Text = System.Text.RegularExpressions.Regex.Replace(tb.Text, "[^a-zA-Z\s]", "")

        ' Move cursor to the end (otherwise it jumps back)
        tb.SelectionStart = tb.Text.Length
    End Sub

    Private Sub LastName_TextChanged(sender As Object, e As EventArgs) Handles LastName.TextChanged
        Dim tb As TextBox = DirectCast(sender, TextBox)

        ' Remove anything that's not a letter or space
        tb.Text = System.Text.RegularExpressions.Regex.Replace(tb.Text, "[^a-zA-Z\s]", "")

        ' Move cursor to the end (otherwise it jumps back)
        tb.SelectionStart = tb.Text.Length
    End Sub

    Private Sub Age_TextChanged(sender As Object, e As EventArgs) Handles Age.TextChanged
        Dim tb As TextBox = DirectCast(sender, TextBox)

        ' Keep only digits
        tb.Text = System.Text.RegularExpressions.Regex.Replace(tb.Text, "[^\d]", "")

        ' Limit to 3 characters (e.g., max age 999)
        If tb.Text.Length > 3 Then
            tb.Text = tb.Text.Substring(0, 3)
        End If

        ' Fix cursor position
        tb.SelectionStart = tb.Text.Length
    End Sub

    Private Sub ContactNum_TextChanged(sender As Object, e As EventArgs) Handles ContactNum.TextChanged
        Dim tb As TextBox = DirectCast(sender, TextBox)

        ' Keep only digits
        tb.Text = System.Text.RegularExpressions.Regex.Replace(tb.Text, "[^\d]", "")

        ' Limit to 11 digits (PH mobile format)
        If tb.Text.Length > 11 Then
            tb.Text = tb.Text.Substring(0, 11)
        End If

        ' Keep cursor at the end
        tb.SelectionStart = tb.Text.Length
    End Sub

    'Gender
    Private Sub Gender_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Gender.SelectedIndexChanged
        If Gender.SelectedIndex = 0 Then
            Exit Sub ' ignore placeholder
        End If

        Dim selectedGender As String = Gender.SelectedItem.ToString()
    End Sub

    Private Sub Save_Click(sender As Object, e As EventArgs) Handles Save.Click
        ' Validate First Name
        If String.IsNullOrWhiteSpace(FirstName.Text) Then
            MessageBox.Show("First Name is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            FirstName.Focus()
            Exit Sub
        End If

        ' Validate Last name
        If String.IsNullOrWhiteSpace(LastName.Text) Then
            MessageBox.Show("Last Name is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            LastName.Focus()
            Exit Sub
        End If

        ' Validate Age
        If Val(Age.Text) <= 0 Then
            MessageBox.Show("Age must be greater than 0.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Age.Focus()
            Exit Sub
        End If
        If String.IsNullOrWhiteSpace(Age.Text) Then
            MessageBox.Show("Age is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Age.Focus()
            Exit Sub
        End If

        ' Validate Gender
        If Me.Gender.SelectedIndex = 0 Or Me.Gender.SelectedIndex = -1 Then
            MessageBox.Show("Please select a gender.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Me.Gender.Focus()
            Exit Sub
        End If

        ' Validate Bloodtype
        If Me.BloodType.SelectedIndex = 0 Or Me.BloodType.SelectedIndex = -1 Then
            MessageBox.Show("Please select a blood type.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Me.BloodType.Focus()
            Exit Sub
        End If

        ' Validate Contact Number must be 11
        If String.IsNullOrWhiteSpace(ContactNum.Text) Then
            MessageBox.Show("Contact no. is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            ContactNum.Focus()
            Exit Sub
        End If
        If ContactNum.Text <> "" AndAlso ContactNum.Text.Length < 11 Then
            MessageBox.Show("Contact Number must be 11 digits.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            ContactNum.Focus()
            Exit Sub
        End If

        ' Validate height
        If String.IsNullOrWhiteSpace(Height.Text) Then
            MessageBox.Show("Height is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Height.Focus()
            Exit Sub
        End If
        If Height.Text <> "" AndAlso Height.Text.Length < 3 Then
            MessageBox.Show("Invalid Height input, should be 3 digits.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Height.Focus()
            Exit Sub
        End If

        ' Validate height
        If String.IsNullOrWhiteSpace(Height.Text) Then
            MessageBox.Show("Height is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Height.Focus()
            Exit Sub
        End If
        If Height.Text <> "" AndAlso Height.Text.Length < 2 Then
            MessageBox.Show("Invalid Weight input, should be atleast 2 digits.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Weight.Focus()
            Exit Sub
        End If

        ' Validate EMERGENyc Contact Number must be 11
        If String.IsNullOrWhiteSpace(EmergencyContact.Text) Then
            MessageBox.Show("Emergency Contact no. is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            EmergencyContact.Focus()
            Exit Sub
        End If
        If EmergencyContact.Text <> "" AndAlso EmergencyContact.Text.Length < 11 Then
            MessageBox.Show("Contact Number must be 11 digits.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            EmergencyContact.Focus()
            Exit Sub
        End If

        ' 
        Dim fname As String = FirstName.Text
        Dim lname As String = LastName.Text
        Dim ageVal As String = Age.Text
        Dim heightVal As String = Height.Text
        Dim weightVal As String = Weight.Text
        Dim gender As String = Me.Gender.SelectedItem.ToString()
        Dim contact As String = ContactNum.Text
        Dim emcontact As String = EmergencyContact.Text
        Dim bloodTypeVal As String = BloodType.Text
        Dim allergiesVal As String = If(String.IsNullOrWhiteSpace(Allergies.Text), "N/A", Allergies.Text)
        Dim medConditionVal As String = If(String.IsNullOrWhiteSpace(MedicalConditions.Text), "N/A", MedicalConditions.Text)


        UcMainMenu.patientInfo = UcMainMenu.patientInfo.Join("|", fname, lname, ageVal, heightVal, weightVal, gender, contact, emcontact, bloodTypeVal, allergiesVal, medConditionVal)
        MsgBox(UcMainMenu.patientInfo)


        ' After the validation success message box
        MessageBox.Show("Patient Saved Successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

        ' === Find the active UcPatientRecords control ===
        For Each ctrl As Control In UcMainMenu.MainContentPanel.Controls
            If TypeOf ctrl Is UcPatientRecords Then
                Dim recordsControl As UcPatientRecords = DirectCast(ctrl, UcPatientRecords)
                recordsControl.AddPatientCard(fname, lname)
                Exit For
            End If
        Next

        ' Close the AddPatient form
        Me.Close()


        'UcMainMenu.MainContentPanel.Controls.Clear()
        'Dim patientInfo As New UcPatientInfo(UcMainMenu.MainContentPanel)
        'patientInfo.Dock = DockStyle.Fill
        'UcMainMenu.MainContentPanel.Controls.Add(patientInfo)

    End Sub

    Private Sub Height_TextChanged(sender As Object, e As EventArgs) Handles Height.TextChanged
        Dim tb As TextBox = DirectCast(sender, TextBox)

        ' Keep only digits
        tb.Text = System.Text.RegularExpressions.Regex.Replace(tb.Text, "[^\d]", "")

        ' Limit to 3 digits
        If tb.Text.Length > 3 Then
            tb.Text = tb.Text.Substring(0, 3)
        End If

        ' Keep cursor at the end
        tb.SelectionStart = tb.Text.Length
    End Sub

    Private Sub BloodType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles BloodType.SelectedIndexChanged
        If BloodType.SelectedIndex = 0 Then
            Exit Sub ' ignore placeholder
        End If

        Dim selectedBloodType As String = BloodType.SelectedItem.ToString()
    End Sub

    Private Sub EmergencyContact_TextChanged(sender As Object, e As EventArgs) Handles EmergencyContact.TextChanged
        Dim tb As TextBox = DirectCast(sender, TextBox)

        ' Keep only digits
        tb.Text = System.Text.RegularExpressions.Regex.Replace(tb.Text, "[^\d]", "")

        ' Limit to 11 digits (PH mobile format)
        If tb.Text.Length > 11 Then
            tb.Text = tb.Text.Substring(0, 11)
        End If

        ' Keep cursor at the end
        tb.SelectionStart = tb.Text.Length
    End Sub

    Private Sub Weight_TextChanged(sender As Object, e As EventArgs) Handles Weight.TextChanged
        Dim tb As TextBox = DirectCast(sender, TextBox)

        ' Keep only digits
        tb.Text = System.Text.RegularExpressions.Regex.Replace(tb.Text, "[^\d]", "")

        ' Limit to 3 digits
        If tb.Text.Length > 3 Then
            tb.Text = tb.Text.Substring(0, 3)
        End If

        ' Keep cursor at the end
        tb.SelectionStart = tb.Text.Length
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim result As DialogResult = MessageBox.Show(
        "Are you sure you want to cancel? Any unsaved information will be lost.",
        "Exit Application",
        MessageBoxButtons.YesNo,
        MessageBoxIcon.Warning
    )
        If result = DialogResult.Yes Then
            Me.Close() ' closes the Add Patient form
        End If
    End Sub



End Class