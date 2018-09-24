Partial Class AF_taF_ForeignTravel
  Inherits SIS.SYS.InsertBase
  Protected Sub FVtaF_ForeignTravel_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVtaF_ForeignTravel.Init
    DataClassName = "AtaF_ForeignTravel"
    SetFormView = FVtaF_ForeignTravel
  End Sub
  Protected Sub TBLtaF_ForeignTravel_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLtaF_ForeignTravel.Init
    SetToolBar = TBLtaF_ForeignTravel
  End Sub
  Protected Sub FVtaF_ForeignTravel_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVtaF_ForeignTravel.DataBound
    SIS.TA.taF_ForeignTravel.SetDefaultValues(sender, e) 
  End Sub
  Protected Sub FVtaF_ForeignTravel_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVtaF_ForeignTravel.PreRender
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/TA_Main/App_Create") & "/AF_taF_ForeignTravel.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scripttaF_ForeignTravel") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scripttaF_ForeignTravel", mStr)
    End If
    If Request.QueryString("SerialNo") IsNot Nothing Then
      CType(FVtaF_ForeignTravel.FindControl("F_SerialNo"), TextBox).Text = Request.QueryString("SerialNo")
      CType(FVtaF_ForeignTravel.FindControl("F_SerialNo"), TextBox).Enabled = False
    End If
  End Sub

End Class
