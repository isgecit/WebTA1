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
Partial Class LC_pakPOBIDocuments
  Inherits System.Web.UI.UserControl
  Private _OrderBy As String = String.Empty
  Private _IncludeDefault As Boolean = True
  Private _DefaultText As String = "-- Select --"
  Private _DefaultValue As String = String.Empty
  Public Event SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
  Public ReadOnly Property LCClientID() As String
    Get
      Return DDLpakPOBIDocuments.ClientID
    End Get
  End Property
  Public Property AddAttributes() As String
    Get
      Return DDLpakPOBIDocuments.Attributes.ToString
    End Get
    Set(ByVal value As String)
      Try
        Dim aVal() As String = value.Split(",".ToCharArray)
        DDLpakPOBIDocuments.Attributes.Add(aVal(0), aVal(1))
      Catch ex As Exception
      End Try
    End Set
  End Property
  Public Property CssClass() As String
    Get
      Return DDLpakPOBIDocuments.CssClass
    End Get
    Set(ByVal value As String)
      DDLpakPOBIDocuments.CssClass = value
    End Set
  End Property
  Public Property Width() As System.Web.UI.WebControls.Unit
    Get
      Return DDLpakPOBIDocuments.Width
    End Get
    Set(ByVal value As System.Web.UI.WebControls.Unit)
      DDLpakPOBIDocuments.Width = value
    End Set
  End Property
  Public Property RequiredFieldErrorMessage() As String
    Get
      Return RequiredFieldValidatorpakPOBIDocuments.Text
    End Get
    Set(ByVal value As String)
      RequiredFieldValidatorpakPOBIDocuments.Text = value
    End Set
  End Property
  Public Property ValidationGroup() As String
    Get
      Return RequiredFieldValidatorpakPOBIDocuments.ValidationGroup
    End Get
    Set(ByVal value As String)
      RequiredFieldValidatorpakPOBIDocuments.ValidationGroup = value
    End Set
  End Property
  Public Property Enabled() As Boolean
    Get
      Return DDLpakPOBIDocuments.Enabled
    End Get
    Set(ByVal value As Boolean)
      DDLpakPOBIDocuments.Enabled = value
    End Set
  End Property
  Public Property AutoPostBack() As Boolean
    Get
      Return DDLpakPOBIDocuments.AutoPostBack
    End Get
    Set(ByVal value As Boolean)
      DDLpakPOBIDocuments.AutoPostBack = value
    End Set
  End Property
  Public Property DataTextField() As String
    Get
      Return DDLpakPOBIDocuments.DataTextField
    End Get
    Set(ByVal value As String)
      DDLpakPOBIDocuments.DataTextField = value
    End Set
  End Property
  Public Property DataValueField() As String
    Get
      Return DDLpakPOBIDocuments.DataValueField
    End Get
    Set(ByVal value As String)
      DDLpakPOBIDocuments.DataValueField = value
    End Set
  End Property
  Public Property SelectedValue() As String
    Get
      Return DDLpakPOBIDocuments.SelectedValue
    End Get
    Set(ByVal value As String)
      If Convert.IsDBNull(value) Then
        DDLpakPOBIDocuments.SelectedValue = String.Empty
      Else
        DDLpakPOBIDocuments.SelectedValue = value
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
  Protected Sub OdsDdlpakPOBIDocuments_Selecting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceSelectingEventArgs) Handles OdsDdlpakPOBIDocuments.Selecting
    e.Arguments.SortExpression = _OrderBy
  End Sub
  Protected Sub DDLpakPOBIDocuments_DataBinding(ByVal sender As Object, ByVal e As System.EventArgs) Handles DDLpakPOBIDocuments.DataBinding
    If _IncludeDefault Then
      DDLpakPOBIDocuments.Items.Add(new ListItem(_DefaultText, _DefaultValue))
    End If
  End Sub
  Protected Sub DDLpakPOBIDocuments_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DDLpakPOBIDocuments.SelectedIndexChanged
    RaiseEvent SelectedIndexChanged(sender, e)
  End Sub
End Class
