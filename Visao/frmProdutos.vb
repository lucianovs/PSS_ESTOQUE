Imports System.Data.OleDb
Imports System.Drawing.Printing

Public Class frmProdutos
    '?? Alterar para a Entidade Principal ??
    Dim dt As DataTable = New DataTable("EES000") ' Tabela de Produtos
    Dim dttipodeprod As DataTable = New DataTable("EES001") ' Tabela de Tipo de Produtos
    Dim dtmodcontabil As DataTable = New DataTable("EES007") ' Tabela de Modelo Contábil
    Dim dtarmazens As DataTable = New DataTable("EES003") ' Tabela de Armazens 


    Dim i As Integer
    Dim bAlterar As Boolean = False
    Dim bIncluir As Boolean = False
    Dim cQuery As String

    Private Sub TratarObjetos()
        Dim sClaTipodeProd As String
        Dim sNometTpodeProd As String = ""
        Dim sClaArmazem As String
        Dim sNomeArmazem As String = ""


        tssContReg.Text = "Registro " & (i + 1).ToString & "/" & dt.Rows.Count().ToString

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

        'Campos
        '?? Alterar para os seus objetos da Tela ??
        lblCodigo.Enabled = False 'bIncluir
        txtCodigo.Enabled = False 'bIncluir

        lbldatacad.Enabled = False
        dtpdatacad.Enabled = False
        lblUsucad.Enabled = False
        txtUsuarioCad.Enabled = False

        lbldatault.Enabled = False
        dtpdatault.Enabled = False
        lblultusuario.Enabled = False
        txtUsuarioUlt.Enabled = False

        lblDescricao.Enabled = bAlterar
        txtDescricao.Enabled = bAlterar
        lblarmazem.Enabled = bAlterar
        cbarmazem.Enabled = bAlterar
        lbltipodeproduto.Enabled = bAlterar
        cbtipodeproduto.Enabled = bAlterar

        lblcontacontabil.Enabled = bAlterar
        txtcontacontabil.Enabled = bAlterar

        lblControlaEstoque.Enabled = bAlterar
        cbSim.Enabled = bAlterar
        cbNao.Enabled = bAlterar
        lblstatus.Enabled = bAlterar  'Status Tipo do produto
        rgAtivo.Enabled = bAlterar
        rgInativo.Enabled = bAlterar

        'Outros Controles
        '*****************


        'Preencher Campos
        If i > -1 And bIncluir Then
            Call PreencherDados()
        End If


        If i > -1 And Not bIncluir Then
            txtCodigo.Text = dt.Rows(i).Item("ES000_CODPRO")
            'Data do  Cadastro
            dtpdatacad.Value = IIf(IsDBNull(dt.Rows(i).Item("ES000_DATCAD")), Date.Now, dt.Rows(i).Item("ES000_DATCAD"))
            If IsDBNull(dt.Rows(i).Item("ES000_USUCAD")) Then
                txtUsuarioCad.Text = ClassCrypt.Decrypt(g_Login)
            Else
                txtUsuarioCad.Text = getLoginaAcessoUsuario(dt.Rows(i).Item("ES000_USUCAD"))
            End If

            ' Ultima data Cadastro
            dtpdatault.Value = Date.Now 'IIf(IsDBNull(dt.Rows(i).Item("ES000_DATALT")), Date.Now, dt.Rows(i).Item("ES000_DATALT"))
            If IsDBNull(dt.Rows(i).Item("ES000_USUALT")) Then
                txtUsuarioUlt.Text = ClassCrypt.Decrypt(g_Login)   '  txtUsuarioUlt.Text = ""
            Else
                txtUsuarioUlt.Text = ClassCrypt.Decrypt(g_Login)
            End If
            txtDescricao.Text = dt.Rows(i).Item("ES000_DESPRO")

            'Verificando registros no combobox - Armazéns
            If Not IsDBNull(dt.Rows(i).Item("ES000_CODARM")) Then
                sClaArmazem = LerClasse_Armazens(dt.Rows(i).Item("ES000_CODARM"), sNomeArmazem)
            Else
                sClaArmazem = ""
                sNomeArmazem = ""
            End If
            cbarmazem.Text = sClaArmazem & IIf(sClaArmazem = "", "", " - ") & sNomeArmazem

            'Verificando registros no combobox - Tipo de Produtos
            If Not IsDBNull(dt.Rows(i).Item("ES000_TIPPRO")) Then
                sClaTipodeProd = LerClasse_TipodeProd(dt.Rows(i).Item("ES000_TIPPRO"), sNometTpodeProd)
            Else
                sClaTipodeProd = ""
                sNometTpodeProd = ""
            End If
            cbtipodeproduto.Text = sClaTipodeProd & IIf(sClaTipodeProd = "", "", " - ") & sNometTpodeProd

            txtcontacontabil.Text = dt.Rows(i).Item("ES000_CTACTB")

            If dt.Rows(i).Item("ES000_CONTES") = "S" Then
                cbSim.Checked = True
                cbNao.Checked = False
            Else
                cbSim.Checked = False
                cbNao.Checked = True
            End If

            If dt.Rows(i).Item("ES000_SITCAD") = "A" Then
                rgAtivo.Checked = True
            Else
                rgInativo.Checked = True
            End If

            'Outros Controles
            '****************
        End If

        'Outras Chamadas
        '***************
        'Verificar se é para excluir o registro comandado pelo browse
        If g_Comando = "excluir" Then
            Call Excluir_Registro()
        End If

    End Sub
    Private Sub PreencherDados()
        dtpdatacad.Value = Date.Now
        txtUsuarioCad.Text = ClassCrypt.Decrypt(g_Login)

        ' Ultima data Cadastro
        dtpdatault.Value = Date.Now
        txtUsuarioUlt.Text = ClassCrypt.Decrypt(g_Login)

        cbSim.Checked = True
        rgAtivo.Checked = True
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

        bAlterar = True
        Call TratarObjetos()
        dtpdatacad.Enabled = False
        dtpdatault.Enabled = False
        txtDescricao.Focus()
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
        txtDescricao.Focus()
    End Sub

    Private Sub btnIncluir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnIncluir.Click
        bAlterar = True
        bIncluir = True

        'Inicializar os seus Componentes de Entrada de Dados
        txtCodigo.Text = ""
        txtDescricao.Text = ""
        cbSim.Checked = False
        cbNao.Checked = False
        rgAtivo.Checked = True 'Status do produto ativo

        Call TratarObjetos()

    End Sub

    Private Sub btnGravar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGravar.Click
        Dim cSql As String = ""
        Dim cMensagem As String = ""
        Dim cmd As OleDbCommand
        Dim nProxCod_Registro As Integer
        Dim statuscontrolaestsimnao As String = ""
        Dim statusativoinativo As String = ""

        'Dim Codigoalfanumerioco As String


        If ConectarBanco() Then
            '?? Colocar o Comando SQL para Gravar (Update e Insert)
            If Validardados(cMensagem) Then
                If bIncluir Then
                    nProxCod_Registro = ProxCodChave("EES000", "ES000_CODPRO")
                    cSql = "INSERT INTO EES000 (ES000_CODPRO, ES000_DATCAD, ES000_USUCAD"
                    cSql += ",ES000_DATALT, ES000_USUALT"
                    cSql += ",ES000_CODARM, ES000_TIPPRO"
                    cSql += ",ES000_DESPRO, ES000_CTACTB"
                    cSql += ",ES000_CONTES, ES000_SITCAD"
                    cSql += ")"

                    'Checar se o staus Controla Estoque esta Sim ou Nao
                    If (cbSim.Checked = True) Then
                        statuscontrolaestsimnao = "S"
                    Else
                        statuscontrolaestsimnao = "N"
                    End If

                    'Checar se o staus do produto esta ativo ou inativo
                    If (rgAtivo.Checked = True) Then
                        statusativoinativo = "A"
                    Else
                        statusativoinativo = "I"
                    End If

                    'Inicio Convertendo codigo numerico para string
                    txtCodigo.Text = String.Format("{0:000000}", nProxCod_Registro)
                    'Fim

                    cSql += " values ('" & txtCodigo.Text & "','" & FormatarData(dtpdatacad.Text) & "', " & getCodUsuario(txtUsuarioCad.Text).ToString
                    cSql += ",'" & FormatarData(Today()) & "', " & getCodUsuario(txtUsuarioUlt.Text).ToString
                    cSql += ",'" & LerCod_Armazens(Microsoft.VisualBasic.Left(cbarmazem.Text, 2)).ToString & "', " & LerCod_TipdeProd(Microsoft.VisualBasic.Left(cbtipodeproduto.Text, 1)).ToString
                    cSql += ",'" & Trim(txtDescricao.Text) & "', '" & Trim(txtcontacontabil.Text) & "'"
                    cSql += ",'" & statuscontrolaestsimnao & "', '" & statusativoinativo & "'"
                    cSql += ")" '


                ElseIf bAlterar Then
                    'Checar se o staus Controla Estoque esta Sim ou Nao
                    If (cbSim.Checked = True) Then
                        statuscontrolaestsimnao = "S"
                    Else
                        statuscontrolaestsimnao = "N"
                    End If

                    'Checar se o staus esta ativo ou inativo
                    If (rgAtivo.Checked = True) Then
                        statusativoinativo = "A"
                    Else
                        statusativoinativo = "I"
                    End If

                    cSql = "UPDATE EES000 set ES000_DESPRO='" & Trim(txtDescricao.Text) & _
                            "',ES000_DATCAD='" & FormatarData(dtpdatacad.Text) & "'"
                    cSql += ",ES000_USUCAD =" & getCodUsuario(txtUsuarioCad.Text).ToString
                    cSql += ",ES000_DATALT ='" & FormatarData(Today) & "'"
                    cSql += ",ES000_USUALT = " & getCodUsuario(txtUsuarioUlt.Text).ToString
                    cSql += ",ES000_CODARM = '" & LerCod_Armazens(Microsoft.VisualBasic.Left(cbarmazem.Text, 2)).ToString & "'"
                    cSql += ",ES000_TIPPRO = " & LerCod_TipdeProd(Microsoft.VisualBasic.Left(cbtipodeproduto.Text, 1)).ToString
                    cSql += ",ES000_CTACTB = '" & Trim(txtcontacontabil.Text) & "'"
                    cSql += ",ES000_CONTES ='" & statuscontrolaestsimnao & "'"
                    cSql += ",ES000_SITCAD ='" & statusativoinativo & _
                            "' where ES000_CODPRO = '" & txtCodigo.Text & "'"

                End If
                cmd = New OleDbCommand(cSql, g_ConnectBanco)

                Try
                    cmd.ExecuteNonQuery()
                Catch ex As Exception
                    MsgBox(ex.ToString())
                Finally
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
                            'Subtrair 1 registro para possa ser atualizado no métado TratarObjetos 
                            'em seguida sera somado o valor do ponteiro "i" + 1 para ser exbido o ultimo registro cadastrado
                            If g_Comando = "incluir" Then i = dt.Rows.Count() - 1
                            TratarObjetos()
                        End If

                    End If
                End Try
            Else
                MsgBox(cMensagem)
            End If
        End If

    End Sub

    Private Function Validardados(ByRef cMensagem As String) As Boolean
        Dim bRetorno As Boolean = True

        '?? Acrescentar as validações da Tela ??
        If Trim(txtDescricao.Text) = "" Then
            cMensagem += " <A Descrição não pode estar vazia> "
            bRetorno = False
        End If

        If Trim(cbarmazem.Text) = "" Then
            cMensagem += " <O Armazem não pode estar vazia> "
            bRetorno = False
        End If

        If Trim(cbtipodeproduto.Text) = "" Then
            cMensagem += " <O Tipo de Produto não pode estar vazia> "
            bRetorno = False
        End If

        If Trim(txtcontacontabil.Text) = "" Then
            cMensagem += " <A Conta Contábil não pode estar vazia> "
            bRetorno = False
        End If

        If (cbSim.Checked = False) And (cbNao.Checked = False) Then
            cMensagem += " <Controla Estoque - Sim ou Não?> "
            bRetorno = False
        End If

        If (rgAtivo.Checked = False) And (rgInativo.Checked = False) Then
            cMensagem += " <Status do Produto é inválido> "
            bRetorno = False
        End If

        Return (bRetorno)

    End Function

    Private Sub btnExcluir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExcluir.Click

        Call Excluir_Registro()

    End Sub

    Private Sub Excluir_Registro()
        Dim cSql As String
        Dim cMensagem As String = ""
        Dim cmd As OleDbCommand

        If MsgBox("Deseja excluir este registro?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "cadastro de Usuarios") = MsgBoxResult.Yes Then
            '?? Alterar para a Tabela a ser Excluída ??
            cSql = "DELETE FROM EES000 where ES000_CODPRO = '" & Trim(txtCodigo.Text) & "'"
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

        'O produto Controla o Estoque - Sim ou Não
        If cbSim.Checked = True Then
            lblControlaEstoque.Text = "Controla Estoque:     Sim"
        Else
            lblControlaEstoque.Text = "Controla Estoque:     Não"
        End If

        ' Verifica se registro esta Ativo ou Inativo
        If rgAtivo.Checked = True Then
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
        lblControlaEstoque.Text = "Controla Estoque"
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

    Private Sub frmTipoDeProdutos_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        g_Param(1) = txtCodigo.Text 'Voltar com a Chave do registro do formulário
    End Sub

    Private Sub frmProdutos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim cQuery_TipodeProduto As String
        Dim cQuery_Armazens As String
        Dim i_point As Integer

        'Criar um adaptador que vai fazer o download de dados da base de dados
        '?? Alterar o Código para a Entidade Principal ??
        If Me.Tag = 4 Then
            cQuery = "SELECT * FROM EES000"
        Else
            cQuery = "SELECT * FROM EES000 where ES000_CODPRO = " & g_Param(1)
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
                If dt.Rows(i_point).Item("ES000_CODPRO").ToString = g_Param(1) Then
                    Exit For
                End If
            Next
            i = i_point

            'Iniciar com o comando passado
            If g_Comando = "incluir" Then
                bIncluir = True
                bAlterar = True
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
            cQuery_Armazens += "(EES003 inner join EES000 on EES000.ES000_CODARM =EES003.ES003_CODARM) WHERE " & _
                "EES000.ES000_USUCAD =" & getCodUsuario(ClassCrypt.Decrypt(g_Login)).ToString & _
                " AND ES000_CODARM > 0 and "
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
        cQuery_TipodeProduto = "SELECT ES001_TIPPRO, ES001_DESTIP FROM "
        If LCase(ClassCrypt.Decrypt(g_Login)) <> "admin" Then 'admin
            cQuery_TipodeProduto += "(EES001 inner join EES000 on EES000.ES000_TIPPRO =EES001.ES001_TIPPRO) WHERE " & _
                "EES000.ES000_USUCAD =" & getCodUsuario(ClassCrypt.Decrypt(g_Login)).ToString & _
                " AND ES000_TIPPRO > 0 and "
        Else
            cQuery_TipodeProduto += "EES001 WHERE "
        End If
        cQuery_TipodeProduto += "right(ES001_TIPPRO,2)<>'00'"

        Using da As New OleDbDataAdapter()
            da.SelectCommand = New OleDbCommand(cQuery_TipodeProduto, g_ConnectBanco)

            ' Preencher o DataTable 
            da.Fill(dttipodeprod)
            If dttipodeprod.Rows.Count() > 0 Then
                For x = 0 To dttipodeprod.Rows.Count() - 1
                    cbtipodeproduto.Items.Add(dttipodeprod.Rows(x).Item("ES001_TIPPRO") & " - " & dttipodeprod.Rows(x).Item("ES001_DESTIP"))
                Next
            Else
                cbtipodeproduto.Items.Clear()
            End If
        End Using
        dttipodeprod.Clear()


        TratarObjetos()
    End Sub

    Private Sub txtDescricao_TextChanged(sender As Object, e As EventArgs) Handles txtDescricao.TextChanged

    End Sub

    Private Sub lblDescricao_Click(sender As Object, e As EventArgs) Handles lblDescricao.Click

    End Sub

    Private Sub txtUsuarioCad_TextChanged(sender As Object, e As EventArgs) Handles txtUsuarioCad.TextChanged

    End Sub

    Private Sub lblControlaEstoque_Click(sender As Object, e As EventArgs) Handles lblControlaEstoque.Click

    End Sub

    Private Sub lbldatault_Click(sender As Object, e As EventArgs) Handles lbldatault.Click

    End Sub

    Private Sub lblUsucad_Click(sender As Object, e As EventArgs) Handles lblUsucad.Click

    End Sub

    Private Sub lbltipodeproduto_Click(sender As Object, e As EventArgs) Handles lbltipodeproduto.Click

    End Sub

    Private Sub cbSim_Click(sender As Object, e As EventArgs) Handles cbSim.Click
        If cbSim.Checked = True Then
            cbNao.Checked = False '
        End If
    End Sub

    Private Sub cbNao_Click(sender As Object, e As EventArgs) Handles cbNao.Click
        If cbNao.Checked = True Then
            cbSim.Checked = False '
        End If
    End Sub
End Class