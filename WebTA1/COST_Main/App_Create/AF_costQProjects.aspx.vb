Partial Class AF_costQProjects
  Inherits SIS.SYS.InsertBase
  Protected Sub FVcostQProjects_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVcostQProjects.Init
    DataClassName = "AcostQProjects"
    SetFormView = FVcostQProjects
  End Sub
  Protected Sub TBLcostQProjects_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLcostQProjects.Init
    SetToolBar = TBLcostQProjects
  End Sub
  Protected Sub FVcostQProjects_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVcostQProjects.DataBound
    SIS.COST.costQProjects.SetDefaultValues(sender, e) 
  End Sub
  Protected Sub FVcostQProjects_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVcostQProjects.PreRender
    Dim oF_ProjectID_Display As Label  = FVcostQProjects.FindControl("F_ProjectID_Display")
    oF_ProjectID_Display.Text = String.Empty
    If Not Session("F_ProjectID_Display") Is Nothing Then
      If Session("F_ProjectID_Display") <> String.Empty Then
        oF_ProjectID_Display.Text = Session("F_ProjectID_Display")
      End If
    End If
    Dim oF_ProjectID As TextBox  = FVcostQProjects.FindControl("F_ProjectID")
    oF_ProjectID.Enabled = True
    oF_ProjectID.Text = String.Empty
    If Not Session("F_ProjectID") Is Nothing Then
      If Session("F_ProjectID") <> String.Empty Then
        oF_ProjectID.Text = Session("F_ProjectID")
      End If
    End If
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/COST_Main/App_Create") & "/AF_costQProjects.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptcostQProjects") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptcostQProjects", mStr)
    End If
    If Request.QueryString("ProjectID") IsNot Nothing Then
      CType(FVcostQProjects.FindControl("F_ProjectID"), TextBox).Text = Request.QueryString("ProjectID")
      CType(FVcostQProjects.FindControl("F_ProjectID"), TextBox).Enabled = False
    End If
    If Request.QueryString("FinYear") IsNot Nothing Then
      CType(FVcostQProjects.FindControl("F_FinYear"), TextBox).Text = Request.QueryString("FinYear")
      CType(FVcostQProjects.FindControl("F_FinYear"), TextBox).Enabled = False
    End If
    If Request.QueryString("Quarter") IsNot Nothing Then
      CType(FVcostQProjects.FindControl("F_Quarter"), TextBox).Text = Request.QueryString("Quarter")
      CType(FVcostQProjects.FindControl("F_Quarter"), TextBox).Enabled = False
    End If
  End Sub
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function ProjectIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.COST.costProjects.SelectcostProjectsAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_COST_Projects_ProjectID(ByVal value As String) As String
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
