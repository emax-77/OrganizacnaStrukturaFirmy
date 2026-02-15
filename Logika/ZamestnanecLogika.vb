Public Class ZamestnanecLogika
    Private ReadOnly _zamestnanecCrud As ZamestnanecCRUD

    Public Sub New(zamestnanecCrud As ZamestnanecCRUD)
        _zamestnanecCrud = zamestnanecCrud
    End Sub
End Class
