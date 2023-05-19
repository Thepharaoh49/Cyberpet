Public Class ShopForm
    Private Sub BuyItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BuyItem.Click
        '' checks if food is selected
        If (ShopInventory.SelectedItem = "CyberFood") Then
            If (Settings.Cash > 4) Then
                '' Checks that there is enough Money
                Settings.Cash -= 5
                '' Adds food to the inventory
                Settings.Food += 1
                MoneySpent += 5
            Else
                Say("You do not have enough CyberCash")
            End If
        End If
        '' checks if drink is selected
        If (ShopInventory.SelectedItem = "CyberDrink") Then
            If (Settings.Cash > 4) Then
                '' checks that there is enough money
                Settings.Cash -= 5
                '' adds drink to inventory
                Settings.Drink += 1
                MoneySpent += 5

            Else
                Say("You do not have enough CyberCash")
            End If
        End If
        '' checks if boost is selected
        If (ShopInventory.SelectedItem = "CyberBoost") Then
            If (Settings.Cash > 9) Then
                '' checks that there is enough money
                Settings.Cash -= 10
                ''adds boost to inventory
                Settings.Boost += 1
                MoneySpent += 10
            Else
                Say("You do not have enough CyberCash")
            End If
        End If
        ''Checks if bandage is selected
        If (ShopInventory.SelectedItem = "CyberBandage") Then
            If (Settings.Cash > 24) Then
                ''checks that there is enough money
                Settings.Cash -= 25
                '' adds bandage to inventory
                Settings.Bandage += 1
                MoneySpent += 25
            Else
                Say("You do not have enough CyberCash")
            End If
        End If
    End Sub
End Class