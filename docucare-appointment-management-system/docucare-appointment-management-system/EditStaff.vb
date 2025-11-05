Imports System.Data
Imports System.Text.RegularExpressions

Public Class EditStaff
    Private dataRow As DataRow
    Private db As New DBHandler()

    Public Sub New(row As DataRow)
        InitializeComponent()
        dataRow = row
        LoadStaffData()
    End Sub

    Private Sub LoadStaffData()
        ' Split full name
        Dim nameParts = dataRow("Personnel_Name").ToString().Split(" "c)
        FirstName.Text = nameParts(0)
        If nameParts.Length > 1 Then LastName.Text = nameParts(1)

        ' Prefill Verification ID
        VerificationID.Text = dataRow("Verified_ID").ToString()

        ' Prefill password fields
        If dataRow.Table.Columns.Contains("Password") Then
            Password.Text = dataRow("Password").ToString()
            ConfirmPassword.Text = dataRow("Password").ToString()
        End If
    End Sub

    Private Sub EditStaffBtn_Click(sender As Object, e As EventArgs) Handles EditStaffBtn.Click
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
        Dim updateQuery As String = "UPDATE personneltable SET Personnel_Name=@name, Verified_ID=@vid"
        Dim parameters As New Dictionary(Of String, Object) From {
        {"@name", fullName},
        {"@vid", VerificationID.Text},
        {"@id", dataRow("ID")}
    }

        ' Include Password only if column exists
        If dataRow.Table.Columns.Contains("Password") Then
            updateQuery &= ", Password=@pass"
            parameters.Add("@pass", Password.Text)
        End If

        updateQuery &= " WHERE ID=@id"

        ' --- EXECUTE ---
        If db.ExecuteNonQueryWithParameters(updateQuery, parameters) Then
            ' Update local DataRow safely
            dataRow("Personnel_Name") = fullName
            dataRow("Verified_ID") = VerificationID.Text
            If dataRow.Table.Columns.Contains("Password") Then dataRow("Password") = Password.Text

            MessageBox.Show("Staff info updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Close()
        Else
            MessageBox.Show("Failed to update staff. Verification ID might already exist or DB error.", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub


    Private Sub Cancel_Click(sender As Object, e As EventArgs) Handles Cancel.Click
        Me.Close()
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
