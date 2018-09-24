Partial Class GF_taRegionTypes
  Inherits SIS.SYS.GridBase
  Private _InfoUrl As String = "~/TA_Main/App_Display/DF_taRegionTypes.aspx"
  Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _InfoUrl  & "?RegionTypeID=" & aVal(0)
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub GVtaRegionTypes_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVtaRegionTypes.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim RegionTypeID As String = GVtaRegionTypes.DataKeys(e.CommandArgument).Values("RegionTypeID")  
        Dim RedirectUrl As String = TBLtaRegionTypes.EditUrl & "?RegionTypeID=" & RegionTypeID
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
      End Try
    End If
  End Sub
  Protected Sub GVtaRegionTypes_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVtaRegionTypes.Init
    DataClassName = "GtaRegionTypes"
    SetGridView = GVtaRegionTypes
  End Sub
  Protected Sub TBLtaRegionTypes_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLtaRegionTypes.Init
    SetToolBar = TBLtaRegionTypes
  End Sub
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod(UseHttpGet:=True)> _
  Public Shared Function doDownLoad(ByVal value As String) As String
    Return value & " Hello"
  End Function
End Class
