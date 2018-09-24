Partial Class GF_eitlUnits
  Inherits SIS.SYS.GridBase
  Private _InfoUrl As String = "~/EITL_Main/App_Display/DF_eitlUnits.aspx"
  Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _InfoUrl  & "?UnitID=" & aVal(0)
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub GVeitlUnits_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVeitlUnits.RowCommand
		If e.CommandName.ToLower = "lgedit".ToLower Then
			Try
				Dim UnitID As String = GVeitlUnits.DataKeys(e.CommandArgument).Values("UnitID")  
				Dim RedirectUrl As String = TBLeitlUnits.EditUrl & "?UnitID=" & UnitID
				Response.Redirect(RedirectUrl)
			Catch ex As Exception
			End Try
		End If
  End Sub
  Protected Sub GVeitlUnits_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVeitlUnits.Init
    DataClassName = "GeitlUnits"
    SetGridView = GVeitlUnits
  End Sub
  Protected Sub TBLeitlUnits_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLeitlUnits.Init
    SetToolBar = TBLeitlUnits
  End Sub
  Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
  End Sub
End Class
