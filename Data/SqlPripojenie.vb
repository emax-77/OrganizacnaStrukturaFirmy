Imports System.Configuration

Public Module SqlPripojenie
    Public Function ZiskajPripojovaciRetazec() As String
        Return ConfigurationManager.ConnectionStrings("OrganizacnaStruktura").ConnectionString
    End Function
End Module
