Imports System
Imports System.Collections
Imports System.Collections.Generic
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Drawing.Imaging
Imports System.IO
Public Class PhotoManager
  'Public Overloads Shared Function GetPhoto(ByVal oImg As SIS.PRD.prdStyleImages) As Stream
  '  If IO.File.Exists(HttpContext.Current.Server.MapPath("~/..") & "StyleImages/" & oImg.DiskFileName) Then
  '    Return New FileStream(HttpContext.Current.Server.MapPath("~/..") & "StyleImages/" & oImg.DiskFileName, FileMode.Open, FileAccess.Read, FileShare.Read)
  '  End If
  '  Return Nothing
  'End Function
  'Public Overloads Shared Function GetPhoto(ByVal photoid As Integer, ByVal size As PhotoSize) As Stream
  '  Using connection As New SqlConnection(ConfigurationManager.ConnectionStrings("Personal").ConnectionString)
  '    Using command As New SqlCommand("GetPhoto", connection)
  '      command.CommandType = CommandType.StoredProcedure
  '      command.Parameters.Add(New SqlParameter("@PhotoID", photoid))
  '      command.Parameters.Add(New SqlParameter("@Size", CType(size, Integer)))
  '      connection.Open()
  '      Dim result As Object = command.ExecuteScalar
  '      Try
  '        Return New MemoryStream(CType(result, Byte()))
  '      Catch
  '        Return Nothing
  '      End Try
  '    End Using
  '  End Using
  'End Function
  'Public Shared Function DownloadPhoto(ByVal PhotoID As Integer) As Photo
  '  Using connection As New SqlConnection(ConfigurationManager.ConnectionStrings("Personal").ConnectionString)
  '    Using command As New SqlCommand("DownloadPhoto", connection)
  '      command.CommandType = CommandType.StoredProcedure
  '      command.Parameters.Add(New SqlParameter("@PhotoID", Convert.ToInt32(PhotoID)))
  '      connection.Open()
  '      Dim temp As Photo = Nothing
  '      Using reader As SqlDataReader = command.ExecuteReader()
  '        Do While (reader.Read())
  '          temp = New Photo(reader)
  '        Loop
  '      End Using
  '      Return temp
  '    End Using
  '  End Using
  'End Function
  ' Album-Related Methods
  'Public Shared Sub AddPhoto(ByVal Blog_ID As String, ByVal PhotoType As PhotoTypes, ByVal Caption As String, ByVal BytesOriginal() As Byte)
  '  Dim msProc As String = "AddUserPhoto"
  '  If PhotoType <> PhotoTypes.User Then
  '    msProc = "AddPhoto"
  '  End If
  '  Using connection As New SqlConnection(ConfigurationManager.ConnectionStrings("Personal").ConnectionString)
  '    Using command As New SqlCommand(msProc, connection)
  '      command.CommandType = CommandType.StoredProcedure
  '      If PhotoType <> PhotoTypes.User Then
  '        command.Parameters.Add(New SqlParameter("@Blog_ID", Convert.ToInt32(Blog_ID)))
  '      Else
  '        command.Parameters.Add(New SqlParameter("@Blog_ID", Blog_ID))
  '      End If
  '      command.Parameters.Add(New SqlParameter("@PhotoType", PhotoType))
  '      command.Parameters.Add(New SqlParameter("@Caption", Caption))
  '      command.Parameters.Add(New SqlParameter("@BytesOriginal", BytesOriginal))
  '      command.Parameters.Add(New SqlParameter("@BytesFull", ResizeImageFile(BytesOriginal, 600)))
  '      command.Parameters.Add(New SqlParameter("@BytesPoster", ResizeImageFile(BytesOriginal, 198)))
  '      command.Parameters.Add(New SqlParameter("@BytesThumb", ResizeImageFile(BytesOriginal, 100)))
  '      connection.Open()
  '      command.ExecuteNonQuery()
  '    End Using
  '  End Using
  'End Sub
  ' Auxiliary Functions
  Public Shared Function ResizeImageFile(ByVal imageFile() As Byte, ByVal targetSize As Integer) As Byte()
    Using oldImage As System.Drawing.Image = System.Drawing.Image.FromStream(New MemoryStream(imageFile))
      Dim newSize As Size = CalculateDimensions(oldImage.Size, targetSize)
      Using newImage As Bitmap = New Bitmap(newSize.Width, newSize.Height, PixelFormat.Format24bppRgb)
        Using canvas As Graphics = Graphics.FromImage(newImage)
          canvas.SmoothingMode = SmoothingMode.AntiAlias
          canvas.InterpolationMode = InterpolationMode.HighQualityBicubic
          canvas.PixelOffsetMode = PixelOffsetMode.HighQuality
          canvas.DrawImage(oldImage, New Rectangle(New Point(0, 0), newSize))
          Dim m As New MemoryStream
          newImage.Save(m, ImageFormat.Jpeg)
          Return m.GetBuffer
        End Using
      End Using
    End Using
  End Function
  Private Shared Function CalculateDimensions(ByVal oldSize As Size, ByVal targetSize As Integer) As Size
    Dim newSize As Size
    If (oldSize.Height > oldSize.Width) Then
      newSize.Width = CType((oldSize.Width * CType((targetSize / CType(oldSize.Height, Single)), Single)), Integer)
      newSize.Height = targetSize
    Else
      newSize.Width = targetSize
      newSize.Height = CType((oldSize.Height * CType((targetSize / CType(oldSize.Width, Single)), Single)), Integer)
    End If
    Return newSize
  End Function
End Class