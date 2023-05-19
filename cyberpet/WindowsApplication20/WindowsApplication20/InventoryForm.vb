Public Class InventoryForm
    Private Sub UseItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UseItem.Click
        '' Checks if food is being used
        If (Inventory.SelectedItem = "CyberFood") Then
            '' feeds the pet
            Feed()
            Inventory.Items.Remove("CyberFood")
        End If
        ''Checks if drink is being used
        If (Inventory.SelectedItem = "CyberDrink") Then
            ''Gives the pet a drink
            UseDrink()
            Inventory.Items.Remove("CyberDrink")
        End If
        ''Checks if boost is being used
        If (Inventory.SelectedItem = "CyberBoost") Then
            '' gives the pet a boost item
            UseBoost()
            Inventory.Items.Remove("CyberBoost")
        End If
        '' Checks if bandage is being used
        If (Inventory.SelectedItem = "CyberBandage") Then
            ''uses a bandage
            UseBandage()
        End If


    End Sub
    Private Sub InventoryForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        For i = 1 To Settings.Food
            Inventory.Items.Add("CyberFood")
        Next i

        For i = 1 To Settings.Drink
            Inventory.Items.Add("CyberDrink")
        Next i

        For i = 1 To Settings.Boost
            Inventory.Items.Add("CyberBoost")
        Next i

        For i = 1 To Settings.Bandage
            Inventory.Items.Add("CyberBandage")
        Next i
    End Sub
End Class