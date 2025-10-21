Public Class Prescriptions
    Public Property SelectedMedicine As String
    Public Property SelectedDose As String
    Public Property SelectedDuration As String
    Public Property SelectedFrequency As String

    Private Sub Prescriptions_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Fill medicine dropdown
        Medicine.Items.AddRange(New String() {
            "Paracetamol",
            "Ibuprofen",
            "Amoxicillin",
            "Cephalexin",
            "Azithromycin",
            "Ciprofloxacin",
            "Metformin",
            "Lisinopril",
            "Cetirizine",
            "Loratadine",
            "Omeprazole",
            "Ranitidine",
            "Salbutamol",
            "Hydrocortisone cream",
            "Loperamide"
        })
        Medicine.DropDownStyle = ComboBoxStyle.DropDownList
    End Sub

    ' Save
    ' Save
    Private Sub buttonSave_Click(sender As Object, e As EventArgs) Handles buttonSave.Click
        ' Check if medicine or dose fields are empty
        If String.IsNullOrWhiteSpace(Medicine.Text) OrElse String.IsNullOrWhiteSpace(Dose.Text) Then
            MessageBox.Show("Please complete all fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Check if Duration or Frequency are zero
        If Duration.Value = 0 Then
            MessageBox.Show("Duration cannot be zero.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Duration.Focus()
            Return
        End If

        If Frequency.Value = 0 Then
            MessageBox.Show("Frequency cannot be zero.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Frequency.Focus()
            Return
        End If

        ' Save values
        SelectedMedicine = Medicine.Text
        SelectedDose = Dose.Text
        SelectedDuration = Duration.Value.ToString()
        SelectedFrequency = Frequency.Value.ToString()

        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub


    ' Cancel
    Private Sub ButtonCancel_Click(sender As Object, e As EventArgs) Handles ButtonCancel.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

    ' Numeric input only for Dose
    Private Sub Dose_TextChanged(sender As Object, e As EventArgs)
        Dim tb As TextBox = DirectCast(sender, TextBox)
        tb.Text = System.Text.RegularExpressions.Regex.Replace(tb.Text, "[^\d]", "")
        If tb.Text.Length > 3 Then tb.Text = tb.Text.Substring(0, 3)
        tb.SelectionStart = tb.Text.Length
    End Sub

    Private Sub Frequency_ValueChanged(sender As Object, e As EventArgs) Handles Frequency.ValueChanged

    End Sub
End Class
