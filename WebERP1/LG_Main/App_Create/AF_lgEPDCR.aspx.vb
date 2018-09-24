Partial Class AF_lgEPDCR
  Inherits SIS.SYS.InsertBase
  Protected Sub FVlgEPDCR_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVlgEPDCR.Init
    DataClassName = "AlgEPDCR"
    SetFormView = FVlgEPDCR
  End Sub
  Protected Sub TBLlgEPDCR_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLlgEPDCR.Init
    SetToolBar = TBLlgEPDCR
  End Sub
  Protected Sub FVlgEPDCR_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVlgEPDCR.PreRender
    Dim oF_DocPK_Display As Label  = FVlgEPDCR.FindControl("F_DocPK_Display")
    oF_DocPK_Display.Text = String.Empty
    If Not Session("F_DocPK_Display") Is Nothing Then
      If Session("F_DocPK_Display") <> String.Empty Then
        oF_DocPK_Display.Text = Session("F_DocPK_Display")
      End If
    End If
    Dim oF_DocPK As TextBox  = FVlgEPDCR.FindControl("F_DocPK")
    oF_DocPK.Enabled = True
    oF_DocPK.Text = String.Empty
    If Not Session("F_DocPK") Is Nothing Then
      If Session("F_DocPK") <> String.Empty Then
        oF_DocPK.Text = Session("F_DocPK")
      End If
    End If
		Dim mStr As String = ""
		Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/LG_Main/App_Create") & "/AF_lgEPDCR.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptlgEPDCR") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptlgEPDCR", mStr)
    End If
    If Request.QueryString("DocPK") IsNot Nothing Then
      CType(FVlgEPDCR.FindControl("F_DocPK"), TextBox).Text = Request.QueryString("DocPK")
      CType(FVlgEPDCR.FindControl("F_DocPK"), TextBox).Enabled = False
    End If
    If Request.QueryString("DCRID") IsNot Nothing Then
      CType(FVlgEPDCR.FindControl("F_DCRID"), TextBox).Text = Request.QueryString("DCRID")
      CType(FVlgEPDCR.FindControl("F_DCRID"), TextBox).Enabled = False
    End If
    If Request.QueryString("DCRLine") IsNot Nothing Then
      CType(FVlgEPDCR.FindControl("F_DCRLine"), TextBox).Text = Request.QueryString("DCRLine")
      CType(FVlgEPDCR.FindControl("F_DCRLine"), TextBox).Enabled = False
    End If
  End Sub
	<System.Web.Services.WebMethod()> _
	<System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function DocPKCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.LG.lgEPDocument.SelectlgEPDocumentAutoCompleteList(prefixText, count, contextKey)
  End Function
	<System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_LG_EPDCR_DocPK(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
		Dim DocPK As Int64 = CType(aVal(1),Int64)
		Dim oVar As SIS.LG.lgEPDocument = SIS.LG.lgEPDocument.lgEPDocumentGetByID(DocPK)
    If oVar Is Nothing Then
			mRet = "1|" & aVal(0) & "|Record not found." 
    Else
			mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function

End Class
