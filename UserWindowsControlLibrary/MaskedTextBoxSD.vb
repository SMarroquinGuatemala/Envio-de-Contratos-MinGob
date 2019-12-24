Public Class MaskedTextBoxSD
   Inherits MaskedTextBox
   Private _typeField As TiposDeCampo = TiposDeCampo.Personalizado
   Private Mascara As String
   Private Validacion As Boolean = True


   Enum TiposDeCampo
      Undefined = 0
      Obligatorio = 1
      Opcional = 2
      Desplieque = 3
      Personalizado = 4
   End Enum

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

   Private Sub Set_TipoCampo()
      Me.TabStop = True
      Me.Enabled = True
      If Me.TypeField = TiposDeCampo.Obligatorio Then         
         Me.BackColor = Color.LemonChiffon
      ElseIf Me.TypeField = TiposDeCampo.Desplieque Then         
         Me.BackColor = Color.LightGreen
         Me.TabStop = False         
      ElseIf Me.TypeField = TiposDeCampo.Opcional Then         
         Me.BackColor = Color.LightGray
      Else         
         Me.BackColor = Color.White
      End If
   End Sub

   Private Sub MaskedTextBoxSD_GotFocus(sender As Object, e As System.EventArgs) Handles Me.GotFocus      
      CType(sender, MaskedTextBoxSD).SelectionStart = 0
      CType(sender, MaskedTextBoxSD).SelectionLength = CType(sender, MaskedTextBoxSD).Mask.Length
   End Sub

   Private Sub MaskedTextBoxSD_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
      Set_TipoCampo()
      Me.ToolTip.Hide(Me)
      If TabEnter Then
         If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
         End If
      End If
   End Sub

   Private Sub MaskedTextBoxSD_PreviewKeyDown(sender As Object, e As System.Windows.Forms.PreviewKeyDownEventArgs) Handles Me.PreviewKeyDown
      Validacion = True
      If (e.Modifiers = Keys.Shift AndAlso e.KeyCode.Equals(Keys.Tab)) Then
         Validacion = False
      End If
   End Sub

   Private Sub MaskedTextBoxSD_TypeValidationCompleted(sender As Object, e As System.Windows.Forms.TypeValidationEventArgs) Handles Me.TypeValidationCompleted
      Dim UserDate As DateTime
      If Validacion = True Then
         If _typeField = TiposDeCampo.Obligatorio Then
            If (String.IsNullOrEmpty(Me.Text.Replace(Me.Culture.DateTimeFormat.DateSeparator, "").Trim)) Then
               Me.BackColor = System.Drawing.Color.MistyRose
               ToolTip.Show(If(Not String.IsNullOrEmpty(Me.Tag), StrConv(Me.Tag, VbStrConv.ProperCase), StrConv(Me.Name.ToUpper.Replace(Me.GetType.Name.ToUpper, "").Replace("TXT", ""), VbStrConv.ProperCase)) & " es obligatorio ", Me, 0, -Me.Size.Height, 3000)
               e.Cancel = True
               Exit Sub
            End If
         End If

         If TypeField = TiposDeCampo.Opcional And String.IsNullOrEmpty((Me.Text.Replace(Me.Culture.DateTimeFormat.DateSeparator, "")).Replace(Me.Culture.DateTimeFormat.TimeSeparator, "").Trim) Then
            Set_TipoCampo()
            CType(sender, MaskedTextBoxSD).SelectionStart = 0
            CType(sender, MaskedTextBoxSD).SelectionLength = CType(sender, MaskedTextBoxSD).Mask.Length
            Exit Sub
         End If


         'Se valida que el texto ingresado sea valido
         If (Not e.IsValidInput) Then
            Me.BackColor = System.Drawing.Color.MistyRose
            ToolTip.Show("Formato incorrecto", Me, 0, -Me.Size.Height, 3000)
            e.Cancel = True

            Exit Sub
         Else
            'Se valida que el año de la fecha ingresado sea mayor de 1900
            If (e.ValidatingType = GetType(System.DateTime)) Then
               If Me.Mask = "00/00/0000" Then
                  If Me.Text.Split(Me.Culture.DateTimeFormat.DateSeparator)(Me.Text.Split(Me.Culture.DateTimeFormat.DateSeparator).GetUpperBound(0)).Length > 0 Then
                     If Me.Text.Split(Me.Culture.DateTimeFormat.DateSeparator)(Me.Text.Split(Me.Culture.DateTimeFormat.DateSeparator).GetUpperBound(0)).ToString < 1900 Then
                        Me.BackColor = System.Drawing.Color.MistyRose
                        ToolTip.Show("Formato incorrecto", Me, 0, -Me.Size.Height, 3000)
                        e.Cancel = True
                        'CType(sender, MaskedTextBoxSD).SelectionStart = 0
                        'CType(sender, MaskedTextBoxSD).SelectionLength = CType(sender, MaskedTextBoxSD).Mask.Length
                        Exit Sub
                     End If
                  End If
                  '
                  UserDate = CDate(e.ReturnValue)
                  'If (UserDate > DateTime.Now) Then
                  '   Me.BackColor = System.Drawing.Color.MistyRose
                  '   ToolTip.Show("La fecha para este campo debe ser menor o igual que la fecha de hoy.", Me, 0, -Me.Size.Height, 3000)
                  '   e.Cancel = True
                  '   'CType(sender, MaskedTextBoxSD).SelectionStart = 0
                  '   'CType(sender, MaskedTextBoxSD).SelectionLength = CType(sender, MaskedTextBoxSD).Mask.Length
                  'End If
               End If

            End If

         End If
      Else
         e.Cancel = False
         ToolTip.RemoveAll()
         Set_TipoCampo()
      End If


   End Sub


   Public Overrides Function ToString() As String
      If String.IsNullOrEmpty(Me.Text.Replace(Me.Culture.DateTimeFormat.DateSeparator, "").Replace(Me.Culture.DateTimeFormat.TimeSeparator, "").Trim) Then
         Return ""
      Else
         Return Me.Text
      End If
   End Function

End Class
