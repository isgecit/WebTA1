Partial Class AF_taEmployees
  Inherits SIS.SYS.InsertBase
  Protected Sub FVtaEmployees_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVtaEmployees.Init
    DataClassName = "AtaEmployees"
    SetFormView = FVtaEmployees
  End Sub
  Protected Sub TBLtaEmployees_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLtaEmployees.Init
    SetToolBar = TBLtaEmployees
  End Sub
  Protected Sub FVtaEmployees_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVtaEmployees.DataBound
    SIS.TA.taEmployees.SetDefaultValues(sender, e) 
  End Sub
  Protected Sub FVtaEmployees_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVtaEmployees.PreRender
    Dim oF_C_CompanyID As LC_qcmCompanies = FVtaEmployees.FindControl("F_C_CompanyID")
    oF_C_CompanyID.Enabled = True
    oF_C_CompanyID.SelectedValue = String.Empty
    If Not Session("F_C_CompanyID") Is Nothing Then
      If Session("F_C_CompanyID") <> String.Empty Then
        oF_C_CompanyID.SelectedValue = Session("F_C_CompanyID")
      End If
    End If
    Dim oF_C_DivisionID As LC_taDivisions = FVtaEmployees.FindControl("F_C_DivisionID")
    oF_C_DivisionID.Enabled = True
    oF_C_DivisionID.SelectedValue = String.Empty
    If Not Session("F_C_DivisionID") Is Nothing Then
      If Session("F_C_DivisionID") <> String.Empty Then
        oF_C_DivisionID.SelectedValue = Session("F_C_DivisionID")
      End If
    End If
    Dim oF_C_DepartmentID As LC_taDepartments = FVtaEmployees.FindControl("F_C_DepartmentID")
    oF_C_DepartmentID.Enabled = True
    oF_C_DepartmentID.SelectedValue = String.Empty
    If Not Session("F_C_DepartmentID") Is Nothing Then
      If Session("F_C_DepartmentID") <> String.Empty Then
        oF_C_DepartmentID.SelectedValue = Session("F_C_DepartmentID")
      End If
    End If
    Dim oF_C_DesignationID As LC_qcmDesignations = FVtaEmployees.FindControl("F_C_DesignationID")
    oF_C_DesignationID.Enabled = True
    oF_C_DesignationID.SelectedValue = String.Empty
    If Not Session("F_C_DesignationID") Is Nothing Then
      If Session("F_C_DesignationID") <> String.Empty Then
        oF_C_DesignationID.SelectedValue = Session("F_C_DesignationID")
      End If
    End If
    Dim oF_C_OfficeID As LC_qcmOffices = FVtaEmployees.FindControl("F_C_OfficeID")
    oF_C_OfficeID.Enabled = True
    oF_C_OfficeID.SelectedValue = String.Empty
    If Not Session("F_C_OfficeID") Is Nothing Then
      If Session("F_C_OfficeID") <> String.Empty Then
        oF_C_OfficeID.SelectedValue = Session("F_C_OfficeID")
      End If
    End If
    Dim oF_TAVerifier_Display As Label  = FVtaEmployees.FindControl("F_TAVerifier_Display")
    Dim oF_TAVerifier As TextBox  = FVtaEmployees.FindControl("F_TAVerifier")
    Dim oF_TAApprover_Display As Label  = FVtaEmployees.FindControl("F_TAApprover_Display")
    Dim oF_TAApprover As TextBox  = FVtaEmployees.FindControl("F_TAApprover")
    Dim oF_TASanctioningAuthority_Display As Label  = FVtaEmployees.FindControl("F_TASanctioningAuthority_Display")
    Dim oF_TASanctioningAuthority As TextBox  = FVtaEmployees.FindControl("F_TASanctioningAuthority")
    Dim oF_CategoryID As LC_taCategories = FVtaEmployees.FindControl("F_CategoryID")
    oF_CategoryID.Enabled = True
    oF_CategoryID.SelectedValue = String.Empty
    If Not Session("F_CategoryID") Is Nothing Then
      If Session("F_CategoryID") <> String.Empty Then
        oF_CategoryID.SelectedValue = Session("F_CategoryID")
      End If
    End If
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/TA_Main/App_Create") & "/AF_taEmployees.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scripttaEmployees") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scripttaEmployees", mStr)
    End If
    If Request.QueryString("CardNo") IsNot Nothing Then
      CType(FVtaEmployees.FindControl("F_CardNo"), TextBox).Text = Request.QueryString("CardNo")
      CType(FVtaEmployees.FindControl("F_CardNo"), TextBox).Enabled = False
    End If
  End Sub
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function TAVerifierCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.TA.taEmployees.SelecttaEmployeesAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function TAApproverCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.TA.taEmployees.SelecttaEmployeesAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function TASanctioningAuthorityCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.TA.taEmployees.SelecttaEmployeesAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()> _
  Public Shared Function validatePK_taEmployees(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
    Dim CardNo As String = CType(aVal(1),String)
    Dim oVar As SIS.TA.taEmployees = SIS.TA.taEmployees.taEmployeesGetByID(CardNo)
    If Not oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record allready exists." 
    End If
    Return mRet
  End Function
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_HRM_Employees_TAVerifier(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
    Dim TAVerifier As String = CType(aVal(1),String)
    Dim oVar As SIS.TA.taEmployees = SIS.TA.taEmployees.taEmployeesGetByID(TAVerifier)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found." 
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_HRM_Employees_TAApprover(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
    Dim TAApprover As String = CType(aVal(1),String)
    Dim oVar As SIS.TA.taEmployees = SIS.TA.taEmployees.taEmployeesGetByID(TAApprover)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found." 
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_HRM_Employees_TASanctioningAuthority(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
    Dim TASanctioningAuthority As String = CType(aVal(1),String)
    Dim oVar As SIS.TA.taEmployees = SIS.TA.taEmployees.taEmployeesGetByID(TASanctioningAuthority)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found." 
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function

End Class
