Imports System.Data.SqlClient
Imports System.Data
Imports System.Web
Imports Microsoft.VisualBasic
Imports System
Namespace SIS.SYS.Utilities
	Public Class ApplicationSpacific
    Public Shared ReadOnly Property NextLinkNo As Integer
      Get
        Dim mRet As Integer = 0
        Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
          Con.Open()
          Using Cmd As SqlCommand = Con.CreateCommand()
            Cmd.CommandType = CommandType.Text
            Cmd.CommandText = "Select top 1 LinkSrNo from TA_LogSrNo"
            mRet = Cmd.ExecuteScalar()
          End Using
          mRet = mRet + 1
          Using Cmd As SqlCommand = Con.CreateCommand()
            Cmd.CommandType = CommandType.Text
            Cmd.CommandText = "Update TA_LogSrNo set LinkSrNo =" & mRet
            Cmd.ExecuteNonQuery()
          End Using
        End Using
        Return mRet
      End Get
    End Property
    Public Shared ReadOnly Property NextMailNo As Integer
      Get
        Dim mRet As Integer = 0
        Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
          Con.Open()
          Using Cmd As SqlCommand = Con.CreateCommand()
            Cmd.CommandType = CommandType.Text
            Cmd.CommandText = "Select top 1 MailSrNo from TA_LogSrNo"
            mRet = Cmd.ExecuteScalar()
          End Using
          mRet = mRet + 1
          Using Cmd As SqlCommand = Con.CreateCommand()
            Cmd.CommandType = CommandType.Text
            Cmd.CommandText = "Update TA_LogSrNo set MailSrNo =" & mRet
            Cmd.ExecuteNonQuery()
          End Using
        End Using
        Return mRet
      End Get
    End Property
    Public Shared ReadOnly Property IsTesting As Boolean
      Get
        Return Convert.ToBoolean(ConfigurationManager.AppSettings("Testing"))
      End Get
    End Property
    Public Shared Sub Initialize()
      With HttpContext.Current
        .Session("ApplicationID") = 24
        .Session("ApplicationDefaultPage") = "~/Default.aspx"
        .Session("PaidAt") = "CSH"
      End With
      HttpContext.Current.Session("FinYear") = SIS.SYS.Utilities.ApplicationSpacific.ActivePRKYear
      Dim tmp As String = SIS.SYS.Utilities.ApplicationSpacific.ActivePRKYearEndDate
      If Now > Convert.ToDateTime(tmp) Then
        HttpContext.Current.Session("Today") = Convert.ToDateTime(tmp)
      Else
        HttpContext.Current.Session("Today") = Now
      End If
    End Sub
    Public Shared ReadOnly Property ActivePRKYearEndDate() As String
      Get
        Dim _Result As String
        Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString)
          Using Cmd As SqlCommand = Con.CreateCommand()
            Dim mSql As String = "SELECT TOP 1 [PRK_FinYears].[EndDate] FROM [PRK_FinYears] WHERE [PRK_FinYears].[Status] = 'Open'"
            Cmd.CommandType = System.Data.CommandType.Text
            Cmd.CommandText = mSql
            Con.Open()
            _Result = Cmd.ExecuteScalar()
          End Using
        End Using
        Return _Result
      End Get
    End Property
    Public Shared ReadOnly Property ActivePRKYear() As Integer
      Get
        Dim _Result As Integer = 0
        Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString)
          Using Cmd As SqlCommand = Con.CreateCommand()
            Dim mSql As String = "SELECT TOP 1 [PRK_FinYears].[FinYear] FROM [PRK_FinYears] WHERE [PRK_FinYears].[Status] = 'Open'"
            Cmd.CommandType = System.Data.CommandType.Text
            Cmd.CommandText = mSql
            Con.Open()
            _Result = Cmd.ExecuteScalar()
          End Using
        End Using
        Return _Result
      End Get
    End Property
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