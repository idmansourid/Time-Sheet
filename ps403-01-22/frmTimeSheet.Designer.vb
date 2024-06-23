<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTimeSheet
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
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.tabMain = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.ToolStrip2 = New System.Windows.Forms.ToolStrip()
        Me.butTsAddRow = New System.Windows.Forms.ToolStripButton()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.TableLayoutPanel4 = New System.Windows.Forms.TableLayoutPanel()
        Me.tlsChideman = New System.Windows.Forms.ToolStrip()
        Me.tsButRozGhabl2 = New System.Windows.Forms.ToolStripButton()
        Me.tsTxtTarikh = New System.Windows.Forms.ToolStripTextBox()
        Me.tsButRozBaad2 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStrip5 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripLabel2 = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStrip4 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.TabPage4 = New System.Windows.Forms.TabPage()
        Me.dgv_Persenel = New dgv.uDgv()
        Me.dgv_SelPersenel = New dgv.uDgv()
        Me.dgv_qHozorGhiab = New dgv.uDgv()
        Me.UDate1 = New dgv.uDate()
        Me.UDgv2 = New dgv.uDgv()
        Me.dgv_FaaliatHa = New dgv.uDgv()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.tabMain.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.TableLayoutPanel3.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.ToolStrip2.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.TableLayoutPanel4.SuspendLayout()
        Me.tlsChideman.SuspendLayout()
        Me.ToolStrip5.SuspendLayout()
        Me.ToolStrip4.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.StatusStrip1, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.tabMain, 0, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(739, 359)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 339)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(739, 20)
        Me.StatusStrip1.TabIndex = 0
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'tabMain
        '
        Me.tabMain.Controls.Add(Me.TabPage1)
        Me.tabMain.Controls.Add(Me.TabPage2)
        Me.tabMain.Controls.Add(Me.TabPage3)
        Me.tabMain.Controls.Add(Me.TabPage4)
        Me.tabMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tabMain.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tabMain.Location = New System.Drawing.Point(0, 20)
        Me.tabMain.Margin = New System.Windows.Forms.Padding(0)
        Me.tabMain.Name = "tabMain"
        Me.tabMain.SelectedIndex = 0
        Me.tabMain.Size = New System.Drawing.Size(739, 319)
        Me.tabMain.TabIndex = 1
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.TableLayoutPanel2)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Margin = New System.Windows.Forms.Padding(0)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Size = New System.Drawing.Size(731, 293)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "پرسنل"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 1
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.ToolStrip1, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.dgv_Persenel, 0, 1)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel2.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 2
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(731, 293)
        Me.TableLayoutPanel2.TabIndex = 1
        '
        'ToolStrip1
        '
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(731, 20)
        Me.ToolStrip1.TabIndex = 0
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.TableLayoutPanel3)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Margin = New System.Windows.Forms.Padding(0)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Size = New System.Drawing.Size(731, 293)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "حضور غیاب"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.ColumnCount = 3
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 217.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 56.42023!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 43.57977!))
        Me.TableLayoutPanel3.Controls.Add(Me.Button1, 2, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.SplitContainer1, 0, 2)
        Me.TableLayoutPanel3.Controls.Add(Me.UDate1, 0, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.ToolStrip2, 0, 1)
        Me.TableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel3.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 3
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 188.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(731, 293)
        Me.TableLayoutPanel3.TabIndex = 0
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(509, 3)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(81, 27)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'SplitContainer1
        '
        Me.TableLayoutPanel3.SetColumnSpan(Me.SplitContainer1, 3)
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(3, 213)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.dgv_SelPersenel)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.dgv_qHozorGhiab)
        Me.SplitContainer1.Size = New System.Drawing.Size(725, 77)
        Me.SplitContainer1.SplitterDistance = 241
        Me.SplitContainer1.TabIndex = 5
        '
        'ToolStrip2
        '
        Me.TableLayoutPanel3.SetColumnSpan(Me.ToolStrip2, 2)
        Me.ToolStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.butTsAddRow})
        Me.ToolStrip2.Location = New System.Drawing.Point(0, 188)
        Me.ToolStrip2.Name = "ToolStrip2"
        Me.ToolStrip2.Size = New System.Drawing.Size(506, 22)
        Me.ToolStrip2.TabIndex = 6
        Me.ToolStrip2.Text = "ToolStrip2"
        '
        'butTsAddRow
        '
        Me.butTsAddRow.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.butTsAddRow.Image = Global.Time_Sheet.My.Resources.Resources.AddRow
        Me.butTsAddRow.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.butTsAddRow.Name = "butTsAddRow"
        Me.butTsAddRow.Size = New System.Drawing.Size(23, 19)
        Me.butTsAddRow.Text = "ToolStripButton1"
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.TableLayoutPanel4)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Margin = New System.Windows.Forms.Padding(0)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(731, 293)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "چیدمان افراد"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel4
        '
        Me.TableLayoutPanel4.ColumnCount = 3
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 3.0!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel4.Controls.Add(Me.UDgv2, 2, 2)
        Me.TableLayoutPanel4.Controls.Add(Me.tlsChideman, 0, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.dgv_FaaliatHa, 0, 2)
        Me.TableLayoutPanel4.Controls.Add(Me.ToolStrip5, 2, 1)
        Me.TableLayoutPanel4.Controls.Add(Me.ToolStrip4, 0, 1)
        Me.TableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel4.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel4.Name = "TableLayoutPanel4"
        Me.TableLayoutPanel4.RowCount = 4
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24.0!))
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24.0!))
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel4.Size = New System.Drawing.Size(731, 293)
        Me.TableLayoutPanel4.TabIndex = 0
        '
        'tlsChideman
        '
        Me.TableLayoutPanel4.SetColumnSpan(Me.tlsChideman, 3)
        Me.tlsChideman.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsButRozGhabl2, Me.tsTxtTarikh, Me.tsButRozBaad2})
        Me.tlsChideman.Location = New System.Drawing.Point(0, 0)
        Me.tlsChideman.Name = "tlsChideman"
        Me.tlsChideman.Size = New System.Drawing.Size(731, 24)
        Me.tlsChideman.TabIndex = 0
        Me.tlsChideman.Text = "ToolStrip3"
        '
        'tsButRozGhabl2
        '
        Me.tsButRozGhabl2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsButRozGhabl2.Image = Global.Time_Sheet.My.Resources.Resources.rozGhabl
        Me.tsButRozGhabl2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsButRozGhabl2.Name = "tsButRozGhabl2"
        Me.tsButRozGhabl2.Size = New System.Drawing.Size(23, 21)
        Me.tsButRozGhabl2.Text = "ToolStripButton2"
        '
        'tsTxtTarikh
        '
        Me.tsTxtTarikh.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tsTxtTarikh.Name = "tsTxtTarikh"
        Me.tsTxtTarikh.Size = New System.Drawing.Size(100, 24)
        '
        'tsButRozBaad2
        '
        Me.tsButRozBaad2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsButRozBaad2.Image = Global.Time_Sheet.My.Resources.Resources.RozBaad
        Me.tsButRozBaad2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsButRozBaad2.Name = "tsButRozBaad2"
        Me.tsButRozBaad2.Size = New System.Drawing.Size(23, 21)
        Me.tsButRozBaad2.Text = "Roz Baad"
        '
        'ToolStrip5
        '
        Me.ToolStrip5.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip5.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel2})
        Me.ToolStrip5.Location = New System.Drawing.Point(367, 24)
        Me.ToolStrip5.Name = "ToolStrip5"
        Me.ToolStrip5.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ToolStrip5.Size = New System.Drawing.Size(364, 24)
        Me.ToolStrip5.TabIndex = 4
        Me.ToolStrip5.Text = "ToolStrip5"
        '
        'ToolStripLabel2
        '
        Me.ToolStripLabel2.Name = "ToolStripLabel2"
        Me.ToolStripLabel2.Size = New System.Drawing.Size(42, 21)
        Me.ToolStripLabel2.Text = "چیدمان"
        '
        'ToolStrip4
        '
        Me.ToolStrip4.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip4.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel1})
        Me.ToolStrip4.Location = New System.Drawing.Point(0, 24)
        Me.ToolStrip4.Name = "ToolStrip4"
        Me.ToolStrip4.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ToolStrip4.Size = New System.Drawing.Size(364, 24)
        Me.ToolStrip4.TabIndex = 3
        Me.ToolStrip4.Text = "ToolStrip4"
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(56, 21)
        Me.ToolStripLabel1.Text = "فعالیت ها"
        '
        'TabPage4
        '
        Me.TabPage4.Location = New System.Drawing.Point(4, 22)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Size = New System.Drawing.Size(731, 293)
        Me.TabPage4.TabIndex = 3
        Me.TabPage4.Text = "TabPage4"
        Me.TabPage4.UseVisualStyleBackColor = True
        '
        'dgv_Persenel
        '
        Me.dgv_Persenel.DataTable = Nothing
        Me.dgv_Persenel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgv_Persenel.Location = New System.Drawing.Point(0, 20)
        Me.dgv_Persenel.Margin = New System.Windows.Forms.Padding(0)
        Me.dgv_Persenel.Name = "dgv_Persenel"
        Me.dgv_Persenel.ShowHelper = False
        Me.dgv_Persenel.Size = New System.Drawing.Size(731, 273)
        Me.dgv_Persenel.TabIndex = 0
        '
        'dgv_SelPersenel
        '
        Me.dgv_SelPersenel.DataTable = Nothing
        Me.dgv_SelPersenel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgv_SelPersenel.Location = New System.Drawing.Point(0, 0)
        Me.dgv_SelPersenel.Margin = New System.Windows.Forms.Padding(0, 0, 3, 0)
        Me.dgv_SelPersenel.Name = "dgv_SelPersenel"
        Me.dgv_SelPersenel.ShowHelper = False
        Me.dgv_SelPersenel.Size = New System.Drawing.Size(241, 77)
        Me.dgv_SelPersenel.TabIndex = 0
        '
        'dgv_qHozorGhiab
        '
        Me.dgv_qHozorGhiab.DataTable = Nothing
        Me.dgv_qHozorGhiab.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgv_qHozorGhiab.Location = New System.Drawing.Point(0, 0)
        Me.dgv_qHozorGhiab.Margin = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.dgv_qHozorGhiab.Name = "dgv_qHozorGhiab"
        Me.dgv_qHozorGhiab.ShowHelper = False
        Me.dgv_qHozorGhiab.Size = New System.Drawing.Size(480, 77)
        Me.dgv_qHozorGhiab.TabIndex = 2
        '
        'UDate1
        '
        Me.UDate1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UDate1.Location = New System.Drawing.Point(0, 0)
        Me.UDate1.Margin = New System.Windows.Forms.Padding(0)
        Me.UDate1.Name = "UDate1"
        Me.UDate1.Size = New System.Drawing.Size(217, 188)
        Me.UDate1.TabIndex = 3
        Me.UDate1.textDate = "03-04-02"
        '
        'UDgv2
        '
        Me.UDgv2.DataTable = Nothing
        Me.UDgv2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UDgv2.Location = New System.Drawing.Point(367, 48)
        Me.UDgv2.Margin = New System.Windows.Forms.Padding(0)
        Me.UDgv2.Name = "UDgv2"
        Me.UDgv2.ShowHelper = False
        Me.UDgv2.Size = New System.Drawing.Size(364, 220)
        Me.UDgv2.TabIndex = 2
        '
        'dgv_FaaliatHa
        '
        Me.dgv_FaaliatHa.DataTable = Nothing
        Me.dgv_FaaliatHa.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgv_FaaliatHa.Location = New System.Drawing.Point(0, 48)
        Me.dgv_FaaliatHa.Margin = New System.Windows.Forms.Padding(0)
        Me.dgv_FaaliatHa.Name = "dgv_FaaliatHa"
        Me.dgv_FaaliatHa.ShowHelper = True
        Me.dgv_FaaliatHa.Size = New System.Drawing.Size(364, 220)
        Me.dgv_FaaliatHa.TabIndex = 1
        '
        'frmTimeSheet
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(739, 359)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "frmTimeSheet"
        Me.Text = "frmTimeSheet"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.tabMain.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TableLayoutPanel3.ResumeLayout(False)
        Me.TableLayoutPanel3.PerformLayout()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.ToolStrip2.ResumeLayout(False)
        Me.ToolStrip2.PerformLayout()
        Me.TabPage3.ResumeLayout(False)
        Me.TableLayoutPanel4.ResumeLayout(False)
        Me.TableLayoutPanel4.PerformLayout()
        Me.tlsChideman.ResumeLayout(False)
        Me.tlsChideman.PerformLayout()
        Me.ToolStrip5.ResumeLayout(False)
        Me.ToolStrip5.PerformLayout()
        Me.ToolStrip4.ResumeLayout(False)
        Me.ToolStrip4.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents tabMain As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents dgv_Persenel As dgv.uDgv
    Friend WithEvents TableLayoutPanel3 As TableLayoutPanel
    Friend WithEvents dgv_SelPersenel As dgv.uDgv
    Friend WithEvents dgv_qHozorGhiab As dgv.uDgv
    Friend WithEvents TabPage3 As TabPage
    Friend WithEvents TableLayoutPanel4 As TableLayoutPanel
    Friend WithEvents UDgv2 As dgv.uDgv
    Friend WithEvents tlsChideman As ToolStrip
    Friend WithEvents dgv_FaaliatHa As dgv.uDgv
    Friend WithEvents ToolStrip4 As ToolStrip
    Friend WithEvents ToolStripLabel1 As ToolStripLabel
    Friend WithEvents ToolStrip5 As ToolStrip
    Friend WithEvents ToolStripLabel2 As ToolStripLabel
    Friend WithEvents tsButRozGhabl2 As ToolStripButton
    Friend WithEvents tsTxtTarikh As ToolStripTextBox
    Friend WithEvents tsButRozBaad2 As ToolStripButton
    Friend WithEvents UDate1 As dgv.uDate
    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents ToolStrip2 As ToolStrip
    Friend WithEvents butTsAddRow As ToolStripButton
    Friend WithEvents TabPage4 As TabPage
    Friend WithEvents Button1 As Button
End Class
