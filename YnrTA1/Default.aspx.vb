Imports System.IO
Imports OfficeOpenXml
Imports System.Web.Script.Serialization
Partial Class LGDefault
  Inherits System.Web.UI.Page


  Public Property abcd As String = ""


  Private Sub LGDefault_PreRender(sender As Object, e As EventArgs) Handles Me.PreRender
    If Page.User.Identity.IsAuthenticated Then

      Dim str As String = ""
      str &= "|~/TA Bill Entry Process Ver_1.pdf|TA Bill Entry HELP"
      str &= "|~/TA_Main/App_Forms/GF_taBH.aspx|TA Claim Form"

      str = str.Replace("~", HttpContext.Current.Request.Url.Scheme & Uri.SchemeDelimiter & HttpContext.Current.Request.Url.Authority & HttpContext.Current.Request.ApplicationPath)
      Dim astr() As String = str.Split("|".ToCharArray)

      abcd &= "<ul class='dashboardIcons'>"
      For i As Integer = 1 To astr.Length - 1 Step 2
        abcd &= "<fieldset id='fs" & i & "' class='ui-widget-content wp_page'>"
        abcd &= "<div class='wp_pagedata'>"
        abcd &= "  <li title='" & astr(i + 1) & "'>"
        abcd &= "    <div class='frame'>"
        If astr(i).StartsWith("#") Then
          abcd &= "      <div onclick=""" & astr(i).Substring(1) & """>"
          abcd &= "        <img src='Images/mnu_" & i & ".jpg' width='50' height='50' alt=''>"
          abcd &= "        <span>" & astr(i + 1) & "</span>"
          abcd &= "      </div>"
        Else
          abcd &= "      <a href='" & astr(i) & "'>"
          abcd &= "        <img src='Images/mnu_" & i & ".jpg' width='50' height='50' alt=''>"
          abcd &= "        <span>" & astr(i + 1) & "</span>"
          abcd &= "      </a>"
        End If
        abcd &= "     </div>"
        abcd &= "  </li>"
        abcd &= "</div>"
        abcd &= "</fieldset>"
      Next
      abcd &= "</ul>"
    End If

  End Sub
End Class
