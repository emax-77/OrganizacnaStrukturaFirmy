Imports System.Data.SqlClient

Public Class FirmaCRUD
    Inherits ZakladnyCRUD

    Public Sub New(connectionString As String)
        MyBase.New(connectionString)
    End Sub

    Public Function ZiskajFirmu() As mFirma
        Using spojenie = VytvorSpojenie()
            Dim sql = "SELECT TOP 1 Id, Nazov, Kod, RiaditelId FROM Firma"
            Dim prikaz = New SqlCommand(sql, spojenie)
            spojenie.Open()
            Using reader = prikaz.ExecuteReader()
                If reader.Read() Then
                    Return New mFirma With {
                        .Id = reader.GetInt32(0),
                        .Nazov = reader.GetString(1),
                        .Kod = reader.GetString(2),
                        .RiaditelId = If(reader.IsDBNull(3), CType(Nothing, Integer?), reader.GetInt32(3))
                    }
                End If
            End Using
        End Using
        Return Nothing
    End Function

    Public Function UlozFirmu(firma As mFirma) As Integer
        Using spojenie = VytvorSpojenie()
            Dim sql = "INSERT INTO Firma (Nazov, Kod, RiaditelId) OUTPUT INSERTED.Id VALUES (@Nazov, @Kod, @RiaditelId)"
            Dim prikaz = New SqlCommand(sql, spojenie)
            PridajParameter(prikaz, "@Nazov", firma.Nazov)
            PridajParameter(prikaz, "@Kod", firma.Kod)
            PridajParameter(prikaz, "@RiaditelId", firma.RiaditelId)
            spojenie.Open()
            Return CInt(prikaz.ExecuteScalar())
        End Using
    End Function

    Public Sub AktualizujFirmu(firma As mFirma)
        Using spojenie = VytvorSpojenie()
            Dim sql = "UPDATE Firma SET Nazov=@Nazov, Kod=@Kod, RiaditelId=@RiaditelId WHERE Id=@Id"
            Dim prikaz = New SqlCommand(sql, spojenie)
            PridajParameter(prikaz, "@Nazov", firma.Nazov)
            PridajParameter(prikaz, "@Kod", firma.Kod)
            PridajParameter(prikaz, "@RiaditelId", firma.RiaditelId)
            PridajParameter(prikaz, "@Id", firma.Id)
            spojenie.Open()
            prikaz.ExecuteNonQuery()
        End Using
    End Sub

    Public Sub NastavRiaditela(firmaId As Integer, riaditelId As Integer?)
        Using spojenie = VytvorSpojenie()
            Dim sql = "UPDATE Firma SET RiaditelId=@RiaditelId WHERE Id=@Id"
            Dim prikaz = New SqlCommand(sql, spojenie)
            PridajParameter(prikaz, "@RiaditelId", riaditelId)
            PridajParameter(prikaz, "@Id", firmaId)
            spojenie.Open()
            prikaz.ExecuteNonQuery()
        End Using
    End Sub

    Public Sub VymazFirmu(id As Integer)
        Using spojenie = VytvorSpojenie()
            Dim sql = "DELETE FROM Firma WHERE Id=@Id"
            Dim prikaz = New SqlCommand(sql, spojenie)
            PridajParameter(prikaz, "@Id", id)
            spojenie.Open()
            prikaz.ExecuteNonQuery()
        End Using
    End Sub
End Class
