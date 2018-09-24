Partial Class AF_pakPkgStatus
  Inherits SIS.SYS.InsertBase
  Protected Sub FVpakPkgStatus_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpakPkgStatus.Init
    DataClassName = "ApakPkgStatus"
    SetFormView = FVpakPkgStatus
  End Sub
  Protected Sub TBLpakPkgStatus_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLpakPkgStatus.Init
    SetToolBar = TBLpakPkgStatus
  End Sub
  Protected Sub FVpakPkgStatus_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpakPkgStatus.DataBound
    SIS.PAK.pakPkgStatus.SetDefaultValues(sender, e) 
  End Sub
  Protected Sub FVpakPkgStatus_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpakPkgStatus.PreRender
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/PAK_Main/App_Create") & "/AF_pakPkgStatus.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptpakPkgStatus") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptpakPkgStatus", mStr)
    End If
    If Request.QueryString("StatusID") IsNot Nothing Then
      CType(FVpakPkgStatus.FindControl("F_StatusID"), TextBox).Text = Request.QueryString("StatusID")
      CType(FVpakPkgStatus.FindControl("F_StatusID"), TextBox).Enabled = False
    End If
  End Sub

End Class
