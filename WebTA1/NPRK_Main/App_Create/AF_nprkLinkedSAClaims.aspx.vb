Imports System.Web.Script.Serialization
Partial Class AF_nprkLinkedSAClaims
  Inherits SIS.SYS.InsertBase
  Protected Sub FVnprkLinkedSAClaims_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVnprkLinkedSAClaims.Init
    DataClassName = "AnprkLinkedSAClaims"
    SetFormView = FVnprkLinkedSAClaims
  End Sub
  Protected Sub TBLnprkLinkedSAClaims_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLnprkLinkedSAClaims.Init
    SetToolBar = TBLnprkLinkedSAClaims
  End Sub
  Protected Sub FVnprkLinkedSAClaims_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVnprkLinkedSAClaims.DataBound
    With FVnprkLinkedSAClaims
      CType(.FindControl("F_Entitled1Days"), TextBox).Text = "0.00"
      CType(.FindControl("F_Entitled2Days"), TextBox).Text = "0.00"
      CType(.FindControl("F_Entitled3Days"), TextBox).Text = "0.00"
      CType(.FindControl("F_Entitled1Amount"), TextBox).Text = "0.00"
      CType(.FindControl("F_Entitled2Amount"), TextBox).Text = "0.00"
      CType(.FindControl("F_Entitled3Amount"), TextBox).Text = "0.00"
    End With
  End Sub
  Protected Sub FVnprkLinkedSAClaims_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVnprkLinkedSAClaims.PreRender
    Dim oF_EmployeeID_Display As Label = FVnprkLinkedSAClaims.FindControl("F_EmployeeID_Display")
    Dim oF_EmployeeID As TextBox = FVnprkLinkedSAClaims.FindControl("F_EmployeeID")
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/NPRK_Main/App_Create") & "/AF_nprkLinkedSAClaims.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptnprkLinkedSAClaims") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptnprkLinkedSAClaims", mStr)
    End If
    If Request.QueryString("FinYear") IsNot Nothing Then
      CType(FVnprkLinkedSAClaims.FindControl("F_FinYear"), TextBox).Text = Request.QueryString("FinYear")
      CType(FVnprkLinkedSAClaims.FindControl("F_FinYear"), TextBox).Enabled = False
    End If
    If Request.QueryString("Quarter") IsNot Nothing Then
      CType(FVnprkLinkedSAClaims.FindControl("F_Quarter"), TextBox).Text = Request.QueryString("Quarter")
      CType(FVnprkLinkedSAClaims.FindControl("F_Quarter"), TextBox).Enabled = False
    End If
    If Request.QueryString("AdviceNo") IsNot Nothing Then
      CType(FVnprkLinkedSAClaims.FindControl("F_AdviceNo"), TextBox).Text = Request.QueryString("AdviceNo")
      CType(FVnprkLinkedSAClaims.FindControl("F_AdviceNo"), TextBox).Enabled = False
    End If
  End Sub
  <System.Web.Services.WebMethod()>
  <System.Web.Script.Services.ScriptMethod()>
  Public Shared Function EmployeeIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.TA.taEmployees.SelecttaEmployeesAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()>
  Public Shared Function validate_FK_PRK_SiteAllowanceClaims_EmployeeID(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String = "0|" & aVal(0)
    Dim EmployeeID As String = CType(aVal(1), String)
    Dim oVar As SIS.TA.taEmployees = SIS.TA.taEmployees.taEmployeesGetByID(EmployeeID)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found."
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField
    End If
    Return mRet
  End Function

  Private Sub FVnprkLinkedSAClaims_ItemInserting(sender As Object, e As FormViewInsertEventArgs) Handles FVnprkLinkedSAClaims.ItemInserting
    Dim FinYear As String = e.Values("FinYear").ToString
    Dim Quarter As String = e.Values("Quarter").ToString
    Dim CardNo As String = e.Values("EmployeeID")
    Dim tmp As SIS.NPRK.nprkSiteAllowanceClaims = SIS.NPRK.nprkSiteAllowanceClaims.nprkSiteAllowanceClaimsGetByID(FinYear, Quarter, CardNo)
    If tmp IsNot Nothing Then
      Dim str As String = New JavaScriptSerializer().Serialize("Claim for Fin. Year and Quarter is already created in Advice No.: " & tmp.AdviceNo)
      Dim script As String = String.Format("alert({0});", str)
      ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", script, True)
      e.Cancel = True
      Exit Sub
    Else
      Dim mStr As String = ""
      Dim oEmp As SIS.QCM.qcmEmployees = Nothing
      oEmp = SIS.QCM.qcmEmployees.qcmEmployeesGetByID(CardNo)
      If oEmp.ActiveState = False Then mStr = "Employee is NOT Active, can not create Site Allowance."
      If oEmp.C_OfficeID <> 6 Then mStr = "Employee is NOT defined as Site Employee. Can NOT Claim Site Allowance."
      If oEmp.CategoryID = "" Then mStr = "Employee TA Category not defined, Pl. get it defined first."
      If mStr <> "" Then
        Dim str As String = New JavaScriptSerializer().Serialize(mStr)
        Dim script As String = String.Format("alert({0});", str)
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", script, True)
        e.Cancel = True
        Exit Sub
      End If
    End If
  End Sub
End Class
