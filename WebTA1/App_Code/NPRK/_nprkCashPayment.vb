Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.NPRK
  <DataObject()> _
  Partial Public Class nprkCashPayment
    Inherits SIS.NPRK.nprkApplications
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function nprkCashPaymentGetNewRecord() As SIS.NPRK.nprkCashPayment
      Return New SIS.NPRK.nprkCashPayment()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function nprkCashPaymentSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal PerkID As Int32, ByVal EmployeeID As Int32) As List(Of SIS.NPRK.nprkCashPayment)
      Dim Results As List(Of SIS.NPRK.nprkCashPayment) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          If OrderBy = String.Empty Then OrderBy = "ApplicationID DESC"
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "spnprkCashPaymentSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "spnprkCashPaymentSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_PerkID",SqlDbType.Int,10, IIf(PerkID = Nothing, 0,PerkID))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_EmployeeID",SqlDbType.Int,10, IIf(EmployeeID = Nothing, 0,EmployeeID))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FinYear",SqlDbType.Int,10, Global.System.Web.HttpContext.Current.Session("FinYear"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StatusID",SqlDbType.Int,10, prkPerkStates.UnderPayment)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PaymentMethod", SqlDbType.NVarChar, 20, "Cash")
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          RecordCount = -1
          Results = New List(Of SIS.NPRK.nprkCashPayment)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.NPRK.nprkCashPayment(Reader))
          End While
          Reader.Close()
          RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function nprkCashPaymentSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String, ByVal PerkID As Int32, ByVal EmployeeID As Int32) As Integer
      Return RecordCount
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function nprkCashPaymentGetByID(ByVal ClaimID As Int32, ByVal ApplicationID As Int32) As SIS.NPRK.nprkCashPayment
      Dim Results As SIS.NPRK.nprkCashPayment = Nothing
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
            Results = New SIS.NPRK.nprkCashPayment(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function nprkCashPaymentGetByID(ByVal ClaimID As Int32, ByVal ApplicationID As Int32, ByVal Filter_PerkID As Int32, ByVal Filter_EmployeeID As Int32) As SIS.NPRK.nprkCashPayment
      Dim Results As SIS.NPRK.nprkCashPayment = SIS.NPRK.nprkCashPayment.nprkCashPaymentGetByID(ClaimID, ApplicationID)
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)> _
    Public Shared Function nprkCashPaymentUpdate(ByVal Record As SIS.NPRK.nprkCashPayment) As SIS.NPRK.nprkCashPayment
      Dim _Rec As SIS.NPRK.nprkCashPayment = SIS.NPRK.nprkCashPayment.nprkCashPaymentGetByID(Record.ClaimID, Record.ApplicationID)
      With _Rec
        .PerkID = Record.PerkID
        .UserRemark = Record.UserRemark
        .Selected = Record.Selected
        .FinYear = Global.System.Web.HttpContext.Current.Session("FinYear")
        .ApprovedBy = Record.ApprovedBy
        .ExcessClaimed = Record.ExcessClaimed
        .PostedOn = Record.PostedOn
        .ApprovedValue = Record.ApprovedValue
        .VerifierRemark = Record.VerifierRemark
        .ApprovedOn = Record.ApprovedOn
        .PostedInBaaN = Record.PostedInBaaN
        .Value = Record.Value
        .VerifiedBy = Record.VerifiedBy
        .UpdatedBy = Global.System.Web.HttpContext.Current.Session("LoginID")
        .StatusID = Record.StatusID
        .PaymentMethod = Record.PaymentMethod
        .Approved = Record.Approved
        .ApprovedAmt = Record.ApprovedAmt
        .Verified = Record.Verified
        .EmployeeID = Record.EmployeeID
        .AppliedOn = Record.AppliedOn
        .Documents = Record.Documents
        .ApproverRemark = Record.ApproverRemark
        .UpdatedOn = Global.System.Web.HttpContext.Current.Session("Today")
        .VerifiedValue = Record.VerifiedValue
        .VerifiedOn = Record.VerifiedOn
        .VerifiedAmt = Record.VerifiedAmt
        .UpdatedInLedger = Record.UpdatedInLedger
        .Applied = Record.Applied
        .PostedBy = Record.PostedBy
      End With
      Return SIS.NPRK.nprkCashPayment.UpdateData(_Rec)
    End Function
    Public Sub New(ByVal Reader As SqlDataReader)
      MyBase.New(Reader)
    End Sub
    Public Sub New()
    End Sub
  End Class
End Namespace
