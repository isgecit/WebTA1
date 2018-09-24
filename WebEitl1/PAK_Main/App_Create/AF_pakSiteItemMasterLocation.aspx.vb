Partial Class AF_pakSiteItemMasterLocation
  Inherits SIS.SYS.InsertBase
  Protected Sub FVpakSiteItemMasterLocation_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpakSiteItemMasterLocation.Init
    DataClassName = "ApakSiteItemMasterLocation"
    SetFormView = FVpakSiteItemMasterLocation
  End Sub
  Protected Sub TBLpakSiteItemMasterLocation_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLpakSiteItemMasterLocation.Init
    SetToolBar = TBLpakSiteItemMasterLocation
  End Sub
  Protected Sub FVpakSiteItemMasterLocation_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpakSiteItemMasterLocation.DataBound
    SIS.PAK.pakSiteItemMasterLocation.SetDefaultValues(sender, e) 
  End Sub
  Protected Sub FVpakSiteItemMasterLocation_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpakSiteItemMasterLocation.PreRender
    Dim oF_ProjectID_Display As Label  = FVpakSiteItemMasterLocation.FindControl("F_ProjectID_Display")
    oF_ProjectID_Display.Text = String.Empty
    If Not Session("F_ProjectID_Display") Is Nothing Then
      If Session("F_ProjectID_Display") <> String.Empty Then
        oF_ProjectID_Display.Text = Session("F_ProjectID_Display")
      End If
    End If
    Dim oF_ProjectID As TextBox  = FVpakSiteItemMasterLocation.FindControl("F_ProjectID")
    oF_ProjectID.Enabled = True
    oF_ProjectID.Text = String.Empty
    If Not Session("F_ProjectID") Is Nothing Then
      If Session("F_ProjectID") <> String.Empty Then
        oF_ProjectID.Text = Session("F_ProjectID")
      End If
    End If
    Dim oF_SiteMarkNo_Display As Label  = FVpakSiteItemMasterLocation.FindControl("F_SiteMarkNo_Display")
    oF_SiteMarkNo_Display.Text = String.Empty
    If Not Session("F_SiteMarkNo_Display") Is Nothing Then
      If Session("F_SiteMarkNo_Display") <> String.Empty Then
        oF_SiteMarkNo_Display.Text = Session("F_SiteMarkNo_Display")
      End If
    End If
    Dim oF_SiteMarkNo As TextBox  = FVpakSiteItemMasterLocation.FindControl("F_SiteMarkNo")
    oF_SiteMarkNo.Enabled = True
    oF_SiteMarkNo.Text = String.Empty
    If Not Session("F_SiteMarkNo") Is Nothing Then
      If Session("F_SiteMarkNo") <> String.Empty Then
        oF_SiteMarkNo.Text = Session("F_SiteMarkNo")
      End If
    End If
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/PAK_Main/App_Create") & "/AF_pakSiteItemMasterLocation.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptpakSiteItemMasterLocation") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptpakSiteItemMasterLocation", mStr)
    End If
    If Request.QueryString("ProjectID") IsNot Nothing Then
      CType(FVpakSiteItemMasterLocation.FindControl("F_ProjectID"), TextBox).Text = Request.QueryString("ProjectID")
      CType(FVpakSiteItemMasterLocation.FindControl("F_ProjectID"), TextBox).Enabled = False
    End If
    If Request.QueryString("SiteMarkNo") IsNot Nothing Then
      CType(FVpakSiteItemMasterLocation.FindControl("F_SiteMarkNo"), TextBox).Text = Request.QueryString("SiteMarkNo")
      CType(FVpakSiteItemMasterLocation.FindControl("F_SiteMarkNo"), TextBox).Enabled = False
    End If
    If Request.QueryString("LocationID") IsNot Nothing Then
      CType(FVpakSiteItemMasterLocation.FindControl("F_LocationID"), TextBox).Text = Request.QueryString("LocationID")
      CType(FVpakSiteItemMasterLocation.FindControl("F_LocationID"), TextBox).Enabled = False
    End If
  End Sub
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function ProjectIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.EITL.eitlProjects.SelecteitlProjectsAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function SiteMarkNoCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.PAK.pakSiteItemMaster.SelectpakSiteItemMasterAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_PAK_SiteItemMasterLocation_ProjectID(ByVal value As String) As String
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
  Public Shared Function validate_FK_PAK_SiteItemMasterLocation_SiteMarkNo(ByVal value As String) As String
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
