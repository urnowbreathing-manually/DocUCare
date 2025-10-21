<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UcPatientRecords
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.NavbarMenu = New System.Windows.Forms.Button()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.addPatientBtn = New System.Windows.Forms.Button()
        Me.PatientInfoPanel = New System.Windows.Forms.Panel()
        Me.patientLayout = New System.Windows.Forms.FlowLayoutPanel()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PatientInfoPanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.NavbarMenu)
        Me.Panel1.Controls.Add(Me.PictureBox3)
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(784, 38)
        Me.Panel1.TabIndex = 6
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
        Me.NavbarMenu.Text = "Menu"
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
        'addPatientBtn
        '
        Me.addPatientBtn.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.addPatientBtn.Location = New System.Drawing.Point(3, 44)
        Me.addPatientBtn.Name = "addPatientBtn"
        Me.addPatientBtn.Size = New System.Drawing.Size(160, 29)
        Me.addPatientBtn.TabIndex = 14
        Me.addPatientBtn.Text = "Add New Patient"
        Me.addPatientBtn.UseVisualStyleBackColor = True
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
        Me.patientLayout.Location = New System.Drawing.Point(18, 19)
        Me.patientLayout.Name = "patientLayout"
        Me.patientLayout.Size = New System.Drawing.Size(743, 370)
        Me.patientLayout.TabIndex = 0
        '
        'UcPatientRecords
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.docucare_appointment_management_system.My.Resources.Resources.bg_alt
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Controls.Add(Me.addPatientBtn)
        Me.Controls.Add(Me.PatientInfoPanel)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "UcPatientRecords"
        Me.Size = New System.Drawing.Size(784, 501)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PatientInfoPanel.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents NavbarMenu As Button
    Friend WithEvents PictureBox3 As PictureBox
    Friend WithEvents Label1 As Label
    Friend WithEvents addPatientBtn As Button
    Friend WithEvents PatientInfoPanel As Panel
    Friend WithEvents patientLayout As FlowLayoutPanel
End Class
