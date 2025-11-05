Imports System.Data
Imports System.Text.RegularExpressions

Public Class EditDoctor
    Private dataRow As DataRow
    Private db As New DBHandler()

    Public Sub New(row As DataRow)
        InitializeComponent()
        dataRow = row
        LoadDoctorData()
    End Sub

    Private Sub LoadDoctorData()
        ' Split full name
        Dim nameParts = dataRow("Personnel_Name").ToString().Split(" "c)
        FirstName.Text = nameParts(0)
        If nameParts.Length > 1 Then LastName.Text = nameParts(1)

        ' Prefill Verification ID
        VerificationID.Text = dataRow("Verified_ID").ToString()

        ' Prefill contact number
        If dataRow.Table.Columns.Contains("ContactNo") Then
            ContactNum.Text = dataRow("ContactNo").ToString()
        End If

        ' Prefill password fields safely
        If dataRow.Table.Columns.Contains("Password") Then
            Password.Text = dataRow("Password").ToString()
            ConfirmPassword.Text = dataRow("Password").ToString()
        End If
    End Sub

    Private Sub SaveBtn_Click(sender As Object, e As EventArgs) Handles SaveBtn.Click
        ' --- VALIDATION ---
        Dim missingFields As New List(Of String)
        If String.IsNullOrWhiteSpace(FirstName.Text) Then missingFields.Add("First Name")
        If String.IsNullOrWhiteSpace(LastName.Text) Then missingFields.Add("Last Name")
        If String.IsNullOrWhiteSpace(VerificationID.Text) Then missingFields.Add("Verification ID")
        If String.IsNullOrWhiteSpace(Password.Text) Then missingFields.Add("Password")
        If String.IsNullOrWhiteSpace(ConfirmPassword.Text) Then missingFields.Add("Confirm Password")

        If missingFields.Count > 0 Then
            MessageBox.Show("Please fill in the following required fields:" & vbCrLf &
                        String.Join(vbCrLf, missingFields),
                        "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If Password.Text <> ConfirmPassword.Text Then
            MessageBox.Show("Passwords do not match.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        ' --- CLEAN INPUTS ---
        FirstName.Text = Regex.Replace(FirstName.Text, "[^a-zA-Z\s]", "")
        LastName.Text = Regex.Replace(LastName.Text, "[^a-zA-Z\s]", "")

        ' --- BUILD SQL & PARAMETERS ---
        Dim fullName = FirstName.Text & " " & LastName.Text

        ' Build update query dynamically depending on columns present
        Dim updateQuery As String = "UPDATE personneltable SET Personnel_Name=@name, Verified_ID=@vid"
        Dim parameters As New Dictionary(Of String, Object) From {
        {"@name", fullName},
        {"@vid", VerificationID.Text},
        {"@id", dataRow("ID")}
    }

        ' Add Password only if column exists
        If dataRow.Table.Columns.Contains("Password") Then
            updateQuery &= ", Password=@pass"
            parameters.Add("@pass", Password.Text)
        End If

        ' Add ContactNo only if column exists
        If dataRow.Table.Columns.Contains("ContactNo") Then
            updateQuery &= ", ContactNo=@contact"
            parameters.Add("@contact", If(ContactNum.Text, ""))
        End If

        updateQuery &= " WHERE ID=@id"

        ' --- EXECUTE ---
        If db.ExecuteNonQueryWithParameters(updateQuery, parameters) Then
            ' Update local DataRow safely
            dataRow("Personnel_Name") = fullName
            dataRow("Verified_ID") = VerificationID.Text
            If dataRow.Table.Columns.Contains("Password") Then dataRow("Password") = Password.Text
            If dataRow.Table.Columns.Contains("ContactNo") Then dataRow("ContactNo") = If(ContactNum.Text, "")

            MessageBox.Show("Doctor info updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Close()
        Else
            MessageBox.Show("Failed to update doctor. Verification ID might already exist or DB error.", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub


    Private Sub Cancel_Click(sender As Object, e As EventArgs) Handles Cancel.Click
        Me.Close()
    End Sub

    ' --- FORCE CONTACT NUMBERS ONLY ---
    Private Sub ContactNum_TextChanged(sender As Object, e As EventArgs) Handles ContactNum.TextChanged
        Dim caret = ContactNum.SelectionStart
        ContactNum.Text = Regex.Replace(ContactNum.Text, "[^\d]", "")
        If ContactNum.Text.Length > 11 Then ContactNum.Text = ContactNum.Text.Substring(0, 11)
        ContactNum.SelectionStart = Math.Min(caret, ContactNum.Text.Length)
    End Sub

    ' --- CLEAN NAMES ---
    Private Sub FirstName_TextChanged(sender As Object, e As EventArgs) Handles FirstName.TextChanged
        Dim caret = FirstName.SelectionStart
        FirstName.Text = Regex.Replace(FirstName.Text, "[^a-zA-Z\s]", "")
        FirstName.SelectionStart = Math.Min(caret, FirstName.Text.Length)
    End Sub

    Private Sub LastName_TextChanged(sender As Object, e As EventArgs) Handles LastName.TextChanged
        Dim caret = LastName.SelectionStart
        LastName.Text = Regex.Replace(LastName.Text, "[^a-zA-Z\s]", "")
        LastName.SelectionStart = Math.Min(caret, LastName.Text.Length)
    End Sub

End Class
