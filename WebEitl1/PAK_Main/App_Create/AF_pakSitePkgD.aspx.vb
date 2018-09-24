Partial Class AF_pakSitePkgD
  Inherits SIS.SYS.InsertBase
  Protected Sub FVpakSitePkgD_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpakSitePkgD.Init
    DataClassName = "ApakSitePkgD"
    SetFormView = FVpakSitePkgD
  End Sub
  Protected Sub TBLpakSitePkgD_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLpakSitePkgD.Init
    SetToolBar = TBLpakSitePkgD
  End Sub
  Protected Sub ODSpakSitePkgD_Inserted(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODSpakSitePkgD.Inserted
    If e.Exception Is Nothing Then
      Dim oDC As SIS.PAK.pakSitePkgD = CType(e.ReturnValue,SIS.PAK.pakSitePkgD)
      Dim tmpURL As String = "?tmp=1"
      tmpURL &= "&ProjectID=" & oDC.ProjectID
      tmpURL &= "&RecNo=" & oDC.RecNo
      tmpURL &= "&RecSrNo=" & oDC.RecSrNo
      TBLpakSitePkgD.AfterInsertURL &= tmpURL 
    End If
  End Sub
  Protected Sub FVpakSitePkgD_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpakSitePkgD.DataBound
    SIS.PAK.pakSitePkgD.SetDefaultValues(sender, e) 
  End Sub
  Protected Sub FVpakSitePkgD_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpakSitePkgD.PreRender
    Dim oF_ProjectID_Display As Label  = FVpakSitePkgD.FindControl("F_ProjectID_Display")
    oF_ProjectID_Display.Text = String.Empty
    If Not Session("F_ProjectID_Display") Is Nothing Then
      If Session("F_ProjectID_Display") <> String.Empty Then
        oF_ProjectID_Display.Text = Session("F_ProjectID_Display")
      End If
    End If
    Dim oF_ProjectID As TextBox  = FVpakSitePkgD.FindControl("F_ProjectID")
    oF_ProjectID.Enabled = True
    oF_ProjectID.Text = String.Empty
    If Not Session("F_ProjectID") Is Nothing Then
      If Session("F_ProjectID") <> String.Empty Then
        oF_ProjectID.Text = Session("F_ProjectID")
      End If
    End If
    Dim oF_RecNo_Display As Label  = FVpakSitePkgD.FindControl("F_RecNo_Display")
    oF_RecNo_Display.Text = String.Empty
    If Not Session("F_RecNo_Display") Is Nothing Then
      If Session("F_RecNo_Display") <> String.Empty Then
        oF_RecNo_Display.Text = Session("F_RecNo_Display")
      End If
    End If
    Dim oF_RecNo As TextBox  = FVpakSitePkgD.FindControl("F_RecNo")
    oF_RecNo.Enabled = True
    oF_RecNo.Text = String.Empty
    If Not Session("F_RecNo") Is Nothing Then
      If Session("F_RecNo") <> String.Empty Then
        oF_RecNo.Text = Session("F_RecNo")
      End If
    End If
    Dim oF_SerialNo_Display As Label  = FVpakSitePkgD.FindControl("F_SerialNo_Display")
    Dim oF_SerialNo As TextBox  = FVpakSitePkgD.FindControl("F_SerialNo")
    Dim oF_PkgNo_Display As Label  = FVpakSitePkgD.FindControl("F_PkgNo_Display")
    Dim oF_PkgNo As TextBox  = FVpakSitePkgD.FindControl("F_PkgNo")
    Dim oF_BOMNo_Display As Label  = FVpakSitePkgD.FindControl("F_BOMNo_Display")
    Dim oF_BOMNo As TextBox  = FVpakSitePkgD.FindControl("F_BOMNo")
    Dim oF_ItemNo_Display As Label  = FVpakSitePkgD.FindControl("F_ItemNo_Display")
    Dim oF_ItemNo As TextBox  = FVpakSitePkgD.FindControl("F_ItemNo")
    Dim oF_SiteMarkNo_Display As Label  = FVpakSitePkgD.FindControl("F_SiteMarkNo_Display")
    Dim oF_SiteMarkNo As TextBox  = FVpakSitePkgD.FindControl("F_SiteMarkNo")
    Dim oF_UOMQuantity_Display As Label  = FVpakSitePkgD.FindControl("F_UOMQuantity_Display")
    Dim oF_UOMQuantity As TextBox  = FVpakSitePkgD.FindControl("F_UOMQuantity")
    Dim oF_DocumentNo_Display As Label  = FVpakSitePkgD.FindControl("F_DocumentNo_Display")
    Dim oF_DocumentNo As TextBox  = FVpakSitePkgD.FindControl("F_DocumentNo")
    Dim oF_PackTypeID_Display As Label  = FVpakSitePkgD.FindControl("F_PackTypeID_Display")
    Dim oF_PackTypeID As TextBox  = FVpakSitePkgD.FindControl("F_PackTypeID")
    Dim oF_UOMPack_Display As Label  = FVpakSitePkgD.FindControl("F_UOMPack_Display")
    Dim oF_UOMPack As TextBox  = FVpakSitePkgD.FindControl("F_UOMPack")
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/PAK_Main/App_Create") & "/AF_pakSitePkgD.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptpakSitePkgD") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptpakSitePkgD", mStr)
    End If
    If Request.QueryString("ProjectID") IsNot Nothing Then
      CType(FVpakSitePkgD.FindControl("F_ProjectID"), TextBox).Text = Request.QueryString("ProjectID")
      CType(FVpakSitePkgD.FindControl("F_ProjectID"), TextBox).Enabled = False
    End If
    If Request.QueryString("RecNo") IsNot Nothing Then
      CType(FVpakSitePkgD.FindControl("F_RecNo"), TextBox).Text = Request.QueryString("RecNo")
      CType(FVpakSitePkgD.FindControl("F_RecNo"), TextBox).Enabled = False
    End If
    If Request.QueryString("RecSrNo") IsNot Nothing Then
      CType(FVpakSitePkgD.FindControl("F_RecSrNo"), TextBox).Text = Request.QueryString("RecSrNo")
      CType(FVpakSitePkgD.FindControl("F_RecSrNo"), TextBox).Enabled = False
    End If
  End Sub
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function ProjectIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.EITL.eitlProjects.SelecteitlProjectsAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function RecNoCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.PAK.pakSitePkgH.SelectpakSitePkgHAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function SerialNoCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.PAK.pakPO.SelectpakPOAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function PkgNoCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.PAK.pakPkgListH.SelectpakPkgListHAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function BOMNoCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.PAK.pakPkgListD.SelectpakPkgListDAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function ItemNoCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.PAK.pakPkgListD.SelectpakPkgListDAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function SiteMarkNoCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.PAK.pakSiteItemMaster.SelectpakSiteItemMasterAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function UOMQuantityCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.PAK.pakUnits.SelectpakUnitsAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function DocumentNoCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.PAK.pakDocuments.SelectpakDocumentsAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function PackTypeIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.PAK.pakPakTypes.SelectpakPakTypesAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function UOMPackCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.PAK.pakUnits.SelectpakUnitsAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_PAK_SitePkgD_ProjectID(ByVal value As String) As String
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
  Public Shared Function validate_FK_PAK_SitePkgD_DocumentNo(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
    Dim DocumentNo As Int32 = CType(aVal(1),Int32)
    Dim oVar As SIS.PAK.pakDocuments = SIS.PAK.pakDocuments.pakDocumentsGetByID(DocumentNo)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found." 
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_PAK_SitePkgD_PAKTypeID(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
    Dim PackTypeID As Int32 = CType(aVal(1),Int32)
    Dim oVar As SIS.PAK.pakPakTypes = SIS.PAK.pakPakTypes.pakPakTypesGetByID(PackTypeID)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found." 
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_PAK_SitePkgD_ItemNo(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
    Dim SerialNo As Int32 = CType(aVal(1),Int32)
    Dim PkgNo As Int32 = CType(aVal(2),Int32)
    Dim BOMNo As Int32 = CType(aVal(3),Int32)
    Dim ItemNo As Int32 = CType(aVal(4),Int32)
    Dim oVar As SIS.PAK.pakPkgListD = SIS.PAK.pakPkgListD.pakPkgListDGetByID(SerialNo,PkgNo,BOMNo,ItemNo)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found." 
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_PAK_SitePkgD_PkgNo(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
    Dim SerialNo As Int32 = CType(aVal(1),Int32)
    Dim PkgNo As Int32 = CType(aVal(2),Int32)
    Dim oVar As SIS.PAK.pakPkgListH = SIS.PAK.pakPkgListH.pakPkgListHGetByID(SerialNo,PkgNo)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found." 
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_PAK_SitePkgD_SerialNo(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
    Dim SerialNo As Int32 = CType(aVal(1),Int32)
    Dim oVar As SIS.PAK.pakPO = SIS.PAK.pakPO.pakPOGetByID(SerialNo)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found." 
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_PAK_SitePkgD_SiteMarkNo(ByVal value As String) As String
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
  Public Shared Function validate_FK_PAK_SitePkgD_RecNo(ByVal value As String) As String
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
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_PAK_SitePkgD_UOMQuantity(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
    Dim UOMQuantity As Int32 = CType(aVal(1),Int32)
    Dim oVar As SIS.PAK.pakUnits = SIS.PAK.pakUnits.pakUnitsGetByID(UOMQuantity)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found." 
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_PAK_SitePkgD_UOMPack(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
    Dim UOMPack As Int32 = CType(aVal(1),Int32)
    Dim oVar As SIS.PAK.pakUnits = SIS.PAK.pakUnits.pakUnitsGetByID(UOMPack)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found." 
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function

End Class
