Partial Class EF_elogBreakbulkTypes
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
  Protected Sub ODSelogBreakbulkTypes_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODSelogBreakbulkTypes.Selected
    Dim tmp As SIS.ELOG.elogBreakbulkTypes = CType(e.ReturnValue, SIS.ELOG.elogBreakbulkTypes)
    Editable = tmp.Editable
    Deleteable = tmp.Deleteable
    PrimaryKey = tmp.PrimaryKey
  End Sub
  Protected Sub FVelogBreakbulkTypes_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVelogBreakbulkTypes.Init
    DataClassName = "EelogBreakbulkTypes"
    SetFormView = FVelogBreakbulkTypes
  End Sub
  Protected Sub TBLelogBreakbulkTypes_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLelogBreakbulkTypes.Init
    SetToolBar = TBLelogBreakbulkTypes
  End Sub
  Protected Sub FVelogBreakbulkTypes_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVelogBreakbulkTypes.PreRender
    TBLelogBreakbulkTypes.EnableSave = Editable
    TBLelogBreakbulkTypes.EnableDelete = Deleteable
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/ELOG_Main/App_Edit") & "/EF_elogBreakbulkTypes.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptelogBreakbulkTypes") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptelogBreakbulkTypes", mStr)
    End If
  End Sub

End Class
