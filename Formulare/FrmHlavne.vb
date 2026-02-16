Imports System.Windows.Forms

Partial Public Class FrmHlavne
    Inherits Form

    Public Sub New()
        InitializeComponent()

        AddHandler btnOrganizacnaStruktura.Click, AddressOf OtvorOrganizacnuStrukturu
        AddHandler btnZamestnanci.Click, AddressOf OtvorZamestnancov
    End Sub

    Private Sub OtvorOrganizacnuStrukturu(sender As Object, e As EventArgs)
        Using frm As New FrmOrganizacnaStruktura()
            frm.ShowDialog(Me)
        End Using
    End Sub

    Private Sub OtvorZamestnancov(sender As Object, e As EventArgs)
        Using frm As New FrmZamestnanci()
            frm.ShowDialog(Me)
        End Using
    End Sub

End Class
