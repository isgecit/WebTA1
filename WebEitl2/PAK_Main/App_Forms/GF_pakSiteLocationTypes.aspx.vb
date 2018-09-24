Imports System.Web.Script.Serialization
Partial Class GF_pakSiteLocationTypes
  Inherits SIS.SYS.GridBase
  Private _InfoUrl As String = "~/PAK_Main/App_Display/DF_pakSiteLocationTypes.aspx"
  Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _InfoUrl  & "?LocationTypeID=" & aVal(0)
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub GVpakSiteLocationTypes_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVpakSiteLocationTypes.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim LocationTypeID As Int32 = GVpakSiteLocationTypes.DataKeys(e.CommandArgument).Values("LocationTypeID")  
        Dim RedirectUrl As String = TBLpakSiteLocationTypes.EditUrl & "?LocationTypeID=" & LocationTypeID
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
      End Try
    End If
  End Sub
  Protected Sub GVpakSiteLocationTypes_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVpakSiteLocationTypes.Init
    DataClassName = "GpakSiteLocationTypes"
    SetGridView = GVpakSiteLocationTypes
  End Sub
  Protected Sub TBLpakSiteLocationTypes_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLpakSiteLocationTypes.Init
    SetToolBar = TBLpakSiteLocationTypes
  End Sub
  Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
  End Sub
End Class
