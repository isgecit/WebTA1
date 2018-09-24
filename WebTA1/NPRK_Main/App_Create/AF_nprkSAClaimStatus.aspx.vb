Partial Class AF_nprkSAClaimStatus
  Inherits SIS.SYS.InsertBase
  Protected Sub FVnprkSAClaimStatus_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVnprkSAClaimStatus.Init
    DataClassName = "AnprkSAClaimStatus"
    SetFormView = FVnprkSAClaimStatus
  End Sub
  Protected Sub TBLnprkSAClaimStatus_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLnprkSAClaimStatus.Init
    SetToolBar = TBLnprkSAClaimStatus
  End Sub
  Protected Sub FVnprkSAClaimStatus_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVnprkSAClaimStatus.DataBound
    SIS.NPRK.nprkSAClaimStatus.SetDefaultValues(sender, e) 
  End Sub
  Protected Sub FVnprkSAClaimStatus_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVnprkSAClaimStatus.PreRender
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/NPRK_Main/App_Create") & "/AF_nprkSAClaimStatus.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptnprkSAClaimStatus") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptnprkSAClaimStatus", mStr)
    End If
    If Request.QueryString("StatusID") IsNot Nothing Then
      CType(FVnprkSAClaimStatus.FindControl("F_StatusID"), TextBox).Text = Request.QueryString("StatusID")
      CType(FVnprkSAClaimStatus.FindControl("F_StatusID"), TextBox).Enabled = False
    End If
  End Sub

End Class
