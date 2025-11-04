<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class UcAppointment
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.NavbarMenu = New System.Windows.Forms.Button()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.PatientInfoPanel = New System.Windows.Forms.Panel()
        Me.AppointmentList = New System.Windows.Forms.FlowLayoutPanel()
        Me.addAppointmentBtn = New System.Windows.Forms.Button()
        Me.MonthCalendar1 = New System.Windows.Forms.MonthCalendar()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.searchDoctor = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.sortComboBox = New System.Windows.Forms.ComboBox()
        Me.searchPatient = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
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
        Me.Label1.Location = New System.Drawing.Point(331, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(108, 20)
        Me.Label1.TabIndex = 12
        Me.Label1.Text = "Appointments"
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
        Me.PatientInfoPanel.BackColor = System.Drawing.Color.WhiteSmoke
        Me.PatientInfoPanel.Controls.Add(Me.AppointmentList)
        Me.PatientInfoPanel.Controls.Add(Me.addAppointmentBtn)
        Me.PatientInfoPanel.Controls.Add(Me.MonthCalendar1)
        Me.PatientInfoPanel.Location = New System.Drawing.Point(0, 101)
        Me.PatientInfoPanel.Name = "PatientInfoPanel"
        Me.PatientInfoPanel.Size = New System.Drawing.Size(784, 400)
        Me.PatientInfoPanel.TabIndex = 7
        '
        'AppointmentList
        '
        Me.AppointmentList.BackColor = System.Drawing.Color.WhiteSmoke
        Me.AppointmentList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.AppointmentList.Location = New System.Drawing.Point(10, 10)
        Me.AppointmentList.Name = "AppointmentList"
        Me.AppointmentList.Size = New System.Drawing.Size(530, 380)
        Me.AppointmentList.TabIndex = 14
        '
        'addAppointmentBtn
        '
        Me.addAppointmentBtn.BackColor = System.Drawing.SystemColors.HotTrack
        Me.addAppointmentBtn.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.addAppointmentBtn.ForeColor = System.Drawing.SystemColors.Control
        Me.addAppointmentBtn.Location = New System.Drawing.Point(576, 237)
        Me.addAppointmentBtn.Name = "addAppointmentBtn"
        Me.addAppointmentBtn.Size = New System.Drawing.Size(165, 41)
        Me.addAppointmentBtn.TabIndex = 13
        Me.addAppointmentBtn.Text = "Add an appointment"
        Me.addAppointmentBtn.UseVisualStyleBackColor = False
        '
        'MonthCalendar1
        '
        Me.MonthCalendar1.Location = New System.Drawing.Point(548, 9)
        Me.MonthCalendar1.Name = "MonthCalendar1"
        Me.MonthCalendar1.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(19, 75)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(96, 16)
        Me.Label2.TabIndex = 16
        Me.Label2.Text = "Search Doctor:"
        '
        'searchDoctor
        '
        Me.searchDoctor.Location = New System.Drawing.Point(119, 74)
        Me.searchDoctor.Name = "searchDoctor"
        Me.searchDoctor.Size = New System.Drawing.Size(206, 20)
        Me.searchDoctor.TabIndex = 17
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(357, 48)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(53, 16)
        Me.Label3.TabIndex = 19
        Me.Label3.Text = "Sort By:"
        '
        'sortComboBox
        '
        Me.sortComboBox.FormattingEnabled = True
        Me.sortComboBox.Location = New System.Drawing.Point(408, 45)
        Me.sortComboBox.Name = "sortComboBox"
        Me.sortComboBox.Size = New System.Drawing.Size(139, 21)
        Me.sortComboBox.TabIndex = 20
        '
        'searchPatient
        '
        Me.searchPatient.Location = New System.Drawing.Point(119, 47)
        Me.searchPatient.Name = "searchPatient"
        Me.searchPatient.Size = New System.Drawing.Size(206, 20)
        Me.searchPatient.TabIndex = 22
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(21, 49)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(97, 16)
        Me.Label4.TabIndex = 21
        Me.Label4.Text = "Search Patient:"
        '
        'UcAppointment
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.docucare_appointment_management_system.My.Resources.Resources.bg_alt
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Controls.Add(Me.searchPatient)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.sortComboBox)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.searchDoctor)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.PatientInfoPanel)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "UcAppointment"
        Me.Size = New System.Drawing.Size(784, 501)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PatientInfoPanel.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents NavbarMenu As Button
    Friend WithEvents PictureBox3 As PictureBox
    Friend WithEvents PatientInfoPanel As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents MonthCalendar1 As MonthCalendar
    Friend WithEvents addAppointmentBtn As Button
    Friend WithEvents AppointmentList As FlowLayoutPanel
    Friend WithEvents Label2 As Label
    Friend WithEvents searchDoctor As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents sortComboBox As ComboBox
    Friend WithEvents searchPatient As TextBox
    Friend WithEvents Label4 As Label
End Class
