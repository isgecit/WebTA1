Partial Class AF_wfdbAttachments
  Inherits SIS.SYS.InsertBase
  Protected Sub FVwfdbAttachments_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVwfdbAttachments.Init
    DataClassName = "AwfdbAttachments"
    SetFormView = FVwfdbAttachments
  End Sub
  Protected Sub TBLwfdbAttachments_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLwfdbAttachments.Init
    SetToolBar = TBLwfdbAttachments
  End Sub
  Protected Sub FVwfdbAttachments_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVwfdbAttachments.DataBound
    SIS.WFDB.wfdbAttachments.SetDefaultValues(sender, e) 
  End Sub
  Protected Sub FVwfdbAttachments_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVwfdbAttachments.PreRender
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/WFDB_Main/App_Create") & "/AF_wfdbAttachments.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptwfdbAttachments") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptwfdbAttachments", mStr)
    End If
    If Request.QueryString("t_indx") IsNot Nothing Then
      CType(FVwfdbAttachments.FindControl("F_t_indx"), TextBox).Text = Request.QueryString("t_indx")
      CType(FVwfdbAttachments.FindControl("F_t_indx"), TextBox).Enabled = False
    End If
    If Request.QueryString("t_dcid") IsNot Nothing Then
      CType(FVwfdbAttachments.FindControl("F_t_dcid"), TextBox).Text = Request.QueryString("t_dcid")
      CType(FVwfdbAttachments.FindControl("F_t_dcid"), TextBox).Enabled = False
    End If
  End Sub

End Class
