Partial Class AF_taOOEReasons
  Inherits SIS.SYS.InsertBase
  Protected Sub FVtaOOEReasons_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVtaOOEReasons.Init
    DataClassName = "AtaOOEReasons"
    SetFormView = FVtaOOEReasons
  End Sub
  Protected Sub TBLtaOOEReasons_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLtaOOEReasons.Init
    SetToolBar = TBLtaOOEReasons
  End Sub
  Protected Sub FVtaOOEReasons_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVtaOOEReasons.DataBound
    SIS.TA.taOOEReasons.SetDefaultValues(sender, e) 
  End Sub
  Protected Sub FVtaOOEReasons_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVtaOOEReasons.PreRender
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/TA_Main/App_Create") & "/AF_taOOEReasons.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scripttaOOEReasons") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scripttaOOEReasons", mStr)
    End If
    If Request.QueryString("ReasonID") IsNot Nothing Then
      CType(FVtaOOEReasons.FindControl("F_ReasonID"), TextBox).Text = Request.QueryString("ReasonID")
      CType(FVtaOOEReasons.FindControl("F_ReasonID"), TextBox).Enabled = False
    End If
  End Sub

End Class
