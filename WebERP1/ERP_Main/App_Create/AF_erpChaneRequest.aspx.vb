Partial Class AF_erpChaneRequest
  Inherits SIS.SYS.InsertBase
  Protected Sub FVerpChaneRequest_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVerpChaneRequest.Init
    DataClassName = "AerpChaneRequest"
    SetFormView = FVerpChaneRequest
  End Sub
  Protected Sub TBLerpChaneRequest_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLerpChaneRequest.Init
    SetToolBar = TBLerpChaneRequest
  End Sub
  Protected Sub ODSerpChaneRequest_Inserted(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODSerpChaneRequest.Inserted
		If e.Exception Is Nothing Then
			Dim oDC As SIS.ERP.erpChaneRequest = CType(e.ReturnValue,SIS.ERP.erpChaneRequest)
			Dim tmpURL As String = "?tmp=1"
			tmpURL &= "&ApplID=" & oDC.ApplID
			tmpURL &= "&RequestID=" & oDC.RequestID
			TBLerpChaneRequest.AfterInsertURL &= tmpURL 
		End If
  End Sub
  Protected Sub FVerpChaneRequest_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVerpChaneRequest.PreRender
    Dim oF_ApplID_Display As Label  = FVerpChaneRequest.FindControl("F_ApplID_Display")
    oF_ApplID_Display.Text = String.Empty
    If Not Session("F_ApplID_Display") Is Nothing Then
      If Session("F_ApplID_Display") <> String.Empty Then
        oF_ApplID_Display.Text = Session("F_ApplID_Display")
      End If
    End If
    Dim oF_ApplID As TextBox  = FVerpChaneRequest.FindControl("F_ApplID")
    oF_ApplID.Enabled = True
    oF_ApplID.Text = String.Empty
    If Not Session("F_ApplID") Is Nothing Then
      If Session("F_ApplID") <> String.Empty Then
        oF_ApplID.Text = Session("F_ApplID")
      End If
    End If
    Dim oF_RequestTypeID As LC_erpRequestTypes = FVerpChaneRequest.FindControl("F_RequestTypeID")
    oF_RequestTypeID.Enabled = True
    oF_RequestTypeID.SelectedValue = String.Empty
    If Not Session("F_RequestTypeID") Is Nothing Then
      If Session("F_RequestTypeID") <> String.Empty Then
        oF_RequestTypeID.SelectedValue = Session("F_RequestTypeID")
      End If
    End If
		Dim mStr As String = ""
		Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/ERP_Main/App_Create") & "/AF_erpChaneRequest.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scripterpChaneRequest") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scripterpChaneRequest", mStr)
    End If
    If Request.QueryString("ApplID") IsNot Nothing Then
      CType(FVerpChaneRequest.FindControl("F_ApplID"), TextBox).Text = Request.QueryString("ApplID")
      CType(FVerpChaneRequest.FindControl("F_ApplID"), TextBox).Enabled = False
    End If
    If Request.QueryString("RequestID") IsNot Nothing Then
      CType(FVerpChaneRequest.FindControl("F_RequestID"), TextBox).Text = Request.QueryString("RequestID")
      CType(FVerpChaneRequest.FindControl("F_RequestID"), TextBox).Enabled = False
    End If
  End Sub
	<System.Web.Services.WebMethod()> _
	<System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function ApplIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.ERP.erpApplications.SelecterpApplicationsAutoCompleteList(prefixText, count, contextKey)
  End Function
	<System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_ERP_ChaneRequest_ApplID(ByVal value As String) As String
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

End Class
