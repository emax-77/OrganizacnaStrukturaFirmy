<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmHlavne
    Inherits System.Windows.Forms.Form

    Friend WithEvents tabHlavne As System.Windows.Forms.TabControl
    Friend WithEvents tabZamestnanci As System.Windows.Forms.TabPage
    Friend WithEvents tabOrganizacnaStruktura As System.Windows.Forms.TabPage

    Private Sub InitializeComponent()
        Me.tabHlavne = New System.Windows.Forms.TabControl()
        Me.tabZamestnanci = New System.Windows.Forms.TabPage()
        Me.tabOrganizacnaStruktura = New System.Windows.Forms.TabPage()
        Me.tabHlavne.SuspendLayout()
        Me.SuspendLayout()
        '
        'tabHlavne
        '
        Me.tabHlavne.Controls.Add(Me.tabZamestnanci)
        Me.tabHlavne.Controls.Add(Me.tabOrganizacnaStruktura)
        Me.tabHlavne.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tabHlavne.Location = New System.Drawing.Point(0, 0)
        Me.tabHlavne.Name = "tabHlavne"
        Me.tabHlavne.SelectedIndex = 0
        Me.tabHlavne.Size = New System.Drawing.Size(550, 316)
        Me.tabHlavne.TabIndex = 0
        '
        'tabZamestnanci
        '
        Me.tabZamestnanci.Location = New System.Drawing.Point(4, 29)
        Me.tabZamestnanci.Name = "tabZamestnanci"
        Me.tabZamestnanci.Padding = New System.Windows.Forms.Padding(3)
        Me.tabZamestnanci.Size = New System.Drawing.Size(542, 283)
        Me.tabZamestnanci.TabIndex = 0
        Me.tabZamestnanci.Text = "Zamestnanci"
        Me.tabZamestnanci.UseVisualStyleBackColor = True
        '
        'tabOrganizacnaStruktura
        '
        Me.tabOrganizacnaStruktura.Location = New System.Drawing.Point(4, 29)
        Me.tabOrganizacnaStruktura.Name = "tabOrganizacnaStruktura"
        Me.tabOrganizacnaStruktura.Padding = New System.Windows.Forms.Padding(3)
        Me.tabOrganizacnaStruktura.Size = New System.Drawing.Size(542, 283)
        Me.tabOrganizacnaStruktura.TabIndex = 1
        Me.tabOrganizacnaStruktura.Text = "Organizačná štruktúra"
        Me.tabOrganizacnaStruktura.UseVisualStyleBackColor = True
        '
        'FrmHlavne
        '
        Me.ClientSize = New System.Drawing.Size(1000, 500)
        Me.MinimumSize = New System.Drawing.Size(800, 400)
        Me.Controls.Add(Me.tabHlavne)
        Me.Name = "FrmHlavne"
        Me.Text = "Organizačná štruktúra firmy"
        Me.tabHlavne.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
End Class
