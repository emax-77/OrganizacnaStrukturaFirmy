Imports System.Data.SqlClient

Public Class ProjektCRUD
    Inherits ZakladnyCRUD

    Public Sub New(connectionString As String)
        MyBase.New(connectionString)
    End Sub

    Public Function ZiskajProjektyPodlaDivizie(diviziaId As Integer) As List(Of mProjekt)
        Dim vysledok As New List(Of mProjekt)
        Using spojenie = VytvorSpojenie()
            Dim sql = "SELECT Id, DiviziaId, Nazov, Kod, VeduciProjektuId FROM Projekt WHERE DiviziaId=@DiviziaId"
            Dim prikaz = New SqlCommand(sql, spojenie)
            PridajParameter(prikaz, "@DiviziaId", diviziaId)
            spojenie.Open()
            Using reader = prikaz.ExecuteReader()
                While reader.Read()
                    vysledok.Add(New mProjekt With {
                        .Id = reader.GetInt32(0),
                        .DiviziaId = reader.GetInt32(1),
                        .Nazov = reader.GetString(2),
                        .Kod = reader.GetString(3),
                        .VeduciProjektuId = If(reader.IsDBNull(4), CType(Nothing, Integer?), reader.GetInt32(4))
                    })
                End While
            End Using
        End Using
        Return vysledok
    End Function

    Public Function UlozProjekt(projekt As mProjekt) As Integer
        Using spojenie = VytvorSpojenie()
            Dim sql = "INSERT INTO Projekt (DiviziaId, Nazov, Kod, VeduciProjektuId) OUTPUT INSERTED.Id VALUES (@DiviziaId, @Nazov, @Kod, @VeduciProjektuId)"
            Dim prikaz = New SqlCommand(sql, spojenie)
            PridajParameter(prikaz, "@DiviziaId", projekt.DiviziaId)
            PridajParameter(prikaz, "@Nazov", projekt.Nazov)
            PridajParameter(prikaz, "@Kod", projekt.Kod)
            PridajParameter(prikaz, "@VeduciProjektuId", projekt.VeduciProjektuId)
            spojenie.Open()
            Return CInt(prikaz.ExecuteScalar())
        End Using
    End Function

    Public Sub AktualizujProjekt(projekt As mProjekt)
        Using spojenie = VytvorSpojenie()
            Dim sql = "UPDATE Projekt SET Nazov=@Nazov, Kod=@Kod, VeduciProjektuId=@VeduciProjektuId WHERE Id=@Id"
            Dim prikaz = New SqlCommand(sql, spojenie)
            PridajParameter(prikaz, "@Nazov", projekt.Nazov)
            PridajParameter(prikaz, "@Kod", projekt.Kod)
            PridajParameter(prikaz, "@VeduciProjektuId", projekt.VeduciProjektuId)
            PridajParameter(prikaz, "@Id", projekt.Id)
            spojenie.Open()
            prikaz.ExecuteNonQuery()
        End Using
    End Sub

    Public Sub NastavVeduciProjektu(projektId As Integer, veduciId As Integer?)
        Using spojenie = VytvorSpojenie()
            Dim sql = "UPDATE Projekt SET VeduciProjektuId=@VeduciProjektuId WHERE Id=@Id"
            Dim prikaz = New SqlCommand(sql, spojenie)
            PridajParameter(prikaz, "@VeduciProjektuId", veduciId)
            PridajParameter(prikaz, "@Id", projektId)
            spojenie.Open()
            prikaz.ExecuteNonQuery()
        End Using
    End Sub

    Public Sub VymazProjekt(id As Integer)
        Using spojenie = VytvorSpojenie()
            Dim sql = "DELETE FROM Projekt WHERE Id=@Id"
            Dim prikaz = New SqlCommand(sql, spojenie)
            PridajParameter(prikaz, "@Id", id)
            spojenie.Open()
            prikaz.ExecuteNonQuery()
        End Using
    End Sub
End Class
