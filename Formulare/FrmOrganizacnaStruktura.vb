Imports System.Windows.Forms

Partial Public Class FrmOrganizacnaStruktura
    Inherits Form
    Private ReadOnly _logika As OrganizacnaStrukturaLogika
    Private ReadOnly _zamestnanecCrud As ZamestnanecCRUD

    Public Sub New()
        InitializeComponent()
        Dim pripojenie = SqlPripojenie.ZiskajPripojovaciRetazec()
        _logika = New OrganizacnaStrukturaLogika(New FirmaCRUD(pripojenie), New DiviziaCRUD(pripojenie), New ProjektCRUD(pripojenie), New OddelenieCRUD(pripojenie))
        _zamestnanecCrud = New ZamestnanecCRUD(pripojenie)
    End Sub

    Private Sub FrmOrganizacnaStruktura_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        hlavnySplit.Panel1MinSize = 250
        hlavnySplit.Panel2MinSize = 300

        Dim dostupnaSirka = hlavnySplit.Width
        Dim preferovana = CInt(dostupnaSirka * 0.55)
        Dim minLeft = hlavnySplit.Panel1MinSize
        Dim maxLeft = dostupnaSirka - hlavnySplit.Panel2MinSize
        hlavnySplit.SplitterDistance = Math.Max(minLeft, Math.Min(preferovana, maxLeft))
        NacitajStrom()
    End Sub

    Private Sub NacitajStrom()
        strom.Nodes.Clear()
        txtNazov.Text = String.Empty
        txtKod.Text = String.Empty
        txtVeduci.Text = String.Empty

        Dim firma = _logika.ZiskajFirmu()
        If firma Is Nothing Then
            Return
        End If

        Dim root = New TreeNode($"{firma.Nazov} ({firma.Kod})") With {.Tag = firma}
        strom.Nodes.Add(root)

        Dim divizie = _logika.ZiskajDivizie(firma.Id)
        For Each divizia In divizie
            Dim divNode = New TreeNode($"{divizia.Nazov} ({divizia.Kod})") With {.Tag = divizia}
            root.Nodes.Add(divNode)

            Dim projekty = _logika.ZiskajProjekty(divizia.Id)
            For Each projekt In projekty
                Dim projNode = New TreeNode($"{projekt.Nazov} ({projekt.Kod})") With {.Tag = projekt}
                divNode.Nodes.Add(projNode)

                Dim oddelenia = _logika.ZiskajOddelenia(projekt.Id)
                For Each oddelenie In oddelenia
                    Dim oddNode = New TreeNode($"{oddelenie.Nazov} ({oddelenie.Kod})") With {.Tag = oddelenie}
                    projNode.Nodes.Add(oddNode)
                Next
            Next
        Next

        root.Expand()
    End Sub

    Private Sub StromPoVybere(sender As Object, e As TreeViewEventArgs) Handles strom.AfterSelect
        txtNazov.Text = String.Empty
        txtKod.Text = String.Empty
        txtVeduci.Text = String.Empty

        Dim tag = e.Node.Tag
        If TypeOf tag Is mFirma Then
            Dim firma = DirectCast(tag, mFirma)
            txtNazov.Text = firma.Nazov
            txtKod.Text = firma.Kod
            txtVeduci.Text = ZiskajMenoVeduceho(firma.RiaditelId)
        ElseIf TypeOf tag Is mDivizia Then
            Dim divizia = DirectCast(tag, mDivizia)
            txtNazov.Text = divizia.Nazov
            txtKod.Text = divizia.Kod
            txtVeduci.Text = ZiskajMenoVeduceho(divizia.VeduciDivizieId)
        ElseIf TypeOf tag Is mProjekt Then
            Dim projekt = DirectCast(tag, mProjekt)
            txtNazov.Text = projekt.Nazov
            txtKod.Text = projekt.Kod
            txtVeduci.Text = ZiskajMenoVeduceho(projekt.VeduciProjektuId)
        ElseIf TypeOf tag Is mOddelenie Then
            Dim oddelenie = DirectCast(tag, mOddelenie)
            txtNazov.Text = oddelenie.Nazov
            txtKod.Text = oddelenie.Kod
            txtVeduci.Text = ZiskajMenoVeduceho(oddelenie.VeduciOddeleniaId)
        End If
    End Sub

    Private Function ZiskajMenoVeduceho(veduciId As Integer?) As String
        If Not veduciId.HasValue Then
            Return "nezadané"
        End If

        Dim zamestnanec = _zamestnanecCrud.ZiskajZamestnancaPodlaId(veduciId.Value)
        If zamestnanec Is Nothing Then
            Return "nezadané"
        End If

        Dim titul = If(String.IsNullOrWhiteSpace(zamestnanec.Titul), String.Empty, zamestnanec.Titul & " ")
        Dim meno = (titul & zamestnanec.Meno & " " & zamestnanec.Priezvisko).Trim()
        Return If(String.IsNullOrWhiteSpace(meno), "nezadané", meno)
    End Function

    Private Sub btnPridat_Click(sender As Object, e As EventArgs) Handles btnPridat.Click
        Dim vybrany = strom.SelectedNode

        If vybrany Is Nothing Then
            If strom.Nodes.Count > 0 Then
                MessageBox.Show(Me, "Najprv vyberte uzol.", "Upozornenie", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            End If

            Using frm As New FrmUpravaUzla()
                If frm.ShowDialog(Me) = DialogResult.OK Then
                    Dim firma = New mFirma With {.Nazov = frm.UzolNazov, .Kod = frm.UzolKod}
                    _logika.UlozFirmu(firma)
                    NacitajStrom()
                End If
            End Using
            Return
        End If

        Dim tag = vybrany.Tag
        If TypeOf tag Is mFirma Then
            Using frm As New FrmUpravaUzla()
                If frm.ShowDialog(Me) = DialogResult.OK Then
                    Dim divizia = New mDivizia With {
                        .FirmaId = DirectCast(tag, mFirma).Id,
                        .Nazov = frm.UzolNazov,
                        .Kod = frm.UzolKod
                    }
                    _logika.UlozDiviziu(divizia)
                    NacitajStrom()
                End If
            End Using
        ElseIf TypeOf tag Is mDivizia Then
            Using frm As New FrmUpravaUzla()
                If frm.ShowDialog(Me) = DialogResult.OK Then
                    Dim projekt = New mProjekt With {
                        .DiviziaId = DirectCast(tag, mDivizia).Id,
                        .Nazov = frm.UzolNazov,
                        .Kod = frm.UzolKod
                    }
                    _logika.UlozProjekt(projekt)
                    NacitajStrom()
                End If
            End Using
        ElseIf TypeOf tag Is mProjekt Then
            Using frm As New FrmUpravaUzla()
                If frm.ShowDialog(Me) = DialogResult.OK Then
                    Dim oddelenie = New mOddelenie With {
                        .ProjektId = DirectCast(tag, mProjekt).Id,
                        .Nazov = frm.UzolNazov,
                        .Kod = frm.UzolKod
                    }
                    _logika.UlozOddelenie(oddelenie)
                    NacitajStrom()
                End If
            End Using
        Else
            MessageBox.Show(Me, "Nie je možné pridať ďalšiu úroveň.", "Upozornenie", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub btnUpravit_Click(sender As Object, e As EventArgs) Handles btnUpravit.Click
        Dim vybrany = strom.SelectedNode
        If vybrany Is Nothing Then
            MessageBox.Show(Me, "Najprv vyberte uzol.", "Upozornenie", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Dim tag = vybrany.Tag
        If TypeOf tag Is mFirma Then
            Dim firma = DirectCast(tag, mFirma)
            Using frm As New FrmUpravaUzla(firma.Nazov, firma.Kod)
                If frm.ShowDialog(Me) = DialogResult.OK Then
                    firma.Nazov = frm.UzolNazov
                    firma.Kod = frm.UzolKod
                    _logika.AktualizujFirmu(firma)
                    NacitajStrom()
                End If
            End Using
        ElseIf TypeOf tag Is mDivizia Then
            Dim divizia = DirectCast(tag, mDivizia)
            Using frm As New FrmUpravaUzla(divizia.Nazov, divizia.Kod)
                If frm.ShowDialog(Me) = DialogResult.OK Then
                    divizia.Nazov = frm.UzolNazov
                    divizia.Kod = frm.UzolKod
                    _logika.AktualizujDiviziu(divizia)
                    NacitajStrom()
                End If
            End Using
        ElseIf TypeOf tag Is mProjekt Then
            Dim projekt = DirectCast(tag, mProjekt)
            Using frm As New FrmUpravaUzla(projekt.Nazov, projekt.Kod)
                If frm.ShowDialog(Me) = DialogResult.OK Then
                    projekt.Nazov = frm.UzolNazov
                    projekt.Kod = frm.UzolKod
                    _logika.AktualizujProjekt(projekt)
                    NacitajStrom()
                End If
            End Using
        ElseIf TypeOf tag Is mOddelenie Then
            Dim oddelenie = DirectCast(tag, mOddelenie)
            Using frm As New FrmUpravaUzla(oddelenie.Nazov, oddelenie.Kod)
                If frm.ShowDialog(Me) = DialogResult.OK Then
                    oddelenie.Nazov = frm.UzolNazov
                    oddelenie.Kod = frm.UzolKod
                    _logika.AktualizujOddelenie(oddelenie)
                    NacitajStrom()
                End If
            End Using
        End If
    End Sub

    Private Sub btnVymazat_Click(sender As Object, e As EventArgs) Handles btnVymazat.Click
        Dim vybrany = strom.SelectedNode
        If vybrany Is Nothing Then
            MessageBox.Show(Me, "Najprv vyberte uzol.", "Upozornenie", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Dim tag = vybrany.Tag
        Dim uzolTyp As TypUzla? = Nothing
        Dim uzolId As Integer = 0

        If TypeOf tag Is mFirma Then
            uzolTyp = TypUzla.Firma
            uzolId = DirectCast(tag, mFirma).Id
        ElseIf TypeOf tag Is mDivizia Then
            uzolTyp = TypUzla.Divizia
            uzolId = DirectCast(tag, mDivizia).Id
        ElseIf TypeOf tag Is mProjekt Then
            uzolTyp = TypUzla.Projekt
            uzolId = DirectCast(tag, mProjekt).Id
        ElseIf TypeOf tag Is mOddelenie Then
            uzolTyp = TypUzla.Oddelenie
            uzolId = DirectCast(tag, mOddelenie).Id
        End If

        If uzolTyp.HasValue AndAlso _zamestnanecCrud.MaUzolZamestnancov(uzolTyp.Value.ToString(), uzolId) Then
            MessageBox.Show(Me, "Uzol nie je možné vymazať, pretože obsahuje priradených zamestnancov.", "Upozornenie", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim potvrdenie = MessageBox.Show(Me, "Naozaj chcete vymazať vybraný uzol?", "Potvrdenie", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If potvrdenie <> DialogResult.Yes Then
            Return
        End If

        Try
            If TypeOf tag Is mFirma Then
                _logika.VymazFirmu(uzolId)
            ElseIf TypeOf tag Is mDivizia Then
                _logika.VymazDiviziu(uzolId)
            ElseIf TypeOf tag Is mProjekt Then
                _logika.VymazProjekt(uzolId)
            ElseIf TypeOf tag Is mOddelenie Then
                _logika.VymazOddelenie(uzolId)
            End If

            NacitajStrom()
        Catch ex As Exception
            MessageBox.Show(Me, "Uzol sa nepodarilo vymazať. Skontroluj, či neobsahuje podriadené záznamy.", "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

End Class
