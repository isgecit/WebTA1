Imports System.Web.Script.Serialization
Partial Class RP_nprkUserClaims
  Inherits System.Web.UI.Page

  'Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
  '  Dim aVal() As String = Request.QueryString("pk").Split("|".ToCharArray)
  '  Dim ClaimID As Int32 = CType(aVal(0), Int32)
  '  Dim oVar As SIS.NPRK.nprkUserClaims = SIS.NPRK.nprkUserClaims.nprkUserClaimsGetByID(ClaimID)
  '  If oVar.ClaimStatusID = prkClaimStates.Free Then
  '    Dim msg = "Perk Claim can be printed after Forwarding to ACCOUNTs."
  '    Dim message As String = New JavaScriptSerializer().Serialize(msg)
  '    Dim script As String = String.Format("alert({0});", message)
  '    ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", script, True)
  '    Exit Sub
  '  End If
  '  Dim oTblnprkUserClaims As New Table
  '  oTblnprkUserClaims.Width = 800
  '  oTblnprkUserClaims.GridLines = GridLines.Both
  '  oTblnprkUserClaims.Style.Add("margin-top", "15px")
  '  oTblnprkUserClaims.Style.Add("margin-left", "10px")
  '  oTblnprkUserClaims.BackColor = Drawing.Color.LightCyan
  '  Dim oColnprkUserClaims As TableCell = Nothing
  '  Dim oRownprkUserClaims As TableRow = Nothing
  '  oRownprkUserClaims = New TableRow
  '  oColnprkUserClaims = New TableCell
  '  oColnprkUserClaims.Text = "Claim Ref.No"
  '  oColnprkUserClaims.Font.Bold = True
  '  oRownprkUserClaims.Cells.Add(oColnprkUserClaims)
  '  oColnprkUserClaims = New TableCell
  '  oColnprkUserClaims.Text = oVar.ClaimRefNo
  '  oColnprkUserClaims.Style.Add("text-align", "center")
  '  oColnprkUserClaims.Font.Bold = True
  '  oColnprkUserClaims.ForeColor = Drawing.Color.Red

  '  oColnprkUserClaims.ColumnSpan = "2"
  '  oRownprkUserClaims.Cells.Add(oColnprkUserClaims)
  '  oColnprkUserClaims = New TableCell
  '  oColnprkUserClaims.Text = "Claim Status"
  '  oColnprkUserClaims.Font.Bold = True
  '  oRownprkUserClaims.Cells.Add(oColnprkUserClaims)
  '  oColnprkUserClaims = New TableCell
  '  oColnprkUserClaims.Text = oVar.ClaimStatusID
  '  oColnprkUserClaims.Style.Add("text-align", "center")
  '  oRownprkUserClaims.Cells.Add(oColnprkUserClaims)
  '  oColnprkUserClaims = New TableCell
  '  oColnprkUserClaims.Text = oVar.PRK_ClaimStatus4_Description
  '  oColnprkUserClaims.Style.Add("text-align", "left")
  '  oRownprkUserClaims.Cells.Add(oColnprkUserClaims)
  '  oTblnprkUserClaims.Rows.Add(oRownprkUserClaims)
  '  oRownprkUserClaims = New TableRow
  '  oColnprkUserClaims = New TableCell
  '  oColnprkUserClaims.Text = "Card No"
  '  oColnprkUserClaims.Font.Bold = True
  '  oRownprkUserClaims.Cells.Add(oColnprkUserClaims)
  '  oColnprkUserClaims = New TableCell
  '  oColnprkUserClaims.Text = oVar.CardNo
  '  oColnprkUserClaims.Style.Add("text-align", "left")
  '  oRownprkUserClaims.Cells.Add(oColnprkUserClaims)
  '  oColnprkUserClaims = New TableCell
  '  oColnprkUserClaims.Text = oVar.aspnet_Users1_UserFullName
  '  oColnprkUserClaims.Style.Add("text-align", "left")
  '  oRownprkUserClaims.Cells.Add(oColnprkUserClaims)
  '  oColnprkUserClaims = New TableCell
  '  oColnprkUserClaims.Text = "Declaration Accepted"
  '  oColnprkUserClaims.Font.Bold = True
  '  oRownprkUserClaims.Cells.Add(oColnprkUserClaims)
  '  oColnprkUserClaims = New TableCell
  '  oColnprkUserClaims.Text = "YES"
  '  oColnprkUserClaims.Style.Add("text-align", "center")
  '  oColnprkUserClaims.ColumnSpan = "2"
  '  oRownprkUserClaims.Cells.Add(oColnprkUserClaims)
  '  oTblnprkUserClaims.Rows.Add(oRownprkUserClaims)
  '  oRownprkUserClaims = New TableRow
  '  oColnprkUserClaims = New TableCell
  '  oColnprkUserClaims.Text = "Claimed Amount"
  '  oColnprkUserClaims.Font.Bold = True
  '  oRownprkUserClaims.Cells.Add(oColnprkUserClaims)
  '  oColnprkUserClaims = New TableCell
  '  oColnprkUserClaims.Text = oVar.TotalAmount
  '  oColnprkUserClaims.Style.Add("text-align", "right")
  '  oColnprkUserClaims.ColumnSpan = "2"
  '  oRownprkUserClaims.Cells.Add(oColnprkUserClaims)
  '  oColnprkUserClaims = New TableCell
  '  oColnprkUserClaims.Text = "Submitted On"
  '  oColnprkUserClaims.Font.Bold = True
  '  oRownprkUserClaims.Cells.Add(oColnprkUserClaims)
  '  oColnprkUserClaims = New TableCell
  '  oColnprkUserClaims.Text = oVar.SubmittedOn
  '  oColnprkUserClaims.Style.Add("text-align", "center")
  '  oColnprkUserClaims.ColumnSpan = "2"
  '  oRownprkUserClaims.Cells.Add(oColnprkUserClaims)
  '  oTblnprkUserClaims.Rows.Add(oRownprkUserClaims)
  '  form1.Controls.Add(oTblnprkUserClaims)
  '  Dim oTblnprkApplications As Table = Nothing
  '  Dim oRownprkApplications As TableRow = Nothing
  '  Dim oColnprkApplications As TableCell = Nothing
  '  Dim onprkApplicationss As List(Of SIS.NPRK.nprkApplications) = SIS.NPRK.nprkApplications.UZ_nprkApplicationsSelectList(0, 999, "", False, "", oVar.ClaimID)
  '  If onprkApplicationss.Count > 0 Then
  '    Dim oTblhnprkApplications As Table = New Table
  '    oTblhnprkApplications.Width = 801
  '    oTblhnprkApplications.Style.Add("margin-top", "15px")
  '    oTblhnprkApplications.Style.Add("margin-left", "10px")
  '    oTblhnprkApplications.Style.Add("margin-right", "10px")
  '    Dim oRowhnprkApplications As TableRow = New TableRow
  '    Dim oColhnprkApplications As TableCell = New TableCell
  '    oColhnprkApplications.Font.Bold = True
  '    oColhnprkApplications.Font.Underline = True
  '    oColhnprkApplications.Font.Size = 10
  '    oColhnprkApplications.CssClass = "grpHD"
  '    oColhnprkApplications.Text = "Claimed Perk Types"
  '    oRowhnprkApplications.Cells.Add(oColhnprkApplications)
  '    oTblhnprkApplications.Rows.Add(oRowhnprkApplications)
  '    form1.Controls.Add(oTblhnprkApplications)
  '    oTblnprkApplications = New Table
  '    oTblnprkApplications.Width = 800
  '    oTblnprkApplications.GridLines = GridLines.Both
  '    oTblnprkApplications.Style.Add("margin-left", "10px")
  '    oTblnprkApplications.Style.Add("margin-right", "10px")
  '    oRownprkApplications = New TableRow
  '    oColnprkApplications = New TableCell
  '    oColnprkApplications.Text = "Perk Type"
  '    oColnprkApplications.Font.Bold = True
  '    oColnprkApplications.CssClass = "colHD"
  '    oColnprkApplications.Style.Add("text-align", "left")
  '    oColnprkApplications.Style.Add("padding-left", "40px")
  '    oRownprkApplications.Cells.Add(oColnprkApplications)
  '    oColnprkApplications = New TableCell
  '    oColnprkApplications.Text = "Claimed Amount"
  '    oColnprkApplications.Font.Bold = True
  '    oColnprkApplications.CssClass = "colHD"
  '    oColnprkApplications.Style.Add("text-align", "right")
  '    oColnprkApplications.Style.Add("padding-right", "40px")
  '    oRownprkApplications.Cells.Add(oColnprkApplications)
  '    oTblnprkApplications.Rows.Add(oRownprkApplications)
  '    For Each onprkApplications As SIS.NPRK.nprkApplications In onprkApplicationss
  '      oRownprkApplications = New TableRow
  '      oColnprkApplications = New TableCell
  '      oColnprkApplications.Text = onprkApplications.PRK_Perks7_Description
  '      oColnprkApplications.CssClass = "rowHD"
  '      oColnprkApplications.Style.Add("text-align", "left")
  '      oColnprkApplications.Style.Add("padding-left", "40px")
  '      oRownprkApplications.Cells.Add(oColnprkApplications)
  '      oColnprkApplications = New TableCell
  '      oColnprkApplications.CssClass = "rowHD"
  '      oColnprkApplications.Text = onprkApplications.Value
  '      oColnprkApplications.Style.Add("text-align", "right")
  '      oColnprkApplications.Style.Add("padding-right", "40px")
  '      oRownprkApplications.Cells.Add(oColnprkApplications)
  '      oTblnprkApplications.Rows.Add(oRownprkApplications)
  '    Next
  '    form1.Controls.Add(oTblnprkApplications)
  '  End If


  'End Sub


  Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    Dim aVal() As String = Request.QueryString("pk").Split("|".ToCharArray)
    Dim ClaimID As Int32 = CType(aVal(0), Int32)
    Dim oVar As SIS.NPRK.nprkUserClaims = SIS.NPRK.nprkUserClaims.nprkUserClaimsGetByID(ClaimID)
    If oVar.ClaimStatusID = prkClaimStates.Free Then
      Dim msg = "Perk Claim can be printed after Forwarding to ACCOUNTs."
      Dim message As String = New JavaScriptSerializer().Serialize(msg)
      Dim script As String = String.Format("alert({0});", message)
      ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", script, True)
      Exit Sub
    End If

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
      'oRownprkApplications = New TableRow
      'oColnprkApplications = New TableCell
      'oColnprkApplications.Text = "Perk Type"
      'oColnprkApplications.Font.Bold = True
      'oColnprkApplications.CssClass = "colHD"
      'oColnprkApplications.Style.Add("text-align", "right")
      'oRownprkApplications.Cells.Add(oColnprkApplications)
      ''oColnprkApplications = New TableCell
      ''oColnprkApplications.Text = "Applied On"
      ''oColnprkApplications.Font.Bold = True
      ''oColnprkApplications.CssClass = "colHD"
      ''oColnprkApplications.Style.Add("text-align", "center")
      ''oRownprkApplications.Cells.Add(oColnprkApplications)
      'oColnprkApplications = New TableCell
      'oColnprkApplications.Text = "Claimed Amount"
      'oColnprkApplications.Font.Bold = True
      'oColnprkApplications.CssClass = "colHD"
      'oColnprkApplications.Style.Add("text-align", "right")
      'oRownprkApplications.Cells.Add(oColnprkApplications)
      ''oColnprkApplications = New TableCell
      ''oColnprkApplications.Text = "Approved On"
      ''oColnprkApplications.Font.Bold = True
      ''oColnprkApplications.CssClass = "colHD"
      ''oColnprkApplications.Style.Add("text-align", "center")
      ''oRownprkApplications.Cells.Add(oColnprkApplications)
      'oColnprkApplications = New TableCell
      'oColnprkApplications.Text = "Approved Amt"
      'oColnprkApplications.Font.Bold = True
      'oColnprkApplications.CssClass = "colHD"
      'oColnprkApplications.Style.Add("text-align", "right")
      'oRownprkApplications.Cells.Add(oColnprkApplications)
      ''oColnprkApplications = New TableCell
      ''oColnprkApplications.Text = "Status ID"
      ''oColnprkApplications.Font.Bold = True
      ''oColnprkApplications.CssClass = "colHD"
      ''oColnprkApplications.Style.Add("text-align", "right")
      ''oRownprkApplications.Cells.Add(oColnprkApplications)
      'oTblnprkApplications.Rows.Add(oRownprkApplications)
      For Each onprkApplications As SIS.NPRK.nprkApplications In onprkApplicationss
        'oRownprkApplications = New TableRow
        'oColnprkApplications = New TableCell
        'oColnprkApplications.Text = onprkApplications.PRK_Perks7_Description
        'oColnprkApplications.CssClass = "rowHD"
        'oColnprkApplications.Style.Add("text-align", "right")
        'oRownprkApplications.Cells.Add(oColnprkApplications)
        'oColnprkApplications = New TableCell
        'oColnprkApplications.CssClass = "rowHD"
        'oColnprkApplications.Text = onprkApplications.Value
        'oColnprkApplications.Style.Add("text-align", "right")
        'oRownprkApplications.Cells.Add(oColnprkApplications)
        'oColnprkApplications = New TableCell
        'oColnprkApplications.CssClass = "rowHD"
        'oColnprkApplications.Text = onprkApplications.ApprovedAmt
        'oColnprkApplications.Style.Add("text-align", "right")
        'oRownprkApplications.Cells.Add(oColnprkApplications)
        'oTblnprkApplications.Rows.Add(oRownprkApplications)
        oRownprkApplications = New TableRow
        oColnprkApplications = New TableCell
        oColnprkApplications.ColumnSpan = 3  'oTblnprkApplications.Rows(0).Cells.Count
        oRownprkApplications.Cells.Add(oColnprkApplications)
        Dim oTblnprkBillDetails As Table = Nothing
        Dim oRownprkBillDetails As TableRow = Nothing
        Dim oColnprkBillDetails As TableCell = Nothing
        Dim onprkBillDetailss As List(Of SIS.NPRK.nprkBillDetails) = SIS.NPRK.nprkBillDetails.UZ_nprkBillDetailsSelectList(0, 999, "", False, "", onprkApplications.ClaimID, onprkApplications.ApplicationID)
        If onprkBillDetailss.Count > 0 Then
          Dim oTblhnprkBillDetails As Table = New Table
          oTblhnprkBillDetails.Width = 760
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
          Dim TotalClaimedAmount As Decimal = 0
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
            TotalClaimedAmount += onprkBillDetails.Amount
          Next
          oRownprkBillDetails = New TableRow
          oColnprkBillDetails = New TableCell
          oColnprkBillDetails.CssClass = "crowHD"
          oColnprkBillDetails.Text = "TOTAL"
          oColnprkBillDetails.Style.Add("text-align", "center")
          oColnprkBillDetails.ColumnSpan = 4
          oRownprkBillDetails.Cells.Add(oColnprkBillDetails)
          oColnprkBillDetails = New TableCell
          oColnprkBillDetails.CssClass = "crowHD"
          oColnprkBillDetails.Text = TotalClaimedAmount.ToString("n")
          oColnprkBillDetails.Style.Add("text-align", "right")
          oRownprkBillDetails.Cells.Add(oColnprkBillDetails)
          oTblnprkBillDetails.Rows.Add(oRownprkBillDetails)

          oRownprkBillDetails = New TableRow
          oColnprkBillDetails = New TableCell
          oColnprkBillDetails.CssClass = "crowHD"
          oColnprkBillDetails.Text = "Claimed Amount"
          oColnprkBillDetails.Style.Add("text-align", "center")
          oColnprkBillDetails.ColumnSpan = 4
          oRownprkBillDetails.Cells.Add(oColnprkBillDetails)
          oColnprkBillDetails = New TableCell
          oColnprkBillDetails.CssClass = "crowHD"
          oColnprkBillDetails.Text = onprkApplications.Value.ToString("n")
          oColnprkBillDetails.Style.Add("text-align", "right")
          oRownprkBillDetails.Cells.Add(oColnprkBillDetails)
          oTblnprkBillDetails.Rows.Add(oRownprkBillDetails)

          'oRownprkBillDetails = New TableRow
          'oColnprkBillDetails = New TableCell
          'oColnprkBillDetails.CssClass = "crowHD"
          'oColnprkBillDetails.Text = "Approved Amount"
          'oColnprkBillDetails.Style.Add("text-align", "center")
          'oColnprkBillDetails.ColumnSpan = 4
          'oRownprkBillDetails.Cells.Add(oColnprkBillDetails)
          'oColnprkBillDetails = New TableCell
          'oColnprkBillDetails.CssClass = "crowHD"
          'oColnprkBillDetails.Text = onprkApplications.ApprovedAmt.ToString("n")
          'oColnprkBillDetails.Style.Add("text-align", "right")
          'oRownprkBillDetails.Cells.Add(oColnprkBillDetails)
          'oTblnprkBillDetails.Rows.Add(oRownprkBillDetails)

          oColnprkApplications.Controls.Add(oTblnprkBillDetails)
          oTblnprkApplications.Rows.Add(oRownprkApplications)

          'oRownprkApplications = New TableRow
          'oColnprkApplications = New TableCell
          'oColnprkApplications.Text = onprkApplications.PRK_Perks7_Description
          'oColnprkApplications.CssClass = "rowHD"
          'oColnprkApplications.Style.Add("text-align", "right")
          'oRownprkApplications.Cells.Add(oColnprkApplications)
          'oColnprkApplications = New TableCell
          'oColnprkApplications.CssClass = "rowHD"
          'oColnprkApplications.Text = onprkApplications.Value
          'oColnprkApplications.Style.Add("text-align", "right")
          'oRownprkApplications.Cells.Add(oColnprkApplications)
          'oColnprkApplications = New TableCell
          'oColnprkApplications.CssClass = "rowHD"
          'oColnprkApplications.Text = onprkApplications.ApprovedAmt
          'oColnprkApplications.Style.Add("text-align", "right")
          'oRownprkApplications.Cells.Add(oColnprkApplications)
          'oTblnprkApplications.Rows.Add(oRownprkApplications)

        End If
      Next
      form1.Controls.Add(oTblnprkApplications)
    End If
  End Sub
End Class
