<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UsrFilterData
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
      Me.Label1 = New System.Windows.Forms.Label()
      Me.CboCondiciones = New ComboBox
      Me.Label2 = New System.Windows.Forms.Label()
      Me.TxtCriterio = New TextBoxSD
      Me.Label3 = New System.Windows.Forms.Label()
      Me.CboCampo = New System.Windows.Forms.ComboBox()
      Me.SuspendLayout()
      '
      'Label1
      '
      Me.Label1.AutoSize = True
      Me.Label1.Location = New System.Drawing.Point(2, 4)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(40, 13)
      Me.Label1.TabIndex = 2
      Me.Label1.Text = "Campo"
      '
      'CboCondiciones
      '
      Me.CboCondiciones.BackColor = System.Drawing.Color.LemonChiffon
      Me.CboCondiciones.DropDownWidth = 125
      Me.CboCondiciones.FormattingEnabled = True
      Me.CboCondiciones.Location = New System.Drawing.Point(121, 20)
      Me.CboCondiciones.Name = "CboCondiciones"
      Me.CboCondiciones.Size = New System.Drawing.Size(80, 21)
      Me.CboCondiciones.TabIndex = 1
      ' Me.CboCondiciones.TypeField = ComboBoxSD.TiposDeCampo.Obligatorio
      '
      'Label2
      '
      Me.Label2.AutoSize = True
      Me.Label2.Location = New System.Drawing.Point(118, 4)
      Me.Label2.Name = "Label2"
      Me.Label2.Size = New System.Drawing.Size(54, 13)
      Me.Label2.TabIndex = 2
      Me.Label2.Text = "Condicion"
      '
      'TxtCriterio
      '
      Me.TxtCriterio.BackColor = System.Drawing.Color.LemonChiffon
      Me.TxtCriterio.Location = New System.Drawing.Point(202, 21)
      Me.TxtCriterio.Name = "TxtCriterio"
      Me.TxtCriterio.Size = New System.Drawing.Size(78, 20)
      Me.TxtCriterio.TabIndex = 2
      Me.TxtCriterio.TypeField = TextBoxSD.TiposDeCampo.Obligatorio

      'Label3
      '
      Me.Label3.AutoSize = True
      Me.Label3.Location = New System.Drawing.Point(199, 5)
      Me.Label3.Name = "Label3"
      Me.Label3.Size = New System.Drawing.Size(39, 13)
      Me.Label3.TabIndex = 2
      Me.Label3.Text = "Criterio"
      '
      'CboCampo
      '
      Me.CboCampo.BackColor = System.Drawing.Color.LemonChiffon
      Me.CboCampo.DropDownHeight = 150
      Me.CboCampo.DropDownWidth = 250
      Me.CboCampo.FormattingEnabled = True
      Me.CboCampo.IntegralHeight = False
      Me.CboCampo.Location = New System.Drawing.Point(1, 20)
      Me.CboCampo.Name = "CboCampo"
      Me.CboCampo.Size = New System.Drawing.Size(118, 21)
      Me.CboCampo.TabIndex = 0
      '
      'UsrFilterData
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.Controls.Add(Me.CboCampo)
      Me.Controls.Add(Me.TxtCriterio)
      Me.Controls.Add(Me.Label3)
      Me.Controls.Add(Me.Label2)
      Me.Controls.Add(Me.Label1)
      Me.Controls.Add(Me.CboCondiciones)
      Me.Name = "UsrFilterData"
      Me.Size = New System.Drawing.Size(283, 44)
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents Label1 As System.Windows.Forms.Label
   Public WithEvents CboCondiciones As ComboBox
   Friend WithEvents Label2 As System.Windows.Forms.Label
   Public WithEvents TxtCriterio As TextBoxSD
   Friend WithEvents Label3 As System.Windows.Forms.Label
   Public WithEvents CboCampo As System.Windows.Forms.ComboBox

End Class
