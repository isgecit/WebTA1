Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Imports System.Web.Script.Serialization
Partial Class GF_nprkVerifyByAdmin
  Inherits SIS.SYS.GridBase
  Protected Sub GVnprkRECUserClaims_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVnprkRECUserClaims.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim ClaimID As Int32 = GVnprkRECUserClaims.DataKeys(e.CommandArgument).Values("ClaimID")
        Dim RedirectUrl As String = TBLnprkRECUserClaims.EditUrl & "?ClaimID=" & ClaimID
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
      End Try
    End If
    If e.CommandName.ToLower = "approvewf".ToLower Then
      Try
        Dim gv As GridView = CType(GVnprkRECUserClaims.Rows(e.CommandArgument).FindControl("GVBills"), GridView)
        For Each r As GridViewRow In gv.Rows
          If r.RowType = DataControlRowType.DataRow Then
            Dim d As String = CType(r.FindControl("F_Verify"), DropDownList).SelectedValue
            If d = String.Empty Then
              Throw New Exception("Pl. update YES/NO against all driver charges.")
            End If
          End If
        Next
        Dim ClaimID As Int32 = GVnprkRECUserClaims.DataKeys(e.CommandArgument).Values("ClaimID")
        For Each r As GridViewRow In gv.Rows
          If r.RowType = DataControlRowType.DataRow Then
            Dim ApplicationID As String = gv.DataKeys(r.DataItemIndex).Values("ApplicationID")
            Dim AttachmentID As String = gv.DataKeys(r.DataItemIndex).Values("AttachmentID")
            Dim d As String = CType(r.FindControl("F_Verify"), DropDownList).SelectedValue
            SIS.NPRK.nprkBillDetails.UZ_nprkBillDetailsVerifiedByAdmin(ClaimID, ApplicationID, AttachmentID, d)
          End If
        Next
        Dim AccountsRemarks As String = CType(GVnprkRECUserClaims.Rows(e.CommandArgument).FindControl("F_AccountsRemarks"), TextBox).Text
        SIS.NPRK.nprkRECUserClaims.ApproveAdminWF(ClaimID, AccountsRemarks)
        GVnprkRECUserClaims.DataBind()
      Catch ex As Exception
        Dim message As String = New JavaScriptSerializer().Serialize(ex.Message)
        Dim script As String = String.Format("alert({0});", message)
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", script, True)
      End Try
    End If
    If e.CommandName.ToLower = "rejectwf".ToLower Then
      Try
        Dim AccountsRemarks As String = CType(GVnprkRECUserClaims.Rows(e.CommandArgument).FindControl("F_AccountsRemarks"), TextBox).Text
        Dim ClaimID As Int32 = GVnprkRECUserClaims.DataKeys(e.CommandArgument).Values("ClaimID")
        SIS.NPRK.nprkRECUserClaims.RejectAdminWF(ClaimID, AccountsRemarks)
        GVnprkRECUserClaims.DataBind()
      Catch ex As Exception
      End Try
    End If
  End Sub
  Protected Sub GVnprkRECUserClaims_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVnprkRECUserClaims.Init
    DataClassName = "GnprkRECUserClaims"
    SetGridView = GVnprkRECUserClaims
  End Sub
  Protected Sub TBLnprkRECUserClaims_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLnprkRECUserClaims.Init
    SetToolBar = TBLnprkRECUserClaims
  End Sub
  Protected Sub F_CardNo_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_CardNo.TextChanged
    Session("F_CardNo") = F_CardNo.Text
    Session("F_CardNo_Display") = F_CardNo_Display.Text
    InitGridPage()
  End Sub
  <System.Web.Services.WebMethod()>
  <System.Web.Script.Services.ScriptMethod()>
  Public Shared Function CardNoCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.TA.taWebUsers.SelecttaWebUsersAutoCompleteList(prefixText, count, contextKey)
  End Function
  Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
    F_CardNo_Display.Text = String.Empty
    If Not Session("F_CardNo_Display") Is Nothing Then
      If Session("F_CardNo_Display") <> String.Empty Then
        F_CardNo_Display.Text = Session("F_CardNo_Display")
      End If
    End If
    F_CardNo.Text = String.Empty
    If Not Session("F_CardNo") Is Nothing Then
      If Session("F_CardNo") <> String.Empty Then
        F_CardNo.Text = Session("F_CardNo")
      End If
    End If
    Dim strScriptCardNo As String = "<script type=""text/javascript""> " &
      "function ACECardNo_Selected(sender, e) {" &
      "  var F_CardNo = $get('" & F_CardNo.ClientID & "');" &
      "  var F_CardNo_Display = $get('" & F_CardNo_Display.ClientID & "');" &
      "  var retval = e.get_value();" &
      "  var p = retval.split('|');" &
      "  F_CardNo.value = p[0];" &
      "  F_CardNo_Display.innerHTML = e.get_text();" &
      "}" &
      "</script>"
    If Not Page.ClientScript.IsClientScriptBlockRegistered("F_CardNo") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_CardNo", strScriptCardNo)
    End If
    Dim strScriptPopulatingCardNo As String = "<script type=""text/javascript""> " &
      "function ACECardNo_Populating(o,e) {" &
      "  var p = $get('" & F_CardNo.ClientID & "');" &
      "  p.style.backgroundImage  = 'url(../../images/loader.gif)';" &
      "  p.style.backgroundRepeat= 'no-repeat';" &
      "  p.style.backgroundPosition = 'right';" &
      "  o._contextKey = '';" &
      "}" &
      "function ACECardNo_Populated(o,e) {" &
      "  var p = $get('" & F_CardNo.ClientID & "');" &
      "  p.style.backgroundImage  = 'none';" &
      "}" &
      "</script>"
    If Not Page.ClientScript.IsClientScriptBlockRegistered("F_CardNoPopulating") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_CardNoPopulating", strScriptPopulatingCardNo)
    End If
    Dim validateScriptCardNo As String = "<script type=""text/javascript"">" &
      "  function validate_CardNo(o) {" &
      "    validated_FK_PRK_UserClaims_CardNo_main = true;" &
      "    validate_FK_PRK_UserClaims_CardNo(o);" &
      "  }" &
      "</script>"
    If Not Page.ClientScript.IsClientScriptBlockRegistered("validateCardNo") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateCardNo", validateScriptCardNo)
    End If
    Dim validateScriptFK_PRK_UserClaims_CardNo As String = "<script type=""text/javascript"">" &
      "  function validate_FK_PRK_UserClaims_CardNo(o) {" &
      "    var value = o.id;" &
      "    var CardNo = $get('" & F_CardNo.ClientID & "');" &
      "    try{" &
      "    if(CardNo.value==''){" &
      "      if(validated_FK_PRK_UserClaims_CardNo.main){" &
      "        var o_d = $get(o.id +'_Display');" &
      "        try{o_d.innerHTML = '';}catch(ex){}" &
      "      }" &
      "    }" &
      "    value = value + ',' + CardNo.value ;" &
      "    }catch(ex){}" &
      "    o.style.backgroundImage  = 'url(../../images/pkloader.gif)';" &
      "    o.style.backgroundRepeat= 'no-repeat';" &
      "    o.style.backgroundPosition = 'right';" &
      "    PageMethods.validate_FK_PRK_UserClaims_CardNo(value, validated_FK_PRK_UserClaims_CardNo);" &
      "  }" &
      "  validated_FK_PRK_UserClaims_CardNo_main = false;" &
      "  function validated_FK_PRK_UserClaims_CardNo(result) {" &
      "    var p = result.split('|');" &
      "    var o = $get(p[1]);" &
      "    var o_d = $get(p[1]+'_Display');" &
      "    try{o_d.innerHTML = p[2];}catch(ex){}" &
      "    o.style.backgroundImage  = 'none';" &
      "    if(p[0]=='1'){" &
      "      o.value='';" &
      "      try{o_d.innerHTML = '';}catch(ex){}" &
      "      __doPostBack(o.id, o.value);" &
      "    }" &
      "    else" &
      "      __doPostBack(o.id, o.value);" &
      "  }" &
      "</script>"
    If Not Page.ClientScript.IsClientScriptBlockRegistered("validateFK_PRK_UserClaims_CardNo") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateFK_PRK_UserClaims_CardNo", validateScriptFK_PRK_UserClaims_CardNo)
    End If
  End Sub
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

  'Private Sub cmdMigrate_Click(sender As Object, e As EventArgs) Handles cmdMigrate.Click

  '  Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
  '    Using Cmd As SqlCommand = Con.CreateCommand()
  '      Cmd.CommandType = CommandType.Text
  '      Cmd.CommandText = "select * from tmp_neg"
  '      Con.Open()
  '      Dim Reader As SqlDataReader = Cmd.ExecuteReader()
  '      While (Reader.Read())
  '        Dim lgr As SIS.NPRK.nprkLedger
  '        Dim news As Decimal = Reader("news")
  '        Dim card As Integer = Reader("card")
  '        Dim uni As Decimal = Reader("uni")
  '        If news <> 0 Then
  '          lgr = New SIS.NPRK.nprkLedger
  '          With lgr
  '            .EmployeeID = card
  '            .PerkID = 6
  '            .TranType = "ADJ"
  '            .TranDate = "30/09/2017"
  '            .FinYear = "2018"
  '            .Value = (news * -1)
  '            .UOM = "Rs."
  '            .Amount = .Value
  '            .Remarks = "Transfered & Closed"
  '            .CreatedBy = "340"
  '          End With
  '          SIS.NPRK.nprkLedger.InsertData(lgr)
  '        End If
  '        If uni <> 0 Then
  '          lgr = New SIS.NPRK.nprkLedger
  '          With lgr
  '            .EmployeeID = card
  '            .PerkID = 8
  '            .TranType = "ADJ"
  '            .TranDate = "30/09/2017"
  '            .FinYear = "2018"
  '            .Value = (uni * -1)
  '            .UOM = "Rs."
  '            .Amount = .Value
  '            .Remarks = "Transfered & Closed"
  '            .CreatedBy = "340"
  '          End With
  '          SIS.NPRK.nprkLedger.InsertData(lgr)
  '        End If
  '      End While
  '      Reader.Close()
  '    End Using
  '  End Using


  '  'Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
  '  '  Using Cmd As SqlCommand = Con.CreateCommand()
  '  '    Cmd.CommandType = CommandType.Text
  '  '    Cmd.CommandText = "select * from tmp_lgr"
  '  '    Con.Open()
  '  '    Dim Reader As SqlDataReader = Cmd.ExecuteReader()
  '  '    While (Reader.Read())
  '  '      Dim lgr As New SIS.NPRK.nprkLedger
  '  '      With lgr
  '  '        .EmployeeID = Reader("emp")
  '  '        .PerkID = 17
  '  '        .TranType = "ADJ"
  '  '        .TranDate = "01/10/2017"
  '  '        .FinYear = "2018"
  '  '        .Value = Reader("med")
  '  '        .UOM = "Rs."
  '  '        .Amount = .Value
  '  '        .Remarks = "Migrated Clubbed OPB"
  '  '        .CreatedBy = "340"
  '  '      End With
  '  '      SIS.NPRK.nprkLedger.InsertData(lgr)
  '  '    End While
  '  '    Reader.Close()
  '  '  End Using
  '  'End Using

  'End Sub
End Class
