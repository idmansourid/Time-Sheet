Public Class frmTaghvim
    Private Sub frmTaghvim_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        UDate1.dgv.RowCount = 6
        UDate1.dgv.ReadOnly = True
        For Each r As DataGridViewRow In UDate1.dgv.Rows
            'r.Cells(0).Value = 1
            r.SetValues({0, 1, 2, 3, 12, 14, 30})
        Next
    End Sub
End Class