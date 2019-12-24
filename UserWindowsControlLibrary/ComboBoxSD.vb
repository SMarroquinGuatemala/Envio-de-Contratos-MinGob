Imports System.Configuration

Public Class ComboBoxSD
   Inherits ComboBox


    Private db As New DataBaseSD.DataBaseSD.DataBaseSD
   Private frm As FrmFindItem
   Private vwFiltro As DataView

   Private Sub ConsultaKeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
      If e.KeyCode = Keys.Enter Then SeleccionarRow()
   End Sub

   Sub SeleccionarRow()
      Try
         Dim RowFound As DataRow
         If frm.GrdDatos.SelectedRows.Count > 0 Then
            RowFound = vwFiltro(frm.GrdDatos.SelectedRows(0).Index).Row
            Me.SelectedValue = RowFound.Item(0).ToString
         Else
            RowFound = Nothing
         End If
         frm.Dispose()
         frm.Close()
      Catch ex As Exception
         Throw
      End Try
   End Sub

   Private Sub ConsultaDblClick(sender As Object, e As EventArgs)
      SeleccionarRow()
   End Sub

   Private Sub CambioDeFiltro(ByVal sender As System.Object, ByVal e As System.EventArgs)
      Try
         Dim RowFilter As String = String.Empty, AddOr As Boolean = False
         If Len(sender.Text) > 1 And vwFiltro.Table IsNot Nothing Then
            'Armamos un filtro para cualquier columna de la tabla
            For i As Integer = 0 To vwFiltro.Table.Columns.Count - 1
               AddOr = False
               ' RowFilter &= xTable.Columns(i).ColumnName & "=" & Send(FindString)
               If vwFiltro.Table.Columns(i).DataType.ToString <> "System.Boolean" Then
                  If InStr(vwFiltro.Table.Columns(i).DataType.ToString, "Int") > 0 And IsNumeric(If(String.IsNullOrEmpty(sender.Text), "0", sender.text)) Then
                     RowFilter &= vwFiltro.Table.Columns(i).ColumnName & "= '" & sender.Text & "'"
                     AddOr = True
                  ElseIf InStr(vwFiltro.Table.Columns(i).DataType.ToString, "String") > 0 Then
                     RowFilter &= vwFiltro.Table.Columns(i).ColumnName & " like '%" & sender.Text & "%'"
                     AddOr = True
                  End If
                  If (i <> vwFiltro.Table.Columns.Count - 1 And Not String.IsNullOrEmpty(RowFilter) And AddOr) Then RowFilter &= " or "
               End If
            Next i
         Else
            RowFilter = ""
         End If
         If Not String.IsNullOrEmpty(RowFilter) Then
            If Trim(Mid(RowFilter, Len(RowFilter) - 3)) = "or" Then RowFilter = Mid(RowFilter, 1, Len(RowFilter) - 3)
         End If

         vwFiltro.RowFilter = RowFilter
         frm.GrdDatos.Refresh()
      Catch ex As Exception
         Throw
      End Try
   End Sub

   Private Sub FrmFindItem_KeyUp(sender As Object, e As KeyEventArgs)
      If e.KeyCode = Keys.Escape Then sender.Close()
   End Sub

   Private _ShowFindDialog As Boolean = True
   '<Description("habilita la opcion si se desea que se muestre un form para realizar una busqueda")> <DefaultValue(False)> _
   Public Property ShowFindDialog() As Boolean
      Get
         Return _ShowFindDialog
      End Get
      Set(ByVal value As Boolean)
         _ShowFindDialog = value
      End Set
   End Property


   Private Sub CreateFindForm()
      Dim DtOriginal, DtTemp As DataTable
      Dim Index As Integer = 0
      Dim RowFilter As String = String.Empty
      DtOriginal = Me.DataSource()
      DtTemp = DtOriginal.Clone
      For Each row As DataRow In DtOriginal.Rows
         DtTemp.ImportRow(row)
      Next
      For x As Integer = 0 To DtTemp.Rows.Count - 1
         Index = DtTemp.Rows(x).Item(1).ToString.IndexOf("-")
         DtTemp.Rows(x).Item(1) = DtTemp.Rows(x).Item(1).ToString.Substring(Index + 1, (DtTemp.Rows(x).Item(1).ToString.Length - Index) - 1)
      Next
      vwFiltro = DtTemp.DefaultView
      If Not String.IsNullOrEmpty(Me.Text) Then
         For i As Integer = 0 To DtTemp.Columns.Count - 1
            If InStr(DtTemp.Columns(i).DataType.ToString, "Int") > 0 And IsNumeric(If(String.IsNullOrEmpty(Me.Text), "0", Me.Text)) Then
               RowFilter &= DtTemp.Columns(i).ColumnName & "= '" & Me.Text & "'"
            ElseIf InStr(DtTemp.Columns(i).DataType.ToString, "String") > 0 Then
               RowFilter &= DtTemp.Columns(i).ColumnName & " like '%" & Me.Text & "%'"
            End If
            If i <> DtTemp.Columns.Count - 1 And Not (String.IsNullOrEmpty(RowFilter)) Then RowFilter &= " or "
         Next i
      End If
      vwFiltro.RowFilter = RowFilter
      If vwFiltro.Count = 1 Then ' Cuando encuentra alguna coincidencia la agregar al control
         Dim row As DataRow = vwFiltro(0).Row
         Me.Text = row.Item(0).ToString & "-" & row.Item(1).ToString
         SendKeys.Send("{TAB}")
      Else 'Si no se encontro ninguna concidencia
         Dim P As New Point(Me.PointToScreen(P))
         frm = New FrmFindItem
         frm.StartPosition = FormStartPosition.Manual
         frm.Location = New Point(P.X, P.Y + Me.Height)
         frm.TxtBusqueda.Text = Me.Text

         AddHandler frm.KeyUp, AddressOf FrmFindItem_KeyUp
         AddHandler frm.TxtBusqueda.TextChanged, AddressOf CambioDeFiltro
         AddHandler frm.GrdDatos.DoubleClick, AddressOf ConsultaDblClick
         AddHandler frm.GrdDatos.KeyDown, AddressOf ConsultaKeyDown
         frm.GrdDatos.DataSource = vwFiltro
         frm.GrdDatos.Columns(0).Width = 70
         frm.GrdDatos.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            frm.ShowDialog()
            'frm.TxtBusqueda.Focus()
            If String.IsNullOrEmpty(Me.SelectedValue) Then
                Dim PositionForm As New Point(frm.PointToScreen(PositionForm))
                'Valida si la posición del form es más grande que la resolución de pantalla
                'El formulario se despliega hacia arriba
                If (PositionForm.Y + frm.Height) > Screen.PrimaryScreen.WorkingArea.Bottom Then
                    frm.Location = New Point(P.X, P.Y - frm.Height)
                    Dim PosicionTxt As Point
                    Dim NewPosition As New Point(frm.PointToScreen(NewPosition))
                    If NewPosition.Y <= 0 Then
                        frm.Height = frm.Height + NewPosition.Y
                    End If
                    frm.Location = New Point(P.X, P.Y - frm.Height)
                    NewPosition = Nothing
                    NewPosition = New Point(frm.PointToScreen(NewPosition))
                    frm.AnchoInicio = NewPosition.X
                    frm.AnchoFinal = NewPosition.X + frm.Width
                    frm.AltoMinimo = NewPosition.Y
                    frm.AltoMaximo = NewPosition.Y + frm.Height
                    PosicionTxt = Nothing
                    PosicionTxt = New Point(frm.TxtBusqueda.PointToScreen(PosicionTxt))
                    Cursor.Position = PosicionTxt 'Posiciona el cursos en el texbox del filtro


                End If
            End If
            End If
    End Sub





   Enum TypeObjects
      Table
      StoreProcedure
   End Enum

   Enum TiposDeOrden
      Desc
      Asc
   End Enum

   Enum Servers
      SQLSDFCA5
      SQLTRFCA6
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

   Private _Server As Servers
   Public Property Server() As Servers
      Get
         Return _Server
      End Get
      Set(ByVal value As Servers)
         _Server = value
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
   Public Property Table As String
      Get
         Return _Table
      End Get
      Set(value As String)
         _Table = value

      End Set
   End Property

   Private _ColumnValue As String
   Public Property ColumnValue As String
      Get
         Return _ColumnValue
      End Get
      Set(value As String)
         _ColumnValue = value

      End Set
   End Property

   Private _SelectedValue As Object



   Private _ColumnDisplay As String
   Public Property ColumnDisplay As String
      Get
         Return _ColumnDisplay
      End Get
      Set(value As String)
         _ColumnDisplay = value
         Fill()
      End Set
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
                  If Me.AddAll Then
                     sqlString = "SELECT  Codigo, Descripcion FROM ("
                  End If
                  sqlString &= "SELECT RIGHT(REPLICATE(0," & _NumberOfZeros + 1 & ")+CAST(" & Me.ColumnValue & " AS VARCHAR)," & _NumberOfZeros + 1 & ") Codigo, "
                  ''If _ConcatenarID Then 
                  sqlString &= " RIGHT(REPLICATE(0," & _NumberOfZeros + 1 & ")+ CAST(" & Me.ColumnValue & " AS VARCHAR)," & _NumberOfZeros + 1 & ")+'-'+"
                  sqlString &= Me.ColumnDisplay & " Descripcion FROM " & Me.DataBase & ".dbo." & Me.Table
               Else
                  If Me.AddAll Then
                     sqlString = "SELECT  Codigo, Descripcion FROM ("
                  End If
                  sqlString &= "SELECT RTRIM(CONVERT(VARCHAR," & Me.ColumnValue & ")) Codigo ,"
                  ''If _ConcatenarID Then
                  sqlString &= " RTRIM(CONVERT(VARCHAR," & Me.ColumnValue & "))+'-'+"
                  sqlString &= Me.ColumnDisplay & " Descripcion FROM " & Me.DataBase & ".dbo." & Me.Table
               End If




               If Not String.IsNullOrEmpty(Me.Conditions) Then sqlString &= " WHERE " & Conditions
               If Not String.IsNullOrEmpty(Me.AlternativeQuery) Then sqlString = AlternativeQuery
               If Me.AddAll Then
                  If String.IsNullOrEmpty(AlternativeQuery) Then
                     sqlString &= " union all "
                     sqlString &= "select '','-Todos-') A"
                  Else
                     sqlString &= " union all "
                     sqlString &= "select '','-Todos-'"
                  End If
               End If
               If String.IsNullOrEmpty(_OrderBy) Then
                  sqlString &= " order by 1"
               Else
                  sqlString &= " order by " & _OrderBy & " " & _TipoDeOrden.ToString
               End If


               Me.Text = ""


               If Server = Servers.SQLTRFCA6 Then
                  db.ConnectionString = My.Settings.SQLTRFCA6
               Else
                  db.ConnectionString = My.Settings.SQLSDFCA5
               End If

               Me.DataSource = db.ExecuteDataSet(CommandType.Text, sqlString).Tables(0)
               If Me.AddAll = True Then Me.SelectedValue = ""

            Else

               If Server = Servers.SQLTRFCA6 Then
                  db.ConnectionString = My.Settings.SQLTRFCA6
               Else
                  db.ConnectionString = My.Settings.SQLSDFCA5
               End If
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
      Me.AutoCompleteMode = Windows.Forms.AutoCompleteMode.None
      Me.AutoCompleteSource = Windows.Forms.AutoCompleteSource.None
      ' Add any initialization after the InitializeComponent() call.
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



   Private Sub ComboBoxSD_LostFocus(sender As Object, e As System.EventArgs) Handles Me.LostFocus
      Try
         If (CType(sender, ComboBoxSD).SelectedValue Is Nothing) Then
            If _AddAll Then
               CType(sender, ComboBoxSD).SelectedValue = ""
            Else

               If Not CType(sender, ComboBoxSD).SelectedValue Is Nothing Then
                  CType(sender, ComboBoxSD).SelectedValue = CType(sender, ComboBoxSD).Text
               Else
                  If Not String.IsNullOrEmpty(CType(sender, ComboBoxSD).Text) Then CType(sender, ComboBoxSD).SelectedValue = CType(sender, ComboBoxSD).Text
                  Me.Focus()
               End If

            End If
         End If
      Catch ex As Exception
         Throw
      End Try
   End Sub



   Private Sub ComboBoxSD_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles Me.Validating
      Dim Index As Integer = 0
      Dim SelectedText As String
      Dim Length As Integer = 0

      Try
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
               If Me.SelectedValue Is Nothing Then Me.SelectedValue = Me.Items(Index)(0).ToString
               Me.OnSelectionChangeCommitted(e)
               e.Cancel = False
            Else

               If ShowFindDialog Then
                  CreateFindForm()
               Else
                  Me.BackColor = System.Drawing.Color.MistyRose
                  Me.Text = "El registro no existe "
                  Me.SelectionStart = 0
                  Me.SelectionLength = Me.Text.Length
                  e.Cancel = True
               End If
            End If
         End If
      Catch ex As Exception
         Throw
      End Try
   End Sub

   Public Overrides Function ToString() As String
      Try
         Return "'" & Me.SelectedValue & "'"
      Catch ex As Exception
         Throw
      End Try
   End Function
End Class

