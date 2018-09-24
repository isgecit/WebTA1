Partial Class RP_pakIQCListH
  Inherits System.Web.UI.Page
  Private _InfoUrl As String = "~/PAK_Main/App_Display/DF_pakIQCListH.aspx"
  Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _InfoUrl  & "?SerialNo=" & aVal(0) & "&QCLNo=" & aVal(1)
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    Dim aVal() As String = Request.QueryString("pk").Split("|".ToCharArray)
    Dim SerialNo As Int32 = CType(aVal(0),Int32)
    Dim QCLNo As Int32 = CType(aVal(1),Int32)
    Dim oVar As SIS.PAK.pakIQCListH = SIS.PAK.pakIQCListH.pakIQCListHGetByID(SerialNo,QCLNo)
    Dim oTblpakIQCListH As New Table
    oTblpakIQCListH.Width = 1000
    oTblpakIQCListH.GridLines = GridLines.Both
    oTblpakIQCListH.Style.Add("margin-top", "15px")
    oTblpakIQCListH.Style.Add("margin-left", "10px")
    Dim oColpakIQCListH As TableCell = Nothing
    Dim oRowpakIQCListH As TableRow = Nothing
    oRowpakIQCListH = New TableRow
    oColpakIQCListH = New TableCell
    oColpakIQCListH.Text = "Serial No"
    oColpakIQCListH.Font.Bold = True
    oRowpakIQCListH.Cells.Add(oColpakIQCListH)
    oColpakIQCListH = New TableCell
    oColpakIQCListH.Text = oVar.SerialNo
      oColpakIQCListH.Style.Add("text-align","right")
    oRowpakIQCListH.Cells.Add(oColpakIQCListH)
    oColpakIQCListH = New TableCell
    oColpakIQCListH.Text = oVar.PAK_PO2_PODescription
      oColpakIQCListH.Style.Add("text-align","right")
    oRowpakIQCListH.Cells.Add(oColpakIQCListH)
    oColpakIQCListH = New TableCell
    oColpakIQCListH.Text = "QC List No"
    oColpakIQCListH.Font.Bold = True
    oRowpakIQCListH.Cells.Add(oColpakIQCListH)
    oColpakIQCListH = New TableCell
    oColpakIQCListH.Text = oVar.QCLNo
      oColpakIQCListH.Style.Add("text-align","right")
    oColpakIQCListH.ColumnSpan = "2"
    oRowpakIQCListH.Cells.Add(oColpakIQCListH)
    oTblpakIQCListH.Rows.Add(oRowpakIQCListH)
    form1.Controls.Add(oTblpakIQCListH)
      Dim oTblpakQCListD As Table = Nothing
      Dim oRowpakQCListD As TableRow = Nothing
      Dim oColpakQCListD As TableCell = Nothing
    Dim opakQCListDs As List(Of SIS.PAK.pakQCListD) = SIS.PAK.pakQCListD.pakQCListDSelectList(0, 999, "", False, "", oVar.SerialNo, oVar.QCLNo)
    If opakQCListDs.Count > 0 Then
      Dim oTblhpakQCListD As Table = New Table
      oTblhpakQCListD.Width = 1000
      oTblhpakQCListD.Style.Add("margin-top", "15px")
      oTblhpakQCListD.Style.Add("margin-left", "10px")
      oTblhpakQCListD.Style.Add("margin-right", "10px")
      Dim oRowhpakQCListD As TableRow = New TableRow
      Dim oColhpakQCListD As TableCell = New TableCell
      oColhpakQCListD.Font.Bold = True
      oColhpakQCListD.Font.UnderLine = True
      oColhpakQCListD.Font.Size = 10
      oColhpakQCListD.CssClass = "grpHD"
      oColhpakQCListD.Text = "Quality Clearance Items"
      oRowhpakQCListD.Cells.Add(oColhpakQCListD)
      oTblhpakQCListD.Rows.Add(oRowhpakQCListD)
      form1.Controls.Add(oTblhpakQCListD)
      oTblpakQCListD = New Table
      oTblpakQCListD.Width = 1000
      oTblpakQCListD.GridLines = GridLines.Both
      oTblpakQCListD.Style.Add("margin-left", "10px")
      oTblpakQCListD.Style.Add("margin-right", "10px")
      oRowpakQCListD = New TableRow
      oColpakQCListD = New TableCell
      oColpakQCListD.Text = "Serial No"
      oColpakQCListD.Font.Bold = True
      oColpakQCListD.CssClass = "colHD"
      oColpakQCListD.Style.Add("text-align","right")
      oRowpakQCListD.Cells.Add(oColpakQCListD)
      oColpakQCListD = New TableCell
      oColpakQCListD.Text = "QCL No"
      oColpakQCListD.Font.Bold = True
      oColpakQCListD.CssClass = "colHD"
      oColpakQCListD.Style.Add("text-align","right")
      oRowpakQCListD.Cells.Add(oColpakQCListD)
      oColpakQCListD = New TableCell
      oColpakQCListD.Text = "BOM No"
      oColpakQCListD.Font.Bold = True
      oColpakQCListD.CssClass = "colHD"
      oColpakQCListD.Style.Add("text-align","right")
      oRowpakQCListD.Cells.Add(oColpakQCListD)
      oColpakQCListD = New TableCell
      oColpakQCListD.Text = "Item No"
      oColpakQCListD.Font.Bold = True
      oColpakQCListD.CssClass = "colHD"
      oColpakQCListD.Style.Add("text-align","right")
      oRowpakQCListD.Cells.Add(oColpakQCListD)
      oColpakQCListD = New TableCell
      oColpakQCListD.Text = "UOM Quantity"
      oColpakQCListD.Font.Bold = True
      oColpakQCListD.CssClass = "colHD"
      oColpakQCListD.Style.Add("text-align","right")
      oRowpakQCListD.Cells.Add(oColpakQCListD)
      oColpakQCListD = New TableCell
      oColpakQCListD.Text = "Quantity"
      oColpakQCListD.Font.Bold = True
      oColpakQCListD.CssClass = "colHD"
      oColpakQCListD.Style.Add("text-align","right")
      oRowpakQCListD.Cells.Add(oColpakQCListD)
      oColpakQCListD = New TableCell
      oColpakQCListD.Text = "UOM Weight"
      oColpakQCListD.Font.Bold = True
      oColpakQCListD.CssClass = "colHD"
      oColpakQCListD.Style.Add("text-align","right")
      oRowpakQCListD.Cells.Add(oColpakQCListD)
      oColpakQCListD = New TableCell
      oColpakQCListD.Text = "Weight Per Unit"
      oColpakQCListD.Font.Bold = True
      oColpakQCListD.CssClass = "colHD"
      oColpakQCListD.Style.Add("text-align","right")
      oRowpakQCListD.Cells.Add(oColpakQCListD)
      oColpakQCListD = New TableCell
      oColpakQCListD.Text = "Quality Cleared Qty"
      oColpakQCListD.Font.Bold = True
      oColpakQCListD.CssClass = "colHD"
      oColpakQCListD.Style.Add("text-align","right")
      oRowpakQCListD.Cells.Add(oColpakQCListD)
      oColpakQCListD = New TableCell
      oColpakQCListD.Text = "Remarks"
      oColpakQCListD.Font.Bold = True
      oColpakQCListD.CssClass = "colHD"
      oColpakQCListD.Style.Add("text-align","left")
      oRowpakQCListD.Cells.Add(oColpakQCListD)
      oColpakQCListD = New TableCell
      oColpakQCListD.Text = "Cleared By"
      oColpakQCListD.Font.Bold = True
      oColpakQCListD.CssClass = "colHD"
      oColpakQCListD.Style.Add("text-align","left")
      oRowpakQCListD.Cells.Add(oColpakQCListD)
      oColpakQCListD = New TableCell
      oColpakQCListD.Text = "Cleared On"
      oColpakQCListD.Font.Bold = True
      oColpakQCListD.CssClass = "colHD"
      oColpakQCListD.Style.Add("text-align","center")
      oRowpakQCListD.Cells.Add(oColpakQCListD)
      oTblpakQCListD.Rows.Add(oRowpakQCListD)
      For Each opakQCListD As SIS.PAK.pakQCListD In opakQCListDs
        oRowpakQCListD = New TableRow
        oColpakQCListD = New TableCell
        oColpakQCListD.Text = opakQCListD.PAK_PO2_PODescription
        oColpakQCListD.CssClass = "rowHD"
      oColpakQCListD.Style.Add("text-align","right")
        oRowpakQCListD.Cells.Add(oColpakQCListD)
        oColpakQCListD = New TableCell
        oColpakQCListD.Text = opakQCListD.PAK_QCListH5_SupplierRef
        oColpakQCListD.CssClass = "rowHD"
      oColpakQCListD.Style.Add("text-align","right")
        oRowpakQCListD.Cells.Add(oColpakQCListD)
        oColpakQCListD = New TableCell
        oColpakQCListD.Text = opakQCListD.PAK_POBOM4_ItemDescription
        oColpakQCListD.CssClass = "rowHD"
      oColpakQCListD.Style.Add("text-align","right")
        oRowpakQCListD.Cells.Add(oColpakQCListD)
        oColpakQCListD = New TableCell
        oColpakQCListD.Text = opakQCListD.PAK_POBItems3_ItemDescription
        oColpakQCListD.CssClass = "rowHD"
      oColpakQCListD.Style.Add("text-align","right")
        oRowpakQCListD.Cells.Add(oColpakQCListD)
        oColpakQCListD = New TableCell
        oColpakQCListD.Text = opakQCListD.PAK_Units6_Description
        oColpakQCListD.CssClass = "rowHD"
      oColpakQCListD.Style.Add("text-align","right")
        oRowpakQCListD.Cells.Add(oColpakQCListD)
        oColpakQCListD = New TableCell
        oColpakQCListD.CssClass = "rowHD"
        oColpakQCListD.Text = opakQCListD.Quantity
      oColpakQCListD.Style.Add("text-align","right")
        oRowpakQCListD.Cells.Add(oColpakQCListD)
        oColpakQCListD = New TableCell
        oColpakQCListD.Text = opakQCListD.PAK_Units7_Description
        oColpakQCListD.CssClass = "rowHD"
      oColpakQCListD.Style.Add("text-align","right")
        oRowpakQCListD.Cells.Add(oColpakQCListD)
        oColpakQCListD = New TableCell
        oColpakQCListD.CssClass = "rowHD"
        oColpakQCListD.Text = opakQCListD.WeightPerUnit
      oColpakQCListD.Style.Add("text-align","right")
        oRowpakQCListD.Cells.Add(oColpakQCListD)
        oColpakQCListD = New TableCell
        oColpakQCListD.CssClass = "rowHD"
        oColpakQCListD.Text = opakQCListD.QualityClearedQty
      oColpakQCListD.Style.Add("text-align","right")
        oRowpakQCListD.Cells.Add(oColpakQCListD)
        oColpakQCListD = New TableCell
        oColpakQCListD.CssClass = "rowHD"
        oColpakQCListD.Text = opakQCListD.Remarks
      oColpakQCListD.Style.Add("text-align","left")
        oRowpakQCListD.Cells.Add(oColpakQCListD)
        oColpakQCListD = New TableCell
        oColpakQCListD.Text = opakQCListD.aspnet_users1_UserFullName
        oColpakQCListD.CssClass = "rowHD"
      oColpakQCListD.Style.Add("text-align","left")
        oRowpakQCListD.Cells.Add(oColpakQCListD)
        oColpakQCListD = New TableCell
        oColpakQCListD.CssClass = "rowHD"
        oColpakQCListD.Text = opakQCListD.ClearedOn
      oColpakQCListD.Style.Add("text-align","center")
        oRowpakQCListD.Cells.Add(oColpakQCListD)
        oTblpakQCListD.Rows.Add(oRowpakQCListD)
      Next
      form1.Controls.Add(oTblpakQCListD)
    End If
  End Sub
End Class
