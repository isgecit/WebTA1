Partial Class AF_taCityTypes
  Inherits SIS.SYS.InsertBase
  Protected Sub FVtaCityTypes_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVtaCityTypes.Init
    DataClassName = "AtaCityTypes"
    SetFormView = FVtaCityTypes
  End Sub
  Protected Sub TBLtaCityTypes_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLtaCityTypes.Init
    SetToolBar = TBLtaCityTypes
  End Sub
  Protected Sub FVtaCityTypes_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVtaCityTypes.DataBound
    SIS.TA.taCityTypes.SetDefaultValues(sender, e) 
  End Sub
  Protected Sub FVtaCityTypes_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVtaCityTypes.PreRender
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/TA_Main/App_Create") & "/AF_taCityTypes.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scripttaCityTypes") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scripttaCityTypes", mStr)
    End If
    If Request.QueryString("CityTypeID") IsNot Nothing Then
      CType(FVtaCityTypes.FindControl("F_CityTypeID"), TextBox).Text = Request.QueryString("CityTypeID")
      CType(FVtaCityTypes.FindControl("F_CityTypeID"), TextBox).Enabled = False
    End If
  End Sub
  <System.Web.Services.WebMethod()> _
  Public Shared Function validatePK_taCityTypes(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
    Dim CityTypeID As String = CType(aVal(1),String)
    Dim oVar As SIS.TA.taCityTypes = SIS.TA.taCityTypes.taCityTypesGetByID(CityTypeID)
    If Not oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record allready exists." 
    End If
    Return mRet
  End Function

End Class
