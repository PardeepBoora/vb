Public Class Detail
    Public Property singleWorkshop As WorkShop
    Private Sub Detail_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Combo.DataSource = WorkShop.CategoryNames
        With singleWorkshop
            txtTitle.Text = .Title
            txtDays.Text = .Days.ToString()
            txtCost.Text = .Cost.ToString("n")
            Combo.SelectedIndex = .Category
        End With
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        With singleWorkshop
            .Title = txtTitle.Text
            .Days = CInt(txtDays.Text)
            .Cost = CDbl(txtCost.Text)
            .Category = CType(Combo.SelectedIndex, WorkShop.CatrgoryType)
        End With
        Close()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Close()
    End Sub
End Class



