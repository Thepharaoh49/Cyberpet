<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AboutForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AboutForm))
        Me.HelpText = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'HelpText
        '
        Me.HelpText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.HelpText.Location = New System.Drawing.Point(4, 3)
        Me.HelpText.Multiline = True
        Me.HelpText.Name = "HelpText"
        Me.HelpText.ReadOnly = True
        Me.HelpText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.HelpText.Size = New System.Drawing.Size(297, 247)
        Me.HelpText.TabIndex = 0
        Me.HelpText.Text = resources.GetString("HelpText.Text")
        '
        'AboutForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.SteelBlue
        Me.ClientSize = New System.Drawing.Size(313, 262)
        Me.Controls.Add(Me.HelpText)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "AboutForm"
        Me.Text = "Help"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents HelpText As TextBox
End Class
