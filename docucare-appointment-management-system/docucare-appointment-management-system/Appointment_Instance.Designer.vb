<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Appointment_Instance
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
        Me.Lbl_Patient = New System.Windows.Forms.Label()
        Me.Lbl_Doctor = New System.Windows.Forms.Label()
        Me.Lbl_Date = New System.Windows.Forms.Label()
        Me.Lbl_Time = New System.Windows.Forms.Label()
        Me.Patient_Name_Placeholder = New System.Windows.Forms.Label()
        Me.Doctor_Name_Placeholder = New System.Windows.Forms.Label()
        Me.Date_Placeholder = New System.Windows.Forms.Label()
        Me.Time_Placeholder = New System.Windows.Forms.Label()
        Me.Btn_Resched = New System.Windows.Forms.Button()
        Me.Btn_Payment = New System.Windows.Forms.Button()
        Me.Btn_Consult = New System.Windows.Forms.Button()
        Me.Btn_Cancel = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Appointment_ID_Placeholder = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Status_Placeholder = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Lbl_Patient
        '
        Me.Lbl_Patient.AutoSize = True
        Me.Lbl_Patient.BackColor = System.Drawing.Color.Transparent
        Me.Lbl_Patient.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Patient.Location = New System.Drawing.Point(65, 34)
        Me.Lbl_Patient.Margin = New System.Windows.Forms.Padding(0)
        Me.Lbl_Patient.Name = "Lbl_Patient"
        Me.Lbl_Patient.Size = New System.Drawing.Size(50, 15)
        Me.Lbl_Patient.TabIndex = 0
        Me.Lbl_Patient.Text = "Patient:"
        Me.Lbl_Patient.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Lbl_Doctor
        '
        Me.Lbl_Doctor.AutoSize = True
        Me.Lbl_Doctor.BackColor = System.Drawing.Color.Transparent
        Me.Lbl_Doctor.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Doctor.Location = New System.Drawing.Point(67, 52)
        Me.Lbl_Doctor.Margin = New System.Windows.Forms.Padding(0)
        Me.Lbl_Doctor.Name = "Lbl_Doctor"
        Me.Lbl_Doctor.Size = New System.Drawing.Size(49, 15)
        Me.Lbl_Doctor.TabIndex = 1
        Me.Lbl_Doctor.Text = "Doctor:"
        Me.Lbl_Doctor.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Lbl_Date
        '
        Me.Lbl_Date.AutoSize = True
        Me.Lbl_Date.BackColor = System.Drawing.Color.Transparent
        Me.Lbl_Date.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Date.Location = New System.Drawing.Point(77, 72)
        Me.Lbl_Date.Margin = New System.Windows.Forms.Padding(0)
        Me.Lbl_Date.Name = "Lbl_Date"
        Me.Lbl_Date.Size = New System.Drawing.Size(37, 15)
        Me.Lbl_Date.TabIndex = 2
        Me.Lbl_Date.Text = "Date:"
        Me.Lbl_Date.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Lbl_Time
        '
        Me.Lbl_Time.AutoSize = True
        Me.Lbl_Time.BackColor = System.Drawing.Color.Transparent
        Me.Lbl_Time.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Time.Location = New System.Drawing.Point(77, 92)
        Me.Lbl_Time.Margin = New System.Windows.Forms.Padding(0)
        Me.Lbl_Time.Name = "Lbl_Time"
        Me.Lbl_Time.Size = New System.Drawing.Size(38, 15)
        Me.Lbl_Time.TabIndex = 3
        Me.Lbl_Time.Text = "Time:"
        Me.Lbl_Time.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Patient_Name_Placeholder
        '
        Me.Patient_Name_Placeholder.AutoSize = True
        Me.Patient_Name_Placeholder.BackColor = System.Drawing.Color.Transparent
        Me.Patient_Name_Placeholder.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Patient_Name_Placeholder.Location = New System.Drawing.Point(127, 32)
        Me.Patient_Name_Placeholder.Margin = New System.Windows.Forms.Padding(0)
        Me.Patient_Name_Placeholder.Name = "Patient_Name_Placeholder"
        Me.Patient_Name_Placeholder.Size = New System.Drawing.Size(97, 15)
        Me.Patient_Name_Placeholder.TabIndex = 4
        Me.Patient_Name_Placeholder.Text = "<Patient_Name>"
        Me.Patient_Name_Placeholder.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Doctor_Name_Placeholder
        '
        Me.Doctor_Name_Placeholder.AutoSize = True
        Me.Doctor_Name_Placeholder.BackColor = System.Drawing.Color.Transparent
        Me.Doctor_Name_Placeholder.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Doctor_Name_Placeholder.Location = New System.Drawing.Point(127, 52)
        Me.Doctor_Name_Placeholder.Margin = New System.Windows.Forms.Padding(0)
        Me.Doctor_Name_Placeholder.Name = "Doctor_Name_Placeholder"
        Me.Doctor_Name_Placeholder.Size = New System.Drawing.Size(96, 15)
        Me.Doctor_Name_Placeholder.TabIndex = 5
        Me.Doctor_Name_Placeholder.Text = "<Doctor_Name>"
        Me.Doctor_Name_Placeholder.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Date_Placeholder
        '
        Me.Date_Placeholder.AutoSize = True
        Me.Date_Placeholder.BackColor = System.Drawing.Color.Transparent
        Me.Date_Placeholder.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Date_Placeholder.Location = New System.Drawing.Point(127, 72)
        Me.Date_Placeholder.Margin = New System.Windows.Forms.Padding(0)
        Me.Date_Placeholder.Name = "Date_Placeholder"
        Me.Date_Placeholder.Size = New System.Drawing.Size(99, 15)
        Me.Date_Placeholder.TabIndex = 6
        Me.Date_Placeholder.Text = "<MM/DD/YYYY>"
        Me.Date_Placeholder.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Time_Placeholder
        '
        Me.Time_Placeholder.AutoSize = True
        Me.Time_Placeholder.BackColor = System.Drawing.Color.Transparent
        Me.Time_Placeholder.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Time_Placeholder.Location = New System.Drawing.Point(127, 92)
        Me.Time_Placeholder.Margin = New System.Windows.Forms.Padding(0)
        Me.Time_Placeholder.Name = "Time_Placeholder"
        Me.Time_Placeholder.Size = New System.Drawing.Size(111, 15)
        Me.Time_Placeholder.TabIndex = 7
        Me.Time_Placeholder.Text = "<HH:MM AM/PM>"
        Me.Time_Placeholder.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Btn_Resched
        '
        Me.Btn_Resched.BackColor = System.Drawing.Color.DarkBlue
        Me.Btn_Resched.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Resched.ForeColor = System.Drawing.SystemColors.Control
        Me.Btn_Resched.Location = New System.Drawing.Point(270, 10)
        Me.Btn_Resched.Margin = New System.Windows.Forms.Padding(0)
        Me.Btn_Resched.Name = "Btn_Resched"
        Me.Btn_Resched.Size = New System.Drawing.Size(90, 30)
        Me.Btn_Resched.TabIndex = 14
        Me.Btn_Resched.Text = "Resched"
        Me.Btn_Resched.UseVisualStyleBackColor = False
        '
        'Btn_Payment
        '
        Me.Btn_Payment.BackColor = System.Drawing.SystemColors.HotTrack
        Me.Btn_Payment.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Payment.ForeColor = System.Drawing.SystemColors.Control
        Me.Btn_Payment.Location = New System.Drawing.Point(270, 45)
        Me.Btn_Payment.Margin = New System.Windows.Forms.Padding(0)
        Me.Btn_Payment.Name = "Btn_Payment"
        Me.Btn_Payment.Size = New System.Drawing.Size(90, 30)
        Me.Btn_Payment.TabIndex = 15
        Me.Btn_Payment.Text = "Payment"
        Me.Btn_Payment.UseVisualStyleBackColor = False
        '
        'Btn_Consult
        '
        Me.Btn_Consult.BackColor = System.Drawing.SystemColors.HotTrack
        Me.Btn_Consult.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Consult.ForeColor = System.Drawing.SystemColors.Control
        Me.Btn_Consult.Location = New System.Drawing.Point(390, 45)
        Me.Btn_Consult.Margin = New System.Windows.Forms.Padding(0)
        Me.Btn_Consult.Name = "Btn_Consult"
        Me.Btn_Consult.Size = New System.Drawing.Size(90, 30)
        Me.Btn_Consult.TabIndex = 16
        Me.Btn_Consult.Text = "Consult"
        Me.Btn_Consult.UseVisualStyleBackColor = False
        '
        'Btn_Cancel
        '
        Me.Btn_Cancel.BackColor = System.Drawing.Color.DarkBlue
        Me.Btn_Cancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Cancel.ForeColor = System.Drawing.SystemColors.Control
        Me.Btn_Cancel.Location = New System.Drawing.Point(270, 80)
        Me.Btn_Cancel.Margin = New System.Windows.Forms.Padding(0)
        Me.Btn_Cancel.Name = "Btn_Cancel"
        Me.Btn_Cancel.Size = New System.Drawing.Size(90, 30)
        Me.Btn_Cancel.TabIndex = 17
        Me.Btn_Cancel.Text = "Cancel"
        Me.Btn_Cancel.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(17, 15)
        Me.Label1.Margin = New System.Windows.Forms.Padding(0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 15)
        Me.Label1.TabIndex = 18
        Me.Label1.Text = "Appointment ID:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Appointment_ID_Placeholder
        '
        Me.Appointment_ID_Placeholder.AutoSize = True
        Me.Appointment_ID_Placeholder.BackColor = System.Drawing.Color.Transparent
        Me.Appointment_ID_Placeholder.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Appointment_ID_Placeholder.Location = New System.Drawing.Point(127, 15)
        Me.Appointment_ID_Placeholder.Margin = New System.Windows.Forms.Padding(0)
        Me.Appointment_ID_Placeholder.Name = "Appointment_ID_Placeholder"
        Me.Appointment_ID_Placeholder.Size = New System.Drawing.Size(110, 15)
        Me.Appointment_ID_Placeholder.TabIndex = 19
        Me.Appointment_ID_Placeholder.Text = "<Appointment_ID>"
        Me.Appointment_ID_Placeholder.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(381, 12)
        Me.Label2.Margin = New System.Windows.Forms.Padding(0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(45, 15)
        Me.Label2.TabIndex = 20
        Me.Label2.Text = "Status:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Status_Placeholder
        '
        Me.Status_Placeholder.AutoSize = True
        Me.Status_Placeholder.BackColor = System.Drawing.Color.Transparent
        Me.Status_Placeholder.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Status_Placeholder.Location = New System.Drawing.Point(428, 13)
        Me.Status_Placeholder.Margin = New System.Windows.Forms.Padding(0)
        Me.Status_Placeholder.Name = "Status_Placeholder"
        Me.Status_Placeholder.Size = New System.Drawing.Size(55, 15)
        Me.Status_Placeholder.TabIndex = 21
        Me.Status_Placeholder.Text = "<Status>"
        Me.Status_Placeholder.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Appointment_Instance
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Controls.Add(Me.Status_Placeholder)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Appointment_ID_Placeholder)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Btn_Cancel)
        Me.Controls.Add(Me.Btn_Consult)
        Me.Controls.Add(Me.Btn_Payment)
        Me.Controls.Add(Me.Btn_Resched)
        Me.Controls.Add(Me.Time_Placeholder)
        Me.Controls.Add(Me.Date_Placeholder)
        Me.Controls.Add(Me.Doctor_Name_Placeholder)
        Me.Controls.Add(Me.Patient_Name_Placeholder)
        Me.Controls.Add(Me.Lbl_Time)
        Me.Controls.Add(Me.Lbl_Date)
        Me.Controls.Add(Me.Lbl_Doctor)
        Me.Controls.Add(Me.Lbl_Patient)
        Me.Margin = New System.Windows.Forms.Padding(0, 0, 0, 10)
        Me.Name = "Appointment_Instance"
        Me.Size = New System.Drawing.Size(510, 120)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Lbl_Patient As Label
    Friend WithEvents Lbl_Doctor As Label
    Friend WithEvents Lbl_Date As Label
    Friend WithEvents Lbl_Time As Label
    Friend WithEvents Patient_Name_Placeholder As Label
    Friend WithEvents Doctor_Name_Placeholder As Label
    Friend WithEvents Date_Placeholder As Label
    Friend WithEvents Time_Placeholder As Label
    Friend WithEvents Btn_Resched As Button
    Friend WithEvents Btn_Payment As Button
    Friend WithEvents Btn_Consult As Button
    Friend WithEvents Btn_Cancel As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Appointment_ID_Placeholder As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Status_Placeholder As Label
End Class
