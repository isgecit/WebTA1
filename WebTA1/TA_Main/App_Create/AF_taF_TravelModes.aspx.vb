Partial Class AF_taF_TravelModes
  Inherits SIS.SYS.InsertBase
  Protected Sub FVtaF_TravelModes_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVtaF_TravelModes.Init
    DataClassName = "AtaF_TravelModes"
    SetFormView = FVtaF_TravelModes
  End Sub
  Protected Sub TBLtaF_TravelModes_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLtaF_TravelModes.Init
    SetToolBar = TBLtaF_TravelModes
  End Sub
  Protected Sub FVtaF_TravelModes_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVtaF_TravelModes.DataBound
    SIS.TA.taF_TravelModes.SetDefaultValues(sender, e) 
  End Sub
  Protected Sub FVtaF_TravelModes_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVtaF_TravelModes.PreRender
    Dim oF_CategoryID As LC_taCategories = FVtaF_TravelModes.FindControl("F_CategoryID")
    oF_CategoryID.Enabled = True
    oF_CategoryID.SelectedValue = String.Empty
    If Not Session("F_CategoryID") Is Nothing Then
      If Session("F_CategoryID") <> String.Empty Then
        oF_CategoryID.SelectedValue = Session("F_CategoryID")
      End If
    End If
    Dim oF_TravelModeID As LC_taTravelModes = FVtaF_TravelModes.FindControl("F_TravelModeID")
    oF_TravelModeID.Enabled = True
    oF_TravelModeID.SelectedValue = String.Empty
    If Not Session("F_TravelModeID") Is Nothing Then
      If Session("F_TravelModeID") <> String.Empty Then
        oF_TravelModeID.SelectedValue = Session("F_TravelModeID")
      End If
    End If
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/TA_Main/App_Create") & "/AF_taF_TravelModes.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scripttaF_TravelModes") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scripttaF_TravelModes", mStr)
    End If
    If Request.QueryString("SerialNo") IsNot Nothing Then
      CType(FVtaF_TravelModes.FindControl("F_SerialNo"), TextBox).Text = Request.QueryString("SerialNo")
      CType(FVtaF_TravelModes.FindControl("F_SerialNo"), TextBox).Enabled = False
    End If
  End Sub

End Class
