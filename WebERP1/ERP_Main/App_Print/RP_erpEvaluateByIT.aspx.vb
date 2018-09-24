Partial Public Class RP_erpEvaluateByIT
	Inherits System.Web.UI.Page
	Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
		Dim aVal() As String = Request.QueryString("pk").Split("|".ToCharArray)
		Dim ApplID As Int32 = CType(aVal(0), Int32)
		Dim RequestID As Int32 = CType(aVal(1), Int32)
		form1.Controls.Add(SIS.ERP.erpChaneRequest.GetTable(ApplID, RequestID))
	End Sub

End Class
