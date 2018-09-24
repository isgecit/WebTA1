Partial Class AF_eitlPODocumentFile
  Inherits SIS.SYS.InsertBase
  Protected Sub FVeitlPODocumentFile_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVeitlPODocumentFile.Init
    DataClassName = "AeitlPODocumentFile"
    SetFormView = FVeitlPODocumentFile
  End Sub
  Protected Sub TBLeitlPODocumentFile_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLeitlPODocumentFile.Init
    SetToolBar = TBLeitlPODocumentFile
  End Sub
  Protected Sub FVeitlPODocumentFile_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVeitlPODocumentFile.PreRender
    Dim oF_SerialNo_Display As Label  = FVeitlPODocumentFile.FindControl("F_SerialNo_Display")
    oF_SerialNo_Display.Text = String.Empty
    If Not Session("F_SerialNo_Display") Is Nothing Then
      If Session("F_SerialNo_Display") <> String.Empty Then
        oF_SerialNo_Display.Text = Session("F_SerialNo_Display")
      End If
    End If
    Dim oF_SerialNo As TextBox  = FVeitlPODocumentFile.FindControl("F_SerialNo")
    oF_SerialNo.Enabled = True
    oF_SerialNo.Text = String.Empty
    If Not Session("F_SerialNo") Is Nothing Then
      If Session("F_SerialNo") <> String.Empty Then
        oF_SerialNo.Text = Session("F_SerialNo")
      End If
    End If
    Dim oF_DocumentLineNo_Display As Label  = FVeitlPODocumentFile.FindControl("F_DocumentLineNo_Display")
    oF_DocumentLineNo_Display.Text = String.Empty
    If Not Session("F_DocumentLineNo_Display") Is Nothing Then
      If Session("F_DocumentLineNo_Display") <> String.Empty Then
        oF_DocumentLineNo_Display.Text = Session("F_DocumentLineNo_Display")
      End If
    End If
    Dim oF_DocumentLineNo As TextBox  = FVeitlPODocumentFile.FindControl("F_DocumentLineNo")
    oF_DocumentLineNo.Enabled = True
    oF_DocumentLineNo.Text = String.Empty
    If Not Session("F_DocumentLineNo") Is Nothing Then
      If Session("F_DocumentLineNo") <> String.Empty Then
        oF_DocumentLineNo.Text = Session("F_DocumentLineNo")
      End If
    End If
		Dim mStr As String = ""
		Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/EITL_Main/App_Create") & "/AF_eitlPODocumentFile.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scripteitlPODocumentFile") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scripteitlPODocumentFile", mStr)
    End If
    If Request.QueryString("SerialNo") IsNot Nothing Then
      CType(FVeitlPODocumentFile.FindControl("F_SerialNo"), TextBox).Text = Request.QueryString("SerialNo")
      CType(FVeitlPODocumentFile.FindControl("F_SerialNo"), TextBox).Enabled = False
    End If
    If Request.QueryString("DocumentLineNo") IsNot Nothing Then
      CType(FVeitlPODocumentFile.FindControl("F_DocumentLineNo"), TextBox).Text = Request.QueryString("DocumentLineNo")
      CType(FVeitlPODocumentFile.FindControl("F_DocumentLineNo"), TextBox).Enabled = False
    End If
    If Request.QueryString("FileNo") IsNot Nothing Then
      CType(FVeitlPODocumentFile.FindControl("F_FileNo"), TextBox).Text = Request.QueryString("FileNo")
      CType(FVeitlPODocumentFile.FindControl("F_FileNo"), TextBox).Enabled = False
    End If
  End Sub
	<System.Web.Services.WebMethod()> _
	<System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function SerialNoCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.EITL.eitlPOList.SelecteitlPOListAutoCompleteList(prefixText, count, contextKey)
  End Function
	<System.Web.Services.WebMethod()> _
	<System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function DocumentLineNoCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.EITL.eitlPODocumentList.SelecteitlPODocumentListAutoCompleteList(prefixText, count, contextKey)
  End Function
	<System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_EITL_PODocumentFile_DocumentLine(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
		Dim SerialNo As Int32 = CType(aVal(1),Int32)
		Dim DocumentLineNo As Int32 = CType(aVal(2),Int32)
		Dim oVar As SIS.EITL.eitlPODocumentList = SIS.EITL.eitlPODocumentList.eitlPODocumentListGetByID(SerialNo,DocumentLineNo)
    If oVar Is Nothing Then
			mRet = "1|" & aVal(0) & "|Record not found." 
    Else
			mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function
	<System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_EITL_PODocumentFile_SerialNo(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
		Dim SerialNo As Int32 = CType(aVal(1),Int32)
		Dim oVar As SIS.EITL.eitlPOList = SIS.EITL.eitlPOList.eitlPOListGetByID(SerialNo)
    If oVar Is Nothing Then
			mRet = "1|" & aVal(0) & "|Record not found." 
    Else
			mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function

End Class
