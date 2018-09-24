Partial Class AF_nprkApplications
  Inherits SIS.SYS.InsertBase
  Protected Sub FVnprkApplications_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVnprkApplications.Init
    DataClassName = "AnprkApplications"
    SetFormView = FVnprkApplications
  End Sub
  Protected Sub TBLnprkApplications_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLnprkApplications.Init
    SetToolBar = TBLnprkApplications
  End Sub
  Protected Sub ODSnprkApplications_Inserted(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODSnprkApplications.Inserted
    If e.Exception Is Nothing Then
      Dim oDC As SIS.NPRK.nprkApplications = CType(e.ReturnValue, SIS.NPRK.nprkApplications)
      Dim tmpURL As String = "?tmp=1"
      tmpURL &= "&ApplicationID=" & oDC.ApplicationID
      tmpURL &= "&ClaimID=" & oDC.ClaimID
      TBLnprkApplications.AfterInsertURL &= tmpURL
    End If
  End Sub
  Protected Sub FVnprkApplications_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVnprkApplications.DataBound
    SIS.NPRK.nprkApplications.SetDefaultValues(sender, e) 
  End Sub
  Protected Sub FVnprkApplications_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVnprkApplications.PreRender
    Dim oF_ClaimID_Display As Label  = FVnprkApplications.FindControl("F_ClaimID_Display")
    oF_ClaimID_Display.Text = String.Empty
    If Not Session("F_ClaimID_Display") Is Nothing Then
      If Session("F_ClaimID_Display") <> String.Empty Then
        oF_ClaimID_Display.Text = Session("F_ClaimID_Display")
      End If
    End If
    Dim oF_ClaimID As TextBox  = FVnprkApplications.FindControl("F_ClaimID")
    oF_ClaimID.Enabled = True
    oF_ClaimID.Text = String.Empty
    If Not Session("F_ClaimID") Is Nothing Then
      If Session("F_ClaimID") <> String.Empty Then
        oF_ClaimID.Text = Session("F_ClaimID")
      End If
    End If
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/NPRK_Main/App_Create") & "/AF_nprkApplications.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptnprkApplications") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptnprkApplications", mStr)
    End If
    If Request.QueryString("ApplicationID") IsNot Nothing Then
      CType(FVnprkApplications.FindControl("F_ApplicationID"), TextBox).Text = Request.QueryString("ApplicationID")
      CType(FVnprkApplications.FindControl("F_ApplicationID"), TextBox).Enabled = False
    End If
    If Request.QueryString("ClaimID") IsNot Nothing Then
      CType(FVnprkApplications.FindControl("F_ClaimID"), TextBox).Text = Request.QueryString("ClaimID")
      CType(FVnprkApplications.FindControl("F_ClaimID"), TextBox).Enabled = False
      CType(FVnprkApplications.FindControl("F_ClaimRefNo"), TextBox).Text = SIS.NPRK.nprkUserClaims.nprkUserClaimsGetByID(Request.QueryString("ClaimID")).ClaimRefNo
      CType(FVnprkApplications.FindControl("F_ClaimRefNo"), TextBox).Enabled = False
    End If
  End Sub
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function ClaimIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.NPRK.nprkUserClaims.SelectnprkUserClaimsAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_PRK_Applications_ClaimID(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
    Dim ClaimID As Int32 = CType(aVal(1),Int32)
    Dim oVar As SIS.NPRK.nprkUserClaims = SIS.NPRK.nprkUserClaims.nprkUserClaimsGetByID(ClaimID)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found." 
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function
  Protected Sub ShowBalance(ByVal sender As Object, ByVal e As System.EventArgs)
    Dim Bal As LC_PrkBalanceAsOn = FVnprkApplications.FindControl("LC_PrkBalance1")
    Dim Prk As LC_nprkPerksClaimable = FVnprkApplications.FindControl("F_PerkID")
    Dim Err As Label = FVnprkApplications.FindControl("L_ErrorMsg")
    Dim Crn As Label = FVnprkApplications.FindControl("L_crn")
    Err.Visible = False
    Crn.Visible = False
    TBLnprkApplications.EnableSave = True
    Dim Amt As Decimal = 0
    If Prk.SelectedValue <> String.Empty Then
      Bal.Visible = True
      Dim Applied As Integer = SIS.NPRK.nprkApplications.CanApply(HttpContext.Current.Session("LoginID"), Prk.SelectedValue, 0)
      If Applied = 0 Then
        With Bal
          .PerkID = Prk.SelectedValue
          .EmployeeID = HttpContext.Current.Session("LoginID")
          Amt = .LoadData()
          If .LedgerCount <= 0 And .EntitlementsCount <= 0 Then
            .Visible = False
          End If
        End With
        Select Case Convert.ToInt32(Prk.SelectedValue)
          Case prkPerk.Mobile, prkPerk.Telephone
          Case Else
            If Amt <= 0 Then
              TBLnprkApplications.EnableSave = False
            End If
        End Select
        'Bal.Visible = False
      Else
        'Already Applied
        TBLnprkApplications.EnableSave = False
        Err.Visible = True
        Crn.Visible = True
        Dim oApl As SIS.NPRK.nprkApplications = SIS.NPRK.nprkApplications.UZ_nprkApplicationsGetByID(Applied)
        Crn.Text = "Claim Ref.No: " & oApl.ClaimRefNo & ", Claimed Amount: " & oApl.Value & ", Status: " & oApl.FK_PRK_Applications_ClaimID.PRK_ClaimStatus4_Description
      End If
    Else
      Bal.Visible = False
    End If
    Dim lbl As Label = FVnprkApplications.FindControl("L_Balance")
    lbl.Text = Math.Round(Amt, 2)
  End Sub

End Class
