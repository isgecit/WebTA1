Partial Class AF_taF_SiteDA
  Inherits SIS.SYS.InsertBase
  Protected Sub FVtaF_SiteDA_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVtaF_SiteDA.Init
    DataClassName = "AtaF_SiteDA"
    SetFormView = FVtaF_SiteDA
  End Sub
  Protected Sub TBLtaF_SiteDA_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLtaF_SiteDA.Init
    SetToolBar = TBLtaF_SiteDA
  End Sub
  Protected Sub FVtaF_SiteDA_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVtaF_SiteDA.DataBound
    SIS.TA.taF_SiteDA.SetDefaultValues(sender, e) 
  End Sub
  Protected Sub FVtaF_SiteDA_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVtaF_SiteDA.PreRender
    Dim oF_CategoryID As LC_taCategories = FVtaF_SiteDA.FindControl("F_CategoryID")
    oF_CategoryID.Enabled = True
    oF_CategoryID.SelectedValue = String.Empty
    If Not Session("F_CategoryID") Is Nothing Then
      If Session("F_CategoryID") <> String.Empty Then
        oF_CategoryID.SelectedValue = Session("F_CategoryID")
      End If
    End If
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/TA_Main/App_Create") & "/AF_taF_SiteDA.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scripttaF_SiteDA") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scripttaF_SiteDA", mStr)
    End If
    If Request.QueryString("SerialNo") IsNot Nothing Then
      CType(FVtaF_SiteDA.FindControl("F_SerialNo"), TextBox).Text = Request.QueryString("SerialNo")
      CType(FVtaF_SiteDA.FindControl("F_SerialNo"), TextBox).Enabled = False
    End If
  End Sub

End Class
