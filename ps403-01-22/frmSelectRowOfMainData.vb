Imports System.ComponentModel

Public Class frmSelectRowOfMainData
    Private Sub frmSelectRowOfMainData_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub frmSelectRowOfMainData_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        e.Cancel = True
        Me.Hide()
    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged

    End Sub

    Private Sub txtSearch_KeyUp(sender As Object, e As KeyEventArgs) Handles txtSearch.KeyUp

    End Sub

    Private Sub txtSearch_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSearch.KeyDown
        If e.KeyCode = Keys.Escape Then
            e.SuppressKeyPress = True
            Me.Hide()
        ElseIf e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            e.Handled = True
            Dim itemsCount As UInt32
            Dim BytMove As Byte = IIf(e.KeyData = Keys.Down And dgv_qMainData.dgv.CurrentCellAddress.Y =
      (dgv_qMainData.dgv.Rows.Count + IIf(dgv_qMainData.dgv.AllowUserToAddRows, 0, 0) - 1), 0,
    IIf(dgv_qMainData.dgv.CurrentCellAddress.Y = 0 And e.KeyData = Keys.Up, 0, 1))
            itemsCount = dgv_qMainData.dgv.Rows.Count - 1
            dgv_qMainData.dgv.CurrentCell = dgv_qMainData.dgv.Rows(dgv_qMainData.dgv.CurrentCellAddress.Y + IIf(e.KeyData = Keys.Down, BytMove, Val("-" & BytMove))) _
                .Cells(dgv_qMainData.dgv.CurrentCell.ColumnIndex)
        End If
    End Sub
End Class