Imports System.Data.SqlClient

Public Class ProjektCRUD
    Inherits ZakladnyCRUD

    Public Sub New(pripojovaciRetazec As String)
        MyBase.New(pripojovaciRetazec)
    End Sub

    Public Function ZiskajProjektyPodlaDivizie(diviziaId As Integer) As List(Of mProjekt)
        Throw New NotImplementedException()
    End Function

    Public Function UlozProjekt(projekt As mProjekt) As Integer
        Throw New NotImplementedException()
    End Function

    Public Sub AktualizujProjekt(projekt As mProjekt)
        Throw New NotImplementedException()
    End Sub

    Public Sub VymazProjekt(id As Integer)
        Throw New NotImplementedException()
    End Sub
End Class
