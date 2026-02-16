<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmZamestnanci
    Inherits System.Windows.Forms.Form

    Friend WithEvents gridZamestnanci As System.Windows.Forms.DataGridView
    Friend WithEvents btnPridat As System.Windows.Forms.Button
    Friend WithEvents btnUpravit As System.Windows.Forms.Button
    Friend WithEvents btnVymazat As System.Windows.Forms.Button
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents FlowLayoutPanel1 As System.Windows.Forms.FlowLayoutPanel

    Private Sub InitializeComponent()
        Me.gridZamestnanci = New System.Windows.Forms.DataGridView()
        Me.btnPridat = New System.Windows.Forms.Button()
        Me.btnUpravit = New System.Windows.Forms.Button()
        Me.btnVymazat = New System.Windows.Forms.Button()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        CType(Me.gridZamestnanci, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'gridZamestnanci
        '
        Me.gridZamestnanci.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gridZamestnanci.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gridZamestnanci.Location = New System.Drawing.Point(3, 43)
        Me.gridZamestnanci.Name = "gridZamestnanci"
        Me.gridZamestnanci.RowHeadersWidth = 51
        Me.gridZamestnanci.RowTemplate.Height = 24
        Me.gridZamestnanci.Size = New System.Drawing.Size(954, 358)
        Me.gridZamestnanci.TabIndex = 0
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
        'btnUpravit
        '
        Me.btnUpravit.Location = New System.Drawing.Point(84, 3)
        Me.btnUpravit.Name = "btnUpravit"
        Me.btnUpravit.Size = New System.Drawing.Size(75, 23)
        Me.btnUpravit.TabIndex = 2
        Me.btnUpravit.Text = "Upraviť"
        Me.btnUpravit.UseVisualStyleBackColor = True
        '
        'btnVymazat
        '
        Me.btnVymazat.Location = New System.Drawing.Point(165, 3)
        Me.btnVymazat.Name = "btnVymazat"
        Me.btnVymazat.Size = New System.Drawing.Size(75, 23)
        Me.btnVymazat.TabIndex = 3
        Me.btnVymazat.Text = "Vymazať"
        Me.btnVymazat.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.FlowLayoutPanel1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.gridZamestnanci, 0, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(960, 404)
        Me.TableLayoutPanel1.TabIndex = 4
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.Controls.Add(Me.btnPridat)
        Me.FlowLayoutPanel1.Controls.Add(Me.btnUpravit)
        Me.FlowLayoutPanel1.Controls.Add(Me.btnVymazat)
        Me.FlowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(3, 3)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(954, 34)
        Me.FlowLayoutPanel1.TabIndex = 0
        '
        'FrmZamestnanci
        '
        Me.AccessibleName = ""
        Me.ClientSize = New System.Drawing.Size(960, 404)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "FrmZamestnanci"
        Me.Text = "Zamestnanci"
        CType(Me.gridZamestnanci, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
End Class
