Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.NPRK
  <DataObject()> _
  Partial Public Class nprkApvrApplications
    Inherits SIS.NPRK.nprkApplications
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function nprkApvrApplicationsGetNewRecord() As SIS.NPRK.nprkApvrApplications
      Return New SIS.NPRK.nprkApvrApplications()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function nprkApvrApplicationsSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal PerkID As Int32, ByVal EmployeeID As Int32) As List(Of SIS.NPRK.nprkApvrApplications)
      Dim Results As List(Of SIS.NPRK.nprkApvrApplications) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          If OrderBy = String.Empty Then OrderBy = "ApplicationID DESC"
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "spnprkApvrApplicationsSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "spnprkApvrApplicationsSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_PerkID",SqlDbType.Int,10, IIf(PerkID = Nothing, 0,PerkID))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_EmployeeID",SqlDbType.Int,10, IIf(EmployeeID = Nothing, 0,EmployeeID))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StatusID",SqlDbType.Int,10, prkPerkStates.UnderApproval)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FinYear",SqlDbType.Int,10, Global.System.Web.HttpContext.Current.Session("FinYear"))
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          RecordCount = -1
          Results = New List(Of SIS.NPRK.nprkApvrApplications)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.NPRK.nprkApvrApplications(Reader))
          End While
          Reader.Close()
          RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function nprkApvrApplicationsSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String, ByVal PerkID As Int32, ByVal EmployeeID As Int32) As Integer
      Return RecordCount
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function nprkApvrApplicationsGetByID(ByVal ClaimID As Int32, ByVal ApplicationID As Int32) As SIS.NPRK.nprkApvrApplications
      Dim Results As SIS.NPRK.nprkApvrApplications = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spnprkApplicationsSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ClaimID",SqlDbType.Int,ClaimID.ToString.Length, ClaimID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ApplicationID",SqlDbType.Int,ApplicationID.ToString.Length, ApplicationID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.NPRK.nprkApvrApplications(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function nprkApvrApplicationsGetByID(ByVal ClaimID As Int32, ByVal ApplicationID As Int32, ByVal Filter_PerkID As Int32, ByVal Filter_EmployeeID As Int32) As SIS.NPRK.nprkApvrApplications
      Dim Results As SIS.NPRK.nprkApvrApplications = SIS.NPRK.nprkApvrApplications.nprkApvrApplicationsGetByID(ClaimID, ApplicationID)
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)> _
    Public Shared Function nprkApvrApplicationsUpdate(ByVal Record As SIS.NPRK.nprkApvrApplications) As SIS.NPRK.nprkApvrApplications
      Dim _Rec As SIS.NPRK.nprkApvrApplications = SIS.NPRK.nprkApvrApplications.nprkApvrApplicationsGetByID(Record.ClaimID, Record.ApplicationID)
      With _Rec
        .PerkID = Record.PerkID
        .UserRemark = Record.UserRemark
        .ApprovedValue = Record.ApprovedValue
        .StatusID = Record.StatusID
        .PostedInBaaN = Record.PostedInBaaN
        .UpdatedOn = Record.UpdatedOn
        .PostedBy = Record.PostedBy
        .VerifiedOn = Global.System.Web.HttpContext.Current.Session("VerifiedOn")
        .ExcessClaimed = Record.ExcessClaimed
        .VerifiedBy = Record.VerifiedBy
        .PostedOn = Record.PostedOn
        .Applied = Record.Applied
        .ApprovedOn = Record.ApprovedOn
        .FinYear = Global.System.Web.HttpContext.Current.Session("FinYear")
        .ApprovedBy = Record.ApprovedBy
        .PaymentMethod = Record.PaymentMethod
        .Approved = Record.Approved
        .ApprovedAmt = Record.ApprovedAmt
        .VerifiedAmt = Record.VerifiedAmt
        .EmployeeID = Record.EmployeeID
        .AppliedOn = Record.AppliedOn
        .Value = Record.Value
        .ApproverRemark = Record.ApproverRemark
        .UpdatedInLedger = Record.UpdatedInLedger
        .VerifiedValue = Record.VerifiedValue
        .Selected = Record.Selected
        .Verified = Record.Verified
        .UpdatedBy = Record.UpdatedBy
        .VerifierRemark = Record.VerifierRemark
        .Documents = Record.Documents
      End With
      Return SIS.NPRK.nprkApvrApplications.UpdateData(_Rec)
    End Function
    Public Sub New(ByVal Reader As SqlDataReader)
      MyBase.New(Reader)
    End Sub
    Public Sub New()
    End Sub
  End Class
End Namespace
