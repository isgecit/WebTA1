Partial Class RP_eitlPODocumentList
  Inherits System.Web.UI.Page
  Private _InfoUrl As String = "~/EITL_Main/App_Display/DF_eitlPODocumentList.aspx"
  Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _InfoUrl  & "?SerialNo=" & aVal(0) & "&DocumentLineNo=" & aVal(1)
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    Dim aVal() As String = Request.QueryString("pk").Split("|".ToCharArray)
		Dim SerialNo As Int32 = CType(aVal(0),Int32)
		Dim DocumentLineNo As Int32 = CType(aVal(1),Int32)
		Dim oVar As SIS.EITL.eitlPODocumentList = SIS.EITL.eitlPODocumentList.eitlPODocumentListGetByID(SerialNo,DocumentLineNo)
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
    oCol.Text = ""
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Document Line No"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.DocumentLineNo
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = ""
    oRow.Cells.Add(oCol)
    oTbl.Rows.Add(oRow)
    oRow = New TableRow
    oCol = New TableCell
    oCol.Text = "Document ID"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.DocumentID
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = ""
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Revision No"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.RevisionNo
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = ""
    oRow.Cells.Add(oCol)
    oTbl.Rows.Add(oRow)
    oRow = New TableRow
    oCol = New TableCell
    oCol.Text = "Description"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.Description
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = ""
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Ready To Despatch"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = IIf(oVar.ReadyToDespatch, "YES", "NO")
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = ""
    oRow.Cells.Add(oCol)
    oTbl.Rows.Add(oRow)
    oRow = New TableRow
    form1.Controls.Add(oTbl)
    Dim oeitlPODocumentFiles As List(Of SIS.EITL.eitlPODocumentFile) = SIS.EITL.eitlPODocumentFile.eitlPODocumentFileSelectList(0, 999, "", False, "", SerialNo, DocumentLineNo)
    oTbl = New Table
    oTbl.GridLines = GridLines.Both
    oRow = New TableRow
    oCol = New TableCell
    oCol.Text = "SerialNo"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "PO Number"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "DocumentLineNo"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Document ID"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "FileNo"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Description"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "FileName"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "DiskFile"
    oRow.Cells.Add(oCol)
    oTbl.Rows.Add(oRow)
    For Each oeitlPODocumentFile As SIS.EITL.eitlPODocumentFile In oeitlPODocumentFiles
      oRow = New TableRow
      oCol = New TableCell
      oCol.Text = oeitlPODocumentFile.SerialNo
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = oeitlPODocumentFile.EITL_POList2_PONumber
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = oeitlPODocumentFile.DocumentLineNo
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = oeitlPODocumentFile.EITL_PODocumentList1_DocumentID
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = oeitlPODocumentFile.FileNo
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = oeitlPODocumentFile.Description
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = oeitlPODocumentFile.FileName
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = oeitlPODocumentFile.DiskFile
      oRow.Cells.Add(oCol)
      oTbl.Rows.Add(oRow)
    Next
    form1.Controls.Add(oTbl)
  End Sub
End Class
