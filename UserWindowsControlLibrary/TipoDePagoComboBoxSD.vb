

Public Class TipoDePagoComboBoxSD
   Inherits ComboBox

   Private db As New DataBaseSD.DataBaseSD.DataBaseSD
   Enum TypeObjects
      Table
      StoreProcedure
   End Enum

   Enum TiposDeOrden
      Desc
      Asc
   End Enum

   Private _ValidField As Boolean = False
   Public Property ValidField As Boolean
      Get
         Return _ValidField
      End Get
      Set(value As Boolean)
         _ValidField = value
      End Set
   End Property

   Private _DataBase As String = "DbRecursosHumanos"
   Public Property DataBase As String
      Get
         Return _DataBase
      End Get
      Set(value As String)
         _DataBase = value
      End Set
   End Property

   Private _Table As String
   Public ReadOnly Property Table
      Get
         Return "VwTiposDePago"
      End Get
   End Property

   Private _ColumnValue As String
   Public ReadOnly Property ColumnValue As String
      Get
         Return "TipoDePago"
      End Get
   End Property

   Private _SelectedValue As Object



   Private _ColumnDisplay As String
   Public ReadOnly Property ColumnDisplay As String
      Get
         Return "Descripcion"
      End Get      
   End Property

   Private _Conditions As String
   Public Property Conditions As String
      Get
         Return _Conditions
      End Get
      Set(value As String)
         _Conditions = value
      End Set
   End Property

   Private _AlternativeQuery As String
   Public Property AlternativeQuery As String
      Get
         Return _AlternativeQuery
      End Get
      Set(value As String)
         _AlternativeQuery = value
      End Set
   End Property


   Private _AddAll As Boolean
   Public Property AddAll As Boolean
      Get
         Return _AddAll
      End Get
      Set(value As Boolean)
         _AddAll = value
         Fill()
      End Set
   End Property

   Private _Object As TypeObjects
   Public Property Objects As TypeObjects
      Get
         Return _Object
      End Get
      Set(value As TypeObjects)
         _Object = value
      End Set
   End Property

   Private _User As String
   Public Property User As String
      Get
         Return _User
      End Get
      Set(value As String)
         _User = value
      End Set
   End Property

   Private _NumberOfZeros As Integer = 0
   Public Property NumberOfZeros As Integer
      Get
         Return _NumberOfZeros
      End Get
      Set(value As Integer)
         _NumberOfZeros = value
      End Set
   End Property

   Private _OrderBy As String = String.Empty
   Public Property OrderBy As String
      Get
         If String.IsNullOrEmpty(_OrderBy) Then Return Nothing
         Return _OrderBy
      End Get
      Set(value As String)
         _OrderBy = value
      End Set
   End Property

   Private _TipoDeOrden As TiposDeOrden = TiposDeOrden.Desc
   Public Property TipoDeOrden As TiposDeOrden
      Get
         Return _TipoDeOrden
      End Get
      Set(value As TiposDeOrden)
         _TipoDeOrden = value
      End Set
   End Property

   Public ReadOnly Property Query As String
      Get
         Dim sqlString As String
         sqlString = " SELECT " & Me.ColumnValue & ", RTRIM(CONVERT(VARCHAR," & Me.ColumnValue & "))+'-'+" & Me.ColumnDisplay & " Descripcion FROM " & Me.DataBase & ".dbo." & Me.Table
         If Not String.IsNullOrEmpty(Me.Conditions) Then sqlString &= " WHERE " & Conditions
         If Not String.IsNullOrEmpty(Me.AlternativeQuery) Then sqlString = AlternativeQuery
         Return sqlString
      End Get
   End Property

   Private _typeField As TiposDeCampo = TiposDeCampo.Personalizado

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

   Private _ConcatenarID As Boolean = True
   Public Property ConcatenarID As Boolean
      Get
         Return _ConcatenarID
      End Get
      Set(value As Boolean)
         _ConcatenarID = value
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
         Me.Enabled = False
      ElseIf Me.TypeField = TiposDeCampo.Opcional Then
         Me.BackColor = Color.LightGray
      Else
         Me.BackColor = Color.White
      End If
   End Sub

   Public Sub Fill()
      Dim cmd As New SqlClient.SqlCommand
      Dim sqlString As String = String.Empty
      Dim ExistsQuery As Integer = 0
      Dim oDataSet As New DataSet
      Try
         sqlString = Nothing
         If Not String.IsNullOrEmpty(Me.DataBase) And Not String.IsNullOrEmpty(Me.ColumnValue) And Not String.IsNullOrEmpty(Me.ColumnDisplay) Then
            If _Object = TypeObjects.Table Then
               If _NumberOfZeros > 0 Then
                  sqlString = "SELECT RIGHT(REPLICATE(0," & _NumberOfZeros + 1 & ")+CAST(" & Me.ColumnValue & " AS VARCHAR)," & _NumberOfZeros + 1 & ") Codigo, "
                  ''If _ConcatenarID Then 
                  sqlString &= " RIGHT(REPLICATE(0," & _NumberOfZeros + 1 & ")+ CAST(" & Me.ColumnValue & " AS VARCHAR)," & _NumberOfZeros + 1 & ")+'-'+"
                  sqlString &= Me.ColumnDisplay & " Descripcion FROM " & Me.DataBase & ".dbo." & Me.Table
               Else

                  sqlString = " SELECT RTRIM(CONVERT(VARCHAR," & Me.ColumnValue & ")) Codigo ,"
                  ''If _ConcatenarID Then
                  sqlString &= " RTRIM(CONVERT(VARCHAR," & Me.ColumnValue & "))+'-'+"
                  sqlString &= Me.ColumnDisplay & " Descripcion FROM " & Me.DataBase & ".dbo." & Me.Table
               End If


               If Not String.IsNullOrEmpty(Me.Conditions) Then sqlString &= " WHERE " & Conditions
               If Not String.IsNullOrEmpty(Me.AlternativeQuery) Then sqlString = AlternativeQuery
               If Me.AddAll Then
                  sqlString &= " union all "
                  sqlString &= "select '','-Todos-'"
               End If
               If String.IsNullOrEmpty(_OrderBy) Then
                  sqlString &= " order by 1"
               Else
                  sqlString &= " order by " & _OrderBy & " " & _TipoDeOrden.ToString
               End If


               Me.Text = ""
               Me.DataSource = db.ExecuteDataSet(CommandType.Text, sqlString).Tables(0)
               If Me.AddAll = True Then Me.SelectedValue = ""

            Else
               sqlString = ""
               oDataSet = db.ExecuteDataSet(_Table, _User)
               If oDataSet.Tables(0).Rows.Count > 0 Then
                  Me.DataSource = oDataSet.Tables(0)
                  Me.ValueMember = oDataSet.Tables(0).Columns(0).ColumnName.ToString
                  Me.DisplayMember = oDataSet.Tables(0).Columns(1).ColumnName.ToString
               End If
            End If
         End If
      Catch ex As Exception

         MsgBox(ex.Message, MsgBoxStyle.Information, "Mensaje del Sistema")
      End Try
   End Sub

   Public Sub New()
      ' This call is required by the designer.
      InitializeComponent()
      Fill()
      ' Add any initialization after the InitializeComponent() call.
      Me.ValueMember = "Codigo"
      Me.DisplayMember = "Descripcion"
   End Sub
   Private _TabEnter As Boolean = True
   ''' <summary>
   ''' Envia Tabulador al presionar Enter
   ''' </summary>
   ''' <value></value>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Property TabEnter As Boolean
      Get
         Return _TabEnter
      End Get
      Set(ByVal value As Boolean)
         _TabEnter = value
      End Set
   End Property

   Private Sub ComboBoxSD_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
      Set_TipoCampo()
      If TabEnter Then
         If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
         End If
      End If
   End Sub

   Private Sub TipoDePagoComboBoxSD_LostFocus(sender As Object, e As System.EventArgs) Handles Me.LostFocus

      Try
         If (CType(sender, ComboBox).SelectedValue Is Nothing) Then
            If _AddAll Then
               CType(sender, ComboBox).SelectedValue = ""
            Else
               If Not CType(sender, ComboBox).SelectedValue Is Nothing Then
                  CType(sender, ComboBox).SelectedValue = CType(sender, ComboBox).Text
               End If
            End If
         End If
      Catch ex As Exception
         MsgBox("Error al cambiar el foco del control " & ex.Message, MsgBoxStyle.Information, "Mensaje del sistema")
      End Try
   End Sub

   
 
   'Private Sub ComboBoxSD_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles Me.SelectedIndexChanged
   '   If (CType(sender, ComboBoxSD).SelectedValue Is Nothing) Then
   '      CType(sender, ComboBoxSD).SelectedValue = ""
   '   End If
   'End Sub

   Private Sub ComboBoxSD_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles Me.Validating
      Dim Index As Integer = 0
      Dim SelectedText As String
      Dim Length As Integer = 0

      If _typeField = TiposDeCampo.Obligatorio And _ValidField Then
         If (String.IsNullOrEmpty(Me.Text.Trim)) Then
            Me.BackColor = System.Drawing.Color.MistyRose
            ToolTip.Show(If(Not String.IsNullOrEmpty(Me.Tag), StrConv(Me.Tag, VbStrConv.ProperCase), StrConv(Me.Name.ToUpper.Replace(Me.GetType.Name.ToUpper, "").Replace("CBO", ""), VbStrConv.ProperCase)) & " es obligatorio ", Me, 0, -Me.Size.Height, 3000)
            e.Cancel = True
            Exit Sub
         End If
      End If


      If Not String.IsNullOrEmpty(Me.Text) Then
         Length = InStr(Me.Text, "-")
         If Length = 0 Then
            SelectedText = Me.Text
         Else
            SelectedText = Microsoft.VisualBasic.Left(Me.Text, Length - 1)
         End If
         Index = Me.FindString(SelectedText)
         If Index >= 0 Then
            Set_TipoCampo()
            Me.SelectedValue = SelectedText
            e.Cancel = False
         Else
            Me.BackColor = System.Drawing.Color.MistyRose
            Me.Text = "El registro no existe "
            Me.SelectionStart = 0
            Me.SelectionLength = Me.Text.Length
            e.Cancel = True
         End If
      End If
   End Sub

   Public Overrides Function ToString() As String
      Return "'" & Me.SelectedValue & "'"
   End Function
End Class

