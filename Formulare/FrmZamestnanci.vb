Imports System.Windows.Forms

Partial Public Class FrmZamestnanci
    Inherits UserControl

    Private ReadOnly _logika As ZamestnanecLogika
    Private _zaradenia As List(Of mUzolStromu)
    Private _uzly As List(Of mUzolStromu)

    Public Sub New()
        InitializeComponent()
        Dim pripojenie = SqlPripojenie.ZiskajPripojovaciRetazec()
        Dim strukturaLogika = New OrganizacnaStrukturaLogika(New FirmaCRUD(pripojenie), New DiviziaCRUD(pripojenie), New ProjektCRUD(pripojenie), New OddelenieCRUD(pripojenie))
        _logika = New ZamestnanecLogika(New ZamestnanecCRUD(pripojenie), strukturaLogika)
    End Sub

    Private Sub FrmZamestnanci_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        _zaradenia = _logika.ZiskajZaradenia()
        _uzly = _logika.ZiskajUzly()
        NacitajZamestnancov()
    End Sub

    Private Sub NacitajZamestnancov()
        gridZamestnanci.DataSource = _logika.ZiskajVsetkychZamestnancov()
    End Sub

    Private Function ZiskajVybranyZaznam() As mZamestnanec
        If gridZamestnanci.CurrentRow Is Nothing Then
            Return Nothing
        End If

        Return TryCast(gridZamestnanci.CurrentRow.DataBoundItem, mZamestnanec)
    End Function

    Private Sub PridajZamestnanca(sender As Object, e As EventArgs) Handles btnPridat.Click
        _zaradenia = _logika.ZiskajZaradenia()
        _uzly = _logika.ZiskajUzly()

        If _uzly.Count = 0 Then
            MessageBox.Show(Me, "Najprv vytvor aspoň jeden uzol v organizačnej štruktúre.", "Upozornenie", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Using frm As New FrmUpravaZamestnanca(_zaradenia, _uzly, _logika)
            If frm.ShowDialog(Me) = DialogResult.OK Then
                _logika.UlozZamestnanca(frm.Zamestnanec)
                NacitajZamestnancov()
            End If
        End Using
    End Sub

    Private Sub UpravZamestnanca(sender As Object, e As EventArgs) Handles btnUpravit.Click
        Dim vybrany = ZiskajVybranyZaznam()
        If vybrany Is Nothing Then
            MessageBox.Show(Me, "Najprv vyber zamestnanca.", "Upozornenie", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        _zaradenia = _logika.ZiskajZaradenia()
        _uzly = _logika.ZiskajUzly()
        Using frm As New FrmUpravaZamestnanca(_zaradenia, _uzly, _logika, vybrany)
            If frm.ShowDialog(Me) = DialogResult.OK Then
                _logika.AktualizujZamestnanca(frm.Zamestnanec)
                NacitajZamestnancov()
            End If
        End Using
    End Sub

    Private Sub VymazZamestnanca(sender As Object, e As EventArgs) Handles btnVymazat.Click
        Dim vybrany = ZiskajVybranyZaznam()
        If vybrany Is Nothing Then
            MessageBox.Show(Me, "Najprv vyber zamestnanca.", "Upozornenie", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Dim potvrdenie = MessageBox.Show(Me, "Naozaj chceš vymazať vybraného zamestnanca?", "Potvrdenie", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If potvrdenie = DialogResult.Yes Then
            _logika.VymazZamestnanca(vybrany.Id)
            NacitajZamestnancov()
        End If
    End Sub

End Class
