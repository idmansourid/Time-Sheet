<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class uDgv
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(uDgv))
        Me.dgv = New System.Windows.Forms.DataGridView()
        Me.tmrMoveHelper = New System.Windows.Forms.Timer(Me.components)
        Me.ts_Helper = New System.Windows.Forms.ToolStrip()
        Me.tsbHelper = New System.Windows.Forms.ToolStripButton()
        Me.txtCurrentCell = New System.Windows.Forms.TextBox()
        Me.tmrIsDupicateRow = New System.Windows.Forms.Timer(Me.components)
        Me.tmrRowAnyChange = New System.Windows.Forms.Timer(Me.components)
        Me.tmrHelperShowAfterScroll = New System.Windows.Forms.Timer(Me.components)
        Me.tmrErrorReprt = New System.Windows.Forms.Timer(Me.components)
        Me.tmrValidateDelay = New System.Windows.Forms.Timer(Me.components)
        Me.lblTableName = New System.Windows.Forms.Label()
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ts_Helper.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgv
        '
        Me.dgv.AllowUserToOrderColumns = True
        Me.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgv.Location = New System.Drawing.Point(0, 0)
        Me.dgv.Name = "dgv"
        Me.dgv.Size = New System.Drawing.Size(306, 228)
        Me.dgv.TabIndex = 0
        '
        'tmrMoveHelper
        '
        Me.tmrMoveHelper.Interval = 10
        '
        'ts_Helper
        '
        Me.ts_Helper.AutoSize = False
        Me.ts_Helper.BackColor = System.Drawing.Color.White
        Me.ts_Helper.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ts_Helper.Dock = System.Windows.Forms.DockStyle.None
        Me.ts_Helper.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ts_Helper.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbHelper})
        Me.ts_Helper.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Table
        Me.ts_Helper.Location = New System.Drawing.Point(14, 11)
        Me.ts_Helper.Name = "ts_Helper"
        Me.ts_Helper.ShowItemToolTips = False
        Me.ts_Helper.Size = New System.Drawing.Size(12, 21)
        Me.ts_Helper.TabIndex = 8
        Me.ts_Helper.Text = "ToolStrip2"
        '
        'tsbHelper
        '
        Me.tsbHelper.AutoToolTip = False
        Me.tsbHelper.BackColor = System.Drawing.Color.YellowGreen
        Me.tsbHelper.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.tsbHelper.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsbHelper.Image = CType(resources.GetObject("tsbHelper.Image"), System.Drawing.Image)
        Me.tsbHelper.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbHelper.Margin = New System.Windows.Forms.Padding(0)
        Me.tsbHelper.Name = "tsbHelper"
        Me.tsbHelper.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never
        Me.tsbHelper.Size = New System.Drawing.Size(23, 19)
        Me.tsbHelper.Text = " "
        '
        'txtCurrentCell
        '
        Me.txtCurrentCell.Location = New System.Drawing.Point(29, 12)
        Me.txtCurrentCell.Name = "txtCurrentCell"
        Me.txtCurrentCell.Size = New System.Drawing.Size(100, 20)
        Me.txtCurrentCell.TabIndex = 9
        Me.txtCurrentCell.Visible = False
        '
        'tmrIsDupicateRow
        '
        Me.tmrIsDupicateRow.Interval = 10
        '
        'tmrRowAnyChange
        '
        Me.tmrRowAnyChange.Interval = 10
        '
        'tmrHelperShowAfterScroll
        '
        Me.tmrHelperShowAfterScroll.Interval = 500
        '
        'tmrErrorReprt
        '
        '
        'tmrValidateDelay
        '
        '
        'lblTableName
        '
        Me.lblTableName.AutoSize = True
        Me.lblTableName.Location = New System.Drawing.Point(26, 185)
        Me.lblTableName.Name = "lblTableName"
        Me.lblTableName.Size = New System.Drawing.Size(39, 13)
        Me.lblTableName.TabIndex = 10
        Me.lblTableName.Text = "Label1"
        '
        'uDgv
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.lblTableName)
        Me.Controls.Add(Me.txtCurrentCell)
        Me.Controls.Add(Me.ts_Helper)
        Me.Controls.Add(Me.dgv)
        Me.Name = "uDgv"
        Me.Size = New System.Drawing.Size(306, 228)
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ts_Helper.ResumeLayout(False)
        Me.ts_Helper.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tmrMoveHelper As Windows.Forms.Timer
    Friend WithEvents ts_Helper As Windows.Forms.ToolStrip
    Friend WithEvents tsbHelper As Windows.Forms.ToolStripButton
    Public WithEvents dgv As Windows.Forms.DataGridView
    Friend WithEvents tmrRowAnyChange As Windows.Forms.Timer
    Public WithEvents txtCurrentCell As Windows.Forms.TextBox
    Public WithEvents tmrIsDupicateRow As Windows.Forms.Timer
    Friend WithEvents tmrHelperShowAfterScroll As Windows.Forms.Timer
    Friend WithEvents tmrErrorReprt As Windows.Forms.Timer
    Public WithEvents tmrValidateDelay As Windows.Forms.Timer
    Friend WithEvents lblTableName As Windows.Forms.Label
End Class
