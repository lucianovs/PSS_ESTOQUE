<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEstruturadeProdutos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmEstruturadeProdutos))
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.btnIncluir = New System.Windows.Forms.ToolStripButton()
        Me.btnAlterar = New System.Windows.Forms.ToolStripButton()
        Me.btnExcluir = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnGravar = New System.Windows.Forms.ToolStripButton()
        Me.btnCancelar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnAnterior = New System.Windows.Forms.ToolStripButton()
        Me.btnProximo = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnLocalizar = New System.Windows.Forms.ToolStripButton()
        Me.btnImprimir = New System.Windows.Forms.ToolStripButton()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.tssContReg = New System.Windows.Forms.ToolStripStatusLabel()
        Me.TabControle = New System.Windows.Forms.TabControl()
        Me.TabPrimeiraPagina = New System.Windows.Forms.TabPage()
        Me.txtquantidade = New System.Windows.Forms.TextBox()
        Me.dgvProdutos = New System.Windows.Forms.DataGridView()
        Me.btncancelarsubprodutos = New System.Windows.Forms.Button()
        Me.btnIncluirsubproduto = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.comandoPesquisarsubpruduto = New System.Windows.Forms.Button()
        Me.txtdescricaosubproduto = New System.Windows.Forms.TextBox()
        Me.txtCodigosubproduto = New System.Windows.Forms.TextBox()
        Me.lblCodSubProd = New System.Windows.Forms.Label()
        Me.PCabecalho = New System.Windows.Forms.Panel()
        Me.ComandoPesquisar = New System.Windows.Forms.Button()
        Me.txtDescricao = New System.Windows.Forms.TextBox()
        Me.txtCodigo = New System.Windows.Forms.TextBox()
        Me.lblCodigo = New System.Windows.Forms.Label()
        Me.ToolStrip1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.TabControle.SuspendLayout()
        Me.TabPrimeiraPagina.SuspendLayout()
        CType(Me.dgvProdutos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PCabecalho.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(32, 32)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnIncluir, Me.btnAlterar, Me.btnExcluir, Me.ToolStripSeparator1, Me.btnGravar, Me.btnCancelar, Me.ToolStripSeparator3, Me.btnAnterior, Me.btnProximo, Me.ToolStripSeparator2, Me.btnLocalizar, Me.btnImprimir})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.ToolStrip1.Size = New System.Drawing.Size(730, 39)
        Me.ToolStrip1.Stretch = True
        Me.ToolStrip1.TabIndex = 3
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'btnIncluir
        '
        Me.btnIncluir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnIncluir.Image = CType(resources.GetObject("btnIncluir.Image"), System.Drawing.Image)
        Me.btnIncluir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnIncluir.Name = "btnIncluir"
        Me.btnIncluir.Size = New System.Drawing.Size(36, 36)
        Me.btnIncluir.Text = "Incluir"
        '
        'btnAlterar
        '
        Me.btnAlterar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnAlterar.Image = CType(resources.GetObject("btnAlterar.Image"), System.Drawing.Image)
        Me.btnAlterar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnAlterar.Name = "btnAlterar"
        Me.btnAlterar.Size = New System.Drawing.Size(36, 36)
        Me.btnAlterar.Text = "Alterar"
        '
        'btnExcluir
        '
        Me.btnExcluir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnExcluir.Image = CType(resources.GetObject("btnExcluir.Image"), System.Drawing.Image)
        Me.btnExcluir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnExcluir.Name = "btnExcluir"
        Me.btnExcluir.Size = New System.Drawing.Size(36, 36)
        Me.btnExcluir.Text = "Excluir"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 39)
        '
        'btnGravar
        '
        Me.btnGravar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnGravar.Image = CType(resources.GetObject("btnGravar.Image"), System.Drawing.Image)
        Me.btnGravar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnGravar.Name = "btnGravar"
        Me.btnGravar.Size = New System.Drawing.Size(36, 36)
        Me.btnGravar.Text = "Gravar"
        '
        'btnCancelar
        '
        Me.btnCancelar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnCancelar.Image = CType(resources.GetObject("btnCancelar.Image"), System.Drawing.Image)
        Me.btnCancelar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(36, 36)
        Me.btnCancelar.Text = "Cancelar"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 39)
        '
        'btnAnterior
        '
        Me.btnAnterior.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnAnterior.Image = CType(resources.GetObject("btnAnterior.Image"), System.Drawing.Image)
        Me.btnAnterior.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnAnterior.Name = "btnAnterior"
        Me.btnAnterior.Size = New System.Drawing.Size(36, 36)
        Me.btnAnterior.Text = "Anterior"
        '
        'btnProximo
        '
        Me.btnProximo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnProximo.Image = CType(resources.GetObject("btnProximo.Image"), System.Drawing.Image)
        Me.btnProximo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnProximo.Name = "btnProximo"
        Me.btnProximo.Size = New System.Drawing.Size(36, 36)
        Me.btnProximo.Text = "Próximo"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 39)
        '
        'btnLocalizar
        '
        Me.btnLocalizar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnLocalizar.Image = CType(resources.GetObject("btnLocalizar.Image"), System.Drawing.Image)
        Me.btnLocalizar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnLocalizar.Name = "btnLocalizar"
        Me.btnLocalizar.Size = New System.Drawing.Size(36, 36)
        Me.btnLocalizar.Text = "Localizar"
        '
        'btnImprimir
        '
        Me.btnImprimir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnImprimir.Image = CType(resources.GetObject("btnImprimir.Image"), System.Drawing.Image)
        Me.btnImprimir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(36, 36)
        Me.btnImprimir.Text = "Imprimir"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tssContReg})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 438)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(730, 22)
        Me.StatusStrip1.TabIndex = 11
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'tssContReg
        '
        Me.tssContReg.Name = "tssContReg"
        Me.tssContReg.Size = New System.Drawing.Size(78, 17)
        Me.tssContReg.Text = "Registro n / n"
        '
        'TabControle
        '
        Me.TabControle.Controls.Add(Me.TabPrimeiraPagina)
        Me.TabControle.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.TabControle.Location = New System.Drawing.Point(0, 107)
        Me.TabControle.Name = "TabControle"
        Me.TabControle.SelectedIndex = 0
        Me.TabControle.Size = New System.Drawing.Size(730, 331)
        Me.TabControle.TabIndex = 35
        '
        'TabPrimeiraPagina
        '
        Me.TabPrimeiraPagina.Controls.Add(Me.txtquantidade)
        Me.TabPrimeiraPagina.Controls.Add(Me.dgvProdutos)
        Me.TabPrimeiraPagina.Controls.Add(Me.btncancelarsubprodutos)
        Me.TabPrimeiraPagina.Controls.Add(Me.btnIncluirsubproduto)
        Me.TabPrimeiraPagina.Controls.Add(Me.Label1)
        Me.TabPrimeiraPagina.Controls.Add(Me.comandoPesquisarsubpruduto)
        Me.TabPrimeiraPagina.Controls.Add(Me.txtdescricaosubproduto)
        Me.TabPrimeiraPagina.Controls.Add(Me.txtCodigosubproduto)
        Me.TabPrimeiraPagina.Controls.Add(Me.lblCodSubProd)
        Me.TabPrimeiraPagina.Location = New System.Drawing.Point(4, 22)
        Me.TabPrimeiraPagina.Name = "TabPrimeiraPagina"
        Me.TabPrimeiraPagina.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPrimeiraPagina.Size = New System.Drawing.Size(722, 305)
        Me.TabPrimeiraPagina.TabIndex = 0
        Me.TabPrimeiraPagina.Text = "Sub Produtos"
        Me.TabPrimeiraPagina.UseVisualStyleBackColor = True
        '
        'txtquantidade
        '
        Me.txtquantidade.Location = New System.Drawing.Point(9, 96)
        Me.txtquantidade.MaxLength = 6
        Me.txtquantidade.Name = "txtquantidade"
        Me.txtquantidade.Size = New System.Drawing.Size(61, 20)
        Me.txtquantidade.TabIndex = 50
        '
        'dgvProdutos
        '
        Me.dgvProdutos.AllowUserToAddRows = False
        Me.dgvProdutos.AllowUserToDeleteRows = False
        Me.dgvProdutos.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvProdutos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvProdutos.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.dgvProdutos.Location = New System.Drawing.Point(3, 122)
        Me.dgvProdutos.Name = "dgvProdutos"
        Me.dgvProdutos.ReadOnly = True
        Me.dgvProdutos.Size = New System.Drawing.Size(716, 180)
        Me.dgvProdutos.TabIndex = 48
        '
        'btncancelarsubprodutos
        '
        Me.btncancelarsubprodutos.Location = New System.Drawing.Point(344, 70)
        Me.btncancelarsubprodutos.Name = "btncancelarsubprodutos"
        Me.btncancelarsubprodutos.Size = New System.Drawing.Size(75, 23)
        Me.btncancelarsubprodutos.TabIndex = 44
        Me.btncancelarsubprodutos.Text = "Cancelar"
        Me.btncancelarsubprodutos.UseVisualStyleBackColor = True
        '
        'btnIncluirsubproduto
        '
        Me.btnIncluirsubproduto.Location = New System.Drawing.Point(344, 24)
        Me.btnIncluirsubproduto.Name = "btnIncluirsubproduto"
        Me.btnIncluirsubproduto.Size = New System.Drawing.Size(75, 23)
        Me.btnIncluirsubproduto.TabIndex = 43
        Me.btnIncluirsubproduto.Text = "Incluir"
        Me.btnIncluirsubproduto.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(5, 80)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 13)
        Me.Label1.TabIndex = 42
        Me.Label1.Text = "Quantidade:"
        '
        'comandoPesquisarsubpruduto
        '
        Me.comandoPesquisarsubpruduto.BackgroundImage = CType(resources.GetObject("comandoPesquisarsubpruduto.BackgroundImage"), System.Drawing.Image)
        Me.comandoPesquisarsubpruduto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.comandoPesquisarsubpruduto.Enabled = False
        Me.comandoPesquisarsubpruduto.Location = New System.Drawing.Point(78, 23)
        Me.comandoPesquisarsubpruduto.Name = "comandoPesquisarsubpruduto"
        Me.comandoPesquisarsubpruduto.Size = New System.Drawing.Size(20, 20)
        Me.comandoPesquisarsubpruduto.TabIndex = 41
        Me.comandoPesquisarsubpruduto.UseVisualStyleBackColor = True
        '
        'txtdescricaosubproduto
        '
        Me.txtdescricaosubproduto.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtdescricaosubproduto.Location = New System.Drawing.Point(9, 50)
        Me.txtdescricaosubproduto.MaxLength = 60
        Me.txtdescricaosubproduto.Name = "txtdescricaosubproduto"
        Me.txtdescricaosubproduto.ReadOnly = True
        Me.txtdescricaosubproduto.Size = New System.Drawing.Size(281, 20)
        Me.txtdescricaosubproduto.TabIndex = 4
        '
        'txtCodigosubproduto
        '
        Me.txtCodigosubproduto.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtCodigosubproduto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCodigosubproduto.Location = New System.Drawing.Point(9, 24)
        Me.txtCodigosubproduto.MaxLength = 6
        Me.txtCodigosubproduto.Name = "txtCodigosubproduto"
        Me.txtCodigosubproduto.Size = New System.Drawing.Size(63, 20)
        Me.txtCodigosubproduto.TabIndex = 3
        '
        'lblCodSubProd
        '
        Me.lblCodSubProd.AutoSize = True
        Me.lblCodSubProd.Location = New System.Drawing.Point(5, 8)
        Me.lblCodSubProd.Name = "lblCodSubProd"
        Me.lblCodSubProd.Size = New System.Drawing.Size(116, 13)
        Me.lblCodSubProd.TabIndex = 39
        Me.lblCodSubProd.Text = "Código do Subproduto:"
        '
        'PCabecalho
        '
        Me.PCabecalho.Controls.Add(Me.ComandoPesquisar)
        Me.PCabecalho.Controls.Add(Me.txtDescricao)
        Me.PCabecalho.Controls.Add(Me.txtCodigo)
        Me.PCabecalho.Controls.Add(Me.lblCodigo)
        Me.PCabecalho.Dock = System.Windows.Forms.DockStyle.Top
        Me.PCabecalho.Location = New System.Drawing.Point(0, 39)
        Me.PCabecalho.Name = "PCabecalho"
        Me.PCabecalho.Size = New System.Drawing.Size(730, 62)
        Me.PCabecalho.TabIndex = 36
        '
        'ComandoPesquisar
        '
        Me.ComandoPesquisar.BackgroundImage = CType(resources.GetObject("ComandoPesquisar.BackgroundImage"), System.Drawing.Image)
        Me.ComandoPesquisar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ComandoPesquisar.Enabled = False
        Me.ComandoPesquisar.Location = New System.Drawing.Point(117, 3)
        Me.ComandoPesquisar.Name = "ComandoPesquisar"
        Me.ComandoPesquisar.Size = New System.Drawing.Size(20, 20)
        Me.ComandoPesquisar.TabIndex = 37
        Me.ComandoPesquisar.UseVisualStyleBackColor = True
        '
        'txtDescricao
        '
        Me.txtDescricao.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtDescricao.Location = New System.Drawing.Point(8, 29)
        Me.txtDescricao.MaxLength = 60
        Me.txtDescricao.Name = "txtDescricao"
        Me.txtDescricao.ReadOnly = True
        Me.txtDescricao.Size = New System.Drawing.Size(306, 20)
        Me.txtDescricao.TabIndex = 1
        '
        'txtCodigo
        '
        Me.txtCodigo.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtCodigo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCodigo.Location = New System.Drawing.Point(50, 3)
        Me.txtCodigo.MaxLength = 6
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.Size = New System.Drawing.Size(63, 20)
        Me.txtCodigo.TabIndex = 0
        '
        'lblCodigo
        '
        Me.lblCodigo.AutoSize = True
        Me.lblCodigo.Location = New System.Drawing.Point(5, 5)
        Me.lblCodigo.Name = "lblCodigo"
        Me.lblCodigo.Size = New System.Drawing.Size(43, 13)
        Me.lblCodigo.TabIndex = 35
        Me.lblCodigo.Text = "Código:"
        '
        'frmEstruturadeProdutos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(730, 460)
        Me.Controls.Add(Me.PCabecalho)
        Me.Controls.Add(Me.TabControle)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "frmEstruturadeProdutos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Estrutura de Produtos"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.TabControle.ResumeLayout(False)
        Me.TabPrimeiraPagina.ResumeLayout(False)
        Me.TabPrimeiraPagina.PerformLayout()
        CType(Me.dgvProdutos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PCabecalho.ResumeLayout(False)
        Me.PCabecalho.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents btnIncluir As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnAlterar As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnExcluir As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnGravar As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnCancelar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnAnterior As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnProximo As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnLocalizar As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnImprimir As System.Windows.Forms.ToolStripButton
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents tssContReg As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents TabControle As System.Windows.Forms.TabControl
    Friend WithEvents TabPrimeiraPagina As System.Windows.Forms.TabPage
    Friend WithEvents PCabecalho As System.Windows.Forms.Panel
    Friend WithEvents ComandoPesquisar As System.Windows.Forms.Button
    Friend WithEvents txtDescricao As System.Windows.Forms.TextBox
    Friend WithEvents txtCodigo As System.Windows.Forms.TextBox
    Friend WithEvents lblCodigo As System.Windows.Forms.Label
    Friend WithEvents comandoPesquisarsubpruduto As System.Windows.Forms.Button
    Friend WithEvents txtdescricaosubproduto As System.Windows.Forms.TextBox
    Friend WithEvents txtCodigosubproduto As System.Windows.Forms.TextBox
    Friend WithEvents lblCodSubProd As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btncancelarsubprodutos As System.Windows.Forms.Button
    Friend WithEvents btnIncluirsubproduto As System.Windows.Forms.Button
    Friend WithEvents dgvProdutos As System.Windows.Forms.DataGridView
    Friend WithEvents txtquantidade As System.Windows.Forms.TextBox
End Class
