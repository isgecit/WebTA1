Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.PAK
  <DataObject()> _
  Partial Public Class pakSiteMtlIssD
    Inherits SIS.PAK.pakSiteIssRecD
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function pakSiteMtlIssDGetNewRecord() As SIS.PAK.pakSiteMtlIssD
      Return New SIS.PAK.pakSiteMtlIssD()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function pakSiteMtlIssDSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal IssueNo As Int32, ByVal ProjectID As String) As List(Of SIS.PAK.pakSiteMtlIssD)
      Dim Results As List(Of SIS.PAK.pakSiteMtlIssD) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "sppakSiteMtlIssDSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "sppakSiteMtlIssDSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_IssueNo",SqlDbType.Int,10, IIf(IssueNo = Nothing, 0,IssueNo))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_ProjectID",SqlDbType.NVarChar,6, IIf(ProjectID Is Nothing, String.Empty,ProjectID))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          RecordCount = -1
          Results = New List(Of SIS.PAK.pakSiteMtlIssD)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.PAK.pakSiteMtlIssD(Reader))
          End While
          Reader.Close()
          RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function pakSiteMtlIssDSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String, ByVal IssueNo As Int32, ByVal ProjectID As String) As Integer
      Return RecordCount
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function pakSiteMtlIssDGetByID(ByVal ProjectID As String, ByVal IssueNo As Int32, ByVal IssueSrNo As Int32) As SIS.PAK.pakSiteMtlIssD
      Dim Results As SIS.PAK.pakSiteMtlIssD = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppakSiteIssRecDSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ProjectID",SqlDbType.NVarChar,ProjectID.ToString.Length, ProjectID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@IssueNo",SqlDbType.Int,IssueNo.ToString.Length, IssueNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@IssueSrNo",SqlDbType.Int,IssueSrNo.ToString.Length, IssueSrNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.PAK.pakSiteMtlIssD(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function pakSiteMtlIssDGetByID(ByVal ProjectID As String, ByVal IssueNo As Int32, ByVal IssueSrNo As Int32, ByVal Filter_IssueNo As Int32, ByVal Filter_ProjectID As String) As SIS.PAK.pakSiteMtlIssD
      Dim Results As SIS.PAK.pakSiteMtlIssD = SIS.PAK.pakSiteMtlIssD.pakSiteMtlIssDGetByID(ProjectID, IssueNo, IssueSrNo)
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Insert, True)> _
    Public Shared Function pakSiteMtlIssDInsert(ByVal Record As SIS.PAK.pakSiteMtlIssD) As SIS.PAK.pakSiteMtlIssD
      Dim _Rec As SIS.PAK.pakSiteMtlIssD = SIS.PAK.pakSiteMtlIssD.pakSiteMtlIssDGetNewRecord()
      With _Rec
        .SiteMarkNo = Record.SiteMarkNo
        .UOMQuantity = Record.UOMQuantity
        .QuantityRequired = Record.QuantityRequired
        .QuantityIssued = Record.QuantityIssued
        .IssueNo = Record.IssueNo
        .ProjectID = Record.ProjectID
        .Remarks = Record.Remarks
        .IssuerRemarks = Record.IssuerRemarks
      End With
      Return SIS.PAK.pakSiteMtlIssD.InsertData(_Rec)
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)> _
    Public Shared Function pakSiteMtlIssDUpdate(ByVal Record As SIS.PAK.pakSiteMtlIssD) As SIS.PAK.pakSiteMtlIssD
      Dim _Rec As SIS.PAK.pakSiteMtlIssD = SIS.PAK.pakSiteMtlIssD.pakSiteMtlIssDGetByID(Record.ProjectID, Record.IssueNo, Record.IssueSrNo)
      With _Rec
        .SiteMarkNo = Record.SiteMarkNo
        .UOMQuantity = Record.UOMQuantity
        .QuantityRequired = Record.QuantityRequired
        .QuantityIssued = Record.QuantityIssued
        .Remarks = Record.Remarks
        .IssuerRemarks = Record.IssuerRemarks
      End With
      Return SIS.PAK.pakSiteMtlIssD.UpdateData(_Rec)
    End Function
    Public Sub New(ByVal Reader As SqlDataReader)
      MyBase.New(Reader)
    End Sub
    Public Sub New()
    End Sub
  End Class
End Namespace
