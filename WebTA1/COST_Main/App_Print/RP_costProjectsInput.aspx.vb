Partial Class RP_costProjectsInput
  Inherits System.Web.UI.Page
  Private _InfoUrl As String = "~/COST_Main/App_Display/DF_costProjectsInput.aspx"
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
    Dim oVar As SIS.COST.costProjectsInput = SIS.COST.costProjectsInput.costProjectsInputGetByID(ProjectGroupID,FinYear,Quarter)
    Dim oTblcostProjectsInput As New Table
    oTblcostProjectsInput.Width = 1000
    oTblcostProjectsInput.GridLines = GridLines.Both
    oTblcostProjectsInput.Style.Add("margin-top", "15px")
    oTblcostProjectsInput.Style.Add("margin-left", "30px")
    Dim oColcostProjectsInput As TableCell = Nothing
    Dim oRowcostProjectsInput As TableRow = Nothing
    oRowcostProjectsInput = New TableRow
    oColcostProjectsInput = New TableCell
    oColcostProjectsInput.Text = "Project Group ID"
    oColcostProjectsInput.Font.Bold = True
    oRowcostProjectsInput.Cells.Add(oColcostProjectsInput)
    oColcostProjectsInput = New TableCell
    oColcostProjectsInput.Text = oVar.ProjectGroupID
      oColcostProjectsInput.Style.Add("text-align","right")
    oRowcostProjectsInput.Cells.Add(oColcostProjectsInput)
    oColcostProjectsInput = New TableCell
    oColcostProjectsInput.Text = oVar.COST_ProjectGroups4_ProjectGroupDescription
      oColcostProjectsInput.Style.Add("text-align","right")
    oRowcostProjectsInput.Cells.Add(oColcostProjectsInput)
    oColcostProjectsInput = New TableCell
    oColcostProjectsInput.Text = "Status ID"
    oColcostProjectsInput.Font.Bold = True
    oRowcostProjectsInput.Cells.Add(oColcostProjectsInput)
    oColcostProjectsInput = New TableCell
    oColcostProjectsInput.Text = oVar.StatusID
      oColcostProjectsInput.Style.Add("text-align","right")
    oRowcostProjectsInput.Cells.Add(oColcostProjectsInput)
    oColcostProjectsInput = New TableCell
    oColcostProjectsInput.Text = oVar.COST_ProjectInputStatus5_Description
      oColcostProjectsInput.Style.Add("text-align","right")
    oRowcostProjectsInput.Cells.Add(oColcostProjectsInput)
    oTblcostProjectsInput.Rows.Add(oRowcostProjectsInput)
    oRowcostProjectsInput = New TableRow
    oColcostProjectsInput = New TableCell
    oColcostProjectsInput.Text = "Fin Year"
    oColcostProjectsInput.Font.Bold = True
    oRowcostProjectsInput.Cells.Add(oColcostProjectsInput)
    oColcostProjectsInput = New TableCell
    oColcostProjectsInput.Text = oVar.FinYear
      oColcostProjectsInput.Style.Add("text-align","right")
    oRowcostProjectsInput.Cells.Add(oColcostProjectsInput)
    oColcostProjectsInput = New TableCell
    oColcostProjectsInput.Text = oVar.COST_FinYear3_Descpription
      oColcostProjectsInput.Style.Add("text-align","right")
    oRowcostProjectsInput.Cells.Add(oColcostProjectsInput)
    oColcostProjectsInput = New TableCell
    oColcostProjectsInput.Text = "Quarter"
    oColcostProjectsInput.Font.Bold = True
    oRowcostProjectsInput.Cells.Add(oColcostProjectsInput)
    oColcostProjectsInput = New TableCell
    oColcostProjectsInput.Text = oVar.Quarter
      oColcostProjectsInput.Style.Add("text-align","right")
    oRowcostProjectsInput.Cells.Add(oColcostProjectsInput)
    oColcostProjectsInput = New TableCell
    oColcostProjectsInput.Text = oVar.COST_Quarters6_Description
      oColcostProjectsInput.Style.Add("text-align","right")
    oRowcostProjectsInput.Cells.Add(oColcostProjectsInput)
    oTblcostProjectsInput.Rows.Add(oRowcostProjectsInput)
    oRowcostProjectsInput = New TableRow
    oColcostProjectsInput = New TableCell
    oColcostProjectsInput.Text = "Currency [Total Order Value]"
    oColcostProjectsInput.Font.Bold = True
    oRowcostProjectsInput.Cells.Add(oColcostProjectsInput)
    oColcostProjectsInput = New TableCell
    oColcostProjectsInput.Text = oVar.CurrencyGOV
      oColcostProjectsInput.Style.Add("text-align","left")
    oRowcostProjectsInput.Cells.Add(oColcostProjectsInput)
    oColcostProjectsInput = New TableCell
    oColcostProjectsInput.Text = oVar.TA_Currencies8_CurrencyName
      oColcostProjectsInput.Style.Add("text-align","left")
    oRowcostProjectsInput.Cells.Add(oColcostProjectsInput)
    oColcostProjectsInput = New TableCell
    oColcostProjectsInput.Text = "Total Order Value"
    oColcostProjectsInput.Font.Bold = True
    oRowcostProjectsInput.Cells.Add(oColcostProjectsInput)
    oColcostProjectsInput = New TableCell
    oColcostProjectsInput.Text = oVar.GroupOrderValue
      oColcostProjectsInput.Style.Add("text-align","right")
    oColcostProjectsInput.ColumnSpan = "2"
    oRowcostProjectsInput.Cells.Add(oColcostProjectsInput)
    oTblcostProjectsInput.Rows.Add(oRowcostProjectsInput)
    oRowcostProjectsInput = New TableRow
    oColcostProjectsInput = New TableCell
    oColcostProjectsInput.Text = "Conversion Factor [Total Order Value]"
    oColcostProjectsInput.Font.Bold = True
    oRowcostProjectsInput.Cells.Add(oColcostProjectsInput)
    oColcostProjectsInput = New TableCell
    oColcostProjectsInput.Text = oVar.CFforGOV
      oColcostProjectsInput.Style.Add("text-align","right")
    oColcostProjectsInput.ColumnSpan = "2"
    oRowcostProjectsInput.Cells.Add(oColcostProjectsInput)
    oColcostProjectsInput = New TableCell
    oColcostProjectsInput.Text = "Total Order Value [INR]"
    oColcostProjectsInput.Font.Bold = True
    oRowcostProjectsInput.Cells.Add(oColcostProjectsInput)
    oColcostProjectsInput = New TableCell
    oColcostProjectsInput.Text = oVar.GroupOrderValueINR
      oColcostProjectsInput.Style.Add("text-align","right")
    oColcostProjectsInput.ColumnSpan = "2"
    oRowcostProjectsInput.Cells.Add(oColcostProjectsInput)
    oTblcostProjectsInput.Rows.Add(oRowcostProjectsInput)
    oRowcostProjectsInput = New TableRow
    oColcostProjectsInput = New TableCell
    oColcostProjectsInput.Text = "Currency for Project Input"
    oColcostProjectsInput.Font.Bold = True
    oRowcostProjectsInput.Cells.Add(oColcostProjectsInput)
    oColcostProjectsInput = New TableCell
    oColcostProjectsInput.Text = oVar.CurrencyPR
      oColcostProjectsInput.Style.Add("text-align","left")
    oRowcostProjectsInput.Cells.Add(oColcostProjectsInput)
    oColcostProjectsInput = New TableCell
    oColcostProjectsInput.Text = oVar.TA_Currencies9_CurrencyName
      oColcostProjectsInput.Style.Add("text-align","left")
    oColcostProjectsInput.ColumnSpan = "4"
    oRowcostProjectsInput.Cells.Add(oColcostProjectsInput)
    oTblcostProjectsInput.Rows.Add(oRowcostProjectsInput)
    oRowcostProjectsInput = New TableRow
    oColcostProjectsInput = New TableCell
    oColcostProjectsInput.Text = "Project Revenue"
    oColcostProjectsInput.Font.Bold = True
    oRowcostProjectsInput.Cells.Add(oColcostProjectsInput)
    oColcostProjectsInput = New TableCell
    oColcostProjectsInput.Text = oVar.ProjectRevenue
      oColcostProjectsInput.Style.Add("text-align","right")
    oColcostProjectsInput.ColumnSpan = "5"
    oRowcostProjectsInput.Cells.Add(oColcostProjectsInput)
    oTblcostProjectsInput.Rows.Add(oRowcostProjectsInput)
    oRowcostProjectsInput = New TableRow
    oColcostProjectsInput = New TableCell
    oColcostProjectsInput.Text = "Project Margin"
    oColcostProjectsInput.Font.Bold = True
    oRowcostProjectsInput.Cells.Add(oColcostProjectsInput)
    oColcostProjectsInput = New TableCell
    oColcostProjectsInput.Text = oVar.ProjectMargin
      oColcostProjectsInput.Style.Add("text-align","right")
    oColcostProjectsInput.ColumnSpan = "5"
    oRowcostProjectsInput.Cells.Add(oColcostProjectsInput)
    oTblcostProjectsInput.Rows.Add(oRowcostProjectsInput)
    oRowcostProjectsInput = New TableRow
    oColcostProjectsInput = New TableCell
    oColcostProjectsInput.Text = "Export Incentive"
    oColcostProjectsInput.Font.Bold = True
    oRowcostProjectsInput.Cells.Add(oColcostProjectsInput)
    oColcostProjectsInput = New TableCell
    oColcostProjectsInput.Text = oVar.ExportIncentive
      oColcostProjectsInput.Style.Add("text-align","right")
    oColcostProjectsInput.ColumnSpan = "5"
    oRowcostProjectsInput.Cells.Add(oColcostProjectsInput)
    oTblcostProjectsInput.Rows.Add(oRowcostProjectsInput)
    oRowcostProjectsInput = New TableRow
    oColcostProjectsInput = New TableCell
    oColcostProjectsInput.Text = "Conversion Factor [INR]"
    oColcostProjectsInput.Font.Bold = True
    oRowcostProjectsInput.Cells.Add(oColcostProjectsInput)
    oColcostProjectsInput = New TableCell
    oColcostProjectsInput.Text = oVar.CFforPR
      oColcostProjectsInput.Style.Add("text-align","right")
    oColcostProjectsInput.ColumnSpan = "5"
    oRowcostProjectsInput.Cells.Add(oColcostProjectsInput)
    oTblcostProjectsInput.Rows.Add(oRowcostProjectsInput)
    oRowcostProjectsInput = New TableRow
    oColcostProjectsInput = New TableCell
    oColcostProjectsInput.Text = "Project Revenue [INR]"
    oColcostProjectsInput.Font.Bold = True
    oRowcostProjectsInput.Cells.Add(oColcostProjectsInput)
    oColcostProjectsInput = New TableCell
    oColcostProjectsInput.Text = oVar.ProjectRevenueINR
      oColcostProjectsInput.Style.Add("text-align","right")
    oColcostProjectsInput.ColumnSpan = "5"
    oRowcostProjectsInput.Cells.Add(oColcostProjectsInput)
    oTblcostProjectsInput.Rows.Add(oRowcostProjectsInput)
    oRowcostProjectsInput = New TableRow
    oColcostProjectsInput = New TableCell
    oColcostProjectsInput.Text = "Project Margin [INR]"
    oColcostProjectsInput.Font.Bold = True
    oRowcostProjectsInput.Cells.Add(oColcostProjectsInput)
    oColcostProjectsInput = New TableCell
    oColcostProjectsInput.Text = oVar.ProjectMarginINR
      oColcostProjectsInput.Style.Add("text-align","right")
    oColcostProjectsInput.ColumnSpan = "5"
    oRowcostProjectsInput.Cells.Add(oColcostProjectsInput)
    oTblcostProjectsInput.Rows.Add(oRowcostProjectsInput)
    oRowcostProjectsInput = New TableRow
    oColcostProjectsInput = New TableCell
    oColcostProjectsInput.Text = "Export Incentive [INR]"
    oColcostProjectsInput.Font.Bold = True
    oRowcostProjectsInput.Cells.Add(oColcostProjectsInput)
    oColcostProjectsInput = New TableCell
    oColcostProjectsInput.Text = oVar.ExportIncentiveINR
      oColcostProjectsInput.Style.Add("text-align","right")
    oColcostProjectsInput.ColumnSpan = "5"
    oRowcostProjectsInput.Cells.Add(oColcostProjectsInput)
    oTblcostProjectsInput.Rows.Add(oRowcostProjectsInput)
    oRowcostProjectsInput = New TableRow
    oColcostProjectsInput = New TableCell
    oColcostProjectsInput.Text = "Remarks"
    oColcostProjectsInput.Font.Bold = True
    oRowcostProjectsInput.Cells.Add(oColcostProjectsInput)
    oColcostProjectsInput = New TableCell
    oColcostProjectsInput.Text = oVar.Remarks
      oColcostProjectsInput.Style.Add("text-align","left")
    oColcostProjectsInput.ColumnSpan = "5"
    oRowcostProjectsInput.Cells.Add(oColcostProjectsInput)
    oTblcostProjectsInput.Rows.Add(oRowcostProjectsInput)
    oRowcostProjectsInput = New TableRow
    oColcostProjectsInput = New TableCell
    oColcostProjectsInput.Text = "Created By"
    oColcostProjectsInput.Font.Bold = True
    oRowcostProjectsInput.Cells.Add(oColcostProjectsInput)
    oColcostProjectsInput = New TableCell
    oColcostProjectsInput.Text = oVar.CreatedBy
      oColcostProjectsInput.Style.Add("text-align","left")
    oRowcostProjectsInput.Cells.Add(oColcostProjectsInput)
    oColcostProjectsInput = New TableCell
    oColcostProjectsInput.Text = oVar.aspnet_users1_UserFullName
      oColcostProjectsInput.Style.Add("text-align","left")
    oRowcostProjectsInput.Cells.Add(oColcostProjectsInput)
    oColcostProjectsInput = New TableCell
    oColcostProjectsInput.Text = "Created On"
    oColcostProjectsInput.Font.Bold = True
    oRowcostProjectsInput.Cells.Add(oColcostProjectsInput)
    oColcostProjectsInput = New TableCell
    oColcostProjectsInput.Text = oVar.CreatedOn
      oColcostProjectsInput.Style.Add("text-align","center")
    oColcostProjectsInput.ColumnSpan = "2"
    oRowcostProjectsInput.Cells.Add(oColcostProjectsInput)
    oTblcostProjectsInput.Rows.Add(oRowcostProjectsInput)
    oRowcostProjectsInput = New TableRow
    oColcostProjectsInput = New TableCell
    oColcostProjectsInput.Text = "Approver Remarks"
    oColcostProjectsInput.Font.Bold = True
    oRowcostProjectsInput.Cells.Add(oColcostProjectsInput)
    oColcostProjectsInput = New TableCell
    oColcostProjectsInput.Text = oVar.ApproverRemarks
      oColcostProjectsInput.Style.Add("text-align","left")
    oColcostProjectsInput.ColumnSpan = "5"
    oRowcostProjectsInput.Cells.Add(oColcostProjectsInput)
    oTblcostProjectsInput.Rows.Add(oRowcostProjectsInput)
    oRowcostProjectsInput = New TableRow
    oColcostProjectsInput = New TableCell
    oColcostProjectsInput.Text = "Approved By"
    oColcostProjectsInput.Font.Bold = True
    oRowcostProjectsInput.Cells.Add(oColcostProjectsInput)
    oColcostProjectsInput = New TableCell
    oColcostProjectsInput.Text = oVar.ApprovedBy
      oColcostProjectsInput.Style.Add("text-align","left")
    oRowcostProjectsInput.Cells.Add(oColcostProjectsInput)
    oColcostProjectsInput = New TableCell
    oColcostProjectsInput.Text = oVar.aspnet_users2_UserFullName
      oColcostProjectsInput.Style.Add("text-align","left")
    oRowcostProjectsInput.Cells.Add(oColcostProjectsInput)
    oColcostProjectsInput = New TableCell
    oColcostProjectsInput.Text = "Approved On"
    oColcostProjectsInput.Font.Bold = True
    oRowcostProjectsInput.Cells.Add(oColcostProjectsInput)
    oColcostProjectsInput = New TableCell
    oColcostProjectsInput.Text = oVar.ApprovedOn
      oColcostProjectsInput.Style.Add("text-align","center")
    oColcostProjectsInput.ColumnSpan = "2"
    oRowcostProjectsInput.Cells.Add(oColcostProjectsInput)
    oTblcostProjectsInput.Rows.Add(oRowcostProjectsInput)
    form1.Controls.Add(oTblcostProjectsInput)
      Dim oTblcostProjectInputFiles As Table = Nothing
      Dim oRowcostProjectInputFiles As TableRow = Nothing
      Dim oColcostProjectInputFiles As TableCell = Nothing
    Dim ocostProjectInputFiless As List(Of SIS.COST.costProjectInputFiles) = SIS.COST.costProjectInputFiles.UZ_costProjectInputFilesSelectList(0, 999, "", False, "", oVar.ProjectGroupID, oVar.FinYear, oVar.Quarter)
    If ocostProjectInputFiless.Count > 0 Then
      oTblcostProjectInputFiles = New Table
      oTblcostProjectInputFiles.Width = 1000
      oTblcostProjectInputFiles.Style.Add("margin-top", "15px")
      oTblcostProjectInputFiles.Style.Add("margin-left", "10px")
      oTblcostProjectInputFiles.Style.Add("margin-right", "10px")
      oRowcostProjectInputFiles = New TableRow
      oColcostProjectInputFiles = New TableCell
      oColcostProjectInputFiles.Font.Bold = True
      oColcostProjectInputFiles.Font.UnderLine = True
      oColcostProjectInputFiles.Font.Size = 10
      oColcostProjectInputFiles.CssClass = "grpHD"
      oColcostProjectInputFiles.Text = "Project Input Attachment"
      oRowcostProjectInputFiles.Cells.Add(oColcostProjectInputFiles)
      oTblcostProjectInputFiles.Rows.Add(oRowcostProjectInputFiles)
      form1.Controls.Add(oTblcostProjectInputFiles)
      oTblcostProjectInputFiles = New Table
      oTblcostProjectInputFiles.Width = 1000
      oTblcostProjectInputFiles.GridLines = GridLines.Both
      oTblcostProjectInputFiles.Style.Add("margin-left", "10px")
      oTblcostProjectInputFiles.Style.Add("margin-right", "10px")
      oRowcostProjectInputFiles = New TableRow
      oColcostProjectInputFiles = New TableCell
      oColcostProjectInputFiles.Text = "Project Group ID"
      oColcostProjectInputFiles.Font.Bold = True
      oColcostProjectInputFiles.CssClass = "colHD"
      oColcostProjectInputFiles.Style.Add("text-align","right")
      oRowcostProjectInputFiles.Cells.Add(oColcostProjectInputFiles)
      oColcostProjectInputFiles = New TableCell
      oColcostProjectInputFiles.Text = "Fin Year"
      oColcostProjectInputFiles.Font.Bold = True
      oColcostProjectInputFiles.CssClass = "colHD"
      oColcostProjectInputFiles.Style.Add("text-align","right")
      oRowcostProjectInputFiles.Cells.Add(oColcostProjectInputFiles)
      oColcostProjectInputFiles = New TableCell
      oColcostProjectInputFiles.Text = "Quarter"
      oColcostProjectInputFiles.Font.Bold = True
      oColcostProjectInputFiles.CssClass = "colHD"
      oColcostProjectInputFiles.Style.Add("text-align","right")
      oRowcostProjectInputFiles.Cells.Add(oColcostProjectInputFiles)
      oColcostProjectInputFiles = New TableCell
      oColcostProjectInputFiles.Text = "Serial No"
      oColcostProjectInputFiles.Font.Bold = True
      oColcostProjectInputFiles.CssClass = "colHD"
      oColcostProjectInputFiles.Style.Add("text-align","right")
      oRowcostProjectInputFiles.Cells.Add(oColcostProjectInputFiles)
      oColcostProjectInputFiles = New TableCell
      oColcostProjectInputFiles.Text = "Description"
      oColcostProjectInputFiles.Font.Bold = True
      oColcostProjectInputFiles.CssClass = "colHD"
      oColcostProjectInputFiles.Style.Add("text-align","left")
      oRowcostProjectInputFiles.Cells.Add(oColcostProjectInputFiles)
      oColcostProjectInputFiles = New TableCell
      oColcostProjectInputFiles.Text = "File Name"
      oColcostProjectInputFiles.Font.Bold = True
      oColcostProjectInputFiles.CssClass = "colHD"
      oColcostProjectInputFiles.Style.Add("text-align","left")
      oRowcostProjectInputFiles.Cells.Add(oColcostProjectInputFiles)
      oColcostProjectInputFiles = New TableCell
      oColcostProjectInputFiles.Text = "Disk File"
      oColcostProjectInputFiles.Font.Bold = True
      oColcostProjectInputFiles.CssClass = "colHD"
      oColcostProjectInputFiles.Style.Add("text-align","left")
      oRowcostProjectInputFiles.Cells.Add(oColcostProjectInputFiles)
      oTblcostProjectInputFiles.Rows.Add(oRowcostProjectInputFiles)
      For Each ocostProjectInputFiles As SIS.COST.costProjectInputFiles In ocostProjectInputFiless
        oRowcostProjectInputFiles = New TableRow
        oColcostProjectInputFiles = New TableCell
        oColcostProjectInputFiles.Text = ocostProjectInputFiles.COST_ProjectGroups2_ProjectGroupDescription
        oColcostProjectInputFiles.CssClass = "rowHD"
      oColcostProjectInputFiles.Style.Add("text-align","right")
        oRowcostProjectInputFiles.Cells.Add(oColcostProjectInputFiles)
        oColcostProjectInputFiles = New TableCell
        oColcostProjectInputFiles.Text = ocostProjectInputFiles.COST_FinYear1_Descpription
        oColcostProjectInputFiles.CssClass = "rowHD"
      oColcostProjectInputFiles.Style.Add("text-align","right")
        oRowcostProjectInputFiles.Cells.Add(oColcostProjectInputFiles)
        oColcostProjectInputFiles = New TableCell
        oColcostProjectInputFiles.Text = ocostProjectInputFiles.COST_ProjectsInput3_GroupOrderValueINR
        oColcostProjectInputFiles.CssClass = "rowHD"
      oColcostProjectInputFiles.Style.Add("text-align","right")
        oRowcostProjectInputFiles.Cells.Add(oColcostProjectInputFiles)
        oColcostProjectInputFiles = New TableCell
        oColcostProjectInputFiles.CssClass = "rowHD"
        oColcostProjectInputFiles.Text = ocostProjectInputFiles.SerialNo
      oColcostProjectInputFiles.Style.Add("text-align","right")
        oRowcostProjectInputFiles.Cells.Add(oColcostProjectInputFiles)
        oColcostProjectInputFiles = New TableCell
        oColcostProjectInputFiles.CssClass = "rowHD"
        oColcostProjectInputFiles.Text = ocostProjectInputFiles.Description
      oColcostProjectInputFiles.Style.Add("text-align","left")
        oRowcostProjectInputFiles.Cells.Add(oColcostProjectInputFiles)
        oColcostProjectInputFiles = New TableCell
        oColcostProjectInputFiles.CssClass = "rowHD"
        oColcostProjectInputFiles.Text = ocostProjectInputFiles.FileName
      oColcostProjectInputFiles.Style.Add("text-align","left")
        oRowcostProjectInputFiles.Cells.Add(oColcostProjectInputFiles)
        oColcostProjectInputFiles = New TableCell
        oColcostProjectInputFiles.CssClass = "rowHD"
        oColcostProjectInputFiles.Text = ocostProjectInputFiles.DiskFile
      oColcostProjectInputFiles.Style.Add("text-align","left")
        oRowcostProjectInputFiles.Cells.Add(oColcostProjectInputFiles)
        oTblcostProjectInputFiles.Rows.Add(oRowcostProjectInputFiles)
      Next
      form1.Controls.Add(oTblcostProjectInputFiles)
    End If
  End Sub
End Class
