Partial Class AF_costProjectInputStatus
  Inherits SIS.SYS.InsertBase
  Protected Sub FVcostProjectInputStatus_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVcostProjectInputStatus.Init
    DataClassName = "AcostProjectInputStatus"
    SetFormView = FVcostProjectInputStatus
  End Sub
  Protected Sub TBLcostProjectInputStatus_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLcostProjectInputStatus.Init
    SetToolBar = TBLcostProjectInputStatus
  End Sub
  Protected Sub FVcostProjectInputStatus_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVcostProjectInputStatus.DataBound
    SIS.COST.costProjectInputStatus.SetDefaultValues(sender, e) 
  End Sub
  Protected Sub FVcostProjectInputStatus_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVcostProjectInputStatus.PreRender
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/COST_Main/App_Create") & "/AF_costProjectInputStatus.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptcostProjectInputStatus") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptcostProjectInputStatus", mStr)
    End If
    If Request.QueryString("StatusID") IsNot Nothing Then
      CType(FVcostProjectInputStatus.FindControl("F_StatusID"), TextBox).Text = Request.QueryString("StatusID")
      CType(FVcostProjectInputStatus.FindControl("F_StatusID"), TextBox).Enabled = False
    End If
  End Sub

End Class
