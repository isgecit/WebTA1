Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports System.Web.Script.Serialization
Imports Ionic
Imports Ionic.Zip

Partial Class docdownload
  Inherits System.Web.UI.Page
  Private st As Long = HttpContext.Current.Server.ScriptTimeout
  Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    HttpContext.Current.Server.ScriptTimeout = Integer.MaxValue
    Dim Value As String = ""
    If Request.QueryString("doc") IsNot Nothing Then
      Value = Request.QueryString("doc")
      DownloadDoc(Value)
    End If
    If Request.QueryString("tmtl") IsNot Nothing Then
      Value = Request.QueryString("tmtl")
      DownloadAll(Value)
    End If
    If Request.QueryString("sdoc") IsNot Nothing Then
      Value = Request.QueryString("sdoc")
      DownloadSDoc(Value)
    End If
    If Request.QueryString("stmtl") IsNot Nothing Then
      Value = Request.QueryString("stmtl")
      DownloadSAll(Value)
    End If

  End Sub
  Private Sub DownloadAll(ByVal pk As String)
    Dim docHndl As String = "TRANSMITTALLINES_200"
    Dim LibFolder As String = "attachmentlibrary1"
    Dim libPath As String = ""
    Dim filePath As String = ""
    Dim fileName As String = pk & ".zip"
    Dim NeedsMapping As Boolean = False
    Dim Mapped As Boolean = False

    Dim UrlAuthority As String = HttpContext.Current.Request.Url.Authority
    If UrlAuthority.ToLower <> "192.9.200.146" Then
      UrlAuthority = "192.9.200.146"
      NeedsMapping = True
    End If
    libPath = "D:\" & LibFolder
    If NeedsMapping Then
      libPath = "\\" & UrlAuthority & "\" & LibFolder
      If ConnectToNetworkFunctions.connectToNetwork(libPath, "X:", "ISGECNET\adskvault", "adskvault@123") Then
        Mapped = True
      End If
    End If
    Dim tmpFilesToDelete As New ArrayList
    Response.Clear()
    Dim TmtlDocs As List(Of SIS.EDI.ediWTmtlD) = SIS.EDI.ediWTmtlD.ediWTmtlDSelectList(0, 9999, "", False, "", pk)
    If TmtlDocs.Count > 0 Then
      Response.AppendHeader("content-disposition", "attachment; filename=" & fileName)
      Response.ContentType = SIS.SYS.Utilities.ApplicationSpacific.ContentType(fileName)
      Using zip As New ZipFile
        zip.CompressionLevel = Zlib.CompressionLevel.Level5
        For Each tDoc As SIS.EDI.ediWTmtlD In TmtlDocs
          Dim docIndx As String = tDoc.PrimaryKey.Replace("|", "_")
          Dim rDoc As SIS.EDI.ediAFile = SIS.EDI.ediAFile.ediAFileGetByHandleIndex(docHndl, docIndx)
          If rDoc IsNot Nothing Then
            filePath = libPath & "\" & rDoc.t_dcid
            fileName = rDoc.t_fnam
            '====================
            '===Just to remap====
            If Not IO.File.Exists(filePath) Then
              libPath = "D:\" & LibFolder
              If NeedsMapping Then
                libPath = "\\" & UrlAuthority & "\" & LibFolder
                If ConnectToNetworkFunctions.connectToNetwork(libPath, "X:", "ISGECNET\adskvault", "adskvault@123") Then
                  Mapped = True
                End If
              End If
            End If
            '====================
            If IO.File.Exists(filePath) Then
              Dim tmpFile As String = Server.MapPath("~/..") & "App_Temp/" & fileName
              If IO.File.Exists(tmpFile) Then
                Try
                  Dim fInfo As New FileInfo(tmpFile)
                  fInfo.IsReadOnly = False
                  IO.File.Delete(tmpFile)
                Catch ex As Exception
                End Try
              End If
              Try
                IO.File.Copy(filePath, tmpFile)
              Catch ex As Exception
              End Try
              zip.AddFile(tmpFile, "Files")
              tmpFilesToDelete.Add(tmpFile)
            End If
          End If
        Next
        zip.Save(Response.OutputStream)
      End Using
    End If
    For Each str As String In tmpFilesToDelete
      Try
        Dim fInfo As New FileInfo(str)
        fInfo.IsReadOnly = False
        IO.File.Delete(str)
      Catch ex As Exception
      End Try
    Next
    If Mapped Then
      ConnectToNetworkFunctions.disconnectFromNetwork("X:")
    End If
    Response.End()

  End Sub




  Private Sub DownloadDoc(ByVal pk As String)
    Dim docHndl As String = "TRANSMITTALLINES_200"
    Dim docIndx As String = pk.Replace("|", "_")
    Dim libPath As String = ""
    Dim filePath As String = ""
    Dim fileName As String = ""
    Dim rDoc As SIS.EDI.ediAFile = SIS.EDI.ediAFile.ediAFileGetByHandleIndex(docHndl, docIndx)
    If rDoc IsNot Nothing Then
      Dim rLib As SIS.EDI.ediALib = SIS.EDI.ediALib.ediALibGetByID(rDoc.t_lbcd)
      If rLib IsNot Nothing Then
        Dim NeedsMapping As Boolean = False
        Dim Mapped As Boolean = False
        Dim UrlAuthority As String = HttpContext.Current.Request.Url.Authority
        If UrlAuthority.ToLower <> "192.9.200.146" Then
          UrlAuthority = "192.9.200.146"
          NeedsMapping = True
        End If
        libPath = "D:\" & rLib.t_path
        If NeedsMapping Then
          libPath = "\\" & UrlAuthority & "\" & rLib.t_path
          If ConnectToNetworkFunctions.connectToNetwork(libPath, "X:", "administrator", "Indian@12345") Then
            Mapped = True
          End If
        End If
        filePath = libPath & "\" & rDoc.t_dcid
        fileName = rDoc.t_fnam
        If IO.File.Exists(filePath) Then
          Response.Clear()
          Response.AppendHeader("content-disposition", "attachment; filename=" & fileName)
          Response.ContentType = SIS.SYS.Utilities.ApplicationSpacific.ContentType(fileName)
          Response.WriteFile(filePath)
          Response.End()
        End If
        If Mapped Then
          ConnectToNetworkFunctions.disconnectFromNetwork("X:")
        End If
      End If
    End If
  End Sub

  Private Sub DownloadSAll(ByVal pk As String)
    Dim docHndl As String = "TRANSMITTALLINES_200"
    Dim LibFolder As String = "attachmentlibrary1"
    Dim libPath As String = ""
    Dim filePath As String = ""
    Dim fileName As String = pk & ".zip"
    Dim NeedsMapping As Boolean = False
    Dim Mapped As Boolean = False

    Dim UrlAuthority As String = HttpContext.Current.Request.Url.Authority
    If UrlAuthority.ToLower <> "cloud.isgec.co.in" Then
      UrlAuthority = "192.9.200.146"
      NeedsMapping = True
    End If
    libPath = "D:\" & LibFolder
    If NeedsMapping Then
      libPath = "\\" & UrlAuthority & "\" & LibFolder
      If ConnectToNetworkFunctions.connectToNetwork(libPath, "X:", "administrator", "Indian@12345") Then
        Mapped = True
      End If
    End If
    Dim tmpFilesToDelete As New ArrayList
    Response.Clear()
    Dim TmtlDocs As List(Of SIS.EDI.ediWTmtlD) = SIS.EDI.ediWTmtlD.ediWTmtlDSelectList(0, 9999, "", False, "", pk)
    If TmtlDocs.Count > 0 Then
      Response.AppendHeader("content-disposition", "attachment; filename=" & fileName)
      Response.ContentType = SIS.SYS.Utilities.ApplicationSpacific.ContentType(fileName)
      Using zip As New ZipFile
        zip.CompressionLevel = Zlib.CompressionLevel.Level5
        For Each tDoc As SIS.EDI.ediWTmtlD In TmtlDocs
          Dim docIndx As String = tDoc.PrimaryKey.Replace("|", "_")
          Dim rDoc As SIS.EDI.ediAFile = SIS.EDI.ediAFile.ediAFileGetByHandleIndex(docHndl, docIndx)
          If rDoc IsNot Nothing Then
            filePath = libPath & "\" & rDoc.t_dcid
            fileName = rDoc.t_fnam
            '====================
            '===Just to remap====
            If Not IO.File.Exists(filePath) Then
              libPath = "D:\" & LibFolder
              If NeedsMapping Then
                libPath = "\\" & UrlAuthority & "\" & LibFolder
                If ConnectToNetworkFunctions.connectToNetwork(libPath, "X:", "administrator", "Indian@12345") Then
                  Mapped = True
                End If
              End If
            End If
            '====================
            If IO.File.Exists(filePath) Then
              Dim tmpFile As String = Server.MapPath("~/..") & "App_Temp/" & fileName
              IO.File.Copy(filePath, tmpFile)
              zip.AddFile(tmpFile, "Files")
              tmpFilesToDelete.Add(tmpFile)
            End If
          End If
        Next
        zip.Save(Response.OutputStream)
      End Using
    End If
    For Each str As String In tmpFilesToDelete
      IO.File.Delete(str)
    Next
    If Mapped Then
      ConnectToNetworkFunctions.disconnectFromNetwork("X:")
    End If
    Response.End()

  End Sub
  Private Sub DownloadSDoc(ByVal pk As String)
    Dim docHndl As String = "TRANSMITTALLINES_200"
    Dim docIndx As String = pk.Replace("|", "_")
    Dim libPath As String = ""
    Dim filePath As String = ""
    Dim fileName As String = ""
    Dim rDoc As SIS.EDI.ediAFile = SIS.EDI.ediAFile.ediAFileGetByHandleIndex(docHndl, docIndx)
    If rDoc IsNot Nothing Then
      Dim rLib As SIS.EDI.ediALib = SIS.EDI.ediALib.ediALibGetByID(rDoc.t_lbcd)
      If rLib IsNot Nothing Then
        Dim NeedsMapping As Boolean = False
        Dim Mapped As Boolean = False
        Dim UrlAuthority As String = HttpContext.Current.Request.Url.Authority
        If UrlAuthority.ToLower <> "cloud.isgec.co.in" Then
          UrlAuthority = "192.9.200.146"
          NeedsMapping = True
        End If
        libPath = "D:\" & rLib.t_path
        If NeedsMapping Then
          libPath = "\\" & UrlAuthority & "\" & rLib.t_path
          If ConnectToNetworkFunctions.connectToNetwork(libPath, "X:", "administrator", "Indian@12345") Then
            Mapped = True
          End If
        End If
        filePath = libPath & "\" & rDoc.t_dcid
        fileName = rDoc.t_fnam
        If IO.File.Exists(filePath) Then
          Response.Clear()
          Response.AppendHeader("content-disposition", "attachment; filename=" & fileName)
          Response.ContentType = SIS.SYS.Utilities.ApplicationSpacific.ContentType(fileName)
          Response.WriteFile(filePath)
          Response.End()
        End If
        If Mapped Then
          ConnectToNetworkFunctions.disconnectFromNetwork("X:")
        End If
      End If
    End If
  End Sub
End Class
