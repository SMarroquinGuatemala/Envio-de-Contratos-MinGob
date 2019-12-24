Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Collections

Namespace DataBaseSD

   Module ModuleSD
      'Public Function CreateParameterCopy(command As SqlCommand) As SqlParameter()
      '   Dim parameters As SqlParameterCollection = command.Parameters
      '   Dim parameterArray As SqlParameterCollection() = New SqlParameterCollection(parameters.Count) {}
      '   parameters.CopyTo(parameterArray, 0)
      '   Return CloneParameters(parameterArray)
      'End Function

      'Public Function CloneParameters(originalParameters As SqlParameterCollection()) As SqlParameter()
      '   Dim clonedParameters As SqlParameter() = New SqlParameter(originalParameters.Length) {}

      '   Dim i As Integer = 0, j As Integer = originalParameters.Length
      '   While i < j

      '      clonedParameters(i) = CType((CType(originalParameters(i),)).Clone(), IDataParameter)
      '      System.Math.Max(System.Threading.Interlocked.Increment(i), i - 1)

      '   End While

      '   Return clonedParameters
      'End Function

      Public Function CreateHashKey(connectionString As String, storedProcedure As String) As String
         Return connectionString + ":" + storedProcedure
      End Function

      Public Sub PrepareCommand(command As SqlCommand, connection As SqlConnection)
         If command Is Nothing Then Throw New ArgumentNullException("command")
         If connection Is Nothing Then Throw New ArgumentNullException("connection")
         command.Connection = connection
      End Sub

   End Module

End Namespace
