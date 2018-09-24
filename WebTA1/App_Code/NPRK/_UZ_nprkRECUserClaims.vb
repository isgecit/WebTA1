Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Imports System.Web.Mail
Imports System.Net.Mail

Namespace SIS.NPRK
  Partial Public Class nprkRECUserClaims
    Public ReadOnly Property ApproveWFVisible() As Boolean
      Get
        Dim mRet As Boolean = False
        Try
          If ClaimStatusID = prkClaimStates.SubmittedToAccounts Or ClaimStatusID = prkClaimStates.Free Then
            mRet = True
          End If
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
        Dim mRet As Boolean = False
        Try
          If ClaimStatusID = prkClaimStates.ReceivedInAccounts Then
            mRet = True
          End If
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
    Public Shared Function ApproveWF(ByVal ClaimID As Int32, ByVal AccountsRemarks As String) As SIS.NPRK.nprkRECUserClaims
      Dim Results As SIS.NPRK.nprkRECUserClaims = nprkRECUserClaimsGetByID(ClaimID)
      With Results
        .ClaimStatusID = prkClaimStates.ReceivedInAccounts
        .ReceivedOn = HttpContext.Current.Session("Today")
        .ReceivedBy = HttpContext.Current.Session("LoginID")
        .AccountsRemarks = AccountsRemarks
      End With
      Results = SIS.NPRK.nprkRECUserClaims.UpdateData(Results)
      Dim oApls As List(Of SIS.NPRK.nprkApplications) = SIS.NPRK.nprkApplications.UZ_nprkApplicationsSelectList(0, 999, "", False, "", ClaimID)
      For Each tmp As SIS.NPRK.nprkApplications In oApls
        With tmp
          .StatusID = prkPerkStates.UnderVerification
          .Applied = True
          .AppliedOn = HttpContext.Current.Session("Today")
          .PaymentMethod = "Cheque"
          .Documents = True
          .Verified = True
          .VerifierRemark = "Verified"
        End With
        SIS.NPRK.nprkApplications.UpdateData(tmp)
      Next
      Return Results
    End Function
    Public Shared Function RejectWF(ByVal ClaimID As Int32, ByVal AccountsRemarks As String) As SIS.NPRK.nprkRECUserClaims
      Dim Results As SIS.NPRK.nprkRECUserClaims = nprkRECUserClaimsGetByID(ClaimID)
      With Results
        .ClaimStatusID = prkClaimStates.ReturnedByAccounts
        .ReturnedOn = HttpContext.Current.Session("Today")
        .ReturnedBy = HttpContext.Current.Session("LoginID")
        .AccountsRemarks = AccountsRemarks
      End With
      Results = SIS.NPRK.nprkRECUserClaims.UpdateData(Results)
      Dim oApls As List(Of SIS.NPRK.nprkApplications) = SIS.NPRK.nprkApplications.UZ_nprkApplicationsSelectList(0, 999, "", False, "", ClaimID)
      For Each tmp As SIS.NPRK.nprkApplications In oApls
        With tmp
          .StatusID = prkPerkStates.Free
          .Applied = False
        End With
        SIS.NPRK.nprkApplications.UpdateData(tmp)
      Next
      '=============
      SendReturnEMail(Results)
      '=============
      Return Results
    End Function
    Public Shared Function UZ_nprkRECUserClaimsSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal CardNo As String, ByVal StatusID As Integer) As List(Of SIS.NPRK.nprkRECUserClaims)
      Dim Results As List(Of SIS.NPRK.nprkRECUserClaims) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          If OrderBy = String.Empty Then OrderBy = "ClaimID DESC"
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "spnprk_LG_RECUserClaimsSelectListSearch"
            'Cmd.CommandText = "spnprkRECUserClaimsSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "spnprk_LG_RECUserClaimsSelectListFilteres"
            'Cmd.CommandText = "spnprkRECUserClaimsSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_CardNo", SqlDbType.NVarChar, 8, IIf(CardNo Is Nothing, String.Empty, CardNo))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ClaimStatusID", SqlDbType.Int, 10, StatusID)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          RecordCount = -1
          Results = New List(Of SIS.NPRK.nprkRECUserClaims)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.NPRK.nprkRECUserClaims(Reader))
          End While
          Reader.Close()
          RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function nprkRECUserClaimsSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String, ByVal CardNo As String, ByVal StatusID As Integer) As Integer
      Return RecordCount
    End Function
    Public Shared Function UZ_nprkRECUserClaimsUpdate(ByVal Record As SIS.NPRK.nprkRECUserClaims) As SIS.NPRK.nprkRECUserClaims
      Dim _Result As SIS.NPRK.nprkRECUserClaims = nprkRECUserClaimsUpdate(Record)
      Return _Result
    End Function
    Public Shared Function ApproveAdminWF(ByVal ClaimID As Int32, ByVal AccountsRemarks As String) As SIS.NPRK.nprkRECUserClaims
      Dim Results As SIS.NPRK.nprkRECUserClaims = nprkRECUserClaimsGetByID(ClaimID)
      With Results
        .ClaimStatusID = prkClaimStates.SubmittedToAccounts
        .VerifiedOn = HttpContext.Current.Session("Today")
        .VerifiedBy = HttpContext.Current.Session("LoginID")
        .AccountsRemarks = AccountsRemarks
      End With
      Results = SIS.NPRK.nprkRECUserClaims.UpdateData(Results)
      Return Results
    End Function
    Public Shared Function RejectAdminWF(ByVal ClaimID As Int32, ByVal AccountsRemarks As String) As SIS.NPRK.nprkRECUserClaims
      Dim Results As SIS.NPRK.nprkRECUserClaims = nprkRECUserClaimsGetByID(ClaimID)
      With Results
        .ClaimStatusID = prkClaimStates.ReturnedByAccounts
        .VerifiedOn = HttpContext.Current.Session("Today")
        .VerifiedBy = HttpContext.Current.Session("LoginID")
        .AccountsRemarks = AccountsRemarks
      End With
      Results = SIS.NPRK.nprkRECUserClaims.UpdateData(Results)
      '=============
      SendReturnEMail(Results, True)
      '=============
      Return Results
    End Function
    Public Shared Function UZ_nprkVerifyByAdminSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal CardNo As String) As List(Of SIS.NPRK.nprkRECUserClaims)
      Dim Results As List(Of SIS.NPRK.nprkRECUserClaims) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          If OrderBy = String.Empty Then OrderBy = "ClaimID DESC"
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "spnprk_LG_VerifyByAdminSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "spnprk_LG_VerifyByAdminSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_CardNo", SqlDbType.NVarChar, 8, IIf(CardNo Is Nothing, String.Empty, CardNo))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          RecordCount = -1
          Results = New List(Of SIS.NPRK.nprkRECUserClaims)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.NPRK.nprkRECUserClaims(Reader))
          End While
          Reader.Close()
          RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function nprkVerifyByAdminSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String, ByVal CardNo As String) As Integer
      Return RecordCount
    End Function
    Public Shared Function SendReturnEMail(ByVal oUC As SIS.NPRK.nprkUserClaims, Optional ByVal ByAdmin As Boolean = False) As String
      Dim mRet As String = ""
      Dim First As Boolean = True
      Dim Cnt As Integer = 0
      Dim mRecipients As New StringBuilder
      Dim maySend As Boolean = False

      Dim oClient As SmtpClient = New SmtpClient()
      Dim oMsg As System.Net.Mail.MailMessage = New System.Net.Mail.MailMessage()
      Dim ad As MailAddress = Nothing
      'From EMail
      If oUC.FK_PRK_UserClaims_ReturnedBy.EMailID <> String.Empty Then
        ad = New MailAddress(oUC.FK_PRK_UserClaims_ReturnedBy.EMailID, oUC.FK_PRK_UserClaims_ReturnedBy.UserFullName)
        oMsg.From = ad
        oMsg.CC.Add(ad)
      End If
      If oUC.FK_PRK_UserClaims_CardNo.EMailID <> String.Empty Then
        ad = New MailAddress(oUC.FK_PRK_UserClaims_CardNo.EMailID, oUC.FK_PRK_UserClaims_CardNo.UserFullName)
        oMsg.To.Add(ad)
      End If
      oMsg.IsBodyHtml = True
      oMsg.Subject = "Perk Claim RETURNED : " & oUC.ClaimRefNo

      Dim sb As New StringBuilder
      With sb
        .AppendLine("<table style=""width:900px"" border=""1"" cellspacing=""1"" cellpadding=""1"">")
        .AppendLine("<tr><td colspan=""2"" style=""color:red"" align=""center""><h3><b>PERK CLAIM RETURNED</b></h3></td></tr>")
        .AppendLine("<tr><td bgcolor=""lightgray""><b>Accounts/Admin Remarks</b></td>")
        .AppendLine("<td>" & oUC.AccountsRemarks & "</td></tr>")
        .AppendLine("</table>")
      End With
      Try
        Dim Header As String = ""
        Header = Header & "<html xmlns=""http://www.w3.org/1999/xhtml"">"
        Header = Header & "<head>"
        Header = Header & "<title></title>"
        Header = Header & "<style>"
        Header = Header & "table{"

        Header = Header & "border: solid 1pt black;"
        Header = Header & "border-collapse:collapse;"
        Header = Header & "font-family: Tahoma;}"

        Header = Header & "td{"
        Header = Header & "border: solid 1pt black;"
        Header = Header & "font-family: Tahoma;"
        Header = Header & "font-size: 12px;"
        Header = Header & "vertical-align:top;}"

        Header = Header & "</style>"
        Header = Header & "</head>"
        Header = Header & "<body>"
        Header = Header & sb.ToString
        Header = Header & "</body></html>"
        oMsg.Body = Header
        oClient.Send(oMsg)
      Catch ex As Exception
        mRet = ex.Message
      End Try
      Return mRet
    End Function
  End Class
End Namespace
