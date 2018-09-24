Partial Class AF_costProjectGroups
  Inherits SIS.SYS.InsertBase
  Protected Sub FVcostProjectGroups_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVcostProjectGroups.Init
    DataClassName = "AcostProjectGroups"
    SetFormView = FVcostProjectGroups
  End Sub
  Protected Sub TBLcostProjectGroups_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLcostProjectGroups.Init
    SetToolBar = TBLcostProjectGroups
  End Sub
  Protected Sub ODScostProjectGroups_Inserted(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODScostProjectGroups.Inserted
    If e.Exception Is Nothing Then
      Dim oDC As SIS.COST.costProjectGroups = CType(e.ReturnValue,SIS.COST.costProjectGroups)
      Dim tmpURL As String = "?tmp=1"
      tmpURL &= "&ProjectGroupID=" & oDC.ProjectGroupID
      TBLcostProjectGroups.AfterInsertURL &= tmpURL 
    End If
  End Sub
  Protected Sub FVcostProjectGroups_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVcostProjectGroups.DataBound
    SIS.COST.costProjectGroups.SetDefaultValues(sender, e) 
  End Sub
  Protected Sub FVcostProjectGroups_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVcostProjectGroups.PreRender
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/COST_Main/App_Create") & "/AF_costProjectGroups.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptcostProjectGroups") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptcostProjectGroups", mStr)
    End If
    If Request.QueryString("ProjectGroupID") IsNot Nothing Then
      CType(FVcostProjectGroups.FindControl("F_ProjectGroupID"), TextBox).Text = Request.QueryString("ProjectGroupID")
      CType(FVcostProjectGroups.FindControl("F_ProjectGroupID"), TextBox).Enabled = False
    End If
  End Sub

End Class
