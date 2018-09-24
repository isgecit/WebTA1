Partial Class AF_pakSiteMtlIssH
  Inherits SIS.SYS.InsertBase
  Protected Sub FVpakSiteMtlIssH_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpakSiteMtlIssH.Init
    DataClassName = "ApakSiteMtlIssH"
    SetFormView = FVpakSiteMtlIssH
  End Sub
  Protected Sub TBLpakSiteMtlIssH_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLpakSiteMtlIssH.Init
    SetToolBar = TBLpakSiteMtlIssH
  End Sub
  Protected Sub ODSpakSiteMtlIssH_Inserted(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODSpakSiteMtlIssH.Inserted
    If e.Exception Is Nothing Then
      Dim oDC As SIS.PAK.pakSiteMtlIssH = CType(e.ReturnValue,SIS.PAK.pakSiteMtlIssH)
      Dim tmpURL As String = "?tmp=1"
      tmpURL &= "&ProjectID=" & oDC.ProjectID
      tmpURL &= "&IssueNo=" & oDC.IssueNo
      TBLpakSiteMtlIssH.AfterInsertURL &= tmpURL 
    End If
  End Sub
  Protected Sub FVpakSiteMtlIssH_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpakSiteMtlIssH.DataBound
    SIS.PAK.pakSiteMtlIssH.SetDefaultValues(sender, e) 
  End Sub
  Protected Sub FVpakSiteMtlIssH_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpakSiteMtlIssH.PreRender
    Dim oF_ProjectID_Display As Label  = FVpakSiteMtlIssH.FindControl("F_ProjectID_Display")
    oF_ProjectID_Display.Text = String.Empty
    If Not Session("F_ProjectID_Display") Is Nothing Then
      If Session("F_ProjectID_Display") <> String.Empty Then
        oF_ProjectID_Display.Text = Session("F_ProjectID_Display")
      End If
    End If
    Dim oF_ProjectID As TextBox  = FVpakSiteMtlIssH.FindControl("F_ProjectID")
    oF_ProjectID.Enabled = True
    oF_ProjectID.Text = String.Empty
    If Not Session("F_ProjectID") Is Nothing Then
      If Session("F_ProjectID") <> String.Empty Then
        oF_ProjectID.Text = Session("F_ProjectID")
      End If
    End If
    Dim oF_IssueToCardNo_Display As Label  = FVpakSiteMtlIssH.FindControl("F_IssueToCardNo_Display")
    Dim oF_IssueToCardNo As TextBox  = FVpakSiteMtlIssH.FindControl("F_IssueToCardNo")
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/PAK_Main/App_Create") & "/AF_pakSiteMtlIssH.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptpakSiteMtlIssH") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptpakSiteMtlIssH", mStr)
    End If
    If Request.QueryString("ProjectID") IsNot Nothing Then
      CType(FVpakSiteMtlIssH.FindControl("F_ProjectID"), TextBox).Text = Request.QueryString("ProjectID")
      CType(FVpakSiteMtlIssH.FindControl("F_ProjectID"), TextBox).Enabled = False
    End If
    If Request.QueryString("IssueNo") IsNot Nothing Then
      CType(FVpakSiteMtlIssH.FindControl("F_IssueNo"), TextBox).Text = Request.QueryString("IssueNo")
      CType(FVpakSiteMtlIssH.FindControl("F_IssueNo"), TextBox).Enabled = False
    End If
  End Sub
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function ProjectIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.QCM.qcmProjects.SelectqcmProjectsAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function IssueToCardNoCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.QCM.qcmUsers.SelectqcmUsersAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_PAK_SiteIssueH_IssueToCardNo(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
    Dim IssueToCardNo As String = CType(aVal(1),String)
    Dim oVar As SIS.QCM.qcmUsers = SIS.QCM.qcmUsers.qcmUsersGetByID(IssueToCardNo)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found." 
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_PAK_SiteIssueH_ProjectID(ByVal value As String) As String
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
