Imports System.Web.Script.Serialization
Partial Class GF_wfdbAttachments
  Inherits SIS.SYS.GridBase
  Private _InfoUrl As String = "~/WFDB_Main/App_Display/DF_wfdbAttachments.aspx"
  Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _InfoUrl  & "?t_indx=" & aVal(0) & "&t_dcid=" & aVal(1)
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub GVwfdbAttachments_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVwfdbAttachments.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim t_indx As String = GVwfdbAttachments.DataKeys(e.CommandArgument).Values("t_indx")  
        Dim t_dcid As String = GVwfdbAttachments.DataKeys(e.CommandArgument).Values("t_dcid")  
        Dim RedirectUrl As String = TBLwfdbAttachments.EditUrl & "?t_indx=" & t_indx & "&t_dcid=" & t_dcid
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
      End Try
    End If
  End Sub
  Protected Sub GVwfdbAttachments_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVwfdbAttachments.Init
    DataClassName = "GwfdbAttachments"
    SetGridView = GVwfdbAttachments
  End Sub
  Protected Sub TBLwfdbAttachments_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLwfdbAttachments.Init
    SetToolBar = TBLwfdbAttachments
  End Sub
  Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
  End Sub
End Class
