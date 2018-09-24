Partial Class RP_erpDCRDetail
  Inherits System.Web.UI.Page
  Private _InfoUrl As String = "~/ERP_Main/App_Display/DF_erpDCRDetail.aspx"
  Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _InfoUrl  & "?DCRNo=" & aVal(0) & "&DocumentID=" & aVal(1) & "&RevisionNo=" & aVal(2)
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    Dim aVal() As String = Request.QueryString("pk").Split("|".ToCharArray)
		Dim DCRNo As String = CType(aVal(0),String)
		Dim DocumentID As String = CType(aVal(1),String)
		Dim RevisionNo As String = CType(aVal(2),String)
		Dim oVar As SIS.ERP.erpDCRDetail = SIS.ERP.erpDCRDetail.erpDCRDetailGetByID(DCRNo,DocumentID,RevisionNo)
    Dim oTbl As New Table
    oTbl.Width = 1000
    Dim oCol As TableCell = Nothing
    Dim oRow As TableRow = Nothing
    oRow = New TableRow
    oCol = New TableCell
    oCol.Text = "DCRNo"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.DCRNo
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.ERP_DCRHeader1_DCRDescription
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "DocumentID"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.DocumentID
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = ""
    oRow.Cells.Add(oCol)
    oTbl.Rows.Add(oRow)
    oRow = New TableRow
    oCol = New TableCell
    oCol.Text = "RevisionNo"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.RevisionNo
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = ""
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "IndentNo"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.IndentNo
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = ""
    oRow.Cells.Add(oCol)
    oTbl.Rows.Add(oRow)
    oRow = New TableRow
    oCol = New TableCell
    oCol.Text = "IndentLine"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.IndentLine
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = ""
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "LotItem"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.LotItem
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = ""
    oRow.Cells.Add(oCol)
    oTbl.Rows.Add(oRow)
    oRow = New TableRow
    oCol = New TableCell
    oCol.Text = "ItemDescription"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.ItemDescription
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = ""
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "IndenterID"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.IndenterID
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = ""
    oRow.Cells.Add(oCol)
    oTbl.Rows.Add(oRow)
    oRow = New TableRow
    oCol = New TableCell
    oCol.Text = "BuyerID"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.BuyerID
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = ""
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "OrderNo"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.OrderNo
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = ""
    oRow.Cells.Add(oCol)
    oTbl.Rows.Add(oRow)
    oRow = New TableRow
    oCol = New TableCell
    oCol.Text = "OrderLine"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.OrderLine
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = ""
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "SupplierID"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.SupplierID
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = ""
    oRow.Cells.Add(oCol)
    oTbl.Rows.Add(oRow)
    oRow = New TableRow
    oCol = New TableCell
    oCol.Text = "BuyerIDinPO"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.BuyerIDinPO
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = ""
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "IndenterName"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.IndenterName
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = ""
    oRow.Cells.Add(oCol)
    oTbl.Rows.Add(oRow)
    oRow = New TableRow
    oCol = New TableCell
    oCol.Text = "IndenterEMail"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.IndenterEMail
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = ""
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "BuyerName"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.BuyerName
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = ""
    oRow.Cells.Add(oCol)
    oTbl.Rows.Add(oRow)
    oRow = New TableRow
    oCol = New TableCell
    oCol.Text = "BuyerEMail"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.BuyerEMail
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = ""
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "BuyerIDinPOName"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.BuyerIDinPOName
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = ""
    oRow.Cells.Add(oCol)
    oTbl.Rows.Add(oRow)
    oRow = New TableRow
    oCol = New TableCell
    oCol.Text = "BuyerIDinPOEMail"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.BuyerIDinPOEMail
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = ""
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "SupplierName"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.SupplierName
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = ""
    oRow.Cells.Add(oCol)
    oTbl.Rows.Add(oRow)
    oRow = New TableRow
    oCol = New TableCell
    oCol.Text = "DocumentTitle"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.DocumentTitle
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = ""
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = ""
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = ""
    oRow.Cells.Add(oCol)
    oTbl.Rows.Add(oRow)
    form1.Controls.Add(oTbl)
  End Sub
End Class
