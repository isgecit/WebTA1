Partial Class AF_pakReasons
  Inherits SIS.SYS.InsertBase
  Protected Sub FVpakReasons_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpakReasons.Init
    DataClassName = "ApakReasons"
    SetFormView = FVpakReasons
  End Sub
  Protected Sub TBLpakReasons_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLpakReasons.Init
    SetToolBar = TBLpakReasons
  End Sub
  Protected Sub FVpakReasons_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpakReasons.DataBound
    SIS.PAK.pakReasons.SetDefaultValues(sender, e) 
  End Sub
  Protected Sub FVpakReasons_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpakReasons.PreRender
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/PAK_Main/App_Create") & "/AF_pakReasons.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptpakReasons") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptpakReasons", mStr)
    End If
    If Request.QueryString("ReasonID") IsNot Nothing Then
      CType(FVpakReasons.FindControl("F_ReasonID"), TextBox).Text = Request.QueryString("ReasonID")
      CType(FVpakReasons.FindControl("F_ReasonID"), TextBox).Enabled = False
    End If
  End Sub

End Class
