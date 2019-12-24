<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ButtonFilter
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
      Me.BtnBuscar = New System.Windows.Forms.Button()
      Me.BtnExportar = New System.Windows.Forms.Button()
      Me.SuspendLayout()
      '
      'BtnBuscar
      '
      Me.BtnBuscar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.BtnBuscar.Image = Global.UserWindowsControlLibrary.My.Resources.Resources.SearchBlack
      Me.BtnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.BtnBuscar.Location = New System.Drawing.Point(1, 0)
      Me.BtnBuscar.Name = "BtnBuscar"
      Me.BtnBuscar.Size = New System.Drawing.Size(100, 38)
      Me.BtnBuscar.TabIndex = 0
      Me.BtnBuscar.Text = "Buscar"
      Me.BtnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.BtnBuscar.UseVisualStyleBackColor = True
      '
      'BtnExportar
      '
      Me.BtnExportar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.BtnExportar.Image = Global.UserWindowsControlLibrary.My.Resources.Resources.ExcelBlack
      Me.BtnExportar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.BtnExportar.Location = New System.Drawing.Point(103, 0)
      Me.BtnExportar.Name = "BtnExportar"
      Me.BtnExportar.Size = New System.Drawing.Size(100, 38)
      Me.BtnExportar.TabIndex = 1
      Me.BtnExportar.Text = "Exportar"
      Me.BtnExportar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.BtnExportar.UseVisualStyleBackColor = True
      '
      'ButtonFilter
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.BackColor = System.Drawing.Color.Transparent
      Me.Controls.Add(Me.BtnExportar)
      Me.Controls.Add(Me.BtnBuscar)
      Me.MaximumSize = New System.Drawing.Size(202, 38)
      Me.Name = "ButtonFilter"
      Me.Size = New System.Drawing.Size(202, 38)
      Me.ResumeLayout(False)

   End Sub
   Friend WithEvents BtnBuscar As System.Windows.Forms.Button
   Friend WithEvents BtnExportar As System.Windows.Forms.Button

End Class
