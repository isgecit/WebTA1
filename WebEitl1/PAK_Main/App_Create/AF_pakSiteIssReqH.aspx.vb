Partial Class AF_pakSiteIssReqH
  Inherits SIS.SYS.InsertBase
  Protected Sub FVpakSiteIssReqH_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpakSiteIssReqH.Init
    DataClassName = "ApakSiteIssReqH"
    SetFormView = FVpakSiteIssReqH
  End Sub
  Protected Sub TBLpakSiteIssReqH_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLpakSiteIssReqH.Init
    SetToolBar = TBLpakSiteIssReqH
  End Sub
  Protected Sub ODSpakSiteIssReqH_Inserted(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODSpakSiteIssReqH.Inserted
    If e.Exception Is Nothing Then
      Dim oDC As SIS.PAK.pakSiteIssReqH = CType(e.ReturnValue,SIS.PAK.pakSiteIssReqH)
      Dim tmpURL As String = "?tmp=1"
      tmpURL &= "&ProjectID=" & oDC.ProjectID
      tmpURL &= "&IssueNo=" & oDC.IssueNo
      TBLpakSiteIssReqH.AfterInsertURL &= tmpURL 
    End If
  End Sub
  Protected Sub FVpakSiteIssReqH_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpakSiteIssReqH.DataBound
    SIS.PAK.pakSiteIssReqH.SetDefaultValues(sender, e) 
  End Sub
  Protected Sub FVpakSiteIssReqH_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpakSiteIssReqH.PreRender
    Dim oF_ProjectID_Display As Label  = FVpakSiteIssReqH.FindControl("F_ProjectID_Display")
    oF_ProjectID_Display.Text = String.Empty
    If Not Session("F_ProjectID_Display") Is Nothing Then
      If Session("F_ProjectID_Display") <> String.Empty Then
        oF_ProjectID_Display.Text = Session("F_ProjectID_Display")
      End If
    End If
    Dim oF_ProjectID As TextBox  = FVpakSiteIssReqH.FindControl("F_ProjectID")
    oF_ProjectID.Enabled = True
    oF_ProjectID.Text = String.Empty
    If Not Session("F_ProjectID") Is Nothing Then
      If Session("F_ProjectID") <> String.Empty Then
        oF_ProjectID.Text = Session("F_ProjectID")
      End If
    End If
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/PAK_Main/App_Create") & "/AF_pakSiteIssReqH.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptpakSiteIssReqH") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptpakSiteIssReqH", mStr)
    End If
    If Request.QueryString("ProjectID") IsNot Nothing Then
      CType(FVpakSiteIssReqH.FindControl("F_ProjectID"), TextBox).Text = Request.QueryString("ProjectID")
      CType(FVpakSiteIssReqH.FindControl("F_ProjectID"), TextBox).Enabled = False
    End If
    If Request.QueryString("IssueNo") IsNot Nothing Then
      CType(FVpakSiteIssReqH.FindControl("F_IssueNo"), TextBox).Text = Request.QueryString("IssueNo")
      CType(FVpakSiteIssReqH.FindControl("F_IssueNo"), TextBox).Enabled = False
    End If
  End Sub
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function ProjectIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.EITL.eitlProjects.SelecteitlProjectsAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_PAK_SiteIssueH_ProjectID(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
    Dim ProjectID As String = CType(aVal(1),String)
    Dim oVar As SIS.EITL.eitlProjects = SIS.EITL.eitlProjects.eitlProjectsGetByID(ProjectID)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found." 
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function

End Class
