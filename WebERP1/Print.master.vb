
Partial Class Print
  Inherits System.Web.UI.MasterPage
  Public Property EncType() As String
    Get
      Return form1.Enctype
    End Get
    Set(ByVal value As String)
      form1.Enctype = value
    End Set
  End Property
  Public Property Method() As String
    Get
      Return form1.Method
    End Get
    Set(ByVal value As String)
      form1.Method = value
    End Set
  End Property
End Class

