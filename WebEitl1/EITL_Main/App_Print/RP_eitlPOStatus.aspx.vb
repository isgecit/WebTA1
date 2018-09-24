Partial Class RP_eitlPOStatus
  Inherits System.Web.UI.Page
  Private _InfoUrl As String = "~/EITL_Main/App_Display/DF_eitlPOStatus.aspx"
  Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _InfoUrl  & "?StatusID=" & aVal(0)
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    Dim aVal() As String = Request.QueryString("pk").Split("|".ToCharArray)
		Dim StatusID As Int32 = CType(aVal(0),Int32)
		Dim oVar As SIS.EITL.eitlPOStatus = SIS.EITL.eitlPOStatus.eitlPOStatusGetByID(StatusID)
    Dim oTbl As New Table
    oTbl.Width = 1000
    Dim oCol As TableCell = Nothing
    Dim oRow As TableRow = Nothing
    oRow = New TableRow
    oCol = New TableCell
    oCol.Text = "Status ID"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.StatusID
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = ""
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Description"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.Description
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = ""
    oRow.Cells.Add(oCol)
    oTbl.Rows.Add(oRow)
    oRow = New TableRow
    form1.Controls.Add(oTbl)
  End Sub
End Class
