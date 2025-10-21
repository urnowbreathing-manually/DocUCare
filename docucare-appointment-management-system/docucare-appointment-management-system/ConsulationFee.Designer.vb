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
        Me.SuspendLayout()
        '
        'Btn_Cancel
        '
        Me.Btn_Cancel.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Btn_Cancel.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Btn_Cancel.FlatAppearance.BorderSize = 0
        Me.Btn_Cancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Cancel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Btn_Cancel.Location = New System.Drawing.Point(165, 204)
        Me.Btn_Cancel.Name = "Btn_Cancel"
        Me.Btn_Cancel.Size = New System.Drawing.Size(142, 36)
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
        Me.Btn_SaveFee.Location = New System.Drawing.Point(12, 204)
        Me.Btn_SaveFee.Name = "Btn_SaveFee"
        Me.Btn_SaveFee.Size = New System.Drawing.Size(142, 36)
        Me.Btn_SaveFee.TabIndex = 3
        Me.Btn_SaveFee.Text = "Save"
        Me.Btn_SaveFee.UseVisualStyleBackColor = False
        '
        'Lbl_PatientName
        '
        Me.Lbl_PatientName.AutoSize = True
        Me.Lbl_PatientName.Location = New System.Drawing.Point(27, 39)
        Me.Lbl_PatientName.Name = "Lbl_PatientName"
        Me.Lbl_PatientName.Size = New System.Drawing.Size(77, 13)
        Me.Lbl_PatientName.TabIndex = 17
        Me.Lbl_PatientName.Text = "Patient Name: "
        '
        'Lbl_Date
        '
        Me.Lbl_Date.AutoSize = True
        Me.Lbl_Date.Location = New System.Drawing.Point(68, 69)
        Me.Lbl_Date.Name = "Lbl_Date"
        Me.Lbl_Date.Size = New System.Drawing.Size(36, 13)
        Me.Lbl_Date.TabIndex = 18
        Me.Lbl_Date.Text = "Date: "
        '
        'Lbl_Time
        '
        Me.Lbl_Time.AutoSize = True
        Me.Lbl_Time.Location = New System.Drawing.Point(68, 100)
        Me.Lbl_Time.Name = "Lbl_Time"
        Me.Lbl_Time.Size = New System.Drawing.Size(36, 13)
        Me.Lbl_Time.TabIndex = 19
        Me.Lbl_Time.Text = "Time: "
        '
        'Lbl_StaffName
        '
        Me.Lbl_StaffName.AutoSize = True
        Me.Lbl_StaffName.Location = New System.Drawing.Point(38, 132)
        Me.Lbl_StaffName.Name = "Lbl_StaffName"
        Me.Lbl_StaffName.Size = New System.Drawing.Size(66, 13)
        Me.Lbl_StaffName.TabIndex = 20
        Me.Lbl_StaffName.Text = "Staff Name: "
        '
        'Lbl_ConsultationFee
        '
        Me.Lbl_ConsultationFee.AutoSize = True
        Me.Lbl_ConsultationFee.Location = New System.Drawing.Point(12, 166)
        Me.Lbl_ConsultationFee.Name = "Lbl_ConsultationFee"
        Me.Lbl_ConsultationFee.Size = New System.Drawing.Size(92, 13)
        Me.Lbl_ConsultationFee.TabIndex = 21
        Me.Lbl_ConsultationFee.Text = "Consultation Fee: "
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(110, 129)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(197, 20)
        Me.TextBox1.TabIndex = 1
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(110, 163)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(197, 20)
        Me.TextBox2.TabIndex = 2
        '
        'PatientNamePlaceholder
        '
        Me.PatientNamePlaceholder.AutoSize = True
        Me.PatientNamePlaceholder.Location = New System.Drawing.Point(107, 39)
        Me.PatientNamePlaceholder.Name = "PatientNamePlaceholder"
        Me.PatientNamePlaceholder.Size = New System.Drawing.Size(71, 13)
        Me.PatientNamePlaceholder.TabIndex = 22
        Me.PatientNamePlaceholder.Text = "<Name here>"
        '
        'DatePlaceholder
        '
        Me.DatePlaceholder.AutoSize = True
        Me.DatePlaceholder.Location = New System.Drawing.Point(107, 69)
        Me.DatePlaceholder.Name = "DatePlaceholder"
        Me.DatePlaceholder.Size = New System.Drawing.Size(66, 13)
        Me.DatePlaceholder.TabIndex = 23
        Me.DatePlaceholder.Text = "<Date here>"
        '
        'TimePlaceHolder
        '
        Me.TimePlaceHolder.AutoSize = True
        Me.TimePlaceHolder.Location = New System.Drawing.Point(107, 100)
        Me.TimePlaceHolder.Name = "TimePlaceHolder"
        Me.TimePlaceHolder.Size = New System.Drawing.Size(66, 13)
        Me.TimePlaceHolder.TabIndex = 24
        Me.TimePlaceHolder.Text = "<Time here>"
        '
        'ConsulationFee
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(319, 263)
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
        Me.Name = "ConsulationFee"
        Me.Text = "ConsulationFee"
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
End Class
