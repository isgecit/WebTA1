Partial Class RP_costProjectsIputApproval
  Inherits System.Web.UI.Page
  Private _InfoUrl As String = "~/COST_Main/App_Display/DF_costProjectsIputApproval.aspx"
  Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _InfoUrl  & "?ProjectGroupID=" & aVal(0) & "&FinYear=" & aVal(1) & "&Quarter=" & aVal(2)
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    Dim aVal() As String = Request.QueryString("pk").Split("|".ToCharArray)
    Dim ProjectGroupID As Int32 = CType(aVal(0),Int32)
    Dim FinYear As Int32 = CType(aVal(1),Int32)
    Dim Quarter As Int32 = CType(aVal(2),Int32)
    Dim oVar As SIS.COST.costProjectsIputApproval = SIS.COST.costProjectsIputApproval.costProjectsIputApprovalGetByID(ProjectGroupID,FinYear,Quarter)
    Dim oTbl As New Table
    oTbl.Width = 1000
    oTbl.GridLines = GridLines.Both
    oTbl.Style.Add("margin-top", "15px")
    oTbl.Style.Add("margin-left", "30px")
    Dim oCol As TableCell = Nothing
    Dim oRow As TableRow = Nothing
    oRow = New TableRow
    oCol = New TableCell
    oCol.Text = "Project Group ID"
    oCol.Font.Bold = True
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.ProjectGroupID
      oCol.Style.Add("text-align","right")
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.COST_ProjectGroups4_ProjectGroupDescription
      oCol.Style.Add("text-align","right")
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Status ID"
    oCol.Font.Bold = True
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.StatusID
      oCol.Style.Add("text-align","right")
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.COST_ProjectInputStatus5_Description
      oCol.Style.Add("text-align","right")
    oRow.Cells.Add(oCol)
    oTbl.Rows.Add(oRow)
    oRow = New TableRow
    oCol = New TableCell
    oCol.Text = "Fin Year"
    oCol.Font.Bold = True
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.FinYear
      oCol.Style.Add("text-align","right")
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.COST_FinYear3_Descpription
      oCol.Style.Add("text-align","right")
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Quarter"
    oCol.Font.Bold = True
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.Quarter
      oCol.Style.Add("text-align","right")
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.COST_Quarters6_Description
      oCol.Style.Add("text-align","right")
    oRow.Cells.Add(oCol)
    oTbl.Rows.Add(oRow)
    oRow = New TableRow
    oCol = New TableCell
    oCol.Text = "Currency [Total Order Value]"
    oCol.Font.Bold = True
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.CurrencyGOV
      oCol.Style.Add("text-align","left")
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.TA_Currencies8_CurrencyName
      oCol.Style.Add("text-align","left")
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Total Order Value"
    oCol.Font.Bold = True
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.GroupOrderValue
      oCol.Style.Add("text-align","right")
    oCol.ColumnSpan = "2"
    oRow.Cells.Add(oCol)
    oTbl.Rows.Add(oRow)
    oRow = New TableRow
    oCol = New TableCell
    oCol.Text = "Conversion Factor [Total Order Value]"
    oCol.Font.Bold = True
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.CFforGOV
      oCol.Style.Add("text-align","right")
    oCol.ColumnSpan = "2"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Total Order Value [INR]"
    oCol.Font.Bold = True
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.GroupOrderValueINR
      oCol.Style.Add("text-align","right")
    oCol.ColumnSpan = "2"
    oRow.Cells.Add(oCol)
    oTbl.Rows.Add(oRow)
    oRow = New TableRow
    oCol = New TableCell
    oCol.Text = "Currency for Project Input"
    oCol.Font.Bold = True
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.CurrencyPR
      oCol.Style.Add("text-align","left")
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.TA_Currencies9_CurrencyName
      oCol.Style.Add("text-align","left")
    oCol.ColumnSpan = "4"
    oRow.Cells.Add(oCol)
    oTbl.Rows.Add(oRow)
    oRow = New TableRow
    oCol = New TableCell
    oCol.Text = "Project Revenue"
    oCol.Font.Bold = True
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.ProjectRevenue
      oCol.Style.Add("text-align","right")
    oCol.ColumnSpan = "5"
    oRow.Cells.Add(oCol)
    oTbl.Rows.Add(oRow)
    oRow = New TableRow
    oCol = New TableCell
    oCol.Text = "Project Margin"
    oCol.Font.Bold = True
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.ProjectMargin
      oCol.Style.Add("text-align","right")
    oCol.ColumnSpan = "5"
    oRow.Cells.Add(oCol)
    oTbl.Rows.Add(oRow)
    oRow = New TableRow
    oCol = New TableCell
    oCol.Text = "Export Incentive"
    oCol.Font.Bold = True
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.ExportIncentive
      oCol.Style.Add("text-align","right")
    oCol.ColumnSpan = "5"
    oRow.Cells.Add(oCol)
    oTbl.Rows.Add(oRow)
    oRow = New TableRow
    oCol = New TableCell
    oCol.Text = "Conversion Factor for Project Input"
    oCol.Font.Bold = True
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.CFforPR
      oCol.Style.Add("text-align","right")
    oCol.ColumnSpan = "5"
    oRow.Cells.Add(oCol)
    oTbl.Rows.Add(oRow)
    oRow = New TableRow
    oCol = New TableCell
    oCol.Text = "Project Revenue [INR]"
    oCol.Font.Bold = True
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.ProjectRevenueINR
      oCol.Style.Add("text-align","right")
    oCol.ColumnSpan = "5"
    oRow.Cells.Add(oCol)
    oTbl.Rows.Add(oRow)
    oRow = New TableRow
    oCol = New TableCell
    oCol.Text = "Project Margin [INR]"
    oCol.Font.Bold = True
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.ProjectMarginINR
      oCol.Style.Add("text-align","right")
    oCol.ColumnSpan = "5"
    oRow.Cells.Add(oCol)
    oTbl.Rows.Add(oRow)
    oRow = New TableRow
    oCol = New TableCell
    oCol.Text = "Export Incentive [INR]"
    oCol.Font.Bold = True
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.ExportIncentiveINR
      oCol.Style.Add("text-align","right")
    oCol.ColumnSpan = "5"
    oRow.Cells.Add(oCol)
    oTbl.Rows.Add(oRow)
    oRow = New TableRow
    oCol = New TableCell
    oCol.Text = "Remarks"
    oCol.Font.Bold = True
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.Remarks
      oCol.Style.Add("text-align","left")
    oCol.ColumnSpan = "5"
    oRow.Cells.Add(oCol)
    oTbl.Rows.Add(oRow)
    oRow = New TableRow
    oCol = New TableCell
    oCol.Text = "Created By"
    oCol.Font.Bold = True
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.CreatedBy
      oCol.Style.Add("text-align","left")
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.aspnet_users1_UserFullName
      oCol.Style.Add("text-align","left")
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Created On"
    oCol.Font.Bold = True
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.CreatedOn
      oCol.Style.Add("text-align","center")
    oCol.ColumnSpan = "2"
    oRow.Cells.Add(oCol)
    oTbl.Rows.Add(oRow)
    oRow = New TableRow
    oCol = New TableCell
    oCol.Text = "Approver Remarks"
    oCol.Font.Bold = True
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.ApproverRemarks
      oCol.Style.Add("text-align","left")
    oCol.ColumnSpan = "5"
    oRow.Cells.Add(oCol)
    oTbl.Rows.Add(oRow)
    oRow = New TableRow
    oCol = New TableCell
    oCol.Text = "Approved By"
    oCol.Font.Bold = True
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.ApprovedBy
      oCol.Style.Add("text-align","left")
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.aspnet_users2_UserFullName
      oCol.Style.Add("text-align","left")
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Approved On"
    oCol.Font.Bold = True
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.ApprovedOn
      oCol.Style.Add("text-align","center")
    oCol.ColumnSpan = "2"
    oRow.Cells.Add(oCol)
    oTbl.Rows.Add(oRow)
    form1.Controls.Add(oTbl)
  End Sub
End Class
