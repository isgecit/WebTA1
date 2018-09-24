Partial Class AF_pakSiteUserProjects
  Inherits SIS.SYS.InsertBase
  Protected Sub FVpakSiteUserProjects_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpakSiteUserProjects.Init
    DataClassName = "ApakSiteUserProjects"
    SetFormView = FVpakSiteUserProjects
  End Sub
  Protected Sub TBLpakSiteUserProjects_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLpakSiteUserProjects.Init
    SetToolBar = TBLpakSiteUserProjects
  End Sub
  Protected Sub FVpakSiteUserProjects_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpakSiteUserProjects.DataBound
    SIS.PAK.pakSiteUserProjects.SetDefaultValues(sender, e) 
  End Sub
  Protected Sub FVpakSiteUserProjects_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpakSiteUserProjects.PreRender
    Dim oF_UserID_Display As Label  = FVpakSiteUserProjects.FindControl("F_UserID_Display")
    oF_UserID_Display.Text = String.Empty
    If Not Session("F_UserID_Display") Is Nothing Then
      If Session("F_UserID_Display") <> String.Empty Then
        oF_UserID_Display.Text = Session("F_UserID_Display")
      End If
    End If
    Dim oF_UserID As TextBox  = FVpakSiteUserProjects.FindControl("F_UserID")
    oF_UserID.Enabled = True
    oF_UserID.Text = String.Empty
    If Not Session("F_UserID") Is Nothing Then
      If Session("F_UserID") <> String.Empty Then
        oF_UserID.Text = Session("F_UserID")
      End If
    End If
    Dim oF_ProjectID_Display As Label  = FVpakSiteUserProjects.FindControl("F_ProjectID_Display")
    oF_ProjectID_Display.Text = String.Empty
    If Not Session("F_ProjectID_Display") Is Nothing Then
      If Session("F_ProjectID_Display") <> String.Empty Then
        oF_ProjectID_Display.Text = Session("F_ProjectID_Display")
      End If
    End If
    Dim oF_ProjectID As TextBox  = FVpakSiteUserProjects.FindControl("F_ProjectID")
    oF_ProjectID.Enabled = True
    oF_ProjectID.Text = String.Empty
    If Not Session("F_ProjectID") Is Nothing Then
      If Session("F_ProjectID") <> String.Empty Then
        oF_ProjectID.Text = Session("F_ProjectID")
      End If
    End If
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/PAK_Main/App_Create") & "/AF_pakSiteUserProjects.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptpakSiteUserProjects") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptpakSiteUserProjects", mStr)
    End If
    If Request.QueryString("UserID") IsNot Nothing Then
      CType(FVpakSiteUserProjects.FindControl("F_UserID"), TextBox).Text = Request.QueryString("UserID")
      CType(FVpakSiteUserProjects.FindControl("F_UserID"), TextBox).Enabled = False
    End If
    If Request.QueryString("ProjectID") IsNot Nothing Then
      CType(FVpakSiteUserProjects.FindControl("F_ProjectID"), TextBox).Text = Request.QueryString("ProjectID")
      CType(FVpakSiteUserProjects.FindControl("F_ProjectID"), TextBox).Enabled = False
    End If
  End Sub
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function UserIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.QCM.qcmUsers.SelectqcmUsersAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function ProjectIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.QCM.qcmProjects.SelectqcmProjectsAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_PAK_SiteUserProjects_UserID(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
    Dim UserID As String = CType(aVal(1),String)
    Dim oVar As SIS.QCM.qcmUsers = SIS.QCM.qcmUsers.qcmUsersGetByID(UserID)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found." 
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_PAK_SiteUserProjects_ProjectID(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
    Dim ProjectID As String = CType(aVal(1),String)
    Dim oVar As SIS.QCM.qcmProjects = SIS.QCM.qcmProjects.qcmProjectsGetByID(ProjectID)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found." 
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function

End Class
