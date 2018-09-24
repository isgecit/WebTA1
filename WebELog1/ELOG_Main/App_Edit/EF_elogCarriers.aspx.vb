Partial Class EF_elogCarriers
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
  Protected Sub ODSelogCarriers_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODSelogCarriers.Selected
    Dim tmp As SIS.ELOG.elogCarriers = CType(e.ReturnValue, SIS.ELOG.elogCarriers)
    Editable = tmp.Editable
    Deleteable = tmp.Deleteable
    PrimaryKey = tmp.PrimaryKey
  End Sub
  Protected Sub FVelogCarriers_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVelogCarriers.Init
    DataClassName = "EelogCarriers"
    SetFormView = FVelogCarriers
  End Sub
  Protected Sub TBLelogCarriers_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLelogCarriers.Init
    SetToolBar = TBLelogCarriers
  End Sub
  Protected Sub FVelogCarriers_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVelogCarriers.PreRender
    TBLelogCarriers.EnableSave = Editable
    TBLelogCarriers.EnableDelete = Deleteable
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/ELOG_Main/App_Edit") & "/EF_elogCarriers.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptelogCarriers") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptelogCarriers", mStr)
    End If
  End Sub

End Class
