Imports System.IO
Imports Newtonsoft.Json

Public Class MainForm
    Public StartTime As DateTime
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '' Start of game; Timer starts, new game is initiated.
        Timer1.Enabled = True
        NewGame()
        SetupDataBindings()
    End Sub
    Private Sub SetupDataBindings()
        EnergyBar.DataBindings.Add(New Binding("Value", Pet, "Energy"))
        ThirstBar.DataBindings.Add(New Binding("Value", Pet, "Thirst"))
        HungerBar.DataBindings.Add(New Binding("Value", Pet, "Hunger"))
        HealthBar.DataBindings.Add(New Binding("Value", Pet, "Health"))
        ToiletBar.DataBindings.Add(New Binding("Value", Pet, "Toilet"))
        ExperienceBar.DataBindings.Add(New Binding("Value", Pet, "Experience"))
        KarmaBar.DataBindings.Add(New Binding("Value", Pet, "Karma"))
        PetNameLabel.DataBindings.Add(New Binding("Text", Pet, "Name"))
        AgeLabel.DataBindings.Add(New Binding("Text", Pet, "Age") With {
            .FormatString = "Age: 0",
            .FormattingEnabled = True
        })
        Pet.Age = 0
    End Sub
    Public Sub UpdateUI()
        '' Changes time label to display time
        Dim timeElapsed = (DateDiff("s", StartTime, Now))
        Dim minutes As Integer = Math.Truncate(timeElapsed / 60)
        Dim seconds As Integer = timeElapsed Mod 60
        TimeLabel.Text = Convert.ToString(minutes) & " : " & seconds
        Pet.Age = minutes
        '' Updates the cash labels
        MainCashLabel.Text = $"£{Settings.Cash}"
        ShopForm.ShopCashLabel.Text = $"£{Settings.Cash}"
        InventoryForm.InventoryCashLabel.Text = $"£{Settings.Cash}"
        CheckKarma()
    End Sub
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick

        Pet.OnTick()
        UpdateUI()

    End Sub
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        '' Pauses the game when PAUSE is clicked
        Settings.Pause()
    End Sub
    Private Sub PetBodyDisplay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PetBodyDisplay.Click
        '' Plays a sound when the pet is clicked, randomly selected from a set of phrases
        Pet.Annoy()
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
        Pet.Play()
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
        Dim SaveFileDialog1 As New SaveFileDialog With {
        .Title = "Save Game",
        .Filter = "JSON files (*.json)|*.json|All files (*.*)|*.*",
        .FilterIndex = 1,
        .RestoreDirectory = True,
        .FileName = "Save.json"
    }

        If SaveFileDialog1.ShowDialog() = DialogResult.OK Then
            Dim gameState As New Dictionary(Of String, Object) From {
            {"Pet", Pet},
            {"Settings", Settings}
        }

            File.WriteAllText(SaveFileDialog1.FileName, JsonConvert.SerializeObject(gameState))
        End If
    End Sub
    Private Sub LOADToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LOADToolStripMenuItem1.Click
        Dim OpenFileDialog1 As New OpenFileDialog With {
        .Title = "Load Game",
        .Filter = "JSON files (*.json)|*.json|All files (*.*)|*.*",
        .FilterIndex = 1,
        .RestoreDirectory = True
    }

        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            Dim gameState As Dictionary(Of String, Object) = JsonConvert.DeserializeObject(Of Dictionary(Of String, Object))(File.ReadAllText(OpenFileDialog1.FileName))

            Pet = JsonConvert.DeserializeObject(Of Cyberpet)(gameState("Pet").ToString())
            Settings = JsonConvert.DeserializeObject(Of GameSettings)(gameState("Settings").ToString())
        End If
    End Sub
    Private Sub KILLToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles KILLToolStripMenuItem1.Click
        '' Kills the pet to start a new game
        Say("Your pet has died.")
        NewGame()
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

    Private Sub ToolStripMenuItem13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem13.Click
        '' Brings up the About form
        Settings.Pause()
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