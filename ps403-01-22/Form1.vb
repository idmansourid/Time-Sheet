Imports dgv

Public Class Form1
    Dim sttPathDbFile As String = IO.Path.GetDirectoryName(Application.ExecutablePath) & "\PS DataBaseMain.accdb"
    Dim ds As New DataSet
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        modMain.sttPathDbFile = sttPathDbFile
        DgvLoad(dgv_tabPipol, dgv_tabPipol.Name)
        DgvLoad(dgv_tabKala, dgv_tabKala.Name)
        ds.Tables.Add(dgv_tabPipol.Tag)
        ds.Tables.Add(dgv_tabKala.Tag)
        Dim rel As New DataRelation("Kala_Pipol", TryCast(dgv_tabPipol.Tag, DataTable).Columns(0), TryCast(dgv_tabKala.Tag, DataTable).Columns(1), True)
        ds.Relations.Add(rel)

    End Sub
    Public Sub DgvLoad(dgv As uDgv, dgvName As String)
        ' BufferToUp(dgv.dgv, True)
        Dim dt As DataTable = modMain.modDataSelectCommend(Split(dgvName, "_")(1)).Copy
        '  dt.PrimaryKey = New DataColumn() {dt.Columns("ID")}
        dgv.Tag = modMain.modDataSelectCommend(Split(dgvName, "_")(1)).Copy
        dgv.dgv.DataSource = dgv.Tag 'modMain.modDataSelectCommend(Split(uDgv.Name, "_")(1))

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        TryCast(dgv_tabPipol.Tag, DataTable).Columns("ID").DefaultValue = 4
        Dim dt4 As New DataTable
        ' dt4 = TryCast(dgv_tabPipol.Tag, DataTable).DefaultView.AsQueryable.
        TryCast(dgv_tabPipol.Tag, DataTable).Rows.Add()
    End Sub

    Private Sub dgv_tabPipol__DataError(sender As uDgv, e As DataGridViewDataErrorEventArgs) Handles dgv_tabPipol._DataError

    End Sub

    Private Sub dgv_tabKala__DataError(sender As uDgv, e As DataGridViewDataErrorEventArgs) Handles dgv_tabKala._DataError

    End Sub
End Class