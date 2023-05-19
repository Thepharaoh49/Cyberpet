Public Class PauseForm
    Dim stoptime As Date
    Dim starttime As Date
    Private Sub PauseForm_Close(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Me.FormClosed
        PauseBoolean = False
        pausegame(False)
    End Sub
    Private Sub PauseForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetBounds(MainForm.Location.X, MainForm.Location.Y, MainForm.Width, MainForm.Height)
        PauseBoolean = True
        pausegame(True)
    End Sub
End Class