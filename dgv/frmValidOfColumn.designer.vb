Imports System.Windows.Forms

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmValidOfColumn
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmValidOfColumn))
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.lblU = New System.Windows.Forms.Label()
        Me.lblLU = New System.Windows.Forms.Label()
        Me.lblRU = New System.Windows.Forms.Label()
        Me.lblLD = New System.Windows.Forms.Label()
        Me.lblRD = New System.Windows.Forms.Label()
        Me.lblR = New System.Windows.Forms.Label()
        Me.lblD = New System.Windows.Forms.Label()
        Me.lblL = New System.Windows.Forms.Label()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.tsb_View = New System.Windows.Forms.ToolStripDropDownButton()
        Me.tsm_List = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsm_Tree = New System.Windows.Forms.ToolStripMenuItem()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.trvFiltered = New System.Windows.Forms.TreeView()
        Me.lstFiltered = New System.Windows.Forms.ListBox()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 3
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 3.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 3.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.lblU, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lblLU, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lblRU, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lblLD, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.lblRD, 2, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.lblR, 2, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.lblD, 1, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.lblL, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.ToolStrip1, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel1, 1, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 4
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 3.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 3.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(191, 233)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'lblU
        '
        Me.lblU.BackColor = System.Drawing.Color.CadetBlue
        Me.lblU.Location = New System.Drawing.Point(3, 0)
        Me.lblU.Margin = New System.Windows.Forms.Padding(0)
        Me.lblU.Name = "lblU"
        Me.lblU.Size = New System.Drawing.Size(17, 3)
        Me.lblU.TabIndex = 13
        '
        'lblLU
        '
        Me.lblLU.BackColor = System.Drawing.Color.Lime
        Me.lblLU.Cursor = System.Windows.Forms.Cursors.SizeNWSE
        Me.lblLU.Location = New System.Drawing.Point(0, 0)
        Me.lblLU.Margin = New System.Windows.Forms.Padding(0)
        Me.lblLU.Name = "lblLU"
        Me.lblLU.Size = New System.Drawing.Size(3, 3)
        Me.lblLU.TabIndex = 16
        '
        'lblRU
        '
        Me.lblRU.BackColor = System.Drawing.Color.Lime
        Me.lblRU.Cursor = System.Windows.Forms.Cursors.SizeNESW
        Me.lblRU.Location = New System.Drawing.Point(188, 0)
        Me.lblRU.Margin = New System.Windows.Forms.Padding(0)
        Me.lblRU.Name = "lblRU"
        Me.lblRU.Size = New System.Drawing.Size(3, 3)
        Me.lblRU.TabIndex = 15
        '
        'lblLD
        '
        Me.lblLD.BackColor = System.Drawing.Color.Lime
        Me.lblLD.Cursor = System.Windows.Forms.Cursors.SizeNESW
        Me.lblLD.Location = New System.Drawing.Point(0, 230)
        Me.lblLD.Margin = New System.Windows.Forms.Padding(0)
        Me.lblLD.Name = "lblLD"
        Me.lblLD.Size = New System.Drawing.Size(3, 3)
        Me.lblLD.TabIndex = 19
        '
        'lblRD
        '
        Me.lblRD.BackColor = System.Drawing.Color.Lime
        Me.lblRD.Cursor = System.Windows.Forms.Cursors.SizeNWSE
        Me.lblRD.Location = New System.Drawing.Point(188, 230)
        Me.lblRD.Margin = New System.Windows.Forms.Padding(0)
        Me.lblRD.Name = "lblRD"
        Me.lblRD.Size = New System.Drawing.Size(3, 3)
        Me.lblRD.TabIndex = 17
        '
        'lblR
        '
        Me.lblR.BackColor = System.Drawing.Color.CadetBlue
        Me.lblR.Cursor = System.Windows.Forms.Cursors.SizeWE
        Me.lblR.Location = New System.Drawing.Point(188, 3)
        Me.lblR.Margin = New System.Windows.Forms.Padding(0)
        Me.lblR.Name = "lblR"
        Me.TableLayoutPanel1.SetRowSpan(Me.lblR, 2)
        Me.lblR.Size = New System.Drawing.Size(3, 157)
        Me.lblR.TabIndex = 20
        '
        'lblD
        '
        Me.lblD.BackColor = System.Drawing.Color.CadetBlue
        Me.lblD.Cursor = System.Windows.Forms.Cursors.SizeNS
        Me.lblD.Location = New System.Drawing.Point(3, 230)
        Me.lblD.Margin = New System.Windows.Forms.Padding(0)
        Me.lblD.Name = "lblD"
        Me.lblD.Size = New System.Drawing.Size(40, 3)
        Me.lblD.TabIndex = 21
        '
        'lblL
        '
        Me.lblL.BackColor = System.Drawing.Color.CadetBlue
        Me.lblL.Cursor = System.Windows.Forms.Cursors.SizeWE
        Me.lblL.Location = New System.Drawing.Point(0, 3)
        Me.lblL.Margin = New System.Windows.Forms.Padding(0)
        Me.lblL.Name = "lblL"
        Me.TableLayoutPanel1.SetRowSpan(Me.lblL, 2)
        Me.lblL.Size = New System.Drawing.Size(3, 157)
        Me.lblL.TabIndex = 22
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.Linen
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsb_View})
        Me.ToolStrip1.Location = New System.Drawing.Point(3, 210)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(185, 20)
        Me.ToolStrip1.TabIndex = 23
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'tsb_View
        '
        Me.tsb_View.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsb_View.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsm_List, Me.tsm_Tree})
        Me.tsb_View.Image = CType(resources.GetObject("tsb_View.Image"), System.Drawing.Image)
        Me.tsb_View.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsb_View.Name = "tsb_View"
        Me.tsb_View.Size = New System.Drawing.Size(45, 17)
        Me.tsb_View.Text = "View"
        '
        'tsm_List
        '
        Me.tsm_List.Name = "tsm_List"
        Me.tsm_List.Size = New System.Drawing.Size(125, 22)
        Me.tsm_List.Text = "List"
        '
        'tsm_Tree
        '
        Me.tsm_Tree.Name = "tsm_Tree"
        Me.tsm_Tree.Size = New System.Drawing.Size(125, 22)
        Me.tsm_Tree.Text = "Tree View"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.trvFiltered)
        Me.Panel1.Controls.Add(Me.lstFiltered)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(3, 3)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(185, 207)
        Me.Panel1.TabIndex = 24
        '
        'trvFiltered
        '
        Me.trvFiltered.Location = New System.Drawing.Point(44, 26)
        Me.trvFiltered.Margin = New System.Windows.Forms.Padding(0)
        Me.trvFiltered.Name = "trvFiltered"
        Me.trvFiltered.Size = New System.Drawing.Size(121, 97)
        Me.trvFiltered.TabIndex = 26
        '
        'lstFiltered
        '
        Me.lstFiltered.FormattingEnabled = True
        Me.lstFiltered.Location = New System.Drawing.Point(-3, 51)
        Me.lstFiltered.Margin = New System.Windows.Forms.Padding(0)
        Me.lstFiltered.Name = "lstFiltered"
        Me.lstFiltered.Size = New System.Drawing.Size(126, 82)
        Me.lstFiltered.TabIndex = 25
        '
        'frmValidOfColumn
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(191, 233)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmValidOfColumn"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "frmValidOfColumn"
        Me.TopMost = True
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents lblU As Label
    Friend WithEvents lblLU As Label
    Friend WithEvents lblRU As Label
    Friend WithEvents lblLD As Label
    Friend WithEvents lblRD As Label
    Friend WithEvents lblR As Label
    Friend WithEvents lblD As Label
    Friend WithEvents lblL As Label
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents Panel1 As Panel
    Friend WithEvents tsb_View As ToolStripDropDownButton
    Friend WithEvents tsm_List As ToolStripMenuItem
    Friend WithEvents tsm_Tree As ToolStripMenuItem
    Public WithEvents trvFiltered As TreeView
    Public WithEvents lstFiltered As ListBox
End Class
