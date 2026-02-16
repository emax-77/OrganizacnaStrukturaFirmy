Imports System.Windows.Forms

Partial Public Class FrmUpravaZamestnanca
    Inherits Form
    Private ReadOnly _zamestnanecId As Integer?
    Private ReadOnly _logika As ZamestnanecLogika

    Public Property Zamestnanec As mZamestnanec

    Public Sub New(zaradenia As List(Of UzolStromu), uzly As List(Of UzolStromu), logika As ZamestnanecLogika, Optional zamestnanec As mZamestnanec = Nothing)
        InitializeComponent()

        _logika = logika

        cmbZaradenie.DataSource = zaradenia
        cmbZaradenie.DisplayMember = "Popis"
        cmbZaradenie.ValueMember = "Id"

        cmbUzol.DataSource = uzly
        cmbUzol.DisplayMember = "Popis"
        cmbUzol.ValueMember = "Id"

        If zamestnanec IsNot Nothing Then
            _zamestnanecId = zamestnanec.Id
            txtTitul.Text = zamestnanec.Titul
            txtMeno.Text = zamestnanec.Meno
            txtPriezvisko.Text = zamestnanec.Priezvisko
            txtTelefon.Text = zamestnanec.Telefon
            txtEmail.Text = zamestnanec.Email
            For Each zaradenie In zaradenia
                If zaradenie.Id = zamestnanec.ZaradenieId AndAlso zaradenie.Popis = zamestnanec.Zaradenie Then
                    cmbZaradenie.SelectedItem = zaradenie
                    Exit For
                End If
            Next

            For Each uzol In uzly
                If uzol.Id = zamestnanec.UzolId AndAlso uzol.Typ = zamestnanec.UzolTyp Then
                    cmbUzol.SelectedItem = uzol
                    Exit For
                End If
            Next
        End If

        AddHandler btnOK.Click, AddressOf Potvrd
        AddHandler btnZrusit.Click, AddressOf Zrus
    End Sub

    Private Sub Potvrd(sender As Object, e As EventArgs)
        If String.IsNullOrWhiteSpace(txtMeno.Text) OrElse String.IsNullOrWhiteSpace(txtPriezvisko.Text) Then
            MessageBox.Show(Me, "Meno a priezvisko sú povinné.", "Upozornenie", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        If cmbZaradenie.SelectedItem Is Nothing Then
            MessageBox.Show(Me, "Vyber zaradenie.", "Upozornenie", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        If cmbUzol.SelectedItem Is Nothing Then
            MessageBox.Show(Me, "Vyber uzol.", "Upozornenie", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Dim vybraneZaradenie = DirectCast(cmbZaradenie.SelectedItem, UzolStromu)
        Dim vybranyUzol = DirectCast(cmbUzol.SelectedItem, UzolStromu)

        If Not String.Equals(vybraneZaradenie.Popis, "Zamestnanec", StringComparison.OrdinalIgnoreCase) Then
            Dim obsadene = _logika.ExistujeVeduci(vybraneZaradenie.Popis, vybraneZaradenie.Id, _zamestnanecId)
            If obsadene Then
                MessageBox.Show(Me, "Pre toto zaradenie už existuje vedúci.", "Upozornenie", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            End If
        End If

        Zamestnanec = New mZamestnanec With {
            .Id = If(_zamestnanecId.HasValue, _zamestnanecId.Value, 0),
            .Titul = txtTitul.Text,
            .Meno = txtMeno.Text,
            .Priezvisko = txtPriezvisko.Text,
            .Telefon = txtTelefon.Text,
            .Email = txtEmail.Text,
            .ZaradenieId = vybraneZaradenie.Id,
            .Zaradenie = vybraneZaradenie.Popis,
            .UzolId = vybranyUzol.Id,
            .UzolTyp = vybranyUzol.Typ
        }

        DialogResult = DialogResult.OK
        Close()
    End Sub

    Private Sub Zrus(sender As Object, e As EventArgs)
        DialogResult = DialogResult.Cancel
        Close()
    End Sub


End Class
