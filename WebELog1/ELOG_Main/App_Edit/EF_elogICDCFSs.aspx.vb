Partial Class EF_elogICDCFSs
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
  Protected Sub ODSelogICDCFSs_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODSelogICDCFSs.Selected
    Dim tmp As SIS.ELOG.elogICDCFSs = CType(e.ReturnValue, SIS.ELOG.elogICDCFSs)
    Editable = tmp.Editable
    Deleteable = tmp.Deleteable
    PrimaryKey = tmp.PrimaryKey
  End Sub
  Protected Sub FVelogICDCFSs_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVelogICDCFSs.Init
    DataClassName = "EelogICDCFSs"
    SetFormView = FVelogICDCFSs
  End Sub
  Protected Sub TBLelogICDCFSs_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLelogICDCFSs.Init
    SetToolBar = TBLelogICDCFSs
  End Sub
  Protected Sub FVelogICDCFSs_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVelogICDCFSs.PreRender
    TBLelogICDCFSs.EnableSave = Editable
    TBLelogICDCFSs.EnableDelete = Deleteable
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/ELOG_Main/App_Edit") & "/EF_elogICDCFSs.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptelogICDCFSs") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptelogICDCFSs", mStr)
    End If
  End Sub

End Class
