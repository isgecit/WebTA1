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
Namespace SIS.EITL
  Public Class Alerts
    Public Shared Function Alert(ByVal PONo As Integer, ByVal AlertEvent As SIS.EITL.AlertEvents) As Boolean
      Dim oPO As SIS.EITL.eitlPOList = Nothing
      Dim oRQ As SIS.EITL.eitlPOOpenRequest = Nothing
      Select Case AlertEvent
        Case AlertEvents.OpenPORequested, AlertEvents.OpenPORequestExecuted
          oRQ = SIS.EITL.eitlPOOpenRequest.eitlPOOpenRequestGetByID(PONo)
          oPO = SIS.EITL.eitlPOList.eitlPOListGetByID(oRQ.SerialNo)
        Case Else
          oPO = SIS.EITL.eitlPOList.eitlPOListGetByID(PONo)
      End Select
      Dim aErr As New ArrayList
      Dim mRet As String = ""
      Dim oClient As SmtpClient = New SmtpClient("192.9.200.214", 25)
      oClient.Credentials = New Net.NetworkCredential("adskvaultadmin", "isgec@123")
      Dim oMsg As System.Net.Mail.MailMessage = New System.Net.Mail.MailMessage()
      With oMsg
        Select Case AlertEvent
          Case AlertEvents.POIssued, AlertEvents.OpenPORequestExecuted
            'FROM Buyer
            Try
              If oPO.FK_EITL_POList_BuyerID.EMailID = String.Empty Then
                aErr.Add(oPO.BuyerID & " " & oPO.FK_EITL_POList_BuyerID.UserFullName)
                .From = New MailAddress("baansupport@isgec.co.in", "BaaN Support")
                .CC.Add(New MailAddress("baansupport@isgec.co.in", "BaaN Support"))
              Else
                .From = New MailAddress(oPO.FK_EITL_POList_BuyerID.EMailID, oPO.FK_EITL_POList_BuyerID.UserFullName)
                .CC.Add(New MailAddress(oPO.FK_EITL_POList_BuyerID.EMailID, oPO.FK_EITL_POList_BuyerID.UserFullName))
              End If
              .CC.Add(New MailAddress("harishkumar@isgec.co.in", "Harish Kumar"))

            Catch ex As Exception
              .From = New MailAddress("baansupport@isgec.co.in", "BaaN Support")
              .CC.Add(New MailAddress("baansupport@isgec.co.in", "BaaN Support"))
              .CC.Add(New MailAddress("harishkumar@isgec.co.in", "Harish Kumar"))
            End Try
            'TO Supplier
            If oPO.FK_EITL_POList_SupplierID.EMailID = String.Empty Then
              aErr.Add(oPO.SupplierID & " " & oPO.FK_EITL_POList_SupplierID.SupplierName)
              .To.Add(New MailAddress("baansupport@isgec.co.in", "BaaN Support"))
            Else
              '.To.Add(New MailAddress(oPO.FK_EITL_POList_SupplierID.EMailID, oPO.FK_EITL_POList_BuyerID.UserFullName))
              .To.Add(New MailAddress("lalit@isgec.co.in", "Lalit Gupta"))
            End If
            'End of Supplier ID
            If AlertEvent = AlertEvents.POIssued Then
              .Subject = "Issued Purchase Order No.: " & oPO.PONumber
            Else
              If oRQ.ExecutedToOpen Then
                .Subject = "Re-Opened Purchase Order No.: " & oPO.PONumber
              Else
                .Subject = "Purchase Order Not Opened.: " & oPO.PONumber
              End If
            End If
          Case AlertEvents.MaterialDespatched, AlertEvents.DocumentsDespatched, AlertEvents.POClosed, AlertEvents.OpenPORequested
            'From Supplier
            Try
              If oPO.FK_EITL_POList_SupplierID.EMailID = String.Empty Then
                aErr.Add(oPO.SupplierID & " " & oPO.FK_EITL_POList_SupplierID.SupplierName)
                .From = New MailAddress("baansupport@isgec.co.in", "BaaN Support")
                .CC.Add(New MailAddress("baansupport@isgec.co.in", "BaaN Support"))
              Else
                '.From = New MailAddress(oPO.FK_EITL_POList_SupplierID.EMailID, oPO.FK_EITL_POList_BuyerID.UserFullName)
                '.CC.Add(New MailAddress(oPO.FK_EITL_POList_SupplierID.EMailID, oPO.FK_EITL_POList_BuyerID.UserFullName))
                .From = New MailAddress("lalit@isgec.co.in", "Lalit Gupta")
                .CC.Add(New MailAddress("lalit@isgec.co.in", "Lalit Gupta"))
              End If
              'End of Supplier ID
            Catch ex As Exception
              .From = New MailAddress("baansupport@isgec.co.in", "BaaN Support")
              .CC.Add(New MailAddress("baansupport@isgec.co.in", "BaaN Support"))
              .CC.Add(New MailAddress("harishkumar@isgec.co.in", "Harish Kumar"))
            End Try
            'To Buyer
            Try
              If oPO.FK_EITL_POList_BuyerID.EMailID = String.Empty Then
                aErr.Add(oPO.BuyerID & " " & oPO.FK_EITL_POList_BuyerID.UserFullName)
                .To.Add(New MailAddress("baansupport@isgec.co.in", "BaaN Support"))
                .CC.Add(New MailAddress("baansupport@isgec.co.in", "BaaN Support"))
              Else
                .To.Add(New MailAddress(oPO.FK_EITL_POList_BuyerID.EMailID, oPO.FK_EITL_POList_BuyerID.UserFullName))
              End If
              .CC.Add(New MailAddress("harishkumar@isgec.co.in", "Harish Kumar"))
            Catch ex As Exception
              .To.Add(New MailAddress("baansupport@isgec.co.in", "BaaN Support"))
              .CC.Add(New MailAddress("harishkumar@isgec.co.in", "Harish Kumar"))
            End Try
            'End of Buyer
            If AlertEvent = AlertEvents.POClosed Then
              .Subject = "Closed Purchase Order No.: " & oPO.PONumber
            ElseIf AlertEvent = AlertEvents.OpenPORequested Then
              .Subject = "Request to Re-Open Purchase Order No.: " & oPO.PONumber
            Else
              .Subject = "Material / Document Despatched for Purchase Order No.: " & oPO.PONumber
            End If
        End Select
        .CC.Add(New MailAddress("lalit@isgec.co.in", "Lalit Gupta"))

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
        Dim strTbl As String = ""
        Dim sb As StringBuilder = New StringBuilder()
        Dim sw As IO.StringWriter = New IO.StringWriter(sb)
        Dim writer As HtmlTextWriter = New HtmlTextWriter(sw)
        Try
          oTbl.RenderControl(writer)
        Catch ex As Exception

        End Try
        strTbl = sb.ToString
        sb.Append("<br /><br />")
        If AlertEvent = AlertEvents.DocumentsDespatched Or AlertEvent = AlertEvents.MaterialDespatched Then
          oTbl = GetDocumentTable(oPO)
          Try
            oTbl.RenderControl(writer)
          Catch ex As Exception
          End Try
          strTbl = strTbl & "<br /><br />" & sb.ToString

          sb.Append("<br /><br />")
          oTbl = GetItemTable(oPO)
          Try
            oTbl.RenderControl(writer)
          Catch ex As Exception
          End Try
          strTbl = strTbl & "<br /><br />" & sb.ToString
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
        If AlertEvent = AlertEvents.OpenPORequested Then
          Header = Header & "<br /><table>"
          Header = Header & "<tr><td><b>"
          Header = Header & "REASON TO RE-OPEN"
          Header = Header & "</b></td></tr>"
          Header = Header & "<tr><td>"
          Header = Header & oRQ.Remarks
          Header = Header & "</td></tr>"
          Header = Header & "</table>"
        ElseIf AlertEvent = AlertEvents.OpenPORequestExecuted Then
          If Not oRQ.ExecutedToOpen Then
            Header = Header & "<br /><table>"
            Header = Header & "<tr><td><b>"
            Header = Header & "REASON TO RE-OPEN"
            Header = Header & "</b></td></tr>"
            Header = Header & "<tr><td>"
            Header = Header & oRQ.ExecuterRemarks
            Header = Header & "</td></tr>"
            Header = Header & "</table>"
          End If
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
    Public Shared Function GetItemTable(ByVal opo As SIS.EITL.eitlPOList) As Table
      Dim oTbl As New Table
      oTbl.GridLines = GridLines.Both
      oTbl.Width = 900
      oTbl.Style.Add("text-align", "left")
      oTbl.Style.Add("font", "Tahoma")
      oTbl.Style("margin-top") = "10px"

      Dim oCol As TableCell = Nothing
      Dim oRow As TableRow = Nothing

      Dim oeitlPOItemLists As List(Of SIS.EITL.eitlPOItemList) = SIS.EITL.eitlPOItemList.eitlPOItemListSelectList(0, 9999, "", False, "", opo.SerialNo)
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
      oCol.Text = "Weight In KG"
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = "Document ID"
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = "Despatched"
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = "Despatch Date"
      oRow.Cells.Add(oCol)
      oTbl.Rows.Add(oRow)
      For Each oeitlPOItemList As SIS.EITL.eitlPOItemList In oeitlPOItemLists
        oRow = New TableRow
        oCol = New TableCell
        oCol.Text = oeitlPOItemList.ItemCode
        oRow.Cells.Add(oCol)
        oCol = New TableCell
        oCol.Text = oeitlPOItemList.Description
        oRow.Cells.Add(oCol)
        oCol = New TableCell
        oCol.Text = oeitlPOItemList.UOM
        oRow.Cells.Add(oCol)
        oCol = New TableCell
        oCol.Text = oeitlPOItemList.Quantity
        oRow.Cells.Add(oCol)
        oCol = New TableCell
        oCol.Text = oeitlPOItemList.WeightInKG
        oRow.Cells.Add(oCol)
        oCol = New TableCell
        oCol.Text = oeitlPOItemList.EITL_PODocumentList3_DocumentID
        oRow.Cells.Add(oCol)
        oCol = New TableCell
        oCol.Text = IIf(oeitlPOItemList.Despatched, "YES", "NO")
        oRow.Cells.Add(oCol)
        oCol = New TableCell
        oCol.Text = oeitlPOItemList.DespatchDate
        oRow.Cells.Add(oCol)
        oTbl.Rows.Add(oRow)
      Next


      Return oTbl
    End Function
    Public Shared Function GetDocumentTable(ByVal opo As SIS.EITL.eitlPOList) As Table
      Dim oeitlPODocumentLists As List(Of SIS.EITL.eitlPODocumentList) = SIS.EITL.eitlPODocumentList.eitlPODocumentListSelectList(0, 9999, "", False, "", opo.SerialNo)
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
      For Each oeitlPODocumentList As SIS.EITL.eitlPODocumentList In oeitlPODocumentLists
        oRow = New TableRow
        oCol = New TableCell
        oCol.Text = oeitlPODocumentList.DocumentID
        oRow.Cells.Add(oCol)
        oCol = New TableCell
        oCol.Text = oeitlPODocumentList.RevisionNo
        oRow.Cells.Add(oCol)
        oCol = New TableCell
        oCol.Text = oeitlPODocumentList.Description
        oRow.Cells.Add(oCol)
        oCol = New TableCell
        Dim oFiles As List(Of SIS.EITL.eitlPODocumentFile) = SIS.EITL.eitlPODocumentFile.eitlPODocumentFileSelectList(0, 1, "", False, "", oeitlPODocumentList.SerialNo, oeitlPODocumentList.DocumentLineNo)
        If oFiles.Count > 0 Then
          If oFiles(0).DiskFile <> String.Empty Then
            oCol.Text = "YES"
          Else
            oCol.Text = "NO"
          End If
        Else
          oCol.Text = "NO"
        End If
        oRow.Cells.Add(oCol)
        oTbl.Rows.Add(oRow)
      Next
      Return oTbl
    End Function
    Public Shared Function GetPOTable(ByVal opo As SIS.EITL.eitlPOList, ByVal AlertEvent As SIS.EITL.AlertEvents) As Table

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
      If AlertEvent = AlertEvents.POIssued Then
        oRow = New TableRow
        oCol = New TableCell
        oCol.ColumnSpan = "6"
        oCol.Text = "Dear Supplier, <br /><br /> Purchase Order No.: " & opo.PONumber & " issued to you from ISGEC, is available online to update Items and Documents information." & _
          "<br /><b>URL:</b> http://cloud.isgec.co.in" & _
          "<br /><b>User ID:</b> " & opo.SupplierID.Substring(1) & _
          "<br /><b>Password:</b> " & SIS.QCM.qcmUsers.qcmUsersGetByID(opo.SupplierID.Substring(1)).MobileNo

        oCol.Style.Add("text-align", "left")
        oCol.Style.Add("border-bottom", "none")
        oCol.Font.Size = "10"
        oRow.Cells.Add(oCol)
        oTbl.Rows.Add(oRow)
      End If
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
      oCol.Text = opo.SerialNo
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = ""
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = "PO Number"
      oCol.Font.Bold = True
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = opo.PONumber
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
      oCol.Text = opo.PORevision
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = ""
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = "PO Date"
      oCol.Font.Bold = True
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = opo.PODate
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
      oCol.Text = opo.SupplierID
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = opo.EITL_Suppliers5_SupplierName
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = "Project"
      oCol.Font.Bold = True
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = opo.ProjectID
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = opo.IDM_Projects6_Description
      oRow.Cells.Add(oCol)
      oTbl.Rows.Add(oRow)
      oRow = New TableRow
      oCol = New TableCell
      oCol.Text = "Division"
      oCol.Font.Bold = True
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = opo.DivisionID
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = ""
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = "Buyer"
      oCol.Font.Bold = True
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = opo.BuyerID
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = opo.aspnet_Users1_UserFullName
      oRow.Cells.Add(oCol)
      oTbl.Rows.Add(oRow)
      oRow = New TableRow
      oCol = New TableCell
      oCol.Text = "POStatus"
      oCol.Font.Bold = True
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = opo.POStatusID
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = opo.EITL_POStatus4_Description
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = "Issued By"
      oCol.Font.Bold = True
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = opo.IssuedBy
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = opo.aspnet_Users3_UserFullName
      oRow.Cells.Add(oCol)
      oTbl.Rows.Add(oRow)
      oRow = New TableRow
      oCol = New TableCell
      oCol.Text = "Issued On"
      oCol.Font.Bold = True
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = opo.IssuedOn
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = ""
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = "Closed By"
      oCol.Font.Bold = True
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = opo.ClosedBy
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = opo.aspnet_Users2_UserFullName
      oRow.Cells.Add(oCol)
      oTbl.Rows.Add(oRow)
      oRow = New TableRow
      oCol = New TableCell
      oCol.Text = "Closed On"
      oCol.Font.Bold = True
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = opo.ClosedOn
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
  End Class
End Namespace
