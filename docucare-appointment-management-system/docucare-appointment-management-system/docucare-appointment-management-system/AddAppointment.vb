Public Class AddAppointment
    Public Property SelectedPatient As String
    Public Property SelectedDoctor As String
    Public Property SelectedDate As String
    Public Property SelectedTime As String
    Public Property SelectedNotes As String

    Private Sub AddAppointment_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Fill dropdowns
        patientDropDown.Items.AddRange(New String() {
            "patient1", "patient2", "patient3"
        })
        patientDropDown.DropDownStyle = ComboBoxStyle.DropDownList

        doctorDropDown.Items.AddRange(New String() {
            "dctr1", "doctor2", "doctor 3"
        })
        doctorDropDown.DropDownStyle = ComboBoxStyle.DropDownList

        ' Set up date/time pickers
        DateVal.Format = DateTimePickerFormat.Short
        TimeVal.Format = DateTimePickerFormat.Custom
        TimeVal.CustomFormat = "hh:mm tt"
        TimeVal.ShowUpDown = True
    End Sub

    Private Sub Save_Click(sender As Object, e As EventArgs) Handles Save.Click
        ' Validation
        If String.IsNullOrWhiteSpace(patientDropDown.Text) OrElse
           String.IsNullOrWhiteSpace(doctorDropDown.Text) OrElse
           String.IsNullOrWhiteSpace(Notes.Text) Then
            MessageBox.Show("Please fill out all required fields.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Pass values to main form
        SelectedPatient = patientDropDown.Text
        SelectedDoctor = doctorDropDown.Text
        SelectedDate = DateVal.Value.ToShortDateString()
        SelectedTime = TimeVal.Text
        SelectedNotes = Notes.Text

        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub
End Class
