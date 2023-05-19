Imports System.ComponentModel
Imports System.Runtime.CompilerServices

Public Class Cyberpet
    Implements INotifyPropertyChanged
    Private _Hunger As Integer = 0
    Private _Thirst As Integer = 0
    Private _Toilet As Integer = 0
    Private _Energy As Integer = 1000
    Private _Karma As Integer = 5
    Private _Experience As Integer = 0
    Private _Health As Integer = 1000
    Private _KarmaExp As Integer = 0
    Private _Age As Integer = 0
    Public Property BodyState As String
    Public Property Level As Byte = 1
    Public Property Injured As Boolean
    Public Property Asleep As Boolean
    Public Property Name As String = ""
    Public Property Age As Integer
        Get
            Return _Age
        End Get
        Set
            _Age = Value
            OnPropertyChanged()
        End Set
    End Property

    Public Property Dead As Boolean
    Public Property WorkLevel As Byte = 1
    Public Property KarmaExp As Integer
        Get
            Return _KarmaExp
        End Get
        Set
            _KarmaExp = Value
            If (_KarmaExp < -0.9) Then
                Karma -= 1
                _KarmaExp = 0
            ElseIf _KarmaExp > 0.9 Then
                Karma += 1
                _KarmaExp = 0
            End If
            OnPropertyChanged()
        End Set
    End Property

    Public Property workbuffer As Double = 0
    Public Property Experience As Integer
        Get
            Return _Experience
        End Get
        Set
            _Experience = Math.Max(0, Math.Min(100, Value))
            If (_Experience = 100) Then
                _Experience = 0
                LevelUp()
            End If
            OnPropertyChanged()
        End Set
    End Property
    Public Property Karma As Integer
        Get
            Return _Karma
        End Get
        Set
            _Karma = Math.Max(0, Math.Min(10, Value))
            OnPropertyChanged()
        End Set
    End Property
    Public Property Hunger As Integer
        Get
            Return _Hunger
        End Get
        Set
            _Hunger = Math.Max(0, Math.Min(1000, Value))
            OnPropertyChanged()
        End Set
    End Property
    Public Property Thirst As Integer
        Get
            Return _Thirst
        End Get
        Set
            _Thirst = Math.Max(0, Math.Min(1000, Value))

            OnPropertyChanged()
        End Set
    End Property
    Public Property Toilet As Integer
        Get
            Return _Toilet
        End Get
        Set
            _Toilet = Math.Max(0, Math.Min(1000, Value))
            If (_Toilet = 1000) Then
                MissedToilet()
            End If

            OnPropertyChanged()
        End Set
    End Property
    Public Property Energy As Integer
        Get
            Return _Energy
        End Get
        Set
            _Energy = Math.Max(0, Math.Min(1000, Value))
            OnPropertyChanged()
        End Set
    End Property
    Public Property Health As Integer
        Get
            Return _Health
        End Get
        Set
            _Health = Value
            OnPropertyChanged()
        End Set
    End Property

    ''' <summary>
    ''' Punishes the pet, causing injury.
    ''' </summary>

    Public Sub Punish()
        '' If the pet is not injured, it becomes injured
        If (Injured = False) Then
            Injured = True
            ''The karma decreases.
            Karma -= 1
            Say("You have injured your cyberpet. Karma - 1")
        Else
            ''if the pet was injured, it is killed
            Say("You have killed your cyberpet.")
            NewGame()
        End If
    End Sub

    ''' <summary>
    ''' Handles max toilet value overflow
    ''' </summary>
    Private Sub MissedToilet()
        If (Injured = False) Then
            Say("Your pet's bladder exploded. Your pet has become injured.")
            Injured = True
        Else
            Say("You pet needed the toilet. Your pet has died.")
            NewGame()
        End If
    End Sub

    Private Sub LevelUp()
        Say("Level Up!")
        Pet.Level += 1
    End Sub

    ''' <summary>
    ''' "plays" with the cyberpet, increasing karma and decreasing energy
    ''' </summary>
    Public Sub Play()
        '' Plays with the cyberpet
        Dim karmaAdd As Double = (Module1.random.Next(1, 5)) / 10
        If (Energy >= 200) Then
            Say("You play with your cyberpet")
            Say("You recieved " & karmaAdd & " karma")
            Say("Your pet used up twenty percent energy")
            KarmaExp += karmaAdd
            Energy -= 200
        Else
            Say("You do not have enough energy")
        End If
    End Sub
    Public Sub OnTick()
        If (Asleep = True) Then
            Energy += 1
        End If
        Hunger -= 1
        Thirst -= 1
        Toilet += Math.Max(1, Math.Min(10, Age))

        CalculateHealth()
    End Sub
    ''' <summary>
    ''' Sets health value based on injury
    ''' </summary>
    Public Sub CalculateHealth()
        '' Checks the pet for injuries
        If (Injured) Then
            Health = ((1000 - Hunger) + (1000 - Thirst)) / 3
        Else
            Health = ((1000 - Hunger) + (1000 - Thirst)) / 2
        End If

        '' Checks if the pet has died or not
        If (Pet.Health < 1) Then
            Say("Your pet has died")
            NewGame()
        End If
    End Sub

    ''' <summary>
    ''' Produces a random speech-synthesised string from a selection
    ''' </summary>

    Public Sub Annoy()
        ''Chooses a phrase from a selection to say
        Dim speechcheck As Integer
        speechcheck = random.Next(1, 5)
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

    Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged

    Protected Sub OnPropertyChanged(<CallerMemberName> Optional ByVal propertyName As String = Nothing)
        RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(propertyName))
    End Sub
End Class
