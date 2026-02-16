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
End Class
