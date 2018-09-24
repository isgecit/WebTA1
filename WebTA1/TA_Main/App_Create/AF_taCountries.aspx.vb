Partial Class AF_taCountries
  Inherits SIS.SYS.InsertBase
  Protected Sub FVtaCountries_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVtaCountries.Init
    DataClassName = "AtaCountries"
    SetFormView = FVtaCountries
  End Sub
  Protected Sub TBLtaCountries_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLtaCountries.Init
    SetToolBar = TBLtaCountries
  End Sub
  Protected Sub FVtaCountries_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVtaCountries.DataBound
    SIS.TA.taCountries.SetDefaultValues(sender, e) 
  End Sub
  Protected Sub FVtaCountries_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVtaCountries.PreRender
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/TA_Main/App_Create") & "/AF_taCountries.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scripttaCountries") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scripttaCountries", mStr)
    End If
    If Request.QueryString("CountryID") IsNot Nothing Then
      CType(FVtaCountries.FindControl("F_CountryID"), TextBox).Text = Request.QueryString("CountryID")
      CType(FVtaCountries.FindControl("F_CountryID"), TextBox).Enabled = False
    End If
  End Sub
  <System.Web.Services.WebMethod()> _
  Public Shared Function validatePK_taCountries(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
    Dim CountryID As String = CType(aVal(1),String)
    Dim oVar As SIS.TA.taCountries = SIS.TA.taCountries.taCountriesGetByID(CountryID)
    If Not oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record allready exists." 
    End If
    Return mRet
  End Function

End Class
