Imports System.Windows.Forms

Partial Public Class FrmHlavne
    Inherits Form

    Private ReadOnly _ucZamestnanci As New FrmZamestnanci()
    Private ReadOnly _ucOrganizacnaStruktura As New FrmOrganizacnaStruktura()

    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub FrmHlavne_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        _ucZamestnanci.Dock = DockStyle.Fill
        tabZamestnanci.Controls.Add(_ucZamestnanci)

        _ucOrganizacnaStruktura.Dock = DockStyle.Fill
        tabOrganizacnaStruktura.Controls.Add(_ucOrganizacnaStruktura)
    End Sub

End Class
