Partial Class AF_pakSTCPOLRD
  Inherits SIS.SYS.InsertBase
  Protected Sub FVpakSTCPOLRD_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpakSTCPOLRD.Init
    DataClassName = "ApakSTCPOLRD"
    SetFormView = FVpakSTCPOLRD
  End Sub
  Protected Sub TBLpakSTCPOLRD_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLpakSTCPOLRD.Init
    SetToolBar = TBLpakSTCPOLRD
  End Sub
  Protected Sub FVpakSTCPOLRD_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpakSTCPOLRD.DataBound
    SIS.PAK.pakSTCPOLRD.SetDefaultValues(sender, e) 
  End Sub
  Protected Sub FVpakSTCPOLRD_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpakSTCPOLRD.PreRender
    Dim oF_SerialNo_Display As Label  = FVpakSTCPOLRD.FindControl("F_SerialNo_Display")
    oF_SerialNo_Display.Text = String.Empty
    If Not Session("F_SerialNo_Display") Is Nothing Then
      If Session("F_SerialNo_Display") <> String.Empty Then
        oF_SerialNo_Display.Text = Session("F_SerialNo_Display")
      End If
    End If
    Dim oF_SerialNo As TextBox  = FVpakSTCPOLRD.FindControl("F_SerialNo")
    oF_SerialNo.Enabled = True
    oF_SerialNo.Text = String.Empty
    If Not Session("F_SerialNo") Is Nothing Then
      If Session("F_SerialNo") <> String.Empty Then
        oF_SerialNo.Text = Session("F_SerialNo")
      End If
    End If
    Dim oF_ItemNo_Display As Label  = FVpakSTCPOLRD.FindControl("F_ItemNo_Display")
    oF_ItemNo_Display.Text = String.Empty
    If Not Session("F_ItemNo_Display") Is Nothing Then
      If Session("F_ItemNo_Display") <> String.Empty Then
        oF_ItemNo_Display.Text = Session("F_ItemNo_Display")
      End If
    End If
    Dim oF_ItemNo As TextBox  = FVpakSTCPOLRD.FindControl("F_ItemNo")
    oF_ItemNo.Enabled = True
    oF_ItemNo.Text = String.Empty
    If Not Session("F_ItemNo") Is Nothing Then
      If Session("F_ItemNo") <> String.Empty Then
        oF_ItemNo.Text = Session("F_ItemNo")
      End If
    End If
    Dim oF_UploadNo_Display As Label  = FVpakSTCPOLRD.FindControl("F_UploadNo_Display")
    oF_UploadNo_Display.Text = String.Empty
    If Not Session("F_UploadNo_Display") Is Nothing Then
      If Session("F_UploadNo_Display") <> String.Empty Then
        oF_UploadNo_Display.Text = Session("F_UploadNo_Display")
      End If
    End If
    Dim oF_UploadNo As TextBox  = FVpakSTCPOLRD.FindControl("F_UploadNo")
    oF_UploadNo.Enabled = True
    oF_UploadNo.Text = String.Empty
    If Not Session("F_UploadNo") Is Nothing Then
      If Session("F_UploadNo") <> String.Empty Then
        oF_UploadNo.Text = Session("F_UploadNo")
      End If
    End If
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/PAK_Main/App_Create") & "/AF_pakSTCPOLRD.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptpakSTCPOLRD") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptpakSTCPOLRD", mStr)
    End If
    If Request.QueryString("SerialNo") IsNot Nothing Then
      CType(FVpakSTCPOLRD.FindControl("F_SerialNo"), TextBox).Text = Request.QueryString("SerialNo")
      CType(FVpakSTCPOLRD.FindControl("F_SerialNo"), TextBox).Enabled = False
    End If
    If Request.QueryString("ItemNo") IsNot Nothing Then
      CType(FVpakSTCPOLRD.FindControl("F_ItemNo"), TextBox).Text = Request.QueryString("ItemNo")
      CType(FVpakSTCPOLRD.FindControl("F_ItemNo"), TextBox).Enabled = False
    End If
    If Request.QueryString("UploadNo") IsNot Nothing Then
      CType(FVpakSTCPOLRD.FindControl("F_UploadNo"), TextBox).Text = Request.QueryString("UploadNo")
      CType(FVpakSTCPOLRD.FindControl("F_UploadNo"), TextBox).Enabled = False
    End If
    If Request.QueryString("DocSerialNo") IsNot Nothing Then
      CType(FVpakSTCPOLRD.FindControl("F_DocSerialNo"), TextBox).Text = Request.QueryString("DocSerialNo")
      CType(FVpakSTCPOLRD.FindControl("F_DocSerialNo"), TextBox).Enabled = False
    End If
  End Sub
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function SerialNoCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.PAK.pakTCPO.SelectpakTCPOAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function ItemNoCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.PAK.pakTCPOL.SelectpakTCPOLAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function UploadNoCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.PAK.pakTCPOLR.SelectpakTCPOLRAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_PAK_POLineRecDoc_SerialNo(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
    Dim SerialNo As Int32 = CType(aVal(1),Int32)
    Dim oVar As SIS.PAK.pakTCPO = SIS.PAK.pakTCPO.pakTCPOGetByID(SerialNo)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found." 
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_PAK_POLineRecDoc_ItemNo(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
    Dim SerialNo As Int32 = CType(aVal(1),Int32)
    Dim ItemNo As Int32 = CType(aVal(2),Int32)
    Dim oVar As SIS.PAK.pakTCPOL = SIS.PAK.pakTCPOL.pakTCPOLGetByID(SerialNo,ItemNo)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found." 
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_PAK_POLineRecDoc_UploadNo(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
    Dim SerialNo As Int32 = CType(aVal(1),Int32)
    Dim ItemNo As Int32 = CType(aVal(2),Int32)
    Dim UploadNo As Int32 = CType(aVal(3),Int32)
    Dim oVar As SIS.PAK.pakTCPOLR = SIS.PAK.pakTCPOLR.pakTCPOLRGetByID(SerialNo,ItemNo,UploadNo)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found." 
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function

  Private Sub ODSpakSTCPOLRD_Inserted(sender As Object, e As ObjectDataSourceStatusEventArgs) Handles ODSpakSTCPOLRD.Inserted
    If e.Exception Is Nothing Then
      Dim oDC As SIS.PAK.pakSTCPOLRD = CType(e.ReturnValue, SIS.PAK.pakSTCPOLRD)
      Dim tmpURL As String = "?tmp=1"
      tmpURL &= "&SerialNo=" & oDC.SerialNo
      tmpURL &= "&ItemNo=" & oDC.ItemNo
      tmpURL &= "&UploadNo=" & oDC.UploadNo
      tmpURL &= "&DocSerialNo=" & oDC.DocSerialNo
      TBLpakSTCPOLRD.AfterInsertURL &= tmpURL
    End If

  End Sub
End Class
