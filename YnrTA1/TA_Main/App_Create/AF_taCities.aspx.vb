Partial Class AF_taCities
  Inherits SIS.SYS.InsertBase
  Protected Sub FVtaCities_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVtaCities.Init
    DataClassName = "AtaCities"
    SetFormView = FVtaCities
  End Sub
  Protected Sub TBLtaCities_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLtaCities.Init
    SetToolBar = TBLtaCities
  End Sub
  Protected Sub FVtaCities_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVtaCities.DataBound
    SIS.TA.taCities.SetDefaultValues(sender, e) 
  End Sub
  Protected Sub FVtaCities_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVtaCities.PreRender
    Dim oF_CountryID_Display As Label  = FVtaCities.FindControl("F_CountryID_Display")
    oF_CountryID_Display.Text = String.Empty
    If Not Session("F_CountryID_Display") Is Nothing Then
      If Session("F_CountryID_Display") <> String.Empty Then
        oF_CountryID_Display.Text = Session("F_CountryID_Display")
      End If
    End If
    Dim oF_CountryID As TextBox  = FVtaCities.FindControl("F_CountryID")
    oF_CountryID.Enabled = True
    oF_CountryID.Text = String.Empty
    If Not Session("F_CountryID") Is Nothing Then
      If Session("F_CountryID") <> String.Empty Then
        oF_CountryID.Text = Session("F_CountryID")
      End If
    End If
    Dim oF_RegionID As LC_taRegions = FVtaCities.FindControl("F_RegionID")
    oF_RegionID.Enabled = True
    oF_RegionID.SelectedValue = String.Empty
    If Not Session("F_RegionID") Is Nothing Then
      If Session("F_RegionID") <> String.Empty Then
        oF_RegionID.SelectedValue = Session("F_RegionID")
      End If
    End If
    Dim oF_CurrencyID As LC_taCurrencies = FVtaCities.FindControl("F_CurrencyID")
    oF_CurrencyID.Enabled = True
    oF_CurrencyID.SelectedValue = String.Empty
    If Not Session("F_CurrencyID") Is Nothing Then
      If Session("F_CurrencyID") <> String.Empty Then
        oF_CurrencyID.SelectedValue = Session("F_CurrencyID")
      End If
    End If
    Dim oF_RegionTypeID As LC_taRegionTypes = FVtaCities.FindControl("F_RegionTypeID")
    oF_RegionTypeID.Enabled = True
    oF_RegionTypeID.SelectedValue = String.Empty
    If Not Session("F_RegionTypeID") Is Nothing Then
      If Session("F_RegionTypeID") <> String.Empty Then
        oF_RegionTypeID.SelectedValue = Session("F_RegionTypeID")
      End If
    End If
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/TA_Main/App_Create") & "/AF_taCities.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scripttaCities") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scripttaCities", mStr)
    End If
    If Request.QueryString("CityID") IsNot Nothing Then
      CType(FVtaCities.FindControl("F_CityID"), TextBox).Text = Request.QueryString("CityID")
      CType(FVtaCities.FindControl("F_CityID"), TextBox).Enabled = False
    End If
  End Sub
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function CountryIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.TA.taCountries.SelecttaCountriesAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()> _
  Public Shared Function validatePK_taCities(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
    Dim CityID As String = CType(aVal(1),String)
    Dim oVar As SIS.TA.taCities = SIS.TA.taCities.taCitiesGetByID(CityID)
    If Not oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record allready exists." 
    End If
    Return mRet
  End Function
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_TA_Cities_CountryID(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
    Dim CountryID As String = CType(aVal(1),String)
    Dim oVar As SIS.TA.taCountries = SIS.TA.taCountries.taCountriesGetByID(CountryID)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found." 
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function

End Class
