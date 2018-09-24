Partial Class AF_costProjectTypes
  Inherits SIS.SYS.InsertBase
  Protected Sub FVcostProjectTypes_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVcostProjectTypes.Init
    DataClassName = "AcostProjectTypes"
    SetFormView = FVcostProjectTypes
  End Sub
  Protected Sub TBLcostProjectTypes_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLcostProjectTypes.Init
    SetToolBar = TBLcostProjectTypes
  End Sub
  Protected Sub FVcostProjectTypes_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVcostProjectTypes.DataBound
    SIS.COST.costProjectTypes.SetDefaultValues(sender, e) 
  End Sub
  Protected Sub FVcostProjectTypes_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVcostProjectTypes.PreRender
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/COST_Main/App_Create") & "/AF_costProjectTypes.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptcostProjectTypes") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptcostProjectTypes", mStr)
    End If
    If Request.QueryString("ProjectTypeID") IsNot Nothing Then
      CType(FVcostProjectTypes.FindControl("F_ProjectTypeID"), TextBox).Text = Request.QueryString("ProjectTypeID")
      CType(FVcostProjectTypes.FindControl("F_ProjectTypeID"), TextBox).Enabled = False
    End If
  End Sub
  <System.Web.Services.WebMethod()> _
  Public Shared Function validatePK_costProjectTypes(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
    Dim ProjectTypeID As String = CType(aVal(1),String)
    Dim oVar As SIS.COST.costProjectTypes = SIS.COST.costProjectTypes.costProjectTypesGetByID(ProjectTypeID)
    If Not oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record allready exists." 
    End If
    Return mRet
  End Function

End Class
