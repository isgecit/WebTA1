Partial Class RP_pakPkgListH
  Inherits System.Web.UI.Page
  Private _InfoUrl As String = "~/PAK_Main/App_Display/DF_pakPkgListH.aspx"
  Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _InfoUrl  & "?SerialNo=" & aVal(0) & "&PkgNo=" & aVal(1)
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    Dim aVal() As String = Request.QueryString("pk").Split("|".ToCharArray)
    Dim SerialNo As Int32 = CType(aVal(0),Int32)
    Dim PkgNo As Int32 = CType(aVal(1),Int32)
    Dim oVar As SIS.PAK.pakPkgListH = SIS.PAK.pakPkgListH.pakPkgListHGetByID(SerialNo,PkgNo)
    Dim oTblpakPkgListH As New Table
    oTblpakPkgListH.Width = 1000
    oTblpakPkgListH.GridLines = GridLines.Both
    oTblpakPkgListH.Style.Add("margin-top", "15px")
    oTblpakPkgListH.Style.Add("margin-left", "10px")
    Dim oColpakPkgListH As TableCell = Nothing
    Dim oRowpakPkgListH As TableRow = Nothing
    oRowpakPkgListH = New TableRow
    oColpakPkgListH = New TableCell
    oColpakPkgListH.Text = "Pkg. No"
    oColpakPkgListH.Font.Bold = True
    oRowpakPkgListH.Cells.Add(oColpakPkgListH)
    oColpakPkgListH = New TableCell
    oColpakPkgListH.Text = oVar.PkgNo
      oColpakPkgListH.Style.Add("text-align","right")
    oColpakPkgListH.ColumnSpan = "2"
    oRowpakPkgListH.Cells.Add(oColpakPkgListH)
    oColpakPkgListH = New TableCell
    oColpakPkgListH.Text = "Supplier Ref. No"
    oColpakPkgListH.Font.Bold = True
    oRowpakPkgListH.Cells.Add(oColpakPkgListH)
    oColpakPkgListH = New TableCell
    oColpakPkgListH.Text = oVar.SupplierRefNo
      oColpakPkgListH.Style.Add("text-align","left")
    oColpakPkgListH.ColumnSpan = "2"
    oRowpakPkgListH.Cells.Add(oColpakPkgListH)
    oTblpakPkgListH.Rows.Add(oRowpakPkgListH)
    form1.Controls.Add(oTblpakPkgListH)
      Dim oTblpakPkgListD As Table = Nothing
      Dim oRowpakPkgListD As TableRow = Nothing
      Dim oColpakPkgListD As TableCell = Nothing
    Dim opakPkgListDs As List(Of SIS.PAK.pakPkgListD) = SIS.PAK.pakPkgListD.pakPkgListDSelectList(0, 999, "", False, "", oVar.SerialNo, oVar.PkgNo)
    If opakPkgListDs.Count > 0 Then
      Dim oTblhpakPkgListD As Table = New Table
      oTblhpakPkgListD.Width = 1000
      oTblhpakPkgListD.Style.Add("margin-top", "15px")
      oTblhpakPkgListD.Style.Add("margin-left", "10px")
      oTblhpakPkgListD.Style.Add("margin-right", "10px")
      Dim oRowhpakPkgListD As TableRow = New TableRow
      Dim oColhpakPkgListD As TableCell = New TableCell
      oColhpakPkgListD.Font.Bold = True
      oColhpakPkgListD.Font.UnderLine = True
      oColhpakPkgListD.Font.Size = 10
      oColhpakPkgListD.CssClass = "grpHD"
      oColhpakPkgListD.Text = "Packing List Items"
      oRowhpakPkgListD.Cells.Add(oColhpakPkgListD)
      oTblhpakPkgListD.Rows.Add(oRowhpakPkgListD)
      form1.Controls.Add(oTblhpakPkgListD)
      oTblpakPkgListD = New Table
      oTblpakPkgListD.Width = 1000
      oTblpakPkgListD.GridLines = GridLines.Both
      oTblpakPkgListD.Style.Add("margin-left", "10px")
      oTblpakPkgListD.Style.Add("margin-right", "10px")
      oRowpakPkgListD = New TableRow
      oColpakPkgListD = New TableCell
      oColpakPkgListD.Text = "BOM No"
      oColpakPkgListD.Font.Bold = True
      oColpakPkgListD.CssClass = "colHD"
      oColpakPkgListD.Style.Add("text-align","right")
      oRowpakPkgListD.Cells.Add(oColpakPkgListD)
      oColpakPkgListD = New TableCell
      oColpakPkgListD.Text = "Item No"
      oColpakPkgListD.Font.Bold = True
      oColpakPkgListD.CssClass = "colHD"
      oColpakPkgListD.Style.Add("text-align","right")
      oRowpakPkgListD.Cells.Add(oColpakPkgListD)
      oColpakPkgListD = New TableCell
      oColpakPkgListD.Text = "UOM Quantity"
      oColpakPkgListD.Font.Bold = True
      oColpakPkgListD.CssClass = "colHD"
      oColpakPkgListD.Style.Add("text-align","right")
      oRowpakPkgListD.Cells.Add(oColpakPkgListD)
      oColpakPkgListD = New TableCell
      oColpakPkgListD.Text = "Quantity"
      oColpakPkgListD.Font.Bold = True
      oColpakPkgListD.CssClass = "colHD"
      oColpakPkgListD.Style.Add("text-align","right")
      oRowpakPkgListD.Cells.Add(oColpakPkgListD)
      oColpakPkgListD = New TableCell
      oColpakPkgListD.Text = "UOM Weight"
      oColpakPkgListD.Font.Bold = True
      oColpakPkgListD.CssClass = "colHD"
      oColpakPkgListD.Style.Add("text-align","right")
      oRowpakPkgListD.Cells.Add(oColpakPkgListD)
      oColpakPkgListD = New TableCell
      oColpakPkgListD.Text = "Weight Per Unit"
      oColpakPkgListD.Font.Bold = True
      oColpakPkgListD.CssClass = "colHD"
      oColpakPkgListD.Style.Add("text-align","right")
      oRowpakPkgListD.Cells.Add(oColpakPkgListD)
      oColpakPkgListD = New TableCell
      oColpakPkgListD.Text = "Pack Type"
      oColpakPkgListD.Font.Bold = True
      oColpakPkgListD.CssClass = "colHD"
      oColpakPkgListD.Style.Add("text-align","right")
      oRowpakPkgListD.Cells.Add(oColpakPkgListD)
      oColpakPkgListD = New TableCell
      oColpakPkgListD.Text = "Packing Mark"
      oColpakPkgListD.Font.Bold = True
      oColpakPkgListD.CssClass = "colHD"
      oColpakPkgListD.Style.Add("text-align","left")
      oRowpakPkgListD.Cells.Add(oColpakPkgListD)
      oColpakPkgListD = New TableCell
      oColpakPkgListD.Text = "Pack Length"
      oColpakPkgListD.Font.Bold = True
      oColpakPkgListD.CssClass = "colHD"
      oColpakPkgListD.Style.Add("text-align","right")
      oRowpakPkgListD.Cells.Add(oColpakPkgListD)
      oColpakPkgListD = New TableCell
      oColpakPkgListD.Text = "Pack Width"
      oColpakPkgListD.Font.Bold = True
      oColpakPkgListD.CssClass = "colHD"
      oColpakPkgListD.Style.Add("text-align","right")
      oRowpakPkgListD.Cells.Add(oColpakPkgListD)
      oColpakPkgListD = New TableCell
      oColpakPkgListD.Text = "Pack Height"
      oColpakPkgListD.Font.Bold = True
      oColpakPkgListD.CssClass = "colHD"
      oColpakPkgListD.Style.Add("text-align","right")
      oRowpakPkgListD.Cells.Add(oColpakPkgListD)
      oColpakPkgListD = New TableCell
      oColpakPkgListD.Text = "UOM Pack"
      oColpakPkgListD.Font.Bold = True
      oColpakPkgListD.CssClass = "colHD"
      oColpakPkgListD.Style.Add("text-align","right")
      oRowpakPkgListD.Cells.Add(oColpakPkgListD)
      oTblpakPkgListD.Rows.Add(oRowpakPkgListD)
      For Each opakPkgListD As SIS.PAK.pakPkgListD In opakPkgListDs
        oRowpakPkgListD = New TableRow
        oColpakPkgListD = New TableCell
        oColpakPkgListD.Text = opakPkgListD.PAK_POBOM5_ItemDescription
        oColpakPkgListD.CssClass = "rowHD"
      oColpakPkgListD.Style.Add("text-align","right")
        oRowpakPkgListD.Cells.Add(oColpakPkgListD)
        oColpakPkgListD = New TableCell
        oColpakPkgListD.Text = opakPkgListD.PAK_POBItems4_ItemDescription
        oColpakPkgListD.CssClass = "rowHD"
      oColpakPkgListD.Style.Add("text-align","right")
        oRowpakPkgListD.Cells.Add(oColpakPkgListD)
        oColpakPkgListD = New TableCell
        oColpakPkgListD.Text = opakPkgListD.PAK_Units6_Description
        oColpakPkgListD.CssClass = "rowHD"
      oColpakPkgListD.Style.Add("text-align","right")
        oRowpakPkgListD.Cells.Add(oColpakPkgListD)
        oColpakPkgListD = New TableCell
        oColpakPkgListD.CssClass = "rowHD"
        oColpakPkgListD.Text = opakPkgListD.Quantity
      oColpakPkgListD.Style.Add("text-align","right")
        oRowpakPkgListD.Cells.Add(oColpakPkgListD)
        oColpakPkgListD = New TableCell
        oColpakPkgListD.Text = opakPkgListD.PAK_Units7_Description
        oColpakPkgListD.CssClass = "rowHD"
      oColpakPkgListD.Style.Add("text-align","right")
        oRowpakPkgListD.Cells.Add(oColpakPkgListD)
        oColpakPkgListD = New TableCell
        oColpakPkgListD.CssClass = "rowHD"
        oColpakPkgListD.Text = opakPkgListD.WeightPerUnit
      oColpakPkgListD.Style.Add("text-align","right")
        oRowpakPkgListD.Cells.Add(oColpakPkgListD)
        oColpakPkgListD = New TableCell
        oColpakPkgListD.Text = opakPkgListD.PAK_PakTypes1_Description
        oColpakPkgListD.CssClass = "rowHD"
      oColpakPkgListD.Style.Add("text-align","right")
        oRowpakPkgListD.Cells.Add(oColpakPkgListD)
        oColpakPkgListD = New TableCell
        oColpakPkgListD.CssClass = "rowHD"
        oColpakPkgListD.Text = opakPkgListD.PackingMark
      oColpakPkgListD.Style.Add("text-align","left")
        oRowpakPkgListD.Cells.Add(oColpakPkgListD)
        oColpakPkgListD = New TableCell
        oColpakPkgListD.CssClass = "rowHD"
        oColpakPkgListD.Text = opakPkgListD.PackLength
      oColpakPkgListD.Style.Add("text-align","right")
        oRowpakPkgListD.Cells.Add(oColpakPkgListD)
        oColpakPkgListD = New TableCell
        oColpakPkgListD.CssClass = "rowHD"
        oColpakPkgListD.Text = opakPkgListD.PackWidth
      oColpakPkgListD.Style.Add("text-align","right")
        oRowpakPkgListD.Cells.Add(oColpakPkgListD)
        oColpakPkgListD = New TableCell
        oColpakPkgListD.CssClass = "rowHD"
        oColpakPkgListD.Text = opakPkgListD.PackHeight
      oColpakPkgListD.Style.Add("text-align","right")
        oRowpakPkgListD.Cells.Add(oColpakPkgListD)
        oColpakPkgListD = New TableCell
        oColpakPkgListD.Text = opakPkgListD.PAK_Units8_Description
        oColpakPkgListD.CssClass = "rowHD"
      oColpakPkgListD.Style.Add("text-align","right")
        oRowpakPkgListD.Cells.Add(oColpakPkgListD)
        oTblpakPkgListD.Rows.Add(oRowpakPkgListD)
      Next
      form1.Controls.Add(oTblpakPkgListD)
    End If
  End Sub
End Class
