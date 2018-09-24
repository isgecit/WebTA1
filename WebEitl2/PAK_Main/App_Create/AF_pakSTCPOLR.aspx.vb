Partial Class AF_pakSTCPOLR
  Inherits SIS.SYS.InsertBase
  Protected Sub FVpakSTCPOLR_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpakSTCPOLR.Init
    DataClassName = "ApakSTCPOLR"
    SetFormView = FVpakSTCPOLR
  End Sub
  Protected Sub TBLpakSTCPOLR_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLpakSTCPOLR.Init
    SetToolBar = TBLpakSTCPOLR
  End Sub
  Protected Sub ODSpakSTCPOLR_Inserted(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODSpakSTCPOLR.Inserted
    If e.Exception Is Nothing Then
      Dim oDC As SIS.PAK.pakSTCPOLR = CType(e.ReturnValue,SIS.PAK.pakSTCPOLR)
      Dim tmpURL As String = "?tmp=1"
      tmpURL &= "&SerialNo=" & oDC.SerialNo
      tmpURL &= "&ItemNo=" & oDC.ItemNo
      tmpURL &= "&UploadNo=" & oDC.UploadNo
      TBLpakSTCPOLR.AfterInsertURL &= tmpURL 
    End If
  End Sub
  Protected Sub FVpakSTCPOLR_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpakSTCPOLR.DataBound
    SIS.PAK.pakSTCPOLR.SetDefaultValues(sender, e) 
  End Sub
  Protected Sub FVpakSTCPOLR_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpakSTCPOLR.PreRender
    Dim oF_SerialNo_Display As Label  = FVpakSTCPOLR.FindControl("F_SerialNo_Display")
    oF_SerialNo_Display.Text = String.Empty
    If Not Session("F_SerialNo_Display") Is Nothing Then
      If Session("F_SerialNo_Display") <> String.Empty Then
        oF_SerialNo_Display.Text = Session("F_SerialNo_Display")
      End If
    End If
    Dim oF_SerialNo As TextBox  = FVpakSTCPOLR.FindControl("F_SerialNo")
    oF_SerialNo.Enabled = True
    oF_SerialNo.Text = String.Empty
    If Not Session("F_SerialNo") Is Nothing Then
      If Session("F_SerialNo") <> String.Empty Then
        oF_SerialNo.Text = Session("F_SerialNo")
      End If
    End If
    Dim oF_ItemNo_Display As Label  = FVpakSTCPOLR.FindControl("F_ItemNo_Display")
    oF_ItemNo_Display.Text = String.Empty
    If Not Session("F_ItemNo_Display") Is Nothing Then
      If Session("F_ItemNo_Display") <> String.Empty Then
        oF_ItemNo_Display.Text = Session("F_ItemNo_Display")
      End If
    End If
    Dim oF_ItemNo As TextBox  = FVpakSTCPOLR.FindControl("F_ItemNo")
    oF_ItemNo.Enabled = True
    oF_ItemNo.Text = String.Empty
    If Not Session("F_ItemNo") Is Nothing Then
      If Session("F_ItemNo") <> String.Empty Then
        oF_ItemNo.Text = Session("F_ItemNo")
      End If
    End If
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/PAK_Main/App_Create") & "/AF_pakSTCPOLR.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptpakSTCPOLR") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptpakSTCPOLR", mStr)
    End If
    If Request.QueryString("SerialNo") IsNot Nothing Then
      CType(FVpakSTCPOLR.FindControl("F_SerialNo"), TextBox).Text = Request.QueryString("SerialNo")
      CType(FVpakSTCPOLR.FindControl("F_SerialNo"), TextBox).Enabled = False
    End If
    If Request.QueryString("ItemNo") IsNot Nothing Then
      CType(FVpakSTCPOLR.FindControl("F_ItemNo"), TextBox).Text = Request.QueryString("ItemNo")
      CType(FVpakSTCPOLR.FindControl("F_ItemNo"), TextBox).Enabled = False
    End If
    If Request.QueryString("UploadNo") IsNot Nothing Then
      CType(FVpakSTCPOLR.FindControl("F_UploadNo"), TextBox).Text = Request.QueryString("UploadNo")
      CType(FVpakSTCPOLR.FindControl("F_UploadNo"), TextBox).Enabled = False
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
  Public Shared Function validate_FK_PAK_POLineRec_SerialNo(ByVal value As String) As String
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
  Public Shared Function validate_FK_PAK_POLineRec_ItemNo(ByVal value As String) As String
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

End Class
