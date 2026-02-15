Imports System.Data.SqlClient

Public Class ZamestnanecCRUD
    Inherits ZakladnyCRUD

    Public Sub New(pripojovaciRetazec As String)
        MyBase.New(pripojovaciRetazec)
    End Sub

    Public Function ZiskajZamestnancovPodlaOddelenia(oddelenieId As Integer) As List(Of mZamestnanec)
        Throw New NotImplementedException()
    End Function

    Public Function UlozZamestnanca(zamestnanec As mZamestnanec) As Integer
        Throw New NotImplementedException()
    End Function

    Public Sub AktualizujZamestnanca(zamestnanec As mZamestnanec)
        Throw New NotImplementedException()
    End Sub

    Public Sub VymazZamestnanca(id As Integer)
        Throw New NotImplementedException()
    End Sub
End Class
