Partial Class EF_eitlPOItemList
  Inherits SIS.SYS.UpdateBase
  Protected Sub FVeitlPOItemList_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVeitlPOItemList.Init
    DataClassName = "EeitlPOItemList"
    SetFormView = FVeitlPOItemList
  End Sub
  Protected Sub TBLeitlPOItemList_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLeitlPOItemList.Init
    SetToolBar = TBLeitlPOItemList
  End Sub
  Protected Sub FVeitlPOItemList_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVeitlPOItemList.PreRender
		TBLeitlPOItemList.PrintUrl &= Request.QueryString("SerialNo") & "|"
		TBLeitlPOItemList.PrintUrl &= Request.QueryString("ItemLineNo") & "|"
		Dim mStr As String = ""
		Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/EITL_Main/App_Edit") & "/EF_eitlPOItemList.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scripteitlPOItemList") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scripteitlPOItemList", mStr)
    End If
  End Sub
	<System.Web.Services.WebMethod()> _
	<System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function DocumentLineNoCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.EITL.eitlPODocumentList.SelecteitlPODocumentListAutoCompleteList(prefixText, count, contextKey)
  End Function
	<System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_EITL_POItemList_DocumentLineNo(ByVal value As String) As String
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

End Class
