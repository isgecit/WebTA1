Partial Class AF_pakSitePkgH
  Inherits SIS.SYS.InsertBase
  Protected Sub FVpakSitePkgH_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpakSitePkgH.Init
    DataClassName = "ApakSitePkgH"
    SetFormView = FVpakSitePkgH
  End Sub
  Protected Sub TBLpakSitePkgH_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLpakSitePkgH.Init
    SetToolBar = TBLpakSitePkgH
  End Sub
  Protected Sub ODSpakSitePkgH_Inserted(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODSpakSitePkgH.Inserted
    If e.Exception Is Nothing Then
      Dim oDC As SIS.PAK.pakSitePkgH = CType(e.ReturnValue,SIS.PAK.pakSitePkgH)
      Dim tmpURL As String = "?tmp=1"
      tmpURL &= "&ProjectID=" & oDC.ProjectID
      tmpURL &= "&RecNo=" & oDC.RecNo
      TBLpakSitePkgH.AfterInsertURL &= tmpURL 
    End If
  End Sub
  Protected Sub FVpakSitePkgH_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpakSitePkgH.DataBound
    SIS.PAK.pakSitePkgH.SetDefaultValues(sender, e) 
  End Sub
  Protected Sub FVpakSitePkgH_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpakSitePkgH.PreRender
    Dim oF_ProjectID_Display As Label  = FVpakSitePkgH.FindControl("F_ProjectID_Display")
    oF_ProjectID_Display.Text = String.Empty
    If Not Session("F_ProjectID_Display") Is Nothing Then
      If Session("F_ProjectID_Display") <> String.Empty Then
        oF_ProjectID_Display.Text = Session("F_ProjectID_Display")
      End If
    End If
    Dim oF_ProjectID As TextBox  = FVpakSitePkgH.FindControl("F_ProjectID")
    oF_ProjectID.Enabled = True
    oF_ProjectID.Text = String.Empty
    If Not Session("F_ProjectID") Is Nothing Then
      If Session("F_ProjectID") <> String.Empty Then
        oF_ProjectID.Text = Session("F_ProjectID")
      End If
    End If
    Dim oF_SerialNo_Display As Label  = FVpakSitePkgH.FindControl("F_SerialNo_Display")
    oF_SerialNo_Display.Text = String.Empty
    If Not Session("F_SerialNo_Display") Is Nothing Then
      If Session("F_SerialNo_Display") <> String.Empty Then
        oF_SerialNo_Display.Text = Session("F_SerialNo_Display")
      End If
    End If
    Dim oF_SerialNo As TextBox  = FVpakSitePkgH.FindControl("F_SerialNo")
    oF_SerialNo.Enabled = True
    oF_SerialNo.Text = String.Empty
    If Not Session("F_SerialNo") Is Nothing Then
      If Session("F_SerialNo") <> String.Empty Then
        oF_SerialNo.Text = Session("F_SerialNo")
      End If
    End If
    Dim oF_PkgNo_Display As Label  = FVpakSitePkgH.FindControl("F_PkgNo_Display")
    oF_PkgNo_Display.Text = String.Empty
    If Not Session("F_PkgNo_Display") Is Nothing Then
      If Session("F_PkgNo_Display") <> String.Empty Then
        oF_PkgNo_Display.Text = Session("F_PkgNo_Display")
      End If
    End If
    Dim oF_PkgNo As TextBox  = FVpakSitePkgH.FindControl("F_PkgNo")
    oF_PkgNo.Enabled = True
    oF_PkgNo.Text = String.Empty
    If Not Session("F_PkgNo") Is Nothing Then
      If Session("F_PkgNo") <> String.Empty Then
        oF_PkgNo.Text = Session("F_PkgNo")
      End If
    End If
    Dim oF_MRNNo_Display As Label  = FVpakSitePkgH.FindControl("F_MRNNo_Display")
    Dim oF_MRNNo As TextBox  = FVpakSitePkgH.FindControl("F_MRNNo")
    Dim oF_SupplierID_Display As Label  = FVpakSitePkgH.FindControl("F_SupplierID_Display")
    oF_SupplierID_Display.Text = String.Empty
    If Not Session("F_SupplierID_Display") Is Nothing Then
      If Session("F_SupplierID_Display") <> String.Empty Then
        oF_SupplierID_Display.Text = Session("F_SupplierID_Display")
      End If
    End If
    Dim oF_SupplierID As TextBox  = FVpakSitePkgH.FindControl("F_SupplierID")
    oF_SupplierID.Enabled = True
    oF_SupplierID.Text = String.Empty
    If Not Session("F_SupplierID") Is Nothing Then
      If Session("F_SupplierID") <> String.Empty Then
        oF_SupplierID.Text = Session("F_SupplierID")
      End If
    End If
    Dim oF_TransporterID_Display As Label  = FVpakSitePkgH.FindControl("F_TransporterID_Display")
    Dim oF_TransporterID As TextBox  = FVpakSitePkgH.FindControl("F_TransporterID")
    Dim oF_UOMTotalWeight_Display As Label  = FVpakSitePkgH.FindControl("F_UOMTotalWeight_Display")
    Dim oF_UOMTotalWeight As TextBox  = FVpakSitePkgH.FindControl("F_UOMTotalWeight")
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/PAK_Main/App_Create") & "/AF_pakSitePkgH.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptpakSitePkgH") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptpakSitePkgH", mStr)
    End If
    If Request.QueryString("ProjectID") IsNot Nothing Then
      CType(FVpakSitePkgH.FindControl("F_ProjectID"), TextBox).Text = Request.QueryString("ProjectID")
      CType(FVpakSitePkgH.FindControl("F_ProjectID"), TextBox).Enabled = False
    End If
    If Request.QueryString("RecNo") IsNot Nothing Then
      CType(FVpakSitePkgH.FindControl("F_RecNo"), TextBox).Text = Request.QueryString("RecNo")
      CType(FVpakSitePkgH.FindControl("F_RecNo"), TextBox).Enabled = False
    End If
  End Sub
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function ProjectIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.QCM.qcmProjects.SelectqcmProjectsAutoCompleteList(prefixText, count, contextKey)
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
  Public Shared Function MRNNoCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.PAK.pakLorryReceipts.SelectpakLorryReceiptsAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function SupplierIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.PAK.pakBusinessPartner.SelectpakBusinessPartnerAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function TransporterIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.PAK.pakBusinessPartner.SelectpakBusinessPartnerAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function UOMTotalWeightCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.PAK.pakUnits.SelectpakUnitsAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_PAK_SitePkgH_ProjectID(ByVal value As String) As String
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
  Public Shared Function validate_FK_PAK_SitePkgH_PkgNo(ByVal value As String) As String
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
  Public Shared Function validate_FK_PAK_SitePkgH_SerialNo(ByVal value As String) As String
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
  Public Shared Function validate_FK_PAK_SitePkgH_UOMTotalWeight(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
    Dim UOMTotalWeight As Int32 = CType(aVal(1),Int32)
    Dim oVar As SIS.PAK.pakUnits = SIS.PAK.pakUnits.pakUnitsGetByID(UOMTotalWeight)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found." 
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_PAK_SitePkgH_TransporterID(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
    Dim TransporterID As String = CType(aVal(1),String)
    Dim oVar As SIS.PAK.pakBusinessPartner = SIS.PAK.pakBusinessPartner.pakBusinessPartnerGetByID(TransporterID)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found." 
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_PAK_SitePkgH_SupplierID(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
    Dim SupplierID As String = CType(aVal(1),String)
    Dim oVar As SIS.PAK.pakBusinessPartner = SIS.PAK.pakBusinessPartner.pakBusinessPartnerGetByID(SupplierID)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found." 
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_PAK_SitePkgH_MRNNo(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
    Dim ProjectID As String = CType(aVal(1),String)
    Dim MRNNo As Int32 = CType(aVal(2),Int32)
    Dim oVar As SIS.PAK.pakLorryReceipts = SIS.PAK.pakLorryReceipts.pakLorryReceiptsGetByID(ProjectID,MRNNo)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found." 
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function

End Class
