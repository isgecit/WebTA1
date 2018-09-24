Partial Class GF_elogCargoTypes
  Inherits SIS.SYS.GridBase
  Private _InfoUrl As String = "~/ELOG_Main/App_Display/DF_elogCargoTypes.aspx"
  Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _InfoUrl  & "?CargoTypeID=" & aVal(0)
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub GVelogCargoTypes_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVelogCargoTypes.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim CargoTypeID As Int32 = GVelogCargoTypes.DataKeys(e.CommandArgument).Values("CargoTypeID")  
        Dim RedirectUrl As String = TBLelogCargoTypes.EditUrl & "?CargoTypeID=" & CargoTypeID
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
      End Try
    End If
  End Sub
  Protected Sub GVelogCargoTypes_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVelogCargoTypes.Init
    DataClassName = "GelogCargoTypes"
    SetGridView = GVelogCargoTypes
  End Sub
  Protected Sub TBLelogCargoTypes_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLelogCargoTypes.Init
    SetToolBar = TBLelogCargoTypes
  End Sub
  Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
  End Sub
End Class
