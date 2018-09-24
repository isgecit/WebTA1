Partial Class AF_eitlSuppliers
  Inherits SIS.SYS.InsertBase
  Protected Sub FVeitlSuppliers_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVeitlSuppliers.Init
    DataClassName = "AeitlSuppliers"
    SetFormView = FVeitlSuppliers
  End Sub
  Protected Sub TBLeitlSuppliers_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLeitlSuppliers.Init
    SetToolBar = TBLeitlSuppliers
  End Sub
  Protected Sub FVeitlSuppliers_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVeitlSuppliers.PreRender
		Dim mStr As String = ""
		Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/EITL_Main/App_Create") & "/AF_eitlSuppliers.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scripteitlSuppliers") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scripteitlSuppliers", mStr)
    End If
    If Request.QueryString("SupplierID") IsNot Nothing Then
      CType(FVeitlSuppliers.FindControl("F_SupplierID"), TextBox).Text = Request.QueryString("SupplierID")
      CType(FVeitlSuppliers.FindControl("F_SupplierID"), TextBox).Enabled = False
    End If
  End Sub
	<System.Web.Services.WebMethod()> _
  Public Shared Function validatePK_eitlSuppliers(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
		Dim SupplierID As String = CType(aVal(1),String)
		Dim oVar As SIS.EITL.eitlSuppliers = SIS.EITL.eitlSuppliers.eitlSuppliersGetByID(SupplierID)
    If Not oVar Is Nothing Then
			mRet = "1|" & aVal(0) & "|Record allready exists." 
    End If
    Return mRet
  End Function

End Class
