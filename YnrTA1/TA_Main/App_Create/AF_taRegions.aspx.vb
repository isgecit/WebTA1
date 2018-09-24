Partial Class AF_taRegions
  Inherits SIS.SYS.InsertBase
  Protected Sub FVtaRegions_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVtaRegions.Init
    DataClassName = "AtaRegions"
    SetFormView = FVtaRegions
  End Sub
  Protected Sub TBLtaRegions_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLtaRegions.Init
    SetToolBar = TBLtaRegions
  End Sub
  Protected Sub FVtaRegions_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVtaRegions.DataBound
    SIS.TA.taRegions.SetDefaultValues(sender, e) 
  End Sub
  Protected Sub FVtaRegions_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVtaRegions.PreRender
    Dim oF_RegionTypeID As LC_taRegionTypes = FVtaRegions.FindControl("F_RegionTypeID")
    oF_RegionTypeID.Enabled = True
    oF_RegionTypeID.SelectedValue = String.Empty
    If Not Session("F_RegionTypeID") Is Nothing Then
      If Session("F_RegionTypeID") <> String.Empty Then
        oF_RegionTypeID.SelectedValue = Session("F_RegionTypeID")
      End If
    End If
    Dim oF_CurrencyID As LC_taCurrencies = FVtaRegions.FindControl("F_CurrencyID")
    oF_CurrencyID.Enabled = True
    oF_CurrencyID.SelectedValue = String.Empty
    If Not Session("F_CurrencyID") Is Nothing Then
      If Session("F_CurrencyID") <> String.Empty Then
        oF_CurrencyID.SelectedValue = Session("F_CurrencyID")
      End If
    End If
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/TA_Main/App_Create") & "/AF_taRegions.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scripttaRegions") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scripttaRegions", mStr)
    End If
    If Request.QueryString("RegionID") IsNot Nothing Then
      CType(FVtaRegions.FindControl("F_RegionID"), TextBox).Text = Request.QueryString("RegionID")
      CType(FVtaRegions.FindControl("F_RegionID"), TextBox).Enabled = False
    End If
  End Sub
  <System.Web.Services.WebMethod()> _
  Public Shared Function validatePK_taRegions(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
    Dim RegionID As String = CType(aVal(1),String)
    Dim oVar As SIS.TA.taRegions = SIS.TA.taRegions.taRegionsGetByID(RegionID)
    If Not oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record allready exists." 
    End If
    Return mRet
  End Function

End Class
