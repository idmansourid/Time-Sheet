Imports System.Runtime.InteropServices
Imports System.Windows.Forms

Public Class frmValidOfColumn
    Public selectForm As New Object
    Public Event _List_SelectedIndexChanged(sender As frmValidOfColumn, OnDgv As uDgv)
    Public Event _List_DoubleClickIfNotError(sender As frmValidOfColumn, OnDgv As uDgv)
    Public IsError As Boolean
    ' Public ErrorColor As colo
#Region "__________________________Move And Resize Form"
    Public Enum ResizeDirection
        None = 0
        Left = 1
        TopLeft = 2
        Top = 3
        TopRight = 4
        Right = 5
        BottomRight = 6
        Bottom = 7
        BottomLeft = 8
    End Enum
    Private _resizeDir As ResizeDirection = ResizeDirection.None
    Private Const WM_NCLBUTTONDOWN As Integer = &HA1
    Private Const HTBORDER As Integer = 18
    Private Const HTBOTTOM As Integer = 15
    Private Const HTBOTTOMLEFT As Integer = 16
    Private Const HTBOTTOMRIGHT As Integer = 17
    Private Const HTCAPTION As Integer = 2
    Private Const HTLEFT As Integer = 10
    Private Const HTRIGHT As Integer = 11
    Private Const HTTOP As Integer = 12
    Private Const HTTOPLEFT As Integer = 13
    Private Const HTTOPRIGHT As Integer = 14
    <System.Runtime.InteropServices.DllImport("user32.dll")>
    Public Shared Function ReleaseCapture() As Boolean
    End Function
    <System.Runtime.InteropServices.DllImport("user32.dll")>
    Public Shared Function SendMessage(ByVal hWnd As IntPtr, ByVal Msg As Integer, ByVal wParam As Integer, ByVal lParam As Integer) As Integer
    End Function
    Private Sub MoveForm(inObj As Object)
        ReleaseCapture()
        SendMessage(Me.Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0)
    End Sub
    Private Sub pnlMove_MouseDown(sender As Object, e As MouseEventArgs) Handles ToolStrip1.MouseDown ', lblLeftRight.MouseDown ', lblSheetName.MouseDown ',lstValidtion.MouseDown,trvValidtion.MouseDown
        MoveForm(sender)
    End Sub
    Private Sub ResizeForm(ByVal direction As ResizeDirection)
        'Dim Lbls As Label() = {lblD, lblL, lblLD, lblLU, lblR, lblRD, lblRU, lblU}
        'Lbls.ToList.ForEach(Sub(f) f.Dock = DockStyle.Fill)
        Dim dir As Integer = -1
        Select Case direction
            Case ResizeDirection.Left
                dir = HTLEFT
            Case ResizeDirection.TopLeft
                dir = HTTOPLEFT
            Case ResizeDirection.Top
                dir = HTTOP
            Case ResizeDirection.TopRight
                dir = HTTOPRIGHT
            Case ResizeDirection.Right
                dir = HTRIGHT
            Case ResizeDirection.BottomRight
                dir = HTBOTTOMRIGHT
            Case ResizeDirection.Bottom
                dir = HTBOTTOM
            Case ResizeDirection.BottomLeft
                dir = HTBOTTOMLEFT
        End Select

        If dir <> -1 Then
            ReleaseCapture()

            SendMessage(Me.Handle, WM_NCLBUTTONDOWN, dir, 0)
        End If
    End Sub
    Private Sub ResizeFormBy6Event(sender As Object, e As MouseEventArgs) Handles lblL.MouseDown, lblR.MouseDown, lblD.MouseDown, lblRD.MouseDown, lblLD.MouseDown ', lblLeftRight.MouseDown
        Dim dir As ResizeDirection
        Select Case sender.name
            Case "lblL"
                dir = ResizeDirection.Left
            Case "lblR"
                dir = ResizeDirection.Right
            Case "lblU"
                dir = ResizeDirection.Top
            Case "lblD"
                dir = ResizeDirection.Bottom
            Case "lblRD"
                dir = ResizeDirection.BottomRight
            Case "lblLD"
                dir = ResizeDirection.BottomLeft
            Case "lblLeftRight"
                '  dir = ResizeDirection.Right
        End Select
        If e.Button = MouseButtons.Left And Me.WindowState <> FormWindowState.Maximized Then
            ResizeForm(dir)
        End If
    End Sub
#End Region
    Public dgv As uDgv

    Private Sub frmValidOfColumn_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim Lbls As Label() = {lblD, lblL, lblLD, lblLU, lblR, lblRD, lblRU, lblU}
        Lbls.ToList.ForEach(Sub(f) f.Dock = DockStyle.Fill)
        lstFiltered.Dock = DockStyle.Fill
        trvFiltered.Dock = DockStyle.Fill
        lstFiltered.Show()
        trvFiltered.Hide()
    End Sub

    Private Sub TableLayoutPanel1_Paint(sender As Object, e As PaintEventArgs) Handles TableLayoutPanel1.Paint

    End Sub

    Private Sub tsm_List_Click(sender As Object, e As EventArgs) Handles tsm_List.Click
        lstFiltered.Show()
        trvFiltered.Hide()
    End Sub

    Private Sub tsm_Tree_Click(sender As Object, e As EventArgs) Handles tsm_Tree.Click
        lstFiltered.Hide()
        trvFiltered.Show()
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub frmValidOfColumn_Deactivate(sender As Object, e As EventArgs) Handles Me.Deactivate
        '  Me.Hide()
    End Sub

    Private Sub lstFiltered_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstFiltered.SelectedIndexChanged
        RaiseEvent _List_SelectedIndexChanged(Me, dgv)
    End Sub

    Private Sub lstFiltered_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles lstFiltered.MouseDoubleClick
        If IsError Then Exit Sub
        RaiseEvent _List_DoubleClickIfNotError(Me, dgv)
    End Sub
End Class