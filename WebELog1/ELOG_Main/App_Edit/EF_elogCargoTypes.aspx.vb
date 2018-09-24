Partial Class EF_elogCargoTypes
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
  Protected Sub ODSelogCargoTypes_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODSelogCargoTypes.Selected
    Dim tmp As SIS.ELOG.elogCargoTypes = CType(e.ReturnValue, SIS.ELOG.elogCargoTypes)
    Editable = tmp.Editable
    Deleteable = tmp.Deleteable
    PrimaryKey = tmp.PrimaryKey
  End Sub
  Protected Sub FVelogCargoTypes_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVelogCargoTypes.Init
    DataClassName = "EelogCargoTypes"
    SetFormView = FVelogCargoTypes
  End Sub
  Protected Sub TBLelogCargoTypes_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLelogCargoTypes.Init
    SetToolBar = TBLelogCargoTypes
  End Sub
  Protected Sub FVelogCargoTypes_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVelogCargoTypes.PreRender
    TBLelogCargoTypes.EnableSave = Editable
    TBLelogCargoTypes.EnableDelete = Deleteable
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/ELOG_Main/App_Edit") & "/EF_elogCargoTypes.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptelogCargoTypes") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptelogCargoTypes", mStr)
    End If
  End Sub

End Class
