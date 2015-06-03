Public Class ClassFuncoes
    'Classe para opção Funçoes
    'Autor: Antônio Carlos - Analista de Sistemas
    'Data: 31/06/2015


    'Formatar TextBox - moeda
    Public Shared Sub TextBoxMoeda(ByRef txt As TextBox)
        Dim n As String = String.Empty
        Dim v As Double = 0
        Try
            n = txt.Text.Replace(",", "").Replace(".", "")
            If n.Equals("") Then n = "000"
            n = n.PadLeft(3, "0")
            If n.Length > 3 And n.Substring(0, 1) = "0" Then n = n.Substring(1, n.Length - 1)
            v = Convert.ToDouble(n) / 100
            txt.Text = String.Format("{0:N}", v)
            txt.SelectionStart = txt.Text.Length
        Catch ex As Exception
            MessageBox.Show(ex.Message, "TextBoxMoeda")
        End Try
    End Sub

    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    ' Função que pega apenas os valores numericos da string
    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    Public Shared Function SoNumero(Text As String) As String
        Dim i As Integer, j As String
        For i = 1 To Len(Text)
            If Asc(Mid(Text, i, 1)) < 48 Or _
               Asc(Mid(Text, i, 1)) > 57 Then
            Else
                j = j & Mid(Text, i, 1)
            End If
            SoNumero = j
        Next
    End Function

    'Verifica se numero é inteiro
    Public Shared Function IsInteger(ByVal Numero As String) As Boolean
        If IsNumeric(Numero) = True Then
            If Numero.Contains(",") = True Then Return False
            Return True
        End If
        Return False
    End Function
End Class
