Partial Class GF_psfCreation
  Inherits SIS.SYS.GridBase
  Private _InfoUrl As String = "~/PSF_Main/App_Display/DF_psfCreation.aspx"
  Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _InfoUrl  & "?SerialNo=" & aVal(0)
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub GVpsfCreation_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVpsfCreation.RowCommand
        If e.CommandName.ToLower = "lgcopy".ToLower Then
            Try
                Dim SerialNo As Int32 = GVpsfCreation.DataKeys(e.CommandArgument).Values("SerialNo")
                Dim oPSF As SIS.PSF.psfCreation = SIS.PSF.psfCreation.psfCreationGetByID(SerialNo)
                With oPSF
                    .SerialNo = 0
                    .InvoiceAmount = 0
                    .AmountInWords = ""
                    .TotalAmountDisbursed = 0
                    .InterestAmount = 0
                    .TDSAmount = 0
                    .ServiceTax = 0
                    .CreatedBy = HttpContext.Current.Session("LoginID")
                    .CreatedOn = Now
                    .PSFStatus = 1
                    .ApprovedBy = ""
                    .ApprovedOn = ""
                    .PaymentDateToBank = ""
                    .ChequeNoPaidToBank = ""
                    .HSBCToVendor = ""
                    .HSBCInterestDays = ""
                    .HSBCInterestAmountInStatement = ""
                End With
                oPSF = SIS.PSF.psfCreation.InsertData(oPSF)
                SerialNo = oPSF.SerialNo
                Dim RedirectUrl As String = TBLpsfCreation.EditUrl & "?SerialNo=" & SerialNo
                Response.Redirect(RedirectUrl)
            Catch ex As Exception
            End Try
        End If
        If e.CommandName.ToLower = "lgedit".ToLower Then
            Try
                Dim SerialNo As Int32 = GVpsfCreation.DataKeys(e.CommandArgument).Values("SerialNo")
                Dim RedirectUrl As String = TBLpsfCreation.EditUrl & "?SerialNo=" & SerialNo
                Response.Redirect(RedirectUrl)
            Catch ex As Exception
            End Try
        End If
        If e.CommandName.ToLower = "initiatewf".ToLower Then
            Try
                Dim SerialNo As Int32 = GVpsfCreation.DataKeys(e.CommandArgument).Values("SerialNo")
                SIS.PSF.psfCreation.InitiateWF(SerialNo)
                GVpsfCreation.DataBind()
            Catch ex As Exception
            End Try
        End If
    End Sub
  Protected Sub GVpsfCreation_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVpsfCreation.Init
    DataClassName = "GpsfCreation"
    SetGridView = GVpsfCreation
  End Sub
  Protected Sub TBLpsfCreation_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLpsfCreation.Init
    SetToolBar = TBLpsfCreation
  End Sub
  Protected Sub F_SerialNo_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_SerialNo.TextChanged
    Session("F_SerialNo") = F_SerialNo.Text
    InitGridPage()
  End Sub
  Protected Sub F_SupplierCode_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_SupplierCode.TextChanged
    Session("F_SupplierCode") = F_SupplierCode.Text
    Session("F_SupplierCode_Display") = F_SupplierCode_Display.Text
    InitGridPage()
  End Sub
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function SupplierCodeCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.PSF.psfSupplier.SelectpsfSupplierAutoCompleteList(prefixText, count, contextKey)
  End Function
  Protected Sub F_PSFStatus_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_PSFStatus.SelectedIndexChanged
    Session("F_PSFStatus") = F_PSFStatus.SelectedValue
    InitGridPage()
  End Sub
  Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
    F_SupplierCode_Display.Text = String.Empty
    If Not Session("F_SupplierCode_Display") Is Nothing Then
      If Session("F_SupplierCode_Display") <> String.Empty Then
        F_SupplierCode_Display.Text = Session("F_SupplierCode_Display")
      End If
    End If
    F_SupplierCode.Text = String.Empty
    If Not Session("F_SupplierCode") Is Nothing Then
      If Session("F_SupplierCode") <> String.Empty Then
        F_SupplierCode.Text = Session("F_SupplierCode")
      End If
    End If
    Dim strScriptSupplierCode As String = "<script type=""text/javascript""> " & _
      "function ACESupplierCode_Selected(sender, e) {" & _
      "  var F_SupplierCode = $get('" & F_SupplierCode.ClientID & "');" & _
      "  var F_SupplierCode_Display = $get('" & F_SupplierCode_Display.ClientID & "');" & _
      "  var retval = e.get_value();" & _
      "  var p = retval.split('|');" & _
      "  F_SupplierCode.value = p[0];" & _
      "  F_SupplierCode_Display.innerHTML = e.get_text();" & _
      "}" & _
      "</script>"
      If Not Page.ClientScript.IsClientScriptBlockRegistered("F_SupplierCode") Then
        Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_SupplierCode", strScriptSupplierCode)
      End If
    Dim strScriptPopulatingSupplierCode As String = "<script type=""text/javascript""> " & _
      "function ACESupplierCode_Populating(o,e) {" & _
      "  var p = $get('" & F_SupplierCode.ClientID & "');" & _
      "  p.style.backgroundImage  = 'url(../../images/loader.gif)';" & _
      "  p.style.backgroundRepeat= 'no-repeat';" & _
      "  p.style.backgroundPosition = 'right';" & _
      "  o._contextKey = '';" & _
      "}" & _
      "function ACESupplierCode_Populated(o,e) {" & _
      "  var p = $get('" & F_SupplierCode.ClientID & "');" & _
      "  p.style.backgroundImage  = 'none';" & _
      "}" & _
      "</script>"
      If Not Page.ClientScript.IsClientScriptBlockRegistered("F_SupplierCodePopulating") Then
        Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_SupplierCodePopulating", strScriptPopulatingSupplierCode)
      End If
    F_PSFStatus.SelectedValue = String.Empty
    If Not Session("F_PSFStatus") Is Nothing Then
      If Session("F_PSFStatus") <> String.Empty Then
        F_PSFStatus.SelectedValue = Session("F_PSFStatus")
      End If
    End If
    Dim validateScriptSupplierCode As String = "<script type=""text/javascript"">" & _
      "  function validate_SupplierCode(o) {" & _
      "    validated_FK_PSF_HSBCMain_SupplierID_main = true;" & _
      "    validate_FK_PSF_HSBCMain_SupplierID(o);" & _
      "  }" & _
      "</script>"
    If Not Page.ClientScript.IsClientScriptBlockRegistered("validateSupplierCode") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateSupplierCode", validateScriptSupplierCode)
    End If
    Dim validateScriptPSFStatus As String = "<script type=""text/javascript"">" & _
      "  function validate_PSFStatus(o) {" & _
      "    validated_FK_PSF_HSBCMain_PSFStatusID_main = true;" & _
      "    validate_FK_PSF_HSBCMain_PSFStatusID(o);" & _
      "  }" & _
      "</script>"
    If Not Page.ClientScript.IsClientScriptBlockRegistered("validatePSFStatus") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validatePSFStatus", validateScriptPSFStatus)
    End If
    Dim validateScriptFK_PSF_HSBCMain_PSFStatusID As String = "<script type=""text/javascript"">" & _
      "  function validate_FK_PSF_HSBCMain_PSFStatusID(o) {" & _
      "    var value = o.id;" & _
      "    var PSFStatus = $get('" & F_PSFStatus.ClientID & "');" & _
      "    try{" & _
      "    if(PSFStatus.value==''){" & _
      "      if(validated_FK_PSF_HSBCMain_PSFStatusID.main){" & _
      "        var o_d = $get(o.id +'_Display');" & _
      "        try{o_d.innerHTML = '';}catch(ex){}" & _
      "      }" & _
      "    }" & _
      "    value = value + ',' + PSFStatus.value ;" & _
      "    }catch(ex){}" & _
      "    o.style.backgroundImage  = 'url(../../images/pkloader.gif)';" & _
      "    o.style.backgroundRepeat= 'no-repeat';" & _
      "    o.style.backgroundPosition = 'right';" & _
      "    PageMethods.validate_FK_PSF_HSBCMain_PSFStatusID(value, validated_FK_PSF_HSBCMain_PSFStatusID);" & _
      "  }" & _
      "  validated_FK_PSF_HSBCMain_PSFStatusID_main = false;" & _
      "  function validated_FK_PSF_HSBCMain_PSFStatusID(result) {" & _
      "    var p = result.split('|');" & _
      "    var o = $get(p[1]);" & _
      "    var o_d = $get(p[1]+'_Display');" & _
      "    try{o_d.innerHTML = p[2];}catch(ex){}" & _
      "    o.style.backgroundImage  = 'none';" & _
      "    if(p[0]=='1'){" & _
      "      o.value='';" & _
      "      try{o_d.innerHTML = '';}catch(ex){}" & _
      "      __doPostBack(o.id, o.value);" & _
      "    }" & _
      "    else" & _
      "      __doPostBack(o.id, o.value);" & _
      "  }" & _
      "</script>"
    If Not Page.ClientScript.IsClientScriptBlockRegistered("validateFK_PSF_HSBCMain_PSFStatusID") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateFK_PSF_HSBCMain_PSFStatusID", validateScriptFK_PSF_HSBCMain_PSFStatusID)
    End If
    Dim validateScriptFK_PSF_HSBCMain_SupplierID As String = "<script type=""text/javascript"">" & _
      "  function validate_FK_PSF_HSBCMain_SupplierID(o) {" & _
      "    var value = o.id;" & _
      "    var SupplierCode = $get('" & F_SupplierCode.ClientID & "');" & _
      "    try{" & _
      "    if(SupplierCode.value==''){" & _
      "      if(validated_FK_PSF_HSBCMain_SupplierID.main){" & _
      "        var o_d = $get(o.id +'_Display');" & _
      "        try{o_d.innerHTML = '';}catch(ex){}" & _
      "      }" & _
      "    }" & _
      "    value = value + ',' + SupplierCode.value ;" & _
      "    }catch(ex){}" & _
      "    o.style.backgroundImage  = 'url(../../images/pkloader.gif)';" & _
      "    o.style.backgroundRepeat= 'no-repeat';" & _
      "    o.style.backgroundPosition = 'right';" & _
      "    PageMethods.validate_FK_PSF_HSBCMain_SupplierID(value, validated_FK_PSF_HSBCMain_SupplierID);" & _
      "  }" & _
      "  validated_FK_PSF_HSBCMain_SupplierID_main = false;" & _
      "  function validated_FK_PSF_HSBCMain_SupplierID(result) {" & _
      "    var p = result.split('|');" & _
      "    var o = $get(p[1]);" & _
      "    var o_d = $get(p[1]+'_Display');" & _
      "    try{o_d.innerHTML = p[2];}catch(ex){}" & _
      "    o.style.backgroundImage  = 'none';" & _
      "    if(p[0]=='1'){" & _
      "      o.value='';" & _
      "      try{o_d.innerHTML = '';}catch(ex){}" & _
      "      __doPostBack(o.id, o.value);" & _
      "    }" & _
      "    else" & _
      "      __doPostBack(o.id, o.value);" & _
      "  }" & _
      "</script>"
    If Not Page.ClientScript.IsClientScriptBlockRegistered("validateFK_PSF_HSBCMain_SupplierID") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateFK_PSF_HSBCMain_SupplierID", validateScriptFK_PSF_HSBCMain_SupplierID)
    End If
  End Sub
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_PSF_HSBCMain_PSFStatusID(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
    Dim PSFStatus As Int32 = CType(aVal(1),Int32)
    Dim oVar As SIS.PSF.psfStatus = SIS.PSF.psfStatus.psfStatusGetByID(PSFStatus)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found." 
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
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
End Class
