Partial Class EF_elogStuffingPoints
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
  Protected Sub ODSelogStuffingPoints_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODSelogStuffingPoints.Selected
    Dim tmp As SIS.ELOG.elogStuffingPoints = CType(e.ReturnValue, SIS.ELOG.elogStuffingPoints)
    Editable = tmp.Editable
    Deleteable = tmp.Deleteable
    PrimaryKey = tmp.PrimaryKey
  End Sub
  Protected Sub FVelogStuffingPoints_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVelogStuffingPoints.Init
    DataClassName = "EelogStuffingPoints"
    SetFormView = FVelogStuffingPoints
  End Sub
  Protected Sub TBLelogStuffingPoints_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLelogStuffingPoints.Init
    SetToolBar = TBLelogStuffingPoints
  End Sub
  Protected Sub FVelogStuffingPoints_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVelogStuffingPoints.PreRender
    TBLelogStuffingPoints.EnableSave = Editable
    TBLelogStuffingPoints.EnableDelete = Deleteable
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/ELOG_Main/App_Edit") & "/EF_elogStuffingPoints.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptelogStuffingPoints") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptelogStuffingPoints", mStr)
    End If
  End Sub

End Class
