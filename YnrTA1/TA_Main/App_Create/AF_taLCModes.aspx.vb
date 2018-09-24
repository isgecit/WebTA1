Partial Class AF_taLCModes
  Inherits SIS.SYS.InsertBase
  Protected Sub FVtaLCModes_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVtaLCModes.Init
    DataClassName = "AtaLCModes"
    SetFormView = FVtaLCModes
  End Sub
  Protected Sub TBLtaLCModes_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLtaLCModes.Init
    SetToolBar = TBLtaLCModes
  End Sub
  Protected Sub FVtaLCModes_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVtaLCModes.DataBound
    SIS.TA.taLCModes.SetDefaultValues(sender, e) 
  End Sub
  Protected Sub FVtaLCModes_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVtaLCModes.PreRender
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/TA_Main/App_Create") & "/AF_taLCModes.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scripttaLCModes") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scripttaLCModes", mStr)
    End If
    If Request.QueryString("ModeID") IsNot Nothing Then
      CType(FVtaLCModes.FindControl("F_ModeID"), TextBox).Text = Request.QueryString("ModeID")
      CType(FVtaLCModes.FindControl("F_ModeID"), TextBox).Enabled = False
    End If
  End Sub

End Class
