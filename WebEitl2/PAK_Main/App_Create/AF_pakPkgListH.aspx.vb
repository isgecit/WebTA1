Partial Class AF_pakPkgListH
  Inherits SIS.SYS.InsertBase
  Protected Sub FVpakPkgListH_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpakPkgListH.Init
    DataClassName = "ApakPkgListH"
    SetFormView = FVpakPkgListH
  End Sub
  Protected Sub TBLpakPkgListH_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLpakPkgListH.Init
    SetToolBar = TBLpakPkgListH
  End Sub
  Protected Sub FVpakPkgListH_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpakPkgListH.DataBound
    SIS.PAK.pakPkgListH.SetDefaultValues(sender, e) 
  End Sub
  Protected Sub FVpakPkgListH_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpakPkgListH.PreRender
    Dim oF_SerialNo_Display As Label  = FVpakPkgListH.FindControl("F_SerialNo_Display")
    oF_SerialNo_Display.Text = String.Empty
    If Not Session("F_SerialNo_Display") Is Nothing Then
      If Session("F_SerialNo_Display") <> String.Empty Then
        oF_SerialNo_Display.Text = Session("F_SerialNo_Display")
      End If
    End If
    Dim oF_SerialNo As TextBox  = FVpakPkgListH.FindControl("F_SerialNo")
    oF_SerialNo.Enabled = True
    oF_SerialNo.Text = String.Empty
    If Not Session("F_SerialNo") Is Nothing Then
      If Session("F_SerialNo") <> String.Empty Then
        oF_SerialNo.Text = Session("F_SerialNo")
      End If
    End If
    Dim oF_TransporterID_Display As Label  = FVpakPkgListH.FindControl("F_TransporterID_Display")
    Dim oF_TransporterID As TextBox  = FVpakPkgListH.FindControl("F_TransporterID")
    Dim oF_VRExecutionNo_Display As Label  = FVpakPkgListH.FindControl("F_VRExecutionNo_Display")
    Dim oF_VRExecutionNo As TextBox  = FVpakPkgListH.FindControl("F_VRExecutionNo")
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/PAK_Main/App_Create") & "/AF_pakPkgListH.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptpakPkgListH") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptpakPkgListH", mStr)
    End If
    If Request.QueryString("SerialNo") IsNot Nothing Then
      CType(FVpakPkgListH.FindControl("F_SerialNo"), TextBox).Text = Request.QueryString("SerialNo")
      CType(FVpakPkgListH.FindControl("F_SerialNo"), TextBox).Enabled = False
    End If
    If Request.QueryString("PkgNo") IsNot Nothing Then
      CType(FVpakPkgListH.FindControl("F_PkgNo"), TextBox).Text = Request.QueryString("PkgNo")
      CType(FVpakPkgListH.FindControl("F_PkgNo"), TextBox).Enabled = False
    End If
  End Sub
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function SerialNoCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.PAK.pakPO.SelectpakPOAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function TransporterIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.PAK.pakBusinessPartner.SelectpakBusinessPartnerAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function VRExecutionNoCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.VR.vrRequestExecution.SelectvrRequestExecutionAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_PAK_PkgListH_SerialNo(ByVal value As String) As String
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
  Public Shared Function validate_FK_PAK_PkgListH_TransporterID(ByVal value As String) As String
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
  Public Shared Function validate_FK_PAK_PkgListH_VRExecutionNo(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
    Dim VRExecutionNo As Int32 = 0
    Try
      VRExecutionNo = CType(aVal(1), Int32)
    Catch ex As Exception
      VRExecutionNo = 0
    End Try
    Dim oVar As SIS.VR.vrRequestExecution = SIS.VR.vrRequestExecution.vrRequestExecutionGetByID(VRExecutionNo)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found.|"
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField & "|" & oVar.TransporterID
    End If
    Return mRet
  End Function

End Class
