Partial Class AF_taRegionTypes
  Inherits SIS.SYS.InsertBase
  Protected Sub FVtaRegionTypes_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVtaRegionTypes.Init
    DataClassName = "AtaRegionTypes"
    SetFormView = FVtaRegionTypes
  End Sub
  Protected Sub TBLtaRegionTypes_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLtaRegionTypes.Init
    SetToolBar = TBLtaRegionTypes
  End Sub
  Protected Sub FVtaRegionTypes_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVtaRegionTypes.DataBound
    SIS.TA.taRegionTypes.SetDefaultValues(sender, e) 
  End Sub
  Protected Sub FVtaRegionTypes_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVtaRegionTypes.PreRender
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/TA_Main/App_Create") & "/AF_taRegionTypes.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scripttaRegionTypes") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scripttaRegionTypes", mStr)
    End If
    If Request.QueryString("RegionTypeID") IsNot Nothing Then
      CType(FVtaRegionTypes.FindControl("F_RegionTypeID"), TextBox).Text = Request.QueryString("RegionTypeID")
      CType(FVtaRegionTypes.FindControl("F_RegionTypeID"), TextBox).Enabled = False
    End If
  End Sub
  <System.Web.Services.WebMethod()> _
  Public Shared Function validatePK_taRegionTypes(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
    Dim RegionTypeID As String = CType(aVal(1),String)
    Dim oVar As SIS.TA.taRegionTypes = SIS.TA.taRegionTypes.taRegionTypesGetByID(RegionTypeID)
    If Not oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record allready exists." 
    End If
    Return mRet
  End Function

End Class
