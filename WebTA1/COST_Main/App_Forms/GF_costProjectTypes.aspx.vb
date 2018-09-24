Partial Class GF_costProjectTypes
  Inherits SIS.SYS.GridBase
  Private _InfoUrl As String = "~/COST_Main/App_Display/DF_costProjectTypes.aspx"
  Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _InfoUrl  & "?ProjectTypeID=" & aVal(0)
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub GVcostProjectTypes_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVcostProjectTypes.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim ProjectTypeID As String = GVcostProjectTypes.DataKeys(e.CommandArgument).Values("ProjectTypeID")  
        Dim RedirectUrl As String = TBLcostProjectTypes.EditUrl & "?ProjectTypeID=" & ProjectTypeID
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
      End Try
    End If
  End Sub
  Protected Sub GVcostProjectTypes_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVcostProjectTypes.Init
    DataClassName = "GcostProjectTypes"
    SetGridView = GVcostProjectTypes
  End Sub
  Protected Sub TBLcostProjectTypes_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLcostProjectTypes.Init
    SetToolBar = TBLcostProjectTypes
  End Sub
  Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
  End Sub
End Class
