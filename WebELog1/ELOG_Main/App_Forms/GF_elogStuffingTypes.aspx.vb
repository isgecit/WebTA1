Partial Class GF_elogStuffingTypes
  Inherits SIS.SYS.GridBase
  Private _InfoUrl As String = "~/ELOG_Main/App_Display/DF_elogStuffingTypes.aspx"
  Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _InfoUrl  & "?StuffingTypeID=" & aVal(0)
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub GVelogStuffingTypes_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVelogStuffingTypes.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim StuffingTypeID As Int32 = GVelogStuffingTypes.DataKeys(e.CommandArgument).Values("StuffingTypeID")  
        Dim RedirectUrl As String = TBLelogStuffingTypes.EditUrl & "?StuffingTypeID=" & StuffingTypeID
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
      End Try
    End If
  End Sub
  Protected Sub GVelogStuffingTypes_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVelogStuffingTypes.Init
    DataClassName = "GelogStuffingTypes"
    SetGridView = GVelogStuffingTypes
  End Sub
  Protected Sub TBLelogStuffingTypes_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLelogStuffingTypes.Init
    SetToolBar = TBLelogStuffingTypes
  End Sub
  Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
  End Sub
End Class
