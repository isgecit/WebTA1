Partial Class AF_pakPkgIStatus
  Inherits SIS.SYS.InsertBase
  Protected Sub FVpakPkgIStatus_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpakPkgIStatus.Init
    DataClassName = "ApakPkgIStatus"
    SetFormView = FVpakPkgIStatus
  End Sub
  Protected Sub TBLpakPkgIStatus_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLpakPkgIStatus.Init
    SetToolBar = TBLpakPkgIStatus
  End Sub
  Protected Sub FVpakPkgIStatus_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpakPkgIStatus.DataBound
    SIS.PAK.pakPkgIStatus.SetDefaultValues(sender, e) 
  End Sub
  Protected Sub FVpakPkgIStatus_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpakPkgIStatus.PreRender
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/PAK_Main/App_Create") & "/AF_pakPkgIStatus.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptpakPkgIStatus") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptpakPkgIStatus", mStr)
    End If
    If Request.QueryString("StatusID") IsNot Nothing Then
      CType(FVpakPkgIStatus.FindControl("F_StatusID"), TextBox).Text = Request.QueryString("StatusID")
      CType(FVpakPkgIStatus.FindControl("F_StatusID"), TextBox).Enabled = False
    End If
  End Sub

End Class
