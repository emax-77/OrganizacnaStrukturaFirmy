Imports System.Data.SqlClient

Public MustInherit Class ZakladnyCRUD
    Protected ReadOnly PripojovaciRetazec As String

    Protected Sub New(pripojovaciRetazec As String)
        Me.PripojovaciRetazec = pripojovaciRetazec
    End Sub

    Protected Function VytvorSpojenie() As SqlConnection
        Return New SqlConnection(PripojovaciRetazec)
    End Function

    Protected Sub PridajParameter(prikaz As SqlCommand, nazov As String, hodnota As Object)
        prikaz.Parameters.AddWithValue(nazov, If(hodnota, DBNull.Value))
    End Sub
End Class
