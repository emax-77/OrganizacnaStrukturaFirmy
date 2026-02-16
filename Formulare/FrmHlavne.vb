Imports System.Windows.Forms

Partial Public Class FrmHlavne
    Inherits Form

    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub OtvorOrganizacnuStrukturu(sender As Object, e As EventArgs) Handles btnOrganizacnaStruktura.Click
        Using frm As New FrmOrganizacnaStruktura()
            frm.ShowDialog(Me)
        End Using
    End Sub

    Private Sub OtvorZamestnancov(sender As Object, e As EventArgs) Handles btnZamestnanci.Click
        Using frm As New FrmZamestnanci()
            frm.ShowDialog(Me)
        End Using
    End Sub

End Class
