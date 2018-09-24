Partial Class RP_eitlPOItemList
  Inherits System.Web.UI.Page
  Private _InfoUrl As String = "~/EITL_Main/App_Display/DF_eitlPOItemList.aspx"
  Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _InfoUrl  & "?SerialNo=" & aVal(0) & "&ItemLineNo=" & aVal(1)
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    Dim aVal() As String = Request.QueryString("pk").Split("|".ToCharArray)
		Dim SerialNo As Int32 = CType(aVal(0),Int32)
		Dim ItemLineNo As Int32 = CType(aVal(1),Int32)
		Dim oVar As SIS.EITL.eitlPOItemList = SIS.EITL.eitlPOItemList.eitlPOItemListGetByID(SerialNo,ItemLineNo)
    Dim oTbl As New Table
    oTbl.Width = 1000
    Dim oCol As TableCell = Nothing
    Dim oRow As TableRow = Nothing
    oRow = New TableRow
    oCol = New TableCell
    oCol.Text = "Serial No"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.SerialNo
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.EITL_POList5_PONumber
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Item Line No"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.ItemLineNo
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = ""
    oRow.Cells.Add(oCol)
    oTbl.Rows.Add(oRow)
    oRow = New TableRow
    oCol = New TableCell
    oCol.Text = "Item Code"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.ItemCode
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
    oCol = New TableCell
    oCol.Text = "UOM"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.UOM
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.EITL_Units6_Description
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Quantity"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.Quantity
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = ""
    oRow.Cells.Add(oCol)
    oTbl.Rows.Add(oRow)
    oRow = New TableRow
    oCol = New TableCell
    oCol.Text = "Weight In KG"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.WeightInKG
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = ""
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Document Line No"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.DocumentLineNo
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.EITL_PODocumentList3_DocumentID
    oRow.Cells.Add(oCol)
    oTbl.Rows.Add(oRow)
    oRow = New TableRow
    oCol = New TableCell
    oCol.Text = "Ready To Despatch"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = IIf(oVar.ReadyToDespatch, "YES", "NO")
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = ""
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Despatched"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = IIf(oVar.Despatched, "YES", "NO")
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = ""
    oRow.Cells.Add(oCol)
    oTbl.Rows.Add(oRow)
    oRow = New TableRow
    oCol = New TableCell
    oCol.Text = "VR Execution No"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.VR_ExecutionNo
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = ""
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Despatch Date"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.DespatchDate
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = ""
    oRow.Cells.Add(oCol)
    oTbl.Rows.Add(oRow)
    oRow = New TableRow
    oCol = New TableCell
    oCol.Text = "Quantity Receipt"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.QuantityReceipt
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = ""
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Weight In KG Receipt"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.WeightInKGReceipt
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = ""
    oRow.Cells.Add(oCol)
    oTbl.Rows.Add(oRow)
    oRow = New TableRow
    oCol = New TableCell
    oCol.Text = "Material State"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.MaterialStateID
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.EITL_MaterialState2_Description
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Received By"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.ReceivedBy
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.aspnet_Users1_UserFullName
    oRow.Cells.Add(oCol)
    oTbl.Rows.Add(oRow)
    oRow = New TableRow
    oCol = New TableCell
    oCol.Text = "Received On"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.ReceivedOn
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = ""
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Item Status"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.ItemStatusID
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.EITL_POItemStatus4_Description
    oRow.Cells.Add(oCol)
    oTbl.Rows.Add(oRow)
    oRow = New TableRow
    form1.Controls.Add(oTbl)
  End Sub
End Class
