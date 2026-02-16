Imports System.Windows.Forms

Public Class FrmHlavne
    Inherits Form

    Friend WithEvents btnZamestnanci As Button
    Friend WithEvents btnOrganizacnaStruktura As Button

    Public Sub New()
        InitializeComponent()

        AddHandler btnOrganizacnaStruktura.Click, AddressOf OtvorOrganizacnuStrukturu
        AddHandler btnZamestnanci.Click, AddressOf OtvorZamestnancov
    End Sub

    Private Sub OtvorOrganizacnuStrukturu(sender As Object, e As EventArgs)
        Using frm As New FrmOrganizacnaStruktura()
            frm.ShowDialog(Me)
        End Using
    End Sub

    Private Sub OtvorZamestnancov(sender As Object, e As EventArgs)
        Using frm As New FrmZamestnanci()
            frm.ShowDialog(Me)
        End Using
    End Sub

    Private Sub InitializeComponent()
        Me.btnOrganizacnaStruktura = New System.Windows.Forms.Button()
        Me.btnZamestnanci = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnOrganizacnaStruktura
        '
        Me.btnOrganizacnaStruktura.Location = New System.Drawing.Point(183, 45)
        Me.btnOrganizacnaStruktura.Name = "btnOrganizacnaStruktura"
        Me.btnOrganizacnaStruktura.Size = New System.Drawing.Size(183, 93)
        Me.btnOrganizacnaStruktura.TabIndex = 0
        Me.btnOrganizacnaStruktura.Text = "Organizačná štruktúra"
        Me.btnOrganizacnaStruktura.UseVisualStyleBackColor = True
        '
        'btnZamestnanci
        '
        Me.btnZamestnanci.Location = New System.Drawing.Point(183, 162)
        Me.btnZamestnanci.Name = "btnZamestnanci"
        Me.btnZamestnanci.Size = New System.Drawing.Size(183, 90)
        Me.btnZamestnanci.TabIndex = 1
        Me.btnZamestnanci.Text = "Zamestnanci"
        Me.btnZamestnanci.UseVisualStyleBackColor = True
        '
        'FrmHlavne
        '
        Me.ClientSize = New System.Drawing.Size(550, 316)
        Me.Controls.Add(Me.btnZamestnanci)
        Me.Controls.Add(Me.btnOrganizacnaStruktura)
        Me.Name = "FrmHlavne"
        Me.Text = "Organizačná štruktúra firmy"
        Me.ResumeLayout(False)

    End Sub

End Class
