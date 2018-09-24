Imports System.Web.Script.Serialization

Partial Class AF_nprkUserClaims
  Inherits SIS.SYS.InsertBase
  Protected Sub FVnprkUserClaims_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVnprkUserClaims.Init
    DataClassName = "AnprkUserClaims"
    SetFormView = FVnprkUserClaims
  End Sub
  Protected Sub TBLnprkUserClaims_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLnprkUserClaims.Init
    SetToolBar = TBLnprkUserClaims
  End Sub
  Protected Sub ODSnprkUserClaims_Inserted(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODSnprkUserClaims.Inserted
    If e.Exception Is Nothing Then
      Dim oDC As SIS.NPRK.nprkUserClaims = CType(e.ReturnValue, SIS.NPRK.nprkUserClaims)
      Dim tmpURL As String = "?tmp=1"
      tmpURL &= "&ClaimID=" & oDC.ClaimID
      TBLnprkUserClaims.AfterInsertURL &= tmpURL
    End If
  End Sub
  Protected Sub FVnprkUserClaims_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVnprkUserClaims.DataBound
    SIS.NPRK.nprkUserClaims.SetDefaultValues(sender, e)
  End Sub
  Protected Sub FVnprkUserClaims_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVnprkUserClaims.PreRender
    Dim oF_CardNo_Display As Label = FVnprkUserClaims.FindControl("F_CardNo_Display")
    Dim oF_CardNo As TextBox = FVnprkUserClaims.FindControl("F_CardNo")
    Dim oF_ReceivedBy_Display As Label = FVnprkUserClaims.FindControl("F_ReceivedBy_Display")
    Dim oF_ReceivedBy As TextBox = FVnprkUserClaims.FindControl("F_ReceivedBy")
    Dim oF_ReturnedBy_Display As Label = FVnprkUserClaims.FindControl("F_ReturnedBy_Display")
    Dim oF_ReturnedBy As TextBox = FVnprkUserClaims.FindControl("F_ReturnedBy")
    Dim oF_ClaimStatusID As LC_nprkClaimStatus = FVnprkUserClaims.FindControl("F_ClaimStatusID")
    oF_ClaimStatusID.Enabled = True
    oF_ClaimStatusID.SelectedValue = String.Empty
    If Not Session("F_ClaimStatusID") Is Nothing Then
      If Session("F_ClaimStatusID") <> String.Empty Then
        oF_ClaimStatusID.SelectedValue = Session("F_ClaimStatusID")
      End If
    End If
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/NPRK_Main/App_Create") & "/AF_nprkUserClaims.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptnprkUserClaims") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptnprkUserClaims", mStr)
    End If
    If Request.QueryString("ClaimID") IsNot Nothing Then
      CType(FVnprkUserClaims.FindControl("F_ClaimID"), TextBox).Text = Request.QueryString("ClaimID")
      CType(FVnprkUserClaims.FindControl("F_ClaimID"), TextBox).Enabled = False
    End If
  End Sub
  <System.Web.Services.WebMethod()>
  <System.Web.Script.Services.ScriptMethod()>
  Public Shared Function CardNoCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.TA.taWebUsers.SelecttaWebUsersAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()>
  <System.Web.Script.Services.ScriptMethod()>
  Public Shared Function ReceivedByCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.TA.taWebUsers.SelecttaWebUsersAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()>
  <System.Web.Script.Services.ScriptMethod()>
  Public Shared Function ReturnedByCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.TA.taWebUsers.SelecttaWebUsersAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()>
  Public Shared Function validate_FK_PRK_UserClaims_CardNo(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String = "0|" & aVal(0)
    Dim CardNo As String = CType(aVal(1), String)
    Dim oVar As SIS.TA.taWebUsers = SIS.TA.taWebUsers.taWebUsersGetByID(CardNo)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found."
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField
    End If
    Return mRet
  End Function
  <System.Web.Services.WebMethod()>
  Public Shared Function validate_FK_PRK_UserClaims_ReceivedBy(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String = "0|" & aVal(0)
    Dim ReceivedBy As String = CType(aVal(1), String)
    Dim oVar As SIS.TA.taWebUsers = SIS.TA.taWebUsers.taWebUsersGetByID(ReceivedBy)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found."
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField
    End If
    Return mRet
  End Function
  <System.Web.Services.WebMethod()>
  Public Shared Function validate_FK_PRK_UserClaims_ReturnedBy(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String = "0|" & aVal(0)
    Dim ReturnedBy As String = CType(aVal(1), String)
    Dim oVar As SIS.TA.taWebUsers = SIS.TA.taWebUsers.taWebUsersGetByID(ReturnedBy)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found."
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField
    End If
    Return mRet
  End Function

End Class
