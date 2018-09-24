Imports System.Data.SqlClient
Imports System.Data
Imports System.Web
Imports Microsoft.VisualBasic
Imports System
Namespace SIS.SYS.Utilities
  Public Class ApplicationSpacific
    Public Shared Sub Initialize()
      With HttpContext.Current
        .Session("ApplicationID") = 21
        .Session("ApplicationDefaultPage") = "~/Default.aspx"
      End With
    End Sub
    Public Shared Function GetPassword() As String
      Dim pWord As String = ""
      Dim tLen As Integer = 0
      Dim rr As New Random
      Do While True
        Dim c As Integer = rr.Next(48, 122)
        If c >= 48 And c <= 57 Then
          pWord &= Convert.ToChar(c)
          tLen += 1
        End If
        If c >= 65 And c <= 90 Then
          pWord &= Convert.ToChar(c)
          tLen += 1
        End If
        If c >= 97 And c <= 122 Then
          pWord &= Convert.ToChar(c)
          tLen += 1
        End If
        If tLen >= 16 Then
          Exit Do
        End If
      Loop
      Return pWord
    End Function
    Public Shared Sub ApplicationReports(ByVal Context As HttpContext)
      If Not Context.Request.QueryString("ReportName") Is Nothing Then
        Select Case (Context.Request.QueryString("ReportName").ToLower)
          Case "customertransmittal"
            'Dim oRep As RPT_idmCT = New RPT_idmCT(Context)
            'oRep.GenerateReport()
            '	Case "pendingdocument"
            '		Dim oRep As RPT_dcmPendingDocument = New RPT_dcmPendingDocument(Context)
            '		oRep.GenerateReport()
            '	Case "sentdocument"
            '		Dim oRep As RPT_dcmSentDocument = New RPT_dcmSentDocument(Context)
            '		oRep.GenerateReport()
        End Select
      End If
    End Sub
    Public Shared Function ContentType(ByVal FileName As String) As String
      Dim mRet As String = "application/octet-stream"
      Dim Extn As String = IO.Path.GetExtension(FileName).ToLower.Replace(".", "")
      Select Case Extn
        Case "pdf", "rtf"
          mRet = "application/" & Extn
        Case "doc", "docx"
          mRet = "application/vnd.ms-works"
        Case "xls", "xlsx"
          mRet = "application/vnd.ms-excel"
        Case "gif", "jpg", "jpeg", "png", "tif", "bmp"
          mRet = "image/" & Extn
        Case "pot", "ppt", "pps", "pptx", "ppsx"
          mRet = "application/vnd.ms-powerpoint"
        Case "htm", "html"
          mRet = "text/HTML"
        Case "txt"
          mRet = "text/plain"
        Case "zip"
          mRet = "application/zip"
        Case "rar", "tar", "tgz"
          mRet = "application/x-compressed"
        Case Else
          mRet = "application/octet-stream"
      End Select
      Return mRet
    End Function
  End Class
End Namespace