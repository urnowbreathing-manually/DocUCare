<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PersonnelInfo
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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
        Me.CloseBtn = New System.Windows.Forms.Button()
        Me.PatientInfoPanel = New System.Windows.Forms.Panel()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.TableLayoutPanel4 = New System.Windows.Forms.TableLayoutPanel()
        Me.Schedule_Lbl = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.Role_Lbl = New System.Windows.Forms.Label()
        Me.ContactNo_Lbl = New System.Windows.Forms.Label()
        Me.VerifiedID_Lbl = New System.Windows.Forms.Label()
        Me.FullName_Lbl = New System.Windows.Forms.Label()
        Me.Lbl_Header1 = New System.Windows.Forms.Label()
        Me.EditPatientBtn = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.PatientInfoPanel.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.TableLayoutPanel4.SuspendLayout()
        Me.TableLayoutPanel3.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'CloseBtn
        '
        Me.CloseBtn.BackColor = System.Drawing.Color.IndianRed
        Me.CloseBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CloseBtn.ForeColor = System.Drawing.SystemColors.Control
        Me.CloseBtn.Location = New System.Drawing.Point(696, 0)
        Me.CloseBtn.Name = "CloseBtn"
        Me.CloseBtn.Size = New System.Drawing.Size(75, 29)
        Me.CloseBtn.TabIndex = 9
        Me.CloseBtn.Text = "Close"
        Me.CloseBtn.UseVisualStyleBackColor = False
        '
        'PatientInfoPanel
        '
        Me.PatientInfoPanel.BackColor = System.Drawing.Color.WhiteSmoke
        Me.PatientInfoPanel.Controls.Add(Me.CloseBtn)
        Me.PatientInfoPanel.Controls.Add(Me.TableLayoutPanel1)
        Me.PatientInfoPanel.Controls.Add(Me.EditPatientBtn)
        Me.PatientInfoPanel.Controls.Add(Me.Panel1)
        Me.PatientInfoPanel.Location = New System.Drawing.Point(0, 12)
        Me.PatientInfoPanel.Name = "PatientInfoPanel"
        Me.PatientInfoPanel.Size = New System.Drawing.Size(784, 400)
        Me.PatientInfoPanel.TabIndex = 8
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel4, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel3, 0, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(25, 59)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(733, 298)
        Me.TableLayoutPanel1.TabIndex = 9
        '
        'TableLayoutPanel4
        '
        Me.TableLayoutPanel4.ColumnCount = 1
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel4.Controls.Add(Me.Schedule_Lbl, 0, 1)
        Me.TableLayoutPanel4.Controls.Add(Me.Label5, 0, 0)
        Me.TableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel4.Location = New System.Drawing.Point(369, 3)
        Me.TableLayoutPanel4.Name = "TableLayoutPanel4"
        Me.TableLayoutPanel4.RowCount = 3
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90.0!))
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel4.Size = New System.Drawing.Size(361, 292)
        Me.TableLayoutPanel4.TabIndex = 2
        '
        'Schedule_Lbl
        '
        Me.Schedule_Lbl.AutoSize = True
        Me.Schedule_Lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Schedule_Lbl.Location = New System.Drawing.Point(10, 37)
        Me.Schedule_Lbl.Margin = New System.Windows.Forms.Padding(10)
        Me.Schedule_Lbl.Name = "Schedule_Lbl"
        Me.Schedule_Lbl.Size = New System.Drawing.Size(55, 13)
        Me.Schedule_Lbl.TabIndex = 3
        Me.Schedule_Lbl.Text = "Schedule:"
        '
        'Label5
        '
        Me.Label5.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(138, 3)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(84, 20)
        Me.Label5.TabIndex = 1
        Me.Label5.Text = "Schedule"
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.ColumnCount = 1
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel3.Controls.Add(Me.TableLayoutPanel2, 0, 1)
        Me.TableLayoutPanel3.Controls.Add(Me.Lbl_Header1, 0, 0)
        Me.TableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(3, 3)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 3
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(360, 292)
        Me.TableLayoutPanel3.TabIndex = 1
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.TableLayoutPanel2.ColumnCount = 1
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.Role_Lbl, 0, 3)
        Me.TableLayoutPanel2.Controls.Add(Me.ContactNo_Lbl, 0, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.VerifiedID_Lbl, 0, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.FullName_Lbl, 0, 0)
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(3, 30)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 5
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(354, 200)
        Me.TableLayoutPanel2.TabIndex = 0
        '
        'Role_Lbl
        '
        Me.Role_Lbl.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Role_Lbl.AutoSize = True
        Me.Role_Lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Role_Lbl.Location = New System.Drawing.Point(3, 133)
        Me.Role_Lbl.Name = "Role_Lbl"
        Me.Role_Lbl.Size = New System.Drawing.Size(32, 13)
        Me.Role_Lbl.TabIndex = 5
        Me.Role_Lbl.Text = "Role:"
        '
        'ContactNo_Lbl
        '
        Me.ContactNo_Lbl.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.ContactNo_Lbl.AutoSize = True
        Me.ContactNo_Lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ContactNo_Lbl.Location = New System.Drawing.Point(3, 93)
        Me.ContactNo_Lbl.Name = "ContactNo_Lbl"
        Me.ContactNo_Lbl.Size = New System.Drawing.Size(64, 13)
        Me.ContactNo_Lbl.TabIndex = 4
        Me.ContactNo_Lbl.Text = "Contact No:"
        '
        'VerifiedID_Lbl
        '
        Me.VerifiedID_Lbl.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.VerifiedID_Lbl.AutoSize = True
        Me.VerifiedID_Lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.VerifiedID_Lbl.Location = New System.Drawing.Point(3, 53)
        Me.VerifiedID_Lbl.Name = "VerifiedID_Lbl"
        Me.VerifiedID_Lbl.Size = New System.Drawing.Size(59, 13)
        Me.VerifiedID_Lbl.TabIndex = 3
        Me.VerifiedID_Lbl.Text = "Verified ID:"
        '
        'FullName_Lbl
        '
        Me.FullName_Lbl.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.FullName_Lbl.AutoSize = True
        Me.FullName_Lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FullName_Lbl.Location = New System.Drawing.Point(3, 13)
        Me.FullName_Lbl.Name = "FullName_Lbl"
        Me.FullName_Lbl.Size = New System.Drawing.Size(57, 13)
        Me.FullName_Lbl.TabIndex = 2
        Me.FullName_Lbl.Text = "Full Name:"
        '
        'Lbl_Header1
        '
        Me.Lbl_Header1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Lbl_Header1.AutoSize = True
        Me.Lbl_Header1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Header1.Location = New System.Drawing.Point(92, 3)
        Me.Lbl_Header1.Name = "Lbl_Header1"
        Me.Lbl_Header1.Size = New System.Drawing.Size(176, 20)
        Me.Lbl_Header1.TabIndex = 1
        Me.Lbl_Header1.Text = "Personal Information"
        '
        'EditPatientBtn
        '
        Me.EditPatientBtn.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.EditPatientBtn.BackColor = System.Drawing.SystemColors.HotTrack
        Me.EditPatientBtn.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.EditPatientBtn.FlatAppearance.BorderSize = 0
        Me.EditPatientBtn.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EditPatientBtn.ForeColor = System.Drawing.SystemColors.Control
        Me.EditPatientBtn.Location = New System.Drawing.Point(29, 362)
        Me.EditPatientBtn.Name = "EditPatientBtn"
        Me.EditPatientBtn.Size = New System.Drawing.Size(293, 36)
        Me.EditPatientBtn.TabIndex = 6
        Me.EditPatientBtn.Text = "Edit Info"
        Me.EditPatientBtn.UseVisualStyleBackColor = False
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Controls.Add(Me.Label11)
        Me.Panel1.Location = New System.Drawing.Point(25, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(2)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(437, 56)
        Me.Panel1.TabIndex = 8
        '
        'PictureBox1
        '
        Me.PictureBox1.BackgroundImage = Global.docucare_appointment_management_system.My.Resources.Resources.Doc_U_Care
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox1.Location = New System.Drawing.Point(2, 0)
        Me.PictureBox1.Margin = New System.Windows.Forms.Padding(2)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(75, 54)
        Me.PictureBox1.TabIndex = 2
        Me.PictureBox1.TabStop = False
        '
        'Label11
        '
        Me.Label11.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(103, 14)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(119, 26)
        Me.Label11.TabIndex = 1
        Me.Label11.Text = "Personnel"
        '
        'PersonnelInfo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(784, 411)
        Me.Controls.Add(Me.PatientInfoPanel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "PersonnelInfo"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "PersonnelInfo"
        Me.PatientInfoPanel.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel4.ResumeLayout(False)
        Me.TableLayoutPanel4.PerformLayout()
        Me.TableLayoutPanel3.ResumeLayout(False)
        Me.TableLayoutPanel3.PerformLayout()
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents CloseBtn As Button
    Friend WithEvents PatientInfoPanel As Panel
    Friend WithEvents EditPatientBtn As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Label11 As Label
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents TableLayoutPanel3 As TableLayoutPanel
    Friend WithEvents Lbl_Header1 As Label
    Friend WithEvents ContactNo_Lbl As Label
    Friend WithEvents VerifiedID_Lbl As Label
    Friend WithEvents FullName_Lbl As Label
    Friend WithEvents Role_Lbl As Label
    Friend WithEvents TableLayoutPanel4 As TableLayoutPanel
    Friend WithEvents Schedule_Lbl As Label
    Friend WithEvents Label5 As Label
End Class
