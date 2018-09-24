Partial Class EF_elogChargeTypes
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
  Protected Sub ODSelogChargeTypes_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODSelogChargeTypes.Selected
    Dim tmp As SIS.ELOG.elogChargeTypes = CType(e.ReturnValue, SIS.ELOG.elogChargeTypes)
    Editable = tmp.Editable
    Deleteable = tmp.Deleteable
    PrimaryKey = tmp.PrimaryKey
  End Sub
  Protected Sub FVelogChargeTypes_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVelogChargeTypes.Init
    DataClassName = "EelogChargeTypes"
    SetFormView = FVelogChargeTypes
  End Sub
  Protected Sub TBLelogChargeTypes_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLelogChargeTypes.Init
    SetToolBar = TBLelogChargeTypes
  End Sub
  Protected Sub FVelogChargeTypes_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVelogChargeTypes.PreRender
    TBLelogChargeTypes.EnableSave = Editable
    TBLelogChargeTypes.EnableDelete = Deleteable
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/ELOG_Main/App_Edit") & "/EF_elogChargeTypes.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptelogChargeTypes") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptelogChargeTypes", mStr)
    End If
  End Sub

End Class
