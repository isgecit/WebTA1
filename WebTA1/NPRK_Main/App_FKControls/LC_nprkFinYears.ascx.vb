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
Partial Class LC_nprkFinYears
  Inherits System.Web.UI.UserControl
  Private _OrderBy As String = String.Empty
  Private _IncludeDefault As Boolean = True
  Private _DefaultText As String = "-- Select --"
  Private _DefaultValue As String = String.Empty
  Public Event SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
  Public ReadOnly Property LCClientID() As String
    Get
      Return DDLnprkFinYears.ClientID
    End Get
  End Property
  Public Property AddAttributes() As String
    Get
      Return DDLnprkFinYears.Attributes.ToString
    End Get
    Set(ByVal value As String)
      Try
        Dim aVal() As String = value.Split(",".ToCharArray)
        DDLnprkFinYears.Attributes.Add(aVal(0), aVal(1))
      Catch ex As Exception
      End Try
    End Set
  End Property
  Public Property CssClass() As String
    Get
      Return DDLnprkFinYears.CssClass
    End Get
    Set(ByVal value As String)
      DDLnprkFinYears.CssClass = value
    End Set
  End Property
  Public Property Width() As System.Web.UI.WebControls.Unit
    Get
      Return DDLnprkFinYears.Width
    End Get
    Set(ByVal value As System.Web.UI.WebControls.Unit)
      DDLnprkFinYears.Width = value
    End Set
  End Property
  Public Property RequiredFieldErrorMessage() As String
    Get
      Return RequiredFieldValidatornprkFinYears.Text
    End Get
    Set(ByVal value As String)
      RequiredFieldValidatornprkFinYears.Text = value
    End Set
  End Property
  Public Property ValidationGroup() As String
    Get
      Return RequiredFieldValidatornprkFinYears.ValidationGroup
    End Get
    Set(ByVal value As String)
      RequiredFieldValidatornprkFinYears.ValidationGroup = value
    End Set
  End Property
  Public Property Enabled() As Boolean
    Get
      Return DDLnprkFinYears.Enabled
    End Get
    Set(ByVal value As Boolean)
      DDLnprkFinYears.Enabled = value
    End Set
  End Property
  Public Property AutoPostBack() As Boolean
    Get
      Return DDLnprkFinYears.AutoPostBack
    End Get
    Set(ByVal value As Boolean)
      DDLnprkFinYears.AutoPostBack = value
    End Set
  End Property
  Public Property DataTextField() As String
    Get
      Return DDLnprkFinYears.DataTextField
    End Get
    Set(ByVal value As String)
      DDLnprkFinYears.DataTextField = value
    End Set
  End Property
  Public Property DataValueField() As String
    Get
      Return DDLnprkFinYears.DataValueField
    End Get
    Set(ByVal value As String)
      DDLnprkFinYears.DataValueField = value
    End Set
  End Property
  Public Property SelectedValue() As String
    Get
      Return DDLnprkFinYears.SelectedValue
    End Get
    Set(ByVal value As String)
      If Convert.IsDBNull(value) Then
        DDLnprkFinYears.SelectedValue = String.Empty
      Else
        DDLnprkFinYears.SelectedValue = value
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
  Protected Sub OdsDdlnprkFinYears_Selecting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceSelectingEventArgs) Handles OdsDdlnprkFinYears.Selecting
    e.Arguments.SortExpression = _OrderBy
  End Sub
  Protected Sub DDLnprkFinYears_DataBinding(ByVal sender As Object, ByVal e As System.EventArgs) Handles DDLnprkFinYears.DataBinding
    If _IncludeDefault Then
      DDLnprkFinYears.Items.Add(new ListItem(_DefaultText, _DefaultValue))
    End If
  End Sub
  Protected Sub DDLnprkFinYears_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DDLnprkFinYears.SelectedIndexChanged
    RaiseEvent SelectedIndexChanged(sender, e)
  End Sub
End Class
