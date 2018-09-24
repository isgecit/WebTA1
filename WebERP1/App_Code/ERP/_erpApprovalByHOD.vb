Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.ERP
  <DataObject()> _
  Partial Public Class erpApprovalByHOD
    Inherits SIS.ERP.erpChaneRequest
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function erpApprovalByHODGetNewRecord() As SIS.ERP.erpApprovalByHOD
      Return New SIS.ERP.erpApprovalByHOD()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function erpApprovalByHODSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal ApplID As Int32, ByVal RequestedBy As String, ByVal RequestTypeID As Int32, ByVal StatusID As Int32, ByVal PriorityID As Int32) As List(Of SIS.ERP.erpApprovalByHOD)
      Dim Results As List(Of SIS.ERP.erpApprovalByHOD) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          If OrderBy = String.Empty Then OrderBy = "RequestID DESC"
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "sperpApprovalByHODSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "sperpApprovalByHODSelectListFilteres"
						SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_ApplID",SqlDbType.Int,10, IIf(ApplID = Nothing, 0,ApplID))
						SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_RequestedBy",SqlDbType.NVarChar,8, IIf(RequestedBy Is Nothing, String.Empty,RequestedBy))
						SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_RequestTypeID",SqlDbType.Int,10, IIf(RequestTypeID = Nothing, 0,RequestTypeID))
						SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_StatusID",SqlDbType.Int,10, IIf(StatusID = Nothing, 0,StatusID))
						SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_PriorityID",SqlDbType.Int,10, IIf(PriorityID = Nothing, 0,PriorityID))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StatusID",SqlDbType.Int,10, 4)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ApprovedBy",SqlDbType.NVarChar,8, Global.System.Web.HttpContext.Current.Session("LoginID"))
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          RecordCount = -1
          Results = New List(Of SIS.ERP.erpApprovalByHOD)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.ERP.erpApprovalByHOD(Reader))
          End While
          Reader.Close()
          RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function erpApprovalByHODSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String, ByVal ApplID As Int32, ByVal RequestedBy As String, ByVal RequestTypeID As Int32, ByVal StatusID As Int32, ByVal PriorityID As Int32) As Integer
      Return RecordCount
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function erpApprovalByHODGetByID(ByVal ApplID As Int32, ByVal RequestID As Int32) As SIS.ERP.erpApprovalByHOD
      Dim Results As SIS.ERP.erpApprovalByHOD = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sperpChaneRequestSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ApplID",SqlDbType.Int,ApplID.ToString.Length, ApplID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@RequestID",SqlDbType.Int,RequestID.ToString.Length, RequestID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
					If Reader.Read() Then
						Results = New SIS.ERP.erpApprovalByHOD(Reader)
					End If
					Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function erpApprovalByHODGetByID(ByVal ApplID As Int32, ByVal RequestID As Int32, ByVal Filter_ApplID As Int32, ByVal Filter_RequestedBy As String, ByVal Filter_RequestTypeID As Int32, ByVal Filter_StatusID As Int32, ByVal Filter_PriorityID As Int32) As SIS.ERP.erpApprovalByHOD
      Dim Results As SIS.ERP.erpApprovalByHOD = SIS.ERP.erpApprovalByHOD.erpApprovalByHODGetByID(ApplID, RequestID)
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)> _
    Public Shared Function erpApprovalByHODUpdate(ByVal Record As SIS.ERP.erpApprovalByHOD) As SIS.ERP.erpApprovalByHOD
      Dim _Rec As SIS.ERP.erpApprovalByHOD = SIS.ERP.erpApprovalByHOD.erpApprovalByHODGetByID(Record.ApplID, Record.RequestID)
      With _Rec
				.StatusID = Record.StatusID
        .ApprovedBy = Global.System.Web.HttpContext.Current.Session("LoginID")
        .ApprovedOn = Now
        .ReturnRemarks = Record.ReturnRemarks
      End With
      Return SIS.ERP.erpApprovalByHOD.UpdateData(_Rec)
    End Function
    Public Sub New(ByVal Reader As SqlDataReader)
      MyBase.New(Reader)
    End Sub
    Public Sub New()
    End Sub
  End Class
End Namespace
