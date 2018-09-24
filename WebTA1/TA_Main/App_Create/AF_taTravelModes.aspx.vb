Partial Class AF_taTravelModes
  Inherits SIS.SYS.InsertBase
  Protected Sub FVtaTravelModes_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVtaTravelModes.Init
    DataClassName = "AtaTravelModes"
    SetFormView = FVtaTravelModes
  End Sub
  Protected Sub TBLtaTravelModes_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLtaTravelModes.Init
    SetToolBar = TBLtaTravelModes
  End Sub
  Protected Sub FVtaTravelModes_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVtaTravelModes.DataBound
    SIS.TA.taTravelModes.SetDefaultValues(sender, e) 
  End Sub
  Protected Sub FVtaTravelModes_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVtaTravelModes.PreRender
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/TA_Main/App_Create") & "/AF_taTravelModes.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scripttaTravelModes") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scripttaTravelModes", mStr)
    End If
    If Request.QueryString("ModeID") IsNot Nothing Then
      CType(FVtaTravelModes.FindControl("F_ModeID"), TextBox).Text = Request.QueryString("ModeID")
      CType(FVtaTravelModes.FindControl("F_ModeID"), TextBox).Enabled = False
    End If
  End Sub

End Class
