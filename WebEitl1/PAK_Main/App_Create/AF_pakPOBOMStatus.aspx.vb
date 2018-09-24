Partial Class AF_pakPOBOMStatus
  Inherits SIS.SYS.InsertBase
  Protected Sub FVpakPOBOMStatus_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpakPOBOMStatus.Init
    DataClassName = "ApakPOBOMStatus"
    SetFormView = FVpakPOBOMStatus
  End Sub
  Protected Sub TBLpakPOBOMStatus_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLpakPOBOMStatus.Init
    SetToolBar = TBLpakPOBOMStatus
  End Sub
  Protected Sub FVpakPOBOMStatus_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpakPOBOMStatus.DataBound
    SIS.PAK.pakPOBOMStatus.SetDefaultValues(sender, e) 
  End Sub
  Protected Sub FVpakPOBOMStatus_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpakPOBOMStatus.PreRender
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/PAK_Main/App_Create") & "/AF_pakPOBOMStatus.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptpakPOBOMStatus") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptpakPOBOMStatus", mStr)
    End If
    If Request.QueryString("StatusID") IsNot Nothing Then
      CType(FVpakPOBOMStatus.FindControl("F_StatusID"), TextBox).Text = Request.QueryString("StatusID")
      CType(FVpakPOBOMStatus.FindControl("F_StatusID"), TextBox).Enabled = False
    End If
  End Sub

End Class
