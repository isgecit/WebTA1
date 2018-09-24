Partial Class AF_pakQCListD
  Inherits SIS.SYS.InsertBase
  Protected Sub FVpakQCListD_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpakQCListD.Init
    DataClassName = "ApakQCListD"
    SetFormView = FVpakQCListD
  End Sub
  Protected Sub TBLpakQCListD_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLpakQCListD.Init
    SetToolBar = TBLpakQCListD
  End Sub
  Protected Sub FVpakQCListD_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpakQCListD.DataBound
    SIS.PAK.pakQCListD.SetDefaultValues(sender, e) 
  End Sub
  Protected Sub FVpakQCListD_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpakQCListD.PreRender
    Dim oF_SerialNo_Display As Label  = FVpakQCListD.FindControl("F_SerialNo_Display")
    oF_SerialNo_Display.Text = String.Empty
    If Not Session("F_SerialNo_Display") Is Nothing Then
      If Session("F_SerialNo_Display") <> String.Empty Then
        oF_SerialNo_Display.Text = Session("F_SerialNo_Display")
      End If
    End If
    Dim oF_SerialNo As TextBox  = FVpakQCListD.FindControl("F_SerialNo")
    oF_SerialNo.Enabled = True
    oF_SerialNo.Text = String.Empty
    If Not Session("F_SerialNo") Is Nothing Then
      If Session("F_SerialNo") <> String.Empty Then
        oF_SerialNo.Text = Session("F_SerialNo")
      End If
    End If
    Dim oF_QCLNo_Display As Label  = FVpakQCListD.FindControl("F_QCLNo_Display")
    oF_QCLNo_Display.Text = String.Empty
    If Not Session("F_QCLNo_Display") Is Nothing Then
      If Session("F_QCLNo_Display") <> String.Empty Then
        oF_QCLNo_Display.Text = Session("F_QCLNo_Display")
      End If
    End If
    Dim oF_QCLNo As TextBox  = FVpakQCListD.FindControl("F_QCLNo")
    oF_QCLNo.Enabled = True
    oF_QCLNo.Text = String.Empty
    If Not Session("F_QCLNo") Is Nothing Then
      If Session("F_QCLNo") <> String.Empty Then
        oF_QCLNo.Text = Session("F_QCLNo")
      End If
    End If
    Dim oF_BOMNo_Display As Label  = FVpakQCListD.FindControl("F_BOMNo_Display")
    Dim oF_BOMNo As TextBox  = FVpakQCListD.FindControl("F_BOMNo")
    Dim oF_ItemNo_Display As Label  = FVpakQCListD.FindControl("F_ItemNo_Display")
    Dim oF_ItemNo As TextBox  = FVpakQCListD.FindControl("F_ItemNo")
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/PAK_Main/App_Create") & "/AF_pakQCListD.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptpakQCListD") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptpakQCListD", mStr)
    End If
    If Request.QueryString("SerialNo") IsNot Nothing Then
      CType(FVpakQCListD.FindControl("F_SerialNo"), TextBox).Text = Request.QueryString("SerialNo")
      CType(FVpakQCListD.FindControl("F_SerialNo"), TextBox).Enabled = False
    End If
    If Request.QueryString("QCLNo") IsNot Nothing Then
      CType(FVpakQCListD.FindControl("F_QCLNo"), TextBox).Text = Request.QueryString("QCLNo")
      CType(FVpakQCListD.FindControl("F_QCLNo"), TextBox).Enabled = False
    End If
    If Request.QueryString("BOMNo") IsNot Nothing Then
      CType(FVpakQCListD.FindControl("F_BOMNo"), TextBox).Text = Request.QueryString("BOMNo")
      CType(FVpakQCListD.FindControl("F_BOMNo"), TextBox).Enabled = False
    End If
    If Request.QueryString("ItemNo") IsNot Nothing Then
      CType(FVpakQCListD.FindControl("F_ItemNo"), TextBox).Text = Request.QueryString("ItemNo")
      CType(FVpakQCListD.FindControl("F_ItemNo"), TextBox).Enabled = False
    End If
  End Sub
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function SerialNoCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.PAK.pakPO.SelectpakPOAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function QCLNoCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.PAK.pakQCListH.SelectpakQCListHAutoCompleteList(prefixText, count, contextKey)
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
  Public Shared Function validate_FK_PAK_QCListD_SerialNo(ByVal value As String) As String
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
  Public Shared Function validate_FK_PAK_QCListD_ItemNo(ByVal value As String) As String
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
  Public Shared Function validate_FK_PAK_QCListD_BOMNo(ByVal value As String) As String
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
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_PAK_QCListD_QCLNo(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
    Dim SerialNo As Int32 = CType(aVal(1),Int32)
    Dim QCLNo As Int32 = CType(aVal(2),Int32)
    Dim oVar As SIS.PAK.pakQCListH = SIS.PAK.pakQCListH.pakQCListHGetByID(SerialNo,QCLNo)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found." 
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function

End Class
