<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UcPersonnelRecords
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.sortComboBox = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.searchTxt = New System.Windows.Forms.TextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.addStaffBtn = New System.Windows.Forms.Button()
        Me.addDoctorBtn = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.NavbarMenu = New System.Windows.Forms.Button()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.PatientInfoPanel = New System.Windows.Forms.Panel()
        Me.PersonnelGrid = New System.Windows.Forms.FlowLayoutPanel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.showOnlyComboBox = New System.Windows.Forms.ComboBox()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PatientInfoPanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'sortComboBox
        '
        Me.sortComboBox.FormattingEnabled = True
        Me.sortComboBox.Location = New System.Drawing.Point(552, 62)
        Me.sortComboBox.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.sortComboBox.Name = "sortComboBox"
        Me.sortComboBox.Size = New System.Drawing.Size(235, 24)
        Me.sortComboBox.TabIndex = 22
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(480, 64)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(70, 20)
        Me.Label3.TabIndex = 21
        Me.Label3.Text = "Sort By:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(28, 65)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(147, 20)
        Me.Label2.TabIndex = 20
        Me.Label2.Text = "Search Personnel:"
        '
        'searchTxt
        '
        Me.searchTxt.Location = New System.Drawing.Point(187, 63)
        Me.searchTxt.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.searchTxt.Name = "searchTxt"
        Me.searchTxt.Size = New System.Drawing.Size(271, 22)
        Me.searchTxt.TabIndex = 19
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel1.Controls.Add(Me.addStaffBtn)
        Me.Panel1.Controls.Add(Me.addDoctorBtn)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.NavbarMenu)
        Me.Panel1.Controls.Add(Me.PictureBox3)
        Me.Panel1.Location = New System.Drawing.Point(0, -1)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1045, 49)
        Me.Panel1.TabIndex = 18
        '
        'addStaffBtn
        '
        Me.addStaffBtn.BackColor = System.Drawing.Color.Green
        Me.addStaffBtn.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.addStaffBtn.FlatAppearance.BorderSize = 0
        Me.addStaffBtn.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.addStaffBtn.ForeColor = System.Drawing.SystemColors.Control
        Me.addStaffBtn.Location = New System.Drawing.Point(775, 6)
        Me.addStaffBtn.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.addStaffBtn.Name = "addStaffBtn"
        Me.addStaffBtn.Size = New System.Drawing.Size(152, 34)
        Me.addStaffBtn.TabIndex = 15
        Me.addStaffBtn.Text = "Add Staff"
        Me.addStaffBtn.UseVisualStyleBackColor = False
        '
        'addDoctorBtn
        '
        Me.addDoctorBtn.BackColor = System.Drawing.SystemColors.HotTrack
        Me.addDoctorBtn.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.addDoctorBtn.FlatAppearance.BorderSize = 0
        Me.addDoctorBtn.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.addDoctorBtn.ForeColor = System.Drawing.SystemColors.Control
        Me.addDoctorBtn.Location = New System.Drawing.Point(619, 7)
        Me.addDoctorBtn.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.addDoctorBtn.Name = "addDoctorBtn"
        Me.addDoctorBtn.Size = New System.Drawing.Size(152, 34)
        Me.addDoctorBtn.TabIndex = 14
        Me.addDoctorBtn.Text = "Add Doctor"
        Me.addDoctorBtn.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(381, 12)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(177, 25)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "Personnel Records"
        '
        'NavbarMenu
        '
        Me.NavbarMenu.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.NavbarMenu.Location = New System.Drawing.Point(933, 4)
        Me.NavbarMenu.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.NavbarMenu.Name = "NavbarMenu"
        Me.NavbarMenu.Size = New System.Drawing.Size(100, 36)
        Me.NavbarMenu.TabIndex = 6
        Me.NavbarMenu.Text = "Back"
        Me.NavbarMenu.UseVisualStyleBackColor = True
        '
        'PictureBox3
        '
        Me.PictureBox3.BackgroundImage = Global.docucare_appointment_management_system.My.Resources.Resources.banner
        Me.PictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox3.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox3.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(133, 43)
        Me.PictureBox3.TabIndex = 6
        Me.PictureBox3.TabStop = False
        '
        'PatientInfoPanel
        '
        Me.PatientInfoPanel.AutoScroll = True
        Me.PatientInfoPanel.BackColor = System.Drawing.Color.WhiteSmoke
        Me.PatientInfoPanel.Controls.Add(Me.PersonnelGrid)
        Me.PatientInfoPanel.Location = New System.Drawing.Point(1, 103)
        Me.PatientInfoPanel.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.PatientInfoPanel.Name = "PatientInfoPanel"
        Me.PatientInfoPanel.Size = New System.Drawing.Size(1045, 514)
        Me.PatientInfoPanel.TabIndex = 23
        '
        'PersonnelGrid
        '
        Me.PersonnelGrid.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PersonnelGrid.AutoSize = True
        Me.PersonnelGrid.Location = New System.Drawing.Point(24, 23)
        Me.PersonnelGrid.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.PersonnelGrid.Name = "PersonnelGrid"
        Me.PersonnelGrid.Size = New System.Drawing.Size(991, 455)
        Me.PersonnelGrid.TabIndex = 0
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(813, 65)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(55, 20)
        Me.Label4.TabIndex = 24
        Me.Label4.Text = "Show:"
        '
        'showOnlyComboBox
        '
        Me.showOnlyComboBox.FormattingEnabled = True
        Me.showOnlyComboBox.Location = New System.Drawing.Point(872, 63)
        Me.showOnlyComboBox.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.showOnlyComboBox.Name = "showOnlyComboBox"
        Me.showOnlyComboBox.Size = New System.Drawing.Size(131, 24)
        Me.showOnlyComboBox.TabIndex = 25
        '
        'UcPersonnelRecords
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.docucare_appointment_management_system.My.Resources.Resources.bg_alt
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Controls.Add(Me.showOnlyComboBox)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.PatientInfoPanel)
        Me.Controls.Add(Me.sortComboBox)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.searchTxt)
        Me.Controls.Add(Me.Panel1)
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "UcPersonnelRecords"
        Me.Size = New System.Drawing.Size(1045, 617)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PatientInfoPanel.ResumeLayout(False)
        Me.PatientInfoPanel.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents sortComboBox As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents searchTxt As TextBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents addDoctorBtn As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents NavbarMenu As Button
    Friend WithEvents PictureBox3 As PictureBox
    Friend WithEvents PatientInfoPanel As Panel
    Friend WithEvents PersonnelGrid As FlowLayoutPanel
    Friend WithEvents addStaffBtn As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents showOnlyComboBox As ComboBox
End Class
