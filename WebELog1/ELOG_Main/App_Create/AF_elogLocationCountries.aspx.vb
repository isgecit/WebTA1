Partial Class AF_elogLocationCountries
  Inherits SIS.SYS.InsertBase
  Protected Sub FVelogLocationCountries_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVelogLocationCountries.Init
    DataClassName = "AelogLocationCountries"
    SetFormView = FVelogLocationCountries
  End Sub
  Protected Sub TBLelogLocationCountries_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLelogLocationCountries.Init
    SetToolBar = TBLelogLocationCountries
  End Sub
  Protected Sub FVelogLocationCountries_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVelogLocationCountries.DataBound
    SIS.ELOG.elogLocationCountries.SetDefaultValues(sender, e) 
  End Sub
  Protected Sub FVelogLocationCountries_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVelogLocationCountries.PreRender
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/ELOG_Main/App_Create") & "/AF_elogLocationCountries.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptelogLocationCountries") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptelogLocationCountries", mStr)
    End If
    If Request.QueryString("LocationCountryID") IsNot Nothing Then
      CType(FVelogLocationCountries.FindControl("F_LocationCountryID"), TextBox).Text = Request.QueryString("LocationCountryID")
      CType(FVelogLocationCountries.FindControl("F_LocationCountryID"), TextBox).Enabled = False
    End If
  End Sub

End Class
