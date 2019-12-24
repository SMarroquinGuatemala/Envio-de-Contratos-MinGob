Imports System.Text.RegularExpressions

Public Class TextBoxSD
   Inherits TextBox
   Private Validacion As Boolean = True

   Enum TiposDeCampo
      Undefined = 0
      Obligatorio = 1
      Opcional = 2
      Desplieque = 3
      Personalizado = 4
   End Enum

   Enum InputFormat
      InputNumber
      InputDecimal
      InputString
   End Enum

   Private _typeField As TiposDeCampo = TiposDeCampo.Personalizado
   Public Property TypeField As TiposDeCampo
      Get
         Return _typeField
      End Get
      Set(ByVal value As TiposDeCampo)
         _typeField = value
         Set_TipoCampo()
      End Set
   End Property

   Private _TabEnter As Boolean = True
   Public Property TabEnter As Boolean
      Get
         Return _TabEnter
      End Get
      Set(ByVal value As Boolean)
         _TabEnter = value
      End Set
   End Property

   Private _NumberDecimal As Integer
   Public Property NumberDecimal As Integer
      Get
         Return _NumberDecimal
      End Get
      Set(value As Integer)
         _NumberDecimal = value
         If Not _FormatInput = InputFormat.InputDecimal Then _NumberDecimal = 0
      End Set
   End Property

   Private _FormatInput As InputFormat = InputFormat.InputString
   Public Property FormatInput As InputFormat
      Get
         Return _FormatInput
      End Get
      Set(value As InputFormat)
         _FormatInput = value
         If Not _FormatInput = InputFormat.InputDecimal Then _NumberDecimal = 0
      End Set
   End Property

   Private _ValidField As Boolean = False
   Public Property ValidField As Boolean
      Get
         Return _ValidField
      End Get
      Set(value As Boolean)
         _ValidField = value
      End Set
   End Property

   Private Sub TextBoxSD_GotFocus(sender As Object, e As System.EventArgs) Handles Me.GotFocus
      Me.SelectionStart = 0
      Me.SelectionLength = Me.Text.Length
   End Sub

   Private Sub TextBoxSD_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
      Set_TipoCampo()
      Me.ToolTip.Hide(Me)
      If TabEnter Then
         If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
         End If
      End If
   End Sub

   Private Sub Set_TipoCampo()
      Me.Enabled = True
      Me.TabStop = True
      If Me.TypeField = TiposDeCampo.Obligatorio Then
         Me.BackColor = Color.LemonChiffon
         Me.ReadOnly = False
      ElseIf Me.TypeField = TiposDeCampo.Desplieque Then         
         Me.BackColor = Color.LightGreen
         Me.TabStop = False
         Me.ReadOnly = True
      ElseIf Me.TypeField = TiposDeCampo.Opcional Then         
         Me.BackColor = Color.LightGray
         Me.ReadOnly = False
      Else         
         Me.BackColor = Color.White
         Me.ReadOnly = False
      End If
   End Sub

   Private Sub TextBoxSD_PreviewKeyDown(sender As Object, e As System.Windows.Forms.PreviewKeyDownEventArgs) Handles Me.PreviewKeyDown
      Validacion = True
      If (e.Modifiers = Keys.Shift AndAlso e.KeyCode.Equals(Keys.Tab)) Then
         Validacion = False
      End If
   End Sub

   

   Private Sub TextBoxSD_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles Me.Validating

      Dim re As Regex
      If Validacion = True Then
         If _typeField = TiposDeCampo.Obligatorio And _ValidField Then
            If (String.IsNullOrEmpty(Me.Text.Trim)) Then
               Me.BackColor = System.Drawing.Color.MistyRose
               ToolTip.Show(If(Not String.IsNullOrEmpty(Me.Tag), StrConv(Me.Tag, VbStrConv.ProperCase), StrConv(Me.Name.ToUpper.Replace(Me.GetType.Name.ToUpper, "").Replace("TXT", ""), VbStrConv.ProperCase)) & " es obligatorio ", Me, 0, -Me.Size.Height, 3000)
               e.Cancel = True
               Exit Sub
            End If
         End If

         If (TypeField = TiposDeCampo.Opcional And String.IsNullOrEmpty(Me.Text)) Then
            Set_TipoCampo()
            CType(sender, TextBox).SelectionStart = 0
            CType(sender, TextBox).SelectionLength = CType(sender, TextBox).Text.Length
            Exit Sub
         End If

         If FormatInput = InputFormat.InputDecimal Then
            re = New Regex("^[0-9]+\.?[0-9]{1," & 9 & "}$|^.?[0-9]{1," & 4 & "}$", RegexOptions.IgnoreCase)
            If Not (re.IsMatch(Me.Text.Trim)) Then
               Me.BackColor = System.Drawing.Color.MistyRose
               ToolTip.Show("Formato incorrecto", Me, 0, -Me.Size.Height, 3000)
               e.Cancel = True
               Exit Sub
            Else
               e.Cancel = False
            End If
         End If

         If FormatInput = InputFormat.InputNumber Then
            re = New Regex("^[0-9]*$", RegexOptions.IgnoreCase)
            If Not (re.IsMatch(Me.Text.Trim)) Then
               Me.BackColor = System.Drawing.Color.MistyRose
               ToolTip.Show("Formato incorrecto", Me, 0, -Me.Size.Height, 3000)
               e.Cancel = True
               Exit Sub
            Else
               e.Cancel = False
            End If
         End If
      Else
         e.Cancel = False
         ToolTip.RemoveAll()
         Set_TipoCampo()
      End If

   End Sub

   Public Sub New()

      ' This call is required by the designer.
      InitializeComponent()

      ' Add any initialization after the InitializeComponent() call.

   End Sub
End Class
