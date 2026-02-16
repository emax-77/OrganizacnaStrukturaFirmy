<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmUpravaZamestnanca
    Inherits System.Windows.Forms.Form

    Friend WithEvents txtTitul As System.Windows.Forms.TextBox
    Friend WithEvents txtMeno As System.Windows.Forms.TextBox
    Friend WithEvents txtPriezvisko As System.Windows.Forms.TextBox
    Friend WithEvents txtTelefon As System.Windows.Forms.TextBox
    Friend WithEvents txtEmail As System.Windows.Forms.TextBox
    Friend WithEvents cmbZaradenie As System.Windows.Forms.ComboBox
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents btnZrusit As System.Windows.Forms.Button
    Friend WithEvents lblTitul As System.Windows.Forms.Label
    Friend WithEvents lblMeno As System.Windows.Forms.Label
    Friend WithEvents lblPriezvisko As System.Windows.Forms.Label
    Friend WithEvents lblTelefon As System.Windows.Forms.Label
    Friend WithEvents lblEmail As System.Windows.Forms.Label
    Friend WithEvents lblZariadenie As System.Windows.Forms.Label
    Friend WithEvents cmbUzol As System.Windows.Forms.ComboBox
    Friend WithEvents lblUzol As System.Windows.Forms.Label

    Private Sub InitializeComponent()
        Me.txtTitul = New System.Windows.Forms.TextBox()
        Me.txtMeno = New System.Windows.Forms.TextBox()
        Me.txtPriezvisko = New System.Windows.Forms.TextBox()
        Me.txtTelefon = New System.Windows.Forms.TextBox()
        Me.txtEmail = New System.Windows.Forms.TextBox()
        Me.cmbZaradenie = New System.Windows.Forms.ComboBox()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.btnZrusit = New System.Windows.Forms.Button()
        Me.lblTitul = New System.Windows.Forms.Label()
        Me.lblMeno = New System.Windows.Forms.Label()
        Me.lblPriezvisko = New System.Windows.Forms.Label()
        Me.lblTelefon = New System.Windows.Forms.Label()
        Me.lblEmail = New System.Windows.Forms.Label()
        Me.lblZariadenie = New System.Windows.Forms.Label()
        Me.cmbUzol = New System.Windows.Forms.ComboBox()
        Me.lblUzol = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'txtTitul
        '
        Me.txtTitul.Location = New System.Drawing.Point(152, 13)
        Me.txtTitul.Name = "txtTitul"
        Me.txtTitul.Size = New System.Drawing.Size(100, 22)
        Me.txtTitul.TabIndex = 0
        '
        'txtMeno
        '
        Me.txtMeno.Location = New System.Drawing.Point(152, 54)
        Me.txtMeno.Name = "txtMeno"
        Me.txtMeno.Size = New System.Drawing.Size(187, 22)
        Me.txtMeno.TabIndex = 1
        '
        'txtPriezvisko
        '
        Me.txtPriezvisko.Location = New System.Drawing.Point(152, 100)
        Me.txtPriezvisko.Name = "txtPriezvisko"
        Me.txtPriezvisko.Size = New System.Drawing.Size(187, 22)
        Me.txtPriezvisko.TabIndex = 2
        '
        'txtTelefon
        '
        Me.txtTelefon.Location = New System.Drawing.Point(152, 140)
        Me.txtTelefon.Name = "txtTelefon"
        Me.txtTelefon.Size = New System.Drawing.Size(187, 22)
        Me.txtTelefon.TabIndex = 3
        '
        'txtEmail
        '
        Me.txtEmail.Location = New System.Drawing.Point(152, 189)
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.Size = New System.Drawing.Size(187, 22)
        Me.txtEmail.TabIndex = 4
        '
        'cmbZaradenie
        '
        Me.cmbZaradenie.FormattingEnabled = True
        Me.cmbZaradenie.Location = New System.Drawing.Point(152, 234)
        Me.cmbZaradenie.Name = "cmbZaradenie"
        Me.cmbZaradenie.Size = New System.Drawing.Size(187, 24)
        Me.cmbZaradenie.TabIndex = 5
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(152, 320)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(121, 43)
        Me.btnOK.TabIndex = 6
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'btnZrusit
        '
        Me.btnZrusit.Location = New System.Drawing.Point(306, 320)
        Me.btnZrusit.Name = "btnZrusit"
        Me.btnZrusit.Size = New System.Drawing.Size(103, 43)
        Me.btnZrusit.TabIndex = 7
        Me.btnZrusit.Text = "Zrušiť"
        Me.btnZrusit.UseVisualStyleBackColor = True
        '
        'lblTitul
        '
        Me.lblTitul.AutoSize = True
        Me.lblTitul.Location = New System.Drawing.Point(63, 18)
        Me.lblTitul.Name = "lblTitul"
        Me.lblTitul.Size = New System.Drawing.Size(32, 16)
        Me.lblTitul.TabIndex = 8
        Me.lblTitul.Text = "Titul"
        '
        'lblMeno
        '
        Me.lblMeno.AutoSize = True
        Me.lblMeno.Location = New System.Drawing.Point(66, 59)
        Me.lblMeno.Name = "lblMeno"
        Me.lblMeno.Size = New System.Drawing.Size(41, 16)
        Me.lblMeno.TabIndex = 9
        Me.lblMeno.Text = "Meno"
        '
        'lblPriezvisko
        '
        Me.lblPriezvisko.AutoSize = True
        Me.lblPriezvisko.Location = New System.Drawing.Point(66, 105)
        Me.lblPriezvisko.Name = "lblPriezvisko"
        Me.lblPriezvisko.Size = New System.Drawing.Size(69, 16)
        Me.lblPriezvisko.TabIndex = 10
        Me.lblPriezvisko.Text = "Priezvisko"
        '
        'lblTelefon
        '
        Me.lblTelefon.AutoSize = True
        Me.lblTelefon.Location = New System.Drawing.Point(66, 145)
        Me.lblTelefon.Name = "lblTelefon"
        Me.lblTelefon.Size = New System.Drawing.Size(53, 16)
        Me.lblTelefon.TabIndex = 11
        Me.lblTelefon.Text = "Telefón"
        '
        'lblEmail
        '
        Me.lblEmail.AutoSize = True
        Me.lblEmail.Location = New System.Drawing.Point(66, 194)
        Me.lblEmail.Name = "lblEmail"
        Me.lblEmail.Size = New System.Drawing.Size(41, 16)
        Me.lblEmail.TabIndex = 12
        Me.lblEmail.Text = "Email"
        '
        'lblZariadenie
        '
        Me.lblZariadenie.AutoSize = True
        Me.lblZariadenie.Location = New System.Drawing.Point(66, 242)
        Me.lblZariadenie.Name = "lblZariadenie"
        Me.lblZariadenie.Size = New System.Drawing.Size(69, 16)
        Me.lblZariadenie.TabIndex = 13
        Me.lblZariadenie.Text = "Zaradenie"
        '
        'cmbUzol
        '
        Me.cmbUzol.FormattingEnabled = True
        Me.cmbUzol.Location = New System.Drawing.Point(152, 275)
        Me.cmbUzol.Name = "cmbUzol"
        Me.cmbUzol.Size = New System.Drawing.Size(187, 24)
        Me.cmbUzol.TabIndex = 14
        '
        'lblUzol
        '
        Me.lblUzol.AutoSize = True
        Me.lblUzol.Location = New System.Drawing.Point(66, 283)
        Me.lblUzol.Name = "lblUzol"
        Me.lblUzol.Size = New System.Drawing.Size(34, 16)
        Me.lblUzol.TabIndex = 15
        Me.lblUzol.Text = "Uzol"
        '
        'FrmUpravaZamestnanca
        '
        Me.ClientSize = New System.Drawing.Size(814, 386)
        Me.Controls.Add(Me.lblUzol)
        Me.Controls.Add(Me.cmbUzol)
        Me.Controls.Add(Me.lblZariadenie)
        Me.Controls.Add(Me.lblEmail)
        Me.Controls.Add(Me.lblTelefon)
        Me.Controls.Add(Me.lblPriezvisko)
        Me.Controls.Add(Me.lblMeno)
        Me.Controls.Add(Me.lblTitul)
        Me.Controls.Add(Me.btnZrusit)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.cmbZaradenie)
        Me.Controls.Add(Me.txtEmail)
        Me.Controls.Add(Me.txtTelefon)
        Me.Controls.Add(Me.txtPriezvisko)
        Me.Controls.Add(Me.txtMeno)
        Me.Controls.Add(Me.txtTitul)
        Me.Name = "FrmUpravaZamestnanca"
        Me.Text = "Úprava zamestnanca"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
End Class
