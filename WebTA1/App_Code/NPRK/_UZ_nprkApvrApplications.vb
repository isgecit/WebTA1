Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.NPRK
  Partial Public Class nprkApvrApplications
    Public ReadOnly Property ApproveWFVisible() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetVisible()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property ApproveWFEnable() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetEnable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property RejectWFVisible() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetVisible()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property RejectWFEnable() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetEnable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public Shared Function ApproveWF(ByVal ClaimID As Int32, ByVal ApplicationID As Int32, ByVal PaymentMethod As String, ByVal Approved As Boolean, ByVal ApprovedAmt As Decimal, ByVal ApproverRemark As String) As SIS.NPRK.nprkApvrApplications
      If Not Approved Then
        Throw New Exception("Approved Value is NO, cannot approve.")
      End If
      Dim Results As SIS.NPRK.nprkApvrApplications = nprkApvrApplicationsGetByID(ClaimID, ApplicationID)
      With Results
        .StatusID = prkPerkStates.UnderPayment
        .PaymentMethod = PaymentMethod
        .Approved = Approved
        .ApprovedAmt = ApprovedAmt
        .ApprovedValue = ApprovedAmt
        .ApproverRemark = ApproverRemark
        .ApprovedOn = HttpContext.Current.Session("Today")
        .ApprovedBy = HttpContext.Current.Session("LoginID")
      End With
      SIS.NPRK.nprkApvrApplications.UpdateData(Results)
      Dim oUC As SIS.NPRK.nprkUserClaims = SIS.NPRK.nprkUserClaims.nprkUserClaimsGetByID(Results.ClaimID)
      With oUC
        .ClaimStatusID = prkClaimStates.UnderProcessInAccounts
      End With
      SIS.NPRK.nprkUserClaims.UpdateData(oUC)
      Return Results
    End Function
    Public Shared Function RejectWF(ByVal ClaimID As Int32, ByVal ApplicationID As Int32, ByVal PaymentMethod As String, ByVal Approved As Boolean, ByVal ApprovedAmt As Decimal, ByVal ApproverRemark As String) As SIS.NPRK.nprkApvrApplications
      Dim Results As SIS.NPRK.nprkApvrApplications = nprkApvrApplicationsGetByID(ClaimID, ApplicationID)
      With Results
        .StatusID = prkPerkStates.UnderVerification
        .PaymentMethod = PaymentMethod
        .Approved = False
        .ApprovedAmt = ApprovedAmt
        .ApproverRemark = ApproverRemark
        .ApprovedOn = HttpContext.Current.Session("Today")
        .ApprovedBy = HttpContext.Current.Session("LoginID")
      End With
      SIS.NPRK.nprkVrfrApplications.UpdateData(Results)
      'Check the status to set Received in Accounts
      Dim oAplLst As List(Of SIS.NPRK.nprkApplications) = SIS.NPRK.nprkApplications.UZ_nprkApplicationsSelectList(0, 9999, "", False, "", ClaimID)
      Dim MayRevert As Boolean = True
      For Each tmp As SIS.NPRK.nprkApplications In oAplLst
        Select Case tmp.StatusID
          Case prkPerkStates.UnderVerification, prkPerkStates.Rejected, prkPerkStates.Expired
          Case Else
            MayRevert = False
        End Select
      Next
      If MayRevert Then
        Dim oUC As SIS.NPRK.nprkUserClaims = SIS.NPRK.nprkUserClaims.nprkUserClaimsGetByID(Results.ClaimID)
        With oUC
          .ClaimStatusID = prkClaimStates.ReceivedInAccounts
        End With
        SIS.NPRK.nprkUserClaims.UpdateData(oUC)
      End If
      '----end of Check the reversal
      SIS.NPRK.nprkUserClaims.UpdatePaid(Results.ClaimID)
      Return Results
    End Function
    Public Shared Function UZ_nprkApvrApplicationsSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal PerkID As Int32, ByVal EmployeeID As Int32) As List(Of SIS.NPRK.nprkApvrApplications)
      Dim Results As List(Of SIS.NPRK.nprkApvrApplications) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          If OrderBy = String.Empty Then OrderBy = "ApplicationID DESC"
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "spnprk_LG_ApvrApplicationsSelectListSearch"
            Cmd.CommandText = "spnprkApvrApplicationsSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "spnprk_LG_ApvrApplicationsSelectListFilteres"
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
    Public Shared Function UZ_nprkApvrApplicationsUpdate(ByVal Record As SIS.NPRK.nprkApvrApplications) As SIS.NPRK.nprkApvrApplications
      Dim _Rec As SIS.NPRK.nprkApvrApplications = SIS.NPRK.nprkApvrApplications.nprkApvrApplicationsGetByID(Record.ClaimID, Record.ApplicationID)
      With _Rec
        .ApprovedValue = Record.ApprovedAmt
        .ApprovedAmt = Record.ApprovedAmt
        .Approved = Record.Approved
        .PaymentMethod = Record.PaymentMethod
        .ApprovedOn = Global.System.Web.HttpContext.Current.Session("Today")
        .ApprovedBy = Global.System.Web.HttpContext.Current.Session("LoginID")
        .ApproverRemark = Record.ApproverRemark
      End With
      Return SIS.NPRK.nprkApvrApplications.UpdateData(_Rec)
    End Function
  End Class
End Namespace
