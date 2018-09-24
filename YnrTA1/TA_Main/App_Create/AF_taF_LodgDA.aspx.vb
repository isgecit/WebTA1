Partial Class AF_taF_LodgDA
  Inherits SIS.SYS.InsertBase
  Protected Sub FVtaF_LodgDA_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVtaF_LodgDA.Init
    DataClassName = "AtaF_LodgDA"
    SetFormView = FVtaF_LodgDA
  End Sub
  Protected Sub TBLtaF_LodgDA_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLtaF_LodgDA.Init
    SetToolBar = TBLtaF_LodgDA
  End Sub
  Protected Sub FVtaF_LodgDA_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVtaF_LodgDA.DataBound
    SIS.TA.taF_LodgDA.SetDefaultValues(sender, e) 
  End Sub
  Protected Sub FVtaF_LodgDA_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVtaF_LodgDA.PreRender
    Dim oF_CategoryID As LC_taCategories = FVtaF_LodgDA.FindControl("F_CategoryID")
    oF_CategoryID.Enabled = True
    oF_CategoryID.SelectedValue = String.Empty
    If Not Session("F_CategoryID") Is Nothing Then
      If Session("F_CategoryID") <> String.Empty Then
        oF_CategoryID.SelectedValue = Session("F_CategoryID")
      End If
    End If
    Dim oF_RegionID As LC_taRegions = FVtaF_LodgDA.FindControl("F_RegionID")
    oF_RegionID.Enabled = True
    oF_RegionID.SelectedValue = String.Empty
    If Not Session("F_RegionID") Is Nothing Then
      If Session("F_RegionID") <> String.Empty Then
        oF_RegionID.SelectedValue = Session("F_RegionID")
      End If
    End If
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/TA_Main/App_Create") & "/AF_taF_LodgDA.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scripttaF_LodgDA") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scripttaF_LodgDA", mStr)
    End If
    If Request.QueryString("SerialNo") IsNot Nothing Then
      CType(FVtaF_LodgDA.FindControl("F_SerialNo"), TextBox).Text = Request.QueryString("SerialNo")
      CType(FVtaF_LodgDA.FindControl("F_SerialNo"), TextBox).Enabled = False
    End If
  End Sub

End Class
