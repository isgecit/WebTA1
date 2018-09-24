Partial Class AF_hrmOfficeLocation
  Inherits SIS.SYS.InsertBase
  Protected Sub FVhrmOfficeLocation_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVhrmOfficeLocation.Init
    DataClassName = "AhrmOfficeLocation"
    SetFormView = FVhrmOfficeLocation
  End Sub
  Protected Sub TBLhrmOfficeLocation_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLhrmOfficeLocation.Init
    SetToolBar = TBLhrmOfficeLocation
  End Sub
  Protected Sub FVhrmOfficeLocation_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVhrmOfficeLocation.DataBound
    SIS.HRM.hrmOfficeLocation.SetDefaultValues(sender, e) 
  End Sub
  Protected Sub FVhrmOfficeLocation_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVhrmOfficeLocation.PreRender
    Dim oF_LocationID As LC_hrmLocations = FVhrmOfficeLocation.FindControl("F_LocationID")
    oF_LocationID.Enabled = True
    oF_LocationID.SelectedValue = String.Empty
    If Not Session("F_LocationID") Is Nothing Then
      If Session("F_LocationID") <> String.Empty Then
        oF_LocationID.SelectedValue = Session("F_LocationID")
      End If
    End If
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/HRM_Main/App_Create") & "/AF_hrmOfficeLocation.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scripthrmOfficeLocation") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scripthrmOfficeLocation", mStr)
    End If
    If Request.QueryString("LocationID") IsNot Nothing Then
      CType(FVhrmOfficeLocation.FindControl("F_LocationID"), LC_hrmLocations).SelectedValue = Request.QueryString("LocationID")
      CType(FVhrmOfficeLocation.FindControl("F_LocationID"), LC_hrmLocations).Enabled = False
    End If
    If Request.QueryString("OfficeID") IsNot Nothing Then
      CType(FVhrmOfficeLocation.FindControl("F_OfficeID"), LC_qcmOffices).SelectedValue = Request.QueryString("OfficeID")
      CType(FVhrmOfficeLocation.FindControl("F_OfficeID"), LC_qcmOffices).Enabled = False
    End If
  End Sub

End Class
