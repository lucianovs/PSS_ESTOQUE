Imports System.Data.OleDb

Public Class frmRelSaldodoProduto
    Dim cQuery As String
    Dim cQuery_Armazens As String
    Dim dt As DataTable = New DataTable("EES003") ' Tabela de Armazens
    Dim sClaArmazem As String
    Dim sNomeArmazem As String
    Dim i As Integer





    Private Sub btnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click
        Me.Cursor = Cursors.WaitCursor

        Dim Rpt_Ds As New DataSet
        Dim RptPath As String
        Dim i As Integer
        Rpt_Ds.Clear()

        If Microsoft.VisualBasic.Left(cbarmazem.Text, 2) <> "00" Then

            cQuery = "SELECT EES002.ES002_CODPRO AS ES002_CODPRO, EES000.ES000_DESPRO AS ES000_DESPRO, EES002.ES002_CODARM AS ES002_CODARM, " & _
                     "EES003.ES003_DESARM AS ES003_DESARM, EES002.ES002_QTDSAL AS ES002_QTDSAL " & _
                     "FROM (EES002 INNER JOIN EES000 ON EES002.ES002_CODPRO = EES000.ES000_CODPRO) INNER JOIN EES003  ON EES002.ES002_CODARM = EES003.ES003_CODARM" & _
                     " WHERE EES002.ES002_CODARM = '" & Microsoft.VisualBasic.Left(cbarmazem.Text, 2) & "'" & _
                     " ORDER BY EES002.ES002_CODPRO"
        Else
            cQuery = "SELECT EES002.ES002_CODPRO AS Cod do produto, EES000.ES000_DESPRO AS Descricao do produto, EES002.ES002_CODARM AS Cod do Armazem, " & _
                     "EES003.ES003_DESARM AS Descricao do Armazem, EES002.ES002_QTDSAL AS Quantidade " & _
                     "FROM (EES002 INNER JOIN EES000 ON EES002.ES002_CODPRO = EES000.ES000_CODPRO) INNER JOIN EES003  ON EES002.ES002_CODARM = EES003.ES003_CODARM" & _
                     " WHERE EES000.ES000_CODARM <> '00'" & _
                     " ORDER BY EES002.ES002_CODPRO"

        End If

        Application.DoEvents()
        Using da As New OleDbDataAdapter()
            da.SelectCommand = New OleDbCommand(cQuery, g_ConnectBanco)

            'Preencher o Data Table
            da.Fill(Rpt_Ds)

            RptPath = LerDadosINI(nomeArquivoINI(), "PATH", "Reports", "C:\Desenvolvimento\Fontes\SSVP_Projeto\Report\")
            'frmReportViewer.ShowReport(Rpt_Ds, "RelSaldodoProduto.rpt", RptPath)
            FormReportViewSaldoProduto.ShowReport(Rpt_Ds, "RelSaldodoProduto.rpt", RptPath)
            Me.Cursor = Cursors.Default

        End Using



    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub frmRelSaldodoProduto_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call CarregarArmazens()
        cbarmazem.Items.Add("00 - Todos Armazéns")
        cbarmazem.Focus()
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
End Class