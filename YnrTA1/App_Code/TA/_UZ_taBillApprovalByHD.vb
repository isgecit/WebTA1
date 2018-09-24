Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Imports System.Web.Mail
Imports System.Net.Mail
Namespace SIS.TA
  Partial Public Class taBillApprovalByHD
    Public ReadOnly Property ApproveWFVisible() As Boolean
      Get
        Dim mRet As Boolean = False
        Try
          Select Case BillStatusID
            Case TAStates.UnderVerification
              mRet = True
          End Select
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
          Select Case BillStatusID
            Case TAStates.UnderVerification
              mRet = True
          End Select
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
    Public Shared Function ApproveWF(ByVal TABillNo As Int32, ByVal ApprovalRemarks As String) As SIS.TA.taBillApprovalByHD
      Dim Results As SIS.TA.taBillApprovalByHD = taBillApprovalByHDGetByID(TABillNo)
      With Results
        .ApprovedBy = HttpContext.Current.Session("LoginID")
        .ApprovedOn = Now
        .ApprovalRemarks = ApprovalRemarks
        If .FK_TA_Bills_EmployeeID.TAApprover <> String.Empty Then
          .BillStatusID = TAStates.UnderApproval
        Else
          If Results.OOEBySystem Then
            If .FK_TA_Bills_EmployeeID.TASanctioningAuthority <> String.Empty Then
              .BillStatusID = TAStates.UnderSpecialSanction
            Else
              .BillStatusID = TAStates.UnderReceiveByAccounts
            End If
          Else
            .BillStatusID = TAStates.UnderReceiveByAccounts
          End If
        End If
      End With
      Results = SIS.TA.taBH.UpdateData(Results)
      Try
        SendEMail(Results)
      Catch ex As Exception
      End Try
      Return Results
    End Function
    Public Shared Function RejectWF(ByVal TABillNo As Int32, ByVal ApprovalRemarks As String) As SIS.TA.taBillApprovalByHD
      Dim Results As SIS.TA.taBillApprovalByHD = taBillApprovalByHDGetByID(TABillNo)
      With Results
        .ApprovedBy = HttpContext.Current.Session("LoginID")
        .ApprovedOn = Now
        .ApprovalRemarks = ApprovalRemarks
        .BillStatusID = TAStates.ReturnedByVerifier
      End With
      Results = SIS.TA.taBH.UpdateData(Results)
      Return Results
    End Function
    Public Shared Function UZ_taBillApprovalByHDSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal TABillNo As Int32, ByVal TravelTypeID As Int32, ByVal DestinationCity As String, ByVal ProjectID As String, ByVal EmployeeID As String, ByVal BillStatusID As Int32) As List(Of SIS.TA.taBillApprovalByHD)
      Dim Results As List(Of SIS.TA.taBillApprovalByHD) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          If OrderBy = String.Empty Then OrderBy = "TABillNo DESC"
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "spta_LG_BillApprovalByHDSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "spta_LG_BillApprovalByHDSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_TABillNo", SqlDbType.Int, 10, IIf(TABillNo = Nothing, 0, TABillNo))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_TravelTypeID", SqlDbType.Int, 10, IIf(TravelTypeID = Nothing, 0, TravelTypeID))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_DestinationCity", SqlDbType.NVarChar, 30, IIf(DestinationCity Is Nothing, String.Empty, DestinationCity))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_ProjectID", SqlDbType.NVarChar, 6, IIf(ProjectID Is Nothing, String.Empty, ProjectID))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_EmployeeID", SqlDbType.NVarChar, 8, IIf(EmployeeID Is Nothing, String.Empty, EmployeeID))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_BillStatusID", SqlDbType.Int, 10, IIf(BillStatusID = Nothing, 0, BillStatusID))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          RecordCount = -1
          Results = New List(Of SIS.TA.taBillApprovalByHD)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.TA.taBillApprovalByHD(Reader))
          End While
          Reader.Close()
          RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function UZ_taBillApprovalByHDUpdate(ByVal Record As SIS.TA.taBillApprovalByHD) As SIS.TA.taBillApprovalByHD
      Dim _Result As SIS.TA.taBillApprovalByHD = taBillApprovalByHDUpdate(Record)
      Return _Result
    End Function
    'Public Shared Shadows Function SendEMail(ByVal oTA As SIS.TA.taBH) As String
    '  Dim mRet As String = ""
    '  Dim First As Boolean = True
    '  Dim Cnt As Integer = 0
    '  Dim mRecipients As New StringBuilder
    '  Dim maySend As Boolean = False

    '  Dim oClient As SmtpClient = New SmtpClient()
    '  Dim oMsg As System.Net.Mail.MailMessage = New System.Net.Mail.MailMessage()
    '  Dim oEmp As SIS.TA.taEmployees = oTA.FK_TA_Bills_EmployeeID
    '  Dim oVrf As SIS.TA.taEmployees = Nothing
    '  Dim oApr As SIS.TA.taEmployees = Nothing
    '  Dim ad As MailAddress = Nothing

    '  If oEmp.TAVerifier <> String.Empty Then
    '    oVrf = SIS.TA.taEmployees.taEmployeesGetByID(oEmp.TAVerifier)
    '  End If
    '  If oEmp.TAApprover <> String.Empty Then
    '    oApr = SIS.TA.taEmployees.taEmployeesGetByID(oEmp.TAApprover)
    '  End If
    '  'From EMail
    '  If oEmp.EMailID <> String.Empty Then
    '    ad = New MailAddress(oEmp.EMailID, oEmp.EmployeeName)
    '    oMsg.From = ad
    '    oMsg.CC.Add(ad)
    '  End If
    '  If oTA.BillStatusID = TAStates.UnderApprovalByHOD Then
    '    If oVrf.EMailID <> String.Empty Then
    '      ad = New MailAddress(oVrf.EMailID, oVrf.EmployeeName)
    '      oMsg.To.Add(ad)
    '    End If
    '  ElseIf oTA.BillStatusID = TAStates.UnderApprovalByBusinessHead Then
    '    If oApr.EMailID <> String.Empty Then
    '      ad = New MailAddress(oApr.EMailID, oApr.EmployeeName)
    '      oMsg.To.Add(ad)
    '    End If
    '  End If
    '  oMsg.IsBodyHtml = True
    '  oMsg.Subject = "Approve TA Bill of : " & oEmp.EmployeeName

    '  Dim sb As New StringBuilder
    '  With sb
    '    .AppendLine("<table style=""width:900px"" border=""1"" cellspacing=""1"" cellpadding=""1"">")
    '    .AppendLine("<tr><td colspan=""2"" align=""center""><h3><b>TA BILL APPROVAL NOTIFICATION</b></h3></td></tr>")
    '    .AppendLine("<tr><td bgcolor=""lightgray""><b>TA Bill No.</b></td>")
    '    .AppendLine("<td>" & oTA.TABillNo & "</td></tr>")
    '    .AppendLine("<tr><td bgcolor=""lightgray""><b>TA Period</b></td>")
    '    .AppendLine("<td>" & "From : " & oTA.StartDateTime & " To : " & oTA.EndDateTime & "</td></tr>")
    '    .AppendLine("<tr><td bgcolor=""lightgray""><b>Purpose</b></td>")
    '    .AppendLine("<td>" & oTA.PurposeOfJourney & "</td></tr>")
    '    .AppendLine("<tr><td bgcolor=""lightgray""><b>Total Claimed Amt.</b></td>")
    '    .AppendLine("<td>" & oTA.TotalClaimedAmount & "</td></tr>")
    '    .AppendLine("<tr><td colspan=""2"">TA is submitted to you for approval. Please Log in online TA Bill System to approve the same.</td>")
    '    .AppendLine("</table>")
    '  End With
    '  Try
    '    Dim Header As String = ""
    '    Header = Header & "<html xmlns=""http://www.w3.org/1999/xhtml"">"
    '    Header = Header & "<head>"
    '    Header = Header & "<title></title>"
    '    Header = Header & "<style>"
    '    Header = Header & "table{"

    '    Header = Header & "border: solid 1pt black;"
    '    Header = Header & "border-collapse:collapse;"
    '    Header = Header & "font-family: Tahoma;}"

    '    Header = Header & "td{"
    '    Header = Header & "border: solid 1pt black;"
    '    Header = Header & "font-family: Tahoma;"
    '    Header = Header & "font-size: 12px;"
    '    Header = Header & "vertical-align:top;}"

    '    Header = Header & "</style>"
    '    Header = Header & "</head>"
    '    Header = Header & "<body>"
    '    Header = Header & sb.ToString
    '    Header = Header & "</body></html>"
    '    oMsg.Body = Header
    '    oClient.Send(oMsg)
    '  Catch ex As Exception
    '    mRet = ex.Message
    '  End Try
    '  Return mRet
    'End Function
  End Class
End Namespace
