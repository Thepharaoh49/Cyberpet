Imports System.Speech.Synthesis
Imports System.Collections.ObjectModel

Module Module1

    Public settingscolour As String
    Public starttime As Date
    Public stoptime As Date
    Public BodyState As String
    Public Level As Byte = 1
    Public emergencycounter As Byte
    Public MoneyLost As Integer
    Public MoneySpent As Integer
    Public MoneyEarned As Integer
    Public WorkLevel As Byte = 1
    Public workbuffer As Double = 0
    Public speaker As SpeechSynthesizer = New SpeechSynthesizer()
    Public sleepboolean As Boolean
    Public injured As Boolean
    Public PetName As String = ""
    Public minutes As Integer = 0
    Public Basetime As Date
    Public TimeText As String = ""
    Public age As Integer
    Public BodyType As String
    Public BodyTypeNumber As Integer
    Public PauseBoolean As Boolean
    Public dead As Boolean
    Public Cash As Integer
    Public pausetime As Date
    Public HealthVar As Integer
    Public Food As Byte
    Public Drink As Byte
    Public Boost As Byte
    Public counter3 As Byte = 0
    Public karmabuffer As Double = 0
    Public karmanegativebuffer As Double = 0
    Public Bandage As Byte
    Public randomclass As New Random()
    Public RandomNumber As Integer
    ''' <summary>
    ''' Punishes the pet, causing injury.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub punish()
        '' If the pet is not injured, it becomes injured
        If (injured = False) Then
            injured = True
            ''The karma decreases.
            MainForm.KarmaBar.Value = MainForm.KarmaBar.Value - 1
            Say("You have injured your cyberpet. Karma - 1")
        Else
            ''if the pet was injured, it is killed
            Say("You have killed your cyberpet.")
            newgame()
        End If
    End Sub
    ''' <summary>
    ''' Checks for a level up in work
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub workcheck()
        If (workbuffer = 1) Then
            WorkLevel += 1
            Say("Work Level up! Work level is now: " & WorkLevel)
            workbuffer = 0
            If (WorkLevel = 100) Then
                Say("You have reached the maximum work level")
            End If
        End If
    End Sub
    ''' <summary>
    ''' Gives the cyberpet food
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub feed()
        ''increases hungerbar and removes a food.
        If (Food > 0) Then
            Food = Food - 1
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
    Public Sub givedrink()
        '' Increases thirstbar and removes a drink
            If (Drink > 0) Then
            Drink = Drink - 1
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
    Public Sub giveboost()
        '' increases energybar and removes a boost
        If (Boost > 0) Then
            Boost = Boost - 1
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
    Public Sub givebandage()
        '' removes injury and bandage
        If (injured = True) Then
            If (Bandage > 0) Then
                Bandage = Bandage - 1
                injured = False
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
    Public Sub annoy()
        ''Chooses a phrase from a selection to say
        Dim speechcheck As Integer
        speechcheck = randomclass.Next(1, 4)
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
            Level += 1
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
            If (injured = False) Then
                Say("Your pet's bladder exploded. Your pet has become injured.")
                injured = True
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
        If (sleepboolean = True) Then
            If (MainForm.EnergyBar.Value < 1000) Then
                MainForm.EnergyBar.Value = MainForm.EnergyBar.Value + 1
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
        If (karmanegativebuffer > 0.9) Then
            MainForm.KarmaBar.Value = MainForm.KarmaBar.Value - 1
            karmanegativebuffer = 0
        End If

        If (karmabuffer > 0.9) Then
            MainForm.KarmaBar.Value = MainForm.KarmaBar.Value + 1
            karmabuffer = 0
        End If
    End Sub
    ''' <summary>
    ''' Sets all cash labels to display up to date
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub updatecash()
        '' Updates the cash labels
        MainForm.MainCashLabel.Text = "£" & Cash

        ShopForm.ShopCashLabel.Text = "£" & Cash
        InventoryForm.InventoryCashLabel.Text = "£" & Cash
    End Sub
    ''' <summary>
    ''' Changes the colour of the karmabar to suit the karma level
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub karmacheck()
        ''Sets the karmabar colour to suit the karma level
        If (MainForm.KarmaBar.Value = 0) Then
            MainForm.KarmaBar.ForeColor = Color.Maroon
        End If
        If (MainForm.KarmaBar.Value = 1) Then
            MainForm.KarmaBar.ForeColor = Color.DarkRed
        End If
        If (MainForm.KarmaBar.Value = 2) Then
            MainForm.KarmaBar.ForeColor = Color.Red
        End If
        If (MainForm.KarmaBar.Value = 3) Then
            MainForm.KarmaBar.ForeColor = Color.LightSalmon
        End If
        If (MainForm.KarmaBar.Value = 4) Then
            MainForm.KarmaBar.ForeColor = Color.Pink
        End If
        If (MainForm.KarmaBar.Value = 5) Then
            MainForm.KarmaBar.ForeColor = Color.White
        End If
        If (MainForm.KarmaBar.Value = 6) Then
            MainForm.KarmaBar.ForeColor = Color.Khaki
        End If
        If (MainForm.KarmaBar.Value = 7) Then
            MainForm.KarmaBar.ForeColor = Color.Yellow
        End If
        If (MainForm.KarmaBar.Value = 8) Then
            MainForm.KarmaBar.ForeColor = Color.YellowGreen
        End If
        If (MainForm.KarmaBar.Value = 9) Then
            MainForm.KarmaBar.ForeColor = Color.Chartreuse
        End If
        If (MainForm.KarmaBar.Value = 10) Then
            MainForm.KarmaBar.ForeColor = Color.Green
        End If
        ''Sets the picture to the correct picture for the karma level
        CheckBodyType()
    End Sub
    ''' <summary>
    ''' Sets health value based on injury
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub injurycheck()
        '' Checks the pet for injuries
        If (injured = False) Then
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
        BodyTypeNumber = MainForm.KarmaBar.Value - 1
        BodyType = "Body" & BodyTypeNumber
        If (sleepboolean = True) Then
            BodyState = "ASLEEP"
        Else
            BodyState = "AWAKE"
        End If
        If (BodyType = "Body-1") Then
            MainForm.PetBodyDisplay.Image = Bitmap.FromFile(Application.StartupPath + "\Resources\Body_1" & BodyState & ".png")
        Else
            MainForm.PetBodyDisplay.Image = Bitmap.FromFile(Application.StartupPath + "\Resources\" & BodyType & BodyState & ".png")
        End If
    End Sub
    ''' <summary>
    ''' Starts a new game
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub newgame()
        '' resets all values
        Cash = 100
        age = 0
        PetName = "NAME"
        MainForm.PetNameLabel.Text = PetName
        BodyTypeNumber = 4
        starttime = Now
        minutes = 0
        MainForm.KarmaBar.Value = 5
        MainForm.HealthBar.Value = 1000
        MainForm.HungerBar.Value = 1000
        MainForm.ThirstBar.Value = 1000
        MainForm.ToiletBar.Value = 0
        MainForm.EnergyBar.Value = 1000
        karmabuffer = 0
        PauseBoolean = False
        Food = 2
        Drink = 2
        Boost = 0
        Bandage = 0
        WorkLevel = 1
        workbuffer = 0
        injured = False
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
    ''' <param name="PauseBoolean"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function pausegame(ByVal PauseBoolean As Boolean)
        '' Pauses the game
        If (PauseBoolean = True) Then
            PauseForm.Show()
            age = age
            MainForm.Timer1.Stop()
            MainForm.HealthBar.Value = MainForm.HealthBar.Value
            MainForm.HungerBar.Value = MainForm.HungerBar.Value
        Else
            PauseForm.Hide()
            MainForm.Timer1.Start()
        End If

    End Function
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
        Dim karmaAdd As Double = (Module1.randomclass.Next(1, 5)) / 10
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
        speaker.SpeakAsync(Speech)
        If (showMsg) Then MsgBox(Speech)
    End Sub
End Module
