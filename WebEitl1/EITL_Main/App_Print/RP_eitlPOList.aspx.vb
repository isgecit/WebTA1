Partial Class RP_eitlPOList
  Inherits System.Web.UI.Page
  Private tblWidth As Integer = 900
  Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    Dim aVal() As String = Request.QueryString("pk").Split("|".ToCharArray)
    Dim SerialNo As Int32 = CType(aVal(0), Int32)
    Dim oVar As SIS.EITL.eitlPOList = SIS.EITL.eitlPOList.eitlPOListGetByID(SerialNo)

    Dim oTbl As Table
    Dim oCol As TableCell = Nothing
    Dim oRow As TableRow = Nothing
    oTbl = New Table
    oTbl.Width = tblWidth
    oTbl.Style("margin") = "10px 10px 10px 10px"
    oRow = New TableRow
    oCol = New TableCell
    Dim img As New Image
    img.ImageUrl = "~/App_Themes/Default/Images/reportLogo.png"
    oCol.Controls.Add(img)
    oCol.Style("text-align") = "Center"
    oCol.Width = 100
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "PURCHASE ORDER DETAILS"
    oCol.Font.Size = 18
    oCol.Font.Bold = True
    oCol.Style("text-align") = "Center"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = " "
    oCol.Width = 100
    oRow.Cells.Add(oCol)
    oTbl.Rows.Add(oRow)
    form1.Controls.Add(oTbl)

first:
    oTbl = New Table
    oTbl.Width = tblWidth
    oTbl.BorderStyle = BorderStyle.Solid
    oTbl.BorderColor = Drawing.Color.Black
    oTbl.BorderWidth = 2
    oRow = New TableRow
    oCol = New TableCell
    oCol.Text = "Serial No"
    oCol.Font.Bold = True
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.SerialNo
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = ""
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "PO Number"
    oCol.Font.Bold = True
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.PONumber
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = ""
    oRow.Cells.Add(oCol)
    oTbl.Rows.Add(oRow)
    oRow = New TableRow
    oCol = New TableCell
    oCol.Text = "PO Revision"
    oCol.Font.Bold = True
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.PORevision
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = ""
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "PO Date"
    oCol.Font.Bold = True
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.PODate
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = ""
    oRow.Cells.Add(oCol)
    oTbl.Rows.Add(oRow)
    oRow = New TableRow
    oCol = New TableCell
    oCol.Text = "Supplier"
    oCol.Font.Bold = True
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.SupplierID
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.EITL_Suppliers5_SupplierName
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Project"
    oCol.Font.Bold = True
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.ProjectID
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.IDM_Projects6_Description
    oRow.Cells.Add(oCol)
    oTbl.Rows.Add(oRow)
    oRow = New TableRow
    oCol = New TableCell
    oCol.Text = "Division"
    oCol.Font.Bold = True
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.DivisionID
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = ""
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Buyer"
    oCol.Font.Bold = True
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.BuyerID
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.aspnet_Users1_UserFullName
    oRow.Cells.Add(oCol)
    oTbl.Rows.Add(oRow)
    oRow = New TableRow
    oCol = New TableCell
    oCol.Text = "POStatus"
    oCol.Font.Bold = True
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.POStatusID
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.EITL_POStatus4_Description
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Issued By"
    oCol.Font.Bold = True
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.IssuedBy
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.aspnet_Users3_UserFullName
    oRow.Cells.Add(oCol)
    oTbl.Rows.Add(oRow)
    oRow = New TableRow
    oCol = New TableCell
    oCol.Text = "Issued On"
    oCol.Font.Bold = True
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.IssuedOn
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = ""
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Closed By"
    oCol.Font.Bold = True
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.ClosedBy
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.aspnet_Users2_UserFullName
    oRow.Cells.Add(oCol)
    oTbl.Rows.Add(oRow)
    oRow = New TableRow
    oCol = New TableCell
    oCol.Text = "Closed On"
    oCol.Font.Bold = True
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.ClosedOn
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
    Dim oeitlPOItemLists As List(Of SIS.EITL.eitlPOItemList) = SIS.EITL.eitlPOItemList.eitlPOItemListSelectList(0, 9999, "", False, "", SerialNo)
second:
    oTbl = New Table
    oTbl.Width = tblWidth
    oTbl.Style("margin-top") = "10px"
    oTbl.GridLines = GridLines.Both
    oRow = New TableRow
    oRow.CssClass = "tblHd"
    'oCol = New TableCell
    'oCol.Text = "Serial No"
    'oRow.Cells.Add(oCol)
    'oCol = New TableCell
    'oCol.Text = "PO Number"
    'oRow.Cells.Add(oCol)
    'oCol = New TableCell
    'oCol.Text = "Item Line No"
    'oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Item Code"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Description"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "UOM"
    oRow.Cells.Add(oCol)
    'oCol = New TableCell
    'oCol.Text = "Description"
    'oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Quantity"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Weight In KG"
    oRow.Cells.Add(oCol)
    'oCol = New TableCell
    'oCol.Text = "Document Line No"
    'oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Document ID"
    oRow.Cells.Add(oCol)
    'oCol = New TableCell
    'oCol.Text = "Ready To Despatch"
    'oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Despatched"
    oRow.Cells.Add(oCol)
    'oCol = New TableCell
    'oCol.Text = "VR Execution No"
    'oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Despatch Date"
    oRow.Cells.Add(oCol)
    'oCol = New TableCell
    'oCol.Text = "Quantity Receipt"
    'oRow.Cells.Add(oCol)
    'oCol = New TableCell
    'oCol.Text = "Weight In KG Receipt"
    'oRow.Cells.Add(oCol)
    'oCol = New TableCell
    'oCol.Text = "Material State"
    'oRow.Cells.Add(oCol)
    'oCol = New TableCell
    'oCol.Text = "Description"
    'oRow.Cells.Add(oCol)
    'oCol = New TableCell
    'oCol.Text = "Received By"
    'oRow.Cells.Add(oCol)
    'oCol = New TableCell
    'oCol.Text = "User Name"
    'oRow.Cells.Add(oCol)
    'oCol = New TableCell
    'oCol.Text = "Received On"
    'oRow.Cells.Add(oCol)
    'oCol = New TableCell
    'oCol.Text = "Item Status"
    'oRow.Cells.Add(oCol)
    'oCol = New TableCell
    'oCol.Text = "Description"
    'oRow.Cells.Add(oCol)
    oTbl.Rows.Add(oRow)
    For Each oeitlPOItemList As SIS.EITL.eitlPOItemList In oeitlPOItemLists
      oRow = New TableRow
      'oCol = New TableCell
      'oCol.Text = oeitlPOItemList.SerialNo
      'oRow.Cells.Add(oCol)
      'oCol = New TableCell
      'oCol.Text = oeitlPOItemList.EITL_POList5_PONumber
      'oRow.Cells.Add(oCol)
      'oCol = New TableCell
      'oCol.Text = oeitlPOItemList.ItemLineNo
      'oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = oeitlPOItemList.ItemCode
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = oeitlPOItemList.Description
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = oeitlPOItemList.UOM
      oRow.Cells.Add(oCol)
      'oCol = New TableCell
      'oCol.Text = oeitlPOItemList.EITL_Units6_Description
      'oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = oeitlPOItemList.Quantity
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = oeitlPOItemList.WeightInKG
      oRow.Cells.Add(oCol)
      'oCol = New TableCell
      'oCol.Text = oeitlPOItemList.DocumentLineNo
      'oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = oeitlPOItemList.EITL_PODocumentList3_DocumentID
      oRow.Cells.Add(oCol)
      'oCol = New TableCell
      'oCol.Text = IIf(oeitlPOItemList.ReadyToDespatch, "YES", "NO")
      'oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = IIf(oeitlPOItemList.Despatched, "YES", "NO")
      oRow.Cells.Add(oCol)
      'oCol = New TableCell
      'oCol.Text = oeitlPOItemList.VR_ExecutionNo
      'oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = oeitlPOItemList.DespatchDate
      oRow.Cells.Add(oCol)
      'oCol = New TableCell
      'oCol.Text = oeitlPOItemList.QuantityReceipt
      'oRow.Cells.Add(oCol)
      'oCol = New TableCell
      'oCol.Text = oeitlPOItemList.WeightInKGReceipt
      'oRow.Cells.Add(oCol)
      'oCol = New TableCell
      'oCol.Text = oeitlPOItemList.MaterialStateID
      'oRow.Cells.Add(oCol)
      'oCol = New TableCell
      'oCol.Text = oeitlPOItemList.EITL_MaterialState2_Description
      'oRow.Cells.Add(oCol)
      'oCol = New TableCell
      'oCol.Text = oeitlPOItemList.ReceivedBy
      'oRow.Cells.Add(oCol)
      'oCol = New TableCell
      'oCol.Text = oeitlPOItemList.aspnet_Users1_UserFullName
      'oRow.Cells.Add(oCol)
      'oCol = New TableCell
      'oCol.Text = oeitlPOItemList.ReceivedOn
      'oRow.Cells.Add(oCol)
      'oCol = New TableCell
      'oCol.Text = oeitlPOItemList.ItemStatusID
      'oRow.Cells.Add(oCol)
      'oCol = New TableCell
      'oCol.Text = oeitlPOItemList.EITL_POItemStatus4_Description
      'oRow.Cells.Add(oCol)
      oTbl.Rows.Add(oRow)
    Next
    form1.Controls.Add(oTbl)
    Dim oeitlPODocumentLists As List(Of SIS.EITL.eitlPODocumentList) = SIS.EITL.eitlPODocumentList.eitlPODocumentListSelectList(0, 999, "", False, "", SerialNo)
Third:
    oTbl = New Table
    oTbl.Width = tblWidth
    oTbl.Style("margin-top") = "10px"
    oTbl.GridLines = GridLines.Both
    oRow = New TableRow
    oRow.CssClass = "tblHd"
    'oCol = New TableCell
    'oCol.Text = "Serial No"
    'oRow.Cells.Add(oCol)
    'oCol = New TableCell
    'oCol.Text = "Document Line No"
    'oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Document ID"
    oCol.Width = 300
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Revision No"
    oCol.Width = 100
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Description"
    oCol.Width = 450
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "File Attached"
    oCol.Width = 50
    oRow.Cells.Add(oCol)
    oTbl.Rows.Add(oRow)
    For Each oeitlPODocumentList As SIS.EITL.eitlPODocumentList In oeitlPODocumentLists
      oRow = New TableRow
      'oCol = New TableCell
      'oCol.Text = oeitlPODocumentList.SerialNo
      'oRow.Cells.Add(oCol)
      'oCol = New TableCell
      'oCol.Text = oeitlPODocumentList.DocumentLineNo
      'oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = oeitlPODocumentList.DocumentID
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = oeitlPODocumentList.RevisionNo
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = oeitlPODocumentList.Description
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      Dim oFiles As List(Of SIS.EITL.eitlPODocumentFile) = SIS.EITL.eitlPODocumentFile.eitlPODocumentFileSelectList(0, 1, "", False, "", oeitlPODocumentList.SerialNo, oeitlPODocumentList.DocumentLineNo)
      If oFiles.Count > 0 Then
        If oFiles(0).DiskFile <> String.Empty Then
          oCol.Text = "YES"
        Else
          oCol.Text = "NO"
        End If
      Else
        oCol.Text = "NO"
      End If
      oRow.Cells.Add(oCol)
      oTbl.Rows.Add(oRow)
    Next
    form1.Controls.Add(oTbl)
  End Sub
End Class
