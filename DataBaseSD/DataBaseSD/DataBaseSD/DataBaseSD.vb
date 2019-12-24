Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Globalization
Imports System.Configuration

Namespace DataBaseSD
   Public Class DataBaseSD
      Public Enum ObjectsDataBase
         DataBases
         Tables
         Columns
      End Enum

      Dim dbConnectionString As New ConnectionString(My.Settings(My.Settings.CnDefault).ToString)
      Dim connection As SqlConnection = New SqlConnection(dbConnectionString.ConnectionString)
      Public ReadOnly Property Server As String
         Get
            Return connection.DataSource
         End Get
      End Property

      Public ReadOnly Property DataBase As String
         Get
            Return connection.Database
         End Get
      End Property

      Public ReadOnly Property ConnectionString As String
         Get
            Return dbConnectionString.ToString
         End Get
      End Property

      Public Function CreateConnection() As SqlConnection
         Dim newConnection As SqlConnection = New SqlConnection
         newConnection.ConnectionString = ConnectionString
         Return newConnection
      End Function

      Friend Function GetNewOpenConnection() As SqlConnection
         Dim connection As SqlConnection = Nothing
         Try
            Try
               connection = CreateConnection()
               connection.Open()
            Catch e As Exception
               Throw
            End Try
         Catch
            If connection IsNot Nothing Then
               connection.Close()
            End If
            Throw
         End Try
         Return connection
      End Function

      Public Function GetStoredProcCommand(storedProcedureName As String) As SqlCommand
         If String.IsNullOrEmpty(storedProcedureName) Then
            Throw New ArgumentException(My.Resources.ExceptionNullOrEmptyString, "storedProcedureName")
         End If
         Return CreateCommandByCommandType(CommandType.StoredProcedure, storedProcedureName)
      End Function

      Public Function GetStoredProcCommand(storedProcedureName As String, ParamArray parameterValues As Object()) As SqlCommand
         If String.IsNullOrEmpty(storedProcedureName) Then
            Throw New ArgumentException(My.Resources.ExceptionNullOrEmptyString, "storedProcedureName")
         End If
         Dim command As SqlCommand = CreateCommandByCommandType(CommandType.StoredProcedure, storedProcedureName)
         AssignParameters(command, parameterValues)
         Return command
      End Function

      Public Sub AssignParameters(command As SqlCommand, parameterValues As Object())
         DiscoverParameters(command)
         If SameNumberOfParametersAndValues(command, parameterValues) = False Then
            Throw New InvalidOperationException(My.Resources.ExceptionMessageParameterMatchFailure)
         End If
         AssignParameterValues(command, parameterValues)
      End Sub

      Public Sub AddInParameter(command As SqlCommand, name As String, dbType As DbType)
         AddParameter(command, name, dbType, ParameterDirection.Input, [String].Empty, DataRowVersion.[Default], Nothing)
      End Sub

      Public Sub AddInParameter(command As SqlCommand, name As String, dbType As DbType, value As Object)
         AddParameter(command, name, dbType, ParameterDirection.Input, [String].Empty, DataRowVersion.[Default], value)
      End Sub

      Public Sub AddParameter(command As SqlCommand, name As String, dbType As DbType, direction As ParameterDirection, sourceColumn As String, sourceVersion As DataRowVersion, value As Object)
         AddParameter(command, name, dbType, 0, direction, False, 0, 0, sourceColumn, sourceVersion, value)
      End Sub

      Public Sub AddParameter(command As SqlCommand, name As String, dbType As DbType, size As Integer, direction As ParameterDirection, nullable As Boolean, precision As Byte, scale As Byte, sourceColumn As String, sourceVersion As DataRowVersion, value As Object)
         If command Is Nothing Then
            Throw New ArgumentNullException("command")
         End If
         Dim parameter As SqlParameter = CreateParameter(name, dbType, size, direction, nullable, precision, scale, sourceColumn, sourceVersion, value)
         command.Parameters.Add(parameter)
      End Sub

      Public Function CreateParameter(name As String, dbType As DbType, size As Integer, direction As ParameterDirection, nullable As Boolean, precision As Byte, scale As Byte, sourceColumn As String, sourceVersion As DataRowVersion, value As Object) As SqlParameter
         Dim param As SqlParameter = CreateParameter(name)
         ConfigureParameter(param, name, dbType, size, direction, nullable, precision, scale, sourceColumn, sourceVersion, value)
         Return param
      End Function

      Protected Sub ConfigureParameter(param As SqlParameter, name As String, dbType As DbType, size As Integer, direction As ParameterDirection, nullable As Boolean, precision As Byte, scale As Byte, sourceColumn As String, sourceVersion As DataRowVersion, value As Object)
         param.DbType = dbType
         param.Size = size
         param.Value = If(value <> Nothing, value, DBNull.Value)
         param.Direction = direction
         param.IsNullable = nullable
         param.SourceColumn = sourceColumn
         param.SourceVersion = sourceVersion
      End Sub

      Protected Function CreateParameter(name As String) As SqlParameter
         Dim param As SqlParameter = New SqlParameter
         param.ParameterName = BuildParameterName(name)
         Return param
      End Function

      Public Function GetSchema(ByVal Objects As ObjectsDataBase) As DataTable
         'Public Function GetSchema() As DataTable
         Try
            Using connection = GetNewOpenConnection()
               Return connection.GetSchema(Objects.ToString)
            End Using
         Catch ex As Exception
            Throw
         End Try
      End Function

      Protected Sub DeriveParameters(discoveryCommand As SqlCommand)
         'Using connection = GetNewOpenConnection()
         '   connection.GetSchema("Procedures")
         '   Dim procedureDataTable As DataTable = connection.GetSchema("Procedures")
         '   Dim procedureDataColumn As DataColumn = procedureDataTable.Columns("ROUTINE_NAME")
         discoveryCommand.Connection = GetNewOpenConnection()
         SqlCommandBuilder.DeriveParameters(discoveryCommand)
         'End Using
      End Sub

      Public Sub DiscoverParameters(command As SqlCommand)
         If command Is Nothing Then
            Throw New ArgumentNullException("command")
         End If
         Using discoveryCommand As SqlCommand = CreateCommandByCommandType(command.CommandType, command.CommandText)
            DeriveParameters(discoveryCommand)
            For Each parameter As SqlParameter In discoveryCommand.Parameters
               Dim cloneParameter As SqlParameter = CType(CType(parameter, ICloneable).Clone(), SqlParameter)
               command.Parameters.Add(cloneParameter)
            Next
         End Using
      End Sub

      Private Sub AssignParameterValues(command As SqlCommand, values As Object())
         Dim parameterIndexShift As Integer = 1
         Dim i As Integer = 0
         While i < values.Length
            Dim parameter As IDataParameter = command.Parameters(i + parameterIndexShift)
            SetParameterValue(command, parameter.ParameterName, values(i))
            System.Math.Max(System.Threading.Interlocked.Increment(i), i - 1)
         End While
      End Sub

      Protected Function SameNumberOfParametersAndValues(command As SqlCommand, values As Object()) As Boolean
         Dim returnParameterCount As Integer = 1
         Dim numberOfParametersToStoredProcedure As Integer = command.Parameters.Count - returnParameterCount
         Dim numberOfValuesProvidedForStoredProcedure As Integer = values.Length
         Return numberOfParametersToStoredProcedure = numberOfValuesProvidedForStoredProcedure
      End Function

      Protected ReadOnly Property ParameterToken() As Char
         Get
            Return "@"c
         End Get
      End Property

      Public Function BuildParameterName(name As String) As String
         If name = Nothing Then
            Throw New ArgumentNullException("name")
         End If

         If name(0) <> ParameterToken Then
            Return name.Insert(0, New String(ParameterToken, 1))
         End If
         Return name
      End Function

      Public Sub SetParameterValue(command As SqlCommand, parameterName As String, value As Object)
         If command Is Nothing Then
            Throw New ArgumentNullException("command")
         End If
         If value IsNot Nothing Then
            If Not value.GetType Is GetType(Boolean) Then
               command.Parameters(BuildParameterName(parameterName)).Value = If(value <> Nothing, value, DBNull.Value)
            Else
               command.Parameters(BuildParameterName(parameterName)).Value = value
            End If
         Else
            command.Parameters(BuildParameterName(parameterName)).Value = If(value <> Nothing, value, DBNull.Value)
         End If
      End Sub

      Public Overridable Function GetParameterValue(command As SqlCommand, name As String) As Object
         If command Is Nothing Then
            Throw New ArgumentNullException("command")
         End If
         Return command.Parameters(BuildParameterName(name)).Value
      End Function

      Public Function GetSqlStringCommand(query As String) As SqlCommand
         If String.IsNullOrEmpty(query) Then
            Throw New ArgumentException(My.Resources.ExceptionNullOrEmptyString, "query")
         End If
         Return CreateCommandByCommandType(CommandType.Text, query)
      End Function

      Private Function CreateCommandByCommandType(commandType As CommandType, commandText As String) As SqlCommand
         Dim command As SqlCommand = New SqlCommand
         command.CommandType = commandType
         command.CommandText = commandText
         command.CommandTimeout = 180
         Return command
      End Function

      Public Function ExecuteNonQuery(command As SqlCommand) As Integer
         Using Connection = GetNewOpenConnection()
            PrepareCommand(command, Connection)
            Return DoExecuteNonQuery(command)
         End Using
      End Function

      Public Function ExecuteNonQuery(storedProcedureName As String, ParamArray parameterValues As Object()) As Integer
         Using command As SqlCommand = GetStoredProcCommand(storedProcedureName, parameterValues)
            Return ExecuteNonQuery(command)
         End Using
      End Function

      Public Function ExecuteNonQuery(commandType As CommandType, commandText As String) As Integer
         Using command As SqlCommand = CreateCommandByCommandType(commandType, commandText)
            Return ExecuteNonQuery(command)
         End Using
      End Function

      Protected Function DoExecuteNonQuery(command As SqlCommand) As Integer
         If command Is Nothing Then Throw New ArgumentNullException("command")
         Try
            Dim rowsAffected As Integer = command.ExecuteNonQuery()
            Return rowsAffected
         Catch e As Exception

            Throw
         End Try
      End Function

      Public Function ExecuteScalar(command As SqlCommand) As Object
         If command Is Nothing Then Throw New ArgumentNullException("command")
         Using connection = GetNewOpenConnection()
            PrepareCommand(command, connection)
            Return DoExecuteScalar(command)
         End Using
      End Function

      Public Function ExecuteScalar(storedProcedureName As String, ParamArray parameterValues As Object()) As Object
         Using command As SqlCommand = GetStoredProcCommand(storedProcedureName, parameterValues)
            Return ExecuteScalar(command)
         End Using
      End Function

      Public Function ExecuteScalar(commandType As CommandType, commandText As String) As Object
         Using command As SqlCommand = CreateCommandByCommandType(commandType, commandText)
            Return ExecuteScalar(command)
         End Using
      End Function

      Private Function DoExecuteScalar(command As SqlCommand) As Object
         Try
            Dim returnValue As Object = command.ExecuteScalar()
            Return returnValue
         Catch e As Exception
            Throw
         End Try
      End Function

      Protected Function GetDataAdapter() As SqlDataAdapter
         Dim adapter As SqlDataAdapter = New SqlDataAdapter
         Return adapter
      End Function

      Public Function ExecuteDataSet(command As SqlCommand) As DataSet
         Dim dataSet As New DataSet()
         dataSet.Locale = CultureInfo.InvariantCulture
         LoadDataSet(command, dataSet, "Table")
         Return dataSet
      End Function

      Public Function ExecuteDataSet(storedProcedureName As String, ParamArray parameterValues As Object()) As DataSet
         Using command As SqlCommand = GetStoredProcCommand(storedProcedureName, parameterValues)
            Return ExecuteDataSet(command)
         End Using
      End Function

      Public Function ExecuteDataSet(commandType As CommandType, commandText As String) As DataSet
         Using command As SqlCommand = CreateCommandByCommandType(commandType, commandText)
            Return ExecuteDataSet(command)
         End Using
      End Function

      Public Sub LoadDataSet(command As SqlCommand, dataSet As DataSet, tableNames As String())
         Using connection = GetNewOpenConnection()
            PrepareCommand(command, connection)
            DoLoadDataSet(command, dataSet, tableNames)
         End Using
      End Sub

      Public Sub LoadDataSet(command As SqlCommand, dataSet As DataSet, tableName As String)
         LoadDataSet(command, dataSet, {tableName})
      End Sub

      Public Sub LoadDataSet(storedProcedureName As String, dataSet As DataSet, tableNames As String(), ParamArray parameterValues As Object())
         Using command As SqlCommand = GetStoredProcCommand(storedProcedureName, parameterValues)
            LoadDataSet(command, dataSet, tableNames)
         End Using
      End Sub

      Public Sub LoadDataSet(commandType As CommandType, commandText As String, dataSet As DataSet, tableNames As String())
         Using command As SqlCommand = CreateCommandByCommandType(commandType, commandText)
            LoadDataSet(command, dataSet, tableNames)
         End Using
      End Sub

      Private Sub DoLoadDataSet(command As SqlCommand, dataSet As DataSet, tableNames As String())
         Dim i As Integer = 0
         If tableNames Is Nothing Then
            Throw New ArgumentNullException("tableNames")
         End If
         If tableNames.Length = 0 Then
            Throw New ArgumentException(My.Resources.ExceptionTableNameArrayEmpty, "tableNames")
         End If

         While i < tableNames.Length
            If String.IsNullOrEmpty(tableNames(i)) Then
               Throw New ArgumentException(My.Resources.ExceptionNullOrEmptyString, String.Concat("tableNames[", i, "]"))
            End If
            System.Math.Max(System.Threading.Interlocked.Increment(i), i - 1)
         End While

         Using adapter As SqlDataAdapter = GetDataAdapter()
            CType(adapter, SqlDataAdapter).SelectCommand = command
            Try

               Dim systemCreatedTableNameRoot As String = "Table"
               i = 0
               While i < tableNames.Length
                  Dim systemCreatedTableName As String = If((i = 0), systemCreatedTableNameRoot, systemCreatedTableNameRoot + i)
                  adapter.TableMappings.Add(systemCreatedTableName, tableNames(i))
                  System.Math.Max(System.Threading.Interlocked.Increment(i), i - 1)
               End While
               adapter.Fill(dataSet)
            Catch e As Exception

               Throw
            End Try
         End Using
      End Sub


   End Class

End Namespace