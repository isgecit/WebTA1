Partial Class AF_pakSiteLocations
  Inherits SIS.SYS.InsertBase
  Protected Sub FVpakSiteLocations_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpakSiteLocations.Init
    DataClassName = "ApakSiteLocations"
    SetFormView = FVpakSiteLocations
  End Sub
  Protected Sub TBLpakSiteLocations_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLpakSiteLocations.Init
    SetToolBar = TBLpakSiteLocations
  End Sub
  Protected Sub FVpakSiteLocations_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpakSiteLocations.DataBound
    SIS.PAK.pakSiteLocations.SetDefaultValues(sender, e) 
  End Sub
  Protected Sub FVpakSiteLocations_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpakSiteLocations.PreRender
    Dim oF_LocationTypeID As LC_pakSiteLocationTypes = FVpakSiteLocations.FindControl("F_LocationTypeID")
    oF_LocationTypeID.Enabled = True
    oF_LocationTypeID.SelectedValue = String.Empty
    If Not Session("F_LocationTypeID") Is Nothing Then
      If Session("F_LocationTypeID") <> String.Empty Then
        oF_LocationTypeID.SelectedValue = Session("F_LocationTypeID")
      End If
    End If
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/PAK_Main/App_Create") & "/AF_pakSiteLocations.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptpakSiteLocations") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptpakSiteLocations", mStr)
    End If
    If Request.QueryString("LocationID") IsNot Nothing Then
      CType(FVpakSiteLocations.FindControl("F_LocationID"), TextBox).Text = Request.QueryString("LocationID")
      CType(FVpakSiteLocations.FindControl("F_LocationID"), TextBox).Enabled = False
    End If
  End Sub

End Class
