Imports System.Web.Script.Serialization
Partial Class GF_ediWTmtlD
  Inherits SIS.SYS.GridBase
  Private _InfoUrl As String = "~/EDI_Main/App_Display/DF_ediWTmtlD.aspx"
  Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _InfoUrl  & "?t_tran=" & aVal(0) & "&t_docn=" & aVal(1) & "&t_revn=" & aVal(2)
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub GVediWTmtlD_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVediWTmtlD.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim t_tran As String = GVediWTmtlD.DataKeys(e.CommandArgument).Values("t_tran")  
        Dim t_docn As String = GVediWTmtlD.DataKeys(e.CommandArgument).Values("t_docn")  
        Dim t_revn As String = GVediWTmtlD.DataKeys(e.CommandArgument).Values("t_revn")  
        Dim RedirectUrl As String = TBLediWTmtlD.EditUrl & "?t_tran=" & t_tran & "&t_docn=" & t_docn & "&t_revn=" & t_revn
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
      End Try
    End If
    If e.CommandName.ToLower = "Downloadwf".ToLower Then
      Try
        Dim t_tran As String = GVediWTmtlD.DataKeys(e.CommandArgument).Values("t_tran")  
        Dim t_docn As String = GVediWTmtlD.DataKeys(e.CommandArgument).Values("t_docn")  
        Dim t_revn As String = GVediWTmtlD.DataKeys(e.CommandArgument).Values("t_revn")  
        SIS.EDI.ediWTmtlD.DownloadWF(t_tran, t_docn, t_revn)
        GVediWTmtlD.DataBind()
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
      End Try
    End If
    If e.CommandName.ToLower = "initiatewf".ToLower Then
      Try
        Dim t_tran As String = GVediWTmtlD.DataKeys(e.CommandArgument).Values("t_tran")  
        Dim t_docn As String = GVediWTmtlD.DataKeys(e.CommandArgument).Values("t_docn")  
        Dim t_revn As String = GVediWTmtlD.DataKeys(e.CommandArgument).Values("t_revn")  
        SIS.EDI.ediWTmtlD.InitiateWF(t_tran, t_docn, t_revn)
        GVediWTmtlD.DataBind()
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
      End Try
    End If
  End Sub
  Protected Sub GVediWTmtlD_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVediWTmtlD.Init
    DataClassName = "GediWTmtlD"
    SetGridView = GVediWTmtlD
  End Sub
  Protected Sub TBLediWTmtlD_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLediWTmtlD.Init
    SetToolBar = TBLediWTmtlD
  End Sub
  Protected Sub F_t_tran_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_t_tran.TextChanged
    Session("F_t_tran") = F_t_tran.Text
    InitGridPage()
  End Sub
  Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
  End Sub
End Class
