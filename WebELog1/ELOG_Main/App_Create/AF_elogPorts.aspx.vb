Partial Class AF_elogPorts
  Inherits SIS.SYS.InsertBase
  Protected Sub FVelogPorts_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVelogPorts.Init
    DataClassName = "AelogPorts"
    SetFormView = FVelogPorts
  End Sub
  Protected Sub TBLelogPorts_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLelogPorts.Init
    SetToolBar = TBLelogPorts
  End Sub
  Protected Sub FVelogPorts_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVelogPorts.DataBound
    SIS.ELOG.elogPorts.SetDefaultValues(sender, e) 
  End Sub
  Protected Sub FVelogPorts_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVelogPorts.PreRender
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/ELOG_Main/App_Create") & "/AF_elogPorts.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptelogPorts") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptelogPorts", mStr)
    End If
    If Request.QueryString("PortID") IsNot Nothing Then
      CType(FVelogPorts.FindControl("F_PortID"), TextBox).Text = Request.QueryString("PortID")
      CType(FVelogPorts.FindControl("F_PortID"), TextBox).Enabled = False
    End If
  End Sub

End Class
