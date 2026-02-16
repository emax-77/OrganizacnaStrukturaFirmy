Imports System.Data.SqlClient

Public Class DiviziaCRUD
    Inherits ZakladnyCRUD

    Public Sub New(connectionString As String)
        MyBase.New(connectionString)
    End Sub

    Public Function ZiskajDiviziePodlaFirmy(firmaId As Integer) As List(Of mDivizia)
        Dim vysledok As New List(Of mDivizia)
        Using spojenie = VytvorSpojenie()
            Dim sql = "SELECT Id, FirmaId, Nazov, Kod, VeduciDivizieId FROM Divizia WHERE FirmaId=@FirmaId"
            Dim prikaz = New SqlCommand(sql, spojenie)
            PridajParameter(prikaz, "@FirmaId", firmaId)
            spojenie.Open()
            Using reader = prikaz.ExecuteReader()
                While reader.Read()
                    vysledok.Add(New mDivizia With {
                        .Id = reader.GetInt32(0),
                        .FirmaId = reader.GetInt32(1),
                        .Nazov = reader.GetString(2),
                        .Kod = reader.GetString(3),
                        .VeduciDivizieId = If(reader.IsDBNull(4), CType(Nothing, Integer?), reader.GetInt32(4))
                    })
                End While
            End Using
        End Using
        Return vysledok
    End Function

    Public Function UlozDiviziu(divizia As mDivizia) As Integer
        Using spojenie = VytvorSpojenie()
            Dim sql = "INSERT INTO Divizia (FirmaId, Nazov, Kod, VeduciDivizieId) OUTPUT INSERTED.Id VALUES (@FirmaId, @Nazov, @Kod, @VeduciDivizieId)"
            Dim prikaz = New SqlCommand(sql, spojenie)
            PridajParameter(prikaz, "@FirmaId", divizia.FirmaId)
            PridajParameter(prikaz, "@Nazov", divizia.Nazov)
            PridajParameter(prikaz, "@Kod", divizia.Kod)
            PridajParameter(prikaz, "@VeduciDivizieId", divizia.VeduciDivizieId)
            spojenie.Open()
            Return CInt(prikaz.ExecuteScalar())
        End Using
    End Function

    Public Sub AktualizujDiviziu(divizia As mDivizia)
        Using spojenie = VytvorSpojenie()
            Dim sql = "UPDATE Divizia SET Nazov=@Nazov, Kod=@Kod, VeduciDivizieId=@VeduciDivizieId WHERE Id=@Id"
            Dim prikaz = New SqlCommand(sql, spojenie)
            PridajParameter(prikaz, "@Nazov", divizia.Nazov)
            PridajParameter(prikaz, "@Kod", divizia.Kod)
            PridajParameter(prikaz, "@VeduciDivizieId", divizia.VeduciDivizieId)
            PridajParameter(prikaz, "@Id", divizia.Id)
            spojenie.Open()
            prikaz.ExecuteNonQuery()
        End Using
    End Sub

    Public Sub NastavVeduciDivizie(diviziaId As Integer, veduciId As Integer?)
        Using spojenie = VytvorSpojenie()
            Dim sql = "UPDATE Divizia SET VeduciDivizieId=@VeduciDivizieId WHERE Id=@Id"
            Dim prikaz = New SqlCommand(sql, spojenie)
            PridajParameter(prikaz, "@VeduciDivizieId", veduciId)
            PridajParameter(prikaz, "@Id", diviziaId)
            spojenie.Open()
            prikaz.ExecuteNonQuery()
        End Using
    End Sub

    Public Sub VymazDiviziu(id As Integer)
        Using spojenie = VytvorSpojenie()
            Dim sql = "DELETE FROM Divizia WHERE Id=@Id"
            Dim prikaz = New SqlCommand(sql, spojenie)
            PridajParameter(prikaz, "@Id", id)
            spojenie.Open()
            prikaz.ExecuteNonQuery()
        End Using
    End Sub
End Class
