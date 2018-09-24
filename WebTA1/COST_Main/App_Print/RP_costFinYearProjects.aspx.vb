Partial Class RP_costFinYearProjects
  Inherits System.Web.UI.Page
  Private _InfoUrl As String = "~/COST_Main/App_Display/DF_costFinYearProjects.aspx"
  Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _InfoUrl  & "?FinYear=" & aVal(0) & "&Quarter=" & aVal(1) & "&ProjectID=" & aVal(2)
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    Dim aVal() As String = Request.QueryString("pk").Split("|".ToCharArray)
    Dim FinYear As Int32 = CType(aVal(0),Int32)
    Dim Quarter As Int32 = CType(aVal(1),Int32)
    Dim ProjectID As String = CType(aVal(2),String)
    Dim oVar As SIS.COST.costFinYearProjects = SIS.COST.costFinYearProjects.costFinYearProjectsGetByID(FinYear,Quarter,ProjectID)
    Dim oTblcostFinYearProjects As New Table
    oTblcostFinYearProjects.Width = 1000
    oTblcostFinYearProjects.GridLines = GridLines.Both
    oTblcostFinYearProjects.Style.Add("margin-top", "15px")
    oTblcostFinYearProjects.Style.Add("margin-left", "10px")
    Dim oColcostFinYearProjects As TableCell = Nothing
    Dim oRowcostFinYearProjects As TableRow = Nothing
    oRowcostFinYearProjects = New TableRow
    oColcostFinYearProjects = New TableCell
    oColcostFinYearProjects.Text = "Fin. Year"
    oColcostFinYearProjects.Font.Bold = True
    oRowcostFinYearProjects.Cells.Add(oColcostFinYearProjects)
    oColcostFinYearProjects = New TableCell
    oColcostFinYearProjects.Text = oVar.FinYear
      oColcostFinYearProjects.Style.Add("text-align","right")
    oRowcostFinYearProjects.Cells.Add(oColcostFinYearProjects)
    oColcostFinYearProjects = New TableCell
    oColcostFinYearProjects.Text = oVar.COST_FinYear1_Descpription
      oColcostFinYearProjects.Style.Add("text-align","right")
    oRowcostFinYearProjects.Cells.Add(oColcostFinYearProjects)
    oColcostFinYearProjects = New TableCell
    oColcostFinYearProjects.Text = "Quarter"
    oColcostFinYearProjects.Font.Bold = True
    oRowcostFinYearProjects.Cells.Add(oColcostFinYearProjects)
    oColcostFinYearProjects = New TableCell
    oColcostFinYearProjects.Text = oVar.Quarter
      oColcostFinYearProjects.Style.Add("text-align","right")
    oRowcostFinYearProjects.Cells.Add(oColcostFinYearProjects)
    oColcostFinYearProjects = New TableCell
    oColcostFinYearProjects.Text = oVar.COST_Quarters2_Description
      oColcostFinYearProjects.Style.Add("text-align","right")
    oRowcostFinYearProjects.Cells.Add(oColcostFinYearProjects)
    oTblcostFinYearProjects.Rows.Add(oRowcostFinYearProjects)
    form1.Controls.Add(oTblcostFinYearProjects)
  End Sub
End Class
