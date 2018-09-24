Partial Class AF_pakQCListH
  Inherits SIS.SYS.InsertBase
  Protected Sub FVpakQCListH_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpakQCListH.Init
    DataClassName = "ApakQCListH"
    SetFormView = FVpakQCListH
  End Sub
  Protected Sub TBLpakQCListH_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLpakQCListH.Init
    SetToolBar = TBLpakQCListH
  End Sub
  Protected Sub ODSpakQCListH_Inserted(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODSpakQCListH.Inserted
    If e.Exception Is Nothing Then
      Dim oDC As SIS.PAK.pakQCListH = CType(e.ReturnValue,SIS.PAK.pakQCListH)
      Dim tmpURL As String = "?tmp=1"
      tmpURL &= "&SerialNo=" & oDC.SerialNo
      tmpURL &= "&QCLNo=" & oDC.QCLNo
      TBLpakQCListH.AfterInsertURL &= tmpURL 
    End If
  End Sub
  Protected Sub FVpakQCListH_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpakQCListH.DataBound
    SIS.PAK.pakQCListH.SetDefaultValues(sender, e) 
  End Sub
  Protected Sub FVpakQCListH_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpakQCListH.PreRender
    Dim oF_SerialNo_Display As Label  = FVpakQCListH.FindControl("F_SerialNo_Display")
    oF_SerialNo_Display.Text = String.Empty
    If Not Session("F_SerialNo_Display") Is Nothing Then
      If Session("F_SerialNo_Display") <> String.Empty Then
        oF_SerialNo_Display.Text = Session("F_SerialNo_Display")
      End If
    End If
    Dim oF_SerialNo As TextBox  = FVpakQCListH.FindControl("F_SerialNo")
    oF_SerialNo.Enabled = True
    oF_SerialNo.Text = String.Empty
    If Not Session("F_SerialNo") Is Nothing Then
      If Session("F_SerialNo") <> String.Empty Then
        oF_SerialNo.Text = Session("F_SerialNo")
      End If
    End If
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/PAK_Main/App_Create") & "/AF_pakQCListH.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptpakQCListH") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptpakQCListH", mStr)
    End If
    If Request.QueryString("SerialNo") IsNot Nothing Then
      CType(FVpakQCListH.FindControl("F_SerialNo"), TextBox).Text = Request.QueryString("SerialNo")
      CType(FVpakQCListH.FindControl("F_SerialNo"), TextBox).Enabled = False
    End If
    If Request.QueryString("QCLNo") IsNot Nothing Then
      CType(FVpakQCListH.FindControl("F_QCLNo"), TextBox).Text = Request.QueryString("QCLNo")
      CType(FVpakQCListH.FindControl("F_QCLNo"), TextBox).Enabled = False
    End If
  End Sub
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function SerialNoCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.PAK.pakPO.SelectpakPOAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_PAK_QCListH_SerialNo(ByVal value As String) As String
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

End Class
