Public Class UsrFilterData
   Private _DatosParametros As DataTable
   Private _DtOperadoresLogicos As DataTable

   Public Property DatosParametros As DataTable
      Get
         Return _DatosParametros
      End Get
      Set(ByVal value As DataTable)
         _DatosParametros = value
         If _DatosParametros IsNot Nothing Then
            CboCampo.DataSource = _DatosParametros
            CboCampo.ValueMember = "ParameterType"
            CboCampo.DisplayMember = "ColumnName"
         End If
      End Set
   End Property

   Public Property DtOperadoresLogicos As DataTable
      Get
         Return _DtOperadoresLogicos
      End Get
      Set(value As DataTable)
         _DtOperadoresLogicos = value
         If _DtOperadoresLogicos IsNot Nothing Then
            CboCondiciones.DataSource = _DtOperadoresLogicos
            CboCondiciones.ValueMember = "Codigo"
            CboCondiciones.DisplayMember = "Descripcion"
         End If
      End Set
   End Property

   Private Sub TxtCriterio_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCriterio.KeyPress
      ValidaEntrada(sender, e, , , "/", , True)
   End Sub

   Private Sub CboCondiciones_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles CboCondiciones.SelectionChangeCommitted
      If CboCondiciones.Text = "Es Nulo" Then
         TxtCriterio.Clear()
         TxtCriterio.Enabled = False
      Else
         TxtCriterio.Enabled = True
      End If
   End Sub

   Private Sub CboCondiciones_Validating(sender As System.Object, e As System.ComponentModel.CancelEventArgs) Handles CboCondiciones.Validating
      Try
         If Not String.IsNullOrEmpty(CboCondiciones.SelectedValue) Then
            If Not F_Null(CboCampo.SelectedValue) Then
               If CboCondiciones.Text = "Parecido a" Then
                  If InStr("smalldatetime,int,decimal,date,numeric,money,datetime,float,Bit,tinyint,smallint", ReturnFieldType(CboCampo.SelectedValue.ToString.Split(" ")(1))) > 0 Then
                     MsgBox("No se puede usar esta condicion para el campo seleccionado....", MsgBoxStyle.Information, "Mensaje Del Sistema")
                     e.Cancel = True
                  End If
               ElseIf CboCondiciones.Text = "Es Nulo" Then
                  TxtCriterio.Clear()
                  TxtCriterio.Enabled = False
               Else
                  TxtCriterio.Enabled = True
               End If
            End If
         End If
      Catch ex As Exception
         MsgBox(ex.Message, "Seleccion de Condicion")
      End Try
   End Sub

   Private Function ReturnFieldType(ByVal value As String) As String
      ReturnFieldType = Nothing
      Try
         value = value.Replace("(", Nothing)
         value = value.Replace(")", Nothing)
         value = value.Replace(",", Nothing)
         Dim Numeros() As Integer = {0, 1, 2, 3, 4, 5, 6, 7, 8, 9}
         For Each Numero In Numeros
            value = value.Replace(Numero, Nothing)
         Next
         Return value
      Catch ex As Exception
         Throw
      End Try
   End Function

   Private Sub TxtCriterio_Validating(sender As System.Object, e As System.ComponentModel.CancelEventArgs) Handles TxtCriterio.Validating
      Try
         If Not String.IsNullOrEmpty(CboCondiciones.SelectedValue) Then
            If Not F_Null(CboCampo.SelectedValue) Then
               If Not String.IsNullOrEmpty(TxtCriterio.Text) Then
                  If InStr("smalldatetime,date,datetime", ReturnFieldType(CboCampo.SelectedValue.ToString.Split(" ")(1))) > 0 Then
                     If Not IsDate(TxtCriterio.Text) Then
                        MsgBox("La fecha ingresada no es valida", MsgBoxStyle.Information, "Mensaje Del Sistema")
                        e.Cancel = True
                     End If
                  ElseIf InStr("int,decimal,numeric,money,tinyint,smallint", ReturnFieldType(CboCampo.SelectedValue.ToString.Split(" ")(1))) > 0 Then
                     If Not IsNumeric(TxtCriterio.Text) Then
                        MsgBox("Ingrese un dato Numerico", MsgBoxStyle.Information, "Mensaje Del Sistema")
                        e.Cancel = True
                     End If
                  End If
               End If
            End If
         End If
      Catch ex As Exception
         MsgBox(ex, MsgBoxStyle.Information, "validacion de Criterio")
      End Try
   End Sub

   Public Function F_Null(ByVal xstring As String) As Boolean
      F_Null = True
      If xstring Is Nothing Then
         F_Null = True
      ElseIf Len(LTrim(RTrim(xstring))) = 0 Or xstring = "__/__/____" Or xstring = "__-___.___" Or xstring = "  -   ." Or xstring = "  -   .   " Or xstring = "__:__" Or xstring = "  /  /" Or Trim(xstring) = ":" Or Trim(xstring) = Trim("  /  /   :") Then
         F_Null = True
      Else
         F_Null = False
      End If
   End Function
   Public Function F_Null(ByVal Row As DataRow) As Boolean
      If Row Is Nothing Then Return True Else Return False
   End Function
   Public Function F_Null(ByVal Table As DataTable) As Boolean
      If Table Is Nothing Then Return True Else Return False
   End Function
   Public Function F_Null(ByVal xobject As Object) As Boolean
      Try
         F_Null = True
         If xobject Is Nothing Then
            F_Null = True
         ElseIf Len(LTrim(RTrim(xobject))) = 0 Or xobject = "__/__/____" Or xobject = "__-___.___" Or xobject = "  -   .   " Or xobject = "__:__" Or xobject = "  /  /" Or Trim(xobject) = ":" Or Trim(xobject) = Trim("  /  /   :") Then
            F_Null = True
         Else
            F_Null = False
         End If
      Catch ex As Exception
         MsgBox(ex, MsgBoxStyle.Information, " validar campos nulos")
      End Try
   End Function

   Public Sub ValidaEntrada(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs, Optional ByVal Numeros As Boolean = True, Optional ByVal Letras As Boolean = True,
                          Optional ByVal CarEspecial As String = Nothing, Optional ByVal AceptaPunto As Boolean = False, Optional ByVal AceptaEspacio As Boolean = False)
      Dim caracter As Char = e.KeyChar
      Dim txt As TextBox = CType(sender, TextBox)
      If caracter = ChrW(Keys.Enter) Then
         e.Handled = False
      ElseIf AceptaEspacio = True And Char.IsSeparator(caracter) Then
         e.Handled = False
      ElseIf Char.IsControl(caracter) Then
         e.Handled = False
      ElseIf Letras = True And Char.IsLetter(caracter) Then
         e.Handled = False
      ElseIf Numeros = True And Char.IsNumber(caracter) Then
         e.Handled = False
      ElseIf CarEspecial IsNot Nothing AndAlso caracter = CarEspecial Then
         e.Handled = False
      ElseIf AceptaPunto = True AndAlso F_Null(txt.Text) And e.KeyChar = "." Then
         e.Handled = True
      ElseIf AceptaPunto = True AndAlso caracter = "." And (txt.Text.Contains(".") = False) Then
         e.Handled = False
      Else
         e.Handled = True
      End If
   End Sub

End Class
