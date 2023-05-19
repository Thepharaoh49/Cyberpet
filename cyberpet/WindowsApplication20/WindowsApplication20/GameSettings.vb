Public Class GameSettings
    Public Property Cash As Integer
    Public Property Food As Byte
    Public Property Drink As Byte
    Public Property Boost As Byte
    Public Property Bandage As Byte
    Public Property Paused As Boolean

    ''' <summary>
    ''' Pauses the game
    ''' </summary>
    ''' <remarks></remarks>
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
