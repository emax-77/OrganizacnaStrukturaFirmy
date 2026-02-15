Imports System.Data.SqlClient

Public Class DiviziaCRUD
    Inherits ZakladnyCRUD

    Public Sub New(pripojovaciRetazec As String)
        MyBase.New(pripojovaciRetazec)
    End Sub

    Public Function ZiskajDiviziePodlaFirmy(firmaId As Integer) As List(Of mDivizia)
        Throw New NotImplementedException()
    End Function

    Public Function UlozDiviziu(divizia As mDivizia) As Integer
        Throw New NotImplementedException()
    End Function

    Public Sub AktualizujDiviziu(divizia As mDivizia)
        Throw New NotImplementedException()
    End Sub

    Public Sub VymazDiviziu(id As Integer)
        Throw New NotImplementedException()
    End Sub
End Class
