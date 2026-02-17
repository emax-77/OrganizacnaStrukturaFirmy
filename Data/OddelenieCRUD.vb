Imports System.Data.SqlClient

Public Class OddelenieCRUD
    Inherits ZakladnyCRUD

    Public Sub New(connectionString As String)
        MyBase.New(connectionString)
    End Sub

    Public Function ZiskajVsetkyOddelenia() As List(Of mOddelenie)
        Dim vysledok As New List(Of mOddelenie)
        Using spojenie = VytvorSpojenie()
            Dim sql = "SELECT Id, ProjektId, Nazov, Kod, VeduciOddeleniaId FROM Oddelenie"
            Using prikaz = New SqlCommand(sql, spojenie)
                spojenie.Open()
                Using reader = prikaz.ExecuteReader()
                    While reader.Read()
                        vysledok.Add(New mOddelenie With {
                            .Id = reader.GetInt32(0),
                            .ProjektId = reader.GetInt32(1),
                            .Nazov = reader.GetString(2),
                            .Kod = reader.GetString(3),
                            .VeduciOddeleniaId = If(reader.IsDBNull(4), CType(Nothing, Integer?), reader.GetInt32(4))
                        })
                    End While
                End Using
            End Using
        End Using
        Return vysledok
    End Function

    Public Function ZiskajOddeleniaPodlaProjektu(projektId As Integer) As List(Of mOddelenie)
        Dim vysledok As New List(Of mOddelenie)
        Using spojenie = VytvorSpojenie()
            Dim sql = "SELECT Id, ProjektId, Nazov, Kod, VeduciOddeleniaId FROM Oddelenie WHERE ProjektId=@ProjektId"
            Using prikaz = New SqlCommand(sql, spojenie)
                PridajParameter(prikaz, "@ProjektId", projektId)
                spojenie.Open()
                Using reader = prikaz.ExecuteReader()
                    While reader.Read()
                        vysledok.Add(New mOddelenie With {
                            .Id = reader.GetInt32(0),
                            .ProjektId = reader.GetInt32(1),
                            .Nazov = reader.GetString(2),
                            .Kod = reader.GetString(3),
                            .VeduciOddeleniaId = If(reader.IsDBNull(4), CType(Nothing, Integer?), reader.GetInt32(4))
                        })
                    End While
                End Using
            End Using
        End Using
        Return vysledok
    End Function

    Public Function UlozOddelenie(oddelenie As mOddelenie) As Integer
        Using spojenie = VytvorSpojenie()
            Dim sql = "INSERT INTO Oddelenie (ProjektId, Nazov, Kod, VeduciOddeleniaId) OUTPUT INSERTED.Id VALUES (@ProjektId, @Nazov, @Kod, @VeduciOddeleniaId)"
            Using prikaz = New SqlCommand(sql, spojenie)
                PridajParameter(prikaz, "@ProjektId", oddelenie.ProjektId)
                PridajParameter(prikaz, "@Nazov", oddelenie.Nazov)
                PridajParameter(prikaz, "@Kod", oddelenie.Kod)
                PridajParameter(prikaz, "@VeduciOddeleniaId", oddelenie.VeduciOddeleniaId)
                spojenie.Open()
                Return CInt(prikaz.ExecuteScalar())
            End Using
        End Using
    End Function

    Public Sub AktualizujOddelenie(oddelenie As mOddelenie)
        Using spojenie = VytvorSpojenie()
            Dim sql = "UPDATE Oddelenie SET Nazov=@Nazov, Kod=@Kod, VeduciOddeleniaId=@VeduciOddeleniaId WHERE Id=@Id"
            Using prikaz = New SqlCommand(sql, spojenie)
                PridajParameter(prikaz, "@Nazov", oddelenie.Nazov)
                PridajParameter(prikaz, "@Kod", oddelenie.Kod)
                PridajParameter(prikaz, "@VeduciOddeleniaId", oddelenie.VeduciOddeleniaId)
                PridajParameter(prikaz, "@Id", oddelenie.Id)
                spojenie.Open()
                prikaz.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    Public Sub NastavVeduciOddelenia(oddelenieId As Integer, veduciId As Integer?)
        Using spojenie = VytvorSpojenie()
            Dim sql = "UPDATE Oddelenie SET VeduciOddeleniaId=@VeduciOddeleniaId WHERE Id=@Id"
            Using prikaz = New SqlCommand(sql, spojenie)
                PridajParameter(prikaz, "@VeduciOddeleniaId", veduciId)
                PridajParameter(prikaz, "@Id", oddelenieId)
                spojenie.Open()
                prikaz.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    Public Sub VymazOddelenie(id As Integer)
        Using spojenie = VytvorSpojenie()
            Dim sql = "DELETE FROM Oddelenie WHERE Id=@Id"
            Using prikaz = New SqlCommand(sql, spojenie)
                PridajParameter(prikaz, "@Id", id)
                spojenie.Open()
                prikaz.ExecuteNonQuery()
            End Using
        End Using
    End Sub
End Class
