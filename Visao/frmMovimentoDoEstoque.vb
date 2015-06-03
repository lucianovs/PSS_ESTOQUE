Imports System.Data.OleDb
Imports System.Drawing.Printing

Public Class frmMovimentoDoEstoque
    '?? Alterar para a Entidade Principal ??
    Dim dt As DataTable = New DataTable("EES005") ' Movimento do Estoque
    Dim dttipodemov As DataTable = New DataTable("EES006") ' Tabela de Tipo de Movimento
    Dim dtarmazens As DataTable = New DataTable("EES003") ' Tabela de Armazens 
    Dim dtconsulta As DataTable = New DataTable("EES000")
    Dim dt_EES002 As DataTable = New DataTable("EES002")
    Dim dtGridprod As DataTable = New DataTable("EES005") ' Preenchimento do Grid

    Dim i As Integer
    Dim bAlterar As Boolean = False
    Dim bIncluir As Boolean = False
    Dim cQuery As String
    Dim cQuery_Armazens As String
    Dim cQuery_TipodeMovimento As String
    Dim Codigook As Boolean = True
    Dim pesq_cod_generico As String
    Dim opcao_sel As String
    Dim cMensagem As String = ""
    Dim InfoGridok As Boolean = True
    Dim vlr_total As Decimal
    Dim nProxCod_Registro As Integer
    Dim operacaododoc As String
    Dim CodPro_EES005 As String
    Dim CodArm_EES005 As String
    Dim QtdeSal_EES005 As Integer
    Dim Saldo_insuficiente As Boolean = False


    Private Sub TratarObjetos()

        tssContReg.Text = "Total de Produtos: " & Format(dtGridprod.Rows.Count, "###0")

        'Botoes da Barra de comandos
        btnIncluir.Enabled = Not bAlterar And Me.Tag = 4 'And Me.Tag > 1
        btnAlterar.Enabled = False   'Not bAlterar 'And Me.Tag > 1
        btnExcluir.Enabled = Not bAlterar And Me.Tag = 4
        btnGravar.Enabled = bAlterar
        btnCancelar.Enabled = bAlterar
        btnAnterior.Enabled = Not bAlterar
        btnProximo.Enabled = Not bAlterar
        btnLocalizar.Enabled = Not bAlterar
        btnImprimir.Enabled = Not bAlterar
        btnIncluirproduto.Enabled = bAlterar
        btncancelarprodutos.Enabled = bAlterar

        'Campos
        '?? Alterar para os seus objetos da Tela ??
        lblCodigo.Enabled = False
        txtCodigo.Enabled = False
        lbldatacad.Enabled = False
        dtpdatacad.Enabled = False
        lblUsuarioCad.Enabled = False
        txtUsuarioCad.Enabled = False
        lblorigmov.Enabled = False
        txtorimov.Enabled = False
        lblcodpro.Enabled = bAlterar
        txtCodigoproduto.Enabled = bAlterar
        txtdescricaoproduto.Enabled = bAlterar
        lblarmazem.Enabled = bAlterar
        cbarmazem.Enabled = bAlterar
        lbltipodemovimento.Enabled = bAlterar
        cbtipodemovimento.Enabled = bAlterar
        txtqtdemovimentada.Enabled = bAlterar
        txtvalorcusto.Enabled = bAlterar
        txthistorico.Enabled = bAlterar
        'TabControle.Enabled = bAlterar
        dgvProdutos.Enabled = bAlterar


        If g_Comando = "incluir" Then
            rgEntrada.Enabled = True
            rgSaida.Enabled = True
            rgEntrada.Checked = False
            rgSaida.Checked = False

            lblnumdoc.Enabled = True
            txtnumdoc.Enabled = True
            txtnumdoc.Text = ""
            Call LimparGrid()
            PCabecalho.Enabled = True
            TabControle.Visible = False
        Else
            lblnumdoc.Enabled = bAlterar
            txtnumdoc.Enabled = bAlterar
            lblstatus.Enabled = bAlterar  'Status Tipo do produto
            rgEntrada.Enabled = bAlterar
            rgSaida.Enabled = bAlterar
            TabControle.Visible = True
        End If

        ComandoPesquisar.Enabled = bAlterar
        txtCodigoproduto.Enabled = bAlterar
        txtdescricaoproduto.Enabled = bAlterar
        txtqtdemovimentada.Enabled = bAlterar
        txtvalorcusto.Enabled = bAlterar
        dgvProdutos.Enabled = bAlterar

        'Preencher Campos
        If i > -1 And bIncluir Then
            Call PreencherDados()
        End If


        'Outros Controles
        '*****************

        'Preencher Campos
        If i > -1 And Not bIncluir Then
            txtCodigo.Text = dt.Rows(i).Item("ES005_CODMOV")
            '   txtDescricao.Text = LerDescricao_Produto(dt.Rows(i).Item("ES005_CODPRO"))
            'Data do  Cadastro
            dtpdatacad.Value = IIf(IsDBNull(dt.Rows(i).Item("ES005_DATMOV")), Date.Now, dt.Rows(i).Item("ES005_DATMOV"))

            If IsDBNull(dt.Rows(i).Item("ES005_USUMOV")) Then
                txtUsuarioCad.Text = ClassCrypt.Decrypt(g_Login)
            Else
                txtUsuarioCad.Text = getLoginaAcessoUsuario(dt.Rows(i).Item("ES005_USUMOV"))
            End If
            txtorimov.Text = dt.Rows(i).Item("ES005_ORIMOV")

            txtnumdoc.Text = dt.Rows(i).Item("ES005_NUMDOC")

            If dt.Rows(i).Item("ES005_ENTSAI") = "E" Then
                rgEntrada.Checked = True
                TabPagEntradaouSaida.Text = "Entrada"
            Else
                rgSaida.Checked = True
                TabPagEntradaouSaida.Text = "Saida"
            End If

            'Outros Controles
            '****************
            If dgvProdutos.ColumnCount = 0 And TabControle.Visible = True Then CarregarGrid()

        End If

        'Outras Chamadas
        '***************

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
        txtnumdoc.Focus()
    End Sub

    Private Sub btnAlterar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAlterar.Click

        bAlterar = True

        Call TratarObjetos()

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
        txtnumdoc.Focus()
    End Sub

    Private Sub btnIncluir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnIncluir.Click
        bAlterar = True
        bIncluir = True

        g_Comando = "incluir"

        Call TratarObjetos()
        tssContReg.Text = "Total de Produtos: 0"
        txtnumdoc.Focus()
    End Sub

    Private Sub btnGravar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGravar.Click
        Dim cSql As String = ""
        Dim cmd As OleDbCommand
        'Dim nProxCod_Registro As Integer
        Dim nlingrid As Integer


        If ConectarBanco() Then
            '?? Colocar o Comando SQL para Gravar (Update e Insert)

            If Validardados(cMensagem) And Codigook = True Then
                If bIncluir Then

                    'Verificando Saldo
                    If operacaododoc = "S" Then
                        Call Verificando_Saldo_EES002()
                    Else
                        Saldo_insuficiente = False
                    End If

                    If dgvProdutos.Rows.Count > 0 And Saldo_insuficiente = False Then
                        For nlingrid = 0 To dgvProdutos.Rows.Count() - 1
                            'Inserir chave
                            nProxCod_Registro = ProxCodChave("EES005", "ES005_CODMOV")

                            cSql = "INSERT INTO EES005 (ES005_CODMOV, ES005_DATMOV, ES005_USUMOV, ES005_ORIMOV"
                            cSql += ",ES005_NUMDOC, ES005_ENTSAI, ES005_CODPRO"
                            cSql += ",ES005_CODARM, ES005_TIPMOV, ES005_QTDMOV"
                            cSql += ",ES005_VLRCST, ES005_VLRMOV, ES005_HISMOV"
                            cSql += ")"

                            cSql += " values (" & nProxCod_Registro.ToString & ",'" & FormatarData(dtpdatacad.Text) & "', " & getCodUsuario(txtUsuarioCad.Text).ToString
                            cSql += ",'" & Trim(txtorimov.Text) & "', " & Trim(txtnumdoc.Text) & ", '" & operacaododoc & "'"
                            cSql += ",'" & dgvProdutos.Rows(nlingrid).Cells(0).Value & "','" & Microsoft.VisualBasic.Left(dgvProdutos.Rows(nlingrid).Cells(2).Value, 2) & "'"
                            cSql += "," & ClassFuncoes.SoNumero(dgvProdutos.Rows(nlingrid).Cells(3).Value) & "," & dgvProdutos.Rows(nlingrid).Cells(4).Value & ""
                            cSql += ",'" & dgvProdutos.Rows(nlingrid).Cells(5).Value & "','" & Format(Convert.ToDouble(vlr_total.ToString), "#,##0.00") & "', '" & Trim(txthistorico.Text) & "'"
                            cSql += ")" '
                            cmd = New OleDbCommand(cSql, g_ConnectBanco)
                            Try
                                CodPro_EES005 = dgvProdutos.Rows(nlingrid).Cells(0).Value
                                CodArm_EES005 = Microsoft.VisualBasic.Left(dgvProdutos.Rows(nlingrid).Cells(2).Value, 2)
                                QtdeSal_EES005 = dgvProdutos.Rows(nlingrid).Cells(4).Value

                                cmd.ExecuteNonQuery()
                                'Atualizar tabela de Saldo EES002
                                Call Atualizar_Saldo_EES002()

                                CodPro_EES005 = ""
                                CodArm_EES005 = ""
                                QtdeSal_EES005 = 0

                            Catch ex As Exception
                                MsgBox(ex.ToString())
                            End Try
                        Next
                    Else
                        txtCodigoproduto.Focus()
                    End If
                ElseIf bAlterar Then
                    'g_Comando = "ver"
                End If
                    If Saldo_insuficiente = False Then
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
                            g_Comando = "ver"
                            TratarObjetos()
                            End If

                        End If
                    End If 'Fim Saldo_insuficiente
                Else
                    If Trim(cMensagem) <> "" Then MsgBox(cMensagem)
                End If
            End If
    End Sub

    Private Function Validardados(ByRef cMensagem As String) As Boolean
        Dim bRetorno As Boolean = True

        '?? Acrescentar as validações da Tela ??
        If Trim(txtnumdoc.Text) = "" Then
            cMensagem += " <Número do documento não pode estar vazio> "
            bRetorno = False
        End If

        If (rgEntrada.Checked = False) And (rgSaida.Checked = False) Then
            cMensagem += " <Status do tipo do documento é inválido> "
            bRetorno = False
        End If

        Return (bRetorno)

    End Function

    Private Sub btnExcluir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExcluir.Click

        Call Excluir_Registro()

    End Sub

    Private Sub Verificando_Saldo_EES002()
        Dim cSql_Saldo As String = ""
        Dim icont As Integer
        Dim vrl_qtde_saldo As Integer
        Dim vrl_vlrsal_saldo As Decimal
        Dim reg_encontrado As Integer
        ' vamos obter a linha da célula selecionada
        Dim rowToDelete As Int32 = Me.dgvProdutos.Rows.GetFirstRow( _
            DataGridViewElementStates.Selected)



        For nlingrid = 0 To dgvProdutos.Rows.Count() - 1
            'verifica registro na tabela EES002
            cSql_Saldo = "SELECT * FROM EES002 where ES002_CODPRO = '" & dgvProdutos.Rows(nlingrid).Cells(0).Value & "'"
            Using daEES002 As New OleDbDataAdapter()
                daEES002.SelectCommand = New OleDbCommand(cSql_Saldo, g_ConnectBanco)

                ' Preencher o DataTable 
                daEES002.Fill(dt_EES002)
            End Using

            'Pesquisando Código do  produto na tabela EES002
            If dt_EES002.Rows.Count > 0 Then
                For icont = 0 To dt_EES002.Rows.Count() - 1
                    If dt_EES002.Rows(icont).Item("ES002_CODPRO").ToString = dgvProdutos.Rows(nlingrid).Cells(0).Value Then
                        vrl_qtde_saldo = dt_EES002.Rows(icont).Item("ES002_QTDSAL").ToString - dgvProdutos.Rows(nlingrid).Cells(4).Value
                        vrl_vlrsal_saldo = dt_EES002.Rows(icont).Item("ES002_VLRSAL").ToString - vlr_total
                        reg_encontrado = reg_encontrado + 1
                        If vrl_qtde_saldo < 0 Then
                            MsgBox("<Produto " & CodPro_EES005 & " - " & LerDescricao_Produto(dgvProdutos.Rows(nlingrid).Cells(0).Value) & " à quantidade é insuficiente!>")
                            rowToDelete = Me.dgvProdutos.Rows(nlingrid).Index
                            If rowToDelete > -1 Then
                                Me.dgvProdutos.Rows.RemoveAt(rowToDelete)
                            End If
                            Saldo_insuficiente = True
                            Exit For
                        Else
                            Saldo_insuficiente = False
                        End If
                    End If
                Next
            Else
                Saldo_insuficiente = True
                MsgBox("<Produto " & CodPro_EES005 & " - " & LerDescricao_Produto(CodPro_EES005) & " não consta no Estoque>")
            End If
            If Saldo_insuficiente = True Then Exit For
        Next
        dt_EES002.Clear()
    End Sub

    Private Sub Atualizar_Saldo_EES002()
        Dim cSql_Saldo As String = ""
        Dim cmd As OleDbCommand
        Dim icont As Integer
        Dim vrl_qtde_saldo As Integer
        Dim vrl_vlrsal_saldo As Decimal
        Dim reg_encontrado As Integer


        reg_encontrado = 0
        vrl_qtde_saldo = 0
        vrl_vlrsal_saldo = 0

        'Atualizando Entrada / Saida de produtos
        If operacaododoc = "E" Then ' Inicio da Rotina Entrada
            If dgvProdutos.Rows.Count > 0 Then
                If bIncluir = True Then
                    'verifica registro na tabela EES002
                    cSql_Saldo = "SELECT * FROM EES002 where ES002_CODPRO = '" & CodPro_EES005 & "'"
                    ' & _
                    '     "AND ES002_CODARM = '" & CodArm_EES005 & "'"
                    Using daEES002 As New OleDbDataAdapter()
                        daEES002.SelectCommand = New OleDbCommand(cSql_Saldo, g_ConnectBanco)

                        ' Preencher o DataTable 
                        daEES002.Fill(dt_EES002)
                    End Using

                    'Pesquisando Código do  produto na tabela EES002
                    If dt_EES002.Rows.Count > 0 Then
                        For icont = 0 To dt_EES002.Rows.Count() - 1
                            If dt_EES002.Rows(icont).Item("ES002_CODPRO").ToString = Trim(CodPro_EES005) Then
                                vrl_qtde_saldo = dt_EES002.Rows(icont).Item("ES002_QTDSAL").ToString + QtdeSal_EES005
                                vrl_vlrsal_saldo = dt_EES002.Rows(icont).Item("ES002_VLRSAL").ToString + vlr_total
                                reg_encontrado = reg_encontrado + 1
                                Exit For
                            End If
                        Next

                        If reg_encontrado > 0 Then
                            'Update - Atualizando tabela EES002 
                            cSql_Saldo = "UPDATE EES002 set ES002_CODPRO='" & CodPro_EES005 & _
                                        "', ES002_CODARM = '" & CodArm_EES005 & _
                                        "', ES002_QTDSAL =" & vrl_qtde_saldo.ToString & _
                                        ", ES002_VLRSAL = '" & Format(Convert.ToDouble(vrl_vlrsal_saldo.ToString), "#,##0.00") & "'" & _
                                        " where ES002_CODPRO = '" & CodPro_EES005 & "'"

                            cmd = New OleDbCommand(cSql_Saldo, g_ConnectBanco)
                            Try
                                cmd.ExecuteNonQuery()
                            Catch ex As Exception
                                MsgBox(ex.ToString())
                            End Try
                        End If ' Fim If reg_encontrado > 0 Then
                    Else
                        If reg_encontrado = 0 Then
                            'Insert - Atualizando tabela EES002
                            cSql_Saldo = "INSERT INTO EES002 (ES002_CODPRO, ES002_CODARM, ES002_QTDSAL"
                            cSql_Saldo += ",ES002_VLRSAL"
                            cSql_Saldo += ")"

                            cSql_Saldo += " values ('" & CodPro_EES005 & "','" & CodArm_EES005 & "'"
                            cSql_Saldo += "," & QtdeSal_EES005 & ", '" & Format(Convert.ToDouble(vlr_total.ToString), "#,##0.00") & "'"
                            cSql_Saldo += ")" '

                            cmd = New OleDbCommand(cSql_Saldo, g_ConnectBanco)
                            Try
                                cmd.ExecuteNonQuery()
                            Catch ex As Exception
                                MsgBox(ex.ToString())
                            End Try
                        End If 'Fim  If reg_encontrado = 0 Then
                    End If
                    dt_EES002.Clear() ' limpar a consulta da tabela EES002
                Else
                End If
            End If
        Else
            ' Inicio da Rotina Saida
            If dgvProdutos.Rows.Count > 0 Then
                If bIncluir = True Then
                    'verifica registro na tabela EES002
                    cSql_Saldo = "SELECT * FROM EES002 where ES002_CODPRO = '" & CodPro_EES005 & "'"
                    Using daEES002 As New OleDbDataAdapter()
                        daEES002.SelectCommand = New OleDbCommand(cSql_Saldo, g_ConnectBanco)

                        ' Preencher o DataTable 
                        daEES002.Fill(dt_EES002)
                    End Using

                    'Pesquisando Código do  produto na tabela EES002
                    If dt_EES002.Rows.Count > 0 Then
                        For icont = 0 To dt_EES002.Rows.Count() - 1
                            If dt_EES002.Rows(icont).Item("ES002_CODPRO").ToString = Trim(CodPro_EES005) Then
                                vrl_qtde_saldo = dt_EES002.Rows(icont).Item("ES002_QTDSAL").ToString - QtdeSal_EES005
                                vrl_vlrsal_saldo = dt_EES002.Rows(icont).Item("ES002_VLRSAL").ToString - vlr_total
                                reg_encontrado = reg_encontrado + 1
                                Exit For
                            End If
                        Next

                        If reg_encontrado > 0 Then
                            'Update - Atualizando tabela EES002 
                            cSql_Saldo = "UPDATE EES002 set ES002_CODPRO='" & CodPro_EES005 & _
                                        "', ES002_CODARM = '" & CodArm_EES005 & _
                                        "', ES002_QTDSAL =" & vrl_qtde_saldo.ToString & _
                                        ", ES002_VLRSAL = '" & Format(Convert.ToDouble(vrl_vlrsal_saldo.ToString), "#,##0.00") & "'" & _
                                        " where ES002_CODPRO = '" & CodPro_EES005 & "'"

                            cmd = New OleDbCommand(cSql_Saldo, g_ConnectBanco)
                            Try
                                cmd.ExecuteNonQuery()
                            Catch ex As Exception
                                MsgBox(ex.ToString())
                            End Try
                        End If ' Fim If reg_encontrado > 0 Then

                        dt_EES002.Clear() ' limpar a consulta da tabela EES002
                    Else
                        MsgBox("<Produto não Consta na tabela de Saldo!>")
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub Excluir_Registro()
        Dim cSql As String
        Dim cMensagem As String = ""
        Dim cmd As OleDbCommand
        Dim Pos_reg As Integer

        If MsgBox("Deseja excluir este registro?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Movimento do Estoque") = MsgBoxResult.Yes Then

            '?? Alterar para a Tabela a ser Excluída ??
            cSql = "DELETE FROM EES005 where ES005_NUMDOC = " & txtnumdoc.Text
            cmd = New OleDbCommand(cSql, g_ConnectBanco)

            Try
                'Pos_reg = dt.Rows.Count() - dgvProdutos.RowCount
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

                '  i = Pos_reg



                'Verificar se o comando veio do browse
                If g_Comando = "excluir" Then
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

        ' Verifica se registro esta Ativo ou Inativo
        If rgEntrada.Checked = True Then
            lblstatus.Text = "Status:                   Ativo"
        Else
            lblstatus.Text = "Status:                   Inativo"
        End If

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
        lblstatus.Text = "Status:"
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
    'Verificar_Codigo se já existe registro salvo na tabela EES000
    Private Sub Verificar_Codigo_TabEES000()
        Dim reg_encontrado As Integer
        Dim i_point As Integer
        Dim icont As Integer

        reg_encontrado = 0

        If txtCodigoproduto.Text.Length < 6 Then
            txtCodigoproduto.Text = String.Format("{0:000000}", Convert.ToInt32(txtCodigoproduto.Text))
        End If

        If pesq_cod_generico = "ES000_CODPRO" Then
            If Trim(txtCodigoproduto.Text <> "") Then
                cQuery = "SELECT * FROM EES000 where ES000_CODPRO = '" & Trim(txtCodigoproduto.Text) & "'"
            End If
        End If

        Using daconsulta As New OleDbDataAdapter()
            daconsulta.SelectCommand = New OleDbCommand(cQuery, g_ConnectBanco)

            ' Preencher o DataTable 
            daconsulta.Fill(dtconsulta)
        End Using

        'Verificar_Codigo se já existe registro salvo na tabela EES000
        If dtconsulta.Rows.Count > 0 Then
            For icont = 0 To dtconsulta.Rows.Count() - 1
                If pesq_cod_generico = "ES000_CODPRO" Then
                    If dtconsulta.Rows(icont).Item("ES000_CODPRO").ToString = Trim(txtCodigoproduto.Text) Then
                        txtCodigoproduto.Text = dtconsulta.Rows(icont).Item("ES000_CODPRO").ToString
                        txtdescricaoproduto.Text = dtconsulta.Rows(icont).Item("ES000_DESPRO").ToString
                        reg_encontrado = reg_encontrado + 1
                        Exit For
                    End If
                End If
            Next
        End If

        If reg_encontrado = 0 Then
            If pesq_cod_generico = "ES000_CODPRO" Then
                txtCodigoproduto.Text = ""
                txtdescricaoproduto.Text = ""
                MsgBox("<Código do produto não cadastrado, digite outro!>")
                Codigook = False
                txtCodigoproduto.Focus()
            End If
        Else
            Codigook = True '
            If Me.Tag = 4 Then
                cQuery = "SELECT * FROM EES005"
            Else
                cQuery = "SELECT * FROM EES005 where ES005_CODMOV = " & g_Param(1)
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
                    If dt.Rows(i_point).Item("ES005_CODMOV").ToString = g_Param(1) Then
                        Exit For
                    End If
                Next
                i = i_point
            End If
        End If

    End Sub

    Private Sub PreencherDados()
        dtpdatacad.Value = Date.Now
        txtUsuarioCad.Text = ClassCrypt.Decrypt(g_Login)
        txtorimov.Text = g_Modulo
    End Sub

    Private Sub frmMovimentoDoEstoque_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim i_point As Integer

        'Criar um adaptador que vai fazer o download de dados da base de dados
        '?? Alterar o Código para a Entidade Principal ??
        If Me.Tag = 4 Then
            cQuery = "SELECT * FROM EES005"
        Else
            cQuery = "SELECT * FROM EES005 where ES005_CODMOV = " & g_Param(1)
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
                If dt.Rows(i_point).Item("ES005_CODMOV").ToString = g_Param(1) Then
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

        'Carregar o Combo de Armazéns
        cQuery_Armazens = "SELECT ES003_CODARM, ES003_DESARM FROM "
        If LCase(ClassCrypt.Decrypt(g_Login)) <> "admin" Then 'admin
            cQuery_Armazens += "(EES003 inner join EES005 on EES005.ES005_CODARM =EES003.ES003_CODARM) WHERE " & _
                "EES005.ES005_USUMOV =" & getCodUsuario(ClassCrypt.Decrypt(g_Login)).ToString & _
                " AND ES005_CODARM > 0 and "
        Else
            cQuery_Armazens += "EES003 WHERE "
        End If
        cQuery_Armazens += "right(ES003_CODARM,2)<>'00'"

        Using da As New OleDbDataAdapter()
            da.SelectCommand = New OleDbCommand(cQuery_Armazens, g_ConnectBanco)

            ' Preencher o DataTable 
            da.Fill(dtarmazens)
            If dtarmazens.Rows.Count() > 0 Then
                For x = 0 To dtarmazens.Rows.Count() - 1
                    cbarmazem.Items.Add(dtarmazens.Rows(x).Item("ES003_CODARM") & " - " & dtarmazens.Rows(x).Item("ES003_DESARM"))
                Next
            Else
                cbarmazem.Items.Clear()
            End If
        End Using
        dtarmazens.Clear()

        'Carregar o Combo de Tipo de Produto
        cQuery_TipodeMovimento = "SELECT ES006_TIPMOV, ES006_DESTIP FROM "
        If LCase(ClassCrypt.Decrypt(g_Login)) <> "admin" Then 'admin
            cQuery_TipodeMovimento += "(EES006 inner join EES005 on EES005.ES005_TIPMOV = EES006.ES006_TIPMOV) WHERE " & _
                "EES005.ES005_USUMOV =" & getCodUsuario(ClassCrypt.Decrypt(g_Login)).ToString & _
                " AND ES005_TIPMOV > 0 and "
        Else
            cQuery_TipodeMovimento += "EES006 WHERE "
        End If
        cQuery_TipodeMovimento += "right(ES006_TIPMOV,6)>0"

        Using da As New OleDbDataAdapter()
            da.SelectCommand = New OleDbCommand(cQuery_TipodeMovimento, g_ConnectBanco)

            ' Preencher o DataTable 
            da.Fill(dttipodemov)
            If dttipodemov.Rows.Count() > 0 Then
                For x = 0 To dttipodemov.Rows.Count() - 1
                    cbtipodemovimento.Items.Add(dttipodemov.Rows(x).Item("ES006_TIPMOV") & " - " & dttipodemov.Rows(x).Item("ES006_DESTIP"))
                Next
            Else
                cbtipodemovimento.Items.Clear()
            End If
        End Using
        dttipodemov.Clear()

        TratarObjetos()
    End Sub

    Private Sub frmMovimentoDoEstoque_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        g_Param(1) = txtCodigo.Text 'Voltar com a Chave do registro do formulário
    End Sub

    Private Sub txtCodigoproduto_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCodigoproduto.KeyPress
        If Not Char.IsDigit(e.KeyChar) And _
        Not Convert.ToInt32(e.KeyChar) = Keys.Back And _
        Not Convert.ToInt32(e.KeyChar) = Keys.Delete Then
            e.Handled = True

            If e.KeyChar <> Chr(13) Then MsgBox("<Somente números!>")
        End If


        If e.KeyChar = Chr(13) Then
            If bIncluir Then
                If txtCodigoproduto.Text <> "" Then
                    pesq_cod_generico = "ES000_CODPRO"
                    If txtCodigoproduto.Text.Length < 6 Then
                        txtCodigoproduto.Text = String.Format("{0:000000}", Convert.ToInt32(txtCodigoproduto.Text))
                    End If

                    '   Call Verificar_Codigo_TabEES004()
                    '  If Codigook = True Then
                    Call Verificar_Codigo_TabEES000()
                    If Codigook = True Then
                        cbarmazem.Focus()
                    End If
                    '  End If
                Else
                    txtdescricaoproduto.Text = ""
                    MsgBox("<Código do produto esta em branco!>")
                    txtCodigoproduto.Focus()
                End If
            End If
        End If
    End Sub
    Private Sub LimparGrid()
        Dim colx As Integer = 0
        Dim contcolx As Integer = 0
        ' Limpar campos
        txtCodigoproduto.Text = ""
        txtdescricaoproduto.Text = ""
        txtqtdemovimentada.Text = ""
        txtvalorcusto.Text = ""

        'Limpar toda Grid
        For contcolx = dgvProdutos.Columns.Count - 1 To colx Step -1
            dgvProdutos.Columns.Remove(dgvProdutos.Columns(colx).Name)
        Next
    End Sub
    Private Sub MontarGrid()
        dgvProdutos.DataSource = Nothing

        dgvProdutos.Columns.Add("0", "Cód. produto")
        dgvProdutos.Columns.Add("1", "Descrição do produto")
        dgvProdutos.Columns.Add("2", "Armazém")
        dgvProdutos.Columns.Add("3", "Tipo Movimento")
        dgvProdutos.Columns.Add("4", "Quantidade")
        dgvProdutos.Columns.Add("5", "Valor de Custo")
        '   dgvProdutos.Columns.Add("6", "Valor Total")


        dgvProdutos.Columns(0).Width = 98
        dgvProdutos.Columns(1).Width = 150
        dgvProdutos.Columns(2).Width = 150
        dgvProdutos.Columns(3).Width = 150
        dgvProdutos.Columns(4).Width = 80
        dgvProdutos.Columns(5).Width = 100
        ' dgvProdutos.Columns(6).Width = 100
    End Sub

    Private Sub txtqtdemovimentada_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtqtdemovimentada.KeyPress
        If e.KeyChar = Chr(13) Then
            txtvalorcusto.Focus()
        End If

        If Not Char.IsDigit(e.KeyChar) And _
               Not Convert.ToInt32(e.KeyChar) = Keys.Back And _
               Not Convert.ToInt32(e.KeyChar) = Keys.Delete Then
            e.Handled = True
            If e.KeyChar <> Chr(13) Then MsgBox("<Somente números!>")
        End If
    End Sub

    Private Sub txtvalorcusto_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtvalorcusto.KeyPress
        If e.KeyChar = Chr(13) Then
            btnIncluirproduto.PerformClick()
        End If

        If Not Char.IsDigit(e.KeyChar) And _
               Not Convert.ToInt32(e.KeyChar) = Keys.Back And _
               Not Convert.ToInt32(e.KeyChar) = Keys.Delete Then
            e.Handled = True
            If e.KeyChar <> Chr(13) Then MsgBox("<Somente números!>")
        End If
    End Sub

    Private Sub CarregarGrid()
        Dim colx As Integer
        Dim increg As Integer

        dgvProdutos.DataSource = Nothing
        dtGridprod.Clear()
        dtGridprod.Reset()



        cQuery = "SELECT EES005.ES005_CODPRO AS ES005_CODPRO, EES005.ES005_CODARM AS ES005_CODARM, " & _
       "EES005.ES005_TIPMOV AS ES005_TIPMOV, EES005.ES005_QTDMOV AS ES005_QTDMOV, " & _
       "EES005.ES005_VLRCST AS ES005_VLRCST " & _
       "FROM EES005 WHERE EES005.ES005_NUMDOC=" & Trim(txtnumdoc.Text) & "" & _
       " ORDER BY EES005.ES005_CODPRO"


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

        increg = 0
        vlr_total = 0
        If dtGridprod.Rows.Count > 0 Then
            For colx = 0 To dtGridprod.Rows.Count() - 1
                Me.dgvProdutos.Rows.Insert(increg, dtGridprod.Rows(colx).Item("ES005_CODPRO").ToString, LerDescricao_Produto(dtGridprod.Rows(colx).Item("ES005_CODPRO").ToString), dtGridprod.Rows(colx).Item("ES005_CODARM").ToString & " - " & LerDescricao_Armazem(dtGridprod.Rows(colx).Item("ES005_CODARM").ToString), dtGridprod.Rows(colx).Item("ES005_TIPMOV").ToString & " - " & LerDescricao_TipodeMovimento(dtGridprod.Rows(colx).Item("ES005_TIPMOV").ToString), dtGridprod.Rows(colx).Item("ES005_QTDMOV").ToString, Format(Convert.ToDouble(dtGridprod.Rows(colx).Item("ES005_VLRCST").ToString), "#,##0.00"))
                vlr_total = vlr_total + dtGridprod.Rows(colx).Item("ES005_VLRCST").ToString
                increg = increg + 1
            Next
        End If

        tssContReg.Text = "Total de Produtos: " & Format(dgvProdutos.RowCount, "###0") & " / " & "Valor Total do documento: R$ " & Format(Convert.ToDouble(vlr_total.ToString), "#,##0.00") ' vlr_total.ToString ' Format(Convert.ToDouble(vlr_total.ToString), "f")

    End Sub
    Private Sub LimparTabControle()
        txtCodigoproduto.Text = ""
        txtdescricaoproduto.Text = ""
        txtqtdemovimentada.Text = ""
        txtvalorcusto.Text = ""
        dgvProdutos.DataSource = Nothing
    End Sub

    Private Sub VerificarNumDoc()
        Dim reg_encontrado As Integer
        Dim i_point As Integer
        Dim icont As Integer
        reg_encontrado = 0
        If Trim(txtnumdoc.Text <> "") Then
            cQuery = "SELECT * FROM EES005 where ES005_NUMDOC = " & Trim(txtnumdoc.Text) & ""

        End If

        Using daconsulta As New OleDbDataAdapter()
            daconsulta.SelectCommand = New OleDbCommand(cQuery, g_ConnectBanco)

            ' Preencher o DataTable 
            daconsulta.Fill(dtconsulta)
        End Using

        'Verificar numero de documento se já existe registro salvo na tabela EES005
        If dtconsulta.Rows.Count > 0 Then
            For icont = 0 To dtconsulta.Rows.Count() - 1
                If dtconsulta.Rows(icont).Item("ES005_NUMDOC").ToString = Trim(txtnumdoc.Text) Then
                    reg_encontrado = reg_encontrado + 1
                    Exit For
                End If
            Next

        End If

        If reg_encontrado > 0 Then
            txtnumdoc.Text = ""
            MsgBox("<Número do documento já foi cadastrado, digite outro!>")
            Codigook = True
            txtnumdoc.Focus()
        Else
            Codigook = False '
            If Me.Tag = 4 Then
                cQuery = "SELECT * FROM EES005"
            Else
                cQuery = "SELECT * FROM EES005 where ES005_CODMOV = " & g_Param(1)
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
                    If dt.Rows(i_point).Item("ES005_CODMOV").ToString = g_Param(1) Then
                        Exit For
                    End If
                Next
                i = i_point
            End If
        End If
    End Sub

    Private Sub btncancelarsubprodutos_Click(sender As Object, e As EventArgs) Handles btncancelarprodutos.Click
        If g_Comando = "incluir" Then
            PCabecalho.Enabled = True
            txtnumdoc.Text = ""
            rgEntrada.Checked = False
            rgSaida.Checked = False
            operacaododoc = ""
            Call LimparTabControle()

            TabControle.Visible = False
            tssContReg.Text = "Total de Produtos: 0"
            txtnumdoc.Focus()
        End If

        If g_Comando = "alterar" Then
            bAlterar = False
            bIncluir = False
            Call LimparGrid()
            Call TratarObjetos()
        End If
    End Sub

    Private Sub txtnumdoc_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtnumdoc.KeyPress
        If Not Char.IsDigit(e.KeyChar) And _
        Not Convert.ToInt32(e.KeyChar) = Keys.Back And _
        Not Convert.ToInt32(e.KeyChar) = Keys.Delete Then
            e.Handled = True

            If e.KeyChar <> Chr(13) Then MsgBox("<Somente números!>")
        End If
    End Sub

    Private Sub rgEntrada_Click(sender As Object, e As EventArgs) Handles rgEntrada.Click
        operacaododoc = "E"
        TabPagEntradaouSaida.Text = "Entrada"
        Call Verificar_Operacao_Entrada_Saida()
    End Sub

    Private Sub rgSaida_Click(sender As Object, e As EventArgs) Handles rgSaida.Click
        operacaododoc = "S"
        TabPagEntradaouSaida.Text = "Saida"
        Call Verificar_Operacao_Entrada_Saida()
    End Sub
    Private Sub Verificar_Operacao_Entrada_Saida()
        If bIncluir Then
            If txtnumdoc.Text <> "" Then
                Call VerificarNumDoc()
                If Codigook = True Then
                    '   MsgBox("<Número do documento já foi cadastrado!>")
                    rgEntrada.Checked = False
                    rgSaida.Checked = False
                    txtnumdoc.Focus()
                Else
                    If dgvProdutos.ColumnCount > 0 Then
                        Call LimparGrid()
                    End If
                    PCabecalho.Enabled = False
                    TabControle.Visible = True
                    If dgvProdutos.ColumnCount = 0 Then
                        'Montar Grid
                        Call MontarGrid()
                    End If
                    txtCodigoproduto.Focus()
                End If
            Else
                MsgBox("<Número do documento não estar vazio!>")
                rgEntrada.Checked = False
                rgSaida.Checked = False
                txtnumdoc.Focus()
            End If
        End If
    End Sub

    Private Sub ComandoPesquisar_Click(sender As Object, e As EventArgs) Handles ComandoPesquisar.Click
        Dim options = New dlgPesquisa

        'Tabela que sera usada na pesquisa
        g_PequisaGenerica = "EES000"
        pesq_coddif = ""

        If bIncluir Then
            If options.ShowDialog() = Windows.Forms.DialogResult.OK Then
                txtCodigoproduto.Text = Microsoft.VisualBasic.Left(options.txtPesquisa.Text, 6)
                txtdescricaoproduto.Text = LerDescricao_Produto(Microsoft.VisualBasic.Left(options.txtPesquisa.Text, 6))
                opcao_sel = "Ok"
            Else
                opcao_sel = "Cancel"
            End If

            If Trim(txtCodigoproduto.Text) <> "" And opcao_sel = "Ok" Then
                txtqtdemovimentada.Focus()
            Else
                If opcao_sel <> "Cancel" Then MsgBox("<Códdigo do produto esta em branco!>")
                txtCodigoproduto.Focus()
            End If
        End If
    End Sub

    Private Sub btnIncluirproduto_Click(sender As Object, e As EventArgs) Handles btnIncluirproduto.Click
        Dim increg As Integer
        Dim nlinhasgrid As Integer


        If Validardados(cMensagem) Then
            If txtCodigoproduto.Text.Length < 1 Then
                MsgBox("<Código do produto esta vazio!>")
                InfoGridok = False

                Codigook = True
                txtCodigoproduto.Focus()
            Else
                pesq_cod_generico = "ES000_CODPRO"
                Call Verificar_Codigo_TabEES000()
                If Codigook <> False Then
                    If cbarmazem.Text.Length < 1 Then
                        MsgBox("<Armazém esta vazia!>")
                        InfoGridok = False

                        Codigook = True
                        cbarmazem.Focus()
                    Else
                        If cbtipodemovimento.Text.Length < 1 Then
                            MsgBox("<Tipo de Movimento esta vazia!>")
                            InfoGridok = False

                            Codigook = True
                            cbtipodemovimento.Focus()
                        Else
                            If txtqtdemovimentada.Text = "" Then
                                MsgBox("<Quantidade do produto esta vazia!>")
                                InfoGridok = False

                                Codigook = True
                                txtqtdemovimentada.Focus()
                            Else
                                If txtvalorcusto.Text = "" Or txtvalorcusto.Text = "0,00" Then
                                    MsgBox("<Valor do custo produto inválido!>")
                                    InfoGridok = False

                                    Codigook = True
                                    txtvalorcusto.Focus()
                                End If
                            End If

                        End If
                    End If
                    If InfoGridok <> False Then
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
                                If dgvProdutos.Rows(nlinhasgrid).Cells(0).Value = Trim(txtCodigoproduto.Text) Then
                                    MsgBox("Código do produto: " & Trim(txtCodigoproduto.Text) & " já foi incluido!")
                                    txtCodigoproduto.Text = ""
                                    txtdescricaoproduto.Text = ""
                                    txtqtdemovimentada.Text = ""
                                    txtvalorcusto.Text = ""
                                    increg = -1
                                    Exit For
                                End If
                            Next
                        End If

                        ' Inserir produtos na Grid
                        If increg > -1 Then
                            ' Pos_armazem = cbarmazem.Text.Length - 5
                            ' Sel_armazem = Microsoft.VisualBasic.Right(cbarmazem.Text, Pos_armazem)
                            ' Pos_tipomovimento = cbtipodemovimento.Text.Length - 4
                            '  Sel_tipomovimento = Microsoft.VisualBasic.Right(cbtipodemovimento.Text, Pos_tipomovimento)
                            Me.dgvProdutos.Rows.Insert(increg, Trim(txtCodigoproduto.Text), txtdescricaoproduto.Text, cbarmazem.Text, cbtipodemovimento.Text, txtqtdemovimentada.Text, txtvalorcusto.Text)

                            'Soma dos Itens selecionados na Grid
                            vlr_total = 0
                            For Each col As DataGridViewRow In dgvProdutos.Rows
                                vlr_total = vlr_total + col.Cells(5).Value
                            Next

                            txtCodigoproduto.Text = ""
                            txtdescricaoproduto.Text = ""
                            txtqtdemovimentada.Text = ""
                            txtvalorcusto.Text = ""
                            tssContReg.Text = "Total de Produtos: " & Format(dgvProdutos.RowCount, "###0") & " / " & "Valor Total do documento: R$ " & Format(Convert.ToDouble(vlr_total.ToString), "#,##0.00") ' vlr_total.ToString ' Format(Convert.ToDouble(vlr_total.ToString), "f")
                            txtCodigoproduto.Focus()
                        End If
                    Else
                        InfoGridok = True
                        '  txtCodigoproduto.Focus()
                    End If
                End If

            End If
        Else
            If Trim(cMensagem) <> "" Then MsgBox(cMensagem)

            Codigook = True
            txtCodigoproduto.Focus()
        End If
    End Sub

    Private Sub txtvalorcusto_TextChanged(sender As Object, e As EventArgs) Handles txtvalorcusto.TextChanged
        ClassFuncoes.TextBoxMoeda(txtvalorcusto)
    End Sub

    Private Sub dgvProdutos_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvProdutos.CellDoubleClick
        ' vamos obter a linha da célula selecionada
        Dim rowToDelete As Int32 = Me.dgvProdutos.Rows.GetFirstRow( _
            DataGridViewElementStates.Selected)
        rowToDelete = Me.dgvProdutos.CurrentRow.Index

        If btnIncluirproduto.Text = "Alterar" Then
            If MsgBox("Deseja alterar o produto?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Movimento do Estoque") = MsgBoxResult.Yes Then
                If rowToDelete > -1 Then
                    txtCodigoproduto.Text = Me.dgvProdutos.CurrentRow.Cells(0).Value
                    txtdescricaoproduto.Text = LerDescricao_Produto(Me.dgvProdutos.CurrentRow.Cells(0).Value)
                    txtqtdemovimentada.Text = Me.dgvProdutos.CurrentRow.Cells(4).Value
                    txtvalorcusto.Text = Me.dgvProdutos.CurrentRow.Cells(5).Value
                    Me.dgvProdutos.Rows.RemoveAt(rowToDelete)
                    txtqtdemovimentada.Enabled = True
                    btnIncluirproduto.Enabled = True
                    txtqtdemovimentada.Focus()

                Else
                    MsgBox("<Não há registro para ser alterado!>")
                End If
            End If
        Else
            If MsgBox("Deseja excluir o produto?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Movimento do Estoque") = MsgBoxResult.Yes Then
                If rowToDelete > -1 Then
                    Me.dgvProdutos.Rows.RemoveAt(rowToDelete)
                    txtqtdemovimentada.Enabled = True
                    txtvalorcusto.Enabled = True
                    btnIncluirproduto.Enabled = True
                    txtCodigoproduto.Focus()

                Else
                    MsgBox("<Não há registro para ser excluído!>")
                End If
            End If
        End If
    End Sub
End Class