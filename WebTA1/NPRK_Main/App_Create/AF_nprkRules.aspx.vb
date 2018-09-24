Partial Class AF_nprkRules
  Inherits SIS.SYS.InsertBase
  Protected Sub FVnprkRules_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVnprkRules.Init
    DataClassName = "AnprkRules"
    SetFormView = FVnprkRules
  End Sub
  Protected Sub TBLnprkRules_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLnprkRules.Init
    SetToolBar = TBLnprkRules
  End Sub
  Protected Sub FVnprkRules_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVnprkRules.DataBound
    SIS.NPRK.nprkRules.SetDefaultValues(sender, e) 
  End Sub
  Protected Sub FVnprkRules_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVnprkRules.PreRender
    Dim oF_PerkID As LC_nprkPerks = FVnprkRules.FindControl("F_PerkID")
    oF_PerkID.Enabled = True
    oF_PerkID.SelectedValue = String.Empty
    If Not Session("F_PerkID") Is Nothing Then
      If Session("F_PerkID") <> String.Empty Then
        oF_PerkID.SelectedValue = Session("F_PerkID")
      End If
    End If
    Dim oF_CategoryID As LC_nprkCategories = FVnprkRules.FindControl("F_CategoryID")
    oF_CategoryID.Enabled = True
    oF_CategoryID.SelectedValue = String.Empty
    If Not Session("F_CategoryID") Is Nothing Then
      If Session("F_CategoryID") <> String.Empty Then
        oF_CategoryID.SelectedValue = Session("F_CategoryID")
      End If
    End If
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/NPRK_Main/App_Create") & "/AF_nprkRules.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptnprkRules") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptnprkRules", mStr)
    End If
    If Request.QueryString("RuleID") IsNot Nothing Then
      CType(FVnprkRules.FindControl("F_RuleID"), TextBox).Text = Request.QueryString("RuleID")
      CType(FVnprkRules.FindControl("F_RuleID"), TextBox).Enabled = False
    End If
  End Sub

End Class
