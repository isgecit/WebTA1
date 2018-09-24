Partial Class AF_taApprovalWFTypes
  Inherits SIS.SYS.InsertBase
  Protected Sub FVtaApprovalWFTypes_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVtaApprovalWFTypes.Init
    DataClassName = "AtaApprovalWFTypes"
    SetFormView = FVtaApprovalWFTypes
  End Sub
  Protected Sub TBLtaApprovalWFTypes_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLtaApprovalWFTypes.Init
    SetToolBar = TBLtaApprovalWFTypes
  End Sub
  Protected Sub FVtaApprovalWFTypes_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVtaApprovalWFTypes.DataBound
    SIS.TA.taApprovalWFTypes.SetDefaultValues(sender, e) 
  End Sub
  Protected Sub FVtaApprovalWFTypes_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVtaApprovalWFTypes.PreRender
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/TA_Main/App_Create") & "/AF_taApprovalWFTypes.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scripttaApprovalWFTypes") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scripttaApprovalWFTypes", mStr)
    End If
    If Request.QueryString("WFTypeID") IsNot Nothing Then
      CType(FVtaApprovalWFTypes.FindControl("F_WFTypeID"), TextBox).Text = Request.QueryString("WFTypeID")
      CType(FVtaApprovalWFTypes.FindControl("F_WFTypeID"), TextBox).Enabled = False
    End If
  End Sub

End Class
