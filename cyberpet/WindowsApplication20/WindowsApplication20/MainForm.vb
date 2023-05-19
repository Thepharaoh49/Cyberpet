Imports System.IO

Public Class MainForm
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '' Start of game; Timer starts, new game is initiated.
        Timer1.Enabled = True
        newgame()
    End Sub
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        '' Changes cash labels to suit any new changes in cash
        updatecash()
        '' update of progressbars and verticalprogressbars

        Pet.OnTick()

        '' Checks if actions are needed based on progressbar values
        checkbars()

        '' Changes time label to display time
        TimeText = (DateDiff("s", starttime, stoptime))
        TimeLabel.Text = Convert.ToString(minutes) & " : " & TimeText
        If (TimeText > 59) Then
            '' when 60 seconds have passed, seconds timer is reset, minutes timer is increased
            Pet.Age += 1
            minutes += 1
            TimeLabel.Text = Convert.ToString(minutes) & " : " & TimeText
            starttime = Now
        End If
        '' Updates age
        AgeLabel.Text = "Age: " & Pet.Age
    End Sub
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        '' Pauses the game when PAUSE is clicked
        Pause()
    End Sub
    Private Sub PetBodyDisplay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PetBodyDisplay.Click
        '' Plays a sound when the pet is clicked, randomly selected from a set of phrases
        Annoy()
    End Sub
    Private Sub FOODToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FOODToolStripMenuItem1.Click
        '' feeds the pet
        Feed()
    End Sub
    Private Sub DRINKToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DRINKToolStripMenuItem1.Click
        '' gives the pet a drink
        UseDrink()
    End Sub
    Private Sub SHOPToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SHOPToolStripMenuItem1.Click
        '' opens the shop
        ShopForm.Show()
    End Sub
    Private Sub PLAYToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PLAYToolStripMenuItem1.Click
        '' plays with the pet
        Pet.play()
    End Sub
    Private Sub FightEnemy(enemyLevel As String)
        Dim SuccessChance As Integer
        Dim KarmaChange As Integer
        Dim MoneyChange As Integer
        Dim ExpChange As Integer
        Dim mult = 0
        Dim EnergyGain = 5
        Dim EnergyLose = 15
        Select Case (enemyLevel)
            Case "Medium"
                mult = 1
                EnergyGain = 10
                EnergyLose = 25
            Case "Strong"
                mult = 2
                EnergyGain = 30
                EnergyLose = 50
        End Select

        SuccessChance = Module1.random.Next(50 * mult, 50 * (mult + 1)) * (Math.Sqrt(Pet.Level))
        MoneyChange = Module1.random.Next((50 * mult) + 1, 50 * (mult + 1))
        KarmaChange = Module1.random.Next(0.1, 0.5)
        ExpChange = ExperienceBar.Maximum / (4 - mult)

        If (Pet.Injured) Then
            Say("Your pet is injured and cannot fight.")
            Return
        End If
        If Not (Pet.Energy > 49 And Pet.Health > 0) Then
            Say("Your pet is not fit enough to fight.")
            Return
        End If

        Say($"You fight a {enemyLevel} enemy")

        If SuccessChance > (4 + (10 * mult)) Then
            Say("You win the fight")
            Say($"You recieved: {MoneyChange} Cybercash and {ExpChange} experience points")
            Say($"You used up {EnergyGain} percent energy")
            Settings.Cash += MoneyChange
            Pet.Energy -= EnergyGain * 10
            MoneyEarned += MoneyChange
            Pet.KarmaExp -= KarmaChange
            Pet.Experience += ExpChange
        Else
            Say("You lose the fight.")
            Say($"You lost: {MoneyChange} CyberCash and became injured.")
            Say($"You used up {EnergyLose} percent energy")
            If (Settings.Cash - MoneyChange > -1) Then
                Settings.Cash -= MoneyChange
                MoneyLost += MoneyChange
            Else
                Settings.Cash = 0
            End If
            Pet.Energy -= EnergyLose * 10
            Pet.Injured = True
        End If

    End Sub
    Private Sub WEAKToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles WEAKToolStripMenuItem1.Click
        FightEnemy("Weak")
    End Sub
    Private Sub MEDIUMToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MEDIUMToolStripMenuItem1.Click
        FightEnemy("Medium")
    End Sub
    Private Sub STRONGToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles STRONGToolStripMenuItem1.Click
        FightEnemy("Strong")
    End Sub
    Private Sub SAVEToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SAVEToolStripMenuItem1.Click
        ''Saves the game
        '' creates a save dialogue box
        '' sets the basic settings for save dialogue
        Dim SaveFileDialog1 As New SaveFileDialog With {
            .Title = "Save Game",
            .Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*",
            .FilterIndex = 2,
            .RestoreDirectory = True,
            .FileName = "Save.txt"
        }
        SaveFileDialog1.ShowDialog()
        Dim savedirectory = SaveFileDialog1.FileName

        '' opens the save file for editing
        FileOpen(1, savedirectory, OpenMode.Output)

        Using save As StreamWriter = New StreamWriter("SaveFile")
            '' Saves the given variables to the text file
            save.WriteLine(Pet.Name)
            save.WriteLine(Pet.Age)
            save.WriteLine(Pet.Karma)
            save.WriteLine(Pet.Health)
            save.WriteLine(Pet.Hunger)
            save.WriteLine(Pet.Thirst)
            save.WriteLine(Pet.Energy)
            save.WriteLine(Pet.Toilet)
            save.WriteLine(Settings.Cash)
            save.WriteLine(Pet.Injured)
            save.WriteLine(Settings.Food)
            save.WriteLine(Settings.Drink)
            save.WriteLine(Settings.Boost)
            save.WriteLine(Settings.Bandage)
            save.WriteLine(Pet.KarmaExp)
            save.WriteLine(Pet.WorkLevel)
            save.WriteLine(Pet.workbuffer)
            save.WriteLine(Pet.Level)
            save.WriteLine(Pet.Experience)
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
        ''creates a load dialogue box
        '' sets the dialogue box basic details
        Dim LoadFileDialog1 As New OpenFileDialog With {
            .Title = "Load Game",
            .Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*",
            .FilterIndex = 1,
            .RestoreDirectory = True,
            .FileName = "Save.txt"
        }
        LoadFileDialog1.ShowDialog()
        Dim loaddirectory = LoadFileDialog1.FileName

        '' opens the file to load from
        FileOpen(1, LoadFileDialog1.FileName, OpenMode.Input)

        Using load As StreamReader = New StreamReader(1)

            '' Gets information from the save file and changes the variables accordingly
            Pet.Name = load.ReadLine()
            Pet.Age = load.ReadLine()
            KarmaBar.Value = load.ReadLine()
            HealthBar.Value = load.ReadLine()
            Pet.Hunger = load.ReadLine()
            Pet.Thirst = load.ReadLine()
            EnergyBar.Value = load.ReadLine()
            Pet.Toilet = load.ReadLine()
            Settings.Cash = load.ReadLine()
            Pet.Injured = load.ReadLine()
            Settings.Food = load.ReadLine()
            Settings.Drink = load.ReadLine()
            Settings.Boost = load.ReadLine()
            Settings.Bandage = load.ReadLine()
            karmabuffer = load.ReadLine()
            Pet.WorkLevel = load.ReadLine()
            Pet.workbuffer = load.ReadLine()
            Pet.Level = load.ReadLine()
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
        PetNameLabel.Text = Pet.Name
    End Sub
    Private Sub KILLToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles KILLToolStripMenuItem1.Click
        '' Kills the pet to start a new game
        Say("Your pet has died.")
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
        Pet.Toilet = 0
    End Sub
    Private Sub SLEEPToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SLEEPToolStripMenuItem.Click
        '' Toggles between awake and asleep
        If (Pet.Asleep = False) Then
            SLEEPToolStripMenuItem.Text = "WAKE"
            Say("Your pet is asleep")
            Pet.Asleep = True
        Else
            SLEEPToolStripMenuItem.Text = "SLEEP"
            Say("Your pet has woken up")
            Pet.Asleep = False
        End If
    End Sub
    Private Sub ToolStripMenuItem12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem12.Click
        ''Sends pet to work to earn money
        '' Calculates money to add
        Dim moneyAdd As Integer = (Module1.random.Next((Pet.WorkLevel * 5), ((Pet.WorkLevel * 5) * Pet.WorkLevel)))
        If (Pet.Energy > 99) Then
            Say("Your pet goes to work.")
            Say("You recieved: " & moneyAdd & " CyberCash")
            Say("You used up ten percent energy")
            '' Updates values
            Settings.Cash += moneyAdd
            Pet.Energy -= 100
            If (Pet.WorkLevel < 100) Then
                Pet.workbuffer += 0.5
            End If
            workcheck()
            MoneyEarned += moneyAdd
        Else
            Say("You do not have enough energy")
        End If
    End Sub
    Private Sub ToolStripMenuItem15_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem15.Click
        '' Shows renaming form
        NameForm.Show()
    End Sub
    Private Sub EmergencyCashButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EmergencyCashButton.Click
        ''Gives the player an emergency cash reserve
        If emergencycounter < 3 Then
            Settings.Cash = 25
            emergencycounter += 1
        ElseIf emergencycounter = 8 Then
            Pet.Karma = 0
            Pet.KarmaExp = 0
        Else
            Say("You have exceeded the amount of emergency cash withdrawals.")
            emergencycounter += 1
        End If
    End Sub

    Private Sub ToolStripMenuItem13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem13.Click
        '' Brings up the About form
        Pause()
        AboutForm.Show()
    End Sub
    Private Sub PUNISHToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PUNISHToolStripMenuItem.Click
        ''Punishes the pet
        Pet.Punish()
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