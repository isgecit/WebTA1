Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.TAR
  <DataObject()> _
  Partial Public Class tarTRApproval
    Inherits SIS.TAR.tarTravelRequest
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function tarTRApprovalGetNewRecord() As SIS.TAR.tarTRApproval
      Return New SIS.TAR.tarTRApproval()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function tarTRApprovalSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal ProjectID As String, ByVal CreatedBy As String) As List(Of SIS.TAR.tarTRApproval)
      Dim Results As List(Of SIS.TAR.tarTRApproval) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          If OrderBy = String.Empty Then OrderBy = "RequestID DESC"
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "sptarTRApprovalSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "sptarTRApprovalSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_ProjectID",SqlDbType.NVarChar,6, IIf(ProjectID Is Nothing, String.Empty,ProjectID))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_CreatedBy",SqlDbType.NVarChar,8, IIf(CreatedBy Is Nothing, String.Empty,CreatedBy))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          RecordCount = -1
          Results = New List(Of SIS.TAR.tarTRApproval)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.TAR.tarTRApproval(Reader))
          End While
          Reader.Close()
          RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function tarTRApprovalSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String, ByVal ProjectID As String, ByVal CreatedBy As String) As Integer
      Return RecordCount
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function tarTRApprovalGetByID(ByVal RequestID As Int32) As SIS.TAR.tarTRApproval
      Dim Results As SIS.TAR.tarTRApproval = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sptarTravelRequestSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@RequestID",SqlDbType.Int,RequestID.ToString.Length, RequestID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.TAR.tarTRApproval(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function tarTRApprovalGetByID(ByVal RequestID As Int32, ByVal Filter_ProjectID As String, ByVal Filter_CreatedBy As String) As SIS.TAR.tarTRApproval
      Dim Results As SIS.TAR.tarTRApproval = SIS.TAR.tarTRApproval.tarTRApprovalGetByID(RequestID)
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)> _
    Public Shared Function tarTRApprovalUpdate(ByVal Record As SIS.TAR.tarTRApproval) As SIS.TAR.tarTRApproval
      Dim _Rec As SIS.TAR.tarTRApproval = SIS.TAR.tarTRApproval.tarTRApprovalGetByID(Record.RequestID)
      With _Rec
        .RequestedFor = Record.RequestedFor
        .RequestedForEmployees = Record.RequestedForEmployees
        .TravelTypeID = Record.TravelTypeID
        .ProjectID = Record.ProjectID
        .ProjectManagerID = Record.ProjectManagerID
        .CostCenterID = Record.CostCenterID
        .TravelItinerary = Record.TravelItinerary
        .Purpose = Record.Purpose
        .TotalRequestedAmount = Record.TotalRequestedAmount
        .RequestedCurrencyID = Record.RequestedCurrencyID
        .RequestedConversionFactor = Record.RequestedConversionFactor
        .TotalRequestedAmountINR = Record.TotalRequestedAmountINR
        .StatusID = Record.StatusID
        .CreatedBy = Record.CreatedBy
        .CreatedOn = Record.CreatedOn
        .BudgetCheckedBy = Record.BudgetCheckedBy
        .BudgetCheckedOn = Record.BudgetCheckedOn
        .ProjectManagerRemarks = Record.ProjectManagerRemarks
        .ApprovedBy = Record.ApprovedBy
        .ApprovedOn = Record.ApprovedOn
        .ApproverRemarks = Record.ApproverRemarks
        .BHApprovalBy = Record.BHApprovalBy
        .BHApprovalOn = Record.BHApprovalOn
        .BHRemarks = Record.BHRemarks
        .MDApprovalBy = Record.MDApprovalBy
        .MDApprovalOn = Record.MDApprovalOn
        .MDRemarks = Record.MDRemarks
        .MDCurrencyID = Record.MDCurrencyID
        .MDConversionFactor = Record.MDConversionFactor
        .MDDAAmount = Record.MDDAAmount
        .MDDAAmountINR = Record.MDDAAmountINR
        .MDLodgingAmount = Record.MDLodgingAmount
        .MDLodgingAmountINR = Record.MDLodgingAmountINR
        .FileAttached = Record.FileAttached
        .BalanceBudgetWhenSubmitted = Record.BalanceBudgetWhenSubmitted
        .RequestKey = Record.RequestKey
      End With
      Return SIS.TAR.tarTRApproval.UpdateData(_Rec)
    End Function
    Public Sub New(ByVal Reader As SqlDataReader)
      MyBase.New(Reader)
    End Sub
    Public Sub New()
    End Sub
  End Class
End Namespace
