Partial Class AF_costGLGroups
  Inherits SIS.SYS.InsertBase
  Protected Sub FVcostGLGroups_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVcostGLGroups.Init
    DataClassName = "AcostGLGroups"
    SetFormView = FVcostGLGroups
  End Sub
  Protected Sub TBLcostGLGroups_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLcostGLGroups.Init
    SetToolBar = TBLcostGLGroups
  End Sub
  Protected Sub ODScostGLGroups_Inserted(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODScostGLGroups.Inserted
    If e.Exception Is Nothing Then
      Dim oDC As SIS.COST.costGLGroups = CType(e.ReturnValue,SIS.COST.costGLGroups)
      Dim tmpURL As String = "?tmp=1"
      tmpURL &= "&GLGroupID=" & oDC.GLGroupID
      TBLcostGLGroups.AfterInsertURL &= tmpURL 
    End If
  End Sub
  Protected Sub FVcostGLGroups_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVcostGLGroups.DataBound
    SIS.COST.costGLGroups.SetDefaultValues(sender, e) 
  End Sub
  Protected Sub FVcostGLGroups_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVcostGLGroups.PreRender
    Dim oF_GLNatureID As LC_costGLNatures = FVcostGLGroups.FindControl("F_GLNatureID")
    oF_GLNatureID.Enabled = True
    oF_GLNatureID.SelectedValue = String.Empty
    If Not Session("F_GLNatureID") Is Nothing Then
      If Session("F_GLNatureID") <> String.Empty Then
        oF_GLNatureID.SelectedValue = Session("F_GLNatureID")
      End If
    End If
    Dim oF_CostGLGroupID_Display As Label  = FVcostGLGroups.FindControl("F_CostGLGroupID_Display")
    Dim oF_CostGLGroupID As TextBox  = FVcostGLGroups.FindControl("F_CostGLGroupID")
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/COST_Main/App_Create") & "/AF_costGLGroups.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptcostGLGroups") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptcostGLGroups", mStr)
    End If
    If Request.QueryString("GLGroupID") IsNot Nothing Then
      CType(FVcostGLGroups.FindControl("F_GLGroupID"), TextBox).Text = Request.QueryString("GLGroupID")
      CType(FVcostGLGroups.FindControl("F_GLGroupID"), TextBox).Enabled = False
    End If
  End Sub
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function CostGLGroupIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.COST.costvGLGroups.SelectcostvGLGroupsAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_COST_GLGroups_CostGLGroupID(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
    Dim CostGLGroupID As Int32 = CType(aVal(1),Int32)
    Dim oVar As SIS.COST.costvGLGroups = SIS.COST.costvGLGroups.costvGLGroupsGetByID(CostGLGroupID)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found." 
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function

End Class
