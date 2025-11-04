<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class UcPatientRecords
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.addPatientBtn = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.NavbarMenu = New System.Windows.Forms.Button()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.PatientInfoPanel = New System.Windows.Forms.Panel()
        Me.patientLayout = New System.Windows.Forms.FlowLayoutPanel()
        Me.searchTextBox = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.sortComboBox = New System.Windows.Forms.ComboBox()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PatientInfoPanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel1.Controls.Add(Me.addPatientBtn)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.NavbarMenu)
        Me.Panel1.Controls.Add(Me.PictureBox3)
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(784, 38)
        Me.Panel1.TabIndex = 6
        '
        'addPatientBtn
        '
        Me.addPatientBtn.BackColor = System.Drawing.SystemColors.HotTrack
        Me.addPatientBtn.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.addPatientBtn.FlatAppearance.BorderSize = 0
        Me.addPatientBtn.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.addPatientBtn.ForeColor = System.Drawing.SystemColors.Control
        Me.addPatientBtn.Location = New System.Drawing.Point(574, 4)
        Me.addPatientBtn.Name = "addPatientBtn"
        Me.addPatientBtn.Size = New System.Drawing.Size(121, 28)
        Me.addPatientBtn.TabIndex = 14
        Me.addPatientBtn.Text = "Add New Patient"
        Me.addPatientBtn.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(332, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(123, 20)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "Patient Records"
        '
        'NavbarMenu
        '
        Me.NavbarMenu.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.NavbarMenu.Location = New System.Drawing.Point(700, 3)
        Me.NavbarMenu.Name = "NavbarMenu"
        Me.NavbarMenu.Size = New System.Drawing.Size(75, 29)
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
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(100, 35)
        Me.PictureBox3.TabIndex = 6
        Me.PictureBox3.TabStop = False
        '
        'PatientInfoPanel
        '
        Me.PatientInfoPanel.AutoScroll = True
        Me.PatientInfoPanel.BackColor = System.Drawing.Color.WhiteSmoke
        Me.PatientInfoPanel.Controls.Add(Me.patientLayout)
        Me.PatientInfoPanel.Location = New System.Drawing.Point(0, 79)
        Me.PatientInfoPanel.Name = "PatientInfoPanel"
        Me.PatientInfoPanel.Size = New System.Drawing.Size(784, 418)
        Me.PatientInfoPanel.TabIndex = 13
        '
        'patientLayout
        '
        Me.patientLayout.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.patientLayout.AutoSize = True
        Me.patientLayout.Location = New System.Drawing.Point(18, 19)
        Me.patientLayout.Name = "patientLayout"
        Me.patientLayout.Size = New System.Drawing.Size(743, 370)
        Me.patientLayout.TabIndex = 0
        '
        'searchTextBox
        '
        Me.searchTextBox.Location = New System.Drawing.Point(163, 50)
        Me.searchTextBox.Name = "searchTextBox"
        Me.searchTextBox.Size = New System.Drawing.Size(181, 20)
        Me.searchTextBox.TabIndex = 14
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(21, 52)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(137, 16)
        Me.Label2.TabIndex = 15
        Me.Label2.Text = "Search Patient Name:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(360, 51)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(53, 16)
        Me.Label3.TabIndex = 16
        Me.Label3.Text = "Sort By:"
        '
        'sortComboBox
        '
        Me.sortComboBox.FormattingEnabled = True
        Me.sortComboBox.Location = New System.Drawing.Point(414, 49)
        Me.sortComboBox.Name = "sortComboBox"
        Me.sortComboBox.Size = New System.Drawing.Size(177, 21)
        Me.sortComboBox.TabIndex = 17
        '
        'UcPatientRecords
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.docucare_appointment_management_system.My.Resources.Resources.bg_alt
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Controls.Add(Me.sortComboBox)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.searchTextBox)
        Me.Controls.Add(Me.PatientInfoPanel)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "UcPatientRecords"
        Me.Size = New System.Drawing.Size(784, 501)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PatientInfoPanel.ResumeLayout(False)
        Me.PatientInfoPanel.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents NavbarMenu As Button
    Friend WithEvents PictureBox3 As PictureBox
    Friend WithEvents Label1 As Label
    Friend WithEvents PatientInfoPanel As Panel
    Friend WithEvents patientLayout As FlowLayoutPanel
    Friend WithEvents addPatientBtn As Button
    Friend WithEvents searchTextBox As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents sortComboBox As ComboBox
End Class
