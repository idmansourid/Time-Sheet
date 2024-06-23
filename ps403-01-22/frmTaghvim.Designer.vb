<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTaghvim
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
        Me.UDate1 = New dgv.uDate()
        Me.SuspendLayout()
        '
        'UDate1
        '
        Me.UDate1.Location = New System.Drawing.Point(63, 24)
        Me.UDate1.Name = "UDate1"
        Me.UDate1.Size = New System.Drawing.Size(210, 208)
        Me.UDate1.TabIndex = 0
        '
        'frmTaghvim
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(433, 291)
        Me.Controls.Add(Me.UDate1)
        Me.Name = "frmTaghvim"
        Me.Text = "frmTaghvim"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents UDate1 As dgv.uDate
End Class
