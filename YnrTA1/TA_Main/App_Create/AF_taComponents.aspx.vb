Partial Class AF_taComponents
  Inherits SIS.SYS.InsertBase
  Protected Sub FVtaComponents_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVtaComponents.Init
    DataClassName = "AtaComponents"
    SetFormView = FVtaComponents
  End Sub
  Protected Sub TBLtaComponents_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLtaComponents.Init
    SetToolBar = TBLtaComponents
  End Sub
  Protected Sub FVtaComponents_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVtaComponents.DataBound
    SIS.TA.taComponents.SetDefaultValues(sender, e) 
  End Sub
  Protected Sub FVtaComponents_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVtaComponents.PreRender
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/TA_Main/App_Create") & "/AF_taComponents.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scripttaComponents") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scripttaComponents", mStr)
    End If
    If Request.QueryString("ComponentID") IsNot Nothing Then
      CType(FVtaComponents.FindControl("F_ComponentID"), TextBox).Text = Request.QueryString("ComponentID")
      CType(FVtaComponents.FindControl("F_ComponentID"), TextBox).Enabled = False
    End If
  End Sub

End Class
