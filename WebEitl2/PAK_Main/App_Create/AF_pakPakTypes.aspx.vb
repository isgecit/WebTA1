Partial Class AF_pakPakTypes
  Inherits SIS.SYS.InsertBase
  Protected Sub FVpakPakTypes_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpakPakTypes.Init
    DataClassName = "ApakPakTypes"
    SetFormView = FVpakPakTypes
  End Sub
  Protected Sub TBLpakPakTypes_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLpakPakTypes.Init
    SetToolBar = TBLpakPakTypes
  End Sub
  Protected Sub FVpakPakTypes_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpakPakTypes.DataBound
    SIS.PAK.pakPakTypes.SetDefaultValues(sender, e) 
  End Sub
  Protected Sub FVpakPakTypes_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpakPakTypes.PreRender
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/PAK_Main/App_Create") & "/AF_pakPakTypes.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptpakPakTypes") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptpakPakTypes", mStr)
    End If
    If Request.QueryString("PackTypeID") IsNot Nothing Then
      CType(FVpakPakTypes.FindControl("F_PackTypeID"), TextBox).Text = Request.QueryString("PackTypeID")
      CType(FVpakPakTypes.FindControl("F_PackTypeID"), TextBox).Enabled = False
    End If
  End Sub

End Class
