Imports System.Data.SqlClient

Public Class FirmaCRUD
    Inherits ZakladnyCRUD

    Public Sub New(pripojovaciRetazec As String)
        MyBase.New(pripojovaciRetazec)
    End Sub

    Public Function ZiskajFirmu() As mFirma
        Throw New NotImplementedException()
    End Function

    Public Function UlozFirmu(firma As mFirma) As Integer
        Throw New NotImplementedException()
    End Function

    Public Sub AktualizujFirmu(firma As mFirma)
        Throw New NotImplementedException()
    End Sub
End Class
