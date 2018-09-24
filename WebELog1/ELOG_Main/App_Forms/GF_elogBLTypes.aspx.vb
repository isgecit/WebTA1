Partial Class GF_elogBLTypes
  Inherits SIS.SYS.GridBase
  Private _InfoUrl As String = "~/ELOG_Main/App_Display/DF_elogBLTypes.aspx"
  Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _InfoUrl  & "?BLTypeID=" & aVal(0)
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub GVelogBLTypes_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVelogBLTypes.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim BLTypeID As Int32 = GVelogBLTypes.DataKeys(e.CommandArgument).Values("BLTypeID")  
        Dim RedirectUrl As String = TBLelogBLTypes.EditUrl & "?BLTypeID=" & BLTypeID
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
      End Try
    End If
  End Sub
  Protected Sub GVelogBLTypes_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVelogBLTypes.Init
    DataClassName = "GelogBLTypes"
    SetGridView = GVelogBLTypes
  End Sub
  Protected Sub TBLelogBLTypes_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLelogBLTypes.Init
    SetToolBar = TBLelogBLTypes
  End Sub
  Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
  End Sub
End Class
