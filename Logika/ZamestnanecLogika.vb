Public Class ZamestnanecLogika
    Private ReadOnly _zamestnanecCrud As ZamestnanecCRUD
    Private ReadOnly _strukturaLogika As OrganizacnaStrukturaLogika

    Public Sub New(zamestnanecCrud As ZamestnanecCRUD, strukturaLogika As OrganizacnaStrukturaLogika)
        _zamestnanecCrud = zamestnanecCrud
        _strukturaLogika = strukturaLogika
    End Sub

    Public Function ZiskajVsetkychZamestnancov() As List(Of mZamestnanec)
        Return _zamestnanecCrud.ZiskajVsetkychZamestnancov()
    End Function

    Public Function ZiskajZaradenia() As List(Of mUzolStromu)
        Return _strukturaLogika.ZiskajZaradenia()
    End Function

    Public Function ZiskajUzly() As List(Of mUzolStromu)
        Return _strukturaLogika.ZiskajUzly()
    End Function

    Public Function UlozZamestnanca(zamestnanec As mZamestnanec) As Integer
        Dim id = _zamestnanecCrud.UlozZamestnanca(zamestnanec)
        _strukturaLogika.NastavVeduciPodlaZaradenia(zamestnanec.Zaradenie, zamestnanec.ZaradenieId, id)
        Return id
    End Function

    Public Sub AktualizujZamestnanca(zamestnanec As mZamestnanec)
        _zamestnanecCrud.AktualizujZamestnanca(zamestnanec)
        _strukturaLogika.NastavVeduciPodlaZaradenia(zamestnanec.Zaradenie, zamestnanec.ZaradenieId, zamestnanec.Id)
    End Sub

    Public Sub VymazZamestnanca(id As Integer)
        Dim zamestnanec = _zamestnanecCrud.ZiskajZamestnancaPodlaId(id)
        If zamestnanec IsNot Nothing AndAlso Not String.Equals(zamestnanec.Zaradenie, "Zamestnanec", StringComparison.OrdinalIgnoreCase) Then
            _strukturaLogika.ZrusVeduciPodlaZaradenia(zamestnanec.Zaradenie, zamestnanec.ZaradenieId)
        End If
        _zamestnanecCrud.VymazZamestnanca(id)
    End Sub

    Public Function ExistujeVeduci(zaradenie As String, zaradenieId As Integer, okremId As Integer?) As Boolean
        Return _zamestnanecCrud.ExistujeVeduci(zaradenie, zaradenieId, okremId)
    End Function
End Class
