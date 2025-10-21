<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CreateStaff
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CreateStaff))
        Me.Label4 = New System.Windows.Forms.Label()
        Me.ConfirmPassword = New System.Windows.Forms.TextBox()
        Me.Password = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.LastName = New System.Windows.Forms.TextBox()
        Me.FirstName = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.VerificationID = New System.Windows.Forms.TextBox()
        Me.CreateStaffBtn = New System.Windows.Forms.Button()
        Me.Cancel = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 185)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(94, 13)
        Me.Label4.TabIndex = 16
        Me.Label4.Text = "Confirm Password:"
        '
        'ConfirmPassword
        '
        Me.ConfirmPassword.Location = New System.Drawing.Point(15, 201)
        Me.ConfirmPassword.Name = "ConfirmPassword"
        Me.ConfirmPassword.Size = New System.Drawing.Size(390, 20)
        Me.ConfirmPassword.TabIndex = 15
        '
        'Password
        '
        Me.Password.Location = New System.Drawing.Point(15, 150)
        Me.Password.Name = "Password"
        Me.Password.Size = New System.Drawing.Size(390, 20)
        Me.Password.TabIndex = 14
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 134)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(56, 13)
        Me.Label3.TabIndex = 13
        Me.Label3.Text = "Password:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 84)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(61, 13)
        Me.Label2.TabIndex = 12
        Me.Label2.Text = "Last Name:"
        '
        'LastName
        '
        Me.LastName.Location = New System.Drawing.Point(15, 100)
        Me.LastName.Name = "LastName"
        Me.LastName.Size = New System.Drawing.Size(390, 20)
        Me.LastName.TabIndex = 11
        '
        'FirstName
        '
        Me.FirstName.Location = New System.Drawing.Point(15, 51)
        Me.FirstName.Name = "FirstName"
        Me.FirstName.Size = New System.Drawing.Size(390, 20)
        Me.FirstName.TabIndex = 10
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 35)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(60, 13)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "First Name:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(12, 236)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(76, 13)
        Me.Label5.TabIndex = 18
        Me.Label5.Text = "Verification ID:"
        '
        'VerificationID
        '
        Me.VerificationID.Location = New System.Drawing.Point(15, 252)
        Me.VerificationID.Name = "VerificationID"
        Me.VerificationID.Size = New System.Drawing.Size(390, 20)
        Me.VerificationID.TabIndex = 17
        '
        'CreateStaffBtn
        '
        Me.CreateStaffBtn.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.CreateStaffBtn.BackColor = System.Drawing.SystemColors.HotTrack
        Me.CreateStaffBtn.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.CreateStaffBtn.FlatAppearance.BorderSize = 0
        Me.CreateStaffBtn.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CreateStaffBtn.ForeColor = System.Drawing.SystemColors.Control
        Me.CreateStaffBtn.Location = New System.Drawing.Point(15, 330)
        Me.CreateStaffBtn.Name = "CreateStaffBtn"
        Me.CreateStaffBtn.Size = New System.Drawing.Size(226, 36)
        Me.CreateStaffBtn.TabIndex = 19
        Me.CreateStaffBtn.Text = "Create Staff Account"
        Me.CreateStaffBtn.UseVisualStyleBackColor = False
        '
        'Cancel
        '
        Me.Cancel.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Cancel.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Cancel.FlatAppearance.BorderSize = 0
        Me.Cancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cancel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Cancel.Location = New System.Drawing.Point(250, 330)
        Me.Cancel.Name = "Cancel"
        Me.Cancel.Size = New System.Drawing.Size(157, 36)
        Me.Cancel.TabIndex = 20
        Me.Cancel.Text = "Cancel"
        Me.Cancel.UseVisualStyleBackColor = False
        '
        'CreateStaff
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(423, 402)
        Me.Controls.Add(Me.Cancel)
        Me.Controls.Add(Me.CreateStaffBtn)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.VerificationID)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.ConfirmPassword)
        Me.Controls.Add(Me.Password)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.LastName)
        Me.Controls.Add(Me.FirstName)
        Me.Controls.Add(Me.Label1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "CreateStaff"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Create Staff"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label4 As Label
    Friend WithEvents ConfirmPassword As TextBox
    Friend WithEvents Password As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents LastName As TextBox
    Friend WithEvents FirstName As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents VerificationID As TextBox
    Friend WithEvents CreateStaffBtn As Button
    Friend WithEvents Cancel As Button
End Class
