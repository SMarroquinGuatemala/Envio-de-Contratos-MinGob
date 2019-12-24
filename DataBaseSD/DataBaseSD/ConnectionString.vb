Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Text
Imports DataBaseSD.My.Resources



Namespace DataBaseSD


   Public Class ConnectionString
      Private _ConnectionString As String
      Public Sub New(connectionString As String)
         If String.IsNullOrEmpty(connectionString) Then
            Throw New ArgumentException(Resources.ExceptionNullOrEmptyString, "connectionString")
         End If
         Me._ConnectionString = connectionString
      End Sub

      Public Function CreateNewConnectionString(connectionStringToFormat As String) As ConnectionString
         Return New ConnectionString(connectionStringToFormat)
      End Function

      Public Property ConnectionString As String
         Get
            Return _ConnectionString
         End Get
         Set(value As String)
            _ConnectionString = value
         End Set
      End Property

      Public Overrides Function ToString() As String
         Return _ConnectionString
      End Function
   End Class
End Namespace

