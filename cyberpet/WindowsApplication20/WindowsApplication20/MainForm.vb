Imports System.IO

Public Class MainForm
    Public savedirectory As String
    Public loaddirectory As String
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '' Start of game; Timer starts, new game is initiated.
        Timer1.Enabled = True
        newgame()
    End Sub
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        '' Checks for new level
        experiencecheck()
        '' Changes cash labels to suit any new changes in cash
        updatecash()
        '' update of progressbars and verticalprogressbars
        If (HungerBar.Value > 0) Then
            HungerBar.Value = HungerBar.Value - 1
        End If
        If (ThirstBar.Value > 0) Then
            ThirstBar.Value = ThirstBar.Value - 1
        End If
        If (ToiletBar.Value < 1000) Then
            If (age > 0) Then
                If (age < 11) Then
                    ToiletBar.Value = ToiletBar.Value + age
                Else
                    ToiletBar.Value = ToiletBar.Value + 10
                End If
            Else
                ToiletBar.Value = ToiletBar.Value + 1
            End If
        End If
        '' Checks if actions are needed based on progressbar values
        checkbars()
        '' Pauses game if needed
        If (PauseBoolean = True) Then
            Threading.Thread.Sleep(0)
        End If
        '' Changes time label to display time
        Dim counter As Byte
        If (counter = 0) Then
            stoptime = Now
            counter = counter + 1
        End If
        TimeText = (DateDiff("s", starttime, stoptime))
        TimeLabel.Text = Convert.ToString(minutes) & " : " & TimeText
        If (TimeText > 59) Then
            '' when 60 seconds have passed, seconds timer is reset, minutes timer is increased
            age = age + 1
            minutes = minutes + 1
            TimeLabel.Text = Convert.ToString(minutes) & " : " & TimeText
            starttime = Now
        End If
        '' Updates age
        AgeLabel.Text = "Age: " & age
        ''Checks to see if the pets karma has changed
        Karmaupdate()
        '' checks to see if there is an injury
        injurycheck()
    End Sub
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        '' Pauses the game when PAUSE is clicked
        pausegame(True)
    End Sub
    Private Sub PetBodyDisplay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PetBodyDisplay.Click
        '' Plays a sound when the pet is clicked, randomly selected from a set of phrases
        annoy()
    End Sub
    Private Sub FOODToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FOODToolStripMenuItem1.Click
        '' feeds the pet
        feed()
    End Sub
    Private Sub DRINKToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DRINKToolStripMenuItem1.Click
        '' gives the pet a drink
        givedrink()
    End Sub
    Private Sub SHOPToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SHOPToolStripMenuItem1.Click
        '' opens the shop
        ShopForm.Show()
    End Sub
    Private Sub PLAYToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PLAYToolStripMenuItem1.Click
        '' plays with the pet
        play()
    End Sub
    Private Sub WEAKToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles WEAKToolStripMenuItem1.Click
        '' fights a weak enemy
        '' calculates chance of winning
        Dim fightchanceweak As Integer = (Module1.randomclass.Next(0, 50 * (Math.Sqrt(Level))))
        '' calculates karma to add
        Dim fightkarmaadd As Integer = (Module1.randomclass.Next(0.1, 0.5))
        '' calculates money that is gambled
        Dim fightmoneyadd As Integer = (Module1.randomclass.Next(1, 50))
        '' calculates experience to add
        Dim experienceadd As Integer = (ExperienceBar.Maximum) / 4
        '' checks that you are capable of fighting
        If (injured = False) Then
            If (EnergyBar.Value > 49) Then
                If (HealthBar.Value > 0) Then
                    Say("You fight a weak enemy")
                    MsgBox("You fight a weak enemy.")
                    ''checks if you win
                    If (fightchanceweak > 4) Then
                        '' Tells the user the fight details
                        Say("you win the fight")
                        MsgBox("You win the fight.")
                        Say("You recieved: " & fightmoneyadd & " Cybercash and " & experienceadd & "experience points")
                        MsgBox("You recieved: " & fightmoneyadd & " Cybercash and " & experienceadd & "experience points")
                        Say("You used up five percent energy")
                        MsgBox("You used up 5% energy")
                        '' updates values
                        Cash = Cash + fightmoneyadd
                        EnergyBar.Value = EnergyBar.Value - 50
                        MoneyEarned = MoneyEarned + fightmoneyadd
                        karmanegativebuffer = karmanegativebuffer + fightkarmaadd
                        If (experienceadd < ((ExperienceBar.Maximum - ExperienceBar.Value))) Then
                            ExperienceBar.Value = ExperienceBar.Value + experienceadd
                        Else
                            ExperienceBar.Value = ExperienceBar.Maximum
                            experiencecheck()
                        End If

                    Else
                        Say("You lose the fight.")
                        MsgBox("You lose the fight.")
                        Say("You lost: " & fightmoneyadd & "CyberCash and became injured.")
                        MsgBox("You lost: " & fightmoneyadd & "CyberCash and became injured.")
                        Say("You used up fifteen percent energy")
                        MsgBox("You used up 15% energy")
                        If (Cash - fightmoneyadd > -1) Then
                            Cash = Cash - fightmoneyadd
                            MoneyLost = MoneyLost + fightmoneyadd
                        Else
                            Cash = 0
                        End If
                        EnergyBar.Value = EnergyBar.Value - 150
                        injured = True
                    End If
                End If
            End If
        Else
            Say("Your pet is injured and cannot fight.")
            MsgBox("Your pet is injured and cannot fight.")
        End If
    End Sub
    Private Sub MEDIUMToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MEDIUMToolStripMenuItem1.Click
        '' fights a medium enemy
        '' calculates chance of winning the fight
        Dim fightchancemedium As Integer = (Module1.randomclass.Next(0, 25 * (Math.Sqrt(Level))))
        '' calculates the amount of money gambled
        Dim fightmoneyaddmedium As Integer = (Module1.randomclass.Next(51, 100))
        '' calculates amount of karma earned/lost
        Dim fightkarmaadd As Integer = (Module1.randomclass.Next(0.1, 0.5))
        '' calculates potential addition to experience
        Dim experienceadd As Integer = (ExperienceBar.Maximum) / 3
        '' checks that you are capable of fighting
        If (injured = False) Then
            If (EnergyBar.Value > 249) Then
                If (HealthBar.Value > 0) Then
                    Say("You fight a medium strength enemy.")
                    MsgBox("You fight a medium strength enemy.")
                    '' checks if you win
                    If (fightchancemedium > 14) Then
                        Say("You win the fight.")
                        MsgBox("You win the fight.")
                        Say("You recieved: " & fightmoneyaddmedium & " Cybercash, and " & experienceadd & "experience points")
                        MsgBox("You recieved: " & fightmoneyaddmedium & " Cybercash, and " & experienceadd & "experience points")
                        Say("You used up ten percent energy")
                        MsgBox("You used up 10% energy")
                        '' updates variables
                        Cash = Cash + fightmoneyaddmedium
                        EnergyBar.Value = EnergyBar.Value - 100
                        MoneyEarned = MoneyEarned + fightmoneyaddmedium
                        If (experienceadd < ((ExperienceBar.Maximum - ExperienceBar.Value))) Then
                            ExperienceBar.Value = ExperienceBar.Value + experienceadd
                        Else
                            ExperienceBar.Value = ExperienceBar.Maximum
                        End If
                        karmanegativebuffer = karmanegativebuffer + fightkarmaadd
                    Else
                        Say("You lose the fight.")
                        MsgBox("You lose the fight.")
                        Say("You lost: " & fightmoneyaddmedium & "CyberCash and became injured.")
                        MsgBox("You lost: " & fightmoneyaddmedium & "CyberCash and became injured.")
                        Say("You used up twenty five percent energy")
                        MsgBox("You used up 25% energy")
                        Cash = Cash - fightmoneyaddmedium
                        If (Cash - fightmoneyaddmedium > -1) Then
                            Cash = Cash - fightmoneyaddmedium
                            MoneyLost = MoneyLost + fightmoneyaddmedium
                        Else
                            Cash = 0
                        End If
                        EnergyBar.Value = EnergyBar.Value - 250
                        injured = True
                    End If
                End If
            End If
        Else
            Say("Your pet is injured and cannot fight.")
            MsgBox("Your pet is injured and cannot fight.")
        End If
    End Sub
    Private Sub SAVEToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SAVEToolStripMenuItem1.Click
        ''Saves the game
        Dim SaveStream As Stream
        '' creates a save dialogue box
        Dim SaveFileDialog1 As New SaveFileDialog()
        '' sets the basic settings for save dialogue
        SaveFileDialog1.Title = "Save Game"
        SaveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*"
        SaveFileDialog1.InitialDirectory = "G:\Visual Studio 2010\Projects\WindowsApplication20\WindowsApplication20\bin\Debug"
        SaveFileDialog1.FilterIndex = 2
        SaveFileDialog1.RestoreDirectory = True
        SaveFileDialog1.FileName = "Save.txt"
        SaveFileDialog1.ShowDialog()
        savedirectory = SaveFileDialog1.FileName

        '' opens the save file for editing
        FileOpen(1, savedirectory, OpenMode.Output)

        Using save As StreamWriter = New StreamWriter("SaveFile")
            '' Saves the given variables to the text file
            save.WriteLine(PetName)
            save.WriteLine(age)
            save.WriteLine(BodyType)
            save.WriteLine(KarmaBar.Value)
            save.WriteLine(HealthBar.Value)
            save.WriteLine(HungerBar.Value)
            save.WriteLine(ThirstBar.Value)
            save.WriteLine(EnergyBar.Value)
            save.WriteLine(ToiletBar.Value)
            save.WriteLine(Cash)
            save.WriteLine(injured)
            save.WriteLine(Food)
            save.WriteLine(Drink)
            save.WriteLine(Boost)
            save.WriteLine(Bandage)
            save.WriteLine(karmabuffer)
            save.WriteLine(WorkLevel)
            save.WriteLine(workbuffer)
            save.WriteLine(Level)
            save.WriteLine(ExperienceBar.Value)
            save.WriteLine(emergencycounter)
            save.WriteLine(MoneyEarned)
            save.WriteLine(MoneyLost)
            save.WriteLine(MoneySpent)

            If (InventoryForm.Inventory.HasChildren) Then
                save.WriteLine(InventoryForm.Inventory.Items)
            Else
                save.WriteLine(0)
            End If

            save.Close()
        End Using

        '' closes the edited file
        FileClose()
    End Sub
    Private Sub LOADToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LOADToolStripMenuItem1.Click
        ''Loads a previous game
        Dim LoadStream As Stream
        ''creates a load dialogue box
        Dim LoadFileDialog1 As New OpenFileDialog()
        '' sets the dialogue box basic details
        LoadFileDialog1.Title = "Load Game"
        LoadFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*"
        LoadFileDialog1.InitialDirectory = savedirectory
        LoadFileDialog1.FilterIndex = 1
        LoadFileDialog1.RestoreDirectory = True
        LoadFileDialog1.FileName = "Save.txt"
        LoadFileDialog1.ShowDialog()
        loaddirectory = LoadFileDialog1.FileName

        '' opens the file to load from
        FileOpen(1, LoadFileDialog1.FileName, OpenMode.Input)

        Using load As StreamReader = New StreamReader(1)

            '' Gets information from the save file and changes the variables accordingly
            PetName = load.ReadLine()
            age = load.ReadLine()
            BodyType = load.ReadLine()
            KarmaBar.Value = load.ReadLine()
            HealthBar.Value = load.ReadLine()
            HungerBar.Value = load.ReadLine()
            ThirstBar.Value = load.ReadLine()
            EnergyBar.Value = load.ReadLine()
            ToiletBar.Value = load.ReadLine()
            Cash = load.ReadLine()
            injured = load.ReadLine()
            Food = load.ReadLine()
            Drink = load.ReadLine()
            Boost = load.ReadLine()
            Bandage = load.ReadLine()
            karmabuffer = load.ReadLine()
            WorkLevel = load.ReadLine()
            workbuffer = load.ReadLine()
            Level = load.ReadLine()
            ExperienceBar.Value = load.ReadLine()
            emergencycounter = load.ReadLine()
            MoneyEarned = load.ReadLine()
            MoneyLost = load.ReadLine()
            MoneySpent = load.ReadLine()

            If (load.Read = 0) Then

            Else
                InventoryForm.Inventory.Items.Add(load.ReadLine())
            End If

            stoptime = Now
            load.Close()
        End Using
        ''Closes the file
        FileClose()
        '' Updates Name Label
        PetNameLabel.Text = PetName
    End Sub
    Private Sub KILLToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles KILLToolStripMenuItem1.Click
        '' Kills the pet to start a new game
        Say("Your pet has died.")
        MsgBox("Your pet has died.")
        newgame()
    End Sub
    Private Sub ToolStripMenuItem6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem6.Click
        '' shows the inventory form
        InventoryForm.Show()
    End Sub
    Private Sub ToolStripMenuItem10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem10.Click
        ''Shows the statistics form
        StatsForm.Show()
    End Sub
    Private Sub TOILETToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TOILETToolStripMenuItem.Click
        '' Sends the pet to the toilet
        ToiletBar.Value = 0
    End Sub
    Private Sub SLEEPToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SLEEPToolStripMenuItem.Click
        '' Toggles between awake and asleep
        If (sleepboolean = False) Then
            SLEEPToolStripMenuItem.Text = "WAKE"
            Say("Your pet is asleep")
            MsgBox("Your pet is asleep")
            sleepboolean = True
        Else
            SLEEPToolStripMenuItem.Text = "SLEEP"
            Say("Your pet has woken up")
            MsgBox("Your pet has woken up")
            sleepboolean = False
        End If
    End Sub
    Private Sub ToolStripMenuItem12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem12.Click
        ''Sends pet to work to earn money
        '' Calculates money to add
        Dim moneyAdd As Integer = (Module1.randomclass.Next((WorkLevel * 5), ((WorkLevel * 5) * WorkLevel)))
        If (EnergyBar.Value > 99) Then
            Say("Your pet goes to work.")
            MsgBox("Your pet goes to work.")
            Say("You recieved: " & moneyAdd & " CyberCash")
            MsgBox("You recieved: " & moneyAdd & " CyberCash")
            Say("You used up ten percent energy")
            MsgBox("You used up 10% energy")
            '' Updates values
            Cash = Cash + moneyAdd
            EnergyBar.Value = EnergyBar.Value - 100
            If (WorkLevel < 100) Then
                workbuffer = workbuffer + 0.5
            End If
            workcheck()
            MoneyEarned = MoneyEarned + moneyAdd
        Else
            Say("You do not have enough energy")
            MsgBox("You do not have enough energy")
        End If
    End Sub
    Private Sub ToolStripMenuItem15_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem15.Click
        '' Shows renaming form
        NameForm.Show()
    End Sub
    Private Sub EmergencyCashButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EmergencyCashButton.Click
        ''Gives the player an emergency cash reserve
        If emergencycounter < 3 Then
            Cash = 25
            emergencycounter = emergencycounter + 1
        ElseIf emergencycounter = 8 Then
            KarmaBar.Value = 0
            karmabuffer = 0
        Else
            Say("You have exceeded the amount of emergency cash withdrawals.")
            MsgBox("You have exceeded the amount of emergency cash withdrawals.")
            emergencycounter = emergencycounter + 1
        End If
    End Sub
    Private Sub STRONGToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles STRONGToolStripMenuItem1.Click
        '' Fights a strong enemy
        '' calculates win chance
        Dim fightchancestrong As Integer = (Module1.randomclass.Next(0, (100 * (Math.Sqrt(Level)))))
        '' calculates money to add/take
        Dim fightmoneyaddstrong As Integer = (Module1.randomclass.Next(101, 200))
        '' calculates karma change
        Dim fightkarmaadd As Integer = (Module1.randomclass.Next(0.1, 0.5))
        ''calculates experience to potentially add
        Dim experienceadd As Integer = (ExperienceBar.Maximum) / 2
        '' checks that the pet is capable of fighting
        If (injured = False) Then
            If (EnergyBar.Value > 249) Then
                If (HealthBar.Value > 0) Then
                    Say("You fight a strong enemy.")
                    MsgBox("You fight a strong enemy.")
                    '' Checks if the pet wins
                    If (fightchancestrong > 49) Then
                        Say("You win the fight.")
                        MsgBox("You win the fight.")
                        Say("You recieved: " & fightmoneyaddstrong & " Cybercash, and " & experienceadd & "experience points")
                        MsgBox("You recieved: " & fightmoneyaddstrong & " Cybercash, and " & experienceadd & "experience points")
                        Say("You used up thirty percent energy")
                        MsgBox("You used up 30% energy")
                        ''Updates values
                        Cash = Cash + fightmoneyaddstrong
                        EnergyBar.Value = EnergyBar.Value - 100
                        MoneyEarned = MoneyEarned + fightmoneyaddstrong
                        If (experienceadd < ((ExperienceBar.Maximum - ExperienceBar.Value))) Then
                            ExperienceBar.Value = ExperienceBar.Value + experienceadd
                        Else
                            ExperienceBar.Value = ExperienceBar.Maximum
                        End If
                        karmanegativebuffer = karmanegativebuffer + fightkarmaadd
                    Else
                        Say("You lose the fight.")
                        MsgBox("You lose the fight.")
                        Say("You lost: " & fightmoneyaddstrong & "CyberCash and became injured.")
                        MsgBox("You lost: " & fightmoneyaddstrong & "CyberCash and became injured.")
                        Say("You used up fifty percent energy")
                        MsgBox("You used up 50% energy")
                        Cash = Cash - fightmoneyaddstrong
                        If (Cash - fightmoneyaddstrong > -1) Then
                            Cash = Cash - fightmoneyaddstrong
                            MoneyLost = MoneyLost + fightmoneyaddstrong
                        Else
                            Cash = 0
                        End If
                        EnergyBar.Value = EnergyBar.Value - 250
                        injured = True
                    End If
                End If
            End If
        Else
            Say("Your pet is injured and cannot fight.")
            MsgBox("Your pet is injured and cannot fight.")
        End If
    End Sub
    Private Sub ToolStripMenuItem13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem13.Click
        '' Brings up the About form
        pausegame(True)
        AboutForm.Show()
    End Sub
    Private Sub PUNISHToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PUNISHToolStripMenuItem.Click
        ''Punishes the pet
        punish()
    End Sub
    Private Sub SETTINGSToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SETTINGSToolStripMenuItem.Click
        ''Brings up the settings form
        SettingsForm.Show()
    End Sub
End Class

'' Changes the parameters of the progressbar so that a vertical one is possible
Public Class VerticalProgressBar
    Inherits ProgressBar
    Protected Overloads Overrides ReadOnly Property CreateParams() As CreateParams
        Get
            Dim cp As CreateParams = MyBase.CreateParams
            cp.Style = cp.Style Or &H4
            Return cp
        End Get
    End Property
End Class