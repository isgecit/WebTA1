Partial Class AF_elogICDCFSs
  Inherits SIS.SYS.InsertBase
  Protected Sub FVelogICDCFSs_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVelogICDCFSs.Init
    DataClassName = "AelogICDCFSs"
    SetFormView = FVelogICDCFSs
  End Sub
  Protected Sub TBLelogICDCFSs_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLelogICDCFSs.Init
    SetToolBar = TBLelogICDCFSs
  End Sub
  Protected Sub FVelogICDCFSs_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVelogICDCFSs.DataBound
    SIS.ELOG.elogICDCFSs.SetDefaultValues(sender, e) 
  End Sub
  Protected Sub FVelogICDCFSs_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVelogICDCFSs.PreRender
    Dim oF_StuffingPointID As LC_elogStuffingPoints = FVelogICDCFSs.FindControl("F_StuffingPointID")
    oF_StuffingPointID.Enabled = True
    oF_StuffingPointID.SelectedValue = String.Empty
    If Not Session("F_StuffingPointID") Is Nothing Then
      If Session("F_StuffingPointID") <> String.Empty Then
        oF_StuffingPointID.SelectedValue = Session("F_StuffingPointID")
      End If
    End If
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/ELOG_Main/App_Create") & "/AF_elogICDCFSs.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptelogICDCFSs") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptelogICDCFSs", mStr)
    End If
    If Request.QueryString("ICDCFSID") IsNot Nothing Then
      CType(FVelogICDCFSs.FindControl("F_ICDCFSID"), TextBox).Text = Request.QueryString("ICDCFSID")
      CType(FVelogICDCFSs.FindControl("F_ICDCFSID"), TextBox).Enabled = False
    End If
  End Sub

End Class
