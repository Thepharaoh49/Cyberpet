Public Class StatsForm
    Private Sub StatsForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        WorkLevelLabel.Text = "Work Level: " & Pet.WorkLevel
        KarmaLevelLabel.Text = "Karma Level: " & MainForm.KarmaBar.Value
        StatsFormCashLabel.Text = "CyberCash: £" & Settings.Cash
        StatsFormAgeLabel.Text = "Age: " & Pet.Age
        MoneySpentLabel.Text = "CyberCash Spent: £" & MoneySpent
        MoneyEarnedLabel.Text = "CyberCash Earned: £" & MoneyEarned
        MoneyLostLabel.Text = "CyberCash Lost in Fights: £" & MoneyLost
        LevelLabel.Text = "Level: " & Pet.Level
    End Sub
End Class