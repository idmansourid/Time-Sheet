<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class uDate
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.dgv = New System.Windows.Forms.DataGridView()
        Me.c0 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.c1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.c2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.c3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.c4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.c5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.c6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.tslNavi = New System.Windows.Forms.ToolStrip()
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgv
        '
        Me.dgv.AllowUserToAddRows = False
        Me.dgv.AllowUserToDeleteRows = False
        Me.dgv.AllowUserToResizeColumns = False
        Me.dgv.AllowUserToResizeRows = False
        Me.dgv.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgv.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised
        Me.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.c0, Me.c1, Me.c2, Me.c3, Me.c4, Me.c5, Me.c6})
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.BottomLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Blue
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgv.DefaultCellStyle = DataGridViewCellStyle1
        Me.dgv.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgv.Location = New System.Drawing.Point(2, 29)
        Me.dgv.Margin = New System.Windows.Forms.Padding(2)
        Me.dgv.MultiSelect = False
        Me.dgv.Name = "dgv"
        Me.dgv.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.dgv.RowHeadersVisible = False
        Me.dgv.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgv.Size = New System.Drawing.Size(192, 186)
        Me.dgv.TabIndex = 1
        '
        'c0
        '
        Me.c0.HeaderText = "ش"
        Me.c0.Name = "c0"
        Me.c0.Width = 27
        '
        'c1
        '
        Me.c1.HeaderText = "ی"
        Me.c1.Name = "c1"
        Me.c1.Width = 27
        '
        'c2
        '
        Me.c2.HeaderText = "د"
        Me.c2.Name = "c2"
        Me.c2.Width = 27
        '
        'c3
        '
        Me.c3.HeaderText = "س"
        Me.c3.Name = "c3"
        Me.c3.Width = 27
        '
        'c4
        '
        Me.c4.HeaderText = "چ"
        Me.c4.Name = "c4"
        Me.c4.Width = 27
        '
        'c5
        '
        Me.c5.HeaderText = "پ"
        Me.c5.Name = "c5"
        Me.c5.Width = 27
        '
        'c6
        '
        Me.c6.HeaderText = "ج"
        Me.c6.Name = "c6"
        Me.c6.Width = 27
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.dgv, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.tslNavi, 0, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(196, 217)
        Me.TableLayoutPanel1.TabIndex = 2
        '
        'tslNavi
        '
        Me.tslNavi.BackColor = System.Drawing.SystemColors.Control
        Me.tslNavi.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.tslNavi.Location = New System.Drawing.Point(2, 2)
        Me.tslNavi.Margin = New System.Windows.Forms.Padding(2, 2, 2, 0)
        Me.tslNavi.Name = "tslNavi"
        Me.tslNavi.Size = New System.Drawing.Size(192, 25)
        Me.tslNavi.TabIndex = 2
        Me.tslNavi.Text = "ToolStrip1"
        '
        'uDate
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "uDate"
        Me.Size = New System.Drawing.Size(196, 217)
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As Windows.Forms.TableLayoutPanel
    Friend WithEvents tslNavi As Windows.Forms.ToolStrip
    Public WithEvents dgv As Windows.Forms.DataGridView
    Friend WithEvents c0 As Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents c1 As Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents c2 As Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents c3 As Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents c4 As Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents c5 As Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents c6 As Windows.Forms.DataGridViewTextBoxColumn
End Class
