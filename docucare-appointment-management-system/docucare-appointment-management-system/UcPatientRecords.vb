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

    ' --- MODIFIED: This function is now fixed for all data types ---
    Private Sub LoadPatientsFromDB()
        Try
            patientLayout.Controls.Clear() ' Clear existing cards
            Dim dt As DataTable = db.GetAllPatients() ' Assumes this function exists in DBHandler

            If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                For Each row As DataRow In dt.Rows

                    ' --- Read the single 'patient_name' column (String) ---
                    Dim fullName As String = row.Field(Of String)("patient_name")
                    Dim firstName As String = ""
                    Dim lastName As String = ""

                    ' --- Split the full name back into first and last ---
                    Dim firstSpaceIndex As Integer = fullName.IndexOf(" ")
                    If firstSpaceIndex > -1 Then
                        firstName = fullName.Substring(0, firstSpaceIndex)
                        lastName = fullName.Substring(firstSpaceIndex + 1)
                    Else
                        firstName = fullName
                        lastName = ""
                    End If

                    ' --- FIX: Read correct data types and convert to String ---
                    Dim ageStr As String = row.Field(Of Integer)("age").ToString()
                    Dim heightStr As String = row.Field(Of Decimal)("height").ToString()
                    Dim weightStr As String = row.Field(Of Decimal)("weight").ToString()

                    ' --- Read all other fields as String ---
                    Dim sexStr As String = row.Field(Of String)("sex")
                    Dim contactStr As String = row.Field(Of String)("contact")
                    Dim emergencyContactStr As String = row.Field(Of String)("em_contact")
                    Dim bloodTypeStr As String = row.Field(Of String)("blood_type")
                    Dim allergiesStr As String = row.Field(Of String)("allergies")
                    Dim medicalConditionsStr As String = row.Field(Of String)("medical_conditions")

                    ' Call your existing function with all String values
                    AddPatientCard(
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

    ' This function is correct as-is. It receives the data and creates the card.
    Public Sub AddPatientCard(firstName As String, lastName As String,
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

        ' Store all info in Tag (so PatientInfo can read it)
        btnView.Tag = String.Join("|", New String() {
            firstName, lastName, age, height, weight, sex,
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

        If parts.Length < 11 Then
            MessageBox.Show("Incomplete patient data. Please re-add the patient.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        UcMainMenu.patientInfo = String.Join("|", parts)
        Dim infoForm As New PatientInfo()
        infoForm.ShowDialog()
    End Sub

    Private Sub addPatientBtn_Click(sender As Object, e As EventArgs) Handles addPatientBtn.Click
        Dim addForm As New AddPatient()
        addForm.ShowDialog()
        ' Refresh the list after adding a new patient
        LoadPatientsFromDB()
    End Sub
End Class