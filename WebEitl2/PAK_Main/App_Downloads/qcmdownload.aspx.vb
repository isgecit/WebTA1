Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports OfficeOpenXml
Imports System.Web.Script.Serialization

Partial Class qcmdownload
  Inherits System.Web.UI.Page
  Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    Dim st As Long = HttpContext.Current.Server.ScriptTimeout
    HttpContext.Current.Server.ScriptTimeout = Integer.MaxValue
    Dim val() As String = Request.QueryString("pk").Split("|".ToCharArray)
    Dim RequestID As Int32 = val(0)
    Dim SerialNo As Int32 = val(1)
    Dim oAT As SIS.QCM.qcmRequestFiles = SIS.QCM.qcmRequestFiles.qcmRequestFilesGetByID(RequestID, SerialNo)
    Dim tPath As String = ""
    Try
      If IO.Directory.Exists(ConfigurationManager.AppSettings("RequestDir")) Then
        tPath = ConfigurationManager.AppSettings("RequestDir")
      ElseIf IO.Directory.Exists(ConfigurationManager.AppSettings("RequestDir1")) Then
        tPath = ConfigurationManager.AppSettings("RequestDir1")
      End If
    Catch ex As Exception
    End Try
    If IO.File.Exists(tPath & "\" & oAT.DiskFIleName) Then
      Response.Clear()
      Response.AppendHeader("content-disposition", "attachment; filename=" & oAT.FileName)
      Response.ContentType = SIS.SYS.Utilities.ApplicationSpacific.ContentType(oAT.FileName)
      Response.WriteFile(tPath & "\" & oAT.DiskFIleName)
      HttpContext.Current.Server.ScriptTimeout = st
      Response.End()
    End If
    HttpContext.Current.Server.ScriptTimeout = st
  End Sub
End Class
