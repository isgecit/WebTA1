Partial Class EF_elogBLDetails
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
  Protected Sub ODSelogBLDetails_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODSelogBLDetails.Selected
    Dim tmp As SIS.ELOG.elogBLDetails = CType(e.ReturnValue, SIS.ELOG.elogBLDetails)
    Editable = tmp.Editable
    Deleteable = tmp.Deleteable
    PrimaryKey = tmp.PrimaryKey
  End Sub
  Protected Sub FVelogBLDetails_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVelogBLDetails.Init
    DataClassName = "EelogBLDetails"
    SetFormView = FVelogBLDetails
  End Sub
  Protected Sub TBLelogBLDetails_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLelogBLDetails.Init
    SetToolBar = TBLelogBLDetails
  End Sub
  Protected Sub FVelogBLDetails_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVelogBLDetails.PreRender
    TBLelogBLDetails.EnableSave = Editable
    TBLelogBLDetails.EnableDelete = Deleteable
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/ELOG_Main/App_Edit") & "/EF_elogBLDetails.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptelogBLDetails") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptelogBLDetails", mStr)
    End If
  End Sub

End Class
