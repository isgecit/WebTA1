Partial Class AF_nprkPerks
  Inherits SIS.SYS.InsertBase
  Protected Sub FVnprkPerks_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVnprkPerks.Init
    DataClassName = "AnprkPerks"
    SetFormView = FVnprkPerks
  End Sub
  Protected Sub TBLnprkPerks_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLnprkPerks.Init
    SetToolBar = TBLnprkPerks
  End Sub
  Protected Sub FVnprkPerks_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVnprkPerks.DataBound
    SIS.NPRK.nprkPerks.SetDefaultValues(sender, e) 
  End Sub
  Protected Sub FVnprkPerks_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVnprkPerks.PreRender
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/NPRK_Main/App_Create") & "/AF_nprkPerks.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptnprkPerks") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptnprkPerks", mStr)
    End If
    If Request.QueryString("PerkID") IsNot Nothing Then
      CType(FVnprkPerks.FindControl("F_PerkID"), TextBox).Text = Request.QueryString("PerkID")
      CType(FVnprkPerks.FindControl("F_PerkID"), TextBox).Enabled = False
    End If
  End Sub

End Class
