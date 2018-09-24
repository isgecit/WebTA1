Partial Class AF_taD_Training
  Inherits SIS.SYS.InsertBase
  Protected Sub FVtaD_Training_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVtaD_Training.Init
    DataClassName = "AtaD_Training"
    SetFormView = FVtaD_Training
  End Sub
  Protected Sub TBLtaD_Training_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLtaD_Training.Init
    SetToolBar = TBLtaD_Training
  End Sub
  Protected Sub FVtaD_Training_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVtaD_Training.DataBound
    SIS.TA.taD_Training.SetDefaultValues(sender, e) 
  End Sub
  Protected Sub FVtaD_Training_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVtaD_Training.PreRender
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/TA_Main/App_Create") & "/AF_taD_Training.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scripttaD_Training") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scripttaD_Training", mStr)
    End If
    If Request.QueryString("SerialNo") IsNot Nothing Then
      CType(FVtaD_Training.FindControl("F_SerialNo"), TextBox).Text = Request.QueryString("SerialNo")
      CType(FVtaD_Training.FindControl("F_SerialNo"), TextBox).Enabled = False
    End If
  End Sub

End Class
