Imports System.Data.SqlClient

Public Class OddelenieCRUD
    Inherits ZakladnyCRUD

    Public Sub New(pripojovaciRetazec As String)
        MyBase.New(pripojovaciRetazec)
    End Sub

    Public Function ZiskajOddeleniaPodlaProjektu(projektId As Integer) As List(Of mOddelenie)
        Throw New NotImplementedException()
    End Function

    Public Function UlozOddelenie(oddelenie As mOddelenie) As Integer
        Throw New NotImplementedException()
    End Function

    Public Sub AktualizujOddelenie(oddelenie As mOddelenie)
        Throw New NotImplementedException()
    End Sub

    Public Sub VymazOddelenie(id As Integer)
        Throw New NotImplementedException()
    End Sub
End Class
