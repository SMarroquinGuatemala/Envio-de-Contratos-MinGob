Public Class CtrlListado
   Private Checked As String
   Public Event Seleccion()
   Private _SelectedChar As String

   Public Property SelectedChar As String
      Get
         SelectedChar = _SelectedChar
      End Get
      Set(value As String)
         _SelectedChar = value
      End Set
   End Property

   Private Sub CtrlListado_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
      Try
         GenerateEvent()
      Catch ex As Exception
         MsgBox(ex.Message)
      End Try
   End Sub

   Private Sub GenerateEvent()
      For Each Control In Controls
         If TypeOf Control Is RadioButton Then
            AddHandler CType(Control, RadioButton).Click, AddressOf Seleccion_click
         End If
      Next
   End Sub

   Private Sub Seleccion_click(sender As System.Object, e As System.EventArgs)
      If CType(sender, RadioButton).Checked Then
         SelectedChar = CType(sender, RadioButton).Text
         If Checked = CType(sender, RadioButton).Name Then
            SelectedChar = ""
            CType(sender, RadioButton).Checked = False
         End If
         RaiseEvent Seleccion()
      End If
      Checked = CType(sender, RadioButton).Name
   End Sub


End Class
