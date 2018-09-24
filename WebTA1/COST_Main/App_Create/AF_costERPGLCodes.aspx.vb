Partial Class AF_costERPGLCodes
  Inherits SIS.SYS.InsertBase
  Protected Sub FVcostERPGLCodes_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVcostERPGLCodes.Init
    DataClassName = "AcostERPGLCodes"
    SetFormView = FVcostERPGLCodes
  End Sub
  Protected Sub TBLcostERPGLCodes_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLcostERPGLCodes.Init
    SetToolBar = TBLcostERPGLCodes
  End Sub
  Protected Sub FVcostERPGLCodes_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVcostERPGLCodes.DataBound
    SIS.COST.costERPGLCodes.SetDefaultValues(sender, e) 
  End Sub
  Protected Sub FVcostERPGLCodes_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVcostERPGLCodes.PreRender
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/COST_Main/App_Create") & "/AF_costERPGLCodes.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptcostERPGLCodes") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptcostERPGLCodes", mStr)
    End If
    If Request.QueryString("GLCode") IsNot Nothing Then
      CType(FVcostERPGLCodes.FindControl("F_GLCode"), TextBox).Text = Request.QueryString("GLCode")
      CType(FVcostERPGLCodes.FindControl("F_GLCode"), TextBox).Enabled = False
    End If
  End Sub
  <System.Web.Services.WebMethod()> _
  Public Shared Function validatePK_costERPGLCodes(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
    Dim GLCode As String = CType(aVal(1),String)
    Dim oVar As SIS.COST.costERPGLCodes = SIS.COST.costERPGLCodes.costERPGLCodesGetByID(GLCode)
    If Not oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record allready exists." 
    End If
    Return mRet
  End Function

End Class
