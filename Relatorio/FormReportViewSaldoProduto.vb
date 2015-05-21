Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine
Public Class FormReportViewSaldoProduto

    Public Sub ShowReport(ByVal DataTbl As DataSet, _
                    ByVal RptName As String, _
                     ByVal RptPath As String)

        Dim ObjRpt As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        'Dim ObjRpt As New ReportDocument

        ObjRpt.Load(RptPath & RptName)

        Application.DoEvents()

        ' ObjRpt.SetDataSource(DataTbl)
        ObjRpt.SetDataSource(DataTbl.Tables(0))

        Me.CrystalReportSaldodoProduto.ReportSource = ObjRpt
        Me.CrystalReportSaldodoProduto.Refresh()
        Me.Show()

    End Sub

End Class