Public Class FrmFindItem
   Private _AnchiInicio As Integer
   Public Property AnchoInicio() As Integer
      Get
         Return _AnchiInicio
      End Get
      Set(ByVal value As Integer)
         _AnchiInicio = value
      End Set
   End Property

   Private _AnchoFinal As Integer
   Public Property AnchoFinal() As Integer
      Get
         Return _AnchoFinal
      End Get
      Set(ByVal value As Integer)
         _AnchoFinal = value
      End Set
   End Property

   Private _AltoMaximo As Integer
   Public Property AltoMaximo() As Integer
      Get
         Return _AltoMaximo
      End Get
      Set(ByVal value As Integer)
         _AltoMaximo = value
      End Set
   End Property

   Private _AltoMinimo As Integer
   Public Property AltoMinimo() As Integer
      Get
         Return _AltoMinimo
      End Get
      Set(ByVal value As Integer)
         _AltoMinimo = value
      End Set
   End Property

   Private Sub FrmFindItem_Load(sender As Object, e As EventArgs)
      FillColumns()
      Dim PosicionTxt As Point
      PosicionTxt = TxtBusqueda.PointToScreen(PosicionTxt)
      Cursor.Position = PosicionTxt
      tmrValidControl.Enabled = True
      Dim Posicion As New Point(Me.PointToScreen(Posicion))
      AnchoInicio = Posicion.X
      AnchoFinal = Posicion.X + Me.Width
      AltoMinimo = Posicion.Y
      AltoMaximo = Posicion.Y + Me.Height
      Me.TxtBusqueda.Focus()
   End Sub

   Private Sub FillColumns()
      If GrdDatos.Rows.Count > 0 Then
         For Each row As DataGridViewColumn In GrdDatos.Columns
            row.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
         Next
      End If
     
   End Sub

  

   
   Private Sub tmrValidControl_Tick(sender As System.Object, e As System.EventArgs) Handles tmrValidControl.Tick
      Try
         Dim p As New Point(Me.PointToScreen(p))
         If ((MousePosition.X < AnchoInicio) Or (MousePosition.X > AnchoFinal)) Or ((MousePosition.Y < AltoMinimo) Or (MousePosition.Y > AltoMaximo)) Then
            Close()
         End If
      Catch ex As Exception
         Close()
      End Try
   End Sub
  
  
   Private Sub PicClose_Click(sender As System.Object, e As System.EventArgs) Handles PicClose.Click
      Me.Close()
   End Sub

  
   
    Private Sub FrmFindItem_Load1(sender As Object, e As System.EventArgs) Handles Me.Load
        Me.ActiveControl = TxtBusqueda
    End Sub
End Class
