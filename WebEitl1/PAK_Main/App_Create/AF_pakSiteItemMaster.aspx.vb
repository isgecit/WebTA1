Partial Class AF_pakSiteItemMaster
  Inherits SIS.SYS.InsertBase
  Protected Sub FVpakSiteItemMaster_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpakSiteItemMaster.Init
    DataClassName = "ApakSiteItemMaster"
    SetFormView = FVpakSiteItemMaster
  End Sub
  Protected Sub TBLpakSiteItemMaster_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLpakSiteItemMaster.Init
    SetToolBar = TBLpakSiteItemMaster
  End Sub
  Protected Sub ODSpakSiteItemMaster_Inserted(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODSpakSiteItemMaster.Inserted
    If e.Exception Is Nothing Then
      Dim oDC As SIS.PAK.pakSiteItemMaster = CType(e.ReturnValue,SIS.PAK.pakSiteItemMaster)
      Dim tmpURL As String = "?tmp=1"
      tmpURL &= "&ProjectID=" & oDC.ProjectID
      tmpURL &= "&SiteMarkNo=" & oDC.SiteMarkNo
      TBLpakSiteItemMaster.AfterInsertURL &= tmpURL 
    End If
  End Sub
  Protected Sub FVpakSiteItemMaster_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpakSiteItemMaster.DataBound
    SIS.PAK.pakSiteItemMaster.SetDefaultValues(sender, e) 
  End Sub
  Protected Sub FVpakSiteItemMaster_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpakSiteItemMaster.PreRender
    Dim oF_ProjectID_Display As Label  = FVpakSiteItemMaster.FindControl("F_ProjectID_Display")
    oF_ProjectID_Display.Text = String.Empty
    If Not Session("F_ProjectID_Display") Is Nothing Then
      If Session("F_ProjectID_Display") <> String.Empty Then
        oF_ProjectID_Display.Text = Session("F_ProjectID_Display")
      End If
    End If
    Dim oF_ProjectID As TextBox  = FVpakSiteItemMaster.FindControl("F_ProjectID")
    oF_ProjectID.Enabled = True
    oF_ProjectID.Text = String.Empty
    If Not Session("F_ProjectID") Is Nothing Then
      If Session("F_ProjectID") <> String.Empty Then
        oF_ProjectID.Text = Session("F_ProjectID")
      End If
    End If
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/PAK_Main/App_Create") & "/AF_pakSiteItemMaster.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptpakSiteItemMaster") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptpakSiteItemMaster", mStr)
    End If
    If Request.QueryString("ProjectID") IsNot Nothing Then
      CType(FVpakSiteItemMaster.FindControl("F_ProjectID"), TextBox).Text = Request.QueryString("ProjectID")
      CType(FVpakSiteItemMaster.FindControl("F_ProjectID"), TextBox).Enabled = False
    End If
    If Request.QueryString("SiteMarkNo") IsNot Nothing Then
      CType(FVpakSiteItemMaster.FindControl("F_SiteMarkNo"), TextBox).Text = Request.QueryString("SiteMarkNo")
      CType(FVpakSiteItemMaster.FindControl("F_SiteMarkNo"), TextBox).Enabled = False
    End If
  End Sub
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function ProjectIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.EITL.eitlProjects.SelecteitlProjectsAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_PAK_SiteItemMaster_ProjectID(ByVal value As String) As String
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
