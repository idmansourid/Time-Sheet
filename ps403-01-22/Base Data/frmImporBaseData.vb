Public Class frmImporBaseData
    Public sttExcelPath As String
    Dim dtTableWithColumns As New DataTable
    Public ColumnsSoft As String()
    Public sttTableName As String
    Dim bitExit As Boolean

    ' Public columnsSoft() As String

    Private Sub frmImporBaseData_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '   modMain.ExcelImport(sttExcelPath)
        'lstSheetsPreview.Items.Clear()
        'lstSheets.Items.Clear()
        'lstSheets.Items.AddRange(modMain.ExcelImportSchema(sttExcelPath, dtTableWithColumns))
        dgvConnect.Rows.Clear()
        lstColumns.Items.Clear()
        dgvConnect.Rows.Clear()
        dgvPreview.DataSource = Nothing
        lstSheetsPreview.Items.Clear()
        lstSheetsPreview.Items.AddRange(modMain.ExcelImportSchema(sttExcelPath, dtTableWithColumns))
        dgvConnect.RowCount = ColumnsSoft.Length
        For a = 0 To dgvConnect.RowCount - 1
            dgvConnect.Rows(a).Cells(colImport.Name).Value = ""
        Next
        For a = 0 To ColumnsSoft.Length - 1
            dgvConnect.Rows(a).Cells(colSoft.Name).Value = ColumnsSoft(a)
        Next

    End Sub

    Private Sub lstSheets_SelectedIndexChanged(sender As Object, e As EventArgs) 'Handles lstSheets.SelectedIndexChanged
        'If lstSheets.SelectedItem Is Nothing Then Exit Sub
        'Dim sttSel As String = lstSheets.SelectedItem.ToString
        'dtTableWithColumns.DefaultView.RowFilter = "[TABLE_NAME] Like '%" & sttSel & "$" & "%'"
        'Dim dr() As DataRow = dtTableWithColumns.Select("[TABLE_NAME] Like '%" & sttSel & "$" & "%'")
        'Dim a = dr.AsEnumerable.Select(Function(r) r.Item("COLUMN_NAME").ToString).ToArray
        ' lstColumns.Items.Clear()
        ' lstColumns.Items.AddRange(a)

        'Dim dr() As DataRow = cn.GetSchema("columns").Select()
    End Sub

    Private Sub lstColumns_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstColumns.SelectedIndexChanged

    End Sub

    Private Sub lstColumns_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles lstColumns.MouseDoubleClick
        Dim sttSel As String = lstColumns.SelectedItem.ToString
        Me.Text = "Import Data On : '" & sttTableName & "'"
        dgvConnect.CurrentRow.Cells(colImport.Name).Value = sttSel
        dgvConnect.CurrentRow.Cells(colSel.Name).Value = True
        'If dgvConnect.CurrentRow.Index < (dgvConnect.RowCount) Then
        dgvConnect.CurrentCell = dgvConnect.Item(colImport.Name, dgvConnect.CurrentRow.Index + IIf(dgvConnect.CurrentRow.Index < (dgvConnect.RowCount - 1), 1, 0))
        'End If
        Validate()
    End Sub

    Private Sub tsmClear_Click(sender As Object, e As EventArgs) Handles tsmClear.Click
        For a = 0 To dgvConnect.RowCount - 1
            dgvConnect.Rows(a).Cells(colImport.Name).Value = ""
        Next
    End Sub

    Private Sub butImport_Click(sender As Object, e As EventArgs) Handles butImport.Click
        Dim setOnColumns() As String = dgvConnect.Rows.Cast(Of DataGridViewRow).Where(Function(h) h.Cells(colImport.Name).Value <> "" And h.Cells(colSel.Name).Value = True).Select(Function(j) j.Cells(colSoft.Name).Value.ToString).ToArray
        Dim columnsImport() As String = dgvConnect.Rows.Cast(Of DataGridViewRow).Where(Function(h) h.Cells(colImport.Name).Value <> "" And h.Cells(colSel.Name).Value = True).Select(Function(j) j.Cells(colImport.Name).Value.ToString).ToArray
        If setOnColumns.Length = columnsImport.Length Then
            Dim arrColumnsSoft As String() = modData_GetSpcialColumns(sttTableName, setOnColumns, "<|>")
            Dim sttSheet As String = lstSheetsPreview.SelectedItem.ToString
            Dim dtImport As New DataTable
            TryCast(dgvPreview.DataSource, DataTable).AcceptChanges()
            dtImport = TryCast(dgvPreview.DataSource, DataTable).DefaultView.ToTable(False, columnsImport).Copy

            Dim arrColumnsImport As String() = dtImport.AsEnumerable().Select(Function(h) Join(h.ItemArray.Select(Function(s) s.ToString).ToArray, "<|>")).ToArray
            'modExcel_GetSpcialColumns(sttSheet, columnsImport, sttExcelPath, "<|>")
            Dim arrNewRows = arrColumnsImport.Intersect(arrColumnsSoft).ToArray

            If arrNewRows.Length > 0 Then
                Dim sttGetIdx As String = ""
                For a = 0 To arrNewRows.Length - 1
                    sttGetIdx += Array.IndexOf(arrColumnsImport, arrNewRows(a)) & " "
                Next
                Dim msDia As DialogResult = MsgBox("وجود آیتم تکراری در فایل ورودی" & vbNewLine & "Count Of Input Rows : " & arrColumnsImport.Length & vbNewLine & "Error On Index: " & sttGetIdx &
                                                   vbNewLine & "Yes: فقط آیتم های جدید را بپذیر", MsgBoxStyle.YesNoCancel + MsgBoxStyle.DefaultButton2)
                If msDia = DialogResult.Yes Then
                    Dim q As String() = arrColumnsImport.Except(arrNewRows).ToArray
                    'modData_Insert_Update(sttTableName, setOnColumns, q, "<|>")
                    DataInsert(setOnColumns, q)
                End If


                Exit Sub
            End If
            DataInsert(setOnColumns, arrColumnsImport)
            'modData_Insert_Update(sttTableName, setOnColumns, arrColumnsImport, "<|>")
            MsgBox("با موفقیت انجام شد")
        Else
            MsgBox("ارتباط بین ستون ها رو تنظیم کنید")
        End If


    End Sub
    Private Sub DataInsert(setOnColumns As String(), arrColumnsImport As String())

        modData_Insert_Update(sttTableName, setOnColumns, arrColumnsImport, "<|>")
        'frmMain.DgvLoad(dgvForChange, dgvForChange.Name)
        'frmMain.tab_LoadMainData()
    End Sub
    Private Sub butOpen_Click(sender As Object, e As EventArgs) Handles butOpen.Click
        Dim fd As New OpenFileDialog
        fd.ShowDialog()
        If fd.FileName <> "" Then
            ' frmImporBaseData.sttTableName = Split(dgv_BaseItems.Name, "_")(1)
            sttExcelPath = fd.FileName
            frmImporBaseData_Load(Nothing, Nothing)
            '  frmImporBaseData.ColumnsSoft = dgv_BaseItems.Columns.Cast(Of DataGridViewColumn).Select(Function(f) f.Name).ToArray


        End If
    End Sub

    Private Sub lstSheetsPreview_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstSheetsPreview.SelectedIndexChanged

    End Sub

    Private Sub lstSheetsPreview_MouseClick(sender As Object, e As MouseEventArgs) Handles lstSheetsPreview.MouseClick
        Dim sttSheet As String = lstSheetsPreview.SelectedItem.ToString
        lblSelSheet.Text = sttSheet
        dgvPreview.DataSource = modExcelImportSheet(sttExcelPath, sttSheet)
        Dim q As String() = dgvPreview.Columns.Cast(Of DataGridViewColumn).Select(Function(d) dgvPreview.Columns(d.DisplayIndex).Name).ToArray
        lstColumns.Items.Clear()
        lstColumns.Items.AddRange(q)
    End Sub

    Private Sub dgvPreview_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvPreview.CellContentClick

    End Sub



    Private Sub dgvPreview_ColumnDisplayIndexChanged(sender As Object, e As DataGridViewColumnEventArgs) Handles dgvPreview.ColumnDisplayIndexChanged
        'If dgvPreview.Columns.Count - 1 = e.Column.Index Then
        '    Dim q = dgvPreview.Columns.Cast(Of DataGridViewColumn).Select(Function(d) d.Name).ToArray
        'End If
        bitExit = True
    End Sub

    Private Sub dgvPreview_CellMouseUp(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgvPreview.CellMouseUp
        If bitExit Then
            Dim q As String() = dgvPreview.Columns.Cast(Of DataGridViewColumn).Select(Function(d) dgvPreview.Columns(d.DisplayIndex).Name).ToArray
            lstColumns.Items.Clear()
            lstColumns.Items.AddRange(q)



            bitExit = False
        End If

    End Sub
End Class