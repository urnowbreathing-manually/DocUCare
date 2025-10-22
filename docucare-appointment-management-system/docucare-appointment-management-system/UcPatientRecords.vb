Imports System.Data

Public Class UcPatientRecords
    Private MainContentPanel As Panel
    Private db As New DBHandler() ' Database handler instance

    ' Constructor receives parent panel
    Public Sub New(parent As Panel)
        InitializeComponent()
        MainContentPanel = parent
    End Sub

    ' Load event to populate patient list
    Private Sub UcPatientRecords_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadPatientsFromDB()
    End Sub

    ' --- FIXED: robust DB reading and include patient_id in Tag ---
    Private Sub LoadPatientsFromDB()
        Try
            patientLayout.Controls.Clear() ' Clear existing cards
            Dim dt As DataTable = db.GetAllPatients() ' Assumes this function exists in DBHandler

            If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                For Each row As DataRow In dt.Rows
                    ' Safely get columns (handle DBNull)
                    Dim patientID As String = If(row.Table.Columns.Contains("patient_id") AndAlso Not row.IsNull("patient_id"), Convert.ToString(row("patient_id")), "")
                    Dim fullName As String = If(row.Table.Columns.Contains("patient_name") AndAlso Not row.IsNull("patient_name"), Convert.ToString(row("patient_name")), "")
                    Dim ageStr As String = If(row.Table.Columns.Contains("age") AndAlso Not row.IsNull("age"), Convert.ToString(row("age")), "")
                    Dim heightStr As String = If(row.Table.Columns.Contains("height") AndAlso Not row.IsNull("height"), Convert.ToString(row("height")), "")
                    Dim weightStr As String = If(row.Table.Columns.Contains("weight") AndAlso Not row.IsNull("weight"), Convert.ToString(row("weight")), "")
                    Dim sexStr As String = If(row.Table.Columns.Contains("sex") AndAlso Not row.IsNull("sex"), Convert.ToString(row("sex")), "")
                    Dim contactStr As String = If(row.Table.Columns.Contains("contact") AndAlso Not row.IsNull("contact"), Convert.ToString(row("contact")), "")
                    Dim emergencyContactStr As String = If(row.Table.Columns.Contains("em_contact") AndAlso Not row.IsNull("em_contact"), Convert.ToString(row("em_contact")), "")
                    Dim bloodTypeStr As String = If(row.Table.Columns.Contains("blood_type") AndAlso Not row.IsNull("blood_type"), Convert.ToString(row("blood_type")), "")
                    Dim allergiesStr As String = If(row.Table.Columns.Contains("allergies") AndAlso Not row.IsNull("allergies"), Convert.ToString(row("allergies")), "")
                    Dim medicalConditionsStr As String = If(row.Table.Columns.Contains("medical_conditions") AndAlso Not row.IsNull("medical_conditions"), Convert.ToString(row("medical_conditions")), "")

                    ' Split full name into first/last for display
                    Dim firstName As String = ""
                    Dim lastName As String = ""
                    Dim firstSpaceIndex As Integer = fullName.IndexOf(" "c)
                    If firstSpaceIndex > -1 Then
                        firstName = fullName.Substring(0, firstSpaceIndex)
                        lastName = fullName.Substring(firstSpaceIndex + 1)
                    Else
                        firstName = fullName
                        lastName = ""
                    End If

                    ' Call AddPatientCard now with patientID included
                    AddPatientCard(
                        patientID,
                        firstName,
                        lastName,
                        ageStr,
                        heightStr,
                        weightStr,
                        sexStr,
                        contactStr,
                        emergencyContactStr,
                        bloodTypeStr,
                        allergiesStr,
                        medicalConditionsStr
                    )
                Next
            Else
                ' Optional: Display a message if no patients are found
                Dim noPatientsLabel As New Label()
                noPatientsLabel.Text = "No patient records found."
                noPatientsLabel.Font = New Font("Segoe UI", 12)
                noPatientsLabel.AutoSize = True
                patientLayout.Controls.Add(noPatientsLabel)
            End If
        Catch ex As Exception
            ' Show the specific error message
            MessageBox.Show("Failed to load patient records: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    ' --- END MODIFICATION ---

    Private Sub NavbarMenu_Click(sender As Object, e As EventArgs) Handles NavbarMenu.Click
        MainContentPanel.Controls.Clear()
        Dim addMainMenu As New UcMainMenu(MainContentPanel)
        addMainMenu.Dock = DockStyle.Fill
        MainContentPanel.Controls.Add(addMainMenu)
    End Sub

    ' This function receives the data and creates the card.
    ' NOTE: first parameter now is patientID and it is stored as the first element in Tag
    Public Sub AddPatientCard(patientID As String, firstName As String, lastName As String,
                              age As String, height As String, weight As String,
                              sex As String, contact As String, emergencyContact As String,
                              bloodType As String, allergies As String, medicalConditions As String)

        ' === Create main card ===
        Dim card As New Panel()
        card.Width = 220
        card.Height = 100
        card.BackColor = Color.AliceBlue
        card.BorderStyle = BorderStyle.FixedSingle
        card.Margin = New Padding(10)

        ' === Label for patient name ===
        Dim lbl As New Label()
        lbl.Text = $"{firstName} {lastName}"
        lbl.Font = New Font("Segoe UI", 10, FontStyle.Bold)
        lbl.Dock = DockStyle.Top
        lbl.Height = 40
        lbl.TextAlign = ContentAlignment.MiddleCenter

        ' === View button ===
        Dim btnView As New Button()
        btnView.Text = "View"
        btnView.Dock = DockStyle.Bottom
        btnView.Height = 30

        ' Store all info in Tag (patientID is first)
        btnView.Tag = String.Join("|", New String() {
            patientID, firstName, lastName, age, height, weight, sex,
            contact, emergencyContact, bloodType, allergies, medicalConditions
        })

        ' === Add event handler for view button ===
        AddHandler btnView.Click, AddressOf ViewPatient_Click

        ' === Add controls to card ===
        card.Controls.Add(lbl)
        card.Controls.Add(btnView)

        ' === Add card to FlowLayoutPanel ===
        ' Check if a "No patients" label is present and remove it
        If patientLayout.Controls.Count = 1 AndAlso TypeOf patientLayout.Controls(0) Is Label Then
            patientLayout.Controls.Clear()
        End If
        patientLayout.Controls.Add(card)
    End Sub

    Private Sub ViewPatient_Click(sender As Object, e As EventArgs)
        Dim btn As Button = CType(sender, Button)
        Dim parts() As String = btn.Tag.ToString().Split("|"c)

        ' We expect 12 parts with patient_id included
        If parts.Length < 12 Then
            MessageBox.Show("Incomplete patient data. Please re-add the patient.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Set global patientInfo (same format used by PatientInfo/Editor)
        UcMainMenu.patientInfo = String.Join("|", parts)

        Dim infoForm As New PatientInfo()
        infoForm.ShowDialog()

        ' After the dialog closes, reload the list to reflect possible updates
        LoadPatientsFromDB()
    End Sub

    Private Sub addPatientBtn_Click(sender As Object, e As EventArgs) Handles addPatientBtn.Click
        Dim addForm As New AddPatient()
        addForm.ShowDialog()
        ' Refresh the list after adding a new patient
        LoadPatientsFromDB()
    End Sub
End Class
