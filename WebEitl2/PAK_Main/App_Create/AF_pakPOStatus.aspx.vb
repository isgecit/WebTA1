Partial Class AF_pakPOStatus
  Inherits SIS.SYS.InsertBase
  Protected Sub FVpakPOStatus_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpakPOStatus.Init
    DataClassName = "ApakPOStatus"
    SetFormView = FVpakPOStatus
  End Sub
  Protected Sub TBLpakPOStatus_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLpakPOStatus.Init
    SetToolBar = TBLpakPOStatus
  End Sub
  Protected Sub FVpakPOStatus_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpakPOStatus.DataBound
    SIS.PAK.pakPOStatus.SetDefaultValues(sender, e) 
  End Sub
  Protected Sub FVpakPOStatus_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpakPOStatus.PreRender
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/PAK_Main/App_Create") & "/AF_pakPOStatus.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptpakPOStatus") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptpakPOStatus", mStr)
    End If
    If Request.QueryString("StatusID") IsNot Nothing Then
      CType(FVpakPOStatus.FindControl("F_StatusID"), TextBox).Text = Request.QueryString("StatusID")
      CType(FVpakPOStatus.FindControl("F_StatusID"), TextBox).Enabled = False
    End If
  End Sub

End Class
