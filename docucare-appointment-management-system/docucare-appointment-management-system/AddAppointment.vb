Public Class AddAppointment
    ' --- ADDED ---
    Private db As New DBHandler()

    ' Helper class to store Patient Name and ID in the ComboBox
    Private Class PatientItem
        Public Property Name As String
        Public Property ID As String
        Public Overrides Function ToString() As String
            ' This is what the user sees in the dropdown
            Return Name & " (ID: " & ID & ")"
        End Function
    End Class

    ' Helper class to store Doctor Name and ID in the ComboBox
    Private Class DoctorItem
        Public Property Name As String
        Public Property ID As String
        Public Overrides Function ToString() As String
            ' This is what the user sees in the dropdown
            Return Name & " (ID: " & ID & ")"
        End Function
    End Class

    ' --- MODIFIED PROPERTIES ---
    ' These properties will pass data *back* to the form that opened this
    Public Property SelectedPatient As String
    Public Property SelectedDoctor As String
    Public Property SelectedDate As String
    Public Property SelectedTime As String
    Public Property SelectedNotes As String
    ' --- NEW PROPERTIES ---
    ' These will store the *IDs* for the database
    Public Property SelectedPatientID As String
    Public Property SelectedDoctorVID As String
    Public Property NewAppointmentID As Integer = -1 ' This will hold the ID of the new appointment

    ' --- MODIFIED FORM LOAD ---
    Private Sub AddAppointment_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' --- Load Patients from DB ---
        patientDropDown.Items.Clear()
        Try
            Dim patientData As DataTable = db.GetAllPatients()
            If patientData IsNot Nothing AndAlso patientData.Rows.Count > 0 Then
                For Each row As DataRow In patientData.Rows
                    patientDropDown.Items.Add(New PatientItem With {
                        .Name = row("patient_name").ToString(),
                        .ID = row("patient_id").ToString()
                    })
                Next
            Else
                patientDropDown.Items.Add("No patients found")
            End If
        Catch ex As Exception
            patientDropDown.Items.Add("Error loading patients")
        End Try
        patientDropDown.DropDownStyle = ComboBoxStyle.DropDownList

        ' --- Load Doctors from DB ---
        doctorDropDown.Items.Clear()
        Try
            Dim doctorData As DataTable = db.GetAllDoctors()
            If doctorData IsNot Nothing AndAlso doctorData.Rows.Count > 0 Then
                For Each row As DataRow In doctorData.Rows
                    doctorDropDown.Items.Add(New DoctorItem With {
                        .Name = row("Personnel_Name").ToString(),
                        .ID = row("Verified_ID").ToString()
                    })
                Next
            Else
                doctorDropDown.Items.Add("No doctors found")
            End If
        Catch ex As Exception
            doctorDropDown.Items.Add("Error loading doctors")
        End Try
        doctorDropDown.DropDownStyle = ComboBoxStyle.DropDownList

        ' Set up date/time pickers
        DateVal.Format = DateTimePickerFormat.Short
        TimeVal.Format = DateTimePickerFormat.Custom
        TimeVal.CustomFormat = "hh:mm tt"
        TimeVal.ShowUpDown = True
    End Sub

    ' --- MODIFIED SAVE BUTTON ---
    Private Sub Save_Click(sender As Object, e As EventArgs) Handles Save.Click
        ' --- Updated Validation ---
        If patientDropDown.SelectedIndex = -1 OrElse Not TypeOf patientDropDown.SelectedItem Is PatientItem Then
            MessageBox.Show("Please select a valid patient.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        If doctorDropDown.SelectedIndex = -1 OrElse Not TypeOf doctorDropDown.SelectedItem Is DoctorItem Then
            MessageBox.Show("Please select a valid doctor.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        If String.IsNullOrWhiteSpace(Notes.Text) Then
            MessageBox.Show("Please add a note or reason for the appointment.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' --- Get selected objects and their IDs ---
        Dim selectedPatientItem As PatientItem = CType(patientDropDown.SelectedItem, PatientItem)
        Dim selectedDoctorItem As DoctorItem = CType(doctorDropDown.SelectedItem, DoctorItem)

        ' --- Store values in public properties ---
        SelectedPatient = selectedPatientItem.Name
        SelectedPatientID = selectedPatientItem.ID
        SelectedDoctor = selectedDoctorItem.Name
        SelectedDoctorVID = selectedDoctorItem.ID
        SelectedDate = DateVal.Value.ToShortDateString()
        SelectedTime = TimeVal.Text
        SelectedNotes = Notes.Text

        ' --- CALL DATABASE ---
        ' InsertAppointment returns the new appointment_id
        ' As requested, consultFee is saved as 0
        Me.NewAppointmentID = db.InsertAppointment(
            SelectedPatient,
            SelectedPatientID,
            SelectedDoctor,
            SelectedDoctorVID,
            SelectedDate,
            SelectedTime,
            "Scheduled", ' Default status
            SelectedNotes,
            0 ' Default fee is 0, as requested
        )

        If Me.NewAppointmentID > 0 Then
            MessageBox.Show("Appointment saved successfully to database.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.DialogResult = DialogResult.OK
            Me.Close()
        Else
            MessageBox.Show("Failed to save appointment to database.", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ' Me.DialogResult = DialogResult.Cancel ' Let user try again
        End If
    End Sub
End Class