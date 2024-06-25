Imports System.Drawing
Imports System.Reflection
Imports System.Runtime.InteropServices
Imports System.Text
Imports System.Windows.Forms

Public Class uDgv
    Public Event _ErrorUser(sender As uDgv, sttMassege As String)
    Public Event _DataError(sender As uDgv, e As DataGridViewDataErrorEventArgs)
    Public Event _UserDeletingRow(sender As uDgv, e As DataGridViewRowCancelEventArgs)
    Public Event _CellValueChanged(sender As uDgv, e As DataGridViewCellEventArgs)
    Public Event _DefaultValuesNeeded(sender As uDgv, e As DataGridViewRowEventArgs)
    Public Event _TimerCurrentRowIsDouplicate(sender As uDgv, cancel As Boolean)
    Public Event _CellCurrentChange(sender As uDgv, e As EventArgs)
    Public Event _CellXYCoordinate(sender As uDgv, CellRectangleOfScreen As Rectangle)
    Public Event _CellTextChange(sender As uDgv)
    Public Event _CellGreenHelperClick(sender As uDgv)
    Public Event _CellValidating(sender As uDgv, e As DataGridViewCellValidatingEventArgs)
    Public Event _CellValidatingWhenNewOrEdit(sender As uDgv, e As DataGridViewCellValidatingEventArgs)
    Public Event _RowValidating(sender As uDgv, e As DataGridViewCellCancelEventArgs)
    Public Event _RowValidatingWhenNewOrEdit(sender As uDgv, e As DataGridViewCellCancelEventArgs)
    Public Event _CellEndEdit(sender As uDgv, e As DataGridViewCellEventArgs)
    Public Event _CellMouseClick(sender As uDgv, e As DataGridViewCellMouseEventArgs)
    Public Event _ProcessCmdKey(sender As uDgv, ByRef Msg As Message, ByRef keyData As Keys, ByRef Cancel As Boolean)
    '  Public isRowCurrentChange As Boolean
    Structure sBit
        Dim isLoading As Boolean
        Dim isNewRow As Boolean
        Dim isEditRow As Boolean
        Dim ExitTextChange As Boolean
        Dim ExitCellValueChanged As Boolean
        Dim IsRowDuplicate As Boolean
        Dim isCellChange As Boolean
        Dim isCellChangedBefor As Boolean
        Dim isCurrentRowChange As Boolean
        Dim VisibleHelper As Boolean
    End Structure
    Public bit As sBit
    Public RowAnyChange_arrNoCheck As String() = {"ID"}
    Dim dr_ForCancel As DataRow
    Public FrmSelect_SelectItem As String
    Public FrmSelect_CountItems As Integer
    Public FrmSelect_Visible As Boolean
    Public aColumns As String
    Public ErrorMaseege As String
    Public cnSt_ACE_OLEDB_12 As String = "Provider = Microsoft.ACE.OLEDB.12.0;Data Source='FullNameDataBase'; Jet Oledb:Database Password=yourPassword"
    Public TableName As String
    Public KeysLast As Keys
    Public gDataTable As DataTable
    Public DicLanguage As Dictionary(Of String, String)
    Public Property DataTable As DataTable
        Get
            Return dgv.DataSource
        End Get
        Set(value As DataTable)
            ' dgv.DataSource = value
            If value IsNot Nothing Then
                dgv.Font = New Font("Tahoma", 8)
                Dim ss As Object = UserControlExtensions.GetTopLevelForm(Me)
                DicLanguage = ss.DicLanguage
            End If
            SetDataSource(value)


            '  GetParent()
            '  LanguageEnFa = TryCast(Me.ParentForm, Object).MyLanguage
        End Set
    End Property
    Public Property ShowHelper As Boolean
        Get
            Return bit.VisibleHelper
        End Get
        Set(value As Boolean)
            bit.VisibleHelper = value
        End Set
    End Property
    Private Shadows Sub BufferToUp(dgv As Object, setting As Boolean)
        '  BufferToUp(uDgv, True)
        Dim dgvType = dgv.GetType
        Dim proInfo As PropertyInfo = dgvType.GetProperty("DoubleBuffered", BindingFlags.Instance Or BindingFlags.NonPublic)
        proInfo.SetValue(dgv, setting, Nothing)

    End Sub
    Private Sub pRefresh()
        lblTableName.Text = TableName
        lblTableName.Top = Height - lblTableName.Height
        lblTableName.Left = 20
        lblTableName.BackColor = Color.LightBlue

    End Sub
#Region "Move Helper"
    Private Sub OnNeedMoveButton(sender As Object, e As EventArgs) _
    Handles Me.Resize _
    , dgv.Resize _
    , dgv.Scroll _
    , dgv.SelectionChanged _
    , dgv.ColumnWidthChanged _
    , dgv.ColumnHeadersHeightChanged _
    , dgv.RowHeightChanged _
    , dgv.RowHeadersWidthChanged
        pRefresh()
        ts_Helper.Visible = bit.VisibleHelper
        If bit.VisibleHelper = False Then Exit Sub
        ts_Helper.Visible = Not e.ToString Like "*Scrol*"
        TimerFalseTrue(tmrHelperShowAfterScroll, e.ToString Like "*Scrol*")
        If bit.isLoading Then Exit Sub
        TimerFalseTrue(tmrMoveHelper)
    End Sub
    Private Sub tmrMoveHelper_Tick(sender As Object, e As EventArgs) Handles tmrMoveHelper.Tick
        tmrMoveHelper.Enabled = False
        MoveRowSelShowButton()
    End Sub
    Private Sub MoveRowSelShowButton()
        Try

            If dgv.CurrentCell Is Nothing Then
                ts_Helper.Visible = False
                Exit Sub
            End If

            Dim rec As Rectangle = dgv.GetCellDisplayRectangle(dgv.CurrentCell.ColumnIndex, dgv.CurrentCell.RowIndex, True)
            If rec.Width = 0 OrElse rec.Height = 0 Then
                ts_Helper.Visible = False
                Exit Sub
            End If

            ' ts_Helper.Visible = Not isScroll

            Dim pointOnDataGridViewCoodinate = rec.Location
            Dim pointOnScreen = dgv.PointToScreen(pointOnDataGridViewCoodinate)
            'Dim pointOnButtonCoordinate As Point = ts_Helper.PointToClient(pointOnScreen)

            Dim newPoint As Point = pointOnDataGridViewCoodinate
            ' newPoint.Offset(pointOnScreen)
            newPoint.Offset(-ts_Helper.Width, 0)

            ts_Helper.Location = newPoint
            ts_Helper.Height = rec.Height - 3
            ' ContextMenuStrip1.Location = newPoint

            pointOnScreen.Offset(New Point(-ts_Helper.Width, ts_Helper.Height + 2))
            'If (pointOnScreen.Y + frmSelectRow.Height) > My.Computer.Screen.Bounds.Height Then
            '    pointOnScreen.Offset(New Point(0, -frmSelectRow.Height - ts_Helper.Height - 3))
            'End If
            'frmSelectRow.Location = pointOnScreen
            rec.Location = pointOnScreen
            RaiseEvent _CellXYCoordinate(Me, rec)

            ' frmSelectRow.Location = pointOnScreen
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

#End Region
    Public pCurrentCellRectangle As Rectangle
    Public Function CurrentCellRec() As Rectangle
        Dim rec As Rectangle = dgv.GetCellDisplayRectangle(dgv.CurrentCell.ColumnIndex, dgv.CurrentCell.RowIndex, True)
        Dim pointOnScreen = dgv.PointToScreen(rec.Location)
        pointOnScreen.Offset(New Point(-ts_Helper.Width, ts_Helper.Height + 2))
        rec.Location = pointOnScreen
        pCurrentCellRectangle = rec
        Return pCurrentCellRectangle
    End Function
    Public Function LocationFrmSelect(inForm As Form, RectangleCell As Rectangle) As Point
        If (RectangleCell.Y + inForm.Height) > My.Computer.Screen.Bounds.Height Then
            RectangleCell.Offset(New Point(0, -inForm.Height - RectangleCell.Height - 3))
        End If
        Return RectangleCell.Location
    End Function
    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean 'ProcessCmdKey
        Dim cancel As Boolean = False
        Dim f As Integer = msg.LParam.ToInt32
        Dim RepeatedKey As Boolean = (msg.LParam.ToInt32 And (1 << 30)) <> 0
        KeysLast = keyData
        ' If KeysLast.Count >= 10 Then KeysLast.RemoveAt(0)
        RaiseEvent _ProcessCmdKey(Me, msg, keyData, cancel)
        If cancel Then
            Return True
        Else
            ' msg.WParam = keyData
            'Threading.Thread.Sleep(2000)
            Return MyBase.ProcessCmdKey(msg, keyData)
        End If
    End Function
    Public Sub TimerFalseTrue(InTimer As Timer, Optional TrueOrFalse As Boolean = True)
        InTimer.Enabled = False
        InTimer.Enabled = TrueOrFalse
    End Sub
    Public Function Get_DicCountOfDublicateColumn(Column As String, Optional inTable As DataTable = Nothing) As Dictionary(Of String, Integer)
        If inTable Is Nothing Then inTable = dgv.DataSource
        Return inTable.AsEnumerable().
           GroupBy(Function(row) row.Field(Of String)(Column)).
           ToDictionary(Function(group) group.Key, Function(group) group.Count())
    End Function

    Private Sub dgv_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles dgv.EditingControlShowing
        bit.ExitTextChange = False
        bit.isNewRow = dgv.CurrentRow.IsNewRow Or bit.isNewRow
        If bit.isEditRow = False Then
            dr_ForCancel = Nothing
            If dgv.CurrentRow.IsNewRow = False Then
                dr_ForCancel = TryCast(dgv.DataSource, DataTable).NewRow
                For a = 0 To dr_ForCancel.ItemArray.Length - 1
                    dr_ForCancel(TryCast(dgv.DataSource, DataTable).Columns(a).ColumnName) = GetValueFromField(dgv.CurrentRow.Cells(TryCast(dgv.DataSource, DataTable).Columns(a).ColumnName).Value)
                    '  drSetAfterRowValidated.Item(a) = IIf(uDgv.CurrentRow.Cells(a).Value Is Nothing, DBNull.Value, uDgv.CurrentRow.Cells(a).Value)
                Next
            End If

        End If

        bit.isEditRow = bit.isNewRow = False Or bit.isEditRow
        Dim sTypeControl As String = e.Control.GetType.Name
        If sTypeControl = "DataGridViewTextBoxEditingControl" And txtCurrentCell.Tag Is Nothing Then
            txtCurrentCell.Tag = "put"
            txtCurrentCell = CType(e.Control, TextBox)
            txtCurrentCell.PasswordChar = ""
            ' txtCurrentCell.BackColor = Color.Green
        End If
        TimerFalseTrue(tmrRowAnyChange)

        'tmrIsDupicateRow.Enabled = False
        'tmrIsDupicateRow.Enabled = True
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

    Public Sub txtCurrentCell_TextChanged(sender As Object, e As EventArgs) Handles txtCurrentCell.TextChanged
        If bit.ExitTextChange Then Exit Sub
        RowAnyChange()
        If bit.isEditRow Or bit.isNewRow Then
            TimerFalseTrue(tmrIsDupicateRow)

        End If
        RaiseEvent _CellTextChange(Me)

    End Sub
    Private Sub RowAnyChange()
        If dr_ForCancel IsNot Nothing Then
            Dim RowCurrentAnyChange = dr_ForCancel.Table.Columns.Cast(Of DataColumn).Select(Function(d) If(d.ColumnName = dgv.Columns(dgv.CurrentCell.ColumnIndex).Name, dgv.CurrentRow.Cells(d.ColumnName).EditedFormattedValue, dgv.CurrentRow.Cells(d.ColumnName).Value.ToString)).ToArray
            ' isRowCurrentChange = (Not Join(dr_ForCancel.ItemArray.Select(Function(h) h.ToString).ToArray) = Join(RowCurrentAnyChange)) ' And isRowCurrentChange
            bit.isCurrentRowChange = (Not Join(dr_ForCancel.ItemArray.Select(Function(h) h.ToString).ToArray) = Join(RowCurrentAnyChange))
        Else
            '  Stop
        End If
    End Sub

    Private Sub tmrRowAnyChange_Tick(sender As Object, e As EventArgs) Handles tmrRowAnyChange.Tick
        tmrRowAnyChange.Enabled = False
        RowAnyChange()
    End Sub
    Private Sub dgv_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgv.CellEndEdit
        bit.ExitTextChange = True

        RaiseEvent _CellEndEdit(Me, e)
    End Sub

    Private Sub tsbHelper_Click(sender As Object, e As EventArgs) Handles tsbHelper.Click
        RaiseEvent _CellGreenHelperClick(Me)
    End Sub

    Private Sub tmrIsDupicateRow_Tick(sender As Object, e As EventArgs) Handles tmrIsDupicateRow.Tick
        RaiseEvent _TimerCurrentRowIsDouplicate(Me, False)
        TimerFalseTrue(tmrRowAnyChange)
        'Dim curColumn As String = dgv.Columns(dgv.CurrentCell.ColumnIndex).Name
        'Dim sttFilter As String = "[MainGroup] Like '[MainGroup_Rep]' And [SubGroup] Like '[SubGroup_Rep]' And [Dis1] Like '[Dis1_Rep]'"
        'sttFilter = Replace(sttFilter, "[" & curColumn & "_Rep]", IIf(FrmSelect_Visible AndAlso FrmSelect_CountItems > 0, FrmSelect_SelectItem, dgv.CurrentCell.EditedFormattedValue), Count:=1)
        'Dim ColumnsName As String() = {"MainGroup", "SubGroup", "Dis1"}.Except({curColumn}).ToArray
        'For Each cel In ColumnsName
        '    sttFilter = Replace(sttFilter, "[" & cel & "_Rep]", dgv.CurrentRow.Cells(cel).Value, Count:=1)
        'Next

        'Dim drow As DataRow() = TryCast(dgv.DataSource, DataTable).Select(sttFilter)
        'bit.IsRowDuplicate = Not (isRowCurrentChange AndAlso drow.Length = 0)
        tmrIsDupicateRow.Enabled = False

    End Sub

    Private Sub uDgv_Load(sender As Object, e As EventArgs) Handles Me.Load
        ' BufferToUp(dgv, True)

        bit.isLoading = True

    End Sub



    Private Sub dgv_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgv.CellMouseClick
        RaiseEvent _CellMouseClick(Me, e)
    End Sub

    Private Sub dgv_CellValidating(sender As Object, e As DataGridViewCellValidatingEventArgs) Handles dgv.CellValidating
        RaiseEvent _CellValidating(Me, e)
        If bit.isNewRow Or bit.isEditRow Then
            RaiseEvent _CellValidatingWhenNewOrEdit(Me, e)
        End If
    End Sub

    Private Sub dgv_RowValidating(sender As Object, e As DataGridViewCellCancelEventArgs) Handles dgv.RowValidating
        If bit.isLoading Then Exit Sub
        RaiseEvent _RowValidating(Me, e)
        If bit.isNewRow Or bit.isEditRow Then
            RaiseEvent _RowValidatingWhenNewOrEdit(Me, e)
        End If
        bit.isCurrentRowChange = e.Cancel
        bit.isNewRow = e.Cancel And bit.isNewRow
        bit.isEditRow = e.Cancel And bit.isEditRow
    End Sub

    Private Sub dgv_GotFocus(sender As Object, e As EventArgs) Handles dgv.GotFocus
        bit.isLoading = False
        aColumns = GetColumnsName()
    End Sub

    Private Sub dgv_CurrentCellChanged(sender As Object, e As EventArgs) Handles dgv.CurrentCellChanged
        RaiseEvent _CellCurrentChange(Me, e)
    End Sub

    Private Sub tmrHelperShowAfterScroll_Tick(sender As Object, e As EventArgs) Handles tmrHelperShowAfterScroll.Tick
        tmrHelperShowAfterScroll.Enabled = False
        ts_Helper.Visible = True
    End Sub
    Public Function RowNoValidIfCellsNull(ColumnsForCheck As String()) As Boolean
        Dim sttCheck As String
        For Each c In ColumnsForCheck
            sttCheck = dgv.CurrentRow.Cells(c).Value.ToString()
            If sttCheck = "" Then
                Return True
            End If
        Next

    End Function
    Public Function NullCellsInAnyColumns(ColumnsForCheck As String(), Optional ByRef ReturnCellAsNull As String = "") As Boolean
        Dim sttCheck As String
        For Each c In ColumnsForCheck
            sttCheck = dgv.CurrentRow.Cells(Trim(c)).Value.ToString()
            If sttCheck = "" Then
                ReturnCellAsNull = c
                Return True
            End If
        Next

    End Function
    Public Function Sql_Update(inDgv As DataGridView, TableName As String, Optional Where_IsID As Integer = -1, Optional ColumnsFilter As String() = Nothing) As String
        Dim dicTypesName As New Dictionary(Of Type, String)
        dicTypesName.Add(GetType(String), "'")
        dicTypesName.Add(GetType(DateTime), "#")
        dicTypesName.Add(GetType(Int32), Nothing)
        dicTypesName.Add(GetType(Boolean), Nothing)
        Dim q3 As String = Join(inDgv.CurrentRow.Cells.Cast(Of DataGridViewCell).Where(Function(h) ColumnsFilter Is Nothing OrElse Not ColumnsFilter.Contains(inDgv.Columns(h.ColumnIndex).Name)).Select(Function(o) "[" & inDgv.Columns(o.ColumnIndex).Name & "]=" & If(o.Value.ToString = "", "Null", dicTypesName(o.ValueType) & o.Value.ToString & dicTypesName(o.ValueType))).ToArray, ",")
        Dim Sql As String = "Update " & TableName & " Set " & q3 & IIf(Where_IsID > -1, " Where [ID]=" & Where_IsID, "")
        Return Sql
    End Function
    Public Function Sql_Delete(inDgv As DataGridView, TableName As String, Optional Where_IsID As Integer = -1, Optional ColumnsFilter As String() = Nothing) As String
        Dim dicTypesName As New Dictionary(Of Type, String)
        dicTypesName.Add(GetType(String), "'")
        dicTypesName.Add(GetType(DateTime), "#")
        dicTypesName.Add(GetType(Int32), Nothing)
        dicTypesName.Add(GetType(Boolean), Nothing)
        Dim q3 As String = Join(inDgv.CurrentRow.Cells.Cast(Of DataGridViewCell).Where(Function(h) ColumnsFilter Is Nothing OrElse Not ColumnsFilter.Contains(inDgv.Columns(h.ColumnIndex).Name)).Select(Function(o) "[" & inDgv.Columns(o.ColumnIndex).Name & "]=" & If(o.Value.ToString = "", "Null", dicTypesName(o.ValueType) & o.Value.ToString & dicTypesName(o.ValueType))).ToArray, ",")
        Dim Sql As String = "Update " & TableName & " Set " & q3 & IIf(Where_IsID > -1, " Where [ID]=" & Where_IsID, "")
        Return Sql
    End Function
    Public Function Sql_Insert(InRow As DataRow, TableName As String, Optional InColumns As String() = Nothing, Optional ColumnsFilter As String() = Nothing) As String
        ' sql = "INSERT INTO " & TableName & " (" & pColumns & ")  VALUES(" & pValues2 & ")"
        Dim dicTypesName As New Dictionary(Of Type, String)
        dicTypesName.Add(GetType(String), "'")
        dicTypesName.Add(GetType(DateTime), "#")
        dicTypesName.Add(GetType(Int32), Nothing)
        dicTypesName.Add(GetType(Boolean), Nothing)
        '(InColumns Is Nothing OrElse InColumns.Contains(inDgv.Columns(e.ColumnIndex).Name)) OrElse
        Dim qColumns As String = "" ' Join(inDgv.CurrentRow.Cells.Cast(Of DataGridViewCell).Where(Function(e) (ColumnsFilter Is Nothing OrElse Not ColumnsFilter.Contains(inDgv.Columns(e.ColumnIndex).Name))).Select(Function(o) dgv.Columns(o.ColumnIndex).Name).ToArray, ",") '& "|" & dicTypesName(o.ValueType) & o.Value.ToString & dicTypesName(o.ValueType)
        Dim pValues As String = "" ' Join(inDgv.CurrentRow.Cells.Cast(Of DataGridViewCell).Where(Function(e) ColumnsFilter Is Nothing OrElse Not ColumnsFilter.Contains(inDgv.Columns(e.ColumnIndex).Name)).Select(Function(o) If(o.Value.ToString = "", "Null", dicTypesName(o.ValueType) & o.Value.ToString & dicTypesName(o.ValueType))).ToArray, ",")
        If InColumns Is Nothing Then
            '  qColumns = Join(inDgv.CurrentRow.Cells.Cast(Of DataGridViewCell).Where(Function(e) (ColumnsFilter Is Nothing OrElse Not ColumnsFilter.Contains(inDgv.Columns(e.ColumnIndex).Name))).Select(Function(o) dgv.Columns(o.ColumnIndex).Name).ToArray, ",") '& "|" & dicTypesName(o.ValueType) & o.Value.ToString & dicTypesName(o.ValueType)
            ' pValues = Join(inDgv.CurrentRow.Cells.Cast(Of DataGridViewCell).Where(Function(e) ColumnsFilter Is Nothing OrElse Not ColumnsFilter.Contains(inDgv.Columns(e.ColumnIndex).Name)).Select(Function(o) If(o.Value.ToString = "", "Null", dicTypesName(o.ValueType) & o.Value.ToString & dicTypesName(o.ValueType))).ToArray, ",")
            ' qColumns = Join(inDgv.CurrentRow.Cells.Cast(Of DataGridViewCell).Where(Function(e) (ColumnsFilter Is Nothing OrElse Not ColumnsFilter.Contains(inDgv.Columns(e.ColumnIndex).Name))).Select(Function(o) dgv.Columns(o.ColumnIndex).Name).ToArray, ",") '& "|" & dicTypesName(o.ValueType) & o.Value.ToString & dicTypesName(o.ValueType)
            qColumns = Join(InRow.Table.Columns.Cast(Of DataColumn).Where(Function(e) (ColumnsFilter Is Nothing OrElse Not ColumnsFilter.Contains(e.ColumnName))).Select(Function(o) o.ColumnName).ToArray, ",")
            pValues = Join(InRow.Table.Columns.Cast(Of DataColumn).Where(Function(e) ColumnsFilter Is Nothing OrElse Not ColumnsFilter.Contains(e.ColumnName)).Select(Function(o) If(InRow.Item(o.ColumnName).ToString = "", "Null", dicTypesName(o.DataType) & InRow.Item(o.ColumnName) & dicTypesName(o.DataType))).ToArray, ",")

        Else
            '  qColumns = Join(InColumns, ",")
            ' pValues = Join(InColumns.Select(Function(o) If(inDgv.CurrentRow.Cells(o).Value.ToString = "", "Null", dicTypesName(inDgv.CurrentRow.Cells(o).ValueType) & inDgv.CurrentRow.Cells(o).Value.ToString & dicTypesName(inDgv.CurrentRow.Cells(o).ValueType))).ToArray, ",")
        End If
        ' Dim pValues = inDgv.CurrentRow.Cells.Cast(Of DataGridViewCell).Where(Function(e) e.Value.ToString <> "").Select(Function(o) dgv.Columns(o.ColumnIndex).Name & "|" & o.Value.ToString).ToArray
        ' Dim q3 As String = Join(inDgv.CurrentRow.Cells.Cast(Of DataGridViewCell).Where(Function(h) ColumnsFilter Is Nothing OrElse Not ColumnsFilter.Contains(inDgv.Columns(h.ColumnIndex).Name)).Select(Function(h) "[" & inDgv.Columns(h.ColumnIndex).Name & "]=" & dicTypesName(h.ValueType) & h.Value & dicTypesName(h.ValueType)).ToArray, ",")
        Dim Sql As String = "INSERT INTO " & TableName & " (" & qColumns & ")  VALUES(" & pValues & ")"
        Return Sql
    End Function
    Public Function GetColumnsName() As String
        If DicLanguage IsNot Nothing AndAlso DicLanguage.Count > 0 Then
            For Each col As DataGridViewColumn In dgv.Columns
                col.HeaderText = DicLanguage(UCase(col.Name))
            Next
        End If

        aColumns = Join(dgv.Columns.Cast(Of DataGridViewColumn).Select(Function(h) h.Name).ToArray, ",")
        Return Join(dgv.Columns.Cast(Of DataGridViewColumn).Select(Function(h) h.Name).ToArray, ",")
    End Function

    Private Sub dgv_DefaultValuesNeeded(sender As Object, e As DataGridViewRowEventArgs) Handles dgv.DefaultValuesNeeded
        RaiseEvent _DefaultValuesNeeded(Me, e)
    End Sub

    Private Sub dgv_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles dgv.CellValueChanged
        If bit.ExitCellValueChanged Then Exit Sub
        RaiseEvent _CellValueChanged(Me, e)
    End Sub

    Private Sub dgv_UserDeletingRow(sender As Object, e As DataGridViewRowCancelEventArgs) Handles dgv.UserDeletingRow
        RaiseEvent _UserDeletingRow(Me, e)
    End Sub

    Private Sub dgv_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgv.DataError
        RaiseEvent _DataError(Me, e)
        MsgBox(e.Exception.Message)
    End Sub

    Private Sub tmrErrorReprt_Tick(sender As Object, e As EventArgs) Handles tmrErrorReprt.Tick
        RaiseEvent _ErrorUser(Me, ErrorMaseege)
    End Sub
    Public Sub SetDataSource(dtTable As DataTable)
        If dtTable IsNot Nothing Then
            dgv.DataSource = dtTable
            GetColumnsName()
            TableName = Split(Name, "_")(1)
            pRefresh()
        End If

    End Sub
    Public Function Schema_GetTables(Conn_String_Access As String, Optional stFilter As String = "[DESCRIPTION] = 'TimeSheet'") As String()
        'Dim dtForeign As New DataTable
        'Dim dtView As New DataTable
        'dt = cn.GetSchema("columns") 'indexes'columns'Tables'foreignKeys'DataTypes,OleDbSchemaGuid.Foreign_Keys
        Dim cn As New OleDb.OleDbConnection(Conn_String_Access)
        cn.Open()
        Dim dtSheama As New DataTable
        dtSheama = cn.GetSchema("Tables") 'indexes'columns'Tables
        ' dtSheama = cn.GetSchema("columns") 'indexes'columns'Tables'Procedures'Views
        Dim drTables() As DataRow = dtSheama.Select(stFilter)
        Dim q As String() = drTables.Cast(Of DataRow).Select(Function(g) g.Item("TABLE_NAME").ToString).ToArray
        Return q
    End Function
    Public Function Schema_GetColumns(Conn_String_Access As String, Optional stFilter As String = "[DESCRIPTION] = 'TimeSheet'") As String()
        'Dim dtForeign As New DataTable
        'Dim dtView As New DataTable
        'dt = cn.GetSchema("columns") 'indexes'columns'Tables'foreignKeys'DataTypes,OleDbSchemaGuid.Foreign_Keys
        Dim cn As New OleDb.OleDbConnection(Conn_String_Access)
        cn.Open()
        Dim dtSheama As New DataTable
        dtSheama = cn.GetSchema("Tables") 'indexes'columns'Tables
        Dim drTables() As DataRow = dtSheama.Select(stFilter)
        Dim q As String() = drTables.Cast(Of DataRow).Select(Function(g) g.Item("TABLE_NAME").ToString).ToArray
        ' dtSheama = cn.GetSchema("Views")
        dtSheama = cn.GetSchema("columns") 'indexes'columns'Tables'Procedures'Views
        Dim q2 As String() = dtSheama.AsEnumerable.Cast(Of DataRow).Where(Function(a) q.Contains(a.Item("TABLE_NAME"))).Select(Function(f) f.Item("COLUMN_NAME").ToString).Distinct().ToArray()

        Return q2
    End Function


    Private Sub tmrValidateDelay_Tick(sender As Object, e As EventArgs) Handles tmrValidateDelay.Tick

        tmrValidateDelay.Enabled = False

    End Sub

    Private Sub dgv_ColumnDisplayIndexChanged(sender As Object, e As DataGridViewColumnEventArgs) Handles dgv.ColumnDisplayIndexChanged
        If dgv.CurrentCell IsNot Nothing Then
            Dim result As New List(Of Tuple(Of String, Integer))()
            For Each col As DataGridViewColumn In dgv.Columns
                result.Add(Tuple.Create(col.Name, col.Index))
            Next
            Dim displayIndices = From col As DataGridViewColumn In dgv.Columns
                                 Select col.Name, col.DisplayIndex
            displayIndices = displayIndices.ToArray
        End If

        ' Stop
    End Sub
End Class


'_______________________________________________________________Data Base
Public Class DataBase
    Sub New(Optional Connection_String As String = "", Optional DB_PathFile As String = "")
        Dim cnSt_ACE_OLEDB_12 As String = "Provider = Microsoft.ACE.OLEDB.12.0;Data Source='FullNameDataBase'; Jet Oledb:Database Password=yourPassword"
        Me.DB_CnSt = IIf(Connection_String = "", Replace(cnSt_ACE_OLEDB_12, "FullNameDataBase", DB_PathFile), Connection_String)
        Me.DB_PathFile = DB_PathFile
    End Sub
    Public DB_CnSt As String
    Public DB_PathFile As String

    Public TablesWithColumns As Object
    Public TableColumns As String
    Public Function Get_SpcialColumns(TableName As String, columnsNane As String(), Optional Seprator As String = " ") As String()
        Dim SelectCommand As String = "Select  *," & Join(columnsNane, " & '" & Seprator & "' & ") & " As NewColumn,* From " & TableName
        'Dim sttPathDbFile As String = IO.Path.GetDirectoryName(Application.ExecutablePath) & "\PS DataBase.accdb"
        DB_CnSt = Replace(DB_CnSt, "FullNameDataBase", DB_PathFile)
        Dim cn As New OleDb.OleDbConnection(DB_CnSt)
        Dim ds As New DataSet
        Dim dr As DataRow
        Dim oleAdp As OleDb.OleDbDataAdapter = New OleDb.OleDbDataAdapter(SelectCommand, cn)
        ' MsgBox(SelectCommand)
        'Dim gOleAdp As OleDb.OleDbDataAdapter = New OleDb.OleDbDataAdapter("", cn)
        ds.Tables.Clear()

        oleAdp.Fill(ds, SelectCommand)

        Return ds.Tables(0).AsEnumerable.Select(Function(f) f.Item(0).ToString).ToArray
    End Function
    Public Function SQL_SelectAny(TableName As String) As DataTable
        Dim SelectCommand As String = "Select * From " & TableName
        'Dim sttPathDbFile As String = IO.Path.GetDirectoryName(Application.ExecutablePath) & "\PS DataBase.accdb"
        DB_CnSt = Replace(DB_CnSt, "FullNameDataBase", DB_PathFile)
        Dim cn As New OleDb.OleDbConnection(DB_CnSt)
        Dim ds As New DataSet
        Dim dr As DataRow
        Dim oleAdp As OleDb.OleDbDataAdapter = New OleDb.OleDbDataAdapter(SelectCommand, cn)
        ' MsgBox(SelectCommand)
        'Dim gOleAdp As OleDb.OleDbDataAdapter = New OleDb.OleDbDataAdapter("", cn)
        ds.Tables.Clear()

        oleAdp.Fill(ds, SelectCommand)
        Return ds.Tables(0)
        'gOleAdp.SelectCommand.Connection = cn
        'gOleAdp.SelectCommand.CommandText = SelectCommand
        'gOleAdp.Fill(ds, gOleAdp.SelectCommand.CommandText)
    End Function
    Public Function RelationTables(name As String, ParentColumn As DataColumn, ChildColumn As DataColumn) As DataRelation
        Dim Rel As New DataRelation(name, ParentColumn, ChildColumn, createConstraints:=True)
        Return Rel
    End Function
    Public Function SQL_Insert(InRow As DataRow, TableName As String, Optional InColumns As String() = Nothing, Optional ColumnsFilter As String() = Nothing) As String
        ' sql = "INSERT INTO " & TableName & " (" & pColumns & ")  VALUES(" & pValues2 & ")"
        Dim dicTypesName As New Dictionary(Of Type, String)
        dicTypesName.Add(GetType(String), "'")
        dicTypesName.Add(GetType(DateTime), "#")
        dicTypesName.Add(GetType(Int32), Nothing)
        dicTypesName.Add(GetType(Boolean), Nothing)
        '(InColumns Is Nothing OrElse InColumns.Contains(inDgv.Columns(e.ColumnIndex).Name)) OrElse
        Dim qColumns As String = "" ' Join(inDgv.CurrentRow.Cells.Cast(Of DataGridViewCell).Where(Function(e) (ColumnsFilter Is Nothing OrElse Not ColumnsFilter.Contains(inDgv.Columns(e.ColumnIndex).Name))).Select(Function(o) dgv.Columns(o.ColumnIndex).Name).ToArray, ",") '& "|" & dicTypesName(o.ValueType) & o.Value.ToString & dicTypesName(o.ValueType)
        Dim pValues As String = "" ' Join(inDgv.CurrentRow.Cells.Cast(Of DataGridViewCell).Where(Function(e) ColumnsFilter Is Nothing OrElse Not ColumnsFilter.Contains(inDgv.Columns(e.ColumnIndex).Name)).Select(Function(o) If(o.Value.ToString = "", "Null", dicTypesName(o.ValueType) & o.Value.ToString & dicTypesName(o.ValueType))).ToArray, ",")
        If InColumns Is Nothing Then
            '  qColumns = Join(inDgv.CurrentRow.Cells.Cast(Of DataGridViewCell).Where(Function(e) (ColumnsFilter Is Nothing OrElse Not ColumnsFilter.Contains(inDgv.Columns(e.ColumnIndex).Name))).Select(Function(o) dgv.Columns(o.ColumnIndex).Name).ToArray, ",") '& "|" & dicTypesName(o.ValueType) & o.Value.ToString & dicTypesName(o.ValueType)
            ' pValues = Join(inDgv.CurrentRow.Cells.Cast(Of DataGridViewCell).Where(Function(e) ColumnsFilter Is Nothing OrElse Not ColumnsFilter.Contains(inDgv.Columns(e.ColumnIndex).Name)).Select(Function(o) If(o.Value.ToString = "", "Null", dicTypesName(o.ValueType) & o.Value.ToString & dicTypesName(o.ValueType))).ToArray, ",")
            ' qColumns = Join(inDgv.CurrentRow.Cells.Cast(Of DataGridViewCell).Where(Function(e) (ColumnsFilter Is Nothing OrElse Not ColumnsFilter.Contains(inDgv.Columns(e.ColumnIndex).Name))).Select(Function(o) dgv.Columns(o.ColumnIndex).Name).ToArray, ",") '& "|" & dicTypesName(o.ValueType) & o.Value.ToString & dicTypesName(o.ValueType)
            qColumns = Join(InRow.Table.Columns.Cast(Of DataColumn).Where(Function(e) (ColumnsFilter Is Nothing OrElse Not ColumnsFilter.Contains(e.ColumnName))).Select(Function(o) o.ColumnName).ToArray, ",")
            pValues = Join(InRow.Table.Columns.Cast(Of DataColumn).Where(Function(e) ColumnsFilter Is Nothing OrElse Not ColumnsFilter.Contains(e.ColumnName)).Select(Function(o) If(InRow.Item(o.ColumnName).ToString = "", "Null", dicTypesName(o.DataType) & InRow.Item(o.ColumnName) & dicTypesName(o.DataType))).ToArray, ",")

        Else
            Stop
            qColumns = Join(InColumns, ",")
            pValues = Join(InColumns.Select(Function(o) If(InRow.Item(o).ToString = "", "Null", dicTypesName(InRow.Table.Columns(o).DataType) & InRow.Item(o).ToString & dicTypesName(InRow.Table.Columns(o).DataType))).ToArray, ",")
        End If
        ' Dim pValues = inDgv.CurrentRow.Cells.Cast(Of DataGridViewCell).Where(Function(e) e.Value.ToString <> "").Select(Function(o) dgv.Columns(o.ColumnIndex).Name & "|" & o.Value.ToString).ToArray
        ' Dim q3 As String = Join(inDgv.CurrentRow.Cells.Cast(Of DataGridViewCell).Where(Function(h) ColumnsFilter Is Nothing OrElse Not ColumnsFilter.Contains(inDgv.Columns(h.ColumnIndex).Name)).Select(Function(h) "[" & inDgv.Columns(h.ColumnIndex).Name & "]=" & dicTypesName(h.ValueType) & h.Value & dicTypesName(h.ValueType)).ToArray, ",")
        Dim Sql As String = "INSERT INTO " & TableName & " (" & qColumns & ")  VALUES(" & pValues & ")"
        Return Sql
    End Function
    Public Function Get_Tables_DataSet(TableNames As String()) As DataSet
        Dim ds As New DataSet
        DB_CnSt = Replace(DB_CnSt, "FullNameDataBase", DB_PathFile)
        Dim cn As New OleDb.OleDbConnection(DB_CnSt)
        For Each Table In TableNames
            Dim SelectCommand As String = "Select * From " & Table
            Dim oleAdp As OleDb.OleDbDataAdapter = New OleDb.OleDbDataAdapter(SelectCommand, cn)
            oleAdp.Fill(ds, Table)
        Next
        TablesWithColumns = Get_TablesWithColumns(ds)
        Return ds
    End Function
    Public Function Get_TablesWithColumns(InDataSet As DataSet) As Object
        Dim result = From table In InDataSet.Tables.Cast(Of DataTable)()
                     Select {table.TableName, table.Columns.Cast(Of DataColumn).Select(Function(column) column.ColumnName).ToArray()}

        result = result.ToArray
        ' TableColumns = String.Join("|", result.Select(Function(table) $"{table(0)}({String.Join(",", table(1))})"))
        TableColumns = "'" & String.Join(vbNewLine & "'", From table In result
                                                          Let tableName = table(0)
                                                          Let columnNames = String.Join(" ", DirectCast(table(1), String()))
                                                          Select $"{tableName}( {columnNames} )")
        Return result.ToArray
    End Function
    Public Function SQL_ExecuteNonQuery(inDgv As DataGridView, InSql As String) As Integer
        Dim icount As Integer = -1
        DB_CnSt = Replace(DB_CnSt, "FullNameDataBase", DB_PathFile)
        Dim cn As New OleDb.OleDbConnection(DB_CnSt)
        Try
            Dim TableName As String = Split(inDgv.Parent.Name, "_")(1)


            cn.Open()
            Dim oleComand As New OleDb.OleDbCommand(InSql, cn)
            icount = oleComand.ExecuteNonQuery()
            cn.Close()
            Return icount
        Catch ex As Exception
            MsgBox(ex.Message)
            cn.Close()
            Return icount
        End Try

        'Dim dt As New DataTable
        'dt = TryCast(inDgv.DataSource, DataTable).Copy
        'dt.ImportRow(dt.Rows(1))
        '' Dim com As OleDb.OleDbCommandBuilder
        'Dim sqlInsert As String = ""
        'sqlInsert = "INSERT INTO " & TableName & " ([" & Join(InColumns, "],[") & " ]) "
        'Dim SqlValues As String = ""
        'oleComand.CommandText = sqlInsert
        'oleComand.Parameters.Clear()
        'Dim rowsAffected As Integer = -1
        'Using con As New OleDb.OleDbConnection(Conn_String_Accsess)
        '    Using cmd As New OleDb.OleDbCommand("UPDATE " & TableName & " Set  [MainGroup]=@MainGroup , [SubGroup]=@SubGroup , [Dis1]=@Dis1 WHERE [id]=@id", con)
        '        '"UPDATE BaseGrouping SET BaseGrouping.MainGroup = "jkjkj" WHERE (((BaseGrouping.ID)=4));"
        '        cmd.Parameters.Clear()
        '        cmd.Parameters.Add("@id", OleDb.OleDbType.Integer).Value = inDgv.CurrentRow.Cells("id").Value
        '        cmd.Parameters.Add("@MainGroup", OleDb.OleDbType.VarChar).Value = inDgv.CurrentRow.Cells("MainGroup").Value
        '        cmd.Parameters.Add("@SubGroup", OleDb.OleDbType.VarChar).Value = inDgv.CurrentRow.Cells("SubGroup").Value
        '        cmd.Parameters.Add("@Dis1", OleDb.OleDbType.VarChar).Value = inDgv.CurrentRow.Cells("Dis1").Value
        '        ' cmd.Parameters.Clear()


        '        con.Close()
        '        con.Open()
        '        cmd.CommandText = "UPDATE BaseGrouping SET BaseGrouping.MainGroup = " & Microsoft.VisualBasic.Chr(34) & "jkjkj" & Microsoft.VisualBasic.Chr(34) & " WHERE (((BaseGrouping.ID)=4));"
        '        rowsAffected = cmd.ExecuteNonQuery
        '        con.Close()
        '    End Using
        'End Using

    End Function
    Public Function Schema_GetTables(Optional in_CnSt As String = "", Optional stFilter As String = "[DESCRIPTION] = ''") As String()
        in_CnSt = IIf(in_CnSt = "", DB_CnSt, in_CnSt)
        'Dim dtForeign As New DataTable
        'Dim dtView As New DataTable
        'dt = cn.GetSchema("columns") 'indexes'columns'Tables'foreignKeys'DataTypes,OleDbSchemaGuid.Foreign_Keys
        Dim cn As New OleDb.OleDbConnection(in_CnSt)
        cn.Open()
        Dim dtSheama As New DataTable
        dtSheama = cn.GetSchema("Tables") 'indexes'columns'Tables
        ' dtSheama = cn.GetSchema("columns") 'indexes'columns'Tables'Procedures'Views
        Dim drTables() As DataRow = dtSheama.Select(stFilter)
        Dim q As String() = drTables.Cast(Of DataRow).Select(Function(g) g.Item("TABLE_NAME").ToString).ToArray
        Return q
    End Function
    Public Function Schema_GetColumns(Optional in_CnSt As String = "", Optional stFilter As String = "[DESCRIPTION] = 'TimeSheet'") As String()
        in_CnSt = IIf(in_CnSt = "", DB_CnSt, in_CnSt)
        'Dim dtForeign As New DataTable
        'Dim dtView As New DataTable
        'dt = cn.GetSchema("columns") 'indexes'columns'Tables'foreignKeys'DataTypes,OleDbSchemaGuid.Foreign_Keys
        Dim cn As New OleDb.OleDbConnection(in_CnSt)
        cn.Open()
        Dim dtSheama As New DataTable
        dtSheama = cn.GetSchema("Tables") 'indexes'columns'Tables
        Dim drTables() As DataRow = dtSheama.Select(stFilter)
        Dim q As String() = drTables.Cast(Of DataRow).Select(Function(g) g.Item("TABLE_NAME").ToString).ToArray
        ' dtSheama = cn.GetSchema("Views")
        dtSheama = cn.GetSchema("columns") 'indexes'columns'Tables'Procedures'Views
        Dim q2 As String() = dtSheama.AsEnumerable.Cast(Of DataRow).Where(Function(a) q.Contains(a.Item("TABLE_NAME"))).Select(Function(f) f.Item("COLUMN_NAME").ToString).Distinct().ToArray()

        Return q2
    End Function
End Class
Public Class DateConvert
    Public idxBeginSelectFromParent As Integer
    Private Function Ceil(Number As Single) As Long
        Ceil = -Math.Sign(Number) * Int(-Math.Abs(Number))
    End Function

    '
    ' Determine Julian day from Persian date
    '
    Function persian_jdn(iYear, iMonth, iDay)
        Const PERSIAN_EPOCH = 1948321 ' The JDN of 1 Farvardin 1
        Dim epbase As Long
        Dim epyear As Long
        Dim mdays As Long
        If iYear >= 0 Then
            epbase = iYear - 474
        Else
            epbase = iYear - 473
        End If
        epyear = 474 + (epbase Mod 2820)
        If iMonth <= 7 Then
            mdays = (CLng(iMonth) - 1) * 31
        Else
            mdays = (CLng(iMonth) - 1) * 30 + 6
        End If
        persian_jdn = CLng(iDay) _
                    + mdays _
                    + Fix(((epyear * 682) - 110) / 2816) _
                    + (epyear - 1) * 365 _
                    + Fix(epbase / 2820) * 1029983 _
                    + (PERSIAN_EPOCH - 1)
    End Function
    '
    Sub jdn_persian(jdn, ByRef iYear, ByRef iMonth, ByRef iDay)
        Dim depoch
        Dim cycle
        Dim cyear
        Dim ycycle
        Dim aux1, aux2
        Dim yday
        depoch = jdn - persian_jdn(475, 1, 1)
        cycle = Fix(depoch / 1029983)
        cyear = depoch Mod 1029983
        If cyear = 1029982 Then
            ycycle = 2820
        Else
            aux1 = Fix(cyear / 366)
            aux2 = cyear Mod 366
            ycycle = Int(((2134 * aux1) + (2816 * aux2) + 2815) / 1028522) + aux1 + 1
        End If
        iYear = ycycle + (2820 * cycle) + 474
        If iYear <= 0 Then
            iYear = iYear - 1
        End If
        yday = (jdn - persian_jdn(iYear, 1, 1)) + 1
        If yday <= 186 Then
            iMonth = Ceil(yday / 31)
        Else
            iMonth = Ceil((yday - 6) / 30)
        End If
        iDay = (jdn - persian_jdn(iYear, iMonth, 1)) + 1
    End Sub
    Function civil_jdn(ByVal iYear, ByVal iMonth, ByVal iDay)
        Dim lYear
        Dim lMonth
        Dim lDay
        'Dim calendatType
        ' calendarType = Gregorian
        'If calendarType = Gregorian And ((iYear > 1582) _
        If ((iYear > 1582) _
    Or ((iYear = 1582) And (iMonth > 10)) _
    Or ((iYear = 1582) And (iMonth = 10) And (iDay > 14))) Then

            lYear = CLng(iYear)
            lMonth = CLng(iMonth)
            lDay = CLng(iDay)
            civil_jdn = ((1461 * (lYear + 4800 + ((lMonth - 14) \ 12))) \ 4) _
                        + ((367 * (lMonth - 2 - 12 * (((lMonth - 14) \ 12)))) \ 12) _
                        - ((3 * (((lYear + 4900 + ((lMonth - 14) \ 12)) \ 100))) \ 4) _
                        + lDay - 32075
        Else
            civil_jdn = julian_jdn(iYear, iMonth, iDay)
        End If

    End Function
    Sub jdn_julian(jdn, ByRef iYear, ByRef iMonth, ByRef iDay)
        Dim L As Long
        Dim K As Long
        Dim n As Long
        Dim I As Long
        Dim j As Long

        j = jdn + 1402
        K = ((j - 1) \ 1461)
        L = j - 1461 * K
        n = ((L - 1) \ 365) - (L \ 1461)
        I = L - 365 * n + 30
        j = ((80 * I) \ 2447)
        iDay = I - ((2447 * j) \ 80)
        I = (j \ 11)
        iMonth = j + 2 - 12 * I
        iYear = 4 * K + n + I - 4716

    End Sub
    Function julian_jdn(ByVal iYear, iMonth, iDay) As Long

        julian_jdn = 367 * iYear -
                    ((7 * (iYear + 5001 + ((iMonth - 9) \ 7))) \ 4) _
                    + ((275 * iMonth) \ 9) + iDay + 1729777

    End Function
    Sub jdn_civil(jdn, ByRef iYear, ByRef iMonth, ByRef iDay)

        Dim L
        Dim K
        Dim n
        Dim I
        Dim j

        If (jdn > 2299160) Then
            L = jdn + 68569
            n = ((4 * L) \ 146097)
            L = L - ((146097 * n + 3) \ 4)
            I = ((4000 * (L + 1)) \ 1461001)
            L = L - ((1461 * I) \ 4) + 31
            j = ((80 * L) \ 2447)
            iDay = L - ((2447 * j) \ 80)
            L = (j \ 11)
            iMonth = j + 2 - 12 * L
            iYear = 100 * (n - 49) + I + L
        Else
            Call jdn_julian(jdn, iYear, iMonth, iDay)
        End If

    End Sub


    'Function m2s(myDate)
    '    iDay = Day(myDate)
    '    iMonth = Month(myDate)
    '    iYear = Year(myDate)
    '    jdn = civil_jdn(iYear, iMonth, iDay)
    '    Call jdn_persian(jdn, iYear, iMonth, iDay)
    '    m2s = iYear & "/" & iMonth & "/" & iDay
    'End Function

    Function s2m(myDate)
        Dim iYear, iMonth, iDay
        Dim st As Object
        Dim S As Object
        Dim x As Object
        For I = 1 To Len(myDate)

            st = Mid(myDate, I, 1)

            If (st = "/" Or st = "-" Or st = "." Or st = "\") And x <> 1 Then
                x = 1
                If I = 3 Then S = "13" & S
            Else
                If (st = "/" Or st = "-" Or st = "." Or st = "\") And x = 1 Then
                    x = 2
                    If I = 5 Or I = 7 Then S = Left(S, Len(S) - 1) & "0" & Right(S, 1)
                Else
                    S = S & st
                End If
            End If
        Next
        If Len(S) = 7 Then S = Left(S, 6) & "0" & Right(S, 1)
        myDate = S
        iYear = Mid(myDate, 1, 4)
        iMonth = Mid(myDate, 5, 2)
        iDay = Mid(myDate, 7, 2)
        If (iDay > 30 And iMonth > 6) Or iDay > 31 Or iMonth > 12 Then s2m = "Error" : Exit Function
        Dim iYear1
        Dim iMonth1
        Dim jdn1
        Dim iDay1
        Dim jdn
        If (iDay = 30 And iMonth = 12) Then
            iYear1 = iYear + 1
            iMonth1 = 1
            iDay1 = 1
            jdn1 = persian_jdn(iYear1, iMonth1, iDay1)
            jdn = persian_jdn(iYear, iMonth, iDay)
            If jdn1 = jdn Then s2m = "Error" : Exit Function
        End If

        jdn = persian_jdn(iYear, iMonth, iDay)
        Call jdn_civil(jdn, iYear, iMonth, iDay)
        s2m = iYear & "/" & iMonth & "/" & iDay
    End Function

    Function m2s(myDate, Optional Format0to7 = 0)
        Dim iDay
        Dim iMonth
        Dim iYear
        Dim iWeekday
        Dim Rooz
        Dim jdn
        Dim mah
        iDay = Microsoft.VisualBasic.Day(myDate)
        iMonth = Month(myDate)
        iYear = Year(myDate)
        iWeekday = Weekday(myDate)

        jdn = civil_jdn(iYear, iMonth, iDay)
        Call jdn_persian(jdn, iYear, iMonth, iDay)

        Select Case iWeekday
            Case 1
                Rooz = ChrW(1740) & ChrW(1705) & ChrW(1588) & ChrW(1606) & ChrW(1576) & ChrW(1607)
            Case 2
                Rooz = ChrW(1583) & ChrW(1608) & ChrW(1588) & ChrW(1606) & ChrW(1576) & ChrW(1607)
            Case 3
                Rooz = ChrW(1587) & ChrW(1607) & ChrW(8204) & ChrW(1588) & ChrW(1606) & ChrW(1576) & ChrW(1607)
            Case 4
                Rooz = ChrW(1670) & ChrW(1607) & ChrW(1575) & ChrW(1585) & ChrW(1588) & ChrW(1606) & ChrW(1576) & ChrW(1607)
            Case 5
                Rooz = ChrW(1662) & ChrW(1606) & ChrW(1580) & ChrW(8204) & ChrW(1588) & ChrW(1606) & ChrW(1576) & ChrW(1607)
            Case 6
                Rooz = ChrW(1580) & ChrW(1605) & ChrW(1593) & ChrW(1607)
            Case 7
                Rooz = ChrW(1588) & ChrW(1606) & ChrW(1576) & ChrW(1607)
        End Select


        Select Case iMonth

            Case 1
                mah = ChrW(1601) & ChrW(1585) & ChrW(1608) & ChrW(1585) & ChrW(1583) & ChrW(1740) & ChrW(1606)
            Case 2
                mah = ChrW(1575) & ChrW(1585) & ChrW(1583) & ChrW(1740) & ChrW(1576) & ChrW(1607) & ChrW(1588) & ChrW(1578)
            Case 3
                mah = ChrW(1582) & ChrW(1585) & ChrW(1583) & ChrW(1575) & ChrW(1583)
            Case 4
                mah = ChrW(1578) & ChrW(1740) & ChrW(1585)
            Case 5
                mah = ChrW(1605) & ChrW(1585) & ChrW(1583) & ChrW(1575) & ChrW(1583)
            Case 6
                mah = ChrW(1588) & ChrW(1607) & ChrW(1585) & ChrW(1740) & ChrW(1608) & ChrW(1585)
            Case 7
                mah = ChrW(1605) & ChrW(1607) & ChrW(1585)
            Case 8
                mah = ChrW(1570) & ChrW(1576) & ChrW(1575) & ChrW(1606)
            Case 9
                mah = ChrW(1570) & ChrW(1584) & ChrW(1585)
            Case 10
                mah = ChrW(1583) & ChrW(1740)
            Case 11
                mah = ChrW(1576) & ChrW(1607) & ChrW(1605) & ChrW(1606)
            Case 12
                mah = ChrW(1575) & ChrW(1587) & ChrW(1601) & ChrW(1606) & ChrW(1583)

        End Select
        Dim sal As String
        Dim sMah As String
        Dim sRoz As String

        sal = Mid(Val(iYear).ToString, 3)
        sMah = IIf(Val(iMonth) < 10, "0" + Val(iMonth).ToString, Val(iMonth).ToString)
        sRoz = IIf(Val(iDay) < 10, "0" + Val(iDay).ToString, Val(iDay).ToString)
        Select Case Format0to7
            Case 0 'Sal/Mah/Roz

                m2s = Mid(Val(iYear).ToString, 2) & "/" & sMah & "/" & sRoz
            Case 1 'Rooz,Sal/Mah/Roz
                m2s = Rooz & "," & sal & "/" & sMah & "/" & sRoz
            Case 2
                m2s = iYear & "/" & iMonth & "/" & iDay ' & " " & horofi(iDay) & " " & mah & " " & ChrW(1605) & ChrW(1575) & ChrW(1607) & " " & horofi(iYear)
            Case 3
                m2s = Rooz & "," & iYear & "/" & iMonth & "/" & iDay
            Case 4
                m2s = sal & "/" & iMonth & "/" & iDay
            Case 5
                m2s = iYear
            Case 6
                m2s = iMonth
            Case 7
                m2s = iDay
            Case Else
                m2s = "" '"Only one of this number as format(0,1,2,3,4,5) for help visit http://sakhteman.wordpress.com"
        End Select

    End Function
End Class
Public Class mFunction
    <DllImport("user32.dll", CharSet:=CharSet.Auto)>
    Private Shared Function SystemParametersInfo(ByVal uAction As Integer, ByVal uParam As Integer, ByVal lpvParam As StringBuilder, ByVal fuWinIni As Integer) As Boolean
    End Function
    Public Function GetDesktopImage() As Bitmap
        Dim wallpaperPath As New StringBuilder(260)
        SystemParametersInfo(&H73, wallpaperPath.Capacity, wallpaperPath, 0)
        Dim wallpaperImage As New Bitmap(wallpaperPath.ToString())
        Return wallpaperImage
    End Function
#Region "SetDesktopBackground"
    Private Declare Auto Function SystemParametersInfo Lib "user32.dll" (ByVal uAction As Integer, ByVal uParam As Integer, ByVal lpvParam As String, ByVal fuWinIni As Integer) As Integer
    Private Const SPI_SETDESKWALLPAPER As Integer = 20
    Private Const SPIF_UPDATEINIFILE As Integer = &H1
    Private Const SPIF_SENDWININICHANGE As Integer = &H2
    Public Sub Set_DesktopImage(Image As Image, Optional ByVal imagePath As String = "")
        If imagePath = "" Then imagePath = "d:\DeskPic1.jpg"
        Image.Save(imagePath, System.Drawing.Imaging.ImageFormat.Bmp)
        SystemParametersInfo(SPI_SETDESKWALLPAPER, 0, imagePath, SPIF_UPDATEINIFILE Or SPIF_SENDWININICHANGE)
    End Sub
#End Region


    Public Function Get_FromScreen() As Bitmap
        Dim bmpScreenshot As Bitmap = New Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height)
        Dim gfxScreenshot As Graphics = Graphics.FromImage(bmpScreenshot)
        gfxScreenshot.CopyFromScreen(Screen.PrimaryScreen.Bounds.X, Screen.PrimaryScreen.Bounds.Y, 0, 0, Screen.PrimaryScreen.Bounds.Size, CopyPixelOperation.SourceCopy)
        ' Set the PictureBox control's Image property to the screenshot
        Return bmpScreenshot
    End Function
    Public Function Get_ImageSpacialObject(inObject As Object) As Bitmap
        Dim bm As New Bitmap(width:=inObject.Width, height:=inObject.Height)
        inObject.DrawToBitmap(bm, inObject.ClientRectangle)
        Return bm
    End Function
    Public Sub Set_ImageDesktopWithObject(inObject As Object, Optional PoitObject As Point = Nothing)
        Dim bmDesk As New Bitmap(GetDesktopImage)
        Dim bmDate As New Bitmap(Get_ImageSpacialObject(inObject))
        ' Dim gr As Graphics
        Dim x As Integer = (bmDesk.Width - bmDate.Width) \ 2
        Dim y As Integer = (bmDesk.Height - bmDate.Height) \ 2
        Using g As Graphics = Graphics.FromImage(bmDesk)
            g.DrawImage(bmDate, x, y)
        End Using
        Set_DesktopImage(bmDesk)
    End Sub
End Class
Public Module UserControlExtensions
    <Runtime.CompilerServices.Extension()>
    Public Function GetTopLevelForm(control As Control) As Form
        Dim parentForm As Form = TryCast(control, Form)

        While parentForm Is Nothing AndAlso control IsNot Nothing
            control = control.Parent

            If control IsNot Nothing AndAlso TypeOf control Is Form Then
                parentForm = DirectCast(control, Form)
            ElseIf control IsNot Nothing AndAlso control.Parent Is Nothing Then
                Exit While
            End If
        End While

        Return parentForm
    End Function
End Module
Public Module convertDate
    Public idxBeginSelectFromParent As Integer
    Private Function Ceil(Number As Single) As Long
        Ceil = -Math.Sign(Number) * Int(-Math.Abs(Number))
    End Function

    '
    ' Determine Julian day from Persian date
    '
    Function persian_jdn(iYear, iMonth, iDay)
        Const PERSIAN_EPOCH = 1948321 ' The JDN of 1 Farvardin 1
        Dim epbase As Long
        Dim epyear As Long
        Dim mdays As Long
        If iYear >= 0 Then
            epbase = iYear - 474
        Else
            epbase = iYear - 473
        End If
        epyear = 474 + (epbase Mod 2820)
        If iMonth <= 7 Then
            mdays = (CLng(iMonth) - 1) * 31
        Else
            mdays = (CLng(iMonth) - 1) * 30 + 6
        End If
        persian_jdn = CLng(iDay) _
                + mdays _
                + Fix(((epyear * 682) - 110) / 2816) _
                + (epyear - 1) * 365 _
                + Fix(epbase / 2820) * 1029983 _
                + (PERSIAN_EPOCH - 1)
    End Function
    '
    Sub jdn_persian(jdn, ByRef iYear, ByRef iMonth, ByRef iDay)
        Dim depoch
        Dim cycle
        Dim cyear
        Dim ycycle
        Dim aux1, aux2
        Dim yday
        depoch = jdn - persian_jdn(475, 1, 1)
        cycle = Fix(depoch / 1029983)
        cyear = depoch Mod 1029983
        If cyear = 1029982 Then
            ycycle = 2820
        Else
            aux1 = Fix(cyear / 366)
            aux2 = cyear Mod 366
            ycycle = Int(((2134 * aux1) + (2816 * aux2) + 2815) / 1028522) + aux1 + 1
        End If
        iYear = ycycle + (2820 * cycle) + 474
        If iYear <= 0 Then
            iYear = iYear - 1
        End If
        yday = (jdn - persian_jdn(iYear, 1, 1)) + 1
        If yday <= 186 Then
            iMonth = Ceil(yday / 31)
        Else
            iMonth = Ceil((yday - 6) / 30)
        End If
        iDay = (jdn - persian_jdn(iYear, iMonth, 1)) + 1
    End Sub
    Function civil_jdn(ByVal iYear, ByVal iMonth, ByVal iDay)
        Dim lYear
        Dim lMonth
        Dim lDay
        'Dim calendatType
        ' calendarType = Gregorian
        'If calendarType = Gregorian And ((iYear > 1582) _
        If ((iYear > 1582) _
Or ((iYear = 1582) And (iMonth > 10)) _
Or ((iYear = 1582) And (iMonth = 10) And (iDay > 14))) Then

            lYear = CLng(iYear)
            lMonth = CLng(iMonth)
            lDay = CLng(iDay)
            civil_jdn = ((1461 * (lYear + 4800 + ((lMonth - 14) \ 12))) \ 4) _
                    + ((367 * (lMonth - 2 - 12 * (((lMonth - 14) \ 12)))) \ 12) _
                    - ((3 * (((lYear + 4900 + ((lMonth - 14) \ 12)) \ 100))) \ 4) _
                    + lDay - 32075
        Else
            civil_jdn = julian_jdn(iYear, iMonth, iDay)
        End If

    End Function
    Sub jdn_julian(jdn, ByRef iYear, ByRef iMonth, ByRef iDay)
        Dim L As Long
        Dim K As Long
        Dim n As Long
        Dim I As Long
        Dim j As Long

        j = jdn + 1402
        K = ((j - 1) \ 1461)
        L = j - 1461 * K
        n = ((L - 1) \ 365) - (L \ 1461)
        I = L - 365 * n + 30
        j = ((80 * I) \ 2447)
        iDay = I - ((2447 * j) \ 80)
        I = (j \ 11)
        iMonth = j + 2 - 12 * I
        iYear = 4 * K + n + I - 4716

    End Sub
    Function julian_jdn(ByVal iYear, iMonth, iDay) As Long

        julian_jdn = 367 * iYear -
                ((7 * (iYear + 5001 + ((iMonth - 9) \ 7))) \ 4) _
                + ((275 * iMonth) \ 9) + iDay + 1729777

    End Function
    Sub jdn_civil(jdn, ByRef iYear, ByRef iMonth, ByRef iDay)

        Dim L
        Dim K
        Dim n
        Dim I
        Dim j

        If (jdn > 2299160) Then
            L = jdn + 68569
            n = ((4 * L) \ 146097)
            L = L - ((146097 * n + 3) \ 4)
            I = ((4000 * (L + 1)) \ 1461001)
            L = L - ((1461 * I) \ 4) + 31
            j = ((80 * L) \ 2447)
            iDay = L - ((2447 * j) \ 80)
            L = (j \ 11)
            iMonth = j + 2 - 12 * L
            iYear = 100 * (n - 49) + I + L
        Else
            Call jdn_julian(jdn, iYear, iMonth, iDay)
        End If

    End Sub


    'Function m2s(myDate)
    '    iDay = Day(myDate)
    '    iMonth = Month(myDate)
    '    iYear = Year(myDate)
    '    jdn = civil_jdn(iYear, iMonth, iDay)
    '    Call jdn_persian(jdn, iYear, iMonth, iDay)
    '    m2s = iYear & "/" & iMonth & "/" & iDay
    'End Function

    Function s2m(myDate)
        Dim iYear, iMonth, iDay
        Dim st As Object
        Dim S As Object
        Dim x As Object
        For I = 1 To Len(myDate)

            st = Mid(myDate, I, 1)

            If (st = "/" Or st = "-" Or st = "." Or st = "\") And x <> 1 Then
                x = 1
                If I = 3 Then S = "13" & S
            Else
                If (st = "/" Or st = "-" Or st = "." Or st = "\") And x = 1 Then
                    x = 2
                    If I = 5 Or I = 7 Then S = Left(S, Len(S) - 1) & "0" & Right(S, 1)
                Else
                    S = S & st
                End If
            End If
        Next
        If Len(S) = 7 Then S = Left(S, 6) & "0" & Right(S, 1)
        myDate = S
        iYear = Mid(myDate, 1, 4)
        iMonth = Mid(myDate, 5, 2)
        iDay = Mid(myDate, 7, 2)
        If (iDay > 30 And iMonth > 6) Or iDay > 31 Or iMonth > 12 Then s2m = "Error" : Exit Function
        Dim iYear1
        Dim iMonth1
        Dim jdn1
        Dim iDay1
        Dim jdn
        If (iDay = 30 And iMonth = 12) Then
            iYear1 = iYear + 1
            iMonth1 = 1
            iDay1 = 1
            jdn1 = persian_jdn(iYear1, iMonth1, iDay1)
            jdn = persian_jdn(iYear, iMonth, iDay)
            If jdn1 = jdn Then s2m = "Error" : Exit Function
        End If

        jdn = persian_jdn(iYear, iMonth, iDay)
        Call jdn_civil(jdn, iYear, iMonth, iDay)
        s2m = iYear & "/" & iMonth & "/" & iDay
    End Function

    Function m2s(myDate, Optional Format0to7 = 0)
        Dim iDay
        Dim iMonth
        Dim iYear
        Dim iWeekday
        Dim Rooz
        Dim jdn
        Dim mah
        iDay = Microsoft.VisualBasic.Day(myDate)
        iMonth = Month(myDate)
        iYear = Year(myDate)
        iWeekday = Weekday(myDate)

        jdn = civil_jdn(iYear, iMonth, iDay)
        Call jdn_persian(jdn, iYear, iMonth, iDay)

        Select Case iWeekday
            Case 1
                Rooz = ChrW(1740) & ChrW(1705) & ChrW(1588) & ChrW(1606) & ChrW(1576) & ChrW(1607)
            Case 2
                Rooz = ChrW(1583) & ChrW(1608) & ChrW(1588) & ChrW(1606) & ChrW(1576) & ChrW(1607)
            Case 3
                Rooz = ChrW(1587) & ChrW(1607) & ChrW(8204) & ChrW(1588) & ChrW(1606) & ChrW(1576) & ChrW(1607)
            Case 4
                Rooz = ChrW(1670) & ChrW(1607) & ChrW(1575) & ChrW(1585) & ChrW(1588) & ChrW(1606) & ChrW(1576) & ChrW(1607)
            Case 5
                Rooz = ChrW(1662) & ChrW(1606) & ChrW(1580) & ChrW(8204) & ChrW(1588) & ChrW(1606) & ChrW(1576) & ChrW(1607)
            Case 6
                Rooz = ChrW(1580) & ChrW(1605) & ChrW(1593) & ChrW(1607)
            Case 7
                Rooz = ChrW(1588) & ChrW(1606) & ChrW(1576) & ChrW(1607)
        End Select


        Select Case iMonth

            Case 1
                mah = ChrW(1601) & ChrW(1585) & ChrW(1608) & ChrW(1585) & ChrW(1583) & ChrW(1740) & ChrW(1606)
            Case 2
                mah = ChrW(1575) & ChrW(1585) & ChrW(1583) & ChrW(1740) & ChrW(1576) & ChrW(1607) & ChrW(1588) & ChrW(1578)
            Case 3
                mah = ChrW(1582) & ChrW(1585) & ChrW(1583) & ChrW(1575) & ChrW(1583)
            Case 4
                mah = ChrW(1578) & ChrW(1740) & ChrW(1585)
            Case 5
                mah = ChrW(1605) & ChrW(1585) & ChrW(1583) & ChrW(1575) & ChrW(1583)
            Case 6
                mah = ChrW(1588) & ChrW(1607) & ChrW(1585) & ChrW(1740) & ChrW(1608) & ChrW(1585)
            Case 7
                mah = ChrW(1605) & ChrW(1607) & ChrW(1585)
            Case 8
                mah = ChrW(1570) & ChrW(1576) & ChrW(1575) & ChrW(1606)
            Case 9
                mah = ChrW(1570) & ChrW(1584) & ChrW(1585)
            Case 10
                mah = ChrW(1583) & ChrW(1740)
            Case 11
                mah = ChrW(1576) & ChrW(1607) & ChrW(1605) & ChrW(1606)
            Case 12
                mah = ChrW(1575) & ChrW(1587) & ChrW(1601) & ChrW(1606) & ChrW(1583)

        End Select
        Dim sal As String
        Dim sMah As String
        Dim sRoz As String

        sal = Mid(Val(iYear).ToString, 3)
        sMah = IIf(Val(iMonth) < 10, "0" + Val(iMonth).ToString, Val(iMonth).ToString)
        sRoz = IIf(Val(iDay) < 10, "0" + Val(iDay).ToString, Val(iDay).ToString)
        Select Case Format0to7
            Case 0 'Sal/Mah/Roz

                m2s = Mid(Val(iYear).ToString, 2) & "/" & sMah & "/" & sRoz
            Case 1 'Rooz,Sal/Mah/Roz
                m2s = Rooz & "," & sal & "/" & sMah & "/" & sRoz
            Case 2
                m2s = iYear & "/" & iMonth & "/" & iDay ' & " " & horofi(iDay) & " " & mah & " " & ChrW(1605) & ChrW(1575) & ChrW(1607) & " " & horofi(iYear)
            Case 3
                m2s = Rooz & "," & iYear & "/" & iMonth & "/" & iDay
            Case 4
                m2s = sal & "/" & iMonth & "/" & iDay
            Case 5
                m2s = iYear
            Case 6
                m2s = iMonth
            Case 7
                m2s = iDay
            Case Else
                m2s = "" '"Only one of this number as format(0,1,2,3,4,5) for help visit http://sakhteman.wordpress.com"
        End Select

    End Function

End Module