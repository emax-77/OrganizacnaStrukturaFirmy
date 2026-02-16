Imports System.Windows.Forms

Public Class FrmOrganizacnaStruktura
    Inherits Form

    Friend WithEvents hlavnySplit As SplitContainer
    Friend WithEvents strom As TreeView
    Friend WithEvents TableLayoutPanel As TableLayoutPanel
    Friend WithEvents FlowLayoutPanel1 As FlowLayoutPanel
    Friend WithEvents btnUpravit As Button
    Friend WithEvents btnPridat As Button
    Friend WithEvents btnVymazat As Button
    Friend WithEvents FlowLayoutPanel2 As FlowLayoutPanel
    Friend WithEvents txtNazov As TextBox
    Friend WithEvents txtKod As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents txtVeduci As TextBox
    Private ReadOnly _logika As OrganizacnaStrukturaLogika
    Private ReadOnly _zamestnanecCrud As ZamestnanecCRUD

    Public Sub New()
        InitializeComponent()

        Dim pripojenie = SqlPripojenie.ZiskajPripojovaciRetazec()
        _logika = New OrganizacnaStrukturaLogika(New FirmaCRUD(pripojenie), New DiviziaCRUD(pripojenie), New ProjektCRUD(pripojenie), New OddelenieCRUD(pripojenie))
        _zamestnanecCrud = New ZamestnanecCRUD(pripojenie)

        AddHandler Load, AddressOf FrmOrganizacnaStruktura_Load
        AddHandler btnPridat.Click, AddressOf PridajUzol
        AddHandler btnUpravit.Click, AddressOf UpravUzol
        AddHandler btnVymazat.Click, AddressOf VymazUzol
        AddHandler strom.AfterSelect, AddressOf StromPoVybere
    End Sub

    Private Sub FrmOrganizacnaStruktura_Load(sender As Object, e As EventArgs)
        hlavnySplit.Panel1MinSize = 250
        hlavnySplit.Panel2MinSize = 300

        Dim dostupnaSirka = hlavnySplit.Width
        Dim preferovana = CInt(dostupnaSirka * 0.55)
        Dim minLeft = hlavnySplit.Panel1MinSize
        Dim maxLeft = dostupnaSirka - hlavnySplit.Panel2MinSize
        hlavnySplit.SplitterDistance = Math.Max(minLeft, Math.Min(preferovana, maxLeft))
        NacitajStrom()
    End Sub

    Private Sub NacitajStrom()
        strom.Nodes.Clear()

        Dim firma = _logika.ZiskajFirmu()
        If firma Is Nothing Then
            Return
        End If

        Dim root = New TreeNode($"{firma.Nazov} ({firma.Kod})") With {.Tag = firma}
        strom.Nodes.Add(root)

        Dim divizie = _logika.ZiskajDivizie(firma.Id)
        For Each divizia In divizie
            Dim divNode = New TreeNode($"{divizia.Nazov} ({divizia.Kod})") With {.Tag = divizia}
            root.Nodes.Add(divNode)

            Dim projekty = _logika.ZiskajProjekty(divizia.Id)
            For Each projekt In projekty
                Dim projNode = New TreeNode($"{projekt.Nazov} ({projekt.Kod})") With {.Tag = projekt}
                divNode.Nodes.Add(projNode)

                Dim oddelenia = _logika.ZiskajOddelenia(projekt.Id)
                For Each oddelenie In oddelenia
                    Dim oddNode = New TreeNode($"{oddelenie.Nazov} ({oddelenie.Kod})") With {.Tag = oddelenie}
                    projNode.Nodes.Add(oddNode)
                Next
            Next
        Next

        root.Expand()
    End Sub

    Private Sub StromPoVybere(sender As Object, e As TreeViewEventArgs)
        txtNazov.Text = String.Empty
        txtKod.Text = String.Empty
        txtVeduci.Text = String.Empty

        Dim tag = e.Node.Tag
        If TypeOf tag Is mFirma Then
            Dim firma = DirectCast(tag, mFirma)
            txtNazov.Text = firma.Nazov
            txtKod.Text = firma.Kod
            txtVeduci.Text = ZiskajMenoVeduceho(firma.RiaditelId)
        ElseIf TypeOf tag Is mDivizia Then
            Dim divizia = DirectCast(tag, mDivizia)
            txtNazov.Text = divizia.Nazov
            txtKod.Text = divizia.Kod
            txtVeduci.Text = ZiskajMenoVeduceho(divizia.VeduciDivizieId)
        ElseIf TypeOf tag Is mProjekt Then
            Dim projekt = DirectCast(tag, mProjekt)
            txtNazov.Text = projekt.Nazov
            txtKod.Text = projekt.Kod
            txtVeduci.Text = ZiskajMenoVeduceho(projekt.VeduciProjektuId)
        ElseIf TypeOf tag Is mOddelenie Then
            Dim oddelenie = DirectCast(tag, mOddelenie)
            txtNazov.Text = oddelenie.Nazov
            txtKod.Text = oddelenie.Kod
            txtVeduci.Text = ZiskajMenoVeduceho(oddelenie.VeduciOddeleniaId)
        End If
    End Sub

    Private Function ZiskajMenoVeduceho(veduciId As Integer?) As String
        If Not veduciId.HasValue Then
            Return "nezadané"
        End If

        Dim zamestnanec = _zamestnanecCrud.ZiskajZamestnancaPodlaId(veduciId.Value)
        If zamestnanec Is Nothing Then
            Return "nezadané"
        End If

        Dim titul = If(String.IsNullOrWhiteSpace(zamestnanec.Titul), String.Empty, zamestnanec.Titul & " ")
        Dim meno = (titul & zamestnanec.Meno & " " & zamestnanec.Priezvisko).Trim()
        Return If(String.IsNullOrWhiteSpace(meno), "nezadané", meno)
    End Function

    Private Sub PridajUzol(sender As Object, e As EventArgs)
        Dim vybrany = strom.SelectedNode

        If vybrany Is Nothing Then
            If strom.Nodes.Count > 0 Then
                MessageBox.Show(Me, "Najprv vyberte uzol.", "Upozornenie", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            End If

            Using frm As New FrmUpravaUzla()
                If frm.ShowDialog(Me) = DialogResult.OK Then
                    Dim firma = New mFirma With {.Nazov = frm.UzolNazov, .Kod = frm.UzolKod}
                    _logika.UlozFirmu(firma)
                    NacitajStrom()
                End If
            End Using
            Return
        End If

        Dim tag = vybrany.Tag
        If TypeOf tag Is mFirma Then
            Using frm As New FrmUpravaUzla()
                If frm.ShowDialog(Me) = DialogResult.OK Then
                    Dim divizia = New mDivizia With {
                        .FirmaId = DirectCast(tag, mFirma).Id,
                        .Nazov = frm.UzolNazov,
                        .Kod = frm.UzolKod
                    }
                    _logika.UlozDiviziu(divizia)
                    NacitajStrom()
                End If
            End Using
        ElseIf TypeOf tag Is mDivizia Then
            Using frm As New FrmUpravaUzla()
                If frm.ShowDialog(Me) = DialogResult.OK Then
                    Dim projekt = New mProjekt With {
                        .DiviziaId = DirectCast(tag, mDivizia).Id,
                        .Nazov = frm.UzolNazov,
                        .Kod = frm.UzolKod
                    }
                    _logika.UlozProjekt(projekt)
                    NacitajStrom()
                End If
            End Using
        ElseIf TypeOf tag Is mProjekt Then
            Using frm As New FrmUpravaUzla()
                If frm.ShowDialog(Me) = DialogResult.OK Then
                    Dim oddelenie = New mOddelenie With {
                        .ProjektId = DirectCast(tag, mProjekt).Id,
                        .Nazov = frm.UzolNazov,
                        .Kod = frm.UzolKod
                    }
                    _logika.UlozOddelenie(oddelenie)
                    NacitajStrom()
                End If
            End Using
        Else
            MessageBox.Show(Me, "Nie je možné pridať ďalšiu úroveň.", "Upozornenie", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub UpravUzol(sender As Object, e As EventArgs)
        Dim vybrany = strom.SelectedNode
        If vybrany Is Nothing Then
            MessageBox.Show(Me, "Najprv vyberte uzol.", "Upozornenie", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Dim tag = vybrany.Tag
        If TypeOf tag Is mFirma Then
            Dim firma = DirectCast(tag, mFirma)
            Using frm As New FrmUpravaUzla(firma.Nazov, firma.Kod)
                If frm.ShowDialog(Me) = DialogResult.OK Then
                    firma.Nazov = frm.UzolNazov
                    firma.Kod = frm.UzolKod
                    _logika.AktualizujFirmu(firma)
                    NacitajStrom()
                End If
            End Using
        ElseIf TypeOf tag Is mDivizia Then
            Dim divizia = DirectCast(tag, mDivizia)
            Using frm As New FrmUpravaUzla(divizia.Nazov, divizia.Kod)
                If frm.ShowDialog(Me) = DialogResult.OK Then
                    divizia.Nazov = frm.UzolNazov
                    divizia.Kod = frm.UzolKod
                    _logika.AktualizujDiviziu(divizia)
                    NacitajStrom()
                End If
            End Using
        ElseIf TypeOf tag Is mProjekt Then
            Dim projekt = DirectCast(tag, mProjekt)
            Using frm As New FrmUpravaUzla(projekt.Nazov, projekt.Kod)
                If frm.ShowDialog(Me) = DialogResult.OK Then
                    projekt.Nazov = frm.UzolNazov
                    projekt.Kod = frm.UzolKod
                    _logika.AktualizujProjekt(projekt)
                    NacitajStrom()
                End If
            End Using
        ElseIf TypeOf tag Is mOddelenie Then
            Dim oddelenie = DirectCast(tag, mOddelenie)
            Using frm As New FrmUpravaUzla(oddelenie.Nazov, oddelenie.Kod)
                If frm.ShowDialog(Me) = DialogResult.OK Then
                    oddelenie.Nazov = frm.UzolNazov
                    oddelenie.Kod = frm.UzolKod
                    _logika.AktualizujOddelenie(oddelenie)
                    NacitajStrom()
                End If
            End Using
        End If
    End Sub

    Private Sub VymazUzol(sender As Object, e As EventArgs)
        Dim vybrany = strom.SelectedNode
        If vybrany Is Nothing Then
            MessageBox.Show(Me, "Najprv vyberte uzol.", "Upozornenie", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Dim potvrdenie = MessageBox.Show(Me, "Naozaj chcete vymazať vybraný uzol?", "Potvrdenie", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If potvrdenie <> DialogResult.Yes Then
            Return
        End If

        Try
            Dim tag = vybrany.Tag
            If TypeOf tag Is mFirma Then
                _logika.VymazFirmu(DirectCast(tag, mFirma).Id)
            ElseIf TypeOf tag Is mDivizia Then
                _logika.VymazDiviziu(DirectCast(tag, mDivizia).Id)
            ElseIf TypeOf tag Is mProjekt Then
                _logika.VymazProjekt(DirectCast(tag, mProjekt).Id)
            ElseIf TypeOf tag Is mOddelenie Then
                _logika.VymazOddelenie(DirectCast(tag, mOddelenie).Id)
            End If

            NacitajStrom()
        Catch ex As Exception
            MessageBox.Show(Me, "Uzol sa nepodarilo vymazať. Skontroluj, či neobsahuje podriadené záznamy.", "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub InitializeComponent()
        Me.hlavnySplit = New System.Windows.Forms.SplitContainer()
        Me.strom = New System.Windows.Forms.TreeView()
        Me.TableLayoutPanel = New System.Windows.Forms.TableLayoutPanel()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.FlowLayoutPanel2 = New System.Windows.Forms.FlowLayoutPanel()
        Me.btnUpravit = New System.Windows.Forms.Button()
        Me.btnPridat = New System.Windows.Forms.Button()
        Me.btnVymazat = New System.Windows.Forms.Button()
        Me.txtNazov = New System.Windows.Forms.TextBox()
        Me.txtKod = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtVeduci = New System.Windows.Forms.TextBox()
        CType(Me.hlavnySplit, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.hlavnySplit.Panel1.SuspendLayout()
        Me.hlavnySplit.Panel2.SuspendLayout()
        Me.hlavnySplit.SuspendLayout()
        Me.TableLayoutPanel.SuspendLayout()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.FlowLayoutPanel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'hlavnySplit
        '
        Me.hlavnySplit.Dock = System.Windows.Forms.DockStyle.Fill
        Me.hlavnySplit.Location = New System.Drawing.Point(0, 0)
        Me.hlavnySplit.Name = "hlavnySplit"
        '
        'hlavnySplit.Panel1
        '
        Me.hlavnySplit.Panel1.Controls.Add(Me.strom)
        '
        'hlavnySplit.Panel2
        '
        Me.hlavnySplit.Panel2.Controls.Add(Me.TableLayoutPanel)
        Me.hlavnySplit.Size = New System.Drawing.Size(909, 380)
        Me.hlavnySplit.SplitterDistance = 303
        Me.hlavnySplit.TabIndex = 0
        '
        'strom
        '
        Me.strom.Dock = System.Windows.Forms.DockStyle.Fill
        Me.strom.Location = New System.Drawing.Point(0, 0)
        Me.strom.Name = "strom"
        Me.strom.Size = New System.Drawing.Size(303, 380)
        Me.strom.TabIndex = 0
        '
        'TableLayoutPanel
        '
        Me.TableLayoutPanel.ColumnCount = 1
        Me.TableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel.Controls.Add(Me.FlowLayoutPanel1, 0, 0)
        Me.TableLayoutPanel.Controls.Add(Me.FlowLayoutPanel2, 0, 1)
        Me.TableLayoutPanel.Location = New System.Drawing.Point(20, 21)
        Me.TableLayoutPanel.Name = "TableLayoutPanel"
        Me.TableLayoutPanel.RowCount = 2
        Me.TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel.Size = New System.Drawing.Size(552, 347)
        Me.TableLayoutPanel.TabIndex = 0
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.Controls.Add(Me.btnPridat)
        Me.FlowLayoutPanel1.Controls.Add(Me.btnUpravit)
        Me.FlowLayoutPanel1.Controls.Add(Me.btnVymazat)
        Me.FlowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(3, 3)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(546, 34)
        Me.FlowLayoutPanel1.TabIndex = 0
        '
        'FlowLayoutPanel2
        '
        Me.FlowLayoutPanel2.Controls.Add(Me.Label1)
        Me.FlowLayoutPanel2.Controls.Add(Me.txtNazov)
        Me.FlowLayoutPanel2.Controls.Add(Me.Label2)
        Me.FlowLayoutPanel2.Controls.Add(Me.txtKod)
        Me.FlowLayoutPanel2.Controls.Add(Me.Label3)
        Me.FlowLayoutPanel2.Controls.Add(Me.txtVeduci)
        Me.FlowLayoutPanel2.Location = New System.Drawing.Point(3, 43)
        Me.FlowLayoutPanel2.Name = "FlowLayoutPanel2"
        Me.FlowLayoutPanel2.Size = New System.Drawing.Size(194, 130)
        Me.FlowLayoutPanel2.TabIndex = 1
        '
        'btnUpravit
        '
        Me.btnUpravit.Location = New System.Drawing.Point(84, 3)
        Me.btnUpravit.Name = "btnUpravit"
        Me.btnUpravit.Size = New System.Drawing.Size(75, 23)
        Me.btnUpravit.TabIndex = 0
        Me.btnUpravit.Text = "Upraviť"
        Me.btnUpravit.UseVisualStyleBackColor = True
        '
        'btnPridat
        '
        Me.btnPridat.Location = New System.Drawing.Point(3, 3)
        Me.btnPridat.Name = "btnPridat"
        Me.btnPridat.Size = New System.Drawing.Size(75, 23)
        Me.btnPridat.TabIndex = 1
        Me.btnPridat.Text = "Pridať"
        Me.btnPridat.UseVisualStyleBackColor = True
        '
        'btnVymazat
        '
        Me.btnVymazat.Location = New System.Drawing.Point(165, 3)
        Me.btnVymazat.Name = "btnVymazat"
        Me.btnVymazat.Size = New System.Drawing.Size(75, 23)
        Me.btnVymazat.TabIndex = 2
        Me.btnVymazat.Text = "Vymazať"
        Me.btnVymazat.UseVisualStyleBackColor = True
        '
        'txtNazov
        '
        Me.txtNazov.Location = New System.Drawing.Point(55, 3)
        Me.txtNazov.Name = "txtNazov"
        Me.txtNazov.ReadOnly = True
        Me.txtNazov.Size = New System.Drawing.Size(124, 22)
        Me.txtNazov.TabIndex = 1
        '
        'txtKod
        '
        Me.txtKod.Enabled = False
        Me.txtKod.Location = New System.Drawing.Point(40, 31)
        Me.txtKod.Name = "txtKod"
        Me.txtKod.ReadOnly = True
        Me.txtKod.Size = New System.Drawing.Size(139, 22)
        Me.txtKod.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(3, 6)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(46, 16)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Názov"
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(3, 34)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(31, 16)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Kód"
        '
        'Label3
        '
        Me.Label3.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(3, 62)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(49, 16)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Vedúci"
        '
        'txtVeduci
        '
        Me.txtVeduci.Enabled = False
        Me.txtVeduci.Location = New System.Drawing.Point(58, 59)
        Me.txtVeduci.Name = "txtVeduci"
        Me.txtVeduci.Size = New System.Drawing.Size(100, 22)
        Me.txtVeduci.TabIndex = 5
        '
        'FrmOrganizacnaStruktura
        '
        Me.ClientSize = New System.Drawing.Size(909, 380)
        Me.Controls.Add(Me.hlavnySplit)
        Me.Name = "FrmOrganizacnaStruktura"
        Me.Text = "Organizačná štruktúra"
        Me.hlavnySplit.Panel1.ResumeLayout(False)
        Me.hlavnySplit.Panel2.ResumeLayout(False)
        CType(Me.hlavnySplit, System.ComponentModel.ISupportInitialize).EndInit()
        Me.hlavnySplit.ResumeLayout(False)
        Me.TableLayoutPanel.ResumeLayout(False)
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.FlowLayoutPanel2.ResumeLayout(False)
        Me.FlowLayoutPanel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

End Class
