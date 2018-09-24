Partial Class AF_psfCreation
  Inherits SIS.SYS.InsertBase
  Protected Sub FVpsfCreation_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpsfCreation.Init
    DataClassName = "ApsfCreation"
    SetFormView = FVpsfCreation
  End Sub
  Protected Sub TBLpsfCreation_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLpsfCreation.Init
    SetToolBar = TBLpsfCreation
  End Sub
  Protected Sub FVpsfCreation_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpsfCreation.DataBound
    SIS.PSF.psfCreation.SetDefaultValues(sender, e) 
  End Sub
  Protected Sub FVpsfCreation_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpsfCreation.PreRender
    Dim oF_SupplierCode_Display As Label  = FVpsfCreation.FindControl("F_SupplierCode_Display")
    oF_SupplierCode_Display.Text = String.Empty
    If Not Session("F_SupplierCode_Display") Is Nothing Then
      If Session("F_SupplierCode_Display") <> String.Empty Then
        oF_SupplierCode_Display.Text = Session("F_SupplierCode_Display")
      End If
    End If
    Dim oF_SupplierCode As TextBox  = FVpsfCreation.FindControl("F_SupplierCode")
    oF_SupplierCode.Enabled = True
    oF_SupplierCode.Text = String.Empty
    If Not Session("F_SupplierCode") Is Nothing Then
      If Session("F_SupplierCode") <> String.Empty Then
        oF_SupplierCode.Text = Session("F_SupplierCode")
      End If
    End If
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/PSF_Main/App_Create") & "/AF_psfCreation.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptpsfCreation") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptpsfCreation", mStr)
    End If
    If Request.QueryString("SerialNo") IsNot Nothing Then
      CType(FVpsfCreation.FindControl("F_SerialNo"), TextBox).Text = Request.QueryString("SerialNo")
      CType(FVpsfCreation.FindControl("F_SerialNo"), TextBox).Enabled = False
    End If
  End Sub
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function SupplierCodeCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.PSF.psfSupplier.SelectpsfSupplierAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_PSF_HSBCMain_SupplierID(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
    Dim SupplierCode As String = CType(aVal(1),String)
    Dim oVar As SIS.PSF.psfSupplier = SIS.PSF.psfSupplier.psfSupplierGetByID(SupplierCode)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found." 
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function
  <System.Web.Services.WebMethod()>
  Public Shared Function getIRData(ByVal value As String) As String
    Return SIS.PSF.psfCreation.getIRData(value)
  End Function
  <System.Web.Services.WebMethod()>
  Public Shared Function getCqData(ByVal value As String) As String
    Return SIS.PSF.psfCreation.getCqData(value)
  End Function
End Class
