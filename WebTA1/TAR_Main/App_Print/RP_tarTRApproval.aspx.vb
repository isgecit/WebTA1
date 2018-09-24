Partial Class RP_tarTRApproval
  Inherits System.Web.UI.Page
  Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    Dim aVal() As String = Request.QueryString("pk").Split("|".ToCharArray)
    Dim RequestID As Int32 = CType(aVal(0), Int32)
    form1.Controls.Add(New LiteralControl(SIS.TAR.tarTravelRequest.GetTRHtml(RequestID, TARequestStates.UnderApproval)))
  End Sub
End Class
