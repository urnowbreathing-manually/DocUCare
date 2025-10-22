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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(EditPatientInfo))
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
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MedicalConditions
        '
        Me.MedicalConditions.Location = New System.Drawing.Point(43, 446)
        Me.MedicalConditions.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.MedicalConditions.Name = "MedicalConditions"
        Me.MedicalConditions.Size = New System.Drawing.Size(489, 22)
        Me.MedicalConditions.TabIndex = 36
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(39, 426)
        Me.Label12.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(166, 16)
        Me.Label12.TabIndex = 47
        Me.Label12.Text = "Medical Conditions (if any):"
        '
        'EmergencyContact
        '
        Me.EmergencyContact.Location = New System.Drawing.Point(43, 581)
        Me.EmergencyContact.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.EmergencyContact.Name = "EmergencyContact"
        Me.EmergencyContact.Size = New System.Drawing.Size(489, 22)
        Me.EmergencyContact.TabIndex = 39
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(39, 561)
        Me.Label11.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(151, 16)
        Me.Label11.TabIndex = 46
        Me.Label11.Text = "Emergency Contact No.:"
        '
        'BloodType
        '
        Me.BloodType.FormattingEnabled = True
        Me.BloodType.Items.AddRange(New Object() {"Male", "Female"})
        Me.BloodType.Location = New System.Drawing.Point(43, 313)
        Me.BloodType.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.BloodType.Name = "BloodType"
        Me.BloodType.Size = New System.Drawing.Size(161, 24)
        Me.BloodType.TabIndex = 32
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(39, 293)
        Me.Label10.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(81, 16)
        Me.Label10.TabIndex = 45
        Me.Label10.Text = "Blood Type:"
        '
        'Weight
        '
        Me.Weight.Location = New System.Drawing.Point(431, 250)
        Me.Weight.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Weight.Name = "Weight"
        Me.Weight.Size = New System.Drawing.Size(97, 22)
        Me.Weight.TabIndex = 31
        '
        'Weigh
        '
        Me.Weigh.AutoSize = True
        Me.Weigh.Location = New System.Drawing.Point(427, 230)
        Me.Weigh.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Weigh.Name = "Weigh"
        Me.Weigh.Size = New System.Drawing.Size(91, 16)
        Me.Weigh.TabIndex = 44
        Me.Weigh.Text = "Weight (in kg):"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(375, 230)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(0, 16)
        Me.Label8.TabIndex = 43
        '
        'Height
        '
        Me.Height.Location = New System.Drawing.Point(301, 250)
        Me.Height.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Height.Name = "Height"
        Me.Height.Size = New System.Drawing.Size(95, 22)
        Me.Height.TabIndex = 30
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(297, 230)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(91, 16)
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
        Me.BtnCancel.Location = New System.Drawing.Point(319, 676)
        Me.BtnCancel.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(215, 43)
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
        Me.Save.Location = New System.Drawing.Point(43, 676)
        Me.Save.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Save.Name = "Save"
        Me.Save.Size = New System.Drawing.Size(267, 43)
        Me.Save.TabIndex = 40
        Me.Save.Text = "Save"
        Me.Save.UseVisualStyleBackColor = False
        '
        'Allergies
        '
        Me.Allergies.Location = New System.Drawing.Point(43, 377)
        Me.Allergies.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Allergies.Name = "Allergies"
        Me.Allergies.Size = New System.Drawing.Size(489, 22)
        Me.Allergies.TabIndex = 34
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(39, 357)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(105, 16)
        Me.Label6.TabIndex = 38
        Me.Label6.Text = "Allergies (if any):"
        '
        'ContactNum
        '
        Me.ContactNum.Location = New System.Drawing.Point(43, 512)
        Me.ContactNum.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.ContactNum.Name = "ContactNum"
        Me.ContactNum.Size = New System.Drawing.Size(489, 22)
        Me.ContactNum.TabIndex = 37
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(39, 492)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(79, 16)
        Me.Label5.TabIndex = 35
        Me.Label5.Text = "Contact No.:"
        '
        'Gender
        '
        Me.Gender.FormattingEnabled = True
        Me.Gender.Items.AddRange(New Object() {"Male", "Female"})
        Me.Gender.Location = New System.Drawing.Point(109, 249)
        Me.Gender.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Gender.Name = "Gender"
        Me.Gender.Size = New System.Drawing.Size(161, 24)
        Me.Gender.TabIndex = 29
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(105, 230)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(55, 16)
        Me.Label4.TabIndex = 33
        Me.Label4.Text = "Gender:"
        '
        'Age
        '
        Me.Age.Location = New System.Drawing.Point(43, 250)
        Me.Age.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Age.Name = "Age"
        Me.Age.Size = New System.Drawing.Size(43, 22)
        Me.Age.TabIndex = 28
        '
        'LastName
        '
        Me.LastName.Location = New System.Drawing.Point(43, 182)
        Me.LastName.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.LastName.Name = "LastName"
        Me.LastName.Size = New System.Drawing.Size(489, 22)
        Me.LastName.TabIndex = 26
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(39, 162)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(75, 16)
        Me.Label2.TabIndex = 27
        Me.Label2.Text = "Last Name:"
        '
        'FirstName
        '
        Me.FirstName.Location = New System.Drawing.Point(43, 117)
        Me.FirstName.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.FirstName.Name = "FirstName"
        Me.FirstName.Size = New System.Drawing.Size(489, 22)
        Me.FirstName.TabIndex = 25
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(39, 97)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(75, 16)
        Me.Label1.TabIndex = 24
        Me.Label1.Text = "First Name:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(39, 230)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(35, 16)
        Me.Label3.TabIndex = 48
        Me.Label3.Text = "Age:"
        '
        'PictureBox2
        '
        Me.PictureBox2.BackgroundImage = Global.docucare_appointment_management_system.My.Resources.Resources.Doc_U_Care
        Me.PictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox2.Location = New System.Drawing.Point(36, 23)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(49, 45)
        Me.PictureBox2.TabIndex = 52
        Me.PictureBox2.TabStop = False
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label32.Location = New System.Drawing.Point(94, 48)
        Me.Label32.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(95, 20)
        Me.Label32.TabIndex = 51
        Me.Label32.Text = "Edit Patient"
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label33.Location = New System.Drawing.Point(92, 23)
        Me.Label33.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(112, 25)
        Me.Label33.TabIndex = 50
        Me.Label33.Text = "DocUCare"
        '
        'PictureBox1
        '
        Me.PictureBox1.BackgroundImage = CType(resources.GetObject("PictureBox1.BackgroundImage"), System.Drawing.Image)
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox1.Location = New System.Drawing.Point(211, 48)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(21, 20)
        Me.PictureBox1.TabIndex = 49
        Me.PictureBox1.TabStop = False
        '
        'EditPatientInfo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(571, 815)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.Label32)
        Me.Controls.Add(Me.Label33)
        Me.Controls.Add(Me.PictureBox1)
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
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "EditPatientInfo"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Edit Patient "
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents FirstName As TextBox
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents Label32 As Label
    Friend WithEvents Label33 As Label
    Friend WithEvents PictureBox1 As PictureBox
End Class
