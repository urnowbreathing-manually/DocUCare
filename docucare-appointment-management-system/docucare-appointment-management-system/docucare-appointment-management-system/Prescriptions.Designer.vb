<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Prescriptions
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
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Medicine = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.buttonSave = New System.Windows.Forms.Button()
        Me.ButtonCancel = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Frequency = New System.Windows.Forms.NumericUpDown()
        Me.Duration = New System.Windows.Forms.NumericUpDown()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Dose = New System.Windows.Forms.NumericUpDown()
        Me.Label10 = New System.Windows.Forms.Label()
        CType(Me.Frequency, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Duration, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Dose, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(23, 53)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(84, 13)
        Me.Label7.TabIndex = 15
        Me.Label7.Text = "Medicine Name:"
        '
        'Medicine
        '
        Me.Medicine.FormattingEnabled = True
        Me.Medicine.Location = New System.Drawing.Point(26, 69)
        Me.Medicine.Name = "Medicine"
        Me.Medicine.Size = New System.Drawing.Size(229, 21)
        Me.Medicine.TabIndex = 16
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(23, 103)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(47, 13)
        Me.Label1.TabIndex = 17
        Me.Label1.Text = "Dosage:"
        '
        'buttonSave
        '
        Me.buttonSave.BackColor = System.Drawing.SystemColors.HotTrack
        Me.buttonSave.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.buttonSave.ForeColor = System.Drawing.SystemColors.Control
        Me.buttonSave.Location = New System.Drawing.Point(26, 253)
        Me.buttonSave.Name = "buttonSave"
        Me.buttonSave.Size = New System.Drawing.Size(216, 32)
        Me.buttonSave.TabIndex = 21
        Me.buttonSave.Text = "Add"
        Me.buttonSave.UseVisualStyleBackColor = False
        '
        'ButtonCancel
        '
        Me.ButtonCancel.Location = New System.Drawing.Point(63, 291)
        Me.ButtonCancel.Name = "ButtonCancel"
        Me.ButtonCancel.Size = New System.Drawing.Size(136, 32)
        Me.ButtonCancel.TabIndex = 22
        Me.ButtonCancel.Text = "Cancel"
        Me.ButtonCancel.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(23, 187)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(34, 13)
        Me.Label4.TabIndex = 25
        Me.Label4.Text = "Every"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(116, 187)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(48, 13)
        Me.Label5.TabIndex = 26
        Me.Label5.Text = "hours for"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(223, 186)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(32, 13)
        Me.Label2.TabIndex = 27
        Me.Label2.Text = "days."
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(174, 207)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(40, 12)
        Me.Label6.TabIndex = 28
        Me.Label6.Text = "Duration"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(61, 207)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(49, 12)
        Me.Label3.TabIndex = 29
        Me.Label3.Text = "Frequency"
        '
        'Frequency
        '
        Me.Frequency.Location = New System.Drawing.Point(63, 184)
        Me.Frequency.Name = "Frequency"
        Me.Frequency.Size = New System.Drawing.Size(47, 20)
        Me.Frequency.TabIndex = 30
        '
        'Duration
        '
        Me.Duration.Location = New System.Drawing.Point(170, 184)
        Me.Duration.Name = "Duration"
        Me.Duration.Size = New System.Drawing.Size(47, 20)
        Me.Duration.TabIndex = 31
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(26, 29)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(84, 13)
        Me.Label8.TabIndex = 32
        Me.Label8.Text = "Medicine Info"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(26, 159)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(60, 13)
        Me.Label9.TabIndex = 33
        Me.Label9.Text = "Schedule"
        '
        'Dose
        '
        Me.Dose.Location = New System.Drawing.Point(29, 119)
        Me.Dose.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.Dose.Name = "Dose"
        Me.Dose.Size = New System.Drawing.Size(47, 20)
        Me.Dose.TabIndex = 34
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(82, 121)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(54, 13)
        Me.Label10.TabIndex = 35
        Me.Label10.Text = "milligrams."
        '
        'Prescriptions
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(279, 338)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Dose)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Duration)
        Me.Controls.Add(Me.Frequency)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.ButtonCancel)
        Me.Controls.Add(Me.buttonSave)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Medicine)
        Me.Controls.Add(Me.Label7)
        Me.Name = "Prescriptions"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Prescriptions"
        CType(Me.Frequency, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Duration, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Dose, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label7 As Label
    Friend WithEvents Medicine As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents buttonSave As Button
    Friend WithEvents ButtonCancel As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Frequency As NumericUpDown
    Friend WithEvents Duration As NumericUpDown
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Dose As NumericUpDown
    Friend WithEvents Label10 As Label
End Class
