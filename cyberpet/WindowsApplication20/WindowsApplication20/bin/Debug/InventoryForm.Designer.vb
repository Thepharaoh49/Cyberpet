<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class InventoryForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(InventoryForm))
        Me.Inventory = New System.Windows.Forms.ListBox()
        Me.UseItem = New System.Windows.Forms.Button()
        Me.InventoryCashLabel = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Inventory
        '
        Me.Inventory.FormattingEnabled = True
        Me.Inventory.Location = New System.Drawing.Point(12, 12)
        Me.Inventory.Name = "Inventory"
        Me.Inventory.Size = New System.Drawing.Size(199, 381)
        Me.Inventory.TabIndex = 1
        '
        'UseItem
        '
        Me.UseItem.BackColor = System.Drawing.Color.LawnGreen
        Me.UseItem.Location = New System.Drawing.Point(217, 166)
        Me.UseItem.Name = "UseItem"
        Me.UseItem.Size = New System.Drawing.Size(291, 33)
        Me.UseItem.TabIndex = 2
        Me.UseItem.Text = "Use"
        Me.UseItem.UseVisualStyleBackColor = False
        '
        'InventoryCashLabel
        '
        Me.InventoryCashLabel.AutoSize = True
        Me.InventoryCashLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.InventoryCashLabel.Location = New System.Drawing.Point(412, 202)
        Me.InventoryCashLabel.Name = "InventoryCashLabel"
        Me.InventoryCashLabel.Size = New System.Drawing.Size(82, 16)
        Me.InventoryCashLabel.TabIndex = 23
        Me.InventoryCashLabel.Text = "CashLabel"
        '
        'InventoryForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.SteelBlue
        Me.ClientSize = New System.Drawing.Size(520, 405)
        Me.Controls.Add(Me.InventoryCashLabel)
        Me.Controls.Add(Me.UseItem)
        Me.Controls.Add(Me.Inventory)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "InventoryForm"
        Me.ShowInTaskbar = False
        Me.Text = "Inventory"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Inventory As System.Windows.Forms.ListBox
    Friend WithEvents UseItem As System.Windows.Forms.Button
    Friend WithEvents InventoryCashLabel As System.Windows.Forms.Label
End Class
