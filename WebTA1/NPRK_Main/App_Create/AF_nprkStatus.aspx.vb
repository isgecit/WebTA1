Partial Class AF_nprkStatus
  Inherits SIS.SYS.InsertBase
  Protected Sub FVnprkStatus_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVnprkStatus.Init
    DataClassName = "AnprkStatus"
    SetFormView = FVnprkStatus
  End Sub
  Protected Sub TBLnprkStatus_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLnprkStatus.Init
    SetToolBar = TBLnprkStatus
  End Sub
  Protected Sub FVnprkStatus_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVnprkStatus.DataBound
    SIS.NPRK.nprkStatus.SetDefaultValues(sender, e) 
  End Sub
  Protected Sub FVnprkStatus_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVnprkStatus.PreRender
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/NPRK_Main/App_Create") & "/AF_nprkStatus.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptnprkStatus") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptnprkStatus", mStr)
    End If
    If Request.QueryString("StatusID") IsNot Nothing Then
      CType(FVnprkStatus.FindControl("F_StatusID"), TextBox).Text = Request.QueryString("StatusID")
      CType(FVnprkStatus.FindControl("F_StatusID"), TextBox).Enabled = False
    End If
  End Sub

End Class
