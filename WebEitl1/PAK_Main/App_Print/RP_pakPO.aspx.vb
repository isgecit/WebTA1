Partial Class RP_pakPO
  Inherits System.Web.UI.Page
  Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    Dim aVal() As String = Request.QueryString("pk").Split("|".ToCharArray)
    Dim SerialNo As Int32 = CType(aVal(0), Int32)
    Dim BOMNo As Int32 = CType(aVal(1), Int32)

    Dim oVar As SIS.PAK.pakPO = SIS.PAK.pakPO.pakPOGetByID(SerialNo)

    Dim tmpPO As SIS.PAK.pakPO = SIS.PAK.pakPO.pakPOGetByID(SerialNo)
    Dim tmpBOM As SIS.PAK.pakPOBOM = SIS.PAK.pakPOBOM.pakPOBOMGetByID(SerialNo, BOMNo)

    Dim tmpTbl As New Table
    With tmpTbl
      .Width = 1000
      .BorderStyle = BorderStyle.None
      .Style.Add("margin-top", "15px")
      .Style.Add("margin-left", "10px")
    End With
    Dim tmpRow As New TableRow
    Dim tmpCol As New TableCell
    With tmpCol
      .Text = tmpBOM.ItemNo & " - " & tmpBOM.ItemDescription
      .Style.Add("text-align", "center")
      .Font.Size = FontUnit.Point(14)
    End With
    tmpRow.Cells.Add(tmpCol)
    tmpTbl.Rows.Add(tmpRow)
    form1.Controls.Add(tmpTbl)


    Dim oTblpakPO As New Table
    oTblpakPO.Width = 1000
    oTblpakPO.GridLines = GridLines.Both
    oTblpakPO.Style.Add("margin-top", "15px")
    oTblpakPO.Style.Add("margin-left", "10px")
    Dim oColpakPO As TableCell = Nothing
    Dim oRowpakPO As TableRow = Nothing

    oRowpakPO = New TableRow
    oColpakPO = New TableCell
    oColpakPO.Text = "Serial No"
    oColpakPO.Font.Bold = True
    oRowpakPO.Cells.Add(oColpakPO)
    oColpakPO = New TableCell
    oColpakPO.Text = oVar.SerialNo
    oColpakPO.Style.Add("text-align", "center")
    oColpakPO.ColumnSpan = "2"
    oRowpakPO.Cells.Add(oColpakPO)
    oColpakPO = New TableCell
    oColpakPO.Text = "PO Number"
    oColpakPO.Font.Bold = True
    oRowpakPO.Cells.Add(oColpakPO)
    oColpakPO = New TableCell
    oColpakPO.Text = oVar.PONumber
    oColpakPO.Style.Add("text-align", "center")
    oColpakPO.ColumnSpan = "2"
    oRowpakPO.Cells.Add(oColpakPO)
    oTblpakPO.Rows.Add(oRowpakPO)

    oRowpakPO = New TableRow
    oColpakPO = New TableCell
    oColpakPO.Text = "BOM No"
    oColpakPO.Font.Bold = True
    oRowpakPO.Cells.Add(oColpakPO)
    oColpakPO = New TableCell
    oColpakPO.Text = tmpBOM.BOMNo
    oColpakPO.Style.Add("text-align", "right")
    oColpakPO.ColumnSpan = "2"
    oRowpakPO.Cells.Add(oColpakPO)
    oColpakPO = New TableCell
    oColpakPO.Text = "Project"
    oColpakPO.Font.Bold = True
    oRowpakPO.Cells.Add(oColpakPO)
    oColpakPO = New TableCell
    oColpakPO.Text = oVar.ProjectID
    oColpakPO.Style.Add("text-align", "center")
    oRowpakPO.Cells.Add(oColpakPO)
    oColpakPO = New TableCell
    oColpakPO.Text = oVar.IDM_Projects4_Description
    oColpakPO.Style.Add("text-align", "left")
    oRowpakPO.Cells.Add(oColpakPO)
    oTblpakPO.Rows.Add(oRowpakPO)

    oRowpakPO = New TableRow
    oColpakPO = New TableCell
    oColpakPO.Text = "Supplier"
    oColpakPO.Font.Bold = True
    oRowpakPO.Cells.Add(oColpakPO)
    oColpakPO = New TableCell
    oColpakPO.Text = oVar.SupplierID
    oColpakPO.Style.Add("text-align", "center")
    oRowpakPO.Cells.Add(oColpakPO)
    oColpakPO = New TableCell
    oColpakPO.Text = oVar.VR_BusinessPartner9_BPName
    oColpakPO.Style.Add("text-align", "left")
    oRowpakPO.Cells.Add(oColpakPO)
    oColpakPO = New TableCell
    oColpakPO.Text = "Buyer"
    oColpakPO.Font.Bold = True
    oRowpakPO.Cells.Add(oColpakPO)
    oColpakPO = New TableCell
    oColpakPO.Text = oVar.BuyerID
    oColpakPO.Style.Add("text-align", "center")
    oRowpakPO.Cells.Add(oColpakPO)
    oColpakPO = New TableCell
    oColpakPO.Text = oVar.FK_PAK_PO_BuyerID.UserFullName
    oColpakPO.Style.Add("text-align", "left")
    oRowpakPO.Cells.Add(oColpakPO)
    oTblpakPO.Rows.Add(oRowpakPO)


    form1.Controls.Add(oTblpakPO)

    Dim oTblpakCItems As Table = Nothing
    Dim oRowpakCItems As TableRow = Nothing
    Dim oColpakCItems As TableCell = Nothing

    Dim opakCItemss As List(Of SIS.PAK.pakPOBItems) = SIS.PAK.pakPOBItems.UZ_pakPOBItemsSelectList(0, 999, "", False, "", tmpBOM.BOMNo, tmpBOM.SerialNo)
    If opakCItemss.Count > 0 Then
      Dim oTblhpakCItems As Table = New Table
      oTblhpakCItems.Width = 1000
      oTblhpakCItems.Style.Add("margin-top", "15px")
      oTblhpakCItems.Style.Add("margin-left", "10px")
      oTblhpakCItems.Style.Add("margin-right", "10px")
      Dim oRowhpakCItems As TableRow = New TableRow
      Dim oColhpakCItems As TableCell = New TableCell
      oColhpakCItems.Font.Bold = True
      oColhpakCItems.Font.Underline = True
      oColhpakCItems.Font.Size = 10
      oColhpakCItems.CssClass = "grpHD"
      oColhpakCItems.Text = "Child Items"
      oRowhpakCItems.Cells.Add(oColhpakCItems)
      oTblhpakCItems.Rows.Add(oRowhpakCItems)
      form1.Controls.Add(oTblhpakCItems)
      oTblpakCItems = New Table
      oTblpakCItems.Width = 1000
      oTblpakCItems.GridLines = GridLines.Both
      oTblpakCItems.Style.Add("margin-left", "10px")
      oTblpakCItems.Style.Add("margin-right", "10px")
      oRowpakCItems = New TableRow
      oColpakCItems = New TableCell
      oColpakCItems.Text = "Item No"
      oColpakCItems.Font.Bold = True
      oColpakCItems.CssClass = "colHD"
      oColpakCItems.Style.Add("text-align", "center")
      oRowpakCItems.Cells.Add(oColpakCItems)
      'oColpakCItems = New TableCell
      'oColpakCItems.Text = "Item Code"
      'oColpakCItems.Font.Bold = True
      'oColpakCItems.CssClass = "colHD"
      'oColpakCItems.Style.Add("text-align", "left")
      'oRowpakCItems.Cells.Add(oColpakCItems)
      oColpakCItems = New TableCell
      oColpakCItems.Text = "Item Description"
      oColpakCItems.Font.Bold = True
      oColpakCItems.CssClass = "colHD"
      oColpakCItems.Style.Add("text-align", "left")
      oRowpakCItems.Cells.Add(oColpakCItems)
      oColpakCItems = New TableCell
      oColpakCItems.Text = "Element ID"
      oColpakCItems.Font.Bold = True
      oColpakCItems.CssClass = "colHD"
      oColpakCItems.Style.Add("text-align", "left")
      oRowpakCItems.Cells.Add(oColpakCItems)
      oColpakCItems = New TableCell
      oColpakCItems.Text = "UOM Quantity"
      oColpakCItems.Font.Bold = True
      oColpakCItems.CssClass = "colHD"
      oColpakCItems.Style.Add("text-align", "right")
      oRowpakCItems.Cells.Add(oColpakCItems)
      oColpakCItems = New TableCell
      oColpakCItems.Text = "Quantity"
      oColpakCItems.Font.Bold = True
      oColpakCItems.CssClass = "colHD"
      oColpakCItems.Style.Add("text-align", "right")
      oRowpakCItems.Cells.Add(oColpakCItems)
      oColpakCItems = New TableCell
      oColpakCItems.Text = "UOM Weight"
      oColpakCItems.Font.Bold = True
      oColpakCItems.CssClass = "colHD"
      oColpakCItems.Style.Add("text-align", "right")
      oRowpakCItems.Cells.Add(oColpakCItems)
      oColpakCItems = New TableCell
      oColpakCItems.Text = "Weight Per Unit"
      oColpakCItems.Font.Bold = True
      oColpakCItems.CssClass = "colHD"
      oColpakCItems.Style.Add("text-align", "right")
      oRowpakCItems.Cells.Add(oColpakCItems)
      oColpakCItems = New TableCell
      oColpakCItems.Text = "Document No"
      oColpakCItems.Font.Bold = True
      oColpakCItems.CssClass = "colHD"
      oColpakCItems.Style.Add("text-align", "right")
      oRowpakCItems.Cells.Add(oColpakCItems)
      oTblpakCItems.Rows.Add(oRowpakCItems)
      For Each opakCItems As SIS.PAK.pakPOBItems In opakCItemss
        oRowpakCItems = New TableRow
        oColpakCItems = New TableCell
        oColpakCItems.CssClass = "rowHD"
        oColpakCItems.Text = opakCItems.ItemNo
        oColpakCItems.Style.Add("text-align", "center")
        oRowpakCItems.Cells.Add(oColpakCItems)
        'oColpakCItems = New TableCell
        'oColpakCItems.CssClass = "rowHD"
        'oColpakCItems.Text = opakCItems.ItemCode
        'oColpakCItems.Style.Add("text-align", "left")
        'oRowpakCItems.Cells.Add(oColpakCItems)
        oColpakCItems = New TableCell
        oColpakCItems.CssClass = "rowHD"
        oColpakCItems.Text = opakCItems.PItemDescription
        oColpakCItems.Style.Add("text-align", "left")
        With oColpakCItems
          .Font.Bold = opakCItems.FontBold
          .ForeColor = opakCItems.ForeColor
        End With
        oRowpakCItems.Cells.Add(oColpakCItems)
        oColpakCItems = New TableCell
        oColpakCItems.Text = opakCItems.PAK_Elements5_Description
        oColpakCItems.CssClass = "rowHD"
        oColpakCItems.Style.Add("text-align", "left")
        oRowpakCItems.Cells.Add(oColpakCItems)
        oColpakCItems = New TableCell
        oColpakCItems.Text = opakCItems.PAK_Units10_Description
        oColpakCItems.CssClass = "rowHD"
        oColpakCItems.Style.Add("text-align", "right")
        oRowpakCItems.Cells.Add(oColpakCItems)
        oColpakCItems = New TableCell
        oColpakCItems.CssClass = "rowHD"
        oColpakCItems.Text = opakCItems.PQuantity
        oColpakCItems.Style.Add("text-align", "right")
        oRowpakCItems.Cells.Add(oColpakCItems)
        oColpakCItems = New TableCell
        oColpakCItems.Text = opakCItems.PAK_Units11_Description
        oColpakCItems.CssClass = "rowHD"
        oColpakCItems.Style.Add("text-align", "right")
        oRowpakCItems.Cells.Add(oColpakCItems)
        oColpakCItems = New TableCell
        oColpakCItems.CssClass = "rowHD"
        oColpakCItems.Text = opakCItems.PWeightPerUnit
        oColpakCItems.Style.Add("text-align", "right")
        oRowpakCItems.Cells.Add(oColpakCItems)
        oColpakCItems = New TableCell
        oColpakCItems.Text = opakCItems.PAK_Documents4_cmba
        oColpakCItems.CssClass = "rowHD"
        oColpakCItems.Style.Add("text-align", "right")
        oRowpakCItems.Cells.Add(oColpakCItems)
        oTblpakCItems.Rows.Add(oRowpakCItems)
      Next
      form1.Controls.Add(oTblpakCItems)
    End If

  End Sub
End Class
