Imports System.Text.RegularExpressions
Imports System.Windows.Forms

Partial Public Class FrmUpravaZamestnanca
    Inherits Form
    Private ReadOnly _zamestnanecId As Integer?
    Private ReadOnly _logika As ZamestnanecLogika

    Public Property Zamestnanec As mZamestnanec

    Public Sub New(zaradenia As List(Of mUzolStromu), uzly As List(Of mUzolStromu), logika As ZamestnanecLogika, Optional zamestnanec As mZamestnanec = Nothing)
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
    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        If String.IsNullOrWhiteSpace(txtMeno.Text) OrElse String.IsNullOrWhiteSpace(txtPriezvisko.Text) Then
            MessageBox.Show(Me, "Meno a priezvisko sú povinné.", "Upozornenie", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        If Not String.IsNullOrWhiteSpace(txtEmail.Text) AndAlso Not Regex.IsMatch(txtEmail.Text.Trim(), "^[^@\s]+@[^@\s]+\.[^@\s]+$") Then
            MessageBox.Show(Me, "Neplatný formát e-mailovej adresy.", "Upozornenie", MessageBoxButtons.OK, MessageBoxIcon.Information)
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

        Dim vybraneZaradenie = DirectCast(cmbZaradenie.SelectedItem, mUzolStromu)
        Dim vybranyUzol = DirectCast(cmbUzol.SelectedItem, mUzolStromu)

        If vybraneZaradenie.Typ.HasValue Then
            Dim obsadene = _logika.ExistujeVeduci(vybraneZaradenie.Popis, vybraneZaradenie.Id, _zamestnanecId)
            If obsadene Then
                MessageBox.Show(Me, "Pre toto zaradenie už existuje vedúci.", "Upozornenie", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            End If
        End If

        Zamestnanec = New mZamestnanec With {
            .Id = If(_zamestnanecId.HasValue, _zamestnanecId.Value, 0),
            .Titul = txtTitul.Text.Trim(),
            .Meno = txtMeno.Text.Trim(),
            .Priezvisko = txtPriezvisko.Text.Trim(),
            .Telefon = txtTelefon.Text.Trim(),
            .Email = txtEmail.Text.Trim(),
            .ZaradenieId = vybraneZaradenie.Id,
            .Zaradenie = vybraneZaradenie.Popis,
            .ZaradenieTyp = vybraneZaradenie.Typ,
            .UzolId = vybranyUzol.Id,
            .UzolTyp = vybranyUzol.Typ.Value
        }

        DialogResult = DialogResult.OK
        Close()
    End Sub

    Private Sub btnZrusit_Click(sender As Object, e As EventArgs) Handles btnZrusit.Click
        DialogResult = DialogResult.Cancel
        Close()
    End Sub

End Class
