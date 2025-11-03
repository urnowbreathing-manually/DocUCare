<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class AddPatient
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AddPatient))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.FirstName = New System.Windows.Forms.TextBox()
        Me.LastName = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Age = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Gender = New System.Windows.Forms.ComboBox()
        Me.ContactNum = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Allergies = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Save = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Height = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Weight = New System.Windows.Forms.TextBox()
        Me.Weigh = New System.Windows.Forms.Label()
        Me.BloodType = New System.Windows.Forms.ComboBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.EmergencyContact = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.MedicalConditions = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.EmContactName = New System.Windows.Forms.TextBox()
        Me.EmCont = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.EmContactRel = New System.Windows.Forms.ComboBox()
        Me.EtRel = New System.Windows.Forms.Label()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(26, 79)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(60, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "First Name:"
        '
        'FirstName
        '
        Me.FirstName.Location = New System.Drawing.Point(28, 95)
        Me.FirstName.Name = "FirstName"
        Me.FirstName.Size = New System.Drawing.Size(368, 20)
        Me.FirstName.TabIndex = 0
        '
        'LastName
        '
        Me.LastName.Location = New System.Drawing.Point(28, 148)
        Me.LastName.Name = "LastName"
        Me.LastName.Size = New System.Drawing.Size(368, 20)
        Me.LastName.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(26, 132)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(61, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Last Name:"
        '
        'Age
        '
        Me.Age.Location = New System.Drawing.Point(28, 203)
        Me.Age.Name = "Age"
        Me.Age.Size = New System.Drawing.Size(33, 20)
        Me.Age.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(26, 185)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(29, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Age:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(76, 187)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(45, 13)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Gender:"
        '
        'Gender
        '
        Me.Gender.FormattingEnabled = True
        Me.Gender.Items.AddRange(New Object() {"Male", "Female"})
        Me.Gender.Location = New System.Drawing.Point(79, 202)
        Me.Gender.Name = "Gender"
        Me.Gender.Size = New System.Drawing.Size(122, 21)
        Me.Gender.TabIndex = 3
        '
        'ContactNum
        '
        Me.ContactNum.Location = New System.Drawing.Point(28, 416)
        Me.ContactNum.Name = "ContactNum"
        Me.ContactNum.Size = New System.Drawing.Size(368, 20)
        Me.ContactNum.TabIndex = 9
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(26, 400)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(67, 13)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Contact No.:"
        '
        'Allergies
        '
        Me.Allergies.Location = New System.Drawing.Point(28, 306)
        Me.Allergies.Name = "Allergies"
        Me.Allergies.Size = New System.Drawing.Size(368, 20)
        Me.Allergies.TabIndex = 7
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(26, 290)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(83, 13)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "Allergies (if any):"
        '
        'Save
        '
        Me.Save.BackColor = System.Drawing.SystemColors.HotTrack
        Me.Save.FlatAppearance.BorderColor = System.Drawing.SystemColors.HotTrack
        Me.Save.FlatAppearance.BorderSize = 6
        Me.Save.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.HotTrack
        Me.Save.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.HotTrack
        Me.Save.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Save.ForeColor = System.Drawing.Color.Transparent
        Me.Save.Location = New System.Drawing.Point(21, 607)
        Me.Save.Name = "Save"
        Me.Save.Size = New System.Drawing.Size(200, 35)
        Me.Save.TabIndex = 11
        Me.Save.Text = "Save"
        Me.Save.UseVisualStyleBackColor = False
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
        Me.Button2.Location = New System.Drawing.Point(227, 606)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(161, 35)
        Me.Button2.TabIndex = 12
        Me.Button2.Text = "Cancel"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'Height
        '
        Me.Height.Location = New System.Drawing.Point(223, 203)
        Me.Height.Name = "Height"
        Me.Height.Size = New System.Drawing.Size(72, 20)
        Me.Height.TabIndex = 4
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(220, 187)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(75, 13)
        Me.Label7.TabIndex = 14
        Me.Label7.Text = "Height (in cm):"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(278, 187)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(0, 13)
        Me.Label8.TabIndex = 16
        '
        'Weight
        '
        Me.Weight.Location = New System.Drawing.Point(320, 203)
        Me.Weight.Name = "Weight"
        Me.Weight.Size = New System.Drawing.Size(74, 20)
        Me.Weight.TabIndex = 5
        '
        'Weigh
        '
        Me.Weigh.AutoSize = True
        Me.Weigh.Location = New System.Drawing.Point(316, 187)
        Me.Weigh.Name = "Weigh"
        Me.Weigh.Size = New System.Drawing.Size(76, 13)
        Me.Weigh.TabIndex = 17
        Me.Weigh.Text = "Weight (in kg):"
        '
        'BloodType
        '
        Me.BloodType.FormattingEnabled = True
        Me.BloodType.Items.AddRange(New Object() {"Male", "Female"})
        Me.BloodType.Location = New System.Drawing.Point(28, 254)
        Me.BloodType.Name = "BloodType"
        Me.BloodType.Size = New System.Drawing.Size(122, 21)
        Me.BloodType.TabIndex = 6
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(26, 238)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(64, 13)
        Me.Label10.TabIndex = 19
        Me.Label10.Text = "Blood Type:"
        '
        'EmergencyContact
        '
        Me.EmergencyContact.Location = New System.Drawing.Point(28, 472)
        Me.EmergencyContact.Name = "EmergencyContact"
        Me.EmergencyContact.Size = New System.Drawing.Size(172, 20)
        Me.EmergencyContact.TabIndex = 10
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(26, 456)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(123, 13)
        Me.Label11.TabIndex = 21
        Me.Label11.Text = "Emergency Contact No.:"
        '
        'MedicalConditions
        '
        Me.MedicalConditions.Location = New System.Drawing.Point(28, 362)
        Me.MedicalConditions.Name = "MedicalConditions"
        Me.MedicalConditions.Size = New System.Drawing.Size(368, 20)
        Me.MedicalConditions.TabIndex = 8
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(26, 346)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(133, 13)
        Me.Label12.TabIndex = 23
        Me.Label12.Text = "Medical Conditions (if any):"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Firebrick
        Me.Label9.Location = New System.Drawing.Point(87, 77)
        Me.Label9.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(12, 15)
        Me.Label9.TabIndex = 24
        Me.Label9.Text = "*"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.Firebrick
        Me.Label13.Location = New System.Drawing.Point(87, 132)
        Me.Label13.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(12, 15)
        Me.Label13.TabIndex = 25
        Me.Label13.Text = "*"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.Firebrick
        Me.Label14.Location = New System.Drawing.Point(50, 185)
        Me.Label14.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(12, 15)
        Me.Label14.TabIndex = 26
        Me.Label14.Text = "*"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.Firebrick
        Me.Label15.Location = New System.Drawing.Point(115, 185)
        Me.Label15.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(12, 15)
        Me.Label15.TabIndex = 27
        Me.Label15.Text = "*"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.Firebrick
        Me.Label16.Location = New System.Drawing.Point(284, 185)
        Me.Label16.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(12, 15)
        Me.Label16.TabIndex = 28
        Me.Label16.Text = "*"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.BackColor = System.Drawing.Color.Transparent
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.Firebrick
        Me.Label17.Location = New System.Drawing.Point(386, 185)
        Me.Label17.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(12, 15)
        Me.Label17.TabIndex = 29
        Me.Label17.Text = "*"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.BackColor = System.Drawing.Color.Transparent
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.Firebrick
        Me.Label18.Location = New System.Drawing.Point(87, 238)
        Me.Label18.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(12, 15)
        Me.Label18.TabIndex = 30
        Me.Label18.Text = "*"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.BackColor = System.Drawing.Color.Transparent
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.Color.Firebrick
        Me.Label19.Location = New System.Drawing.Point(139, 454)
        Me.Label19.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(12, 15)
        Me.Label19.TabIndex = 31
        Me.Label19.Text = "*"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.BackColor = System.Drawing.Color.Transparent
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.ForeColor = System.Drawing.Color.Firebrick
        Me.Label20.Location = New System.Drawing.Point(87, 398)
        Me.Label20.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(12, 15)
        Me.Label20.TabIndex = 32
        Me.Label20.Text = "*"
        '
        'PictureBox2
        '
        Me.PictureBox2.BackgroundImage = Global.docucare_appointment_management_system.My.Resources.Resources.Doc_U_Care
        Me.PictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox2.Location = New System.Drawing.Point(24, 22)
        Me.PictureBox2.Margin = New System.Windows.Forms.Padding(2)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(37, 37)
        Me.PictureBox2.TabIndex = 47
        Me.PictureBox2.TabStop = False
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label32.Location = New System.Drawing.Point(68, 42)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(81, 17)
        Me.Label32.TabIndex = 46
        Me.Label32.Text = "Add Patient"
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label33.Location = New System.Drawing.Point(66, 22)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(92, 20)
        Me.Label33.TabIndex = 45
        Me.Label33.Text = "DocUCare"
        '
        'PictureBox1
        '
        Me.PictureBox1.BackgroundImage = CType(resources.GetObject("PictureBox1.BackgroundImage"), System.Drawing.Image)
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox1.Location = New System.Drawing.Point(155, 42)
        Me.PictureBox1.Margin = New System.Windows.Forms.Padding(2)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(16, 16)
        Me.PictureBox1.TabIndex = 44
        Me.PictureBox1.TabStop = False
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.BackColor = System.Drawing.Color.Transparent
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.ForeColor = System.Drawing.Color.Firebrick
        Me.Label21.Location = New System.Drawing.Point(354, 452)
        Me.Label21.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(12, 15)
        Me.Label21.TabIndex = 50
        Me.Label21.Text = "*"
        '
        'EmContactName
        '
        Me.EmContactName.Location = New System.Drawing.Point(223, 472)
        Me.EmContactName.Name = "EmContactName"
        Me.EmContactName.Size = New System.Drawing.Size(172, 20)
        Me.EmContactName.TabIndex = 48
        '
        'EmCont
        '
        Me.EmCont.AutoSize = True
        Me.EmCont.Location = New System.Drawing.Point(221, 456)
        Me.EmCont.Name = "EmCont"
        Me.EmCont.Size = New System.Drawing.Size(134, 13)
        Me.EmCont.TabIndex = 49
        Me.EmCont.Text = "Emergency Contact Name:"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.BackColor = System.Drawing.Color.Transparent
        Me.Label23.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.ForeColor = System.Drawing.Color.Firebrick
        Me.Label23.Location = New System.Drawing.Point(187, 507)
        Me.Label23.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(12, 15)
        Me.Label23.TabIndex = 53
        Me.Label23.Text = "*"
        '
        'EmContactRel
        '
        Me.EmContactRel.FormattingEnabled = True
        Me.EmContactRel.Items.AddRange(New Object() {"Male", "Female"})
        Me.EmContactRel.Location = New System.Drawing.Point(29, 527)
        Me.EmContactRel.Name = "EmContactRel"
        Me.EmContactRel.Size = New System.Drawing.Size(155, 21)
        Me.EmContactRel.TabIndex = 51
        '
        'EtRel
        '
        Me.EtRel.AutoSize = True
        Me.EtRel.Location = New System.Drawing.Point(27, 511)
        Me.EtRel.Name = "EtRel"
        Me.EtRel.Size = New System.Drawing.Size(161, 13)
        Me.EtRel.TabIndex = 52
        Me.EtRel.Text = "Emergency Contact Relationship"
        '
        'AddPatient
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(428, 662)
        Me.Controls.Add(Me.Label23)
        Me.Controls.Add(Me.EmContactRel)
        Me.Controls.Add(Me.EtRel)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.EmContactName)
        Me.Controls.Add(Me.EmCont)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.Label32)
        Me.Controls.Add(Me.Label33)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label9)
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
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Save)
        Me.Controls.Add(Me.Allergies)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.ContactNum)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Gender)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Age)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.LastName)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.FirstName)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "AddPatient"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Add New Patient Profile"
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents FirstName As TextBox
    Friend WithEvents LastName As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Age As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Gender As ComboBox
    Friend WithEvents ContactNum As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Allergies As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Save As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Height As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Weight As TextBox
    Friend WithEvents Weigh As Label
    Friend WithEvents BloodType As ComboBox
    Friend WithEvents Label10 As Label
    Friend WithEvents EmergencyContact As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents MedicalConditions As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents Label17 As Label
    Friend WithEvents Label18 As Label
    Friend WithEvents Label19 As Label
    Friend WithEvents Label20 As Label
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents Label32 As Label
    Friend WithEvents Label33 As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Label21 As Label
    Friend WithEvents EmContactName As TextBox
    Friend WithEvents EmCont As Label
    Friend WithEvents Label23 As Label
    Friend WithEvents EmContactRel As ComboBox
    Friend WithEvents EtRel As Label
End Class
