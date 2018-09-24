Partial Class AF_taD_TravelModes
  Inherits SIS.SYS.InsertBase
  Protected Sub FVtaD_TravelModes_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVtaD_TravelModes.Init
    DataClassName = "AtaD_TravelModes"
    SetFormView = FVtaD_TravelModes
  End Sub
  Protected Sub TBLtaD_TravelModes_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLtaD_TravelModes.Init
    SetToolBar = TBLtaD_TravelModes
  End Sub
  Protected Sub FVtaD_TravelModes_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVtaD_TravelModes.DataBound
    SIS.TA.taD_TravelModes.SetDefaultValues(sender, e) 
  End Sub
  Protected Sub FVtaD_TravelModes_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVtaD_TravelModes.PreRender
    Dim oF_CategoryID As LC_taCategories = FVtaD_TravelModes.FindControl("F_CategoryID")
    oF_CategoryID.Enabled = True
    oF_CategoryID.SelectedValue = String.Empty
    If Not Session("F_CategoryID") Is Nothing Then
      If Session("F_CategoryID") <> String.Empty Then
        oF_CategoryID.SelectedValue = Session("F_CategoryID")
      End If
    End If
    Dim oF_TravelModeID As LC_taTravelModes = FVtaD_TravelModes.FindControl("F_TravelModeID")
    oF_TravelModeID.Enabled = True
    oF_TravelModeID.SelectedValue = String.Empty
    If Not Session("F_TravelModeID") Is Nothing Then
      If Session("F_TravelModeID") <> String.Empty Then
        oF_TravelModeID.SelectedValue = Session("F_TravelModeID")
      End If
    End If
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/TA_Main/App_Create") & "/AF_taD_TravelModes.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scripttaD_TravelModes") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scripttaD_TravelModes", mStr)
    End If
    If Request.QueryString("SerialNo") IsNot Nothing Then
      CType(FVtaD_TravelModes.FindControl("F_SerialNo"), TextBox).Text = Request.QueryString("SerialNo")
      CType(FVtaD_TravelModes.FindControl("F_SerialNo"), TextBox).Enabled = False
    End If
  End Sub

End Class
