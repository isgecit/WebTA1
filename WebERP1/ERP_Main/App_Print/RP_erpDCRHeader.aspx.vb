Partial Class RP_erpDCRHeader
  Inherits System.Web.UI.Page
  Private _InfoUrl As String = "~/ERP_Main/App_Display/DF_erpDCRHeader.aspx"
  Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _InfoUrl  & "?DCRNo=" & aVal(0)
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    Dim aVal() As String = Request.QueryString("pk").Split("|".ToCharArray)
		Dim DCRNo As String = CType(aVal(0),String)
		Dim oVar As SIS.ERP.erpDCRHeader = SIS.ERP.erpDCRHeader.erpDCRHeaderGetByID(DCRNo)
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
    oCol.Text = ""
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "DCRDate"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.DCRDate
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = ""
    oRow.Cells.Add(oCol)
    oTbl.Rows.Add(oRow)
    oRow = New TableRow
    oCol = New TableCell
    oCol.Text = "DCRDescription"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.DCRDescription
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = ""
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "CreatedBy"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.CreatedBy
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = ""
    oRow.Cells.Add(oCol)
    oTbl.Rows.Add(oRow)
    oRow = New TableRow
    oCol = New TableCell
    oCol.Text = "CreatedName"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.CreatedName
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = ""
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "CreatedEMail"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.CreatedEMail
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = ""
    oRow.Cells.Add(oCol)
    oTbl.Rows.Add(oRow)
    oRow = New TableRow
    oCol = New TableCell
    oCol.Text = "ProjectID"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.ProjectID
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = ""
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "ProjectDescription"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.ProjectDescription
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = ""
    oRow.Cells.Add(oCol)
    oTbl.Rows.Add(oRow)
    oRow = New TableRow
    form1.Controls.Add(oTbl)
    Dim oerpDCRDetails As List(Of SIS.ERP.erpDCRDetail) = SIS.ERP.erpDCRDetail.erpDCRDetailSelectList(0, 999, "", False, "", DCRNo)
    oTbl = New Table
    oTbl.GridLines = GridLines.Both
    oRow = New TableRow
    oCol = New TableCell
    oCol.Text = "DCRNo"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "DCRDescription"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "DocumentID"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "RevisionNo"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "IndentNo"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "IndentLine"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "LotItem"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "ItemDescription"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "IndenterID"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "BuyerID"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "OrderNo"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "OrderLine"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "SupplierID"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "BuyerIDinPO"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "IndenterName"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "IndenterEMail"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "BuyerName"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "BuyerEMail"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "BuyerIDinPOName"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "BuyerIDinPOEMail"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "SupplierName"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "DocumentTitle"
    oRow.Cells.Add(oCol)
    oTbl.Rows.Add(oRow)
    For Each oerpDCRDetail As SIS.ERP.erpDCRDetail In oerpDCRDetails
      oRow = New TableRow
      oCol = New TableCell
      oCol.Text = oerpDCRDetail.DCRNo
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = oerpDCRDetail.ERP_DCRHeader1_DCRDescription
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = oerpDCRDetail.DocumentID
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = oerpDCRDetail.RevisionNo
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = oerpDCRDetail.IndentNo
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = oerpDCRDetail.IndentLine
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = oerpDCRDetail.LotItem
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = oerpDCRDetail.ItemDescription
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = oerpDCRDetail.IndenterID
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = oerpDCRDetail.BuyerID
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = oerpDCRDetail.OrderNo
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = oerpDCRDetail.OrderLine
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = oerpDCRDetail.SupplierID
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = oerpDCRDetail.BuyerIDinPO
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = oerpDCRDetail.IndenterName
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = oerpDCRDetail.IndenterEMail
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = oerpDCRDetail.BuyerName
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = oerpDCRDetail.BuyerEMail
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = oerpDCRDetail.BuyerIDinPOName
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = oerpDCRDetail.BuyerIDinPOEMail
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = oerpDCRDetail.SupplierName
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = oerpDCRDetail.DocumentTitle
      oRow.Cells.Add(oCol)
      oTbl.Rows.Add(oRow)
    Next
    form1.Controls.Add(oTbl)
  End Sub
End Class
