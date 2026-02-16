<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmOrganizacnaStruktura
    Inherits System.Windows.Forms.Form

    Friend WithEvents hlavnySplit As System.Windows.Forms.SplitContainer
    Friend WithEvents strom As System.Windows.Forms.TreeView
    Friend WithEvents TableLayoutPanel As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents FlowLayoutPanel1 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents btnUpravit As System.Windows.Forms.Button
    Friend WithEvents btnPridat As System.Windows.Forms.Button
    Friend WithEvents btnVymazat As System.Windows.Forms.Button
    Friend WithEvents FlowLayoutPanel2 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents txtNazov As System.Windows.Forms.TextBox
    Friend WithEvents txtKod As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtVeduci As System.Windows.Forms.TextBox

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
