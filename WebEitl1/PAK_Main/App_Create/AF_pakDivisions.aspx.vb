Partial Class AF_pakDivisions
  Inherits SIS.SYS.InsertBase
  Protected Sub FVpakDivisions_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpakDivisions.Init
    DataClassName = "ApakDivisions"
    SetFormView = FVpakDivisions
  End Sub
  Protected Sub TBLpakDivisions_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLpakDivisions.Init
    SetToolBar = TBLpakDivisions
  End Sub
  Protected Sub FVpakDivisions_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpakDivisions.DataBound
    SIS.PAK.pakDivisions.SetDefaultValues(sender, e) 
  End Sub
  Protected Sub FVpakDivisions_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpakDivisions.PreRender
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/PAK_Main/App_Create") & "/AF_pakDivisions.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptpakDivisions") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptpakDivisions", mStr)
    End If
    If Request.QueryString("DivisionID") IsNot Nothing Then
      CType(FVpakDivisions.FindControl("F_DivisionID"), TextBox).Text = Request.QueryString("DivisionID")
      CType(FVpakDivisions.FindControl("F_DivisionID"), TextBox).Enabled = False
    End If
  End Sub

End Class
