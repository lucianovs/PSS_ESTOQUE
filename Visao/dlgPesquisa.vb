Imports System.Windows.Forms
Imports System.Data.OleDb

Public Class dlgPesquisa
    Dim cQuery As String

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click, lstPesquisa.DoubleClick
        If lstPesquisa.SelectedItem.ToString <> "" Then
            'Foi selecionado um Colaborador
            txtPesquisa.Text = lstPesquisa.SelectedItem
            'Microsoft.VisualBasic.Left(lstPesquisa.SelectedItem, 6)
            Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Me.Close()
        Else
            MsgBox("Nenhum registro foi selecionado!!")
        End If
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub btnPesquisa_Click(sender As Object, e As EventArgs) Handles btnPesquisa.Click
        Dim nPos As Integer = 99
        Dim nSeq As Integer = 0
        Dim nStart As Integer = 1
        Dim sNome(10) As String
        Dim sItemLista As String
        'Dim CampoCod As String
        'Dim CampoDesc As String

        Dim dtPesquisar As DataTable = New DataTable(g_PequisaGenerica)
        'Dim dtPesquisar As DataTable = New DataTable("EES000")

        If Not Trim(txtPesquisa.Text) = "" Then
            If pesq_coddif = "" Then
                cQuery = "Select EES000.ES000_CODPRO, EES000.ES000_DESPRO, EES000.ES000_SITCAD From EES000 " & _
                    "where EES000.ES000_SITCAD<>'I' AND EES000.ES000_CODPRO<>'000000'"
            End If
            If pesq_coddif <> "" Then
                cQuery = "Select EES000.ES000_CODPRO, EES000.ES000_DESPRO, EES000.ES000_SITCAD From EES000 where EES000.ES000_SITCAD <> 'I' AND " & _
                    "EES000.ES000_CODPRO<>'" & pesq_coddif & "'"
            End If
            nStart = 1

            lstPesquisa.Items.Clear()

            Do Until nPos = 0
                nPos = InStr(nStart, txtPesquisa.Text, " ")
                If nPos > 0 Then
                    sNome(nSeq) = Mid(txtPesquisa.Text, nStart, nPos - nStart)
                    nStart = nPos + 1
                    nSeq += 1
                Else
                    sNome(nSeq) = Mid(txtPesquisa.Text, nStart, Len(txtPesquisa.Text) - nStart + 1)
                End If
            Loop
            'Montar a Condição
            For nPos = 0 To nSeq
                cQuery += " and EES000.ES000_DESPRO LIKE '%" & sNome(nPos) & "%'"
            Next nPos
            cQuery += " order by EES000.ES000_DESPRO"

            Using da As New OleDbDataAdapter()
                da.SelectCommand = New OleDbCommand(cQuery, g_ConnectBanco)

                ' Preencher o DataTable 
                da.Fill(dtPesquisar)
            End Using

            For nSeq = 0 To dtPesquisar.Rows.Count - 1
                sItemLista = dtPesquisar.Rows(nSeq).Item("ES000_CODPRO") & " | "
                sItemLista += IIf(IsDBNull(dtPesquisar.Rows(nSeq).Item("ES000_DESPRO")), "", dtPesquisar.Rows(nSeq).Item("ES000_DESPRO"))

                lstPesquisa.Items.Add(sItemLista)
            Next nSeq

            dtPesquisar.Clear()
        Else
            MsgBox("Digite um nome para pesquisar. Para melhor performance, digitar nome e sobrenome.'")
        End If

    End Sub

    Private Sub lstPesquisa_DoubleClick(sender As Object, e As EventArgs) Handles lstPesquisa.DoubleClick

    End Sub

    Private Sub lstPesquisa_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstPesquisa.SelectedIndexChanged

    End Sub

    Private Sub dlgPesquisa_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtPesquisa.Focus() '
    End Sub
End Class
