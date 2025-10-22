Public Class EditPatientInfo
    ' Public property to hold primary key (patient_id)
    Public Property PatientID As String

    ' Patient info fields (initial values passed from caller)
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
        ' --- populate combos to match AddPatient form ---
        Gender.Items.Clear()
        Gender.Items.Add("Male")
        Gender.Items.Add("Female")
        Gender.Items.Add("Other")
        Gender.Items.Insert(0, "Select Gender")
        Gender.SelectedIndex = 0
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
        BloodType.DropDownStyle = ComboBoxStyle.DropDownList

        ' --- pre-fill values (if provided) ---
        FirstName.Text = TxtFirstName
        LastName.Text = TxtLastName
        Age.Text = TxtAge
        Height.Text = TxtHeight
        Weight.Text = TxtWeight
        Allergies.Text = TxtAllergies
        MedicalConditions.Text = TxtMedicalConditions
        ContactNum.Text = TxtContactNum
        EmergencyContact.Text = TxtEmergencyContact

        ' Set Gender selection if matches an item
        If Not String.IsNullOrWhiteSpace(TxtGender) Then
            Dim gi As Integer = Gender.FindStringExact(TxtGender)
            If gi >= 0 Then
                Gender.SelectedIndex = gi
            Else
                Gender.SelectedIndex = 0
            End If
        End If

        ' Set BloodType selection if matches an item
        If Not String.IsNullOrWhiteSpace(TxtBloodType) Then
            Dim bi As Integer = BloodType.FindStringExact(TxtBloodType)
            If bi >= 0 Then
                BloodType.SelectedIndex = bi
            Else
                BloodType.SelectedIndex = 0
            End If
        End If
    End Sub

    ' --- Live input cleaning to match AddPatient behavior ---

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
        If tb.Text.Length > 3 Then
            tb.Text = tb.Text.Substring(0, 3)
        End If
        tb.SelectionStart = tb.Text.Length
    End Sub

    Private Sub ContactNum_TextChanged(sender As Object, e As EventArgs) Handles ContactNum.TextChanged
        Dim tb As TextBox = DirectCast(sender, TextBox)
        tb.Text = System.Text.RegularExpressions.Regex.Replace(tb.Text, "[^\d]", "")
        If tb.Text.Length > 11 Then
            tb.Text = tb.Text.Substring(0, 11)
        End If
        tb.SelectionStart = tb.Text.Length
    End Sub

    Private Sub Height_TextChanged(sender As Object, e As EventArgs) Handles Height.TextChanged
        Dim tb As TextBox = DirectCast(sender, TextBox)
        tb.Text = System.Text.RegularExpressions.Regex.Replace(tb.Text, "[^\d]", "")
        If tb.Text.Length > 3 Then
            tb.Text = tb.Text.Substring(0, 3)
        End If
        tb.SelectionStart = tb.Text.Length
    End Sub

    Private Sub Weight_TextChanged(sender As Object, e As EventArgs) Handles Weight.TextChanged
        Dim tb As TextBox = DirectCast(sender, TextBox)
        tb.Text = System.Text.RegularExpressions.Regex.Replace(tb.Text, "[^\d]", "")
        If tb.Text.Length > 3 Then
            tb.Text = tb.Text.Substring(0, 3)
        End If
        tb.SelectionStart = tb.Text.Length
    End Sub

    Private Sub EmergencyContact_TextChanged(sender As Object, e As EventArgs) Handles EmergencyContact.TextChanged
        Dim tb As TextBox = DirectCast(sender, TextBox)
        tb.Text = System.Text.RegularExpressions.Regex.Replace(tb.Text, "[^\d]", "")
        If tb.Text.Length > 11 Then
            tb.Text = tb.Text.Substring(0, 11)
        End If
        tb.SelectionStart = tb.Text.Length
    End Sub

    ' Keep combo placeholders from being treated as valid choices (same pattern as AddPatient)
    Private Sub Gender_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Gender.SelectedIndexChanged
        If Gender.SelectedIndex = 0 Then Exit Sub
        ' nothing else required here unless you want to react to change
    End Sub

    Private Sub BloodType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles BloodType.SelectedIndexChanged
        If BloodType.SelectedIndex = 0 Then Exit Sub
        ' nothing else required here
    End Sub

    ' --- Save validation (aligned with AddPatient Save) ---
    Private Sub Save_Click(sender As Object, e As EventArgs) Handles Save.Click
        ' Required: FirstName
        If String.IsNullOrWhiteSpace(FirstName.Text) Then
            MessageBox.Show("First Name is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            FirstName.Focus()
            Exit Sub
        End If

        ' Required: LastName
        If String.IsNullOrWhiteSpace(LastName.Text) Then
            MessageBox.Show("Last Name is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            LastName.Focus()
            Exit Sub
        End If

        ' Required: Age (must be > 0)
        If String.IsNullOrWhiteSpace(Age.Text) Then
            MessageBox.Show("Age is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Age.Focus()
            Exit Sub
        End If
        If Val(Age.Text) <= 0 Then
            MessageBox.Show("Age must be greater than 0.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Age.Focus()
            Exit Sub
        End If

        ' Gender must be selected (index 0 is placeholder)
        If Me.Gender.SelectedIndex = 0 Or Me.Gender.SelectedIndex = -1 Then
            MessageBox.Show("Please select a gender.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Me.Gender.Focus()
            Exit Sub
        End If

        ' BloodType must be selected
        If Me.BloodType.SelectedIndex = 0 Or Me.BloodType.SelectedIndex = -1 Then
            MessageBox.Show("Please select a blood type.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Me.BloodType.Focus()
            Exit Sub
        End If

        ' Contact Number required and must be 11 digits
        If String.IsNullOrWhiteSpace(ContactNum.Text) Then
            MessageBox.Show("Contact no. is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            ContactNum.Focus()
            Exit Sub
        End If
        If ContactNum.Text.Length < 11 Then
            MessageBox.Show("Contact Number must be 11 digits.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            ContactNum.Focus()
            Exit Sub
        End If

        ' Height required and minimal length check (to match AddPatient)
        If String.IsNullOrWhiteSpace(Height.Text) Then
            MessageBox.Show("Height is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Height.Focus()
            Exit Sub
        End If
        If Height.Text.Length < 3 Then
            MessageBox.Show("Invalid Height input, should be 3 digits.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Height.Focus()
            Exit Sub
        End If

        ' Weight required and minimal length check
        If String.IsNullOrWhiteSpace(Weight.Text) Then
            MessageBox.Show("Weight is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Weight.Focus()
            Exit Sub
        End If
        If Weight.Text.Length < 2 Then
            MessageBox.Show("Invalid Weight input, should be at least 2 digits.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Weight.Focus()
            Exit Sub
        End If

        ' Emergency contact required and must be 11 digits
        If String.IsNullOrWhiteSpace(EmergencyContact.Text) Then
            MessageBox.Show("Emergency Contact no. is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            EmergencyContact.Focus()
            Exit Sub
        End If
        If EmergencyContact.Text.Length < 11 Then
            MessageBox.Show("Emergency Contact Number must be 11 digits.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            EmergencyContact.Focus()
            Exit Sub
        End If

        ' Validate PatientID exists before saving
        If String.IsNullOrWhiteSpace(PatientID) Then
            MessageBox.Show("Cannot save patient: missing Patient ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        ' All validation passed — copy trimmed fields back to properties
        TxtFirstName = FirstName.Text.Trim()
        TxtLastName = LastName.Text.Trim()
        TxtAge = Age.Text.Trim()
        TxtGender = If(Gender.SelectedIndex > 0, Gender.SelectedItem.ToString(), "")
        TxtHeight = Height.Text.Trim()
        TxtWeight = Weight.Text.Trim()
        TxtBloodType = If(BloodType.SelectedIndex > 0, BloodType.SelectedItem.ToString(), "")
        TxtAllergies = If(String.IsNullOrWhiteSpace(Allergies.Text), "N/A", Allergies.Text.Trim())
        TxtMedicalConditions = If(String.IsNullOrWhiteSpace(MedicalConditions.Text), "N/A", MedicalConditions.Text.Trim())
        TxtContactNum = ContactNum.Text.Trim()
        TxtEmergencyContact = EmergencyContact.Text.Trim()

        ' Success: close with OK
        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        Dim result As DialogResult = MessageBox.Show(
            "Are you sure you want to cancel? Any unsaved changes will be lost.",
            "Cancel Edit",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Warning
        )
        If result = DialogResult.Yes Then
            Me.DialogResult = DialogResult.Cancel
            Me.Close()
        End If
    End Sub
End Class
