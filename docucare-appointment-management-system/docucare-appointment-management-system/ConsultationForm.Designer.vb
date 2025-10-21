<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ConsultationForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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
        Me.components = New System.ComponentModel.Container()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.lblNotes = New System.Windows.Forms.Label()
        Me.lblTime = New System.Windows.Forms.Label()
        Me.lblDate = New System.Windows.Forms.Label()
        Me.lblDoctor = New System.Windows.Forms.Label()
        Me.lblPatient = New System.Windows.Forms.Label()
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
        Me.Diagnosis = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Symptoms = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.DrugPrescriptionNotes = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.CreateConsultation = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.PrescriptionsBindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.PrescriptionsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.TableLayoutPanel2.SuspendLayout()
        Me.TableLayoutPanel3.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.PrescriptionsBindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PrescriptionsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label7
        '
        Me.Label7.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(61, 9)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(172, 20)
        Me.Label7.TabIndex = 2
        Me.Label7.Text = "Patient Consultation"
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.[Single]
        Me.TableLayoutPanel2.ColumnCount = 2
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.lblTime, 1, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.lblDate, 0, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.lblDoctor, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.lblPatient, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.lblNotes, 0, 2)
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(4, 45)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 3
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(628, 117)
        Me.TableLayoutPanel2.TabIndex = 0
        '
        'lblNotes
        '
        Me.lblNotes.AutoSize = True
        Me.lblNotes.Location = New System.Drawing.Point(4, 47)
        Me.lblNotes.Name = "lblNotes"
        Me.lblNotes.Size = New System.Drawing.Size(47, 13)
        Me.lblNotes.TabIndex = 12
        Me.lblNotes.Text = "Reason:"
        '
        'lblTime
        '
        Me.lblTime.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblTime.AutoSize = True
        Me.lblTime.Location = New System.Drawing.Point(317, 28)
        Me.lblTime.Name = "lblTime"
        Me.lblTime.Size = New System.Drawing.Size(33, 13)
        Me.lblTime.TabIndex = 8
        Me.lblTime.Text = "Time:"
        '
        'lblDate
        '
        Me.lblDate.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblDate.AutoSize = True
        Me.lblDate.Location = New System.Drawing.Point(4, 28)
        Me.lblDate.Name = "lblDate"
        Me.lblDate.Size = New System.Drawing.Size(33, 13)
        Me.lblDate.TabIndex = 7
        Me.lblDate.Text = "Date:"
        '
        'lblDoctor
        '
        Me.lblDoctor.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblDoctor.AutoSize = True
        Me.lblDoctor.Location = New System.Drawing.Point(317, 5)
        Me.lblDoctor.Name = "lblDoctor"
        Me.lblDoctor.Size = New System.Drawing.Size(88, 13)
        Me.lblDoctor.TabIndex = 2
        Me.lblDoctor.Text = "Assigned Doctor:"
        '
        'lblPatient
        '
        Me.lblPatient.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblPatient.AutoSize = True
        Me.lblPatient.Location = New System.Drawing.Point(4, 5)
        Me.lblPatient.Name = "lblPatient"
        Me.lblPatient.Size = New System.Drawing.Size(74, 13)
        Me.lblPatient.TabIndex = 1
        Me.lblPatient.Text = "Patient Name:"
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset
        Me.TableLayoutPanel3.ColumnCount = 1
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel3.Controls.Add(Me.Diagnosis, 0, 3)
        Me.TableLayoutPanel3.Controls.Add(Me.Label8, 0, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.Label9, 0, 2)
        Me.TableLayoutPanel3.Controls.Add(Me.Symptoms, 0, 1)
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(4, 192)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 4
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40.0!))
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(628, 170)
        Me.TableLayoutPanel3.TabIndex = 1
        '
        'Diagnosis
        '
        Me.Diagnosis.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Diagnosis.Location = New System.Drawing.Point(5, 107)
        Me.Diagnosis.Multiline = True
        Me.Diagnosis.Name = "Diagnosis"
        Me.Diagnosis.Size = New System.Drawing.Size(618, 58)
        Me.Diagnosis.TabIndex = 14
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(5, 2)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(136, 13)
        Me.Label8.TabIndex = 12
        Me.Label8.Text = "Symptoms/Chief Complaint:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(5, 86)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(56, 13)
        Me.Label9.TabIndex = 13
        Me.Label9.Text = "Diagnosis:"
        '
        'Symptoms
        '
        Me.Symptoms.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Symptoms.Location = New System.Drawing.Point(5, 23)
        Me.Symptoms.Multiline = True
        Me.Symptoms.Name = "Symptoms"
        Me.Symptoms.Size = New System.Drawing.Size(618, 58)
        Me.Symptoms.TabIndex = 3
        '
        'Label14
        '
        Me.Label14.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(241, 173)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(158, 16)
        Me.Label14.TabIndex = 5
        Me.Label14.Text = "Professional Observation"
        '
        'PictureBox1
        '
        Me.PictureBox1.BackgroundImage = Global.docucare_appointment_management_system.My.Resources.Resources.Doc_U_Care
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox1.Location = New System.Drawing.Point(4, 4)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(51, 35)
        Me.PictureBox1.TabIndex = 1
        Me.PictureBox1.TabStop = False
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.DrugPrescriptionNotes, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label10, 0, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(4, 368)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.028369!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 93.97163!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(628, 282)
        Me.TableLayoutPanel1.TabIndex = 11
        '
        'DrugPrescriptionNotes
        '
        Me.DrugPrescriptionNotes.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.DrugPrescriptionNotes.Location = New System.Drawing.Point(5, 24)
        Me.DrugPrescriptionNotes.Multiline = True
        Me.DrugPrescriptionNotes.Name = "DrugPrescriptionNotes"
        Me.DrugPrescriptionNotes.Size = New System.Drawing.Size(618, 251)
        Me.DrugPrescriptionNotes.TabIndex = 15
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(3, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(93, 13)
        Me.Label10.TabIndex = 14
        Me.Label10.Text = "Drug Prescriptions"
        '
        'CreateConsultation
        '
        Me.CreateConsultation.BackColor = System.Drawing.SystemColors.HotTrack
        Me.CreateConsultation.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CreateConsultation.ForeColor = System.Drawing.SystemColors.Control
        Me.CreateConsultation.Location = New System.Drawing.Point(63, 668)
        Me.CreateConsultation.Name = "CreateConsultation"
        Me.CreateConsultation.Size = New System.Drawing.Size(298, 35)
        Me.CreateConsultation.TabIndex = 12
        Me.CreateConsultation.Text = "Create Consultation"
        Me.CreateConsultation.UseVisualStyleBackColor = False
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.SystemColors.Control
        Me.Button2.FlatAppearance.BorderColor = System.Drawing.SystemColors.HotTrack
        Me.Button2.FlatAppearance.BorderSize = 6
        Me.Button2.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.HotTrack
        Me.Button2.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.HotTrack
        Me.Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.ForeColor = System.Drawing.Color.Black
        Me.Button2.Location = New System.Drawing.Point(367, 668)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(161, 35)
        Me.Button2.TabIndex = 13
        Me.Button2.Text = "Cancel"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'PrescriptionsBindingSource1
        '
        Me.PrescriptionsBindingSource1.DataSource = GetType(docucare_appointment_management_system.Prescriptions)
        '
        'PrescriptionsBindingSource
        '
        Me.PrescriptionsBindingSource.DataSource = GetType(docucare_appointment_management_system.Prescriptions)
        '
        'ConsultationForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(634, 766)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.CreateConsultation)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.TableLayoutPanel3)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.TableLayoutPanel2)
        Me.Controls.Add(Me.PictureBox1)
        Me.Name = "ConsultationForm"
        Me.Text = "Consultation Form"
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        Me.TableLayoutPanel3.ResumeLayout(False)
        Me.TableLayoutPanel3.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        CType(Me.PrescriptionsBindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PrescriptionsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Label7 As Label
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents lblTime As Label
    Friend WithEvents lblDate As Label
    Friend WithEvents lblDoctor As Label
    Friend WithEvents lblPatient As Label
    Friend WithEvents TableLayoutPanel3 As TableLayoutPanel
    Friend WithEvents Diagnosis As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Symptoms As TextBox
    Friend WithEvents Label14 As Label
    Friend WithEvents PrescriptionsBindingSource1 As BindingSource
    Friend WithEvents PrescriptionsBindingSource As BindingSource
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents DrugPrescriptionNotes As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents CreateConsultation As Button
    Friend WithEvents lblNotes As Label
    Friend WithEvents Button2 As Button
End Class
