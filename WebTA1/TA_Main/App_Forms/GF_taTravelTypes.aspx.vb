Partial Class GF_taTravelTypes
  Inherits SIS.SYS.GridBase
  Private _InfoUrl As String = "~/TA_Main/App_Display/DF_taTravelTypes.aspx"
  Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _InfoUrl  & "?TravelTypeID=" & aVal(0)
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub GVtaTravelTypes_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVtaTravelTypes.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim TravelTypeID As Int32 = GVtaTravelTypes.DataKeys(e.CommandArgument).Values("TravelTypeID")  
        Dim RedirectUrl As String = TBLtaTravelTypes.EditUrl & "?TravelTypeID=" & TravelTypeID
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
      End Try
    End If
  End Sub
  Protected Sub GVtaTravelTypes_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVtaTravelTypes.Init
    DataClassName = "GtaTravelTypes"
    SetGridView = GVtaTravelTypes
  End Sub
  Protected Sub TBLtaTravelTypes_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLtaTravelTypes.Init
    SetToolBar = TBLtaTravelTypes
  End Sub
  Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
  End Sub
End Class
