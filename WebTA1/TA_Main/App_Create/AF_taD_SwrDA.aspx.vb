Partial Class AF_taD_SwrDA
  Inherits SIS.SYS.InsertBase
  Protected Sub FVtaD_SwrDA_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVtaD_SwrDA.Init
    DataClassName = "AtaD_SwrDA"
    SetFormView = FVtaD_SwrDA
  End Sub
  Protected Sub TBLtaD_SwrDA_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLtaD_SwrDA.Init
    SetToolBar = TBLtaD_SwrDA
  End Sub
  Protected Sub FVtaD_SwrDA_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVtaD_SwrDA.DataBound
    SIS.TA.taD_SwrDA.SetDefaultValues(sender, e) 
  End Sub
  Protected Sub FVtaD_SwrDA_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVtaD_SwrDA.PreRender
    Dim oF_CategoryID As LC_taCategories = FVtaD_SwrDA.FindControl("F_CategoryID")
    oF_CategoryID.Enabled = True
    oF_CategoryID.SelectedValue = String.Empty
    If Not Session("F_CategoryID") Is Nothing Then
      If Session("F_CategoryID") <> String.Empty Then
        oF_CategoryID.SelectedValue = Session("F_CategoryID")
      End If
    End If
    Dim oF_CityTypeID As LC_taCityTypes = FVtaD_SwrDA.FindControl("F_CityTypeID")
    oF_CityTypeID.Enabled = True
    oF_CityTypeID.SelectedValue = String.Empty
    If Not Session("F_CityTypeID") Is Nothing Then
      If Session("F_CityTypeID") <> String.Empty Then
        oF_CityTypeID.SelectedValue = Session("F_CityTypeID")
      End If
    End If
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/TA_Main/App_Create") & "/AF_taD_SwrDA.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scripttaD_SwrDA") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scripttaD_SwrDA", mStr)
    End If
    If Request.QueryString("SerialNo") IsNot Nothing Then
      CType(FVtaD_SwrDA.FindControl("F_SerialNo"), TextBox).Text = Request.QueryString("SerialNo")
      CType(FVtaD_SwrDA.FindControl("F_SerialNo"), TextBox).Enabled = False
    End If
  End Sub

End Class
