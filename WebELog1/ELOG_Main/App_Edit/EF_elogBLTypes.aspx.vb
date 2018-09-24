Partial Class EF_elogBLTypes
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
  Protected Sub ODSelogBLTypes_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODSelogBLTypes.Selected
    Dim tmp As SIS.ELOG.elogBLTypes = CType(e.ReturnValue, SIS.ELOG.elogBLTypes)
    Editable = tmp.Editable
    Deleteable = tmp.Deleteable
    PrimaryKey = tmp.PrimaryKey
  End Sub
  Protected Sub FVelogBLTypes_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVelogBLTypes.Init
    DataClassName = "EelogBLTypes"
    SetFormView = FVelogBLTypes
  End Sub
  Protected Sub TBLelogBLTypes_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLelogBLTypes.Init
    SetToolBar = TBLelogBLTypes
  End Sub
  Protected Sub FVelogBLTypes_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVelogBLTypes.PreRender
    TBLelogBLTypes.EnableSave = Editable
    TBLelogBLTypes.EnableDelete = Deleteable
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/ELOG_Main/App_Edit") & "/EF_elogBLTypes.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptelogBLTypes") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptelogBLTypes", mStr)
    End If
  End Sub

End Class
