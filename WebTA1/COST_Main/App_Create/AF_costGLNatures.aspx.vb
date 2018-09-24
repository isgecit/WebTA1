Partial Class AF_costGLNatures
  Inherits SIS.SYS.InsertBase
  Protected Sub FVcostGLNatures_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVcostGLNatures.Init
    DataClassName = "AcostGLNatures"
    SetFormView = FVcostGLNatures
  End Sub
  Protected Sub TBLcostGLNatures_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLcostGLNatures.Init
    SetToolBar = TBLcostGLNatures
  End Sub
  Protected Sub FVcostGLNatures_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVcostGLNatures.DataBound
    SIS.COST.costGLNatures.SetDefaultValues(sender, e) 
  End Sub
  Protected Sub FVcostGLNatures_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVcostGLNatures.PreRender
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/COST_Main/App_Create") & "/AF_costGLNatures.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptcostGLNatures") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptcostGLNatures", mStr)
    End If
    If Request.QueryString("GLNatureID") IsNot Nothing Then
      CType(FVcostGLNatures.FindControl("F_GLNatureID"), TextBox).Text = Request.QueryString("GLNatureID")
      CType(FVcostGLNatures.FindControl("F_GLNatureID"), TextBox).Enabled = False
    End If
  End Sub

End Class
