Public Class SettingsForm
    Private Sub SlowBtn_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SlowBtn.CheckedChanged
        ''changes speed
        If (SlowBtn.Checked = True) Then
            NormalBtn.Checked = False
            FastBtn.Checked = False
            StupidBtn.Checked = False
            MainForm.Timer1.Interval = 1000
        Else
        End If
    End Sub
    Private Sub NormalBtn_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NormalBtn.CheckedChanged
        ''changes speed
        If (NormalBtn.Checked = True) Then
            SlowBtn.Checked = False
            FastBtn.Checked = False
            StupidBtn.Checked = False
            MainForm.Timer1.Interval = 100
        Else
        End If
    End Sub
    Private Sub FastBtn_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FastBtn.CheckedChanged
        ''changes speed
        If (FastBtn.Checked = True) Then
            NormalBtn.Checked = False
            SlowBtn.Checked = False
            StupidBtn.Checked = False
            MainForm.Timer1.Interval = 10
        Else
        End If
    End Sub
    Private Sub StupidBtn_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StupidBtn.CheckedChanged
        ''changes speed
        If (StupidBtn.Checked = True) Then
            NormalBtn.Checked = False
            SlowBtn.Checked = False
            FastBtn.Checked = False
            MainForm.Timer1.Interval = 1
        Else
        End If
    End Sub
    Public Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        ''sets the background colour
        If (ComboBox1.SelectedItem = "Blue") Then
            AboutForm.BackColor = Color.SteelBlue
            InventoryForm.BackColor = Color.SteelBlue
            MainForm.BackColor = Color.SteelBlue
            NameForm.BackColor = Color.SteelBlue
            settingscolour = "Blue"
            ShopForm.BackColor = Color.SteelBlue
            StatsForm.BackColor = Color.SteelBlue

            MainForm.MenuStrip1.BackColor = Color.LawnGreen
            MainForm.MenuStrip2.BackColor = Color.LawnGreen
            MainForm.EmergencyCashButton.BackColor = Color.LawnGreen
            MainForm.Button3.BackColor = Color.LawnGreen
            ShopForm.BuyItem.BackColor = Color.LawnGreen
            NameForm.NamePetOk.BackColor = Color.LawnGreen
            NameForm.NamePetBox.BackColor = Color.LawnGreen
            NameForm.RenameCancel.BackColor = Color.LawnGreen
            InventoryForm.UseItem.BackColor = Color.LawnGreen

        ElseIf (ComboBox1.SelectedItem = "Red") Then
            AboutForm.BackColor = Color.IndianRed
            InventoryForm.BackColor = Color.IndianRed
            MainForm.BackColor = Color.IndianRed
            NameForm.BackColor = Color.IndianRed
            settingscolour = "Red"
            ShopForm.BackColor = Color.IndianRed
            StatsForm.BackColor = Color.IndianRed

            MainForm.MenuStrip1.BackColor = Color.SteelBlue
            MainForm.MenuStrip2.BackColor = Color.SteelBlue
            MainForm.EmergencyCashButton.BackColor = Color.SteelBlue
            MainForm.Button3.BackColor = Color.SteelBlue
            ShopForm.BuyItem.BackColor = Color.SteelBlue
            NameForm.NamePetOk.BackColor = Color.SteelBlue
            NameForm.NamePetBox.BackColor = Color.SteelBlue
            NameForm.RenameCancel.BackColor = Color.SteelBlue
            InventoryForm.UseItem.BackColor = Color.SteelBlue

        ElseIf (ComboBox1.SelectedItem = "Green") Then
            AboutForm.BackColor = Color.Green
            InventoryForm.BackColor = Color.Green
            MainForm.BackColor = Color.Green
            NameForm.BackColor = Color.Green
            settingscolour = "Green"
            ShopForm.BackColor = Color.Green
            StatsForm.BackColor = Color.Green

            MainForm.MenuStrip1.BackColor = Color.IndianRed
            MainForm.MenuStrip2.BackColor = Color.IndianRed
            MainForm.EmergencyCashButton.BackColor = Color.IndianRed
            MainForm.Button3.BackColor = Color.IndianRed
            ShopForm.BuyItem.BackColor = Color.IndianRed
            NameForm.NamePetOk.BackColor = Color.IndianRed
            NameForm.NamePetBox.BackColor = Color.IndianRed
            NameForm.RenameCancel.BackColor = Color.IndianRed
            InventoryForm.UseItem.BackColor = Color.IndianRed

        ElseIf (ComboBox1.SelectedItem = "Pink") Then
            AboutForm.BackColor = Color.LightPink
            InventoryForm.BackColor = Color.LightPink
            MainForm.BackColor = Color.LightPink
            NameForm.BackColor = Color.LightPink
            settingscolour = "Pink"
            ShopForm.BackColor = Color.LightPink
            StatsForm.BackColor = Color.LightPink

            MainForm.MenuStrip1.BackColor = Color.LightYellow
            MainForm.MenuStrip2.BackColor = Color.LightYellow
            MainForm.EmergencyCashButton.BackColor = Color.LightYellow
            MainForm.Button3.BackColor = Color.LightYellow
            ShopForm.BuyItem.BackColor = Color.LightYellow
            NameForm.NamePetOk.BackColor = Color.LightYellow
            NameForm.NamePetBox.BackColor = Color.LightYellow
            NameForm.RenameCancel.BackColor = Color.LightYellow
            InventoryForm.UseItem.BackColor = Color.LightYellow
        End If
        Backgroundcheck()
    End Sub
    Private Sub TimeYes_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TimeYes.CheckedChanged
        '' Shows the timer
        If (TimeYes.Checked = True) Then
            TimeNo.Checked = False
            MainForm.TimeLabel.Visible = True
        Else
        End If

    End Sub
    Private Sub TimeNo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TimeNo.CheckedChanged
        '' hides the timer
        If (TimeNo.Checked = True) Then
            TimeYes.Checked = False
            MainForm.TimeLabel.Visible = False
        Else
        End If
    End Sub
    Private Sub SettingsForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Backgroundcheck()
    End Sub
End Class