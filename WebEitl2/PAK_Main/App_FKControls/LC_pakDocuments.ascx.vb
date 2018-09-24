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
Partial Class LC_pakDocuments
  Inherits System.Web.UI.UserControl
  Private _OrderBy As String = String.Empty
  Private _IncludeDefault As Boolean = True
  Private _DefaultText As String = "-- Select --"
  Private _DefaultValue As String = String.Empty
  Public Event SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
  Public ReadOnly Property LCClientID() As String
    Get
      Return DDLpakDocuments.ClientID
    End Get
  End Property
  Public Property AddAttributes() As String
    Get
      Return DDLpakDocuments.Attributes.ToString
    End Get
    Set(ByVal value As String)
      Try
        Dim aVal() As String = value.Split(",".ToCharArray)
        DDLpakDocuments.Attributes.Add(aVal(0), aVal(1))
      Catch ex As Exception
      End Try
    End Set
  End Property
  Public Property CssClass() As String
    Get
      Return DDLpakDocuments.CssClass
    End Get
    Set(ByVal value As String)
      DDLpakDocuments.CssClass = value
    End Set
  End Property
  Public Property Width() As System.Web.UI.WebControls.Unit
    Get
      Return DDLpakDocuments.Width
    End Get
    Set(ByVal value As System.Web.UI.WebControls.Unit)
      DDLpakDocuments.Width = value
    End Set
  End Property
  Public Property RequiredFieldErrorMessage() As String
    Get
      Return RequiredFieldValidatorpakDocuments.Text
    End Get
    Set(ByVal value As String)
      RequiredFieldValidatorpakDocuments.Text = value
    End Set
  End Property
  Public Property ValidationGroup() As String
    Get
      Return RequiredFieldValidatorpakDocuments.ValidationGroup
    End Get
    Set(ByVal value As String)
      RequiredFieldValidatorpakDocuments.ValidationGroup = value
    End Set
  End Property
  Public Property Enabled() As Boolean
    Get
      Return DDLpakDocuments.Enabled
    End Get
    Set(ByVal value As Boolean)
      DDLpakDocuments.Enabled = value
    End Set
  End Property
  Public Property AutoPostBack() As Boolean
    Get
      Return DDLpakDocuments.AutoPostBack
    End Get
    Set(ByVal value As Boolean)
      DDLpakDocuments.AutoPostBack = value
    End Set
  End Property
  Public Property DataTextField() As String
    Get
      Return DDLpakDocuments.DataTextField
    End Get
    Set(ByVal value As String)
      DDLpakDocuments.DataTextField = value
    End Set
  End Property
  Public Property DataValueField() As String
    Get
      Return DDLpakDocuments.DataValueField
    End Get
    Set(ByVal value As String)
      DDLpakDocuments.DataValueField = value
    End Set
  End Property
  Public Property SelectedValue() As String
    Get
      Return DDLpakDocuments.SelectedValue
    End Get
    Set(ByVal value As String)
      If Convert.IsDBNull(value) Then
        DDLpakDocuments.SelectedValue = String.Empty
      Else
        DDLpakDocuments.SelectedValue = value
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
  Protected Sub OdsDdlpakDocuments_Selecting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceSelectingEventArgs) Handles OdsDdlpakDocuments.Selecting
    e.Arguments.SortExpression = _OrderBy
  End Sub
  Protected Sub DDLpakDocuments_DataBinding(ByVal sender As Object, ByVal e As System.EventArgs) Handles DDLpakDocuments.DataBinding
    If _IncludeDefault Then
      DDLpakDocuments.Items.Add(new ListItem(_DefaultText, _DefaultValue))
    End If
  End Sub
  Protected Sub DDLpakDocuments_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DDLpakDocuments.SelectedIndexChanged
    RaiseEvent SelectedIndexChanged(sender, e)
  End Sub
End Class
