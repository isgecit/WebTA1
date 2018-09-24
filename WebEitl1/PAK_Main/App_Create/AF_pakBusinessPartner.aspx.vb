Partial Class AF_pakBusinessPartner
  Inherits SIS.SYS.InsertBase
  Protected Sub FVpakBusinessPartner_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpakBusinessPartner.Init
    DataClassName = "ApakBusinessPartner"
    SetFormView = FVpakBusinessPartner
  End Sub
  Protected Sub TBLpakBusinessPartner_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLpakBusinessPartner.Init
    SetToolBar = TBLpakBusinessPartner
  End Sub
  Protected Sub FVpakBusinessPartner_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpakBusinessPartner.DataBound
    SIS.PAK.pakBusinessPartner.SetDefaultValues(sender, e) 
  End Sub
  Protected Sub FVpakBusinessPartner_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpakBusinessPartner.PreRender
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/PAK_Main/App_Create") & "/AF_pakBusinessPartner.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptpakBusinessPartner") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptpakBusinessPartner", mStr)
    End If
    If Request.QueryString("BPID") IsNot Nothing Then
      CType(FVpakBusinessPartner.FindControl("F_BPID"), TextBox).Text = Request.QueryString("BPID")
      CType(FVpakBusinessPartner.FindControl("F_BPID"), TextBox).Enabled = False
    End If
  End Sub

End Class
