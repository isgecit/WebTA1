Partial Class AF_taTravelTypes
  Inherits SIS.SYS.InsertBase
  Protected Sub FVtaTravelTypes_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVtaTravelTypes.Init
    DataClassName = "AtaTravelTypes"
    SetFormView = FVtaTravelTypes
  End Sub
  Protected Sub TBLtaTravelTypes_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLtaTravelTypes.Init
    SetToolBar = TBLtaTravelTypes
  End Sub
  Protected Sub FVtaTravelTypes_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVtaTravelTypes.DataBound
    SIS.TA.taTravelTypes.SetDefaultValues(sender, e) 
  End Sub
  Protected Sub FVtaTravelTypes_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVtaTravelTypes.PreRender
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/TA_Main/App_Create") & "/AF_taTravelTypes.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scripttaTravelTypes") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scripttaTravelTypes", mStr)
    End If
    If Request.QueryString("TravelTypeID") IsNot Nothing Then
      CType(FVtaTravelTypes.FindControl("F_TravelTypeID"), TextBox).Text = Request.QueryString("TravelTypeID")
      CType(FVtaTravelTypes.FindControl("F_TravelTypeID"), TextBox).Enabled = False
    End If
  End Sub

End Class
