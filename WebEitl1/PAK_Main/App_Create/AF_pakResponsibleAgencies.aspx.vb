Partial Class AF_pakResponsibleAgencies
  Inherits SIS.SYS.InsertBase
  Protected Sub FVpakResponsibleAgencies_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpakResponsibleAgencies.Init
    DataClassName = "ApakResponsibleAgencies"
    SetFormView = FVpakResponsibleAgencies
  End Sub
  Protected Sub TBLpakResponsibleAgencies_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLpakResponsibleAgencies.Init
    SetToolBar = TBLpakResponsibleAgencies
  End Sub
  Protected Sub FVpakResponsibleAgencies_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpakResponsibleAgencies.DataBound
    SIS.PAK.pakResponsibleAgencies.SetDefaultValues(sender, e) 
  End Sub
  Protected Sub FVpakResponsibleAgencies_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpakResponsibleAgencies.PreRender
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/PAK_Main/App_Create") & "/AF_pakResponsibleAgencies.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptpakResponsibleAgencies") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptpakResponsibleAgencies", mStr)
    End If
    If Request.QueryString("ResponsibleAgencyID") IsNot Nothing Then
      CType(FVpakResponsibleAgencies.FindControl("F_ResponsibleAgencyID"), TextBox).Text = Request.QueryString("ResponsibleAgencyID")
      CType(FVpakResponsibleAgencies.FindControl("F_ResponsibleAgencyID"), TextBox).Enabled = False
    End If
  End Sub

End Class
