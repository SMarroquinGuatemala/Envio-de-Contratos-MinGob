<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmFindItem
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
        Me.GrdDatos = New System.Windows.Forms.DataGridView()
        Me.PicClose = New System.Windows.Forms.PictureBox()
        Me.TxtBusqueda = New System.Windows.Forms.TextBox()
        Me.tmrValidControl = New System.Windows.Forms.Timer(Me.components)
        CType(Me.GrdDatos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PicClose, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GrdDatos
        '
        Me.GrdDatos.AllowUserToAddRows = False
        Me.GrdDatos.AllowUserToDeleteRows = False
        Me.GrdDatos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrdDatos.BackgroundColor = System.Drawing.Color.White
        Me.GrdDatos.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.GrdDatos.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
        Me.GrdDatos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        Me.GrdDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GrdDatos.Location = New System.Drawing.Point(4, 31)
        Me.GrdDatos.Name = "GrdDatos"
        Me.GrdDatos.ReadOnly = True
        Me.GrdDatos.RowHeadersWidth = 10
        Me.GrdDatos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.GrdDatos.Size = New System.Drawing.Size(313, 272)
        Me.GrdDatos.TabIndex = 0
        '
        'PicClose
        '
        Me.PicClose.Image = Global.UserWindowsControlLibrary.My.Resources.Resources.Close_16
        Me.PicClose.Location = New System.Drawing.Point(296, 4)
        Me.PicClose.Name = "PicClose"
        Me.PicClose.Size = New System.Drawing.Size(23, 23)
        Me.PicClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.PicClose.TabIndex = 1
        Me.PicClose.TabStop = False
        Me.PicClose.Visible = False
        '
        'TxtBusqueda
        '
        Me.TxtBusqueda.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtBusqueda.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtBusqueda.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtBusqueda.Location = New System.Drawing.Point(4, 4)
        Me.TxtBusqueda.Name = "TxtBusqueda"
        Me.TxtBusqueda.Size = New System.Drawing.Size(313, 23)
        Me.TxtBusqueda.TabIndex = 2
        '
        'tmrValidControl
        '
        '
        'FrmFindItem
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(321, 307)
        Me.Controls.Add(Me.TxtBusqueda)
        Me.Controls.Add(Me.PicClose)
        Me.Controls.Add(Me.GrdDatos)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FrmFindItem"
        Me.Text = "FrmFindItem"
        CType(Me.GrdDatos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PicClose, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
   Friend WithEvents GrdDatos As System.Windows.Forms.DataGridView
   Friend WithEvents PicClose As System.Windows.Forms.PictureBox
   Friend WithEvents TxtBusqueda As System.Windows.Forms.TextBox
   Friend WithEvents tmrValidControl As System.Windows.Forms.Timer
End Class
