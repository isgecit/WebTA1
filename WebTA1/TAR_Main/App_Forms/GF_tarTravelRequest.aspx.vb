Imports System.Web.Script.Serialization
Partial Class GF_tarTravelRequest
  Inherits SIS.SYS.GridBase
  Private _InfoUrl As String = "~/TAR_Main/App_Display/DF_tarTravelRequest.aspx"
  Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _InfoUrl  & "?RequestID=" & aVal(0)
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub GVtarTravelRequest_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVtarTravelRequest.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim RequestID As Int32 = GVtarTravelRequest.DataKeys(e.CommandArgument).Values("RequestID")  
        Dim RedirectUrl As String = TBLtarTravelRequest.EditUrl & "?RequestID=" & RequestID
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
      End Try
    End If
    If e.CommandName.ToLower = "initiatewf".ToLower Then
      Try
        Dim RequestID As Int32 = GVtarTravelRequest.DataKeys(e.CommandArgument).Values("RequestID")  
        SIS.TAR.tarTravelRequest.InitiateWF(RequestID)
        GVtarTravelRequest.DataBind()
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
      End Try
    End If
    If e.CommandName.ToLower = "budgetwf".ToLower Then
      Try
        Dim RequestID As Int32 = GVtarTravelRequest.DataKeys(e.CommandArgument).Values("RequestID")
        Dim tmpStr As String = SIS.TAR.tarTravelRequest.SanctionAvailableHTML(RequestID)
        Dim str As String = New JavaScriptSerializer().Serialize(tmpStr)
        Dim script As String = String.Format("show_message({0});", str)
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", script, True)
      Catch ex As Exception
        Dim str As String = New JavaScriptSerializer().Serialize(ex.Message)
        Dim script As String = String.Format("alert({0});", str)
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", script, True)
      End Try
    End If
    If e.CommandName.ToLower = "approvewf".ToLower Then
      Try
        Dim RequestID As Int32 = GVtarTravelRequest.DataKeys(e.CommandArgument).Values("RequestID")
        SIS.TAR.tarTravelRequest.ApproveWF(RequestID)
        GVtarTravelRequest.DataBind()
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
      End Try
    End If
  End Sub
  Protected Sub GVtarTravelRequest_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVtarTravelRequest.Init
    DataClassName = "GtarTravelRequest"
    SetGridView = GVtarTravelRequest
  End Sub
  Protected Sub TBLtarTravelRequest_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLtarTravelRequest.Init
    SetToolBar = TBLtarTravelRequest
  End Sub
  Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
  End Sub
End Class
