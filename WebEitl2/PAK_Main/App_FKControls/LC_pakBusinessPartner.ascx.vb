Imports System
Imports System.Data
Imports System.Configuration
Imports System.Collections
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls

<ValidationProperty("SelectedValue")> _
Partial Class LC_pakBusinessPartner
  Inherits System.Web.UI.UserControl
  Private _OrderBy As String = String.Empty
  Private _IncludeDefault As Boolean = True
  Private _DefaultText As String = "-- Select --"
  Private _DefaultValue As String = String.Empty
  Public Event SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
  Public ReadOnly Property LCClientID() As String
    Get
      Return DDLpakBusinessPartner.ClientID
    End Get
  End Property
  Public Property AddAttributes() As String
    Get
      Return DDLpakBusinessPartner.Attributes.ToString
    End Get
    Set(ByVal value As String)
      Try
        Dim aVal() As String = value.Split(",".ToCharArray)
        DDLpakBusinessPartner.Attributes.Add(aVal(0), aVal(1))
      Catch ex As Exception
      End Try
    End Set
  End Property
  Public Property CssClass() As String
    Get
      Return DDLpakBusinessPartner.CssClass
    End Get
    Set(ByVal value As String)
      DDLpakBusinessPartner.CssClass = value
    End Set
  End Property
  Public Property Width() As System.Web.UI.WebControls.Unit
    Get
      Return DDLpakBusinessPartner.Width
    End Get
    Set(ByVal value As System.Web.UI.WebControls.Unit)
      DDLpakBusinessPartner.Width = value
    End Set
  End Property
  Public Property RequiredFieldErrorMessage() As String
    Get
      Return RequiredFieldValidatorpakBusinessPartner.Text
    End Get
    Set(ByVal value As String)
      RequiredFieldValidatorpakBusinessPartner.Text = value
    End Set
  End Property
  Public Property ValidationGroup() As String
    Get
      Return RequiredFieldValidatorpakBusinessPartner.ValidationGroup
    End Get
    Set(ByVal value As String)
      RequiredFieldValidatorpakBusinessPartner.ValidationGroup = value
    End Set
  End Property
  Public Property Enabled() As Boolean
    Get
      Return DDLpakBusinessPartner.Enabled
    End Get
    Set(ByVal value As Boolean)
      DDLpakBusinessPartner.Enabled = value
    End Set
  End Property
  Public Property AutoPostBack() As Boolean
    Get
      Return DDLpakBusinessPartner.AutoPostBack
    End Get
    Set(ByVal value As Boolean)
      DDLpakBusinessPartner.AutoPostBack = value
    End Set
  End Property
  Public Property DataTextField() As String
    Get
      Return DDLpakBusinessPartner.DataTextField
    End Get
    Set(ByVal value As String)
      DDLpakBusinessPartner.DataTextField = value
    End Set
  End Property
  Public Property DataValueField() As String
    Get
      Return DDLpakBusinessPartner.DataValueField
    End Get
    Set(ByVal value As String)
      DDLpakBusinessPartner.DataValueField = value
    End Set
  End Property
  Public Property SelectedValue() As String
    Get
      Return DDLpakBusinessPartner.SelectedValue
    End Get
    Set(ByVal value As String)
      If Convert.IsDBNull(value) Then
        DDLpakBusinessPartner.SelectedValue = String.Empty
      Else
        DDLpakBusinessPartner.SelectedValue = value
      End If
    End Set
  End Property
  Public Property OrderBy() As String
    Get
      Return _OrderBy
    End Get
    Set(ByVal value As String)
      _OrderBy = value
    End Set
  End Property
  Public Property IncludeDefault() As Boolean
    Get
      Return _IncludeDefault
    End Get
    Set(ByVal value As Boolean)
      _IncludeDefault = value
    End Set
  End Property
  Public Property DefaultText() As String
    Get
      Return _DefaultText
    End Get
    Set(ByVal value As String)
      _DefaultText = value
    End Set
  End Property
  Public Property DefaultValue() As String
    Get
      Return _DefaultValue
    End Get
    Set(ByVal value As String)
      _DefaultValue = value
    End Set
  End Property
  Protected Sub OdsDdlpakBusinessPartner_Selecting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceSelectingEventArgs) Handles OdsDdlpakBusinessPartner.Selecting
    e.Arguments.SortExpression = _OrderBy
  End Sub
  Protected Sub DDLpakBusinessPartner_DataBinding(ByVal sender As Object, ByVal e As System.EventArgs) Handles DDLpakBusinessPartner.DataBinding
    If _IncludeDefault Then
      DDLpakBusinessPartner.Items.Add(new ListItem(_DefaultText, _DefaultValue))
    End If
  End Sub
  Protected Sub DDLpakBusinessPartner_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DDLpakBusinessPartner.SelectedIndexChanged
    RaiseEvent SelectedIndexChanged(sender, e)
  End Sub
End Class
