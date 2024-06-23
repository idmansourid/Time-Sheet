<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Me.dgv_tabPipol = New dgv.uDgv()
        Me.dgv_tabKala = New dgv.uDgv()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'dgv_tabPipol
        '
        Me.dgv_tabPipol.Location = New System.Drawing.Point(-1, 12)
        Me.dgv_tabPipol.Name = "dgv_tabPipol"
        Me.dgv_tabPipol.Size = New System.Drawing.Size(668, 162)
        Me.dgv_tabPipol.TabIndex = 0
        '
        'dgv_tabKala
        '
        Me.dgv_tabKala.Location = New System.Drawing.Point(-1, 180)
        Me.dgv_tabKala.Name = "dgv_tabKala"
        Me.dgv_tabKala.Size = New System.Drawing.Size(658, 177)
        Me.dgv_tabKala.TabIndex = 1
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(127, 372)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(164, 29)
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.dgv_tabKala)
        Me.Controls.Add(Me.dgv_tabPipol)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents dgv_tabPipol As dgv.uDgv
    Friend WithEvents dgv_tabKala As dgv.uDgv
    Friend WithEvents Button1 As Button
End Class
