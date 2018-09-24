Partial Class AF_pakPkgListD
  Inherits SIS.SYS.InsertBase
  Protected Sub FVpakPkgListD_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpakPkgListD.Init
    DataClassName = "ApakPkgListD"
    SetFormView = FVpakPkgListD
  End Sub
  Protected Sub TBLpakPkgListD_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLpakPkgListD.Init
    SetToolBar = TBLpakPkgListD
  End Sub
  Protected Sub FVpakPkgListD_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpakPkgListD.DataBound
    SIS.PAK.pakPkgListD.SetDefaultValues(sender, e) 
  End Sub
  Protected Sub FVpakPkgListD_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpakPkgListD.PreRender
    Dim oF_SerialNo_Display As Label  = FVpakPkgListD.FindControl("F_SerialNo_Display")
    oF_SerialNo_Display.Text = String.Empty
    If Not Session("F_SerialNo_Display") Is Nothing Then
      If Session("F_SerialNo_Display") <> String.Empty Then
        oF_SerialNo_Display.Text = Session("F_SerialNo_Display")
      End If
    End If
    Dim oF_SerialNo As TextBox  = FVpakPkgListD.FindControl("F_SerialNo")
    oF_SerialNo.Enabled = True
    oF_SerialNo.Text = String.Empty
    If Not Session("F_SerialNo") Is Nothing Then
      If Session("F_SerialNo") <> String.Empty Then
        oF_SerialNo.Text = Session("F_SerialNo")
      End If
    End If
    Dim oF_PkgNo_Display As Label  = FVpakPkgListD.FindControl("F_PkgNo_Display")
    oF_PkgNo_Display.Text = String.Empty
    If Not Session("F_PkgNo_Display") Is Nothing Then
      If Session("F_PkgNo_Display") <> String.Empty Then
        oF_PkgNo_Display.Text = Session("F_PkgNo_Display")
      End If
    End If
    Dim oF_PkgNo As TextBox  = FVpakPkgListD.FindControl("F_PkgNo")
    oF_PkgNo.Enabled = True
    oF_PkgNo.Text = String.Empty
    If Not Session("F_PkgNo") Is Nothing Then
      If Session("F_PkgNo") <> String.Empty Then
        oF_PkgNo.Text = Session("F_PkgNo")
      End If
    End If
    Dim oF_BOMNo_Display As Label  = FVpakPkgListD.FindControl("F_BOMNo_Display")
    Dim oF_BOMNo As TextBox  = FVpakPkgListD.FindControl("F_BOMNo")
    Dim oF_ItemNo_Display As Label  = FVpakPkgListD.FindControl("F_ItemNo_Display")
    Dim oF_ItemNo As TextBox  = FVpakPkgListD.FindControl("F_ItemNo")
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/PAK_Main/App_Create") & "/AF_pakPkgListD.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptpakPkgListD") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptpakPkgListD", mStr)
    End If
    If Request.QueryString("SerialNo") IsNot Nothing Then
      CType(FVpakPkgListD.FindControl("F_SerialNo"), TextBox).Text = Request.QueryString("SerialNo")
      CType(FVpakPkgListD.FindControl("F_SerialNo"), TextBox).Enabled = False
    End If
    If Request.QueryString("PkgNo") IsNot Nothing Then
      CType(FVpakPkgListD.FindControl("F_PkgNo"), TextBox).Text = Request.QueryString("PkgNo")
      CType(FVpakPkgListD.FindControl("F_PkgNo"), TextBox).Enabled = False
    End If
    If Request.QueryString("BOMNo") IsNot Nothing Then
      CType(FVpakPkgListD.FindControl("F_BOMNo"), TextBox).Text = Request.QueryString("BOMNo")
      CType(FVpakPkgListD.FindControl("F_BOMNo"), TextBox).Enabled = False
    End If
    If Request.QueryString("ItemNo") IsNot Nothing Then
      CType(FVpakPkgListD.FindControl("F_ItemNo"), TextBox).Text = Request.QueryString("ItemNo")
      CType(FVpakPkgListD.FindControl("F_ItemNo"), TextBox).Enabled = False
    End If
  End Sub
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function SerialNoCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.PAK.pakPO.SelectpakPOAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function PkgNoCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.PAK.pakPkgListH.SelectpakPkgListHAutoCompleteList(prefixText, count, contextKey)
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
  Public Shared Function validate_FK_PAK_PkgListD_PkgNo(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
    Dim SerialNo As Int32 = CType(aVal(1),Int32)
    Dim PkgNo As Int32 = CType(aVal(2),Int32)
    Dim oVar As SIS.PAK.pakPkgListH = SIS.PAK.pakPkgListH.pakPkgListHGetByID(SerialNo,PkgNo)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found." 
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_PAK_PkgListD_SerialNo(ByVal value As String) As String
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
  Public Shared Function validate_FK_PAK_PkgListD_ItemNo(ByVal value As String) As String
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
  Public Shared Function validate_FK_PAK_PkgListD_BOMNo(ByVal value As String) As String
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
