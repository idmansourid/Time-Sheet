<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmMain
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.cms_BaseData = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.tsmImportData = New System.Windows.Forms.ToolStripMenuItem()
        Me.cms_qBaseItemsP = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.tsm_Update = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsm_BaseLocations = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmNonSelectAll = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmSelectAllHigh = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmImportMainData = New System.Windows.Forms.ToolStripMenuItem()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.txtCurrentCell = New System.Windows.Forms.TextBox()
        Me.txtSearch = New System.Windows.Forms.TextBox()
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.TableLayoutPanel8 = New System.Windows.Forms.TableLayoutPanel()
        Me.tabBase = New System.Windows.Forms.TabControl()
        Me.TabPage9 = New System.Windows.Forms.TabPage()
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
        Me.TableLayoutPanel9 = New System.Windows.Forms.TableLayoutPanel()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ts_WorkGroup = New System.Windows.Forms.ToolStripDropDownButton()
        Me.tsmCheckGroup = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsm_ExpandAll = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsm_CollapseAll = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmEditTrvGrouping = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ts_GetText = New System.Windows.Forms.ToolStripTextBox()
        Me.ts_Rename = New System.Windows.Forms.ToolStripButton()
        Me.ts_AddGroup = New System.Windows.Forms.ToolStripButton()
        Me.ts_CopyGroup = New System.Windows.Forms.ToolStripButton()
        Me.ts_DeleteGroup = New System.Windows.Forms.ToolStripButton()
        Me.ts_EditGroup = New System.Windows.Forms.ToolStripButton()
        Me.trvGrouping = New System.Windows.Forms.TreeView()
        Me.lstChackGroup = New System.Windows.Forms.ListBox()
        Me.dgv_BaseGrouping = New dgv.uDgv()
        Me.TabPage10 = New System.Windows.Forms.TabPage()
        Me.TableLayoutPanel5 = New System.Windows.Forms.TableLayoutPanel()
        Me.dgv_BaseLocations = New dgv.uDgv()
        Me.ToolStrip2 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripDropDownButton1 = New System.Windows.Forms.ToolStripDropDownButton()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.tlpMainData = New System.Windows.Forms.TableLayoutPanel()
        Me.lblLeftRight = New System.Windows.Forms.Label()
        Me.TabControl2 = New System.Windows.Forms.TabControl()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.TableLayoutPanel6 = New System.Windows.Forms.TableLayoutPanel()
        Me.lstGrouping = New System.Windows.Forms.ListBox()
        Me.comSubMain = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.comMain = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TabPage4 = New System.Windows.Forms.TabPage()
        Me.lstFiltering = New System.Windows.Forms.ListBox()
        Me.TabPage5 = New System.Windows.Forms.TabPage()
        Me.trvFind = New System.Windows.Forms.TreeView()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.TabControl3 = New System.Windows.Forms.TabControl()
        Me.TabPage6 = New System.Windows.Forms.TabPage()
        Me.TableLayoutPanel7 = New System.Windows.Forms.TableLayoutPanel()
        Me.lstLocations = New System.Windows.Forms.ListBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.com_Area = New System.Windows.Forms.ComboBox()
        Me.TabPage7 = New System.Windows.Forms.TabPage()
        Me.lstResult = New System.Windows.Forms.ListBox()
        Me.TableLayoutPanel4 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.dgv_qMainData = New dgv.uDgv()
        Me.TabPage8 = New System.Windows.Forms.TabPage()
        Me.TableLayoutPanel10 = New System.Windows.Forms.TableLayoutPanel()
        Me.TabControl4 = New System.Windows.Forms.TabControl()
        Me.TabPage11 = New System.Windows.Forms.TabPage()
        Me.TabPage12 = New System.Windows.Forms.TabPage()
        Me.dgv_qMivMrv = New dgv.uDgv()
        Me.dgv2_qMainData = New dgv.uDgv()
        Me.ToolStrip3 = New System.Windows.Forms.ToolStrip()
        Me.cms_AddGroping = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.tsmAddChild = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmAddOnParent = New System.Windows.Forms.ToolStripMenuItem()
        Me.staMain = New System.Windows.Forms.StatusStrip()
        Me.tssb1 = New System.Windows.Forms.ToolStripSplitButton()
        Me.tsm2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.lblTssStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.ToolStrip4 = New System.Windows.Forms.ToolStrip()
        Me.trvGroupingMiv = New System.Windows.Forms.TreeView()
        Me.cms_BaseData.SuspendLayout()
        Me.cms_qBaseItemsP.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TableLayoutPanel8.SuspendLayout()
        Me.tabBase.SuspendLayout()
        Me.TabPage9.SuspendLayout()
        Me.TableLayoutPanel3.SuspendLayout()
        Me.TableLayoutPanel9.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.TabPage10.SuspendLayout()
        Me.TableLayoutPanel5.SuspendLayout()
        Me.ToolStrip2.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.tlpMainData.SuspendLayout()
        Me.TabControl2.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.TableLayoutPanel6.SuspendLayout()
        Me.TabPage4.SuspendLayout()
        Me.TabPage5.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.TabControl3.SuspendLayout()
        Me.TabPage6.SuspendLayout()
        Me.TableLayoutPanel7.SuspendLayout()
        Me.TabPage7.SuspendLayout()
        Me.TableLayoutPanel4.SuspendLayout()
        Me.TabPage8.SuspendLayout()
        Me.TableLayoutPanel10.SuspendLayout()
        Me.TabControl4.SuspendLayout()
        Me.cms_AddGroping.SuspendLayout()
        Me.staMain.SuspendLayout()
        Me.SuspendLayout()
        '
        'cms_BaseData
        '
        Me.cms_BaseData.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmImportData})
        Me.cms_BaseData.Name = "cmsBaseData"
        Me.cms_BaseData.Size = New System.Drawing.Size(188, 26)
        '
        'tsmImportData
        '
        Me.tsmImportData.Name = "tsmImportData"
        Me.tsmImportData.Size = New System.Drawing.Size(187, 22)
        Me.tsmImportData.Text = "Import Data Excel File"
        '
        'cms_qBaseItemsP
        '
        Me.cms_qBaseItemsP.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsm_Update, Me.tsm_BaseLocations, Me.tsmNonSelectAll, Me.tsmSelectAllHigh, Me.tsmImportMainData})
        Me.cms_qBaseItemsP.Name = "cmsBaseData"
        Me.cms_qBaseItemsP.Size = New System.Drawing.Size(188, 114)
        '
        'tsm_Update
        '
        Me.tsm_Update.Name = "tsm_Update"
        Me.tsm_Update.Size = New System.Drawing.Size(187, 22)
        Me.tsm_Update.Text = "Update Select"
        '
        'tsm_BaseLocations
        '
        Me.tsm_BaseLocations.Name = "tsm_BaseLocations"
        Me.tsm_BaseLocations.Size = New System.Drawing.Size(187, 22)
        Me.tsm_BaseLocations.Text = "Base Locations"
        '
        'tsmNonSelectAll
        '
        Me.tsmNonSelectAll.Name = "tsmNonSelectAll"
        Me.tsmNonSelectAll.Size = New System.Drawing.Size(187, 22)
        Me.tsmNonSelectAll.Text = "Non Select All"
        '
        'tsmSelectAllHigh
        '
        Me.tsmSelectAllHigh.BackColor = System.Drawing.SystemColors.Control
        Me.tsmSelectAllHigh.Name = "tsmSelectAllHigh"
        Me.tsmSelectAllHigh.Size = New System.Drawing.Size(187, 22)
        Me.tsmSelectAllHigh.Text = "Select All Highlight"
        '
        'tsmImportMainData
        '
        Me.tsmImportMainData.Name = "tsmImportMainData"
        Me.tsmImportMainData.Size = New System.Drawing.Size(187, 22)
        Me.tsmImportMainData.Text = "Import Data Excel File"
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Panel1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.TabControl1, 0, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(848, 403)
        Me.TableLayoutPanel1.TabIndex = 2
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.txtCurrentCell)
        Me.Panel1.Controls.Add(Me.txtSearch)
        Me.Panel1.Controls.Add(Me.ListBox1)
        Me.Panel1.Controls.Add(Me.Button1)
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(720, 40)
        Me.Panel1.TabIndex = 2
        '
        'txtCurrentCell
        '
        Me.txtCurrentCell.Location = New System.Drawing.Point(15, 7)
        Me.txtCurrentCell.Name = "txtCurrentCell"
        Me.txtCurrentCell.Size = New System.Drawing.Size(100, 20)
        Me.txtCurrentCell.TabIndex = 2
        '
        'txtSearch
        '
        Me.txtSearch.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtSearch.Location = New System.Drawing.Point(461, 5)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(182, 20)
        Me.txtSearch.TabIndex = 0
        '
        'ListBox1
        '
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.Location = New System.Drawing.Point(72, 5)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(271, 17)
        Me.ListBox1.TabIndex = 1
        Me.ListBox1.Visible = False
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(365, 3)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        Me.Button1.Visible = False
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage8)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(0, 40)
        Me.TabControl1.Margin = New System.Windows.Forms.Padding(0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(848, 363)
        Me.TabControl1.TabIndex = 3
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.TableLayoutPanel8)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Margin = New System.Windows.Forms.Padding(0)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Size = New System.Drawing.Size(840, 337)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Bases"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel8
        '
        Me.TableLayoutPanel8.ColumnCount = 1
        Me.TableLayoutPanel8.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel8.Controls.Add(Me.tabBase, 0, 1)
        Me.TableLayoutPanel8.Controls.Add(Me.ToolStrip2, 0, 0)
        Me.TableLayoutPanel8.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel8.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel8.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutPanel8.Name = "TableLayoutPanel8"
        Me.TableLayoutPanel8.RowCount = 2
        Me.TableLayoutPanel8.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26.0!))
        Me.TableLayoutPanel8.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel8.Size = New System.Drawing.Size(840, 337)
        Me.TableLayoutPanel8.TabIndex = 2
        '
        'tabBase
        '
        Me.tabBase.Appearance = System.Windows.Forms.TabAppearance.FlatButtons
        Me.tabBase.Controls.Add(Me.TabPage9)
        Me.tabBase.Controls.Add(Me.TabPage10)
        Me.tabBase.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tabBase.Location = New System.Drawing.Point(0, 26)
        Me.tabBase.Margin = New System.Windows.Forms.Padding(0)
        Me.tabBase.Name = "tabBase"
        Me.tabBase.SelectedIndex = 0
        Me.tabBase.Size = New System.Drawing.Size(840, 311)
        Me.tabBase.TabIndex = 1
        '
        'TabPage9
        '
        Me.TabPage9.Controls.Add(Me.TableLayoutPanel3)
        Me.TabPage9.Location = New System.Drawing.Point(4, 25)
        Me.TabPage9.Margin = New System.Windows.Forms.Padding(0)
        Me.TabPage9.Name = "TabPage9"
        Me.TabPage9.Size = New System.Drawing.Size(832, 282)
        Me.TabPage9.TabIndex = 0
        Me.TabPage9.Text = "Base Grouping"
        Me.TabPage9.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.ColumnCount = 2
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35.67839!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 64.32161!))
        Me.TableLayoutPanel3.Controls.Add(Me.TableLayoutPanel9, 0, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.dgv_BaseGrouping, 1, 0)
        Me.TableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel3.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 2
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 91.52542!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.474576!))
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(832, 282)
        Me.TableLayoutPanel3.TabIndex = 0
        '
        'TableLayoutPanel9
        '
        Me.TableLayoutPanel9.ColumnCount = 1
        Me.TableLayoutPanel9.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel9.Controls.Add(Me.ToolStrip1, 0, 0)
        Me.TableLayoutPanel9.Controls.Add(Me.trvGrouping, 0, 1)
        Me.TableLayoutPanel9.Controls.Add(Me.lstChackGroup, 0, 2)
        Me.TableLayoutPanel9.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel9.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel9.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutPanel9.Name = "TableLayoutPanel9"
        Me.TableLayoutPanel9.RowCount = 3
        Me.TableLayoutPanel9.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29.0!))
        Me.TableLayoutPanel9.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 66.66666!))
        Me.TableLayoutPanel9.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel9.Size = New System.Drawing.Size(296, 258)
        Me.TableLayoutPanel9.TabIndex = 1
        '
        'ToolStrip1
        '
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ts_WorkGroup, Me.ToolStripSeparator1, Me.ts_GetText, Me.ts_Rename, Me.ts_AddGroup, Me.ts_CopyGroup, Me.ts_DeleteGroup, Me.ts_EditGroup})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(296, 25)
        Me.ToolStrip1.TabIndex = 0
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ts_WorkGroup
        '
        Me.ts_WorkGroup.AutoToolTip = False
        Me.ts_WorkGroup.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ts_WorkGroup.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmCheckGroup, Me.tsm_ExpandAll, Me.tsm_CollapseAll, Me.tsmEditTrvGrouping})
        Me.ts_WorkGroup.Image = CType(resources.GetObject("ts_WorkGroup.Image"), System.Drawing.Image)
        Me.ts_WorkGroup.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ts_WorkGroup.Name = "ts_WorkGroup"
        Me.ts_WorkGroup.Size = New System.Drawing.Size(23, 22)
        Me.ts_WorkGroup.Text = " "
        '
        'tsmCheckGroup
        '
        Me.tsmCheckGroup.Name = "tsmCheckGroup"
        Me.tsmCheckGroup.Size = New System.Drawing.Size(136, 22)
        Me.tsmCheckGroup.Text = "Chack"
        '
        'tsm_ExpandAll
        '
        Me.tsm_ExpandAll.Name = "tsm_ExpandAll"
        Me.tsm_ExpandAll.Size = New System.Drawing.Size(136, 22)
        Me.tsm_ExpandAll.Text = "Expand All"
        '
        'tsm_CollapseAll
        '
        Me.tsm_CollapseAll.Name = "tsm_CollapseAll"
        Me.tsm_CollapseAll.Size = New System.Drawing.Size(136, 22)
        Me.tsm_CollapseAll.Text = "Collapse All"
        '
        'tsmEditTrvGrouping
        '
        Me.tsmEditTrvGrouping.Name = "tsmEditTrvGrouping"
        Me.tsmEditTrvGrouping.Size = New System.Drawing.Size(136, 22)
        Me.tsmEditTrvGrouping.Text = "Edit"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'ts_GetText
        '
        Me.ts_GetText.BackColor = System.Drawing.Color.PapayaWhip
        Me.ts_GetText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ts_GetText.Name = "ts_GetText"
        Me.ts_GetText.Size = New System.Drawing.Size(120, 25)
        '
        'ts_Rename
        '
        Me.ts_Rename.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ts_Rename.Image = CType(resources.GetObject("ts_Rename.Image"), System.Drawing.Image)
        Me.ts_Rename.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ts_Rename.Name = "ts_Rename"
        Me.ts_Rename.Size = New System.Drawing.Size(54, 22)
        Me.ts_Rename.Text = "Rename"
        Me.ts_Rename.Visible = False
        '
        'ts_AddGroup
        '
        Me.ts_AddGroup.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ts_AddGroup.Image = CType(resources.GetObject("ts_AddGroup.Image"), System.Drawing.Image)
        Me.ts_AddGroup.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ts_AddGroup.Name = "ts_AddGroup"
        Me.ts_AddGroup.Size = New System.Drawing.Size(64, 22)
        Me.ts_AddGroup.Text = "Add Child"
        Me.ts_AddGroup.Visible = False
        '
        'ts_CopyGroup
        '
        Me.ts_CopyGroup.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ts_CopyGroup.Image = CType(resources.GetObject("ts_CopyGroup.Image"), System.Drawing.Image)
        Me.ts_CopyGroup.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ts_CopyGroup.Name = "ts_CopyGroup"
        Me.ts_CopyGroup.Size = New System.Drawing.Size(39, 22)
        Me.ts_CopyGroup.Text = "Copy"
        Me.ts_CopyGroup.Visible = False
        '
        'ts_DeleteGroup
        '
        Me.ts_DeleteGroup.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ts_DeleteGroup.Image = CType(resources.GetObject("ts_DeleteGroup.Image"), System.Drawing.Image)
        Me.ts_DeleteGroup.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ts_DeleteGroup.Name = "ts_DeleteGroup"
        Me.ts_DeleteGroup.Size = New System.Drawing.Size(44, 22)
        Me.ts_DeleteGroup.Text = "Delete"
        Me.ts_DeleteGroup.Visible = False
        '
        'ts_EditGroup
        '
        Me.ts_EditGroup.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ts_EditGroup.Image = CType(resources.GetObject("ts_EditGroup.Image"), System.Drawing.Image)
        Me.ts_EditGroup.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ts_EditGroup.Name = "ts_EditGroup"
        Me.ts_EditGroup.Size = New System.Drawing.Size(31, 22)
        Me.ts_EditGroup.Text = "Edit"
        '
        'trvGrouping
        '
        Me.trvGrouping.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.trvGrouping.Dock = System.Windows.Forms.DockStyle.Fill
        Me.trvGrouping.FullRowSelect = True
        Me.trvGrouping.HideSelection = False
        Me.trvGrouping.HotTracking = True
        Me.trvGrouping.LabelEdit = True
        Me.trvGrouping.Location = New System.Drawing.Point(0, 29)
        Me.trvGrouping.Margin = New System.Windows.Forms.Padding(0)
        Me.trvGrouping.Name = "trvGrouping"
        Me.trvGrouping.Size = New System.Drawing.Size(296, 152)
        Me.trvGrouping.TabIndex = 1
        '
        'lstChackGroup
        '
        Me.lstChackGroup.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lstChackGroup.FormattingEnabled = True
        Me.lstChackGroup.Location = New System.Drawing.Point(0, 181)
        Me.lstChackGroup.Margin = New System.Windows.Forms.Padding(0)
        Me.lstChackGroup.Name = "lstChackGroup"
        Me.lstChackGroup.Size = New System.Drawing.Size(296, 77)
        Me.lstChackGroup.TabIndex = 2
        '
        'dgv_BaseGrouping
        '
        Me.dgv_BaseGrouping.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgv_BaseGrouping.Location = New System.Drawing.Point(296, 0)
        Me.dgv_BaseGrouping.Margin = New System.Windows.Forms.Padding(0)
        Me.dgv_BaseGrouping.Name = "dgv_BaseGrouping"
        Me.TableLayoutPanel3.SetRowSpan(Me.dgv_BaseGrouping, 2)
        Me.dgv_BaseGrouping.Size = New System.Drawing.Size(536, 282)
        Me.dgv_BaseGrouping.TabIndex = 2
        '
        'TabPage10
        '
        Me.TabPage10.Controls.Add(Me.TableLayoutPanel5)
        Me.TabPage10.Location = New System.Drawing.Point(4, 25)
        Me.TabPage10.Margin = New System.Windows.Forms.Padding(0)
        Me.TabPage10.Name = "TabPage10"
        Me.TabPage10.Size = New System.Drawing.Size(832, 282)
        Me.TabPage10.TabIndex = 1
        Me.TabPage10.Text = "Base Locations"
        Me.TabPage10.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel5
        '
        Me.TableLayoutPanel5.ColumnCount = 1
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel5.Controls.Add(Me.dgv_BaseLocations, 0, 1)
        Me.TableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel5.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel5.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutPanel5.Name = "TableLayoutPanel5"
        Me.TableLayoutPanel5.RowCount = 2
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel5.Size = New System.Drawing.Size(832, 282)
        Me.TableLayoutPanel5.TabIndex = 1
        '
        'dgv_BaseLocations
        '
        Me.dgv_BaseLocations.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgv_BaseLocations.Location = New System.Drawing.Point(0, 20)
        Me.dgv_BaseLocations.Margin = New System.Windows.Forms.Padding(0)
        Me.dgv_BaseLocations.Name = "dgv_BaseLocations"
        Me.TableLayoutPanel5.SetRowSpan(Me.dgv_BaseLocations, 2)
        Me.dgv_BaseLocations.Size = New System.Drawing.Size(832, 262)
        Me.dgv_BaseLocations.TabIndex = 3
        '
        'ToolStrip2
        '
        Me.ToolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripDropDownButton1})
        Me.ToolStrip2.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip2.Name = "ToolStrip2"
        Me.ToolStrip2.Size = New System.Drawing.Size(840, 25)
        Me.ToolStrip2.TabIndex = 2
        Me.ToolStrip2.Text = "ToolStrip2"
        '
        'ToolStripDropDownButton1
        '
        Me.ToolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripDropDownButton1.Image = CType(resources.GetObject("ToolStripDropDownButton1.Image"), System.Drawing.Image)
        Me.ToolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripDropDownButton1.Name = "ToolStripDropDownButton1"
        Me.ToolStripDropDownButton1.Size = New System.Drawing.Size(29, 22)
        Me.ToolStripDropDownButton1.Text = "ToolStripDropDownButton1"
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.TableLayoutPanel2)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Margin = New System.Windows.Forms.Padding(0)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Size = New System.Drawing.Size(840, 337)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Main Data"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 1
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.tlpMainData, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.TableLayoutPanel4, 0, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.dgv_qMainData, 0, 2)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel2.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 3
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 186.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(840, 337)
        Me.TableLayoutPanel2.TabIndex = 2
        '
        'tlpMainData
        '
        Me.tlpMainData.ColumnCount = 3
        Me.tlpMainData.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 346.0!))
        Me.tlpMainData.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 3.0!))
        Me.tlpMainData.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpMainData.Controls.Add(Me.lblLeftRight, 1, 0)
        Me.tlpMainData.Controls.Add(Me.TabControl2, 2, 0)
        Me.tlpMainData.Controls.Add(Me.Panel3, 0, 0)
        Me.tlpMainData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpMainData.Location = New System.Drawing.Point(3, 3)
        Me.tlpMainData.Name = "tlpMainData"
        Me.tlpMainData.RowCount = 1
        Me.tlpMainData.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpMainData.Size = New System.Drawing.Size(834, 180)
        Me.tlpMainData.TabIndex = 1
        '
        'lblLeftRight
        '
        Me.lblLeftRight.BackColor = System.Drawing.Color.Chartreuse
        Me.lblLeftRight.Cursor = System.Windows.Forms.Cursors.SizeWE
        Me.lblLeftRight.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblLeftRight.Location = New System.Drawing.Point(346, 0)
        Me.lblLeftRight.Margin = New System.Windows.Forms.Padding(0)
        Me.lblLeftRight.Name = "lblLeftRight"
        Me.lblLeftRight.Size = New System.Drawing.Size(3, 180)
        Me.lblLeftRight.TabIndex = 0
        '
        'TabControl2
        '
        Me.TabControl2.Appearance = System.Windows.Forms.TabAppearance.Buttons
        Me.TabControl2.Controls.Add(Me.TabPage3)
        Me.TabControl2.Controls.Add(Me.TabPage4)
        Me.TabControl2.Controls.Add(Me.TabPage5)
        Me.TabControl2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl2.Location = New System.Drawing.Point(349, 0)
        Me.TabControl2.Margin = New System.Windows.Forms.Padding(0)
        Me.TabControl2.Name = "TabControl2"
        Me.TabControl2.SelectedIndex = 0
        Me.TabControl2.Size = New System.Drawing.Size(485, 180)
        Me.TabControl2.TabIndex = 0
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.TableLayoutPanel6)
        Me.TabPage3.Location = New System.Drawing.Point(4, 25)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(477, 151)
        Me.TabPage3.TabIndex = 0
        Me.TabPage3.Text = "List View"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel6
        '
        Me.TableLayoutPanel6.ColumnCount = 5
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 146.0!))
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60.0!))
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 154.0!))
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 77.0!))
        Me.TableLayoutPanel6.Controls.Add(Me.lstGrouping, 0, 1)
        Me.TableLayoutPanel6.Controls.Add(Me.comSubMain, 3, 0)
        Me.TableLayoutPanel6.Controls.Add(Me.Label1, 0, 0)
        Me.TableLayoutPanel6.Controls.Add(Me.comMain, 1, 0)
        Me.TableLayoutPanel6.Controls.Add(Me.Label2, 2, 0)
        Me.TableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel6.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel6.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutPanel6.Name = "TableLayoutPanel6"
        Me.TableLayoutPanel6.RowCount = 2
        Me.TableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel6.Size = New System.Drawing.Size(477, 151)
        Me.TableLayoutPanel6.TabIndex = 0
        '
        'lstGrouping
        '
        Me.TableLayoutPanel6.SetColumnSpan(Me.lstGrouping, 5)
        Me.lstGrouping.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lstGrouping.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstGrouping.FormattingEnabled = True
        Me.lstGrouping.ItemHeight = 16
        Me.lstGrouping.Location = New System.Drawing.Point(0, 25)
        Me.lstGrouping.Margin = New System.Windows.Forms.Padding(0)
        Me.lstGrouping.Name = "lstGrouping"
        Me.lstGrouping.Size = New System.Drawing.Size(477, 126)
        Me.lstGrouping.TabIndex = 0
        '
        'comSubMain
        '
        Me.comSubMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.comSubMain.FormattingEnabled = True
        Me.comSubMain.Location = New System.Drawing.Point(246, 0)
        Me.comSubMain.Margin = New System.Windows.Forms.Padding(0)
        Me.comSubMain.Name = "comSubMain"
        Me.comSubMain.Size = New System.Drawing.Size(154, 21)
        Me.comSubMain.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Margin = New System.Windows.Forms.Padding(0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 25)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Main :"
        '
        'comMain
        '
        Me.comMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.comMain.FormattingEnabled = True
        Me.comMain.Location = New System.Drawing.Point(40, 0)
        Me.comMain.Margin = New System.Windows.Forms.Padding(0)
        Me.comMain.Name = "comMain"
        Me.comMain.Size = New System.Drawing.Size(146, 21)
        Me.comMain.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(186, 0)
        Me.Label2.Margin = New System.Windows.Forms.Padding(0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(60, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Sub Main :"
        '
        'TabPage4
        '
        Me.TabPage4.Controls.Add(Me.lstFiltering)
        Me.TabPage4.Location = New System.Drawing.Point(4, 25)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage4.Size = New System.Drawing.Size(477, 151)
        Me.TabPage4.TabIndex = 1
        Me.TabPage4.Text = "Combo Box"
        Me.TabPage4.UseVisualStyleBackColor = True
        '
        'lstFiltering
        '
        Me.lstFiltering.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lstFiltering.FormattingEnabled = True
        Me.lstFiltering.Location = New System.Drawing.Point(3, 3)
        Me.lstFiltering.Name = "lstFiltering"
        Me.lstFiltering.Size = New System.Drawing.Size(471, 145)
        Me.lstFiltering.TabIndex = 1
        '
        'TabPage5
        '
        Me.TabPage5.Controls.Add(Me.trvFind)
        Me.TabPage5.Location = New System.Drawing.Point(4, 25)
        Me.TabPage5.Name = "TabPage5"
        Me.TabPage5.Size = New System.Drawing.Size(477, 151)
        Me.TabPage5.TabIndex = 2
        Me.TabPage5.Text = "Tree View"
        Me.TabPage5.UseVisualStyleBackColor = True
        '
        'trvFind
        '
        Me.trvFind.Dock = System.Windows.Forms.DockStyle.Fill
        Me.trvFind.Location = New System.Drawing.Point(0, 0)
        Me.trvFind.Name = "trvFind"
        Me.trvFind.Size = New System.Drawing.Size(477, 151)
        Me.trvFind.TabIndex = 0
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.TabControl3)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(346, 180)
        Me.Panel3.TabIndex = 1
        '
        'TabControl3
        '
        Me.TabControl3.Appearance = System.Windows.Forms.TabAppearance.FlatButtons
        Me.TabControl3.Controls.Add(Me.TabPage6)
        Me.TabControl3.Controls.Add(Me.TabPage7)
        Me.TabControl3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl3.Location = New System.Drawing.Point(0, 0)
        Me.TabControl3.Margin = New System.Windows.Forms.Padding(0)
        Me.TabControl3.Name = "TabControl3"
        Me.TabControl3.SelectedIndex = 0
        Me.TabControl3.Size = New System.Drawing.Size(346, 180)
        Me.TabControl3.TabIndex = 7
        '
        'TabPage6
        '
        Me.TabPage6.Controls.Add(Me.TableLayoutPanel7)
        Me.TabPage6.Location = New System.Drawing.Point(4, 25)
        Me.TabPage6.Margin = New System.Windows.Forms.Padding(0)
        Me.TabPage6.Name = "TabPage6"
        Me.TabPage6.Size = New System.Drawing.Size(338, 151)
        Me.TabPage6.TabIndex = 0
        Me.TabPage6.Text = "Combo Box"
        Me.TabPage6.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel7
        '
        Me.TableLayoutPanel7.ColumnCount = 3
        Me.TableLayoutPanel7.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 38.0!))
        Me.TableLayoutPanel7.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 160.0!))
        Me.TableLayoutPanel7.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 140.0!))
        Me.TableLayoutPanel7.Controls.Add(Me.lstLocations, 0, 1)
        Me.TableLayoutPanel7.Controls.Add(Me.Label3, 0, 0)
        Me.TableLayoutPanel7.Controls.Add(Me.com_Area, 1, 0)
        Me.TableLayoutPanel7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel7.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel7.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutPanel7.Name = "TableLayoutPanel7"
        Me.TableLayoutPanel7.RowCount = 2
        Me.TableLayoutPanel7.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel7.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel7.Size = New System.Drawing.Size(338, 151)
        Me.TableLayoutPanel7.TabIndex = 0
        '
        'lstLocations
        '
        Me.TableLayoutPanel7.SetColumnSpan(Me.lstLocations, 5)
        Me.lstLocations.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lstLocations.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstLocations.FormattingEnabled = True
        Me.lstLocations.ItemHeight = 16
        Me.lstLocations.Location = New System.Drawing.Point(0, 25)
        Me.lstLocations.Margin = New System.Windows.Forms.Padding(0)
        Me.lstLocations.Name = "lstLocations"
        Me.lstLocations.Size = New System.Drawing.Size(338, 126)
        Me.lstLocations.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label3.Location = New System.Drawing.Point(0, 0)
        Me.Label3.Margin = New System.Windows.Forms.Padding(0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(38, 25)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Area :"
        '
        'com_Area
        '
        Me.com_Area.Dock = System.Windows.Forms.DockStyle.Fill
        Me.com_Area.FormattingEnabled = True
        Me.com_Area.Location = New System.Drawing.Point(38, 0)
        Me.com_Area.Margin = New System.Windows.Forms.Padding(0)
        Me.com_Area.Name = "com_Area"
        Me.com_Area.Size = New System.Drawing.Size(160, 21)
        Me.com_Area.TabIndex = 4
        '
        'TabPage7
        '
        Me.TabPage7.Controls.Add(Me.lstResult)
        Me.TabPage7.Location = New System.Drawing.Point(4, 25)
        Me.TabPage7.Margin = New System.Windows.Forms.Padding(0)
        Me.TabPage7.Name = "TabPage7"
        Me.TabPage7.Size = New System.Drawing.Size(338, 151)
        Me.TabPage7.TabIndex = 1
        Me.TabPage7.Text = "Tree View"
        Me.TabPage7.UseVisualStyleBackColor = True
        '
        'lstResult
        '
        Me.lstResult.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lstResult.FormattingEnabled = True
        Me.lstResult.Location = New System.Drawing.Point(0, 0)
        Me.lstResult.Name = "lstResult"
        Me.lstResult.Size = New System.Drawing.Size(338, 151)
        Me.lstResult.TabIndex = 0
        '
        'TableLayoutPanel4
        '
        Me.TableLayoutPanel4.ColumnCount = 3
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 192.0!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 188.0!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 460.0!))
        Me.TableLayoutPanel4.Controls.Add(Me.Label4, 0, 0)
        Me.TableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel4.Location = New System.Drawing.Point(0, 186)
        Me.TableLayoutPanel4.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutPanel4.Name = "TableLayoutPanel4"
        Me.TableLayoutPanel4.RowCount = 1
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel4.Size = New System.Drawing.Size(840, 34)
        Me.TableLayoutPanel4.TabIndex = 2
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(3, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(39, 13)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Label4"
        '
        'dgv_qMainData
        '
        Me.dgv_qMainData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgv_qMainData.Location = New System.Drawing.Point(3, 223)
        Me.dgv_qMainData.Name = "dgv_qMainData"
        Me.dgv_qMainData.Size = New System.Drawing.Size(834, 111)
        Me.dgv_qMainData.TabIndex = 3
        '
        'TabPage8
        '
        Me.TabPage8.Controls.Add(Me.TableLayoutPanel10)
        Me.TabPage8.Location = New System.Drawing.Point(4, 22)
        Me.TabPage8.Name = "TabPage8"
        Me.TabPage8.Size = New System.Drawing.Size(840, 337)
        Me.TabPage8.TabIndex = 2
        Me.TabPage8.Text = "MIV MRV"
        Me.TabPage8.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel10
        '
        Me.TableLayoutPanel10.ColumnCount = 2
        Me.TableLayoutPanel10.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 232.0!))
        Me.TableLayoutPanel10.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel10.Controls.Add(Me.TabControl4, 0, 4)
        Me.TableLayoutPanel10.Controls.Add(Me.ToolStrip3, 0, 0)
        Me.TableLayoutPanel10.Controls.Add(Me.dgv2_qMainData, 1, 1)
        Me.TableLayoutPanel10.Controls.Add(Me.dgv_qMivMrv, 0, 3)
        Me.TableLayoutPanel10.Controls.Add(Me.ToolStrip4, 0, 2)
        Me.TableLayoutPanel10.Controls.Add(Me.trvGroupingMiv, 0, 1)
        Me.TableLayoutPanel10.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel10.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel10.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutPanel10.Name = "TableLayoutPanel10"
        Me.TableLayoutPanel10.RowCount = 5
        Me.TableLayoutPanel10.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23.0!))
        Me.TableLayoutPanel10.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 59.2233!))
        Me.TableLayoutPanel10.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel10.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40.7767!))
        Me.TableLayoutPanel10.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 111.0!))
        Me.TableLayoutPanel10.Size = New System.Drawing.Size(840, 337)
        Me.TableLayoutPanel10.TabIndex = 2
        '
        'TabControl4
        '
        Me.TabControl4.Alignment = System.Windows.Forms.TabAlignment.Bottom
        Me.TabControl4.Appearance = System.Windows.Forms.TabAppearance.Buttons
        Me.TableLayoutPanel10.SetColumnSpan(Me.TabControl4, 2)
        Me.TabControl4.Controls.Add(Me.TabPage11)
        Me.TabControl4.Controls.Add(Me.TabPage12)
        Me.TabControl4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl4.Location = New System.Drawing.Point(0, 225)
        Me.TabControl4.Margin = New System.Windows.Forms.Padding(0)
        Me.TabControl4.Multiline = True
        Me.TabControl4.Name = "TabControl4"
        Me.TabControl4.SelectedIndex = 0
        Me.TabControl4.Size = New System.Drawing.Size(840, 112)
        Me.TabControl4.TabIndex = 0
        '
        'TabPage11
        '
        Me.TabPage11.Location = New System.Drawing.Point(4, 4)
        Me.TabPage11.Name = "TabPage11"
        Me.TabPage11.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage11.Size = New System.Drawing.Size(832, 0)
        Me.TabPage11.TabIndex = 0
        Me.TabPage11.Text = "TabPage11"
        Me.TabPage11.UseVisualStyleBackColor = True
        '
        'TabPage12
        '
        Me.TabPage12.Location = New System.Drawing.Point(4, 4)
        Me.TabPage12.Name = "TabPage12"
        Me.TabPage12.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage12.Size = New System.Drawing.Size(832, 0)
        Me.TabPage12.TabIndex = 1
        Me.TabPage12.Text = "TabPage12"
        Me.TabPage12.UseVisualStyleBackColor = True
        '
        'dgv_qMivMrv
        '
        Me.TableLayoutPanel10.SetColumnSpan(Me.dgv_qMivMrv, 2)
        Me.dgv_qMivMrv.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgv_qMivMrv.Location = New System.Drawing.Point(0, 151)
        Me.dgv_qMivMrv.Margin = New System.Windows.Forms.Padding(0)
        Me.dgv_qMivMrv.Name = "dgv_qMivMrv"
        Me.dgv_qMivMrv.Size = New System.Drawing.Size(840, 74)
        Me.dgv_qMivMrv.TabIndex = 0
        '
        'dgv2_qMainData
        '
        Me.dgv2_qMainData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgv2_qMainData.Location = New System.Drawing.Point(232, 23)
        Me.dgv2_qMainData.Margin = New System.Windows.Forms.Padding(0)
        Me.dgv2_qMainData.Name = "dgv2_qMainData"
        Me.dgv2_qMainData.Size = New System.Drawing.Size(608, 108)
        Me.dgv2_qMainData.TabIndex = 1
        '
        'ToolStrip3
        '
        Me.TableLayoutPanel10.SetColumnSpan(Me.ToolStrip3, 2)
        Me.ToolStrip3.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip3.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip3.Name = "ToolStrip3"
        Me.ToolStrip3.Size = New System.Drawing.Size(840, 23)
        Me.ToolStrip3.TabIndex = 2
        Me.ToolStrip3.Text = "ToolStrip3"
        '
        'cms_AddGroping
        '
        Me.cms_AddGroping.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmAddChild, Me.tsmAddOnParent})
        Me.cms_AddGroping.Name = "cmsBaseData"
        Me.cms_AddGroping.Size = New System.Drawing.Size(153, 48)
        '
        'tsmAddChild
        '
        Me.tsmAddChild.Name = "tsmAddChild"
        Me.tsmAddChild.Size = New System.Drawing.Size(152, 22)
        Me.tsmAddChild.Text = "Add Child"
        '
        'tsmAddOnParent
        '
        Me.tsmAddOnParent.Name = "tsmAddOnParent"
        Me.tsmAddOnParent.Size = New System.Drawing.Size(152, 22)
        Me.tsmAddOnParent.Text = "Add On Parent"
        '
        'staMain
        '
        Me.staMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tssb1, Me.lblTssStatus})
        Me.staMain.Location = New System.Drawing.Point(0, 403)
        Me.staMain.Name = "staMain"
        Me.staMain.Size = New System.Drawing.Size(848, 22)
        Me.staMain.TabIndex = 3
        Me.staMain.Text = "StatusStrip1"
        '
        'tssb1
        '
        Me.tssb1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tssb1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsm2})
        Me.tssb1.Image = CType(resources.GetObject("tssb1.Image"), System.Drawing.Image)
        Me.tssb1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tssb1.Name = "tssb1"
        Me.tssb1.Size = New System.Drawing.Size(32, 20)
        Me.tssb1.Text = "ToolStripSplitButton1"
        '
        'tsm2
        '
        Me.tsm2.Name = "tsm2"
        Me.tsm2.Size = New System.Drawing.Size(160, 22)
        Me.tsm2.Text = "Import Excel File"
        '
        'lblTssStatus
        '
        Me.lblTssStatus.Name = "lblTssStatus"
        Me.lblTssStatus.Size = New System.Drawing.Size(39, 17)
        Me.lblTssStatus.Text = "Status"
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(61, 4)
        '
        'Timer1
        '
        Me.Timer1.Interval = 500
        '
        'ToolStrip4
        '
        Me.ToolStrip4.Location = New System.Drawing.Point(0, 131)
        Me.ToolStrip4.Name = "ToolStrip4"
        Me.ToolStrip4.Size = New System.Drawing.Size(232, 20)
        Me.ToolStrip4.TabIndex = 3
        Me.ToolStrip4.Text = "ToolStrip4"
        '
        'trvGroupingMiv
        '
        Me.trvGroupingMiv.Dock = System.Windows.Forms.DockStyle.Fill
        Me.trvGroupingMiv.Location = New System.Drawing.Point(3, 26)
        Me.trvGroupingMiv.Name = "trvGroupingMiv"
        Me.trvGroupingMiv.Size = New System.Drawing.Size(226, 102)
        Me.trvGroupingMiv.TabIndex = 4
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(848, 425)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.staMain)
        Me.Name = "frmMain"
        Me.Text = "Form1"
        Me.cms_BaseData.ResumeLayout(False)
        Me.cms_qBaseItemsP.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TableLayoutPanel8.ResumeLayout(False)
        Me.TableLayoutPanel8.PerformLayout()
        Me.tabBase.ResumeLayout(False)
        Me.TabPage9.ResumeLayout(False)
        Me.TableLayoutPanel3.ResumeLayout(False)
        Me.TableLayoutPanel9.ResumeLayout(False)
        Me.TableLayoutPanel9.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.TabPage10.ResumeLayout(False)
        Me.TableLayoutPanel5.ResumeLayout(False)
        Me.ToolStrip2.ResumeLayout(False)
        Me.ToolStrip2.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.tlpMainData.ResumeLayout(False)
        Me.TabControl2.ResumeLayout(False)
        Me.TabPage3.ResumeLayout(False)
        Me.TableLayoutPanel6.ResumeLayout(False)
        Me.TabPage4.ResumeLayout(False)
        Me.TabPage5.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.TabControl3.ResumeLayout(False)
        Me.TabPage6.ResumeLayout(False)
        Me.TableLayoutPanel7.ResumeLayout(False)
        Me.TabPage7.ResumeLayout(False)
        Me.TableLayoutPanel4.ResumeLayout(False)
        Me.TableLayoutPanel4.PerformLayout()
        Me.TabPage8.ResumeLayout(False)
        Me.TableLayoutPanel10.ResumeLayout(False)
        Me.TableLayoutPanel10.PerformLayout()
        Me.TabControl4.ResumeLayout(False)
        Me.cms_AddGroping.ResumeLayout(False)
        Me.staMain.ResumeLayout(False)
        Me.staMain.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Button1 As Button
    Friend WithEvents ListBox1 As ListBox
    Friend WithEvents cms_BaseData As ContextMenuStrip
    Friend WithEvents cms_qBaseItemsP As ContextMenuStrip
    Friend WithEvents tsmImportData As ToolStripMenuItem
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents TabControl2 As TabControl
    Friend WithEvents TabPage3 As TabPage
    Friend WithEvents TabPage4 As TabPage
    Friend WithEvents TabPage5 As TabPage
    Friend WithEvents lstGrouping As ListBox
    Friend WithEvents tlpMainData As TableLayoutPanel
    Friend WithEvents lblLeftRight As Label
    Friend WithEvents Panel3 As Panel
    Friend WithEvents txtSearch As TextBox
    Friend WithEvents comMain As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents comSubMain As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents TableLayoutPanel4 As TableLayoutPanel
    Friend WithEvents Label4 As Label
    Friend WithEvents TabControl3 As TabControl
    Friend WithEvents TabPage6 As TabPage
    Friend WithEvents TabPage7 As TabPage
    Friend WithEvents trvFind As TreeView
    Friend WithEvents tsm_Update As ToolStripMenuItem
    Friend WithEvents tsm_BaseLocations As ToolStripMenuItem
    Friend WithEvents tabBase As TabControl
    Friend WithEvents TabPage9 As TabPage
    Friend WithEvents TableLayoutPanel3 As TableLayoutPanel
    Friend WithEvents TabPage10 As TabPage
    Friend WithEvents TableLayoutPanel5 As TableLayoutPanel
    Friend WithEvents TableLayoutPanel6 As TableLayoutPanel
    Friend WithEvents TableLayoutPanel7 As TableLayoutPanel
    Friend WithEvents lstLocations As ListBox
    Friend WithEvents Label3 As Label
    Friend WithEvents com_Area As ComboBox
    Friend WithEvents tsmNonSelectAll As ToolStripMenuItem
    Friend WithEvents tsmSelectAllHigh As ToolStripMenuItem
    Friend WithEvents staMain As StatusStrip
    Friend WithEvents tssb1 As ToolStripSplitButton
    Friend WithEvents tsm2 As ToolStripMenuItem
    Friend WithEvents tsmImportMainData As ToolStripMenuItem
    Friend WithEvents lstFiltering As ListBox
    Friend WithEvents lstResult As ListBox
    Friend WithEvents trvGrouping As TreeView
    Friend WithEvents txtCurrentCell As TextBox
    Friend WithEvents cms_AddGroping As ContextMenuStrip
    Friend WithEvents tsmAddChild As ToolStripMenuItem
    Friend WithEvents tsmAddOnParent As ToolStripMenuItem
    Friend WithEvents TableLayoutPanel9 As TableLayoutPanel
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents ts_EditGroup As ToolStripButton
    Friend WithEvents ts_WorkGroup As ToolStripDropDownButton
    Friend WithEvents tsmCheckGroup As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents ts_AddGroup As ToolStripButton
    Friend WithEvents ts_CopyGroup As ToolStripButton
    Friend WithEvents ts_DeleteGroup As ToolStripButton
    Friend WithEvents lstChackGroup As ListBox
    Friend WithEvents ToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents tsm_ExpandAll As ToolStripMenuItem
    Friend WithEvents tsm_CollapseAll As ToolStripMenuItem
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents lblTssStatus As ToolStripStatusLabel
    Friend WithEvents tsmEditTrvGrouping As ToolStripMenuItem
    Friend WithEvents ts_Rename As ToolStripButton
    Friend WithEvents ts_GetText As ToolStripTextBox
    Friend WithEvents dgv_BaseGrouping As dgv.uDgv
    Friend WithEvents dgv_BaseLocations As dgv.uDgv
    Friend WithEvents Timer1 As Timer
    Friend WithEvents dgv_qMainData As dgv.uDgv
    Friend WithEvents TabPage8 As TabPage
    Friend WithEvents dgv_qMivMrv As dgv.uDgv
    Friend WithEvents dgv2_qMainData As dgv.uDgv
    Friend WithEvents TableLayoutPanel8 As TableLayoutPanel
    Friend WithEvents ToolStrip2 As ToolStrip
    Friend WithEvents ToolStripDropDownButton1 As ToolStripDropDownButton
    Friend WithEvents TableLayoutPanel10 As TableLayoutPanel
    Friend WithEvents TabControl4 As TabControl
    Friend WithEvents TabPage11 As TabPage
    Friend WithEvents TabPage12 As TabPage
    Friend WithEvents ToolStrip3 As ToolStrip
    Friend WithEvents ToolStrip4 As ToolStrip
    Friend WithEvents trvGroupingMiv As TreeView
End Class
