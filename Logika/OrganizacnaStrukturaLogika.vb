Public Class OrganizacnaStrukturaLogika
    Private ReadOnly _firmaCrud As FirmaCRUD
    Private ReadOnly _diviziaCrud As DiviziaCRUD
    Private ReadOnly _projektCrud As ProjektCRUD
    Private ReadOnly _oddelenieCrud As OddelenieCRUD

    Public Sub New(firmaCrud As FirmaCRUD, diviziaCrud As DiviziaCRUD, projektCrud As ProjektCRUD, oddelenieCrud As OddelenieCRUD)
        _firmaCrud = firmaCrud
        _diviziaCrud = diviziaCrud
        _projektCrud = projektCrud
        _oddelenieCrud = oddelenieCrud
    End Sub
End Class
