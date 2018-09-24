Partial Class GF_elogChargeCodes
  Inherits SIS.SYS.GridBase
  Private _InfoUrl As String = "~/ELOG_Main/App_Display/DF_elogChargeCodes.aspx"
  Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _InfoUrl  & "?ChargeCategoryID=" & aVal(0) & "&ChargeCodeID=" & aVal(1)
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub GVelogChargeCodes_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVelogChargeCodes.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim ChargeCategoryID As Int32 = GVelogChargeCodes.DataKeys(e.CommandArgument).Values("ChargeCategoryID")  
        Dim ChargeCodeID As Int32 = GVelogChargeCodes.DataKeys(e.CommandArgument).Values("ChargeCodeID")  
        Dim RedirectUrl As String = TBLelogChargeCodes.EditUrl & "?ChargeCategoryID=" & ChargeCategoryID & "&ChargeCodeID=" & ChargeCodeID
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
      End Try
    End If
  End Sub
  Protected Sub GVelogChargeCodes_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVelogChargeCodes.Init
    DataClassName = "GelogChargeCodes"
    SetGridView = GVelogChargeCodes
  End Sub
  Protected Sub TBLelogChargeCodes_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLelogChargeCodes.Init
    SetToolBar = TBLelogChargeCodes
  End Sub
  Protected Sub F_ChargeCategoryID_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_ChargeCategoryID.SelectedIndexChanged
    Session("F_ChargeCategoryID") = F_ChargeCategoryID.SelectedValue
    InitGridPage()
  End Sub
  Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
    F_ChargeCategoryID.SelectedValue = String.Empty
    If Not Session("F_ChargeCategoryID") Is Nothing Then
      If Session("F_ChargeCategoryID") <> String.Empty Then
        F_ChargeCategoryID.SelectedValue = Session("F_ChargeCategoryID")
      End If
    End If
  End Sub
End Class
