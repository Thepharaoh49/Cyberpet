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
            Pet.Hunger += 200
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
            Pet.Thirst += 200
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
            Pet.Energy += 200
        End If
    End Sub
    ''' <summary>
    ''' Gives the pet a bandage, healing injury
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub UseBandage()
        '' removes injury and bandage
        If (Pet.Injured) Then
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
        Pet.Karma = 5
        Pet.Health = 1000
        Pet.Hunger = 1000
        Pet.Thirst = 1000
        Pet.Toilet = 0
        Pet.Energy = 1000
        Pet.KarmaExp = 0
        Settings.Paused = False
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
    ''' Runs subroutines as above
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub checkbars()
        '' Runs several subroutines
        karmacheck()
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
