Public Class SettingsForm
    Private Sub SlowBtn_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SlowBtn.CheckedChanged
        ''changes speed
        If (SlowBtn.Checked = True) Then
            Settings.GameSpeed = 1000
            NormalBtn.Checked = False
            FastBtn.Checked = False
            StupidBtn.Checked = False
        Else
        End If
    End Sub
    Private Sub NormalBtn_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NormalBtn.CheckedChanged
        ''changes speed
        If (NormalBtn.Checked = True) Then
            Settings.GameSpeed = 100
            SlowBtn.Checked = False
            FastBtn.Checked = False
            StupidBtn.Checked = False
        Else
        End If
    End Sub
    Private Sub FastBtn_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FastBtn.CheckedChanged
        ''changes speed
        If (FastBtn.Checked = True) Then
            Settings.GameSpeed = 10
            NormalBtn.Checked = False
            SlowBtn.Checked = False
            StupidBtn.Checked = False
        Else
        End If
    End Sub
    Private Sub StupidBtn_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StupidBtn.CheckedChanged
        ''changes speed
        If (StupidBtn.Checked = True) Then
            Settings.GameSpeed = 1
            NormalBtn.Checked = False
            SlowBtn.Checked = False
            FastBtn.Checked = False
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
        MsgCheckbox.Checked = Settings.MsgEnabled
        TTSCheckBox.Checked = Settings.TTSEnabled
        StupidBtn.Checked = False
        NormalBtn.Checked = False
        SlowBtn.Checked = False
        FastBtn.Checked = False

        Select Case (Settings.GameSpeed)
            Case 1
                StupidBtn.Checked = True
            Case 10
                FastBtn.Checked = True
            Case 100
                NormalBtn.Checked = True
            Case 1000
                SlowBtn.Checked = True
        End Select
    End Sub

    Private Sub TTSCheckBox_CheckedChanged(sender As Object, e As EventArgs) Handles TTSCheckBox.CheckedChanged
        Settings.TTSEnabled = TTSCheckBox.Checked
    End Sub

    Private Sub MsgCheckbox_CheckedChanged(sender As Object, e As EventArgs) Handles MsgCheckbox.CheckedChanged
        Settings.MsgEnabled = MsgCheckbox.Checked
    End Sub
End Class