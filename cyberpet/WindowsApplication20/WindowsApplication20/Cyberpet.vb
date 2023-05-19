Public Class Cyberpet
    Private _Hunger As Integer = 0
    Private _Thirst As Integer = 0
    Private _Toilet As Integer = 0
    Private _Energy As Integer = 1000
    Private _Karma As Integer = 5
    Private _Experience As Integer = 0
    Public Property BodyState As String
    Public Property Level As Byte = 1
    Public Property Injured As Boolean
    Public Property Asleep As Boolean
    Public Property Name As String = ""
    Public Property Age As Integer = 0
    Public Property Dead As Boolean
    Public Property WorkLevel As Byte = 1
    Public Property workbuffer As Double = 0
    Public Property Experience As Integer
        Get
            Return _Experience
        End Get
        Set
            _Experience = Math.Max(0, Math.Min(1000, Value))
            If (_Experience = 1000) Then
                _Experience = 0
                LevelUp()
            End If
        End Set
    End Property
    Public Property Karma As Integer
        Get
            Return _Karma
        End Get
        Set
            _Karma = Math.Max(0, Math.Min(10, Value))
        End Set
    End Property
    Public Property Hunger As Integer
        Get
            Return _Hunger
        End Get
        Set
            _Hunger = Math.Max(0, Math.Min(1000, Value))
        End Set
    End Property
    Public Property Thirst As Integer
        Get
            Return _Thirst
        End Get
        Set
            _Thirst = Math.Max(0, Math.Min(1000, Value))
        End Set
    End Property
    Public Property Toilet As Integer
        Get
            Return _Toilet
        End Get
        Set
            _Toilet = Math.Max(0, Math.Min(1000, Value))
        End Set
    End Property
    Public Property Energy As Integer
        Get
            Return _Energy
        End Get
        Set
            _Energy = Math.Max(0, Math.Min(1000, Value))
        End Set
    End Property

    ''' <summary>
    ''' Punishes the pet, causing injury.
    ''' </summary>
    ''' <remarks></remarks>
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
            newgame()
        End If
    End Sub
    Private Sub LevelUp()
    End Sub
End Class
