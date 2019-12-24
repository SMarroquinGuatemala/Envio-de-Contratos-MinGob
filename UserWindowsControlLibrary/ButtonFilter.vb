Public Class ButtonFilter
   Private _OnlyImage As Boolean
   Public Property OnlyImage As Boolean
      Get
         OnlyImage = _OnlyImage
      End Get
      Set(value As Boolean)
         _OnlyImage = value
         If _OnlyImage Then
            BtnBuscar.Text = Nothing : BtnExportar.Text = Nothing
            BtnBuscar.Size = New Size(41, 38) : BtnExportar.Size = New Size(41, 38)
            If Me.Width > 200 Then
               BtnExportar.Location = New Point(43, 0)
            End If
         Else
            BtnBuscar.Text = "Buscar" : BtnExportar.Text = "Exportar"
            BtnBuscar.Size = New Size(100, 38) : BtnExportar.Size = New Size(100, 38)
            BtnExportar.Location = New Point((BtnBuscar.Width + 3), 0)
         End If

      End Set
   End Property

   Public Event Search(ByVal sender As System.Object, ByVal e As System.EventArgs)
   Public Event Export(ByVal sender As System.Object, ByVal e As System.EventArgs)

   Private Sub BtnBuscar_Click(sender As System.Object, e As System.EventArgs) Handles BtnBuscar.Click
      RaiseEvent Search(sender, e)
   End Sub

   Private Sub BtnExportar_Click(sender As System.Object, e As System.EventArgs) Handles BtnExportar.Click
      RaiseEvent Export(sender, e)
   End Sub

   Private Sub BtnBuscar_MouseEnter(sender As Object, e As System.EventArgs) Handles BtnBuscar.MouseEnter
      CType(sender, Button).Image = My.Resources.SearchBlue
   End Sub

   Private Sub BtnBuscar_MouseLeave(sender As Object, e As System.EventArgs) Handles BtnBuscar.MouseLeave
      CType(sender, Button).Image = My.Resources.SearchBlack
   End Sub

   Private Sub BtnExportar_MouseEnter(sender As Object, e As System.EventArgs) Handles BtnExportar.MouseEnter
      CType(sender, Button).Image = My.Resources.ExcelBlue
   End Sub

   Private Sub BtnExportar_MouseLeave(sender As Object, e As System.EventArgs) Handles BtnExportar.MouseLeave
      CType(sender, Button).Image = My.Resources.ExcelBlack
   End Sub

   Private Sub ButtonFilter_Resize(sender As Object, e As System.EventArgs) Handles Me.Resize
      Dim p As New Point(p)
      If Me.Width < 200 Then
         If Not OnlyImage Then
            BtnBuscar.PointToScreen(p)
            BtnExportar.Location = New Point(1, 38)
            BtnExportar.PointToScreen(p)
            Me.MaximumSize = New Size(202, 77)
            Me.Size = New Size(101, 78)
         End If
      Else
         If Not OnlyImage Then
            BtnBuscar.PointToScreen(p)
            BtnExportar.Location = New Point((p.X + BtnBuscar.Width + 3), 0)
            Me.Size = New Size(202, 38)
         End If
         End If
   End Sub

End Class
