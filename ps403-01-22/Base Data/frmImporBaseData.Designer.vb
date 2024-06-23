<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmImporBaseData
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmImporBaseData))
        Me.dgvConnect = New System.Windows.Forms.DataGridView()
        Me.lstColumns = New System.Windows.Forms.ListBox()
        Me.cmsColumns = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.tsmClear = New System.Windows.Forms.ToolStripMenuItem()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.butImport = New System.Windows.Forms.Button()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.lblPreview = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.lstSheetsPreview = New System.Windows.Forms.ListBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.dgvPreview = New System.Windows.Forms.DataGridView()
        Me.butOpen = New System.Windows.Forms.Button()
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.lblSelSheet = New System.Windows.Forms.Label()
        Me.colSel = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.colSoft = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colImport = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.dgvConnect, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmsColumns.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        CType(Me.dgvPreview, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel3.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgvConnect
        '
        Me.dgvConnect.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvConnect.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colSel, Me.colSoft, Me.colImport})
        Me.dgvConnect.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvConnect.Location = New System.Drawing.Point(0, 242)
        Me.dgvConnect.Margin = New System.Windows.Forms.Padding(0)
        Me.dgvConnect.Name = "dgvConnect"
        Me.dgvConnect.RowHeadersVisible = False
        Me.dgvConnect.Size = New System.Drawing.Size(325, 131)
        Me.dgvConnect.TabIndex = 2
        '
        'lstColumns
        '
        Me.lstColumns.ContextMenuStrip = Me.cmsColumns
        Me.lstColumns.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.lstColumns.FormattingEnabled = True
        Me.lstColumns.Location = New System.Drawing.Point(0, 252)
        Me.lstColumns.Margin = New System.Windows.Forms.Padding(0)
        Me.lstColumns.Name = "lstColumns"
        Me.lstColumns.Size = New System.Drawing.Size(177, 121)
        Me.lstColumns.TabIndex = 3
        '
        'cmsColumns
        '
        Me.cmsColumns.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmClear})
        Me.cmsColumns.Name = "cmsColumns"
        Me.cmsColumns.Size = New System.Drawing.Size(102, 26)
        '
        'tsmClear
        '
        Me.tsmClear.Name = "tsmClear"
        Me.tsmClear.Size = New System.Drawing.Size(101, 22)
        Me.tsmClear.Text = "Clear"
        '
        'TextBox1
        '
        Me.TextBox1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.Location = New System.Drawing.Point(461, 6)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TextBox1.Size = New System.Drawing.Size(233, 53)
        Me.TextBox1.TabIndex = 4
        Me.TextBox1.Text = resources.GetString("TextBox1.Text")
        '
        'butImport
        '
        Me.butImport.Location = New System.Drawing.Point(93, 12)
        Me.butImport.Name = "butImport"
        Me.butImport.Size = New System.Drawing.Size(119, 23)
        Me.butImport.TabIndex = 6
        Me.butImport.Text = "Import File To Soft"
        Me.butImport.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 177.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Panel2, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel3, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel1, 1, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 56)
        Me.TableLayoutPanel1.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 12.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(722, 407)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'Panel2
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.Panel2, 2)
        Me.Panel2.Controls.Add(Me.lblPreview)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(722, 22)
        Me.Panel2.TabIndex = 1
        '
        'lblPreview
        '
        Me.lblPreview.AutoSize = True
        Me.lblPreview.Location = New System.Drawing.Point(174, 6)
        Me.lblPreview.Name = "lblPreview"
        Me.lblPreview.Size = New System.Drawing.Size(48, 13)
        Me.lblPreview.TabIndex = 1
        Me.lblPreview.Text = "Preview:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(3, 6)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(43, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Sheets:"
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.lstSheetsPreview)
        Me.Panel3.Controls.Add(Me.Label2)
        Me.Panel3.Controls.Add(Me.lstColumns)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(0, 22)
        Me.Panel3.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(177, 373)
        Me.Panel3.TabIndex = 2
        '
        'lstSheetsPreview
        '
        Me.lstSheetsPreview.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lstSheetsPreview.FormattingEnabled = True
        Me.lstSheetsPreview.Location = New System.Drawing.Point(0, 0)
        Me.lstSheetsPreview.Name = "lstSheetsPreview"
        Me.lstSheetsPreview.Size = New System.Drawing.Size(177, 239)
        Me.lstSheetsPreview.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Label2.Location = New System.Drawing.Point(0, 239)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(177, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Columns:"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.TableLayoutPanel2)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(177, 22)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel1.Name = "Panel1"
        Me.TableLayoutPanel1.SetRowSpan(Me.Panel1, 2)
        Me.Panel1.Size = New System.Drawing.Size(545, 385)
        Me.Panel1.TabIndex = 3
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 2
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 325.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 220.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.dgvPreview, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.dgvConnect, 0, 1)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel2.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 3
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 131.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 12.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(545, 385)
        Me.TableLayoutPanel2.TabIndex = 0
        '
        'dgvPreview
        '
        Me.dgvPreview.AllowUserToOrderColumns = True
        Me.dgvPreview.AllowUserToResizeRows = False
        Me.dgvPreview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.TableLayoutPanel2.SetColumnSpan(Me.dgvPreview, 2)
        Me.dgvPreview.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvPreview.Location = New System.Drawing.Point(0, 0)
        Me.dgvPreview.Margin = New System.Windows.Forms.Padding(0)
        Me.dgvPreview.Name = "dgvPreview"
        Me.dgvPreview.Size = New System.Drawing.Size(545, 242)
        Me.dgvPreview.TabIndex = 0
        '
        'butOpen
        '
        Me.butOpen.Location = New System.Drawing.Point(12, 12)
        Me.butOpen.Name = "butOpen"
        Me.butOpen.Size = New System.Drawing.Size(75, 23)
        Me.butOpen.TabIndex = 0
        Me.butOpen.Text = "Import File"
        Me.butOpen.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.ColumnCount = 1
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel3.Controls.Add(Me.Panel4, 0, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.TableLayoutPanel1, 0, 1)
        Me.TableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel3.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 2
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 56.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(722, 463)
        Me.TableLayoutPanel3.TabIndex = 8
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.TextBox1)
        Me.Panel4.Controls.Add(Me.butImport)
        Me.Panel4.Controls.Add(Me.lblSelSheet)
        Me.Panel4.Controls.Add(Me.butOpen)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel4.Location = New System.Drawing.Point(0, 0)
        Me.Panel4.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(722, 56)
        Me.Panel4.TabIndex = 8
        '
        'lblSelSheet
        '
        Me.lblSelSheet.AutoSize = True
        Me.lblSelSheet.Font = New System.Drawing.Font("Tahoma", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSelSheet.Location = New System.Drawing.Point(294, 12)
        Me.lblSelSheet.Name = "lblSelSheet"
        Me.lblSelSheet.Size = New System.Drawing.Size(140, 23)
        Me.lblSelSheet.TabIndex = 1
        Me.lblSelSheet.Text = "Sheets Of Excel"
        '
        'colSel
        '
        Me.colSel.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.colSel.HeaderText = ""
        Me.colSel.Name = "colSel"
        Me.colSel.Width = 21
        '
        'colSoft
        '
        Me.colSoft.HeaderText = "Columns Soft"
        Me.colSoft.Name = "colSoft"
        Me.colSoft.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colSoft.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.colSoft.Width = 120
        '
        'colImport
        '
        Me.colImport.HeaderText = "Columns Import"
        Me.colImport.Name = "colImport"
        Me.colImport.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colImport.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.colImport.Width = 130
        '
        'frmImporBaseData
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(722, 463)
        Me.Controls.Add(Me.TableLayoutPanel3)
        Me.Name = "frmImporBaseData"
        Me.Text = "Import Data On BaseI tems"
        CType(Me.dgvConnect, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmsColumns.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        CType(Me.dgvPreview, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel3.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgvConnect As DataGridView
    Friend WithEvents lstColumns As ListBox
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents cmsColumns As ContextMenuStrip
    Friend WithEvents tsmClear As ToolStripMenuItem
    Friend WithEvents butImport As Button
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents dgvPreview As DataGridView
    Friend WithEvents Panel2 As Panel
    Friend WithEvents butOpen As Button
    Friend WithEvents Panel3 As Panel
    Friend WithEvents lstSheetsPreview As ListBox
    Friend WithEvents Label1 As Label
    Friend WithEvents TableLayoutPanel3 As TableLayoutPanel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents lblSelSheet As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents lblPreview As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents colSel As DataGridViewCheckBoxColumn
    Friend WithEvents colSoft As DataGridViewTextBoxColumn
    Friend WithEvents colImport As DataGridViewTextBoxColumn
End Class
