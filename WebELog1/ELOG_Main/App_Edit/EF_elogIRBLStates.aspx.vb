Partial Class EF_elogIRBLStates
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
  Protected Sub ODSelogIRBLStates_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODSelogIRBLStates.Selected
    Dim tmp As SIS.ELOG.elogIRBLStates = CType(e.ReturnValue, SIS.ELOG.elogIRBLStates)
    Editable = tmp.Editable
    Deleteable = tmp.Deleteable
    PrimaryKey = tmp.PrimaryKey
  End Sub
  Protected Sub FVelogIRBLStates_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVelogIRBLStates.Init
    DataClassName = "EelogIRBLStates"
    SetFormView = FVelogIRBLStates
  End Sub
  Protected Sub TBLelogIRBLStates_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLelogIRBLStates.Init
    SetToolBar = TBLelogIRBLStates
  End Sub
  Protected Sub FVelogIRBLStates_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVelogIRBLStates.PreRender
    TBLelogIRBLStates.EnableSave = Editable
    TBLelogIRBLStates.EnableDelete = Deleteable
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/ELOG_Main/App_Edit") & "/EF_elogIRBLStates.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptelogIRBLStates") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptelogIRBLStates", mStr)
    End If
  End Sub

End Class
