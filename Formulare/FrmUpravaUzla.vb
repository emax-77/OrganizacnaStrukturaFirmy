Imports System.Windows.Forms

Partial Public Class FrmUpravaUzla
    Inherits Form
    Public Property UzolNazov As String
    Public Property UzolKod As String

    Public Sub New(Optional nazov As String = Nothing, Optional kod As String = Nothing)
        InitializeComponent()
        txtNazov.Text = nazov
        txtKod.Text = kod
    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        If String.IsNullOrWhiteSpace(txtNazov.Text) OrElse String.IsNullOrWhiteSpace(txtKod.Text) Then
            MessageBox.Show(Me, "Názov a kód sú povinné.", "Upozornenie", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        UzolNazov = txtNazov.Text.Trim()
        UzolKod = txtKod.Text.Trim()
        DialogResult = DialogResult.OK
        Close()
    End Sub

    Private Sub btnZrusit_Click(sender As Object, e As EventArgs) Handles btnZrusit.Click
        DialogResult = DialogResult.Cancel
        Close()
    End Sub
End Class
