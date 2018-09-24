Partial Class AF_erpRequestAttachments
  Inherits SIS.SYS.InsertBase
  Protected Sub FVerpRequestAttachments_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVerpRequestAttachments.Init
    DataClassName = "AerpRequestAttachments"
    SetFormView = FVerpRequestAttachments
  End Sub
  Protected Sub TBLerpRequestAttachments_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLerpRequestAttachments.Init
    SetToolBar = TBLerpRequestAttachments
  End Sub
  Protected Sub FVerpRequestAttachments_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVerpRequestAttachments.PreRender
    Dim oF_ApplID_Display As Label  = FVerpRequestAttachments.FindControl("F_ApplID_Display")
    oF_ApplID_Display.Text = String.Empty
    If Not Session("F_ApplID_Display") Is Nothing Then
      If Session("F_ApplID_Display") <> String.Empty Then
        oF_ApplID_Display.Text = Session("F_ApplID_Display")
      End If
    End If
    Dim oF_ApplID As TextBox  = FVerpRequestAttachments.FindControl("F_ApplID")
    oF_ApplID.Enabled = True
    oF_ApplID.Text = String.Empty
    If Not Session("F_ApplID") Is Nothing Then
      If Session("F_ApplID") <> String.Empty Then
        oF_ApplID.Text = Session("F_ApplID")
      End If
    End If
    Dim oF_RequestID_Display As Label  = FVerpRequestAttachments.FindControl("F_RequestID_Display")
    oF_RequestID_Display.Text = String.Empty
    If Not Session("F_RequestID_Display") Is Nothing Then
      If Session("F_RequestID_Display") <> String.Empty Then
        oF_RequestID_Display.Text = Session("F_RequestID_Display")
      End If
    End If
    Dim oF_RequestID As TextBox  = FVerpRequestAttachments.FindControl("F_RequestID")
    oF_RequestID.Enabled = True
    oF_RequestID.Text = String.Empty
    If Not Session("F_RequestID") Is Nothing Then
      If Session("F_RequestID") <> String.Empty Then
        oF_RequestID.Text = Session("F_RequestID")
      End If
    End If
		Dim mStr As String = ""
		Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/ERP_Main/App_Create") & "/AF_erpRequestAttachments.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scripterpRequestAttachments") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scripterpRequestAttachments", mStr)
    End If
    If Request.QueryString("ApplID") IsNot Nothing Then
      CType(FVerpRequestAttachments.FindControl("F_ApplID"), TextBox).Text = Request.QueryString("ApplID")
      CType(FVerpRequestAttachments.FindControl("F_ApplID"), TextBox).Enabled = False
    End If
    If Request.QueryString("RequestID") IsNot Nothing Then
      CType(FVerpRequestAttachments.FindControl("F_RequestID"), TextBox).Text = Request.QueryString("RequestID")
      CType(FVerpRequestAttachments.FindControl("F_RequestID"), TextBox).Enabled = False
    End If
    If Request.QueryString("SerialNo") IsNot Nothing Then
      CType(FVerpRequestAttachments.FindControl("F_SerialNo"), TextBox).Text = Request.QueryString("SerialNo")
      CType(FVerpRequestAttachments.FindControl("F_SerialNo"), TextBox).Enabled = False
    End If
  End Sub
	<System.Web.Services.WebMethod()> _
	<System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function ApplIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.ERP.erpApplications.SelecterpApplicationsAutoCompleteList(prefixText, count, contextKey)
  End Function
	<System.Web.Services.WebMethod()> _
	<System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function RequestIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.ERP.erpChaneRequest.SelecterpChaneRequestAutoCompleteList(prefixText, count, contextKey)
  End Function
	<System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_ERP_RequestAttachments_ApplID(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
		Dim ApplID As Int32 = CType(aVal(1),Int32)
		Dim oVar As SIS.ERP.erpApplications = SIS.ERP.erpApplications.erpApplicationsGetByID(ApplID)
    If oVar Is Nothing Then
			mRet = "1|" & aVal(0) & "|Record not found." 
    Else
			mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function
	<System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_ERP_RequestAttachments_ApplID_RequestID(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
		Dim ApplID As Int32 = CType(aVal(1),Int32)
		Dim RequestID As Int32 = CType(aVal(2),Int32)
		Dim oVar As SIS.ERP.erpChaneRequest = SIS.ERP.erpChaneRequest.erpChaneRequestGetByID(ApplID,RequestID)
    If oVar Is Nothing Then
			mRet = "1|" & aVal(0) & "|Record not found." 
    Else
			mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function

End Class
