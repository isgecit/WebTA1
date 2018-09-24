Partial Class AF_pakUnitSets
  Inherits SIS.SYS.InsertBase
  Protected Sub FVpakUnitSets_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpakUnitSets.Init
    DataClassName = "ApakUnitSets"
    SetFormView = FVpakUnitSets
  End Sub
  Protected Sub TBLpakUnitSets_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLpakUnitSets.Init
    SetToolBar = TBLpakUnitSets
  End Sub
  Protected Sub FVpakUnitSets_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpakUnitSets.DataBound
    SIS.PAK.pakUnitSets.SetDefaultValues(sender, e) 
  End Sub
  Protected Sub FVpakUnitSets_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpakUnitSets.PreRender
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/PAK_Main/App_Create") & "/AF_pakUnitSets.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptpakUnitSets") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptpakUnitSets", mStr)
    End If
    If Request.QueryString("UnitSetID") IsNot Nothing Then
      CType(FVpakUnitSets.FindControl("F_UnitSetID"), TextBox).Text = Request.QueryString("UnitSetID")
      CType(FVpakUnitSets.FindControl("F_UnitSetID"), TextBox).Enabled = False
    End If
  End Sub

End Class
