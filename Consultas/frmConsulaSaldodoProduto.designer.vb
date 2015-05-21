<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmConsultaSaldodoProduto
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmConsultaSaldodoProduto))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.cbarmazem = New System.Windows.Forms.ComboBox()
        Me.btnsair = New System.Windows.Forms.Button()
        Me.lblPesquisa = New System.Windows.Forms.Label()
        Me.btnPesquisa = New System.Windows.Forms.Button()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.tssContReg = New System.Windows.Forms.ToolStripStatusLabel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.dgvProdutos = New System.Windows.Forms.DataGridView()
        Me.Panel1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.dgvProdutos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.cbarmazem)
        Me.Panel1.Controls.Add(Me.btnsair)
        Me.Panel1.Controls.Add(Me.lblPesquisa)
        Me.Panel1.Controls.Add(Me.btnPesquisa)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(730, 52)
        Me.Panel1.TabIndex = 43
        '
        'cbarmazem
        '
        Me.cbarmazem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbarmazem.FormattingEnabled = True
        Me.cbarmazem.Location = New System.Drawing.Point(3, 25)
        Me.cbarmazem.Name = "cbarmazem"
        Me.cbarmazem.Size = New System.Drawing.Size(449, 21)
        Me.cbarmazem.TabIndex = 57
        '
        'btnsair
        '
        Me.btnsair.BackgroundImage = CType(resources.GetObject("btnsair.BackgroundImage"), System.Drawing.Image)
        Me.btnsair.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnsair.Location = New System.Drawing.Point(492, 27)
        Me.btnsair.Name = "btnsair"
        Me.btnsair.Size = New System.Drawing.Size(28, 20)
        Me.btnsair.TabIndex = 56
        Me.btnsair.UseVisualStyleBackColor = True
        '
        'lblPesquisa
        '
        Me.lblPesquisa.AutoSize = True
        Me.lblPesquisa.Location = New System.Drawing.Point(11, 9)
        Me.lblPesquisa.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblPesquisa.Name = "lblPesquisa"
        Me.lblPesquisa.Size = New System.Drawing.Size(302, 13)
        Me.lblPesquisa.TabIndex = 52
        Me.lblPesquisa.Text = "Selecione o armazém que deseja pesquisar o saldo do produto"
        '
        'btnPesquisa
        '
        Me.btnPesquisa.BackgroundImage = CType(resources.GetObject("btnPesquisa.BackgroundImage"), System.Drawing.Image)
        Me.btnPesquisa.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnPesquisa.Location = New System.Drawing.Point(458, 27)
        Me.btnPesquisa.Name = "btnPesquisa"
        Me.btnPesquisa.Size = New System.Drawing.Size(28, 20)
        Me.btnPesquisa.TabIndex = 54
        Me.btnPesquisa.UseVisualStyleBackColor = True
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tssContReg})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 438)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(730, 22)
        Me.StatusStrip1.TabIndex = 44
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'tssContReg
        '
        Me.tssContReg.Name = "tssContReg"
        Me.tssContReg.Size = New System.Drawing.Size(78, 17)
        Me.tssContReg.Text = "Registro n / n"
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.dgvProdutos)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 52)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(730, 386)
        Me.Panel2.TabIndex = 45
        '
        'dgvProdutos
        '
        Me.dgvProdutos.AllowUserToAddRows = False
        Me.dgvProdutos.AllowUserToDeleteRows = False
        Me.dgvProdutos.AllowUserToOrderColumns = True
        Me.dgvProdutos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvProdutos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvProdutos.Location = New System.Drawing.Point(0, 0)
        Me.dgvProdutos.Name = "dgvProdutos"
        Me.dgvProdutos.Size = New System.Drawing.Size(730, 386)
        Me.dgvProdutos.TabIndex = 43
        '
        'frmConsultaSaldodoProduto
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(730, 460)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.Panel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "frmConsultaSaldodoProduto"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Conslta de Saldo do produto"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        CType(Me.dgvProdutos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lblPesquisa As System.Windows.Forms.Label
    Friend WithEvents btnPesquisa As System.Windows.Forms.Button
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents tssContReg As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents btnsair As System.Windows.Forms.Button
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents dgvProdutos As System.Windows.Forms.DataGridView
    Friend WithEvents cbarmazem As System.Windows.Forms.ComboBox
End Class
