Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.PAK
  <DataObject()> _
  Partial Public Class pakSiteMtlIssH
    Inherits SIS.PAK.pakSiteIssReqH
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function pakSiteMtlIssHGetNewRecord() As SIS.PAK.pakSiteMtlIssH
      Return New SIS.PAK.pakSiteMtlIssH()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function pakSiteMtlIssHSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal ProjectID As String) As List(Of SIS.PAK.pakSiteMtlIssH)
      Dim Results As List(Of SIS.PAK.pakSiteMtlIssH) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "sppakSiteMtlIssHSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "sppakSiteMtlIssHSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_ProjectID",SqlDbType.NVarChar,6, IIf(ProjectID Is Nothing, String.Empty,ProjectID))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          RecordCount = -1
          Results = New List(Of SIS.PAK.pakSiteMtlIssH)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.PAK.pakSiteMtlIssH(Reader))
          End While
          Reader.Close()
          RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function pakSiteMtlIssHSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String, ByVal ProjectID As String) As Integer
      Return RecordCount
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function pakSiteMtlIssHGetByID(ByVal ProjectID As String, ByVal IssueNo As Int32) As SIS.PAK.pakSiteMtlIssH
      Dim Results As SIS.PAK.pakSiteMtlIssH = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppakSiteIssReqHSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ProjectID",SqlDbType.NVarChar,ProjectID.ToString.Length, ProjectID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@IssueNo",SqlDbType.Int,IssueNo.ToString.Length, IssueNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.PAK.pakSiteMtlIssH(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function pakSiteMtlIssHGetByID(ByVal ProjectID As String, ByVal IssueNo As Int32, ByVal Filter_ProjectID As String) As SIS.PAK.pakSiteMtlIssH
      Dim Results As SIS.PAK.pakSiteMtlIssH = SIS.PAK.pakSiteMtlIssH.pakSiteMtlIssHGetByID(ProjectID, IssueNo)
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Insert, True)> _
    Public Shared Function pakSiteMtlIssHInsert(ByVal Record As SIS.PAK.pakSiteMtlIssH) As SIS.PAK.pakSiteMtlIssH
      Dim _Rec As SIS.PAK.pakSiteMtlIssH = SIS.PAK.pakSiteMtlIssH.pakSiteMtlIssHGetNewRecord()
      With _Rec
        .ProjectID = Record.ProjectID
        .RequestedBy = Record.RequestedBy
        .RequestedOn = Record.RequestedOn
        .RequesterRemarks = Record.RequesterRemarks
        .IssueToName = Record.IssueToName
        .IssueToCardNo = Record.IssueToCardNo
        .IssueRemarks = Record.IssueRemarks
        .IssueTypeID = Record.IssueTypeID
        .IssuedOn = Now
        .IssuedBy =  Global.System.Web.HttpContext.Current.Session("LoginID")
        .IssueStatusID = Record.IssueStatusID
      End With
      Return SIS.PAK.pakSiteMtlIssH.InsertData(_Rec)
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)> _
    Public Shared Function pakSiteMtlIssHUpdate(ByVal Record As SIS.PAK.pakSiteMtlIssH) As SIS.PAK.pakSiteMtlIssH
      Dim _Rec As SIS.PAK.pakSiteMtlIssH = SIS.PAK.pakSiteMtlIssH.pakSiteMtlIssHGetByID(Record.ProjectID, Record.IssueNo)
      With _Rec
        .RequestedBy = Record.RequestedBy
        .RequestedOn = Record.RequestedOn
        .RequesterRemarks = Record.RequesterRemarks
        .IssueToName = Record.IssueToName
        .IssueToCardNo = Record.IssueToCardNo
        .IssueRemarks = Record.IssueRemarks
        .IssueTypeID = Record.IssueTypeID
        .IssuedOn = Now
        .IssuedBy = Global.System.Web.HttpContext.Current.Session("LoginID")
        .IssueStatusID = Record.IssueStatusID
      End With
      Return SIS.PAK.pakSiteMtlIssH.UpdateData(_Rec)
    End Function
    Public Sub New(ByVal Reader As SqlDataReader)
      MyBase.New(Reader)
    End Sub
    Public Sub New()
    End Sub
  End Class
End Namespace
