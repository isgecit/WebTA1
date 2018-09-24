Partial Class RP_ediWTmtlH
  Inherits System.Web.UI.Page
  Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    Dim aVal() As String = Request.QueryString("pk").Split("|".ToCharArray)
    Dim t_tran As String = CType(aVal(0), String)
    Dim oVar As SIS.EDI.ediWTmtlH = SIS.EDI.ediWTmtlH.ediWTmtlHGetByID(t_tran)
    Dim oTblediWTmtlH As New Table
    oTblediWTmtlH.Width = 1000
    oTblediWTmtlH.GridLines = GridLines.Both
    oTblediWTmtlH.Style.Add("margin-top", "15px")
    oTblediWTmtlH.Style.Add("margin-left", "10px")
    Dim oColediWTmtlH As TableCell = Nothing
    Dim oRowediWTmtlH As TableRow = Nothing
    oRowediWTmtlH = New TableRow
    oColediWTmtlH = New TableCell
    oColediWTmtlH.Text = "Transmittal No."
    oColediWTmtlH.Font.Bold = True
    oRowediWTmtlH.Cells.Add(oColediWTmtlH)
    oColediWTmtlH = New TableCell
    oColediWTmtlH.Text = oVar.t_tran
    oColediWTmtlH.Style.Add("text-align", "left")
    oColediWTmtlH.ColumnSpan = "2"
    oRowediWTmtlH.Cells.Add(oColediWTmtlH)
    oColediWTmtlH = New TableCell
    oColediWTmtlH.Text = "Reference No."
    oColediWTmtlH.Font.Bold = True
    oRowediWTmtlH.Cells.Add(oColediWTmtlH)
    oColediWTmtlH = New TableCell
    oColediWTmtlH.Text = oVar.t_refr
    oColediWTmtlH.Style.Add("text-align", "left")
    oColediWTmtlH.ColumnSpan = "2"
    oRowediWTmtlH.Cells.Add(oColediWTmtlH)
    oTblediWTmtlH.Rows.Add(oRowediWTmtlH)
    oRowediWTmtlH = New TableRow
    oColediWTmtlH = New TableCell
    oColediWTmtlH.Text = "Tmtl. Type"
    oColediWTmtlH.Font.Bold = True
    oRowediWTmtlH.Cells.Add(oColediWTmtlH)
    oColediWTmtlH = New TableCell
    oColediWTmtlH.Text = oVar.t_type
    oColediWTmtlH.Style.Add("text-align", "right")
    oColediWTmtlH.ColumnSpan = "2"
    oRowediWTmtlH.Cells.Add(oColediWTmtlH)
    oColediWTmtlH = New TableCell
    oColediWTmtlH.Text = "Tmtl. Project"
    oColediWTmtlH.Font.Bold = True
    oRowediWTmtlH.Cells.Add(oColediWTmtlH)
    oColediWTmtlH = New TableCell
    oColediWTmtlH.Text = oVar.t_cprj
    oColediWTmtlH.Style.Add("text-align", "left")
    oColediWTmtlH.ColumnSpan = "2"
    oRowediWTmtlH.Cells.Add(oColediWTmtlH)
    oTblediWTmtlH.Rows.Add(oRowediWTmtlH)
    oRowediWTmtlH = New TableRow
    oColediWTmtlH = New TableCell
    oColediWTmtlH.Text = "Customer"
    oColediWTmtlH.Font.Bold = True
    oRowediWTmtlH.Cells.Add(oColediWTmtlH)
    oColediWTmtlH = New TableCell
    oColediWTmtlH.Text = oVar.t_bpid
    oColediWTmtlH.Style.Add("text-align", "left")
    oColediWTmtlH.ColumnSpan = "2"
    oRowediWTmtlH.Cells.Add(oColediWTmtlH)
    oColediWTmtlH = New TableCell
    oColediWTmtlH.Text = "Vendor"
    oColediWTmtlH.Font.Bold = True
    oRowediWTmtlH.Cells.Add(oColediWTmtlH)
    oColediWTmtlH = New TableCell
    oColediWTmtlH.Text = oVar.t_ofbp
    oColediWTmtlH.Style.Add("text-align", "left")
    oColediWTmtlH.ColumnSpan = "2"
    oRowediWTmtlH.Cells.Add(oColediWTmtlH)
    oTblediWTmtlH.Rows.Add(oRowediWTmtlH)
    oRowediWTmtlH = New TableRow
    oColediWTmtlH = New TableCell
    oColediWTmtlH.Text = "Employee"
    oColediWTmtlH.Font.Bold = True
    oRowediWTmtlH.Cells.Add(oColediWTmtlH)
    oColediWTmtlH = New TableCell
    oColediWTmtlH.Text = oVar.t_logn
    oColediWTmtlH.Style.Add("text-align", "left")
    oColediWTmtlH.ColumnSpan = "2"
    oRowediWTmtlH.Cells.Add(oColediWTmtlH)
    oColediWTmtlH = New TableCell
    oColediWTmtlH.Text = "Project"
    oColediWTmtlH.Font.Bold = True
    oRowediWTmtlH.Cells.Add(oColediWTmtlH)
    oColediWTmtlH = New TableCell
    oColediWTmtlH.Text = oVar.t_dprj
    oColediWTmtlH.Style.Add("text-align", "left")
    oColediWTmtlH.ColumnSpan = "2"
    oRowediWTmtlH.Cells.Add(oColediWTmtlH)
    oTblediWTmtlH.Rows.Add(oRowediWTmtlH)
    oRowediWTmtlH = New TableRow
    oColediWTmtlH = New TableCell
    oColediWTmtlH.Text = "Issued Via"
    oColediWTmtlH.Font.Bold = True
    oRowediWTmtlH.Cells.Add(oColediWTmtlH)
    oColediWTmtlH = New TableCell
    oColediWTmtlH.Text = oVar.t_issu
    oColediWTmtlH.Style.Add("text-align", "left")
    oColediWTmtlH.ColumnSpan = "5"
    oRowediWTmtlH.Cells.Add(oColediWTmtlH)
    oTblediWTmtlH.Rows.Add(oRowediWTmtlH)
    oRowediWTmtlH = New TableRow
    oColediWTmtlH = New TableCell
    oColediWTmtlH.Text = "Subject"
    oColediWTmtlH.Font.Bold = True
    oRowediWTmtlH.Cells.Add(oColediWTmtlH)
    oColediWTmtlH = New TableCell
    oColediWTmtlH.Text = oVar.t_subj
    oColediWTmtlH.Style.Add("text-align", "left")
    oColediWTmtlH.ColumnSpan = "5"
    oRowediWTmtlH.Cells.Add(oColediWTmtlH)
    oTblediWTmtlH.Rows.Add(oRowediWTmtlH)
    oRowediWTmtlH = New TableRow
    oColediWTmtlH = New TableCell
    oColediWTmtlH.Text = "Remarks"
    oColediWTmtlH.Font.Bold = True
    oRowediWTmtlH.Cells.Add(oColediWTmtlH)
    oColediWTmtlH = New TableCell
    oColediWTmtlH.Text = oVar.t_remk
    oColediWTmtlH.Style.Add("text-align", "left")
    oColediWTmtlH.ColumnSpan = "5"
    oRowediWTmtlH.Cells.Add(oColediWTmtlH)
    oTblediWTmtlH.Rows.Add(oRowediWTmtlH)
    oRowediWTmtlH = New TableRow
    oColediWTmtlH = New TableCell
    oColediWTmtlH.Text = "Created By"
    oColediWTmtlH.Font.Bold = True
    oRowediWTmtlH.Cells.Add(oColediWTmtlH)
    oColediWTmtlH = New TableCell
    oColediWTmtlH.Text = oVar.t_user
    oColediWTmtlH.Style.Add("text-align", "left")
    oColediWTmtlH.ColumnSpan = "2"
    oRowediWTmtlH.Cells.Add(oColediWTmtlH)
    oColediWTmtlH = New TableCell
    oColediWTmtlH.Text = "Created On"
    oColediWTmtlH.Font.Bold = True
    oRowediWTmtlH.Cells.Add(oColediWTmtlH)
    oColediWTmtlH = New TableCell
    oColediWTmtlH.Text = oVar.t_date
    oColediWTmtlH.Style.Add("text-align", "center")
    oColediWTmtlH.ColumnSpan = "2"
    oRowediWTmtlH.Cells.Add(oColediWTmtlH)
    oTblediWTmtlH.Rows.Add(oRowediWTmtlH)
    oRowediWTmtlH = New TableRow
    oColediWTmtlH = New TableCell
    oColediWTmtlH.Text = "Approved By"
    oColediWTmtlH.Font.Bold = True
    oRowediWTmtlH.Cells.Add(oColediWTmtlH)
    oColediWTmtlH = New TableCell
    oColediWTmtlH.Text = oVar.t_apsu
    oColediWTmtlH.Style.Add("text-align", "left")
    oColediWTmtlH.ColumnSpan = "2"
    oRowediWTmtlH.Cells.Add(oColediWTmtlH)
    oColediWTmtlH = New TableCell
    oColediWTmtlH.Text = "Approved On"
    oColediWTmtlH.Font.Bold = True
    oRowediWTmtlH.Cells.Add(oColediWTmtlH)
    oColediWTmtlH = New TableCell
    oColediWTmtlH.Text = oVar.t_apdt
    oColediWTmtlH.Style.Add("text-align", "center")
    oColediWTmtlH.ColumnSpan = "2"
    oRowediWTmtlH.Cells.Add(oColediWTmtlH)
    oTblediWTmtlH.Rows.Add(oRowediWTmtlH)
    oRowediWTmtlH = New TableRow
    oColediWTmtlH = New TableCell
    oColediWTmtlH.Text = "Issued By"
    oColediWTmtlH.Font.Bold = True
    oRowediWTmtlH.Cells.Add(oColediWTmtlH)
    oColediWTmtlH = New TableCell
    oColediWTmtlH.Text = oVar.t_isby
    oColediWTmtlH.Style.Add("text-align", "left")
    oColediWTmtlH.ColumnSpan = "2"
    oRowediWTmtlH.Cells.Add(oColediWTmtlH)
    oColediWTmtlH = New TableCell
    oColediWTmtlH.Text = "Issued On"
    oColediWTmtlH.Font.Bold = True
    oRowediWTmtlH.Cells.Add(oColediWTmtlH)
    oColediWTmtlH = New TableCell
    oColediWTmtlH.Text = oVar.t_isdt
    oColediWTmtlH.Style.Add("text-align", "center")
    oColediWTmtlH.ColumnSpan = "2"
    oRowediWTmtlH.Cells.Add(oColediWTmtlH)
    oTblediWTmtlH.Rows.Add(oRowediWTmtlH)
    form1.Controls.Add(oTblediWTmtlH)
    Dim oTblediWTmtlD As Table = Nothing
    Dim oRowediWTmtlD As TableRow = Nothing
    Dim oColediWTmtlD As TableCell = Nothing
    Dim oediWTmtlDs As List(Of SIS.EDI.ediWTmtlD) = SIS.EDI.ediWTmtlD.UZ_ediWTmtlDSelectList(0, 999, "", False, "", oVar.t_tran)
    If oediWTmtlDs.Count > 0 Then
      Dim oTblhediWTmtlD As Table = New Table
      oTblhediWTmtlD.Width = 1000
      oTblhediWTmtlD.Style.Add("margin-top", "15px")
      oTblhediWTmtlD.Style.Add("margin-left", "10px")
      oTblhediWTmtlD.Style.Add("margin-right", "10px")
      Dim oRowhediWTmtlD As TableRow = New TableRow
      Dim oColhediWTmtlD As TableCell = New TableCell
      oColhediWTmtlD.Font.Bold = True
      oColhediWTmtlD.Font.Underline = True
      oColhediWTmtlD.Font.Size = 10
      oColhediWTmtlD.CssClass = "grpHD"
      oColhediWTmtlD.Text = "Transmittal Detail"
      oRowhediWTmtlD.Cells.Add(oColhediWTmtlD)
      oTblhediWTmtlD.Rows.Add(oRowhediWTmtlD)
      form1.Controls.Add(oTblhediWTmtlD)
      oTblediWTmtlD = New Table
      oTblediWTmtlD.Width = 1000
      oTblediWTmtlD.GridLines = GridLines.Both
      oTblediWTmtlD.Style.Add("margin-left", "10px")
      oTblediWTmtlD.Style.Add("margin-right", "10px")
      oRowediWTmtlD = New TableRow
      oColediWTmtlD = New TableCell
      oColediWTmtlD.Text = "Transmittal No."
      oColediWTmtlD.Font.Bold = True
      oColediWTmtlD.CssClass = "colHD"
      oColediWTmtlD.Style.Add("text-align", "left")
      oRowediWTmtlD.Cells.Add(oColediWTmtlD)
      oColediWTmtlD = New TableCell
      oColediWTmtlD.Text = "Document ID"
      oColediWTmtlD.Font.Bold = True
      oColediWTmtlD.CssClass = "colHD"
      oColediWTmtlD.Style.Add("text-align", "left")
      oRowediWTmtlD.Cells.Add(oColediWTmtlD)
      oColediWTmtlD = New TableCell
      oColediWTmtlD.Text = "Revision No."
      oColediWTmtlD.Font.Bold = True
      oColediWTmtlD.CssClass = "colHD"
      oColediWTmtlD.Style.Add("text-align", "left")
      oRowediWTmtlD.Cells.Add(oColediWTmtlD)
      oColediWTmtlD = New TableCell
      oColediWTmtlD.Text = "Remarks"
      oColediWTmtlD.Font.Bold = True
      oColediWTmtlD.CssClass = "colHD"
      oColediWTmtlD.Style.Add("text-align", "left")
      oRowediWTmtlD.Cells.Add(oColediWTmtlD)
      oTblediWTmtlD.Rows.Add(oRowediWTmtlD)
      For Each oediWTmtlD As SIS.EDI.ediWTmtlD In oediWTmtlDs
        oRowediWTmtlD = New TableRow
        oColediWTmtlD = New TableCell
        oColediWTmtlD.CssClass = "rowHD"
        oColediWTmtlD.Text = oediWTmtlD.t_tran
        oColediWTmtlD.Style.Add("text-align", "left")
        oRowediWTmtlD.Cells.Add(oColediWTmtlD)
        oColediWTmtlD = New TableCell
        oColediWTmtlD.CssClass = "rowHD"
        oColediWTmtlD.Text = oediWTmtlD.t_docn
        oColediWTmtlD.Style.Add("text-align", "left")
        oRowediWTmtlD.Cells.Add(oColediWTmtlD)
        oColediWTmtlD = New TableCell
        oColediWTmtlD.CssClass = "rowHD"
        oColediWTmtlD.Text = oediWTmtlD.t_revn
        oColediWTmtlD.Style.Add("text-align", "left")
        oRowediWTmtlD.Cells.Add(oColediWTmtlD)
        oColediWTmtlD = New TableCell
        oColediWTmtlD.CssClass = "rowHD"
        oColediWTmtlD.Text = oediWTmtlD.t_remk
        oColediWTmtlD.Style.Add("text-align", "left")
        oRowediWTmtlD.Cells.Add(oColediWTmtlD)
        oTblediWTmtlD.Rows.Add(oRowediWTmtlD)
      Next
      form1.Controls.Add(oTblediWTmtlD)
    End If
  End Sub
End Class
