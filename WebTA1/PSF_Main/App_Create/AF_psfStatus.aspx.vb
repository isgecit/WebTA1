Partial Class AF_psfStatus
  Inherits SIS.SYS.InsertBase
  Protected Sub FVpsfStatus_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpsfStatus.Init
    DataClassName = "ApsfStatus"
    SetFormView = FVpsfStatus
  End Sub
  Protected Sub TBLpsfStatus_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLpsfStatus.Init
    SetToolBar = TBLpsfStatus
  End Sub
  Protected Sub FVpsfStatus_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpsfStatus.DataBound
    SIS.PSF.psfStatus.SetDefaultValues(sender, e) 
  End Sub
  Protected Sub FVpsfStatus_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpsfStatus.PreRender
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/PSF_Main/App_Create") & "/AF_psfStatus.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptpsfStatus") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptpsfStatus", mStr)
    End If
    If Request.QueryString("PSFStatus") IsNot Nothing Then
      CType(FVpsfStatus.FindControl("F_PSFStatus"), TextBox).Text = Request.QueryString("PSFStatus")
      CType(FVpsfStatus.FindControl("F_PSFStatus"), TextBox).Enabled = False
    End If
  End Sub

End Class
