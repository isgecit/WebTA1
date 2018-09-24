Partial Class AF_elogIRBLStates
  Inherits SIS.SYS.InsertBase
  Protected Sub FVelogIRBLStates_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVelogIRBLStates.Init
    DataClassName = "AelogIRBLStates"
    SetFormView = FVelogIRBLStates
  End Sub
  Protected Sub TBLelogIRBLStates_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLelogIRBLStates.Init
    SetToolBar = TBLelogIRBLStates
  End Sub
  Protected Sub FVelogIRBLStates_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVelogIRBLStates.DataBound
    SIS.ELOG.elogIRBLStates.SetDefaultValues(sender, e) 
  End Sub
  Protected Sub FVelogIRBLStates_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVelogIRBLStates.PreRender
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/ELOG_Main/App_Create") & "/AF_elogIRBLStates.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptelogIRBLStates") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptelogIRBLStates", mStr)
    End If
    If Request.QueryString("StatusID") IsNot Nothing Then
      CType(FVelogIRBLStates.FindControl("F_StatusID"), TextBox).Text = Request.QueryString("StatusID")
      CType(FVelogIRBLStates.FindControl("F_StatusID"), TextBox).Enabled = False
    End If
  End Sub

End Class
