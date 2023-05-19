Public Class ShopForm
    Private Sub BuyItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BuyItem.Click
        '' checks if food is selected
        If (ShopInventory.SelectedItem = "CyberFood") Then
            If (Cash > 4) Then
                '' Checks that there is enough Money
                Cash = Cash - 5
                '' Adds food to the inventory
                Food = Food + 1
                MoneySpent = MoneySpent + 5
            Else
                Say("You do not have enough CyberCash")
            End If
        End If
        '' checks if drink is selected
        If (ShopInventory.SelectedItem = "CyberDrink") Then
            If (Cash > 4) Then
                '' checks that there is enough money
                Cash = Cash - 5
                '' adds drink to inventory
                Drink = Drink + 1
                MoneySpent = MoneySpent + 5

            Else
                Say("You do not have enough CyberCash")
            End If
        End If
        '' checks if boost is selected
        If (ShopInventory.SelectedItem = "CyberBoost") Then
            If (Cash > 9) Then
                '' checks that there is enough money
                Cash = Cash - 10
                ''adds boost to inventory
                Boost = Boost + 1
                MoneySpent = MoneySpent + 10
            Else
                Say("You do not have enough CyberCash")
            End If
        End If
        ''Checks if bandage is selected
        If (ShopInventory.SelectedItem = "CyberBandage") Then
            If (Cash > 24) Then
                ''checks that there is enough money
                Cash = Cash - 25
                '' adds bandage to inventory
                Bandage = Bandage + 1
                MoneySpent = MoneySpent + 25
            Else
                Say("You do not have enough CyberCash")
            End If
        End If
    End Sub
End Class