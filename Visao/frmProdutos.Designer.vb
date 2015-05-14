<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmProdutos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmProdutos))
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
        Me.txtDescricao = New System.Windows.Forms.TextBox()
        Me.txtCodigo = New System.Windows.Forms.TextBox()
        Me.lblDescricao = New System.Windows.Forms.Label()
        Me.lblCodigo = New System.Windows.Forms.Label()
        Me.lblstatus = New System.Windows.Forms.Label()
        Me.rgAtivo = New System.Windows.Forms.RadioButton()
        Me.rgInativo = New System.Windows.Forms.RadioButton()
        Me.lbldatacad = New System.Windows.Forms.Label()
        Me.dtpdatacad = New System.Windows.Forms.DateTimePicker()
        Me.lbltipodeproduto = New System.Windows.Forms.Label()
        Me.cbtipodeproduto = New System.Windows.Forms.ComboBox()
        Me.lblControlaEstoque = New System.Windows.Forms.Label()
        Me.lblarmazem = New System.Windows.Forms.Label()
        Me.cbarmazem = New System.Windows.Forms.ComboBox()
        Me.txtUsuarioCad = New System.Windows.Forms.TextBox()
        Me.lbldatault = New System.Windows.Forms.Label()
        Me.dtpdatault = New System.Windows.Forms.DateTimePicker()
        Me.lblUsucad = New System.Windows.Forms.Label()
        Me.lblultusuario = New System.Windows.Forms.Label()
        Me.txtUsuarioUlt = New System.Windows.Forms.TextBox()
        Me.cbSim = New System.Windows.Forms.CheckBox()
        Me.cbNao = New System.Windows.Forms.CheckBox()
        Me.lblcontacontabil = New System.Windows.Forms.Label()
        Me.txtcontacontabil = New System.Windows.Forms.TextBox()
        Me.ToolStrip1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
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
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 393)
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
        'txtDescricao
        '
        Me.txtDescricao.Location = New System.Drawing.Point(72, 233)
        Me.txtDescricao.MaxLength = 60
        Me.txtDescricao.Name = "txtDescricao"
        Me.txtDescricao.Size = New System.Drawing.Size(335, 20)
        Me.txtDescricao.TabIndex = 8
        '
        'txtCodigo
        '
        Me.txtCodigo.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtCodigo.Location = New System.Drawing.Point(62, 46)
        Me.txtCodigo.MaxLength = 6
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.Size = New System.Drawing.Size(63, 20)
        Me.txtCodigo.TabIndex = 1
        '
        'lblDescricao
        '
        Me.lblDescricao.AutoSize = True
        Me.lblDescricao.Location = New System.Drawing.Point(12, 235)
        Me.lblDescricao.Name = "lblDescricao"
        Me.lblDescricao.Size = New System.Drawing.Size(58, 13)
        Me.lblDescricao.TabIndex = 8
        Me.lblDescricao.Text = "Descrição:"
        '
        'lblCodigo
        '
        Me.lblCodigo.AutoSize = True
        Me.lblCodigo.Location = New System.Drawing.Point(13, 47)
        Me.lblCodigo.Name = "lblCodigo"
        Me.lblCodigo.Size = New System.Drawing.Size(43, 13)
        Me.lblCodigo.TabIndex = 1
        Me.lblCodigo.Text = "Código:"
        '
        'lblstatus
        '
        Me.lblstatus.AutoSize = True
        Me.lblstatus.Location = New System.Drawing.Point(12, 349)
        Me.lblstatus.Name = "lblstatus"
        Me.lblstatus.Size = New System.Drawing.Size(40, 13)
        Me.lblstatus.TabIndex = 11
        Me.lblstatus.Text = "Status:"
        '
        'rgAtivo
        '
        Me.rgAtivo.AutoSize = True
        Me.rgAtivo.Location = New System.Drawing.Point(57, 347)
        Me.rgAtivo.Name = "rgAtivo"
        Me.rgAtivo.Size = New System.Drawing.Size(49, 17)
        Me.rgAtivo.TabIndex = 11
        Me.rgAtivo.Text = "Ativo"
        Me.rgAtivo.UseVisualStyleBackColor = True
        '
        'rgInativo
        '
        Me.rgInativo.AutoSize = True
        Me.rgInativo.Location = New System.Drawing.Point(109, 347)
        Me.rgInativo.Name = "rgInativo"
        Me.rgInativo.Size = New System.Drawing.Size(57, 17)
        Me.rgInativo.TabIndex = 11
        Me.rgInativo.Text = "Inativo"
        Me.rgInativo.UseVisualStyleBackColor = True
        '
        'lbldatacad
        '
        Me.lbldatacad.AutoSize = True
        Me.lbldatacad.Location = New System.Drawing.Point(13, 87)
        Me.lbldatacad.Name = "lbldatacad"
        Me.lbldatacad.Size = New System.Drawing.Size(93, 13)
        Me.lbldatacad.TabIndex = 2
        Me.lbldatacad.Text = "Data do Cadastro:"
        '
        'dtpdatacad
        '
        Me.dtpdatacad.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpdatacad.Location = New System.Drawing.Point(108, 85)
        Me.dtpdatacad.MinDate = New Date(1800, 1, 1, 0, 0, 0, 0)
        Me.dtpdatacad.Name = "dtpdatacad"
        Me.dtpdatacad.Size = New System.Drawing.Size(94, 20)
        Me.dtpdatacad.TabIndex = 2
        '
        'lbltipodeproduto
        '
        Me.lbltipodeproduto.AutoSize = True
        Me.lbltipodeproduto.Location = New System.Drawing.Point(12, 201)
        Me.lbltipodeproduto.Name = "lbltipodeproduto"
        Me.lbltipodeproduto.Size = New System.Drawing.Size(86, 13)
        Me.lbltipodeproduto.TabIndex = 7
        Me.lbltipodeproduto.Text = "Tipo de Produto:"
        '
        'cbtipodeproduto
        '
        Me.cbtipodeproduto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbtipodeproduto.FormattingEnabled = True
        Me.cbtipodeproduto.Location = New System.Drawing.Point(104, 198)
        Me.cbtipodeproduto.Name = "cbtipodeproduto"
        Me.cbtipodeproduto.Size = New System.Drawing.Size(299, 21)
        Me.cbtipodeproduto.TabIndex = 7
        '
        'lblControlaEstoque
        '
        Me.lblControlaEstoque.AutoSize = True
        Me.lblControlaEstoque.Location = New System.Drawing.Point(12, 312)
        Me.lblControlaEstoque.Name = "lblControlaEstoque"
        Me.lblControlaEstoque.Size = New System.Drawing.Size(91, 13)
        Me.lblControlaEstoque.TabIndex = 10
        Me.lblControlaEstoque.Text = "Controla Estoque:"
        '
        'lblarmazem
        '
        Me.lblarmazem.AutoSize = True
        Me.lblarmazem.Location = New System.Drawing.Point(12, 164)
        Me.lblarmazem.Name = "lblarmazem"
        Me.lblarmazem.Size = New System.Drawing.Size(53, 13)
        Me.lblarmazem.TabIndex = 6
        Me.lblarmazem.Text = "Armazém:"
        '
        'cbarmazem
        '
        Me.cbarmazem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbarmazem.FormattingEnabled = True
        Me.cbarmazem.Location = New System.Drawing.Point(71, 161)
        Me.cbarmazem.Name = "cbarmazem"
        Me.cbarmazem.Size = New System.Drawing.Size(332, 21)
        Me.cbarmazem.TabIndex = 6
        '
        'txtUsuarioCad
        '
        Me.txtUsuarioCad.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower
        Me.txtUsuarioCad.Location = New System.Drawing.Point(320, 85)
        Me.txtUsuarioCad.MaxLength = 100
        Me.txtUsuarioCad.Name = "txtUsuarioCad"
        Me.txtUsuarioCad.Size = New System.Drawing.Size(148, 20)
        Me.txtUsuarioCad.TabIndex = 3
        '
        'lbldatault
        '
        Me.lbldatault.AutoSize = True
        Me.lbldatault.Location = New System.Drawing.Point(13, 127)
        Me.lbldatault.Name = "lbldatault"
        Me.lbldatault.Size = New System.Drawing.Size(87, 13)
        Me.lbldatault.TabIndex = 4
        Me.lbldatault.Text = "Última Alteração:"
        '
        'dtpdatault
        '
        Me.dtpdatault.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpdatault.Location = New System.Drawing.Point(110, 125)
        Me.dtpdatault.MinDate = New Date(1800, 1, 1, 0, 0, 0, 0)
        Me.dtpdatault.Name = "dtpdatault"
        Me.dtpdatault.Size = New System.Drawing.Size(94, 20)
        Me.dtpdatault.TabIndex = 4
        '
        'lblUsucad
        '
        Me.lblUsucad.AutoSize = True
        Me.lblUsucad.Location = New System.Drawing.Point(229, 87)
        Me.lblUsucad.Name = "lblUsucad"
        Me.lblUsucad.Size = New System.Drawing.Size(91, 13)
        Me.lblUsucad.TabIndex = 3
        Me.lblUsucad.Text = "Cadastro Usuário:"
        '
        'lblultusuario
        '
        Me.lblultusuario.AutoSize = True
        Me.lblultusuario.Location = New System.Drawing.Point(229, 127)
        Me.lblultusuario.Name = "lblultusuario"
        Me.lblultusuario.Size = New System.Drawing.Size(78, 13)
        Me.lblultusuario.TabIndex = 5
        Me.lblultusuario.Text = "Último Usuário:"
        '
        'txtUsuarioUlt
        '
        Me.txtUsuarioUlt.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower
        Me.txtUsuarioUlt.Location = New System.Drawing.Point(320, 124)
        Me.txtUsuarioUlt.MaxLength = 100
        Me.txtUsuarioUlt.Name = "txtUsuarioUlt"
        Me.txtUsuarioUlt.Size = New System.Drawing.Size(148, 20)
        Me.txtUsuarioUlt.TabIndex = 5
        '
        'cbSim
        '
        Me.cbSim.AutoSize = True
        Me.cbSim.Location = New System.Drawing.Point(109, 311)
        Me.cbSim.Name = "cbSim"
        Me.cbSim.Size = New System.Drawing.Size(43, 17)
        Me.cbSim.TabIndex = 10
        Me.cbSim.Text = "Sim"
        Me.cbSim.UseVisualStyleBackColor = True
        '
        'cbNao
        '
        Me.cbNao.AutoSize = True
        Me.cbNao.Location = New System.Drawing.Point(158, 311)
        Me.cbNao.Name = "cbNao"
        Me.cbNao.Size = New System.Drawing.Size(46, 17)
        Me.cbNao.TabIndex = 10
        Me.cbNao.Text = "Não"
        Me.cbNao.UseVisualStyleBackColor = True
        '
        'lblcontacontabil
        '
        Me.lblcontacontabil.AutoSize = True
        Me.lblcontacontabil.Location = New System.Drawing.Point(12, 275)
        Me.lblcontacontabil.Name = "lblcontacontabil"
        Me.lblcontacontabil.Size = New System.Drawing.Size(82, 13)
        Me.lblcontacontabil.TabIndex = 9
        Me.lblcontacontabil.Text = "Conta Contábil::"
        '
        'txtcontacontabil
        '
        Me.txtcontacontabil.Location = New System.Drawing.Point(92, 273)
        Me.txtcontacontabil.MaxLength = 12
        Me.txtcontacontabil.Name = "txtcontacontabil"
        Me.txtcontacontabil.Size = New System.Drawing.Size(193, 20)
        Me.txtcontacontabil.TabIndex = 9
        '
        'frmProdutos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(730, 415)
        Me.Controls.Add(Me.txtcontacontabil)
        Me.Controls.Add(Me.lblcontacontabil)
        Me.Controls.Add(Me.cbNao)
        Me.Controls.Add(Me.cbSim)
        Me.Controls.Add(Me.txtUsuarioUlt)
        Me.Controls.Add(Me.lblultusuario)
        Me.Controls.Add(Me.lblUsucad)
        Me.Controls.Add(Me.dtpdatault)
        Me.Controls.Add(Me.lbldatault)
        Me.Controls.Add(Me.txtUsuarioCad)
        Me.Controls.Add(Me.cbarmazem)
        Me.Controls.Add(Me.lblarmazem)
        Me.Controls.Add(Me.lblControlaEstoque)
        Me.Controls.Add(Me.cbtipodeproduto)
        Me.Controls.Add(Me.lbltipodeproduto)
        Me.Controls.Add(Me.dtpdatacad)
        Me.Controls.Add(Me.lbldatacad)
        Me.Controls.Add(Me.rgInativo)
        Me.Controls.Add(Me.rgAtivo)
        Me.Controls.Add(Me.lblstatus)
        Me.Controls.Add(Me.txtDescricao)
        Me.Controls.Add(Me.txtCodigo)
        Me.Controls.Add(Me.lblDescricao)
        Me.Controls.Add(Me.lblCodigo)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "frmProdutos"
        Me.Text = "Produtos "
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
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
    Friend WithEvents txtDescricao As System.Windows.Forms.TextBox
    Friend WithEvents txtCodigo As System.Windows.Forms.TextBox
    Friend WithEvents lblDescricao As System.Windows.Forms.Label
    Friend WithEvents lblCodigo As System.Windows.Forms.Label
    Friend WithEvents lblstatus As System.Windows.Forms.Label
    Friend WithEvents rgAtivo As System.Windows.Forms.RadioButton
    Friend WithEvents rgInativo As System.Windows.Forms.RadioButton
    Friend WithEvents lbldatacad As System.Windows.Forms.Label
    Friend WithEvents dtpdatacad As System.Windows.Forms.DateTimePicker
    Friend WithEvents lbltipodeproduto As System.Windows.Forms.Label
    Friend WithEvents cbtipodeproduto As System.Windows.Forms.ComboBox
    Friend WithEvents lblControlaEstoque As System.Windows.Forms.Label
    Friend WithEvents lblarmazem As System.Windows.Forms.Label
    Friend WithEvents cbarmazem As System.Windows.Forms.ComboBox
    Friend WithEvents txtUsuarioCad As System.Windows.Forms.TextBox
    Friend WithEvents lbldatault As System.Windows.Forms.Label
    Friend WithEvents dtpdatault As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblUsucad As System.Windows.Forms.Label
    Friend WithEvents lblultusuario As System.Windows.Forms.Label
    Friend WithEvents txtUsuarioUlt As System.Windows.Forms.TextBox
    Friend WithEvents cbSim As System.Windows.Forms.CheckBox
    Friend WithEvents cbNao As System.Windows.Forms.CheckBox
    Friend WithEvents lblcontacontabil As System.Windows.Forms.Label
    Friend WithEvents txtcontacontabil As System.Windows.Forms.TextBox
End Class
