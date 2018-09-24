Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.NPRK
  Partial Public Class nprkVrfrApplications
    Public Shadows ReadOnly Property Editable() As Boolean
      Get
        Dim mRet As Boolean = False
        If StatusID = prkPerkStates.UnderVerification Then
          mRet = True
        End If
        Return mRet
      End Get
    End Property
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
    Public Shared Function ApproveWF(ByVal ClaimID As Int32, ByVal ApplicationID As Int32, ByVal Documents As Boolean, ByVal Verified As Boolean, ByVal PaymentMethod As String, ByVal VerifiedAmt As Decimal, ByVal VerifierRemark As String) As SIS.NPRK.nprkVrfrApplications
      If Not Verified Or Not Documents Then
        Throw New Exception("Verified value is NO or Document NOT OK, cannot verify.")
      End If
      Dim Results As SIS.NPRK.nprkVrfrApplications = nprkVrfrApplicationsGetByID(ClaimID, ApplicationID)
      With Results
        .StatusID = prkPerkStates.UnderApproval
        .Documents = Documents
        .Verified = Verified
        .PaymentMethod = PaymentMethod
        .VerifiedValue = VerifiedAmt
        .VerifiedAmt = VerifiedAmt
        .ApprovedAmt = VerifiedAmt
        .ApprovedValue = VerifiedAmt
        .VerifierRemark = VerifierRemark
        .ApproverRemark = "Approved"
        .VerifiedOn = HttpContext.Current.Session("Today")
        .VerifiedBy = HttpContext.Current.Session("LoginID")
      End With
      Results = SIS.NPRK.nprkVrfrApplications.UpdateData(Results)
      Dim oUC As SIS.NPRK.nprkUserClaims = SIS.NPRK.nprkUserClaims.nprkUserClaimsGetByID(Results.ClaimID)
      With oUC
        .ClaimStatusID = prkClaimStates.UnderProcessInAccounts
      End With
      SIS.NPRK.nprkUserClaims.UpdateData(oUC)
      Return Results
    End Function
    Public Shared Function RejectWF(ByVal ClaimID As Int32, ByVal ApplicationID As Int32, ByVal Documents As Boolean, ByVal Verified As Boolean, ByVal PaymentMethod As String, ByVal VerifiedAmt As Decimal, ByVal VerifierRemark As String) As SIS.NPRK.nprkVrfrApplications
      Dim Results As SIS.NPRK.nprkVrfrApplications = nprkVrfrApplicationsGetByID(ClaimID, ApplicationID)
      With Results
        .StatusID = prkPerkStates.Rejected
        .Documents = Documents
        .Verified = False
        .PaymentMethod = PaymentMethod
        .VerifiedAmt = VerifiedAmt
        .VerifierRemark = VerifierRemark
        .VerifiedOn = HttpContext.Current.Session("Today")
        .VerifiedBy = HttpContext.Current.Session("LoginID")
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
    Public Shared Function UZ_nprkVrfrApplicationsSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal PerkID As Int32, ByVal EmployeeID As Int32) As List(Of SIS.NPRK.nprkVrfrApplications)
      Dim Results As List(Of SIS.NPRK.nprkVrfrApplications) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          If OrderBy = String.Empty Then OrderBy = "ApplicationID DESC"
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "spnprk_LG_VrfrApplicationsSelectListSearch"
            Cmd.CommandText = "spnprkVrfrApplicationsSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "spnprk_LG_VrfrApplicationsSelectListFilteres"
            Cmd.CommandText = "spnprkVrfrApplicationsSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_PerkID", SqlDbType.Int, 10, IIf(PerkID = Nothing, 0, PerkID))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_EmployeeID", SqlDbType.Int, 10, IIf(EmployeeID = Nothing, 0, EmployeeID))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FinYear", SqlDbType.Int, 10, Global.System.Web.HttpContext.Current.Session("FinYear"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StatusID", SqlDbType.Int, 10, prkPerkStates.UnderVerification)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          RecordCount = -1
          Results = New List(Of SIS.NPRK.nprkVrfrApplications)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.NPRK.nprkVrfrApplications(Reader))
          End While
          Reader.Close()
          RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function UZ_nprkVrfrApplicationsUpdate(ByVal Record As SIS.NPRK.nprkVrfrApplications) As SIS.NPRK.nprkVrfrApplications
      Dim _Rec As SIS.NPRK.nprkVrfrApplications = SIS.NPRK.nprkVrfrApplications.nprkVrfrApplicationsGetByID(Record.ClaimID, Record.ApplicationID)
      With _Rec
        .ApprovedValue = Record.VerifiedAmt
        .ApprovedAmt = Record.VerifiedAmt
        .VerifiedValue = Record.VerifiedAmt
        .VerifiedAmt = Record.VerifiedAmt
        .Documents = Record.Documents
        .Verified = Record.Verified
        .PaymentMethod = Record.PaymentMethod
        .VerifierRemark = Record.VerifierRemark
        .VerifiedBy = Global.System.Web.HttpContext.Current.Session("LoginID")
        .VerifiedOn = Global.System.Web.HttpContext.Current.Session("Today")
      End With
      Return SIS.NPRK.nprkVrfrApplications.UpdateData(_Rec)
    End Function
  End Class
End Namespace
