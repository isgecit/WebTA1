Imports System.Web.Script.Serialization
Partial Class GF_pakSiteLocations
  Inherits SIS.SYS.GridBase
  Private _InfoUrl As String = "~/PAK_Main/App_Display/DF_pakSiteLocations.aspx"
  Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _InfoUrl  & "?LocationID=" & aVal(0)
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub GVpakSiteLocations_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVpakSiteLocations.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim LocationID As Int32 = GVpakSiteLocations.DataKeys(e.CommandArgument).Values("LocationID")  
        Dim RedirectUrl As String = TBLpakSiteLocations.EditUrl & "?LocationID=" & LocationID
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
      End Try
    End If
  End Sub
  Protected Sub GVpakSiteLocations_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVpakSiteLocations.Init
    DataClassName = "GpakSiteLocations"
    SetGridView = GVpakSiteLocations
  End Sub
  Protected Sub TBLpakSiteLocations_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLpakSiteLocations.Init
    SetToolBar = TBLpakSiteLocations
  End Sub
  Protected Sub F_LocationTypeID_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_LocationTypeID.SelectedIndexChanged
    Session("F_LocationTypeID") = F_LocationTypeID.SelectedValue
    InitGridPage()
  End Sub
  Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
    F_LocationTypeID.SelectedValue = String.Empty
    If Not Session("F_LocationTypeID") Is Nothing Then
      If Session("F_LocationTypeID") <> String.Empty Then
        F_LocationTypeID.SelectedValue = Session("F_LocationTypeID")
      End If
    End If
  End Sub
End Class
