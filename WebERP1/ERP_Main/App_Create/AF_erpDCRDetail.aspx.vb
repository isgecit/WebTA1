Partial Class AF_erpDCRDetail
  Inherits SIS.SYS.InsertBase
  Protected Sub FVerpDCRDetail_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVerpDCRDetail.Init
    DataClassName = "AerpDCRDetail"
    SetFormView = FVerpDCRDetail
  End Sub
  Protected Sub TBLerpDCRDetail_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLerpDCRDetail.Init
    SetToolBar = TBLerpDCRDetail
  End Sub
  Protected Sub FVerpDCRDetail_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVerpDCRDetail.PreRender
    Dim oF_DCRNo_Display As Label  = FVerpDCRDetail.FindControl("F_DCRNo_Display")
    oF_DCRNo_Display.Text = String.Empty
    If Not Session("F_DCRNo_Display") Is Nothing Then
      If Session("F_DCRNo_Display") <> String.Empty Then
        oF_DCRNo_Display.Text = Session("F_DCRNo_Display")
      End If
    End If
    Dim oF_DCRNo As TextBox  = FVerpDCRDetail.FindControl("F_DCRNo")
    oF_DCRNo.Enabled = True
    oF_DCRNo.Text = String.Empty
    If Not Session("F_DCRNo") Is Nothing Then
      If Session("F_DCRNo") <> String.Empty Then
        oF_DCRNo.Text = Session("F_DCRNo")
      End If
    End If
		Dim mStr As String = ""
		Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/ERP_Main/App_Create") & "/AF_erpDCRDetail.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scripterpDCRDetail") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scripterpDCRDetail", mStr)
    End If
    If Request.QueryString("DCRNo") IsNot Nothing Then
      CType(FVerpDCRDetail.FindControl("F_DCRNo"), TextBox).Text = Request.QueryString("DCRNo")
      CType(FVerpDCRDetail.FindControl("F_DCRNo"), TextBox).Enabled = False
    End If
    If Request.QueryString("DocumentID") IsNot Nothing Then
      CType(FVerpDCRDetail.FindControl("F_DocumentID"), TextBox).Text = Request.QueryString("DocumentID")
      CType(FVerpDCRDetail.FindControl("F_DocumentID"), TextBox).Enabled = False
    End If
    If Request.QueryString("RevisionNo") IsNot Nothing Then
      CType(FVerpDCRDetail.FindControl("F_RevisionNo"), TextBox).Text = Request.QueryString("RevisionNo")
      CType(FVerpDCRDetail.FindControl("F_RevisionNo"), TextBox).Enabled = False
    End If
  End Sub
	<System.Web.Services.WebMethod()> _
	<System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function DCRNoCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.ERP.erpDCRHeader.SelecterpDCRHeaderAutoCompleteList(prefixText, count, contextKey)
  End Function
	<System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_ERP_DCRDetail_DCRNo(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
		Dim DCRNo As String = CType(aVal(1),String)
		Dim oVar As SIS.ERP.erpDCRHeader = SIS.ERP.erpDCRHeader.erpDCRHeaderGetByID(DCRNo)
    If oVar Is Nothing Then
			mRet = "1|" & aVal(0) & "|Record not found." 
    Else
			mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function

End Class
