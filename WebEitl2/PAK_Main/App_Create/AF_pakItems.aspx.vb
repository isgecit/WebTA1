Partial Class AF_pakItems
  Inherits SIS.SYS.InsertBase
  Protected Sub FVpakItems_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpakItems.Init
    DataClassName = "ApakItems"
    SetFormView = FVpakItems
  End Sub
  Protected Sub TBLpakItems_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLpakItems.Init
    SetToolBar = TBLpakItems
  End Sub
  Protected Sub ODSpakItems_Inserted(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODSpakItems.Inserted
    If e.Exception Is Nothing Then
      Dim oDC As SIS.PAK.pakItems = CType(e.ReturnValue,SIS.PAK.pakItems)
      Dim tmpURL As String = "?tmp=1"
      tmpURL &= "&ItemNo=" & oDC.ItemNo
      TBLpakItems.AfterInsertURL &= tmpURL 
    End If
  End Sub
  Protected Sub FVpakItems_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpakItems.DataBound
    SIS.PAK.pakItems.SetDefaultValues(sender, e) 
  End Sub
  Protected Sub FVpakItems_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpakItems.PreRender
    Dim oF_ElementID_Display As Label  = FVpakItems.FindControl("F_ElementID_Display")
    Dim oF_ElementID As TextBox  = FVpakItems.FindControl("F_ElementID")
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/PAK_Main/App_Create") & "/AF_pakItems.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptpakItems") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptpakItems", mStr)
    End If
    If Request.QueryString("ItemNo") IsNot Nothing Then
      CType(FVpakItems.FindControl("F_ItemNo"), TextBox).Text = Request.QueryString("ItemNo")
      CType(FVpakItems.FindControl("F_ItemNo"), TextBox).Enabled = False
    End If
  End Sub
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function ElementIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.PAK.pakElements.SelectpakElementsAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_PAK_Items_ElementID(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
    Dim ElementID As String = CType(aVal(1),String)
    Dim oVar As SIS.PAK.pakElements = SIS.PAK.pakElements.pakElementsGetByID(ElementID)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found." 
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function

End Class
