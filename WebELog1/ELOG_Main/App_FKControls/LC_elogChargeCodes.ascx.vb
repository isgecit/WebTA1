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
Partial Class LC_elogChargeCodes
  Inherits System.Web.UI.UserControl
  Private _OrderBy As String = String.Empty
  Private _IncludeDefault As Boolean = True
  Private _DefaultText As String = "-- Select --"
  Private _DefaultValue As String = String.Empty
  Public Event SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
  Public Sub Clear()
    DDLelogChargeCodes.Items.Clear()
  End Sub
  Public Overrides Sub DataBind()
    DDLelogChargeCodes.DataBind()
  End Sub
  Public ReadOnly Property LCClientID() As String
    Get
      Return DDLelogChargeCodes.ClientID
    End Get
  End Property
  Public Property AddAttributes() As String
    Get
      Return DDLelogChargeCodes.Attributes.ToString
    End Get
    Set(ByVal value As String)
      Try
        Dim aVal() As String = value.Split(",".ToCharArray)
        DDLelogChargeCodes.Attributes.Add(aVal(0), aVal(1))
      Catch ex As Exception
      End Try
    End Set
  End Property
  Public Property CssClass() As String
    Get
      Return DDLelogChargeCodes.CssClass
    End Get
    Set(ByVal value As String)
      DDLelogChargeCodes.CssClass = value
    End Set
  End Property
  Public Property Width() As System.Web.UI.WebControls.Unit
    Get
      Return DDLelogChargeCodes.Width
    End Get
    Set(ByVal value As System.Web.UI.WebControls.Unit)
      DDLelogChargeCodes.Width = value
    End Set
  End Property
  Public Property RequiredFieldErrorMessage() As String
    Get
      Return RequiredFieldValidatorelogChargeCodes.Text
    End Get
    Set(ByVal value As String)
      RequiredFieldValidatorelogChargeCodes.Text = value
    End Set
  End Property
  Public Property ValidationGroup() As String
    Get
      Return RequiredFieldValidatorelogChargeCodes.ValidationGroup
    End Get
    Set(ByVal value As String)
      RequiredFieldValidatorelogChargeCodes.ValidationGroup = value
    End Set
  End Property
  Public Property Enabled() As Boolean
    Get
      Return DDLelogChargeCodes.Enabled
    End Get
    Set(ByVal value As Boolean)
      DDLelogChargeCodes.Enabled = value
      RequiredFieldValidatorelogChargeCodes.Enabled = value
    End Set
  End Property
  Public Property AutoPostBack() As Boolean
    Get
      Return DDLelogChargeCodes.AutoPostBack
    End Get
    Set(ByVal value As Boolean)
      DDLelogChargeCodes.AutoPostBack = value
    End Set
  End Property
  Public Property DataTextField() As String
    Get
      Return DDLelogChargeCodes.DataTextField
    End Get
    Set(ByVal value As String)
      DDLelogChargeCodes.DataTextField = value
    End Set
  End Property
  Public Property DataValueField() As String
    Get
      Return DDLelogChargeCodes.DataValueField
    End Get
    Set(ByVal value As String)
      DDLelogChargeCodes.DataValueField = value
    End Set
  End Property
  Public Property SelectedValue() As String
    Get
      Return DDLelogChargeCodes.SelectedValue
    End Get
    Set(ByVal value As String)
      If Convert.IsDBNull(value) Then
        DDLelogChargeCodes.SelectedValue = String.Empty
      Else
        DDLelogChargeCodes.SelectedValue = value
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
  Protected Sub OdsDdlelogChargeCodes_Selecting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceSelectingEventArgs) Handles OdsDdlelogChargeCodes.Selecting
    e.Arguments.SortExpression = _OrderBy
  End Sub
  Protected Sub DDLelogChargeCodes_DataBinding(ByVal sender As Object, ByVal e As System.EventArgs) Handles DDLelogChargeCodes.DataBinding
    If _IncludeDefault Then
      DDLelogChargeCodes.Items.Add(new ListItem(_DefaultText, _DefaultValue))
    End If
  End Sub
  Protected Sub DDLelogChargeCodes_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DDLelogChargeCodes.SelectedIndexChanged
    RaiseEvent SelectedIndexChanged(sender, e)
  End Sub
End Class
