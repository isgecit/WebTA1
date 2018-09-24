Partial Class AF_pakPOTypes
  Inherits SIS.SYS.InsertBase
  Protected Sub FVpakPOTypes_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpakPOTypes.Init
    DataClassName = "ApakPOTypes"
    SetFormView = FVpakPOTypes
  End Sub
  Protected Sub TBLpakPOTypes_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLpakPOTypes.Init
    SetToolBar = TBLpakPOTypes
  End Sub
  Protected Sub FVpakPOTypes_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpakPOTypes.DataBound
    SIS.PAK.pakPOTypes.SetDefaultValues(sender, e) 
  End Sub
  Protected Sub FVpakPOTypes_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpakPOTypes.PreRender
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/PAK_Main/App_Create") & "/AF_pakPOTypes.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptpakPOTypes") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptpakPOTypes", mStr)
    End If
    If Request.QueryString("POTypeID") IsNot Nothing Then
      CType(FVpakPOTypes.FindControl("F_POTypeID"), TextBox).Text = Request.QueryString("POTypeID")
      CType(FVpakPOTypes.FindControl("F_POTypeID"), TextBox).Enabled = False
    End If
  End Sub

End Class
