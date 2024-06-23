Imports System.Drawing
Imports System.Windows.Forms


Public Class uDate
    Public WithEvents txtmTarikh As New claMaskTextBox
    Dim WithEvents tsButNow As New ToolStripButton("", My.Resources.dateNow, Nothing, "tsButNow")
    Dim WithEvents tsButRozGhabl As New ToolStripButton("", My.Resources.rozGhabl, Nothing, "tsButRozGhabl")
    Dim WithEvents tsButRozBaad As New ToolStripButton("", My.Resources.RozBaad, Nothing, "tsButRozBaad")
    Dim tsLblWeek As New ToolStripLabel("", Nothing, False, Nothing, "tsLblWeek")
    Public ConvertDate As New DateM2S_S2M
    Public DateOffset As Date
    Public CellToDey As DataGridViewCell
    Public SalMahRozToDay As String
    Public OfsetSal As Integer
    Public MovMah As Integer
    Public OffSetMovMah As Integer
    Public Event _CellClick(sender As DataGridView, e As DataGridViewCellEventArgs)
    Public Event _CellSetNumber(sender As DataGridView, e As DataGridViewCellPaintingEventArgs, CellDate As String, ByRef NumberForSet As Integer)
    Dim dicNameDay As New Dictionary(Of DayOfWeek, String)
    Public Property textDate As String
        Get
            Return txtmTarikh.Text
        End Get
        Set(value As String)
            txtmTarikh.Text = value
        End Set
    End Property
    Private Sub uDate_Load(sender As Object, e As EventArgs) Handles Me.Load

        dicNameDay.Add(DayOfWeek.Saturday, "شنبه")
        dicNameDay.Add(DayOfWeek.Sunday, "یکشنبه")
        dicNameDay.Add(DayOfWeek.Monday, "دوشنبه")
        dicNameDay.Add(DayOfWeek.Tuesday, "سه شنبه")
        dicNameDay.Add(DayOfWeek.Wednesday, "چهارشنبه")
        dicNameDay.Add(DayOfWeek.Thursday, "پنجشنبه")
        dicNameDay.Add(DayOfWeek.Friday, "جمعه")

        tslNavi.Items.Add(tsButRozGhabl)
        txtmTarikh.MaskedTextBoxControl.Mask = "00-00-00"
        txtmTarikh.MaskedTextBoxControl.Size = New Size(60, 20)
        txtmTarikh.AutoSize = False

        txtmTarikh.TextAlign = ContentAlignment.MiddleCenter
        tslNavi.Items.Add(txtmTarikh)
        tslNavi.Items.Add(tsButRozBaad)
        tslNavi.Items.Add(tsButNow)
        tsLblWeek.AutoSize = False
        tsLblWeek.Size = New Size(50, 20)
        tslNavi.Items.Add(tsLblWeek)
        dgv.RowCount = 6
        dgv.ReadOnly = True
        For Each r As Windows.Forms.DataGridViewColumn In dgv.Columns
            r.Width = 30
            r.SortMode = DataGridViewColumnSortMode.NotSortable
        Next
        DateOffset = Now

        'SalMahRozToDay = ConvertData.SetupDate2(DateOffset)
        'MovMah = ConvertData.Pro.Mah - 1
        'OfsetSal = ConvertData.Pro.Sal
        '    Dim AddressCells As DataGridViewCell() =
        '(From row As DataGridViewRow In dgv.Rows
        ' From cell As DataGridViewCell In row.Cells
        ' Select cell).ToArray()

        '    Dim sAt As Integer = ConvertData.lisMoveMah(MovMah) - 1
        '    For a = 0 To AddressCells.Length - 1
        '        sAt += 1
        '        AddressCells(a).Value = Split(ConvertData.Pro.SalMahRoz366(sAt), "/")(2)
        '        If SalMahRozToDay = ConvertData.Pro.SalMahRoz366(sAt) Then
        '            '  ConvertData.Pro.CurrentDay =
        '            CellToDey = AddressCells(a)
        '        End If
        '    Next
        'Dim bytDay As Byte = 1
        'For a = ConvertData.Pro.FirstPositionIdx To AddressCells.Length - 1
        '    If bytDay > ConvertData.Pro.CountRozCourrentMah Then
        '        bytDay = 1
        '    End If
        '    AddressCells(a).Value = bytDay
        '    If (a + 1) = ConvertData.Pro.ToDay Then
        '        '  ConvertData.Pro.CurrentDay =
        '        CellToDey = AddressCells(a)
        '    End If

        '    bytDay += 1
        'Next
        'Dim s As Byte = 1
        'For Each r As DataGridViewCell In AddressCells
        '    r.Value = s
        '    s += 1
        'Next
        ' CellToDey.Style = New DataGridViewCellStyle With {.BackColor = Color.Green}
        SalMahRozToDay = ConvertDate.SetupDate2(DateOffset)
        tsButNow_Click(tsButNow, Nothing)

    End Sub
    Public Function ShamsiToMiladi(GDay As Long, GMonth As Long, GYear As Long) As Date
        Dim dTime As New DateTime(year:=2024, month:=4, day:=30)
        Dim calPer As New System.Globalization.PersianCalendar
        Dim stt3 As String = String.Format("{0}/{1}/{2}", calPer.GetYear(dTime), calPer.GetMonth(dTime), calPer.GetDayOfMonth(dTime))





        Return stt3
        '    DateTime Date = New DateTime(2013, 10, 24);
        'var calendar = New PersianCalendar();
        'var persianDate = New DateTime(calendar.GetYear(Of Date), calendar.GetMonth(Of Date), calendar.GetDayOfMonth(Of Date));
        'var result = persianDate.ToString("yyyy MMM ddd", CultureInfo.GetCultureInfo("fa-Ir"));

        '        String GregorianDate = "Thursday, October 24, 2013";
        'DateTime d = DateTime.Parse(GregorianDate);
        'PersianCalendar pc = New PersianCalendar();
        'Console.WriteLine(String.Format("{0}/{1}/{2}", pc.GetYear(d), pc.GetMonth(d), pc.GetDayOfMonth(d)));
    End Function

    Private Sub tsButNow_Click(sender As ToolStripButton, e As EventArgs) Handles tsButNow.Click, tsButRozGhabl.Click, tsButRozBaad.Click


        Dim AddressCells As DataGridViewCell() =
    (From row As DataGridViewRow In dgv.Rows
     From cell As DataGridViewCell In row.Cells
     Select cell).ToArray()
        Select Case sender.Name
            Case "tsButNow"
                DateOffset = Now
             '   OffSetMovMah = MovMah
                '  Dim CountDay As Integer = ConvertData.GetCountDay_FA(DateOffset)
                '  Dim arrSetWidthColumn() = Split(My.Settings.WidthColumns, "|")
                ' arrSetWidthColumn.ToList.ForEach(Sub(g) dgv.Columns(CInt(Split(g, ",")(0))).Width = CInt(Split(g, ",")(1)))
                ' Dim q = dgv.Columns.Cast(Of DataGridViewColumn).Select(Function(ss) Join(New Object() {ss.Name, ss.Width}.ToArray, ",")).ToArray

                'Dim AddressCells = dgv.Columns.Cast(Of DataGridViewColumn).Select(Function(h) New DataGridViewCell() {dgv.Rows.Cast(Of DataGridViewRow).Select(Function(g) g.Cells(h.Index))}).ToArray
                'For Each s As DataGridViewCell In AddressCells
                '    s.Value = "op"
                'Next


               ' txtmTarikh.Text = ConvertData.m2s(DateOffset, DateM2S_S2M.FormatDate.Sal3MahRoz)' dgv_Persenel.DateM2S(DateOffset)
            Case "tsButRozGhabl"

                DateOffset = DateOffset.AddMonths(-1)

                'If OffSetMovMah = 0 Then
                '    OfsetSal -= 1
                '    Dim d As Date = ConvertData.s2m(OfsetSal & "01" & "/01")

                '    ConvertData.SetupDate(d)
                '    OffSetMovMah = 10
                'Else
                '    OffSetMovMah -= 1
                'End If

              '  Dim fIdx As Byte = IIf(OffSetMovMah < 0, OffSetMovMah + 1, OffSetMovMah + -6)  ' Mod 7


                'DateOffset = DateOffset.AddDays(-1)
                'txtmTarikh.Text = ConvertData.m2s(DateOffset, DateM2S_S2M.FormatDate.Sal3MahRoz)
            Case "tsButRozBaad"
                ' OffSetMovMah += 1

                DateOffset = DateOffset.AddMonths(1)
                'txtmTarikh.Text = ConvertData.m2s(DateOffset, DateM2S_S2M.FormatDate.Sal3MahRoz)
        End Select
        Dim CurentDate As String = ConvertDate.SetupDate2(DateOffset)
        CurentDate = ConvertDate.SetupDate2(DateOffset)
        txtmTarikh.Text = ConvertDate.mFormat(CurentDate) ' Mid(Split(SalMahRozToDay, "/")(0), 2) & "-" &
        CellToDey = Nothing
        For a = 0 To AddressCells.Length - 1
            AddressCells(a).Value = Split(ConvertDate.Pro.SalMahRoz366(a), "/")(2)
            AddressCells(a).Tag = ConvertDate.Pro.SalMahRoz366(a)
            If Split(CurentDate, "/")(1) = Split(SalMahRozToDay, "/")(1) And SalMahRozToDay = ConvertDate.Pro.SalMahRoz366(a) And CellToDey Is Nothing Then
                '  ConvertData.Pro.CurrentDay =
                CellToDey = AddressCells(a)
                dgv.CurrentCell = CellToDey

            End If
            If Mid(CurentDate, 1, 8) = Mid(ConvertDate.Pro.SalMahRoz366(a), 1, 8) Then
                AddressCells(a).Style = New DataGridViewCellStyle With {.BackColor = Color.LightBlue, .Font = New Font("tahoma", 8, FontStyle.Bold)}
            Else
                AddressCells(a).Style = New DataGridViewCellStyle With {.BackColor = Color.GreenYellow, .Font = New Font("tahoma", 8, FontStyle.Regular)}
            End If
        Next

        '   Dim sAt As Integer = ConvertData.lisMoveMah(OffSetMovMah) - 1
        'For a = 0 To AddressCells.Length - 1
        '    sAt += 1
        '    AddressCells(a).Value = Split(ConvertData.Pro.SalMahRoz366(sAt), "/")(2)
        '    If SalMahRozToDay = ConvertData.Pro.SalMahRoz366(sAt) Then
        '        '  ConvertData.Pro.CurrentDay =
        '        CellToDey = AddressCells(a)
        '    End If
        '    If Mid(SalMahRozToDay, 1, 8) = Mid(ConvertData.Pro.SalMahRoz366(sAt), 1, 8) Then
        '        AddressCells(a).Style = New DataGridViewCellStyle With {.BackColor = Color.LightBlue}
        '    Else
        '        AddressCells(a).Style = New DataGridViewCellStyle With {.BackColor = Color.GreenYellow}
        '    End If


        'Next

        tsLblWeek.Text = dicNameDay(DateOffset.DayOfWeek)
        'dgv_HozorGhiab.DataTable.DefaultView.RowFilter = "[tarikh] Like '" & txtmTarikh.Text & "'"
        'dgv_HozorGhiab.DataTable.ExtendedProperties.Item("Filter") = dgv_HozorGhiab.DataTable.DefaultView.RowFilter
        'Dim q As String() = dgv_HozorGhiab.DataTable.DefaultView.Cast(Of DataRowView).Select(Function(g) g.Item("IdPer").ToString).ToArray
        'For Each rSelPer As DataRow In dgv_SelPersenel.DataTable.Rows
        '    rSelPer.Item("Sel") = False
        '    rSelPer.Item("TimeStart") = ""
        '    rSelPer.Item("TimeEnd") = ""
        ''Next
        'For Each rHozor As DataRow In dgv_HozorGhiab.DataTable.DefaultView.ToTable.Rows
        '    dgv_SelPersenel.DataTable.Rows.Find(rHozor.Item("IDPer")).Item("Sel") = True
        '    dgv_SelPersenel.DataTable.Rows.Find(rHozor.Item("IDPer")).Item("TimeStart") = rHozor.Item("TimeStart")
        '    dgv_SelPersenel.DataTable.Rows.Find(rHozor.Item("IDPer")).Item("TimeEnd") = rHozor.Item("TimeEnd")
        'Next
        'For Each a As DataGridViewRow In dgv_SelPersenel.dgv.Rows
        '    If q.Contains(a.Cells("ID").Value) Then
        '        a.Cells("Sel").Value = True
        '    Else
        '        a.Cells("Sel").Value = False
        '        ' a.Cells("Start").Value =
        '    End If
        'Next
        'Dim dv As New DataView(dgv_SelPersenel.DataTable, "[Sel]=True", "", DataViewRowState.CurrentRows)
        'frmSelectPer.dgv_SelectPer.DataTable = dv.ToTable(False, {"ID", "code", "fName", "famil"})

        'For Each a As DataRow In dgv_HozorGhiab.DataTable.DefaultView

        'Next

    End Sub
    Private Sub uDate_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        ' MyBase.OnPaint(e)

        ' Declare and instantiate a drawing pen.
        Using myPen = New System.Drawing.Pen(Color.FromArgb(255, 224, 224, 224), 4)

            ' Create a rectangle that represents the size of the control, minus 1 pixel.
            Dim area = New Rectangle(New Point(0, 0), New Size(Me.Size.Width - 1, Me.Size.Height - 1))

            ' Draw an aqua rectangle in the rectangle represented by the control.
            e.Graphics.DrawRectangle(myPen, area)

        End Using
    End Sub

    Private Sub dgv_CellPainting(sender As Object, e As DataGridViewCellPaintingEventArgs) Handles dgv.CellPainting
        ' Exit Sub
        If e.ColumnIndex > -1 And e.RowIndex > -1 Then
            e.PaintBackground(e.CellBounds, True)
            If CellToDey IsNot Nothing Then

                If e.ColumnIndex = CellToDey.ColumnIndex And e.RowIndex = CellToDey.RowIndex Then
                    CelllPait_ToDay(e)
                End If
            End If
            Dim inNumber As Integer
            RaiseEvent _CellSetNumber(dgv, e, sender.Item(e.ColumnIndex, e.RowIndex).tag, inNumber)
            If inNumber > 0 Then CelllPait_SetNumber(e, inNumber.ToString)
            e.PaintContent(e.ClipBounds)
            e.Handled = True

        End If


        ' Stop


        '  

        '   End If

    End Sub
    Sub CelllPait_ToDay(e As DataGridViewCellPaintingEventArgs)
        Dim point2 As Point = dgv.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, False).Location
        point2.Offset(8, 7)
        ' Dim area = New Rectangle(point2, New Size(dgv.CurrentCell.Size.Width - 4, dgv.CurrentCell.Size.Height - 4))
        Dim area = New Rectangle(point2, New Size(20, 15))
        '  Dim br
        'e.PaintBackground(e.CellBounds, True)
        ' e.Graphics.FillRectangle(, e.CellBounds)
        ' e.Graphics.DrawEllipse(Pens.Blue, area)
        e.Graphics.FillEllipse(Brushes.Orange, area)
        '  e.Graphics.DrawRectangle(New Pen(Color.Red, 1), area)


    End Sub
    Sub CelllPait_SetNumber(e As DataGridViewCellPaintingEventArgs, InNumber As String)

        'Dim w As Single = 30
        'Dim h As Single = 50
        'Dim centerY As Single = CSng(Button2.Height / 2)

        'e.Graphics.SmoothingMode = SmoothingMode.AntiAlias
        'e.Graphics.CompositingQuality = CompositingQuality.HighQuality

        'Using gp As New GraphicsPath()
        '    gp.AddLine(0, centerY - h / 2, w, centerY)
        '    gp.AddLine(w, centerY, 0, centerY + h / 2)
        '    e.Graphics.DrawPath(Pens.Red, gp)
        '    e.Graphics.FillPath(Brushes.Red, gp)
        'End Using
        Dim point3 As Point = New Point(e.CellBounds.Location)
        point3.Offset(New Point(0, 0))
        e.Graphics.DrawString(InNumber, New Font("tahoma", 7, FontStyle.Regular), Brushes.Red, point3)
        Exit Sub
        Dim point2 As Point = dgv.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, False).Location
        point2.Offset(2, 2)
        Dim area = New Rectangle(point2, New Size(dgv.CurrentCell.Size.Width - 4, dgv.CurrentCell.Size.Height - 4))
        '  Dim br
        ' e.PaintBackground(e.CellBounds, True)
        ' e.Graphics.FillRectangle(, e.CellBounds)
        ' e.Graphics.DrawRectangle(New Pen(Color.Blue, 1), area)
        Dim gp As New Drawing2D.GraphicsPath()
        '  gp.
        '  Dim point3 As Point = New Point(e.CellBounds.Location)
        point3.Offset(New Point(30, 20))
        gp.AddLine(point3.X, point3.Y, point3.X - 10, point3.Y)
        gp.AddLine(point3.X - 10, point3.Y, point3.X - 10, point3.Y - 10)
        gp.AddLine(point3.X, point3.Y - 10, point3.X, point3.Y)
        'gp.AddLine(e.CellBounds.Height - 10 + InOffset, e.CellBounds.Width, e.CellBounds.Height + InOffset, e.CellBounds.Width - 10)
        'gp.AddLine(e.CellBounds.Height + InOffset, e.CellBounds.Width - 10, e.CellBounds.Height + InOffset, e.CellBounds.Width)

        ' e.Graphics = CreateGraphics()
        e.Graphics.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
        e.Graphics.CompositingQuality = Drawing2D.CompositingQuality.HighQuality
        e.Graphics.DrawPath(Pens.Red, gp)
        e.Graphics.FillPath(Brushes.Red, gp)
        ' e.Graphics.DrawImage(My.Resources.ok, point2)

        ' e.Handled = True
    End Sub

    Private Sub dgv_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv.CellClick
        txtmTarikh.Text = ConvertDate.mFormat(dgv.CurrentCell.Tag)
        RaiseEvent _CellClick(sender, e)
        tsLblWeek.Text = dicNameDay(DateOffset.DayOfWeek)
    End Sub
End Class
Public Class claMaskTextBox
    Inherits ToolStripControlHost

    Public Sub New()
        MyBase.New(New MaskedTextBox())
    End Sub

    Public ReadOnly Property MaskedTextBoxControl As MaskedTextBox
        Get
            Return CType(Me.Control, MaskedTextBox)
        End Get
    End Property
End Class
Public Class DateM2S_S2M
    Public Enum mFormatDate
        SalMahRoz = 0
        Sal3MahRoz = 1

        Sal2MahRoz = 2
        Only_Roz = 3
        Only_Mah = 4

    End Enum
    Public CountDaysOfM As Integer
    Public CountSal As Integer
    Public idxBeginSelectFromParent As Integer
    Private Function Ceil(Number As Single) As Long
        Ceil = -Math.Sign(Number) * Int(-Math.Abs(Number))
    End Function
    Public Structure sCellPro
        Dim SalMahRoz As String
        Dim isToDay As Boolean
    End Structure
    Public Structure sDate
        Dim Sal As Integer
        Dim Mah As Byte
        Dim Roz As Byte
        Dim CountRozCourrentMah As Byte
        Dim FirstPositionIdx As Byte
        Dim CurrentDay As DataGridViewCell
        Dim ToDay As Byte
        Dim IsLeapYear As Boolean
        Dim Days As List(Of String)
        Dim SalMahRoz366 As List(Of String)
        Dim cellPro As List(Of sCellPro)
    End Structure
    Public Pro As sDate
    Public lisMoveMah As New List(Of Integer)
    Public Function m2sNET(MiladiDate2024_01_01 As String) As String

        Dim Sal As Integer = Val(Split(MiladiDate2024_01_01, "/")(0))
        Dim Mah As Integer = Val(Split(MiladiDate2024_01_01, "/")(1))
        Dim Roz As Integer = Val(Split(MiladiDate2024_01_01, "/")(2))
        Dim dTime As New DateTime(year:=Sal, month:=Mah, day:=Roz)
        Dim calPer As New System.Globalization.PersianCalendar
        Sal = calPer.GetYear(dTime)
        Mah = calPer.GetMonth(dTime)
        Roz = calPer.GetDayOfMonth(dTime)
        Dim stt3 As String = String.Format("{0}/{1}/{2}", Format(Sal, "0000"), Format(Mah, "00"), Format(Roz, "00"))
        'Sal = calPer.Getday(dTime)
        Return stt3
    End Function
    Public Function s2mNET(SamsiDate1403_01_01 As String) As String
        '  SamsiDate1403_01_01 = "1397/10/01"
        Dim spl(2) As String
        Dim Sal As Integer = Val(Split(SamsiDate1403_01_01, "/")(0))
        Dim Mah As Integer = Val(Split(SamsiDate1403_01_01, "/")(1))
        Dim Roz As Integer = Val(Split(SamsiDate1403_01_01, "/")(2))
        spl(0) = New Date(Sal, Mah, Roz, New System.Globalization.PersianCalendar).Year
        spl(1) = New Date(Sal, Mah, Roz, New System.Globalization.PersianCalendar).Month
        spl(2) = New Date(Sal, Mah, Roz, New System.Globalization.PersianCalendar).Day
        Dim stt3 As String = String.Format("{0}/{1}/{2}", spl(0), spl(1), spl(2))
        Return stt3
    End Function
    Public Function SetupDate2(myDate As Date) As String
        Dim lisCelPro As New List(Of sCellPro)
        Pro.SalMahRoz366 = New List(Of String)

        Pro.Days = New List(Of String)
        Pro.cellPro = New List(Of sCellPro)

        Dim SalMahRow As String = m2sNET(myDate.Year & "/" & myDate.Month & "/" & myDate.Day)
        Dim spl() As String = Split(SalMahRow, "/")
        Pro.Sal = spl(0)
        Pro.Mah = spl(1)
        Pro.Roz = spl(2)
        'sAvalHafte()
        Dim AvaliRozMiladi As Date

        'Dim sttAvalMah As String = s2mNET(Pro.Sal.ToString & "/" & "01/01")
        'Dim AvaliRozMiladi As Date = New Date(year:=Split(sttAvalMah, "/")(0), month:=Split(sttAvalMah, "/")(1), day:=Split(sttAvalMah, "/")(2))
        'Dim dte1 As DayOfWeek = AvaliRozMiladi.DayOfWeek
        'AvaliRozMiladi = AvaliRozMiladi.AddDays(-dte1 - 2)
        AvaliRozMiladi = sAvalHafte()
        Pro.SalMahRoz366.Clear()
        Dim stt1 As String()
        Dim stt2 As String
        Dim stt3 As String = ""
        For a = 1 To 100
            Pro.SalMahRoz366.Add(m2sNET(AvaliRozMiladi.AddDays(a).Year & "/" & AvaliRozMiladi.AddDays(a).Month & "/" & AvaliRozMiladi.AddDays(a).Day))
        Next
        'For b = 0 To Pro.SalMahRoz366.Count - 1 Step 7
        '    ' stt1 += "," & Pro.SalMahRoz366(b)
        '    stt1 = Pro.SalMahRoz366.Skip(b).Take(7).ToArray
        '    stt2 = Join(stt1, "|")
        '    If InStr(stt2, "/01|") <> 0 Then
        '        lisMoveMah.Add(Pro.SalMahRoz366.IndexOf(stt1(0)))
        '    End If

        'Next

        Return SalMahRow


    End Function
    Public Function mFormat(inDate As String, Optional InFormat As mFormatDate = mFormatDate.Sal2MahRoz)
        Dim spl() As String = Split(inDate, "/")
        Dim stt As String = ""
        Select Case InFormat
            Case mFormatDate.Sal3MahRoz
                stt = Mid(spl(0), 2) & "-" & spl(1) & "-" & spl(2)
            Case mFormatDate.Sal2MahRoz
                stt = Mid(spl(0), 3) & "-" & spl(1) & "-" & spl(2)
        End Select
        Return stt
    End Function
    Private Function sAvalHafte()
        Dim sttAvalMah As String = s2mNET(Pro.Sal.ToString & "/" & Pro.Mah.ToString & "/01")
        Dim AvaliRozMiladi As Date = New Date(year:=Split(sttAvalMah, "/")(0), month:=Split(sttAvalMah, "/")(1), day:=Split(sttAvalMah, "/")(2))
        Dim dte1 As DayOfWeek = AvaliRozMiladi.DayOfWeek ' IIf(AvaliRozMiladi.DayOfWeek = 6, 0, IIf(AvaliRozMiladi.DayOfWeek = 0, 6, AvaliRozMiladi.DayOfWeek))
        Dim ofset As Integer = IIf(dte1 = 6, 0, IIf(dte1 = 0, 6, 2))
        AvaliRozMiladi = AvaliRozMiladi.AddDays(-IIf(dte1 = 6, 0, dte1) - IIf(dte1 = 6, 1, 2)) '2 - IIf(AvaliRozMiladi.DayOfWeek = 6, 0, 2)

        Return AvaliRozMiladi
    End Function
    Public Function SetupDate(myDate) As String
        Dim lisCelPro As New List(Of sCellPro)
        Pro.SalMahRoz366 = New List(Of String)

        Pro.Days = New List(Of String)
        Pro.cellPro = New List(Of sCellPro)
        Dim SalMahRow As String = m2s(myDate)
        SetupDate = SalMahRow
        '  Dim offset As Integer = 31 - roz
        Dim spl() As String = Split(SalMahRow, "/")
        Pro.Sal = spl(0)
        Pro.Mah = spl(1)
        Pro.Roz = spl(2)
        Pro.IsLeapYear = Val(spl(0) + 1) Mod 4 = 0
        Dim LenMah() As String = Split(IIf(Val(spl(0)) Mod 4 = 0, 30, 29) & ",31,31,31,31,31,31,30,30,30,30,30," & IIf(Pro.IsLeapYear, 30, 29) & ",31", ",")
        Dim Day As Byte = 0
        Pro.SalMahRoz366.Clear()

        For d = 0 To LenMah.Length - 1
            For h = 1 To Val(LenMah(d))
                Pro.SalMahRoz366.Add(IIf(d = 0, Val(Pro.Sal) - 1, IIf(d > 12, Pro.Sal + 1, Pro.Sal)) & "/" & Format(IIf(d = 0, 12, IIf(d > 12, 1, d)), "00") & "/" & Format(h, "00"))
            Next

        Next
        Dim AvalinRozSal As Byte = Pro.SalMahRoz366.IndexOf(Format(Pro.Sal, "00") & "/" & "01/01")
        Dim idxOf As Integer = Pro.SalMahRoz366.IndexOf(SalMahRow)
        idxOf -= AvalinRozSal
        Dim mDate As Date = DirectCast(myDate, Date).AddDays(-idxOf)
        Dim mRoz As Byte = mDate.DayOfWeek
        mDate = DirectCast(myDate, Date).AddDays(-(idxOf + mRoz + 1))
        AvalinRozSal -= mRoz + 1
        Dim lisDate As New List(Of String)
        For a = AvalinRozSal To Pro.SalMahRoz366.Count - 1
            lisDate.Add(Pro.SalMahRoz366(a))
        Next
        Pro.SalMahRoz366 = lisDate
        Dim stt1 As String()
        lisMoveMah.Clear()

        For b = 0 To Pro.SalMahRoz366.Count - 1 Step 7
            ' stt1 += "," & Pro.SalMahRoz366(b)
            stt1 = Pro.SalMahRoz366.Skip(b).Take(7).ToArray
            Dim stt2 As String = Join(stt1, "|")
            If InStr(stt2, "/01|") <> 0 Then
                lisMoveMah.Add(Pro.SalMahRoz366.IndexOf(stt1(0)))
            End If

        Next


        '  Dim a = Pro.SalMahRoz366.Select(Of

        'Dim kDate As Date = DirectCast(myDate, Date).AddDays(-Val(spl(2) - 1)).DayOfWeek
        Pro.ToDay = Val(spl(2))
        Exit Function
        Dim fIdx As Byte = IIf((DirectCast(myDate, Date).AddDays(-Val(spl(2) - 1)).DayOfWeek + -6) < 0, DirectCast(myDate, Date).AddDays(-Val(spl(2) - 1)).DayOfWeek + 1, DirectCast(myDate, Date).AddDays(-Val(spl(2) - 1)).DayOfWeek + -6)  ' Mod 7
        Pro.FirstPositionIdx = fIdx

        idxOf = Pro.SalMahRoz366.IndexOf(Format(Pro.Sal, "00") & "/" & Format(Pro.Mah, "00") & "/01")
        Dim sAt As Integer = idxOf - fIdx
        For a = sAt To sAt + 41
            Pro.Days.Add(Split(Pro.SalMahRoz366(a), "/")(2))
        Next


        'Dim isLab As Boolean = Date.IsLeapYear(2052)

        If fIdx > 0 Then
            Dim StartDey As Integer = IIf(Pro.IsLeapYear = False, 30, 29) - fIdx
            Pro.Days.Clear()
            Dim bitMahGhabl As Boolean = False
            For a = 0 To 42
                StartDey += 1
                If (bitMahGhabl = False AndAlso StartDey > IIf(Pro.IsLeapYear = False, 30, 29)) Then
                    StartDey = 1
                    bitMahGhabl = True
                ElseIf spl(1) = 12 And StartDey > IIf(Pro.IsLeapYear, 30, 29) Then
                    StartDey = 1
                ElseIf (spl(1) >= 7 And spl(1) <= 11) And StartDey > 30 Then
                    StartDey = 1
                ElseIf (spl(1) >= 1 And spl(1) <= 6) And StartDey > 31 Then '31
                    StartDey = 1
                End If

                Pro.Days.Add(StartDey.ToString)
            Next

        Else
            Dim StartDey As Integer = 0 ' IIf(Pro.IsLeapYear = False, 30, 29) - fIdx
            Pro.Days.Clear()
            Dim bitMahGhabl As Boolean = False
            For a = 0 To 42
                StartDey += 1
                If spl(1) = 12 And StartDey > IIf(Pro.IsLeapYear, 30, 29) Then
                    StartDey = 1
                ElseIf (spl(1) >= 7 And spl(1) <= 11) And StartDey > 30 Then
                    StartDey = 1
                ElseIf (spl(1) >= 1 And spl(1) <= 6) And StartDey > 31 Then '31
                    StartDey = 1
                End If
                Pro.Days.Add(StartDey.ToString)
            Next
        End If

        If spl(1) = 12 Then
            'if Sal Kabise 29 else 30
            Pro.CountRozCourrentMah = IIf(Pro.IsLeapYear, 30, 29)
        ElseIf spl(1) >= 1 And spl(1) <= 6 Then
            Pro.CountRozCourrentMah = 31
        Else
            Pro.CountRozCourrentMah = 30
        End If





    End Function
    Function m2s(myDate As Object, Optional FormatDate As mFormatDate = 0)
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
        Select Case FormatDate
            Case mFormatDate.SalMahRoz
                m2s = Format(iYear, "00") & "/" & Format(iMonth, "00") & "/" & Format(iDay, "00")
               ' m2s = Mid(Val(iYear).ToString, 2) & "/" & sMah & "/" & sRoz
            Case mFormatDate.Sal3MahRoz
                m2s = Mid(Format(iYear, "00"), 2) & "/" & Format(iMonth, "00") & "/" & Format(iDay, "00")
               ' m2s = sal & "/" & sMah & "/" & sRoz
            Case mFormatDate.Sal2MahRoz
                m2s = Mid(Format(iYear, "00"), 3) & "/" & Format(iMonth, "00") & "/" & Format(iDay, "00")
              '  m2s = iYear & "/" & iMonth & "/" & iDay ' & " " & horofi(iDay) & " " & mah & " " & ChrW(1605) & ChrW(1575) & ChrW(1607) & " " & horofi(iYear)
            Case mFormatDate.Only_Mah
                m2s = Format(iMonth, "00")
              '  m2s = Rooz & "," & iYear & "/" & iMonth & "/" & iDay
            Case mFormatDate.Only_Roz
                m2s = Format(iDay, "00")
                'm2s = sal & "/" & iMonth & "/" & iDay
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
            jdn1 = persian_jdn(iYear1, iMonth1, iDay1, False)
            jdn = persian_jdn(iYear, iMonth, iDay, False)
            If jdn1 = jdn Then s2m = "Error" : Exit Function
        End If

        jdn = persian_jdn(iYear, iMonth, iDay, False)
        Call jdn_civil(jdn, iYear, iMonth, iDay)
        s2m = iYear & "/" & iMonth & "/" & iDay
    End Function


    '
    ' Determine Julian day from Persian date
    '
    Function persian_jdn(iYear, iMonth, iDay, ForDay)
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
            If ForDay Then
                CountDaysOfM = (CLng(iMonth)) * 31 ' IIf(mdays = 0, 30, 31)
            End If

        Else
            If ForDay Then
                CountDaysOfM = (CLng(iMonth)) * 30 + 6
            End If
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
        depoch = jdn - persian_jdn(475, 1, 1, False)
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
        yday = (jdn - persian_jdn(iYear, 1, 1, False)) + 1
        CountSal = yday
        If yday <= 186 Then
            iMonth = Ceil(yday / 31)
        Else
            iMonth = Ceil((yday - 6) / 30)
        End If
        iDay = (jdn - persian_jdn(iYear, iMonth, 1, True)) + 1
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


End Class