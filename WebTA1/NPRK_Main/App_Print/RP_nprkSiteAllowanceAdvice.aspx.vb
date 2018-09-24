Partial Class RP_nprkSiteAllowanceAdvice
  Inherits System.Web.UI.Page
  Private _InfoUrl As String = "~/NPRK_Main/App_Display/DF_nprkSiteAllowanceAdvice.aspx"
  Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _InfoUrl  & "?FinYear=" & aVal(0) & "&Quarter=" & aVal(1) & "&AdviceNo=" & aVal(2)
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    Dim aVal() As String = Request.QueryString("pk").Split("|".ToCharArray)
    Dim FinYear As Int32 = CType(aVal(0), Int32)
    Dim Quarter As Int32 = CType(aVal(1), Int32)
    Dim AdviceNo As Int32 = CType(aVal(2), Int32)
    Dim oVar As SIS.NPRK.nprkSiteAllowanceAdvice = SIS.NPRK.nprkSiteAllowanceAdvice.nprkSiteAllowanceAdviceGetByID(FinYear, Quarter, AdviceNo)
    Dim oTblnprkSiteAllowanceAdvice As New Table
    oTblnprkSiteAllowanceAdvice.Width = 1000
    oTblnprkSiteAllowanceAdvice.GridLines = GridLines.Both
    oTblnprkSiteAllowanceAdvice.Style.Add("margin-top", "15px")
    oTblnprkSiteAllowanceAdvice.Style.Add("margin-left", "10px")
    Dim oColnprkSiteAllowanceAdvice As TableCell = Nothing
    Dim oRownprkSiteAllowanceAdvice As TableRow = Nothing
    oRownprkSiteAllowanceAdvice = New TableRow
    oColnprkSiteAllowanceAdvice = New TableCell
    oColnprkSiteAllowanceAdvice.Text = "Fin Year"
    oColnprkSiteAllowanceAdvice.Font.Bold = True
    oRownprkSiteAllowanceAdvice.Cells.Add(oColnprkSiteAllowanceAdvice)
    oColnprkSiteAllowanceAdvice = New TableCell
    oColnprkSiteAllowanceAdvice.Text = oVar.FinYear
    oColnprkSiteAllowanceAdvice.Style.Add("text-align", "right")
    oRownprkSiteAllowanceAdvice.Cells.Add(oColnprkSiteAllowanceAdvice)
    oColnprkSiteAllowanceAdvice = New TableCell
    oColnprkSiteAllowanceAdvice.Text = oVar.COST_FinYear5_Descpription
    oColnprkSiteAllowanceAdvice.Style.Add("text-align", "right")
    oRownprkSiteAllowanceAdvice.Cells.Add(oColnprkSiteAllowanceAdvice)
    oColnprkSiteAllowanceAdvice = New TableCell
    oColnprkSiteAllowanceAdvice.Text = "Quarter"
    oColnprkSiteAllowanceAdvice.Font.Bold = True
    oRownprkSiteAllowanceAdvice.Cells.Add(oColnprkSiteAllowanceAdvice)
    oColnprkSiteAllowanceAdvice = New TableCell
    oColnprkSiteAllowanceAdvice.Text = oVar.Quarter
    oColnprkSiteAllowanceAdvice.Style.Add("text-align", "right")
    oRownprkSiteAllowanceAdvice.Cells.Add(oColnprkSiteAllowanceAdvice)
    oColnprkSiteAllowanceAdvice = New TableCell
    oColnprkSiteAllowanceAdvice.Text = oVar.COST_Quarters6_Description
    oColnprkSiteAllowanceAdvice.Style.Add("text-align", "right")
    oRownprkSiteAllowanceAdvice.Cells.Add(oColnprkSiteAllowanceAdvice)
    oTblnprkSiteAllowanceAdvice.Rows.Add(oRownprkSiteAllowanceAdvice)
    oRownprkSiteAllowanceAdvice = New TableRow
    oColnprkSiteAllowanceAdvice = New TableCell
    oColnprkSiteAllowanceAdvice.Text = "Advice No"
    oColnprkSiteAllowanceAdvice.Font.Bold = True
    oRownprkSiteAllowanceAdvice.Cells.Add(oColnprkSiteAllowanceAdvice)
    oColnprkSiteAllowanceAdvice = New TableCell
    oColnprkSiteAllowanceAdvice.Text = oVar.AdviceNo
    oColnprkSiteAllowanceAdvice.Style.Add("text-align", "right")
    oColnprkSiteAllowanceAdvice.ColumnSpan = "2"
    oRownprkSiteAllowanceAdvice.Cells.Add(oColnprkSiteAllowanceAdvice)
    oColnprkSiteAllowanceAdvice = New TableCell
    oColnprkSiteAllowanceAdvice.Text = "Status ID"
    oColnprkSiteAllowanceAdvice.Font.Bold = True
    oRownprkSiteAllowanceAdvice.Cells.Add(oColnprkSiteAllowanceAdvice)
    oColnprkSiteAllowanceAdvice = New TableCell
    oColnprkSiteAllowanceAdvice.Text = oVar.StatusID
    oColnprkSiteAllowanceAdvice.Style.Add("text-align", "right")
    oRownprkSiteAllowanceAdvice.Cells.Add(oColnprkSiteAllowanceAdvice)
    oColnprkSiteAllowanceAdvice = New TableCell
    oColnprkSiteAllowanceAdvice.Text = oVar.PRK_SAAdviceStatus7_Description
    oColnprkSiteAllowanceAdvice.Style.Add("text-align", "right")
    oRownprkSiteAllowanceAdvice.Cells.Add(oColnprkSiteAllowanceAdvice)
    oTblnprkSiteAllowanceAdvice.Rows.Add(oRownprkSiteAllowanceAdvice)
    oRownprkSiteAllowanceAdvice = New TableRow
    oColnprkSiteAllowanceAdvice = New TableCell
    oColnprkSiteAllowanceAdvice.Text = "Total Advice Amount"
    oColnprkSiteAllowanceAdvice.Font.Bold = True
    oRownprkSiteAllowanceAdvice.Cells.Add(oColnprkSiteAllowanceAdvice)
    oColnprkSiteAllowanceAdvice = New TableCell
    oColnprkSiteAllowanceAdvice.Text = oVar.TotalAdviceAmount
    oColnprkSiteAllowanceAdvice.Style.Add("text-align", "right")
    oColnprkSiteAllowanceAdvice.ColumnSpan = "5"
    oRownprkSiteAllowanceAdvice.Cells.Add(oColnprkSiteAllowanceAdvice)
    oTblnprkSiteAllowanceAdvice.Rows.Add(oRownprkSiteAllowanceAdvice)
    oRownprkSiteAllowanceAdvice = New TableRow
    oColnprkSiteAllowanceAdvice = New TableCell
    oColnprkSiteAllowanceAdvice.Text = "Remarks"
    oColnprkSiteAllowanceAdvice.Font.Bold = True
    oRownprkSiteAllowanceAdvice.Cells.Add(oColnprkSiteAllowanceAdvice)
    oColnprkSiteAllowanceAdvice = New TableCell
    oColnprkSiteAllowanceAdvice.Text = oVar.Remarks
    oColnprkSiteAllowanceAdvice.Style.Add("text-align", "left")
    oColnprkSiteAllowanceAdvice.ColumnSpan = "5"
    oRownprkSiteAllowanceAdvice.Cells.Add(oColnprkSiteAllowanceAdvice)
    oTblnprkSiteAllowanceAdvice.Rows.Add(oRownprkSiteAllowanceAdvice)
    oRownprkSiteAllowanceAdvice = New TableRow
    oColnprkSiteAllowanceAdvice = New TableCell
    oColnprkSiteAllowanceAdvice.Text = "Created On"
    oColnprkSiteAllowanceAdvice.Font.Bold = True
    oRownprkSiteAllowanceAdvice.Cells.Add(oColnprkSiteAllowanceAdvice)
    oColnprkSiteAllowanceAdvice = New TableCell
    oColnprkSiteAllowanceAdvice.Text = oVar.CreatedOn
    oColnprkSiteAllowanceAdvice.Style.Add("text-align", "center")
    oColnprkSiteAllowanceAdvice.ColumnSpan = "2"
    oRownprkSiteAllowanceAdvice.Cells.Add(oColnprkSiteAllowanceAdvice)
    oColnprkSiteAllowanceAdvice = New TableCell
    oColnprkSiteAllowanceAdvice.Text = "Created By"
    oColnprkSiteAllowanceAdvice.Font.Bold = True
    oRownprkSiteAllowanceAdvice.Cells.Add(oColnprkSiteAllowanceAdvice)
    oColnprkSiteAllowanceAdvice = New TableCell
    oColnprkSiteAllowanceAdvice.Text = oVar.CreatedBy
    oColnprkSiteAllowanceAdvice.Style.Add("text-align", "left")
    oRownprkSiteAllowanceAdvice.Cells.Add(oColnprkSiteAllowanceAdvice)
    oColnprkSiteAllowanceAdvice = New TableCell
    oColnprkSiteAllowanceAdvice.Text = oVar.aspnet_users1_UserFullName
    oColnprkSiteAllowanceAdvice.Style.Add("text-align", "left")
    oRownprkSiteAllowanceAdvice.Cells.Add(oColnprkSiteAllowanceAdvice)
    oTblnprkSiteAllowanceAdvice.Rows.Add(oRownprkSiteAllowanceAdvice)
    form1.Controls.Add(oTblnprkSiteAllowanceAdvice)
    Dim oTblnprkLinkedSAClaims As Table = Nothing
    Dim oRownprkLinkedSAClaims As TableRow = Nothing
    Dim oColnprkLinkedSAClaims As TableCell = Nothing
    Dim onprkLinkedSAClaimss As List(Of SIS.NPRK.nprkLinkedSAClaims) = SIS.NPRK.nprkLinkedSAClaims.UZ_nprkLinkedSAClaimsSelectList(0, 999, "", False, "", oVar.AdviceNo)
    If onprkLinkedSAClaimss.Count > 0 Then
      Dim oTblhnprkLinkedSAClaims As Table = New Table
      oTblhnprkLinkedSAClaims.Width = 1000
      oTblhnprkLinkedSAClaims.Style.Add("margin-top", "15px")
      oTblhnprkLinkedSAClaims.Style.Add("margin-left", "10px")
      oTblhnprkLinkedSAClaims.Style.Add("margin-right", "10px")
      Dim oRowhnprkLinkedSAClaims As TableRow = New TableRow
      Dim oColhnprkLinkedSAClaims As TableCell = New TableCell
      oColhnprkLinkedSAClaims.Font.Bold = True
      oColhnprkLinkedSAClaims.Font.UnderLine = True
      oColhnprkLinkedSAClaims.Font.Size = 10
      oColhnprkLinkedSAClaims.CssClass = "grpHD"
      oColhnprkLinkedSAClaims.Text = "Selected Claims"
      oRowhnprkLinkedSAClaims.Cells.Add(oColhnprkLinkedSAClaims)
      oTblhnprkLinkedSAClaims.Rows.Add(oRowhnprkLinkedSAClaims)
      form1.Controls.Add(oTblhnprkLinkedSAClaims)
      oTblnprkLinkedSAClaims = New Table
      oTblnprkLinkedSAClaims.Width = 1000
      oTblnprkLinkedSAClaims.GridLines = GridLines.Both
      oTblnprkLinkedSAClaims.Style.Add("margin-left", "10px")
      oTblnprkLinkedSAClaims.Style.Add("margin-right", "10px")
      oRownprkLinkedSAClaims = New TableRow
      oColnprkLinkedSAClaims = New TableCell
      oColnprkLinkedSAClaims.Text = "Employee"
      oColnprkLinkedSAClaims.Font.Bold = True
      oColnprkLinkedSAClaims.CssClass = "colHD"
      oColnprkLinkedSAClaims.Style.Add("text-align", "left")
      oRownprkLinkedSAClaims.Cells.Add(oColnprkLinkedSAClaims)
      oColnprkLinkedSAClaims = New TableCell
      oColnprkLinkedSAClaims.Text = "Approved Days [1]"
      oColnprkLinkedSAClaims.Font.Bold = True
      oColnprkLinkedSAClaims.CssClass = "colHD"
      oColnprkLinkedSAClaims.Style.Add("text-align", "right")
      oRownprkLinkedSAClaims.Cells.Add(oColnprkLinkedSAClaims)
      oColnprkLinkedSAClaims = New TableCell
      oColnprkLinkedSAClaims.Text = "Approved Days [2]"
      oColnprkLinkedSAClaims.Font.Bold = True
      oColnprkLinkedSAClaims.CssClass = "colHD"
      oColnprkLinkedSAClaims.Style.Add("text-align", "right")
      oRownprkLinkedSAClaims.Cells.Add(oColnprkLinkedSAClaims)
      oColnprkLinkedSAClaims = New TableCell
      oColnprkLinkedSAClaims.Text = "Approved Days [3]"
      oColnprkLinkedSAClaims.Font.Bold = True
      oColnprkLinkedSAClaims.CssClass = "colHD"
      oColnprkLinkedSAClaims.Style.Add("text-align", "right")
      oRownprkLinkedSAClaims.Cells.Add(oColnprkLinkedSAClaims)
      oColnprkLinkedSAClaims = New TableCell
      oColnprkLinkedSAClaims.Text = "Approved Amount [1]"
      oColnprkLinkedSAClaims.Font.Bold = True
      oColnprkLinkedSAClaims.CssClass = "colHD"
      oColnprkLinkedSAClaims.Style.Add("text-align", "right")
      oRownprkLinkedSAClaims.Cells.Add(oColnprkLinkedSAClaims)
      oColnprkLinkedSAClaims = New TableCell
      oColnprkLinkedSAClaims.Text = "Approved Amount [2]"
      oColnprkLinkedSAClaims.Font.Bold = True
      oColnprkLinkedSAClaims.CssClass = "colHD"
      oColnprkLinkedSAClaims.Style.Add("text-align", "right")
      oRownprkLinkedSAClaims.Cells.Add(oColnprkLinkedSAClaims)
      oColnprkLinkedSAClaims = New TableCell
      oColnprkLinkedSAClaims.Text = "Approved Amount [3]"
      oColnprkLinkedSAClaims.Font.Bold = True
      oColnprkLinkedSAClaims.CssClass = "colHD"
      oColnprkLinkedSAClaims.Style.Add("text-align", "right")
      oRownprkLinkedSAClaims.Cells.Add(oColnprkLinkedSAClaims)
      oColnprkLinkedSAClaims = New TableCell
      oColnprkLinkedSAClaims.Text = "Total Approved Amount"
      oColnprkLinkedSAClaims.Font.Bold = True
      oColnprkLinkedSAClaims.CssClass = "colHD"
      oColnprkLinkedSAClaims.Style.Add("text-align", "right")
      oRownprkLinkedSAClaims.Cells.Add(oColnprkLinkedSAClaims)
      oTblnprkLinkedSAClaims.Rows.Add(oRownprkLinkedSAClaims)
      For Each onprkLinkedSAClaims As SIS.NPRK.nprkLinkedSAClaims In onprkLinkedSAClaimss
        oRownprkLinkedSAClaims = New TableRow
        oColnprkLinkedSAClaims = New TableCell
        oColnprkLinkedSAClaims.Text = onprkLinkedSAClaims.HRM_Employees5_EmployeeName
        oColnprkLinkedSAClaims.CssClass = "rowHD"
        oColnprkLinkedSAClaims.Style.Add("text-align", "left")
        oRownprkLinkedSAClaims.Cells.Add(oColnprkLinkedSAClaims)
        oColnprkLinkedSAClaims = New TableCell
        oColnprkLinkedSAClaims.CssClass = "rowHD"
        oColnprkLinkedSAClaims.Text = onprkLinkedSAClaims.Approved1Days
        oColnprkLinkedSAClaims.Style.Add("text-align", "right")
        oRownprkLinkedSAClaims.Cells.Add(oColnprkLinkedSAClaims)
        oColnprkLinkedSAClaims = New TableCell
        oColnprkLinkedSAClaims.CssClass = "rowHD"
        oColnprkLinkedSAClaims.Text = onprkLinkedSAClaims.Approved2Days
        oColnprkLinkedSAClaims.Style.Add("text-align", "right")
        oRownprkLinkedSAClaims.Cells.Add(oColnprkLinkedSAClaims)
        oColnprkLinkedSAClaims = New TableCell
        oColnprkLinkedSAClaims.CssClass = "rowHD"
        oColnprkLinkedSAClaims.Text = onprkLinkedSAClaims.Approved3Days
        oColnprkLinkedSAClaims.Style.Add("text-align", "right")
        oRownprkLinkedSAClaims.Cells.Add(oColnprkLinkedSAClaims)
        oColnprkLinkedSAClaims = New TableCell
        oColnprkLinkedSAClaims.CssClass = "rowHD"
        oColnprkLinkedSAClaims.Text = onprkLinkedSAClaims.Approved1Amount
        oColnprkLinkedSAClaims.Style.Add("text-align", "right")
        oRownprkLinkedSAClaims.Cells.Add(oColnprkLinkedSAClaims)
        oColnprkLinkedSAClaims = New TableCell
        oColnprkLinkedSAClaims.CssClass = "rowHD"
        oColnprkLinkedSAClaims.Text = onprkLinkedSAClaims.Approved2Amount
        oColnprkLinkedSAClaims.Style.Add("text-align", "right")
        oRownprkLinkedSAClaims.Cells.Add(oColnprkLinkedSAClaims)
        oColnprkLinkedSAClaims = New TableCell
        oColnprkLinkedSAClaims.CssClass = "rowHD"
        oColnprkLinkedSAClaims.Text = onprkLinkedSAClaims.Approved3Amount
        oColnprkLinkedSAClaims.Style.Add("text-align", "right")
        oRownprkLinkedSAClaims.Cells.Add(oColnprkLinkedSAClaims)
        oColnprkLinkedSAClaims = New TableCell
        oColnprkLinkedSAClaims.CssClass = "rowHD"
        oColnprkLinkedSAClaims.Text = onprkLinkedSAClaims.TotalApprovedAmount
        oColnprkLinkedSAClaims.Style.Add("text-align", "right")
        oRownprkLinkedSAClaims.Cells.Add(oColnprkLinkedSAClaims)
        oTblnprkLinkedSAClaims.Rows.Add(oRownprkLinkedSAClaims)
      Next
      form1.Controls.Add(oTblnprkLinkedSAClaims)
    End If
  End Sub
End Class
