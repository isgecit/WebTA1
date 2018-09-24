Imports System.Xml
Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Imports System.Net.Mail
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Text
Namespace SIS.PAK
  Public Class Alerts
    Public Shared Function TCAlert(ByVal PONo As Integer, ByVal AlertEvent As pakTCAlertEvents, Optional ByVal ItemNo As Integer = 0, Optional ByVal UploadNo As Integer = 0) As Boolean
      Dim oPO As SIS.PAK.pakTCPO = Nothing
      Dim oItm As SIS.PAK.pakTCPOL = Nothing
      Dim oUpl As SIS.PAK.pakTCPOLR = Nothing
      Select Case AlertEvent
        Case pakTCAlertEvents.OpenPORequested, pakTCAlertEvents.OpenPORequestExecuted, pakTCAlertEvents.POClosed
          oPO = SIS.PAK.pakTCPO.pakTCPOGetByID(PONo)
        Case pakTCAlertEvents.TCPOIssued
          oPO = SIS.PAK.pakTCPO.pakTCPOGetByID(PONo)
        Case pakTCAlertEvents.DocumentsSubmitted
          oPO = SIS.PAK.pakTCPO.pakTCPOGetByID(PONo)
          oItm = SIS.PAK.pakTCPOL.pakTCPOLGetByID(PONo, ItemNo)
          oUpl = SIS.PAK.pakTCPOLR.pakTCPOLRGetByID(PONo, ItemNo, UploadNo)
      End Select
      If AlertEvent = pakTCAlertEvents.TCPOIssued Then
        SendPasswordToSupplier(PONo, True)
      End If
      Dim aErr As New ArrayList
      Dim mRet As String = ""
      Dim oClient As SmtpClient = New SmtpClient("192.9.200.214", 25)
      oClient.Credentials = New Net.NetworkCredential("adskvaultadmin", "isgec@123")
      Dim oMsg As System.Net.Mail.MailMessage = New System.Net.Mail.MailMessage()
      With oMsg
        Select Case AlertEvent
          Case pakTCAlertEvents.TCPOIssued, pakTCAlertEvents.OpenPORequestExecuted
            'FROM Issuer
            Try
              If oPO.FK_PAK_PO_IssuedBy.EMailID = String.Empty Then
                aErr.Add(oPO.IssuedBy & " " & oPO.FK_PAK_PO_IssuedBy.UserFullName)
                .From = New MailAddress("baansupport@isgec.co.in", "BaaN Support")
                .CC.Add(New MailAddress("baansupport@isgec.co.in", "BaaN Support"))
              Else
                .From = New MailAddress(oPO.FK_PAK_PO_IssuedBy.EMailID, oPO.FK_PAK_PO_IssuedBy.UserFullName)
                .CC.Add(New MailAddress(oPO.FK_PAK_PO_IssuedBy.EMailID, oPO.FK_PAK_PO_IssuedBy.UserFullName))
              End If
              'CC to Buyer
              If oPO.FK_PAK_PO_BuyerID.EMailID = String.Empty Then
                aErr.Add(oPO.BuyerID & " " & oPO.FK_PAK_PO_BuyerID.UserFullName)
                .CC.Add(New MailAddress("baansupport@isgec.co.in", "BaaN Support"))
              Else
                If Not Convert.ToBoolean(ConfigurationManager.AppSettings("Testing")) Then
                  .CC.Add(New MailAddress(oPO.FK_PAK_PO_BuyerID.EMailID, oPO.FK_PAK_PO_BuyerID.UserFullName))
                End If
              End If
              'Default CC Include
              .CC.Add(New MailAddress("harishkumar@isgec.co.in", "Harish Kumar"))
              .CC.Add(New MailAddress("lalit@isgec.co.in", "Lalit Gupta"))

            Catch ex As Exception
              .From = New MailAddress("baansupport@isgec.co.in", "BaaN Support")
              .CC.Add(New MailAddress("baansupport@isgec.co.in", "BaaN Support"))
              .CC.Add(New MailAddress("harishkumar@isgec.co.in", "Harish Kumar"))
            End Try
            'TO Supplier
            If oPO.FK_PAK_SupplierID.EMailID = String.Empty Then
              aErr.Add(oPO.SupplierID & " " & oPO.FK_PAK_SupplierID.BPName)
              .To.Add(New MailAddress("baansupport@isgec.co.in", "BaaN Support"))
            Else
              Dim aIDs() As String = oPO.FK_PAK_SupplierID.EMailID.Split(",".ToCharArray)
              For Each tmp As String In aIDs
                .To.Add(New MailAddress(tmp, tmp))
              Next
            End If
            'End of Supplier ID
            If AlertEvent = pakTCAlertEvents.TCPOIssued Then
              .Subject = "Issued Purchase Order No.: " & oPO.PONumber
            Else
              'If oRQ.ExecutedToOpen Then
              '  .Subject = "Re-Opened Purchase Order No.: " & oPO.PONumber
              'Else
              '  .Subject = "Purchase Order Not Opened.: " & oPO.PONumber
              'End If
            End If
          Case pakTCAlertEvents.DocumentsSubmitted, pakTCAlertEvents.POClosed, pakTCAlertEvents.OpenPORequested
            'From Supplier
            Try
              If oPO.FK_PAK_SupplierID.EMailID = String.Empty Then
                aErr.Add(oPO.SupplierID & " " & oPO.FK_PAK_SupplierID.BPName)
                .From = New MailAddress("baansupport@isgec.co.in", "BaaN Support")
                .CC.Add(New MailAddress("baansupport@isgec.co.in", "BaaN Support"))
              Else
                .From = New MailAddress(oPO.FK_PAK_SupplierID.EMailID, oPO.FK_PAK_SupplierID.BPName)
                .CC.Add(New MailAddress(oPO.FK_PAK_SupplierID.EMailID, oPO.FK_PAK_SupplierID.BPName))
              End If
              'End of Supplier ID
            Catch ex As Exception
              .From = New MailAddress("baansupport@isgec.co.in", "BaaN Support")
              .CC.Add(New MailAddress("baansupport@isgec.co.in", "BaaN Support"))
              .CC.Add(New MailAddress("harishkumar@isgec.co.in", "Harish Kumar"))
            End Try
            'To Issuer
            Try
              If oPO.FK_PAK_PO_IssuedBy.EMailID = String.Empty Then
                aErr.Add(oPO.IssuedBy & " " & oPO.FK_PAK_PO_IssuedBy.UserFullName)
                .To.Add(New MailAddress("baansupport@isgec.co.in", "BaaN Support"))
              Else
                .To.Add(New MailAddress(oPO.FK_PAK_PO_IssuedBy.EMailID, oPO.FK_PAK_PO_IssuedBy.UserFullName))
              End If
              'Include Buyer
              If oPO.FK_PAK_PO_BuyerID.EMailID = String.Empty Then
                aErr.Add(oPO.BuyerID & " " & oPO.FK_PAK_PO_BuyerID.UserFullName)
                .CC.Add(New MailAddress("baansupport@isgec.co.in", "BaaN Support"))
              Else
                If Not Convert.ToBoolean(ConfigurationManager.AppSettings("Testing")) Then
                  .CC.Add(New MailAddress(oPO.FK_PAK_PO_BuyerID.EMailID, oPO.FK_PAK_PO_BuyerID.UserFullName))
                End If
              End If
            Catch ex As Exception
              .To.Add(New MailAddress("baansupport@isgec.co.in", "BaaN Support"))
              .CC.Add(New MailAddress("harishkumar@isgec.co.in", "Harish Kumar"))
            End Try
            'End of Buyer
            If AlertEvent = pakTCAlertEvents.POClosed Then
              .Subject = "Closed Purchase Order No.: " & oPO.PONumber
            ElseIf AlertEvent = pakTCAlertEvents.OpenPORequested Then
              .Subject = "Request to Re-Open Purchase Order No.: " & oPO.PONumber
            Else
              .Subject = "Document Submitted for Technical Clearance: " & oItm.ItemDescription
            End If
        End Select

        If AlertEvent = pakTCAlertEvents.DocumentsSubmitted Then
          'Add Project wise Alert Group in CC
          Dim eunt As String = ""
          Select Case oPO.PONumber.Substring(0, 4)
            Case "P101"
              eunt = "EU200"
            Case "P201"
              eunt = "EU230"
            Case "P301"
              eunt = "EU210"
            Case "P401"
              eunt = "EU220"
            Case "P501"
              eunt = "EU240"
          End Select

          Dim Users As List(Of SIS.PAK.erpData.erpEnggGroup) = SIS.PAK.erpData.erpEnggGroup.GetFromERP(eunt, oPO.ProjectID)
          For Each usr As SIS.PAK.erpData.erpEnggGroup In Users
            Try
              Dim ad As MailAddress = New MailAddress(usr.EMailID, usr.EmpName)
              If Not .CC.Contains(ad) Then
                .CC.Add(ad)
              End If
            Catch ex As Exception
              aErr.Add(usr.EmpID & " " & usr.EmpName)
            End Try
          Next
          'End of Add Project Users
        End If
      End With
      With oMsg
        If .To.Count <= 0 Then
          .To.Add(New MailAddress("baansupport@isgec.co.in", "BaaN Support"))
        End If
        .IsBodyHtml = True
        Dim sb As StringBuilder = New StringBuilder()
        Dim sw As IO.StringWriter = New IO.StringWriter(sb)
        Dim writer As HtmlTextWriter = New HtmlTextWriter(sw)

        Dim oTbl As Table = GetTCPOTable(oPO, AlertEvent)
        Try
          oTbl.RenderControl(writer)
          sb.Append("<br /><br />")
        Catch ex As Exception
        End Try
        Select Case AlertEvent
          Case pakTCAlertEvents.TCPOIssued
            oTbl = GetTCItemTable(oPO)
            Try
              oTbl.RenderControl(writer)
              sb.Append("<br /><br />")
            Catch ex As Exception
            End Try
          Case pakTCAlertEvents.DocumentsSubmitted
            Try
              oTbl = GetTCItemTable(oPO, ItemNo)
              oTbl.RenderControl(writer)
              sb.Append("<br /><br />")
            Catch ex As Exception
            End Try
            sb.Append("<b>Receipt No.: </b>" & oUpl.ReceiptNo)
            sb.Append("<br /><br />")
            oTbl = GetTCUploadTable(PONo, ItemNo, UploadNo)
            Try
              oTbl.RenderControl(writer)
              sb.Append("<br /><br />")
            Catch ex As Exception
            End Try
        End Select

        Dim Header As String = ""
        Header = Header & "<html xmlns=""http://www.w3.org/1999/xhtml"">"
        Header = Header & "<head>"
        Header = Header & "<title></title>"
        Header = Header & "<style>"
        Header = Header & "body{margin: 10px auto auto 60px;}"
        Header = Header & ".tblHd, .tblHd td{font-size: 12px;font-weight: bold;height: 30px !important;background-color:lightgray;}"
        Header = Header & "table{"
        Header = Header & "border: solid 1pt black;"
        Header = Header & "border-collapse:collapse;"
        Header = Header & "font-family: Tahoma;}"

        Header = Header & "td{padding-left: 4px;"
        Header = Header & "border: solid 1pt black;"
        Header = Header & "font-family: Tahoma;"
        Header = Header & "font-size: 9px;"
        Header = Header & "vertical-align:top;}"

        Header = Header & "</style>"
        Header = Header & "</head>"
        Header = Header & "<body>"
        If aErr.Count > 0 Then
          Header = Header & "<table>"
          Header = Header & "<tr><td style=""color: red""><i><b>"
          Header = Header & "NOTE: E-Mail Alert could not be delivered to following recipient(s), Please update their E-Mail ID in EITL/ERP Application."
          Header = Header & "</b></i></td></tr>"
          For Each Err As String In aErr
            Header = Header & "<tr><td color=""red""><i>"
            Header = Header & Err
            Header = Header & "</i></td></tr>"
          Next
          Header = Header & "</table>"
        End If
        If AlertEvent = pakTCAlertEvents.OpenPORequested Then
          'Header = Header & "<br /><table>"
          'Header = Header & "<tr><td><b>"
          'Header = Header & "REASON TO RE-OPEN"
          'Header = Header & "</b></td></tr>"
          'Header = Header & "<tr><td>"
          'Header = Header & oRQ.Remarks
          'Header = Header & "</td></tr>"
          'Header = Header & "</table>"
        ElseIf AlertEvent = pakTCAlertEvents.OpenPORequestExecuted Then
          ''If Not oRQ.ExecutedToOpen Then
          ''  Header = Header & "<br /><table>"
          ''  Header = Header & "<tr><td><b>"
          ''  Header = Header & "REASON TO RE-OPEN"
          ''  Header = Header & "</b></td></tr>"
          ''  Header = Header & "<tr><td>"
          ''  Header = Header & oRQ.ExecuterRemarks
          ''  Header = Header & "</td></tr>"
          ''  Header = Header & "</table>"
          ''End If
        End If
        Header = Header & sb.ToString
        Header = Header & "</body></html>"
        .Body = Header
      End With
      Try
        oClient.Send(oMsg)
      Catch ex As Exception
      End Try
      Return True
    End Function

    Public Shared Sub SendPasswordToSupplier(ByVal PONo As Integer, Optional ByVal IsTC As Boolean = False)
      Dim oPO As SIS.PAK.pakPO = SIS.PAK.pakPO.pakPOGetByID(PONo)
      Dim oClient As SmtpClient = New SmtpClient("192.9.200.214", 25)
      oClient.Credentials = New Net.NetworkCredential("adskvaultadmin", "isgec@123")
      Dim oMsg As System.Net.Mail.MailMessage = New System.Net.Mail.MailMessage()
      With oMsg
        Try
          Dim aIDs() As String = oPO.FK_PAK_SupplierID.EMailID.Split(",".ToCharArray)
          For Each tmp As String In aIDs
            .To.Add(New MailAddress(tmp, tmp))
          Next

        Catch ex As Exception
          .To.Add(New MailAddress("baansupport@isgec.co.in", "BaaN Support"))
        End Try
        .From = New MailAddress("baansupport@isgec.co.in", "BaaN Support")
        .Subject = "Authorization Details to access Purchase Order No.: " & oPO.PONumber
        .IsBodyHtml = True
        Dim oTbl As Table = Nothing
        If Not IsTC Then
          oTbl = GetPOTable(oPO, pakAlertEvents.POVerification, True)
        Else
          oTbl = GetTCPOTable(SIS.PAK.pakTCPO.pakTCPOGetByID(PONo), pakTCAlertEvents.TCPOIssued, True)
        End If
        Dim sb As StringBuilder = New StringBuilder()
        Dim sw As IO.StringWriter = New IO.StringWriter(sb)
        Dim writer As HtmlTextWriter = New HtmlTextWriter(sw)
        Try
          oTbl.RenderControl(writer)
        Catch ex As Exception
        End Try
        Dim Header As String = ""
        Header = Header & "<html xmlns=""http://www.w3.org/1999/xhtml"">"
        Header = Header & "<head>"
        Header = Header & "<title></title>"
        Header = Header & "<style>"
        Header = Header & "body{margin: 10px auto auto 60px;}"
        Header = Header & ".tblHd, .tblHd td{font-size: 12px;font-weight: bold;height: 30px !important;background-color:lightgray;}"
        Header = Header & "table{"
        Header = Header & "border: solid 1pt black;"
        Header = Header & "border-collapse:collapse;"
        Header = Header & "font-family: Tahoma;}"

        Header = Header & "td{padding-left: 4px;"
        Header = Header & "border: solid 1pt black;"
        Header = Header & "font-family: Tahoma;"
        Header = Header & "font-size: 9px;"
        Header = Header & "vertical-align:top;}"

        Header = Header & "</style>"
        Header = Header & "</head>"
        Header = Header & "<body>"
        Header = Header & sb.ToString
        Header = Header & "</body></html>"
        .Body = Header
        If Not IsTC Then
          Try
            Dim oAt As New System.Net.Mail.Attachment("~/User_Mannual.pdf")
            oAt.Name = "User Mannual"
            .Attachments.Add(oAt)
          Catch ex As Exception
          End Try
        End If
      End With
      Try
        oClient.Send(oMsg)
      Catch ex As Exception
      End Try
    End Sub
    Public Shared Function Alert(ByVal PONo As Integer, ByVal AlertEvent As pakAlertEvents) As Boolean
      Dim oPO As SIS.PAK.pakPO = Nothing
      oPO = SIS.PAK.pakPO.pakPOGetByID(PONo)
      Select Case AlertEvent
        Case pakAlertEvents.OpenPORequested, pakAlertEvents.OpenPORequestExecuted
        Case Else
      End Select
      If oPO.POTypeID = pakErpPOTypes.Package Then
        If AlertEvent = pakAlertEvents.POVerification Then
          SendPasswordToSupplier(PONo)
        End If
      Else
        If AlertEvent = pakAlertEvents.POIssued Then
          SendPasswordToSupplier(PONo)
        End If
      End If

      Dim aErr As New ArrayList
      Dim mRet As String = ""
      Dim oClient As SmtpClient = New SmtpClient("192.9.200.214", 25)
      oClient.Credentials = New Net.NetworkCredential("adskvaultadmin", "isgec@123")
      Dim oMsg As System.Net.Mail.MailMessage = New System.Net.Mail.MailMessage()
      With oMsg
        Select Case AlertEvent
          Case pakAlertEvents.POVerification, pakAlertEvents.POIssued, pakAlertEvents.OpenPORequestExecuted
            'FROM Issuer
            Try
              If oPO.FK_PAK_PO_IssuedBy.EMailID = String.Empty Then
                aErr.Add(oPO.IssuedBy & " " & oPO.FK_PAK_PO_IssuedBy.UserFullName)
                .From = New MailAddress("baansupport@isgec.co.in", "BaaN Support")
                .CC.Add(New MailAddress("baansupport@isgec.co.in", "BaaN Support"))
              Else
                .From = New MailAddress(oPO.FK_PAK_PO_IssuedBy.EMailID, oPO.FK_PAK_PO_IssuedBy.UserFullName)
                .CC.Add(New MailAddress(oPO.FK_PAK_PO_IssuedBy.EMailID, oPO.FK_PAK_PO_IssuedBy.UserFullName))
              End If
              'CC to Buyer
              If oPO.FK_PAK_PO_BuyerID.EMailID = String.Empty Then
                aErr.Add(oPO.BuyerID & " " & oPO.FK_PAK_PO_BuyerID.UserFullName)
                .CC.Add(New MailAddress("baansupport@isgec.co.in", "BaaN Support"))
              Else
                If Not Convert.ToBoolean(ConfigurationManager.AppSettings("Testing")) Then
                  .CC.Add(New MailAddress(oPO.FK_PAK_PO_BuyerID.EMailID, oPO.FK_PAK_PO_BuyerID.UserFullName))
                End If
              End If
              'Default CC Include
              .CC.Add(New MailAddress("harishkumar@isgec.co.in", "Harish Kumar"))
              .CC.Add(New MailAddress("lalit@isgec.co.in", "Lalit Gupta"))
            Catch ex As Exception
              .From = New MailAddress("baansupport@isgec.co.in", "BaaN Support")
              .CC.Add(New MailAddress("baansupport@isgec.co.in", "BaaN Support"))
              .CC.Add(New MailAddress("harishkumar@isgec.co.in", "Harish Kumar"))
            End Try
            'TO Supplier
            If oPO.FK_PAK_SupplierID.EMailID = String.Empty Then
              aErr.Add(oPO.SupplierID & " " & oPO.FK_PAK_SupplierID.BPName)
              .To.Add(New MailAddress("baansupport@isgec.co.in", "BaaN Support"))
            Else
              Dim aIDs() As String = oPO.FK_PAK_SupplierID.EMailID.Split(",".ToCharArray)
              For Each tmp As String In aIDs
                .To.Add(New MailAddress(tmp, "<" & tmp & ">"))
              Next
            End If
            'End of Supplier ID
            If AlertEvent = pakAlertEvents.POIssued Then
              .Subject = "Issued Purchase Order No.: " & oPO.PONumber
            ElseIf AlertEvent = pakAlertEvents.POVerification Then
              .Subject = "Verify Purchase Order No.: " & oPO.PONumber
            Else
              'If oRQ.ExecutedToOpen Then
              '  .Subject = "Re-Opened Purchase Order No.: " & oPO.PONumber
              'Else
              '  .Subject = "Purchase Order Not Opened.: " & oPO.PONumber
              'End If
            End If
          Case pakAlertEvents.POApproval, pakAlertEvents.MaterialDespatched, pakAlertEvents.DocumentsDespatched, pakAlertEvents.POClosed, pakAlertEvents.OpenPORequested
            'From Supplier
            Try
              If oPO.FK_PAK_SupplierID.EMailID = String.Empty Then
                aErr.Add(oPO.SupplierID & " " & oPO.FK_PAK_SupplierID.BPName)
                .From = New MailAddress("baansupport@isgec.co.in", "BaaN Support")
                .CC.Add(New MailAddress("baansupport@isgec.co.in", "BaaN Support"))
              Else
                .From = New MailAddress(oPO.FK_PAK_SupplierID.EMailID, oPO.FK_PAK_SupplierID.BPName)
                .CC.Add(New MailAddress(oPO.FK_PAK_SupplierID.EMailID, oPO.FK_PAK_SupplierID.BPName))
              End If
              'End of Supplier ID
            Catch ex As Exception
              .From = New MailAddress("baansupport@isgec.co.in", "BaaN Support")
              .CC.Add(New MailAddress("baansupport@isgec.co.in", "BaaN Support"))
              .CC.Add(New MailAddress("harishkumar@isgec.co.in", "Harish Kumar"))
            End Try
            'To Issuer
            Try
              If oPO.FK_PAK_PO_IssuedBy.EMailID = String.Empty Then
                aErr.Add(oPO.IssuedBy & " " & oPO.FK_PAK_PO_IssuedBy.UserFullName)
                .To.Add(New MailAddress("baansupport@isgec.co.in", "BaaN Support"))
              Else
                .To.Add(New MailAddress(oPO.FK_PAK_PO_IssuedBy.EMailID, oPO.FK_PAK_PO_IssuedBy.UserFullName))
              End If
              'Include Buyer
              If oPO.FK_PAK_PO_BuyerID.EMailID = String.Empty Then
                aErr.Add(oPO.BuyerID & " " & oPO.FK_PAK_PO_BuyerID.UserFullName)
                .CC.Add(New MailAddress("baansupport@isgec.co.in", "BaaN Support"))
              Else
                If Not Convert.ToBoolean(ConfigurationManager.AppSettings("Testing")) Then
                  .CC.Add(New MailAddress(oPO.FK_PAK_PO_BuyerID.EMailID, oPO.FK_PAK_PO_BuyerID.UserFullName))
                End If
              End If
            Catch ex As Exception
              .To.Add(New MailAddress("baansupport@isgec.co.in", "BaaN Support"))
              .CC.Add(New MailAddress("harishkumar@isgec.co.in", "Harish Kumar"))
            End Try
            'End of Buyer
            If AlertEvent = pakAlertEvents.POClosed Then
              .Subject = "Closed Purchase Order No.: " & oPO.PONumber
            ElseIf AlertEvent = pakAlertEvents.OpenPORequested Then
              .Subject = "Request to Re-Open Purchase Order No.: " & oPO.PONumber
            ElseIf AlertEvent = pakAlertEvents.POApproval Then
              .Subject = "Approve Purchase Order No.: " & oPO.PONumber
            Else
              .Subject = "Material / Document Despatched for Purchase Order No.: " & oPO.PONumber
            End If
        End Select

        'Add Project wise Alert Group in CC
        Dim Users As List(Of SIS.EITL.eitlProjectWiseUser) = SIS.EITL.eitlProjectWiseUser.GetByProjectID(oPO.ProjectID, "")
        For Each usr As SIS.EITL.eitlProjectWiseUser In Users
          Try
            Dim ad As MailAddress = New MailAddress(usr.FK_EITL_ProjectWiseUser_UserID.EMailID, usr.FK_EITL_ProjectWiseUser_UserID.UserFullName)
            If Not .CC.Contains(ad) Then
              .CC.Add(ad)
            End If
          Catch ex As Exception
            aErr.Add(usr.UserID & " " & usr.FK_EITL_ProjectWiseUser_UserID.UserFullName)
          End Try
        Next
        'End of Add Project Users
      End With
      With oMsg
        If .To.Count <= 0 Then
          .To.Add(New MailAddress("baansupport@isgec.co.in", "BaaN Support"))
        End If
        .IsBodyHtml = True
        Dim oTbl As Table = GetPOTable(oPO, AlertEvent)
        Dim sb As StringBuilder = New StringBuilder()
        Dim sw As IO.StringWriter = New IO.StringWriter(sb)
        Dim writer As HtmlTextWriter = New HtmlTextWriter(sw)
        Try
          oTbl.RenderControl(writer)
          sb.Append("<br /><br />")
        Catch ex As Exception

        End Try
        If AlertEvent = pakAlertEvents.DocumentsDespatched Or AlertEvent = pakAlertEvents.MaterialDespatched Then
          'oTbl = GetDocumentTable(oPO)
          'Try
          '  oTbl.RenderControl(writer)
          '  sb.Append("<br /><br />")
          'Catch ex As Exception
          'End Try
          oTbl = GetItemTable(oPO)
          Try
            oTbl.RenderControl(writer)
            sb.Append("<br /><br />")
          Catch ex As Exception
          End Try
        End If

        Dim Header As String = ""
        Header = Header & "<html xmlns=""http://www.w3.org/1999/xhtml"">"
        Header = Header & "<head>"
        Header = Header & "<title></title>"
        Header = Header & "<style>"
        Header = Header & "body{margin: 10px auto auto 60px;}"
        Header = Header & ".tblHd, .tblHd td{font-size: 12px;font-weight: bold;height: 30px !important;background-color:lightgray;}"
        Header = Header & "table{"
        Header = Header & "border: solid 1pt black;"
        Header = Header & "border-collapse:collapse;"
        Header = Header & "font-family: Tahoma;}"

        Header = Header & "td{padding-left: 4px;"
        Header = Header & "border: solid 1pt black;"
        Header = Header & "font-family: Tahoma;"
        Header = Header & "font-size: 9px;"
        Header = Header & "vertical-align:top;}"

        Header = Header & "</style>"
        Header = Header & "</head>"
        Header = Header & "<body>"
        If aErr.Count > 0 Then
          Header = Header & "<table>"
          Header = Header & "<tr><td style=""color: red""><i><b>"
          Header = Header & "NOTE: E-Mail Alert could not be delivered to following recipient(s), Please update their E-Mail ID in EITL Application."
          Header = Header & "</b></i></td></tr>"
          For Each Err As String In aErr
            Header = Header & "<tr><td color=""red""><i>"
            Header = Header & Err
            Header = Header & "</i></td></tr>"
          Next
          Header = Header & "</table>"
        End If
        If AlertEvent = pakAlertEvents.OpenPORequested Then
          'Header = Header & "<br /><table>"
          'Header = Header & "<tr><td><b>"
          'Header = Header & "REASON TO RE-OPEN"
          'Header = Header & "</b></td></tr>"
          'Header = Header & "<tr><td>"
          'Header = Header & oRQ.Remarks
          'Header = Header & "</td></tr>"
          'Header = Header & "</table>"
        ElseIf AlertEvent = pakAlertEvents.OpenPORequestExecuted Then
          ''If Not oRQ.ExecutedToOpen Then
          ''  Header = Header & "<br /><table>"
          ''  Header = Header & "<tr><td><b>"
          ''  Header = Header & "REASON TO RE-OPEN"
          ''  Header = Header & "</b></td></tr>"
          ''  Header = Header & "<tr><td>"
          ''  Header = Header & oRQ.ExecuterRemarks
          ''  Header = Header & "</td></tr>"
          ''  Header = Header & "</table>"
          ''End If
        End If
        Header = Header & sb.ToString
        Header = Header & "</body></html>"
        .Body = Header
      End With
      Try
        oClient.Send(oMsg)
      Catch ex As Exception
      End Try
      Return True
    End Function
    Public Shared Function GetItemTable(ByVal oPO As SIS.PAK.pakPO) As Table
      Dim oTbl As New Table
      oTbl.GridLines = GridLines.Both
      oTbl.Width = 900
      oTbl.Style.Add("text-align", "left")
      oTbl.Style.Add("font", "Tahoma")
      oTbl.Style("margin-top") = "10px"

      Dim oCol As TableCell = Nothing
      Dim oRow As TableRow = Nothing

      Dim pakPOBOMLists As List(Of SIS.PAK.pakPOBOM) = SIS.PAK.pakPOBOM.pakPOBOMSelectList(0, 9999, "", False, "", oPO.SerialNo)
      oRow = New TableRow
      oRow.CssClass = "tblHd"
      oCol = New TableCell
      oCol.Text = "Item Code"
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = "Description"
      oRow.Cells.Add(oCol)
      'oCol = New TableCell
      'oCol.Text = "UOM"
      'oRow.Cells.Add(oCol)
      'oCol = New TableCell
      'oCol.Text = "Quantity"
      'oRow.Cells.Add(oCol)
      'oCol = New TableCell
      'oCol.Text = "Weight In KG"
      'oRow.Cells.Add(oCol)
      'oCol = New TableCell
      'oCol.Text = "Document ID"
      'oRow.Cells.Add(oCol)
      'oCol = New TableCell
      'oCol.Text = "Despatched"
      'oRow.Cells.Add(oCol)
      'oCol = New TableCell
      'oCol.Text = "Despatch Date"
      'oRow.Cells.Add(oCol)
      oTbl.Rows.Add(oRow)
      For Each pakpoBom As SIS.PAK.pakPOBOM In pakPOBOMLists
        With pakpoBom
          oRow = New TableRow
          oCol = New TableCell
          oCol.Text = .ItemCode
          oRow.Cells.Add(oCol)
          oCol = New TableCell
          oCol.Text = .ItemDescription
          oRow.Cells.Add(oCol)
          'oCol = New TableCell
          'oCol.Text = oeitlPOItemList.UOM
          'oRow.Cells.Add(oCol)
          'oCol = New TableCell
          'oCol.Text = oeitlPOItemList.Quantity
          'oRow.Cells.Add(oCol)
          'oCol = New TableCell
          'oCol.Text = oeitlPOItemList.WeightInKG
          'oRow.Cells.Add(oCol)
          'oCol = New TableCell
          'oCol.Text = oeitlPOItemList.EITL_PODocumentList3_DocumentID
          'oRow.Cells.Add(oCol)
          'oCol = New TableCell
          'oCol.Text = IIf(oeitlPOItemList.Despatched, "YES", "NO")
          'oRow.Cells.Add(oCol)
          'oCol = New TableCell
          'oCol.Text = oeitlPOItemList.DespatchDate
          'oRow.Cells.Add(oCol)
          oTbl.Rows.Add(oRow)
        End With
      Next

      Return oTbl
    End Function
    'Public Shared Function GetDocumentTable(ByVal opo As SIS.EITL.eitlPOList) As Table
    '  Dim oeitlPODocumentLists As List(Of SIS.EITL.eitlPODocumentList) = SIS.EITL.eitlPODocumentList.eitlPODocumentListSelectList(0, 9999, "", False, "", opo.SerialNo)
    '  Dim oTbl As New Table
    '  oTbl.GridLines = GridLines.Both
    '  oTbl.Width = 900
    '  oTbl.Style.Add("text-align", "left")
    '  oTbl.Style.Add("font", "Tahoma")
    '  oTbl.Style("margin-top") = "10px"

    '  Dim oCol As TableCell = Nothing
    '  Dim oRow As TableRow = Nothing

    '  oRow = New TableRow
    '  oRow.CssClass = "tblHd"
    '  oCol = New TableCell
    '  oCol.Text = "Document ID"
    '  oCol.Width = 300
    '  oRow.Cells.Add(oCol)
    '  oCol = New TableCell
    '  oCol.Text = "Revision No"
    '  oCol.Width = 100
    '  oRow.Cells.Add(oCol)
    '  oCol = New TableCell
    '  oCol.Text = "Description"
    '  oCol.Width = 450
    '  oRow.Cells.Add(oCol)
    '  oCol = New TableCell
    '  oCol.Text = "File Attached"
    '  oCol.Width = 50
    '  oRow.Cells.Add(oCol)
    '  oTbl.Rows.Add(oRow)
    '  For Each oeitlPODocumentList As SIS.EITL.eitlPODocumentList In oeitlPODocumentLists
    '    oRow = New TableRow
    '    oCol = New TableCell
    '    oCol.Text = oeitlPODocumentList.DocumentID
    '    oRow.Cells.Add(oCol)
    '    oCol = New TableCell
    '    oCol.Text = oeitlPODocumentList.RevisionNo
    '    oRow.Cells.Add(oCol)
    '    oCol = New TableCell
    '    oCol.Text = oeitlPODocumentList.Description
    '    oRow.Cells.Add(oCol)
    '    oCol = New TableCell
    '    Dim oFiles As List(Of SIS.EITL.eitlPODocumentFile) = SIS.EITL.eitlPODocumentFile.eitlPODocumentFileSelectList(0, 1, "", False, "", oeitlPODocumentList.SerialNo, oeitlPODocumentList.DocumentLineNo)
    '    If oFiles.Count > 0 Then
    '      If oFiles(0).DiskFile <> String.Empty Then
    '        oCol.Text = "YES"
    '      Else
    '        oCol.Text = "NO"
    '      End If
    '    Else
    '      oCol.Text = "NO"
    '    End If
    '    oRow.Cells.Add(oCol)
    '    oTbl.Rows.Add(oRow)
    '  Next
    '  Return oTbl
    'End Function
    Public Shared Function GetPOTable(ByVal oPO As SIS.PAK.pakPO, ByVal AlertEvent As pakAlertEvents, Optional ByVal IncludeAuthorization As Boolean = False) As Table

      Dim oTbl As New Table
      oTbl.GridLines = GridLines.Both
      oTbl.Width = 900
      oTbl.Style.Add("text-align", "left")
      oTbl.Style.Add("font", "Tahoma")

      Dim oCol As TableCell = Nothing
      Dim oRow As TableRow = Nothing
      '1.
      oRow = New TableRow
      oCol = New TableCell
      oCol.ColumnSpan = "6"
      oCol.Text = "Purchase Order Detail"
      oCol.Style.Add("text-align", "center")
      oCol.Style.Add("border-bottom", "none")
      oCol.Font.Size = "14"
      oRow.Cells.Add(oCol)
      oTbl.Rows.Add(oRow)
      '2.
      Select Case AlertEvent
        Case pakAlertEvents.POIssued, pakAlertEvents.POVerification
          oRow = New TableRow
          oCol = New TableCell
          oCol.ColumnSpan = "6"
          oCol.Text = "Dear Supplier, <br /><br /> Purchase Order No.: " & oPO.PONumber & " issued to you from ISGEC, is available online to update Items and Documents information."
          If IncludeAuthorization Then
            oCol.Text &= "<br /><b>URL:</b> http://cloud.isgec.co.in/WebEitl1"
            oCol.Text &= "<br /><b>User ID:</b> " & oPO.SupplierID.Substring(1, 8)
            oCol.Text &= "<br /><b>Password:</b> " & SIS.QCM.qcmUsers.qcmUsersGetByID(oPO.SupplierID.Substring(1, 8)).PW
          Else
            oCol.Text &= "<br />Login ID & Password has been sent separately."
          End If
          oCol.Style.Add("text-align", "left")
          oCol.Style.Add("border-bottom", "none")
          oCol.Font.Size = "10"
          oRow.Cells.Add(oCol)
          oTbl.Rows.Add(oRow)
        Case pakAlertEvents.POApproval
          oRow = New TableRow
          oCol = New TableCell
          oCol.ColumnSpan = "6"
          oCol.Text = "<br /><br /> Purchase Order No.: " & oPO.PONumber & " is verified by supplier, and submitted for approval."
          oCol.Style.Add("text-align", "left")
          oCol.Style.Add("border-bottom", "none")
          oCol.Font.Size = "10"
          oRow.Cells.Add(oCol)
          oTbl.Rows.Add(oRow)
      End Select
      '3.
      oTbl.Width = 900
      oTbl.BorderStyle = BorderStyle.Solid
      oTbl.BorderColor = Drawing.Color.Black
      oTbl.BorderWidth = 2
      oRow = New TableRow
      oCol = New TableCell
      oCol.Text = "Serial No"
      oCol.Font.Bold = True
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = oPO.SerialNo
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = ""
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = "PO Number"
      oCol.Font.Bold = True
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = oPO.PONumber
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = ""
      oRow.Cells.Add(oCol)
      oTbl.Rows.Add(oRow)
      oRow = New TableRow
      oCol = New TableCell
      oCol.Text = "PO Revision"
      oCol.Font.Bold = True
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = oPO.PORevision
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = ""
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = "PO Date"
      oCol.Font.Bold = True
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = oPO.PODate
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = ""
      oRow.Cells.Add(oCol)
      oTbl.Rows.Add(oRow)
      oRow = New TableRow
      oCol = New TableCell
      oCol.Text = "Supplier"
      oCol.Font.Bold = True
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = oPO.SupplierID
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = oPO.VR_BusinessPartner9_BPName
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = "Project"
      oCol.Font.Bold = True
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = oPO.ProjectID
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = oPO.IDM_Projects4_Description
      oRow.Cells.Add(oCol)
      oTbl.Rows.Add(oRow)
      oRow = New TableRow
      oCol = New TableCell
      oCol.Text = "Division"
      oCol.Font.Bold = True
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = oPO.DivisionID
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = ""
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = "Buyer"
      oCol.Font.Bold = True
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = oPO.BuyerID
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = oPO.aspnet_Users1_UserFullName
      oRow.Cells.Add(oCol)
      oTbl.Rows.Add(oRow)
      oRow = New TableRow
      oCol = New TableCell
      oCol.Text = "POStatus"
      oCol.Font.Bold = True
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = oPO.POStatusID
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = oPO.PAK_POStatus6_Description
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = "Issued By"
      oCol.Font.Bold = True
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = oPO.IssuedBy
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = oPO.aspnet_Users2_UserFullName
      oRow.Cells.Add(oCol)
      oTbl.Rows.Add(oRow)
      oRow = New TableRow
      oCol = New TableCell
      oCol.Text = "Issued On"
      oCol.Font.Bold = True
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = oPO.IssuedOn
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = ""
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = "Closed By"
      oCol.Font.Bold = True
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = oPO.ClosedBy
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = oPO.aspnet_Users3_UserFullName
      oRow.Cells.Add(oCol)
      oTbl.Rows.Add(oRow)
      oRow = New TableRow
      oCol = New TableCell
      oCol.Text = "Closed On"
      oCol.Font.Bold = True
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = oPO.ClosedOn
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = ""
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = ""
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = ""
      oRow.Cells.Add(oCol)
      oTbl.Rows.Add(oRow)
      Return oTbl
    End Function
    Public Shared Function GetTCPOTable(ByVal oPO As SIS.PAK.pakTCPO, ByVal AlertEvent As pakTCAlertEvents, Optional ByVal IncludeAuthorization As Boolean = False) As Table

      Dim oTbl As New Table
      oTbl.GridLines = GridLines.Both
      oTbl.Width = 900
      oTbl.Style.Add("text-align", "left")
      oTbl.Style.Add("font", "Tahoma")

      Dim oCol As TableCell = Nothing
      Dim oRow As TableRow = Nothing
      '1.
      oRow = New TableRow
      oCol = New TableCell
      oCol.ColumnSpan = "6"
      oCol.Text = "Purchase Order Detail"
      oCol.Style.Add("text-align", "center")
      oCol.Style.Add("border-bottom", "none")
      oCol.Font.Size = "14"
      oRow.Cells.Add(oCol)
      oTbl.Rows.Add(oRow)
      '2.
      Select Case AlertEvent
        Case pakTCAlertEvents.TCPOIssued
          oRow = New TableRow
          oCol = New TableCell
          oCol.ColumnSpan = "6"
          oCol.Text = "Dear Supplier, <br /><br /> Purchase Order No.: " & oPO.PONumber & " issued to you from ISGEC, is available online to submit documents for technical clearance."
          If IncludeAuthorization Then
            oCol.Text &= "<br /><b>URL:</b> http://cloud.isgec.co.in/WebEitl1"
            oCol.Text &= "<br /><b>User ID:</b> " & oPO.SupplierID.Substring(1, 8)
            oCol.Text &= "<br /><b>Password:</b> " & SIS.QCM.qcmUsers.qcmUsersGetByID(oPO.SupplierID.Substring(1, 8)).PW
          Else
            oCol.Text &= "<br />Login ID & Password has been sent separately."
          End If
          oCol.Style.Add("text-align", "left")
          oCol.Style.Add("border-bottom", "none")
          oCol.Font.Size = "10"
          oRow.Cells.Add(oCol)
          oTbl.Rows.Add(oRow)
        Case pakTCAlertEvents.DocumentsSubmitted
          oRow = New TableRow
          oCol = New TableCell
          oCol.ColumnSpan = "6"
          oCol.Text = "<br /><br /> Documents submitted by supplier for technical clearance."
          oCol.Style.Add("text-align", "left")
          oCol.Style.Add("border-bottom", "none")
          oCol.Font.Size = "10"
          oRow.Cells.Add(oCol)
          oTbl.Rows.Add(oRow)
      End Select
      '3.
      oTbl.Width = 900
      oTbl.BorderStyle = BorderStyle.Solid
      oTbl.BorderColor = Drawing.Color.Black
      oTbl.BorderWidth = 2
      oRow = New TableRow
      oCol = New TableCell
      oCol.Text = "Serial No"
      oCol.Font.Bold = True
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = oPO.SerialNo
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = ""
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = "PO Number"
      oCol.Font.Bold = True
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = oPO.PONumber
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = ""
      oRow.Cells.Add(oCol)
      oTbl.Rows.Add(oRow)
      oRow = New TableRow
      oCol = New TableCell
      oCol.Text = "PO Revision"
      oCol.Font.Bold = True
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = oPO.PORevision
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = ""
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = "PO Date"
      oCol.Font.Bold = True
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = oPO.PODate
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = ""
      oRow.Cells.Add(oCol)
      oTbl.Rows.Add(oRow)
      oRow = New TableRow
      oCol = New TableCell
      oCol.Text = "Supplier"
      oCol.Font.Bold = True
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = oPO.SupplierID
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = oPO.VR_BusinessPartner9_BPName
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = "Project"
      oCol.Font.Bold = True
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = oPO.ProjectID
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = oPO.IDM_Projects4_Description
      oRow.Cells.Add(oCol)
      oTbl.Rows.Add(oRow)
      oRow = New TableRow
      oCol = New TableCell
      oCol.Text = "Division"
      oCol.Font.Bold = True
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = oPO.DivisionID
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = ""
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = "Buyer"
      oCol.Font.Bold = True
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = oPO.BuyerID
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = oPO.aspnet_Users1_UserFullName
      oRow.Cells.Add(oCol)
      oTbl.Rows.Add(oRow)
      oRow = New TableRow
      oCol = New TableCell
      oCol.Text = "POStatus"
      oCol.Font.Bold = True
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = oPO.POStatusID
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = oPO.PAK_POStatus6_Description
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = "Issued By"
      oCol.Font.Bold = True
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = oPO.IssuedBy
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = oPO.aspnet_Users2_UserFullName
      oRow.Cells.Add(oCol)
      oTbl.Rows.Add(oRow)
      oRow = New TableRow
      oCol = New TableCell
      oCol.Text = "Issued On"
      oCol.Font.Bold = True
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = oPO.IssuedOn
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = ""
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = "Closed By"
      oCol.Font.Bold = True
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = oPO.ClosedBy
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = oPO.aspnet_Users3_UserFullName
      oRow.Cells.Add(oCol)
      oTbl.Rows.Add(oRow)
      oRow = New TableRow
      oCol = New TableCell
      oCol.Text = "Closed On"
      oCol.Font.Bold = True
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = oPO.ClosedOn
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = ""
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = ""
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = ""
      oRow.Cells.Add(oCol)
      oTbl.Rows.Add(oRow)
      Return oTbl
    End Function
    Public Shared Function GetTCItemTable(ByVal oPO As SIS.PAK.pakTCPO, Optional ByVal ItemNo As Integer = 0) As Table
      Dim oTbl As New Table
      oTbl.GridLines = GridLines.Both
      oTbl.Width = 900
      oTbl.Style.Add("text-align", "left")
      oTbl.Style.Add("font", "Tahoma")
      oTbl.Style("margin-top") = "10px"

      Dim oCol As TableCell = Nothing
      Dim oRow As TableRow = Nothing

      Dim TCPOL As List(Of SIS.PAK.pakTCPOL) = SIS.PAK.pakTCPOL.pakTCPOLSelectList(0, 9999, "", False, "", oPO.SerialNo)
      oRow = New TableRow
      oRow.CssClass = "tblHd"
      oCol = New TableCell
      oCol.Text = "Item Code"
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = "Description"
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = "UOM"
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = "Quantity"
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = "Element"
      oRow.Cells.Add(oCol)
      oTbl.Rows.Add(oRow)
      For Each itm As SIS.PAK.pakTCPOL In TCPOL
        If ItemNo <> 0 Then
          If itm.ItemNo <> ItemNo Then
            Continue For
          End If
        End If
        With itm
          oRow = New TableRow
          oCol = New TableCell
          oCol.Text = .ItemCode
          oRow.Cells.Add(oCol)
          oCol = New TableCell
          oCol.Text = .ItemDescription
          oRow.Cells.Add(oCol)
          oCol = New TableCell
          oCol.Text = .ItemUnit
          oRow.Cells.Add(oCol)
          oCol = New TableCell
          oCol.Text = .ItemQuantity
          oRow.Cells.Add(oCol)
          oCol = New TableCell
          oCol.Text = .ItemElement
          oRow.Cells.Add(oCol)
          oTbl.Rows.Add(oRow)
        End With
      Next
      Return oTbl
    End Function
    Public Shared Function GetTCUploadTable(ByVal SerialNo As Integer, ByVal ItemNo As Integer, ByVal UploadNo As Integer) As Table
      Dim tmpDocs As List(Of SIS.PAK.pakSTCPOLRD) = SIS.PAK.pakSTCPOLRD.pakSTCPOLRDSelectList(0, 9999, "", False, "", SerialNo, ItemNo, UploadNo)
      Dim oTbl As New Table
      oTbl.GridLines = GridLines.Both
      oTbl.Width = 900
      oTbl.Style.Add("text-align", "left")
      oTbl.Style.Add("font", "Tahoma")
      oTbl.Style("margin-top") = "10px"

      Dim oCol As TableCell = Nothing
      Dim oRow As TableRow = Nothing

      oRow = New TableRow
      oRow.CssClass = "tblHd"
      oCol = New TableCell
      oCol.Text = "Document ID"
      oCol.Width = 300
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = "Revision No"
      oCol.Width = 100
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = "Description"
      oCol.Width = 450
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = "File Attached"
      oCol.Width = 50
      oRow.Cells.Add(oCol)
      oTbl.Rows.Add(oRow)
      For Each tmp As SIS.PAK.pakSTCPOLRD In tmpDocs
        oRow = New TableRow
        oCol = New TableCell
        oCol.Text = tmp.DocumentID
        oRow.Cells.Add(oCol)
        oCol = New TableCell
        oCol.Text = tmp.DocumentRev
        oRow.Cells.Add(oCol)
        oCol = New TableCell
        oCol.Text = tmp.DocumentDescription
        oRow.Cells.Add(oCol)
        oCol = New TableCell
        oRow.Cells.Add(oCol)
        oCol.Text = tmp.FileName
        oTbl.Rows.Add(oRow)
      Next
      Return oTbl
    End Function
  End Class
End Namespace
