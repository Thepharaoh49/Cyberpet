Public Class AboutForm
    Private Sub AboutForm_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        ''Resumes the game upon closure
        pausegame()
    End Sub
End Class