Partial Class AF_costGLGroupGLs
  Inherits SIS.SYS.InsertBase
  Protected Sub FVcostGLGroupGLs_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVcostGLGroupGLs.Init
    DataClassName = "AcostGLGroupGLs"
    SetFormView = FVcostGLGroupGLs
  End Sub
  Protected Sub TBLcostGLGroupGLs_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLcostGLGroupGLs.Init
    SetToolBar = TBLcostGLGroupGLs
  End Sub
  Protected Sub FVcostGLGroupGLs_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVcostGLGroupGLs.DataBound
    SIS.COST.costGLGroupGLs.SetDefaultValues(sender, e) 
  End Sub
  Protected Sub FVcostGLGroupGLs_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVcostGLGroupGLs.PreRender
    Dim oF_GLGroupID_Display As Label  = FVcostGLGroupGLs.FindControl("F_GLGroupID_Display")
    oF_GLGroupID_Display.Text = String.Empty
    If Not Session("F_GLGroupID_Display") Is Nothing Then
      If Session("F_GLGroupID_Display") <> String.Empty Then
        oF_GLGroupID_Display.Text = Session("F_GLGroupID_Display")
      End If
    End If
    Dim oF_GLGroupID As TextBox  = FVcostGLGroupGLs.FindControl("F_GLGroupID")
    oF_GLGroupID.Enabled = True
    oF_GLGroupID.Text = String.Empty
    If Not Session("F_GLGroupID") Is Nothing Then
      If Session("F_GLGroupID") <> String.Empty Then
        oF_GLGroupID.Text = Session("F_GLGroupID")
      End If
    End If
    Dim oF_GLCode_Display As Label  = FVcostGLGroupGLs.FindControl("F_GLCode_Display")
    Dim oF_GLCode As TextBox  = FVcostGLGroupGLs.FindControl("F_GLCode")
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/COST_Main/App_Create") & "/AF_costGLGroupGLs.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptcostGLGroupGLs") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptcostGLGroupGLs", mStr)
    End If
    If Request.QueryString("GLGroupID") IsNot Nothing Then
      CType(FVcostGLGroupGLs.FindControl("F_GLGroupID"), TextBox).Text = Request.QueryString("GLGroupID")
      CType(FVcostGLGroupGLs.FindControl("F_GLGroupID"), TextBox).Enabled = False
    End If
    If Request.QueryString("GLCode") IsNot Nothing Then
      CType(FVcostGLGroupGLs.FindControl("F_GLCode"), TextBox).Text = Request.QueryString("GLCode")
      CType(FVcostGLGroupGLs.FindControl("F_GLCode"), TextBox).Enabled = False
    End If
  End Sub
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function GLGroupIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.COST.costGLGroups.SelectcostGLGroupsAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function GLCodeCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.COST.costERPGLCodes.SelectcostERPGLCodesAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_COST_GLGroupGLs_GLGroupID(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
    Dim GLGroupID As Int32 = CType(aVal(1),Int32)
    Dim oVar As SIS.COST.costGLGroups = SIS.COST.costGLGroups.costGLGroupsGetByID(GLGroupID)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found." 
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_COST_GLGroupGLs_GLCode(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
    Dim GLCode As String = CType(aVal(1),String)
    Dim oVar As SIS.COST.costERPGLCodes = SIS.COST.costERPGLCodes.costERPGLCodesGetByID(GLCode)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found." 
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function

End Class
