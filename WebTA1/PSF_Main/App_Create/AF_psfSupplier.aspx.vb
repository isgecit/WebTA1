Partial Class AF_psfSupplier
  Inherits SIS.SYS.InsertBase
  Protected Sub FVpsfSupplier_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpsfSupplier.Init
    DataClassName = "ApsfSupplier"
    SetFormView = FVpsfSupplier
  End Sub
  Protected Sub TBLpsfSupplier_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLpsfSupplier.Init
    SetToolBar = TBLpsfSupplier
  End Sub
  Protected Sub FVpsfSupplier_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpsfSupplier.DataBound
    SIS.PSF.psfSupplier.SetDefaultValues(sender, e) 
  End Sub
  Protected Sub FVpsfSupplier_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpsfSupplier.PreRender
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/PSF_Main/App_Create") & "/AF_psfSupplier.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptpsfSupplier") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptpsfSupplier", mStr)
    End If
    If Request.QueryString("SupplierID") IsNot Nothing Then
      CType(FVpsfSupplier.FindControl("F_SupplierID"), TextBox).Text = Request.QueryString("SupplierID")
      CType(FVpsfSupplier.FindControl("F_SupplierID"), TextBox).Enabled = False
    End If
  End Sub
  <System.Web.Services.WebMethod()> _
  Public Shared Function validatePK_psfSupplier(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
    Dim SupplierID As String = CType(aVal(1),String)
    Dim oVar As SIS.PSF.psfSupplier = SIS.PSF.psfSupplier.psfSupplierGetByID(SupplierID)
    If Not oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record allready exists." 
    End If
    Return mRet
  End Function

End Class
