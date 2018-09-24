Partial Class RP_pakItems
  Inherits System.Web.UI.Page
  Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    Dim aVal() As String = Request.QueryString("pk").Split("|".ToCharArray)
    Dim ItemNo As Int32 = CType(aVal(0), Int32)
    Dim oVar As SIS.PAK.pakItems = SIS.PAK.pakItems.pakItemsGetByID(ItemNo)


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
      .Text = oVar.ItemNo & " - " & oVar.ItemDescription
      .Style.Add("text-align", "center")
      .Font.Size = FontUnit.Point(14)
    End With
    tmpRow.Cells.Add(tmpCol)
    tmpTbl.Rows.Add(tmpRow)
    form1.Controls.Add(tmpTbl)



    Dim oTblpakItems As New Table
    oTblpakItems.Width = 1000
    oTblpakItems.GridLines = GridLines.Both
    oTblpakItems.Style.Add("margin-top", "15px")
    oTblpakItems.Style.Add("margin-left", "10px")
    Dim oColpakItems As TableCell = Nothing
    Dim oRowpakItems As TableRow = Nothing
    oRowpakItems = New TableRow
    oColpakItems = New TableCell
    oColpakItems.Text = "Item Code"
    oColpakItems.Font.Bold = True
    oRowpakItems.Cells.Add(oColpakItems)
    oColpakItems = New TableCell
    oColpakItems.Text = oVar.ItemCode
    oColpakItems.Style.Add("text-align", "left")
    oColpakItems.ColumnSpan = "2"
    oRowpakItems.Cells.Add(oColpakItems)
    oColpakItems = New TableCell
    oColpakItems.Text = "Item No"
    oColpakItems.Font.Bold = True
    oRowpakItems.Cells.Add(oColpakItems)
    oColpakItems = New TableCell
    oColpakItems.Text = oVar.ItemNo
    oColpakItems.Style.Add("text-align", "right")
    oColpakItems.ColumnSpan = "2"
    oRowpakItems.Cells.Add(oColpakItems)
    oTblpakItems.Rows.Add(oRowpakItems)
    oRowpakItems = New TableRow
    oColpakItems = New TableCell
    oColpakItems.Text = "Item Description"
    oColpakItems.Font.Bold = True
    oRowpakItems.Cells.Add(oColpakItems)
    oColpakItems = New TableCell
    oColpakItems.Text = oVar.ItemDescription
    oColpakItems.Style.Add("text-align", "left")
    oColpakItems.ColumnSpan = "5"
    oRowpakItems.Cells.Add(oColpakItems)
    oTblpakItems.Rows.Add(oRowpakItems)
    oRowpakItems = New TableRow
    oColpakItems = New TableCell
    oColpakItems.Text = "Element ID"
    oColpakItems.Font.Bold = True
    oRowpakItems.Cells.Add(oColpakItems)
    oColpakItems = New TableCell
    oColpakItems.Text = oVar.ElementID
    oColpakItems.Style.Add("text-align", "left")
    oRowpakItems.Cells.Add(oColpakItems)
    oColpakItems = New TableCell
    oColpakItems.Text = oVar.PAK_Elements3_Description
    oColpakItems.Style.Add("text-align", "left")
    oColpakItems.ColumnSpan = "4"
    oRowpakItems.Cells.Add(oColpakItems)
    oTblpakItems.Rows.Add(oRowpakItems)
    oRowpakItems = New TableRow
    oColpakItems = New TableCell
    oColpakItems.Text = "Active"
    oColpakItems.Font.Bold = True
    oRowpakItems.Cells.Add(oColpakItems)
    oColpakItems = New TableCell
    oColpakItems.Text = IIf(oVar.Active, "YES", "NO")
    oColpakItems.Style.Add("text-align", "center")
    oColpakItems.ColumnSpan = "5"
    oRowpakItems.Cells.Add(oColpakItems)
    oTblpakItems.Rows.Add(oRowpakItems)
    form1.Controls.Add(oTblpakItems)

    Dim oTblpakCItems As Table = Nothing
    Dim oRowpakCItems As TableRow = Nothing
    Dim oColpakCItems As TableCell = Nothing

    Dim opakCItemss As List(Of SIS.PAK.pakCItems) = SIS.PAK.pakCItems.UZ_pakHCItemsSelectList(0, 999, "", False, "", oVar.ItemNo)
    If opakCItemss.Count > 0 Then
      Dim oTblhpakCItems As Table = New Table
      oTblhpakCItems.Width = 1000
      oTblhpakCItems.Style.Add("margin-top", "15px")
      oTblhpakCItems.Style.Add("margin-left", "10px")
      oTblhpakCItems.Style.Add("margin-right", "10px")
      Dim oRowhpakCItems As TableRow = New TableRow
      Dim oColhpakCItems As TableCell = New TableCell
      oColhpakCItems.Font.Bold = True
      oColhpakCItems.Font.UnderLine = True
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
      For Each opakCItems As SIS.PAK.pakCItems In opakCItemss
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
        oColpakCItems.Text = opakCItems.PAK_Elements3_Description
        oColpakCItems.CssClass = "rowHD"
        oColpakCItems.Style.Add("text-align", "left")
        oRowpakCItems.Cells.Add(oColpakCItems)
        oColpakCItems = New TableCell
        oColpakCItems.Text = opakCItems.PAK_Units5_Description
        oColpakCItems.CssClass = "rowHD"
        oColpakCItems.Style.Add("text-align", "right")
        oRowpakCItems.Cells.Add(oColpakCItems)
        oColpakCItems = New TableCell
        oColpakCItems.CssClass = "rowHD"
        oColpakCItems.Text = opakCItems.PQuantity
        oColpakCItems.Style.Add("text-align", "right")
        oRowpakCItems.Cells.Add(oColpakCItems)
        oColpakCItems = New TableCell
        oColpakCItems.Text = opakCItems.PAK_Units6_Description
        oColpakCItems.CssClass = "rowHD"
        oColpakCItems.Style.Add("text-align", "right")
        oRowpakCItems.Cells.Add(oColpakCItems)
        oColpakCItems = New TableCell
        oColpakCItems.CssClass = "rowHD"
        oColpakCItems.Text = opakCItems.PWeightPerUnit
        oColpakCItems.Style.Add("text-align", "right")
        oRowpakCItems.Cells.Add(oColpakCItems)
        oColpakCItems = New TableCell
        oColpakCItems.Text = opakCItems.PAK_Documents2_cmba
        oColpakCItems.CssClass = "rowHD"
        oColpakCItems.Style.Add("text-align", "right")
        oRowpakCItems.Cells.Add(oColpakCItems)
        oTblpakCItems.Rows.Add(oRowpakCItems)
      Next
      form1.Controls.Add(oTblpakCItems)
    End If
  End Sub
End Class