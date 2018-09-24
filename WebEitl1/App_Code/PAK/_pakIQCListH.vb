Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.PAK
  <DataObject()> _
  Partial Public Class pakIQCListH
    Inherits SIS.PAK.pakQCListH
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function pakIQCListHGetNewRecord() As SIS.PAK.pakIQCListH
      Return New SIS.PAK.pakIQCListH()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function pakIQCListHSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal SerialNo As Int32, ByVal QCLNo As Int32, ByVal ClearedBy As String, ByVal StatusID As Int32, ByVal CreatedBy As String) As List(Of SIS.PAK.pakIQCListH)
      Dim Results As List(Of SIS.PAK.pakIQCListH) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          If OrderBy = String.Empty Then OrderBy = "QCLNo DESC"
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "sppakIQCListHSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "sppakIQCListHSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_SerialNo",SqlDbType.Int,10, IIf(SerialNo = Nothing, 0,SerialNo))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_QCLNo",SqlDbType.Int,10, IIf(QCLNo = Nothing, 0,QCLNo))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_ClearedBy",SqlDbType.NVarChar,8, IIf(ClearedBy Is Nothing, String.Empty,ClearedBy))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_StatusID",SqlDbType.Int,10, IIf(StatusID = Nothing, 0,StatusID))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_CreatedBy",SqlDbType.NVarChar,8, IIf(CreatedBy Is Nothing, String.Empty,CreatedBy))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          RecordCount = -1
          Results = New List(Of SIS.PAK.pakIQCListH)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.PAK.pakIQCListH(Reader))
          End While
          Reader.Close()
          RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function pakIQCListHSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String, ByVal SerialNo As Int32, ByVal QCLNo As Int32, ByVal ClearedBy As String, ByVal StatusID As Int32, ByVal CreatedBy As String) As Integer
      Return RecordCount
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function pakIQCListHGetByID(ByVal SerialNo As Int32, ByVal QCLNo As Int32) As SIS.PAK.pakIQCListH
      Dim Results As SIS.PAK.pakIQCListH = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppakQCListHSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SerialNo",SqlDbType.Int,SerialNo.ToString.Length, SerialNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@QCLNo",SqlDbType.Int,QCLNo.ToString.Length, QCLNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.PAK.pakIQCListH(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function pakIQCListHGetByID(ByVal SerialNo As Int32, ByVal QCLNo As Int32, ByVal Filter_SerialNo As Int32, ByVal Filter_QCLNo As Int32, ByVal Filter_ClearedBy As String, ByVal Filter_StatusID As Int32, ByVal Filter_CreatedBy As String) As SIS.PAK.pakIQCListH
      Dim Results As SIS.PAK.pakIQCListH = SIS.PAK.pakIQCListH.pakIQCListHGetByID(SerialNo, QCLNo)
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)> _
    Public Shared Function pakIQCListHUpdate(ByVal Record As SIS.PAK.pakIQCListH) As SIS.PAK.pakIQCListH
      Dim _Rec As SIS.PAK.pakIQCListH = SIS.PAK.pakIQCListH.pakIQCListHGetByID(Record.SerialNo, Record.QCLNo)
      With _Rec
        .Remarks = Record.Remarks
        .ClearedBy = Global.System.Web.HttpContext.Current.Session("LoginID")
        .ClearedOn = Now
      End With
      Return SIS.PAK.pakIQCListH.UpdateData(_Rec)
    End Function
    Public Sub New(ByVal Reader As SqlDataReader)
      MyBase.New(Reader)
    End Sub
    Public Sub New()
    End Sub
  End Class
End Namespace
