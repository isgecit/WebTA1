Partial Class AF_erpUserRoles
  Inherits SIS.SYS.InsertBase
  Protected Sub FVerpUserRoles_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVerpUserRoles.Init
    DataClassName = "AerpUserRoles"
    SetFormView = FVerpUserRoles
  End Sub
  Protected Sub TBLerpUserRoles_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLerpUserRoles.Init
    SetToolBar = TBLerpUserRoles
  End Sub
  Protected Sub FVerpUserRoles_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVerpUserRoles.PreRender
    Dim oF_RequesterID_Display As Label  = FVerpUserRoles.FindControl("F_RequesterID_Display")
    oF_RequesterID_Display.Text = String.Empty
    If Not Session("F_RequesterID_Display") Is Nothing Then
      If Session("F_RequesterID_Display") <> String.Empty Then
        oF_RequesterID_Display.Text = Session("F_RequesterID_Display")
      End If
    End If
    Dim oF_RequesterID As TextBox  = FVerpUserRoles.FindControl("F_RequesterID")
    oF_RequesterID.Enabled = True
    oF_RequesterID.Text = String.Empty
    If Not Session("F_RequesterID") Is Nothing Then
      If Session("F_RequesterID") <> String.Empty Then
        oF_RequesterID.Text = Session("F_RequesterID")
      End If
    End If
    Dim oF_ApproverID_Display As Label  = FVerpUserRoles.FindControl("F_ApproverID_Display")
    oF_ApproverID_Display.Text = String.Empty
    If Not Session("F_ApproverID_Display") Is Nothing Then
      If Session("F_ApproverID_Display") <> String.Empty Then
        oF_ApproverID_Display.Text = Session("F_ApproverID_Display")
      End If
    End If
    Dim oF_ApproverID As TextBox  = FVerpUserRoles.FindControl("F_ApproverID")
    oF_ApproverID.Enabled = True
    oF_ApproverID.Text = String.Empty
    If Not Session("F_ApproverID") Is Nothing Then
      If Session("F_ApproverID") <> String.Empty Then
        oF_ApproverID.Text = Session("F_ApproverID")
      End If
    End If
    Dim oF_RoleID As LC_erpRoles = FVerpUserRoles.FindControl("F_RoleID")
    oF_RoleID.Enabled = True
    oF_RoleID.SelectedValue = String.Empty
    If Not Session("F_RoleID") Is Nothing Then
      If Session("F_RoleID") <> String.Empty Then
        oF_RoleID.SelectedValue = Session("F_RoleID")
      End If
    End If
		Dim mStr As String = ""
		Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/ERP_Main/App_Create") & "/AF_erpUserRoles.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scripterpUserRoles") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scripterpUserRoles", mStr)
    End If
    If Request.QueryString("SerialNo") IsNot Nothing Then
      CType(FVerpUserRoles.FindControl("F_SerialNo"), TextBox).Text = Request.QueryString("SerialNo")
      CType(FVerpUserRoles.FindControl("F_SerialNo"), TextBox).Enabled = False
    End If
  End Sub
	<System.Web.Services.WebMethod()> _
	<System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function RequesterIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.QCM.qcmUsers.SelectqcmUsersAutoCompleteList(prefixText, count, contextKey)
  End Function
	<System.Web.Services.WebMethod()> _
	<System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function ApproverIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.QCM.qcmUsers.SelectqcmUsersAutoCompleteList(prefixText, count, contextKey)
  End Function
	<System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_ERP_UserRoles_RequesterID(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
		Dim RequesterID As String = CType(aVal(1),String)
		Dim oVar As SIS.QCM.qcmUsers = SIS.QCM.qcmUsers.qcmUsersGetByID(RequesterID)
    If oVar Is Nothing Then
			mRet = "1|" & aVal(0) & "|Record not found." 
    Else
			mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function
	<System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_ERP_UserRoles_ApproverID(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
		Dim ApproverID As String = CType(aVal(1),String)
		Dim oVar As SIS.QCM.qcmUsers = SIS.QCM.qcmUsers.qcmUsersGetByID(ApproverID)
    If oVar Is Nothing Then
			mRet = "1|" & aVal(0) & "|Record not found." 
    Else
			mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function

End Class
