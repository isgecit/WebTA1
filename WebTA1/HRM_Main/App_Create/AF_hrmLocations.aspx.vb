Partial Class AF_hrmLocations
  Inherits SIS.SYS.InsertBase
  Protected Sub FVhrmLocations_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVhrmLocations.Init
    DataClassName = "AhrmLocations"
    SetFormView = FVhrmLocations
  End Sub
  Protected Sub TBLhrmLocations_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLhrmLocations.Init
    SetToolBar = TBLhrmLocations
  End Sub
  Protected Sub ODShrmLocations_Inserted(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODShrmLocations.Inserted
    If e.Exception Is Nothing Then
      Dim oDC As SIS.HRM.hrmLocations = CType(e.ReturnValue,SIS.HRM.hrmLocations)
      Dim tmpURL As String = "?tmp=1"
      tmpURL &= "&LocationID=" & oDC.LocationID
      TBLhrmLocations.AfterInsertURL &= tmpURL 
    End If
  End Sub
  Protected Sub FVhrmLocations_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVhrmLocations.DataBound
    SIS.HRM.hrmLocations.SetDefaultValues(sender, e) 
  End Sub
  Protected Sub FVhrmLocations_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVhrmLocations.PreRender
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/HRM_Main/App_Create") & "/AF_hrmLocations.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scripthrmLocations") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scripthrmLocations", mStr)
    End If
    If Request.QueryString("LocationID") IsNot Nothing Then
      CType(FVhrmLocations.FindControl("F_LocationID"), TextBox).Text = Request.QueryString("LocationID")
      CType(FVhrmLocations.FindControl("F_LocationID"), TextBox).Enabled = False
    End If
  End Sub

End Class
