Partial Class RP_pakSiteIssReqH
  Inherits System.Web.UI.Page
  Private _InfoUrl As String = "~/PAK_Main/App_Display/DF_pakSiteIssReqH.aspx"
  Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _InfoUrl  & "?ProjectID=" & aVal(0) & "&IssueNo=" & aVal(1)
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    Dim aVal() As String = Request.QueryString("pk").Split("|".ToCharArray)
    Dim ProjectID As String = CType(aVal(0),String)
    Dim IssueNo As Int32 = CType(aVal(1),Int32)
    Dim oVar As SIS.PAK.pakSiteIssReqH = SIS.PAK.pakSiteIssReqH.pakSiteIssReqHGetByID(ProjectID,IssueNo)
    Dim oTblpakSiteIssReqH As New Table
    oTblpakSiteIssReqH.Width = 1000
    oTblpakSiteIssReqH.GridLines = GridLines.Both
    oTblpakSiteIssReqH.Style.Add("margin-top", "15px")
    oTblpakSiteIssReqH.Style.Add("margin-left", "10px")
    Dim oColpakSiteIssReqH As TableCell = Nothing
    Dim oRowpakSiteIssReqH As TableRow = Nothing
    oRowpakSiteIssReqH = New TableRow
    oColpakSiteIssReqH = New TableCell
    oColpakSiteIssReqH.Text = "Project"
    oColpakSiteIssReqH.Font.Bold = True
    oRowpakSiteIssReqH.Cells.Add(oColpakSiteIssReqH)
    oColpakSiteIssReqH = New TableCell
    oColpakSiteIssReqH.Text = oVar.ProjectID
      oColpakSiteIssReqH.Style.Add("text-align","left")
    oRowpakSiteIssReqH.Cells.Add(oColpakSiteIssReqH)
    oColpakSiteIssReqH = New TableCell
    oColpakSiteIssReqH.Text = oVar.IDM_Projects3_Description
      oColpakSiteIssReqH.Style.Add("text-align","left")
    oRowpakSiteIssReqH.Cells.Add(oColpakSiteIssReqH)
    oColpakSiteIssReqH = New TableCell
    oColpakSiteIssReqH.Text = "Request No"
    oColpakSiteIssReqH.Font.Bold = True
    oRowpakSiteIssReqH.Cells.Add(oColpakSiteIssReqH)
    oColpakSiteIssReqH = New TableCell
    oColpakSiteIssReqH.Text = oVar.IssueNo
      oColpakSiteIssReqH.Style.Add("text-align","right")
    oColpakSiteIssReqH.ColumnSpan = "2"
    oRowpakSiteIssReqH.Cells.Add(oColpakSiteIssReqH)
    oTblpakSiteIssReqH.Rows.Add(oRowpakSiteIssReqH)
    oRowpakSiteIssReqH = New TableRow
    oColpakSiteIssReqH = New TableCell
    oColpakSiteIssReqH.Text = "Requester Remarks"
    oColpakSiteIssReqH.Font.Bold = True
    oRowpakSiteIssReqH.Cells.Add(oColpakSiteIssReqH)
    oColpakSiteIssReqH = New TableCell
    oColpakSiteIssReqH.Text = oVar.RequesterRemarks
      oColpakSiteIssReqH.Style.Add("text-align","left")
    oColpakSiteIssReqH.ColumnSpan = "5"
    oRowpakSiteIssReqH.Cells.Add(oColpakSiteIssReqH)
    oTblpakSiteIssReqH.Rows.Add(oRowpakSiteIssReqH)
    oRowpakSiteIssReqH = New TableRow
    oColpakSiteIssReqH = New TableCell
    oColpakSiteIssReqH.Text = "Requested By"
    oColpakSiteIssReqH.Font.Bold = True
    oRowpakSiteIssReqH.Cells.Add(oColpakSiteIssReqH)
    oColpakSiteIssReqH = New TableCell
    oColpakSiteIssReqH.Text = oVar.RequestedBy
      oColpakSiteIssReqH.Style.Add("text-align","left")
    oRowpakSiteIssReqH.Cells.Add(oColpakSiteIssReqH)
    oColpakSiteIssReqH = New TableCell
    oColpakSiteIssReqH.Text = oVar.aspnet_users6_UserFullName
      oColpakSiteIssReqH.Style.Add("text-align","left")
    oRowpakSiteIssReqH.Cells.Add(oColpakSiteIssReqH)
    oColpakSiteIssReqH = New TableCell
    oColpakSiteIssReqH.Text = "Requested On"
    oColpakSiteIssReqH.Font.Bold = True
    oRowpakSiteIssReqH.Cells.Add(oColpakSiteIssReqH)
    oColpakSiteIssReqH = New TableCell
    oColpakSiteIssReqH.Text = oVar.RequestedOn
      oColpakSiteIssReqH.Style.Add("text-align","center")
    oColpakSiteIssReqH.ColumnSpan = "2"
    oRowpakSiteIssReqH.Cells.Add(oColpakSiteIssReqH)
    oTblpakSiteIssReqH.Rows.Add(oRowpakSiteIssReqH)
    oRowpakSiteIssReqH = New TableRow
    oColpakSiteIssReqH = New TableCell
    oColpakSiteIssReqH.Text = "Issued By"
    oColpakSiteIssReqH.Font.Bold = True
    oRowpakSiteIssReqH.Cells.Add(oColpakSiteIssReqH)
    oColpakSiteIssReqH = New TableCell
    oColpakSiteIssReqH.Text = oVar.IssuedBy
      oColpakSiteIssReqH.Style.Add("text-align","left")
    oRowpakSiteIssReqH.Cells.Add(oColpakSiteIssReqH)
    oColpakSiteIssReqH = New TableCell
    oColpakSiteIssReqH.Text = oVar.aspnet_users2_UserFullName
      oColpakSiteIssReqH.Style.Add("text-align","left")
    oRowpakSiteIssReqH.Cells.Add(oColpakSiteIssReqH)
    oColpakSiteIssReqH = New TableCell
    oColpakSiteIssReqH.Text = "Issued On"
    oColpakSiteIssReqH.Font.Bold = True
    oRowpakSiteIssReqH.Cells.Add(oColpakSiteIssReqH)
    oColpakSiteIssReqH = New TableCell
    oColpakSiteIssReqH.Text = oVar.IssuedOn
      oColpakSiteIssReqH.Style.Add("text-align","center")
    oColpakSiteIssReqH.ColumnSpan = "2"
    oRowpakSiteIssReqH.Cells.Add(oColpakSiteIssReqH)
    oTblpakSiteIssReqH.Rows.Add(oRowpakSiteIssReqH)
    oRowpakSiteIssReqH = New TableRow
    oColpakSiteIssReqH = New TableCell
    oColpakSiteIssReqH.Text = "Issue Remarks"
    oColpakSiteIssReqH.Font.Bold = True
    oRowpakSiteIssReqH.Cells.Add(oColpakSiteIssReqH)
    oColpakSiteIssReqH = New TableCell
    oColpakSiteIssReqH.Text = oVar.IssueRemarks
      oColpakSiteIssReqH.Style.Add("text-align","left")
    oColpakSiteIssReqH.ColumnSpan = "5"
    oRowpakSiteIssReqH.Cells.Add(oColpakSiteIssReqH)
    oTblpakSiteIssReqH.Rows.Add(oRowpakSiteIssReqH)
    oRowpakSiteIssReqH = New TableRow
    oColpakSiteIssReqH = New TableCell
    oColpakSiteIssReqH.Text = "Issue To"
    oColpakSiteIssReqH.Font.Bold = True
    oRowpakSiteIssReqH.Cells.Add(oColpakSiteIssReqH)
    oColpakSiteIssReqH = New TableCell
    oColpakSiteIssReqH.Text = oVar.IssueToCardNo
      oColpakSiteIssReqH.Style.Add("text-align","left")
    oRowpakSiteIssReqH.Cells.Add(oColpakSiteIssReqH)
    oColpakSiteIssReqH = New TableCell
    oColpakSiteIssReqH.Text = oVar.aspnet_users1_UserFullName
      oColpakSiteIssReqH.Style.Add("text-align","left")
    oRowpakSiteIssReqH.Cells.Add(oColpakSiteIssReqH)
    oColpakSiteIssReqH = New TableCell
    oColpakSiteIssReqH.Text = "Requester Name"
    oColpakSiteIssReqH.Font.Bold = True
    oRowpakSiteIssReqH.Cells.Add(oColpakSiteIssReqH)
    oColpakSiteIssReqH = New TableCell
    oColpakSiteIssReqH.Text = oVar.IssueToName
      oColpakSiteIssReqH.Style.Add("text-align","left")
    oColpakSiteIssReqH.ColumnSpan = "2"
    oRowpakSiteIssReqH.Cells.Add(oColpakSiteIssReqH)
    oTblpakSiteIssReqH.Rows.Add(oRowpakSiteIssReqH)
    oRowpakSiteIssReqH = New TableRow
    oColpakSiteIssReqH = New TableCell
    oColpakSiteIssReqH.Text = "Issue Type"
    oColpakSiteIssReqH.Font.Bold = True
    oRowpakSiteIssReqH.Cells.Add(oColpakSiteIssReqH)
    oColpakSiteIssReqH = New TableCell
    oColpakSiteIssReqH.Text = oVar.IssueTypeID
      oColpakSiteIssReqH.Style.Add("text-align","right")
    oRowpakSiteIssReqH.Cells.Add(oColpakSiteIssReqH)
    oColpakSiteIssReqH = New TableCell
    oColpakSiteIssReqH.Text = oVar.PAK_IssueTypes5_Description
      oColpakSiteIssReqH.Style.Add("text-align","right")
    oRowpakSiteIssReqH.Cells.Add(oColpakSiteIssReqH)
    oColpakSiteIssReqH = New TableCell
    oColpakSiteIssReqH.Text = "Status"
    oColpakSiteIssReqH.Font.Bold = True
    oRowpakSiteIssReqH.Cells.Add(oColpakSiteIssReqH)
    oColpakSiteIssReqH = New TableCell
    oColpakSiteIssReqH.Text = oVar.IssueStatusID
      oColpakSiteIssReqH.Style.Add("text-align","right")
    oRowpakSiteIssReqH.Cells.Add(oColpakSiteIssReqH)
    oColpakSiteIssReqH = New TableCell
    oColpakSiteIssReqH.Text = oVar.PAK_IssueStatus4_Description
      oColpakSiteIssReqH.Style.Add("text-align","right")
    oRowpakSiteIssReqH.Cells.Add(oColpakSiteIssReqH)
    oTblpakSiteIssReqH.Rows.Add(oRowpakSiteIssReqH)
    form1.Controls.Add(oTblpakSiteIssReqH)
      Dim oTblpakSiteIssRecD As Table = Nothing
      Dim oRowpakSiteIssRecD As TableRow = Nothing
      Dim oColpakSiteIssRecD As TableCell = Nothing
    Dim opakSiteIssRecDs As List(Of SIS.PAK.pakSiteIssRecD) = SIS.PAK.pakSiteIssRecD.pakSiteIssRecDSelectList(0, 999, "", False, "", oVar.IssueNo, oVar.ProjectID)
    If opakSiteIssRecDs.Count > 0 Then
      Dim oTblhpakSiteIssRecD As Table = New Table
      oTblhpakSiteIssRecD.Width = 1000
      oTblhpakSiteIssRecD.Style.Add("margin-top", "15px")
      oTblhpakSiteIssRecD.Style.Add("margin-left", "10px")
      oTblhpakSiteIssRecD.Style.Add("margin-right", "10px")
      Dim oRowhpakSiteIssRecD As TableRow = New TableRow
      Dim oColhpakSiteIssRecD As TableCell = New TableCell
      oColhpakSiteIssRecD.Font.Bold = True
      oColhpakSiteIssRecD.Font.UnderLine = True
      oColhpakSiteIssRecD.Font.Size = 10
      oColhpakSiteIssRecD.CssClass = "grpHD"
      oColhpakSiteIssRecD.Text = "Site Issue Request Item"
      oRowhpakSiteIssRecD.Cells.Add(oColhpakSiteIssRecD)
      oTblhpakSiteIssRecD.Rows.Add(oRowhpakSiteIssRecD)
      form1.Controls.Add(oTblhpakSiteIssRecD)
      oTblpakSiteIssRecD = New Table
      oTblpakSiteIssRecD.Width = 1000
      oTblpakSiteIssRecD.GridLines = GridLines.Both
      oTblpakSiteIssRecD.Style.Add("margin-left", "10px")
      oTblpakSiteIssRecD.Style.Add("margin-right", "10px")
      oRowpakSiteIssRecD = New TableRow
      oColpakSiteIssRecD = New TableCell
      oColpakSiteIssRecD.Text = "Request Line No"
      oColpakSiteIssRecD.Font.Bold = True
      oColpakSiteIssRecD.CssClass = "colHD"
      oColpakSiteIssRecD.Style.Add("text-align","right")
      oRowpakSiteIssRecD.Cells.Add(oColpakSiteIssRecD)
      oColpakSiteIssRecD = New TableCell
      oColpakSiteIssRecD.Text = "Site Mark No"
      oColpakSiteIssRecD.Font.Bold = True
      oColpakSiteIssRecD.CssClass = "colHD"
      oColpakSiteIssRecD.Style.Add("text-align","left")
      oRowpakSiteIssRecD.Cells.Add(oColpakSiteIssRecD)
      oColpakSiteIssRecD = New TableCell
      oColpakSiteIssRecD.Text = "UOM Quantity"
      oColpakSiteIssRecD.Font.Bold = True
      oColpakSiteIssRecD.CssClass = "colHD"
      oColpakSiteIssRecD.Style.Add("text-align","right")
      oRowpakSiteIssRecD.Cells.Add(oColpakSiteIssRecD)
      oColpakSiteIssRecD = New TableCell
      oColpakSiteIssRecD.Text = "Quantity Required"
      oColpakSiteIssRecD.Font.Bold = True
      oColpakSiteIssRecD.CssClass = "colHD"
      oColpakSiteIssRecD.Style.Add("text-align","right")
      oRowpakSiteIssRecD.Cells.Add(oColpakSiteIssRecD)
      oColpakSiteIssRecD = New TableCell
      oColpakSiteIssRecD.Text = "Quantity Issued"
      oColpakSiteIssRecD.Font.Bold = True
      oColpakSiteIssRecD.CssClass = "colHD"
      oColpakSiteIssRecD.Style.Add("text-align","right")
      oRowpakSiteIssRecD.Cells.Add(oColpakSiteIssRecD)
      oColpakSiteIssRecD = New TableCell
      oColpakSiteIssRecD.Text = "Issuer Remarks"
      oColpakSiteIssRecD.Font.Bold = True
      oColpakSiteIssRecD.CssClass = "colHD"
      oColpakSiteIssRecD.Style.Add("text-align","left")
      oRowpakSiteIssRecD.Cells.Add(oColpakSiteIssRecD)
      oTblpakSiteIssRecD.Rows.Add(oRowpakSiteIssRecD)
      For Each opakSiteIssRecD As SIS.PAK.pakSiteIssRecD In opakSiteIssRecDs
        oRowpakSiteIssRecD = New TableRow
        oColpakSiteIssRecD = New TableCell
        oColpakSiteIssRecD.CssClass = "rowHD"
        oColpakSiteIssRecD.Text = opakSiteIssRecD.IssueSrNo
      oColpakSiteIssRecD.Style.Add("text-align","right")
        oRowpakSiteIssRecD.Cells.Add(oColpakSiteIssRecD)
        oColpakSiteIssRecD = New TableCell
        oColpakSiteIssRecD.Text = opakSiteIssRecD.PAK_SiteItemMaster3_ItemDescription
        oColpakSiteIssRecD.CssClass = "rowHD"
      oColpakSiteIssRecD.Style.Add("text-align","left")
        oRowpakSiteIssRecD.Cells.Add(oColpakSiteIssRecD)
        oColpakSiteIssRecD = New TableCell
        oColpakSiteIssRecD.Text = opakSiteIssRecD.PAK_Units4_Description
        oColpakSiteIssRecD.CssClass = "rowHD"
      oColpakSiteIssRecD.Style.Add("text-align","right")
        oRowpakSiteIssRecD.Cells.Add(oColpakSiteIssRecD)
        oColpakSiteIssRecD = New TableCell
        oColpakSiteIssRecD.CssClass = "rowHD"
        oColpakSiteIssRecD.Text = opakSiteIssRecD.QuantityRequired
      oColpakSiteIssRecD.Style.Add("text-align","right")
        oRowpakSiteIssRecD.Cells.Add(oColpakSiteIssRecD)
        oColpakSiteIssRecD = New TableCell
        oColpakSiteIssRecD.CssClass = "rowHD"
        oColpakSiteIssRecD.Text = opakSiteIssRecD.QuantityIssued
      oColpakSiteIssRecD.Style.Add("text-align","right")
        oRowpakSiteIssRecD.Cells.Add(oColpakSiteIssRecD)
        oColpakSiteIssRecD = New TableCell
        oColpakSiteIssRecD.CssClass = "rowHD"
        oColpakSiteIssRecD.Text = opakSiteIssRecD.IssuerRemarks
      oColpakSiteIssRecD.Style.Add("text-align","left")
        oRowpakSiteIssRecD.Cells.Add(oColpakSiteIssRecD)
        oTblpakSiteIssRecD.Rows.Add(oRowpakSiteIssRecD)
      Next
      form1.Controls.Add(oTblpakSiteIssRecD)
    End If
  End Sub
End Class
