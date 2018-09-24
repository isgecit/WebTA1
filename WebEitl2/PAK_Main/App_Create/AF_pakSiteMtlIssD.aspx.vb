Partial Class AF_pakSiteMtlIssD
  Inherits SIS.SYS.InsertBase
  Protected Sub FVpakSiteMtlIssD_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpakSiteMtlIssD.Init
    DataClassName = "ApakSiteMtlIssD"
    SetFormView = FVpakSiteMtlIssD
  End Sub
  Protected Sub TBLpakSiteMtlIssD_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLpakSiteMtlIssD.Init
    SetToolBar = TBLpakSiteMtlIssD
  End Sub
  Protected Sub FVpakSiteMtlIssD_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpakSiteMtlIssD.DataBound
    SIS.PAK.pakSiteMtlIssD.SetDefaultValues(sender, e) 
  End Sub
  Protected Sub FVpakSiteMtlIssD_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpakSiteMtlIssD.PreRender
    Dim oF_ProjectID_Display As Label  = FVpakSiteMtlIssD.FindControl("F_ProjectID_Display")
    oF_ProjectID_Display.Text = String.Empty
    If Not Session("F_ProjectID_Display") Is Nothing Then
      If Session("F_ProjectID_Display") <> String.Empty Then
        oF_ProjectID_Display.Text = Session("F_ProjectID_Display")
      End If
    End If
    Dim oF_ProjectID As TextBox  = FVpakSiteMtlIssD.FindControl("F_ProjectID")
    oF_ProjectID.Enabled = True
    oF_ProjectID.Text = String.Empty
    If Not Session("F_ProjectID") Is Nothing Then
      If Session("F_ProjectID") <> String.Empty Then
        oF_ProjectID.Text = Session("F_ProjectID")
      End If
    End If
    Dim oF_IssueNo_Display As Label  = FVpakSiteMtlIssD.FindControl("F_IssueNo_Display")
    oF_IssueNo_Display.Text = String.Empty
    If Not Session("F_IssueNo_Display") Is Nothing Then
      If Session("F_IssueNo_Display") <> String.Empty Then
        oF_IssueNo_Display.Text = Session("F_IssueNo_Display")
      End If
    End If
    Dim oF_IssueNo As TextBox  = FVpakSiteMtlIssD.FindControl("F_IssueNo")
    oF_IssueNo.Enabled = True
    oF_IssueNo.Text = String.Empty
    If Not Session("F_IssueNo") Is Nothing Then
      If Session("F_IssueNo") <> String.Empty Then
        oF_IssueNo.Text = Session("F_IssueNo")
      End If
    End If
    Dim oF_SiteMarkNo_Display As Label  = FVpakSiteMtlIssD.FindControl("F_SiteMarkNo_Display")
    Dim oF_SiteMarkNo As TextBox  = FVpakSiteMtlIssD.FindControl("F_SiteMarkNo")
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/PAK_Main/App_Create") & "/AF_pakSiteMtlIssD.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptpakSiteMtlIssD") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptpakSiteMtlIssD", mStr)
    End If
    If Request.QueryString("ProjectID") IsNot Nothing Then
      CType(FVpakSiteMtlIssD.FindControl("F_ProjectID"), TextBox).Text = Request.QueryString("ProjectID")
      CType(FVpakSiteMtlIssD.FindControl("F_ProjectID"), TextBox).Enabled = False
    End If
    If Request.QueryString("IssueNo") IsNot Nothing Then
      CType(FVpakSiteMtlIssD.FindControl("F_IssueNo"), TextBox).Text = Request.QueryString("IssueNo")
      CType(FVpakSiteMtlIssD.FindControl("F_IssueNo"), TextBox).Enabled = False
    End If
    If Request.QueryString("IssueSrNo") IsNot Nothing Then
      CType(FVpakSiteMtlIssD.FindControl("F_IssueSrNo"), TextBox).Text = Request.QueryString("IssueSrNo")
      CType(FVpakSiteMtlIssD.FindControl("F_IssueSrNo"), TextBox).Enabled = False
    End If
  End Sub
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function ProjectIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.QCM.qcmProjects.SelectqcmProjectsAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function IssueNoCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.PAK.pakSiteIssReqH.SelectpakSiteIssReqHAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function SiteMarkNoCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.PAK.pakSiteItemMaster.SelectpakSiteItemMasterAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_PAK_SiteIssueD_ProjectID(ByVal value As String) As String
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
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_PAK_SiteIssueD_IssueNo(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
    Dim ProjectID As String = CType(aVal(1),String)
    Dim IssueNo As Int32 = CType(aVal(2),Int32)
    Dim oVar As SIS.PAK.pakSiteIssReqH = SIS.PAK.pakSiteIssReqH.pakSiteIssReqHGetByID(ProjectID,IssueNo)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found." 
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_PAK_SiteIssueD_SiteMarkNo(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
    Dim ProjectID As String = CType(aVal(1),String)
    Dim SiteMarkNo As String = CType(aVal(2),String)
    Dim oVar As SIS.PAK.pakSiteItemMaster = SIS.PAK.pakSiteItemMaster.pakSiteItemMasterGetByID(ProjectID,SiteMarkNo)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found." 
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function

End Class
