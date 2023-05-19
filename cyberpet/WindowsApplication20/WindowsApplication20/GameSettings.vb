Public Class GameSettings
    Public Property Cash As Integer = 100
    Public Property Food As Byte = 2
    Public Property Drink As Byte = 2
    Public Property Boost As Byte = 0
    Public Property Bandage As Byte = 0
    Public Property Paused As Boolean

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
End Class
