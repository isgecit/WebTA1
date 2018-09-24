Imports System.Web.Script.Serialization
Partial Class GF_ediWTmtlH
  Inherits SIS.SYS.GridBase
  Private _InfoUrl As String = "~/EDI_Main/App_Display/DF_ediWTmtlH.aspx"
  Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _InfoUrl  & "?t_tran=" & aVal(0)
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub GVediWTmtlH_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVediWTmtlH.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim t_tran As String = GVediWTmtlH.DataKeys(e.CommandArgument).Values("t_tran")  
        Dim RedirectUrl As String = TBLediWTmtlH.EditUrl & "?t_tran=" & t_tran
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
      End Try
    End If
  End Sub
  Protected Sub GVediWTmtlH_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVediWTmtlH.Init
    DataClassName = "GediWTmtlH"
    SetGridView = GVediWTmtlH
  End Sub
  Protected Sub TBLediWTmtlH_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLediWTmtlH.Init
    SetToolBar = TBLediWTmtlH
  End Sub
  Protected Sub F_t_tran_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_t_tran.TextChanged
    Session("F_t_tran") = F_t_tran.Text
    InitGridPage()
  End Sub
  Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
  End Sub
End Class
