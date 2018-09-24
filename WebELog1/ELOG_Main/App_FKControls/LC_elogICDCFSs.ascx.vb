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
Partial Class LC_elogICDCFSs
  Inherits System.Web.UI.UserControl
  Private _OrderBy As String = String.Empty
  Private _IncludeDefault As Boolean = True
  Private _DefaultText As String = "-- Select --"
  Private _DefaultValue As String = String.Empty
  Public Event SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
  Public Sub Clear()
    DDLelogICDCFSs.Items.Clear()
  End Sub
  Public Overrides Sub DataBind()
    DDLelogICDCFSs.DataBind()
  End Sub
  Public ReadOnly Property LCClientID() As String
    Get
      Return DDLelogICDCFSs.ClientID
    End Get
  End Property
  Public Property AddAttributes() As String
    Get
      Return DDLelogICDCFSs.Attributes.ToString
    End Get
    Set(ByVal value As String)
      Try
        Dim aVal() As String = value.Split(",".ToCharArray)
        DDLelogICDCFSs.Attributes.Add(aVal(0), aVal(1))
      Catch ex As Exception
      End Try
    End Set
  End Property
  Public Property CssClass() As String
    Get
      Return DDLelogICDCFSs.CssClass
    End Get
    Set(ByVal value As String)
      DDLelogICDCFSs.CssClass = value
    End Set
  End Property
  Public Property Width() As System.Web.UI.WebControls.Unit
    Get
      Return DDLelogICDCFSs.Width
    End Get
    Set(ByVal value As System.Web.UI.WebControls.Unit)
      DDLelogICDCFSs.Width = value
    End Set
  End Property
  Public Property RequiredFieldErrorMessage() As String
    Get
      Return RequiredFieldValidatorelogICDCFSs.Text
    End Get
    Set(ByVal value As String)
      RequiredFieldValidatorelogICDCFSs.Text = value
    End Set
  End Property
  Public Property ValidationGroup() As String
    Get
      Return RequiredFieldValidatorelogICDCFSs.ValidationGroup
    End Get
    Set(ByVal value As String)
      RequiredFieldValidatorelogICDCFSs.ValidationGroup = value
    End Set
  End Property
  Public Property Enabled() As Boolean
    Get
      Return DDLelogICDCFSs.Enabled
    End Get
    Set(ByVal value As Boolean)
      DDLelogICDCFSs.Enabled = value
      RequiredFieldValidatorelogICDCFSs.Enabled = value
    End Set
  End Property
  Public Property AutoPostBack() As Boolean
    Get
      Return DDLelogICDCFSs.AutoPostBack
    End Get
    Set(ByVal value As Boolean)
      DDLelogICDCFSs.AutoPostBack = value
    End Set
  End Property
  Public Property DataTextField() As String
    Get
      Return DDLelogICDCFSs.DataTextField
    End Get
    Set(ByVal value As String)
      DDLelogICDCFSs.DataTextField = value
    End Set
  End Property
  Public Property DataValueField() As String
    Get
      Return DDLelogICDCFSs.DataValueField
    End Get
    Set(ByVal value As String)
      DDLelogICDCFSs.DataValueField = value
    End Set
  End Property
  Public Property SelectedValue() As String
    Get
      Return DDLelogICDCFSs.SelectedValue
    End Get
    Set(ByVal value As String)
      If Convert.IsDBNull(value) Then
        DDLelogICDCFSs.SelectedValue = String.Empty
      Else
        DDLelogICDCFSs.SelectedValue = value
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
  Protected Sub OdsDdlelogICDCFSs_Selecting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceSelectingEventArgs) Handles OdsDdlelogICDCFSs.Selecting
    e.Arguments.SortExpression = _OrderBy
  End Sub
  Protected Sub DDLelogICDCFSs_DataBinding(ByVal sender As Object, ByVal e As System.EventArgs) Handles DDLelogICDCFSs.DataBinding
    If _IncludeDefault Then
      DDLelogICDCFSs.Items.Add(new ListItem(_DefaultText, _DefaultValue))
    End If
  End Sub
  Protected Sub DDLelogICDCFSs_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DDLelogICDCFSs.SelectedIndexChanged
    RaiseEvent SelectedIndexChanged(sender, e)
  End Sub
End Class
