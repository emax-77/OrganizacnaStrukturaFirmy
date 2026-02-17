Public Class OrganizacnaStrukturaLogika
    Private ReadOnly _firmaCrud As FirmaCRUD
    Private ReadOnly _diviziaCrud As DiviziaCRUD
    Private ReadOnly _projektCrud As ProjektCRUD
    Private ReadOnly _oddelenieCrud As OddelenieCRUD

    Public Sub New(firmaCrud As FirmaCRUD, diviziaCrud As DiviziaCRUD, projektCrud As ProjektCRUD, oddelenieCrud As OddelenieCRUD)
        _firmaCrud = firmaCrud
        _diviziaCrud = diviziaCrud
        _projektCrud = projektCrud
        _oddelenieCrud = oddelenieCrud
    End Sub

    Public Function ZiskajFirmu() As mFirma
        Return _firmaCrud.ZiskajFirmu()
    End Function

    Public Function UlozFirmu(firma As mFirma) As Integer
        Return _firmaCrud.UlozFirmu(firma)
    End Function

    Public Sub AktualizujFirmu(firma As mFirma)
        _firmaCrud.AktualizujFirmu(firma)
    End Sub

    Public Sub VymazFirmu(id As Integer)
        _firmaCrud.VymazFirmu(id)
    End Sub

    Public Function ZiskajDivizie(firmaId As Integer) As List(Of mDivizia)
        Return _diviziaCrud.ZiskajDiviziePodlaFirmy(firmaId)
    End Function

    Public Function UlozDiviziu(divizia As mDivizia) As Integer
        Return _diviziaCrud.UlozDiviziu(divizia)
    End Function

    Public Sub AktualizujDiviziu(divizia As mDivizia)
        _diviziaCrud.AktualizujDiviziu(divizia)
    End Sub

    Public Sub VymazDiviziu(id As Integer)
        _diviziaCrud.VymazDiviziu(id)
    End Sub

    Public Function ZiskajProjekty(diviziaId As Integer) As List(Of mProjekt)
        Return _projektCrud.ZiskajProjektyPodlaDivizie(diviziaId)
    End Function

    Public Function UlozProjekt(projekt As mProjekt) As Integer
        Return _projektCrud.UlozProjekt(projekt)
    End Function

    Public Sub AktualizujProjekt(projekt As mProjekt)
        _projektCrud.AktualizujProjekt(projekt)
    End Sub

    Public Sub VymazProjekt(id As Integer)
        _projektCrud.VymazProjekt(id)
    End Sub

    Public Function ZiskajOddelenia(projektId As Integer) As List(Of mOddelenie)
        Return _oddelenieCrud.ZiskajOddeleniaPodlaProjektu(projektId)
    End Function

    Private Function ZiskajVsetkyUzly(typPopisu As String) As List(Of mUzolStromu)
        Dim vysledok As New List(Of mUzolStromu)

        Dim firma = _firmaCrud.ZiskajFirmu()
        If firma Is Nothing Then Return vysledok

        vysledok.Add(New mUzolStromu With {
            .Id = firma.Id,
            .Nazov = firma.Nazov,
            .Kod = firma.Kod,
            .Typ = TypUzla.Firma,
            .Popis = If(typPopisu = "zaradenie",
                        $"Riaditeľ: {firma.Nazov} ({firma.Kod})",
                        $"Firma: {firma.Nazov} ({firma.Kod})")
        })

        For Each divizia In _diviziaCrud.ZiskajDiviziePodlaFirmy(firma.Id)
            vysledok.Add(New mUzolStromu With {
                .Id = divizia.Id, .RodicId = divizia.FirmaId,
                .Nazov = divizia.Nazov, .Kod = divizia.Kod, .Typ = TypUzla.Divizia,
                .Popis = If(typPopisu = "zaradenie",
                            $"Vedúci divízie: {divizia.Nazov} ({divizia.Kod})",
                            $"Divízia: {divizia.Nazov} ({divizia.Kod})")
            })
            For Each projekt In _projektCrud.ZiskajProjektyPodlaDivizie(divizia.Id)
                vysledok.Add(New mUzolStromu With {
                    .Id = projekt.Id, .RodicId = projekt.DiviziaId,
                    .Nazov = projekt.Nazov, .Kod = projekt.Kod, .Typ = TypUzla.Projekt,
                    .Popis = If(typPopisu = "zaradenie",
                                $"Vedúci projektu: {projekt.Nazov} ({projekt.Kod})",
                                $"Projekt: {projekt.Nazov} ({projekt.Kod})")
                })
                For Each oddelenie In _oddelenieCrud.ZiskajOddeleniaPodlaProjektu(projekt.Id)
                    vysledok.Add(New mUzolStromu With {
                        .Id = oddelenie.Id, .RodicId = oddelenie.ProjektId,
                        .Nazov = oddelenie.Nazov, .Kod = oddelenie.Kod, .Typ = TypUzla.Oddelenie,
                        .Popis = If(typPopisu = "zaradenie",
                                    $"Vedúci oddelenia: {oddelenie.Nazov} ({oddelenie.Kod})",
                                    $"Oddelenie: {oddelenie.Nazov} ({oddelenie.Kod})")
                    })
                Next
            Next
        Next

        Return vysledok
    End Function

    Public Function ZiskajZaradenia() As List(Of mUzolStromu)
        Dim vysledok = New List(Of mUzolStromu)
        vysledok.Add(New mUzolStromu With {
            .Id = 0, .Nazov = "Zamestnanec", .Kod = String.Empty,
            .Typ = Nothing, .Popis = "Zamestnanec"
        })
        vysledok.AddRange(ZiskajVsetkyUzly("zaradenie"))
        Return vysledok
    End Function

    Public Function ZiskajUzly() As List(Of mUzolStromu)
        Return ZiskajVsetkyUzly("uzol")
    End Function

    Public Function UlozOddelenie(oddelenie As mOddelenie) As Integer
        Return _oddelenieCrud.UlozOddelenie(oddelenie)
    End Function

    Public Sub AktualizujOddelenie(oddelenie As mOddelenie)
        _oddelenieCrud.AktualizujOddelenie(oddelenie)
    End Sub

    Public Sub VymazOddelenie(id As Integer)
        _oddelenieCrud.VymazOddelenie(id)
    End Sub

    Public Sub NastavVeduciPodlaZaradenia(zaradenie As String, uzolTyp As TypUzla?, uzolId As Integer, zamestnanecId As Integer)
        If Not uzolTyp.HasValue Then
            Return
        End If

        Select Case uzolTyp.Value
            Case TypUzla.Firma
                _firmaCrud.NastavRiaditela(uzolId, zamestnanecId)
            Case TypUzla.Divizia
                _diviziaCrud.NastavVeduciDivizie(uzolId, zamestnanecId)
            Case TypUzla.Projekt
                _projektCrud.NastavVeduciProjektu(uzolId, zamestnanecId)
            Case TypUzla.Oddelenie
                _oddelenieCrud.NastavVeduciOddelenia(uzolId, zamestnanecId)
        End Select
    End Sub

    Public Sub ZrusVeduciPodlaZaradenia(uzolTyp As TypUzla?, uzolId As Integer)
        If Not uzolTyp.HasValue Then Return

        Select Case uzolTyp.Value
            Case TypUzla.Firma
                _firmaCrud.NastavRiaditela(uzolId, Nothing)
            Case TypUzla.Divizia
                _diviziaCrud.NastavVeduciDivizie(uzolId, Nothing)
            Case TypUzla.Projekt
                _projektCrud.NastavVeduciProjektu(uzolId, Nothing)
            Case TypUzla.Oddelenie
                _oddelenieCrud.NastavVeduciOddelenia(uzolId, Nothing)
        End Select
    End Sub

End Class
