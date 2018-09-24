Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.EITL
  <DataObject()> _
  Partial Public Class eitlIssuedPODocumentFile
    Inherits SIS.EITL.eitlPODocumentFile
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function eitlIssuedPODocumentFileGetNewRecord() As SIS.EITL.eitlIssuedPODocumentFile
      Return New SIS.EITL.eitlIssuedPODocumentFile()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function eitlIssuedPODocumentFileSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal SerialNo As Int32, ByVal DocumentLineNo As Int32) As List(Of SIS.EITL.eitlIssuedPODocumentFile)
      Dim Results As List(Of SIS.EITL.eitlIssuedPODocumentFile) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "speitlIssuedPODocumentFileSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "speitlIssuedPODocumentFileSelectListFilteres"
						SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_SerialNo",SqlDbType.Int,10, IIf(SerialNo = Nothing, 0,SerialNo))
						SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_DocumentLineNo",SqlDbType.Int,10, IIf(DocumentLineNo = Nothing, 0,DocumentLineNo))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          RecordCount = -1
          Results = New List(Of SIS.EITL.eitlIssuedPODocumentFile)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.EITL.eitlIssuedPODocumentFile(Reader))
          End While
          Reader.Close()
          RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function eitlIssuedPODocumentFileSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String, ByVal SerialNo As Int32, ByVal DocumentLineNo As Int32) As Integer
      Return RecordCount
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function eitlIssuedPODocumentFileGetByID(ByVal SerialNo As Int32, ByVal DocumentLineNo As Int32, ByVal FileNo As Int32) As SIS.EITL.eitlIssuedPODocumentFile
      Dim Results As SIS.EITL.eitlIssuedPODocumentFile = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "speitlPODocumentFileSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SerialNo",SqlDbType.Int,SerialNo.ToString.Length, SerialNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DocumentLineNo",SqlDbType.Int,DocumentLineNo.ToString.Length, DocumentLineNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FileNo",SqlDbType.Int,FileNo.ToString.Length, FileNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
					If Reader.Read() Then
						Results = New SIS.EITL.eitlIssuedPODocumentFile(Reader)
					End If
					Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function eitlIssuedPODocumentFileGetByID(ByVal SerialNo As Int32, ByVal DocumentLineNo As Int32, ByVal FileNo As Int32, ByVal Filter_SerialNo As Int32, ByVal Filter_DocumentLineNo As Int32) As SIS.EITL.eitlIssuedPODocumentFile
      Dim Results As SIS.EITL.eitlIssuedPODocumentFile = SIS.EITL.eitlIssuedPODocumentFile.eitlIssuedPODocumentFileGetByID(SerialNo, DocumentLineNo, FileNo)
      Return Results
    End Function
    Public Sub New(ByVal Reader As SqlDataReader)
      MyBase.New(Reader)
    End Sub
    Public Sub New()
    End Sub
  End Class
End Namespace
