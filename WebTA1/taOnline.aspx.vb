Imports System.Data
Imports System.Data.SqlClient
Partial Class taOnline
  Inherits System.Web.UI.Page
  Protected Function CreateLog() As Boolean
    Dim Blocked As Boolean = False
    Dim Prop As String = ""
    Dim head As String = ""
    Dim Req As String = ""
    Dim emp As String = ""
    Dim action As String = ""
    Dim mMailID As String = "0"
    Dim mLinkID As String = "0"

    For Each pi As System.Reflection.PropertyInfo In Request.GetType.GetProperties
      If pi.MemberType = Reflection.MemberTypes.Property Then
        Try
          Prop &= "<br/> " & pi.Name & " : " & pi.GetValue(Request, Nothing)
        Catch ex As Exception
        End Try
      End If
    Next
    For I As Integer = 0 To Request.Headers.Count - 1
      head &= "<br/> " & Request.Headers.Keys(I) & " : " & Request.Headers.Item(I)
    Next
    If Request.QueryString.Count > 0 Then
      If Request.QueryString(0).ToLower = "atabillno" Then
        action = "Approve"
      ElseIf Request.QueryString(0).ToLower = "rtabillno" Then
        action = "Reject"
      End If
      Req = Request.QueryString.Item(0)
    End If
    Dim RemoteIP As String = ""
    Dim ip As String = String.Empty
    ip = Request.ServerVariables("HTTP_X_FORWARDED_FOR")
    If Not String.IsNullOrEmpty(ip) Then
      Dim ipRange As String() = ip.Split(","c)
      Dim le As Integer = ipRange.Length - 1
      RemoteIP = ipRange(le)
    Else
      RemoteIP = Request.ServerVariables("REMOTE_ADDR")
    End If
    mMailID = Request.QueryString("MailID")
    mLinkID = Request.QueryString("LinkID")

    If head.Trim.StartsWith("<br/> Accept : */*") Then
      Blocked = True
    End If

    Dim mSql As String = " INSERT TA_Log "
    mSql &= " ("
    mSql &= " UserID,"
    mSql &= " Action,"
    mSql &= " RequestID,"
    mSql &= " LoggedOn,"
    mSql &= " RequestProp,"
    mSql &= " RequestHeader,"
    mSql &= " MailSrNo,"
    mSql &= " LinkSrNo"
    mSql &= " )"
    mSql &= " VALUES ("
    mSql &= "'" & 0 & "',"
    mSql &= "'" & action & "',"
    mSql &= Req & ",GetDate()"
    mSql &= ",'" & Prop & "',"
    If Blocked Then
      mSql &= "'BLOCKED " & head & "REMOTE_ADDRESS : " & RemoteIP & "',"
    Else
      mSql &= "'" & head & "REMOTE_ADDRESS : " & RemoteIP & "',"
    End If
    mSql &= mMailID & ","
    mSql &= mLinkID
    mSql &= ")"
    Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
      Using Cmd As SqlCommand = Con.CreateCommand()
        Cmd.CommandType = CommandType.Text
        Cmd.CommandText = mSql
        Con.Open()
        Cmd.ExecuteNonQuery()
      End Using
    End Using
    Return Blocked
  End Function

  Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
    Dim Blocked As Boolean = False
    Try
      Blocked = CreateLog()
    Catch ex As Exception
      Dim xx As String = ex.Message
    End Try
    If Blocked Then Exit Sub

    Dim toBeApproved As Boolean = False
    Dim taBillNo As Integer = 0
    Dim tmpStr As String = ""
    If Request.QueryString("atabillno") IsNot Nothing Then
      toBeApproved = True
      tmpStr = Request.QueryString("atabillno")
    ElseIf Request.QueryString("rtabillno") IsNot Nothing Then
      toBeApproved = False
      tmpStr = Request.QueryString("rtabillno")
    End If
    If tmpStr = String.Empty Then
      msg.Text = "Invalid Link."
      msg.ForeColor = Drawing.Color.Red
      Exit Sub
    End If
    taBillNo = tmpStr
    HttpContext.Current.Session("LoginID") = "0340"
    Dim oTA As SIS.TA.taBH = SIS.TA.taBH.taBHGetByID(taBillNo)
    If oTA Is Nothing Then
      msg.Text = "Invalid TA Bill No."
      msg.ForeColor = Drawing.Color.Red
      Exit Sub
    End If
    Select Case oTA.BillStatusID
      Case TAStates.UnderSpecialSanction
        If Not oTA.FK_TA_Bills_EmployeeID.TASelfApproval Then
          HttpContext.Current.Session("LoginID") = oTA.FK_TA_Bills_EmployeeID.TASanctioningAuthority
        Else
          HttpContext.Current.Session("LoginID") = oTA.EmployeeID
        End If
        If toBeApproved Then
          Try
            oTA = SIS.TA.taBillApprovalByMD.ApproveWF(oTA.TABillNo, "Approved from E-Mail")
          Catch ex As Exception
          End Try
          If oTA.BillStatusID = TAStates.UnderReceiveByAccounts Then
            msg.Text = "TA Bill Special Sanction APPROVED"
            msg.ForeColor = Drawing.Color.Green
            Exit Sub
          Else
            msg.Text = "Error Approving TA Bill."
            msg.ForeColor = Drawing.Color.Red
            Exit Sub
          End If
        Else
          Try
            oTA = SIS.TA.taBillApprovalByMD.RejectWF(oTA.TABillNo, "Return executed from E-Mail")
          Catch ex As Exception
          End Try
          If oTA.BillStatusID = TAStates.ReturnedBySanctioningAuthority Then
            msg.Text = "TA Bill Special Sanction RETURNED"
            msg.ForeColor = Drawing.Color.Green
            Exit Sub
          Else
            msg.Text = "Error Rejecting TA Bill."
            msg.ForeColor = Drawing.Color.Red
            Exit Sub
          End If
        End If
      Case TAStates.UnderReceiveByAccounts
        msg.Text = "TA Bill already approved."
        msg.ForeColor = Drawing.Color.Green
        Exit Sub
      Case TAStates.ReturnedBySanctioningAuthority
        msg.Text = "TA Bill already returned."
        msg.ForeColor = Drawing.Color.Red
        Exit Sub
      Case Else
        msg.Text = "TA Bill State is NOT Under Special Sanction"
        msg.ForeColor = Drawing.Color.Red
        Exit Sub
    End Select
  End Sub
End Class
