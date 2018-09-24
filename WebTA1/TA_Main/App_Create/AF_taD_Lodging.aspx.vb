Partial Class AF_taD_Lodging
  Inherits SIS.SYS.InsertBase
  Protected Sub FVtaD_Lodging_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVtaD_Lodging.Init
    DataClassName = "AtaD_Lodging"
    SetFormView = FVtaD_Lodging
  End Sub
  Protected Sub TBLtaD_Lodging_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLtaD_Lodging.Init
    SetToolBar = TBLtaD_Lodging
  End Sub
  Protected Sub FVtaD_Lodging_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVtaD_Lodging.DataBound
    SIS.TA.taD_Lodging.SetDefaultValues(sender, e) 
  End Sub
  Protected Sub FVtaD_Lodging_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVtaD_Lodging.PreRender
    Dim oF_CategoryID As LC_taCategories = FVtaD_Lodging.FindControl("F_CategoryID")
    oF_CategoryID.Enabled = True
    oF_CategoryID.SelectedValue = String.Empty
    If Not Session("F_CategoryID") Is Nothing Then
      If Session("F_CategoryID") <> String.Empty Then
        oF_CategoryID.SelectedValue = Session("F_CategoryID")
      End If
    End If
    Dim oF_CityTypeID As LC_taCityTypes = FVtaD_Lodging.FindControl("F_CityTypeID")
    oF_CityTypeID.Enabled = True
    oF_CityTypeID.SelectedValue = String.Empty
    If Not Session("F_CityTypeID") Is Nothing Then
      If Session("F_CityTypeID") <> String.Empty Then
        oF_CityTypeID.SelectedValue = Session("F_CityTypeID")
      End If
    End If
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/TA_Main/App_Create") & "/AF_taD_Lodging.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scripttaD_Lodging") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scripttaD_Lodging", mStr)
    End If
    If Request.QueryString("SerialNo") IsNot Nothing Then
      CType(FVtaD_Lodging.FindControl("F_SerialNo"), TextBox).Text = Request.QueryString("SerialNo")
      CType(FVtaD_Lodging.FindControl("F_SerialNo"), TextBox).Enabled = False
    End If
  End Sub

End Class
