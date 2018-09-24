Partial Class RP_nprkRECUserClaims
  Inherits System.Web.UI.Page
  Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    Dim aVal() As String = Request.QueryString("pk").Split("|".ToCharArray)
    Dim ClaimID As Int32 = CType(aVal(0), Int32)
    Dim oVar As SIS.NPRK.nprkRECUserClaims = SIS.NPRK.nprkRECUserClaims.nprkRECUserClaimsGetByID(ClaimID)
    Dim oTblnprkRECUserClaims As New Table
    oTblnprkRECUserClaims.Width = 1000
    oTblnprkRECUserClaims.GridLines = GridLines.Both
    oTblnprkRECUserClaims.Style.Add("margin-top", "15px")
    oTblnprkRECUserClaims.Style.Add("margin-left", "10px")
    Dim oColnprkRECUserClaims As TableCell = Nothing
    Dim oRownprkRECUserClaims As TableRow = Nothing
    oRownprkRECUserClaims = New TableRow
    oColnprkRECUserClaims = New TableCell
    oColnprkRECUserClaims.Text = "Claim ID"
    oColnprkRECUserClaims.Font.Bold = True
    oRownprkRECUserClaims.Cells.Add(oColnprkRECUserClaims)
    oColnprkRECUserClaims = New TableCell
    oColnprkRECUserClaims.Text = oVar.ClaimID
    oColnprkRECUserClaims.Style.Add("text-align", "right")
    oColnprkRECUserClaims.ColumnSpan = "2"
    oRownprkRECUserClaims.Cells.Add(oColnprkRECUserClaims)
    oColnprkRECUserClaims = New TableCell
    oColnprkRECUserClaims.Text = "Claim Status"
    oColnprkRECUserClaims.Font.Bold = True
    oRownprkRECUserClaims.Cells.Add(oColnprkRECUserClaims)
    oColnprkRECUserClaims = New TableCell
    oColnprkRECUserClaims.Text = oVar.ClaimStatusID
    oColnprkRECUserClaims.Style.Add("text-align", "right")
    oRownprkRECUserClaims.Cells.Add(oColnprkRECUserClaims)
    oColnprkRECUserClaims = New TableCell
    oColnprkRECUserClaims.Text = oVar.PRK_ClaimStatus4_Description
    oColnprkRECUserClaims.Style.Add("text-align", "right")
    oRownprkRECUserClaims.Cells.Add(oColnprkRECUserClaims)
    oTblnprkRECUserClaims.Rows.Add(oRownprkRECUserClaims)
    oRownprkRECUserClaims = New TableRow
    oColnprkRECUserClaims = New TableCell
    oColnprkRECUserClaims.Text = "Card No"
    oColnprkRECUserClaims.Font.Bold = True
    oRownprkRECUserClaims.Cells.Add(oColnprkRECUserClaims)
    oColnprkRECUserClaims = New TableCell
    oColnprkRECUserClaims.Text = oVar.CardNo
    oColnprkRECUserClaims.Style.Add("text-align", "left")
    oRownprkRECUserClaims.Cells.Add(oColnprkRECUserClaims)
    oColnprkRECUserClaims = New TableCell
    oColnprkRECUserClaims.Text = oVar.aspnet_Users1_UserFullName
    oColnprkRECUserClaims.Style.Add("text-align", "left")
    oRownprkRECUserClaims.Cells.Add(oColnprkRECUserClaims)
    oColnprkRECUserClaims = New TableCell
    oColnprkRECUserClaims.Text = "Description"
    oColnprkRECUserClaims.Font.Bold = True
    oRownprkRECUserClaims.Cells.Add(oColnprkRECUserClaims)
    oColnprkRECUserClaims = New TableCell
    oColnprkRECUserClaims.Text = oVar.Description
    oColnprkRECUserClaims.Style.Add("text-align", "left")
    oColnprkRECUserClaims.ColumnSpan = "2"
    oRownprkRECUserClaims.Cells.Add(oColnprkRECUserClaims)
    oTblnprkRECUserClaims.Rows.Add(oRownprkRECUserClaims)
    oRownprkRECUserClaims = New TableRow
    oColnprkRECUserClaims = New TableCell
    oColnprkRECUserClaims.Text = "Claimed Amount"
    oColnprkRECUserClaims.Font.Bold = True
    oRownprkRECUserClaims.Cells.Add(oColnprkRECUserClaims)
    oColnprkRECUserClaims = New TableCell
    oColnprkRECUserClaims.Text = oVar.TotalAmount
    oColnprkRECUserClaims.Style.Add("text-align", "right")
    oColnprkRECUserClaims.ColumnSpan = "2"
    oRownprkRECUserClaims.Cells.Add(oColnprkRECUserClaims)
    oColnprkRECUserClaims = New TableCell
    oColnprkRECUserClaims.Text = "Submitted On"
    oColnprkRECUserClaims.Font.Bold = True
    oRownprkRECUserClaims.Cells.Add(oColnprkRECUserClaims)
    oColnprkRECUserClaims = New TableCell
    oColnprkRECUserClaims.Text = oVar.SubmittedOn
    oColnprkRECUserClaims.Style.Add("text-align", "center")
    oColnprkRECUserClaims.ColumnSpan = "2"
    oRownprkRECUserClaims.Cells.Add(oColnprkRECUserClaims)
    oTblnprkRECUserClaims.Rows.Add(oRownprkRECUserClaims)
    oRownprkRECUserClaims = New TableRow
    oColnprkRECUserClaims = New TableCell
    oColnprkRECUserClaims.Text = "Received On"
    oColnprkRECUserClaims.Font.Bold = True
    oRownprkRECUserClaims.Cells.Add(oColnprkRECUserClaims)
    oColnprkRECUserClaims = New TableCell
    oColnprkRECUserClaims.Text = oVar.ReceivedOn
    oColnprkRECUserClaims.Style.Add("text-align", "center")
    oColnprkRECUserClaims.ColumnSpan = "2"
    oRownprkRECUserClaims.Cells.Add(oColnprkRECUserClaims)
    oColnprkRECUserClaims = New TableCell
    oColnprkRECUserClaims.Text = "Received By"
    oColnprkRECUserClaims.Font.Bold = True
    oRownprkRECUserClaims.Cells.Add(oColnprkRECUserClaims)
    oColnprkRECUserClaims = New TableCell
    oColnprkRECUserClaims.Text = oVar.ReceivedBy
    oColnprkRECUserClaims.Style.Add("text-align", "left")
    oRownprkRECUserClaims.Cells.Add(oColnprkRECUserClaims)
    oColnprkRECUserClaims = New TableCell
    oColnprkRECUserClaims.Text = oVar.aspnet_Users2_UserFullName
    oColnprkRECUserClaims.Style.Add("text-align", "left")
    oRownprkRECUserClaims.Cells.Add(oColnprkRECUserClaims)
    oTblnprkRECUserClaims.Rows.Add(oRownprkRECUserClaims)
    oRownprkRECUserClaims = New TableRow
    oColnprkRECUserClaims = New TableCell
    oColnprkRECUserClaims.Text = "Passed Amount"
    oColnprkRECUserClaims.Font.Bold = True
    oRownprkRECUserClaims.Cells.Add(oColnprkRECUserClaims)
    oColnprkRECUserClaims = New TableCell
    oColnprkRECUserClaims.Text = oVar.PassedAmount
    oColnprkRECUserClaims.Style.Add("text-align", "right")
    oColnprkRECUserClaims.ColumnSpan = "2"
    oRownprkRECUserClaims.Cells.Add(oColnprkRECUserClaims)
    oColnprkRECUserClaims = New TableCell
    oColnprkRECUserClaims.Text = "Completed On"
    oColnprkRECUserClaims.Font.Bold = True
    oRownprkRECUserClaims.Cells.Add(oColnprkRECUserClaims)
    oColnprkRECUserClaims = New TableCell
    oColnprkRECUserClaims.Text = oVar.CompletedOn
    oColnprkRECUserClaims.Style.Add("text-align", "center")
    oColnprkRECUserClaims.ColumnSpan = "2"
    oRownprkRECUserClaims.Cells.Add(oColnprkRECUserClaims)
    oTblnprkRECUserClaims.Rows.Add(oRownprkRECUserClaims)
    oRownprkRECUserClaims = New TableRow
    oColnprkRECUserClaims = New TableCell
    oColnprkRECUserClaims.Text = "Accounts Remarks"
    oColnprkRECUserClaims.Font.Bold = True
    oRownprkRECUserClaims.Cells.Add(oColnprkRECUserClaims)
    oColnprkRECUserClaims = New TableCell
    oColnprkRECUserClaims.Text = oVar.AccountsRemarks
    oColnprkRECUserClaims.Style.Add("text-align", "left")
    oColnprkRECUserClaims.ColumnSpan = "2"
    oRownprkRECUserClaims.Cells.Add(oColnprkRECUserClaims)
    oColnprkRECUserClaims = New TableCell
    oColnprkRECUserClaims.Text = "Declaration Accepted"
    oColnprkRECUserClaims.Font.Bold = True
    oRownprkRECUserClaims.Cells.Add(oColnprkRECUserClaims)
    oColnprkRECUserClaims = New TableCell
    oColnprkRECUserClaims.Text = IIf(oVar.DeclarationAccepted, "YES", "NO")
    oColnprkRECUserClaims.Style.Add("text-align", "center")
    oColnprkRECUserClaims.ColumnSpan = "2"
    oRownprkRECUserClaims.Cells.Add(oColnprkRECUserClaims)
    oTblnprkRECUserClaims.Rows.Add(oRownprkRECUserClaims)
    form1.Controls.Add(oTblnprkRECUserClaims)
    Dim oTblnprkApplications As Table = Nothing
    Dim oRownprkApplications As TableRow = Nothing
    Dim oColnprkApplications As TableCell = Nothing
    Dim onprkApplicationss As List(Of SIS.NPRK.nprkApplications) = SIS.NPRK.nprkApplications.UZ_nprkApplicationsSelectList(0, 999, "", False, "", oVar.ClaimID)
    If onprkApplicationss.Count > 0 Then
      Dim oTblhnprkApplications As Table = New Table
      oTblhnprkApplications.Width = 1000
      oTblhnprkApplications.Style.Add("margin-top", "15px")
      oTblhnprkApplications.Style.Add("margin-left", "10px")
      oTblhnprkApplications.Style.Add("margin-right", "10px")
      Dim oRowhnprkApplications As TableRow = New TableRow
      Dim oColhnprkApplications As TableCell = New TableCell
      oColhnprkApplications.Font.Bold = True
      oColhnprkApplications.Font.Underline = True
      oColhnprkApplications.Font.Size = 10
      oColhnprkApplications.CssClass = "grpHD"
      oColhnprkApplications.Text = "Claim Perks"
      oRowhnprkApplications.Cells.Add(oColhnprkApplications)
      oTblhnprkApplications.Rows.Add(oRowhnprkApplications)
      form1.Controls.Add(oTblhnprkApplications)
      oTblnprkApplications = New Table
      oTblnprkApplications.Width = 1000
      oTblnprkApplications.GridLines = GridLines.Both
      oTblnprkApplications.Style.Add("margin-left", "10px")
      oTblnprkApplications.Style.Add("margin-right", "10px")
      oRownprkApplications = New TableRow
      oColnprkApplications = New TableCell
      oColnprkApplications.Text = "Perk ID"
      oColnprkApplications.Font.Bold = True
      oColnprkApplications.CssClass = "colHD"
      oColnprkApplications.Style.Add("text-align", "right")
      oRownprkApplications.Cells.Add(oColnprkApplications)
      oColnprkApplications = New TableCell
      oColnprkApplications.Text = "Applied On"
      oColnprkApplications.Font.Bold = True
      oColnprkApplications.CssClass = "colHD"
      oColnprkApplications.Style.Add("text-align", "center")
      oRownprkApplications.Cells.Add(oColnprkApplications)
      oColnprkApplications = New TableCell
      oColnprkApplications.Text = "Claimed Amount"
      oColnprkApplications.Font.Bold = True
      oColnprkApplications.CssClass = "colHD"
      oColnprkApplications.Style.Add("text-align", "right")
      oRownprkApplications.Cells.Add(oColnprkApplications)
      oColnprkApplications = New TableCell
      oColnprkApplications.Text = "Verified On"
      oColnprkApplications.Font.Bold = True
      oColnprkApplications.CssClass = "colHD"
      oColnprkApplications.Style.Add("text-align", "center")
      oRownprkApplications.Cells.Add(oColnprkApplications)
      oColnprkApplications = New TableCell
      oColnprkApplications.Text = "Approved On"
      oColnprkApplications.Font.Bold = True
      oColnprkApplications.CssClass = "colHD"
      oColnprkApplications.Style.Add("text-align", "center")
      oRownprkApplications.Cells.Add(oColnprkApplications)
      oColnprkApplications = New TableCell
      oColnprkApplications.Text = "Posted On"
      oColnprkApplications.Font.Bold = True
      oColnprkApplications.CssClass = "colHD"
      oColnprkApplications.Style.Add("text-align", "center")
      oRownprkApplications.Cells.Add(oColnprkApplications)
      oColnprkApplications = New TableCell
      oColnprkApplications.Text = "Approved Amt"
      oColnprkApplications.Font.Bold = True
      oColnprkApplications.CssClass = "colHD"
      oColnprkApplications.Style.Add("text-align", "right")
      oRownprkApplications.Cells.Add(oColnprkApplications)
      oColnprkApplications = New TableCell
      oColnprkApplications.Text = "Status ID"
      oColnprkApplications.Font.Bold = True
      oColnprkApplications.CssClass = "colHD"
      oColnprkApplications.Style.Add("text-align", "right")
      oRownprkApplications.Cells.Add(oColnprkApplications)
      oTblnprkApplications.Rows.Add(oRownprkApplications)
      For Each onprkApplications As SIS.NPRK.nprkApplications In onprkApplicationss
        oRownprkApplications = New TableRow
        oColnprkApplications = New TableCell
        oColnprkApplications.Text = onprkApplications.PRK_Perks7_Description
        oColnprkApplications.CssClass = "rowHD"
        oColnprkApplications.Style.Add("text-align", "right")
        oRownprkApplications.Cells.Add(oColnprkApplications)
        oColnprkApplications = New TableCell
        oColnprkApplications.CssClass = "rowHD"
        oColnprkApplications.Text = onprkApplications.AppliedOn
        oColnprkApplications.Style.Add("text-align", "center")
        oRownprkApplications.Cells.Add(oColnprkApplications)
        oColnprkApplications = New TableCell
        oColnprkApplications.CssClass = "rowHD"
        oColnprkApplications.Text = onprkApplications.Value
        oColnprkApplications.Style.Add("text-align", "right")
        oRownprkApplications.Cells.Add(oColnprkApplications)
        oColnprkApplications = New TableCell
        oColnprkApplications.CssClass = "rowHD"
        oColnprkApplications.Text = onprkApplications.VerifiedOn
        oColnprkApplications.Style.Add("text-align", "center")
        oRownprkApplications.Cells.Add(oColnprkApplications)
        oColnprkApplications = New TableCell
        oColnprkApplications.CssClass = "rowHD"
        oColnprkApplications.Text = onprkApplications.ApprovedOn
        oColnprkApplications.Style.Add("text-align", "center")
        oRownprkApplications.Cells.Add(oColnprkApplications)
        oColnprkApplications = New TableCell
        oColnprkApplications.CssClass = "rowHD"
        oColnprkApplications.Text = onprkApplications.PostedOn
        oColnprkApplications.Style.Add("text-align", "center")
        oRownprkApplications.Cells.Add(oColnprkApplications)
        oColnprkApplications = New TableCell
        oColnprkApplications.CssClass = "rowHD"
        oColnprkApplications.Text = onprkApplications.ApprovedAmt
        oColnprkApplications.Style.Add("text-align", "right")
        oRownprkApplications.Cells.Add(oColnprkApplications)
        oColnprkApplications = New TableCell
        oColnprkApplications.Text = onprkApplications.PRK_Status8_Description
        oColnprkApplications.CssClass = "rowHD"
        oColnprkApplications.Style.Add("text-align", "right")
        oRownprkApplications.Cells.Add(oColnprkApplications)
        oTblnprkApplications.Rows.Add(oRownprkApplications)
        oRownprkApplications = New TableRow
        oColnprkApplications = New TableCell
        oColnprkApplications.ColumnSpan = oTblnprkApplications.Rows(0).Cells.Count
        oRownprkApplications.Cells.Add(oColnprkApplications)
        Dim oTblnprkBillDetails As Table = Nothing
        Dim oRownprkBillDetails As TableRow = Nothing
        Dim oColnprkBillDetails As TableCell = Nothing
        Dim onprkBillDetailss As List(Of SIS.NPRK.nprkBillDetails) = SIS.NPRK.nprkBillDetails.UZ_nprkBillDetailsSelectList(0, 999, "", False, "", onprkApplications.ClaimID, onprkApplications.ApplicationID)
        If onprkBillDetailss.Count > 0 Then
          Dim oTblhnprkBillDetails As Table = New Table
          oTblhnprkBillDetails.Width = 980
          oTblhnprkBillDetails.Style.Add("margin-top", "15px")
          oTblhnprkBillDetails.Style.Add("margin-left", "10px")
          oTblhnprkBillDetails.Style.Add("margin-right", "10px")
          Dim oRowhnprkBillDetails As TableRow = New TableRow
          Dim oColhnprkBillDetails As TableCell = New TableCell
          oColhnprkBillDetails.Font.Bold = True
          oColhnprkBillDetails.Font.Underline = True
          oColhnprkBillDetails.Font.Size = 10
          oColhnprkBillDetails.CssClass = "grpHD"
          oColhnprkBillDetails.Text = "Bill Details"
          oRowhnprkBillDetails.Cells.Add(oColhnprkBillDetails)
          oTblhnprkBillDetails.Rows.Add(oRowhnprkBillDetails)
          oColnprkApplications.Controls.Add(oTblhnprkBillDetails)
          oTblnprkBillDetails = New Table
          oTblnprkBillDetails.Width = 980
          oTblnprkBillDetails.GridLines = GridLines.Both
          oTblnprkBillDetails.Style.Add("margin-left", "10px")
          oTblnprkBillDetails.Style.Add("margin-right", "10px")
          oRownprkBillDetails = New TableRow
          oColnprkBillDetails = New TableCell
          oColnprkBillDetails.Text = "Application ID"
          oColnprkBillDetails.Font.Bold = True
          oColnprkBillDetails.CssClass = "colHD"
          oColnprkBillDetails.Style.Add("text-align", "right")
          oRownprkBillDetails.Cells.Add(oColnprkBillDetails)
          oColnprkBillDetails = New TableCell
          oColnprkBillDetails.Text = "BILL NO"
          oColnprkBillDetails.Font.Bold = True
          oColnprkBillDetails.CssClass = "colHD"
          oColnprkBillDetails.Style.Add("text-align", "left")
          oRownprkBillDetails.Cells.Add(oColnprkBillDetails)
          oColnprkBillDetails = New TableCell
          oColnprkBillDetails.Text = "BILL DATE"
          oColnprkBillDetails.Font.Bold = True
          oColnprkBillDetails.CssClass = "colHD"
          oColnprkBillDetails.Style.Add("text-align", "center")
          oRownprkBillDetails.Cells.Add(oColnprkBillDetails)
          oColnprkBillDetails = New TableCell
          oColnprkBillDetails.Text = "PARTICULARS"
          oColnprkBillDetails.Font.Bold = True
          oColnprkBillDetails.CssClass = "colHD"
          oColnprkBillDetails.Style.Add("text-align", "left")
          oRownprkBillDetails.Cells.Add(oColnprkBillDetails)
          oColnprkBillDetails = New TableCell
          oColnprkBillDetails.Text = "BILL AMT."
          oColnprkBillDetails.Font.Bold = True
          oColnprkBillDetails.CssClass = "colHD"
          oColnprkBillDetails.Style.Add("text-align", "right")
          oRownprkBillDetails.Cells.Add(oColnprkBillDetails)
          oColnprkBillDetails = New TableCell
          oColnprkBillDetails.Text = "CLAIMED AMT."
          oColnprkBillDetails.Font.Bold = True
          oColnprkBillDetails.CssClass = "colHD"
          oColnprkBillDetails.Style.Add("text-align", "right")
          oRownprkBillDetails.Cells.Add(oColnprkBillDetails)
          oColnprkBillDetails = New TableCell
          oColnprkBillDetails.Text = "Claim ID"
          oColnprkBillDetails.Font.Bold = True
          oColnprkBillDetails.CssClass = "colHD"
          oColnprkBillDetails.Style.Add("text-align", "right")
          oRownprkBillDetails.Cells.Add(oColnprkBillDetails)
          oTblnprkBillDetails.Rows.Add(oRownprkBillDetails)
          For Each onprkBillDetails As SIS.NPRK.nprkBillDetails In onprkBillDetailss
            oRownprkBillDetails = New TableRow
            oColnprkBillDetails = New TableCell
            oColnprkBillDetails.Text = onprkBillDetails.PRK_Applications2_UserRemark
            oColnprkBillDetails.CssClass = "rowHD"
            oColnprkBillDetails.Style.Add("text-align", "right")
            oRownprkBillDetails.Cells.Add(oColnprkBillDetails)
            oColnprkBillDetails = New TableCell
            oColnprkBillDetails.CssClass = "rowHD"
            oColnprkBillDetails.Text = onprkBillDetails.BillNo
            oColnprkBillDetails.Style.Add("text-align", "left")
            oRownprkBillDetails.Cells.Add(oColnprkBillDetails)
            oColnprkBillDetails = New TableCell
            oColnprkBillDetails.CssClass = "rowHD"
            oColnprkBillDetails.Text = onprkBillDetails.BillDate
            oColnprkBillDetails.Style.Add("text-align", "center")
            oRownprkBillDetails.Cells.Add(oColnprkBillDetails)
            oColnprkBillDetails = New TableCell
            oColnprkBillDetails.CssClass = "rowHD"
            oColnprkBillDetails.Text = onprkBillDetails.Particulars
            oColnprkBillDetails.Style.Add("text-align", "left")
            oRownprkBillDetails.Cells.Add(oColnprkBillDetails)
            oColnprkBillDetails = New TableCell
            oColnprkBillDetails.CssClass = "rowHD"
            oColnprkBillDetails.Text = onprkBillDetails.Quantity
            oColnprkBillDetails.Style.Add("text-align", "right")
            oRownprkBillDetails.Cells.Add(oColnprkBillDetails)
            oColnprkBillDetails = New TableCell
            oColnprkBillDetails.CssClass = "rowHD"
            oColnprkBillDetails.Text = onprkBillDetails.Amount
            oColnprkBillDetails.Style.Add("text-align", "right")
            oRownprkBillDetails.Cells.Add(oColnprkBillDetails)
            oColnprkBillDetails = New TableCell
            oColnprkBillDetails.Text = onprkBillDetails.PRK_UserClaims1_Description
            oColnprkBillDetails.CssClass = "rowHD"
            oColnprkBillDetails.Style.Add("text-align", "right")
            oRownprkBillDetails.Cells.Add(oColnprkBillDetails)
            oTblnprkBillDetails.Rows.Add(oRownprkBillDetails)
          Next
          oColnprkApplications.Controls.Add(oTblnprkBillDetails)
          oTblnprkApplications.Rows.Add(oRownprkApplications)
        End If
      Next
      form1.Controls.Add(oTblnprkApplications)
    End If
  End Sub
End Class
