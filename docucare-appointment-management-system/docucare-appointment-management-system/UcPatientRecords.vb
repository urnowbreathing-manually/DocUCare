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

    ' Load patients from DB
    Private Sub LoadPatientsFromDB()
        Try
            patientLayout.Controls.Clear()
            Dim dt As DataTable = db.GetAllPatients()

            If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                For Each row As DataRow In dt.Rows
                    ' --- Safe value extraction with flexible column names ---
                    Dim patientID As String = SafeGet(row, {"patient_id"})
                    Dim fullName As String = SafeGet(row, {"patient_name"})
                    Dim ageStr As String = SafeGet(row, {"age"})
                    Dim heightStr As String = SafeGet(row, {"height"})
                    Dim weightStr As String = SafeGet(row, {"weight"})
                    Dim sexStr As String = SafeGet(row, {"sex"})
                    Dim contactStr As String = SafeGet(row, {"contact"})
                    Dim emergencyContactStr As String = SafeGet(row, {"em_contact"})
                    Dim emContactNameStr As String = SafeGet(row, {"em_contact_name"})
                    ' FIXED: supports both "em_contact_rel" and "em_contact_relationship"
                    Dim emContactRelStr As String = SafeGet(row, {"em_contact_rel", "em_contact_relationship"})
                    Dim bloodTypeStr As String = SafeGet(row, {"blood_type"})
                    Dim allergiesStr As String = SafeGet(row, {"allergies"})
                    Dim medicalConditionsStr As String = SafeGet(row, {"medical_conditions"})

                    ' Split full name for label display
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

                    ' Add patient card with complete info
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
                        emContactNameStr,
                        emContactRelStr,
                        bloodTypeStr,
                        allergiesStr,
                        medicalConditionsStr
                    )
                Next
            Else
                ' No patients found
                Dim noPatientsLabel As New Label()
                noPatientsLabel.Text = "No patient records found."
                noPatientsLabel.Font = New Font("Segoe UI", 12)
                noPatientsLabel.AutoSize = True
                patientLayout.Controls.Add(noPatientsLabel)
            End If
        Catch ex As Exception
            MessageBox.Show("Failed to load patient records: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' Safely get a field by trying multiple possible column names
    Private Function SafeGet(row As DataRow, columnNames As String()) As String
        For Each col In columnNames
            If row.Table.Columns.Contains(col) AndAlso Not row.IsNull(col) Then
                Return Convert.ToString(row(col))
            End If
        Next
        Return ""
    End Function

    ' Back to main menu
    Private Sub NavbarMenu_Click(sender As Object, e As EventArgs) Handles NavbarMenu.Click
        MainContentPanel.Controls.Clear()
        Dim addMainMenu As New UcMainMenu(MainContentPanel)
        addMainMenu.Dock = DockStyle.Fill
        MainContentPanel.Controls.Add(addMainMenu)
    End Sub

    ' Create each patient card
    Public Sub AddPatientCard(patientID As String, firstName As String, lastName As String,
                              age As String, height As String, weight As String,
                              sex As String, contact As String, emergencyContact As String,
                              emContactName As String, emContactRel As String,
                              bloodType As String, allergies As String, medicalConditions As String)

        Dim card As New Panel() With {
            .Width = 220,
            .Height = 100,
            .BackColor = Color.AliceBlue,
            .BorderStyle = BorderStyle.FixedSingle,
            .Margin = New Padding(10)
        }

        Dim lbl As New Label() With {
            .Text = $"{firstName} {lastName}",
            .Font = New Font("Segoe UI", 10, FontStyle.Bold),
            .Dock = DockStyle.Top,
            .Height = 40,
            .TextAlign = ContentAlignment.MiddleCenter
        }

        Dim btnView As New Button() With {
            .Text = "View",
            .Dock = DockStyle.Bottom,
            .Height = 30
        }

        ' Tag data in correct order
        btnView.Tag = String.Join("|", New String() {
            patientID,          ' 0
            firstName,          ' 1
            lastName,           ' 2
            age,                ' 3
            height,             ' 4
            weight,             ' 5
            sex,                ' 6
            contact,            ' 7
            emergencyContact,   ' 8
            emContactName,      ' 9
            emContactRel,       ' 10
            bloodType,          ' 11
            allergies,          ' 12
            medicalConditions   ' 13
        })

        AddHandler btnView.Click, AddressOf ViewPatient_Click

        card.Controls.Add(lbl)
        card.Controls.Add(btnView)

        ' Clear "no patients" label
        If patientLayout.Controls.Count = 1 AndAlso TypeOf patientLayout.Controls(0) Is Label Then
            patientLayout.Controls.Clear()
        End If

        patientLayout.Controls.Add(card)
    End Sub

    ' View patient info
    Private Sub ViewPatient_Click(sender As Object, e As EventArgs)
        Dim btn As Button = CType(sender, Button)
        Dim parts() As String = btn.Tag.ToString().Split("|"c)

        If parts.Length < 14 Then
            MessageBox.Show("Incomplete patient data. Please re-add the patient.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        UcMainMenu.patientInfo = String.Join("|", parts)

        Dim infoForm As New PatientInfo()
        infoForm.ShowDialog()

        LoadPatientsFromDB() ' refresh after close
    End Sub

    Private Sub addPatientBtn_Click(sender As Object, e As EventArgs) Handles addPatientBtn.Click
        Dim addForm As New AddPatient()
        addForm.ShowDialog()
        LoadPatientsFromDB()
    End Sub

    Private Sub patientLayout_Paint(sender As Object, e As PaintEventArgs) Handles patientLayout.Paint
        ' Optional
    End Sub
End Class
