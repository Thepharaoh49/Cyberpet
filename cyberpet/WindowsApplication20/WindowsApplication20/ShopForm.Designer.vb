<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ShopForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ShopForm))
        Me.ShopInventory = New System.Windows.Forms.ListBox()
        Me.BuyItem = New System.Windows.Forms.Button()
        Me.ShopCashLabel = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'ShopInventory
        '
        Me.ShopInventory.FormattingEnabled = True
        Me.ShopInventory.Items.AddRange(New Object() {"CyberFood", "CyberDrink", "CyberBoost", "CyberBandage"})
        Me.ShopInventory.Location = New System.Drawing.Point(12, 12)
        Me.ShopInventory.Name = "ShopInventory"
        Me.ShopInventory.Size = New System.Drawing.Size(204, 69)
        Me.ShopInventory.TabIndex = 0
        '
        'BuyItem
        '
        Me.BuyItem.BackColor = System.Drawing.Color.LawnGreen
        Me.BuyItem.Location = New System.Drawing.Point(259, 48)
        Me.BuyItem.Name = "BuyItem"
        Me.BuyItem.Size = New System.Drawing.Size(79, 33)
        Me.BuyItem.TabIndex = 1
        Me.BuyItem.Text = "Buy"
        Me.BuyItem.UseVisualStyleBackColor = False
        '
        'ShopCashLabel
        '
        Me.ShopCashLabel.AutoSize = True
        Me.ShopCashLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ShopCashLabel.Location = New System.Drawing.Point(256, 84)
        Me.ShopCashLabel.Name = "ShopCashLabel"
        Me.ShopCashLabel.Size = New System.Drawing.Size(82, 16)
        Me.ShopCashLabel.TabIndex = 22
        Me.ShopCashLabel.Text = "CashLabel"
        '
        'ShopForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.SteelBlue
        Me.ClientSize = New System.Drawing.Size(368, 118)
        Me.Controls.Add(Me.ShopCashLabel)
        Me.Controls.Add(Me.BuyItem)
        Me.Controls.Add(Me.ShopInventory)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "ShopForm"
        Me.ShowInTaskbar = False
        Me.Text = "Shop"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ShopInventory As System.Windows.Forms.ListBox
    Friend WithEvents BuyItem As System.Windows.Forms.Button
    Friend WithEvents ShopCashLabel As System.Windows.Forms.Label
End Class
