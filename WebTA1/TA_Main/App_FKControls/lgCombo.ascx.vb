Imports System.Web.UI.WebControls
Partial Class lgCombo
  Inherits System.Web.UI.UserControl
  Private LG_Text As TextBox
  Public Property TargetField As String
    Get
      Return LG_Text.ID
    End Get
    Set(value As String)
      LG_Text = Page.FindControl(value)
    End Set
  End Property
  Public Property PageMethod As String


  '<System.Web.Services.WebMethod()> _
  '<System.Web.Script.Services.ScriptMethod(UseHttpGet:=True)> _
  'Public Shared Function getData(ByVal value As String) As String
  '  Return "Hello " & value
  'End Function


  Protected Sub Page_PreRender(sender As Object, e As System.EventArgs) Handles Me.PreRender
    Dim mStr As String = ""
    mStr &= "<script type=""text/javascript"">"
    mStr &= "  try { script_lgCombo.start('" & LG_Text.ClientID & "', '" & LG_panel.ClientID & "'); } catch (e) { alert(e); }"
    mStr &= "</script>"
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptlgCombo") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptlgCombo", mStr)
    End If

  End Sub
End Class
