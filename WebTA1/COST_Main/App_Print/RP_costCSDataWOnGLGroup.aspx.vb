Partial Class RP_costCSDataWOnGLGroup
  Inherits System.Web.UI.Page
  Private _InfoUrl As String = "~/COST_Main/App_Display/DF_costCSDataWOnGLGroup.aspx"
  Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _InfoUrl  & "?ProjectGroupID=" & aVal(0) & "&FinYear=" & aVal(1) & "&Quarter=" & aVal(2) & "&Revision=" & aVal(3) & "&WorkOrderTypeID=" & aVal(4) & "&GLGroupID=" & aVal(5)
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    Dim aVal() As String = Request.QueryString("pk").Split("|".ToCharArray)
    Dim ProjectGroupID As Int32 = CType(aVal(0),Int32)
    Dim FinYear As Int32 = CType(aVal(1),Int32)
    Dim Quarter As Int32 = CType(aVal(2),Int32)
    Dim Revision As Int32 = CType(aVal(3),Int32)
    Dim WorkOrderTypeID As Int32 = CType(aVal(4),Int32)
    Dim GLGroupID As Int32 = CType(aVal(5),Int32)
    Dim oVar As SIS.COST.costCSDataWOnGLGroup = SIS.COST.costCSDataWOnGLGroup.costCSDataWOnGLGroupGetByID(ProjectGroupID,FinYear,Quarter,Revision,WorkOrderTypeID,GLGroupID)
    Dim oTblcostCSDataWOnGLGroup As New Table
    oTblcostCSDataWOnGLGroup.Width = 1000
    oTblcostCSDataWOnGLGroup.GridLines = GridLines.Both
    oTblcostCSDataWOnGLGroup.Style.Add("margin-top", "15px")
    oTblcostCSDataWOnGLGroup.Style.Add("margin-left", "10px")
    Dim oColcostCSDataWOnGLGroup As TableCell = Nothing
    Dim oRowcostCSDataWOnGLGroup As TableRow = Nothing
    oRowcostCSDataWOnGLGroup = New TableRow
    oColcostCSDataWOnGLGroup = New TableCell
    oColcostCSDataWOnGLGroup.Text = "Project Group ID"
    oColcostCSDataWOnGLGroup.Font.Bold = True
    oRowcostCSDataWOnGLGroup.Cells.Add(oColcostCSDataWOnGLGroup)
    oColcostCSDataWOnGLGroup = New TableCell
    oColcostCSDataWOnGLGroup.Text = oVar.ProjectGroupID
      oColcostCSDataWOnGLGroup.Style.Add("text-align","right")
    oRowcostCSDataWOnGLGroup.Cells.Add(oColcostCSDataWOnGLGroup)
    oColcostCSDataWOnGLGroup = New TableCell
    oColcostCSDataWOnGLGroup.Text = oVar.COST_ProjectGroups4_ProjectGroupDescription
      oColcostCSDataWOnGLGroup.Style.Add("text-align","right")
    oRowcostCSDataWOnGLGroup.Cells.Add(oColcostCSDataWOnGLGroup)
    oColcostCSDataWOnGLGroup = New TableCell
    oColcostCSDataWOnGLGroup.Text = "Fin.Year"
    oColcostCSDataWOnGLGroup.Font.Bold = True
    oRowcostCSDataWOnGLGroup.Cells.Add(oColcostCSDataWOnGLGroup)
    oColcostCSDataWOnGLGroup = New TableCell
    oColcostCSDataWOnGLGroup.Text = oVar.FinYear
      oColcostCSDataWOnGLGroup.Style.Add("text-align","right")
    oRowcostCSDataWOnGLGroup.Cells.Add(oColcostCSDataWOnGLGroup)
    oColcostCSDataWOnGLGroup = New TableCell
    oColcostCSDataWOnGLGroup.Text = oVar.COST_FinYear2_Descpription
      oColcostCSDataWOnGLGroup.Style.Add("text-align","right")
    oRowcostCSDataWOnGLGroup.Cells.Add(oColcostCSDataWOnGLGroup)
    oTblcostCSDataWOnGLGroup.Rows.Add(oRowcostCSDataWOnGLGroup)
    form1.Controls.Add(oTblcostCSDataWOnGLGroup)
  End Sub
End Class
