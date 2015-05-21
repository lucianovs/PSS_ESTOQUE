Imports System.Data.OleDb
Imports System.Drawing.Printing

Public Class frmEstruturadeProdutos
    '?? Alterar para a Entidade Principal ??
    Dim dt As DataTable = New DataTable("EES004")
    Dim dtprodutos As DataTable = New DataTable("EES000") ' Tabela de Produtos
    Dim dtconsulta As DataTable = New DataTable("EES000")
    Dim dtGridprod As DataTable = New DataTable("EES004")

    Dim i As Integer
    Dim bAlterar As Boolean = False
    Dim bIncluir As Boolean = False
    Dim cQuery As String
    Dim Codigook As Boolean = True
    Dim pesq_cod_generico As String
    Dim opcao_sel As String
    Dim cMensagem As String = ""



    Private Sub TratarObjetos()

        '  tssContReg.Text = "Registro " & (i + 1).ToString & "/" & dt.Rows.Count().ToString
        tssContReg.Text = "Total de Produtos: " & Format(dtGridprod.Rows.Count, "###0")

        'Botoes da Barra de comandos
        btnIncluir.Enabled = Not bAlterar And Me.Tag = 4 'And Me.Tag > 1
        btnAlterar.Enabled = Not bAlterar 'And Me.Tag > 1
        btnExcluir.Enabled = Not bAlterar And Me.Tag = 4
        btnGravar.Enabled = bAlterar
        btnCancelar.Enabled = bAlterar
        btnAnterior.Enabled = Not bAlterar
        btnProximo.Enabled = Not bAlterar
        btnLocalizar.Enabled = Not bAlterar
        btnImprimir.Enabled = Not bAlterar
        btnIncluirsubproduto.Enabled = bAlterar
        btncancelarsubprodutos.Enabled = bAlterar

        'Campos
        '?? Alterar para os seus objetos da Tela ??
        If bIncluir = True Then
            lblCodigo.Enabled = True
            txtCodigo.Enabled = True
            txtDescricao.Enabled = True
        Else
            lblCodigo.Enabled = False
            txtCodigo.Enabled = False
            txtDescricao.Enabled = False
        End If
        ComandoPesquisar.Enabled = bAlterar
        comandoPesquisarsubpruduto.Enabled = bAlterar


        txtCodigosubproduto.Enabled = bAlterar
        txtdescricaosubproduto.Enabled = bAlterar
        txtquantidade.Enabled = bAlterar
        dgvProdutos.Enabled = bAlterar

        'Outros Controles
        '*****************


        'Preencher Campos
        If i > -1 And Not bIncluir Then
            txtCodigo.Text = dt.Rows(i).Item("ES004_CODPRO")
            txtDescricao.Text = LerDescricao_Produto(dt.Rows(i).Item("ES004_CODPRO"))

            'Outros Controles
            '****************
        End If

        'Outras Chamadas
        '***************
        If dgvProdutos.ColumnCount = 0 Then CarregarGrid()


        'Verificar se é para excluir o registro comandado pelo browse
        If g_Comando = "excluir" Then
            Call Excluir_Registro()
        End If


    End Sub

    Private Sub btnProximo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProximo.Click

        i += 1
        If Not i = dt.Rows.Count() Then
            Call TratarObjetos()
        Else
            i = dt.Rows.Count() - 1
        End If

    End Sub

    Private Sub btnAnterior_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAnterior.Click

        i -= 1
        If Not i < 0 Then
            Call TratarObjetos()
        Else
            i = 0
        End If


    End Sub

    Private Sub btnAlterar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAlterar.Click
        g_Comando = "alterar"
        bAlterar = True
        bIncluir = False
        Call TratarObjetos()
        btnIncluirsubproduto.Text = "Alterar"
        btnIncluirsubproduto.Enabled = False

        txtCodigosubproduto.Enabled = False
        comandoPesquisarsubpruduto.Enabled = False
        txtdescricaosubproduto.Enabled = False
        txtquantidade.Enabled = False
        dgvProdutos.Focus()
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click

        If g_Comando = "incluir" Or g_Comando = "alterar" Then
            dt.Clear()
            Me.Close()
        Else
            bAlterar = False
            bIncluir = False
            TratarObjetos()
        End If

    End Sub

    Private Sub btnIncluir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnIncluir.Click
        bAlterar = True
        bIncluir = True

        'Inicializar os seus Componentes de Entrada de Dados
        txtCodigo.Text = ""
        txtDescricao.Text = ""

        Call TratarObjetos()
        txtCodigo.Focus()
    End Sub

    Private Sub btnGravar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGravar.Click
        Dim cSql As String = ""
        Dim cmd As OleDbCommand
        'Dim nProxCod_Registro As Integer
        Dim statusativoinativo As String = "A"
        Dim nlingrid As Integer


        If ConectarBanco() Then
            '?? Colocar o Comando SQL para Gravar (Update e Insert)

            If Validardados(cMensagem) And Codigook = True Then
                If bIncluir Then

                    If dgvProdutos.Rows.Count > 0 Then
                        For nlingrid = 0 To dgvProdutos.Rows.Count() - 1
                            cSql = "INSERT INTO EES004 (ES004_CODPRO, ES004_SUBPRO, ES004_QTDPRO, ES004_SITCAD)"
                            cSql += " values ('" & txtCodigo.Text & "', '" & dgvProdutos.Rows(nlingrid).Cells(2).Value & "',  " & dgvProdutos.Rows(nlingrid).Cells(4).Value & ", '" & statusativoinativo & "')"
                            cmd = New OleDbCommand(cSql, g_ConnectBanco)
                            Try
                                cmd.ExecuteNonQuery()
                            Catch ex As Exception
                                MsgBox(ex.ToString())
                            End Try
                        Next
                    End If

                ElseIf bAlterar Then
                    'Checar se o staus esta ativo ou inativo
                    If dgvProdutos.Rows.Count > 0 Then
                        For nlingrid = 0 To dgvProdutos.Rows.Count() - 1
                            cSql = "UPDATE EES004 set ES004_SUBPRO='" & dgvProdutos.Rows(nlingrid).Cells(2).Value & _
                                    "', ES004_QTDPRO =" & dgvProdutos.Rows(nlingrid).Cells(4).Value & _
                                    " where ES004_CODPRO = '" & txtCodigo.Text & "'" & _
                                    "AND ES004_SUBPRO = '" & dgvProdutos.Rows(nlingrid).Cells(2).Value & "'"
                            cmd = New OleDbCommand(cSql, g_ConnectBanco)
                            Try
                                cmd.ExecuteNonQuery()
                            Catch ex As Exception
                                MsgBox(ex.ToString())
                            End Try
                        Next
                    End If
                    g_Comando = "ver"
                End If

                bIncluir = False
                bAlterar = False

                If g_Param(1) = "INSERT" Then
                    dt.Clear()
                    'fechar o form de cadastro
                    Me.Close()
                Else
                    dt.Reset()
                    Using da As New OleDbDataAdapter()
                        da.SelectCommand = New OleDbCommand(cQuery, g_ConnectBanco)

                        ' Preencher o DataTable 
                        da.Fill(dt)
                    End Using

                    'Verificar se o comando veio do browse
                    If g_Comando = "inserir" Or g_Comando = "alterar" Then
                        dt.Clear()
                        Me.Close()
                    Else
                        'i = dt.Rows.Count()
                        TratarObjetos()
                    End If

                End If
            Else
                If Trim(cMensagem) <> "" Then MsgBox(cMensagem)
            End If
        End If

    End Sub

    Private Function Validardados(ByRef cMensagem As String) As Boolean
        Dim bRetorno As Boolean = True

        '?? Acrescentar as validações da Tela ??
        If Trim(txtCodigo.Text) = "" Then
            cMensagem += " <O código produto não pode estar vazio> "
            bRetorno = False
        End If

        If Trim(txtDescricao.Text) = "" Then
            cMensagem += " <A descrição produto não pode estar vazia> "
            bRetorno = False
        End If

        If dgvProdutos.ColumnCount = 0 Then
            cMensagem += " <Grid de produtos não pode estar vazio> "
            bRetorno = False
        End If
        Return (bRetorno)

    End Function

    Private Sub btnExcluir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExcluir.Click

        Call Excluir_Registro()

    End Sub
    'Verificar_Codigo do sub produto se já existe registro salvo na tabela EES004
    Private Sub Verificar_Codigo_Subproduto_TabEES004()
        Dim reg_encontrado As Integer
        Dim i_point As Integer
        Dim icont As Integer

        reg_encontrado = 0
        If Trim(txtCodigosubproduto.Text <> "") Then
            cQuery = "SELECT * FROM EES004 where ES004_SUBPRO = '" & Trim(txtCodigosubproduto.Text) & "'"

            '   cQuery = "SELECT * FROM EES004 where ES004_CODPRO = '" & Trim(txtCodigo.Text) & "' AND " & _
            '      "ES004_SUBPRO='" & Trim(txtCodigosubproduto.Text) & "'"

        End If

        Using daconsulta As New OleDbDataAdapter()
            daconsulta.SelectCommand = New OleDbCommand(cQuery, g_ConnectBanco)

            ' Preencher o DataTable 
            daconsulta.Fill(dtconsulta)
        End Using

        'Verificar_Codigo se já existe registro salvo na tabela EES004
        If dtconsulta.Rows.Count > 0 Then
            For icont = 0 To dtconsulta.Rows.Count() - 1
                If dtconsulta.Rows(icont).Item("ES004_SUBPRO").ToString = Trim(txtCodigosubproduto.Text) Then
                    reg_encontrado = reg_encontrado + 1
                    Exit For
                End If
            Next

        End If

        If reg_encontrado > 0 Then
            txtCodigosubproduto.Text = ""
            MsgBox("<Código do sub produto já cadastrado, digite outro!>")
            Codigook = False
            txtCodigosubproduto.Focus()
        Else
            Codigook = True '
            If Me.Tag = 4 Then
                cQuery = "SELECT * FROM EES004"
            Else
                cQuery = "SELECT * FROM EES004 where ES004_CODPRO = " & g_Param(1)
            End If

            dt.Reset()
            Using da As New OleDbDataAdapter()
                da.SelectCommand = New OleDbCommand(cQuery, g_ConnectBanco)

                ' Preencher o DataTable 
                da.Fill(dt)
            End Using
            If g_Param(1) <> "INSERT" Then
                'Posicionar no registro selecionado
                '?? Alterar para localizar a chave da tabela ??
                For i_point = 0 To dt.Rows.Count() - 1
                    If dt.Rows(i_point).Item("ES004_CODPRO").ToString = g_Param(1) Then
                        Exit For
                    End If
                Next
                i = i_point
            End If
        End If
    End Sub

    'Verificar_Codigo se já existe registro salvo na tabela EES000
    Private Sub Verificar_Codigo_TabEES000()
        Dim reg_encontrado As Integer
        Dim i_point As Integer
        Dim icont As Integer

        reg_encontrado = 0
        If pesq_cod_generico = "ES000_CODPRO" Then
            If Trim(txtCodigo.Text <> "") Then
                cQuery = "SELECT * FROM EES000 where ES000_CODPRO = '" & Trim(txtCodigo.Text) & "'"
            End If
        End If

        If pesq_cod_generico = "ES004_SUBPRO" Then
            If Trim(txtCodigosubproduto.Text <> "") Then
                cQuery = "SELECT * FROM EES000 where ES000_CODPRO = '" & Trim(txtCodigosubproduto.Text) & "'"
            End If
        End If


        Using daconsulta As New OleDbDataAdapter()
            daconsulta.SelectCommand = New OleDbCommand(cQuery, g_ConnectBanco)

            ' Preencher o DataTable 
            daconsulta.Fill(dtconsulta)
        End Using

        'Verificar_Codigo se já existe registro salvo na tabela EES004
        If dtconsulta.Rows.Count > 0 Then
            For icont = 0 To dtconsulta.Rows.Count() - 1
                If pesq_cod_generico = "ES000_CODPRO" Then
                    If dtconsulta.Rows(icont).Item("ES000_CODPRO").ToString = Trim(txtCodigo.Text) Then
                        txtCodigo.Text = dtconsulta.Rows(icont).Item("ES000_CODPRO").ToString
                        txtDescricao.Text = dtconsulta.Rows(icont).Item("ES000_DESPRO").ToString
                        reg_encontrado = reg_encontrado + 1
                        Exit For
                    End If

                End If ' verifica codigo produto "ES004_SUBPRO"
                If pesq_cod_generico = "ES004_SUBPRO" Then
                    If dtconsulta.Rows(icont).Item("ES000_CODPRO").ToString = Trim(txtCodigosubproduto.Text) Then
                        txtCodigosubproduto.Text = dtconsulta.Rows(icont).Item("ES000_CODPRO").ToString
                        txtdescricaosubproduto.Text = dtconsulta.Rows(icont).Item("ES000_DESPRO").ToString
                        reg_encontrado = reg_encontrado + 1
                        Exit For
                    End If
                End If ' verifica codigo produto "ES004_SUBPRO"


            Next

        End If

        If reg_encontrado = 0 Then
            If pesq_cod_generico = "ES000_CODPRO" Then
                txtCodigo.Text = ""
                txtDescricao.Text = ""
                MsgBox("<Código do produto não cadastrado, digite outro!>")
                Codigook = False
                txtCodigo.Focus()
            End If
            If pesq_cod_generico = "ES004_SUBPRO" Then
                txtCodigosubproduto.Text = ""
                txtdescricaosubproduto.Text = ""
                MsgBox("<Código do sub produto inválido, digite outro!>")
                Codigook = False
                txtCodigosubproduto.Focus()
            End If


        Else
            Codigook = True '
            If Me.Tag = 4 Then
                cQuery = "SELECT * FROM EES004"
            Else
                cQuery = "SELECT * FROM EES004 where ES004_CODPRO = " & g_Param(1)
            End If

            dt.Reset()
            Using da As New OleDbDataAdapter()
                da.SelectCommand = New OleDbCommand(cQuery, g_ConnectBanco)

                ' Preencher o DataTable 
                da.Fill(dt)
            End Using
            If g_Param(1) <> "INSERT" Then
                'Posicionar no registro selecionado
                '?? Alterar para localizar a chave da tabela ??
                For i_point = 0 To dt.Rows.Count() - 1
                    If dt.Rows(i_point).Item("ES004_CODPRO").ToString = g_Param(1) Then
                        Exit For
                    End If
                Next
                i = i_point
            End If
        End If

    End Sub

    ' Verificar Código na tabela EES004
    Private Sub Verificar_Codigo_TabEES004()

        Dim reg_encontrado As Integer
        Dim i_point As Integer
        Dim icont As Integer

        reg_encontrado = 0
        If Trim(txtCodigo.Text <> "") Then
            cQuery = "SELECT * FROM EES004 where ES004_CODPRO = '" & Trim(txtCodigo.Text) & "'"
        End If

        Using daconsulta As New OleDbDataAdapter()
            daconsulta.SelectCommand = New OleDbCommand(cQuery, g_ConnectBanco)

            ' Preencher o DataTable 
            daconsulta.Fill(dtconsulta)
        End Using

        'Verificar_Codigo se já existe registro salvo na tabela EES004
        If dtconsulta.Rows.Count > 0 Then
            For icont = 0 To dtconsulta.Rows.Count() - 1
                If dtconsulta.Rows(icont).Item("ES004_CODPRO").ToString = Trim(txtCodigo.Text) Then
                    reg_encontrado = reg_encontrado + 1
                    Exit For
                End If
            Next

        End If

        If reg_encontrado > 0 Then
            txtCodigo.Text = ""
            txtDescricao.Text = ""
            MsgBox("<Código do produto já cadastrado, digite outro!>")
            Codigook = False
            txtCodigo.Focus()
        Else
            Codigook = True '
            If Me.Tag = 4 Then
                cQuery = "SELECT * FROM EES004"
            Else
                cQuery = "SELECT * FROM EES004 where ES004_CODPRO = " & g_Param(1)
            End If

            dt.Reset()
            Using da As New OleDbDataAdapter()
                da.SelectCommand = New OleDbCommand(cQuery, g_ConnectBanco)

                ' Preencher o DataTable 
                da.Fill(dt)
            End Using
            If g_Param(1) <> "INSERT" Then
                'Posicionar no registro selecionado
                '?? Alterar para localizar a chave da tabela ??
                For i_point = 0 To dt.Rows.Count() - 1
                    If dt.Rows(i_point).Item("ES004_CODPRO").ToString = g_Param(1) Then
                        Exit For
                    End If
                Next
                i = i_point
            End If
        End If


    End Sub

    Private Sub Excluir_Registro()
        Dim cSql As String
        Dim cMensagem As String = ""
        Dim cmd As OleDbCommand

        If MsgBox("Deseja excluir este registro?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Estrutura de Produtos") = MsgBoxResult.Yes Then
            '?? Alterar para a Tabela a ser Excluída ??
            cSql = "DELETE FROM EES004 where ES004_CODPRO = '" & Trim(txtCodigo.Text) & "'"
            cmd = New OleDbCommand(cSql, g_ConnectBanco)

            Try
                cmd.ExecuteNonQuery()
            Catch ex As Exception
                MsgBox(ex.ToString())
            Finally

                dt.Reset()
                Using da As New OleDbDataAdapter()
                    da.SelectCommand = New OleDbCommand(cQuery, g_ConnectBanco)

                    'Preencher o DataTable 
                    da.Fill(dt)
                End Using

                If i > dt.Rows.Count() - 1 Then
                    i = dt.Rows.Count() - 1
                End If

                'Verificar se o comando veio do browse
                If g_Comando = "excluir" Or dt.Rows.Count() = 0 Then
                    dt.Clear() 'Limpar o DataTable
                    Me.Close()
                Else
                    TratarObjetos()
                End If

            End Try

        Else
            If g_Comando_auxiliar = "excluir_voltar_browse" Then
                dt.Clear() 'Limpar o DataTable
                g_Comando_auxiliar = ""
                Me.Close()
            End If
            'MsgBox(cMensagem)
        End If
    End Sub

    Private Sub btnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click
        'MsgBox("Opção Imprimir não esta pronta. Por favor aguarde...")
        'cria um novo documento para impressão
        Dim pd As PrintDocument = New PrintDocument()

        'relaciona o objeto pd ao procedimento rptProdutos
        AddHandler pd.PrintPage, AddressOf Me.rptFormulario

        'cria uma nova instância do objeto PrintPreviewDialog()
        Dim objPrintPreview = New PrintPreviewDialog()

        'define algumas propriedades do obejto
        With objPrintPreview
            'indica qual o documento vai ser visualizado
            .Document = pd
            .WindowState = FormWindowState.Maximized
            .PrintPreviewControl.Zoom = 1   'maxima a visualização
            .Text = Me.Text
            'exibe a janela de visualização para o usuário
            .ShowDialog()
        End With

    End Sub

    Private Sub rptFormulario(ByVal sender As Object, ByVal Relatorio As System.Drawing.Printing.PrintPageEventArgs)
        Dim FormControl As Control
        Dim FormListBox As ListBox
        Dim pLinhaList As String

        Dim LinhasPorPagina As Integer
        Dim LinhaAdic As Integer
        Dim posicaoDaLinha As Integer
        Dim y As Integer

        Dim margemEsq As Single = Relatorio.MarginBounds.Left
        Dim margemSup As Single = Relatorio.MarginBounds.Top
        Dim margemDir As Single = Relatorio.MarginBounds.Right
        Dim margemInf As Single = Relatorio.MarginBounds.Bottom

        Dim fonteTitulo As Font
        Dim fonteRodape As Font
        Dim fonteNormal As Font

        fonteTitulo = New Font("Verdana", 15, FontStyle.Bold)
        fonteRodape = New Font("Verdana", 8)
        fonteNormal = New Font("Verdana", 10)

        LinhasPorPagina = Relatorio.MarginBounds.Height / fonteNormal.GetHeight(Relatorio.Graphics) - 10

        margemEsq = 5
        'Imprimir o Cabeçalho
        Relatorio.Graphics.DrawLine(Pens.Black, margemEsq, 40, margemDir, 40)
        Relatorio.Graphics.DrawImage(Image.FromFile("logo.png"), 10, 48)
        Relatorio.Graphics.DrawString(Me.Text, fonteTitulo, Brushes.Blue, margemEsq + 275, 80, New StringFormat())
        Relatorio.Graphics.DrawLine(Pens.Black, margemEsq, 145, margemDir, 145)
        LinhaAdic = 2

        For Each FormControl In Me.Controls
            If (TypeOf FormControl Is Label) Then
                posicaoDaLinha = margemSup + (((FormControl.TabIndex * 2) + LinhaAdic) * fonteNormal.GetHeight(Relatorio.Graphics))
                Relatorio.Graphics.DrawString(FormControl.Text, fonteNormal, Brushes.Black, margemEsq, posicaoDaLinha, New StringFormat())
            ElseIf (TypeOf FormControl Is TextBox) Or (TypeOf FormControl Is ComboBox) Then
                posicaoDaLinha = margemSup + (((FormControl.TabIndex * 2) + LinhaAdic) * fonteNormal.GetHeight(Relatorio.Graphics))
                Relatorio.Graphics.DrawString(FormControl.Text, fonteNormal, Brushes.Black, margemEsq + 150, posicaoDaLinha, New StringFormat())
            ElseIf (TypeOf FormControl Is DateTimePicker) Then
                posicaoDaLinha = margemSup + (((FormControl.TabIndex * 2) + LinhaAdic) * fonteNormal.GetHeight(Relatorio.Graphics))
                Relatorio.Graphics.DrawString(FormControl.Text, fonteNormal, Brushes.Black, margemEsq + 150, posicaoDaLinha, New StringFormat())
            ElseIf (TypeOf FormControl Is ListBox) Then
                FormListBox = FormControl
                posicaoDaLinha = margemSup + (((FormListBox.TabIndex * 2) + LinhaAdic) * fonteNormal.GetHeight(Relatorio.Graphics))
                pLinhaList = ""
                For y = 0 To FormListBox.Items.Count - 1
                    If Trim(FormListBox.Items(y).ToString) = "" Then Exit For
                    pLinhaList += "(" & FormListBox.Items(y).ToString & ") "
                Next
                Relatorio.Graphics.DrawString(pLinhaList, fonteNormal, Brushes.Black, margemEsq + 150, posicaoDaLinha, New StringFormat())
            End If
        Next

        'imprime o rodape no relatorio
        Relatorio.Graphics.DrawLine(Pens.Black, margemEsq, margemInf, margemDir, margemInf)
        Relatorio.Graphics.DrawString(System.DateTime.Now, fonteRodape, Brushes.Black, margemEsq, margemInf, New StringFormat())
        Relatorio.Graphics.DrawString("Formulário", fonteRodape, Brushes.Black, margemDir - 50, margemInf, New StringFormat())

        Relatorio.HasMorePages = False

    End Sub

    Private Sub btnLocalizar_Click(sender As Object, e As EventArgs) Handles btnLocalizar.Click
        dt.Clear() 'Limpar o DataTable

        Me.Close()
    End Sub

    Private Sub frmArmazens_FormClosing(sender As Object, e As FormClosingEventArgs)

    End Sub
    Private Sub ComandoPesquisar_Click(sender As Object, e As EventArgs) Handles ComandoPesquisar.Click
        Dim options = New dlgPesquisa

        'Tabela que sera usada na pesquisa
        g_PequisaGenerica = "EES000"
        pesq_coddif = ""

        If bIncluir Then
            If options.ShowDialog() = Windows.Forms.DialogResult.OK Then
                txtCodigo.Text = Microsoft.VisualBasic.Left(options.txtPesquisa.Text, 6)
                txtDescricao.Text = LerDescricao_Produto(Microsoft.VisualBasic.Left(options.txtPesquisa.Text, 6))
                opcao_sel = "Ok"
            Else
                opcao_sel = "Cancel"
            End If

            If opcao_sel = "Cancel" Then
                txtCodigo.Text = ""
                txtCodigo.Focus()
            Else
                If txtCodigo.Text <> "" Then
                    If txtCodigo.Text.Length < 6 Then
                        txtCodigo.Text = String.Format("{0:000000}", Convert.ToInt32(txtCodigo.Text))
                    End If

                    Call Verificar_Codigo_TabEES004()
                    If Codigook = True Then
                        Call Verificar_Codigo_TabEES000()
                        If Codigook = True Then
                            ' Inicializando Grid
                            If dgvProdutos.ColumnCount > 0 Then
                                Call LimparGrid()
                            End If
                            PCabecalho.Enabled = False
                            TabControle.Visible = True
                            If dgvProdutos.ColumnCount = 0 Then
                                'Montar Grid
                                Call MontarGrid()
                            End If
                            txtCodigosubproduto.Focus()
                        End If
                    End If
                End If
            End If
        End If

    End Sub

    Private Sub LimparTabControle()
        txtCodigosubproduto.Text = ""
        txtdescricaosubproduto.Text = ""
        txtquantidade.Text = ""
        dgvProdutos.DataSource = Nothing
    End Sub

    Private Sub MontarGrid()

        dgvProdutos.DataSource = Nothing

        dgvProdutos.Columns.Add("0", "Cód. produto")
        dgvProdutos.Columns.Add("1", "Descrição produto")
        dgvProdutos.Columns.Add("2", "Cód. sub produto")
        dgvProdutos.Columns.Add("3", "Descrição sub produto")
        dgvProdutos.Columns.Add("4", "Quantidade")

        dgvProdutos.Columns(0).Width = 100
        dgvProdutos.Columns(1).Width = 150
        dgvProdutos.Columns(2).Width = 120
        dgvProdutos.Columns(3).Width = 150
        dgvProdutos.Columns(4).Width = 70

    End Sub

    Private Sub CarregarGrid()
        Dim colx As Integer
        Dim increg As Integer

        dgvProdutos.DataSource = Nothing
        dtGridprod.Clear()
        dtGridprod.Reset()

        cQuery = "SELECT EES004.ES004_CODPRO AS ES004_CODPRO, EES000.ES000_DESPRO AS ES000_DESPRO, EES004.ES004_SUBPRO AS ES004_SUBPRO, " & _
     "EES000_1.ES000_DESPRO AS ES004_DESPRO, EES004.ES004_QTDPRO AS ES004_QTDPRO " & _
     "FROM (EES004 INNER JOIN EES000 ON EES004.ES004_CODPRO = EES000.ES000_CODPRO) INNER JOIN EES000 AS EES000_1 ON EES004.ES004_SUBPRO = EES000_1.ES000_CODPRO" & _
     " WHERE EES004.ES004_CODPRO='" & Trim(txtCodigo.Text) & "'" & _
     " ORDER BY EES004.ES004_SUBPRO"

        If bIncluir = False Then
            PCabecalho.Enabled = False
            TabControle.Visible = True
        End If


        Using da As New OleDbDataAdapter()
            da.SelectCommand = New OleDbCommand(cQuery, g_ConnectBanco)
            ' Preencher o DataTable  
            da.Fill(dtGridprod)
        End Using

        If dgvProdutos.ColumnCount = 0 Then
            Call LimparTabControle()
            'Montar Grid
            Call MontarGrid()
        End If

        '  If dgvProdutos.ColumnCount = 0 Then
        ''Montar Grid
        '    Call MontarGrid()
        '     End If

        increg = 0
        If dtGridprod.Rows.Count > 0 Then
            For colx = 0 To dtGridprod.Rows.Count() - 1
                Me.dgvProdutos.Rows.Insert(increg, dtGridprod.Rows(colx).Item("ES004_CODPRO").ToString, dtGridprod.Rows(colx).Item("ES000_DESPRO").ToString, dtGridprod.Rows(colx).Item("ES004_SUBPRO").ToString, dtGridprod.Rows(colx).Item("ES004_DESPRO").ToString, dtGridprod.Rows(colx).Item("ES004_QTDPRO").ToString)
                increg = increg + 1
            Next
        End If


        tssContReg.Text = "Total de Produtos: " & Format(dgvProdutos.RowCount, "###0")
    End Sub
    Private Sub LimparGrid()
        Dim colx As Integer = 0
        Dim contcolx As Integer = 0
        ' Limpar campos
        txtCodigosubproduto.Text = ""
        txtdescricaosubproduto.Text = ""
        txtquantidade.Text = ""

        'Limpar toda Grid
        For contcolx = dgvProdutos.Columns.Count - 1 To colx Step -1
            dgvProdutos.Columns.Remove(dgvProdutos.Columns(colx).Name)
        Next
    End Sub
    Private Sub btnIncluirsubproduto_Click(sender As Object, e As EventArgs) Handles btnIncluirsubproduto.Click
        Dim increg As Integer
        Dim nlinhasgrid As Integer

        If Validardados(cMensagem) And Codigook = True Then

            If txtCodigosubproduto.Text.Length < 6 Then
                txtCodigosubproduto.Text = String.Format("{0:000000}", Convert.ToInt32(txtCodigosubproduto.Text))
            End If

            If txtdescricaosubproduto.Text = "" Then
                txtdescricaosubproduto.Text = LerDescricao_Produto(txtCodigosubproduto.Text)
            End If

            If txtquantidade.Text = "" Then
                MsgBox("<Quantidade do sub produto esta vazia!>")
                txtquantidade.Focus()
            End If

            If dgvProdutos.ColumnCount = 0 Then
                'Montar Grid
                Call MontarGrid()
            End If


            ' Armazna total de registros
            nlinhasgrid = dgvProdutos.Rows.Count
            increg = dgvProdutos.Rows.Count

            'Verificar se ja esta incluido na grid
            If dgvProdutos.Rows.Count > 0 Then
                For nlinhasgrid = 0 To dgvProdutos.Rows.Count() - 1
                    If dgvProdutos.Rows(nlinhasgrid).Cells(2).Value = Trim(txtCodigosubproduto.Text) Then
                        MsgBox("Código do Sub produto: " & Trim(txtCodigosubproduto.Text) & " já foi incluido!")
                        txtCodigosubproduto.Text = ""
                        txtdescricaosubproduto.Text = ""
                        txtquantidade.Text = ""
                        increg = -1
                        Exit For
                    End If
                Next
            End If

            ' Inserir produtos na Grid
            If increg > -1 Then
                Me.dgvProdutos.Rows.Insert(increg, Trim(txtCodigo.Text), txtDescricao.Text, txtCodigosubproduto.Text, txtdescricaosubproduto.Text, txtquantidade.Text)
                txtCodigosubproduto.Text = ""
                txtdescricaosubproduto.Text = ""
                txtquantidade.Text = ""
                tssContReg.Text = "Total de Produtos: " & Format(dgvProdutos.RowCount, "###0")
                txtCodigosubproduto.Focus()
            End If
        Else
            If Trim(cMensagem) <> "" Then MsgBox(cMensagem)
        End If



    End Sub

    Private Sub dgvProdutos_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvProdutos.CellDoubleClick
        ' vamos obter a linha da célula selecionada
        Dim rowToDelete As Int32 = Me.dgvProdutos.Rows.GetFirstRow( _
            DataGridViewElementStates.Selected)
        rowToDelete = Me.dgvProdutos.CurrentRow.Index

        If btnIncluirsubproduto.Text = "Alterar" Then
            If MsgBox("Deseja alterar o produto?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Estrutura de Proodutos") = MsgBoxResult.Yes Then
                If rowToDelete > -1 Then
                    txtCodigosubproduto.Text = Me.dgvProdutos.CurrentRow.Cells(2).Value
                    txtdescricaosubproduto.Text = Me.dgvProdutos.CurrentRow.Cells(3).Value
                    txtquantidade.Text = Me.dgvProdutos.CurrentRow.Cells(4).Value
                    Me.dgvProdutos.Rows.RemoveAt(rowToDelete)
                    txtquantidade.Enabled = True
                    btnIncluirsubproduto.Enabled = True
                    txtquantidade.Focus()

                Else
                    MsgBox("<Não há registro para ser alterado!>")
                End If
            End If
        Else
            If MsgBox("Deseja excluir o produto?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Estrutura de Proodutos") = MsgBoxResult.Yes Then
                If rowToDelete > -1 Then
                    Me.dgvProdutos.Rows.RemoveAt(rowToDelete)
                    txtquantidade.Enabled = True
                    btnIncluirsubproduto.Enabled = True
                    txtquantidade.Focus()

                Else
                    MsgBox("<Não há registro para ser excluído!>")
                End If
            End If
        End If
    End Sub

    Private Sub btncancelarsubprodutos_Click(sender As Object, e As EventArgs) Handles btncancelarsubprodutos.Click
        If g_Comando = "incluir" Then
            PCabecalho.Enabled = True
            txtCodigo.Text = ""
            txtDescricao.Text = ""
            Call LimparTabControle()

            TabControle.Visible = False
            txtCodigo.Focus()
        End If

        If g_Comando = "alterar" Then
            bAlterar = False
            bIncluir = False
            Call LimparGrid()
            Call TratarObjetos()
        End If
    End Sub

    Private Sub txtCodigo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCodigo.KeyPress
        If Not Char.IsDigit(e.KeyChar) And _
       Not Convert.ToInt32(e.KeyChar) = Keys.Back And _
       Not Convert.ToInt32(e.KeyChar) = Keys.Delete Then
            e.Handled = True

            If e.KeyChar <> Chr(13) Then MsgBox("<Somente números!>")
        End If


        If e.KeyChar = Chr(13) Then
            If bIncluir Then
                If txtCodigo.Text <> "" Then
                    pesq_cod_generico = "ES000_CODPRO"
                    If txtCodigo.Text.Length < 6 Then
                        txtCodigo.Text = String.Format("{0:000000}", Convert.ToInt32(txtCodigo.Text))
                    End If

                    Call Verificar_Codigo_TabEES004()
                    If Codigook = True Then
                        Call Verificar_Codigo_TabEES000()
                        If Codigook = True Then
                            ' Inicializando Grid
                            If dgvProdutos.ColumnCount > 0 Then
                                Call LimparGrid()
                            End If
                            PCabecalho.Enabled = False
                            TabControle.Visible = True
                            If dgvProdutos.ColumnCount = 0 Then
                                'Montar Grid
                                Call MontarGrid()
                            End If
                            txtCodigosubproduto.Focus()
                        End If
                    End If
                Else
                    txtDescricao.Text = ""
                    MsgBox("<Códdigo do produto esta em branco!>")
                    txtCodigo.Focus()
                End If
            End If
        End If

    End Sub
    Private Sub txtCodigosubproduto_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCodigosubproduto.KeyPress
        If e.KeyChar = Chr(13) Then
            If Trim(txtCodigo.Text) = Trim(txtCodigosubproduto.Text) Then
                MsgBox("<Código do produto não pode ser igual ao código do sub produto, digite outro!>")
                txtCodigosubproduto.Text = ""
                txtdescricaosubproduto.Text = ""
                txtCodigosubproduto.Focus()
            Else
                If Trim(txtCodigosubproduto.Text) <> "" Then
                    pesq_cod_generico = "ES004_SUBPRO"
                    If txtCodigosubproduto.Text.Length < 6 Then
                        txtCodigosubproduto.Text = String.Format("{0:000000}", Convert.ToInt32(txtCodigosubproduto.Text))
                    End If

                    Call Verificar_Codigo_Subproduto_TabEES004()

                    If Codigook = True Then
                        Call Verificar_Codigo_TabEES000()
                        If Codigook = True Then
                            txtquantidade.Focus()
                        End If
                    End If
                Else
                    txtdescricaosubproduto.Text = ""
                    MsgBox("<Códdigo do sub produto esta em branco!>")
                    txtCodigosubproduto.Focus()
                End If
            End If
        End If

        If Not Char.IsDigit(e.KeyChar) And _
       Not Convert.ToInt32(e.KeyChar) = Keys.Back And _
       Not Convert.ToInt32(e.KeyChar) = Keys.Delete Then
            e.Handled = True
            If e.KeyChar <> Chr(13) Then MsgBox("<Somente números!>")
        End If
    End Sub

    Private Sub txtquantidade_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtquantidade.KeyPress
        If e.KeyChar = Chr(13) Then
            btnIncluirsubproduto.PerformClick()
        End If

        If Not Char.IsDigit(e.KeyChar) And _
               Not Convert.ToInt32(e.KeyChar) = Keys.Back And _
               Not Convert.ToInt32(e.KeyChar) = Keys.Delete Then
            e.Handled = True
            If e.KeyChar <> Chr(13) Then MsgBox("<Somente números!>")
        End If
    End Sub

    Private Sub comandoPesquisarsubpruduto_Click(sender As Object, e As EventArgs) Handles comandoPesquisarsubpruduto.Click
        Dim options = New dlgPesquisa

        'Tabela que sera usada na pesquisa
        pesq_cod_generico = "ES004_SUBPRO"
        pesq_coddif = Trim(txtCodigo.Text)

        If options.ShowDialog() = Windows.Forms.DialogResult.OK Then
            txtCodigosubproduto.Text = Microsoft.VisualBasic.Left(options.txtPesquisa.Text, 6)
            txtdescricaosubproduto.Text = LerDescricao_Produto(Microsoft.VisualBasic.Left(options.txtPesquisa.Text, 6))
            opcao_sel = "Ok"
        Else
            opcao_sel = "Cancel"
        End If

        If Trim(txtCodigosubproduto.Text) <> "" Then

            Call Verificar_Codigo_Subproduto_TabEES004()

            If Codigook = True Then
                Call Verificar_Codigo_TabEES000()
                If Codigook = True Then
                    txtquantidade.Focus()
                End If
            End If
        Else
            If opcao_sel <> "Cancel" Then MsgBox("<Códdigo do sub produto esta em branco!>")
            txtCodigosubproduto.Focus()
        End If
    End Sub

    Private Sub frmEstruturadeProdutos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim i_point As Integer

        'Criar um adaptador que vai fazer o download de dados da base de dados
        '?? Alterar o Código para a Entidade Principal ??
        If Me.Tag = 4 Then
            cQuery = "SELECT * FROM EES004"
        Else
            cQuery = "SELECT * FROM EES004 where ES004_CODPRO = " & g_Param(1)
        End If

        Using da As New OleDbDataAdapter()
            da.SelectCommand = New OleDbCommand(cQuery, g_ConnectBanco)

            ' Preencher o DataTable 
            da.Fill(dt)
        End Using
        If g_Param(1) <> "INSERT" Then
            'Posicionar no registro selecionado
            '?? Alterar para localizar a chave da tabela ??
            For i_point = 0 To dt.Rows.Count() - 1
                If dt.Rows(i_point).Item("ES004_CODPRO").ToString = g_Param(1) Then
                    Exit For
                End If
            Next
            i = i_point

            'Iniciar com o comando passado
            If g_Comando = "incluir" Then
                bIncluir = True
                bAlterar = True
                TabControle.Visible = False
            ElseIf g_Comando = "alterar" Then
                bIncluir = False
                bAlterar = True
            Else
                bIncluir = False
                bAlterar = False
            End If
        Else
            bIncluir = True
            bAlterar = True
        End If

        TratarObjetos()
    End Sub

    Private Sub frmEstruturadeProdutos_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        g_Param(1) = txtCodigo.Text 'Voltar com a Chave do registro do formulário
    End Sub

End Class