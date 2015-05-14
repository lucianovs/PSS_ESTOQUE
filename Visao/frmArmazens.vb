Imports System.Data.OleDb
Imports System.Drawing.Printing

Public Class frmArmazens
    '?? Alterar para a Entidade Principal ??
    Dim dt As DataTable = New DataTable("EES003")
    Dim dtconsulta As DataTable = New DataTable("EES003")

    Dim i As Integer
    Dim bAlterar As Boolean = False
    Dim bIncluir As Boolean = False
    Dim cQuery As String
    Dim Codigook As Boolean = True



    Private Sub TratarObjetos()

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
        If bIncluir = True Then
            lblCodigo.Enabled = bIncluir 'bIncluir
            txtCodigo.Enabled = bIncluir 'bIncluir
        Else
            lblCodigo.Enabled = False 'bIncluir
            txtCodigo.Enabled = False 'bIncluir
        End If


        lblDescricao.Enabled = bAlterar
        txtDescricao.Enabled = bAlterar
        lblstatus.Enabled = bAlterar  'Status Tipo do produto
        rgAtivo.Enabled = bAlterar
        rgInativo.Enabled = bAlterar

        'Outros Controles
        '*****************


        'Preencher Campos
        If i > -1 And Not bIncluir Then
            txtCodigo.Text = dt.Rows(i).Item("ES003_CODARM")
            txtDescricao.Text = dt.Rows(i).Item("ES003_DESARM")
            If dt.Rows(i).Item("ES003_SITCAD") = "A" Then
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
        bIncluir = False
        Call TratarObjetos()
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

    End Sub

    Private Sub btnIncluir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnIncluir.Click
        bAlterar = True
        bIncluir = True

        'Inicializar os seus Componentes de Entrada de Dados
        txtCodigo.Text = ""
        txtDescricao.Text = ""
        rgAtivo.Checked = True 'Status do produto ativo

        Call TratarObjetos()
        txtCodigo.Focus()
    End Sub

    Private Sub btnGravar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGravar.Click
        Dim cSql As String = ""
        Dim cMensagem As String = ""
        Dim cmd As OleDbCommand
        'Dim nProxCod_Registro As Integer
        Dim statusativoinativo As String = ""

        If ConectarBanco() Then
            '?? Colocar o Comando SQL para Gravar (Update e Insert)
            ' Verifica se código foi cadastrado
            If bIncluir Then
                Call Verificar_Codigo()
            End If

            If Validardados(cMensagem) And Codigook = True Then
                If bIncluir Then
                    'nProxCod_Registro = ProxCodChave("EES003", "ES003_CODARM")
                    cSql = "INSERT INTO EES003 (ES003_CODARM, ES003_DESARM, ES003_SITCAD)"

                    'Checar se o staus esta ativo ou inativo
                    If (rgAtivo.Checked = True) Then
                        statusativoinativo = "A"
                    Else
                        statusativoinativo = "I"
                    End If

                    cSql += " values ('" & txtCodigo.Text & "','" & txtDescricao.Text & "', '" & statusativoinativo & "')"

                ElseIf bAlterar Then
                    'Checar se o staus esta ativo ou inativo
                    If (rgAtivo.Checked = True) Then
                        statusativoinativo = "A"
                    Else
                        statusativoinativo = "I"
                    End If

                    cSql = "UPDATE EES003 set ES003_DESARM='" & Trim(txtDescricao.Text) & _
                            "', ES003_SITCAD ='" & statusativoinativo & _
                            "' where ES003_CODARM = '" & txtCodigo.Text & "'"
                    'acessoWEB=" & If(chkSIM.Checked = 0, False, True)
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
                            'i = dt.Rows.Count()
                            TratarObjetos()
                        End If

                    End If
                End Try
            Else
                If Trim(cMensagem) <> "" Then MsgBox(cMensagem)
            End If
        End If

    End Sub

    Private Function Validardados(ByRef cMensagem As String) As Boolean
        Dim bRetorno As Boolean = True

        '?? Acrescentar as validações da Tela ??
        If Trim(txtCodigo.Text) = "" Then
            cMensagem += " <O código não pode estar vazio> "
            bRetorno = False
        End If

        If Trim(txtDescricao.Text) = "" Then
            cMensagem += " <A descrição não pode estar vazia> "
            bRetorno = False
        End If

        If (rgAtivo.Checked = False) And (rgInativo.Checked = False) Then
            cMensagem += " <Status do tipo do produto é inválido> "
            bRetorno = False
        End If

        Return (bRetorno)

    End Function

    Private Sub btnExcluir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExcluir.Click

        Call Excluir_Registro()

    End Sub

    ' Verificar Código na tabela
    Private Sub Verificar_Codigo()

        Dim reg_encontrado As Integer
        Dim i_point As Integer
        Dim icont As Integer

        reg_encontrado = 0
        If Trim(txtCodigo.Text <> "") Then
            cQuery = "SELECT * FROM EES003 where ES003_CODARM = '" & Trim(txtCodigo.Text) & "'"
        End If

        Using daconsulta As New OleDbDataAdapter()
            daconsulta.SelectCommand = New OleDbCommand(cQuery, g_ConnectBanco)

            ' Preencher o DataTable 
            daconsulta.Fill(dtconsulta)
        End Using

        'Verificar_Codigo se já existe registro salvo
        If dtconsulta.Rows.Count > 0 Then
            For icont = 0 To dtconsulta.Rows.Count() - 1
                If dtconsulta.Rows(icont).Item("ES003_CODARM").ToString = Trim(txtCodigo.Text) Then
                    reg_encontrado = reg_encontrado + 1
                    Exit For
                End If
            Next

        End If

        If reg_encontrado > 0 Then
            MsgBox("Código já cadastrado, digite outro!")
            ' txtCodigo.Clear()
            Codigook = False
            txtCodigo.Focus()
        Else
            Codigook = True '
            If Me.Tag = 4 Then
                cQuery = "SELECT * FROM EES003"
            Else
                cQuery = "SELECT * FROM EES003 where ES003_CODARM = " & g_Param(1)
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
                    If dt.Rows(i_point).Item("ES003_CODARM").ToString = g_Param(1) Then
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

        If MsgBox("Deseja excluir este registro?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "cadastro de Usuarios") = MsgBoxResult.Yes Then
            '?? Alterar para a Tabela a ser Excluída ??
            cSql = "DELETE FROM EES003 where ES003_CODARM = '" & Trim(txtCodigo.Text) & "'"
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

    Private Sub frmArmazens_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        g_Param(1) = txtCodigo.Text 'Voltar com a Chave do registro do formulário
    End Sub

    Private Sub frmArmazens_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim i_point As Integer

        'Criar um adaptador que vai fazer o download de dados da base de dados
        '?? Alterar o Código para a Entidade Principal ??
        If Me.Tag = 4 Then
            cQuery = "SELECT * FROM EES003"
        Else
            cQuery = "SELECT * FROM EES003 where ES003_CODARM = " & g_Param(1)
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
                If dt.Rows(i_point).Item("ES003_CODARM").ToString = g_Param(1) Then
                    Exit For
                End If
            Next
            i = i_point

            'Iniciar com o comando passado
            If g_Comando = "incluir" Then
                bIncluir = True
                bAlterar = True
                rgAtivo.Checked = True
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

End Class