Partial Class AF_taD_LCModes
  Inherits SIS.SYS.InsertBase
  Protected Sub FVtaD_LCModes_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVtaD_LCModes.Init
    DataClassName = "AtaD_LCModes"
    SetFormView = FVtaD_LCModes
  End Sub
  Protected Sub TBLtaD_LCModes_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLtaD_LCModes.Init
    SetToolBar = TBLtaD_LCModes
  End Sub
  Protected Sub FVtaD_LCModes_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVtaD_LCModes.DataBound
    SIS.TA.taD_LCModes.SetDefaultValues(sender, e) 
  End Sub
  Protected Sub FVtaD_LCModes_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVtaD_LCModes.PreRender
    Dim oF_CategoryID As LC_taCategories = FVtaD_LCModes.FindControl("F_CategoryID")
    oF_CategoryID.Enabled = True
    oF_CategoryID.SelectedValue = String.Empty
    If Not Session("F_CategoryID") Is Nothing Then
      If Session("F_CategoryID") <> String.Empty Then
        oF_CategoryID.SelectedValue = Session("F_CategoryID")
      End If
    End If
    Dim oF_LCModeID As LC_taLCModes = FVtaD_LCModes.FindControl("F_LCModeID")
    oF_LCModeID.Enabled = True
    oF_LCModeID.SelectedValue = String.Empty
    If Not Session("F_LCModeID") Is Nothing Then
      If Session("F_LCModeID") <> String.Empty Then
        oF_LCModeID.SelectedValue = Session("F_LCModeID")
      End If
    End If
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/TA_Main/App_Create") & "/AF_taD_LCModes.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scripttaD_LCModes") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scripttaD_LCModes", mStr)
    End If
    If Request.QueryString("SerialNo") IsNot Nothing Then
      CType(FVtaD_LCModes.FindControl("F_SerialNo"), TextBox).Text = Request.QueryString("SerialNo")
      CType(FVtaD_LCModes.FindControl("F_SerialNo"), TextBox).Enabled = False
    End If
  End Sub

End Class
