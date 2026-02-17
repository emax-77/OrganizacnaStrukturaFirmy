Imports System.Data.SqlClient

Public Class ZamestnanecCRUD
    Inherits ZakladnyCRUD

    Public Sub New(connectionString As String)
        MyBase.New(connectionString)
    End Sub

    Public Function ZiskajVsetkychZamestnancov() As List(Of mZamestnanec)
        Dim vysledok As New List(Of mZamestnanec)
        Using spojenie = VytvorSpojenie()
            Dim sql = "SELECT Id, Titul, Meno, Priezvisko, Telefon, Email, Zaradenie, ZaradenieId, UzolTyp, UzolId FROM Zamestnanec"
            Using prikaz = New SqlCommand(sql, spojenie)
                spojenie.Open()
                Using reader = prikaz.ExecuteReader()
                    While reader.Read()
                        vysledok.Add(New mZamestnanec With {
                            .Id = reader.GetInt32(0),
                            .Titul = If(reader.IsDBNull(1), Nothing, reader.GetString(1)),
                            .Meno = reader.GetString(2),
                            .Priezvisko = reader.GetString(3),
                            .Telefon = If(reader.IsDBNull(4), Nothing, reader.GetString(4)),
                            .Email = If(reader.IsDBNull(5), Nothing, reader.GetString(5)),
                            .Zaradenie = reader.GetString(6),
                            .ZaradenieId = reader.GetInt32(7),
                            .UzolTyp = ParseTypUzla(reader.GetString(8)),
                            .UzolId = reader.GetInt32(9)
                        })
                    End While
                End Using
            End Using
        End Using
        Return vysledok
    End Function

    Public Function ZiskajZamestnancaPodlaId(id As Integer) As mZamestnanec
        Using spojenie = VytvorSpojenie()
            Dim sql = "SELECT Id, Titul, Meno, Priezvisko, Telefon, Email, Zaradenie, ZaradenieId, UzolTyp, UzolId FROM Zamestnanec WHERE Id=@Id"
            Using prikaz = New SqlCommand(sql, spojenie)
                PridajParameter(prikaz, "@Id", id)
                spojenie.Open()
                Using reader = prikaz.ExecuteReader()
                    If reader.Read() Then
                        Return New mZamestnanec With {
                            .Id = reader.GetInt32(0),
                            .Titul = If(reader.IsDBNull(1), Nothing, reader.GetString(1)),
                            .Meno = reader.GetString(2),
                            .Priezvisko = reader.GetString(3),
                            .Telefon = If(reader.IsDBNull(4), Nothing, reader.GetString(4)),
                            .Email = If(reader.IsDBNull(5), Nothing, reader.GetString(5)),
                            .Zaradenie = reader.GetString(6),
                            .ZaradenieId = reader.GetInt32(7),
                            .UzolTyp = ParseTypUzla(reader.GetString(8)),
                            .UzolId = reader.GetInt32(9)
                        }
                    End If
                End Using
            End Using
        End Using

        Return Nothing
    End Function

    Public Function ZiskajZamestnancovPodlaZaradenia(zaradenie As String, zaradenieId As Integer) As List(Of mZamestnanec)
        Dim vysledok As New List(Of mZamestnanec)
        Using spojenie = VytvorSpojenie()
            Dim sql = "SELECT Id, Titul, Meno, Priezvisko, Telefon, Email, Zaradenie, ZaradenieId, UzolTyp, UzolId FROM Zamestnanec WHERE Zaradenie=@Zaradenie AND ZaradenieId=@ZaradenieId"
            Using prikaz = New SqlCommand(sql, spojenie)
                PridajParameter(prikaz, "@Zaradenie", zaradenie)
                PridajParameter(prikaz, "@ZaradenieId", zaradenieId)
                spojenie.Open()
                Using reader = prikaz.ExecuteReader()
                    While reader.Read()
                        vysledok.Add(New mZamestnanec With {
                            .Id = reader.GetInt32(0),
                            .Titul = If(reader.IsDBNull(1), Nothing, reader.GetString(1)),
                            .Meno = reader.GetString(2),
                            .Priezvisko = reader.GetString(3),
                            .Telefon = If(reader.IsDBNull(4), Nothing, reader.GetString(4)),
                            .Email = If(reader.IsDBNull(5), Nothing, reader.GetString(5)),
                            .Zaradenie = reader.GetString(6),
                            .ZaradenieId = reader.GetInt32(7),
                            .UzolTyp = ParseTypUzla(reader.GetString(8)),
                            .UzolId = reader.GetInt32(9)
                        })
                    End While
                End Using
            End Using
        End Using
        Return vysledok
    End Function

    Public Function UlozZamestnanca(zamestnanec As mZamestnanec) As Integer
        Using spojenie = VytvorSpojenie()
            Dim sql = "INSERT INTO Zamestnanec (Titul, Meno, Priezvisko, Telefon, Email, Zaradenie, ZaradenieId, UzolTyp, UzolId) OUTPUT INSERTED.Id VALUES (@Titul, @Meno, @Priezvisko, @Telefon, @Email, @Zaradenie, @ZaradenieId, @UzolTyp, @UzolId)"
            Using prikaz = New SqlCommand(sql, spojenie)
                PridajParameter(prikaz, "@Titul", zamestnanec.Titul)
                PridajParameter(prikaz, "@Meno", zamestnanec.Meno)
                PridajParameter(prikaz, "@Priezvisko", zamestnanec.Priezvisko)
                PridajParameter(prikaz, "@Telefon", zamestnanec.Telefon)
                PridajParameter(prikaz, "@Email", zamestnanec.Email)
                PridajParameter(prikaz, "@Zaradenie", zamestnanec.Zaradenie)
                PridajParameter(prikaz, "@ZaradenieId", zamestnanec.ZaradenieId)
                PridajParameter(prikaz, "@UzolTyp", If(zamestnanec.UzolTyp.HasValue, zamestnanec.UzolTyp.Value.ToString(), CObj(DBNull.Value)))
                PridajParameter(prikaz, "@UzolId", zamestnanec.UzolId)
                spojenie.Open()
                Return CInt(prikaz.ExecuteScalar())
            End Using
        End Using
    End Function

    Public Sub AktualizujZamestnanca(zamestnanec As mZamestnanec)
        Using spojenie = VytvorSpojenie()
            Dim sql = "UPDATE Zamestnanec SET Titul=@Titul, Meno=@Meno, Priezvisko=@Priezvisko, Telefon=@Telefon, Email=@Email, Zaradenie=@Zaradenie, ZaradenieId=@ZaradenieId, UzolTyp=@UzolTyp, UzolId=@UzolId WHERE Id=@Id"
            Using prikaz = New SqlCommand(sql, spojenie)
                PridajParameter(prikaz, "@Titul", zamestnanec.Titul)
                PridajParameter(prikaz, "@Meno", zamestnanec.Meno)
                PridajParameter(prikaz, "@Priezvisko", zamestnanec.Priezvisko)
                PridajParameter(prikaz, "@Telefon", zamestnanec.Telefon)
                PridajParameter(prikaz, "@Email", zamestnanec.Email)
                PridajParameter(prikaz, "@Zaradenie", zamestnanec.Zaradenie)
                PridajParameter(prikaz, "@ZaradenieId", zamestnanec.ZaradenieId)
                PridajParameter(prikaz, "@UzolTyp", If(zamestnanec.UzolTyp.HasValue, zamestnanec.UzolTyp.Value.ToString(), CObj(DBNull.Value)))
                PridajParameter(prikaz, "@UzolId", zamestnanec.UzolId)
                PridajParameter(prikaz, "@Id", zamestnanec.Id)
                spojenie.Open()
                prikaz.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    Public Sub VymazZamestnanca(id As Integer)
        Using spojenie = VytvorSpojenie()
            Dim sql = "DELETE FROM Zamestnanec WHERE Id=@Id"
            Using prikaz = New SqlCommand(sql, spojenie)
                PridajParameter(prikaz, "@Id", id)
                spojenie.Open()
                prikaz.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    Public Function MaUzolZamestnancov(uzolTyp As String, uzolId As Integer) As Boolean
        Using spojenie = VytvorSpojenie()
            Dim sql = "SELECT COUNT(1) FROM Zamestnanec WHERE UzolTyp=@UzolTyp AND UzolId=@UzolId"
            Using prikaz = New SqlCommand(sql, spojenie)
                PridajParameter(prikaz, "@UzolTyp", uzolTyp)
                PridajParameter(prikaz, "@UzolId", uzolId)
                spojenie.Open()
                Return CInt(prikaz.ExecuteScalar()) > 0
            End Using
        End Using
    End Function

    Public Function ExistujeVeduci(zaradenie As String, zaradenieId As Integer, okremId As Integer?) As Boolean
        Using spojenie = VytvorSpojenie()
            Dim sql = "SELECT COUNT(1) FROM Zamestnanec WHERE Zaradenie=@Zaradenie AND ZaradenieId=@ZaradenieId"
            If okremId.HasValue Then
                sql &= " AND Id<>@Id"
            End If

            Using prikaz = New SqlCommand(sql, spojenie)
                PridajParameter(prikaz, "@Zaradenie", zaradenie)
                PridajParameter(prikaz, "@ZaradenieId", zaradenieId)
                If okremId.HasValue Then
                    PridajParameter(prikaz, "@Id", okremId.Value)
                End If

                spojenie.Open()
                Return CInt(prikaz.ExecuteScalar()) > 0
            End Using
        End Using
    End Function
End Class
