Imports System.Windows.Forms

Public Class FrmUpravaUzla
    Inherits Form

    Friend WithEvents btnOK As Button
    Friend WithEvents btnZrusit As Button
    Friend WithEvents txtNazov As TextBox
    Friend WithEvents lblNazov As Label
    Friend WithEvents lblKod As Label
    Friend WithEvents txtKod As TextBox
    Public Property UzolNazov As String
    Public Property UzolKod As String

    Public Sub New(Optional nazov As String = Nothing, Optional kod As String = Nothing)
        InitializeComponent()

        txtNazov.Text = nazov
        txtKod.Text = kod

        AddHandler btnOK.Click, AddressOf Potvrd
        AddHandler btnZrusit.Click, AddressOf Zrus
    End Sub

    Private Sub Potvrd(sender As Object, e As EventArgs)
        If String.IsNullOrWhiteSpace(txtNazov.Text) OrElse String.IsNullOrWhiteSpace(txtKod.Text) Then
            MessageBox.Show(Me, "Názov a kód sú povinné.", "Upozornenie", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        UzolNazov = txtNazov.Text
        UzolKod = txtKod.Text
        DialogResult = DialogResult.OK
        Close()
    End Sub

    Private Sub Zrus(sender As Object, e As EventArgs)
        DialogResult = DialogResult.Cancel
        Close()
    End Sub

    Private Sub InitializeComponent()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.btnZrusit = New System.Windows.Forms.Button()
        Me.txtNazov = New System.Windows.Forms.TextBox()
        Me.txtKod = New System.Windows.Forms.TextBox()
        Me.lblNazov = New System.Windows.Forms.Label()
        Me.lblKod = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(122, 94)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(118, 43)
        Me.btnOK.TabIndex = 0
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'btnZrusit
        '
        Me.btnZrusit.Location = New System.Drawing.Point(282, 94)
        Me.btnZrusit.Name = "btnZrusit"
        Me.btnZrusit.Size = New System.Drawing.Size(101, 43)
        Me.btnZrusit.TabIndex = 1
        Me.btnZrusit.Text = "Zrušiť"
        Me.btnZrusit.UseVisualStyleBackColor = True
        '
        'txtNazov
        '
        Me.txtNazov.Location = New System.Drawing.Point(88, 38)
        Me.txtNazov.Name = "txtNazov"
        Me.txtNazov.Size = New System.Drawing.Size(152, 22)
        Me.txtNazov.TabIndex = 2
        '
        'txtKod
        '
        Me.txtKod.Location = New System.Drawing.Point(316, 40)
        Me.txtKod.Name = "txtKod"
        Me.txtKod.Size = New System.Drawing.Size(152, 22)
        Me.txtKod.TabIndex = 3
        '
        'lblNazov
        '
        Me.lblNazov.AutoSize = True
        Me.lblNazov.Location = New System.Drawing.Point(32, 43)
        Me.lblNazov.Name = "lblNazov"
        Me.lblNazov.Size = New System.Drawing.Size(46, 16)
        Me.lblNazov.TabIndex = 4
        Me.lblNazov.Text = "Názov"
        '
        'lblKod
        '
        Me.lblKod.AutoSize = True
        Me.lblKod.Location = New System.Drawing.Point(279, 44)
        Me.lblKod.Name = "lblKod"
        Me.lblKod.Size = New System.Drawing.Size(31, 16)
        Me.lblKod.TabIndex = 5
        Me.lblKod.Text = "Kód"
        '
        'FrmUpravaUzla
        '
        Me.ClientSize = New System.Drawing.Size(520, 180)
        Me.Controls.Add(Me.lblKod)
        Me.Controls.Add(Me.lblNazov)
        Me.Controls.Add(Me.txtKod)
        Me.Controls.Add(Me.txtNazov)
        Me.Controls.Add(Me.btnZrusit)
        Me.Controls.Add(Me.btnOK)
        Me.Name = "FrmUpravaUzla"
        Me.Text = "Úprava uzla"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub


End Class
