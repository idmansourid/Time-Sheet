<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSelectRowOfMainData
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
        Me.dgv_qMainData = New dgv.uDgv()
        Me.txtSearch = New System.Windows.Forms.TextBox()
        Me.trvGrouping = New System.Windows.Forms.TreeView()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgv_qMainData
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.dgv_qMainData, 2)
        Me.dgv_qMainData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgv_qMainData.Location = New System.Drawing.Point(0, 201)
        Me.dgv_qMainData.Margin = New System.Windows.Forms.Padding(0)
        Me.dgv_qMainData.Name = "dgv_qMainData"
        Me.dgv_qMainData.Size = New System.Drawing.Size(765, 178)
        Me.dgv_qMainData.TabIndex = 0
        '
        'txtSearch
        '
        Me.txtSearch.Location = New System.Drawing.Point(340, 3)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(215, 20)
        Me.txtSearch.TabIndex = 0
        '
        'trvGrouping
        '
        Me.trvGrouping.Dock = System.Windows.Forms.DockStyle.Fill
        Me.trvGrouping.Location = New System.Drawing.Point(0, 0)
        Me.trvGrouping.Margin = New System.Windows.Forms.Padding(0)
        Me.trvGrouping.Name = "trvGrouping"
        Me.trvGrouping.Size = New System.Drawing.Size(337, 175)
        Me.trvGrouping.TabIndex = 1
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 337.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.trvGrouping, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.dgv_qMainData, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.txtSearch, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.ToolStrip1, 0, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 175.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(765, 379)
        Me.TableLayoutPanel1.TabIndex = 2
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 175)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(337, 25)
        Me.ToolStrip1.TabIndex = 2
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'frmSelectRowOfMainData
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(765, 379)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "frmSelectRowOfMainData"
        Me.Text = "frmSelectRowOfMainData"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents dgv_qMainData As dgv.uDgv
    Friend WithEvents txtSearch As TextBox
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents trvGrouping As TreeView
    Friend WithEvents ToolStrip1 As ToolStrip
End Class
