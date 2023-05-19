<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SettingsForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SettingsForm))
        Me.SpeedLabel = New System.Windows.Forms.Label()
        Me.SlowBtn = New System.Windows.Forms.RadioButton()
        Me.NormalBtn = New System.Windows.Forms.RadioButton()
        Me.FastBtn = New System.Windows.Forms.RadioButton()
        Me.StupidBtn = New System.Windows.Forms.RadioButton()
        Me.BackGroundLabel = New System.Windows.Forms.Label()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.TimeCheckLabel = New System.Windows.Forms.Label()
        Me.TimeYes = New System.Windows.Forms.RadioButton()
        Me.TimeNo = New System.Windows.Forms.RadioButton()
        Me.SuspendLayout()
        '
        'SpeedLabel
        '
        Me.SpeedLabel.AutoSize = True
        Me.SpeedLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SpeedLabel.Location = New System.Drawing.Point(3, 18)
        Me.SpeedLabel.Name = "SpeedLabel"
        Me.SpeedLabel.Size = New System.Drawing.Size(103, 16)
        Me.SpeedLabel.TabIndex = 0
        Me.SpeedLabel.Text = "Game Speed:"
        '
        'SlowBtn
        '
        Me.SlowBtn.AutoSize = True
        Me.SlowBtn.Location = New System.Drawing.Point(111, 18)
        Me.SlowBtn.Name = "SlowBtn"
        Me.SlowBtn.Size = New System.Drawing.Size(48, 17)
        Me.SlowBtn.TabIndex = 1
        Me.SlowBtn.Text = "Slow"
        Me.SlowBtn.UseVisualStyleBackColor = True
        '
        'NormalBtn
        '
        Me.NormalBtn.AutoSize = True
        Me.NormalBtn.Location = New System.Drawing.Point(166, 18)
        Me.NormalBtn.Name = "NormalBtn"
        Me.NormalBtn.Size = New System.Drawing.Size(58, 17)
        Me.NormalBtn.TabIndex = 2
        Me.NormalBtn.Text = "Normal"
        Me.NormalBtn.UseVisualStyleBackColor = True
        '
        'FastBtn
        '
        Me.FastBtn.AutoSize = True
        Me.FastBtn.Location = New System.Drawing.Point(231, 18)
        Me.FastBtn.Name = "FastBtn"
        Me.FastBtn.Size = New System.Drawing.Size(45, 17)
        Me.FastBtn.TabIndex = 3
        Me.FastBtn.TabStop = True
        Me.FastBtn.Text = "Fast"
        Me.FastBtn.UseVisualStyleBackColor = True
        '
        'StupidBtn
        '
        Me.StupidBtn.AutoSize = True
        Me.StupidBtn.Location = New System.Drawing.Point(282, 18)
        Me.StupidBtn.Name = "StupidBtn"
        Me.StupidBtn.Size = New System.Drawing.Size(65, 17)
        Me.StupidBtn.TabIndex = 4
        Me.StupidBtn.TabStop = True
        Me.StupidBtn.Text = "STUPID"
        Me.StupidBtn.UseVisualStyleBackColor = True
        '
        'BackGroundLabel
        '
        Me.BackGroundLabel.AutoSize = True
        Me.BackGroundLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BackGroundLabel.Location = New System.Drawing.Point(3, 45)
        Me.BackGroundLabel.Name = "BackGroundLabel"
        Me.BackGroundLabel.Size = New System.Drawing.Size(95, 16)
        Me.BackGroundLabel.TabIndex = 5
        Me.BackGroundLabel.Text = "Background:"
        '
        'ComboBox1
        '
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Items.AddRange(New Object() {"Blue", "Red", "Green", "Pink"})
        Me.ComboBox1.Location = New System.Drawing.Point(138, 42)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(121, 21)
        Me.ComboBox1.TabIndex = 6
        Me.ComboBox1.Text = "----Select a Colour ---"
        '
        'TimeCheckLabel
        '
        Me.TimeCheckLabel.AutoSize = True
        Me.TimeCheckLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TimeCheckLabel.Location = New System.Drawing.Point(3, 71)
        Me.TimeCheckLabel.Name = "TimeCheckLabel"
        Me.TimeCheckLabel.Size = New System.Drawing.Size(88, 16)
        Me.TimeCheckLabel.TabIndex = 7
        Me.TimeCheckLabel.Text = "Show Time:"
        '
        'TimeYes
        '
        Me.TimeYes.AutoSize = True
        Me.TimeYes.Location = New System.Drawing.Point(111, 70)
        Me.TimeYes.Name = "TimeYes"
        Me.TimeYes.Size = New System.Drawing.Size(43, 17)
        Me.TimeYes.TabIndex = 8
        Me.TimeYes.TabStop = True
        Me.TimeYes.Text = "Yes"
        Me.TimeYes.UseVisualStyleBackColor = True
        '
        'TimeNo
        '
        Me.TimeNo.AutoSize = True
        Me.TimeNo.Location = New System.Drawing.Point(169, 71)
        Me.TimeNo.Name = "TimeNo"
        Me.TimeNo.Size = New System.Drawing.Size(39, 17)
        Me.TimeNo.TabIndex = 9
        Me.TimeNo.TabStop = True
        Me.TimeNo.Text = "No"
        Me.TimeNo.UseVisualStyleBackColor = True
        '
        'SettingsForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.SteelBlue
        Me.ClientSize = New System.Drawing.Size(352, 105)
        Me.Controls.Add(Me.TimeNo)
        Me.Controls.Add(Me.TimeYes)
        Me.Controls.Add(Me.TimeCheckLabel)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.BackGroundLabel)
        Me.Controls.Add(Me.StupidBtn)
        Me.Controls.Add(Me.FastBtn)
        Me.Controls.Add(Me.NormalBtn)
        Me.Controls.Add(Me.SlowBtn)
        Me.Controls.Add(Me.SpeedLabel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "SettingsForm"
        Me.Text = " Settings"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents SpeedLabel As System.Windows.Forms.Label
    Friend WithEvents SlowBtn As System.Windows.Forms.RadioButton
    Friend WithEvents NormalBtn As System.Windows.Forms.RadioButton
    Friend WithEvents FastBtn As System.Windows.Forms.RadioButton
    Friend WithEvents StupidBtn As System.Windows.Forms.RadioButton
    Friend WithEvents BackGroundLabel As System.Windows.Forms.Label
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents TimeCheckLabel As System.Windows.Forms.Label
    Friend WithEvents TimeYes As System.Windows.Forms.RadioButton
    Friend WithEvents TimeNo As System.Windows.Forms.RadioButton
End Class
