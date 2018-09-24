Partial Class AF_pakCItems
  Inherits SIS.SYS.InsertBase
  Protected Sub FVpakCItems_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpakCItems.Init
    DataClassName = "ApakCItems"
    SetFormView = FVpakCItems
  End Sub
  Protected Sub TBLpakCItems_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLpakCItems.Init
    SetToolBar = TBLpakCItems
  End Sub
  Protected Sub FVpakCItems_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpakCItems.DataBound
    SIS.PAK.pakCItems.SetDefaultValues(sender, e) 
  End Sub
  Protected Sub FVpakCItems_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpakCItems.PreRender
    Dim oF_RootItem_Display As Label  = FVpakCItems.FindControl("F_RootItem_Display")
    oF_RootItem_Display.Text = String.Empty
    If Not Session("F_RootItem_Display") Is Nothing Then
      If Session("F_RootItem_Display") <> String.Empty Then
        oF_RootItem_Display.Text = Session("F_RootItem_Display")
      End If
    End If
    Dim oF_RootItem As TextBox  = FVpakCItems.FindControl("F_RootItem")
    oF_RootItem.Enabled = True
    oF_RootItem.Text = String.Empty
    If Not Session("F_RootItem") Is Nothing Then
      If Session("F_RootItem") <> String.Empty Then
        oF_RootItem.Text = Session("F_RootItem")
      End If
    End If
    Dim oF_ElementID_Display As Label  = FVpakCItems.FindControl("F_ElementID_Display")
    Dim oF_ElementID As TextBox  = FVpakCItems.FindControl("F_ElementID")
    Dim oF_DocumentNo_Display As Label  = FVpakCItems.FindControl("F_DocumentNo_Display")
    Dim oF_DocumentNo As TextBox  = FVpakCItems.FindControl("F_DocumentNo")
    Dim oF_ParentItemNo_Display As Label  = FVpakCItems.FindControl("F_ParentItemNo_Display")
    Dim oF_ParentItemNo As TextBox  = FVpakCItems.FindControl("F_ParentItemNo")
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/PAK_Main/App_Create") & "/AF_pakCItems.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptpakCItems") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptpakCItems", mStr)
    End If
    If Request.QueryString("RootItem") IsNot Nothing Then
      CType(FVpakCItems.FindControl("F_RootItem"), TextBox).Text = Request.QueryString("RootItem")
      CType(FVpakCItems.FindControl("F_RootItem"), TextBox).Enabled = False
    End If
    If Request.QueryString("ItemNo") IsNot Nothing Then
      CType(FVpakCItems.FindControl("F_ItemNo"), TextBox).Text = Request.QueryString("ItemNo")
      CType(FVpakCItems.FindControl("F_ItemNo"), TextBox).Enabled = False
    End If
  End Sub
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function RootItemCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.PAK.pakItems.SelectpakItemsAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function ElementIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.PAK.pakElements.SelectpakElementsAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function DocumentNoCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.PAK.pakDocuments.SelectpakDocumentsAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function ParentItemNoCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.PAK.pakCItems.SelectpakCItemsAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_PAK_Items_DocumentNo(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
    Dim DocumentNo As Int32 = CType(aVal(1),Int32)
    Dim oVar As SIS.PAK.pakDocuments = SIS.PAK.pakDocuments.pakDocumentsGetByID(DocumentNo)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found." 
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
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
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_PAK_Items_ParentItemNo(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
    Dim ParentItemNo As Int32 = CType(aVal(1),Int32)
    Dim oVar As SIS.PAK.pakItems = SIS.PAK.pakItems.pakItemsGetByID(ParentItemNo)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found." 
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_PAK_Items_RootItem(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
    Dim RootItem As Int32 = CType(aVal(1),Int32)
    Dim oVar As SIS.PAK.pakItems = SIS.PAK.pakItems.pakItemsGetByID(RootItem)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found." 
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function

End Class
