<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EditPatientInfo
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
        Me.MedicalConditions = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.EmergencyContact = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.BloodType = New System.Windows.Forms.ComboBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Weight = New System.Windows.Forms.TextBox()
        Me.Weigh = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Height = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.BtnCancel = New System.Windows.Forms.Button()
        Me.Save = New System.Windows.Forms.Button()
        Me.Allergies = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.ContactNum = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Gender = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Age = New System.Windows.Forms.TextBox()
        Me.LastName = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.FirstName = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'MedicalConditions
        '
        Me.MedicalConditions.Location = New System.Drawing.Point(32, 362)
        Me.MedicalConditions.Name = "MedicalConditions"
        Me.MedicalConditions.Size = New System.Drawing.Size(368, 20)
        Me.MedicalConditions.TabIndex = 36
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(29, 346)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(133, 13)
        Me.Label12.TabIndex = 47
        Me.Label12.Text = "Medical Conditions (if any):"
        '
        'EmergencyContact
        '
        Me.EmergencyContact.Location = New System.Drawing.Point(32, 472)
        Me.EmergencyContact.Name = "EmergencyContact"
        Me.EmergencyContact.Size = New System.Drawing.Size(368, 20)
        Me.EmergencyContact.TabIndex = 39
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(29, 456)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(123, 13)
        Me.Label11.TabIndex = 46
        Me.Label11.Text = "Emergency Contact No.:"
        '
        'BloodType
        '
        Me.BloodType.FormattingEnabled = True
        Me.BloodType.Items.AddRange(New Object() {"Male", "Female"})
        Me.BloodType.Location = New System.Drawing.Point(32, 254)
        Me.BloodType.Name = "BloodType"
        Me.BloodType.Size = New System.Drawing.Size(122, 21)
        Me.BloodType.TabIndex = 32
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(29, 238)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(64, 13)
        Me.Label10.TabIndex = 45
        Me.Label10.Text = "Blood Type:"
        '
        'Weight
        '
        Me.Weight.Location = New System.Drawing.Point(323, 203)
        Me.Weight.Name = "Weight"
        Me.Weight.Size = New System.Drawing.Size(74, 20)
        Me.Weight.TabIndex = 31
        '
        'Weigh
        '
        Me.Weigh.AutoSize = True
        Me.Weigh.Location = New System.Drawing.Point(320, 187)
        Me.Weigh.Name = "Weigh"
        Me.Weigh.Size = New System.Drawing.Size(76, 13)
        Me.Weigh.TabIndex = 44
        Me.Weigh.Text = "Weight (in kg):"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(281, 187)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(0, 13)
        Me.Label8.TabIndex = 43
        '
        'Height
        '
        Me.Height.Location = New System.Drawing.Point(226, 203)
        Me.Height.Name = "Height"
        Me.Height.Size = New System.Drawing.Size(72, 20)
        Me.Height.TabIndex = 30
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(223, 187)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(75, 13)
        Me.Label7.TabIndex = 42
        Me.Label7.Text = "Height (in cm):"
        '
        'BtnCancel
        '
        Me.BtnCancel.BackColor = System.Drawing.SystemColors.Control
        Me.BtnCancel.FlatAppearance.BorderColor = System.Drawing.SystemColors.HotTrack
        Me.BtnCancel.FlatAppearance.BorderSize = 6
        Me.BtnCancel.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.HotTrack
        Me.BtnCancel.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.HotTrack
        Me.BtnCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnCancel.ForeColor = System.Drawing.Color.Black
        Me.BtnCancel.Location = New System.Drawing.Point(239, 549)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(161, 35)
        Me.BtnCancel.TabIndex = 41
        Me.BtnCancel.Text = "Cancel"
        Me.BtnCancel.UseVisualStyleBackColor = False
        '
        'Save
        '
        Me.Save.BackColor = System.Drawing.SystemColors.HotTrack
        Me.Save.FlatAppearance.BorderColor = System.Drawing.SystemColors.HotTrack
        Me.Save.FlatAppearance.BorderSize = 6
        Me.Save.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.HotTrack
        Me.Save.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.HotTrack
        Me.Save.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Save.ForeColor = System.Drawing.Color.Transparent
        Me.Save.Location = New System.Drawing.Point(32, 549)
        Me.Save.Name = "Save"
        Me.Save.Size = New System.Drawing.Size(200, 35)
        Me.Save.TabIndex = 40
        Me.Save.Text = "Save"
        Me.Save.UseVisualStyleBackColor = False
        '
        'Allergies
        '
        Me.Allergies.Location = New System.Drawing.Point(32, 306)
        Me.Allergies.Name = "Allergies"
        Me.Allergies.Size = New System.Drawing.Size(368, 20)
        Me.Allergies.TabIndex = 34
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(29, 290)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(83, 13)
        Me.Label6.TabIndex = 38
        Me.Label6.Text = "Allergies (if any):"
        '
        'ContactNum
        '
        Me.ContactNum.Location = New System.Drawing.Point(32, 416)
        Me.ContactNum.Name = "ContactNum"
        Me.ContactNum.Size = New System.Drawing.Size(368, 20)
        Me.ContactNum.TabIndex = 37
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(29, 400)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(67, 13)
        Me.Label5.TabIndex = 35
        Me.Label5.Text = "Contact No.:"
        '
        'Gender
        '
        Me.Gender.FormattingEnabled = True
        Me.Gender.Items.AddRange(New Object() {"Male", "Female"})
        Me.Gender.Location = New System.Drawing.Point(82, 202)
        Me.Gender.Name = "Gender"
        Me.Gender.Size = New System.Drawing.Size(122, 21)
        Me.Gender.TabIndex = 29
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(79, 187)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(45, 13)
        Me.Label4.TabIndex = 33
        Me.Label4.Text = "Gender:"
        '
        'Age
        '
        Me.Age.Location = New System.Drawing.Point(32, 203)
        Me.Age.Name = "Age"
        Me.Age.Size = New System.Drawing.Size(33, 20)
        Me.Age.TabIndex = 28
        '
        'LastName
        '
        Me.LastName.Location = New System.Drawing.Point(32, 148)
        Me.LastName.Name = "LastName"
        Me.LastName.Size = New System.Drawing.Size(368, 20)
        Me.LastName.TabIndex = 26
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(29, 132)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(61, 13)
        Me.Label2.TabIndex = 27
        Me.Label2.Text = "Last Name:"
        '
        'FirstName
        '
        Me.FirstName.Location = New System.Drawing.Point(32, 95)
        Me.FirstName.Name = "FirstName"
        Me.FirstName.Size = New System.Drawing.Size(368, 20)
        Me.FirstName.TabIndex = 25
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(29, 79)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(60, 13)
        Me.Label1.TabIndex = 24
        Me.Label1.Text = "First Name:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(29, 187)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(29, 13)
        Me.Label3.TabIndex = 48
        Me.Label3.Text = "Age:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(36, 32)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(127, 18)
        Me.Label9.TabIndex = 49
        Me.Label9.Text = "Edit Patient Info"
        '
        'EditPatientInfo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(428, 662)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.MedicalConditions)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.EmergencyContact)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.BloodType)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Weight)
        Me.Controls.Add(Me.Weigh)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Height)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.BtnCancel)
        Me.Controls.Add(Me.Save)
        Me.Controls.Add(Me.Allergies)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.ContactNum)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Gender)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Age)
        Me.Controls.Add(Me.LastName)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.FirstName)
        Me.Controls.Add(Me.Label1)
        Me.Name = "EditPatientInfo"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Edit Patient "
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MedicalConditions As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents EmergencyContact As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents BloodType As ComboBox
    Friend WithEvents Label10 As Label
    Friend WithEvents Weight As TextBox
    Friend WithEvents Weigh As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Height As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents BtnCancel As Button
    Friend WithEvents Save As Button
    Friend WithEvents Allergies As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents ContactNum As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Gender As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Age As TextBox
    Friend WithEvents LastName As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents FirstName As TextBox
End Class
