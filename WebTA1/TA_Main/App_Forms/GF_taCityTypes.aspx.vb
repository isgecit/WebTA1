Partial Class GF_taCityTypes
  Inherits SIS.SYS.GridBase
  Private _InfoUrl As String = "~/TA_Main/App_Display/DF_taCityTypes.aspx"
  Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _InfoUrl  & "?CityTypeID=" & aVal(0)
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub GVtaCityTypes_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVtaCityTypes.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim CityTypeID As String = GVtaCityTypes.DataKeys(e.CommandArgument).Values("CityTypeID")  
        Dim RedirectUrl As String = TBLtaCityTypes.EditUrl & "?CityTypeID=" & CityTypeID
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
      End Try
    End If
  End Sub
  Protected Sub GVtaCityTypes_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVtaCityTypes.Init
    DataClassName = "GtaCityTypes"
    SetGridView = GVtaCityTypes
  End Sub
  Protected Sub TBLtaCityTypes_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLtaCityTypes.Init
    SetToolBar = TBLtaCityTypes
  End Sub
  Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
  End Sub
End Class
