Partial Class AF_taBDDriver
  Inherits SIS.SYS.InsertBase
  Protected Sub FVtaBDDriver_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVtaBDDriver.Init
    DataClassName = "AtaBDDriver"
    SetFormView = FVtaBDDriver
  End Sub
  Protected Sub TBLtaBDDriver_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLtaBDDriver.Init
    SetToolBar = TBLtaBDDriver
  End Sub
  Protected Sub FVtaBDDriver_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVtaBDDriver.DataBound
    SIS.TA.taBDDriver.SetDefaultValues(sender, e) 
  End Sub
  Protected Sub FVtaBDDriver_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVtaBDDriver.PreRender
    Dim oF_TABillNo_Display As Label  = FVtaBDDriver.FindControl("F_TABillNo_Display")
    oF_TABillNo_Display.Text = String.Empty
    If Not Session("F_TABillNo_Display") Is Nothing Then
      If Session("F_TABillNo_Display") <> String.Empty Then
        oF_TABillNo_Display.Text = Session("F_TABillNo_Display")
      End If
    End If
    Dim oF_TABillNo As TextBox  = FVtaBDDriver.FindControl("F_TABillNo")
    oF_TABillNo.Enabled = True
    oF_TABillNo.Text = String.Empty
    If Not Session("F_TABillNo") Is Nothing Then
      If Session("F_TABillNo") <> String.Empty Then
        oF_TABillNo.Text = Session("F_TABillNo")
      End If
    End If
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/TA_Main/App_Create") & "/AF_taBDDriver.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scripttaBDDriver") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scripttaBDDriver", mStr)
    End If
    If Request.QueryString("TABillNo") IsNot Nothing Then
      CType(FVtaBDDriver.FindControl("F_TABillNo"), TextBox).Text = Request.QueryString("TABillNo")
      CType(FVtaBDDriver.FindControl("F_TABillNo"), TextBox).Enabled = False
    End If
    If Request.QueryString("SerialNo") IsNot Nothing Then
      CType(FVtaBDDriver.FindControl("F_SerialNo"), TextBox).Text = Request.QueryString("SerialNo")
      CType(FVtaBDDriver.FindControl("F_SerialNo"), TextBox).Enabled = False
    End If
  End Sub
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function TABillNoCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.TA.taBH.SelecttaBHAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_TA_BillDetails_TABillNo(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
    Dim TABillNo As Int32 = CType(aVal(1),Int32)
    Dim oVar As SIS.TA.taBH = SIS.TA.taBH.taBHGetByID(TABillNo)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found."
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function

End Class
