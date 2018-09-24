Partial Class AF_eitlUnits
  Inherits SIS.SYS.InsertBase
  Protected Sub FVeitlUnits_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVeitlUnits.Init
    DataClassName = "AeitlUnits"
    SetFormView = FVeitlUnits
  End Sub
  Protected Sub TBLeitlUnits_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLeitlUnits.Init
    SetToolBar = TBLeitlUnits
  End Sub
  Protected Sub FVeitlUnits_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVeitlUnits.PreRender
		Dim mStr As String = ""
		Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/EITL_Main/App_Create") & "/AF_eitlUnits.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scripteitlUnits") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scripteitlUnits", mStr)
    End If
    If Request.QueryString("UnitID") IsNot Nothing Then
      CType(FVeitlUnits.FindControl("F_UnitID"), TextBox).Text = Request.QueryString("UnitID")
      CType(FVeitlUnits.FindControl("F_UnitID"), TextBox).Enabled = False
    End If
  End Sub
	<System.Web.Services.WebMethod()> _
  Public Shared Function validatePK_eitlUnits(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
		Dim UnitID As String = CType(aVal(1),String)
		Dim oVar As SIS.EITL.eitlUnits = SIS.EITL.eitlUnits.eitlUnitsGetByID(UnitID)
    If Not oVar Is Nothing Then
			mRet = "1|" & aVal(0) & "|Record allready exists." 
    End If
    Return mRet
  End Function

End Class
