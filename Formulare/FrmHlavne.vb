Imports System.Windows.Forms

Partial Public Class FrmHlavne
    Inherits Form

    Private _frmZamestnanci As FrmZamestnanci
    Private _frmOrganizacnaStruktura As FrmOrganizacnaStruktura

    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub FrmHlavne_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        InicializujZalozky()
    End Sub

    Private Sub InicializujZalozky()
        _frmZamestnanci = New FrmZamestnanci() With {
            .TopLevel = False,
            .FormBorderStyle = FormBorderStyle.None,
            .Dock = DockStyle.Fill
        }
        tabZamestnanci.Controls.Add(_frmZamestnanci)
        _frmZamestnanci.Show()

        _frmOrganizacnaStruktura = New FrmOrganizacnaStruktura() With {
            .TopLevel = False,
            .FormBorderStyle = FormBorderStyle.None,
            .Dock = DockStyle.Fill
        }
        tabOrganizacnaStruktura.Controls.Add(_frmOrganizacnaStruktura)
        _frmOrganizacnaStruktura.Show()
    End Sub

    Protected Overrides Sub OnFormClosed(e As FormClosedEventArgs)
        If _frmZamestnanci IsNot Nothing Then
            _frmZamestnanci.Dispose()
        End If

        If _frmOrganizacnaStruktura IsNot Nothing Then
            _frmOrganizacnaStruktura.Dispose()
        End If

        MyBase.OnFormClosed(e)
    End Sub

End Class
