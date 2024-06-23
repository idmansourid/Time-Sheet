
Module modMain
    Dim Conn_String_Access As String = "Provider = Microsoft.ACE.OLEDB.12.0;Data Source='FullNameDataBase'; Jet Oledb:Database Password=yourPassword"
    Const Const_Conn_String_Excel As String = "Provider = Microsoft.ACE.OLEDB.12.0;Data Source = 'FullNameDataBase' ; Extended Properties = 'Excel 8.0;HDR=YES'"
    Public sttPathDbFile As String
    Public dgvForChange As New DataGridView
    Dim isEndTable As Boolean

    Public Function modDataSelectCommend(TableName As String) As DataTable
        Dim SelectCommand As String = "Select * From " & TableName
        'Dim sttPathDbFile As String = IO.Path.GetDirectoryName(Application.ExecutablePath) & "\PS DataBase.accdb"
        Conn_String_Access = Replace(Conn_String_Access, "FullNameDataBase", sttPathDbFile)
        Dim cn As New OleDb.OleDbConnection(Conn_String_Access)
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
    Public Function modDataFillDataSet(TableNames As String()) As DataSet
        Dim ds As New DataSet

        For Each Table In TableNames
            Dim SelectCommand As String = "Select * From " & Table
            'Dim sttPathDbFile As String = IO.Path.GetDirectoryName(Application.ExecutablePath) & "\PS DataBase.accdb"
            Conn_String_Access = Replace(Conn_String_Access, "FullNameDataBase", sttPathDbFile)
            Dim cn As New OleDb.OleDbConnection(Conn_String_Access)

            Dim dr As DataRow
            Dim oleAdp As OleDb.OleDbDataAdapter = New OleDb.OleDbDataAdapter(SelectCommand, cn)
            ' MsgBox(SelectCommand)
            'Dim gOleAdp As OleDb.OleDbDataAdapter = New OleDb.OleDbDataAdapter("", cn)


            oleAdp.Fill(ds, Table)
        Next

        Return ds
        'gOleAdp.SelectCommand.Connection = cn
        'gOleAdp.SelectCommand.CommandText = SelectCommand
        'gOleAdp.Fill(ds, gOleAdp.SelectCommand.CommandText)
    End Function
    Public Function ExcelImport(inPath As String)
        Dim oleConString As String = "Provider= Microsoft.ACE.OLEDB.12.0; Data Source = " & inPath & " ; Extended Properties = 'Excel 8.0;HDR=YES'"
        Dim MyConnection As OleDb.OleDbConnection
        Dim DtSet As DataSet 'ACE.OLEDB.12.0
        'Microsoft.Jet.OLEDB.4.0
        'ACE.OLEDB.12.0
        Dim MyCommand As New System.Data.OleDb.OleDbDataAdapter
        MyConnection = New System.Data.OleDb.OleDbConnection(oleConString)
        ' MyConnection = New System.Data.OleDb.OleDbConnection("provider=Microsoft.Jet.OLEDB.4.0;Data Source='" & txtPathFile.Text & " ';Extended Properties=Excel 8.0;MAXSCANROWS=15;")
        MyCommand = New System.Data.OleDb.OleDbDataAdapter("select * from [Contract Items2$]", MyConnection)
        'MyCommand = New System.Data.OleDb.OleDbDataAdapter("select true as [sel],* from [Document last status Client$]", MyConnection)
        MyCommand.TableMappings.Add("Table", "table1")
        DtSet = New System.Data.DataSet
        MyCommand.Fill(DtSet)
        '  dtMain = DtSet.Tables(0)
    End Function
    Public Function ExcelImportSchema(inPath As String, ByRef dtTableWithColumns As DataTable)
        Dim Conn_String_Excel = Replace(Const_Conn_String_Excel, "FullNameDataBase", inPath)
        Dim MyConnection As OleDb.OleDbConnection
        Dim DtSet As DataSet 'ACE.OLEDB.12.0
        'Microsoft.Jet.OLEDB.4.0
        'ACE.OLEDB.12.0
        Dim MyCommand As New System.Data.OleDb.OleDbDataAdapter
        MyConnection = New System.Data.OleDb.OleDbConnection(Conn_String_Excel)
        MyConnection.Open()
        dtTableWithColumns = MyConnection.GetSchema("Tables")
        Dim dr() As String = MyConnection.GetSchema("Tables").Select.AsEnumerable.Where(Function(f) Not f.Item(2).ToString Like "*xlnm*").Select(Function(g) g.Item(2).ToString).ToArray
        Dim q = dr.Select(Function(g) If(g Like "* *", Mid(g, 2, InStr(g, "$'") - 2), Mid(g, 1, InStr(g, "$") - 1))).ToArray
        Dim bb As Boolean = "'ShopCalibre (1)$'_xlnm#_FilterDatabase" Like "*FilterDatabase*"
        'Dim dt As New DataTable
        'dt.Columns.Add("Table")
        'dt.Columns.Add("Column")

        dtTableWithColumns = MyConnection.GetSchema("columns").Copy

        ' MyConnection = New System.Data.OleDb.OleDbConnection("provider=Microsoft.Jet.OLEDB.4.0;Data Source='" & txtPathFile.Text & " ';Extended Properties=Excel 8.0;MAXSCANROWS=15;")
        '  MyCommand = New System.Data.OleDb.OleDbDataAdapter("select * from [Contract Items2$]", MyConnection)
        'MyCommand = New System.Data.OleDb.OleDbDataAdapter("select true as [sel],* from [Document last status Client$]", MyConnection)
        '   MyCommand.TableMappings.Add("Table", "table1")
        '  DtSet = New System.Data.DataSet
        ' MyCommand.Fill(DtSet)
        '  dtMain = DtSet.Tables(0)
        MyConnection.Close()
        Return q
    End Function
    Public Sub MultiFilterOnTables(sttText As String, lisChildTables As List(Of DataTable), lstFiltering As ListBox, LastLen As Byte, lstResult As ListBox)
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
            If sttText.Length > 0 AndAlso Mid(sttText, sttText.Length) = Microsoft.VisualBasic.Chr(4) Then
                If LastLen < sttText.Length Then
                    Dim stt4 As String = Split(lstFiltering.SelectedItem.item(0), Microsoft.VisualBasic.Chr(3))(0)
                    lisChildTables(SplChangeDB.Length - 2).DefaultView.RowFilter = "[SpcialColumns] Like '" & stt4 & Microsoft.VisualBasic.Chr(3) & "*'"
                    stt4 = lstFiltering.SelectedItem.item(0)

                    lstResult.Items.Add(stt4)
                    'Else
                    '    lisChildTables(SplChangeDB.Length - 2).DefaultView.RowFilter = ""
                End If
                If SplChangeDB.Length - 1 < lisChildTables.Count Then
                    lstFiltering.DataSource = lisChildTables(SplChangeDB.Length - 1)
                    lisChildTables(SplChangeDB.Length - 1).DefaultView.RowFilter = ""
                Else
                    isEndTable = True
                End If

            ElseIf SplChangeDB.Length - 1 < lisChildTables.Count Then
                If lstFiltering.DataSource IsNot lisChildTables(SplChangeDB.Length - 1) Or isEndTable Then
                    lstFiltering.DataSource = lisChildTables(SplChangeDB.Length - 1)
                    isEndTable = False
                    If lstResult.Items.Count > 0 Then lstResult.Items.RemoveAt(lstResult.Items.Count - 1)
                End If
                lisChildTables(SplChangeDB.Length - 1).DefaultView.RowFilter = sttFilter
            End If
        End If
    End Sub
    Public Function modCellIsNullFromColumns(inDgv As dgv.uDgv, ColumnsForCheck As String()) As Boolean
        ' CellIsNullFromColumns(sender, Split("MainGroup,SubGroup,Dis1", ","))
        Dim sttCheck As String
        For Each c In ColumnsForCheck
            sttCheck = inDgv.dgv.CurrentRow.Cells(c).Value.ToString()
            If sttCheck = "" Then
                Return True
            End If
        Next


    End Function
    Public Sub TreeViewFilter(inText As String, InDT As DataTable, InTreeView As TreeView, inColumns As String())
        Dim arrTree = (From row In InDT.DefaultView.ToTable.AsEnumerable()
                       Select inColumns.Select(Function(h) row.Item(h)).ToArray).ToArray
        'arrTree = (From row In InDT.AsEnumerable()
        '           Select dynamicColumn.Select(Function(h) row.Item(h)).ToArray).ToArray

        'arrTree = (From row In InDT.AsEnumerable()
        '           Select row.ItemArray).ToArray
        'trvValidtion.Nodes.Clear()

        For a = 0 To arrTree.Length - 1
            Dim parentNode As TreeNode = Nothing
            For b = 1 To arrTree(a).Length - 1
                Dim value1 = arrTree(a)(b).ToString()
                If value1 = "" Then
                    value1 = "[Blanks]"
                End If
                Dim node As TreeNode = Nothing
                If parentNode IsNot Nothing Then
                    node = parentNode.Nodes.Cast(Of TreeNode)() _
            .FirstOrDefault(Function(n) n.Text = value1)
                Else
                    node = InTreeView.Nodes.Cast(Of TreeNode)() _
            .FirstOrDefault(Function(n) n.Text = value1)
                End If
                If node IsNot Nothing Then
                    node.ForeColor = Color.FromArgb(0, 0, 0, 0)
                End If

                If node Is Nothing Then
                    node = New TreeNode(value1)
                    node.Tag = inColumns(b) & "|" & a ').Item(DgvFrom.ColumnPrimaryKey)
                    node.Name = arrTree(a)(0).ToString()
                    If parentNode IsNot Nothing Then
                        parentNode.Nodes.Add(node)
                    Else
                        InTreeView.Nodes.Add(node)
                    End If
                End If
                parentNode = node
            Next
        Next
        'InTreeView.CollapseAll()
        'lstOfNodes = GetNodes(dynamicColumn, DtFilterForFunction, Level)
        'bitExitAfterSelect = True
        'If lstOfNodes IsNot Nothing Then

        '    For Each itemList In lstOfNodes
        '        itemList.Expand()
        '    Next

        'End If

        'If lstOfNodes.Count > 0 Then
        '    trvValidtion.SelectedNode = lstOfNodes(lstOfNodes.Count - 1)
        '    lstOfNodes(lstOfNodes.Count - 1).ForeColor = Color.Red
        'End If
        'bitExitAfterSelect = False

    End Sub
    Public Function modExcelImportSheet(inPath As String, SheetName As String) As DataTable
        Dim Conn_String_Excel = Replace(Const_Conn_String_Excel, "FullNameDataBase", inPath)
        Dim MyConnection As OleDb.OleDbConnection
        Dim DtSet As DataSet
        Dim MyCommand As New System.Data.OleDb.OleDbDataAdapter
        MyConnection = New System.Data.OleDb.OleDbConnection(Conn_String_Excel)
        ' MyConnection = New System.Data.OleDb.OleDbConnection("provider=Microsoft.Jet.OLEDB.4.0;Data Source='" & txtPathFile.Text & " ';Extended Properties=Excel 8.0;MAXSCANROWS=15;")
        MyCommand = New System.Data.OleDb.OleDbDataAdapter("select * from [" & SheetName & "$]", MyConnection)
        'MyCommand = New System.Data.OleDb.OleDbDataAdapter("select true as [sel],* from [Document last status Client$]", MyConnection)
        MyCommand.TableMappings.Add("Table", "table1")
        DtSet = New System.Data.DataSet
        MyCommand.Fill(DtSet)
        MyConnection.Close()
        Return DtSet.Tables(0).Copy
    End Function
    Public Function modExcel_GetSpcialColumns(TableName As String, columnsNane As String(), sttExcelPath As String, Optional Seprator As String = " ")
        Dim SelectCommand As String = Join(columnsNane, "] & '" & Seprator & "' & [") '& " As NewColumn From [" & TableName & "$]"
        SelectCommand = "Select [" & SelectCommand & "] As [NewColumn] From ['" & TableName & "$']"
        Dim Conn_String_Excel = Replace(Const_Conn_String_Excel, "FullNameDataBase", sttExcelPath)
        Dim cn As New OleDb.OleDbConnection(Conn_String_Excel)
        Dim ds As New DataSet
        Dim dr As DataRow
        Dim oleAdp As OleDb.OleDbDataAdapter = New OleDb.OleDbDataAdapter(SelectCommand, cn)
        ds.Tables.Clear()
        oleAdp.Fill(ds, SelectCommand)
        cn.Close()
        Return ds.Tables(0).AsEnumerable.Select(Function(f) f.Item(0).ToString).ToArray

    End Function
    Public Function modData_GetSpcialColumns(TableName As String, columnsNane As String(), Optional Seprator As String = " ") As String()
        Dim SelectCommand As String = "Select  *," & Join(columnsNane, " & '" & Seprator & "' & ") & " As NewColumn,* From " & TableName
        'Dim sttPathDbFile As String = IO.Path.GetDirectoryName(Application.ExecutablePath) & "\PS DataBase.accdb"
        Conn_String_Access = Replace(Conn_String_Access, "FullNameDataBase", sttPathDbFile)
        Dim cn As New OleDb.OleDbConnection(Conn_String_Access)
        Dim ds As New DataSet
        Dim dr As DataRow
        Dim oleAdp As OleDb.OleDbDataAdapter = New OleDb.OleDbDataAdapter(SelectCommand, cn)
        ' MsgBox(SelectCommand)
        'Dim gOleAdp As OleDb.OleDbDataAdapter = New OleDb.OleDbDataAdapter("", cn)
        ds.Tables.Clear()

        oleAdp.Fill(ds, SelectCommand)

        Return ds.Tables(0).AsEnumerable.Select(Function(f) f.Item(0).ToString).ToArray
    End Function
    Public Function modSetLocationFormOfCellDgv(inDgv As DataGridView, frm As Form)
        frm.StartPosition = FormStartPosition.Manual
        Dim rec As Rectangle
        rec = inDgv.GetCellDisplayRectangle(inDgv.CurrentCell.ColumnIndex, inDgv.CurrentCell.RowIndex, True)

        ' rec = DgvFrom.uDgv.GetCellDisplayRectangle(DgvFrom.uDgv.CurrentCell.ColumnIndex, DgvFrom.uDgv.CurrentCell.RowIndex, True)
        '  If PinOFF Then
        If (inDgv.PointToScreen(New Point(rec.X, rec.Y + rec.Height + 20)).Y + frm.Height) > (My.Computer.Screen.Bounds.Height) Then
            frm.Location = inDgv.PointToScreen(New Point(rec.X, rec.Y - frm.Height - 10))
            '   Location = DgvFrom.PointToScreen(New Point(rec.X, (rec.Y + rec.Height - 10) - Height))
        Else
            frm.Location = inDgv.PointToScreen(New Point(rec.X, rec.Y + rec.Height + 20))
        End If
        '  End If
    End Function
    Public Function modGetLocationCellDgv(inDgv As DataGridView, frm As Form, inOffset As Point) As Point
        frm.StartPosition = FormStartPosition.Manual
        Dim rec As Rectangle
        rec = inDgv.GetCellDisplayRectangle(inDgv.CurrentCell.ColumnIndex, inDgv.CurrentCell.RowIndex, True)
        Dim pPoint As Point = New Point(inDgv.PointToScreen(New Point(rec.X, rec.Y - frm.Height)))
        pPoint.Offset(inOffset)
        Return pPoint 'inDgv.PointToScreen(New Point(rec.X, rec.Y - frm.Height)).Offset(inOffset)
        If (inDgv.PointToScreen(New Point(rec.X, rec.Y + rec.Height + 20)).Y + frm.Height) > (My.Computer.Screen.Bounds.Height) Then
            Return New Point(rec.X, rec.Y - frm.Height - 10)
        Else
            Return New Point(rec.X, rec.Y + rec.Height + 20)
        End If
    End Function
    Public Function modLstBoxSelectItemUpDown(keyData As Keys, lstBox As ListBox) As String
        If lstBox.SelectedIndex < 0 Then Exit Function
        Dim BytMove As Byte = IIf(keyData = Keys.Down And lstBox.SelectedIndex =
  (lstBox.Items.Count - 1), 0, IIf(lstBox.SelectedIndex = 0 And keyData = Keys.Up, 0, 1))
        lstBox.SelectedIndex = lstBox.SelectedIndex + IIf(keyData = Keys.Down, BytMove, Val("-" & BytMove))
        Return lstBox.SelectedItem
    End Function
    Public Function modData_GetSpcialColumnsAsTable(TableName As String, columnsNane As String(), Optional Seprator As String = " ", Optional AllColumn As Boolean = False) As DataTable
        Dim SelectCommand As String = "Select  " & Join(columnsNane, " & '" & Seprator & "' & ") & " As SpcialColumns," & IIf(AllColumn, " * ", " [" & Join(columnsNane, "],[") & "]") & " From " & TableName
        'Dim sttPathDbFile As String = IO.Path.GetDirectoryName(Application.ExecutablePath) & "\PS DataBase.accdb"
        Conn_String_Access = Replace(Conn_String_Access, "FullNameDataBase", sttPathDbFile)
        Dim cn As New OleDb.OleDbConnection(Conn_String_Access)
        Dim ds As New DataSet
        Dim dr As DataRow
        Dim oleAdp As OleDb.OleDbDataAdapter = New OleDb.OleDbDataAdapter(SelectCommand, cn)
        ' MsgBox(SelectCommand)
        'Dim gOleAdp As OleDb.OleDbDataAdapter = New OleDb.OleDbDataAdapter("", cn)
        ds.Tables.Clear()

        oleAdp.Fill(ds, SelectCommand)

        Return ds.Tables(0)
    End Function
    Public Function modDataDataSet(TableName As String) As DataSet
        Dim SelectCommand As String = "Select DisItem From " & TableName
        'Dim sttPathDbFile As String = IO.Path.GetDirectoryName(Application.ExecutablePath) & "\PS DataBase.accdb"

        Dim Connection_String As String = "Provider = Microsoft.ACE.OLEDB.12.0;Data Source='FullNameDataBase'; Jet Oledb:Database Password=yourPassword"
        Connection_String = Replace(Connection_String, "FullNameDataBase", sttPathDbFile)
        Dim cn As New OleDb.OleDbConnection(Connection_String)
        Dim ds As New DataSet
        Dim dr As DataRow
        Dim oleAdp As OleDb.OleDbDataAdapter = New OleDb.OleDbDataAdapter(SelectCommand, cn)
        ' MsgBox(SelectCommand)
        'Dim gOleAdp As OleDb.OleDbDataAdapter = New OleDb.OleDbDataAdapter("", cn)
        ds.Tables.Clear()

        oleAdp.Fill(ds, TableName)
        Return ds
        'gOleAdp.SelectCommand.Connection = cn
        'gOleAdp.SelectCommand.CommandText = SelectCommand
        'gOleAdp.Fill(ds, gOleAdp.SelectCommand.CommandText)
    End Function
    Public Sub SaveData2(ds As DataSet, connString As String)
        Dim sttPathDbFile As String = IO.Path.GetDirectoryName(Application.ExecutablePath) & "\PS DataBase.accdb"
        Dim Connection_String As String = "Provider = Microsoft.ACE.OLEDB.12.0;Data Source='FullNameDataBase'; Jet Oledb:Database Password=yourPassword"
        Connection_String = Replace(Connection_String, "FullNameDataBase", sttPathDbFile)
        Dim cn As New OleDb.OleDbConnection(Connection_String)

        Using conn As New OleDb.OleDbConnection(Connection_String)

            Dim selectCommand As New OleDb.OleDbCommand("SELECT [DisItem] FROM qBaseItemsP", conn)
            Dim da As New OleDb.OleDbDataAdapter(selectCommand)

            ' For simple tables you can get the commands auto-generated, otherwise create the commands manually
            ' and set the appropriate properties on the da
            Dim builder As New OleDb.OleDbCommandBuilder(da)
            da.InsertCommand = builder.GetInsertCommand()
            da.UpdateCommand = builder.GetUpdateCommand()
            da.DeleteCommand = builder.GetDeleteCommand()

            Dim changes = ds.GetChanges()

            ' Save data
            conn.Open()
            da.Update(ds, "qBaseItemsP")
        End Using
    End Sub
    Private Function LoadData(connString As String) As DataSet
        Using conn As New OleDb.OleDbConnection(connString)

            Dim selectCommand As New OleDb.OleDbCommand("SELECT ID, Title FROM ProjectsDB", conn)
            Dim ds As New DataSet

            ' Load data
            Dim da As New OleDb.OleDbDataAdapter(selectCommand)
            conn.Open()
            da.Fill(ds, "Projects")

            Return ds
        End Using
    End Function
    Public Function modData_ExecuteNonQuery(inDgv As DataGridView, InSql As String) As Integer
        Dim icount As Integer = -1
        Conn_String_Access = Replace(Conn_String_Access, "FullNameDataBase", sttPathDbFile)
        Dim cn As New OleDb.OleDbConnection(Conn_String_Access)
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
    Public Function modData_Insert_Update(TableName As String, InColumns As String(), inValues As Object(), Optional Seprator As String = "")
        Dim icount As Integer = -1

        Dim SelectCommand As String = "Select * From " & TableName
        Conn_String_Access = Replace(Conn_String_Access, "FullNameDataBase", sttPathDbFile)
        Dim cn As New OleDb.OleDbConnection(Conn_String_Access)
        cn.Open()
        Dim oleComand As New OleDb.OleDbCommand("", cn)
        Dim ds As New DataSet
        Dim oleAdp As OleDb.OleDbDataAdapter = New OleDb.OleDbDataAdapter("", cn)
        ' Sql = "INSERT INTO " & TableName & " VALUES(" & pValues & ")"
        Dim sqlInsert As String = ""
        sqlInsert = "INSERT INTO " & TableName & " ([" & Join(InColumns, "],[") & " ]) "
        Dim SqlValues As String
        oleComand.CommandText = sqlInsert
        ' pValues = Replace(pValues, "@", "")
        'sql = "INSERT INTO " & TableName & " (" & pColumns & ")  VALUES(" & pValues2 & ")"
        oleComand.Parameters.Clear()
        Dim sttSql As String = ""
        'Dim CountInsert As Integer = 0
        ' Dim gRow(CountInsert) As DataGridViewRow
        Try
            For a = 0 To inValues.Length - 1
                Dim stt2 = "'" & Replace(inValues(a), Seprator, "','") & "'"
                SqlValues = inValues(a)
                'sttSql = sqlInsert & " VALUES(" & stt2 & ")"
                oleComand.CommandText = sqlInsert & " VALUES(" & stt2 & ")"
                icount = oleComand.ExecuteNonQuery
                'Dim dataGridViewRow As New DataGridViewRow
                'Dim sttRow As String() = Split(inValues(a), Seprator)
                'dataGridViewRow.CreateCells(dgvForChange, sttRow)
                'gRow(a) = dataGridViewRow
                'CountInsert += 1
                'ReDim Preserve gRow(CountInsert)
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            '    dgvForChange.Rows.AddRange(gRow)

        End Try



        cn.Close()
        Return icount
    End Function
    Private Sub SaveData(ds As DataSet, connString As String)
        Using conn As New OleDb.OleDbConnection(connString)

            Dim selectCommand As New OleDb.OleDbCommand("SELECT ID, Title FROM ProjectsDB", conn)
            Dim da As New OleDb.OleDbDataAdapter(selectCommand)

            ' For simple tables you can get the commands auto-generated, otherwise create the commands manually
            ' and set the appropriate properties on the da
            Dim builder As New OleDb.OleDbCommandBuilder(da)
            da.InsertCommand = builder.GetInsertCommand()
            da.UpdateCommand = builder.GetUpdateCommand()
            da.DeleteCommand = builder.GetDeleteCommand()

            Dim changes = ds.GetChanges()

            ' Save data
            conn.Open()
            da.Update(ds, "Projects")
        End Using
    End Sub
    Public Function modColumnDistinct(dataTable As DataTable, ColumnName As String) As String()
        Dim q = dataTable.AsEnumerable.Where(Function(h) Not h.RowState = DataRowState.Deleted).Select(Function(h) h.Item(ColumnName).ToString).Distinct.ToArray
        Return q
    End Function

    Private Sub MoveRowSelShowButton(pnlRowSelect As Panel, dgv As DataGridView)
        'Button1.Location = New Point((ClientSize.Width - Button1.Width) \ 2, (ClientSize.Height - Button1.Height) \ 2)
        If dgv.CurrentCell Is Nothing Then
            pnlRowSelect.Visible = False
            Exit Sub
        End If

        Dim rec As Rectangle = dgv.GetCellDisplayRectangle(dgv.CurrentCell.ColumnIndex, dgv.CurrentCell.RowIndex, True)
        If rec.Width = 0 OrElse rec.Height = 0 Then
            pnlRowSelect.Visible = False
            Exit Sub
        End If

        pnlRowSelect.Visible = True

        Dim pointOnDataGridViewCoodinate = rec.Location
        Dim pointOnScreen = dgv.PointToScreen(pointOnDataGridViewCoodinate)
        Dim pointOnButtonCoordinate As Point = pnlRowSelect.PointToClient(pointOnScreen)

        Dim newPoint As Point = pnlRowSelect.Location
        newPoint.Offset(pointOnButtonCoordinate)
        newPoint.Offset(-pnlRowSelect.Width, 0)

        pnlRowSelect.Location = newPoint
        pnlRowSelect.Height = rec.Height
        'Private Sub OnNeedMoveButton(sender As Object, e As EventArgs) _
        'Handles Me.Shown _
        ', Me.Resize _
        ', dgv_BaseGrouping.Resize _
        ', dgv_BaseGrouping.Scroll _
        ', dgv_BaseGrouping.SelectionChanged _
        ', dgv_BaseGrouping.ColumnWidthChanged _
        ', dgv_BaseGrouping.ColumnHeadersHeightChanged _
        ', dgv_BaseGrouping.RowHeightChanged _
        ', dgv_BaseGrouping.RowHeadersWidthChanged

        '    MoveRowSelShowButton()
        'End Sub
    End Sub

End Module
