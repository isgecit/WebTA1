Partial Class RP_nprkVrfrApplications
  Inherits System.Web.UI.Page

  Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    Dim aVal() As String = Request.QueryString("pk").Split("|".ToCharArray)
    Dim ClaimID As Int32 = CType(aVal(0), Int32)
    Dim oVar As SIS.NPRK.nprkUserClaims = SIS.NPRK.nprkUserClaims.nprkUserClaimsGetByID(ClaimID)
    Dim oTblnprkUserClaims As New Table
    oTblnprkUserClaims.Width = 800
    oTblnprkUserClaims.GridLines = GridLines.Both
    oTblnprkUserClaims.Style.Add("margin-top", "15px")
    oTblnprkUserClaims.Style.Add("margin-left", "10px")
    Dim oColnprkUserClaims As TableCell = Nothing
    Dim oRownprkUserClaims As TableRow = Nothing
    oRownprkUserClaims = New TableRow
    oColnprkUserClaims = New TableCell
    oColnprkUserClaims.Text = "Claim Ref.No"
    oColnprkUserClaims.Font.Bold = True
    oRownprkUserClaims.Cells.Add(oColnprkUserClaims)
    oColnprkUserClaims = New TableCell
    oColnprkUserClaims.Text = oVar.ClaimRefNo
    oColnprkUserClaims.Style.Add("text-align", "center")
    oColnprkUserClaims.ColumnSpan = "2"
    oRownprkUserClaims.Cells.Add(oColnprkUserClaims)
    oColnprkUserClaims = New TableCell
    oColnprkUserClaims.Text = "Claim Status"
    oColnprkUserClaims.Font.Bold = True
    oRownprkUserClaims.Cells.Add(oColnprkUserClaims)
    oColnprkUserClaims = New TableCell
    oColnprkUserClaims.Text = oVar.ClaimStatusID
    oColnprkUserClaims.Style.Add("text-align", "center")
    oRownprkUserClaims.Cells.Add(oColnprkUserClaims)
    oColnprkUserClaims = New TableCell
    oColnprkUserClaims.Text = oVar.PRK_ClaimStatus4_Description
    oColnprkUserClaims.Style.Add("text-align", "left")
    oRownprkUserClaims.Cells.Add(oColnprkUserClaims)
    oTblnprkUserClaims.Rows.Add(oRownprkUserClaims)
    oRownprkUserClaims = New TableRow
    oColnprkUserClaims = New TableCell
    oColnprkUserClaims.Text = "Card No"
    oColnprkUserClaims.Font.Bold = True
    oRownprkUserClaims.Cells.Add(oColnprkUserClaims)
    oColnprkUserClaims = New TableCell
    oColnprkUserClaims.Text = oVar.CardNo
    oColnprkUserClaims.Style.Add("text-align", "left")
    oRownprkUserClaims.Cells.Add(oColnprkUserClaims)
    oColnprkUserClaims = New TableCell
    oColnprkUserClaims.Text = oVar.aspnet_Users1_UserFullName
    oColnprkUserClaims.Style.Add("text-align", "left")
    oRownprkUserClaims.Cells.Add(oColnprkUserClaims)
    oColnprkUserClaims = New TableCell
    oColnprkUserClaims.Text = "Description"
    oColnprkUserClaims.Font.Bold = True
    oRownprkUserClaims.Cells.Add(oColnprkUserClaims)
    oColnprkUserClaims = New TableCell
    oColnprkUserClaims.Text = ""  ' oVar.Description
    oColnprkUserClaims.Style.Add("text-align", "left")
    oColnprkUserClaims.ColumnSpan = "2"
    oRownprkUserClaims.Cells.Add(oColnprkUserClaims)
    oTblnprkUserClaims.Rows.Add(oRownprkUserClaims)
    oRownprkUserClaims = New TableRow
    oColnprkUserClaims = New TableCell
    oColnprkUserClaims.Text = "Claimed Amount"
    oColnprkUserClaims.Font.Bold = True
    oRownprkUserClaims.Cells.Add(oColnprkUserClaims)
    oColnprkUserClaims = New TableCell
    oColnprkUserClaims.Text = oVar.TotalAmount
    oColnprkUserClaims.Style.Add("text-align", "right")
    oColnprkUserClaims.ColumnSpan = "2"
    oRownprkUserClaims.Cells.Add(oColnprkUserClaims)
    oColnprkUserClaims = New TableCell
    oColnprkUserClaims.Text = "Submitted On"
    oColnprkUserClaims.Font.Bold = True
    oRownprkUserClaims.Cells.Add(oColnprkUserClaims)
    oColnprkUserClaims = New TableCell
    oColnprkUserClaims.Text = oVar.SubmittedOn
    oColnprkUserClaims.Style.Add("text-align", "center")
    oColnprkUserClaims.ColumnSpan = "2"
    oRownprkUserClaims.Cells.Add(oColnprkUserClaims)
    oTblnprkUserClaims.Rows.Add(oRownprkUserClaims)
    oRownprkUserClaims = New TableRow
    oColnprkUserClaims = New TableCell
    oColnprkUserClaims.Text = "Received On"
    oColnprkUserClaims.Font.Bold = True
    oRownprkUserClaims.Cells.Add(oColnprkUserClaims)
    oColnprkUserClaims = New TableCell
    oColnprkUserClaims.Text = oVar.ReceivedOn
    oColnprkUserClaims.Style.Add("text-align", "center")
    oColnprkUserClaims.ColumnSpan = "2"
    oRownprkUserClaims.Cells.Add(oColnprkUserClaims)
    oColnprkUserClaims = New TableCell
    oColnprkUserClaims.Text = "Received By"
    oColnprkUserClaims.Font.Bold = True
    oRownprkUserClaims.Cells.Add(oColnprkUserClaims)
    oColnprkUserClaims = New TableCell
    oColnprkUserClaims.Text = oVar.ReceivedBy
    oColnprkUserClaims.Style.Add("text-align", "left")
    oRownprkUserClaims.Cells.Add(oColnprkUserClaims)
    oColnprkUserClaims = New TableCell
    oColnprkUserClaims.Text = oVar.aspnet_Users2_UserFullName
    oColnprkUserClaims.Style.Add("text-align", "left")
    oRownprkUserClaims.Cells.Add(oColnprkUserClaims)
    oTblnprkUserClaims.Rows.Add(oRownprkUserClaims)
    oRownprkUserClaims = New TableRow
    oColnprkUserClaims = New TableCell
    oColnprkUserClaims.Text = "Passed Amount"
    oColnprkUserClaims.Font.Bold = True
    oRownprkUserClaims.Cells.Add(oColnprkUserClaims)
    oColnprkUserClaims = New TableCell
    oColnprkUserClaims.Text = oVar.PassedAmount
    oColnprkUserClaims.Style.Add("text-align", "right")
    oColnprkUserClaims.ColumnSpan = "2"
    oRownprkUserClaims.Cells.Add(oColnprkUserClaims)
    oColnprkUserClaims = New TableCell
    oColnprkUserClaims.Text = "Completed On"
    oColnprkUserClaims.Font.Bold = True
    oRownprkUserClaims.Cells.Add(oColnprkUserClaims)
    oColnprkUserClaims = New TableCell
    oColnprkUserClaims.Text = oVar.CompletedOn
    oColnprkUserClaims.Style.Add("text-align", "center")
    oColnprkUserClaims.ColumnSpan = "2"
    oRownprkUserClaims.Cells.Add(oColnprkUserClaims)
    oTblnprkUserClaims.Rows.Add(oRownprkUserClaims)
    oRownprkUserClaims = New TableRow
    oColnprkUserClaims = New TableCell
    oColnprkUserClaims.Text = "Accounts Remarks"
    oColnprkUserClaims.Font.Bold = True
    oRownprkUserClaims.Cells.Add(oColnprkUserClaims)
    oColnprkUserClaims = New TableCell
    oColnprkUserClaims.Text = oVar.AccountsRemarks
    oColnprkUserClaims.Style.Add("text-align", "left")
    oColnprkUserClaims.ColumnSpan = "2"
    oRownprkUserClaims.Cells.Add(oColnprkUserClaims)
    oColnprkUserClaims = New TableCell
    oColnprkUserClaims.Text = "Declaration Accepted"
    oColnprkUserClaims.Font.Bold = True
    oRownprkUserClaims.Cells.Add(oColnprkUserClaims)
    oColnprkUserClaims = New TableCell
    oColnprkUserClaims.Text = "YES"  'IIf(oVar.DeclarationAccepted, "YES", "NO")
    oColnprkUserClaims.Style.Add("text-align", "center")
    oColnprkUserClaims.ColumnSpan = "2"
    oRownprkUserClaims.Cells.Add(oColnprkUserClaims)
    oTblnprkUserClaims.Rows.Add(oRownprkUserClaims)
    form1.Controls.Add(oTblnprkUserClaims)
    Dim oTblnprkApplications As Table = Nothing
    Dim oRownprkApplications As TableRow = Nothing
    Dim oColnprkApplications As TableCell = Nothing
    Dim onprkApplicationss As List(Of SIS.NPRK.nprkApplications) = SIS.NPRK.nprkApplications.UZ_nprkApplicationsSelectList(0, 999, "", False, "", oVar.ClaimID)
    If onprkApplicationss.Count > 0 Then
      Dim oTblhnprkApplications As Table = New Table
      oTblhnprkApplications.Width = 801
      oTblhnprkApplications.Style.Add("margin-top", "15px")
      oTblhnprkApplications.Style.Add("margin-left", "10px")
      oTblhnprkApplications.Style.Add("margin-right", "10px")
      Dim oRowhnprkApplications As TableRow = New TableRow
      Dim oColhnprkApplications As TableCell = New TableCell
      oColhnprkApplications.Font.Bold = True
      oColhnprkApplications.Font.Underline = True
      oColhnprkApplications.Font.Size = 10
      oColhnprkApplications.CssClass = "grpHD"
      oColhnprkApplications.Text = "Claimed Perk Types"
      oRowhnprkApplications.Cells.Add(oColhnprkApplications)
      oTblhnprkApplications.Rows.Add(oRowhnprkApplications)
      form1.Controls.Add(oTblhnprkApplications)
      oTblnprkApplications = New Table
      oTblnprkApplications.Width = 800
      oTblnprkApplications.GridLines = GridLines.Both
      oTblnprkApplications.Style.Add("margin-left", "10px")
      oTblnprkApplications.Style.Add("margin-right", "10px")
      oRownprkApplications = New TableRow
      oColnprkApplications = New TableCell
      oColnprkApplications.Text = "Perk Type"
      oColnprkApplications.Font.Bold = True
      oColnprkApplications.CssClass = "colHD"
      oColnprkApplications.Style.Add("text-align", "right")
      oRownprkApplications.Cells.Add(oColnprkApplications)
      'oColnprkApplications = New TableCell
      'oColnprkApplications.Text = "Applied On"
      'oColnprkApplications.Font.Bold = True
      'oColnprkApplications.CssClass = "colHD"
      'oColnprkApplications.Style.Add("text-align", "center")
      'oRownprkApplications.Cells.Add(oColnprkApplications)
      oColnprkApplications = New TableCell
      oColnprkApplications.Text = "Claimed Amount"
      oColnprkApplications.Font.Bold = True
      oColnprkApplications.CssClass = "colHD"
      oColnprkApplications.Style.Add("text-align", "right")
      oRownprkApplications.Cells.Add(oColnprkApplications)
      'oColnprkApplications = New TableCell
      'oColnprkApplications.Text = "Approved On"
      'oColnprkApplications.Font.Bold = True
      'oColnprkApplications.CssClass = "colHD"
      'oColnprkApplications.Style.Add("text-align", "center")
      'oRownprkApplications.Cells.Add(oColnprkApplications)
      oColnprkApplications = New TableCell
      oColnprkApplications.Text = "Approved Amt"
      oColnprkApplications.Font.Bold = True
      oColnprkApplications.CssClass = "colHD"
      oColnprkApplications.Style.Add("text-align", "right")
      oRownprkApplications.Cells.Add(oColnprkApplications)
      'oColnprkApplications = New TableCell
      'oColnprkApplications.Text = "Status ID"
      'oColnprkApplications.Font.Bold = True
      'oColnprkApplications.CssClass = "colHD"
      'oColnprkApplications.Style.Add("text-align", "right")
      'oRownprkApplications.Cells.Add(oColnprkApplications)
      oTblnprkApplications.Rows.Add(oRownprkApplications)
      For Each onprkApplications As SIS.NPRK.nprkApplications In onprkApplicationss
        oRownprkApplications = New TableRow
        oColnprkApplications = New TableCell
        oColnprkApplications.Text = onprkApplications.PRK_Perks7_Description
        oColnprkApplications.CssClass = "rowHD"
        oColnprkApplications.Style.Add("text-align", "right")
        oRownprkApplications.Cells.Add(oColnprkApplications)
        'oColnprkApplications = New TableCell
        'oColnprkApplications.CssClass = "rowHD"
        'oColnprkApplications.Text = onprkApplications.AppliedOn
        'oColnprkApplications.Style.Add("text-align", "center")
        'oRownprkApplications.Cells.Add(oColnprkApplications)
        oColnprkApplications = New TableCell
        oColnprkApplications.CssClass = "rowHD"
        oColnprkApplications.Text = onprkApplications.Value
        oColnprkApplications.Style.Add("text-align", "right")
        oRownprkApplications.Cells.Add(oColnprkApplications)
        'oColnprkApplications = New TableCell
        'oColnprkApplications.CssClass = "rowHD"
        'oColnprkApplications.Text = onprkApplications.ApprovedOn
        'oColnprkApplications.Style.Add("text-align", "center")
        'oRownprkApplications.Cells.Add(oColnprkApplications)
        oColnprkApplications = New TableCell
        oColnprkApplications.CssClass = "rowHD"
        oColnprkApplications.Text = onprkApplications.ApprovedAmt
        oColnprkApplications.Style.Add("text-align", "right")
        oRownprkApplications.Cells.Add(oColnprkApplications)
        'oColnprkApplications = New TableCell
        'oColnprkApplications.Text = onprkApplications.PRK_Status8_Description
        'oColnprkApplications.CssClass = "rowHD"
        'oColnprkApplications.Style.Add("text-align", "right")
        'oRownprkApplications.Cells.Add(oColnprkApplications)
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
          oTblhnprkBillDetails.Width = 761
          oTblhnprkBillDetails.Style.Add("margin-top", "15px")
          oTblhnprkBillDetails.Style.Add("margin-left", "10px")
          oTblhnprkBillDetails.Style.Add("margin-right", "10px")
          Dim oRowhnprkBillDetails As TableRow = New TableRow
          Dim oColhnprkBillDetails As TableCell = New TableCell
          oColhnprkBillDetails.Font.Bold = True
          oColhnprkBillDetails.Font.Underline = True
          oColhnprkBillDetails.Font.Size = 10
          oColhnprkBillDetails.CssClass = "grpHD"
          oColhnprkBillDetails.Text = onprkApplications.PRK_Perks7_Description & " Details"
          oRowhnprkBillDetails.Cells.Add(oColhnprkBillDetails)
          oTblhnprkBillDetails.Rows.Add(oRowhnprkBillDetails)
          oColnprkApplications.Controls.Add(oTblhnprkBillDetails)
          oTblnprkBillDetails = New Table
          oTblnprkBillDetails.Width = 760
          oTblnprkBillDetails.GridLines = GridLines.Both
          oTblnprkBillDetails.Style.Add("margin-left", "10px")
          oTblnprkBillDetails.Style.Add("margin-right", "10px")
          oTblnprkBillDetails.Style.Add("margin-bottom", "10px")
          oRownprkBillDetails = New TableRow
          oColnprkBillDetails = New TableCell
          oColnprkBillDetails.Text = "ID"
          oColnprkBillDetails.Font.Bold = True
          oColnprkBillDetails.CssClass = "colHD"
          oColnprkBillDetails.Style.Add("text-align", "center")
          oRownprkBillDetails.Cells.Add(oColnprkBillDetails)
          oColnprkBillDetails = New TableCell
          oColnprkBillDetails.Text = "Description"
          oColnprkBillDetails.Font.Bold = True
          oColnprkBillDetails.CssClass = "colHD"
          oColnprkBillDetails.Style.Add("text-align", "left")
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
          oTblnprkBillDetails.Rows.Add(oRownprkBillDetails)
          For Each onprkBillDetails As SIS.NPRK.nprkBillDetails In onprkBillDetailss
            oRownprkBillDetails = New TableRow
            oColnprkBillDetails = New TableCell
            oColnprkBillDetails.CssClass = "crowHD"
            oColnprkBillDetails.Text = onprkBillDetails.SerialNo
            oColnprkBillDetails.Style.Add("text-align", "center")
            oRownprkBillDetails.Cells.Add(oColnprkBillDetails)
            oColnprkBillDetails = New TableCell
            oColnprkBillDetails.CssClass = "crowHD"
            oColnprkBillDetails.Text = onprkBillDetails.Description
            oColnprkBillDetails.Style.Add("text-align", "left")
            oRownprkBillDetails.Cells.Add(oColnprkBillDetails)
            oColnprkBillDetails = New TableCell
            oColnprkBillDetails.CssClass = "crowHD"
            oColnprkBillDetails.Text = onprkBillDetails.Particulars
            oColnprkBillDetails.Style.Add("text-align", "left")
            oRownprkBillDetails.Cells.Add(oColnprkBillDetails)
            oColnprkBillDetails = New TableCell
            oColnprkBillDetails.CssClass = "crowHD"
            oColnprkBillDetails.Text = onprkBillDetails.Quantity
            oColnprkBillDetails.Style.Add("text-align", "right")
            oRownprkBillDetails.Cells.Add(oColnprkBillDetails)
            oColnprkBillDetails = New TableCell
            oColnprkBillDetails.CssClass = "crowHD"
            oColnprkBillDetails.Text = onprkBillDetails.Amount
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


  'Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
  '  Dim aVal() As String = Request.QueryString("pk").Split("|".ToCharArray)
  '  Dim ClaimID As Int32 = CType(aVal(0), Int32)
  '  Dim ApplicationID As Int32 = CType(aVal(1), Int32)
  '  Dim oVar As SIS.NPRK.nprkVrfrApplications = SIS.NPRK.nprkVrfrApplications.nprkVrfrApplicationsGetByID(ClaimID,ApplicationID)
  '  Dim oTblnprkVrfrApplications As New Table
  '  oTblnprkVrfrApplications.Width = 800
  '  oTblnprkVrfrApplications.GridLines = GridLines.Both
  '  oTblnprkVrfrApplications.Style.Add("margin-top", "15px")
  '  oTblnprkVrfrApplications.Style.Add("margin-left", "10px")
  '  Dim oColnprkVrfrApplications As TableCell = Nothing
  '  Dim oRownprkVrfrApplications As TableRow = Nothing
  '  oRownprkVrfrApplications = New TableRow
  '  oColnprkVrfrApplications = New TableCell
  '  oColnprkVrfrApplications.Text = "Claim Number"
  '  oColnprkVrfrApplications.Font.Bold = True
  '  oRownprkVrfrApplications.Cells.Add(oColnprkVrfrApplications)
  '  oColnprkVrfrApplications = New TableCell
  '  oColnprkVrfrApplications.Text = oVar.ClaimID
  '    oColnprkVrfrApplications.Style.Add("text-align","right")
  '  oRownprkVrfrApplications.Cells.Add(oColnprkVrfrApplications)
  '  oColnprkVrfrApplications = New TableCell
  '  oColnprkVrfrApplications.Text = oVar.PRK_UserClaims9_Description
  '    oColnprkVrfrApplications.Style.Add("text-align","right")
  '  oRownprkVrfrApplications.Cells.Add(oColnprkVrfrApplications)
  '  oColnprkVrfrApplications = New TableCell
  '  oColnprkVrfrApplications.Text = "Application ID"
  '  oColnprkVrfrApplications.Font.Bold = True
  '  oRownprkVrfrApplications.Cells.Add(oColnprkVrfrApplications)
  '  oColnprkVrfrApplications = New TableCell
  '  oColnprkVrfrApplications.Text = oVar.ApplicationID
  '    oColnprkVrfrApplications.Style.Add("text-align","right")
  '  oColnprkVrfrApplications.ColumnSpan = "2"
  '  oRownprkVrfrApplications.Cells.Add(oColnprkVrfrApplications)
  '  oTblnprkVrfrApplications.Rows.Add(oRownprkVrfrApplications)
  '  oRownprkVrfrApplications = New TableRow
  '  oColnprkVrfrApplications = New TableCell
  '  oColnprkVrfrApplications.Text = "Employee"
  '  oColnprkVrfrApplications.Font.Bold = True
  '  oRownprkVrfrApplications.Cells.Add(oColnprkVrfrApplications)
  '  oColnprkVrfrApplications = New TableCell
  '  oColnprkVrfrApplications.Text = oVar.EmployeeID
  '    oColnprkVrfrApplications.Style.Add("text-align","right")
  '  oRownprkVrfrApplications.Cells.Add(oColnprkVrfrApplications)
  '  oColnprkVrfrApplications = New TableCell
  '  oColnprkVrfrApplications.Text = oVar.PRK_Employees1_EmployeeName
  '    oColnprkVrfrApplications.Style.Add("text-align","right")
  '  oRownprkVrfrApplications.Cells.Add(oColnprkVrfrApplications)
  '  oColnprkVrfrApplications = New TableCell
  '  oColnprkVrfrApplications.Text = "Perk"
  '  oColnprkVrfrApplications.Font.Bold = True
  '  oRownprkVrfrApplications.Cells.Add(oColnprkVrfrApplications)
  '  oColnprkVrfrApplications = New TableCell
  '  oColnprkVrfrApplications.Text = oVar.PerkID
  '    oColnprkVrfrApplications.Style.Add("text-align","right")
  '  oRownprkVrfrApplications.Cells.Add(oColnprkVrfrApplications)
  '  oColnprkVrfrApplications = New TableCell
  '  oColnprkVrfrApplications.Text = oVar.PRK_Perks7_Description
  '    oColnprkVrfrApplications.Style.Add("text-align","right")
  '  oRownprkVrfrApplications.Cells.Add(oColnprkVrfrApplications)
  '  oTblnprkVrfrApplications.Rows.Add(oRownprkVrfrApplications)
  '  oRownprkVrfrApplications = New TableRow
  '  oColnprkVrfrApplications = New TableCell
  '  oColnprkVrfrApplications.Text = "Applied On"
  '  oColnprkVrfrApplications.Font.Bold = True
  '  oRownprkVrfrApplications.Cells.Add(oColnprkVrfrApplications)
  '  oColnprkVrfrApplications = New TableCell
  '  oColnprkVrfrApplications.Text = oVar.AppliedOn
  '    oColnprkVrfrApplications.Style.Add("text-align","center")
  '  oColnprkVrfrApplications.ColumnSpan = "2"
  '  oRownprkVrfrApplications.Cells.Add(oColnprkVrfrApplications)
  '  oColnprkVrfrApplications = New TableCell
  '  oColnprkVrfrApplications.Text = "Claimed Amount"
  '  oColnprkVrfrApplications.Font.Bold = True
  '  oRownprkVrfrApplications.Cells.Add(oColnprkVrfrApplications)
  '  oColnprkVrfrApplications = New TableCell
  '  oColnprkVrfrApplications.Text = oVar.Value
  '    oColnprkVrfrApplications.Style.Add("text-align","right")
  '  oColnprkVrfrApplications.ColumnSpan = "2"
  '  oRownprkVrfrApplications.Cells.Add(oColnprkVrfrApplications)
  '  oTblnprkVrfrApplications.Rows.Add(oRownprkVrfrApplications)
  '  oRownprkVrfrApplications = New TableRow
  '  oColnprkVrfrApplications = New TableCell
  '  oColnprkVrfrApplications.Text = "User Remark"
  '  oColnprkVrfrApplications.Font.Bold = True
  '  oRownprkVrfrApplications.Cells.Add(oColnprkVrfrApplications)
  '  oColnprkVrfrApplications = New TableCell
  '  oColnprkVrfrApplications.Text = oVar.UserRemark
  '    oColnprkVrfrApplications.Style.Add("text-align","left")
  '  oColnprkVrfrApplications.ColumnSpan = "5"
  '  oRownprkVrfrApplications.Cells.Add(oColnprkVrfrApplications)
  '  oTblnprkVrfrApplications.Rows.Add(oRownprkVrfrApplications)
  '  form1.Controls.Add(oTblnprkVrfrApplications)
  '    Dim oTblnprkBillDetails As Table = Nothing
  '    Dim oRownprkBillDetails As TableRow = Nothing
  '    Dim oColnprkBillDetails As TableCell = Nothing
  '  Dim onprkBillDetailss As List(Of SIS.NPRK.nprkBillDetails) = SIS.NPRK.nprkBillDetails.UZ_nprkBillDetailsSelectList(0, 999, "", False, "", oVar.ClaimID, oVar.ApplicationID)
  '  If onprkBillDetailss.Count > 0 Then
  '    Dim oTblhnprkBillDetails As Table = New Table
  '    oTblhnprkBillDetails.Width = 800
  '    oTblhnprkBillDetails.Style.Add("margin-top", "15px")
  '    oTblhnprkBillDetails.Style.Add("margin-left", "10px")
  '    oTblhnprkBillDetails.Style.Add("margin-right", "10px")
  '    Dim oRowhnprkBillDetails As TableRow = New TableRow
  '    Dim oColhnprkBillDetails As TableCell = New TableCell
  '    oColhnprkBillDetails.Font.Bold = True
  '    oColhnprkBillDetails.Font.UnderLine = True
  '    oColhnprkBillDetails.Font.Size = 10
  '    oColhnprkBillDetails.CssClass = "grpHD"
  '    oColhnprkBillDetails.Text = "Bill Details"
  '    oRowhnprkBillDetails.Cells.Add(oColhnprkBillDetails)
  '    oTblhnprkBillDetails.Rows.Add(oRowhnprkBillDetails)
  '    form1.Controls.Add(oTblhnprkBillDetails)
  '    oTblnprkBillDetails = New Table
  '    oTblnprkBillDetails.Width = 800
  '    oTblnprkBillDetails.GridLines = GridLines.Both
  '    oTblnprkBillDetails.Style.Add("margin-left", "10px")
  '    oTblnprkBillDetails.Style.Add("margin-right", "10px")
  '    oRownprkBillDetails = New TableRow
  '    oColnprkBillDetails = New TableCell
  '    oColnprkBillDetails.Text = "ID"
  '    oColnprkBillDetails.Font.Bold = True
  '    oColnprkBillDetails.CssClass = "colHD"
  '    oColnprkBillDetails.Style.Add("text-align","center")
  '    oRownprkBillDetails.Cells.Add(oColnprkBillDetails)
  '    oColnprkBillDetails = New TableCell
  '    oColnprkBillDetails.Text = "Description"
  '    oColnprkBillDetails.Font.Bold = True
  '    oColnprkBillDetails.CssClass = "colHD"
  '    oColnprkBillDetails.Style.Add("text-align","left")
  '    oRownprkBillDetails.Cells.Add(oColnprkBillDetails)
  '    oColnprkBillDetails = New TableCell
  '    oColnprkBillDetails.Text = "PARTICULARS"
  '    oColnprkBillDetails.Font.Bold = True
  '    oColnprkBillDetails.CssClass = "colHD"
  '    oColnprkBillDetails.Style.Add("text-align","left")
  '    oRownprkBillDetails.Cells.Add(oColnprkBillDetails)
  '    oColnprkBillDetails = New TableCell
  '    oColnprkBillDetails.Text = "BILL AMT."
  '    oColnprkBillDetails.Font.Bold = True
  '    oColnprkBillDetails.CssClass = "colHD"
  '    oColnprkBillDetails.Style.Add("text-align","right")
  '    oRownprkBillDetails.Cells.Add(oColnprkBillDetails)
  '    oColnprkBillDetails = New TableCell
  '    oColnprkBillDetails.Text = "CLAIMED AMT."
  '    oColnprkBillDetails.Font.Bold = True
  '    oColnprkBillDetails.CssClass = "colHD"
  '    oColnprkBillDetails.Style.Add("text-align","right")
  '    oRownprkBillDetails.Cells.Add(oColnprkBillDetails)
  '    oTblnprkBillDetails.Rows.Add(oRownprkBillDetails)
  '    For Each onprkBillDetails As SIS.NPRK.nprkBillDetails In onprkBillDetailss
  '      oRownprkBillDetails = New TableRow
  '      oColnprkBillDetails = New TableCell
  '      oColnprkBillDetails.CssClass = "rowHD"
  '      oColnprkBillDetails.Text = onprkBillDetails.SerialNo
  '    oColnprkBillDetails.Style.Add("text-align","center")
  '      oRownprkBillDetails.Cells.Add(oColnprkBillDetails)
  '      oColnprkBillDetails = New TableCell
  '      oColnprkBillDetails.CssClass = "rowHD"
  '      oColnprkBillDetails.Text = onprkBillDetails.Description
  '    oColnprkBillDetails.Style.Add("text-align","left")
  '      oRownprkBillDetails.Cells.Add(oColnprkBillDetails)
  '      oColnprkBillDetails = New TableCell
  '      oColnprkBillDetails.CssClass = "rowHD"
  '      oColnprkBillDetails.Text = onprkBillDetails.Particulars
  '    oColnprkBillDetails.Style.Add("text-align","left")
  '      oRownprkBillDetails.Cells.Add(oColnprkBillDetails)
  '      oColnprkBillDetails = New TableCell
  '      oColnprkBillDetails.CssClass = "rowHD"
  '      oColnprkBillDetails.Text = onprkBillDetails.Quantity
  '    oColnprkBillDetails.Style.Add("text-align","right")
  '      oRownprkBillDetails.Cells.Add(oColnprkBillDetails)
  '      oColnprkBillDetails = New TableCell
  '      oColnprkBillDetails.CssClass = "rowHD"
  '      oColnprkBillDetails.Text = onprkBillDetails.Amount
  '    oColnprkBillDetails.Style.Add("text-align","right")
  '      oRownprkBillDetails.Cells.Add(oColnprkBillDetails)
  '      oTblnprkBillDetails.Rows.Add(oRownprkBillDetails)
  '    Next
  '    form1.Controls.Add(oTblnprkBillDetails)
  '  End If
  'End Sub
End Class
