Partial Class AF_nprkSAAdviceStatus
  Inherits SIS.SYS.InsertBase
  Protected Sub FVnprkSAAdviceStatus_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVnprkSAAdviceStatus.Init
    DataClassName = "AnprkSAAdviceStatus"
    SetFormView = FVnprkSAAdviceStatus
  End Sub
  Protected Sub TBLnprkSAAdviceStatus_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLnprkSAAdviceStatus.Init
    SetToolBar = TBLnprkSAAdviceStatus
  End Sub
  Protected Sub FVnprkSAAdviceStatus_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVnprkSAAdviceStatus.DataBound
    SIS.NPRK.nprkSAAdviceStatus.SetDefaultValues(sender, e) 
  End Sub
  Protected Sub FVnprkSAAdviceStatus_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVnprkSAAdviceStatus.PreRender
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/NPRK_Main/App_Create") & "/AF_nprkSAAdviceStatus.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptnprkSAAdviceStatus") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptnprkSAAdviceStatus", mStr)
    End If
    If Request.QueryString("StatusID") IsNot Nothing Then
      CType(FVnprkSAAdviceStatus.FindControl("F_StatusID"), TextBox).Text = Request.QueryString("StatusID")
      CType(FVnprkSAAdviceStatus.FindControl("F_StatusID"), TextBox).Enabled = False
    End If
  End Sub

End Class
