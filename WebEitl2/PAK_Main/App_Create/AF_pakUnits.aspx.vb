Partial Class AF_pakUnits
  Inherits SIS.SYS.InsertBase
  Protected Sub FVpakUnits_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpakUnits.Init
    DataClassName = "ApakUnits"
    SetFormView = FVpakUnits
  End Sub
  Protected Sub TBLpakUnits_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLpakUnits.Init
    SetToolBar = TBLpakUnits
  End Sub
  Protected Sub FVpakUnits_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpakUnits.DataBound
    SIS.PAK.pakUnits.SetDefaultValues(sender, e) 
  End Sub
  Protected Sub FVpakUnits_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpakUnits.PreRender
    Dim oF_UnitSetID As LC_pakUnitSets = FVpakUnits.FindControl("F_UnitSetID")
    oF_UnitSetID.Enabled = True
    oF_UnitSetID.SelectedValue = String.Empty
    If Not Session("F_UnitSetID") Is Nothing Then
      If Session("F_UnitSetID") <> String.Empty Then
        oF_UnitSetID.SelectedValue = Session("F_UnitSetID")
      End If
    End If
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/PAK_Main/App_Create") & "/AF_pakUnits.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptpakUnits") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptpakUnits", mStr)
    End If
    If Request.QueryString("UnitID") IsNot Nothing Then
      CType(FVpakUnits.FindControl("F_UnitID"), TextBox).Text = Request.QueryString("UnitID")
      CType(FVpakUnits.FindControl("F_UnitID"), TextBox).Enabled = False
    End If
  End Sub

End Class
