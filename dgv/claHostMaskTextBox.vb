Imports System.Windows.Forms

Public Class claHostMaskTextBox
    Inherits ToolStripControlHost

    Public Sub New()
        MyBase.New(New MaskedTextBox())
    End Sub

    Public ReadOnly Property MaskedTextBoxControl As MaskedTextBox
        Get
            Return CType(Me.Control, MaskedTextBox)
        End Get
    End Property
End Class
