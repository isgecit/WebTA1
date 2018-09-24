Imports System.Data.SqlClient
Imports System.Data
Namespace SIS.SYS.Utilities
	Public Class ApplicationSpacific
    Public Shared Sub Initialize()
      With HttpContext.Current
        .Session("ApplicationID") = 23
        .Session("ApplicationDefaultPage") = "~/Default.aspx"
        .Session("DivisionID") = GetDivision(HttpContext.Current.Session("LoginID"))
        .Session("IsSupplier") = False
      End With
    End Sub
    Public Shared Function GetDivision(ByVal CardNo As String) As Integer
      If CardNo.StartsWith("UP") AndAlso CardNo.Length >= 7 Then
        HttpContext.Current.Session("IsSupplier") = True
        Return 0
      End If
      Dim Results As String = ""
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spqcmEmployeesSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CardNo", SqlDbType.NVarChar, CardNo.ToString.Length, CardNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = IIf(IsDBNull(Reader("C_DivisionID")), "", Reader("C_DivisionID"))
          End If
          Reader.Close()
        End Using
      End Using
      Dim mRet As Integer = 0
      Select Case Results.ToUpper
        Case "APCE"
          mRet = 4
        Case "BOILER", "BOI", "BOILE"
          mRet = 1
        Case "EPC"
          mRet = 3
        Case "PC"
          mRet = 5
        Case "SMD"
          mRet = 2
      End Select
      Return mRet
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