Imports System.Windows.Forms

Partial Public Class FrmUpravaUzla
    Inherits Form
    Public Property UzolNazov As String
    Public Property UzolKod As String

    Public Sub New(Optional nazov As String = Nothing, Optional kod As String = Nothing)
        InitializeComponent()

        txtNazov.Text = nazov
        txtKod.Text = kod

        AddHandler btnOK.Click, AddressOf Potvrd
        AddHandler btnZrusit.Click, AddressOf Zrus
    End Sub

    Private Sub Potvrd(sender As Object, e As EventArgs)
        If String.IsNullOrWhiteSpace(txtNazov.Text) OrElse String.IsNullOrWhiteSpace(txtKod.Text) Then
            MessageBox.Show(Me, "Názov a kód sú povinné.", "Upozornenie", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        UzolNazov = txtNazov.Text
        UzolKod = txtKod.Text
        DialogResult = DialogResult.OK
        Close()
    End Sub

    Private Sub Zrus(sender As Object, e As EventArgs)
        DialogResult = DialogResult.Cancel
        Close()
    End Sub


End Class
