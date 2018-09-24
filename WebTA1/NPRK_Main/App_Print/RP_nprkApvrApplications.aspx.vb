Partial Class RP_nprkApvrApplications
  Inherits System.Web.UI.Page
  Private _InfoUrl As String = "~/NPRK_Main/App_Display/DF_nprkApvrApplications.aspx"
  Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _InfoUrl  & "?ClaimID=" & aVal(0) & "&ApplicationID=" & aVal(1)
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    Dim aVal() As String = Request.QueryString("pk").Split("|".ToCharArray)
    Dim ClaimID As Int32 = CType(aVal(0),Int32)
    Dim ApplicationID As Int32 = CType(aVal(1),Int32)
    Dim oVar As SIS.NPRK.nprkApvrApplications = SIS.NPRK.nprkApvrApplications.nprkApvrApplicationsGetByID(ClaimID,ApplicationID)
    Dim oTblnprkApvrApplications As New Table
    oTblnprkApvrApplications.Width = 1000
    oTblnprkApvrApplications.GridLines = GridLines.Both
    oTblnprkApvrApplications.Style.Add("margin-top", "15px")
    oTblnprkApvrApplications.Style.Add("margin-left", "10px")
    Dim oColnprkApvrApplications As TableCell = Nothing
    Dim oRownprkApvrApplications As TableRow = Nothing
    oRownprkApvrApplications = New TableRow
    oColnprkApvrApplications = New TableCell
    oColnprkApvrApplications.Text = "Claim Number"
    oColnprkApvrApplications.Font.Bold = True
    oRownprkApvrApplications.Cells.Add(oColnprkApvrApplications)
    oColnprkApvrApplications = New TableCell
    oColnprkApvrApplications.Text = oVar.ClaimID
      oColnprkApvrApplications.Style.Add("text-align","right")
    oRownprkApvrApplications.Cells.Add(oColnprkApvrApplications)
    oColnprkApvrApplications = New TableCell
    oColnprkApvrApplications.Text = oVar.PRK_UserClaims9_Description
      oColnprkApvrApplications.Style.Add("text-align","right")
    oRownprkApvrApplications.Cells.Add(oColnprkApvrApplications)
    oColnprkApvrApplications = New TableCell
    oColnprkApvrApplications.Text = "Application ID"
    oColnprkApvrApplications.Font.Bold = True
    oRownprkApvrApplications.Cells.Add(oColnprkApvrApplications)
    oColnprkApvrApplications = New TableCell
    oColnprkApvrApplications.Text = oVar.ApplicationID
      oColnprkApvrApplications.Style.Add("text-align","right")
    oColnprkApvrApplications.ColumnSpan = "2"
    oRownprkApvrApplications.Cells.Add(oColnprkApvrApplications)
    oTblnprkApvrApplications.Rows.Add(oRownprkApvrApplications)
    oRownprkApvrApplications = New TableRow
    oColnprkApvrApplications = New TableCell
    oColnprkApvrApplications.Text = "Employee"
    oColnprkApvrApplications.Font.Bold = True
    oRownprkApvrApplications.Cells.Add(oColnprkApvrApplications)
    oColnprkApvrApplications = New TableCell
    oColnprkApvrApplications.Text = oVar.EmployeeID
      oColnprkApvrApplications.Style.Add("text-align","right")
    oRownprkApvrApplications.Cells.Add(oColnprkApvrApplications)
    oColnprkApvrApplications = New TableCell
    oColnprkApvrApplications.Text = oVar.PRK_Employees1_EmployeeName
      oColnprkApvrApplications.Style.Add("text-align","right")
    oRownprkApvrApplications.Cells.Add(oColnprkApvrApplications)
    oColnprkApvrApplications = New TableCell
    oColnprkApvrApplications.Text = "Perk"
    oColnprkApvrApplications.Font.Bold = True
    oRownprkApvrApplications.Cells.Add(oColnprkApvrApplications)
    oColnprkApvrApplications = New TableCell
    oColnprkApvrApplications.Text = oVar.PerkID
      oColnprkApvrApplications.Style.Add("text-align","right")
    oRownprkApvrApplications.Cells.Add(oColnprkApvrApplications)
    oColnprkApvrApplications = New TableCell
    oColnprkApvrApplications.Text = oVar.PRK_Perks7_Description
      oColnprkApvrApplications.Style.Add("text-align","right")
    oRownprkApvrApplications.Cells.Add(oColnprkApvrApplications)
    oTblnprkApvrApplications.Rows.Add(oRownprkApvrApplications)
    oRownprkApvrApplications = New TableRow
    oColnprkApvrApplications = New TableCell
    oColnprkApvrApplications.Text = "Applied On"
    oColnprkApvrApplications.Font.Bold = True
    oRownprkApvrApplications.Cells.Add(oColnprkApvrApplications)
    oColnprkApvrApplications = New TableCell
    oColnprkApvrApplications.Text = oVar.AppliedOn
      oColnprkApvrApplications.Style.Add("text-align","center")
    oColnprkApvrApplications.ColumnSpan = "2"
    oRownprkApvrApplications.Cells.Add(oColnprkApvrApplications)
    oColnprkApvrApplications = New TableCell
    oColnprkApvrApplications.Text = "Claimed Amount"
    oColnprkApvrApplications.Font.Bold = True
    oRownprkApvrApplications.Cells.Add(oColnprkApvrApplications)
    oColnprkApvrApplications = New TableCell
    oColnprkApvrApplications.Text = oVar.Value
      oColnprkApvrApplications.Style.Add("text-align","right")
    oColnprkApvrApplications.ColumnSpan = "2"
    oRownprkApvrApplications.Cells.Add(oColnprkApvrApplications)
    oTblnprkApvrApplications.Rows.Add(oRownprkApvrApplications)
    oRownprkApvrApplications = New TableRow
    oColnprkApvrApplications = New TableCell
    oColnprkApvrApplications.Text = "User Remark"
    oColnprkApvrApplications.Font.Bold = True
    oRownprkApvrApplications.Cells.Add(oColnprkApvrApplications)
    oColnprkApvrApplications = New TableCell
    oColnprkApvrApplications.Text = oVar.UserRemark
      oColnprkApvrApplications.Style.Add("text-align","left")
    oColnprkApvrApplications.ColumnSpan = "5"
    oRownprkApvrApplications.Cells.Add(oColnprkApvrApplications)
    oTblnprkApvrApplications.Rows.Add(oRownprkApvrApplications)
    form1.Controls.Add(oTblnprkApvrApplications)
      Dim oTblnprkBillDetails As Table = Nothing
      Dim oRownprkBillDetails As TableRow = Nothing
      Dim oColnprkBillDetails As TableCell = Nothing
    Dim onprkBillDetailss As List(Of SIS.NPRK.nprkBillDetails) = SIS.NPRK.nprkBillDetails.UZ_nprkBillDetailsSelectList(0, 999, "", False, "", oVar.ClaimID, oVar.ApplicationID)
    If onprkBillDetailss.Count > 0 Then
      Dim oTblhnprkBillDetails As Table = New Table
      oTblhnprkBillDetails.Width = 1000
      oTblhnprkBillDetails.Style.Add("margin-top", "15px")
      oTblhnprkBillDetails.Style.Add("margin-left", "10px")
      oTblhnprkBillDetails.Style.Add("margin-right", "10px")
      Dim oRowhnprkBillDetails As TableRow = New TableRow
      Dim oColhnprkBillDetails As TableCell = New TableCell
      oColhnprkBillDetails.Font.Bold = True
      oColhnprkBillDetails.Font.UnderLine = True
      oColhnprkBillDetails.Font.Size = 10
      oColhnprkBillDetails.CssClass = "grpHD"
      oColhnprkBillDetails.Text = "Bill Details"
      oRowhnprkBillDetails.Cells.Add(oColhnprkBillDetails)
      oTblhnprkBillDetails.Rows.Add(oRowhnprkBillDetails)
      form1.Controls.Add(oTblhnprkBillDetails)
      oTblnprkBillDetails = New Table
      oTblnprkBillDetails.Width = 1000
      oTblnprkBillDetails.GridLines = GridLines.Both
      oTblnprkBillDetails.Style.Add("margin-left", "10px")
      oTblnprkBillDetails.Style.Add("margin-right", "10px")
      oRownprkBillDetails = New TableRow
      oColnprkBillDetails = New TableCell
      oColnprkBillDetails.Text = "ID"
      oColnprkBillDetails.Font.Bold = True
      oColnprkBillDetails.CssClass = "colHD"
      oColnprkBillDetails.Style.Add("text-align","center")
      oRownprkBillDetails.Cells.Add(oColnprkBillDetails)
      oColnprkBillDetails = New TableCell
      oColnprkBillDetails.Text = "Description"
      oColnprkBillDetails.Font.Bold = True
      oColnprkBillDetails.CssClass = "colHD"
      oColnprkBillDetails.Style.Add("text-align","left")
      oRownprkBillDetails.Cells.Add(oColnprkBillDetails)
      oColnprkBillDetails = New TableCell
      oColnprkBillDetails.Text = "PARTICULARS"
      oColnprkBillDetails.Font.Bold = True
      oColnprkBillDetails.CssClass = "colHD"
      oColnprkBillDetails.Style.Add("text-align","left")
      oRownprkBillDetails.Cells.Add(oColnprkBillDetails)
      oColnprkBillDetails = New TableCell
      oColnprkBillDetails.Text = "BILL AMT."
      oColnprkBillDetails.Font.Bold = True
      oColnprkBillDetails.CssClass = "colHD"
      oColnprkBillDetails.Style.Add("text-align","right")
      oRownprkBillDetails.Cells.Add(oColnprkBillDetails)
      oColnprkBillDetails = New TableCell
      oColnprkBillDetails.Text = "CLAIMED AMT."
      oColnprkBillDetails.Font.Bold = True
      oColnprkBillDetails.CssClass = "colHD"
      oColnprkBillDetails.Style.Add("text-align","right")
      oRownprkBillDetails.Cells.Add(oColnprkBillDetails)
      oTblnprkBillDetails.Rows.Add(oRownprkBillDetails)
      For Each onprkBillDetails As SIS.NPRK.nprkBillDetails In onprkBillDetailss
        oRownprkBillDetails = New TableRow
        oColnprkBillDetails = New TableCell
        oColnprkBillDetails.CssClass = "rowHD"
        oColnprkBillDetails.Text = onprkBillDetails.SerialNo
      oColnprkBillDetails.Style.Add("text-align","center")
        oRownprkBillDetails.Cells.Add(oColnprkBillDetails)
        oColnprkBillDetails = New TableCell
        oColnprkBillDetails.CssClass = "rowHD"
        oColnprkBillDetails.Text = onprkBillDetails.Description
      oColnprkBillDetails.Style.Add("text-align","left")
        oRownprkBillDetails.Cells.Add(oColnprkBillDetails)
        oColnprkBillDetails = New TableCell
        oColnprkBillDetails.CssClass = "rowHD"
        oColnprkBillDetails.Text = onprkBillDetails.Particulars
      oColnprkBillDetails.Style.Add("text-align","left")
        oRownprkBillDetails.Cells.Add(oColnprkBillDetails)
        oColnprkBillDetails = New TableCell
        oColnprkBillDetails.CssClass = "rowHD"
        oColnprkBillDetails.Text = onprkBillDetails.Quantity
      oColnprkBillDetails.Style.Add("text-align","right")
        oRownprkBillDetails.Cells.Add(oColnprkBillDetails)
        oColnprkBillDetails = New TableCell
        oColnprkBillDetails.CssClass = "rowHD"
        oColnprkBillDetails.Text = onprkBillDetails.Amount
      oColnprkBillDetails.Style.Add("text-align","right")
        oRownprkBillDetails.Cells.Add(oColnprkBillDetails)
        oTblnprkBillDetails.Rows.Add(oRownprkBillDetails)
      Next
      form1.Controls.Add(oTblnprkBillDetails)
    End If
  End Sub
End Class
