Imports System.Data
Imports System.Data.SqlClient
Imports System.Web.Configuration

Namespace SIS.SYS.SQLDatabase
  Public Class DBCommon
    Implements IDisposable
    Private Shared ReadOnly _conString As String = ""
    Private Shared ReadOnly _banString As String = ""
    Public Shared Function GetBaaNConnectionString() As String
      Return _banString
    End Function
    Public Shared Function GetConnectionString() As String
      Return _conString
    End Function
    Shared Sub New()
      Dim conSettings As ConnectionStringSettings = WebConfigurationManager.ConnectionStrings("AspNetDBConnection")
      If conSettings Is Nothing Then
        Throw New ConfigurationErrorsException("Missing AspNetDBConnection connection String.")
      End If
      Dim tmpERP As ConnectionStringSettings = Nothing
      If WebConfigurationManager.AppSettings("UseBaaN").ToString.ToLower = "Live".ToLower Then
        tmpERP = WebConfigurationManager.ConnectionStrings("BaaNLiveConnection")
      Else
        tmpERP = WebConfigurationManager.ConnectionStrings("BaaNTestConnection")
      End If
      _conString = conSettings.ConnectionString
      _banString = tmpERP.ConnectionString
    End Sub
    Public Shared Sub AddDBParameter(ByRef Cmd As SqlCommand, ByVal name As String, ByVal type As SqlDbType, ByVal size As Integer, ByVal value As Object)
      Dim Parm As SqlParameter = Cmd.CreateParameter()
      Parm.ParameterName = name
      Parm.SqlDbType = type
      Parm.Size = size
      Parm.Value = value
      Cmd.Parameters.Add(Parm)
    End Sub
    Private disposedValue As Boolean = False    ' To detect redundant calls
    ' IDisposable
    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
      If Not Me.disposedValue Then
        If disposing Then
          ' TODO: free unmanaged resources when explicitly called
        End If

        ' TODO: free shared unmanaged resources
      End If
      Me.disposedValue = True
    End Sub
#Region " IDisposable Support "
    ' This code added by Visual Basic to correctly implement the disposable pattern.
    Public Sub Dispose() Implements IDisposable.Dispose
      ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
      Dispose(True)
      GC.SuppressFinalize(Me)
    End Sub
#End Region

  End Class
End Namespace
