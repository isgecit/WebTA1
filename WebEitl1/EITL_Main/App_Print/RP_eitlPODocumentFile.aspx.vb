Partial Class RP_eitlPODocumentFile
  Inherits System.Web.UI.Page
  Private _InfoUrl As String = "~/EITL_Main/App_Display/DF_eitlPODocumentFile.aspx"
  Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _InfoUrl  & "?SerialNo=" & aVal(0) & "&DocumentLineNo=" & aVal(1) & "&FileNo=" & aVal(2)
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    Dim aVal() As String = Request.QueryString("pk").Split("|".ToCharArray)
		Dim SerialNo As Int32 = CType(aVal(0),Int32)
		Dim DocumentLineNo As Int32 = CType(aVal(1),Int32)
		Dim FileNo As Int32 = CType(aVal(2),Int32)
		Dim oVar As SIS.EITL.eitlPODocumentFile = SIS.EITL.eitlPODocumentFile.eitlPODocumentFileGetByID(SerialNo,DocumentLineNo,FileNo)
    Dim oTbl As New Table
    oTbl.Width = 1000
    Dim oCol As TableCell = Nothing
    Dim oRow As TableRow = Nothing
    oRow = New TableRow
    oCol = New TableCell
    oCol.Text = "SerialNo"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.SerialNo
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.EITL_POList2_PONumber
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "DocumentLineNo"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.DocumentLineNo
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.EITL_PODocumentList1_DocumentID
    oRow.Cells.Add(oCol)
    oTbl.Rows.Add(oRow)
    oRow = New TableRow
    oCol = New TableCell
    oCol.Text = "FileNo"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.FileNo
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
    oCol.Text = "FileName"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.FileName
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = ""
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "DiskFile"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.DiskFile
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = ""
    oRow.Cells.Add(oCol)
    oTbl.Rows.Add(oRow)
    oRow = New TableRow
    form1.Controls.Add(oTbl)
  End Sub
End Class
