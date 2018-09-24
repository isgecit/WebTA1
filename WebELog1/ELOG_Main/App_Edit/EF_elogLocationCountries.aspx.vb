Partial Class EF_elogLocationCountries
  Inherits SIS.SYS.UpdateBase
  Public Property Editable() As Boolean
    Get
      If ViewState("Editable") IsNot Nothing Then
        Return CType(ViewState("Editable"), Boolean)
      End If
      Return True
    End Get
    Set(ByVal value As Boolean)
      ViewState.Add("Editable", value)
    End Set
  End Property
  Public Property Deleteable() As Boolean
    Get
      If ViewState("Deleteable") IsNot Nothing Then
        Return CType(ViewState("Deleteable"), Boolean)
      End If
      Return True
    End Get
    Set(ByVal value As Boolean)
      ViewState.Add("Deleteable", value)
    End Set
  End Property
  Public Property PrimaryKey() As String
    Get
      If ViewState("PrimaryKey") IsNot Nothing Then
        Return CType(ViewState("PrimaryKey"), String)
      End If
      Return True
    End Get
    Set(ByVal value As String)
      ViewState.Add("PrimaryKey", value)
    End Set
  End Property
  Protected Sub ODSelogLocationCountries_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODSelogLocationCountries.Selected
    Dim tmp As SIS.ELOG.elogLocationCountries = CType(e.ReturnValue, SIS.ELOG.elogLocationCountries)
    Editable = tmp.Editable
    Deleteable = tmp.Deleteable
    PrimaryKey = tmp.PrimaryKey
  End Sub
  Protected Sub FVelogLocationCountries_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVelogLocationCountries.Init
    DataClassName = "EelogLocationCountries"
    SetFormView = FVelogLocationCountries
  End Sub
  Protected Sub TBLelogLocationCountries_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLelogLocationCountries.Init
    SetToolBar = TBLelogLocationCountries
  End Sub
  Protected Sub FVelogLocationCountries_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVelogLocationCountries.PreRender
    TBLelogLocationCountries.EnableSave = Editable
    TBLelogLocationCountries.EnableDelete = Deleteable
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/ELOG_Main/App_Edit") & "/EF_elogLocationCountries.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptelogLocationCountries") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptelogLocationCountries", mStr)
    End If
  End Sub

End Class
