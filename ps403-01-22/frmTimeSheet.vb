
Imports System.Runtime.InteropServices
Imports System.Text

Public Class frmTimeSheet
    Dim WithEvents txtmTarikh As New dgv.claHostMaskTextBox
    Dim WithEvents tsButNow As New ToolStripButton("", My.Resources.dateNow, Nothing, "tsButNow")
    Dim WithEvents tsButRozGhabl As New ToolStripButton("", My.Resources.rozGhabl, Nothing, "tsButRozGhabl")
    Dim WithEvents tsButRozBaad As New ToolStripButton("", My.Resources.RozBaad, Nothing, "tsButRozBaad")
    Dim tsLblWeek As New ToolStripLabel("", Nothing, False, Nothing, "tsLblWeek")
    Dim WithEvents tsButRej As New ToolStripButton("", My.Resources.AddRow, Nothing, "tsButRej")
    Public WithEvents tsButResult As New ToolStripButton("", My.Resources.result, Nothing, "tsButResult")
    Public WithEvents tsButNonFilter As New ToolStripButton("", My.Resources.result, Nothing, "tsButNonFilter")
    Dim sep As New ToolStripSeparator

    Dim DBPathFile As String = IO.Path.GetDirectoryName(Application.ExecutablePath) & "\PS DataBaseMain.accdb"
    Dim sttTables As String = "qHozorGhiab,HozorGhiabDayli,K_PersenelWork,Persenel,SematHa,FaaliatHa"
    Dim WithEvents dt0qHozorGhiab, dt0HozorGhiabDayli, dt0K_PersenelWork, dt0Persenel, dt0SematHa, dt0FaaliatHa As New DataTable
    Dim lisTables As String()
    Dim WithEvents ds As New DataSet
    Dim dt_Persenel As New DataTable
    Dim WithEvents dt0SelPersenel As New DataTable
    Dim bit2 As Boolean
    Dim DateOffset As Date
    Public MyLanguage As String()
    Public DicLanguage As New Dictionary(Of String, String)
    Dim DB As New dgv.DataBase(DB_PathFile:=DBPathFile)
    Dim ConvertData As New dgv.DateConvert
    Dim mFunc As New dgv.mFunction
    Dim WithEvents frmSelectRows As New dgv.frmSelectRows
    Dim dicDateCountPersonel As New Dictionary(Of String, Integer)

    Private Sub frmTimeSheet_Load(sender As Object, e As EventArgs) Handles Me.Load

        ' Me.BackgroundImage = Image

        '   PictureBox1.Image = mFunc.GetDesktopImage

#Region "زبان انگلیسی به فارسی"
        MyLanguage = Split(My.Settings.LanguageEnFa, vbNewLine)
        For Each a In MyLanguage
            If a Like "*=*" Then
                DicLanguage.Add(UCase(Split(a, "=")(0)), Split(a, "=")(1))
            End If
        Next
        frmSelectPer.DicLanguage = DicLanguage
#End Region
        frmSelectRows.StartPosition = FormStartPosition.Manual
        frmSelectRows.Height = 160
        Dim Conn_String_Access As String = Replace(dgv_Persenel.cnSt_ACE_OLEDB_12, "FullNameDataBase", DBPathFile)
        'لیست جدول های بین دیتابیس و نرم افزار
        lisTables = Split(sttTables, ",")
        DB.Schema_GetTables(stFilter:="[DESCRIPTION] = 'TimeSheet'")
        ' Join(dgv_Persenel.Schema_GetTables(Conn_String_Access, "[DESCRIPTION] = 'TimeSheet'"), ",")
        '  Clipboard.SetText(Join(dgv_Persenel.Schema_GetColumns(Conn_String_Access), vbNewLine))
        modMain.sttPathDbFile = DBPathFile
        'آماده سازی دیتاست نرم افزار توسط نام های جدول ها
        ds = DB.Get_Tables_DataSet(lisTables)
        'qHozorGhiab( idPer tarikh TimeStart TimeEnd TimeLen )
        'HozorGhiabDayli( ID tarikh )
        'K_PersenelWork( ID idPerSarparast idPerZirGroh idArea idWork )
        'Persenel( sel ID code fName famil semat tel remark address )
        'SematHa( ID fName )
        'FaaliatHa( ID Sarparast ZirGroh WorkType Area tarikh )

        ds.Relations.Add(DB.RelationTables("Persenel@qHozorGhiab", ds.Tables("Persenel").Columns("ID"), ds.Tables("qHozorGhiab").Columns("idPer")))


        dt0Persenel = ds.Tables(Split(NameOf(dt0Persenel), "0")(1))
        dgv_Persenel.DataTable = dt0Persenel
        dgv_Persenel.DataTable.PrimaryKey = New DataColumn() {dgv_Persenel.DataTable.Columns("ID")}

        dgv_Persenel.dgv.Columns("Sel").Visible = False

#Region "آماده سازی جدول انتخاب افراد"
        dt0SelPersenel.Columns.Add("Sel", GetType(Boolean))
        dt0SelPersenel.Columns.Add("ID", GetType(Integer))
        dt0SelPersenel.Columns.Add("Code", GetType(String))
        dt0SelPersenel.Columns.Add("fName", GetType(String))
        dt0SelPersenel.Columns.Add("Famil", GetType(String))
        dt0SelPersenel.Columns.Add("TimeStart", GetType(String))
        dt0SelPersenel.Columns.Add("TimeEnd", GetType(String))
        dt0SelPersenel.Columns.Add("Semat", GetType(String))
        dgv_SelPersenel.DataTable = dt0SelPersenel
        dgv_SelPersenel.dgv.Columns("Sel").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader
        dgv_SelPersenel.dgv.Columns("ID").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader
        dgv_SelPersenel.dgv.Columns("Code").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader
        dgv_SelPersenel.dgv.Columns("TimeStart").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader
        dgv_SelPersenel.dgv.Columns("TimeEnd").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader
        dgv_SelPersenel.dgv.Columns("Sel").ReadOnly = True
        dgv_SelPersenel.dgv.AllowUserToAddRows = False
        ' Dim dRowSelPer As DataRow = dt0SelPersenel.NewRow
        For Each a As DataRow In dt0Persenel.Rows
            dt0SelPersenel.Rows.Add({False, a.Item("ID"), a.Item("Code"), a.Item("fName"), a.Item("Famil"), Nothing, Nothing, a.Item("Semat")})
        Next
        ' ست کردن کلید اصلی
        dgv_SelPersenel.DataTable.PrimaryKey = New DataColumn() {dgv_SelPersenel.DataTable.Columns("ID")}

#End Region
#Region "چیدمان افراد"
        dt0FaaliatHa = ds.Tables(Split(NameOf(dt0FaaliatHa), "0")(1))
        dt0FaaliatHa.Columns(0).SetOrdinal(4)
        dgv_FaaliatHa.DataTable = dt0FaaliatHa
        dgv_FaaliatHa.dgv.RightToLeft = RightToLeft.Yes
#End Region



        dt0qHozorGhiab = ds.Tables(Split(NameOf(dt0qHozorGhiab), "0")(1))
        dgv_qHozorGhiab.DataTable = dt0qHozorGhiab
        'تنظیم کلید اصلی جهت استفاده از تابع پیدا کردن
        dgv_qHozorGhiab.DataTable.PrimaryKey = New DataColumn() {dgv_qHozorGhiab.DataTable.Columns("IDPer"), dgv_qHozorGhiab.DataTable.Columns("Tarikh")}
        dgv_qHozorGhiab.DataTable.ExtendedProperties.Add("Filter", "")
        dicDateCountPersonel = dgv_qHozorGhiab.Get_DicCountOfDublicateColumn("tarikh")
        'tlsHozorGhiab.Items.Add(sep)
        'tlsHozorGhiab.Items.Add(tsButRej)
        'tlsHozorGhiab.Items.Add(tsButResult)
        'tlsHozorGhiab.Items.Add(tsButNonFilter)


    End Sub

    Private Sub dgv_Persenel__CellTextChange(sender As dgv.uDgv) Handles dgv_Persenel._CellTextChange

    End Sub

    Private Sub dgv_Persenel__RowValidating(sender As dgv.uDgv, e As DataGridViewCellCancelEventArgs) Handles dgv_Persenel._RowValidating

    End Sub

    Private Sub dgv_Persenel__RowValidatingWhenNewOrEdit(sender As dgv.uDgv, e As DataGridViewCellCancelEventArgs) Handles dgv_Persenel._RowValidatingWhenNewOrEdit
        If sender.KeysLast = Keys.Escape + Keys.Shift Or sender.KeysLast = Keys.Escape Then Exit Sub
        Dim sttColIndex As String = ""
        If sender.NullCellsInAnyColumns(Split("ID,code,fName,famil,semat", ","), sttColIndex) Then
            sender.dgv.CurrentCell = sender.dgv.Item(sttColIndex, sender.dgv.CurrentRow.Index)
            e.Cancel = True
            Exit Sub
        End If


        Dim sttSQL As String
        If sender.bit.isNewRow Then
            sttSQL = sender.Sql_Insert(sender.dgv.CurrentRow.DataBoundItem.row, sender.TableName)
            If DB.SQL_ExecuteNonQuery(sender.dgv, sttSQL) = -1 Then
                e.Cancel = True
                Exit Sub
            End If
        ElseIf sender.bit.isEditRow Then
            sttSQL = sender.Sql_Update(sender.dgv, sender.TableName, ColumnsFilter:=Split("ID", ","), Where_IsID:=sender.dgv.CurrentRow.Cells("id").Value)
            If DB.SQL_ExecuteNonQuery(sender.dgv, sttSQL) = -1 Then
                e.Cancel = True
                Exit Sub
            End If
        End If
    End Sub

    Private Sub dgv_Persenel__CellValidating(sender As dgv.uDgv, e As DataGridViewCellValidatingEventArgs) Handles dgv_Persenel._CellValidating

    End Sub

    Private Sub tsTxtTarikh_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub dgv_Persenel__DefaultValuesNeeded(sender As dgv.uDgv, e As DataGridViewRowEventArgs) Handles dgv_Persenel._DefaultValuesNeeded
        Dim maxId As Integer = Val(TryCast(sender.dgv.DataSource, DataTable).Compute("Max([Id])", "").ToString)

        e.Row.Cells("Id").Value = maxId + 1
    End Sub

    Private Sub tabMain_TabIndexChanged(sender As Object, e As EventArgs) Handles tabMain.TabIndexChanged

    End Sub

    Private Sub dgv_SelPersenel__CellMouseClick(sender As dgv.uDgv, e As DataGridViewCellMouseEventArgs) Handles dgv_SelPersenel._CellMouseClick
        If (e.Button = MouseButtons.Left And e.ColumnIndex > -1 And e.RowIndex > -1) AndAlso sender.dgv.Columns(sender.dgv.CurrentCell.ColumnIndex).Name = "Sel" Then
            sender.dgv.CurrentRow.Cells("TimeStart").Value = IIf(Not sender.dgv.CurrentCell.EditedFormattedValue, "07:00", "")
            sender.dgv.CurrentRow.Cells("TimeEnd").Value = IIf(Not sender.dgv.CurrentCell.EditedFormattedValue, "17:00", "")
            sender.dgv.CurrentRow.Cells("Sel").Value = Not sender.dgv.CurrentRow.Cells("Sel").Value
            sender.Validate()
            Dim dv As New DataView(sender.DataTable, "[Sel]=True", "", DataViewRowState.CurrentRows)
            '   dv = sender.DataTable.DefaultView
            frmSelectPer.dgv_SelectPer.DataTable = dv.ToTable(False, {"ID", "code", "fName", "famil"})
        End If


    End Sub



    Private Sub MaskedTextBox1_TextChanged(sender As Object, e As EventArgs)
        'bit2 = True
        'tsTxtTarikh.Text = MaskedTextBox1.Text
        'bit2 = False
    End Sub

    Private Sub dgv_FaaliatHa_Load(sender As Object, e As EventArgs) Handles dgv_FaaliatHa.Load

    End Sub

    Private Sub tsButNow_Click(sender As ToolStripButton, e As EventArgs) Handles tsButNow.Click, tsButRozGhabl.Click, tsButRozBaad.Click
        Dim dicNameDay As New Dictionary(Of DayOfWeek, String)
        dicNameDay.Add(DayOfWeek.Saturday, "شنبه")
        dicNameDay.Add(DayOfWeek.Sunday, "یکشنبه")
        dicNameDay.Add(DayOfWeek.Monday, "دوشنبه")
        dicNameDay.Add(DayOfWeek.Tuesday, "سه شنبه")
        dicNameDay.Add(DayOfWeek.Wednesday, "چهارشنبه")
        dicNameDay.Add(DayOfWeek.Thursday, "پنجشنبه")
        dicNameDay.Add(DayOfWeek.Friday, "جمعه")
        Select Case sender.Name
            Case "tsButNow"
                DateOffset = Now
                txtmTarikh.Text = ConvertData.m2s(DateOffset)' dgv_Persenel.DateM2S(DateOffset)
            Case "tsButRozGhabl"
                DateOffset = DateOffset.AddDays(-1)
                txtmTarikh.Text = ConvertData.m2s(DateOffset)
            Case "tsButRozBaad"
                DateOffset = DateOffset.AddDays(1)
                txtmTarikh.Text = ConvertData.m2s(DateOffset)
        End Select
        tsLblWeek.Text = dicNameDay(DateOffset.DayOfWeek)
        dgv_qHozorGhiab.DataTable.DefaultView.RowFilter = "[tarikh] Like '" & UDate1.textDate & "'"
        dgv_qHozorGhiab.DataTable.ExtendedProperties.Item("Filter") = dgv_qHozorGhiab.DataTable.DefaultView.RowFilter
        Dim q As String() = dgv_qHozorGhiab.DataTable.DefaultView.Cast(Of DataRowView).Select(Function(g) g.Item("IdPer").ToString).ToArray
        For Each rSelPer As DataRow In dgv_SelPersenel.DataTable.Rows
            rSelPer.Item("Sel") = False
            rSelPer.Item("TimeStart") = ""
            rSelPer.Item("TimeEnd") = ""
        Next
        For Each rHozor As DataRow In dgv_qHozorGhiab.DataTable.DefaultView.ToTable.Rows
            dgv_SelPersenel.DataTable.Rows.Find(rHozor.Item("IDPer")).Item("Sel") = True
            dgv_SelPersenel.DataTable.Rows.Find(rHozor.Item("IDPer")).Item("TimeStart") = rHozor.Item("TimeStart")
            dgv_SelPersenel.DataTable.Rows.Find(rHozor.Item("IDPer")).Item("TimeEnd") = rHozor.Item("TimeEnd")
        Next
        'For Each a As DataGridViewRow In dgv_SelPersenel.dgv.Rows
        '    If q.Contains(a.Cells("ID").Value) Then
        '        a.Cells("Sel").Value = True
        '    Else
        '        a.Cells("Sel").Value = False
        '        ' a.Cells("Start").Value =
        '    End If
        'Next
        Dim dv As New DataView(dgv_SelPersenel.DataTable, "[Sel]=True", "", DataViewRowState.CurrentRows)
        frmSelectPer.dgv_SelectPer.DataTable = dv.ToTable(False, {"ID", "code", "fName", "famil"})

        'For Each a As DataRow In dgv_HozorGhiab.DataTable.DefaultView

        'Next

    End Sub



    Private Sub tsButResult_Click(sender As Object, e As EventArgs) Handles tsButResult.Click
        tsButResult.Checked = Not tsButResult.Checked
        frmSelectPer.Visible = tsButResult.Checked
    End Sub



    Private Sub butTsAddRow_Click(sender As Object, e As EventArgs) Handles butTsAddRow.Click
        '   Dim maxId As Integer = Val(dgv_HozorGhiab.DataTable.Compute("Max([Id])", "").ToString) + 1
        dgv_SelPersenel.Validate()
        Dim dRowSelectTarikh() As DataRow = dgv_qHozorGhiab.DataTable.Select("[tarikh] Like '" & UDate1.textDate & "'")
        For Each a In dRowSelectTarikh
            dgv_qHozorGhiab.DataTable.Rows.Remove(a)
        Next
        '  dgv_HozorGhiab.Sql_Insert
        '        DELETE HozorGhiab.tarikh
        'From HozorGhiab
        'Where (((HozorGhiab.tarikh) = "a"));
        Dim sttSql As String = "Delete * From HozorGhiab Where (((HozorGhiab.tarikh) = '" & UDate1.textDate & "'))" 'dgv_HozorGhiab.Sql_Delete(dgv_HozorGhiab.dgv, dgv_HozorGhiab.TableName)
        DB.SQL_ExecuteNonQuery(dgv_qHozorGhiab.dgv, sttSql)
        Dim dt As DataTable = frmSelectPer.dgv_SelectPer.DataTable
        '  Dim q As String() = dt.Rows.Cast(Of DataRow).Select(Function(g) g.Item("id").ToString).ToArray
        ' Dim q1 As String() = dgv_HozorGhiab.DataTable.DefaultView.Cast(Of DataRowView).Select(Function(g) g.Item("IdPer").ToString).ToArray

        For Each drow As DataRow In dt.Rows
            'If q1.Contains(drow.Item("ID")) = False Then
            '    dgv_HozorGhiab.DataTable.Rows.Add({drow.Item("ID"), UDate1.textDate, drow.Item("Start"), drow.Item("End")})
            'Else
            '    Stop
            '    Dim remowRow As DataRow() = dgv_HozorGhiab.DataTable.Select(dgv_HozorGhiab.DataTable.DefaultView.RowFilter & " And  [IdPer]=" & drow.Item("ID"))
            '    dgv_HozorGhiab.DataTable.Rows.Remove(remowRow(0))
            'End If
            Dim dRowSelPer As DataRow = dgv_SelPersenel.DataTable.Rows.Find(drow.Item("ID"))
            Dim dRowData As DataRow = dgv_qHozorGhiab.DataTable.NewRow
            dRowData.ItemArray = {drow.Item("ID"), UDate1.textDate, dRowSelPer.Item("TimeStart"), dRowSelPer.Item("TimeEnd")}
            dgv_qHozorGhiab.DataTable.Rows.Add(dRowData)
            sttSql = dgv_qHozorGhiab.Sql_Insert(dRowData, "HozorGhiab", ColumnsFilter:=Split("Sel,fName,famil,semat,tel", ","))
            DB.SQL_ExecuteNonQuery(dgv_qHozorGhiab.dgv, sttSql)
        Next
        Dim drows As DataRow() = dgv_qHozorGhiab.DataTable.Select("[tarikh] Like '" & UDate1.textDate & "'")
        drows.ToList().ForEach(Sub(g)
                                   g.Item("fName") = dgv_Persenel.DataTable.Rows.Find(g.Item("idPer")).Item("fName")
                                   g.Item("Famil") = dgv_Persenel.DataTable.Rows.Find(g.Item("idPer")).Item("Famil")
                                   g.Item("Semat") = dgv_Persenel.DataTable.Rows.Find(g.Item("idPer")).Item("Semat")
                                   g.Item("Semat") = dgv_Persenel.DataTable.Rows.Find(g.Item("idPer")).Item("Semat")
                               End Sub)
        dicDateCountPersonel = dgv_qHozorGhiab.Get_DicCountOfDublicateColumn("tarikh")
        '   dgv_qHozorGhiab.dgv.Ref
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        mFunc.Set_ImageDesktopWithObject(UDate1)
    End Sub

    Private Sub dgv_SelPersenel_Load(sender As Object, e As EventArgs) Handles dgv_SelPersenel.Load

    End Sub

    Private Sub tsButNonFilter_Click(sender As ToolStripButton, e As EventArgs) Handles tsButNonFilter.Click
        sender.Checked = Not sender.Checked
        sender.Tag = dgv_qHozorGhiab.DataTable.DefaultView.RowFilter
        If sender.Checked Then
            dgv_qHozorGhiab.DataTable.DefaultView.RowFilter = ""
        Else
            dgv_qHozorGhiab.DataTable.DefaultView.RowFilter = dgv_qHozorGhiab.DataTable.ExtendedProperties.Item("Filter")
        End If
    End Sub

    Private Sub dgv_FaaliatHa__CellGreenHelperClick(sender As dgv.uDgv) Handles dgv_FaaliatHa._CellGreenHelperClick
        frmSelectRows.Location = sender.LocationFrmSelect(frmSelectRows, sender.CurrentCellRec)

        Dim sttColName As String = sender.dgv.Columns(sender.dgv.CurrentCell.ColumnIndex).Name
        Select Case sttColName
            Case "Sarparast"
                frmSelectRows.Visible = Not frmSelectRows.Visible
                frmSelectRows.Show_TrvLstChk(dgv.frmSelectRows.ShowMode.List, {"محسن رمضانی", "خداپرست"})

            Case "ZirGroh"
                frmSelectRows.Visible = Not frmSelectRows.Visible
                frmSelectRows.Show_TrvLstChk(dgv.frmSelectRows.ShowMode.CheckBoxList, {"محمد صادقی", "رضا نادری", "احمد علی زاده"})

        End Select

    End Sub

    Private Sub UDate1_CellClick(sender As DataGridView, e As DataGridViewCellEventArgs) Handles UDate1._CellClick
        dgv_qHozorGhiab.DataTable.DefaultView.RowFilter = "[tarikh] Like '" & UDate1.textDate & "'"
        dgv_qHozorGhiab.DataTable.ExtendedProperties.Item("Filter") = dgv_qHozorGhiab.DataTable.DefaultView.RowFilter
        Dim q As String() = dgv_qHozorGhiab.DataTable.DefaultView.Cast(Of DataRowView).Select(Function(g) g.Item("IdPer").ToString).ToArray
        For Each rSelPer As DataRow In dgv_SelPersenel.DataTable.Rows
            rSelPer.Item("Sel") = False
            rSelPer.Item("TimeStart") = ""
            rSelPer.Item("TimeEnd") = ""
        Next
        For Each rHozor As DataRow In dgv_qHozorGhiab.DataTable.DefaultView.ToTable.Rows
            dgv_SelPersenel.DataTable.Rows.Find(rHozor.Item("IDPer")).Item("Sel") = True
            dgv_SelPersenel.DataTable.Rows.Find(rHozor.Item("IDPer")).Item("TimeStart") = rHozor.Item("TimeStart")
            dgv_SelPersenel.DataTable.Rows.Find(rHozor.Item("IDPer")).Item("TimeEnd") = rHozor.Item("TimeEnd")
        Next
        'For Each a As DataGridViewRow In dgv_SelPersenel.dgv.Rows
        '    If q.Contains(a.Cells("ID").Value) Then
        '        a.Cells("Sel").Value = True
        '    Else
        '        a.Cells("Sel").Value = False
        '        ' a.Cells("Start").Value =
        '    End If
        'Next
        Dim dv As New DataView(dgv_SelPersenel.DataTable, "[Sel]=True", "", DataViewRowState.CurrentRows)
        frmSelectPer.dgv_SelectPer.DataTable = dv.ToTable(False, {"ID", "code", "fName", "famil"})
    End Sub

    Private Sub UDate1__CellSetNumber(sender As DataGridView, e As DataGridViewCellPaintingEventArgs, CellDate As String, ByRef NumberForSet As Integer) Handles UDate1._CellSetNumber
        CellDate = Replace(UDate1.ConvertDate.mFormat(CellDate), "/", "-")
        If dicDateCountPersonel.Keys.Contains(CellDate) Then
            NumberForSet = dicDateCountPersonel(CellDate)
        End If

    End Sub

    Private Sub tabMain_SelectedIndexChanged(sender As Object, e As EventArgs) Handles tabMain.SelectedIndexChanged
        Dim bmp As New Bitmap(UDate1.Width, UDate1.Height)
        Dim g As Graphics = UDate1.CreateGraphics()
        g.CopyFromScreen(UDate1.PointToScreen(New Point(0, 0)), New Point(0, 0), UDate1.Size, CopyPixelOperation.SourceCopy)
        g.Dispose()
        bmp.Save("Image" & Now.Millisecond & ".png")

        'Dim gr As Graphics = UDate1.CreateGraphics
        'Dim size As Size = UDate1.Size
        'Dim memoryImage As New Bitmap(size.Width, size.Height, gr)
        'Dim memoryGraphics As Graphics = Graphics.FromImage(memoryImage)
        'Dim location As Point = UDate1.Location
        'memoryGraphics.CopyFromScreen(location.X, location.Y, 0, 0, size)

    End Sub
End Class