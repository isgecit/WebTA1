Partial Class AF_nprkFinYears
  Inherits SIS.SYS.InsertBase
  Protected Sub FVnprkFinYears_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVnprkFinYears.Init
    DataClassName = "AnprkFinYears"
    SetFormView = FVnprkFinYears
  End Sub
  Protected Sub TBLnprkFinYears_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLnprkFinYears.Init
    SetToolBar = TBLnprkFinYears
  End Sub
  Protected Sub FVnprkFinYears_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVnprkFinYears.DataBound
    SIS.NPRK.nprkFinYears.SetDefaultValues(sender, e) 
  End Sub
  Protected Sub FVnprkFinYears_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVnprkFinYears.PreRender
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/NPRK_Main/App_Create") & "/AF_nprkFinYears.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptnprkFinYears") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptnprkFinYears", mStr)
    End If
    If Request.QueryString("FinYear") IsNot Nothing Then
      CType(FVnprkFinYears.FindControl("F_FinYear"), TextBox).Text = Request.QueryString("FinYear")
      CType(FVnprkFinYears.FindControl("F_FinYear"), TextBox).Enabled = False
    End If
  End Sub

End Class
