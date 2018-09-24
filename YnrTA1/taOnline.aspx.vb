
Partial Class taOnline
  Inherits System.Web.UI.Page

  Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
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
