Partial Class AF_nprkLedgerEntry
  Inherits SIS.SYS.InsertBase
  Protected Sub FVnprkLedgerEntry_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVnprkLedgerEntry.Init
    DataClassName = "AnprkLedgerEntry"
    SetFormView = FVnprkLedgerEntry
  End Sub
  Protected Sub TBLnprkLedgerEntry_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLnprkLedgerEntry.Init
    SetToolBar = TBLnprkLedgerEntry
  End Sub
  Protected Sub FVnprkLedgerEntry_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVnprkLedgerEntry.DataBound
    SIS.NPRK.nprkLedgerEntry.SetDefaultValues(sender, e) 
  End Sub
  Protected Sub FVnprkLedgerEntry_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVnprkLedgerEntry.PreRender
    Dim oF_EmployeeID_Display As Label  = FVnprkLedgerEntry.FindControl("F_EmployeeID_Display")
    oF_EmployeeID_Display.Text = String.Empty
    If Not Session("F_EmployeeID_Display") Is Nothing Then
      If Session("F_EmployeeID_Display") <> String.Empty Then
        oF_EmployeeID_Display.Text = Session("F_EmployeeID_Display")
      End If
    End If
    Dim oF_EmployeeID As TextBox  = FVnprkLedgerEntry.FindControl("F_EmployeeID")
    oF_EmployeeID.Enabled = True
    oF_EmployeeID.Text = String.Empty
    If Not Session("F_EmployeeID") Is Nothing Then
      If Session("F_EmployeeID") <> String.Empty Then
        oF_EmployeeID.Text = Session("F_EmployeeID")
      End If
    End If
    Dim oF_PerkID As LC_nprkPerks = FVnprkLedgerEntry.FindControl("F_PerkID")
    oF_PerkID.Enabled = True
    oF_PerkID.SelectedValue = String.Empty
    If Not Session("F_PerkID") Is Nothing Then
      If Session("F_PerkID") <> String.Empty Then
        oF_PerkID.SelectedValue = Session("F_PerkID")
      End If
    End If

    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/NPRK_Main/App_Create") & "/AF_nprkLedgerEntry.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptnprkLedgerEntry") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptnprkLedgerEntry", mStr)
    End If
    mStr = "<script type=""text/javascript"" language=""javascript"">"
    mStr &= "function enableCheckTransfer(x){"
    mStr &= "var o=document.getElementById('" & FVnprkLedgerEntry.FindControl("F_TranType").ClientID & "');"
    mStr &= "var p=document.getElementById('" & FVnprkLedgerEntry.FindControl("F_PostedInBaaN").ClientID & "');"
    mStr &= "var q=document.getElementById('" & CType(FVnprkLedgerEntry.FindControl("F_TargetPerkID"), LC_nprkPerks).LCClientID & "');"
    mStr &= "p.checked=false;"
    mStr &= "p.disabled=true;"
    mStr &= "q.disabled=true;"
    mStr &= "if(o.options[o.selectedIndex].value=='ADJ')"
    mStr &= " p.disabled=false;"
    mStr &= "}"
    mStr &= "</script>"
    If Not Page.ClientScript.IsClientScriptBlockRegistered("enableCheckTransfer") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "enableCheckTransfer", mStr)
    End If
    'Second Script
    mStr = "<script type=""text/javascript"" language=""javascript"">"
    mStr &= "function checkTransfer(){"
    mStr &= "var p=document.getElementById('" & FVnprkLedgerEntry.FindControl("F_PostedInBaaN").ClientID & "');"
    mStr &= "var o=document.getElementById('" & CType(FVnprkLedgerEntry.FindControl("F_TargetPerkID"), LC_nprkPerks).LCClientID & "');"
    mStr &= "o.disabled=true;"
    mStr &= "if(p.checked==true)"
    mStr &= " o.disabled=false;"
    mStr &= "}"
    mStr &= "</script>"
    If Not Page.ClientScript.IsClientScriptBlockRegistered("CheckTransfer") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "CheckTransfer", mStr)
      CType(FVnprkLedgerEntry.FindControl("F_PostedInBaaN"), CheckBox).Attributes.Add("onclick", "checkTransfer();")
    End If

    If Request.QueryString("DocumentID") IsNot Nothing Then
      CType(FVnprkLedgerEntry.FindControl("F_DocumentID"), TextBox).Text = Request.QueryString("DocumentID")
      CType(FVnprkLedgerEntry.FindControl("F_DocumentID"), TextBox).Enabled = False
    End If
  End Sub
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function EmployeeIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.NPRK.nprkEmployees.SelectnprkEmployeesAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_PRK_Ledger_PRK_Employees(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
    Dim EmployeeID As Int32 = CType(aVal(1),Int32)
    Dim oVar As SIS.NPRK.nprkEmployees = SIS.NPRK.nprkEmployees.nprkEmployeesGetByID(EmployeeID)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found." 
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function

End Class
