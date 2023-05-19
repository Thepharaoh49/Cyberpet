Imports System.Speech.Synthesis
Imports System.Collections.ObjectModel

Module Module1

    Public Pet As Cyberpet = New Cyberpet
    Public Settings As GameSettings = New GameSettings
    Public settingscolour As String
    Public starttime As Date
    Public stoptime As Date
    Public emergencycounter As Byte
    Public MoneyLost As Integer
    Public MoneySpent As Integer
    Public MoneyEarned As Integer
    Public Speaker As SpeechSynthesizer = New SpeechSynthesizer()
    Public minutes As Integer = 0
    Public Basetime As Date
    Public TimeText As String = ""
    Public Paused As Boolean
    Public pausetime As Date
    Public HealthVar As Integer
    Public karmabuffer As Double = 0
    Public random As New Random()
    Public RandomNumber As Integer

    ''' <summary>
    ''' Checks for a level up in work
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub workcheck()
        If (Pet.workbuffer = 1) Then
            Pet.WorkLevel += 1
            Say("Work Level up! Work level is now: " & Pet.WorkLevel)
            Pet.workbuffer = 0
            If (Pet.WorkLevel = 100) Then
                Say("You have reached the maximum work level")
            End If
        End If
    End Sub
    ''' <summary>
    ''' Gives the cyberpet food
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub Feed()
        ''increases hungerbar and removes a food.
        If (Settings.Food > 0) Then
            Settings.Food -= 1
            If (MainForm.HungerBar.Value < 801) Then
                MainForm.HungerBar.Value += 200
            Else
                MainForm.HungerBar.Value = 1000
            End If
            If (MainForm.EnergyBar.Value < 901) Then
                MainForm.EnergyBar.Value += 100
            Else
                MainForm.EnergyBar.Value = 1000
            End If
        Else
            Say("You do not have any cyber food")

        End If

    End Sub
    ''' <summary>
    ''' gives the cyberpet drink
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub UseDrink()
        '' Increases thirstbar and removes a drink
        If (Settings.Drink > 0) Then
            Settings.Drink -= 1
            If (MainForm.ThirstBar.Value < 801) Then
                MainForm.ThirstBar.Value += 200
            Else
                MainForm.ThirstBar.Value = 1000
            End If
            If (MainForm.ToiletBar.Value < 801) Then
                MainForm.ToiletBar.Value += 200
            Else
                MainForm.ToiletBar.Value = 1000
            End If
        End If
    End Sub
    ''' <summary>
    ''' Gives the cyberpet an energy boost
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub UseBoost()
        '' increases energybar and removes a boost
        If (Settings.Boost > 0) Then
            Settings.Boost -= 1
            If (MainForm.EnergyBar.Value < 801) Then
                MainForm.EnergyBar.Value += 200
            Else
                MainForm.EnergyBar.Value = 1000
            End If
        End If
    End Sub
    ''' <summary>
    ''' Gives the pet a bandage, healing injury
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub UseBandage()
        '' removes injury and bandage
        If (Pet.Injured = True) Then
            If (Settings.Bandage > 0) Then
                Settings.Bandage -= 1
                Pet.Injured = False
                InventoryForm.Inventory.Items.Remove("CyberBandage")
                Say("Your CyberPet is no longer injured.")
            Else
                Say("You do not have a CyberBandage.")
            End If
        Else
            Say("Your CyberPet is not injured.")
        End If
    End Sub
    ''' <summary>
    ''' Produces a random speech-synthesised string from a selection
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub Annoy()
        ''Chooses a phrase from a selection to say
        Dim speechcheck As Integer
        speechcheck = random.Next(1, 4)
        If (speechcheck = 1) Then
            Say("OUCH!", False)
        ElseIf (speechcheck = 2) Then
            Say("Stop it", False)
        ElseIf (speechcheck = 3) Then
            Say("You are annoying me", False)
        ElseIf (speechcheck = 4) Then
            Say("ow", False)
        End If
    End Sub
    ''' <summary>
    ''' Checks for a level up
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub experiencecheck()
        ''Checks for level up in experience
        If (MainForm.ExperienceBar.Value = MainForm.ExperienceBar.Maximum) Then
            MainForm.ExperienceBar.Value = 0
            Say("Level! Up!")
            Pet.Level += 1
        End If
    End Sub
    ''' <summary>
    ''' Checks the need for toilet
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub ToiletCheck()
        ''Checks for actions needed based on toiletbar value
        If (MainForm.ToiletBar.Value > 999) Then
            MainForm.ToiletBar.Value = 1
            If (Pet.Injured = False) Then
                Say("Your pet's bladder exploded. Your pet has become injured.")
                Pet.Injured = True
            Else
                Say("You pet needed the toilet. Your pet has died.")
                newgame()
            End If
        End If
    End Sub
    ''' <summary>
    ''' Checks whether the pet is asleep and regaining energy
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub SleepCheck()
        '' Increases energy when asleep
        If (Pet.Asleep = True) Then
            If (MainForm.EnergyBar.Value < 1000) Then
                MainForm.EnergyBar.Value += 1
            Else
                MainForm.EnergyBar.Value = 1000
            End If
        End If
    End Sub
    ''' <summary>
    ''' Adds one to the karma if the buffer is at 1
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub Karmaupdate()
        '' updates the karma when needed
        If (karmabuffer < -0.9) Then
            MainForm.KarmaBar.Value += 1
            karmabuffer = 0
        End If

        If (karmabuffer > 0.9) Then
            MainForm.KarmaBar.Value += 1
            karmabuffer = 0
        End If
    End Sub
    ''' <summary>
    ''' Sets all cash labels to display up to date
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub updatecash()
        '' Updates the cash labels
        MainForm.MainCashLabel.Text = "£" & Settings.Cash

        ShopForm.ShopCashLabel.Text = "£" & Settings.Cash
        InventoryForm.InventoryCashLabel.Text = "£" & Settings.Cash
    End Sub
    ''' <summary>
    ''' Changes the colour of the karmabar to suit the karma level
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub karmacheck()
        ''Sets the karmabar colour to suit the karma level
        Select Case (MainForm.KarmaBar.Value)
            Case 0
                MainForm.KarmaBar.ForeColor = Color.Maroon
            Case 1
                MainForm.KarmaBar.ForeColor = Color.DarkRed
            Case 2
                MainForm.KarmaBar.ForeColor = Color.Red
            Case 3
                MainForm.KarmaBar.ForeColor = Color.LightSalmon
            Case 4
                MainForm.KarmaBar.ForeColor = Color.Pink
            Case 5
                MainForm.KarmaBar.ForeColor = Color.White
            Case 6
                MainForm.KarmaBar.ForeColor = Color.Khaki
            Case 7
                MainForm.KarmaBar.ForeColor = Color.Yellow
            Case 8
                MainForm.KarmaBar.ForeColor = Color.YellowGreen
            Case 9
                MainForm.KarmaBar.ForeColor = Color.Chartreuse
            Case 10
                MainForm.KarmaBar.ForeColor = Color.Green
        End Select

        ''Sets the picture to the correct picture for the karma level
        CheckBodyType()
    End Sub
    ''' <summary>
    ''' Sets health value based on injury
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub injurycheck()
        '' Checks the pet for injuries
        If (Pet.Injured = False) Then
            HealthVar = MainForm.HealthBar.Value
            MainForm.HealthBar.Value = ((MainForm.HungerBar.Value + MainForm.ThirstBar.Value) / 2)
        Else
            MainForm.HealthBar.Value = ((MainForm.HungerBar.Value + MainForm.ThirstBar.Value) / 3)
        End If
    End Sub
    ''' <summary>
    ''' Checks whether the health has hit 0 or not
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub HealthCheck()
        '' Checks if the pet has died or not
        If (MainForm.HealthBar.Value < 1) Then
            MainForm.ThirstBar.Value = 1000
            MainForm.HungerBar.Value = 1000
            MainForm.HealthBar.Value = 1000
            Say("Your pet has died")
            newgame()

        End If
    End Sub
    ''' <summary>
    ''' Updates the colour of the pet, and whether it is awake or not
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub CheckBodyType()
        '' Updates the picture based on the pet's body state
        Dim filePath = String.Format("{0}\Resources\Body{1}{2}.png", Application.StartupPath, MainForm.KarmaBar.Value, If(Pet.Asleep, "ASLEEP", "AWAKE"))
        MainForm.PetBodyDisplay.Image = Bitmap.FromFile(filePath)
    End Sub
    ''' <summary>
    ''' Starts a new game
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub newgame()
        '' resets all values
        Settings.Cash = 100
        Pet.Age = 0
        Pet.Name = "NAME"
        MainForm.PetNameLabel.Text = Pet.Name
        starttime = Now
        minutes = 0
        MainForm.KarmaBar.Value = 5
        MainForm.HealthBar.Value = 1000
        MainForm.HungerBar.Value = 1000
        MainForm.ThirstBar.Value = 1000
        MainForm.ToiletBar.Value = 0
        MainForm.EnergyBar.Value = 1000
        karmabuffer = 0
        Paused = False
        Settings.Food = 2
        Settings.Drink = 2
        Settings.Boost = 0
        Settings.Bandage = 0
        Pet.WorkLevel = 1
        Pet.workbuffer = 0
        Pet.Injured = False
        NameForm.Show()
        SettingsForm.SlowBtn.Checked = False
        SettingsForm.FastBtn.Checked = False
        SettingsForm.StupidBtn.Checked = False
        MainForm.Timer1.Interval = 100
        SettingsForm.NormalBtn.Checked = True
    End Sub
    ''' <summary>
    ''' Pauses the game
    ''' </summary>
    ''' <remarks></remarks>
    Sub pausegame()
        '' Pauses the game
        If Settings.Paused Then
            MainForm.Timer1.Start()
            Settings.Paused = False
            MainForm.Button3.Text = "PAUSE"
        Else
            Settings.Paused = True
            MainForm.Timer1.Stop()
            MainForm.Button3.Text = "RESUME"
        End If

    End Sub
    ''' <summary>
    ''' Runs subroutines as above
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub checkbars()
        '' Runs several subroutines
        ToiletCheck()
        SleepCheck()
        karmacheck()
        HealthCheck()
    End Sub
    ''' <summary>
    ''' Sets the background of the settings form
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub Backgroundcheck()
        If (settingscolour = "Blue") Then
            SettingsForm.BackColor = Color.SteelBlue
        ElseIf (settingscolour = "Red") Then
            SettingsForm.BackColor = Color.IndianRed
        ElseIf (settingscolour = "Green") Then
            SettingsForm.BackColor = Color.Green
        ElseIf (settingscolour = "Pink") Then
            SettingsForm.BackColor = Color.LightPink
        End If
    End Sub
    ''' <summary>
    ''' "plays" with the cyberpet, increasing karma and decreasing energy
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub play()
        '' Plays with the cyberpet
        Dim karmaAdd As Double = (Module1.random.Next(1, 5)) / 10
        If (MainForm.EnergyBar.Value > 199) Then
            Say("You play with your cyberpet")
            Say("You recieved " & karmaAdd & " karma")
            Say("Your pet used up twenty percent energy")
            karmabuffer += karmaAdd
            MainForm.EnergyBar.Value -= 200
        Else
            Say("You do not have enough energy")
        End If
    End Sub
    ''' <summary>
    ''' Allows speech synthesis
    ''' </summary>
    ''' <param name="Speech"></param>
    ''' <remarks></remarks>
    Public Sub Say(Speech As String, Optional showMsg As Boolean = True)
        '   speaker.SelectVoice("Microsoft Anna")
        Speaker.SpeakAsync(Speech)
        If (showMsg) Then MsgBox(Speech)
    End Sub
End Module
