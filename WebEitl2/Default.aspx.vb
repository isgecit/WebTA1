Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Imports System.Web.Services
Imports System.IO

Partial Class LGDefault
  Inherits System.Web.UI.Page

  Private Sub LGDefault_Load(sender As Object, e As EventArgs) Handles Me.Load
  End Sub

  <System.Web.Services.WebMethod()>
  <System.Web.Script.Services.ScriptMethod()>
  Public Shared Function LoadUserControl(ByVal message As String) As String
    Using page As New Page()
      Dim userControl As UserControl = DirectCast(page.LoadControl("Message.ascx"), UserControl)
      TryCast(userControl.FindControl("lblMessage"), Label).Text = message
      page.Controls.Add(userControl)
      Using writer As New StringWriter()
        page.Controls.Add(userControl)
        HttpContext.Current.Server.Execute(page, writer, False)
        Return writer.ToString()
      End Using
    End Using
  End Function
End Class
