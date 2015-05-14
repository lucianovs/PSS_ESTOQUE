Imports System.Windows.Forms
Imports System.Data.OleDb

Public Class mdiPrincipal

    Private Sub mdiPrincipal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim Argumentos() As String = Environment.GetCommandLineArgs
        Dim sNomeUsuario As String
        Dim bArguments As Boolean = True
        Dim x, y As Integer

        'g_Modulo = "COLABORADOR"
        g_Modulo = "ESTOQUE"

        'Ativar os Parâmetros iniciais de Segurança
        'Resgatar as Informações da Chamada
        x = 0
        Y = 0
        g_Login = ""

        '***** Desativar as opções abaixo para usar local
        g_Login = ClassCrypt.Encrypt("admin")
        ''g_Login =  ClassCrypt.Encrypt("jose.alves")
        ''g_Login = ClassCrypt.Encrypt("luciano.vieira")
        bArguments = False
        '*****
        Try
            Do While bArguments
                If Environment.CommandLine(x) = "-" Then
                    If y = 0 Then
                        y = x
                    Else
                        bArguments = False
                    End If
                ElseIf y <> 0 Then
                    g_Login += Environment.CommandLine(x)
                End If
                x += 1
            Loop

            'MsgBox(g_Login)
            If g_Login = "" Then
                'Ativar estas Linhas quando for colocar em produção
                MsgBox("Este programa não tem permissão para ser executado. Contactar o administrador da rede!!", MsgBoxStyle.Critical)
                Application.Exit()
            End If
        Catch ex As Exception
            MsgBox("Este programa não tem permissão para ser executado. Contactar o administrador da rede!!", MsgBoxStyle.Critical)
            Application.Exit()

        Finally
            'Conection String
            g_ConnectString = (LerDadosINI(nomeArquivoINI(), "CONEXAO", "ConnectString", _
                ClassCrypt.Encrypt("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=SSVP.accdb;Persist Security Info=False;")))

            'Conectar com o Banco de dados
            If Not ConectarBanco() Then
                Application.Exit()
            End If

            'Ler o Usuário e Validar o Acesso
            sNomeUsuario = LerUsuario(ClassCrypt.Decrypt(g_Login), Nothing)

            If sNomeUsuario <> "" Then
                Me.Text = "Modulo " & g_Modulo & " - Usuário: " & sNomeUsuario
            Else
                Application.Exit()
            End If

            'Verificar o acesso às opções do sistema
            Dim cModulo As Integer = getCodModulo(g_Modulo) 'Pegar o código do Módulo
            Dim nCodUsuario As Integer = getCodUsuario(ClassCrypt.Decrypt(g_Login)) 'pegar o código do usuario

            For Each _control As Object In Me.Controls
                If TypeOf (_control) Is MenuStrip Then
                    For Each itm As ToolStripMenuItem In _control.items
                        If itm.Text <> "&Sair" And itm.Name.ToString.StartsWith("menu") Then
                            itm.Tag = NivelAcesso(nCodUsuario, cModulo, itm.Name, "")
                            itm.Enabled = itm.Tag > 0
                            'Função para Verificar os SubItens do menu
                            If itm.DropDownItems.Count > 0 Then LoopMenuItems(itm, nCodUsuario, cModulo, itm.Name)
                        End If
                    Next
                End If
            Next
        End Try

    End Sub

    Private Function LoopMenuItems(ByVal parent As ToolStripMenuItem, nCodUsuario As Integer, cModulo As Integer, fPrincOpcao As String) As Object
        Dim retval As Object = Nothing

        For Each child As Object In parent.DropDownItems

            'MessageBox.Show("Child : " & child.name)

            If TypeOf (child) Is ToolStripMenuItem Then
                If child.Text <> "Sair" And child.Name.ToString.StartsWith("menu") Then
                    child.Tag = NivelAcesso(nCodUsuario, cModulo, child.Name, fPrincOpcao)
                    child.Enabled = child.Tag > 0
                    If child.DropDownItems.Count > 0 Then
                        retval = LoopMenuItems(child, nCodUsuario, cModulo, child.name)
                        If Not retval Is Nothing Then Exit For
                    End If
                End If
            End If
        Next

        Return retval
    End Function

    Private Sub menuConfiguracoes_Click(sender As Object, e As EventArgs) Handles menuSisConfiguracoes.Click
        Dim ChildForm As New Parametros

        ChildForm.MdiParent = Me
        ChildForm.Tag = menuSisConfiguracoes.Tag 'é gravado no tag do menu o nível de acesso
        ChildForm.Show()

    End Sub

    Private Sub menuUsuarios_Click(sender As Object, e As EventArgs) Handles menuSisUsuarios.Click
        '?? Alterar os parâmetros para passar ao Browse (Entudade e Form. do Cadastro) ??
        Dim frmBrowse_Usuario As frmBrowse = New frmBrowse("ESI000", "frmUsuario")

        frmBrowse_Usuario.MdiParent = Me
        frmBrowse_Usuario.Tag = menuSisUsuarios.Tag 'é gravado no tag do menu o nível de acesso
        frmBrowse_Usuario.Text = menuSisUsuarios.Text
        frmBrowse_Usuario.Show()

    End Sub

    Private Sub menuRelatorios_Click(sender As Object, e As EventArgs) Handles menuRelatorios.Click

    End Sub

    Private Sub menuCadTipoDeOcupacao_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub menuCadTipoDeComplemento_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub menuVincularUsuárioXUnidades_Click(sender As Object, e As EventArgs)
    End Sub

    Private Sub menuGerenciarUnidades_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub menuSolicitarAgregaçãoDeUnidades_Click(sender As Object, e As EventArgs)
    End Sub

    Private Sub menuRelUnidades_Click(sender As Object, e As EventArgs)


    End Sub

    Private Sub ContentsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ContentsToolStripMenuItem.Click

    End Sub

    Private Sub menuConsAgre_Click(sender As Object, e As EventArgs)
        Dim cQuery As String
        Dim dtQuery As DataTable = New DataTable("EUN015")
        Dim cmd As OleDbCommand
        Dim ix As Double
        Dim CodRed As Integer

        'Atualizar o num. de registro da Agregação na Unidade
        cQuery = "SELECT UN015_NUMAGR, UN015_CLAUNI FROM EUN015"
        Using daTabela As New OleDbDataAdapter()
            daTabela.SelectCommand = New OleDbCommand(cQuery, g_ConnectBanco)

            ' Preencher o DataTable 
            daTabela.Fill(dtQuery)
            For ix = 0 To dtQuery.Rows.Count - 1
                CodRed = LerCod_Unidade(dtQuery.Rows(ix).Item("UN015_CLAUNI"))
                cQuery = "UPDATE EUN015 set UN015_CODCF=" & CodRed & _
                        " where UN015_NUMAGR = " & dtQuery.Rows(ix).Item("UN015_NUMAGR").ToString

                cmd = New OleDbCommand(cQuery, g_ConnectBanco)

                Try
                    cmd.ExecuteNonQuery()
                Catch ex As Exception
                    MsgBox(ex.ToString())
                Finally
                End Try
            Next
        End Using

        dtQuery.Clear()

        MsgBox("Termino da Atualizacao !!")

    End Sub

    Private Sub menuCadTipoDeProdutos_Click(sender As Object, e As EventArgs) Handles menuCadTipodeProdutos.Click
        Dim frmBrowse_TipoDeProdutos As frmBrowse = New frmBrowse("EES001", "frmTipoDeProdutos")

        frmBrowse_TipoDeProdutos.MdiParent = Me
        frmBrowse_TipoDeProdutos.Tag = menuCadTipodeProdutos.Tag 'é gravado no tag do menu o nível de acesso
        frmBrowse_TipoDeProdutos.Text = menuCadTipodeProdutos.Text
        frmBrowse_TipoDeProdutos.Show()
    End Sub

    Private Sub menuConsultas_Click(sender As Object, e As EventArgs) Handles menuConsultas.Click

    End Sub

    Private Sub mnuSair_Click(sender As Object, e As EventArgs) Handles mnuSair.Click
        Application.Exit()
    End Sub


    Private Sub menuCadArmazens_Click(sender As Object, e As EventArgs) Handles menuCadArmazens.Click
        Dim frmBrowse_Armazens As frmBrowse = New frmBrowse("EES003", "frmArmazens")

        frmBrowse_Armazens.MdiParent = Me
        frmBrowse_Armazens.Tag = menuCadArmazens.Tag 'é gravado no tag do menu o nível de acesso
        frmBrowse_Armazens.Text = menuCadArmazens.Text
        frmBrowse_Armazens.Show()
    End Sub

    Private Sub menuCadProduto_Click(sender As Object, e As EventArgs) Handles menuCadProdutos.Click
        Dim frmBrowse_Produto As frmBrowse = New frmBrowse("EES000", "frmProdutos")

        frmBrowse_Produto.MdiParent = Me
        frmBrowse_Produto.Tag = menuCadProdutos.Tag 'é gravado no tag do menu o nível de acesso
        frmBrowse_Produto.Text = menuCadProdutos.Text
        frmBrowse_Produto.Show()
    End Sub

    Private Sub menuCadTipodeMovimentos_Click(sender As Object, e As EventArgs) Handles menuCadTipodeMovimentos.Click
        Dim frmBrowse_TipodeMovimentos As frmBrowse = New frmBrowse("EES006", "frmTipoDeMovimentos")

        frmBrowse_TipodeMovimentos.MdiParent = Me
        frmBrowse_TipodeMovimentos.Tag = menuCadTipodeMovimentos.Tag 'é gravado no tag do menu o nível de acesso
        frmBrowse_TipodeMovimentos.Text = menuCadTipodeMovimentos.Text
        frmBrowse_TipodeMovimentos.Show()
    End Sub
    Private Sub menuCadEstruturadeProdutos_Click(sender As Object, e As EventArgs) Handles menuCadEstruturadeProdutos.Click
        'MsgBox("Cadastro de Estrutura de Produtos em manutenção. Por favor aguarde à liberação!")
        Dim frmBrowse_EstruturadeProdutos As frmBrowse = New frmBrowse("QES004", "frmEstruturadeProdutos")

        frmBrowse_EstruturadeProdutos.MdiParent = Me
        frmBrowse_EstruturadeProdutos.Tag = menuCadEstruturadeProdutos.Tag 'é gravado no tag do menu o nível de acesso
        frmBrowse_EstruturadeProdutos.Text = menuCadEstruturadeProdutos.Text
        frmBrowse_EstruturadeProdutos.Show()
    End Sub

    Private Sub menuProcMovimentodeEstoque_Click(sender As Object, e As EventArgs) Handles menuProcMovimentodeEstoque.Click
        MsgBox("Processo de Movimento de Estoque em manutenção. Por favor aguarde à liberação!")
    End Sub
    Private Sub menuProcAtualizaçãodeSaldo_Click(sender As Object, e As EventArgs) Handles menuProcAtualizaçãodeSaldo.Click
        MsgBox("Processo de Atualização de Saldo em manutenção. Por favor aguarde à liberação!")
    End Sub
    Private Sub menuProcFechamentodeEstoque_Click(sender As Object, e As EventArgs) Handles menuProcFechamentodeEstoque.Click
        MsgBox("Processo de Fechamento de Estoque em manutenção. Por favor aguarde à liberação!")
    End Sub

    Private Sub menuProcIntegraçãoContábil_Click(sender As Object, e As EventArgs) Handles menuProcIntegraçãoContábil.Click
        MsgBox("Processo de Integração Contábil em manutenção. Por favor aguarde à liberação!")
    End Sub

    Private Sub menuProcDigitaçãodoInventário_Click(sender As Object, e As EventArgs) Handles menuProcDigitaçãodoInventário.Click
        MsgBox("Processo de Digitação do Inventário em manutenção. Por favor aguarde à liberação!")
    End Sub

    Private Sub menuProcProcessaroinventário_Click(sender As Object, e As EventArgs) Handles menuProcProcessaroinventário.Click
        MsgBox("Processo de Processar o Inventário em manutenção. Por favor aguarde à liberação!")
    End Sub
    Private Sub menuConsSaldodoProduto_Click(sender As Object, e As EventArgs) Handles menuConsSaldodoProduto.Click
        MsgBox("Consulta de Saldo de Produto em manutenção. Por favor aguarde à liberação!")
    End Sub

    Private Sub menuRelSaldodoProduto_Click(sender As Object, e As EventArgs) Handles menuRelSaldodoProduto.Click
        MsgBox("Relatório de Saldo de Produto em manutenção. Por favor aguarde à liberação!")
    End Sub

    Private Sub menuRelContagemdoInventário_Click_1(sender As Object, e As EventArgs) Handles menuRelContagemdoInventário.Click
        MsgBox("Relatório de Contagem de Inventário em manutenção. Por favor aguarde à liberação!")
    End Sub

    Private Sub menuCadastro_Click(sender As Object, e As EventArgs) Handles menuCadastro.Click

    End Sub
End Class
