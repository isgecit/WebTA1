Partial Class AF_pakSitePkgDLocation
  Inherits SIS.SYS.InsertBase
  Protected Sub FVpakSitePkgDLocation_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpakSitePkgDLocation.Init
    DataClassName = "ApakSitePkgDLocation"
    SetFormView = FVpakSitePkgDLocation
  End Sub
  Protected Sub TBLpakSitePkgDLocation_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLpakSitePkgDLocation.Init
    SetToolBar = TBLpakSitePkgDLocation
  End Sub
  Protected Sub FVpakSitePkgDLocation_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpakSitePkgDLocation.DataBound
    'SIS.PAK.pakSitePkgDLocation.SetDefaultValues(sender, e) 
  End Sub
  Protected Sub FVpakSitePkgDLocation_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpakSitePkgDLocation.PreRender
    Dim oF_ProjectID_Display As Label  = FVpakSitePkgDLocation.FindControl("F_ProjectID_Display")
    oF_ProjectID_Display.Text = String.Empty
    If Not Session("F_ProjectID_Display") Is Nothing Then
      If Session("F_ProjectID_Display") <> String.Empty Then
        oF_ProjectID_Display.Text = Session("F_ProjectID_Display")
      End If
    End If
    Dim oF_ProjectID As TextBox  = FVpakSitePkgDLocation.FindControl("F_ProjectID")
    oF_ProjectID.Enabled = True
    oF_ProjectID.Text = String.Empty
    If Not Session("F_ProjectID") Is Nothing Then
      If Session("F_ProjectID") <> String.Empty Then
        oF_ProjectID.Text = Session("F_ProjectID")
      End If
    End If
    Dim oF_RecNo_Display As Label  = FVpakSitePkgDLocation.FindControl("F_RecNo_Display")
    oF_RecNo_Display.Text = String.Empty
    If Not Session("F_RecNo_Display") Is Nothing Then
      If Session("F_RecNo_Display") <> String.Empty Then
        oF_RecNo_Display.Text = Session("F_RecNo_Display")
      End If
    End If
    Dim oF_RecNo As TextBox  = FVpakSitePkgDLocation.FindControl("F_RecNo")
    oF_RecNo.Enabled = True
    oF_RecNo.Text = String.Empty
    If Not Session("F_RecNo") Is Nothing Then
      If Session("F_RecNo") <> String.Empty Then
        oF_RecNo.Text = Session("F_RecNo")
      End If
    End If
    Dim oF_RecSrNo_Display As Label  = FVpakSitePkgDLocation.FindControl("F_RecSrNo_Display")
    oF_RecSrNo_Display.Text = String.Empty
    If Not Session("F_RecSrNo_Display") Is Nothing Then
      If Session("F_RecSrNo_Display") <> String.Empty Then
        oF_RecSrNo_Display.Text = Session("F_RecSrNo_Display")
      End If
    End If
    Dim oF_RecSrNo As TextBox  = FVpakSitePkgDLocation.FindControl("F_RecSrNo")
    oF_RecSrNo.Enabled = True
    oF_RecSrNo.Text = String.Empty
    If Not Session("F_RecSrNo") Is Nothing Then
      If Session("F_RecSrNo") <> String.Empty Then
        oF_RecSrNo.Text = Session("F_RecSrNo")
      End If
    End If
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/PAK_Main/App_Create") & "/AF_pakSitePkgDLocation.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptpakSitePkgDLocation") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptpakSitePkgDLocation", mStr)
    End If
    Dim ProjectID As String = Request.QueryString("ProjectID")
    Dim RecNo As String = Request.QueryString("RecNo")
    Dim RecSrNo As String = Request.QueryString("RecSrNo")
    If Request.QueryString("ProjectID") IsNot Nothing Then
      CType(FVpakSitePkgDLocation.FindControl("F_ProjectID"), TextBox).Text = Request.QueryString("ProjectID")
      CType(FVpakSitePkgDLocation.FindControl("F_ProjectID"), TextBox).Enabled = False
    End If
    If Request.QueryString("RecNo") IsNot Nothing Then
      CType(FVpakSitePkgDLocation.FindControl("F_RecNo"), TextBox).Text = Request.QueryString("RecNo")
      CType(FVpakSitePkgDLocation.FindControl("F_RecNo"), TextBox).Enabled = False
    End If
    If Request.QueryString("RecSrNo") IsNot Nothing Then
      CType(FVpakSitePkgDLocation.FindControl("F_RecSrNo"), TextBox).Text = Request.QueryString("RecSrNo")
      CType(FVpakSitePkgDLocation.FindControl("F_RecSrNo"), TextBox).Enabled = False
    End If
    If Request.QueryString("RecSrLNo") IsNot Nothing Then
      CType(FVpakSitePkgDLocation.FindControl("F_RecSrLNo"), TextBox).Text = Request.QueryString("RecSrLNo")
      CType(FVpakSitePkgDLocation.FindControl("F_RecSrLNo"), TextBox).Enabled = False
    End If
    Dim tmpD As SIS.PAK.pakSitePkgD = SIS.PAK.pakSitePkgD.pakSitePkgDGetByID(ProjectID, RecNo, RecSrNo)
    CType(FVpakSitePkgDLocation.FindControl("F_SerialNo"), TextBox).Text = tmpD.SerialNo
    CType(FVpakSitePkgDLocation.FindControl("F_PkgNo"), TextBox).Text = tmpD.PkgNo
    CType(FVpakSitePkgDLocation.FindControl("F_BOMNo"), TextBox).Text = tmpD.BOMNo
    CType(FVpakSitePkgDLocation.FindControl("F_ItemNo"), TextBox).Text = tmpD.ItemNo
    CType(FVpakSitePkgDLocation.FindControl("F_SiteMarkNo"), TextBox).Text = tmpD.SiteMarkNo
    CType(FVpakSitePkgDLocation.FindControl("F_UOMQuantity"), TextBox).Text = tmpD.UOMQuantity
  End Sub
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function ProjectIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.QCM.qcmProjects.SelectqcmProjectsAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function RecNoCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.PAK.pakSitePkgH.SelectpakSitePkgHAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function RecSrNoCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.PAK.pakSitePkgD.SelectpakSitePkgDAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_PAK_SitePkgDLocation_ProjectID(ByVal value As String) As String
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
  Public Shared Function validate_FK_PAK_SitePkgDLocation_SiteMarkNo(ByVal value As String) As String
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
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_PAK_SitePkgDLocation_RecSrNo(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
    Dim ProjectID As String = CType(aVal(1),String)
    Dim RecNo As Int32 = CType(aVal(2),Int32)
    Dim RecSrNo As Int32 = CType(aVal(3),Int32)
    Dim oVar As SIS.PAK.pakSitePkgD = SIS.PAK.pakSitePkgD.pakSitePkgDGetByID(ProjectID,RecNo,RecSrNo)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found." 
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_PAK_SitePkgDLocation_RecNo(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
    Dim ProjectID As String = CType(aVal(1),String)
    Dim RecNo As Int32 = CType(aVal(2),Int32)
    Dim oVar As SIS.PAK.pakSitePkgH = SIS.PAK.pakSitePkgH.pakSitePkgHGetByID(ProjectID,RecNo)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found." 
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function

End Class
