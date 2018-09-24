Partial Class GF_taCalcMethod
  Inherits SIS.SYS.GridBase
  Private _InfoUrl As String = "~/TA_Main/App_Display/DF_taCalcMethod.aspx"
  Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _InfoUrl  & "?CalculationTypeID=" & aVal(0)
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub GVtaCalcMethod_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVtaCalcMethod.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim CalculationTypeID As String = GVtaCalcMethod.DataKeys(e.CommandArgument).Values("CalculationTypeID")  
        Dim RedirectUrl As String = TBLtaCalcMethod.EditUrl & "?CalculationTypeID=" & CalculationTypeID
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
      End Try
    End If
  End Sub
  Protected Sub GVtaCalcMethod_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVtaCalcMethod.Init
    DataClassName = "GtaCalcMethod"
    SetGridView = GVtaCalcMethod
  End Sub
  Protected Sub TBLtaCalcMethod_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLtaCalcMethod.Init
    SetToolBar = TBLtaCalcMethod
  End Sub
  Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
  End Sub
End Class
