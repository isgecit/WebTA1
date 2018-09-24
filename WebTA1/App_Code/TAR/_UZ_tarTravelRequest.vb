Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Imports System.Web.Mail
Imports System.Net.Mail
Namespace SIS.TAR
  Partial Public Class tarTravelRequest
    Public Function GetColor() As System.Drawing.Color
      Dim mRet As System.Drawing.Color = Drawing.Color.Black
      Select Case StatusID
        Case TARequestStates.ReturnedFromApprover, TARequestStates.ReturnedFromBH, TARequestStates.ReturnedFromMD, TARequestStates.ReturnedFromProjectManager
          mRet = Drawing.Color.Red
        Case TARequestStates.UnderBudgetChecking
          mRet = Drawing.Color.DarkMagenta
        Case TARequestStates.UnderApproval
          mRet = Drawing.Color.Purple
        Case TARequestStates.UnderMDApproval
          mRet = Drawing.Color.DarkGoldenrod
        Case TARequestStates.Approved
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
    Public Function GetEditable() As Boolean
      Dim mRet As Boolean = False
      Select Case StatusID
        Case TARequestStates.Free, TARequestStates.ReturnedFromApprover, TARequestStates.ReturnedFromBH, TARequestStates.ReturnedFromMD, TARequestStates.ReturnedFromProjectManager
          mRet = True
      End Select
      Return mRet
    End Function
    Public Function GetDeleteable() As Boolean
      Dim mRet As Boolean = False
      Select Case StatusID
        Case TARequestStates.Free, TARequestStates.ReturnedFromApprover, TARequestStates.ReturnedFromBH, TARequestStates.ReturnedFromMD, TARequestStates.ReturnedFromProjectManager
          mRet = True
      End Select
      Return mRet
    End Function
    Public ReadOnly Property Editable() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetEditable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property Deleteable() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetDeleteable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property InitiateWFVisible() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetEditable()
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
    Public Shared Function InitiateWF(ByVal RequestID As Int32) As SIS.TAR.tarTravelRequest
      Dim Results As SIS.TAR.tarTravelRequest = tarTravelRequestGetByID(RequestID)
      '1. 
      If Convert.ToDecimal(Results.TotalRequestedAmountINR) <= 0 Then
        Throw New Exception("Requested sanction amount is ZERO, can not forward for approval.")
      End If
      '2.
      If Convert.ToDecimal(Results.RequestedConversionFactor) <= 0 Then
        Throw New Exception("Conversion Factor is ZERO, can not forward for approval.")
      End If
      '3.
      If Results.ProjectID = String.Empty AndAlso Results.CostCenterID = String.Empty Then
        Throw New Exception("Project ID and Cost center both are Blank, Enter at least one value.")
      End If
      '4.
      If Results.ProjectID <> String.Empty AndAlso Results.ProjectManagerID = String.Empty Then
        Throw New Exception("For Project related travel, Project Manager ID is required for budget entry/checking.")
      End If
      Dim IsBudgetAvailable As Boolean = True
      Dim tmpSamt As Double = 0
      '5.
      If Results.ProjectID <> String.Empty Then
        tmpSamt = SIS.TA.taBH.GetAvailableSanctionInERP(Results.ProjectID)
        If tmpSamt <= 0 Then
          IsBudgetAvailable = False
          'ElseIf tmpSamt - results.TotalRequestedAmountINR < 0 Then
          '  IsBudgetAvailable = False
        End If
      End If
      With Results
        If .StatusID <> TARequestStates.Free Then
          .ProjectManagerRemarks = ""
          .BudgetCheckedBy = ""
          .BudgetCheckedOn = ""
          .ApproverRemarks = ""
          .ApprovedOn = ""
          .ApprovedBy = ""
          .BHApprovalBy = ""
          .BHApprovalOn = ""
          .BHRemarks = ""
          .MDApprovalBy = ""
          .MDApprovalOn = ""
          .MDRemarks = ""
        End If
        .BalanceBudgetWhenSubmitted = tmpSamt
        .CreatedBy = HttpContext.Current.Session("LoginID")
        .CreatedOn = Now
        If Not IsBudgetAvailable Then
          .StatusID = TARequestStates.UnderBudgetChecking
        Else
          .StatusID = TARequestStates.UnderApproval
        End If
      End With
      Results = SIS.TAR.tarTravelRequest.UpdateData(Results)
      'E-Mail Alert
      Try
        SendEMail(Results)
      Catch ex As Exception

      End Try
      '============
      Return Results
    End Function
    Public Shared Sub SendEMail(ByVal oTR As SIS.TAR.tarTravelRequest)
      Dim mRet As String = ""
      Dim oClient As SmtpClient = New SmtpClient()
      Dim oMsg As System.Net.Mail.MailMessage = New System.Net.Mail.MailMessage()
      Dim FromID As String = ""
      Dim ToID As String = ""
      Dim Subject As String = ""
      oMsg.IsBodyHtml = True
      Select Case oTR.StatusID
        Case TARequestStates.UnderBudgetChecking
          oMsg.From = New MailAddress(oTR.FK_TA_TravelRequest_RequestedFor.EMailID, oTR.FK_TA_TravelRequest_RequestedFor.UserFullName)
          oMsg.To.Add(New MailAddress(oTR.FK_TA_TravelRequest_ProjectManagerID.EMailID, oTR.FK_TA_TravelRequest_ProjectManagerID.UserFullName))
          oMsg.CC.Add(New MailAddress(oTR.FK_TA_TravelRequest_RequestedFor.EMailID, oTR.FK_TA_TravelRequest_RequestedFor.UserFullName))
          oMsg.Subject = "Enter Travel Budget in " & oTR.ProjectID
      End Select
      Dim mBody As String = ""
      mBody &= "<table style=""width:1000px;margin-top:15px;margin-left:10px;border:none;"">"
      mBody &= "<tr><td><b>Please enter budget as per following Travel Request.</b></td></tr>"
      mBody &= "</table>"
      mBody &= "<br/><br/>"


      Dim bdStr As String = ""
      Try
        bdStr &= "<html xmlns=""http://www.w3.org/1999/xhtml"">"
        bdStr &= "<head>"
        bdStr &= "<title></title>"
        bdStr &= "<meta charset=""utf-8""/>"
        bdStr &= "<meta name=""viewport"" content=""width=device-width, initial-scale=1"" />"
        bdStr &= "<style>"
        bdStr &= "table{"

        'bdStr &= "border: solid 1pt black;"
        bdStr &= "border-collapse:collapse;"
        bdStr &= "font-family: Tahoma;}"

        bdStr &= "td{"
        'bdStr &= "border: solid 1pt black;"
        bdStr &= "font-family: Tahoma;"
        bdStr &= "font-size: 100%;"
        bdStr &= "vertical-align:top;}"

        bdStr &= "</style>"
        bdStr &= "</head>"
        bdStr &= "<body>"
        bdStr &= mBody
        bdStr &= GetTRHtml(oTR.RequestID, TARequestStates.UnderBudgetChecking)
        bdStr &= "</body></html>"
        oMsg.Body = bdStr
        oClient.Send(oMsg)
      Catch ex As Exception
        mRet = ex.Message
      End Try
    End Sub
    Public Shared Function GetTRHtml(ByVal RequestID As String, ByVal ViewFor As TARequestStates) As String
      Dim pnl1 As New Panel
      Dim oVar As SIS.TAR.tarTravelRequest = SIS.TAR.tarTravelRequest.tarTravelRequestGetByID(RequestID)

      Dim sn As Integer = 0
      Dim tmpTbl As New Table
      With tmpTbl
        .Width = 1000
        .BorderStyle = BorderStyle.None
        .Style.Add("margin-top", "15px")
        .Style.Add("margin-left", "10px")
      End With
      Dim tmpRow As New TableRow
      Dim tmpCol As New TableCell
      With tmpCol
        Select Case oVar.TravelTypeID
          Case TATravelTypeValues.Domestic
            .Text = "TRAVEL REQUEST"
          Case TATravelTypeValues.ForeignTravel
            .Text = "FOREIGN TRAVEL REQUEST"
          Case TATravelTypeValues.ForeignSiteVisit
            .Text = "FOREIGN SITE VISIT REQUEST"
          Case TATravelTypeValues.HomeVisit
            .Text = "HOME VISIT REQUEST"
        End Select
        .Style.Add("text-align", "center")
        .Font.Size = FontUnit.Point(14)
        .Font.Bold = True
      End With
      tmpRow.Cells.Add(tmpCol)
      tmpTbl.Rows.Add(tmpRow)
      pnl1.Controls.Add(tmpTbl)

      Dim oTbltarTravelRequest As New Table
      oTbltarTravelRequest.Width = 1000
      oTbltarTravelRequest.GridLines = GridLines.Both
      oTbltarTravelRequest.Style.Add("margin-top", "15px")
      oTbltarTravelRequest.Style.Add("margin-left", "10px")
      oTbltarTravelRequest.CellPadding = 4

      Dim oColtarTravelRequest As TableCell = Nothing
      Dim oRowtarTravelRequest As TableRow = Nothing
      oRowtarTravelRequest = New TableRow
      oColtarTravelRequest = New TableCell
      oColtarTravelRequest.Text = "Request ID"
      oColtarTravelRequest.Font.Bold = True
      oRowtarTravelRequest.Cells.Add(oColtarTravelRequest)
      oColtarTravelRequest = New TableCell
      oColtarTravelRequest.Text = oVar.RequestID
      oColtarTravelRequest.Style.Add("text-align", "left")
      oColtarTravelRequest.ColumnSpan = "2"
      oColtarTravelRequest.Font.Size = FontUnit.Point(12)
      oRowtarTravelRequest.Cells.Add(oColtarTravelRequest)
      oColtarTravelRequest = New TableCell
      oColtarTravelRequest.Text = "Travel Request For"
      oColtarTravelRequest.Font.Bold = True
      oRowtarTravelRequest.Cells.Add(oColtarTravelRequest)
      oColtarTravelRequest = New TableCell
      oColtarTravelRequest.Text = oVar.RequestedFor
      oColtarTravelRequest.Style.Add("text-align", "left")
      oRowtarTravelRequest.Cells.Add(oColtarTravelRequest)
      oColtarTravelRequest = New TableCell
      oColtarTravelRequest.Text = oVar.aspnet_Users1_UserFullName
      oColtarTravelRequest.Style.Add("text-align", "left")
      oRowtarTravelRequest.Cells.Add(oColtarTravelRequest)
      oTbltarTravelRequest.Rows.Add(oRowtarTravelRequest)
      oRowtarTravelRequest = New TableRow
      oColtarTravelRequest = New TableCell
      oColtarTravelRequest.Text = "Along with Employee(s) [Group-List]"
      oColtarTravelRequest.Font.Bold = True
      oRowtarTravelRequest.Cells.Add(oColtarTravelRequest)
      oColtarTravelRequest = New TableCell
      oColtarTravelRequest.Text = oVar.RequestedForEmployees
      oColtarTravelRequest.Style.Add("text-align", "left")
      oColtarTravelRequest.ColumnSpan = "5"
      oRowtarTravelRequest.Cells.Add(oColtarTravelRequest)
      oTbltarTravelRequest.Rows.Add(oRowtarTravelRequest)
      oRowtarTravelRequest = New TableRow
      oColtarTravelRequest = New TableCell
      oColtarTravelRequest.Text = "Travel Type"
      oColtarTravelRequest.Font.Bold = True
      oRowtarTravelRequest.Cells.Add(oColtarTravelRequest)
      oColtarTravelRequest = New TableCell
      oColtarTravelRequest.Text = oVar.TA_TravelTypes13_TravelTypeDescription
      oColtarTravelRequest.Style.Add("text-align", "left")
      oColtarTravelRequest.ColumnSpan = "5"
      oRowtarTravelRequest.Cells.Add(oColtarTravelRequest)
      oTbltarTravelRequest.Rows.Add(oRowtarTravelRequest)
      oRowtarTravelRequest = New TableRow
      oColtarTravelRequest = New TableCell
      oColtarTravelRequest.Text = "Project"
      oColtarTravelRequest.Font.Bold = True
      oRowtarTravelRequest.Cells.Add(oColtarTravelRequest)
      oColtarTravelRequest = New TableCell
      oColtarTravelRequest.Text = oVar.ProjectID
      oColtarTravelRequest.Style.Add("text-align", "left")
      oRowtarTravelRequest.Cells.Add(oColtarTravelRequest)
      oColtarTravelRequest = New TableCell
      oColtarTravelRequest.Text = oVar.IDM_Projects9_Description
      oColtarTravelRequest.Style.Add("text-align", "left")
      oRowtarTravelRequest.Cells.Add(oColtarTravelRequest)
      oColtarTravelRequest = New TableCell
      oColtarTravelRequest.Text = "Cost Center"
      oColtarTravelRequest.Font.Bold = True
      oRowtarTravelRequest.Cells.Add(oColtarTravelRequest)
      oColtarTravelRequest = New TableCell
      oColtarTravelRequest.Text = oVar.CostCenterID
      oColtarTravelRequest.Style.Add("text-align", "left")
      oRowtarTravelRequest.Cells.Add(oColtarTravelRequest)
      oColtarTravelRequest = New TableCell
      oColtarTravelRequest.Text = oVar.HRM_Departments8_Description
      oColtarTravelRequest.Style.Add("text-align", "left")
      oRowtarTravelRequest.Cells.Add(oColtarTravelRequest)
      oTbltarTravelRequest.Rows.Add(oRowtarTravelRequest)
      oRowtarTravelRequest = New TableRow
      oColtarTravelRequest = New TableCell
      oColtarTravelRequest.Text = "Travel Itinerary"
      oColtarTravelRequest.Font.Bold = True
      oColtarTravelRequest.Height = 40
      oRowtarTravelRequest.Cells.Add(oColtarTravelRequest)
      oColtarTravelRequest = New TableCell
      oColtarTravelRequest.Text = oVar.TravelItinerary
      oColtarTravelRequest.Style.Add("text-align", "left")
      oColtarTravelRequest.ColumnSpan = "5"
      oRowtarTravelRequest.Cells.Add(oColtarTravelRequest)
      oTbltarTravelRequest.Rows.Add(oRowtarTravelRequest)
      oRowtarTravelRequest = New TableRow
      oColtarTravelRequest = New TableCell
      oColtarTravelRequest.Text = "Purpose"
      oColtarTravelRequest.Font.Bold = True
      oColtarTravelRequest.Height = 40
      oRowtarTravelRequest.Cells.Add(oColtarTravelRequest)
      oColtarTravelRequest = New TableCell
      oColtarTravelRequest.Text = oVar.Purpose
      oColtarTravelRequest.Style.Add("text-align", "left")
      oColtarTravelRequest.ColumnSpan = "5"
      oRowtarTravelRequest.Cells.Add(oColtarTravelRequest)
      oTbltarTravelRequest.Rows.Add(oRowtarTravelRequest)

      oRowtarTravelRequest = New TableRow
      oColtarTravelRequest = New TableCell
      oColtarTravelRequest.Text = "Requested Amount"
      oColtarTravelRequest.Font.Bold = True
      oRowtarTravelRequest.Cells.Add(oColtarTravelRequest)
      oColtarTravelRequest = New TableCell
      oColtarTravelRequest.Text = oVar.TotalRequestedAmount
      oColtarTravelRequest.Style.Add("text-align", "right")
      oColtarTravelRequest.ColumnSpan = "2"
      oRowtarTravelRequest.Cells.Add(oColtarTravelRequest)
      oColtarTravelRequest = New TableCell
      oColtarTravelRequest.Text = "Currency"
      oColtarTravelRequest.Font.Bold = True
      oRowtarTravelRequest.Cells.Add(oColtarTravelRequest)
      oColtarTravelRequest = New TableCell
      oColtarTravelRequest.Text = oVar.RequestedCurrencyID
      oColtarTravelRequest.Style.Add("text-align", "left")
      oColtarTravelRequest.ColumnSpan = "2"
      oRowtarTravelRequest.Cells.Add(oColtarTravelRequest)
      oTbltarTravelRequest.Rows.Add(oRowtarTravelRequest)

      oRowtarTravelRequest = New TableRow

      oColtarTravelRequest = New TableCell
      oColtarTravelRequest.Text = "Conversion Factor"
      oColtarTravelRequest.Font.Bold = True
      oRowtarTravelRequest.Cells.Add(oColtarTravelRequest)
      oColtarTravelRequest = New TableCell
      oColtarTravelRequest.Text = oVar.RequestedConversionFactor
      oColtarTravelRequest.Style.Add("text-align", "right")
      oColtarTravelRequest.ColumnSpan = "2"
      oRowtarTravelRequest.Cells.Add(oColtarTravelRequest)
      oColtarTravelRequest = New TableCell
      oColtarTravelRequest.Text = "Requested Amount [INR]"
      oColtarTravelRequest.Font.Bold = True
      oRowtarTravelRequest.Cells.Add(oColtarTravelRequest)
      oColtarTravelRequest = New TableCell
      oColtarTravelRequest.Text = oVar.TotalRequestedAmountINR
      oColtarTravelRequest.Style.Add("text-align", "right")
      oColtarTravelRequest.ColumnSpan = "2"
      oRowtarTravelRequest.Cells.Add(oColtarTravelRequest)
      oTbltarTravelRequest.Rows.Add(oRowtarTravelRequest)

      oRowtarTravelRequest = New TableRow

      oColtarTravelRequest = New TableCell
      oColtarTravelRequest.Text = "Status"
      oColtarTravelRequest.Font.Bold = True
      oRowtarTravelRequest.Cells.Add(oColtarTravelRequest)
      oColtarTravelRequest = New TableCell
      oColtarTravelRequest.Text = oVar.TA_TravelRequestStatus12_Description
      oColtarTravelRequest.Style.Add("text-align", "left")
      oColtarTravelRequest.ColumnSpan = "5"
      oRowtarTravelRequest.Cells.Add(oColtarTravelRequest)
      oTbltarTravelRequest.Rows.Add(oRowtarTravelRequest)

      oRowtarTravelRequest = New TableRow
      oColtarTravelRequest = New TableCell
      oColtarTravelRequest.Text = "Created By"
      oColtarTravelRequest.Font.Bold = True
      oRowtarTravelRequest.Cells.Add(oColtarTravelRequest)
      oColtarTravelRequest = New TableCell
      oColtarTravelRequest.Text = oVar.CreatedBy
      oColtarTravelRequest.Style.Add("text-align", "left")
      oRowtarTravelRequest.Cells.Add(oColtarTravelRequest)
      oColtarTravelRequest = New TableCell
      oColtarTravelRequest.Text = oVar.aspnet_Users2_UserFullName
      oColtarTravelRequest.Style.Add("text-align", "left")
      oRowtarTravelRequest.Cells.Add(oColtarTravelRequest)
      oColtarTravelRequest = New TableCell
      oColtarTravelRequest.Text = "Created On"
      oColtarTravelRequest.Font.Bold = True
      oRowtarTravelRequest.Cells.Add(oColtarTravelRequest)
      oColtarTravelRequest = New TableCell
      oColtarTravelRequest.Text = oVar.CreatedOn
      oColtarTravelRequest.Style.Add("text-align", "center")
      oColtarTravelRequest.ColumnSpan = "2"
      oRowtarTravelRequest.Cells.Add(oColtarTravelRequest)
      oTbltarTravelRequest.Rows.Add(oRowtarTravelRequest)

      Select Case ViewFor
        Case TARequestStates.UnderApproval, TARequestStates.UnderApprovalByBH, TARequestStates.UnderMDApproval, TARequestStates.CompleteView
          oRowtarTravelRequest = New TableRow
          oColtarTravelRequest = New TableCell
          oColtarTravelRequest.Text = "Budget Checked By"
          oColtarTravelRequest.Font.Bold = True
          oRowtarTravelRequest.Cells.Add(oColtarTravelRequest)
          oColtarTravelRequest = New TableCell
          oColtarTravelRequest.Text = oVar.BudgetCheckedBy
          oColtarTravelRequest.Style.Add("text-align", "left")
          oRowtarTravelRequest.Cells.Add(oColtarTravelRequest)
          oColtarTravelRequest = New TableCell
          oColtarTravelRequest.Text = oVar.aspnet_Users3_UserFullName
          oColtarTravelRequest.Style.Add("text-align", "left")
          oRowtarTravelRequest.Cells.Add(oColtarTravelRequest)
          oColtarTravelRequest = New TableCell
          oColtarTravelRequest.Text = "Budget Checked On"
          oColtarTravelRequest.Font.Bold = True
          oRowtarTravelRequest.Cells.Add(oColtarTravelRequest)
          oColtarTravelRequest = New TableCell
          oColtarTravelRequest.Text = oVar.BudgetCheckedOn
          oColtarTravelRequest.Style.Add("text-align", "center")
          oColtarTravelRequest.ColumnSpan = "2"
          oRowtarTravelRequest.Cells.Add(oColtarTravelRequest)
          oTbltarTravelRequest.Rows.Add(oRowtarTravelRequest)
          oRowtarTravelRequest = New TableRow
          oColtarTravelRequest = New TableCell
          oColtarTravelRequest.Text = "Project Manager Remarks"
          oColtarTravelRequest.Font.Bold = True
          oColtarTravelRequest.Height = 40
          oRowtarTravelRequest.Cells.Add(oColtarTravelRequest)
          oColtarTravelRequest = New TableCell
          oColtarTravelRequest.Text = oVar.ProjectManagerRemarks
          oColtarTravelRequest.Style.Add("text-align", "left")
          oColtarTravelRequest.ColumnSpan = "5"
          oRowtarTravelRequest.Cells.Add(oColtarTravelRequest)
          oTbltarTravelRequest.Rows.Add(oRowtarTravelRequest)

          Select Case ViewFor
            Case TARequestStates.UnderApprovalByBH, TARequestStates.UnderMDApproval, TARequestStates.CompleteView
              oRowtarTravelRequest = New TableRow
              oColtarTravelRequest = New TableCell
              oColtarTravelRequest.Text = "Approved By"
              oColtarTravelRequest.Font.Bold = True
              oRowtarTravelRequest.Cells.Add(oColtarTravelRequest)
              oColtarTravelRequest = New TableCell
              oColtarTravelRequest.Text = oVar.ApprovedBy
              oColtarTravelRequest.Style.Add("text-align", "left")
              oRowtarTravelRequest.Cells.Add(oColtarTravelRequest)
              oColtarTravelRequest = New TableCell
              oColtarTravelRequest.Text = oVar.aspnet_Users4_UserFullName
              oColtarTravelRequest.Style.Add("text-align", "left")
              oRowtarTravelRequest.Cells.Add(oColtarTravelRequest)
              oColtarTravelRequest = New TableCell
              oColtarTravelRequest.Text = "Approved On"
              oColtarTravelRequest.Font.Bold = True
              oRowtarTravelRequest.Cells.Add(oColtarTravelRequest)
              oColtarTravelRequest = New TableCell
              oColtarTravelRequest.Text = oVar.ApprovedOn
              oColtarTravelRequest.Style.Add("text-align", "center")
              oColtarTravelRequest.ColumnSpan = "2"
              oRowtarTravelRequest.Cells.Add(oColtarTravelRequest)
              oTbltarTravelRequest.Rows.Add(oRowtarTravelRequest)
              oRowtarTravelRequest = New TableRow
              oColtarTravelRequest = New TableCell
              oColtarTravelRequest.Text = "Approver Remarks"
              oColtarTravelRequest.Font.Bold = True
              oColtarTravelRequest.Height = 40
              oRowtarTravelRequest.Cells.Add(oColtarTravelRequest)
              oColtarTravelRequest = New TableCell
              oColtarTravelRequest.Text = oVar.ApproverRemarks
              oColtarTravelRequest.Style.Add("text-align", "left")
              oColtarTravelRequest.ColumnSpan = "5"
              oRowtarTravelRequest.Cells.Add(oColtarTravelRequest)
              oTbltarTravelRequest.Rows.Add(oRowtarTravelRequest)

              Select Case ViewFor
                Case TARequestStates.UnderMDApproval, TARequestStates.CompleteView
                  oRowtarTravelRequest = New TableRow
                  oColtarTravelRequest = New TableCell
                  oColtarTravelRequest.Text = "Approval By Business Head"
                  oColtarTravelRequest.Font.Bold = True
                  oRowtarTravelRequest.Cells.Add(oColtarTravelRequest)
                  oColtarTravelRequest = New TableCell
                  oColtarTravelRequest.Text = oVar.BHApprovalBy
                  oColtarTravelRequest.Style.Add("text-align", "left")
                  oRowtarTravelRequest.Cells.Add(oColtarTravelRequest)
                  oColtarTravelRequest = New TableCell
                  oColtarTravelRequest.Text = oVar.aspnet_Users5_UserFullName
                  oColtarTravelRequest.Style.Add("text-align", "left")
                  oRowtarTravelRequest.Cells.Add(oColtarTravelRequest)
                  oColtarTravelRequest = New TableCell
                  oColtarTravelRequest.Text = "Approval By Business Head On"
                  oColtarTravelRequest.Font.Bold = True
                  oRowtarTravelRequest.Cells.Add(oColtarTravelRequest)
                  oColtarTravelRequest = New TableCell
                  oColtarTravelRequest.Text = oVar.BHApprovalOn
                  oColtarTravelRequest.Style.Add("text-align", "center")
                  oColtarTravelRequest.ColumnSpan = "2"
                  oRowtarTravelRequest.Cells.Add(oColtarTravelRequest)
                  oTbltarTravelRequest.Rows.Add(oRowtarTravelRequest)
                  oRowtarTravelRequest = New TableRow
                  oColtarTravelRequest = New TableCell
                  oColtarTravelRequest.Text = "Business Head Remarks"
                  oColtarTravelRequest.Font.Bold = True
                  oColtarTravelRequest.Height = 40
                  oRowtarTravelRequest.Cells.Add(oColtarTravelRequest)
                  oColtarTravelRequest = New TableCell
                  oColtarTravelRequest.Text = oVar.BHRemarks
                  oColtarTravelRequest.Style.Add("text-align", "left")
                  oColtarTravelRequest.ColumnSpan = "5"
                  oRowtarTravelRequest.Cells.Add(oColtarTravelRequest)
                  oTbltarTravelRequest.Rows.Add(oRowtarTravelRequest)

                  Select Case ViewFor
                    Case TARequestStates.CompleteView
                      oRowtarTravelRequest = New TableRow
                      oColtarTravelRequest = New TableCell
                      oColtarTravelRequest.Text = "Approval For MD By"
                      oColtarTravelRequest.Font.Bold = True
                      oRowtarTravelRequest.Cells.Add(oColtarTravelRequest)
                      oColtarTravelRequest = New TableCell
                      oColtarTravelRequest.Text = oVar.MDApprovalBy
                      oColtarTravelRequest.Style.Add("text-align", "left")
                      oRowtarTravelRequest.Cells.Add(oColtarTravelRequest)
                      oColtarTravelRequest = New TableCell
                      oColtarTravelRequest.Text = oVar.aspnet_Users6_UserFullName
                      oColtarTravelRequest.Style.Add("text-align", "left")
                      oRowtarTravelRequest.Cells.Add(oColtarTravelRequest)
                      oColtarTravelRequest = New TableCell
                      oColtarTravelRequest.Text = "Approval By MD On"
                      oColtarTravelRequest.Font.Bold = True
                      oRowtarTravelRequest.Cells.Add(oColtarTravelRequest)
                      oColtarTravelRequest = New TableCell
                      oColtarTravelRequest.Text = oVar.MDApprovalOn
                      oColtarTravelRequest.Style.Add("text-align", "center")
                      oColtarTravelRequest.ColumnSpan = "2"
                      oRowtarTravelRequest.Cells.Add(oColtarTravelRequest)
                      oTbltarTravelRequest.Rows.Add(oRowtarTravelRequest)
                      oRowtarTravelRequest = New TableRow
                      oColtarTravelRequest = New TableCell
                      oColtarTravelRequest.Text = "Remarks From MD"
                      oColtarTravelRequest.Font.Bold = True
                      oColtarTravelRequest.Height = 40
                      oRowtarTravelRequest.Cells.Add(oColtarTravelRequest)
                      oColtarTravelRequest = New TableCell
                      oColtarTravelRequest.Text = oVar.MDRemarks
                      oColtarTravelRequest.Style.Add("text-align", "left")
                      oColtarTravelRequest.ColumnSpan = "5"
                      oRowtarTravelRequest.Cells.Add(oColtarTravelRequest)
                      oTbltarTravelRequest.Rows.Add(oRowtarTravelRequest)

                      oRowtarTravelRequest = New TableRow
                      oColtarTravelRequest = New TableCell
                      oColtarTravelRequest.Text = "Details of MD Sanction"
                      oColtarTravelRequest.BackColor = Drawing.Color.LightGray
                      oColtarTravelRequest.Font.Bold = True
                      oColtarTravelRequest.Font.Italic = True
                      oColtarTravelRequest.ColumnSpan = "6"
                      oColtarTravelRequest.Style.Add("text-align", "center")
                      oRowtarTravelRequest.Cells.Add(oColtarTravelRequest)
                      oTbltarTravelRequest.Rows.Add(oRowtarTravelRequest)

                      oRowtarTravelRequest = New TableRow
                      oColtarTravelRequest = New TableCell
                      oColtarTravelRequest.Text = "Currency"
                      oColtarTravelRequest.Font.Bold = True
                      oRowtarTravelRequest.Cells.Add(oColtarTravelRequest)
                      oColtarTravelRequest = New TableCell
                      oColtarTravelRequest.Text = oVar.MDCurrencyID
                      oColtarTravelRequest.Style.Add("text-align", "left")
                      oRowtarTravelRequest.Cells.Add(oColtarTravelRequest)
                      oColtarTravelRequest = New TableCell
                      oColtarTravelRequest.Text = oVar.TA_Currencies11_CurrencyName
                      oColtarTravelRequest.Style.Add("text-align", "left")
                      oRowtarTravelRequest.Cells.Add(oColtarTravelRequest)
                      oColtarTravelRequest = New TableCell
                      oColtarTravelRequest.Text = "Conversion Factor"
                      oColtarTravelRequest.Font.Bold = True
                      oRowtarTravelRequest.Cells.Add(oColtarTravelRequest)
                      oColtarTravelRequest = New TableCell
                      oColtarTravelRequest.Text = oVar.MDConversionFactor
                      oColtarTravelRequest.Style.Add("text-align", "right")
                      oColtarTravelRequest.ColumnSpan = "2"
                      oRowtarTravelRequest.Cells.Add(oColtarTravelRequest)
                      oTbltarTravelRequest.Rows.Add(oRowtarTravelRequest)
                      oRowtarTravelRequest = New TableRow
                      oColtarTravelRequest = New TableCell
                      oColtarTravelRequest.Text = "Sanctioned DA Amount"
                      oColtarTravelRequest.Font.Bold = True
                      oRowtarTravelRequest.Cells.Add(oColtarTravelRequest)
                      oColtarTravelRequest = New TableCell
                      oColtarTravelRequest.Text = oVar.MDDAAmount
                      oColtarTravelRequest.Style.Add("text-align", "right")
                      oColtarTravelRequest.ColumnSpan = "2"
                      oRowtarTravelRequest.Cells.Add(oColtarTravelRequest)
                      oColtarTravelRequest = New TableCell
                      oColtarTravelRequest.Text = "Sanctioned DA [INR]"
                      oColtarTravelRequest.Font.Bold = True
                      oRowtarTravelRequest.Cells.Add(oColtarTravelRequest)
                      oColtarTravelRequest = New TableCell
                      oColtarTravelRequest.Text = oVar.MDDAAmountINR
                      oColtarTravelRequest.Style.Add("text-align", "right")
                      oColtarTravelRequest.ColumnSpan = "2"
                      oRowtarTravelRequest.Cells.Add(oColtarTravelRequest)
                      oTbltarTravelRequest.Rows.Add(oRowtarTravelRequest)
                      oRowtarTravelRequest = New TableRow
                      oColtarTravelRequest = New TableCell
                      oColtarTravelRequest.Text = "Sanctioned Lodging"
                      oColtarTravelRequest.Font.Bold = True
                      oRowtarTravelRequest.Cells.Add(oColtarTravelRequest)
                      oColtarTravelRequest = New TableCell
                      oColtarTravelRequest.Text = oVar.MDLodgingAmount
                      oColtarTravelRequest.Style.Add("text-align", "right")
                      oColtarTravelRequest.ColumnSpan = "2"
                      oRowtarTravelRequest.Cells.Add(oColtarTravelRequest)
                      oColtarTravelRequest = New TableCell
                      oColtarTravelRequest.Text = "Sanctioned Lodging [INR]"
                      oColtarTravelRequest.Font.Bold = True
                      oRowtarTravelRequest.Cells.Add(oColtarTravelRequest)
                      oColtarTravelRequest = New TableCell
                      oColtarTravelRequest.Text = oVar.MDLodgingAmountINR
                      oColtarTravelRequest.Style.Add("text-align", "right")
                      oColtarTravelRequest.ColumnSpan = "2"
                      oRowtarTravelRequest.Cells.Add(oColtarTravelRequest)
                      oTbltarTravelRequest.Rows.Add(oRowtarTravelRequest)
                  End Select
              End Select
          End Select
      End Select

      pnl1.Controls.Add(oTbltarTravelRequest)

      Dim sb As Text.StringBuilder = New Text.StringBuilder()
      Dim stWriter As IO.StringWriter = New IO.StringWriter(sb)
      Dim htmlWriter As System.Web.UI.HtmlTextWriter = New System.Web.UI.HtmlTextWriter(stWriter)
      pnl1.RenderControl(htmlWriter)
      Return sb.ToString()

    End Function



    Public Shared Function SanctionAvailableHTML(ByVal RequestID As Integer, Optional ForPM As Boolean = False) As String
      Dim mRet As String = "<table style='margin:20px auto auto auto;' cellspacing='1' cellpadding='1' border='1'>"
      mRet &= "<thead><tr><th>Project</th><th>Element</th><th>Available Budget</th><th>Required in Request</th><th>Balance<br/>[After this Bill]</th></tr></thead>"
      Dim Results As SIS.TAR.tarTravelRequest = tarTravelRequestGetByID(RequestID)
      If Results.ProjectID = "" Then
        mRet &= "<tr><td colspan='5' style='color:green;text-align:center;'>This Travel Request does not require Project Budget.</td></tr>"
      Else
        Dim Element As String = ""
        Dim tmpSamt As Double = SIS.TA.taBH.GetAvailableSanctionInERP(Results.ProjectID, Element)
        mRet &= "<tr><td>" & Results.ProjectID & "</td><td style='text-align:center'>" & Element & "</td><td style='text-align:center'>" & tmpSamt.ToString("n") & "</td><td style='text-align:center'>" & Results.TotalRequestedAmountINR & "</td><td style='text-align:center'>" & (tmpSamt - Results.TotalRequestedAmountINR).ToString("n") & "</td></tr>"
      End If
      If Results.ProjectID <> "" AndAlso Not ForPM Then
        mRet &= "<tr><td colspan='5' style='color:red;'>NOTE:=&gt;Travel Request will be submitted to Project manager, if balance is negative in project.<br/>Contact Project Manager to enter budget if required.</td></tr>"
      End If
      mRet &= "</table>"
      Return mRet
    End Function
    Public Shared Function ApproveWF(ByVal RequestID As Int32) As SIS.TAR.tarTravelRequest
      Dim Results As SIS.TAR.tarTravelRequest = tarTravelRequestGetByID(RequestID)
      Return Results
    End Function
    Public Shared Function UZ_tarTravelRequestSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String) As List(Of SIS.TAR.tarTravelRequest)
      Dim Results As List(Of SIS.TAR.tarTravelRequest) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          If OrderBy = String.Empty Then OrderBy = "RequestID DESC"
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "sptar_LG_TravelRequestSelectListSearch"
            Cmd.CommandText = "sptarTravelRequestSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "sptar_LG_TravelRequestSelectListFilteres"
            Cmd.CommandText = "sptarTravelRequestSelectListFilteres"
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.TAR.tarTravelRequest)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.TAR.tarTravelRequest(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function UZ_tarTravelRequestInsert(ByVal Record As SIS.TAR.tarTravelRequest) As SIS.TAR.tarTravelRequest
      Dim _Result As SIS.TAR.tarTravelRequest = tarTravelRequestInsert(Record)
      Return _Result
    End Function
    Public Shared Function UZ_tarTravelRequestUpdate(ByVal Record As SIS.TAR.tarTravelRequest) As SIS.TAR.tarTravelRequest
      Dim _Result As SIS.TAR.tarTravelRequest = tarTravelRequestUpdate(Record)
      Return _Result
    End Function
    Public Shared Function UZ_tarTravelRequestDelete(ByVal Record As SIS.TAR.tarTravelRequest) As Integer
      Dim _Result As Integer = tarTravelRequestDelete(Record)
      Return _Result
    End Function
    Public Shared Function SetDefaultValues(ByVal sender As System.Web.UI.WebControls.FormView, ByVal e As System.EventArgs) As System.Web.UI.WebControls.FormView
      On Error Resume Next
      Dim tmpEmp As SIS.TA.taEmployees = SIS.TA.taEmployees.taEmployeesGetByID(HttpContext.Current.Session("LoginID"))
      With sender
        CType(.FindControl("F_RequestID"), TextBox).Text = ""
        CType(.FindControl("F_RequestedFor"), TextBox).Text = HttpContext.Current.Session("LoginID")
        CType(.FindControl("F_RequestedFor_Display"), Label).Text = HttpContext.Current.User.Identity.Name
        CType(.FindControl("F_RequestedForEmployees"), TextBox).Text = ""
        CType(.FindControl("F_TravelTypeID"), Object).SelectedValue = "1"
        CType(.FindControl("F_ProjectID"), TextBox).Text = ""
        CType(.FindControl("F_ProjectID_Display"), Label).Text = ""
        CType(.FindControl("F_ProjectManagerID"), TextBox).Text = ""
        CType(.FindControl("F_ProjectManagerID_Display"), Label).Text = ""
        CType(.FindControl("F_CostCenterID"), Object).SelectedValue = tmpEmp.C_DepartmentID
        CType(.FindControl("F_TravelItinerary"), TextBox).Text = ""
        CType(.FindControl("F_Purpose"), TextBox).Text = ""
        CType(.FindControl("F_TotalRequestedAmount"), TextBox).Text = "0.00"
        CType(.FindControl("F_TotalRequestedAmountINR"), TextBox).Text = "0.00"
        CType(.FindControl("F_Add1AmountDescription"), TextBox).Text = ""
        CType(.FindControl("F_Add1Amount"), TextBox).Text = "0.00"
        CType(.FindControl("F_Add2AmountDescription"), TextBox).Text = ""
        CType(.FindControl("F_Add2Amount"), TextBox).Text = "0.00"
        CType(.FindControl("F_Add3AmountDescription"), TextBox).Text = ""
        CType(.FindControl("F_Add3Amount"), TextBox).Text = "0.00"
        CType(.FindControl("F_Add4AmountDescription"), TextBox).Text = ""
        CType(.FindControl("F_Add4Amount"), TextBox).Text = "0.00"
        CType(.FindControl("F_Add5AmountDescription"), TextBox).Text = ""
        CType(.FindControl("F_Add5Amount"), TextBox).Text = "0.00"
        CType(.FindControl("F_TravelStartDate"), TextBox).Text = ""
        CType(.FindControl("F_TravelFinishDate"), TextBox).Text = ""
        CType(.FindControl("F_RequestedCurrencyID"), Object).SelectedValue = "INR"
        CType(.FindControl("F_RequestedConversionFactor"), TextBox).Text = "1.000000"
        CType(.FindControl("F_AdditionalCurrency"), TextBox).Text = "0.00"
      End With
      Return sender
    End Function
  End Class
End Namespace
