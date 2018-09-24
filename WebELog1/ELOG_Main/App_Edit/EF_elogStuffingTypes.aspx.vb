Partial Class EF_elogStuffingTypes
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
  Protected Sub ODSelogStuffingTypes_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODSelogStuffingTypes.Selected
    Dim tmp As SIS.ELOG.elogStuffingTypes = CType(e.ReturnValue, SIS.ELOG.elogStuffingTypes)
    Editable = tmp.Editable
    Deleteable = tmp.Deleteable
    PrimaryKey = tmp.PrimaryKey
  End Sub
  Protected Sub FVelogStuffingTypes_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVelogStuffingTypes.Init
    DataClassName = "EelogStuffingTypes"
    SetFormView = FVelogStuffingTypes
  End Sub
  Protected Sub TBLelogStuffingTypes_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLelogStuffingTypes.Init
    SetToolBar = TBLelogStuffingTypes
  End Sub
  Protected Sub FVelogStuffingTypes_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVelogStuffingTypes.PreRender
    TBLelogStuffingTypes.EnableSave = Editable
    TBLelogStuffingTypes.EnableDelete = Deleteable
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/ELOG_Main/App_Edit") & "/EF_elogStuffingTypes.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptelogStuffingTypes") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptelogStuffingTypes", mStr)
    End If
  End Sub

End Class
