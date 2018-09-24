Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.NPRK
  <DataObject()> _
  Partial Public Class nprkLinkedSAClaims
    Inherits SIS.NPRK.nprkSiteAllowanceClaims
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function nprkLinkedSAClaimsGetNewRecord() As SIS.NPRK.nprkLinkedSAClaims
      Return New SIS.NPRK.nprkLinkedSAClaims()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function nprkLinkedSAClaimsSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal AdviceNo As Int32) As List(Of SIS.NPRK.nprkLinkedSAClaims)
      Dim Results As List(Of SIS.NPRK.nprkLinkedSAClaims) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "spnprkLinkedSAClaimsSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "spnprkLinkedSAClaimsSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_AdviceNo",SqlDbType.Int,10, IIf(AdviceNo = Nothing, 0,AdviceNo))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          RecordCount = -1
          Results = New List(Of SIS.NPRK.nprkLinkedSAClaims)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.NPRK.nprkLinkedSAClaims(Reader))
          End While
          Reader.Close()
          RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function nprkLinkedSAClaimsSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String, ByVal AdviceNo As Int32) As Integer
      Return RecordCount
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function nprkLinkedSAClaimsGetByID(ByVal FinYear As Int32, ByVal Quarter As Int32, ByVal EmployeeID As String) As SIS.NPRK.nprkLinkedSAClaims
      Dim Results As SIS.NPRK.nprkLinkedSAClaims = Nothing
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
            Results = New SIS.NPRK.nprkLinkedSAClaims(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function nprkLinkedSAClaimsGetByID(ByVal FinYear As Int32, ByVal Quarter As Int32, ByVal EmployeeID As String, ByVal Filter_AdviceNo As Int32) As SIS.NPRK.nprkLinkedSAClaims
      Dim Results As SIS.NPRK.nprkLinkedSAClaims = SIS.NPRK.nprkLinkedSAClaims.nprkLinkedSAClaimsGetByID(FinYear, Quarter, EmployeeID)
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)> _
    Public Shared Function nprkLinkedSAClaimsUpdate(ByVal Record As SIS.NPRK.nprkLinkedSAClaims) As SIS.NPRK.nprkLinkedSAClaims
      Dim _Rec As SIS.NPRK.nprkLinkedSAClaims = SIS.NPRK.nprkLinkedSAClaims.nprkLinkedSAClaimsGetByID(Record.FinYear, Record.Quarter, Record.EmployeeID)
      With _Rec
        .Entitled1Days = Record.Entitled1Days
        .Entitled2Days = Record.Entitled2Days
        .Entitled3Days = Record.Entitled3Days
        .Applied1Days = Record.Entitled1Days
        .Applied2Days = Record.Entitled2Days
        .Applied3Days = Record.Entitled3Days
        .Approved1Days = Record.Entitled1Days
        .Approved2Days = Record.Entitled2Days
        .Approved3Days = Record.Entitled3Days
        .Entitled1Amount = Record.Entitled1Amount
        .Entitled2Amount = Record.Entitled2Amount
        .Entitled3Amount = Record.Entitled3Amount
        .Applied1Amount = Record.Entitled1Amount
        .Applied2Amount = Record.Entitled2Amount
        .Applied3Amount = Record.Entitled3Amount
        .Approved1Amount = Record.Entitled1Amount
        .Approved2Amount = Record.Entitled2Amount
        .Approved3Amount = Record.Entitled3Amount
        .ApproverRemarks = Record.ApproverRemarks
        .TotalEntitledAmount = Convert.ToDecimal(Record.Entitled1Amount) + Convert.ToDecimal(Record.Entitled2Amount) + Convert.ToDecimal(Record.Entitled3Amount)
        .TotalAppliedAmount = .TotalEntitledAmount
        .TotalApprovedAmount = .TotalEntitledAmount
      End With
      _Rec = SIS.NPRK.nprkLinkedSAClaims.UpdateData(_Rec)
      SIS.NPRK.nprkSiteAllowanceAdvice.Validate(_Rec.FK_PRK_SiteAllowanceClaims_AdviceNo.PrimaryKey)
      Return _Rec
    End Function
    <DataObjectMethod(DataObjectMethodType.Insert, True)>
    Public Shared Function nprkLinkedSAClaimsInsert(ByVal Record As SIS.NPRK.nprkLinkedSAClaims) As SIS.NPRK.nprkLinkedSAClaims
      Dim _Rec As SIS.NPRK.nprkLinkedSAClaims = SIS.NPRK.nprkLinkedSAClaims.nprkLinkedSAClaimsGetNewRecord()
      With _Rec
        .FinYear = Record.FinYear
        .Quarter = Record.Quarter
        .EmployeeID = Record.EmployeeID
        .Entitled1Days = Record.Entitled1Days
        .Entitled2Days = Record.Entitled2Days
        .Entitled3Days = Record.Entitled3Days
        .Applied1Days = Record.Entitled1Days
        .Applied2Days = Record.Entitled2Days
        .Applied3Days = Record.Entitled3Days
        .Approved1Days = Record.Entitled1Days
        .Approved2Days = Record.Entitled2Days
        .Approved3Days = Record.Entitled3Days
        .Entitled1Amount = Record.Entitled1Amount
        .Entitled2Amount = Record.Entitled2Amount
        .Entitled3Amount = Record.Entitled3Amount
        .Applied1Amount = Record.Entitled1Amount
        .Applied2Amount = Record.Entitled2Amount
        .Applied3Amount = Record.Entitled3Amount
        .Approved1Amount = Record.Entitled1Amount
        .Approved2Amount = Record.Entitled2Amount
        .Approved3Amount = Record.Entitled3Amount
        .ApproverRemarks = Record.ApproverRemarks
        .TotalEntitledAmount = Convert.ToDecimal(Record.Entitled1Amount) + Convert.ToDecimal(Record.Entitled2Amount) + Convert.ToDecimal(Record.Entitled3Amount)
        .TotalAppliedAmount = .TotalEntitledAmount
        .TotalApprovedAmount = .TotalEntitledAmount

        .CreatedBy = HttpContext.Current.Session("LoginID")
        .CreatedOn = Now

        .AdviceNo = Record.AdviceNo
        .StatusID = saClaimStates.LinkedInAdvice
        .Linked = True
      End With
      _Rec = SIS.NPRK.nprkLinkedSAClaims.InsertData(_Rec)
      SIS.NPRK.nprkSiteAllowanceAdvice.Validate(_Rec.FK_PRK_SiteAllowanceClaims_AdviceNo.PrimaryKey)
      Return _Rec
    End Function
    Public Sub New(ByVal Reader As SqlDataReader)
      MyBase.New(Reader)
    End Sub
    Public Sub New()
    End Sub
  End Class
End Namespace
