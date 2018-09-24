Partial Class GF_elogChargeTypes
  Inherits SIS.SYS.GridBase
  Private _InfoUrl As String = "~/ELOG_Main/App_Display/DF_elogChargeTypes.aspx"
  Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _InfoUrl  & "?ChargeTypeID=" & aVal(0)
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub GVelogChargeTypes_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVelogChargeTypes.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim ChargeTypeID As Int32 = GVelogChargeTypes.DataKeys(e.CommandArgument).Values("ChargeTypeID")  
        Dim RedirectUrl As String = TBLelogChargeTypes.EditUrl & "?ChargeTypeID=" & ChargeTypeID
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
      End Try
    End If
  End Sub
  Protected Sub GVelogChargeTypes_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVelogChargeTypes.Init
    DataClassName = "GelogChargeTypes"
    SetGridView = GVelogChargeTypes
  End Sub
  Protected Sub TBLelogChargeTypes_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLelogChargeTypes.Init
    SetToolBar = TBLelogChargeTypes
  End Sub
  Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
  End Sub
End Class
