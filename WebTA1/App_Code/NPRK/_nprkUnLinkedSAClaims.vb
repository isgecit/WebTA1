Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.NPRK
  <DataObject()> _
  Partial Public Class nprkUnLinkedSAClaims
    Inherits SIS.NPRK.nprkSiteAllowanceClaims
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function nprkUnLinkedSAClaimsGetNewRecord() As SIS.NPRK.nprkUnLinkedSAClaims
      Return New SIS.NPRK.nprkUnLinkedSAClaims()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function nprkUnLinkedSAClaimsSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal FinYear As Int32, ByVal Quarter As Int32) As List(Of SIS.NPRK.nprkUnLinkedSAClaims)
      Dim Results As List(Of SIS.NPRK.nprkUnLinkedSAClaims) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "spnprkUnLinkedSAClaimsSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "spnprkUnLinkedSAClaimsSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_FinYear",SqlDbType.Int,10, IIf(FinYear = Nothing, 0,FinYear))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_Quarter",SqlDbType.Int,10, IIf(Quarter = Nothing, 0,Quarter))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Linked",SqlDbType.Bit,2, False)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StatusID",SqlDbType.Int,10, saClaimStates.SubmittedToHO)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          RecordCount = -1
          Results = New List(Of SIS.NPRK.nprkUnLinkedSAClaims)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.NPRK.nprkUnLinkedSAClaims(Reader))
          End While
          Reader.Close()
          RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function nprkUnLinkedSAClaimsSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String, ByVal FinYear As Int32, ByVal Quarter As Int32) As Integer
      Return RecordCount
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function nprkUnLinkedSAClaimsGetByID(ByVal FinYear As Int32, ByVal Quarter As Int32, ByVal EmployeeID As String) As SIS.NPRK.nprkUnLinkedSAClaims
      Dim Results As SIS.NPRK.nprkUnLinkedSAClaims = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spnprkSiteAllowanceClaimsSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FinYear",SqlDbType.Int,FinYear.ToString.Length, FinYear)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Quarter",SqlDbType.Int,Quarter.ToString.Length, Quarter)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@EmployeeID",SqlDbType.NVarChar,EmployeeID.ToString.Length, EmployeeID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.NPRK.nprkUnLinkedSAClaims(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function nprkUnLinkedSAClaimsGetByID(ByVal FinYear As Int32, ByVal Quarter As Int32, ByVal EmployeeID As String, ByVal Filter_FinYear As Int32, ByVal Filter_Quarter As Int32) As SIS.NPRK.nprkUnLinkedSAClaims
      Dim Results As SIS.NPRK.nprkUnLinkedSAClaims = SIS.NPRK.nprkUnLinkedSAClaims.nprkUnLinkedSAClaimsGetByID(FinYear, Quarter, EmployeeID)
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)> _
    Public Shared Function nprkUnLinkedSAClaimsUpdate(ByVal Record As SIS.NPRK.nprkUnLinkedSAClaims) As SIS.NPRK.nprkUnLinkedSAClaims
      Dim _Rec As SIS.NPRK.nprkUnLinkedSAClaims = SIS.NPRK.nprkUnLinkedSAClaims.nprkUnLinkedSAClaimsGetByID(Record.FinYear, Record.Quarter, Record.EmployeeID)
      With _Rec
        .Entitled1Days = Record.Entitled1Days
        .Entitled2Days = Record.Entitled2Days
        .Entitled3Days = Record.Entitled3Days
        .Applied1Days = Record.Applied1Days
        .Applied2Days = Record.Applied2Days
        .Applied3Days = Record.Applied3Days
        .Approved1Days = Record.Approved1Days
        .Approved2Days = Record.Approved2Days
        .Approved3Days = Record.Approved3Days
        .UserRemarks = Record.UserRemarks
        .ApproverRemarks = Record.ApproverRemarks
        .CreatedBy = Record.CreatedBy
        .CreatedOn = Record.CreatedOn
        .Linked = False
        .StatusID = saClaimStates.SubmittedToHO
        .ApprovedBy = Record.ApprovedBy
        .ApprovedOn = Record.ApprovedOn
        .Entitled1Amount = Record.Entitled1Amount
        .Entitled2Amount = Record.Entitled2Amount
        .Entitled3Amount = Record.Entitled3Amount
        .Applied1Amount = Record.Applied1Amount
        .Applied2Amount = Record.Applied2Amount
        .Applied3Amount = Record.Applied3Amount
        .Approved1Amount = Record.Approved1Amount
        .Approved2Amount = Record.Approved2Amount
        .Approved3Amount = Record.Approved3Amount
        .TotalEntitledAmount = Record.TotalEntitledAmount
        .TotalAppliedAmount = Record.TotalAppliedAmount
        .TotalApprovedAmount = Record.TotalApprovedAmount
        .AdviceNo = Record.AdviceNo
      End With
      Return SIS.NPRK.nprkUnLinkedSAClaims.UpdateData(_Rec)
    End Function
    Public Sub New(ByVal Reader As SqlDataReader)
      MyBase.New(Reader)
    End Sub
    Public Sub New()
    End Sub
  End Class
End Namespace
