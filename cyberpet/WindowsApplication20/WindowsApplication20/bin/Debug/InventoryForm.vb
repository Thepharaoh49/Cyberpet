Public Class InventoryForm
    Private Sub UseItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UseItem.Click
        '' Checks if food is being used
        If (Inventory.SelectedItem = "CyberFood") Then
            '' feeds the pet
            feed()
            Inventory.Items.Remove("CyberFood")
        End If
        ''Checks if drink is being used
        If (Inventory.SelectedItem = "CyberDrink") Then
            ''Gives the pet a drink
            givedrink()
            Inventory.Items.Remove("CyberDrink")
        End If
        ''Checks if boost is being used
        If (Inventory.SelectedItem = "CyberBoost") Then
            '' gives the pet a boost item
            giveboost()
            Inventory.Items.Remove("CyberBoost")
        End If
        '' Checks if bandage is being used
        If (Inventory.SelectedItem = "CyberBandage") Then
            ''uses a bandage
            givebandage()
        End If


    End Sub
    Private Sub InventoryForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim foodcounter As Integer = Food
        For i = 1 To foodcounter
            Inventory.Items.Add("CyberFood")
        Next i

        Dim drinkcounter As Integer = Drink
        For i = 1 To drinkcounter
            Inventory.Items.Add("CyberDrink")
        Next i

        Dim boostcounter As Integer = Boost
        For i = 1 To boostcounter
            Inventory.Items.Add("CyberBoost")
        Next i

        Dim bandagecounter As Integer = Bandage
        For i = 1 To bandagecounter
            Inventory.Items.Add("CyberBandage")
        Next i
    End Sub
End Class