Partial Class RP_pakSiteMtlIssH
  Inherits System.Web.UI.Page
  Private _InfoUrl As String = "~/PAK_Main/App_Display/DF_pakSiteMtlIssH.aspx"
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
    Dim oVar As SIS.PAK.pakSiteMtlIssH = SIS.PAK.pakSiteMtlIssH.pakSiteMtlIssHGetByID(ProjectID,IssueNo)
    Dim oTblpakSiteMtlIssH As New Table
    oTblpakSiteMtlIssH.Width = 1000
    oTblpakSiteMtlIssH.GridLines = GridLines.Both
    oTblpakSiteMtlIssH.Style.Add("margin-top", "15px")
    oTblpakSiteMtlIssH.Style.Add("margin-left", "10px")
    Dim oColpakSiteMtlIssH As TableCell = Nothing
    Dim oRowpakSiteMtlIssH As TableRow = Nothing
    oRowpakSiteMtlIssH = New TableRow
    oColpakSiteMtlIssH = New TableCell
    oColpakSiteMtlIssH.Text = "Project"
    oColpakSiteMtlIssH.Font.Bold = True
    oRowpakSiteMtlIssH.Cells.Add(oColpakSiteMtlIssH)
    oColpakSiteMtlIssH = New TableCell
    oColpakSiteMtlIssH.Text = oVar.ProjectID
      oColpakSiteMtlIssH.Style.Add("text-align","left")
    oRowpakSiteMtlIssH.Cells.Add(oColpakSiteMtlIssH)
    oColpakSiteMtlIssH = New TableCell
    oColpakSiteMtlIssH.Text = oVar.IDM_Projects3_Description
      oColpakSiteMtlIssH.Style.Add("text-align","left")
    oRowpakSiteMtlIssH.Cells.Add(oColpakSiteMtlIssH)
    oColpakSiteMtlIssH = New TableCell
    oColpakSiteMtlIssH.Text = "Request No"
    oColpakSiteMtlIssH.Font.Bold = True
    oRowpakSiteMtlIssH.Cells.Add(oColpakSiteMtlIssH)
    oColpakSiteMtlIssH = New TableCell
    oColpakSiteMtlIssH.Text = oVar.IssueNo
      oColpakSiteMtlIssH.Style.Add("text-align","right")
    oColpakSiteMtlIssH.ColumnSpan = "2"
    oRowpakSiteMtlIssH.Cells.Add(oColpakSiteMtlIssH)
    oTblpakSiteMtlIssH.Rows.Add(oRowpakSiteMtlIssH)
    oRowpakSiteMtlIssH = New TableRow
    oColpakSiteMtlIssH = New TableCell
    oColpakSiteMtlIssH.Text = "Requester Remarks"
    oColpakSiteMtlIssH.Font.Bold = True
    oRowpakSiteMtlIssH.Cells.Add(oColpakSiteMtlIssH)
    oColpakSiteMtlIssH = New TableCell
    oColpakSiteMtlIssH.Text = oVar.RequesterRemarks
      oColpakSiteMtlIssH.Style.Add("text-align","left")
    oColpakSiteMtlIssH.ColumnSpan = "5"
    oRowpakSiteMtlIssH.Cells.Add(oColpakSiteMtlIssH)
    oTblpakSiteMtlIssH.Rows.Add(oRowpakSiteMtlIssH)
    oRowpakSiteMtlIssH = New TableRow
    oColpakSiteMtlIssH = New TableCell
    oColpakSiteMtlIssH.Text = "Requested By"
    oColpakSiteMtlIssH.Font.Bold = True
    oRowpakSiteMtlIssH.Cells.Add(oColpakSiteMtlIssH)
    oColpakSiteMtlIssH = New TableCell
    oColpakSiteMtlIssH.Text = oVar.RequestedBy
      oColpakSiteMtlIssH.Style.Add("text-align","left")
    oRowpakSiteMtlIssH.Cells.Add(oColpakSiteMtlIssH)
    oColpakSiteMtlIssH = New TableCell
    oColpakSiteMtlIssH.Text = oVar.aspnet_users6_UserFullName
      oColpakSiteMtlIssH.Style.Add("text-align","left")
    oRowpakSiteMtlIssH.Cells.Add(oColpakSiteMtlIssH)
    oColpakSiteMtlIssH = New TableCell
    oColpakSiteMtlIssH.Text = "Requested On"
    oColpakSiteMtlIssH.Font.Bold = True
    oRowpakSiteMtlIssH.Cells.Add(oColpakSiteMtlIssH)
    oColpakSiteMtlIssH = New TableCell
    oColpakSiteMtlIssH.Text = oVar.RequestedOn
      oColpakSiteMtlIssH.Style.Add("text-align","center")
    oColpakSiteMtlIssH.ColumnSpan = "2"
    oRowpakSiteMtlIssH.Cells.Add(oColpakSiteMtlIssH)
    oTblpakSiteMtlIssH.Rows.Add(oRowpakSiteMtlIssH)
    oRowpakSiteMtlIssH = New TableRow
    oColpakSiteMtlIssH = New TableCell
    oColpakSiteMtlIssH.Text = "Issued By"
    oColpakSiteMtlIssH.Font.Bold = True
    oRowpakSiteMtlIssH.Cells.Add(oColpakSiteMtlIssH)
    oColpakSiteMtlIssH = New TableCell
    oColpakSiteMtlIssH.Text = oVar.IssuedBy
      oColpakSiteMtlIssH.Style.Add("text-align","left")
    oRowpakSiteMtlIssH.Cells.Add(oColpakSiteMtlIssH)
    oColpakSiteMtlIssH = New TableCell
    oColpakSiteMtlIssH.Text = oVar.aspnet_users2_UserFullName
      oColpakSiteMtlIssH.Style.Add("text-align","left")
    oRowpakSiteMtlIssH.Cells.Add(oColpakSiteMtlIssH)
    oColpakSiteMtlIssH = New TableCell
    oColpakSiteMtlIssH.Text = "Issued On"
    oColpakSiteMtlIssH.Font.Bold = True
    oRowpakSiteMtlIssH.Cells.Add(oColpakSiteMtlIssH)
    oColpakSiteMtlIssH = New TableCell
    oColpakSiteMtlIssH.Text = oVar.IssuedOn
      oColpakSiteMtlIssH.Style.Add("text-align","center")
    oColpakSiteMtlIssH.ColumnSpan = "2"
    oRowpakSiteMtlIssH.Cells.Add(oColpakSiteMtlIssH)
    oTblpakSiteMtlIssH.Rows.Add(oRowpakSiteMtlIssH)
    oRowpakSiteMtlIssH = New TableRow
    oColpakSiteMtlIssH = New TableCell
    oColpakSiteMtlIssH.Text = "Issue Remarks"
    oColpakSiteMtlIssH.Font.Bold = True
    oRowpakSiteMtlIssH.Cells.Add(oColpakSiteMtlIssH)
    oColpakSiteMtlIssH = New TableCell
    oColpakSiteMtlIssH.Text = oVar.IssueRemarks
      oColpakSiteMtlIssH.Style.Add("text-align","left")
    oColpakSiteMtlIssH.ColumnSpan = "5"
    oRowpakSiteMtlIssH.Cells.Add(oColpakSiteMtlIssH)
    oTblpakSiteMtlIssH.Rows.Add(oRowpakSiteMtlIssH)
    oRowpakSiteMtlIssH = New TableRow
    oColpakSiteMtlIssH = New TableCell
    oColpakSiteMtlIssH.Text = "Issue To"
    oColpakSiteMtlIssH.Font.Bold = True
    oRowpakSiteMtlIssH.Cells.Add(oColpakSiteMtlIssH)
    oColpakSiteMtlIssH = New TableCell
    oColpakSiteMtlIssH.Text = oVar.IssueToCardNo
      oColpakSiteMtlIssH.Style.Add("text-align","left")
    oRowpakSiteMtlIssH.Cells.Add(oColpakSiteMtlIssH)
    oColpakSiteMtlIssH = New TableCell
    oColpakSiteMtlIssH.Text = oVar.aspnet_users1_UserFullName
      oColpakSiteMtlIssH.Style.Add("text-align","left")
    oRowpakSiteMtlIssH.Cells.Add(oColpakSiteMtlIssH)
    oColpakSiteMtlIssH = New TableCell
    oColpakSiteMtlIssH.Text = "Requester Name"
    oColpakSiteMtlIssH.Font.Bold = True
    oRowpakSiteMtlIssH.Cells.Add(oColpakSiteMtlIssH)
    oColpakSiteMtlIssH = New TableCell
    oColpakSiteMtlIssH.Text = oVar.IssueToName
      oColpakSiteMtlIssH.Style.Add("text-align","left")
    oColpakSiteMtlIssH.ColumnSpan = "2"
    oRowpakSiteMtlIssH.Cells.Add(oColpakSiteMtlIssH)
    oTblpakSiteMtlIssH.Rows.Add(oRowpakSiteMtlIssH)
    oRowpakSiteMtlIssH = New TableRow
    oColpakSiteMtlIssH = New TableCell
    oColpakSiteMtlIssH.Text = "Issue Type"
    oColpakSiteMtlIssH.Font.Bold = True
    oRowpakSiteMtlIssH.Cells.Add(oColpakSiteMtlIssH)
    oColpakSiteMtlIssH = New TableCell
    oColpakSiteMtlIssH.Text = oVar.IssueTypeID
      oColpakSiteMtlIssH.Style.Add("text-align","right")
    oRowpakSiteMtlIssH.Cells.Add(oColpakSiteMtlIssH)
    oColpakSiteMtlIssH = New TableCell
    oColpakSiteMtlIssH.Text = oVar.PAK_IssueTypes5_Description
      oColpakSiteMtlIssH.Style.Add("text-align","right")
    oRowpakSiteMtlIssH.Cells.Add(oColpakSiteMtlIssH)
    oColpakSiteMtlIssH = New TableCell
    oColpakSiteMtlIssH.Text = "Status"
    oColpakSiteMtlIssH.Font.Bold = True
    oRowpakSiteMtlIssH.Cells.Add(oColpakSiteMtlIssH)
    oColpakSiteMtlIssH = New TableCell
    oColpakSiteMtlIssH.Text = oVar.IssueStatusID
      oColpakSiteMtlIssH.Style.Add("text-align","right")
    oRowpakSiteMtlIssH.Cells.Add(oColpakSiteMtlIssH)
    oColpakSiteMtlIssH = New TableCell
    oColpakSiteMtlIssH.Text = oVar.PAK_IssueStatus4_Description
      oColpakSiteMtlIssH.Style.Add("text-align","right")
    oRowpakSiteMtlIssH.Cells.Add(oColpakSiteMtlIssH)
    oTblpakSiteMtlIssH.Rows.Add(oRowpakSiteMtlIssH)
    form1.Controls.Add(oTblpakSiteMtlIssH)
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
