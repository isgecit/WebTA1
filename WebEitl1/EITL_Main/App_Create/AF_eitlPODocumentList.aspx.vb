Partial Class AF_eitlPODocumentList
  Inherits SIS.SYS.InsertBase
  Protected Sub FVeitlPODocumentList_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVeitlPODocumentList.Init
    DataClassName = "AeitlPODocumentList"
    SetFormView = FVeitlPODocumentList
  End Sub
  Protected Sub TBLeitlPODocumentList_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLeitlPODocumentList.Init
    SetToolBar = TBLeitlPODocumentList
  End Sub
  Protected Sub ODSeitlPODocumentList_Inserted(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODSeitlPODocumentList.Inserted
		If e.Exception Is Nothing Then
			Dim oDC As SIS.EITL.eitlPODocumentList = CType(e.ReturnValue,SIS.EITL.eitlPODocumentList)
			Dim tmpURL As String = "?tmp=1"
			tmpURL &= "&SerialNo=" & oDC.SerialNo
			tmpURL &= "&DocumentLineNo=" & oDC.DocumentLineNo
			TBLeitlPODocumentList.AfterInsertURL &= tmpURL 
		End If
  End Sub
  Protected Sub FVeitlPODocumentList_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVeitlPODocumentList.PreRender
		Dim mStr As String = ""
		Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/EITL_Main/App_Create") & "/AF_eitlPODocumentList.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scripteitlPODocumentList") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scripteitlPODocumentList", mStr)
    End If
    If Request.QueryString("SerialNo") IsNot Nothing Then
      CType(FVeitlPODocumentList.FindControl("F_SerialNo"), TextBox).Text = Request.QueryString("SerialNo")
      CType(FVeitlPODocumentList.FindControl("F_SerialNo"), TextBox).Enabled = False
    End If
    If Request.QueryString("DocumentLineNo") IsNot Nothing Then
      CType(FVeitlPODocumentList.FindControl("F_DocumentLineNo"), TextBox).Text = Request.QueryString("DocumentLineNo")
      CType(FVeitlPODocumentList.FindControl("F_DocumentLineNo"), TextBox).Enabled = False
    End If
  End Sub

End Class
