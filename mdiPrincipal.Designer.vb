<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class mdiPrincipal
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(mdiPrincipal))
        Me.MenuStrip = New System.Windows.Forms.MenuStrip()
        Me.menuCadastro = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.menuCadProdutos = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuCadTipodeProdutos = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuCadEstruturadeProdutos = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuCadTipodeMovimentos = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuCadArmazens = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuSair = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuProcessos = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuProcMovimentodeEstoque = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuProcAtualizaçãodeSaldo = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuProcFechamentodeEstoque = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuProcIntegraçãoContábil = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuProcDigitaçãodoInventário = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuProcProcessaroinventário = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuConsultas = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuConsSaldodoProduto = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuRelatorios = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuRelSaldodoProduto = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuRelContagemdoInventário = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuSistema = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuSisConfiguracoes = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.menuSisUsuarios = New System.Windows.Forms.ToolStripMenuItem()
        Me.Ajuda = New System.Windows.Forms.ToolStripMenuItem()
        Me.ContentsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator8 = New System.Windows.Forms.ToolStripSeparator()
        Me.AboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StatusStrip = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.MenuStrip.SuspendLayout()
        Me.StatusStrip.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip
        '
        Me.MenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.menuCadastro, Me.menuProcessos, Me.menuConsultas, Me.menuRelatorios, Me.menuSistema, Me.Ajuda})
        Me.MenuStrip.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip.MdiWindowListItem = Me.menuRelatorios
        Me.MenuStrip.Name = "MenuStrip"
        Me.MenuStrip.Padding = New System.Windows.Forms.Padding(8, 2, 0, 2)
        Me.MenuStrip.Size = New System.Drawing.Size(933, 28)
        Me.MenuStrip.TabIndex = 5
        Me.MenuStrip.Text = "MenuStrip"
        '
        'menuCadastro
        '
        Me.menuCadastro.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator5, Me.menuCadProdutos, Me.menuCadTipodeProdutos, Me.menuCadEstruturadeProdutos, Me.menuCadTipodeMovimentos, Me.menuCadArmazens, Me.ToolStripMenuItem2, Me.mnuSair})
        Me.menuCadastro.ImageTransparentColor = System.Drawing.SystemColors.ActiveBorder
        Me.menuCadastro.Name = "menuCadastro"
        Me.menuCadastro.Size = New System.Drawing.Size(86, 24)
        Me.menuCadastro.Text = "&Cadastros"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(218, 6)
        '
        'menuCadProdutos
        '
        Me.menuCadProdutos.Name = "menuCadProdutos"
        Me.menuCadProdutos.Size = New System.Drawing.Size(221, 24)
        Me.menuCadProdutos.Text = "Produto"
        '
        'menuCadTipodeProdutos
        '
        Me.menuCadTipodeProdutos.Name = "menuCadTipodeProdutos"
        Me.menuCadTipodeProdutos.Size = New System.Drawing.Size(221, 24)
        Me.menuCadTipodeProdutos.Text = "Tipo de Produtos"
        '
        'menuCadEstruturadeProdutos
        '
        Me.menuCadEstruturadeProdutos.Name = "menuCadEstruturadeProdutos"
        Me.menuCadEstruturadeProdutos.Size = New System.Drawing.Size(221, 24)
        Me.menuCadEstruturadeProdutos.Text = "Estrutura do Produtos"
        '
        'menuCadTipodeMovimentos
        '
        Me.menuCadTipodeMovimentos.Name = "menuCadTipodeMovimentos"
        Me.menuCadTipodeMovimentos.Size = New System.Drawing.Size(221, 24)
        Me.menuCadTipodeMovimentos.Text = "Tipo de Movimentos"
        '
        'menuCadArmazens
        '
        Me.menuCadArmazens.Name = "menuCadArmazens"
        Me.menuCadArmazens.Size = New System.Drawing.Size(221, 24)
        Me.menuCadArmazens.Text = "Armazéns"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(218, 6)
        '
        'mnuSair
        '
        Me.mnuSair.Name = "mnuSair"
        Me.mnuSair.Size = New System.Drawing.Size(221, 24)
        Me.mnuSair.Text = "Sair"
        '
        'menuProcessos
        '
        Me.menuProcessos.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.menuProcMovimentodeEstoque, Me.menuProcAtualizaçãodeSaldo, Me.menuProcFechamentodeEstoque, Me.menuProcIntegraçãoContábil, Me.menuProcDigitaçãodoInventário, Me.menuProcProcessaroinventário})
        Me.menuProcessos.Name = "menuProcessos"
        Me.menuProcessos.Size = New System.Drawing.Size(85, 24)
        Me.menuProcessos.Text = "Processos"
        '
        'menuProcMovimentodeEstoque
        '
        Me.menuProcMovimentodeEstoque.Name = "menuProcMovimentodeEstoque"
        Me.menuProcMovimentodeEstoque.Size = New System.Drawing.Size(241, 24)
        Me.menuProcMovimentodeEstoque.Text = "Movimento de Estoque "
        '
        'menuProcAtualizaçãodeSaldo
        '
        Me.menuProcAtualizaçãodeSaldo.Name = "menuProcAtualizaçãodeSaldo"
        Me.menuProcAtualizaçãodeSaldo.Size = New System.Drawing.Size(241, 24)
        Me.menuProcAtualizaçãodeSaldo.Text = "Atualização de Saldo "
        '
        'menuProcFechamentodeEstoque
        '
        Me.menuProcFechamentodeEstoque.Name = "menuProcFechamentodeEstoque"
        Me.menuProcFechamentodeEstoque.Size = New System.Drawing.Size(241, 24)
        Me.menuProcFechamentodeEstoque.Text = "Fechamento de Estoque "
        '
        'menuProcIntegraçãoContábil
        '
        Me.menuProcIntegraçãoContábil.Name = "menuProcIntegraçãoContábil"
        Me.menuProcIntegraçãoContábil.Size = New System.Drawing.Size(241, 24)
        Me.menuProcIntegraçãoContábil.Text = "Integração Contábil "
        '
        'menuProcDigitaçãodoInventário
        '
        Me.menuProcDigitaçãodoInventário.Name = "menuProcDigitaçãodoInventário"
        Me.menuProcDigitaçãodoInventário.Size = New System.Drawing.Size(241, 24)
        Me.menuProcDigitaçãodoInventário.Text = "Digitação do Inventário "
        '
        'menuProcProcessaroinventário
        '
        Me.menuProcProcessaroinventário.Name = "menuProcProcessaroinventário"
        Me.menuProcProcessaroinventário.Size = New System.Drawing.Size(241, 24)
        Me.menuProcProcessaroinventário.Text = "Processar o Inventário "
        '
        'menuConsultas
        '
        Me.menuConsultas.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.menuConsSaldodoProduto})
        Me.menuConsultas.Name = "menuConsultas"
        Me.menuConsultas.Size = New System.Drawing.Size(84, 24)
        Me.menuConsultas.Text = "Consultas"
        '
        'menuConsSaldodoProduto
        '
        Me.menuConsSaldodoProduto.Name = "menuConsSaldodoProduto"
        Me.menuConsSaldodoProduto.Size = New System.Drawing.Size(200, 24)
        Me.menuConsSaldodoProduto.Text = "Saldo do produto "
        '
        'menuRelatorios
        '
        Me.menuRelatorios.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.menuRelSaldodoProduto, Me.menuRelContagemdoInventário})
        Me.menuRelatorios.Name = "menuRelatorios"
        Me.menuRelatorios.Size = New System.Drawing.Size(88, 24)
        Me.menuRelatorios.Text = "&Relatórios"
        '
        'menuRelSaldodoProduto
        '
        Me.menuRelSaldodoProduto.Name = "menuRelSaldodoProduto"
        Me.menuRelSaldodoProduto.Size = New System.Drawing.Size(239, 24)
        Me.menuRelSaldodoProduto.Text = "Saldo do produto "
        '
        'menuRelContagemdoInventário
        '
        Me.menuRelContagemdoInventário.Name = "menuRelContagemdoInventário"
        Me.menuRelContagemdoInventário.Size = New System.Drawing.Size(239, 24)
        Me.menuRelContagemdoInventário.Text = "Contagem do Inventário"
        '
        'menuSistema
        '
        Me.menuSistema.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.menuSisConfiguracoes, Me.ToolStripMenuItem1, Me.menuSisUsuarios})
        Me.menuSistema.Name = "menuSistema"
        Me.menuSistema.Size = New System.Drawing.Size(73, 24)
        Me.menuSistema.Text = "&Sistema"
        '
        'menuSisConfiguracoes
        '
        Me.menuSisConfiguracoes.Name = "menuSisConfiguracoes"
        Me.menuSisConfiguracoes.Size = New System.Drawing.Size(173, 24)
        Me.menuSisConfiguracoes.Text = "Configurações"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(170, 6)
        '
        'menuSisUsuarios
        '
        Me.menuSisUsuarios.Name = "menuSisUsuarios"
        Me.menuSisUsuarios.Size = New System.Drawing.Size(173, 24)
        Me.menuSisUsuarios.Text = "Usuários"
        '
        'Ajuda
        '
        Me.Ajuda.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ContentsToolStripMenuItem, Me.ToolStripSeparator8, Me.AboutToolStripMenuItem})
        Me.Ajuda.Name = "Ajuda"
        Me.Ajuda.Size = New System.Drawing.Size(60, 24)
        Me.Ajuda.Text = "&Ajuda"
        '
        'ContentsToolStripMenuItem
        '
        Me.ContentsToolStripMenuItem.Name = "ContentsToolStripMenuItem"
        Me.ContentsToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.F1), System.Windows.Forms.Keys)
        Me.ContentsToolStripMenuItem.Size = New System.Drawing.Size(184, 24)
        Me.ContentsToolStripMenuItem.Text = "Manual"
        '
        'ToolStripSeparator8
        '
        Me.ToolStripSeparator8.Name = "ToolStripSeparator8"
        Me.ToolStripSeparator8.Size = New System.Drawing.Size(181, 6)
        '
        'AboutToolStripMenuItem
        '
        Me.AboutToolStripMenuItem.Image = CType(resources.GetObject("AboutToolStripMenuItem.Image"), System.Drawing.Image)
        Me.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
        Me.AboutToolStripMenuItem.Size = New System.Drawing.Size(184, 24)
        Me.AboutToolStripMenuItem.Text = "Sobre ..."
        '
        'StatusStrip
        '
        Me.StatusStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel})
        Me.StatusStrip.Location = New System.Drawing.Point(0, 533)
        Me.StatusStrip.Name = "StatusStrip"
        Me.StatusStrip.Padding = New System.Windows.Forms.Padding(1, 0, 19, 0)
        Me.StatusStrip.Size = New System.Drawing.Size(933, 25)
        Me.StatusStrip.TabIndex = 7
        Me.StatusStrip.Text = "StatusStrip"
        '
        'ToolStripStatusLabel
        '
        Me.ToolStripStatusLabel.Name = "ToolStripStatusLabel"
        Me.ToolStripStatusLabel.Size = New System.Drawing.Size(49, 20)
        Me.ToolStripStatusLabel.Text = "Status"
        '
        'mdiPrincipal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(933, 558)
        Me.Controls.Add(Me.MenuStrip)
        Me.Controls.Add(Me.StatusStrip)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.IsMdiContainer = True
        Me.MainMenuStrip = Me.MenuStrip
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "mdiPrincipal"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "COLABORADORES"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.MenuStrip.ResumeLayout(False)
        Me.MenuStrip.PerformLayout()
        Me.StatusStrip.ResumeLayout(False)
        Me.StatusStrip.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ContentsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Ajuda As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator8 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents AboutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuRelatorios As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolTip As System.Windows.Forms.ToolTip
    Friend WithEvents ToolStripStatusLabel As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents StatusStrip As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents menuCadastro As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuStrip As System.Windows.Forms.MenuStrip
    Friend WithEvents menuSistema As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuProcessos As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuConsultas As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuSisConfiguracoes As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuSair As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuSisUsuarios As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuCadArmazens As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuCadTipodeProdutos As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents menuCadProdutos As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuCadTipodeMovimentos As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuCadEstruturadeProdutos As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuProcMovimentodeEstoque As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuProcAtualizaçãodeSaldo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuProcFechamentodeEstoque As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuProcIntegraçãoContábil As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuProcDigitaçãodoInventário As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuProcProcessaroinventário As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuConsSaldodoProduto As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuRelSaldodoProduto As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuRelContagemdoInventário As System.Windows.Forms.ToolStripMenuItem

End Class
