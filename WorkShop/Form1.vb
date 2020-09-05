Imports System.IO
Public Class Form1
    Private ReadOnly filePath = "..\..\workshop.txt"
    Private allWorkShops() As WorkShop
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetFile()
        FillList()
    End Sub
    Private Function GetFile() As Boolean
        Dim inFile As StreamReader = Nothing
        txtDetail.Text = String.Empty
        Try
            inFile = File.OpenText(filePath)
            Dim numvals As Integer = File.ReadAllLines(filePath).Length
            ReDim allWorkShops(numvals - 1)
            For i As Integer = 0 To numvals - 1
                Dim line As String = inFile.ReadLine()
                Dim fields() As String = line.Split("\"c)
                Dim wshop As New WorkShop With {
                               .Category = CType(fields(0), WorkShop.CatrgoryType),
                                .Days = CInt(fields(1)),
                                .Cost = CDbl(fields(2)),
                                .Title = fields(3)}
                allWorkShops(i) = wshop
            Next
            txtDetail.Text = "workshop loaded successfull"
            Return True
        Catch ex As Exception
            txtDetail.Text = ex.Message
            Return False
        Finally
            If inFile IsNot Nothing Then inFile.Close()
        End Try
        Return False
    End Function
    Private Sub FillList()
        lstWorkshops.Items.Clear()
        For Each ws As WorkShop In allWorkShops
            lstWorkshops.Items.Add(ws)
        Next
    End Sub

    Private Sub btnShow_Click(sender As Object, e As EventArgs) Handles btnShow.Click
        Dim index As Integer = lstWorkshops.SelectedIndex
        If index = -1 Then
            txtDetail.Text = "please select workshop"
            Return
        Else
            txtDetail.Text = String.Empty
        End If
        Dim frm As New Detail
        frm.singleWorkshop = allWorkShops(index)
        frm.ShowDialog()
        FillList()
    End Sub
End Class
