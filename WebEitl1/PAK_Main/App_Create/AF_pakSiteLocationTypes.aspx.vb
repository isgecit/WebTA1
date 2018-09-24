Partial Class AF_pakSiteLocationTypes
  Inherits SIS.SYS.InsertBase
  Protected Sub FVpakSiteLocationTypes_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpakSiteLocationTypes.Init
    DataClassName = "ApakSiteLocationTypes"
    SetFormView = FVpakSiteLocationTypes
  End Sub
  Protected Sub TBLpakSiteLocationTypes_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLpakSiteLocationTypes.Init
    SetToolBar = TBLpakSiteLocationTypes
  End Sub
  Protected Sub FVpakSiteLocationTypes_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpakSiteLocationTypes.DataBound
    SIS.PAK.pakSiteLocationTypes.SetDefaultValues(sender, e) 
  End Sub
  Protected Sub FVpakSiteLocationTypes_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpakSiteLocationTypes.PreRender
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/PAK_Main/App_Create") & "/AF_pakSiteLocationTypes.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptpakSiteLocationTypes") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptpakSiteLocationTypes", mStr)
    End If
    If Request.QueryString("LocationTypeID") IsNot Nothing Then
      CType(FVpakSiteLocationTypes.FindControl("F_LocationTypeID"), TextBox).Text = Request.QueryString("LocationTypeID")
      CType(FVpakSiteLocationTypes.FindControl("F_LocationTypeID"), TextBox).Enabled = False
    End If
  End Sub

End Class
