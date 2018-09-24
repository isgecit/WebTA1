Partial Class AF_nprkClaimStatus
  Inherits SIS.SYS.InsertBase
  Protected Sub FVnprkClaimStatus_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVnprkClaimStatus.Init
    DataClassName = "AnprkClaimStatus"
    SetFormView = FVnprkClaimStatus
  End Sub
  Protected Sub TBLnprkClaimStatus_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLnprkClaimStatus.Init
    SetToolBar = TBLnprkClaimStatus
  End Sub
  Protected Sub FVnprkClaimStatus_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVnprkClaimStatus.DataBound
    SIS.NPRK.nprkClaimStatus.SetDefaultValues(sender, e) 
  End Sub
  Protected Sub FVnprkClaimStatus_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVnprkClaimStatus.PreRender
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/NPRK_Main/App_Create") & "/AF_nprkClaimStatus.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptnprkClaimStatus") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptnprkClaimStatus", mStr)
    End If
    If Request.QueryString("ClaimStatusID") IsNot Nothing Then
      CType(FVnprkClaimStatus.FindControl("F_ClaimStatusID"), TextBox).Text = Request.QueryString("ClaimStatusID")
      CType(FVnprkClaimStatus.FindControl("F_ClaimStatusID"), TextBox).Enabled = False
    End If
  End Sub

End Class
