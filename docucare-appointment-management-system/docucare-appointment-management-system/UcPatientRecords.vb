Imports System.Data
Imports System.Linq

Public Class UcPatientRecords
    Private MainContentPanel As Panel
    Private db As New DBHandler()
    Private allPatients As DataTable

    Public Sub New(parent As Panel)
        InitializeComponent()
        MainContentPanel = parent
    End Sub

    Private Sub UcPatientRecords_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Initialize sort combo options
        sortComboBox.Items.Clear()
        sortComboBox.Items.AddRange({
            "Name (A–Z)",
            "Name (Z–A)",
            "Age (Young → Old)",
            "Age (Old → Young)",
            "Patient ID (Ascending)",
            "Patient ID (Descending)"
        })
        sortComboBox.SelectedIndex = 0 ' Default sort A–Z
        sortComboBox.DropDownStyle = ComboBoxStyle.DropDownList
        LoadPatientsFromDB()
    End Sub

    Private Sub LoadPatientsFromDB()
        Try
            allPatients = db.GetAllPatients()
            ApplySearchAndSort()
        Catch ex As Exception
            MessageBox.Show("Failed to load patient records: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' --- MAIN FUNCTION TO HANDLE SEARCH + SORT TOGETHER ---
    Private Sub ApplySearchAndSort()
        If allPatients Is Nothing Then Exit Sub

        Dim keyword As String = searchTextBox.Text.Trim().ToLower()
        Dim filteredTable As DataTable

        ' 🔍 Filter by search
        If keyword = "" Then
            filteredTable = allPatients.Copy()
        Else
            Dim filteredRows = allPatients.AsEnumerable().Where(Function(r) r.Field(Of String)("patient_name").ToLower().Contains(keyword))
            If filteredRows.Any() Then filteredTable = filteredRows.CopyToDataTable() Else filteredTable = allPatients.Clone()
        End If


        ' 🔢 Apply sorting
        If filteredTable.Rows.Count > 0 Then
            Dim sortedView As DataView = filteredTable.DefaultView
            Select Case sortComboBox.SelectedItem.ToString()
                Case "Name (A–Z)"
                    sortedView.Sort = "patient_name ASC"
                Case "Name (Z–A)"
                    sortedView.Sort = "patient_name DESC"
                Case "Age (Young → Old)"
                    sortedView.Sort = "age ASC"
                Case "Age (Old → Young)"
                    sortedView.Sort = "age DESC"
                Case "Patient ID (Ascending)"
                    sortedView.Sort = "patient_id ASC"
                Case "Patient ID (Descending)"
                    sortedView.Sort = "patient_id DESC"
            End Select
            filteredTable = sortedView.ToTable()
        End If

        ' Display results
        DisplayPatients(filteredTable)
    End Sub

    ' --- SEARCH TRIGGER ---
    Private Sub searchTextBox_TextChanged(sender As Object, e As EventArgs) Handles searchTextBox.TextChanged
        ApplySearchAndSort()
    End Sub

    ' --- SORT TRIGGER ---
    Private Sub sortComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles sortComboBox.SelectedIndexChanged
        ApplySearchAndSort()
    End Sub

    ' --- DISPLAY PATIENT CARDS ---
    Private Sub DisplayPatients(dt As DataTable)
        patientLayout.Controls.Clear()

        If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
            For Each row As DataRow In dt.Rows
                Dim patientID As String = SafeGet(row, {"patient_id"})
                Dim fullName As String = SafeGet(row, {"patient_name"})
                Dim ageStr As String = SafeGet(row, {"age"})
                Dim heightStr As String = SafeGet(row, {"height"})
                Dim weightStr As String = SafeGet(row, {"weight"})
                Dim sexStr As String = SafeGet(row, {"sex"})
                Dim contactStr As String = SafeGet(row, {"contact"})
                Dim emergencyContactStr As String = SafeGet(row, {"em_contact"})
                Dim emContactNameStr As String = SafeGet(row, {"em_contact_name"})
                Dim emContactRelStr As String = SafeGet(row, {"em_contact_rel", "em_contact_relationship"})
                Dim bloodTypeStr As String = SafeGet(row, {"blood_type"})
                Dim allergiesStr As String = SafeGet(row, {"allergies"})
                Dim medicalConditionsStr As String = SafeGet(row, {"medical_conditions"})

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

                AddPatientCard(
                    patientID, firstName, lastName, ageStr, heightStr, weightStr,
                    sexStr, contactStr, emergencyContactStr, emContactNameStr,
                    emContactRelStr, bloodTypeStr, allergiesStr, medicalConditionsStr
                )
            Next
        Else
            Dim noPatientsLabel As New Label() With {
                .Text = "No patient records found.",
                .Font = New Font("Segoe UI", 12),
                .AutoSize = True
            }
            patientLayout.Controls.Add(noPatientsLabel)
        End If
    End Sub

    Private Function SafeGet(row As DataRow, columnNames As String()) As String
        For Each col In columnNames
            If row.Table.Columns.Contains(col) AndAlso Not row.IsNull(col) Then
                Return Convert.ToString(row(col))
            End If
        Next
        Return ""
    End Function

    Private Sub NavbarMenu_Click(sender As Object, e As EventArgs) Handles NavbarMenu.Click
        MainContentPanel.Controls.Clear()
        Dim addMainMenu As New UcMainMenu(MainContentPanel)
        addMainMenu.Dock = DockStyle.Fill
        MainContentPanel.Controls.Add(addMainMenu)
    End Sub

    Public Sub AddPatientCard(patientID As String, firstName As String, lastName As String,
                          age As String, height As String, weight As String,
                          sex As String, contact As String, emergencyContact As String,
                          emContactName As String, emContactRel As String,
                          bloodType As String, allergies As String, medicalConditions As String)

        Dim card As New Panel() With {
        .Width = 220,
        .Height = 130,
        .BackColor = Color.AliceBlue,
        .BorderStyle = BorderStyle.FixedSingle,
        .Margin = New Padding(10)
    }

        ' 🔹 Full Name Label
        Dim lblName As New Label() With {
        .Text = $"{firstName} {lastName}",
        .Font = New Font("Segoe UI", 10, FontStyle.Bold),
        .Dock = DockStyle.Top,
        .Height = 35,
        .TextAlign = ContentAlignment.MiddleCenter
    }

        ' 🔹 Patient Info (ID + Age)
        Dim lblInfo As New Label() With {
        .Text = $"Patient ID: {patientID}" & vbCrLf & $"Age: {age}",
        .Font = New Font("Segoe UI", 9, FontStyle.Regular),
        .Dock = DockStyle.Top,
        .Height = 40,
        .TextAlign = ContentAlignment.MiddleCenter
    }

        ' 🔹 View Button
        Dim btnView As New Button() With {
        .Text = "View",
        .Dock = DockStyle.Bottom,
        .Height = 30
    }

        btnView.Tag = String.Join("|", New String() {
        patientID, firstName, lastName, age, height, weight,
        sex, contact, emergencyContact, emContactName,
        emContactRel, bloodType, allergies, medicalConditions
    })

        AddHandler btnView.Click, AddressOf ViewPatient_Click

        ' Add controls in order
        card.Controls.Add(lblInfo)
        card.Controls.Add(lblName)
        card.Controls.Add(btnView)

        ' Remove "no patients" label if present
        If patientLayout.Controls.Count = 1 AndAlso TypeOf patientLayout.Controls(0) Is Label Then
            patientLayout.Controls.Clear()
        End If

        patientLayout.Controls.Add(card)
    End Sub


    Private Sub ViewPatient_Click(sender As Object, e As EventArgs)
        Dim btn As Button = CType(sender, Button)
        Dim parts() As String = btn.Tag.ToString().Split("|"c)
        If parts.Length < 14 Then
            MessageBox.Show("Incomplete patient data.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        'debug messagebox
        'MessageBox.Show(String.Join(vbCrLf, parts), "Debug: Passed Values")
        UcMainMenu.patientInfo = String.Join("|", parts)

        Dim infoForm As New PatientInfo()
        infoForm.ShowDialog()

        LoadPatientsFromDB()
    End Sub

    Private Sub addPatientBtn_Click(sender As Object, e As EventArgs) Handles addPatientBtn.Click
        Dim addForm As New AddPatient()
        addForm.ShowDialog()
        LoadPatientsFromDB()
    End Sub

    Private Sub patientLayout_Paint(sender As Object, e As PaintEventArgs) Handles patientLayout.Paint

    End Sub
End Class
