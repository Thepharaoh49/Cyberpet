<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class StatsForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(StatsForm))
        Me.WorkLevelLabel = New System.Windows.Forms.Label()
        Me.KarmaLevelLabel = New System.Windows.Forms.Label()
        Me.StatsFormCashLabel = New System.Windows.Forms.Label()
        Me.StatsFormAgeLabel = New System.Windows.Forms.Label()
        Me.MoneySpentLabel = New System.Windows.Forms.Label()
        Me.MoneyEarnedLabel = New System.Windows.Forms.Label()
        Me.MoneyLostLabel = New System.Windows.Forms.Label()
        Me.LevelLabel = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'WorkLevelLabel
        '
        Me.WorkLevelLabel.AutoSize = True
        Me.WorkLevelLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.WorkLevelLabel.Location = New System.Drawing.Point(26, 29)
        Me.WorkLevelLabel.Name = "WorkLevelLabel"
        Me.WorkLevelLabel.Size = New System.Drawing.Size(102, 20)
        Me.WorkLevelLabel.TabIndex = 0
        Me.WorkLevelLabel.Text = "Work Level:"
        '
        'KarmaLevelLabel
        '
        Me.KarmaLevelLabel.AutoSize = True
        Me.KarmaLevelLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KarmaLevelLabel.Location = New System.Drawing.Point(26, 61)
        Me.KarmaLevelLabel.Name = "KarmaLevelLabel"
        Me.KarmaLevelLabel.Size = New System.Drawing.Size(112, 20)
        Me.KarmaLevelLabel.TabIndex = 1
        Me.KarmaLevelLabel.Text = "Karma Level:"
        '
        'StatsFormCashLabel
        '
        Me.StatsFormCashLabel.AutoSize = True
        Me.StatsFormCashLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.StatsFormCashLabel.Location = New System.Drawing.Point(26, 95)
        Me.StatsFormCashLabel.Name = "StatsFormCashLabel"
        Me.StatsFormCashLabel.Size = New System.Drawing.Size(101, 20)
        Me.StatsFormCashLabel.TabIndex = 2
        Me.StatsFormCashLabel.Text = "CyberCash:"
        '
        'StatsFormAgeLabel
        '
        Me.StatsFormAgeLabel.AutoSize = True
        Me.StatsFormAgeLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.StatsFormAgeLabel.Location = New System.Drawing.Point(26, 129)
        Me.StatsFormAgeLabel.Name = "StatsFormAgeLabel"
        Me.StatsFormAgeLabel.Size = New System.Drawing.Size(46, 20)
        Me.StatsFormAgeLabel.TabIndex = 3
        Me.StatsFormAgeLabel.Text = "Age:"
        '
        'MoneySpentLabel
        '
        Me.MoneySpentLabel.AutoSize = True
        Me.MoneySpentLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MoneySpentLabel.Location = New System.Drawing.Point(26, 160)
        Me.MoneySpentLabel.Name = "MoneySpentLabel"
        Me.MoneySpentLabel.Size = New System.Drawing.Size(119, 20)
        Me.MoneySpentLabel.TabIndex = 4
        Me.MoneySpentLabel.Text = "Money Spent:"
        '
        'MoneyEarnedLabel
        '
        Me.MoneyEarnedLabel.AutoSize = True
        Me.MoneyEarnedLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MoneyEarnedLabel.Location = New System.Drawing.Point(26, 189)
        Me.MoneyEarnedLabel.Name = "MoneyEarnedLabel"
        Me.MoneyEarnedLabel.Size = New System.Drawing.Size(129, 20)
        Me.MoneyEarnedLabel.TabIndex = 5
        Me.MoneyEarnedLabel.Text = "Money Earned:"
        '
        'MoneyLostLabel
        '
        Me.MoneyLostLabel.AutoSize = True
        Me.MoneyLostLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MoneyLostLabel.Location = New System.Drawing.Point(26, 219)
        Me.MoneyLostLabel.Name = "MoneyLostLabel"
        Me.MoneyLostLabel.Size = New System.Drawing.Size(180, 20)
        Me.MoneyLostLabel.TabIndex = 6
        Me.MoneyLostLabel.Text = "Money Lost in Fights:"
        '
        'LevelLabel
        '
        Me.LevelLabel.AutoSize = True
        Me.LevelLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LevelLabel.Location = New System.Drawing.Point(205, 275)
        Me.LevelLabel.Name = "LevelLabel"
        Me.LevelLabel.Size = New System.Drawing.Size(83, 29)
        Me.LevelLabel.TabIndex = 7
        Me.LevelLabel.Text = "Level:"
        '
        'StatsForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.SteelBlue
        Me.ClientSize = New System.Drawing.Size(555, 344)
        Me.Controls.Add(Me.LevelLabel)
        Me.Controls.Add(Me.MoneyLostLabel)
        Me.Controls.Add(Me.MoneyEarnedLabel)
        Me.Controls.Add(Me.MoneySpentLabel)
        Me.Controls.Add(Me.StatsFormAgeLabel)
        Me.Controls.Add(Me.StatsFormCashLabel)
        Me.Controls.Add(Me.KarmaLevelLabel)
        Me.Controls.Add(Me.WorkLevelLabel)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "StatsForm"
        Me.Text = "Statistics"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents WorkLevelLabel As System.Windows.Forms.Label
    Friend WithEvents KarmaLevelLabel As System.Windows.Forms.Label
    Friend WithEvents StatsFormCashLabel As System.Windows.Forms.Label
    Friend WithEvents StatsFormAgeLabel As System.Windows.Forms.Label
    Friend WithEvents MoneySpentLabel As System.Windows.Forms.Label
    Friend WithEvents MoneyEarnedLabel As System.Windows.Forms.Label
    Friend WithEvents MoneyLostLabel As System.Windows.Forms.Label
    Friend WithEvents LevelLabel As System.Windows.Forms.Label
End Class
