Public Class NameForm
    Private Sub NamePetOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NamePetOk.Click
        ''Puts the name to uppercase
        Pet.Name = NamePetBox.Text.ToUpper
        ''Updates the name label
        MainForm.PetNameLabel.Text = Pet.Name
        Close()
        Pause()

    End Sub
    Private Sub RenameCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RenameCancel.Click
        Close()
        Pause()
    End Sub
    Private Sub NameForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Pause()

    End Sub
    Private Sub NameForm_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Pause()
    End Sub
End Class