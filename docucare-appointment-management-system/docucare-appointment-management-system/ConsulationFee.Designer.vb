<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ConsulationFee
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ConsulationFee))
        Me.Btn_Cancel = New System.Windows.Forms.Button()
        Me.Btn_SaveFee = New System.Windows.Forms.Button()
        Me.Lbl_PatientName = New System.Windows.Forms.Label()
        Me.Lbl_Date = New System.Windows.Forms.Label()
        Me.Lbl_Time = New System.Windows.Forms.Label()
        Me.Lbl_StaffName = New System.Windows.Forms.Label()
        Me.Lbl_ConsultationFee = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.PatientNamePlaceholder = New System.Windows.Forms.Label()
        Me.DatePlaceholder = New System.Windows.Forms.Label()
        Me.TimePlaceHolder = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Btn_Cancel
        '
        Me.Btn_Cancel.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Btn_Cancel.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Btn_Cancel.FlatAppearance.BorderSize = 0
        Me.Btn_Cancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Cancel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Btn_Cancel.Location = New System.Drawing.Point(223, 327)
        Me.Btn_Cancel.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Btn_Cancel.Name = "Btn_Cancel"
        Me.Btn_Cancel.Size = New System.Drawing.Size(189, 44)
        Me.Btn_Cancel.TabIndex = 4
        Me.Btn_Cancel.Text = "Cancel"
        Me.Btn_Cancel.UseVisualStyleBackColor = False
        '
        'Btn_SaveFee
        '
        Me.Btn_SaveFee.BackColor = System.Drawing.SystemColors.HotTrack
        Me.Btn_SaveFee.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Btn_SaveFee.FlatAppearance.BorderSize = 0
        Me.Btn_SaveFee.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_SaveFee.ForeColor = System.Drawing.SystemColors.Control
        Me.Btn_SaveFee.Location = New System.Drawing.Point(19, 327)
        Me.Btn_SaveFee.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Btn_SaveFee.Name = "Btn_SaveFee"
        Me.Btn_SaveFee.Size = New System.Drawing.Size(189, 44)
        Me.Btn_SaveFee.TabIndex = 3
        Me.Btn_SaveFee.Text = "Save"
        Me.Btn_SaveFee.UseVisualStyleBackColor = False
        '
        'Lbl_PatientName
        '
        Me.Lbl_PatientName.AutoSize = True
        Me.Lbl_PatientName.Location = New System.Drawing.Point(39, 124)
        Me.Lbl_PatientName.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Lbl_PatientName.Name = "Lbl_PatientName"
        Me.Lbl_PatientName.Size = New System.Drawing.Size(94, 16)
        Me.Lbl_PatientName.TabIndex = 17
        Me.Lbl_PatientName.Text = "Patient Name: "
        '
        'Lbl_Date
        '
        Me.Lbl_Date.AutoSize = True
        Me.Lbl_Date.Location = New System.Drawing.Point(94, 161)
        Me.Lbl_Date.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Lbl_Date.Name = "Lbl_Date"
        Me.Lbl_Date.Size = New System.Drawing.Size(42, 16)
        Me.Lbl_Date.TabIndex = 18
        Me.Lbl_Date.Text = "Date: "
        '
        'Lbl_Time
        '
        Me.Lbl_Time.AutoSize = True
        Me.Lbl_Time.Location = New System.Drawing.Point(94, 199)
        Me.Lbl_Time.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Lbl_Time.Name = "Lbl_Time"
        Me.Lbl_Time.Size = New System.Drawing.Size(44, 16)
        Me.Lbl_Time.TabIndex = 19
        Me.Lbl_Time.Text = "Time: "
        '
        'Lbl_StaffName
        '
        Me.Lbl_StaffName.AutoSize = True
        Me.Lbl_StaffName.Location = New System.Drawing.Point(54, 238)
        Me.Lbl_StaffName.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Lbl_StaffName.Name = "Lbl_StaffName"
        Me.Lbl_StaffName.Size = New System.Drawing.Size(79, 16)
        Me.Lbl_StaffName.TabIndex = 20
        Me.Lbl_StaffName.Text = "Staff Name: "
        '
        'Lbl_ConsultationFee
        '
        Me.Lbl_ConsultationFee.AutoSize = True
        Me.Lbl_ConsultationFee.Location = New System.Drawing.Point(19, 280)
        Me.Lbl_ConsultationFee.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Lbl_ConsultationFee.Name = "Lbl_ConsultationFee"
        Me.Lbl_ConsultationFee.Size = New System.Drawing.Size(113, 16)
        Me.Lbl_ConsultationFee.TabIndex = 21
        Me.Lbl_ConsultationFee.Text = "Consultation Fee: "
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(150, 235)
        Me.TextBox1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(261, 22)
        Me.TextBox1.TabIndex = 1
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(150, 277)
        Me.TextBox2.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(261, 22)
        Me.TextBox2.TabIndex = 2
        '
        'PatientNamePlaceholder
        '
        Me.PatientNamePlaceholder.AutoSize = True
        Me.PatientNamePlaceholder.Location = New System.Drawing.Point(146, 124)
        Me.PatientNamePlaceholder.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.PatientNamePlaceholder.Name = "PatientNamePlaceholder"
        Me.PatientNamePlaceholder.Size = New System.Drawing.Size(88, 16)
        Me.PatientNamePlaceholder.TabIndex = 22
        Me.PatientNamePlaceholder.Text = "<Name here>"
        '
        'DatePlaceholder
        '
        Me.DatePlaceholder.AutoSize = True
        Me.DatePlaceholder.Location = New System.Drawing.Point(146, 161)
        Me.DatePlaceholder.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.DatePlaceholder.Name = "DatePlaceholder"
        Me.DatePlaceholder.Size = New System.Drawing.Size(80, 16)
        Me.DatePlaceholder.TabIndex = 23
        Me.DatePlaceholder.Text = "<Date here>"
        '
        'TimePlaceHolder
        '
        Me.TimePlaceHolder.AutoSize = True
        Me.TimePlaceHolder.Location = New System.Drawing.Point(146, 199)
        Me.TimePlaceHolder.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.TimePlaceHolder.Name = "TimePlaceHolder"
        Me.TimePlaceHolder.Size = New System.Drawing.Size(82, 16)
        Me.TimePlaceHolder.TabIndex = 24
        Me.TimePlaceHolder.Text = "<Time here>"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Firebrick
        Me.Label9.Location = New System.Drawing.Point(129, 235)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(14, 18)
        Me.Label9.TabIndex = 25
        Me.Label9.Text = "*"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Firebrick
        Me.Label1.Location = New System.Drawing.Point(129, 278)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(14, 18)
        Me.Label1.TabIndex = 26
        Me.Label1.Text = "*"
        '
        'PictureBox2
        '
        Me.PictureBox2.BackgroundImage = Global.docucare_appointment_management_system.My.Resources.Resources.Doc_U_Care
        Me.PictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox2.Location = New System.Drawing.Point(24, 21)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(49, 45)
        Me.PictureBox2.TabIndex = 43
        Me.PictureBox2.TabStop = False
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label32.Location = New System.Drawing.Point(80, 50)
        Me.Label32.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(107, 16)
        Me.Label32.TabIndex = 42
        Me.Label32.Text = "Consultation Fee"
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label33.Location = New System.Drawing.Point(80, 21)
        Me.Label33.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(112, 25)
        Me.Label33.TabIndex = 41
        Me.Label33.Text = "DocUCare"
        '
        'PictureBox1
        '
        Me.PictureBox1.BackgroundImage = CType(resources.GetObject("PictureBox1.BackgroundImage"), System.Drawing.Image)
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox1.Location = New System.Drawing.Point(202, 46)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(21, 20)
        Me.PictureBox1.TabIndex = 40
        Me.PictureBox1.TabStop = False
        '
        'ConsulationFee
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(425, 415)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.Label32)
        Me.Controls.Add(Me.Label33)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.TimePlaceHolder)
        Me.Controls.Add(Me.DatePlaceholder)
        Me.Controls.Add(Me.PatientNamePlaceholder)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Lbl_ConsultationFee)
        Me.Controls.Add(Me.Lbl_StaffName)
        Me.Controls.Add(Me.Lbl_Time)
        Me.Controls.Add(Me.Lbl_Date)
        Me.Controls.Add(Me.Lbl_PatientName)
        Me.Controls.Add(Me.Btn_Cancel)
        Me.Controls.Add(Me.Btn_SaveFee)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "ConsulationFee"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Add Consulation Fee"
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Btn_Cancel As Button
    Friend WithEvents Btn_SaveFee As Button
    Friend WithEvents Lbl_PatientName As Label
    Friend WithEvents Lbl_Date As Label
    Friend WithEvents Lbl_Time As Label
    Friend WithEvents Lbl_StaffName As Label
    Friend WithEvents Lbl_ConsultationFee As Label
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents PatientNamePlaceholder As Label
    Friend WithEvents DatePlaceholder As Label
    Friend WithEvents TimePlaceHolder As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents Label32 As Label
    Friend WithEvents Label33 As Label
    Friend WithEvents PictureBox1 As PictureBox
End Class
