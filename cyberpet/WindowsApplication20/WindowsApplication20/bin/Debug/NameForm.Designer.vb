<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class NameForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(NameForm))
        Me.NamePetBox = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.NamePetOk = New System.Windows.Forms.Button()
        Me.RenameCancel = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'NamePetBox
        '
        Me.NamePetBox.BackColor = System.Drawing.Color.LawnGreen
        Me.NamePetBox.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.NamePetBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NamePetBox.Location = New System.Drawing.Point(53, 133)
        Me.NamePetBox.Name = "NamePetBox"
        Me.NamePetBox.Size = New System.Drawing.Size(158, 22)
        Me.NamePetBox.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(30, 85)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(223, 16)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Enter a name for your CyberPet"
        '
        'NamePetOk
        '
        Me.NamePetOk.BackColor = System.Drawing.Color.LawnGreen
        Me.NamePetOk.Location = New System.Drawing.Point(102, 195)
        Me.NamePetOk.Name = "NamePetOk"
        Me.NamePetOk.Size = New System.Drawing.Size(70, 33)
        Me.NamePetOk.TabIndex = 2
        Me.NamePetOk.Text = "OK"
        Me.NamePetOk.UseVisualStyleBackColor = False
        '
        'RenameCancel
        '
        Me.RenameCancel.BackColor = System.Drawing.Color.LawnGreen
        Me.RenameCancel.Location = New System.Drawing.Point(102, 227)
        Me.RenameCancel.Name = "RenameCancel"
        Me.RenameCancel.Size = New System.Drawing.Size(70, 23)
        Me.RenameCancel.TabIndex = 3
        Me.RenameCancel.Text = "Cancel"
        Me.RenameCancel.UseVisualStyleBackColor = False
        '
        'NameForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.SteelBlue
        Me.ClientSize = New System.Drawing.Size(284, 262)
        Me.Controls.Add(Me.RenameCancel)
        Me.Controls.Add(Me.NamePetOk)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.NamePetBox)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "NameForm"
        Me.ShowInTaskbar = False
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Name Your Pet"
        Me.TopMost = True
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents NamePetBox As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents NamePetOk As System.Windows.Forms.Button
    Friend WithEvents RenameCancel As System.Windows.Forms.Button
End Class
