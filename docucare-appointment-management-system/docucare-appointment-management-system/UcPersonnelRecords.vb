Imports System.Data

Public Class UcPersonnelRecords
    Private MainContentPanel As Panel
    Private db As New DBHandler()
    Private allPersonnel As DataTable
    Private isInitialized As Boolean = False

    Public Sub New(parent As Panel)
        InitializeComponent()
        MainContentPanel = parent
    End Sub

    Private Sub UcPersonnelRecords_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        showOnlyComboBox.Items.Clear()
        showOnlyComboBox.Items.AddRange(New String() {"All", "Doctor", "Staff"})
        showOnlyComboBox.SelectedIndex = 0
        showOnlyComboBox.DropDownStyle = ComboBoxStyle.DropDownList

        sortComboBox.Items.Clear()
        sortComboBox.Items.AddRange(New String() {
            "ID (Asc)", "ID (Desc)",
            "Name (A-Z)", "Name (Z-A)",
            "Role (Asc)", "Role (Desc)"
        })
        sortComboBox.SelectedIndex = 0
        sortComboBox.DropDownStyle = ComboBoxStyle.DropDownList

        LoadPersonnel()
        isInitialized = True
    End Sub

    Private Sub LoadPersonnel(Optional roleFilter As String = "All", Optional search As String = "", Optional sortBy As String = "ID (Asc)")
        Try
            Dim query As String = "SELECT ID, Personnel_Name, Verified_ID, Role, ContactNo, Schedule FROM personneltable"
            Dim filters As New List(Of String)
            Dim parameters As New Dictionary(Of String, Object)

            If roleFilter <> "All" Then
                filters.Add("Role = @role")
                parameters.Add("@role", roleFilter)
            End If

            If Not String.IsNullOrWhiteSpace(search) Then
                filters.Add("(Personnel_Name LIKE @search OR Verified_ID LIKE @search)")
                parameters.Add("@search", "%" & search & "%")
            End If

            If filters.Count > 0 Then query &= " WHERE " & String.Join(" AND ", filters)

            Select Case sortBy
                Case "ID (Asc)" : query &= " ORDER BY ID ASC"
                Case "ID (Desc)" : query &= " ORDER BY ID DESC"
                Case "Name (A-Z)" : query &= " ORDER BY Personnel_Name ASC"
                Case "Name (Z-A)" : query &= " ORDER BY Personnel_Name DESC"
                Case "Role (Asc)" : query &= " ORDER BY Role ASC"
                Case "Role (Desc)" : query &= " ORDER BY Role DESC"
                Case Else : query &= " ORDER BY ID ASC"
            End Select

            allPersonnel = db.ReadWithParameters(query, parameters)
            PersonnelGrid.Controls.Clear()

            For Each row As DataRow In allPersonnel.Rows
                Dim card As New Panel With {
                    .Width = PersonnelGrid.Width - 25,
                    .Height = 90,
                    .BorderStyle = BorderStyle.FixedSingle,
                    .Margin = New Padding(5),
                    .Padding = New Padding(10)
                }

                Dim lbl As New Label With {
                    .Text = $"Verified ID: {row("Verified_ID")}" & vbCrLf &
                            $"Name: {row("Personnel_Name")}" & vbCrLf &
                            $"Role: {row("Role")}",
                    .Dock = DockStyle.Fill,
                    .AutoSize = False,
                    .TextAlign = ContentAlignment.MiddleLeft
                }

                card.Controls.Add(lbl)

                If row("Role").ToString().ToLower() <> "admin" Then
                    Dim viewBtn As New Button With {
                        .Text = "View",
                        .Dock = DockStyle.Bottom,
                        .Height = 25,
                        .Tag = row
                    }
                    AddHandler viewBtn.Click, AddressOf ViewPersonnel_Click
                    card.Controls.Add(viewBtn)
                End If

                PersonnelGrid.Controls.Add(card)
            Next

        Catch ex As Exception
            MessageBox.Show("Error loading personnel: " & ex.Message)
        End Try
    End Sub

    Private Sub ViewPersonnel_Click(sender As Object, e As EventArgs)
        Dim btn As Button = CType(sender, Button)
        Dim data As DataRow = CType(btn.Tag, DataRow)
        Dim infoForm As New PersonnelInfo(data, AddressOf RefreshGrid)
        infoForm.ShowDialog()
    End Sub

    Private Sub RefreshGrid()
        LoadPersonnel(showOnlyComboBox.SelectedItem.ToString(), searchTxt.Text.Trim(), sortComboBox.SelectedItem.ToString())
    End Sub

    ' --- Search / Filter / Sort Event Handlers ---
    Private Sub searchTxt_TextChanged(sender As Object, e As EventArgs) Handles searchTxt.TextChanged
        If isInitialized Then RefreshGrid()
    End Sub

    Private Sub showOnlyComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles showOnlyComboBox.SelectedIndexChanged
        If isInitialized Then RefreshGrid()
    End Sub

    Private Sub sortComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles sortComboBox.SelectedIndexChanged
        If isInitialized Then RefreshGrid()
    End Sub

    Private Sub NavbarMenu_Click(sender As Object, e As EventArgs) Handles NavbarMenu.Click
        MainContentPanel.Controls.Clear()
        Dim addMainMenu As New UcMainMenu(MainContentPanel)
        addMainMenu.Dock = DockStyle.Fill
        MainContentPanel.Controls.Add(addMainMenu)
    End Sub

    ' --- Add Doctor / Staff Buttons ---
    Private Sub addDoctorBtn_Click(sender As Object, e As EventArgs) Handles addDoctorBtn.Click
        Dim createForm As New CreateDoctor()
        AddHandler createForm.FormClosed, Sub()
                                              RefreshGrid()
                                          End Sub
        createForm.ShowDialog()
    End Sub

    Private Sub addStaffBtn_Click(sender As Object, e As EventArgs) Handles addStaffBtn.Click
        Dim createForm As New CreateStaff()
        AddHandler createForm.FormClosed, Sub()
                                              RefreshGrid()
                                          End Sub
        createForm.ShowDialog()
    End Sub
End Class
