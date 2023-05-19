Public Class StatsForm
    Private Sub StatsForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        WorkLevelLabel.Text = "Work Level: " & WorkLevel
        KarmaLevelLabel.Text = "Karma Level: " & MainForm.KarmaBar.Value
        StatsFormCashLabel.Text = "CyberCash: £" & Cash
        StatsFormAgeLabel.Text = "Age: " & age
        MoneySpentLabel.Text = "CyberCash Spent: £" & MoneySpent
        MoneyEarnedLabel.Text = "CyberCash Earned: £" & MoneyEarned
        MoneyLostLabel.Text = "CyberCash Lost in Fights: £" & MoneyLost
        LevelLabel.Text = "Level: " & Level
    End Sub
End Class