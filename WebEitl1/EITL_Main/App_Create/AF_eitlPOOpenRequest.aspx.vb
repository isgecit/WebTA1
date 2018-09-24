Partial Class AF_eitlPOOpenRequest
  Inherits SIS.SYS.InsertBase
  Protected Sub FVeitlPOOpenRequest_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVeitlPOOpenRequest.Init
    DataClassName = "AeitlPOOpenRequest"
    SetFormView = FVeitlPOOpenRequest
  End Sub
  Protected Sub TBLeitlPOOpenRequest_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLeitlPOOpenRequest.Init
    SetToolBar = TBLeitlPOOpenRequest
  End Sub
  Protected Sub FVeitlPOOpenRequest_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVeitlPOOpenRequest.PreRender
    Dim oF_SerialNo_Display As Label  = FVeitlPOOpenRequest.FindControl("F_SerialNo_Display")
    oF_SerialNo_Display.Text = String.Empty
    If Not Session("F_SerialNo_Display") Is Nothing Then
      If Session("F_SerialNo_Display") <> String.Empty Then
        oF_SerialNo_Display.Text = Session("F_SerialNo_Display")
      End If
    End If
    Dim oF_SerialNo As TextBox  = FVeitlPOOpenRequest.FindControl("F_SerialNo")
    oF_SerialNo.Enabled = True
    oF_SerialNo.Text = String.Empty
    If Not Session("F_SerialNo") Is Nothing Then
      If Session("F_SerialNo") <> String.Empty Then
        oF_SerialNo.Text = Session("F_SerialNo")
      End If
    End If
    Dim oF_SupplierID_Display As Label  = FVeitlPOOpenRequest.FindControl("F_SupplierID_Display")
    oF_SupplierID_Display.Text = String.Empty
    If Not Session("F_SupplierID_Display") Is Nothing Then
      If Session("F_SupplierID_Display") <> String.Empty Then
        oF_SupplierID_Display.Text = Session("F_SupplierID_Display")
      End If
    End If
    Dim oF_SupplierID As TextBox  = FVeitlPOOpenRequest.FindControl("F_SupplierID")
    oF_SupplierID.Enabled = True
    oF_SupplierID.Text = String.Empty
    If Not Session("F_SupplierID") Is Nothing Then
      If Session("F_SupplierID") <> String.Empty Then
        oF_SupplierID.Text = Session("F_SupplierID")
      End If
    End If
		Dim mStr As String = ""
		Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/EITL_Main/App_Create") & "/AF_eitlPOOpenRequest.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scripteitlPOOpenRequest") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scripteitlPOOpenRequest", mStr)
    End If
    If Request.QueryString("RequestNo") IsNot Nothing Then
      CType(FVeitlPOOpenRequest.FindControl("F_RequestNo"), TextBox).Text = Request.QueryString("RequestNo")
      CType(FVeitlPOOpenRequest.FindControl("F_RequestNo"), TextBox).Enabled = False
    End If
  End Sub
	<System.Web.Services.WebMethod()> _
	<System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function SerialNoCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.EITL.eitlPOList.SelecteitlPOListAutoCompleteList(prefixText, count, contextKey)
  End Function
	<System.Web.Services.WebMethod()> _
	<System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function SupplierIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.EITL.eitlSuppliers.SelecteitlSuppliersAutoCompleteList(prefixText, count, contextKey)
  End Function
	<System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_EITL_POOpenRequest_SerialNo(ByVal value As String) As String
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
	<System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_EITL_POOpenRequest_SupplierID(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
		Dim SupplierID As String = CType(aVal(1),String)
		Dim oVar As SIS.EITL.eitlSuppliers = SIS.EITL.eitlSuppliers.eitlSuppliersGetByID(SupplierID)
    If oVar Is Nothing Then
			mRet = "1|" & aVal(0) & "|Record not found." 
    Else
			mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function

End Class
