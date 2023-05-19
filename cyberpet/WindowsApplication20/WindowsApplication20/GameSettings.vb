Imports System.ComponentModel
Imports System.Runtime.CompilerServices

Public Class GameSettings
    Implements INotifyPropertyChanged
    Private _GameSpeed As Integer = 10
    Private _Cash As Integer = 100

    Public Property Cash As Integer
        Get
            Return _Cash
        End Get
        Set
            _Cash = Value
            OnPropertyChanged()
        End Set
    End Property

    Public Property Food As Byte = 2
    Public Property Drink As Byte = 2
    Public Property Boost As Byte = 0
    Public Property Bandage As Byte = 0
    Public Property Paused As Boolean
    Public Property TTSEnabled As Boolean = True
    Public Property MsgEnabled As Boolean = True
    Public Property GameSpeed As Integer
        Get
            Return _GameSpeed
        End Get
        Set
            _GameSpeed = Value
            MainForm.Timer1.Interval = Value
            OnPropertyChanged()
        End Set
    End Property

    ''' <summary>
    ''' Pauses the game
    ''' </summary>

    Sub Pause()
        '' Pauses the game
        If Paused Then
            MainForm.Timer1.Start()
            Paused = False
            MainForm.Button3.Text = "PAUSE"
        Else
            Paused = True
            MainForm.Timer1.Stop()
            MainForm.Button3.Text = "RESUME"
        End If
    End Sub

    Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged

    Protected Sub OnPropertyChanged(<CallerMemberName> Optional ByVal propertyName As String = Nothing)
        RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(propertyName))
    End Sub
End Class
