Imports System.Data.SqlClient
Imports System.Reflection
Imports dgv

Public Class frmMain

    Structure sBits
        Dim ValidByEnter As Boolean
        Dim ValidBySelectList As Boolean
        Dim RowValitingExitByCancel As Boolean
        Dim AcceptValidByShiftEnter As Boolean
        Dim bitDownUpKey As Boolean
        Dim ExitCellValidating As Boolean
        Dim isNewRow As Boolean
        Dim isEditRow As Boolean
        Dim ExitTrvGruping As Boolean
        Dim RowIsDouplicate As Boolean
    End Structure
    Dim bit As sBits
    Dim DataRowCancel As DataRow
    Dim WithEvents cms_Menu As New ContextMenuStrip
    Dim bitExitCtrl As Boolean
    Dim color1 As Color = Color.FromArgb(255, 150, 27)
    Dim color2 As Color = Color.FromArgb(100, 225, 30)
    Dim dtf_BaseGroping As New DataTable
    Dim dtf_BaseLocations As New DataTable
    Dim bitNoFilterBySpace As Boolean
    Dim WithEvents frmSelectRow As dgv.frmValidOfColumn
    '  Dim dtValidFind As New DataTable
    Dim bitExitTextChange As Boolean

    Dim LisDouplicatNodes As New List(Of TreeNode)
    Dim dgvCurrent As DataGridView
    Structure sJointCells
        Dim ColumnName As String
        Dim cValue As String
    End Structure
    Dim lisJoint As New List(Of sJointCells)
    Dim lisJoint2 As New List(Of String)
    Dim lisChildTables As New List(Of DataTable)
    Dim lisResultColunm As New List(Of String())
    Dim JointCellsAfterEnter As String = ""
    Dim isEndTable As Boolean
    Dim LastLen As Byte
    Dim idxChildTable As Integer

    Dim isScroll As Boolean

    Dim OffsetLeftRight As Integer
    Dim sttPathDbFile As String = IO.Path.GetDirectoryName(Application.ExecutablePath) & "\PS DataBaseMain.accdb"
    Dim WithEvents ds As New DataSet
    Dim WithEvents dt_BaseGrouping As DataTable
    Dim WithEvents dt_qMainData As DataTable
    Dim WithEvents dt_BaseLocations As DataTable
    Dim WithEvents dt_qMivMrv As DataTable
    Dim lisTables As New List(Of String)
    Private Shadows Sub BufferToUp(dgv As Object, setting As Boolean)
        '  BufferToUp(uDgv, True)
        Dim dgvType = dgv.GetType
        Dim proInfo As PropertyInfo = dgvType.GetProperty("DoubleBuffered", BindingFlags.Instance Or BindingFlags.NonPublic)
        proInfo.SetValue(dgv, setting, Nothing)
    End Sub
    Private Sub Load2()
        lisTables.AddRange({"BaseGrouping", "qMainData", "BaseLocations", "qMivMrv"})
        ds = modDataFillDataSet(lisTables.ToArray)

        dt_BaseGrouping = ds.Tables(Split(NameOf(dt_BaseGrouping), "_")(1))
        dt_qMainData = ds.Tables(Split(NameOf(dt_qMainData), "_")(1))
        dt_BaseLocations = ds.Tables(Split(NameOf(dt_BaseLocations), "_")(1))
        dt_qMivMrv = ds.Tables(Split(NameOf(dt_qMivMrv), "_")(1))


        Loadgv2(dgv_BaseGrouping, dt_BaseGrouping)
        Loadgv2(dgv_qMainData, dt_qMainData)
        Loadgv2(dgv2_qMainData, dt_qMainData)
        Loadgv2(frmSelectRowOfMainData.dgv_qMainData, dt_qMainData)
        Loadgv2(dgv_BaseLocations, dt_BaseLocations)
        Loadgv2(dgv_qMivMrv, dt_qMivMrv)


        Dim rela As New List(Of DataRelation)
        rela.Add(New DataRelation("BaseGrouping@qMainData", dt_BaseGrouping.Columns("ID"), dt_qMainData.Columns("idBaseGrouping"), createConstraints:=True))
        ds.Relations.AddRange(rela.ToArray)

        dt_BaseGrouping.PrimaryKey = New DataColumn() {dt_BaseGrouping.Columns("ID")}
        dt_qMainData.PrimaryKey = New DataColumn() {dt_qMainData.Columns("ID")}
        dt_BaseLocations.PrimaryKey = New DataColumn() {dt_BaseLocations.Columns("ID")}
        dt_qMivMrv.PrimaryKey = New DataColumn() {dt_qMivMrv.Columns("ID")}

        dgv_qMainData.dgv.Columns("fSelect").AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader



    End Sub
    Private Sub Loadgv2(inDgv As uDgv, dtTable As DataTable)
        inDgv.dgv.DataSource = dtTable
        inDgv.GetColumnsName()
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim ar() As String = {"a", "b"}
        Dim ar2() As String = {"b", "a"}
        Dim d As Boolean = Join(ar) = Join(ar2)
        frmSelectRow = New dgv.frmValidOfColumn

        frmSelectRow.StartPosition = FormStartPosition.Manual
        frmSelectRowOfMainData.StartPosition = FormStartPosition.Manual

        modMain.sttPathDbFile = sttPathDbFile
        dgv_BaseGrouping.dgv.Dock = DockStyle.Fill
        dgv_qMainData.Dock = DockStyle.Fill
        Load2()
        tab_LoadMainData()
        Exit Sub
        DgvLoad(dgv_BaseGrouping, dgv_BaseGrouping.Name)
        DgvLoad(dgv_qMainData, dgv_qMainData.Name)
        DgvLoad(dgv_BaseLocations, dgv_BaseLocations.Name)
        DgvLoad(dgv_qMivMrv, dgv_qMivMrv.Name)
        DgvLoad(dgv2_qMainData, dgv2_qMainData.Name)
        ds.Tables.AddRange({dgv_BaseGrouping.Tag, dgv_qMainData.Tag, dgv_BaseLocations.Tag, dgv_qMivMrv.Tag})
        Dim rel As New DataRelation("Groping@Id_to_Main@idBaseGrouping", TryCast(dgv_BaseGrouping.Tag, DataTable).Columns("ID"),
TryCast(dgv_qMainData.Tag, DataTable).Columns("idBaseGrouping"), True)
        Dim rel2 As New List(Of DataRelation)

        rel2.Add(New DataRelation("Groping@Id_to_Main@idBaseGrouping", TryCast(dgv_BaseGrouping.Tag, DataTable).Columns("ID"),
TryCast(dgv_qMainData.Tag, DataTable).Columns("idBaseGrouping"), createConstraints:=True))
        '        rel2.Add(New DataRelation("Groping@Id_to_Main@idBaseGrouping", TryCast(dgv_BaseGrouping.Tag, DataTable).Columns("ID"),
        'TryCast(dgv_qMainData.Tag, DataTable).Columns("idBaseGrouping"), True))
        ds.Relations.AddRange(rel2.ToArray)
        frmSelectRowOfMainData.dgv_qMainData.dgv.DataSource = dgv_qMainData.Tag

        TryCast(dgv_BaseGrouping.Tag, DataTable).PrimaryKey = New DataColumn() {TryCast(dgv_BaseGrouping.Tag, DataTable).Columns("ID")}
        TryCast(dgv_qMainData.Tag, DataTable).PrimaryKey = New DataColumn() {TryCast(dgv_qMainData.Tag, DataTable).Columns("ID")}
        TryCast(dgv_BaseLocations.Tag, DataTable).PrimaryKey = New DataColumn() {TryCast(dgv_BaseLocations.Tag, DataTable).Columns("ID")}
        TryCast(dgv_qMivMrv.Tag, DataTable).PrimaryKey = New DataColumn() {TryCast(dgv_qMivMrv.Tag, DataTable).Columns("ID")}
        TryCast(dgv2_qMainData.Tag, DataTable).PrimaryKey = New DataColumn() {TryCast(dgv2_qMainData.Tag, DataTable).Columns("ID")}
        dgv2_qMainData.dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        'dgv_BaseGrouping.DataSource = modMain.modDataSelectCommend(Split(dgv_BaseGrouping.Name, "_")(1))
        'dgv_qMainData.DataSource = modMain.modDataSelectCommend(Split(dgv_qMainData.Name, "_")(1))
        'dgv_BaseLocations.DataSource = modMain.modDataSelectCommend(Split(dgv_BaseLocations.Name, "_")(1))
        dgv_qMainData.dgv.Columns("fSelect").AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader
        tab_LoadMainData()
        frmSelectRow.Height = 160
        lstFiltering.DataSource = lisChildTables(0)
        lstFiltering.DisplayMember = "SpcialColumns"
        TryCast(dgv_BaseGrouping.Tag, DataTable).Columns("id").ExtendedProperties.Add("Max", 6)
        ' TryCast(dgv_BaseGrouping.Tag, DataTable).aaa += ff_dfdf

    End Sub
    Public Sub DgvLoad(dgv As uDgv, dgvName As String)
        BufferToUp(dgv.dgv, True)
        Dim dt As DataTable = modMain.modDataSelectCommend(Split(dgvName, "_")(1)).Copy
        '  dt.PrimaryKey = New DataColumn() {dt.Columns("ID")}
        dgv.Tag = modMain.modDataSelectCommend(Split(dgvName, "_")(1)).Copy
        dgv.dgv.DataSource = dgv.Tag 'modMain.modDataSelectCommend(Split(uDgv.Name, "_")(1))
        dgv.GetColumnsName()
    End Sub
    Public Sub tab_LoadMainData()

        dtf_BaseGroping = modData_GetSpcialColumnsAsTable(Split(dgv_BaseGrouping.Name, "_")(1), {"ID", "MainGroup", "SubGroup", "Dis1"}, Microsoft.VisualBasic.Chr(3))
        lisChildTables.Add(dtf_BaseGroping.Copy)
        lstGrouping.DataSource = dtf_BaseGroping
        lstGrouping.DisplayMember = "SpcialColumns"

        trvFind.Nodes.Clear()
        trvGrouping.Nodes.Clear()
        TreeViewFilter("", dgv_BaseGrouping.dgv.DataSource, trvFind, {"Id", "MainGroup", "SubGroup", "Dis1"})
        TreeViewFilter("", dgv_BaseGrouping.dgv.DataSource, trvGrouping, {"Id", "MainGroup", "SubGroup", "Dis1"})
        TreeViewFilter("", dgv_BaseGrouping.dgv.DataSource, trvGroupingMiv, {"Id", "MainGroup", "SubGroup", "Dis1"})
        trvGrouping.Refresh()

        ts_WorkGroup.Text = "Count: " & trvGrouping.Nodes.Count

        dtf_BaseLocations = modData_GetSpcialColumnsAsTable(Split(dgv_BaseLocations.Name, "_")(1), {"ID", "Area", "SubArea"}, Microsoft.VisualBasic.Chr(3))
        lisChildTables.Add(dtf_BaseLocations.Copy)
        lstLocations.DataSource = dtf_BaseLocations
        lstLocations.DisplayMember = "SpcialColumns"


        comMain.Items.Clear()
        comMain.Items.AddRange(modColumnDistinct(dgv_BaseGrouping.dgv.DataSource, "MainGroup"))
        comSubMain.Enabled = False
        com_Area.Items.Clear()
        com_Area.Items.AddRange(modColumnDistinct(dgv_BaseLocations.dgv.DataSource, "Area"))
    End Sub
    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        Filter3(txtSearch.Text)
    End Sub
    Public Sub Filter3(sttText As String)
        Dim inText As String
        Dim SplChangeDB As String() = Split(sttText, Microsoft.VisualBasic.Chr(4))
        inText = SplChangeDB(SplChangeDB.Length - 1)
        Dim sttSpliterSub As String = Microsoft.VisualBasic.Chr(2)
        Dim sttF2 As String = ""
        Dim splSpace As String() = Split(inText, sttSpliterSub)
        Dim sttFilter As String = ""
        splSpace = Split(inText, sttSpliterSub)
        If splSpace.Length > 1 Then
            For b = 0 To splSpace.Length - 1
                If splSpace(b) = "" Then Continue For
                sttF2 += IIf(sttF2 <> "", " And ", "") & " [" & "SpcialColumns" & "] Like '*" & splSpace(b) & "*'"
            Next
            sttFilter = sttF2
        ElseIf inText <> "" Then
            sttFilter = "[" & "SpcialColumns" & "] Like '*" & inText & "*'"
        End If

        If SplChangeDB.Length - 2 < lisChildTables.Count Then
            If txtSearch.Text.Length > 0 AndAlso Mid(txtSearch.Text, txtSearch.Text.Length) = Microsoft.VisualBasic.Chr(4) Then
                If LastLen < txtSearch.Text.Length Then
                    Dim stt4 As String = Split(lstFiltering.SelectedItem.item(0), Microsoft.VisualBasic.Chr(3))(0)
                    lisChildTables(SplChangeDB.Length - 2).DefaultView.RowFilter = "[SpcialColumns] Like '" & stt4 & Microsoft.VisualBasic.Chr(3) & "*'"
                    stt4 = lstFiltering.SelectedItem.item(0)
                    Dim splFilter() = Split(stt4, Microsoft.VisualBasic.Chr(3))
                    Dim stt5 As String() = lisChildTables(SplChangeDB.Length - 2).Columns.Cast(Of DataColumn).Skip(1).Select(Function(g) g.ColumnName).ToArray
                    '  stt5.ToList.ForEach(Sub(h) stt4 = 4)
                    ' lisResultColunm.Add(stt5)
                    For a = 0 To stt5.Length - 1
                        ' stt5(a) += Microsoft.VisualBasic.Chr(3) & splFilter(a)
                        lisJoint2.Add(stt5(a) & Microsoft.VisualBasic.Chr(3) & splFilter(a))
                    Next
                    'lisJoint.Add(New sJointCells With{.ColumnName)
                    lstResult.Items.Add(stt4)
                    'Else
                    '    lisChildTables(SplChangeDB.Length - 2).DefaultView.RowFilter = ""
                End If
                If SplChangeDB.Length - 1 < lisChildTables.Count Then
                    lstFiltering.DataSource = lisChildTables(SplChangeDB.Length - 1)
                    ' lisChildTables(SplChangeDB.Length - 1).DefaultView.RowFilter = ""
                    lisChildTables(SplChangeDB.Length - 1).DefaultView.RowFilter = ""
                Else
                    isEndTable = True
                End If

            ElseIf SplChangeDB.Length - 1 < lisChildTables.Count Then
                ' If lstFiltering.DataSource IsNot lisChildTables(SplChangeDB.Length - 1) Or isEndTable Then
                If lstFiltering.DataSource IsNot lisChildTables(SplChangeDB.Length - 1) Or isEndTable Then
                    '  Dim stt5 As String() = lisChildTables(SplChangeDB.Length - 2).Columns.Cast(Of DataColumn).Skip(1).Select(Function(g) g.ColumnName).ToArray
                    lstFiltering.DataSource = lisChildTables(SplChangeDB.Length - 1)
                    isEndTable = False
                    For b = lisJoint2.Count - 1 To +lisChildTables(SplChangeDB.Length - 1).Columns.Count Step -1
                        lisJoint2.RemoveAt(b)


                    Next

                    If lstResult.Items.Count > 0 Then
                        lstResult.Items.RemoveAt(lstResult.Items.Count - 1)
                        '  lisResultColunm.RemoveAt(lisResultColunm.Count - 1)
                    End If
                End If
                ' lisChildTables(SplChangeDB.Length - 1).DefaultView.RowFilter = sttFilter
                lisChildTables(SplChangeDB.Length - 1).DefaultView.RowFilter = sttFilter
            End If
        Else

        End If
    End Sub
    Private Sub txtSearch_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSearch.KeyDown
        LastLen = txtSearch.Text.Length
        Dim keyData As Keys = e.KeyCode
        Dim lstBox As ListBox = lstFiltering
        If e.KeyCode = Keys.Down Or e.KeyCode = Keys.Up Then
            e.SuppressKeyPress = True
            '        ' e.Handled = True

            '        Dim BytMove As Byte = IIf(keyData = Keys.Down And dgvItems.CurrentCellAddress.Y =
            '  (dgvItems.Rows.Count + IIf(dgvItems.AllowUserToAddRows, 0, 0) - 1), 0,
            'IIf(dgvItems.CurrentCellAddress.Y = 0 And keyData = Keys.Up, 0, 1))

            '        Dim itemsCount = dgvItems.Rows.Count - 1
            '        dgvItems.CurrentCell = dgvItems.Rows(dgvItems.CurrentCellAddress.Y + IIf(keyData = Keys.Down, BytMove, Val("-" & BytMove))) _
            '            .Cells(dgvItems.CurrentCell.ColumnIndex)
            Dim BytMove As Byte = IIf(keyData = Keys.Down And lstBox.SelectedIndex =
              (lstBox.Items.Count - 1), 0, IIf(lstBox.SelectedIndex = 0 And keyData = Keys.Up, 0, 1))
            lstBox.SelectedIndex = lstBox.SelectedIndex + IIf(keyData = Keys.Down, BytMove, Val("-" & BytMove))

        ElseIf e.KeyCode = Keys.Enter And lstGrouping.SelectedItem IsNot Nothing Then
            Dim stt2 As String = Split(lstGrouping.SelectedItem.item(0), Microsoft.VisualBasic.Chr(3))(0)
            e.SuppressKeyPress = True
            'txtSearch.BackColor = IIf(txtSearch.BackColor = color1, color2, color1)
            Dim sttGetSub As String = Microsoft.VisualBasic.Chr(4)
            e.SuppressKeyPress = True
            If txtSearch.Text.Length > 0 Then
                Dim stt = Mid(txtSearch.Text, txtSearch.Text.Length)
                If Mid(txtSearch.Text, txtSearch.Text.Length) = sttGetSub Then
                    '  txtSearch.BackColor = color1
                Else
                    txtSearch.Text += sttGetSub
                    txtSearch.SelectionStart = txtSearch.Text.Length
                    '  txtSearch.BackColor = color2
                End If
            End If
            'Dim SplChangeDB As String() = Split(txtSearch.Text, Microsoft.VisualBasic.Chr(4))
            'Dim stt4 As String = Split(lstFiltering.SelectedItem.item(0), Microsoft.VisualBasic.Chr(3))(0)
            'lisChildTables(SplChangeDB.Length - 2).DefaultView.RowFilter = "[SpcialColumns] Like '" & stt4 & Microsoft.VisualBasic.Chr(3) & "*'"
            'stt4 = lstFiltering.SelectedItem.item(0)
            'lstResult.Items.Add(stt4)
            'If SplChangeDB.Length - 1 < lisChildTables.Count Then
            '    lstFiltering.DataSource = lisChildTables(SplChangeDB.Length - 1)
            'End If


            'dtBaseGroping.DefaultView.RowFilter = "[SpcialColumns] Like '" & stt2 & Microsoft.VisualBasic.Chr(3) & "*'"

        ElseIf e.Control And e.KeyCode = Keys.Space Then
            e.SuppressKeyPress = True
            Exit Sub
        ElseIf bitExitCtrl Then
            e.SuppressKeyPress = True

        End If
        ' e.SuppressKeyPress = e.Control

    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) ' Handles Button1.Click
        Dim con As SqlConnection
        con = New SqlConnection
        con.ConnectionString = "Data Source=.\SQLEXPRESS;AttachDbFilename=" & sttPathDbFile & ";Integrated Security=False;User Instance=False"
        Try
            con.Open()
            MessageBox.Show("Connected!")
            con.Close()
        Catch ex As SqlException
            MessageBox.Show(ex.Message)
        Finally
            con.Dispose()
        End Try






        SaveData2(dgv_BaseGrouping.dgv.DataSource, sttPathDbFile)
        Dim q As String = Join(dgv_qMainData.dgv.Columns.Cast(Of DataGridViewColumn).Select(Function(f) f.Name).ToArray, " ")
        ' modData_Insert_Update("qBaseItemsP", q)
    End Sub


    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        '  Dim q As String = Join(dgv2.Columns.Cast(Of DataGridViewColumn).Select(Function(f) f.Name).ToArray, " ")
        ' modData_Insert_Update("qBaseItemsP", sttPathDbFile, q)
        ListBox1.Items.AddRange(modData_GetSpcialColumns("sheet1", {"f2", "f3", "f4"}))

    End Sub

    Private Sub tsmImportData_Click(sender As Object, e As EventArgs) Handles tsmImportData.Click, tsmImportMainData.Click

        Dim fd As New OpenFileDialog
        fd.ShowDialog()
        If fd.FileName <> "" Then
            If tsmImportData.Tag = "dgv_BaseLocations" Then
                modMain.dgvForChange = dgv_BaseLocations.dgv
                frmImporBaseData.sttTableName = Split(dgv_BaseLocations.Name, "_")(1)
                frmImporBaseData.sttExcelPath = fd.FileName
                frmImporBaseData.ColumnsSoft = dgv_BaseLocations.dgv.Columns.Cast(Of DataGridViewColumn).Select(Function(f) f.Name).ToArray
            ElseIf tsmImportData.Tag = "dgv_BaseGrouping" Then
                modMain.dgvForChange = dgv_BaseGrouping.dgv
                frmImporBaseData.sttTableName = Split(dgv_BaseGrouping.dgv.Name, "_")(1)
                frmImporBaseData.sttExcelPath = fd.FileName
                frmImporBaseData.ColumnsSoft = dgv_BaseGrouping.dgv.Columns.Cast(Of DataGridViewColumn).Select(Function(f) f.Name).ToArray
            ElseIf tsmImportData.Tag = "dgv_qMainData" Then
                modMain.dgvForChange = dgv_qMainData.dgv
                frmImporBaseData.sttTableName = Split(dgv_qMainData.Name, "_")(1)
                frmImporBaseData.sttExcelPath = fd.FileName
                frmImporBaseData.ColumnsSoft = dgv_qMainData.dgv.Columns.Cast(Of DataGridViewColumn).Select(Function(f) f.Name).ToArray


            End If
            frmImporBaseData.Text = "Import Data On : '" & frmImporBaseData.sttTableName & "'"
            frmImporBaseData.ShowDialog()
        End If

    End Sub


    Public Sub Filter2(inText As String)
        Dim SplChangeDB As String() = Split(txtSearch.Text, Microsoft.VisualBasic.Chr(4))
        If SplChangeDB.Length Mod lisChildTables.Count = 0 Then
            txtSearch.BackColor = color1
        Else
            txtSearch.BackColor = color2
        End If
        inText = SplChangeDB(SplChangeDB.Length - 1)
        Dim InDT As DataTable = dtf_BaseGroping
        Dim CurrentColumn As String '= dgvItems.Columns(dgvFilter.CurrentCell.ColumnIndex).Name
        Dim sttSpliterSub As String = Microsoft.VisualBasic.Chr(2)
        Dim sttCurrentColumn As String = ""
        Dim SplDot As String() = Split(inText, sttSpliterSub)
        Dim sttFilter As String = ""
        Dim sttF2 As String = ""
        Dim Level As Byte = 0
        Dim isInText As Boolean = False
        Dim bitIsInText As Boolean '= InDT.AsEnumerable.Select(Function(h) h.Item(dynamicColumn(Level - 1))).Contains(SplDot(a))
        '  Dim bitIsInText2 As String = "," & String.Join(",", InDT.AsEnumerable.Select(Function(h) h.Item(dynamicColumn(Level - 1))).Distinct) & ","
        ' bitIsInText = InStr(bitIsInText2, "," & SplDot(a) & ",", CompareMethod.Text) > 0
        Dim splSpace As String() = Split(inText, sttSpliterSub)
        'If splSpace.Length > 1 Then
        '    For b = 0 To splSpace.Length - 1
        '        If splSpace(b) = "" Then Continue For
        '        sttF2 += IIf(b > 0, " And ", "") & "[" & CurrentColumn & "] Like '*" & splSpace(b) & "*'"
        '    Next
        '    ' sttFilter += IIf(a > 0, " And ", "") & sttF2
        '    ' sttF2 = ""
        '    sttFilter = sttF2
        'ElseIf txtSearch.Text <> "" Then
        '    '    sttFilter += IIf(a > 0, " And ", "") & "[" & CurrentColumn & "] Like '" & IIf(bitIsInText, "", "*") & SplDot(a) & IIf(bitIsInText, "", "*") & "'"
        '    sttFilter = "[" & CurrentColumn & "] Like '*" & txtSearch.Text & "*'"
        'End If
        '  Next

        Dim sttFilter2 As String = ""
        splSpace = Split(inText, sttSpliterSub)
        If splSpace.Length > 1 Then
            For b = 0 To splSpace.Length - 1
                If splSpace(b) = "" Then Continue For
                sttF2 += IIf(sttF2 <> "", " And ", "") & " [" & "SpcialColumns" & "] Like '*" & splSpace(b) & "*'"
            Next
            ' sttFilter += IIf(a > 0, " And ", "") & sttF2
            ' sttF2 = ""
            sttFilter2 = sttF2
        ElseIf inText <> "" Then
            '    sttFilter += IIf(a > 0, " And ", "") & "[" & CurrentColumn & "] Like '" & IIf(bitIsInText, "", "*") & SplDot(a) & IIf(bitIsInText, "", "*") & "'"
            sttFilter2 = "[" & "SpcialColumns" & "] Like '*" & inText & "*'"
        End If


        '' dgvItems.Columns(CurrentColumn).Tag = sttFilter
        'Dim OtherFilter '= dgvItems.Columns.Cast(Of DataGridViewColumn).Where(Function(f) f.Tag IsNot Nothing AndAlso f.Tag <> "").Select(Function(g) "(" & g.Tag & ")").ToArray
        'Dim sttJoin As String = String.Join(" And ", OtherFilter)

        'Dim sttResult As String = sttJoin & IIf(sttFilter2 <> "", IIf(sttJoin <> "", " And ", "") & sttFilter2, "")

        dtf_BaseGroping.DefaultView.RowFilter = sttFilter2

    End Sub

    Private Sub txtSearch_KeyUp(sender As Object, e As KeyEventArgs) Handles txtSearch.KeyUp
        If e.Control And e.KeyCode = Keys.Space Then
            e.SuppressKeyPress = True
            bitExitCtrl = True
            ' txtSearch.BackColor = IIf(txtSearch.BackColor = color1, color2, color1)
            Dim sttGetSub As String = Microsoft.VisualBasic.Chr(4)
            e.SuppressKeyPress = True
            Dim stt = Mid(txtSearch.Text, txtSearch.Text.Length)
            If Mid(txtSearch.Text, txtSearch.Text.Length) = sttGetSub Then
            Else
                txtSearch.Text += sttGetSub
                txtSearch.SelectionStart = txtSearch.Text.Length
            End If


            Exit Sub
        ElseIf e.KeyCode = Keys.ControlKey And bitExitCtrl = False Then
            Dim sttGetSub As String = Microsoft.VisualBasic.Chr(2)
            e.SuppressKeyPress = True
            If Mid(txtSearch.Text, txtSearch.Text.Length) = sttGetSub Then
            Else
                txtSearch.Text += sttGetSub
                txtSearch.SelectionStart = txtSearch.Text.Length
            End If
        ElseIf e.KeyCode = Keys.Down Or e.KeyCode = Keys.Up Then


        End If
        bitExitCtrl = False
    End Sub



    Private Sub comMain_SelectedIndexChanged(sender As Object, e As EventArgs) Handles comMain.SelectedIndexChanged
        Dim sttSel As String = comMain.SelectedItem.ToString
        dtf_BaseGroping.DefaultView.RowFilter = "[MainGroup] Like '" & sttSel & "'"
        comMain.Tag = "[MainGroup] Like '" & sttSel & "'"
        Dim q As String() = dtf_BaseGroping.DefaultView.ToTable(True, {"SubGroup"}).AsEnumerable.Select(Function(g) g.Item(0).ToString).ToArray
        comSubMain.Items.Clear()
        comSubMain.Items.AddRange(q)
        comSubMain.Enabled = True
    End Sub

    Private Sub comSubMain_SelectedIndexChanged(sender As Object, e As EventArgs) Handles comSubMain.SelectedIndexChanged
        Dim sttSel As String = comSubMain.SelectedItem.ToString
        dtf_BaseGroping.DefaultView.RowFilter = comMain.Tag & " And [SubGroup] Like '" & sttSel & "'"
        '  Dim q As String() = dt.DefaultView.ToTable(True, {"Dis1"}).AsEnumerable.Select(Function(g) g.Item(0).ToString).ToArray

    End Sub

    Private Sub lblLeftRight_MouseDown(sender As Object, e As MouseEventArgs) Handles lblLeftRight.MouseDown
        OffsetLeftRight = e.X
    End Sub

    Private Sub lblLeftRight_MouseMove(sender As Object, e As MouseEventArgs) Handles lblLeftRight.MouseMove
        OffsetLeftRight = e.X
    End Sub

    Private Sub lblLeftRight_MouseUp(sender As Object, e As MouseEventArgs) Handles lblLeftRight.MouseUp
        If -150 <= OffsetLeftRight Then
            tlpMainData.ColumnStyles(0).Width -= -OffsetLeftRight
        Else
            tlpMainData.ColumnStyles(0).Width = 150 ' Val(lblMoveRightLeft.Text)
        End If
    End Sub

    Private Sub com_Area_SelectedIndexChanged(sender As Object, e As EventArgs) Handles com_Area.SelectedIndexChanged

        Dim sttSel As String = com_Area.SelectedItem.ToString
        TryCast(dgv_BaseLocations.dgv.DataSource, DataTable).DefaultView.RowFilter = "[Area] Like '" & sttSel & "'"
    End Sub

    Private Sub tsmNonSelectAll_Click(sender As Object, e As EventArgs) Handles tsmNonSelectAll.Click
        Dim drow() As DataRow = TryCast(dgv_qMainData.dgv.DataSource, DataTable).Select("[fSelect] = true")
        drow.ToList().ForEach(Sub(h) h.Item("fSelect") = False)
        Me.Validate()
    End Sub

    Private Sub tsmSelectAllHigh_Click(sender As Object, e As EventArgs) Handles tsmSelectAllHigh.Click
        For a = 0 To dgv_qMainData.dgv.SelectedRows.Count - 1
            dgv_qMainData.dgv.SelectedRows(a).Cells("fSelect").Value = True
        Next
        Me.Validate()
    End Sub

    Private Sub tsm_Update_Click(sender As Object, e As EventArgs) Handles tsm_Update.Click

        Dim drow() As DataRow = TryCast(dgv_qMainData.dgv.DataSource, DataTable).Select("[fSelect] = true")
        Dim q As String() = TryCast(dgv_qMainData.dgv.DataSource, DataTable).Columns.Cast(Of DataColumn).Select(Function(h) h.ColumnName).ToArray
        For a = 0 To drow.Length - 1

            ' drow(a).Item("idBaseGrouping")
        Next
    End Sub

    Private Sub trvGrouping_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles trvGrouping.AfterSelect
        'If trvGrouping.SelectedNode.Parent Is Nothing Then
        '    ts_AddGroup.Text = "Add Root"
        'Else
        '    ts_AddGroup.Text = "Add Child"
        'End If
        ButAddCopyChech()
        Me.Text = trvGrouping.SelectedNode.Name
        '  ts_AddGroup.Enabled = trvGrouping.SelectedNode.Level < 2


    End Sub

    Private Sub StatusRefresh()

        lblTssStatus.Text = IIf(bit.isEditRow, "Edit Row", "")
    End Sub
    Private Function GetValueFromField(inColumnAnyType As Object) As Object
        If inColumnAnyType Is Nothing Then
            Return DBNull.Value
        ElseIf inColumnAnyType.ToString = "" Then
            Return DBNull.Value
        Else

            Return inColumnAnyType
        End If

        ', DBNull.Value, uDgv.CurrentRow.Cells(dtMain.Columns(a).ColumnName).Value)
    End Function

    Private Sub txtCurentCell_TextChanged(sender As TextBox, e As EventArgs) 'Handles dgv_BaseGrouping._CellTextChange 'txtCurrentCell.TextChanged
        If bitExitTextChange Then Exit Sub
        '  SetLoacationPnlRewSelect(dgv_BaseGrouping)
        'Me.AddOwnedForm(frmSelectRow)
        ' frmSelectRow.AddOwnedForm(Me)
        frmSelectRow.Show()
        txtCurrentCell.Focus()
        Dim sttColumn As String = dgv_BaseGrouping.dgv.Columns(dgv_BaseGrouping.dgv.CurrentCell.ColumnIndex).Name

        Select Case sttColumn
            Case "MainGroup"
                dtf_BaseGroping.DefaultView.RowFilter = IIf(dgv_BaseGrouping.dgv.IsCurrentCellInEditMode And bitNoFilterBySpace = False, "[" & dtf_BaseGroping.Columns(0).ColumnName & "] Like '*" & txtCurrentCell.Text & "*'", "") ' "[" & dtValidFind.Columns(0).ColumnName & "] Like '*" & txtCurrentCell.Text & "*'"
                frmSelectRow.lstFiltered.Items.Clear()
                frmSelectRow.lstFiltered.Items.AddRange(modColumnDistinct(dtf_BaseGroping.DefaultView.ToTable, "MainGroup"))
                If frmSelectRow.lstFiltered.Items.Count > 0 Then frmSelectRow.lstFiltered.SelectedIndex = 0
            Case "SubGroup"
                dtf_BaseGroping.DefaultView.RowFilter = "[MainGroup] Like '" & dgv_BaseGrouping.dgv.CurrentRow.Cells("MainGroup").Value &
                    "'  And [SubGroup] Like '*" & IIf(dgv_BaseGrouping.dgv.IsCurrentCellInEditMode And bitNoFilterBySpace = False, txtCurrentCell.Text, "") & "*'"
                frmSelectRow.lstFiltered.Items.Clear()
                frmSelectRow.lstFiltered.Items.AddRange(modColumnDistinct(dtf_BaseGroping.DefaultView.ToTable, "SubGroup"))
                If frmSelectRow.lstFiltered.Items.Count > 0 Then frmSelectRow.lstFiltered.SelectedIndex = 0
                '   Stop
            Case "Dis1"
                dtf_BaseGroping.DefaultView.RowFilter = "[MainGroup] Like '" & dgv_BaseGrouping.dgv.CurrentRow.Cells("MainGroup").Value &
    "'  And [SubGroup] Like '" & dgv_BaseGrouping.dgv.CurrentRow.Cells("SubGroup").Value & "' And [Dis1] Like '*" &
    IIf(dgv_BaseGrouping.dgv.IsCurrentCellInEditMode And bitNoFilterBySpace = False, txtCurrentCell.Text, "") & "*'"
                frmSelectRow.lstFiltered.Items.Clear()
                frmSelectRow.lstFiltered.Items.AddRange(modColumnDistinct(dtf_BaseGroping.DefaultView.ToTable, "Dis1"))
                If frmSelectRow.lstFiltered.Items.Count > 0 Then frmSelectRow.lstFiltered.SelectedIndex = 0
        End Select
        bitNoFilterBySpace = False

    End Sub
    Private Sub dgv_BaseGrouping__CellTextChange(sender As uDgv) Handles dgv_BaseGrouping._CellTextChange
        'If dgv_BaseGrouping.bit.isEditRow Or dgv_BaseGrouping.bit.isNewRow Then
        '    tmrIsDupicateRow.Enabled = False
        '    tmrIsDupicateRow.Enabled = True
        'End If
        ' frmSelectRow.Show
        ' dgv_BaseGrouping.txtCurrentCell.Focus()
        Dim sttColumn As String = dgv_BaseGrouping.dgv.Columns(dgv_BaseGrouping.dgv.CurrentCell.ColumnIndex).Name

        Select Case sttColumn
            Case "MainGroup"
                dtf_BaseGroping.DefaultView.RowFilter = IIf(dgv_BaseGrouping.dgv.IsCurrentCellInEditMode And bitNoFilterBySpace = False, "[" & dtf_BaseGroping.Columns(0).ColumnName & "] Like '*" & dgv_BaseGrouping.txtCurrentCell.Text & "*'", "") ' "[" & dtValidFind.Columns(0).ColumnName & "] Like '*" & txtCurrentCell.Text & "*'"

                frmSelectRow.lstFiltered.Items.Clear()
                frmSelectRow.lstFiltered.Items.AddRange(modColumnDistinct(dtf_BaseGroping.DefaultView.ToTable, "MainGroup"))
                If frmSelectRow.lstFiltered.Items.Count > 0 Then frmSelectRow.lstFiltered.SelectedIndex = 0
            Case "SubGroup"
                dtf_BaseGroping.DefaultView.RowFilter = "[MainGroup] Like '" & dgv_BaseGrouping.dgv.CurrentRow.Cells("MainGroup").Value &
                    "'  And [SubGroup] Like '*" & IIf(dgv_BaseGrouping.dgv.IsCurrentCellInEditMode And bitNoFilterBySpace = False, dgv_BaseGrouping.txtCurrentCell.Text, "") & "*'"
                frmSelectRow.lstFiltered.Items.Clear()
                frmSelectRow.lstFiltered.Items.AddRange(modColumnDistinct(dtf_BaseGroping.DefaultView.ToTable, "SubGroup"))
                If frmSelectRow.lstFiltered.Items.Count > 0 Then frmSelectRow.lstFiltered.SelectedIndex = 0
                '   Stop
            Case "Dis1"
                dtf_BaseGroping.DefaultView.RowFilter = "[MainGroup] Like '" & dgv_BaseGrouping.dgv.CurrentRow.Cells("MainGroup").Value &
    "'  And [SubGroup] Like '" & dgv_BaseGrouping.dgv.CurrentRow.Cells("SubGroup").Value & "' And [Dis1] Like '*" &
    IIf(dgv_BaseGrouping.dgv.IsCurrentCellInEditMode And bitNoFilterBySpace = False, dgv_BaseGrouping.txtCurrentCell.Text, "") & "*'"
                frmSelectRow.lstFiltered.Items.Clear()
                frmSelectRow.lstFiltered.Items.AddRange(modColumnDistinct(dtf_BaseGroping.DefaultView.ToTable, "Dis1"))
                If frmSelectRow.lstFiltered.Items.Count > 0 Then frmSelectRow.lstFiltered.SelectedIndex = 0
        End Select
        bitNoFilterBySpace = False

        frmSelectRow.Visible = frmSelectRow.lstFiltered.Items.Count > 0
        If frmSelectRow.Visible Then dgv_BaseGrouping.txtCurrentCell.Focus()
        If frmSelectRow.Visible And frmSelectRow.dgv Is Nothing Then
            frmSelectRow.dgv = sender

        End If
        dgv_BaseGrouping.FrmSelect_CountItems = frmSelectRow.lstFiltered.Items.Count
        dgv_BaseGrouping.FrmSelect_Visible = frmSelectRow.Visible
        dgv_BaseGrouping.FrmSelect_SelectItem = frmSelectRow.lstFiltered.SelectedItem

    End Sub
    Private Sub dgv_BaseGrouping__ProcessCmdKey(sender As uDgv, ByRef m As Message, ByRef keyData As Keys, ByRef Cancel As Boolean) Handles dgv_BaseGrouping._ProcessCmdKey
        dgvCurrent = sender.dgv
        ' keyData = Keys.Tab
        ' m.WParam = CInt(Keys.Tab)
        ' Exit Sub
        If dgvCurrent.IsCurrentCellInEditMode = False And keyData = Keys.Space And frmSelectRow.Visible = False Then


            frmSelectRow.Show()
            dgv_BaseGrouping.dgv.BeginEdit(True)
            bitNoFilterBySpace = True
            dgv_BaseGrouping__CellTextChange(sender)
            If dgv_BaseGrouping.bit.isEditRow Or dgv_BaseGrouping.bit.isNewRow Then
                dgv_BaseGrouping.TimerFalseTrue(dgv_BaseGrouping.tmrIsDupicateRow)
            End If
            Cancel = True
        ElseIf frmSelectRow.Visible And keyData = (Keys.ControlKey + Keys.Control) Then
            Cancel = True
            dgv_BaseGrouping.bit.ExitTextChange = True
            dgv_BaseGrouping.txtCurrentCell.Text = frmSelectRow.lstFiltered.SelectedItem
            dgv_BaseGrouping.txtCurrentCell.SelectionStart = dgv_BaseGrouping.txtCurrentCell.TextLength
            dgv_BaseGrouping.bit.ExitTextChange = False

        ElseIf frmSelectRow.Visible = False And keyData = Keys.Enter Then
            If sender.dgv.IsCurrentCellInEditMode Then
                dgv_BaseGrouping.dgv.EndEdit()
            Else
                keyData = Keys.Tab
                m.WParam = CInt(Keys.Tab)
            End If
        ElseIf frmSelectRow.Visible And keyData = Keys.Escape And sender.bit.isNewRow Then
            Cancel = True
            frmSelectRow.Hide()
        ElseIf keyData = Keys.Escape And sender.bit.isNewRow Then
            sender.bit.isNewRow = False
            '  dgv_BaseGrouping.dgv.EndEdit()
        ElseIf frmSelectRow.Visible Then
            If keyData = Keys.Enter Or keyData = Keys.Tab Then
                If frmSelectRow.lstFiltered.BackColor.Name = "ffff961b" And keyData = Keys.Tab Then
                    dgv_BaseGrouping.bit.ExitTextChange = True
                    dgv_BaseGrouping.txtCurrentCell.Text = frmSelectRow.lstFiltered.SelectedItem
                    dgv_BaseGrouping.txtCurrentCell.SelectionStart = dgv_BaseGrouping.txtCurrentCell.TextLength
                    dgv_BaseGrouping.bit.ExitTextChange = False
                    Cancel = True
                    dgv_BaseGrouping.TimerFalseTrue(dgv_BaseGrouping.tmrIsDupicateRow)
                ElseIf (frmSelectRow.lstFiltered.Items.Count = 0) Or (dgv_BaseGrouping.tmrIsDupicateRow.Enabled = False AndAlso dgv_BaseGrouping.bit.IsRowDuplicate) Then
                    Cancel = True

                Else

                    dgv_BaseGrouping.bit.ExitTextChange = True
                    dgv_BaseGrouping.txtCurrentCell.Text = frmSelectRow.lstFiltered.SelectedItem
                    dgv_BaseGrouping.bit.ExitTextChange = False
                    ' dgv_BaseGrouping.FrmSelect_Visible = frmSelectRow.Visible
                    dgv_BaseGrouping.dgv.EndEdit()
                    frmSelectRow.Hide()
                    '  dgv_BaseGrouping.Focus()
                    '  keyData = Keys.Tab
                    ' m.WParam = CInt(Keys.Tab)
                    'Cancel = False
                End If
            ElseIf (keyData = Keys.Down Or keyData = Keys.Up) Then
                If dgv_BaseGrouping.bit.isEditRow Or dgv_BaseGrouping.bit.isNewRow Then
                    dgv_BaseGrouping.TimerFalseTrue(dgv_BaseGrouping.tmrIsDupicateRow)
                End If
                modLstBoxSelectItemUpDown(keyData, frmSelectRow.lstFiltered)
                Cancel = True
            ElseIf keyData = Keys.Escape Then
                frmSelectRow.Hide()

                dgv_BaseGrouping.TimerFalseTrue(dgv_BaseGrouping.tmrIsDupicateRow)


                Cancel = True
            ElseIf frmSelectRow.lstFiltered.BackColor.Name = "ffff961b" And keyData = Keys.Tab Then
                dgv_BaseGrouping.bit.ExitTextChange = True
                dgv_BaseGrouping.txtCurrentCell.Text = frmSelectRow.lstFiltered.SelectedItem
                dgv_BaseGrouping.bit.ExitTextChange = False
                Cancel = True
            End If



        End If

    End Sub
    Private Sub dgv_BaseGrouping__TimerCurrentRowIsDouplicate(sender As uDgv, cancel As Boolean) Handles dgv_BaseGrouping._TimerCurrentRowIsDouplicate
        Dim curColumn As String = sender.dgv.Columns(sender.dgv.CurrentCell.ColumnIndex).Name
        Dim sttFilter As String = "([MainGroup] Like '[MainGroup_Rep]') And ([SubGroup] Like '[SubGroup_Rep]') And ([Dis1] Like '[Dis1_Rep]')"
        sttFilter = Replace(sttFilter, "[" & curColumn & "_Rep]", IIf(frmSelectRow.Visible AndAlso frmSelectRow.lstFiltered.Items.Count > 0, frmSelectRow.lstFiltered.SelectedItem, dgv_BaseGrouping.dgv.CurrentCell.EditedFormattedValue), Count:=1)
        Dim ColumnsName As String() = {"MainGroup", "SubGroup", "Dis1"}.Except({curColumn}).ToArray
        For Each cel In ColumnsName
            sttFilter = Replace(sttFilter, "[" & cel & "_Rep]", sender.dgv.CurrentRow.Cells(cel).Value.ToString, Count:=1)
        Next
        Dim SpecialColumns As String() = {"MainGroup", "SubGroup", "Dis1"}
        Dim CurrentRowAnyChange As String = Join(SpecialColumns.Select(Function(h) If(h = curColumn, IIf(frmSelectRow.Visible AndAlso frmSelectRow.lstFiltered.Items.Count > 0, frmSelectRow.lstFiltered.SelectedItem, dgv_BaseGrouping.dgv.CurrentCell.EditedFormattedValue), sender.dgv.CurrentRow.Cells(h).Value.ToString)).ToArray, "")
        If TryCast(sender.dgv.DataSource, DataTable).Rows.Count = 0 Then

        End If
        Dim q3 = TryCast(sender.dgv.DataSource, DataTable).AsEnumerable.Where(Function(b) b.RowState <> DataRowState.Deleted).Select(Function(h) h.Item("MainGroup") & h.Item("SubGroup") & h.Item("Dis1")).ToArray

        sender.bit.isCellChange = sender.dgv.CurrentCell.EditedFormattedValue <> sender.dgv.CurrentCell.Value.ToString
        Dim drow As DataRow() = TryCast(sender.dgv.DataSource, DataTable).Select(sttFilter)
        sender.bit.IsRowDuplicate = sender.dgv.IsCurrentCellInEditMode AndAlso q3.Contains(CurrentRowAnyChange) '(Not drow.Length = 0) ' sender.isRowCurrentChange AndAlso (Not drow.Length = 0)
        ' Me.Text = q3.Contains(CurrentRowAnyChange) & " " & sender.bit.IsRowDuplicate
        frmSelectRow.lstFiltered.BackColor = IIf(dgv_BaseGrouping.bit.IsRowDuplicate, color1, color2)
        frmSelectRow.IsError = sender.bit.IsRowDuplicate
        Dim q1 = Join(drow.AsEnumerable.Select(Function(h) h.Item("id").ToString).ToArray, ",")
        If drow.Length > 0 And sender.dgv.IsCurrentCellInEditMode Then
            lblTssStatus.Text = "Duplicati On :" & Join(drow.AsEnumerable.Select(Function(h) h.Item("id").ToString).ToArray, ",")

        Else

            lblTssStatus.Text = ""

        End If
        'Dim dtTest As New DataTable
        'dtTest = TryCast(sender.dgv.DataSource, DataTable)
        'dtTest.Columns.AddRange({New DataColumn With {.ColumnName = "MainGroup"}, New DataColumn With {.ColumnName = "SubGroup"}, New DataColumn With {.ColumnName = "Dis1"}})
        'dtTest.Rows.Add({"CCM", "Supporting", "UNP 100 mm"})
        'dtTest.Rows.Add({"CCM", "Supporting", "UNP 80 mm"})
        'Dim dr() As DataRow = dtTest.Select("[MainGroup] Like 'Pump Station' And [SubGroup] Like 'Supporting' And [Dis1] Like 'UNP 100 mm'")

    End Sub
    Private Sub dgv_BaseGrouping__CellValidating(sender As uDgv, e As DataGridViewCellValidatingEventArgs) Handles dgv_BaseGrouping._CellValidating
        If dgv_BaseGrouping.bit.isCurrentRowChange AndAlso dgv_BaseGrouping.bit.isEditRow Or dgv_BaseGrouping.bit.isNewRow Then

            e.Cancel = (dgv_BaseGrouping.tmrIsDupicateRow.Enabled Or dgv_BaseGrouping.bit.isCellChange) AndAlso dgv_BaseGrouping.bit.IsRowDuplicate
            'dgv_BaseGrouping.bit.isCurrentRowChange = False
            'If dgv_BaseGrouping.bit.isCellChange = False Then dgv_BaseGrouping.dgv.EndEdit()
        End If
        'If e.Cancel = False Then

        'End If
        ' dgv_BaseGrouping.TimerFalseTrue(dgv_BaseGrouping.tmrIsDupicateRow)

    End Sub


    Private Sub dgv_BaseGrouping_RowValidating(sender As uDgv, e As DataGridViewCellCancelEventArgs) Handles dgv_BaseGrouping._RowValidating
        If dgv_BaseGrouping.bit.isEditRow Or dgv_BaseGrouping.bit.isNewRow Then
            ' sender.dgv.CurrentRow.DataBoundItem
            If sender.NullCellsInAnyColumns(Split("MainGroup,SubGroup,Dis1", ",")) Then
                e.Cancel = True

                Exit Sub
            End If
            e.Cancel = (dgv_BaseGrouping.tmrIsDupicateRow.Enabled Or dgv_BaseGrouping.bit.isCellChange) AndAlso dgv_BaseGrouping.bit.IsRowDuplicate
        End If
        If sender.bit.isCurrentRowChange AndAlso e.Cancel = False AndAlso (sender.bit.isEditRow Or sender.bit.isNewRow) Then
            tab_LoadMainData()
            Dim sttSql As String
            If sender.bit.isNewRow Then
                sttSql = sender.Sql_Insert(sender.dgv.CurrentRow.DataBoundItem.row, Split(sender.Name, "_")(1))
                modData_ExecuteNonQuery(sender.dgv, sttSql)
            Else
                Dim drows As DataRow() = dt_qMainData.Select("[idBaseGrouping]=" & sender.dgv.CurrentRow.Cells("ID").Value)
                Dim q3 = Split("MainGroup,SubGroup,Dis1,Dis2", ",")
                drows.ToList().ForEach(Sub(g)
                                           g.Item("MainGroup") = sender.dgv.CurrentRow.Cells("MainGroup").Value
                                           g.Item("SubGroup") = sender.dgv.CurrentRow.Cells("SubGroup").Value
                                           g.Item("Dis1") = sender.dgv.CurrentRow.Cells("Dis1").Value
                                           g.Item("Dis2") = sender.dgv.CurrentRow.Cells("Dis2").Value
                                       End Sub)

                sttSql = sender.Sql_Update(sender.dgv, Split(sender.Name, "_")(1), ColumnsFilter:={"ID"}) & " Where (Id=" & sender.dgv.CurrentRow.Cells("ID").Value & ")"
                If modData_ExecuteNonQuery(sender.dgv, sttSql) = 0 Then
                    Stop
                    ' Dim drv As DataRowView
                    ' ds.Tables(0).ChildRelations.
                End If
            End If

            'TryCast(sender.dgv.CurrentRow.DataBoundItem.row, DataRow).ItemArray
        End If
        'sender.bit.isNewRow = e.Cancel And sender.bit.isNewRow
        'sender.bit.isEditRow = e.Cancel And sender.bit.isEditRow
    End Sub
    Private Sub dgv_BaseGrouping__CellEndEdit(sender As uDgv, e As DataGridViewCellEventArgs) Handles dgv_BaseGrouping._CellEndEdit
        bit.RowIsDouplicate = (dgv_BaseGrouping.bit.isEditRow Or dgv_BaseGrouping.bit.isNewRow) AndAlso bit.RowIsDouplicate
        frmSelectRow.lstFiltered.Items.Clear()
        bitExitTextChange = True

        frmSelectRow.Hide()
        dgv_BaseGrouping.TimerFalseTrue(dgv_BaseGrouping.tmrIsDupicateRow)

    End Sub

    Private Function KeyEvent(ByRef KeyData As Keys) As Boolean

        If dgvCurrent.IsCurrentCellInEditMode = False And KeyData = Keys.Space And frmSelectRow.Visible = False Then
            frmSelectRow.Show()
            dgv_BaseGrouping.dgv.BeginEdit(True)
            bitNoFilterBySpace = True
            dgv_BaseGrouping__CellTextChange(Nothing)
            If dgv_BaseGrouping.bit.isEditRow Or dgv_BaseGrouping.bit.isNewRow Then
                dgv_BaseGrouping.TimerFalseTrue(dgv_BaseGrouping.tmrIsDupicateRow)
            End If
        ElseIf KeyData = Keys.Enter Or KeyData = Keys.Tab Then
            If frmSelectRow.Visible Then
                If (frmSelectRow.lstFiltered.Items.Count = 0) Or (dgv_BaseGrouping.tmrIsDupicateRow.Enabled = False AndAlso dgv_BaseGrouping.bit.IsRowDuplicate) Then
                    Return True

                Else

                    dgv_BaseGrouping.bit.ExitTextChange = True
                    dgv_BaseGrouping.txtCurrentCell.Text = frmSelectRow.lstFiltered.SelectedItem
                    dgv_BaseGrouping.bit.ExitTextChange = False
                    KeyData = Keys.Tab
                    Return False
                End If


            End If



            Return False

            If dgv_BaseGrouping.tmrIsDupicateRow.Enabled = False AndAlso dgv_BaseGrouping.bit.IsRowDuplicate = False Then

            Else
                If frmSelectRow.Visible And frmSelectRow.lstFiltered.Items.Count > 0 Then

                Else
                    If dgv_BaseGrouping.txtCurrentCell.Text = frmSelectRow.lstFiltered.SelectedItem Then
                        Return True
                    End If
                End If


            End If

            ' If bit.IsRowDuplicate = False Then
            bit.ExitCellValidating = True
            If frmSelectRow.Visible And frmSelectRow.lstFiltered.Items.Count > 0 Then
                bitExitTextChange = True
                dgv_BaseGrouping.txtCurrentCell.Text = frmSelectRow.lstFiltered.SelectedItem
                bitExitTextChange = False
                '   bit.ValidByEnter = False
                ' ElseIf frmSelectRow.lstFiltered.Items.Count > 0 Then

            ElseIf dtf_BaseGroping.DefaultView.RowFilter = "" Then

            Else
                '   e.Cancel = True
            End If

            If dgv_BaseGrouping.dgv.Columns(dgv_BaseGrouping.dgv.CurrentCell.ColumnIndex).Name = "MainGroup" Then

                dgv_BaseGrouping.dgv.CurrentCell = dgv_BaseGrouping.dgv.Item("SubGroup", dgv_BaseGrouping.dgv.CurrentRow.Index)
            ElseIf dgv_BaseGrouping.dgv.Columns(dgv_BaseGrouping.dgv.CurrentCell.ColumnIndex).Name = "SubGroup" Then
                dgv_BaseGrouping.dgv.CurrentCell = dgv_BaseGrouping.dgv.Item("Dis1", dgv_BaseGrouping.dgv.CurrentRow.Index)
            ElseIf dgv_BaseGrouping.dgv.Columns(dgv_BaseGrouping.dgv.CurrentCell.ColumnIndex).Name = "Dis1" Then
                ' Me.Validate()
                ' Dim bitRowChange As Boolean = dgv_BaseGrouping.IsCurrentCellInEditMode AndAlso Not Join(DataRowCancel.ItemArray) = Join(TryCast(dgv_BaseGrouping.CurrentRow.DataBoundItem.row, DataRow).ItemArray)

                If dgv_BaseGrouping.tmrIsDupicateRow.Enabled AndAlso dgv_BaseGrouping.bit.IsRowDuplicate = False Then
                    dgv_BaseGrouping.dgv.CurrentCell = dgv_BaseGrouping.dgv.Item("MainGroup", dgv_BaseGrouping.dgv.CurrentRow.Index + IIf(dgv_BaseGrouping.dgv.RowCount - 1 = dgv_BaseGrouping.dgv.CurrentRow.Index, 0, 1))

                    'Else

                End If
            Else
                dgv_BaseGrouping.dgv.CurrentCell = dgv_BaseGrouping.dgv.Item("MainGroup", dgv_BaseGrouping.dgv.CurrentRow.Index + IIf(dgv_BaseGrouping.dgv.RowCount - 1 = dgv_BaseGrouping.dgv.CurrentRow.Index, 0, 1))

                ' e.Cancel = False
            End If

            ' bit.ValidByEnter = True
            '  KeyData = Keys.Tab


            'End If
            Return True
        ElseIf frmSelectRow.Visible AndAlso (KeyData = Keys.Down Or KeyData = Keys.Up) Then
            If dgv_BaseGrouping.bit.isEditRow Or dgv_BaseGrouping.bit.isNewRow Then
                dgv_BaseGrouping.tmrIsDupicateRow.Enabled = False

            End If
            modLstBoxSelectItemUpDown(KeyData, frmSelectRow.lstFiltered)
            ' bitExitTextChange = False
            Return True

        ElseIf frmSelectRow.Visible AndAlso KeyData = Keys.Tab Then
            bit.ValidByEnter = True
            'bitExitTextChange = True
            'txtCurrentCell.Text = frmSelectRow.lstFiltered.SelectedItem
            'txtCurrentCell.SelectionStart = txtCurrentCell.Text.Length
            'bitExitTextChange = False
            'Return True
        ElseIf KeyData = Keys.Enter + Keys.Shift Then
            KeyData = Keys.Enter
            bit.ExitCellValidating = True
            If bit.RowIsDouplicate = False Then
                dgv_BaseGrouping.dgv.CurrentCell = dgv_BaseGrouping.dgv.Item(dgv_BaseGrouping.dgv.CurrentCell.ColumnIndex, dgv_BaseGrouping.dgv.CurrentRow.Index + 1)
            Else
                Return True
            End If
            '  bit.AcceptValidByShiftEnter = True
        ElseIf KeyData = Keys.Escape And frmSelectRow.Visible Then
            frmSelectRow.Hide()
            Return True
        ElseIf KeyData = Keys.Escape Then
            dgv_BaseGrouping.bit.IsRowDuplicate = False
        ElseIf dgv_BaseGrouping.tmrIsDupicateRow.Enabled = False AndAlso dgv_BaseGrouping.bit.IsRowDuplicate Then
            If dgv_BaseGrouping.bit.isEditRow Or dgv_BaseGrouping.bit.isNewRow Then
                dgv_BaseGrouping.TimerFalseTrue(dgv_BaseGrouping.tmrIsDupicateRow)

            End If
            '    Return True
        Else
        End If
        'If dgv_BaseGrouping.bit.isEditRow Or dgv_BaseGrouping.bit.isNewRow Then
        '    tmrIsDupicateRow.Enabled = False
        '    tmrIsDupicateRow.Enabled = True
        'End If
    End Function

    Private Sub tsbHelper_Click(sender As Object, e As EventArgs)
        frmSelectRow.AddOwnedForm(Me)
        frmSelectRow.Visible = Not frmSelectRow.Visible
        If frmSelectRow.Visible Then
            dgv_BaseGrouping.dgv.BeginEdit(True)
            bitNoFilterBySpace = True
            txtCurentCell_TextChanged(Nothing, Nothing)
        ElseIf frmSelectRow.lstFiltered.Items.Count > 0 Then
            'dgv_BaseGrouping.EndEdit()
        End If

    End Sub


    Private Sub txtSearch_Click(sender As Object, e As EventArgs) Handles txtSearch.Click
        cms_Menu.Show(MousePosition)
    End Sub
    Public Sub SelectRow(InList As ListBox)
        bit.ExitCellValidating = True
        bitExitTextChange = True
        dgv_BaseGrouping.txtCurrentCell.Text = InList.SelectedItem
        bit.ValidBySelectList = True
        bitExitTextChange = False
        frmSelectRow.Visible = False
    End Sub


    Private Sub cms_AddGroping_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles cms_AddGroping.Opening
        tsmAddChild.Enabled = trvGrouping.SelectedNode.Level < 2
    End Sub

    Private Sub butCopyGroup_Click(sender As Object, e As EventArgs)
        trvGrouping.SelectedNode.Parent.Nodes.Add(trvGrouping.SelectedNode.Text)

    End Sub

    Private Sub butAddGroup_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub ts_EditGroup_Click(sender As Object, e As EventArgs) Handles ts_EditGroup.Click


    End Sub

    Private Sub ts_CopyGroup_Click(sender As Object, e As EventArgs) Handles ts_CopyGroup.Click
        'If trvGrouping.SelectedNode.Parent IsNot Nothing Then
        '    trvGrouping.SelectedNode.Parent.Nodes.Add(trvGrouping.SelectedNode.Text)
        'Else
        '    trvGrouping.Nodes.Add(trvGrouping.SelectedNode.Text)
        'End If
        Dim MaxId As Integer = TryCast(dgv_BaseGrouping.dgv.DataSource, DataTable).Compute("Max([ID])", "") + 1
        If trvGrouping.SelectedNode.Level = 0 Then
            TryCast(dgv_BaseGrouping.dgv.DataSource, DataTable).Rows.Add({MaxId, ts_GetText.Text})
        ElseIf trvGrouping.SelectedNode.Level = 1 Then
            TryCast(dgv_BaseGrouping.dgv.DataSource, DataTable).Rows.Add({MaxId, trvGrouping.SelectedNode.Parent.Text, ts_GetText.Text})


            '   Dim drow As DataRow() = TryCast(dgv_BaseGrouping.DataSource, DataTable).Select("[id]=" & trvGrouping.SelectedNode.Name)
            '  drow(0).Item("SubGroup") = ts_GetText.Text
        End If


        If trvGrouping.SelectedNode.Parent IsNot Nothing Then
            trvGrouping.SelectedNode.Parent.Nodes.Add(MaxId, ts_GetText.Text)
        Else
            trvGrouping.Nodes.Add(MaxId, ts_GetText.Text)
        End If

        ButAddCopyChech()
    End Sub

    Private Sub ts_AddGroup_Click(sender As Object, e As EventArgs) Handles ts_AddGroup.Click
        '  trvGrouping.SelectedNode.Nodes.Add(trvGrouping.SelectedNode.Text)
        trvGrouping.SelectedNode.Nodes.Add(ts_GetText.Text)




        ButAddCopyChech()
    End Sub

    Private Sub tsmCheckGroup_Click(sender As Object, e As EventArgs) Handles tsmCheckGroup.Click
        '  ClearNodeBackgroundColors(trvGrouping.Nodes)
        '  Dim q = trvGrouping.Nodes.Cast(Of TreeNode).Select(Function(h) h.Text).ToArray
        LisDouplicatNodes.Clear()
        CheckDoublicateOnNodes(trvGrouping.Nodes)
        If LisDouplicatNodes.Count > 0 Then
            lstChackGroup.Items.Clear()
            lstChackGroup.Items.AddRange(LisDouplicatNodes.ToArray)
        End If

    End Sub
    Private Function CheckDoublicateOnNodes(ByVal Nodes As TreeNodeCollection) As String()
        Dim q = Nodes.Cast(Of TreeNode).Select(Function(h) h.Text).ToArray
        Dim q2 = q.AsEnumerable.Select(Function(x, idx) New With {x, idx}).GroupBy(Function(h) h.x).Select(Function(j) j.ToArray).ToArray ' .GroupBy(Function(t) t).Select(Function(h) h).ToArray
        For a = 0 To q2.Length - 1
            If q2(a).Length > 1 Then
                For b = 0 To q2(a).Length - 1
                    LisDouplicatNodes.Add(Nodes(q2(a)(b).idx))
                Next

            End If
        Next
        Nodes.Cast(Of TreeNode)().ToList().ForEach(Sub(node) CheckDoublicateOnNodes(node.Nodes))

        '        Dim myArray As Integer() = {1, 2, 3, 5, 6, 8, 9, 7, 10, 20, 21, 23, 22}
        '        Dim result As Integer()() = myArray _
        '.OrderBy(Function(x) x) _
        '.Select(Function(x, i) New With {x, i, .d = x - i}) _
        '.GroupBy(Function(t) t.d) _
        '.Select(Function(g) New Integer() {g.Min(Function(t) t.x), g.Max(Function(t) t.x)}) _
        '.ToArray

    End Function
    Private Sub ClearNodeBackgroundColors(ByVal nodes As TreeNodeCollection)
        nodes.Cast(Of TreeNode)().ToList().ForEach(Sub(node) node.ForeColor = Color.FromArgb(0, 0, 0, 0))
        nodes.Cast(Of TreeNode)().ToList().ForEach(Sub(node) ClearNodeBackgroundColors(node.Nodes))
    End Sub


    Private Sub lstChackGroup_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstChackGroup.SelectedIndexChanged
        trvGrouping.SelectedNode = LisDouplicatNodes(lstChackGroup.SelectedIndex)
        trvGrouping.Focus()
        ' trvGrouping.LabelEdit = True
    End Sub

    Private Sub tsm_ExpandAll_Click(sender As Object, e As EventArgs) Handles tsm_ExpandAll.Click
        trvGrouping.ExpandAll()

    End Sub

    Private Sub tsm_CollapseAll_Click(sender As Object, e As EventArgs) Handles tsm_CollapseAll.Click
        trvGrouping.CollapseAll()
    End Sub



    Private Sub lstRowSelFind_MouseDown(sender As Object, e As MouseEventArgs)

    End Sub

    Private Sub trvGrouping_AfterLabelEdit(sender As Object, e As NodeLabelEditEventArgs) Handles trvGrouping.AfterLabelEdit
        Dim qCurrent As String()
        If trvGrouping.SelectedNode.Parent Is Nothing Then
            qCurrent = trvGrouping.Nodes.Cast(Of TreeNode).Select(Function(h) h.Text).ToArray
        Else
            qCurrent = trvGrouping.SelectedNode.Parent.Nodes.Cast(Of TreeNode).Select(Function(h) h.Text).ToArray
        End If
        e.CancelEdit = qCurrent.Contains(e.Label)
        ButAddCopyChech(e.Label)
        Exit Sub
        If e.Label Is Nothing Then Exit Sub

        Dim dRow() As DataRow
        'If bit.ExitTrvGruping Then

        '    Exit Sub
        'End If
        If e.Node.Level = 0 Then
            dRow = TryCast(dgv_BaseGrouping.dgv.DataSource, DataTable).Select("[MainGroup] Like '" & e.Node.Text & "'")
            For Each a As DataRow In dRow
                a.Item("MainGroup") = e.Label
            Next
        ElseIf e.Node.Level = 1 Then

            dRow = TryCast(dgv_BaseGrouping.dgv.DataSource, DataTable).Select("[MainGroup] Like '" & e.Node.Parent.Text & "' And [SubGroup] Like '" & e.Node.Text & "'")
            For Each a As DataRow In dRow
                a.Item("SubGroup") = e.Label
            Next
        ElseIf e.Node.Level = 2 Then
            dRow = TryCast(dgv_BaseGrouping.dgv.DataSource, DataTable).Select("[MainGroup] Like '" & e.Node.Parent.Parent.Text & "' And [SubGroup] Like '" & e.Node.Parent.Text & "' And [Dis1] Like '" & e.Node.Text & "'")
            For Each a As DataRow In dRow
                a.Item("Dis1") = e.Label
            Next
        End If

        tab_LoadMainData()

    End Sub

    Private Sub trvGrouping_TextChanged(sender As Object, e As EventArgs) Handles trvGrouping.TextChanged

    End Sub

    Private Sub trvGrouping_KeyUp(sender As Object, e As KeyEventArgs) Handles trvGrouping.KeyUp
        If e.KeyData = Keys.Enter Then
            e.SuppressKeyPress = True
            '  Me.Validate()
        End If
    End Sub

    Private Sub trvGrouping_Validated(sender As Object, e As EventArgs) Handles trvGrouping.Validated

    End Sub

    Private Sub trvGrouping_BeforeLabelEdit(sender As Object, e As NodeLabelEditEventArgs) Handles trvGrouping.BeforeLabelEdit

    End Sub

    Private Sub trvGrouping_BeforeSelect(sender As Object, e As TreeViewCancelEventArgs) Handles trvGrouping.BeforeSelect
        '  bit.ExitTrvGruping = False
    End Sub

    Private Sub tsmEditTrvGrouping_Click(sender As Object, e As EventArgs) Handles tsmEditTrvGrouping.Click
        tsmEditTrvGrouping.Checked = Not tsmEditTrvGrouping.Checked
        trvGrouping.CheckBoxes = tsmEditTrvGrouping.Checked
        'ts_OkGroup.Visible = tsmEditTrvGrouping.Checked
        'ts_CancelGroup.Visible = tsmEditTrvGrouping.Checked
        ts_AddGroup.Visible = tsmEditTrvGrouping.Checked
        ts_CopyGroup.Visible = tsmEditTrvGrouping.Checked
        ts_DeleteGroup.Visible = tsmEditTrvGrouping.Checked
        ts_Rename.Visible = tsmEditTrvGrouping.Checked
        If tsmEditTrvGrouping.Checked Then
            trvGrouping.BackColor = Color.LightGreen
        Else
            trvGrouping.BackColor = Color.White
        End If
    End Sub

    Private Sub ts_Rename_Click(sender As Object, e As EventArgs) Handles ts_Rename.Click
        If trvGrouping.SelectedNode Is Nothing Then Exit Sub
        frmDialogRename.txtRename.Text = trvGrouping.SelectedNode.Text

        frmDialogRename.ShowDialog()
        If frmDialogRename.DialogResult = DialogResult.OK Then
            ' trvGrouping.SelectedNode.Text = frmDialogRename.txtRename.Text
            ' If e.Label Is Nothing Then Exit Sub

            Dim dRow() As DataRow
            'If bit.ExitTrvGruping Then

            '    Exit Sub
            'End If
            If trvGrouping.SelectedNode.Level = 0 Then
                dRow = TryCast(dgv_BaseGrouping.dgv.DataSource, DataTable).Select("[MainGroup] Like '" & trvGrouping.SelectedNode.Text & "'")
                For Each a As DataRow In dRow
                    a.Item("MainGroup") = frmDialogRename.txtRename.Text
                Next
            ElseIf trvGrouping.SelectedNode.Level = 1 Then

                dRow = TryCast(dgv_BaseGrouping.dgv.DataSource, DataTable).Select("[MainGroup] Like '" & trvGrouping.SelectedNode.Parent.Text & "' And [SubGroup] Like '" & trvGrouping.SelectedNode.Text & "'")
                For Each a As DataRow In dRow
                    a.Item("SubGroup") = frmDialogRename.txtRename.Text
                Next
            ElseIf trvGrouping.SelectedNode.Level = 2 Then
                dRow = TryCast(dgv_BaseGrouping.dgv.DataSource, DataTable).Select("[MainGroup] Like '" & trvGrouping.SelectedNode.Parent.Parent.Text & "' And [SubGroup] Like '" & trvGrouping.SelectedNode.Parent.Text & "' And [Dis1] Like '" & trvGrouping.SelectedNode.Text & "'")
                For Each a As DataRow In dRow
                    a.Item("Dis1") = frmDialogRename.txtRename.Text
                Next
            End If

            tab_LoadMainData()



        End If


    End Sub

    Private Sub ts_GetText_Click(sender As Object, e As EventArgs) Handles ts_GetText.Click

    End Sub

    Private Sub ts_GetText_DoubleClick(sender As Object, e As EventArgs) Handles ts_GetText.DoubleClick
        If trvGrouping.SelectedNode Is Nothing Then Exit Sub
        ts_GetText.Text = trvGrouping.SelectedNode.Text
    End Sub

    Private Sub ts_GetText_KeyUp(sender As Object, e As KeyEventArgs) Handles ts_GetText.KeyUp

    End Sub

    Private Sub ts_GetText_TextChanged(sender As Object, e As EventArgs) Handles ts_GetText.TextChanged
        ButAddCopyChech()
    End Sub
    Private Sub ButAddCopyChech(Optional InText As String = Nothing)
        Dim qCurrent As String()
        If trvGrouping.SelectedNode.Parent Is Nothing Then
            qCurrent = trvGrouping.Nodes.Cast(Of TreeNode).Select(Function(h) h.Text).ToArray
        Else
            qCurrent = trvGrouping.SelectedNode.Parent.Nodes.Cast(Of TreeNode).Select(Function(h) h.Text).ToArray
        End If

        Dim qChild = trvGrouping.SelectedNode.Nodes.Cast(Of TreeNode).Select(Function(h) h.Text).ToArray
        ts_CopyGroup.Enabled = Not qCurrent.Contains(ts_GetText.Text) And ts_GetText.Text <> ""
        ' ts_AddGroup.Enabled = Not bit2
        ts_AddGroup.Enabled = Not qChild.Contains(ts_GetText.Text) And trvGrouping.SelectedNode.Level < 2 And ts_GetText.Text <> ""

    End Sub



    Private Sub dgv_BaseGrouping_Load(sender As Object, e As EventArgs) Handles dgv_BaseGrouping.Load

    End Sub



    Private Sub dgv_BaseGrouping__CellMouseClick(sender As uDgv, e As DataGridViewCellMouseEventArgs) Handles dgv_BaseGrouping._CellMouseClick
        tsmImportData.Tag = sender.Name
    End Sub





    Private Sub dgv_BaseGrouping__CellXYCoordinate(sender As uDgv, CellRectangleOfScreen As Rectangle) Handles dgv_BaseGrouping._CellXYCoordinate
        If (CellRectangleOfScreen.Y + frmSelectRow.Height) > My.Computer.Screen.Bounds.Height Then
            CellRectangleOfScreen.Offset(New Point(0, -frmSelectRow.Height - CellRectangleOfScreen.Height - 3))
        End If
        frmSelectRow.Location = CellRectangleOfScreen.Location
    End Sub

    Private Sub dgv_BaseGrouping__CellCurrentChange(sender As uDgv, e As EventArgs) Handles dgv_BaseGrouping._CellCurrentChange
        If dgv_BaseGrouping.dgv.CurrentCell IsNot Nothing Then
            frmSelectRow.Hide()
            If dtf_BaseGroping.TableName <> "" Then
                dtf_BaseGroping = TryCast(dgv_BaseGrouping.dgv.DataSource, DataTable).DefaultView.ToTable(True, {"MainGroup", "SubGroup", "Dis1"})
            End If

        End If
    End Sub

    Private Sub dgv_BaseGrouping__CellGreenHelperClick(sender As uDgv) Handles dgv_BaseGrouping._CellGreenHelperClick
        frmSelectRow.Visible = Not frmSelectRow.Visible
        If frmSelectRow.Visible Then
            frmSelectRow.dgv = sender
            dgv_BaseGrouping.dgv.BeginEdit(True)
            bitNoFilterBySpace = True
            dgv_BaseGrouping__CellTextChange(Nothing)
            If dgv_BaseGrouping.bit.isEditRow Or dgv_BaseGrouping.bit.isNewRow Then
                dgv_BaseGrouping.TimerFalseTrue(dgv_BaseGrouping.tmrIsDupicateRow)

            End If
        End If


    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        ' Exit Sub
        Me.Text = "isEditRow: " & dgv_BaseGrouping.bit.isEditRow & " isNewRow: " & dgv_BaseGrouping.bit.isNewRow &
           " IsRowDuplicate: " & dgv_BaseGrouping.bit.IsRowDuplicate & " isCurrentRowChange:" & dgv_BaseGrouping.bit.isCurrentRowChange &
           " isCellChange: " & dgv_BaseGrouping.bit.isCellChange
    End Sub

    Private Sub frmSelectRow__List_SelectedIndexChanged(sender As dgv.frmValidOfColumn, OnDgv As uDgv) Handles frmSelectRow._List_SelectedIndexChanged
        dgv_BaseGrouping.TimerFalseTrue(dgv_BaseGrouping.tmrIsDupicateRow)

    End Sub

    Private Sub frmSelectRow__List_DoubleClickIfNotError(sender As dgv.frmValidOfColumn, OnDgv As uDgv) Handles frmSelectRow._List_DoubleClickIfNotError
        dgv_BaseGrouping.txtCurrentCell.Text = sender.lstFiltered.SelectedItem
        OnDgv.dgv.EndEdit()
        frmSelectRow.Visible = False
    End Sub

    Private Sub dgv_qMainData__RowValidating(sender As uDgv, e As DataGridViewCellCancelEventArgs) Handles dgv_qMainData._RowValidating

    End Sub

    Private Sub dgv_qMainData__RowValidatingWhenNewOrEdit(sender As uDgv, e As DataGridViewCellCancelEventArgs) Handles dgv_qMainData._RowValidatingWhenNewOrEdit
        If sender.bit.isCurrentRowChange = False Then Exit Sub
        Dim sttSql As String = sender.GetColumnsName
        'fSelect,ID,idBaseGrouping,idBaseLocations,DisItem,kAvaliyeQty,kArea,kGHararDad,kRadifGhararDad,pAvaliyeQty,vahed,Area,SubArea,MainGroup,SubGroup,Dis1,Dis2
        If sender.bit.isNewRow And sender.bit.isEditRow = False Then 'is Insert On Data Base
            sttSql = sender.Sql_Insert(sender.dgv.CurrentRow.DataBoundItem.row, Split(sender.Name, "_")(1), ColumnsFilter:=Split("fSelect,ID,Area,SubArea,MainGroup,SubGroup,Dis1,Dis2", ","))
            modData_ExecuteNonQuery(sender.dgv, sttSql)
        ElseIf sender.bit.isEditRow Then ' is Update Data Base By Where Id=?
            sttSql = sender.Sql_Update(sender.dgv, Split(sender.Name, "_")(1), sender.dgv.CurrentRow.Cells("Id").Value, ColumnsFilter:=Split("fSelect,ID,Area,SubArea,MainGroup,SubGroup,Dis1,Dis2", ","))
            modData_ExecuteNonQuery(sender.dgv, sttSql)
        End If

    End Sub

    Private Sub dgv_qMainData__DefaultValuesNeeded(sender As uDgv, e As DataGridViewRowEventArgs) Handles dgv_qMainData._DefaultValuesNeeded
        ' "fSelect,ID,idBaseGrouping,idBaseLocations,DisItem,kAvaliyeQty,kArea,kGHararDad,kRadifGhararDad,pAvaliyeQty,vahed,Area,SubArea,MainGroup,SubGroup,Dis1,Dis2"
        sender.bit.ExitCellValueChanged = True
        Dim MaxMainData As Object = Val(TryCast(sender.dgv.DataSource, DataTable).Compute("Max([ID])", "").ToString) + 1
        e.Row.Cells("ID").Value = Val(TryCast(sender.dgv.DataSource, DataTable).Compute("Max([ID])", "").ToString) + 1


        Dim drow As DataRow
        drow = TryCast(dgv_BaseGrouping.dgv.DataSource, DataTable).Rows.Find(1)
        If drow IsNot Nothing Then
            e.Row.Cells("idBaseGrouping").Value = 1
            TryCast(dgv_BaseGrouping.dgv.DataSource, DataTable).Columns.Cast(Of DataColumn).Where(Function(f) f.ColumnName <> "ID").ToList().ForEach(Sub(s) e.Row.Cells(s.ColumnName).Value = drow(s))
        Else
            MsgBox("dgv_qMainData__DefaultValuesNeeded Length of drow is 0 ")
        End If

        sender.bit.ExitCellValueChanged = False
        e.Row.Cells("idBaseLocations").Value = 1
    End Sub

    Private Sub dgv_BaseGrouping__DefaultValuesNeeded(sender As uDgv, e As DataGridViewRowEventArgs) Handles dgv_BaseGrouping._DefaultValuesNeeded
        e.Row.Cells("ID").Value = TryCast(sender.dgv.DataSource, DataTable).Compute("Max(ID)", "") + 1
    End Sub

    Private Sub dgv_qMainData__CellValueChanged(sender As uDgv, e As DataGridViewCellEventArgs) Handles dgv_qMainData._CellValueChanged
        'fSelect,ID,idBaseGrouping,idBaseLocations,DisItem,kAvaliyeQty,kArea,kGHararDad,kRadifGhararDad,pAvaliyeQty,vahed,Area,SubArea,MainGroup,SubGroup,Dis1,Dis2
        Dim currenColumnName As String = sender.dgv.Columns(e.ColumnIndex).Name
        Select Case currenColumnName
            Case "idBaseGrouping"
                Dim drow As DataRow()
                If dgv_qMainData.dgv.SelectedCells.Count = 1 Then

                    sender.bit.ExitCellValueChanged = True
                    drow = TryCast(dgv_BaseGrouping.dgv.DataSource, DataTable).Select("[Id]=" & sender.dgv.CurrentRow.Cells("idBaseGrouping").Value)
                    TryCast(dgv_BaseGrouping.dgv.DataSource, DataTable).Columns.Cast(Of DataColumn).Where(Function(f) f.ColumnName <> "ID").ToList().ForEach(Sub(s) sender.dgv.CurrentRow.Cells(s.ColumnName).Value = drow(0)(s))
                    'TryCast(sender.dgv.DataSource, DataTable).Columns.Cast(Of DataColumn).ToList().ForEach(Sub(s) sender.dgv.CurrentRow.Cells(s.ColumnName).Value = drow(0)(s))
                    sender.bit.ExitCellValueChanged = False
                End If

                '  sender.dgv.CurrentRow.Cells("MainGroup").Value = drow
        End Select



    End Sub

    Private Sub dgv_qMainData__UserDeletingRow(sender As uDgv, e As DataGridViewRowCancelEventArgs) Handles dgv_qMainData._UserDeletingRow
        '  Me.Text += "," & e.Row.Cells("id").Value
    End Sub

    Private Sub dgv_qMainData__ProcessCmdKey(sender As uDgv, ByRef Msg As Message, ByRef keyData As Keys, ByRef Cancel As Boolean) Handles dgv_qMainData._ProcessCmdKey
        If keyData = Keys.Delete Then

            Dim q = sender.dgv.SelectedRows.Cast(Of DataGridViewRow).Where(Function(b) b.Selected = True And b.IsNewRow = False).Select(Function(f) f.Cells("ID").Value).ToArray
            If q.Length = 0 Then
                Cancel = True
            ElseIf MsgBox("Delete " & IIf(q.Length = 1, "Row ?", q.Length & " Rows ?"), MsgBoxStyle.OkCancel + MsgBoxStyle.DefaultButton2) = MsgBoxResult.Ok Then
                Dim sttSql As String = "DELETE From kMainData WHERE [id] In (" & Join(q, ",") & ")"
                If modData_ExecuteNonQuery(sender.dgv, sttSql) > 0 Then
                Else
                    Cancel = True
                End If
            Else
                Cancel = True
            End If

            Me.Text = Join(q)
        End If
    End Sub

    Private Sub dgv_kMivMrv__CellGreenHelperClick(sender As uDgv) Handles dgv_qMivMrv._CellGreenHelperClick
        ' frmSelectRowOfMainData.Visible = Not frmSelectRowOfMainData.Visible
        frmSelectRowOfMainData.ShowDialog()
        frmSelectRowOfMainData.TopMost = True
    End Sub

    Private Sub dgv_kMivMrv__CellXYCoordinate(sender As uDgv, CellRectangleOfScreen As Rectangle) Handles dgv_qMivMrv._CellXYCoordinate

        frmSelectRowOfMainData.Location = CellRectangleOfScreen.Location
    End Sub

    Private Sub dgv_qMivMrv__ProcessCmdKey(sender As uDgv, ByRef Msg As Message, ByRef keyData As Keys, ByRef Cancel As Boolean) Handles dgv_qMivMrv._ProcessCmdKey
        If keyData = Keys.Enter And sender.dgv.CurrentRow.IsNewRow Then
            'frmSelectRowOfMainData.ShowDialog()


        End If
    End Sub

    Private Sub dgv_qMainData__DataError(sender As uDgv, e As DataGridViewDataErrorEventArgs) Handles dgv_qMainData._DataError

    End Sub

    Private Sub dt_BaseGrouping_TableNewRow(sender As Object, e As DataTableNewRowEventArgs) Handles dt_BaseGrouping.TableNewRow

    End Sub

    Private Sub dt_BaseGrouping_RowChanging(sender As Object, e As DataRowChangeEventArgs) Handles dt_BaseGrouping.RowChanging

    End Sub

    Private Sub dt_qMainData_RowChanging(sender As Object, e As DataRowChangeEventArgs) Handles dt_qMainData.RowChanging

    End Sub

    Private Sub dgv_qMainData__CellValidating(sender As uDgv, e As DataGridViewCellValidatingEventArgs) Handles dgv_qMainData._CellValidating
        If sender.dgv.Columns(e.ColumnIndex).Name = "idBaseGrouping" Then
            Dim obRow As Object = dt_BaseGrouping.Rows.Find(Val(e.FormattedValue))
            e.Cancel = obRow Is Nothing
        End If

    End Sub

    Private Sub dgv_BaseGrouping__ErrorUser(sender As uDgv, sttMassege As String) Handles dgv_BaseGrouping._ErrorUser
        lblTssStatus.Text = sttMassege
    End Sub
End Class
