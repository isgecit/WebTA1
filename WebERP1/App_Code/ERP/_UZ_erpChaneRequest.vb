Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Imports System.Web.Mail
Imports System.Net.Mail
Namespace SIS.ERP
  Partial Public Class erpChaneRequest
    Public ReadOnly Property GetNotesLink() As String
      Get
        Dim mRet As String = HttpContext.Current.Request.Url.Scheme & Uri.SchemeDelimiter & HttpContext.Current.Request.Url.Authority
        If HttpContext.Current.Request.Url.Authority.ToLower = "localhost" Then
          mRet = "http://192.9.200.146"
        End If
        mRet &= "/Attachment/Notes.aspx?handle=J_ERPCHANGEREQUEST"
        Dim Index As String = ApplID & "_" & RequestID
        Dim User As String = HttpContext.Current.Session("LoginID")
        Dim canEdit As String = "y"
        Return mRet & "&Index=" & Index & "&user=" & User & "&ed=" & canEdit
      End Get
    End Property
    Public Function GetColor() As System.Drawing.Color
      Dim mRet As System.Drawing.Color = Drawing.Color.Black
      Select Case StatusID
        Case erpRequestStates.Cancelled, erpRequestStates.ReturnedForCorrection
          mRet = Drawing.Color.Red
        Case erpRequestStates.UnderApprovalByHOD
          mRet = Drawing.Color.DarkMagenta
        Case erpRequestStates.UnderEvaluationByIT
          mRet = Drawing.Color.DarkGoldenrod
        Case erpRequestStates.UnderEvaluationByESC, erpRequestStates.AcceptedByESC
          mRet = Drawing.Color.MediumPurple
        Case erpRequestStates.HoldByESC, erpRequestStates.RejectedByESC
          mRet = Drawing.Color.Red
        Case erpRequestStates.UnderDevelopmentByMSL, erpRequestStates.UnderEstimationByMSL
          mRet = Drawing.Color.Crimson
        Case erpRequestStates.Delivered
          mRet = Drawing.Color.Green
      End Select
      Return mRet
    End Function
    Public Function GetVisible() As Boolean
      Dim mRet As Boolean = True
      Return mRet
    End Function
    Public Function GetEnable() As Boolean
      Dim mRet As Boolean = True
      Return mRet
    End Function
    Public ReadOnly Property InitiateWFVisible() As Boolean
      Get
        Dim mRet As Boolean = False
        Try
          If _StatusID = 2 Or _StatusID = 3 Then
            mRet = True
          End If
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property InitiateWFEnable() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetEnable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public Shared Function InitiateWF(ByVal ApplID As Int32, ByVal RequestID As Int32) As SIS.ERP.erpChaneRequest
      Dim Results As SIS.ERP.erpChaneRequest = erpChaneRequestGetByID(ApplID, RequestID)
      Dim oUserRoles As List(Of SIS.ERP.erpUserRoles) = SIS.ERP.erpUserRoles.erpUserRolesSelectList(0, 99, "", False, "", HttpContext.Current.Session("LoginID"), "", 1)
      Dim ApproverID As String = ""
      For Each _ur As SIS.ERP.erpUserRoles In oUserRoles
        If _ur.RoleID = 1 Then
          If _ur.ApproverID <> String.Empty Then
            ApproverID = _ur.ApproverID
            Exit For
          End If
        End If
      Next
      If ApproverID = String.Empty Then
        Throw New Exception("No Approver is assigned in system, CANNOT FORWARD for approval.")
      Else
        Results.StatusID = 4
        Results.ApprovedBy = ApproverID
        Results.RequestedOn = Now
        Results.ApprovedOn = ""
        Results.ReturnRemarks = ""
        Results = SIS.ERP.erpChaneRequest.UpdateData(Results)
        SendEMail(Results, 1)
      End If
      Return Results
    End Function
    Public Shared Function UZ_erpChaneRequestSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal ApplID As Int32, ByVal RequestedBy As String, ByVal RequestTypeID As Int32, ByVal StatusID As Int32, ByVal PriorityID As Int32) As List(Of SIS.ERP.erpChaneRequest)
      Dim Results As List(Of SIS.ERP.erpChaneRequest) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          If OrderBy = String.Empty Then OrderBy = "RequestID DESC"
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "sperpChaneRequestSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "sperpChaneRequestSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_ApplID", SqlDbType.Int, 10, IIf(ApplID = Nothing, 0, ApplID))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_RequestedBy", SqlDbType.NVarChar, 8, IIf(RequestedBy Is Nothing, String.Empty, RequestedBy))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_RequestTypeID", SqlDbType.Int, 10, IIf(RequestTypeID = Nothing, 0, RequestTypeID))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_StatusID", SqlDbType.Int, 10, IIf(StatusID = Nothing, 0, StatusID))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_PriorityID", SqlDbType.Int, 10, IIf(PriorityID = Nothing, 0, PriorityID))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.ERP.erpChaneRequest)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.ERP.erpChaneRequest(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function UZ_erpChaneRequestInsert(ByVal Record As SIS.ERP.erpChaneRequest) As SIS.ERP.erpChaneRequest
      Dim _Result As SIS.ERP.erpChaneRequest = erpChaneRequestInsert(Record)
      Return _Result
    End Function
    Public Shared Function UZ_erpChaneRequestUpdate(ByVal Record As SIS.ERP.erpChaneRequest) As SIS.ERP.erpChaneRequest
      Dim _Result As SIS.ERP.erpChaneRequest = erpChaneRequestUpdate(Record)
      Return _Result
    End Function
    Public Shared Shadows Function SendEMail(ByVal oRq As SIS.ERP.erpChaneRequest, Optional ByVal Objective As String = "1") As String
      Dim mRet As String = ""
      Dim First As Boolean = True
      Dim Cnt As Integer = 0
      Dim maySend As Boolean = False
      Dim FromID As String = ""
      Dim oClient As SmtpClient = New SmtpClient()
      Dim oMsg As System.Net.Mail.MailMessage = New System.Net.Mail.MailMessage()
      Select Case Objective
        Case "1" 'Approval By HOD
          oMsg.From = New MailAddress(oRq.FK_ERP_ChaneRequest_RequestedBy.EMailID, oRq.FK_ERP_ChaneRequest_RequestedBy.UserFullName)
          oMsg.To.Add(New MailAddress(oRq.FK_ERP_ChaneRequest_ApprovedBy.EMailID, oRq.FK_ERP_ChaneRequest_ApprovedBy.UserFullName))
          oMsg.CC.Add(New MailAddress(oRq.FK_ERP_ChaneRequest_RequestedBy.EMailID, oRq.FK_ERP_ChaneRequest_RequestedBy.UserFullName))
          oMsg.CC.Add(New MailAddress("veena@isgec.co.in", "Veena"))
          oMsg.Subject = "HOD Approval ERP Change Request #" & oRq.RequestID
        Case "2" 'Reject By HOD
          oMsg.From = New MailAddress(oRq.FK_ERP_ChaneRequest_ApprovedBy.EMailID, oRq.FK_ERP_ChaneRequest_ApprovedBy.UserFullName)
          oMsg.To.Add(New MailAddress(oRq.FK_ERP_ChaneRequest_RequestedBy.EMailID, oRq.FK_ERP_ChaneRequest_RequestedBy.UserFullName))
          oMsg.CC.Add(New MailAddress(oRq.FK_ERP_ChaneRequest_ApprovedBy.EMailID, oRq.FK_ERP_ChaneRequest_ApprovedBy.UserFullName))
          oMsg.Subject = "HOD Returned ERP Change Request #" & oRq.RequestID
        Case "3" 'Approved By HOD, Evaluation By IT
          oMsg.From = New MailAddress(oRq.FK_ERP_ChaneRequest_ApprovedBy.EMailID, oRq.FK_ERP_ChaneRequest_ApprovedBy.UserFullName)
          Dim oURs As List(Of SIS.ERP.erpUserRoles) = SIS.ERP.erpUserRoles.erpUserRolesSelectList(0, 999, "", False, "", "", "", 2)
          For Each _ur As SIS.ERP.erpUserRoles In oURs
            oMsg.To.Add(New MailAddress(_ur.FK_ERP_UserRoles_RequesterID.EMailID, _ur.FK_ERP_UserRoles_RequesterID.UserFullName))
          Next
          oMsg.CC.Add(New MailAddress(oRq.FK_ERP_ChaneRequest_RequestedBy.EMailID, oRq.FK_ERP_ChaneRequest_RequestedBy.UserFullName))
          oMsg.CC.Add(New MailAddress(oRq.FK_ERP_ChaneRequest_ApprovedBy.EMailID, oRq.FK_ERP_ChaneRequest_ApprovedBy.UserFullName))
          oMsg.Subject = "Evalustion By IT -ERP Change Request #" & oRq.RequestID
        Case "4" 'Reject By IT
          Dim LoginUser As SIS.QCM.qcmUsers = SIS.QCM.qcmUsers.qcmUsersGetByID(HttpContext.Current.Session("LoginID"))
          oMsg.From = New MailAddress(LoginUser.EMailID, LoginUser.UserFullName)
          oMsg.To.Add(New MailAddress(oRq.FK_ERP_ChaneRequest_RequestedBy.EMailID, oRq.FK_ERP_ChaneRequest_RequestedBy.UserFullName))
          'IT
          Dim oURs As List(Of SIS.ERP.erpUserRoles) = SIS.ERP.erpUserRoles.erpUserRolesSelectList(0, 999, "", False, "", "", "", 2)
          For Each _ur As SIS.ERP.erpUserRoles In oURs
            oMsg.CC.Add(New MailAddress(_ur.FK_ERP_UserRoles_RequesterID.EMailID, _ur.FK_ERP_UserRoles_RequesterID.UserFullName))
          Next
          oMsg.CC.Add(New MailAddress(oRq.FK_ERP_ChaneRequest_ApprovedBy.EMailID, oRq.FK_ERP_ChaneRequest_ApprovedBy.UserFullName))
          oMsg.CC.Add(New MailAddress(LoginUser.EMailID, LoginUser.UserFullName))
          oMsg.Subject = "IT Returned -ERP Change Request #" & oRq.RequestID
        Case "5" 'Approved By IT, Evaluation By ESC
          Dim LoginUser As SIS.QCM.qcmUsers = SIS.QCM.qcmUsers.qcmUsersGetByID(HttpContext.Current.Session("LoginID"))
          oMsg.From = New MailAddress(LoginUser.EMailID, LoginUser.UserFullName)
          oMsg.To.Add(New MailAddress(oRq.FK_ERP_ChaneRequest_RequestedBy.EMailID, oRq.FK_ERP_ChaneRequest_RequestedBy.UserFullName))
          'SC
          Dim oURs As List(Of SIS.ERP.erpUserRoles) = SIS.ERP.erpUserRoles.erpUserRolesSelectList(0, 999, "", False, "", "", "", 3)
          For Each _ur As SIS.ERP.erpUserRoles In oURs
            oMsg.CC.Add(New MailAddress(_ur.FK_ERP_UserRoles_RequesterID.EMailID, _ur.FK_ERP_UserRoles_RequesterID.UserFullName))
          Next
          'IT
          oURs = SIS.ERP.erpUserRoles.erpUserRolesSelectList(0, 999, "", False, "", "", "", 2)
          For Each _ur As SIS.ERP.erpUserRoles In oURs
            oMsg.CC.Add(New MailAddress(_ur.FK_ERP_UserRoles_RequesterID.EMailID, _ur.FK_ERP_UserRoles_RequesterID.UserFullName))
          Next

          oMsg.CC.Add(New MailAddress(oRq.FK_ERP_ChaneRequest_ApprovedBy.EMailID, oRq.FK_ERP_ChaneRequest_ApprovedBy.UserFullName))
          oMsg.CC.Add(New MailAddress(LoginUser.EMailID, LoginUser.UserFullName))
          oMsg.Subject = "Evaluation By Sterring Committee -ERP Change Request #" & oRq.RequestID
        Case "6" 'Decided By ESC
          Dim LoginUser As SIS.QCM.qcmUsers = SIS.QCM.qcmUsers.qcmUsersGetByID(HttpContext.Current.Session("LoginID"))
          oMsg.From = New MailAddress(LoginUser.EMailID, LoginUser.UserFullName)
          oMsg.To.Add(New MailAddress(oRq.FK_ERP_ChaneRequest_RequestedBy.EMailID, oRq.FK_ERP_ChaneRequest_RequestedBy.UserFullName))
          Dim oURs As List(Of SIS.ERP.erpUserRoles) = SIS.ERP.erpUserRoles.erpUserRolesSelectList(0, 999, "", False, "", "", "", 3)
          For Each _ur As SIS.ERP.erpUserRoles In oURs
            oMsg.CC.Add(New MailAddress(_ur.FK_ERP_UserRoles_RequesterID.EMailID, _ur.FK_ERP_UserRoles_RequesterID.UserFullName))
          Next
          oMsg.CC.Add(New MailAddress(LoginUser.EMailID, LoginUser.UserFullName))
          oMsg.CC.Add(New MailAddress(oRq.FK_ERP_ChaneRequest_ApprovedBy.EMailID, oRq.FK_ERP_ChaneRequest_ApprovedBy.UserFullName))
          oMsg.Subject = "Finalized By Sterring Committee -ERP Change Request #" & oRq.RequestID
      End Select
      If oMsg.To.Count > 0 Then
        With oMsg
          .IsBodyHtml = True
          Dim oTbl As Table = SIS.ERP.erpChaneRequest.GetTable(oRq.ApplID, oRq.RequestID)
          Dim sb As StringBuilder = New StringBuilder()
          Dim sw As IO.StringWriter = New IO.StringWriter(sb)
          Dim writer As HtmlTextWriter = New HtmlTextWriter(sw)
          Try
            oTbl.RenderControl(writer)
          Catch ex As Exception

          End Try
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
          Header = Header & "font-size: 9px;"
          Header = Header & "vertical-align:top;}"

          Header = Header & "</style>"
          Header = Header & "</head>"
          Header = Header & "<body>"
          Header = Header & sb.ToString
          Header = Header & "</body></html>"
          .Body = Header
        End With
        Try
          oClient.Send(oMsg)
        Catch ex As Exception
        End Try
      End If
      Return mRet
    End Function
    Public Shared Function GetTable(ByVal ApplID As String, ByVal RequestID As String) As Table
      Dim oVar As SIS.ERP.erpChaneRequest = SIS.ERP.erpChaneRequest.erpChaneRequestGetByID(ApplID, RequestID)

      Dim oTbl As New Table
      oTbl.GridLines = GridLines.Both
      oTbl.Width = 900
      oTbl.Style.Add("text-align", "left")
      oTbl.Style.Add("font", "Tahoma")

      Dim oCol As TableCell = Nothing
      Dim oRow As TableRow = Nothing

      oRow = New TableRow
      oCol = New TableCell
      oCol.ColumnSpan = "5"
      oCol.Text = "Annexure-I"
      oCol.Style.Add("text-align", "center")
      oCol.Style.Add("border-bottom", "none")
      oCol.Font.Size = "14"
      oRow.Cells.Add(oCol)
      oTbl.Rows.Add(oRow)

      oRow = New TableRow
      oCol = New TableCell
      oCol.ColumnSpan = "5"
      oCol.Text = "IT Business Application Change Request Form"
      oCol.Style.Add("text-align", "center")
      oCol.Style.Add("border-bottom", "none")
      oCol.Font.Size = "16"
      oRow.Cells.Add(oCol)
      oTbl.Rows.Add(oRow)

      oRow = New TableRow
      oCol = New TableCell
      oCol.Text = "APPLICTION"
      oCol.Font.Bold = True
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.ColumnSpan = "4"
      oCol.Text = oVar.ERP_Applications3_ApplName
      oRow.Cells.Add(oCol)
      oTbl.Rows.Add(oRow)


      oRow = New TableRow
      oCol = New TableCell
      oCol.Text = "REQUEST ID"
      oCol.Font.Bold = True
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.ColumnSpan = "4"
      oCol.Text = ConfigurationManager.AppSettings("IDPrefix") & oVar.RequestID.ToString.PadLeft(ConfigurationManager.AppSettings("IDLength"), "0")
      oRow.Cells.Add(oCol)
      oTbl.Rows.Add(oRow)

      oRow = New TableRow
      oCol = New TableCell
      oCol.Text = "DATE"
      oCol.Font.Bold = True
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.ColumnSpan = "4"
      oCol.Text = Convert.ToDateTime(oVar.RequestedOn).ToString("dd/MM/yyyy")
      oRow.Cells.Add(oCol)
      oTbl.Rows.Add(oRow)

      oRow = New TableRow
      oCol = New TableCell
      oCol.Text = "REQUESTOR NAME"
      oCol.Font.Bold = True
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.ColumnSpan = "2"
      oCol.Text = oVar.aspnet_Users1_UserFullName
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = "DEPARTMENT"
      oCol.Font.Bold = True
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      Try
        oCol.Text = oVar.FK_ERP_ChaneRequest_RequestedBy.FK_USR_Department.Description
      Catch ex As Exception
        oCol.Text = " "
      End Try
      oRow.Cells.Add(oCol)
      oTbl.Rows.Add(oRow)

      oRow = New TableRow
      oCol = New TableCell
      oCol.Text = "APPROVED BY HOD"
      oCol.Font.Bold = True
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.ColumnSpan = "2"
      oCol.Text = oVar.aspnet_Users2_UserFullName
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = "APPROVAL DATE"
      oCol.Font.Bold = True
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      Try
        oCol.Text = Convert.ToDateTime(oVar.ApprovedOn).ToString("dd/MM/yyyy")
      Catch ex As Exception
      End Try
      oRow.Cells.Add(oCol)
      oTbl.Rows.Add(oRow)

      oRow = New TableRow
      oCol = New TableCell
      oCol.ColumnSpan = "3"
      oCol.BackColor = Drawing.Color.LightGray
      oCol.Text = "BRIEF PROBLEM (Improvement) STATEMENT"
      oCol.Font.Bold = True
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.BackColor = Drawing.Color.LightGray
      oCol.Text = "REQUEST CATEGORY"
      oCol.Font.Bold = True
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.BackColor = Drawing.Color.LightGray
      oCol.Text = oVar.ERP_RequestTypes6_Description
      oRow.Cells.Add(oCol)
      oTbl.Rows.Add(oRow)

      oRow = New TableRow
      oCol = New TableCell
      oCol.ColumnSpan = "5"
      oCol.Height = 120
      oCol.Wrap = True
      oCol.Text = oVar.ChangeSubject
      oRow.Cells.Add(oCol)
      oTbl.Rows.Add(oRow)

      oRow = New TableRow
      oCol = New TableCell
      oCol.ColumnSpan = "5"
      oCol.BackColor = Drawing.Color.LightGray
      oCol.Text = "CHANGE REQUESTED (in Detail)-Attach supporting document where ever needed"
      oCol.Font.Bold = True
      oRow.Cells.Add(oCol)
      oTbl.Rows.Add(oRow)

      oRow = New TableRow
      oCol = New TableCell
      oCol.ColumnSpan = "5"
      oCol.Height = 200
      oCol.Wrap = True
      oCol.Text = oVar.ChangeDetails
      oRow.Cells.Add(oCol)
      oTbl.Rows.Add(oRow)

      oRow = New TableRow
      oCol = New TableCell
      oCol.ColumnSpan = "3"
      oCol.BackColor = Drawing.Color.LightGray
      oCol.Text = "EVALUATION DONE BY IT (after key user discussion)"
      oCol.Font.Bold = True
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.BackColor = Drawing.Color.LightGray
      oCol.Text = "DATE"
      oCol.Font.Bold = True
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.BackColor = Drawing.Color.LightGray
      Try
        oCol.Text = Convert.ToDateTime(oVar.EvaluationByITOn).ToString("dd/MM/yyyy")
      Catch ex As Exception
      End Try
      oRow.Cells.Add(oCol)
      oTbl.Rows.Add(oRow)

      oRow = New TableRow
      oCol = New TableCell
      oCol.ColumnSpan = "5"
      oCol.Height = 150
      oCol.Wrap = True
      oCol.Text = oVar.EvaluationByIT
      oRow.Cells.Add(oCol)
      oTbl.Rows.Add(oRow)

      oRow = New TableRow
      oCol = New TableCell
      oCol.ColumnSpan = "5"
      oCol.BackColor = Drawing.Color.LightGray
      oCol.Text = "JUSTIFICATION"
      oCol.Font.Bold = True
      oRow.Cells.Add(oCol)
      oTbl.Rows.Add(oRow)

      oRow = New TableRow
      oCol = New TableCell
      oCol.ColumnSpan = "5"
      oCol.Height = 100
      oCol.Wrap = True
      oCol.Text = oVar.Justification
      oRow.Cells.Add(oCol)
      oTbl.Rows.Add(oRow)

      oRow = New TableRow
      oCol = New TableCell
      oCol.ColumnSpan = "3"
      oCol.BackColor = Drawing.Color.LightGray
      oCol.Text = "EVALUATION BY STEERING COMMITTEE"
      oCol.Font.Bold = True
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.BackColor = Drawing.Color.LightGray
      oCol.Text = "DATE"
      oCol.Font.Bold = True
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.BackColor = Drawing.Color.LightGray
      Try
        oCol.Text = Convert.ToDateTime(oVar.EvaluationByESCOn).ToString("dd/MM/yyyy")
      Catch ex As Exception
      End Try
      oRow.Cells.Add(oCol)
      oTbl.Rows.Add(oRow)

      oRow = New TableRow
      oCol = New TableCell
      oCol.ColumnSpan = "5"
      oCol.Height = 150
      oCol.Wrap = True
      oCol.Text = oVar.EvaluationByESC
      oRow.Cells.Add(oCol)
      oTbl.Rows.Add(oRow)


      oRow = New TableRow
      oCol = New TableCell
      oCol.Text = "REQUEST STATUS"
      oCol.Font.Bold = True
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.ColumnSpan = "2"
      oCol.Text = oVar.ERP_RequestStatus5_Description
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = "REQUEST PRIORITY"
      oCol.Font.Bold = True
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = oVar.ERP_RequestPriority4_Description
      oRow.Cells.Add(oCol)
      oTbl.Rows.Add(oRow)



      oRow = New TableRow
      oCol = New TableCell
      oCol.Text = "EFFORT ESTIMATION (INR)"
      oCol.Font.Bold = True
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.ColumnSpan = "2"
      oCol.Text = oVar.EffortEstimation
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = "DELIVERY TIMELINE"
      oCol.Font.Bold = True
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      Try
        oCol.Text = Convert.ToDateTime(oVar.PlannedDeliveryDate).ToString("dd/MM/yyyy")
      Catch ex As Exception
      End Try
      oRow.Cells.Add(oCol)
      oTbl.Rows.Add(oRow)
      Return oTbl
    End Function
  End Class
End Namespace
