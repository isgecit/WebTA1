Partial Class AF_nprkSiteAllowanceEntitlement
  Inherits SIS.SYS.InsertBase
  Protected Sub FVnprkSiteAllowanceEntitlement_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVnprkSiteAllowanceEntitlement.Init
    DataClassName = "AnprkSiteAllowanceEntitlement"
    SetFormView = FVnprkSiteAllowanceEntitlement
  End Sub
  Protected Sub TBLnprkSiteAllowanceEntitlement_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLnprkSiteAllowanceEntitlement.Init
    SetToolBar = TBLnprkSiteAllowanceEntitlement
  End Sub
  Protected Sub FVnprkSiteAllowanceEntitlement_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVnprkSiteAllowanceEntitlement.DataBound
    SIS.NPRK.nprkSiteAllowanceEntitlement.SetDefaultValues(sender, e) 
  End Sub
  Protected Sub FVnprkSiteAllowanceEntitlement_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVnprkSiteAllowanceEntitlement.PreRender
    Dim oF_TACategoryID As LC_taCategories = FVnprkSiteAllowanceEntitlement.FindControl("F_TACategoryID")
    oF_TACategoryID.Enabled = True
    oF_TACategoryID.SelectedValue = String.Empty
    If Not Session("F_TACategoryID") Is Nothing Then
      If Session("F_TACategoryID") <> String.Empty Then
        oF_TACategoryID.SelectedValue = Session("F_TACategoryID")
      End If
    End If
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/NPRK_Main/App_Create") & "/AF_nprkSiteAllowanceEntitlement.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptnprkSiteAllowanceEntitlement") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptnprkSiteAllowanceEntitlement", mStr)
    End If
    If Request.QueryString("SerialNo") IsNot Nothing Then
      CType(FVnprkSiteAllowanceEntitlement.FindControl("F_SerialNo"), TextBox).Text = Request.QueryString("SerialNo")
      CType(FVnprkSiteAllowanceEntitlement.FindControl("F_SerialNo"), TextBox).Enabled = False
    End If
  End Sub

End Class
