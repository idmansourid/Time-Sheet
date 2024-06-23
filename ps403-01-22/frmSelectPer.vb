Imports System.ComponentModel

Public Class frmSelectPer
    Public DicLanguage As Dictionary(Of String, String)
    Public WithEvents dt0SelectPer As New DataTable

    Private Sub frmSelectPer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dgv_SelectPer.SetDataSource(dt0SelectPer)
        dgv_SelectPer.Dock = DockStyle.Fill
        StartPosition = FormStartPosition.Manual
    End Sub

    Private Sub frmSelectPer_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        e.Cancel = True
        frmTimeSheet.tsButResult.Checked = False
        Me.Hide()
    End Sub

    Private Sub dt0SelectPer_RowChanging(sender As Object, e As DataRowChangeEventArgs) Handles dt0SelectPer.RowChanging

    End Sub
End Class