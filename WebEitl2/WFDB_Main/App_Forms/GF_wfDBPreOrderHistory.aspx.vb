Imports System.Web.Script.Serialization
Partial Class GF_wfDBPreOrderHistory
  Inherits SIS.SYS.GridBase
  Private _InfoUrl As String = "~/WFDB_Main/App_Display/DF_wfDBPreOrderHistory.aspx"
  Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _InfoUrl  & "?WFID=" & aVal(0)
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub GVwfDBPreOrderHistory_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVwfDBPreOrderHistory.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim WFID As Int32 = GVwfDBPreOrderHistory.DataKeys(e.CommandArgument).Values("WFID")  
        Dim RedirectUrl As String = TBLwfDBPreOrderHistory.EditUrl & "?WFID=" & WFID
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
      End Try
    End If
  End Sub
  Protected Sub GVwfDBPreOrderHistory_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVwfDBPreOrderHistory.Init
    DataClassName = "GwfDBPreOrderHistory"
    SetGridView = GVwfDBPreOrderHistory
  End Sub
  Protected Sub TBLwfDBPreOrderHistory_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLwfDBPreOrderHistory.Init
    SetToolBar = TBLwfDBPreOrderHistory
  End Sub
  Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
  End Sub
End Class
