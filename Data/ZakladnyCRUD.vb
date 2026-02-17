Imports System.Data.SqlClient

Public MustInherit Class ZakladnyCRUD
    Protected ReadOnly ConnectionString As String

    Protected Sub New(connectionString As String)
        Me.ConnectionString = connectionString
    End Sub

    Protected Function VytvorSpojenie() As SqlConnection
        Return New SqlConnection(ConnectionString)
    End Function

    Protected Sub PridajParameter(prikaz As SqlCommand, nazov As String, hodnota As Object)
        prikaz.Parameters.AddWithValue(nazov, If(hodnota, DBNull.Value))
    End Sub

    Protected Function ParseTypUzla(hodnota As String) As TypUzla?
        Dim vysledok As TypUzla
        If [Enum].TryParse(hodnota, vysledok) Then
            Return vysledok
        End If
        Return Nothing
    End Function

    Protected Function ParseZaradenieTyp(zaradenie As String) As TypUzla?
        If String.IsNullOrEmpty(zaradenie) Then Return Nothing
        If zaradenie.StartsWith("Riaditeľ", StringComparison.OrdinalIgnoreCase) Then Return TypUzla.Firma
        If zaradenie.StartsWith("Vedúci divízie", StringComparison.OrdinalIgnoreCase) Then Return TypUzla.Divizia
        If zaradenie.StartsWith("Vedúci projektu", StringComparison.OrdinalIgnoreCase) Then Return TypUzla.Projekt
        If zaradenie.StartsWith("Vedúci oddelenia", StringComparison.OrdinalIgnoreCase) Then Return TypUzla.Oddelenie
        Return Nothing
    End Function
End Class
