<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMovimentoDoEstoque
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMovimentoDoEstoque))
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
        Me.PCabecalho = New System.Windows.Forms.Panel()
        Me.txtorimov = New System.Windows.Forms.TextBox()
        Me.lblorigmov = New System.Windows.Forms.Label()
        Me.lblUsuarioCad = New System.Windows.Forms.Label()
        Me.txtUsuarioCad = New System.Windows.Forms.TextBox()
        Me.dtpdatacad = New System.Windows.Forms.DateTimePicker()
        Me.lbldatacad = New System.Windows.Forms.Label()
        Me.txtnumdoc = New System.Windows.Forms.TextBox()
        Me.lblnumdoc = New System.Windows.Forms.Label()
        Me.rgSaida = New System.Windows.Forms.RadioButton()
        Me.rgEntrada = New System.Windows.Forms.RadioButton()
        Me.lblstatus = New System.Windows.Forms.Label()
        Me.txtCodigo = New System.Windows.Forms.TextBox()
        Me.lblCodigo = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.TabControle = New System.Windows.Forms.TabControl()
        Me.TabPagEntradaouSaida = New System.Windows.Forms.TabPage()
        Me.btncancelarprodutos = New System.Windows.Forms.Button()
        Me.btnIncluirproduto = New System.Windows.Forms.Button()
        Me.dgvProdutos = New System.Windows.Forms.DataGridView()
        Me.lblvalorcusto = New System.Windows.Forms.Label()
        Me.txtvalorcusto = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtqtdemovimentada = New System.Windows.Forms.TextBox()
        Me.cbtipodemovimento = New System.Windows.Forms.ComboBox()
        Me.lbltipodemovimento = New System.Windows.Forms.Label()
        Me.cbarmazem = New System.Windows.Forms.ComboBox()
        Me.lblarmazem = New System.Windows.Forms.Label()
        Me.ComandoPesquisar = New System.Windows.Forms.Button()
        Me.txtdescricaoproduto = New System.Windows.Forms.TextBox()
        Me.txtCodigoproduto = New System.Windows.Forms.TextBox()
        Me.lblcodpro = New System.Windows.Forms.Label()
        Me.TabPagHistorico = New System.Windows.Forms.TabPage()
        Me.txthistorico = New System.Windows.Forms.TextBox()
        Me.ToolStrip1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.PCabecalho.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.TabControle.SuspendLayout()
        Me.TabPagEntradaouSaida.SuspendLayout()
        CType(Me.dgvProdutos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPagHistorico.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(32, 32)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnIncluir, Me.btnAlterar, Me.btnExcluir, Me.ToolStripSeparator1, Me.btnGravar, Me.btnCancelar, Me.ToolStripSeparator3, Me.btnAnterior, Me.btnProximo, Me.ToolStripSeparator2, Me.btnLocalizar, Me.btnImprimir})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.ToolStrip1.Size = New System.Drawing.Size(784, 39)
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
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 393)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(784, 22)
        Me.StatusStrip1.TabIndex = 11
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'tssContReg
        '
        Me.tssContReg.Name = "tssContReg"
        Me.tssContReg.Size = New System.Drawing.Size(78, 17)
        Me.tssContReg.Text = "Registro n / n"
        '
        'PCabecalho
        '
        Me.PCabecalho.Controls.Add(Me.txtorimov)
        Me.PCabecalho.Controls.Add(Me.lblorigmov)
        Me.PCabecalho.Controls.Add(Me.lblUsuarioCad)
        Me.PCabecalho.Controls.Add(Me.txtUsuarioCad)
        Me.PCabecalho.Controls.Add(Me.dtpdatacad)
        Me.PCabecalho.Controls.Add(Me.lbldatacad)
        Me.PCabecalho.Controls.Add(Me.txtnumdoc)
        Me.PCabecalho.Controls.Add(Me.lblnumdoc)
        Me.PCabecalho.Controls.Add(Me.rgSaida)
        Me.PCabecalho.Controls.Add(Me.rgEntrada)
        Me.PCabecalho.Controls.Add(Me.lblstatus)
        Me.PCabecalho.Controls.Add(Me.txtCodigo)
        Me.PCabecalho.Controls.Add(Me.lblCodigo)
        Me.PCabecalho.Dock = System.Windows.Forms.DockStyle.Top
        Me.PCabecalho.Location = New System.Drawing.Point(0, 39)
        Me.PCabecalho.Name = "PCabecalho"
        Me.PCabecalho.Size = New System.Drawing.Size(784, 55)
        Me.PCabecalho.TabIndex = 13
        '
        'txtorimov
        '
        Me.txtorimov.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower
        Me.txtorimov.Location = New System.Drawing.Point(142, 30)
        Me.txtorimov.MaxLength = 100
        Me.txtorimov.Name = "txtorimov"
        Me.txtorimov.Size = New System.Drawing.Size(160, 20)
        Me.txtorimov.TabIndex = 17
        '
        'lblorigmov
        '
        Me.lblorigmov.AutoSize = True
        Me.lblorigmov.Location = New System.Drawing.Point(13, 33)
        Me.lblorigmov.Name = "lblorigmov"
        Me.lblorigmov.Size = New System.Drawing.Size(131, 13)
        Me.lblorigmov.TabIndex = 16
        Me.lblorigmov.Text = "Origem da Movimentação:"
        '
        'lblUsuarioCad
        '
        Me.lblUsuarioCad.AutoSize = True
        Me.lblUsuarioCad.Location = New System.Drawing.Point(336, 8)
        Me.lblUsuarioCad.Name = "lblUsuarioCad"
        Me.lblUsuarioCad.Size = New System.Drawing.Size(46, 13)
        Me.lblUsuarioCad.TabIndex = 15
        Me.lblUsuarioCad.Text = "Usuário:"
        '
        'txtUsuarioCad
        '
        Me.txtUsuarioCad.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower
        Me.txtUsuarioCad.Location = New System.Drawing.Point(388, 7)
        Me.txtUsuarioCad.MaxLength = 100
        Me.txtUsuarioCad.Name = "txtUsuarioCad"
        Me.txtUsuarioCad.Size = New System.Drawing.Size(148, 20)
        Me.txtUsuarioCad.TabIndex = 3
        '
        'dtpdatacad
        '
        Me.dtpdatacad.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpdatacad.Location = New System.Drawing.Point(236, 5)
        Me.dtpdatacad.MinDate = New Date(1800, 1, 1, 0, 0, 0, 0)
        Me.dtpdatacad.Name = "dtpdatacad"
        Me.dtpdatacad.Size = New System.Drawing.Size(94, 20)
        Me.dtpdatacad.TabIndex = 1
        '
        'lbldatacad
        '
        Me.lbldatacad.AutoSize = True
        Me.lbldatacad.Location = New System.Drawing.Point(134, 7)
        Me.lbldatacad.Name = "lbldatacad"
        Me.lbldatacad.Size = New System.Drawing.Size(103, 13)
        Me.lbldatacad.TabIndex = 14
        Me.lbldatacad.Text = "Data do Movimento:"
        '
        'txtnumdoc
        '
        Me.txtnumdoc.Location = New System.Drawing.Point(399, 30)
        Me.txtnumdoc.MaxLength = 6
        Me.txtnumdoc.Name = "txtnumdoc"
        Me.txtnumdoc.Size = New System.Drawing.Size(91, 20)
        Me.txtnumdoc.TabIndex = 4
        '
        'lblnumdoc
        '
        Me.lblnumdoc.AutoSize = True
        Me.lblnumdoc.Location = New System.Drawing.Point(308, 33)
        Me.lblnumdoc.Name = "lblnumdoc"
        Me.lblnumdoc.Size = New System.Drawing.Size(88, 13)
        Me.lblnumdoc.TabIndex = 11
        Me.lblnumdoc.Text = "Número do Doc.:"
        '
        'rgSaida
        '
        Me.rgSaida.AutoSize = True
        Me.rgSaida.Location = New System.Drawing.Point(633, 31)
        Me.rgSaida.Name = "rgSaida"
        Me.rgSaida.Size = New System.Drawing.Size(52, 17)
        Me.rgSaida.TabIndex = 6
        Me.rgSaida.Text = "Saida"
        Me.rgSaida.UseVisualStyleBackColor = True
        '
        'rgEntrada
        '
        Me.rgEntrada.AutoSize = True
        Me.rgEntrada.Location = New System.Drawing.Point(563, 31)
        Me.rgEntrada.Name = "rgEntrada"
        Me.rgEntrada.Size = New System.Drawing.Size(62, 17)
        Me.rgEntrada.TabIndex = 5
        Me.rgEntrada.Text = "Entrada"
        Me.rgEntrada.UseVisualStyleBackColor = True
        '
        'lblstatus
        '
        Me.lblstatus.AutoSize = True
        Me.lblstatus.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblstatus.Location = New System.Drawing.Point(504, 33)
        Me.lblstatus.Name = "lblstatus"
        Me.lblstatus.Size = New System.Drawing.Size(57, 13)
        Me.lblstatus.TabIndex = 10
        Me.lblstatus.Text = "Operação:"
        '
        'txtCodigo
        '
        Me.txtCodigo.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtCodigo.Location = New System.Drawing.Point(62, 4)
        Me.txtCodigo.MaxLength = 8
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.Size = New System.Drawing.Size(63, 20)
        Me.txtCodigo.TabIndex = 0
        '
        'lblCodigo
        '
        Me.lblCodigo.AutoSize = True
        Me.lblCodigo.Location = New System.Drawing.Point(13, 7)
        Me.lblCodigo.Name = "lblCodigo"
        Me.lblCodigo.Size = New System.Drawing.Size(43, 13)
        Me.lblCodigo.TabIndex = 5
        Me.lblCodigo.Text = "Código:"
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.TabControle)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 94)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(784, 299)
        Me.Panel2.TabIndex = 14
        '
        'TabControle
        '
        Me.TabControle.Controls.Add(Me.TabPagEntradaouSaida)
        Me.TabControle.Controls.Add(Me.TabPagHistorico)
        Me.TabControle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControle.Location = New System.Drawing.Point(0, 0)
        Me.TabControle.Name = "TabControle"
        Me.TabControle.SelectedIndex = 0
        Me.TabControle.Size = New System.Drawing.Size(784, 299)
        Me.TabControle.TabIndex = 13
        '
        'TabPagEntradaouSaida
        '
        Me.TabPagEntradaouSaida.Controls.Add(Me.btncancelarprodutos)
        Me.TabPagEntradaouSaida.Controls.Add(Me.btnIncluirproduto)
        Me.TabPagEntradaouSaida.Controls.Add(Me.dgvProdutos)
        Me.TabPagEntradaouSaida.Controls.Add(Me.lblvalorcusto)
        Me.TabPagEntradaouSaida.Controls.Add(Me.txtvalorcusto)
        Me.TabPagEntradaouSaida.Controls.Add(Me.Label2)
        Me.TabPagEntradaouSaida.Controls.Add(Me.txtqtdemovimentada)
        Me.TabPagEntradaouSaida.Controls.Add(Me.cbtipodemovimento)
        Me.TabPagEntradaouSaida.Controls.Add(Me.lbltipodemovimento)
        Me.TabPagEntradaouSaida.Controls.Add(Me.cbarmazem)
        Me.TabPagEntradaouSaida.Controls.Add(Me.lblarmazem)
        Me.TabPagEntradaouSaida.Controls.Add(Me.ComandoPesquisar)
        Me.TabPagEntradaouSaida.Controls.Add(Me.txtdescricaoproduto)
        Me.TabPagEntradaouSaida.Controls.Add(Me.txtCodigoproduto)
        Me.TabPagEntradaouSaida.Controls.Add(Me.lblcodpro)
        Me.TabPagEntradaouSaida.Location = New System.Drawing.Point(4, 22)
        Me.TabPagEntradaouSaida.Name = "TabPagEntradaouSaida"
        Me.TabPagEntradaouSaida.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPagEntradaouSaida.Size = New System.Drawing.Size(776, 273)
        Me.TabPagEntradaouSaida.TabIndex = 0
        Me.TabPagEntradaouSaida.Text = "Entrada/Saida"
        Me.TabPagEntradaouSaida.UseVisualStyleBackColor = True
        '
        'btncancelarprodutos
        '
        Me.btncancelarprodutos.Location = New System.Drawing.Point(474, 78)
        Me.btncancelarprodutos.Name = "btncancelarprodutos"
        Me.btncancelarprodutos.Size = New System.Drawing.Size(75, 23)
        Me.btncancelarprodutos.TabIndex = 52
        Me.btncancelarprodutos.Text = "Cancelar"
        Me.btncancelarprodutos.UseVisualStyleBackColor = True
        '
        'btnIncluirproduto
        '
        Me.btnIncluirproduto.Location = New System.Drawing.Point(474, 32)
        Me.btnIncluirproduto.Name = "btnIncluirproduto"
        Me.btnIncluirproduto.Size = New System.Drawing.Size(75, 23)
        Me.btnIncluirproduto.TabIndex = 51
        Me.btnIncluirproduto.Text = "Incluir"
        Me.btnIncluirproduto.UseVisualStyleBackColor = True
        '
        'dgvProdutos
        '
        Me.dgvProdutos.AllowUserToAddRows = False
        Me.dgvProdutos.AllowUserToDeleteRows = False
        Me.dgvProdutos.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvProdutos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvProdutos.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.dgvProdutos.Location = New System.Drawing.Point(3, 139)
        Me.dgvProdutos.Name = "dgvProdutos"
        Me.dgvProdutos.ReadOnly = True
        Me.dgvProdutos.Size = New System.Drawing.Size(770, 131)
        Me.dgvProdutos.TabIndex = 50
        '
        'lblvalorcusto
        '
        Me.lblvalorcusto.AutoSize = True
        Me.lblvalorcusto.Location = New System.Drawing.Point(218, 116)
        Me.lblvalorcusto.Name = "lblvalorcusto"
        Me.lblvalorcusto.Size = New System.Drawing.Size(99, 13)
        Me.lblvalorcusto.TabIndex = 49
        Me.lblvalorcusto.Text = "Valor de Custo R$ :"
        '
        'txtvalorcusto
        '
        Me.txtvalorcusto.Location = New System.Drawing.Point(315, 113)
        Me.txtvalorcusto.MaxLength = 10
        Me.txtvalorcusto.Name = "txtvalorcusto"
        Me.txtvalorcusto.Size = New System.Drawing.Size(81, 20)
        Me.txtvalorcusto.TabIndex = 48
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(4, 114)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(132, 13)
        Me.Label2.TabIndex = 47
        Me.Label2.Text = "Quantidade Movimentada:"
        '
        'txtqtdemovimentada
        '
        Me.txtqtdemovimentada.Location = New System.Drawing.Point(138, 112)
        Me.txtqtdemovimentada.MaxLength = 6
        Me.txtqtdemovimentada.Name = "txtqtdemovimentada"
        Me.txtqtdemovimentada.Size = New System.Drawing.Size(55, 20)
        Me.txtqtdemovimentada.TabIndex = 46
        '
        'cbtipodemovimento
        '
        Me.cbtipodemovimento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbtipodemovimento.FormattingEnabled = True
        Me.cbtipodemovimento.Location = New System.Drawing.Point(102, 85)
        Me.cbtipodemovimento.Name = "cbtipodemovimento"
        Me.cbtipodemovimento.Size = New System.Drawing.Size(267, 21)
        Me.cbtipodemovimento.TabIndex = 44
        '
        'lbltipodemovimento
        '
        Me.lbltipodemovimento.AutoSize = True
        Me.lbltipodemovimento.Location = New System.Drawing.Point(4, 88)
        Me.lbltipodemovimento.Name = "lbltipodemovimento"
        Me.lbltipodemovimento.Size = New System.Drawing.Size(101, 13)
        Me.lbltipodemovimento.TabIndex = 45
        Me.lbltipodemovimento.Text = "Tipo de Movimento:"
        '
        'cbarmazem
        '
        Me.cbarmazem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbarmazem.FormattingEnabled = True
        Me.cbarmazem.Location = New System.Drawing.Point(55, 58)
        Me.cbarmazem.Name = "cbarmazem"
        Me.cbarmazem.Size = New System.Drawing.Size(314, 21)
        Me.cbarmazem.TabIndex = 42
        '
        'lblarmazem
        '
        Me.lblarmazem.AutoSize = True
        Me.lblarmazem.Location = New System.Drawing.Point(4, 61)
        Me.lblarmazem.Name = "lblarmazem"
        Me.lblarmazem.Size = New System.Drawing.Size(53, 13)
        Me.lblarmazem.TabIndex = 43
        Me.lblarmazem.Text = "Armazém:"
        '
        'ComandoPesquisar
        '
        Me.ComandoPesquisar.BackgroundImage = CType(resources.GetObject("ComandoPesquisar.BackgroundImage"), System.Drawing.Image)
        Me.ComandoPesquisar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ComandoPesquisar.Enabled = False
        Me.ComandoPesquisar.Location = New System.Drawing.Point(116, 6)
        Me.ComandoPesquisar.Name = "ComandoPesquisar"
        Me.ComandoPesquisar.Size = New System.Drawing.Size(20, 20)
        Me.ComandoPesquisar.TabIndex = 41
        Me.ComandoPesquisar.UseVisualStyleBackColor = True
        '
        'txtdescricaoproduto
        '
        Me.txtdescricaoproduto.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtdescricaoproduto.Location = New System.Drawing.Point(7, 32)
        Me.txtdescricaoproduto.MaxLength = 60
        Me.txtdescricaoproduto.Name = "txtdescricaoproduto"
        Me.txtdescricaoproduto.ReadOnly = True
        Me.txtdescricaoproduto.Size = New System.Drawing.Size(306, 20)
        Me.txtdescricaoproduto.TabIndex = 39
        '
        'txtCodigoproduto
        '
        Me.txtCodigoproduto.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtCodigoproduto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCodigoproduto.Location = New System.Drawing.Point(49, 6)
        Me.txtCodigoproduto.MaxLength = 6
        Me.txtCodigoproduto.Name = "txtCodigoproduto"
        Me.txtCodigoproduto.Size = New System.Drawing.Size(63, 20)
        Me.txtCodigoproduto.TabIndex = 38
        '
        'lblcodpro
        '
        Me.lblcodpro.AutoSize = True
        Me.lblcodpro.Location = New System.Drawing.Point(4, 8)
        Me.lblcodpro.Name = "lblcodpro"
        Me.lblcodpro.Size = New System.Drawing.Size(43, 13)
        Me.lblcodpro.TabIndex = 40
        Me.lblcodpro.Text = "Código:"
        '
        'TabPagHistorico
        '
        Me.TabPagHistorico.Controls.Add(Me.txthistorico)
        Me.TabPagHistorico.Location = New System.Drawing.Point(4, 22)
        Me.TabPagHistorico.Name = "TabPagHistorico"
        Me.TabPagHistorico.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPagHistorico.Size = New System.Drawing.Size(776, 273)
        Me.TabPagHistorico.TabIndex = 1
        Me.TabPagHistorico.Text = "Histórico"
        Me.TabPagHistorico.UseVisualStyleBackColor = True
        '
        'txthistorico
        '
        Me.txthistorico.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txthistorico.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txthistorico.Location = New System.Drawing.Point(3, 3)
        Me.txthistorico.Margin = New System.Windows.Forms.Padding(2)
        Me.txthistorico.MaxLength = 80
        Me.txthistorico.Multiline = True
        Me.txthistorico.Name = "txthistorico"
        Me.txthistorico.Size = New System.Drawing.Size(770, 267)
        Me.txthistorico.TabIndex = 48
        '
        'frmMovimentoDoEstoque
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(784, 415)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.PCabecalho)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "frmMovimentoDoEstoque"
        Me.Text = "Movimento do Estoque"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.PCabecalho.ResumeLayout(False)
        Me.PCabecalho.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.TabControle.ResumeLayout(False)
        Me.TabPagEntradaouSaida.ResumeLayout(False)
        Me.TabPagEntradaouSaida.PerformLayout()
        CType(Me.dgvProdutos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPagHistorico.ResumeLayout(False)
        Me.TabPagHistorico.PerformLayout()
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
    Friend WithEvents PCabecalho As System.Windows.Forms.Panel
    Friend WithEvents rgSaida As System.Windows.Forms.RadioButton
    Friend WithEvents rgEntrada As System.Windows.Forms.RadioButton
    Friend WithEvents lblstatus As System.Windows.Forms.Label
    Friend WithEvents txtCodigo As System.Windows.Forms.TextBox
    Friend WithEvents lblCodigo As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents TabControle As System.Windows.Forms.TabControl
    Friend WithEvents TabPagEntradaouSaida As System.Windows.Forms.TabPage
    Friend WithEvents lblnumdoc As System.Windows.Forms.Label
    Friend WithEvents txtnumdoc As System.Windows.Forms.TextBox
    Friend WithEvents dtpdatacad As System.Windows.Forms.DateTimePicker
    Friend WithEvents lbldatacad As System.Windows.Forms.Label
    Friend WithEvents lblUsuarioCad As System.Windows.Forms.Label
    Friend WithEvents txtUsuarioCad As System.Windows.Forms.TextBox
    Friend WithEvents ComandoPesquisar As System.Windows.Forms.Button
    Friend WithEvents txtdescricaoproduto As System.Windows.Forms.TextBox
    Friend WithEvents txtCodigoproduto As System.Windows.Forms.TextBox
    Friend WithEvents lblcodpro As System.Windows.Forms.Label
    Friend WithEvents cbarmazem As System.Windows.Forms.ComboBox
    Friend WithEvents lblarmazem As System.Windows.Forms.Label
    Friend WithEvents cbtipodemovimento As System.Windows.Forms.ComboBox
    Friend WithEvents lbltipodemovimento As System.Windows.Forms.Label
    Friend WithEvents TabPagHistorico As System.Windows.Forms.TabPage
    Friend WithEvents txthistorico As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtqtdemovimentada As System.Windows.Forms.TextBox
    Friend WithEvents lblvalorcusto As System.Windows.Forms.Label
    Friend WithEvents txtvalorcusto As System.Windows.Forms.TextBox
    Friend WithEvents dgvProdutos As System.Windows.Forms.DataGridView
    Friend WithEvents btncancelarprodutos As System.Windows.Forms.Button
    Friend WithEvents btnIncluirproduto As System.Windows.Forms.Button
    Friend WithEvents txtorimov As System.Windows.Forms.TextBox
    Friend WithEvents lblorigmov As System.Windows.Forms.Label
End Class
