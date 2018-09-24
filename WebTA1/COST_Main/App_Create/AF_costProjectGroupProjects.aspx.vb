Partial Class AF_costProjectGroupProjects
  Inherits SIS.SYS.InsertBase
  Protected Sub FVcostProjectGroupProjects_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVcostProjectGroupProjects.Init
    DataClassName = "AcostProjectGroupProjects"
    SetFormView = FVcostProjectGroupProjects
  End Sub
  Protected Sub TBLcostProjectGroupProjects_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLcostProjectGroupProjects.Init
    SetToolBar = TBLcostProjectGroupProjects
  End Sub
  Protected Sub FVcostProjectGroupProjects_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVcostProjectGroupProjects.DataBound
    SIS.COST.costProjectGroupProjects.SetDefaultValues(sender, e) 
  End Sub
  Protected Sub FVcostProjectGroupProjects_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVcostProjectGroupProjects.PreRender
    Dim oF_ProjectGroupID_Display As Label  = FVcostProjectGroupProjects.FindControl("F_ProjectGroupID_Display")
    oF_ProjectGroupID_Display.Text = String.Empty
    If Not Session("F_ProjectGroupID_Display") Is Nothing Then
      If Session("F_ProjectGroupID_Display") <> String.Empty Then
        oF_ProjectGroupID_Display.Text = Session("F_ProjectGroupID_Display")
      End If
    End If
    Dim oF_ProjectGroupID As TextBox  = FVcostProjectGroupProjects.FindControl("F_ProjectGroupID")
    oF_ProjectGroupID.Enabled = True
    oF_ProjectGroupID.Text = String.Empty
    If Not Session("F_ProjectGroupID") Is Nothing Then
      If Session("F_ProjectGroupID") <> String.Empty Then
        oF_ProjectGroupID.Text = Session("F_ProjectGroupID")
      End If
    End If
    Dim oF_ProjectID_Display As Label  = FVcostProjectGroupProjects.FindControl("F_ProjectID_Display")
    Dim oF_ProjectID As TextBox  = FVcostProjectGroupProjects.FindControl("F_ProjectID")
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/COST_Main/App_Create") & "/AF_costProjectGroupProjects.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptcostProjectGroupProjects") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptcostProjectGroupProjects", mStr)
    End If
    If Request.QueryString("ProjectGroupID") IsNot Nothing Then
      CType(FVcostProjectGroupProjects.FindControl("F_ProjectGroupID"), TextBox).Text = Request.QueryString("ProjectGroupID")
      CType(FVcostProjectGroupProjects.FindControl("F_ProjectGroupID"), TextBox).Enabled = False
    End If
    If Request.QueryString("ProjectID") IsNot Nothing Then
      CType(FVcostProjectGroupProjects.FindControl("F_ProjectID"), TextBox).Text = Request.QueryString("ProjectID")
      CType(FVcostProjectGroupProjects.FindControl("F_ProjectID"), TextBox).Enabled = False
    End If
  End Sub
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function ProjectGroupIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.COST.costProjectGroups.SelectcostProjectGroupsAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function ProjectIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.COST.costProjects.SelectcostProjectsAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_COST_ProjectGroupProjects_ProjectGroupID(ByVal value As String) As String
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
  Public Shared Function validate_FK_COST_ProjectGroupProjects_ProjectID(ByVal value As String) As String
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
