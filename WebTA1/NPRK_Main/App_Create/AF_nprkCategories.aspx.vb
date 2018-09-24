Partial Class AF_nprkCategories
  Inherits SIS.SYS.InsertBase
  Protected Sub FVnprkCategories_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVnprkCategories.Init
    DataClassName = "AnprkCategories"
    SetFormView = FVnprkCategories
  End Sub
  Protected Sub TBLnprkCategories_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLnprkCategories.Init
    SetToolBar = TBLnprkCategories
  End Sub
  Protected Sub FVnprkCategories_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVnprkCategories.DataBound
    SIS.NPRK.nprkCategories.SetDefaultValues(sender, e) 
  End Sub
  Protected Sub FVnprkCategories_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVnprkCategories.PreRender
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/NPRK_Main/App_Create") & "/AF_nprkCategories.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptnprkCategories") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptnprkCategories", mStr)
    End If
    If Request.QueryString("CategoryID") IsNot Nothing Then
      CType(FVnprkCategories.FindControl("F_CategoryID"), TextBox).Text = Request.QueryString("CategoryID")
      CType(FVnprkCategories.FindControl("F_CategoryID"), TextBox).Enabled = False
    End If
  End Sub

End Class
