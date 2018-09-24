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
Partial Class LC_elogCarriers
  Inherits System.Web.UI.UserControl
  Private _OrderBy As String = String.Empty
  Private _IncludeDefault As Boolean = True
  Private _DefaultText As String = "-- Select --"
  Private _DefaultValue As String = String.Empty
  Public Event SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
  Public Sub Clear()
    DDLelogCarriers.Items.Clear()
  End Sub
  Public Overrides Sub DataBind()
    'DDLelogCarriers.Items.Clear()
    DDLelogCarriers.DataBind()
    'MyBase.OnDataBinding(EventArgs.Empty)
    '' Reset the control's state.
    'Controls.Clear()
    '' Check for HasChildViewState to avoid unnecessary calls to ClearChildViewState.
    'If HasChildViewState Then
    '  ClearChildViewState()
    'End If
    'ChildControlsCreated = True
    'If Not IsTrackingViewState Then
    '  TrackViewState()
    'End If
  End Sub
  Public Overrides Property EnableViewState As Boolean
    Get
      Return DDLelogCarriers.EnableViewState
    End Get
    Set(value As Boolean)
      MyBase.EnableViewState = value
      DDLelogCarriers.EnableViewState = value
    End Set
  End Property

  Public ReadOnly Property LCClientID() As String
    Get
      Return DDLelogCarriers.ClientID
    End Get
  End Property
  Public Property AddAttributes() As String
    Get
      Return DDLelogCarriers.Attributes.ToString
    End Get
    Set(ByVal value As String)
      Try
        Dim aVal() As String = value.Split(",".ToCharArray)
        DDLelogCarriers.Attributes.Add(aVal(0), aVal(1))
      Catch ex As Exception
      End Try
    End Set
  End Property
  Public Property CssClass() As String
    Get
      Return DDLelogCarriers.CssClass
    End Get
    Set(ByVal value As String)
      DDLelogCarriers.CssClass = value
    End Set
  End Property
  Public Property Width() As System.Web.UI.WebControls.Unit
    Get
      Return DDLelogCarriers.Width
    End Get
    Set(ByVal value As System.Web.UI.WebControls.Unit)
      DDLelogCarriers.Width = value
    End Set
  End Property
  Public Property RequiredFieldErrorMessage() As String
    Get
      Return RequiredFieldValidatorelogCarriers.Text
    End Get
    Set(ByVal value As String)
      RequiredFieldValidatorelogCarriers.Text = value
    End Set
  End Property
  Public Property ValidationGroup() As String
    Get
      Return RequiredFieldValidatorelogCarriers.ValidationGroup
    End Get
    Set(ByVal value As String)
      RequiredFieldValidatorelogCarriers.ValidationGroup = value
    End Set
  End Property
  Public Property Enabled() As Boolean
    Get
      Return DDLelogCarriers.Enabled
    End Get
    Set(ByVal value As Boolean)
      DDLelogCarriers.Enabled = value
      RequiredFieldValidatorelogCarriers.Enabled = value
    End Set
  End Property
  Public Property AutoPostBack() As Boolean
    Get
      Return DDLelogCarriers.AutoPostBack
    End Get
    Set(ByVal value As Boolean)
      DDLelogCarriers.AutoPostBack = value
    End Set
  End Property
  Public Property DataTextField() As String
    Get
      Return DDLelogCarriers.DataTextField
    End Get
    Set(ByVal value As String)
      DDLelogCarriers.DataTextField = value
    End Set
  End Property
  Public Property DataValueField() As String
    Get
      Return DDLelogCarriers.DataValueField
    End Get
    Set(ByVal value As String)
      DDLelogCarriers.DataValueField = value
    End Set
  End Property
  Public Property SelectedValue() As String
    Get
      Return DDLelogCarriers.SelectedValue
    End Get
    Set(ByVal value As String)
      If Convert.IsDBNull(value) Then
        DDLelogCarriers.SelectedValue = String.Empty
      Else
        DDLelogCarriers.SelectedValue = value
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
  Protected Sub OdsDdlelogCarriers_Selecting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceSelectingEventArgs) Handles OdsDdlelogCarriers.Selecting
    e.Arguments.SortExpression = _OrderBy
  End Sub
  Protected Sub DDLelogCarriers_DataBinding(ByVal sender As Object, ByVal e As System.EventArgs) Handles DDLelogCarriers.DataBinding
    If _IncludeDefault Then
      DDLelogCarriers.Items.Add(new ListItem(_DefaultText, _DefaultValue))
    End If
  End Sub
  Protected Sub DDLelogCarriers_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DDLelogCarriers.SelectedIndexChanged
    RaiseEvent SelectedIndexChanged(sender, e)
  End Sub
End Class
