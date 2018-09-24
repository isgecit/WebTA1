Partial Class AF_pakPOBIDocuments
  Inherits SIS.SYS.InsertBase
  Protected Sub FVpakPOBIDocuments_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpakPOBIDocuments.Init
    DataClassName = "ApakPOBIDocuments"
    SetFormView = FVpakPOBIDocuments
  End Sub
  Protected Sub TBLpakPOBIDocuments_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLpakPOBIDocuments.Init
    SetToolBar = TBLpakPOBIDocuments
  End Sub
  Protected Sub ODSpakPOBIDocuments_Inserted(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODSpakPOBIDocuments.Inserted
    If e.Exception Is Nothing Then
      Dim oDC As SIS.PAK.pakPOBIDocuments = CType(e.ReturnValue,SIS.PAK.pakPOBIDocuments)
      Dim tmpURL As String = "?tmp=1"
      tmpURL &= "&SerialNo=" & oDC.SerialNo
      tmpURL &= "&BOMNo=" & oDC.BOMNo
      tmpURL &= "&ItemNo=" & oDC.ItemNo
      tmpURL &= "&DocNo=" & oDC.DocNo
      TBLpakPOBIDocuments.AfterInsertURL &= tmpURL 
    End If
  End Sub
  Protected Sub FVpakPOBIDocuments_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpakPOBIDocuments.DataBound
    SIS.PAK.pakPOBIDocuments.SetDefaultValues(sender, e) 
  End Sub
  Protected Sub FVpakPOBIDocuments_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpakPOBIDocuments.PreRender
    Dim oF_SerialNo_Display As Label  = FVpakPOBIDocuments.FindControl("F_SerialNo_Display")
    oF_SerialNo_Display.Text = String.Empty
    If Not Session("F_SerialNo_Display") Is Nothing Then
      If Session("F_SerialNo_Display") <> String.Empty Then
        oF_SerialNo_Display.Text = Session("F_SerialNo_Display")
      End If
    End If
    Dim oF_SerialNo As TextBox  = FVpakPOBIDocuments.FindControl("F_SerialNo")
    oF_SerialNo.Enabled = True
    oF_SerialNo.Text = String.Empty
    If Not Session("F_SerialNo") Is Nothing Then
      If Session("F_SerialNo") <> String.Empty Then
        oF_SerialNo.Text = Session("F_SerialNo")
      End If
    End If
    Dim oF_BOMNo_Display As Label  = FVpakPOBIDocuments.FindControl("F_BOMNo_Display")
    oF_BOMNo_Display.Text = String.Empty
    If Not Session("F_BOMNo_Display") Is Nothing Then
      If Session("F_BOMNo_Display") <> String.Empty Then
        oF_BOMNo_Display.Text = Session("F_BOMNo_Display")
      End If
    End If
    Dim oF_BOMNo As TextBox  = FVpakPOBIDocuments.FindControl("F_BOMNo")
    oF_BOMNo.Enabled = True
    oF_BOMNo.Text = String.Empty
    If Not Session("F_BOMNo") Is Nothing Then
      If Session("F_BOMNo") <> String.Empty Then
        oF_BOMNo.Text = Session("F_BOMNo")
      End If
    End If
    Dim oF_ItemNo_Display As Label  = FVpakPOBIDocuments.FindControl("F_ItemNo_Display")
    oF_ItemNo_Display.Text = String.Empty
    If Not Session("F_ItemNo_Display") Is Nothing Then
      If Session("F_ItemNo_Display") <> String.Empty Then
        oF_ItemNo_Display.Text = Session("F_ItemNo_Display")
      End If
    End If
    Dim oF_ItemNo As TextBox  = FVpakPOBIDocuments.FindControl("F_ItemNo")
    oF_ItemNo.Enabled = True
    oF_ItemNo.Text = String.Empty
    If Not Session("F_ItemNo") Is Nothing Then
      If Session("F_ItemNo") <> String.Empty Then
        oF_ItemNo.Text = Session("F_ItemNo")
      End If
    End If
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/PAK_Main/App_Create") & "/AF_pakPOBIDocuments.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptpakPOBIDocuments") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptpakPOBIDocuments", mStr)
    End If
    If Request.QueryString("SerialNo") IsNot Nothing Then
      CType(FVpakPOBIDocuments.FindControl("F_SerialNo"), TextBox).Text = Request.QueryString("SerialNo")
      CType(FVpakPOBIDocuments.FindControl("F_SerialNo"), TextBox).Enabled = False
    End If
    If Request.QueryString("BOMNo") IsNot Nothing Then
      CType(FVpakPOBIDocuments.FindControl("F_BOMNo"), TextBox).Text = Request.QueryString("BOMNo")
      CType(FVpakPOBIDocuments.FindControl("F_BOMNo"), TextBox).Enabled = False
    End If
    If Request.QueryString("ItemNo") IsNot Nothing Then
      CType(FVpakPOBIDocuments.FindControl("F_ItemNo"), TextBox).Text = Request.QueryString("ItemNo")
      CType(FVpakPOBIDocuments.FindControl("F_ItemNo"), TextBox).Enabled = False
    End If
    If Request.QueryString("DocNo") IsNot Nothing Then
      CType(FVpakPOBIDocuments.FindControl("F_DocNo"), TextBox).Text = Request.QueryString("DocNo")
      CType(FVpakPOBIDocuments.FindControl("F_DocNo"), TextBox).Enabled = False
    End If
  End Sub
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function SerialNoCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.PAK.pakPO.SelectpakPOAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function BOMNoCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.PAK.pakPOBOM.SelectpakPOBOMAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function ItemNoCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.PAK.pakPOBItems.SelectpakPOBItemsAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_PAK_POBIDocuments_SerialNo(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
    Dim SerialNo As Int32 = CType(aVal(1),Int32)
    Dim oVar As SIS.PAK.pakPO = SIS.PAK.pakPO.pakPOGetByID(SerialNo)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found." 
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_PAK_POBIDocuments_ItemNo(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
    Dim SerialNo As Int32 = CType(aVal(1),Int32)
    Dim BOMNo As Int32 = CType(aVal(2),Int32)
    Dim ItemNo As Int32 = CType(aVal(3),Int32)
    Dim oVar As SIS.PAK.pakPOBItems = SIS.PAK.pakPOBItems.pakPOBItemsGetByID(SerialNo,BOMNo,ItemNo)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found." 
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_PAK_POBIDocuments_BOMNo(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
    Dim SerialNo As Int32 = CType(aVal(1),Int32)
    Dim BOMNo As Int32 = CType(aVal(2),Int32)
    Dim oVar As SIS.PAK.pakPOBOM = SIS.PAK.pakPOBOM.pakPOBOMGetByID(SerialNo,BOMNo)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found." 
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function

End Class
