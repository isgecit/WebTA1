Partial Class AF_taCategories
  Inherits SIS.SYS.InsertBase
  Protected Sub FVtaCategories_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVtaCategories.Init
    DataClassName = "AtaCategories"
    SetFormView = FVtaCategories
  End Sub
  Protected Sub TBLtaCategories_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLtaCategories.Init
    SetToolBar = TBLtaCategories
  End Sub
  Protected Sub FVtaCategories_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVtaCategories.DataBound
    SIS.TA.taCategories.SetDefaultValues(sender, e) 
  End Sub
  Protected Sub FVtaCategories_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVtaCategories.PreRender
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/TA_Main/App_Create") & "/AF_taCategories.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scripttaCategories") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scripttaCategories", mStr)
    End If
    If Request.QueryString("CategoryID") IsNot Nothing Then
      CType(FVtaCategories.FindControl("F_CategoryID"), TextBox).Text = Request.QueryString("CategoryID")
      CType(FVtaCategories.FindControl("F_CategoryID"), TextBox).Enabled = False
    End If
  End Sub

End Class
