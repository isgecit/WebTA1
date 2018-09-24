Partial Class AF_costAdjustmentEntry
  Inherits SIS.SYS.InsertBase
  Protected Sub FVcostAdjustmentEntry_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVcostAdjustmentEntry.Init
    DataClassName = "AcostAdjustmentEntry"
    SetFormView = FVcostAdjustmentEntry
  End Sub
  Protected Sub TBLcostAdjustmentEntry_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLcostAdjustmentEntry.Init
    SetToolBar = TBLcostAdjustmentEntry
  End Sub
  Protected Sub FVcostAdjustmentEntry_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVcostAdjustmentEntry.DataBound
    SIS.COST.costAdjustmentEntry.SetDefaultValues(sender, e) 
  End Sub
  Protected Sub FVcostAdjustmentEntry_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVcostAdjustmentEntry.PreRender
    Dim oF_ProjectGroupID_Display As Label  = FVcostAdjustmentEntry.FindControl("F_ProjectGroupID_Display")
    oF_ProjectGroupID_Display.Text = String.Empty
    If Not Session("F_ProjectGroupID_Display") Is Nothing Then
      If Session("F_ProjectGroupID_Display") <> String.Empty Then
        oF_ProjectGroupID_Display.Text = Session("F_ProjectGroupID_Display")
      End If
    End If
    Dim oF_ProjectGroupID As TextBox  = FVcostAdjustmentEntry.FindControl("F_ProjectGroupID")
    oF_ProjectGroupID.Enabled = True
    oF_ProjectGroupID.Text = String.Empty
    If Not Session("F_ProjectGroupID") Is Nothing Then
      If Session("F_ProjectGroupID") <> String.Empty Then
        oF_ProjectGroupID.Text = Session("F_ProjectGroupID")
      End If
    End If
    Dim oF_FinYear_Display As Label  = FVcostAdjustmentEntry.FindControl("F_FinYear_Display")
    oF_FinYear_Display.Text = String.Empty
    If Not Session("F_FinYear_Display") Is Nothing Then
      If Session("F_FinYear_Display") <> String.Empty Then
        oF_FinYear_Display.Text = Session("F_FinYear_Display")
      End If
    End If
    Dim oF_FinYear As TextBox  = FVcostAdjustmentEntry.FindControl("F_FinYear")
    oF_FinYear.Enabled = True
    oF_FinYear.Text = String.Empty
    If Not Session("F_FinYear") Is Nothing Then
      If Session("F_FinYear") <> String.Empty Then
        oF_FinYear.Text = Session("F_FinYear")
      End If
    End If
    Dim oF_Quarter_Display As Label  = FVcostAdjustmentEntry.FindControl("F_Quarter_Display")
    oF_Quarter_Display.Text = String.Empty
    If Not Session("F_Quarter_Display") Is Nothing Then
      If Session("F_Quarter_Display") <> String.Empty Then
        oF_Quarter_Display.Text = Session("F_Quarter_Display")
      End If
    End If
    Dim oF_Quarter As TextBox  = FVcostAdjustmentEntry.FindControl("F_Quarter")
    oF_Quarter.Enabled = True
    oF_Quarter.Text = String.Empty
    If Not Session("F_Quarter") Is Nothing Then
      If Session("F_Quarter") <> String.Empty Then
        oF_Quarter.Text = Session("F_Quarter")
      End If
    End If
    Dim oF_ProjectID_Display As Label  = FVcostAdjustmentEntry.FindControl("F_ProjectID_Display")
    Dim oF_ProjectID As TextBox  = FVcostAdjustmentEntry.FindControl("F_ProjectID")
    Dim oF_CrGLCode_Display As Label  = FVcostAdjustmentEntry.FindControl("F_CrGLCode_Display")
    Dim oF_CrGLCode As TextBox  = FVcostAdjustmentEntry.FindControl("F_CrGLCode")
    Dim oF_DrGLCode_Display As Label  = FVcostAdjustmentEntry.FindControl("F_DrGLCode_Display")
    Dim oF_DrGLCode As TextBox  = FVcostAdjustmentEntry.FindControl("F_DrGLCode")
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/COST_Main/App_Create") & "/AF_costAdjustmentEntry.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptcostAdjustmentEntry") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptcostAdjustmentEntry", mStr)
    End If
    If Request.QueryString("ProjectGroupID") IsNot Nothing Then
      CType(FVcostAdjustmentEntry.FindControl("F_ProjectGroupID"), TextBox).Text = Request.QueryString("ProjectGroupID")
      CType(FVcostAdjustmentEntry.FindControl("F_ProjectGroupID"), TextBox).Enabled = False
    End If
    If Request.QueryString("FinYear") IsNot Nothing Then
      CType(FVcostAdjustmentEntry.FindControl("F_FinYear"), TextBox).Text = Request.QueryString("FinYear")
      CType(FVcostAdjustmentEntry.FindControl("F_FinYear"), TextBox).Enabled = False
    End If
    If Request.QueryString("Quarter") IsNot Nothing Then
      CType(FVcostAdjustmentEntry.FindControl("F_Quarter"), TextBox).Text = Request.QueryString("Quarter")
      CType(FVcostAdjustmentEntry.FindControl("F_Quarter"), TextBox).Enabled = False
    End If
    If Request.QueryString("Revision") IsNot Nothing Then
      CType(FVcostAdjustmentEntry.FindControl("F_Revision"), TextBox).Text = Request.QueryString("Revision")
      CType(FVcostAdjustmentEntry.FindControl("F_Revision"), TextBox).Enabled = False
    End If
    If Request.QueryString("AdjustmentSerialNo") IsNot Nothing Then
      CType(FVcostAdjustmentEntry.FindControl("F_AdjustmentSerialNo"), TextBox).Text = Request.QueryString("AdjustmentSerialNo")
      CType(FVcostAdjustmentEntry.FindControl("F_AdjustmentSerialNo"), TextBox).Enabled = False
    End If
  End Sub
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function ProjectGroupIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.COST.costProjectGroups.SelectcostProjectGroupsAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function FinYearCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.COST.costFinYear.SelectcostFinYearAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function QuarterCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.COST.costQuarters.SelectcostQuartersAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function ProjectIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.COST.costProjects.SelectcostProjectsAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function CrGLCodeCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.COST.costERPGLCodes.SelectcostERPGLCodesAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function DrGLCodeCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.COST.costERPGLCodes.SelectcostERPGLCodesAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_COST_AdjustmentEntry_CrGLCode(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
    Dim CrGLCode As String = CType(aVal(1),String)
    Dim oVar As SIS.COST.costERPGLCodes = SIS.COST.costERPGLCodes.costERPGLCodesGetByID(CrGLCode)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found." 
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_COST_AdjustmentEntry_DrGLCode(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
    Dim DrGLCode As String = CType(aVal(1),String)
    Dim oVar As SIS.COST.costERPGLCodes = SIS.COST.costERPGLCodes.costERPGLCodesGetByID(DrGLCode)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found." 
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_COST_AdjustmentEntry_FinYear(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
    Dim FinYear As Int32 = CType(aVal(1),Int32)
    Dim oVar As SIS.COST.costFinYear = SIS.COST.costFinYear.costFinYearGetByID(FinYear)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found." 
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_COST_AdjustmentEntry_ProjectGroupID(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
    Dim ProjectGroupID As Int32 = CType(aVal(1),Int32)
    Dim oVar As SIS.COST.costProjectGroups = SIS.COST.costProjectGroups.costProjectGroupsGetByID(ProjectGroupID)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found." 
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_COST_AdjustmentEntry_Quarter(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
    Dim Quarter As Int32 = CType(aVal(1),Int32)
    Dim oVar As SIS.COST.costQuarters = SIS.COST.costQuarters.costQuartersGetByID(Quarter)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found." 
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_COST_AdjustmentEntry_ProjectID(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
    Dim ProjectID As String = CType(aVal(1),String)
    Dim oVar As SIS.COST.costProjects = SIS.COST.costProjects.costProjectsGetByID(ProjectID)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found." 
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function

End Class
