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
        Dim backColour As Color
        Dim foreColour As Color
        If (ComboBox1.SelectedItem = "Blue") Then
            backColour = Color.SteelBlue
            foreColour = Color.LawnGreen
            settingscolour = "Blue"
        ElseIf (ComboBox1.SelectedItem = "Red") Then
            backColour = Color.IndianRed
            foreColour = Color.SteelBlue
            settingscolour = "Red"
        ElseIf (ComboBox1.SelectedItem = "Green") Then
            backColour = Color.Green
            foreColour = Color.IndianRed
            settingscolour = "Green"
        ElseIf (ComboBox1.SelectedItem = "Pink") Then
            backColour = Color.LightPink
            foreColour = Color.LightYellow
            settingscolour = "Pink"
        End If


        AboutForm.BackColor = backColour
        InventoryForm.BackColor = backColour
        MainForm.BackColor = backColour
        NameForm.BackColor = backColour
        ShopForm.BackColor = backColour
        StatsForm.BackColor = backColour

        MainForm.MenuStrip1.BackColor = foreColour
        MainForm.MenuStrip2.BackColor = foreColour
        MainForm.Button3.BackColor = foreColour
        ShopForm.BuyItem.BackColor = foreColour
        NameForm.NamePetOk.BackColor = foreColour
        NameForm.NamePetBox.BackColor = foreColour
        NameForm.RenameCancel.BackColor = foreColour
        InventoryForm.UseItem.BackColor = foreColour

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