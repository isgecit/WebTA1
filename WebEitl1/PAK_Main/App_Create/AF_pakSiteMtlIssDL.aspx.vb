Partial Class AF_pakSiteMtlIssDL
  Inherits SIS.SYS.InsertBase
  Protected Sub FVpakSiteMtlIssDL_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpakSiteMtlIssDL.Init
    DataClassName = "ApakSiteMtlIssDL"
    SetFormView = FVpakSiteMtlIssDL
  End Sub
  Protected Sub TBLpakSiteMtlIssDL_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLpakSiteMtlIssDL.Init
    SetToolBar = TBLpakSiteMtlIssDL
  End Sub
  Protected Sub FVpakSiteMtlIssDL_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpakSiteMtlIssDL.DataBound
    SIS.PAK.pakSiteMtlIssDL.SetDefaultValues(sender, e) 
  End Sub
  Protected Sub FVpakSiteMtlIssDL_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpakSiteMtlIssDL.PreRender
    Dim oF_ProjectID_Display As Label  = FVpakSiteMtlIssDL.FindControl("F_ProjectID_Display")
    oF_ProjectID_Display.Text = String.Empty
    If Not Session("F_ProjectID_Display") Is Nothing Then
      If Session("F_ProjectID_Display") <> String.Empty Then
        oF_ProjectID_Display.Text = Session("F_ProjectID_Display")
      End If
    End If
    Dim oF_ProjectID As TextBox  = FVpakSiteMtlIssDL.FindControl("F_ProjectID")
    oF_ProjectID.Enabled = True
    oF_ProjectID.Text = String.Empty
    If Not Session("F_ProjectID") Is Nothing Then
      If Session("F_ProjectID") <> String.Empty Then
        oF_ProjectID.Text = Session("F_ProjectID")
      End If
    End If
    Dim oF_IssueNo_Display As Label  = FVpakSiteMtlIssDL.FindControl("F_IssueNo_Display")
    oF_IssueNo_Display.Text = String.Empty
    If Not Session("F_IssueNo_Display") Is Nothing Then
      If Session("F_IssueNo_Display") <> String.Empty Then
        oF_IssueNo_Display.Text = Session("F_IssueNo_Display")
      End If
    End If
    Dim oF_IssueNo As TextBox  = FVpakSiteMtlIssDL.FindControl("F_IssueNo")
    oF_IssueNo.Enabled = True
    oF_IssueNo.Text = String.Empty
    If Not Session("F_IssueNo") Is Nothing Then
      If Session("F_IssueNo") <> String.Empty Then
        oF_IssueNo.Text = Session("F_IssueNo")
      End If
    End If
    Dim oF_IssueSrNo_Display As Label  = FVpakSiteMtlIssDL.FindControl("F_IssueSrNo_Display")
    oF_IssueSrNo_Display.Text = String.Empty
    If Not Session("F_IssueSrNo_Display") Is Nothing Then
      If Session("F_IssueSrNo_Display") <> String.Empty Then
        oF_IssueSrNo_Display.Text = Session("F_IssueSrNo_Display")
      End If
    End If
    Dim oF_IssueSrNo As TextBox  = FVpakSiteMtlIssDL.FindControl("F_IssueSrNo")
    oF_IssueSrNo.Enabled = True
    oF_IssueSrNo.Text = String.Empty
    If Not Session("F_IssueSrNo") Is Nothing Then
      If Session("F_IssueSrNo") <> String.Empty Then
        oF_IssueSrNo.Text = Session("F_IssueSrNo")
      End If
    End If
    Dim oF_SiteMarkNo_Display As Label  = FVpakSiteMtlIssDL.FindControl("F_SiteMarkNo_Display")
    Dim oF_SiteMarkNo As TextBox  = FVpakSiteMtlIssDL.FindControl("F_SiteMarkNo")
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/PAK_Main/App_Create") & "/AF_pakSiteMtlIssDL.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptpakSiteMtlIssDL") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptpakSiteMtlIssDL", mStr)
    End If
    If Request.QueryString("ProjectID") IsNot Nothing Then
      CType(FVpakSiteMtlIssDL.FindControl("F_ProjectID"), TextBox).Text = Request.QueryString("ProjectID")
      CType(FVpakSiteMtlIssDL.FindControl("F_ProjectID"), TextBox).Enabled = False
    End If
    If Request.QueryString("IssueNo") IsNot Nothing Then
      CType(FVpakSiteMtlIssDL.FindControl("F_IssueNo"), TextBox).Text = Request.QueryString("IssueNo")
      CType(FVpakSiteMtlIssDL.FindControl("F_IssueNo"), TextBox).Enabled = False
    End If
    If Request.QueryString("IssueSrNo") IsNot Nothing Then
      CType(FVpakSiteMtlIssDL.FindControl("F_IssueSrNo"), TextBox).Text = Request.QueryString("IssueSrNo")
      CType(FVpakSiteMtlIssDL.FindControl("F_IssueSrNo"), TextBox).Enabled = False
    End If
    If Request.QueryString("IssueSrLNo") IsNot Nothing Then
      CType(FVpakSiteMtlIssDL.FindControl("F_IssueSrLNo"), TextBox).Text = Request.QueryString("IssueSrLNo")
      CType(FVpakSiteMtlIssDL.FindControl("F_IssueSrLNo"), TextBox).Enabled = False
    End If
  End Sub
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function ProjectIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.EITL.eitlProjects.SelecteitlProjectsAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function IssueNoCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.PAK.pakSiteIssReqH.SelectpakSiteIssReqHAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function IssueSrNoCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.PAK.pakSiteIssRecD.SelectpakSiteIssRecDAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function SiteMarkNoCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.PAK.pakSiteItemMaster.SelectpakSiteItemMasterAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_PAK_SiteIssueDLocation_ProjectID(ByVal value As String) As String
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
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_PAK_SiteIssueDLocation_IssueSrNo(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
    Dim ProjectID As String = CType(aVal(1),String)
    Dim IssueNo As Int32 = CType(aVal(2),Int32)
    Dim IssueSrNo As Int32 = CType(aVal(3),Int32)
    Dim oVar As SIS.PAK.pakSiteIssRecD = SIS.PAK.pakSiteIssRecD.pakSiteIssRecDGetByID(ProjectID,IssueNo,IssueSrNo)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found." 
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_PAK_SiteIssueDLocation_IssueNo(ByVal value As String) As String
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
  Public Shared Function validate_FK_PAK_SiteIssueDLocation_SiteMarkNo(ByVal value As String) As String
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
