Partial Class RP_elogDetentionBill
  Inherits System.Web.UI.Page
  Private _InfoUrl As String = "~/ELOG_Main/App_Display/DF_elogDetentionBill.aspx"
  Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _InfoUrl  & "?IRNo=" & aVal(0)
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    Dim aVal() As String = Request.QueryString("pk").Split("|".ToCharArray)
    Dim IRNo As Int32 = CType(aVal(0),Int32)
    Dim oVar As SIS.ELOG.elogDetentionBill = SIS.ELOG.elogDetentionBill.elogDetentionBillGetByID(IRNo)
    Dim oTblelogDetentionBill As New Table
    oTblelogDetentionBill.Width = 1000
    oTblelogDetentionBill.GridLines = GridLines.Both
    oTblelogDetentionBill.Style.Add("margin-top", "15px")
    oTblelogDetentionBill.Style.Add("margin-left", "10px")
    Dim oColelogDetentionBill As TableCell = Nothing
    Dim oRowelogDetentionBill As TableRow = Nothing
    oRowelogDetentionBill = New TableRow
    oColelogDetentionBill = New TableCell
    oColelogDetentionBill.Text = "IR No"
    oColelogDetentionBill.Font.Bold = True
    oRowelogDetentionBill.Cells.Add(oColelogDetentionBill)
    oColelogDetentionBill = New TableCell
    oColelogDetentionBill.Text = oVar.IRNo
      oColelogDetentionBill.Style.Add("text-align","right")
    oColelogDetentionBill.ColumnSpan = "2"
    oRowelogDetentionBill.Cells.Add(oColelogDetentionBill)
    oColelogDetentionBill = New TableCell
    oColelogDetentionBill.Text = "IR Date"
    oColelogDetentionBill.Font.Bold = True
    oRowelogDetentionBill.Cells.Add(oColelogDetentionBill)
    oColelogDetentionBill = New TableCell
    oColelogDetentionBill.Text = oVar.IRDate
      oColelogDetentionBill.Style.Add("text-align","center")
    oColelogDetentionBill.ColumnSpan = "2"
    oRowelogDetentionBill.Cells.Add(oColelogDetentionBill)
    oTblelogDetentionBill.Rows.Add(oRowelogDetentionBill)
    form1.Controls.Add(oTblelogDetentionBill)
  End Sub
End Class
