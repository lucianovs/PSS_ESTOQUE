Imports System.Data.OleDb

Public Class frmConsultaSaldodoProduto
    Dim dtGridprod As DataTable = New DataTable("EES004")
    Dim cQuery As String
    Dim dt As DataTable = New DataTable("EES003") ' Tabela de Armazens
    Dim sClaArmazem As String
    Dim sNomeArmazem As String
    Dim i As Integer


    Dim cQuery_Armazens As String

    Private Sub btnPesquisa_Click(sender As Object, e As EventArgs) Handles btnPesquisa.Click
        If cbarmazem.Text <> "" Then

            dgvProdutos.DataSource = Nothing
            dtGridprod.Clear()


            cQuery = "SELECT EES002.ES002_CODPRO AS Cod do produto, EES000.ES000_DESPRO AS Descricao do produto, EES002.ES002_CODARM AS Cod do Armazem, " & _
                     "EES003.ES003_DESARM AS Descricao do Armazem, EES002.ES002_QTDSAL AS Quantidade " & _
                     "FROM (EES002 INNER JOIN EES000 ON EES002.ES002_CODPRO = EES000.ES000_CODPRO) INNER JOIN EES003  ON EES002.ES002_CODARM = EES003.ES003_CODARM" & _
                     " WHERE EES000.ES000_CODARM = '" & Microsoft.VisualBasic.Left(cbarmazem.Text, 2) & "'" & _
                     " ORDER BY EES002.ES002_CODPRO"



            Using da As New OleDbDataAdapter()
                da.SelectCommand = New OleDbCommand(cQuery, g_ConnectBanco)
                ' Preencher o DataTable  
                da.Fill(dtGridprod)
            End Using



            If dtGridprod.Rows.Count > 0 Then
                dgvProdutos.DataSource = dtGridprod

                dgvProdutos.Columns(0).Width = 100
                dgvProdutos.Columns(1).Width = 150
                dgvProdutos.Columns(2).Width = 120
                dgvProdutos.Columns(3).Width = 150
                dgvProdutos.Columns(4).Width = 70

                dgvProdutos.ReadOnly = True
            Else
                MsgBox("<Armazém não encontrado, selecione outro armazém!>")
                dtGridprod.Clear()
                dgvProdutos.DataSource = Nothing
                cbarmazem.Focus()
            End If
        Else
            MsgBox("<Armazém em branco, selecione o armazém desejado!>")
            dtGridprod.Clear()
            dgvProdutos.DataSource = Nothing
            cbarmazem.Focus()
        End If
        tssContReg.Text = "Total de Itens: " & Format(dtGridprod.Rows.Count, "###0")
    End Sub
    Private Sub CarregarArmazens()

        Dim i_point As Integer
        '     cQuery_Armazens = "SELECT ES000_CODPRO,ES000_DESPRO,ES000_CODARM FROM EES000"
        cQuery_Armazens = "SELECT * FROM EES003 where ES003_CODARM <> 'I'"

        Using da As New OleDbDataAdapter()
            da.SelectCommand = New OleDbCommand(cQuery_Armazens, g_ConnectBanco)

            ' Preencher o DataTable 
            da.Fill(dt)
        End Using


        'Verificando registros no combobox - Armazéns
        For i_point = 0 To dt.Rows.Count() - 1
            If Not IsDBNull(dt.Rows(i_point).Item("ES003_CODARM")) Then
                sClaArmazem = LerClasse_Armazens(dt.Rows(i_point).Item("ES003_CODARM"), sNomeArmazem)

                cbarmazem.Items.Add(sClaArmazem & IIf(sClaArmazem = "", "", " - ") & sNomeArmazem)
            Else
                sClaArmazem = ""
                sNomeArmazem = ""
            End If
        Next



    End Sub

    Private Sub frmConsultaSaldodoProduto_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dtGridprod.Clear()
        dgvProdutos.DataSource = Nothing
        Call CarregarArmazens()
        tssContReg.Text = "Total de Itens: " & Format(dtGridprod.Rows.Count, "###0")
        cbarmazem.Focus()
    End Sub

    Private Sub txtPequisa_KeyPress(sender As Object, e As KeyPressEventArgs)
        If e.KeyChar = Chr(13) Then
            btnPesquisa.PerformClick()
        End If
    End Sub

    Private Sub btnsair_Click(sender As Object, e As EventArgs) Handles btnsair.Click
        dtGridprod.Clear() 'Limpar o DataTable
        Me.Close()
    End Sub

End Class