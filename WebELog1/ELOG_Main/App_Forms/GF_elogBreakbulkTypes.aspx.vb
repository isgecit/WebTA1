Partial Class GF_elogBreakbulkTypes
  Inherits SIS.SYS.GridBase
  Private _InfoUrl As String = "~/ELOG_Main/App_Display/DF_elogBreakbulkTypes.aspx"
  Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _InfoUrl  & "?BreakbulkTypeID=" & aVal(0)
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub GVelogBreakbulkTypes_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVelogBreakbulkTypes.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim BreakbulkTypeID As Int32 = GVelogBreakbulkTypes.DataKeys(e.CommandArgument).Values("BreakbulkTypeID")  
        Dim RedirectUrl As String = TBLelogBreakbulkTypes.EditUrl & "?BreakbulkTypeID=" & BreakbulkTypeID
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
      End Try
    End If
  End Sub
  Protected Sub GVelogBreakbulkTypes_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVelogBreakbulkTypes.Init
    DataClassName = "GelogBreakbulkTypes"
    SetGridView = GVelogBreakbulkTypes
  End Sub
  Protected Sub TBLelogBreakbulkTypes_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLelogBreakbulkTypes.Init
    SetToolBar = TBLelogBreakbulkTypes
  End Sub
  Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
  End Sub
End Class
