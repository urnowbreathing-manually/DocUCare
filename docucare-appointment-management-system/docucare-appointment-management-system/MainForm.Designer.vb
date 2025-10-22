<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
        Me.MainContentPanel = New System.Windows.Forms.Panel()
        Me.SuspendLayout()
        '
        'MainContentPanel
        '
        Me.MainContentPanel.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.MainContentPanel.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.MainContentPanel.Location = New System.Drawing.Point(16, 15)
        Me.MainContentPanel.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.MainContentPanel.Name = "MainContentPanel"
        Me.MainContentPanel.Size = New System.Drawing.Size(1025, 606)
        Me.MainContentPanel.TabIndex = 0
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1043, 614)
        Me.Controls.Add(Me.MainContentPanel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "MainForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "DocUCare"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents MainContentPanel As Panel
End Class
