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
        Me.AboutTabs = New System.Windows.Forms.TabControl()
        Me.GeneralTab = New System.Windows.Forms.TabPage()
        Me.GeneralText = New System.Windows.Forms.TextBox()
        Me.HelpTab = New System.Windows.Forms.TabPage()
        Me.HelpText = New System.Windows.Forms.TextBox()
        Me.AboutTabs.SuspendLayout()
        Me.GeneralTab.SuspendLayout()
        Me.HelpTab.SuspendLayout()
        Me.SuspendLayout()
        '
        'AboutTabs
        '
        Me.AboutTabs.Controls.Add(Me.GeneralTab)
        Me.AboutTabs.Controls.Add(Me.HelpTab)
        Me.AboutTabs.HotTrack = True
        Me.AboutTabs.Location = New System.Drawing.Point(1, 2)
        Me.AboutTabs.Multiline = True
        Me.AboutTabs.Name = "AboutTabs"
        Me.AboutTabs.SelectedIndex = 0
        Me.AboutTabs.Size = New System.Drawing.Size(309, 260)
        Me.AboutTabs.TabIndex = 0
        '
        'GeneralTab
        '
        Me.GeneralTab.Controls.Add(Me.GeneralText)
        Me.GeneralTab.Location = New System.Drawing.Point(4, 22)
        Me.GeneralTab.Name = "GeneralTab"
        Me.GeneralTab.Padding = New System.Windows.Forms.Padding(3)
        Me.GeneralTab.Size = New System.Drawing.Size(301, 234)
        Me.GeneralTab.TabIndex = 0
        Me.GeneralTab.Text = "General"
        Me.GeneralTab.UseVisualStyleBackColor = True
        '
        'GeneralText
        '
        Me.GeneralText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GeneralText.Location = New System.Drawing.Point(3, 3)
        Me.GeneralText.Multiline = True
        Me.GeneralText.Name = "GeneralText"
        Me.GeneralText.ReadOnly = True
        Me.GeneralText.Size = New System.Drawing.Size(292, 222)
        Me.GeneralText.TabIndex = 0
        Me.GeneralText.Text = resources.GetString("GeneralText.Text")
        '
        'HelpTab
        '
        Me.HelpTab.Controls.Add(Me.HelpText)
        Me.HelpTab.Location = New System.Drawing.Point(4, 22)
        Me.HelpTab.Name = "HelpTab"
        Me.HelpTab.Padding = New System.Windows.Forms.Padding(3)
        Me.HelpTab.Size = New System.Drawing.Size(301, 234)
        Me.HelpTab.TabIndex = 1
        Me.HelpTab.Text = "Help"
        Me.HelpTab.UseVisualStyleBackColor = True
        '
        'HelpText
        '
        Me.HelpText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.HelpText.Location = New System.Drawing.Point(3, 0)
        Me.HelpText.Multiline = True
        Me.HelpText.Name = "HelpText"
        Me.HelpText.ReadOnly = True
        Me.HelpText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.HelpText.Size = New System.Drawing.Size(297, 233)
        Me.HelpText.TabIndex = 0
        Me.HelpText.Text = resources.GetString("HelpText.Text")
        '
        'AboutForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.SteelBlue
        Me.ClientSize = New System.Drawing.Size(313, 262)
        Me.Controls.Add(Me.AboutTabs)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "AboutForm"
        Me.Text = "About"
        Me.AboutTabs.ResumeLayout(False)
        Me.GeneralTab.ResumeLayout(False)
        Me.GeneralTab.PerformLayout()
        Me.HelpTab.ResumeLayout(False)
        Me.HelpTab.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents AboutTabs As System.Windows.Forms.TabControl
    Friend WithEvents GeneralTab As System.Windows.Forms.TabPage
    Friend WithEvents GeneralText As System.Windows.Forms.TextBox
    Friend WithEvents HelpTab As System.Windows.Forms.TabPage
    Friend WithEvents HelpText As System.Windows.Forms.TextBox
End Class
