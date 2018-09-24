Partial Class RP_pakSTCPO
  Inherits System.Web.UI.Page
  Private _InfoUrl As String = "~/PAK_Main/App_Display/DF_pakSTCPO.aspx"
  Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _InfoUrl  & "?SerialNo=" & aVal(0)
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    Dim aVal() As String = Request.QueryString("pk").Split("|".ToCharArray)
    Dim SerialNo As Int32 = CType(aVal(0),Int32)
    Dim oVar As SIS.PAK.pakSTCPO = SIS.PAK.pakSTCPO.pakSTCPOGetByID(SerialNo)
    Dim oTblpakSTCPO As New Table
    oTblpakSTCPO.Width = 1000
    oTblpakSTCPO.GridLines = GridLines.Both
    oTblpakSTCPO.Style.Add("margin-top", "15px")
    oTblpakSTCPO.Style.Add("margin-left", "10px")
    Dim oColpakSTCPO As TableCell = Nothing
    Dim oRowpakSTCPO As TableRow = Nothing
    oRowpakSTCPO = New TableRow
    oColpakSTCPO = New TableCell
    oColpakSTCPO.Text = "PO Number"
    oColpakSTCPO.Font.Bold = True
    oRowpakSTCPO.Cells.Add(oColpakSTCPO)
    oColpakSTCPO = New TableCell
    oColpakSTCPO.Text = oVar.PONumber
      oColpakSTCPO.Style.Add("text-align","left")
    oColpakSTCPO.ColumnSpan = "2"
    oRowpakSTCPO.Cells.Add(oColpakSTCPO)
    oColpakSTCPO = New TableCell
    oColpakSTCPO.Text = "Serial No"
    oColpakSTCPO.Font.Bold = True
    oRowpakSTCPO.Cells.Add(oColpakSTCPO)
    oColpakSTCPO = New TableCell
    oColpakSTCPO.Text = oVar.SerialNo
      oColpakSTCPO.Style.Add("text-align","right")
    oColpakSTCPO.ColumnSpan = "2"
    oRowpakSTCPO.Cells.Add(oColpakSTCPO)
    oTblpakSTCPO.Rows.Add(oRowpakSTCPO)
    oRowpakSTCPO = New TableRow
    oColpakSTCPO = New TableCell
    oColpakSTCPO.Text = "PO Description"
    oColpakSTCPO.Font.Bold = True
    oRowpakSTCPO.Cells.Add(oColpakSTCPO)
    oColpakSTCPO = New TableCell
    oColpakSTCPO.Text = oVar.PODescription
      oColpakSTCPO.Style.Add("text-align","left")
    oColpakSTCPO.ColumnSpan = "2"
    oRowpakSTCPO.Cells.Add(oColpakSTCPO)
    oColpakSTCPO = New TableCell
    oColpakSTCPO.Text = "PO Revision"
    oColpakSTCPO.Font.Bold = True
    oRowpakSTCPO.Cells.Add(oColpakSTCPO)
    oColpakSTCPO = New TableCell
    oColpakSTCPO.Text = oVar.PORevision
      oColpakSTCPO.Style.Add("text-align","left")
    oColpakSTCPO.ColumnSpan = "2"
    oRowpakSTCPO.Cells.Add(oColpakSTCPO)
    oTblpakSTCPO.Rows.Add(oRowpakSTCPO)
    oRowpakSTCPO = New TableRow
    oColpakSTCPO = New TableCell
    oColpakSTCPO.Text = "Supplier"
    oColpakSTCPO.Font.Bold = True
    oRowpakSTCPO.Cells.Add(oColpakSTCPO)
    oColpakSTCPO = New TableCell
    oColpakSTCPO.Text = oVar.SupplierID
      oColpakSTCPO.Style.Add("text-align","left")
    oRowpakSTCPO.Cells.Add(oColpakSTCPO)
    oColpakSTCPO = New TableCell
    oColpakSTCPO.Text = oVar.VR_BusinessPartner9_BPName
      oColpakSTCPO.Style.Add("text-align","left")
    oRowpakSTCPO.Cells.Add(oColpakSTCPO)
    oColpakSTCPO = New TableCell
    oColpakSTCPO.Text = "PO Date"
    oColpakSTCPO.Font.Bold = True
    oRowpakSTCPO.Cells.Add(oColpakSTCPO)
    oColpakSTCPO = New TableCell
    oColpakSTCPO.Text = oVar.PODate
      oColpakSTCPO.Style.Add("text-align","center")
    oColpakSTCPO.ColumnSpan = "2"
    oRowpakSTCPO.Cells.Add(oColpakSTCPO)
    oTblpakSTCPO.Rows.Add(oRowpakSTCPO)
    oRowpakSTCPO = New TableRow
    oColpakSTCPO = New TableCell
    oColpakSTCPO.Text = "Project"
    oColpakSTCPO.Font.Bold = True
    oRowpakSTCPO.Cells.Add(oColpakSTCPO)
    oColpakSTCPO = New TableCell
    oColpakSTCPO.Text = oVar.ProjectID
      oColpakSTCPO.Style.Add("text-align","left")
    oRowpakSTCPO.Cells.Add(oColpakSTCPO)
    oColpakSTCPO = New TableCell
    oColpakSTCPO.Text = oVar.IDM_Projects4_Description
      oColpakSTCPO.Style.Add("text-align","left")
    oRowpakSTCPO.Cells.Add(oColpakSTCPO)
    oColpakSTCPO = New TableCell
    oColpakSTCPO.Text = "Buyer"
    oColpakSTCPO.Font.Bold = True
    oRowpakSTCPO.Cells.Add(oColpakSTCPO)
    oColpakSTCPO = New TableCell
    oColpakSTCPO.Text = oVar.BuyerID
      oColpakSTCPO.Style.Add("text-align","left")
    oRowpakSTCPO.Cells.Add(oColpakSTCPO)
    oColpakSTCPO = New TableCell
    oColpakSTCPO.Text = oVar.aspnet_users1_UserFullName
      oColpakSTCPO.Style.Add("text-align","left")
    oRowpakSTCPO.Cells.Add(oColpakSTCPO)
    oTblpakSTCPO.Rows.Add(oRowpakSTCPO)
    oRowpakSTCPO = New TableRow
    oColpakSTCPO = New TableCell
    oColpakSTCPO.Text = "Status"
    oColpakSTCPO.Font.Bold = True
    oRowpakSTCPO.Cells.Add(oColpakSTCPO)
    oColpakSTCPO = New TableCell
    oColpakSTCPO.Text = oVar.POStatusID
      oColpakSTCPO.Style.Add("text-align","right")
    oRowpakSTCPO.Cells.Add(oColpakSTCPO)
    oColpakSTCPO = New TableCell
    oColpakSTCPO.Text = oVar.PAK_POStatus6_Description
      oColpakSTCPO.Style.Add("text-align","right")
    oColpakSTCPO.ColumnSpan = "4"
    oRowpakSTCPO.Cells.Add(oColpakSTCPO)
    oTblpakSTCPO.Rows.Add(oRowpakSTCPO)
    oRowpakSTCPO = New TableRow
    oColpakSTCPO = New TableCell
    oColpakSTCPO.Text = "Issued By"
    oColpakSTCPO.Font.Bold = True
    oRowpakSTCPO.Cells.Add(oColpakSTCPO)
    oColpakSTCPO = New TableCell
    oColpakSTCPO.Text = oVar.IssuedBy
      oColpakSTCPO.Style.Add("text-align","left")
    oRowpakSTCPO.Cells.Add(oColpakSTCPO)
    oColpakSTCPO = New TableCell
    oColpakSTCPO.Text = oVar.aspnet_users2_UserFullName
      oColpakSTCPO.Style.Add("text-align","left")
    oRowpakSTCPO.Cells.Add(oColpakSTCPO)
    oColpakSTCPO = New TableCell
    oColpakSTCPO.Text = "Issued On"
    oColpakSTCPO.Font.Bold = True
    oRowpakSTCPO.Cells.Add(oColpakSTCPO)
    oColpakSTCPO = New TableCell
    oColpakSTCPO.Text = oVar.IssuedOn
      oColpakSTCPO.Style.Add("text-align","center")
    oColpakSTCPO.ColumnSpan = "2"
    oRowpakSTCPO.Cells.Add(oColpakSTCPO)
    oTblpakSTCPO.Rows.Add(oRowpakSTCPO)
    form1.Controls.Add(oTblpakSTCPO)
      Dim oTblpakTCPOL As Table = Nothing
      Dim oRowpakTCPOL As TableRow = Nothing
      Dim oColpakTCPOL As TableCell = Nothing
    Dim opakTCPOLs As List(Of SIS.PAK.pakTCPOL) = SIS.PAK.pakTCPOL.pakTCPOLSelectList(0, 999, "", False, "", oVar.SerialNo)
    If opakTCPOLs.Count > 0 Then
      Dim oTblhpakTCPOL As Table = New Table
      oTblhpakTCPOL.Width = 1000
      oTblhpakTCPOL.Style.Add("margin-top", "15px")
      oTblhpakTCPOL.Style.Add("margin-left", "10px")
      oTblhpakTCPOL.Style.Add("margin-right", "10px")
      Dim oRowhpakTCPOL As TableRow = New TableRow
      Dim oColhpakTCPOL As TableCell = New TableCell
      oColhpakTCPOL.Font.Bold = True
      oColhpakTCPOL.Font.UnderLine = True
      oColhpakTCPOL.Font.Size = 10
      oColhpakTCPOL.CssClass = "grpHD"
      oColhpakTCPOL.Text = "PO Items"
      oRowhpakTCPOL.Cells.Add(oColhpakTCPOL)
      oTblhpakTCPOL.Rows.Add(oRowhpakTCPOL)
      form1.Controls.Add(oTblhpakTCPOL)
      oTblpakTCPOL = New Table
      oTblpakTCPOL.Width = 1000
      oTblpakTCPOL.GridLines = GridLines.Both
      oTblpakTCPOL.Style.Add("margin-left", "10px")
      oTblpakTCPOL.Style.Add("margin-right", "10px")
      oRowpakTCPOL = New TableRow
      oColpakTCPOL = New TableCell
      oColpakTCPOL.Text = "Item Code"
      oColpakTCPOL.Font.Bold = True
      oColpakTCPOL.CssClass = "colHD"
      oColpakTCPOL.Style.Add("text-align","left")
      oRowpakTCPOL.Cells.Add(oColpakTCPOL)
      oColpakTCPOL = New TableCell
      oColpakTCPOL.Text = "Description"
      oColpakTCPOL.Font.Bold = True
      oColpakTCPOL.CssClass = "colHD"
      oColpakTCPOL.Style.Add("text-align","left")
      oRowpakTCPOL.Cells.Add(oColpakTCPOL)
      oColpakTCPOL = New TableCell
      oColpakTCPOL.Text = "Quantity"
      oColpakTCPOL.Font.Bold = True
      oColpakTCPOL.CssClass = "colHD"
      oColpakTCPOL.Style.Add("text-align","right")
      oRowpakTCPOL.Cells.Add(oColpakTCPOL)
      oColpakTCPOL = New TableCell
      oColpakTCPOL.Text = "Unit"
      oColpakTCPOL.Font.Bold = True
      oColpakTCPOL.CssClass = "colHD"
      oColpakTCPOL.Style.Add("text-align","left")
      oRowpakTCPOL.Cells.Add(oColpakTCPOL)
      oColpakTCPOL = New TableCell
      oColpakTCPOL.Text = "Element"
      oColpakTCPOL.Font.Bold = True
      oColpakTCPOL.CssClass = "colHD"
      oColpakTCPOL.Style.Add("text-align","left")
      oRowpakTCPOL.Cells.Add(oColpakTCPOL)
      oColpakTCPOL = New TableCell
      oColpakTCPOL.Text = "Status"
      oColpakTCPOL.Font.Bold = True
      oColpakTCPOL.CssClass = "colHD"
      oColpakTCPOL.Style.Add("text-align","right")
      oRowpakTCPOL.Cells.Add(oColpakTCPOL)
      oTblpakTCPOL.Rows.Add(oRowpakTCPOL)
      For Each opakTCPOL As SIS.PAK.pakTCPOL In opakTCPOLs
        oRowpakTCPOL = New TableRow
        oColpakTCPOL = New TableCell
        oColpakTCPOL.CssClass = "rowHD"
        oColpakTCPOL.Text = opakTCPOL.ItemCode
      oColpakTCPOL.Style.Add("text-align","left")
        oRowpakTCPOL.Cells.Add(oColpakTCPOL)
        oColpakTCPOL = New TableCell
        oColpakTCPOL.CssClass = "rowHD"
        oColpakTCPOL.Text = opakTCPOL.ItemDescription
      oColpakTCPOL.Style.Add("text-align","left")
        oRowpakTCPOL.Cells.Add(oColpakTCPOL)
        oColpakTCPOL = New TableCell
        oColpakTCPOL.CssClass = "rowHD"
        oColpakTCPOL.Text = opakTCPOL.ItemQuantity
      oColpakTCPOL.Style.Add("text-align","right")
        oRowpakTCPOL.Cells.Add(oColpakTCPOL)
        oColpakTCPOL = New TableCell
        oColpakTCPOL.CssClass = "rowHD"
        oColpakTCPOL.Text = opakTCPOL.ItemUnit
      oColpakTCPOL.Style.Add("text-align","left")
        oRowpakTCPOL.Cells.Add(oColpakTCPOL)
        oColpakTCPOL = New TableCell
        oColpakTCPOL.Text = opakTCPOL.IDM_WBS1_Description
        oColpakTCPOL.CssClass = "rowHD"
      oColpakTCPOL.Style.Add("text-align","left")
        oRowpakTCPOL.Cells.Add(oColpakTCPOL)
        oColpakTCPOL = New TableCell
        oColpakTCPOL.Text = opakTCPOL.PAK_POLineStatus3_Description
        oColpakTCPOL.CssClass = "rowHD"
      oColpakTCPOL.Style.Add("text-align","right")
        oRowpakTCPOL.Cells.Add(oColpakTCPOL)
        oTblpakTCPOL.Rows.Add(oRowpakTCPOL)
    oRowpakTCPOL = New TableRow
    oColpakTCPOL = New TableCell
    oColpakTCPOL.ColumnSpan = oTblpakTCPOL.Rows(0).Cells.Count
    oRowpakTCPOL.Cells.Add(oColpakTCPOL)
      Dim oTblpakTCPOLR As Table = Nothing
      Dim oRowpakTCPOLR As TableRow = Nothing
      Dim oColpakTCPOLR As TableCell = Nothing
    Dim opakTCPOLRs As List(Of SIS.PAK.pakTCPOLR) = SIS.PAK.pakTCPOLR.pakTCPOLRSelectList(0, 999, "", False, "", opakTCPOL.SerialNo, opakTCPOL.ItemNo)
    If opakTCPOLRs.Count > 0 Then
      Dim oTblhpakTCPOLR As Table = New Table
      oTblhpakTCPOLR.Width = 980
      oTblhpakTCPOLR.Style.Add("margin-top", "15px")
      oTblhpakTCPOLR.Style.Add("margin-left", "10px")
      oTblhpakTCPOLR.Style.Add("margin-right", "10px")
      Dim oRowhpakTCPOLR As TableRow = New TableRow
      Dim oColhpakTCPOLR As TableCell = New TableCell
      oColhpakTCPOLR.Font.Bold = True
      oColhpakTCPOLR.Font.UnderLine = True
      oColhpakTCPOLR.Font.Size = 10
      oColhpakTCPOLR.CssClass = "grpHD"
      oColhpakTCPOLR.Text = "Submitted for TC"
      oRowhpakTCPOLR.Cells.Add(oColhpakTCPOLR)
      oTblhpakTCPOLR.Rows.Add(oRowhpakTCPOLR)
      oColpakTCPOL.Controls.Add(oTblhpakTCPOLR)
      oTblpakTCPOLR = New Table
      oTblpakTCPOLR.Width = 980
      oTblpakTCPOLR.GridLines = GridLines.Both
      oTblpakTCPOLR.Style.Add("margin-left", "10px")
      oTblpakTCPOLR.Style.Add("margin-right", "10px")
      oRowpakTCPOLR = New TableRow
      oColpakTCPOLR = New TableCell
      oColpakTCPOLR.Text = "Upload No"
      oColpakTCPOLR.Font.Bold = True
      oColpakTCPOLR.CssClass = "colHD"
      oColpakTCPOLR.Style.Add("text-align","right")
      oRowpakTCPOLR.Cells.Add(oColpakTCPOLR)
      oColpakTCPOLR = New TableCell
      oColpakTCPOLR.Text = "Document Category"
      oColpakTCPOLR.Font.Bold = True
      oColpakTCPOLR.CssClass = "colHD"
      oColpakTCPOLR.Style.Add("text-align","right")
      oRowpakTCPOLR.Cells.Add(oColpakTCPOLR)
      oColpakTCPOLR = New TableCell
      oColpakTCPOLR.Text = "Remarks"
      oColpakTCPOLR.Font.Bold = True
      oColpakTCPOLR.CssClass = "colHD"
      oColpakTCPOLR.Style.Add("text-align","left")
      oRowpakTCPOLR.Cells.Add(oColpakTCPOLR)
      oColpakTCPOLR = New TableCell
      oColpakTCPOLR.Text = "Submitted On"
      oColpakTCPOLR.Font.Bold = True
      oColpakTCPOLR.CssClass = "colHD"
      oColpakTCPOLR.Style.Add("text-align","center")
      oRowpakTCPOLR.Cells.Add(oColpakTCPOLR)
      oColpakTCPOLR = New TableCell
      oColpakTCPOLR.Text = "Status"
      oColpakTCPOLR.Font.Bold = True
      oColpakTCPOLR.CssClass = "colHD"
      oColpakTCPOLR.Style.Add("text-align","right")
      oRowpakTCPOLR.Cells.Add(oColpakTCPOLR)
      oColpakTCPOLR = New TableCell
      oColpakTCPOLR.Text = "ERP Receipt No"
      oColpakTCPOLR.Font.Bold = True
      oColpakTCPOLR.CssClass = "colHD"
      oColpakTCPOLR.Style.Add("text-align","left")
      oRowpakTCPOLR.Cells.Add(oColpakTCPOLR)
      oColpakTCPOLR = New TableCell
      oColpakTCPOLR.Text = "ERP Rev. No"
      oColpakTCPOLR.Font.Bold = True
      oColpakTCPOLR.CssClass = "colHD"
      oColpakTCPOLR.Style.Add("text-align","left")
      oRowpakTCPOLR.Cells.Add(oColpakTCPOLR)
      oTblpakTCPOLR.Rows.Add(oRowpakTCPOLR)
      For Each opakTCPOLR As SIS.PAK.pakTCPOLR In opakTCPOLRs
        oRowpakTCPOLR = New TableRow
        oColpakTCPOLR = New TableCell
        oColpakTCPOLR.CssClass = "rowHD"
        oColpakTCPOLR.Text = opakTCPOLR.UploadNo
      oColpakTCPOLR.Style.Add("text-align","right")
        oRowpakTCPOLR.Cells.Add(oColpakTCPOLR)
        oColpakTCPOLR = New TableCell
        oColpakTCPOLR.Text = opakTCPOLR.PAK_POLineRecCategory4_Description
        oColpakTCPOLR.CssClass = "rowHD"
      oColpakTCPOLR.Style.Add("text-align","right")
        oRowpakTCPOLR.Cells.Add(oColpakTCPOLR)
        oColpakTCPOLR = New TableCell
        oColpakTCPOLR.CssClass = "rowHD"
        oColpakTCPOLR.Text = opakTCPOLR.UploadRemarks
      oColpakTCPOLR.Style.Add("text-align","left")
        oRowpakTCPOLR.Cells.Add(oColpakTCPOLR)
        oColpakTCPOLR = New TableCell
        oColpakTCPOLR.CssClass = "rowHD"
        oColpakTCPOLR.Text = opakTCPOLR.CreatedOn
      oColpakTCPOLR.Style.Add("text-align","center")
        oRowpakTCPOLR.Cells.Add(oColpakTCPOLR)
        oColpakTCPOLR = New TableCell
        oColpakTCPOLR.Text = opakTCPOLR.PAK_POLineRecStatus5_Description
        oColpakTCPOLR.CssClass = "rowHD"
      oColpakTCPOLR.Style.Add("text-align","right")
        oRowpakTCPOLR.Cells.Add(oColpakTCPOLR)
        oColpakTCPOLR = New TableCell
        oColpakTCPOLR.CssClass = "rowHD"
        oColpakTCPOLR.Text = opakTCPOLR.ReceiptNo
      oColpakTCPOLR.Style.Add("text-align","left")
        oRowpakTCPOLR.Cells.Add(oColpakTCPOLR)
        oColpakTCPOLR = New TableCell
        oColpakTCPOLR.CssClass = "rowHD"
        oColpakTCPOLR.Text = opakTCPOLR.RevisionNo
      oColpakTCPOLR.Style.Add("text-align","left")
        oRowpakTCPOLR.Cells.Add(oColpakTCPOLR)
        oTblpakTCPOLR.Rows.Add(oRowpakTCPOLR)
    oRowpakTCPOLR = New TableRow
    oColpakTCPOLR = New TableCell
    oColpakTCPOLR.ColumnSpan = oTblpakTCPOLR.Rows(0).Cells.Count
    oRowpakTCPOLR.Cells.Add(oColpakTCPOLR)
      Dim oTblpakTCPOLRD As Table = Nothing
      Dim oRowpakTCPOLRD As TableRow = Nothing
      Dim oColpakTCPOLRD As TableCell = Nothing
    Dim opakTCPOLRDs As List(Of SIS.PAK.pakTCPOLRD) = SIS.PAK.pakTCPOLRD.pakTCPOLRDSelectList(0, 999, "", False, "", opakTCPOLR.SerialNo, opakTCPOLR.ItemNo, opakTCPOLR.UploadNo)
    If opakTCPOLRDs.Count > 0 Then
      Dim oTblhpakTCPOLRD As Table = New Table
      oTblhpakTCPOLRD.Width = 960
      oTblhpakTCPOLRD.Style.Add("margin-top", "15px")
      oTblhpakTCPOLRD.Style.Add("margin-left", "10px")
      oTblhpakTCPOLRD.Style.Add("margin-right", "10px")
      Dim oRowhpakTCPOLRD As TableRow = New TableRow
      Dim oColhpakTCPOLRD As TableCell = New TableCell
      oColhpakTCPOLRD.Font.Bold = True
      oColhpakTCPOLRD.Font.UnderLine = True
      oColhpakTCPOLRD.Font.Size = 10
      oColhpakTCPOLRD.CssClass = "grpHD"
      oColhpakTCPOLRD.Text = "Documents"
      oRowhpakTCPOLRD.Cells.Add(oColhpakTCPOLRD)
      oTblhpakTCPOLRD.Rows.Add(oRowhpakTCPOLRD)
      oColpakTCPOLR.Controls.Add(oTblhpakTCPOLRD)
      oTblpakTCPOLRD = New Table
      oTblpakTCPOLRD.Width = 960
      oTblpakTCPOLRD.GridLines = GridLines.Both
      oTblpakTCPOLRD.Style.Add("margin-left", "10px")
      oTblpakTCPOLRD.Style.Add("margin-right", "10px")
      oRowpakTCPOLRD = New TableRow
      oColpakTCPOLRD = New TableCell
      oColpakTCPOLRD.Text = "Document"
      oColpakTCPOLRD.Font.Bold = True
      oColpakTCPOLRD.CssClass = "colHD"
      oColpakTCPOLRD.Style.Add("text-align","right")
      oRowpakTCPOLRD.Cells.Add(oColpakTCPOLRD)
      oColpakTCPOLRD = New TableCell
      oColpakTCPOLRD.Text = "ID"
      oColpakTCPOLRD.Font.Bold = True
      oColpakTCPOLRD.CssClass = "colHD"
      oColpakTCPOLRD.Style.Add("text-align","left")
      oRowpakTCPOLRD.Cells.Add(oColpakTCPOLRD)
      oColpakTCPOLRD = New TableCell
      oColpakTCPOLRD.Text = "Rev."
      oColpakTCPOLRD.Font.Bold = True
      oColpakTCPOLRD.CssClass = "colHD"
      oColpakTCPOLRD.Style.Add("text-align","left")
      oRowpakTCPOLRD.Cells.Add(oColpakTCPOLRD)
      oColpakTCPOLRD = New TableCell
      oColpakTCPOLRD.Text = "Description"
      oColpakTCPOLRD.Font.Bold = True
      oColpakTCPOLRD.CssClass = "colHD"
      oColpakTCPOLRD.Style.Add("text-align","left")
      oRowpakTCPOLRD.Cells.Add(oColpakTCPOLRD)
      oColpakTCPOLRD = New TableCell
      oColpakTCPOLRD.Text = "File Name"
      oColpakTCPOLRD.Font.Bold = True
      oColpakTCPOLRD.CssClass = "colHD"
      oColpakTCPOLRD.Style.Add("text-align","left")
      oRowpakTCPOLRD.Cells.Add(oColpakTCPOLRD)
      oTblpakTCPOLRD.Rows.Add(oRowpakTCPOLRD)
      For Each opakTCPOLRD As SIS.PAK.pakTCPOLRD In opakTCPOLRDs
        oRowpakTCPOLRD = New TableRow
        oColpakTCPOLRD = New TableCell
        oColpakTCPOLRD.CssClass = "rowHD"
        oColpakTCPOLRD.Text = opakTCPOLRD.DocSerialNo
      oColpakTCPOLRD.Style.Add("text-align","right")
        oRowpakTCPOLRD.Cells.Add(oColpakTCPOLRD)
        oColpakTCPOLRD = New TableCell
        oColpakTCPOLRD.CssClass = "rowHD"
        oColpakTCPOLRD.Text = opakTCPOLRD.DocumentID
      oColpakTCPOLRD.Style.Add("text-align","left")
        oRowpakTCPOLRD.Cells.Add(oColpakTCPOLRD)
        oColpakTCPOLRD = New TableCell
        oColpakTCPOLRD.CssClass = "rowHD"
        oColpakTCPOLRD.Text = opakTCPOLRD.DocumentRev
      oColpakTCPOLRD.Style.Add("text-align","left")
        oRowpakTCPOLRD.Cells.Add(oColpakTCPOLRD)
        oColpakTCPOLRD = New TableCell
        oColpakTCPOLRD.CssClass = "rowHD"
        oColpakTCPOLRD.Text = opakTCPOLRD.DocumentDescription
      oColpakTCPOLRD.Style.Add("text-align","left")
        oRowpakTCPOLRD.Cells.Add(oColpakTCPOLRD)
        oColpakTCPOLRD = New TableCell
        oColpakTCPOLRD.CssClass = "rowHD"
        oColpakTCPOLRD.Text = opakTCPOLRD.FileName
      oColpakTCPOLRD.Style.Add("text-align","left")
        oRowpakTCPOLRD.Cells.Add(oColpakTCPOLRD)
        oTblpakTCPOLRD.Rows.Add(oRowpakTCPOLRD)
      Next
      oColpakTCPOLR.Controls.Add(oTblpakTCPOLRD)
      oTblpakTCPOLR.Rows.Add(oRowpakTCPOLR)
    End If
      Next
      oColpakTCPOL.Controls.Add(oTblpakTCPOLR)
      oTblpakTCPOL.Rows.Add(oRowpakTCPOL)
    End If
      Next
      form1.Controls.Add(oTblpakTCPOL)
    End If
  End Sub
End Class
