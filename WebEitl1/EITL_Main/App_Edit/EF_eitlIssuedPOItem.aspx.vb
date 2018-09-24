Partial Class EF_eitlIssuedPOItem
  Inherits SIS.SYS.UpdateBase
  Protected Sub FVeitlIssuedPOItem_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVeitlIssuedPOItem.Init
    DataClassName = "EeitlIssuedPOItem"
    SetFormView = FVeitlIssuedPOItem
  End Sub
  Protected Sub TBLeitlIssuedPOItem_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLeitlIssuedPOItem.Init
    SetToolBar = TBLeitlIssuedPOItem
  End Sub
  Protected Sub FVeitlIssuedPOItem_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVeitlIssuedPOItem.PreRender
		Dim mStr As String = ""
		Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/EITL_Main/App_Edit") & "/EF_eitlIssuedPOItem.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scripteitlIssuedPOItem") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scripteitlIssuedPOItem", mStr)
    End If
  End Sub
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
