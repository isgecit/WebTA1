Imports System.Web.Script.Serialization
Partial Class GF_wfdbNotes
  Inherits SIS.SYS.GridBase
  Private _InfoUrl As String = "~/WFDB_Main/App_Display/DF_wfdbNotes.aspx"
  Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _InfoUrl  & "?IndexValue=" & aVal(0) & "&NotesId=" & aVal(1)
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub GVwfdbNotes_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVwfdbNotes.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim IndexValue As String = GVwfdbNotes.DataKeys(e.CommandArgument).Values("IndexValue")  
        Dim NotesId As String = GVwfdbNotes.DataKeys(e.CommandArgument).Values("NotesId")  
        Dim RedirectUrl As String = TBLwfdbNotes.EditUrl & "?IndexValue=" & IndexValue & "&NotesId=" & NotesId
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
      End Try
    End If
  End Sub
  Protected Sub GVwfdbNotes_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVwfdbNotes.Init
    DataClassName = "GwfdbNotes"
    SetGridView = GVwfdbNotes
  End Sub
  Protected Sub TBLwfdbNotes_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLwfdbNotes.Init
    SetToolBar = TBLwfdbNotes
  End Sub
  Protected Sub F_IndexValue_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_IndexValue.TextChanged
    Session("F_IndexValue") = F_IndexValue.Text
    InitGridPage()
  End Sub
  Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
  End Sub
End Class
