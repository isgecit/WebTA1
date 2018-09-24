Partial Class EF_hrmOfficeLocation
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
  Protected Sub ODShrmOfficeLocation_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODShrmOfficeLocation.Selected
    Dim tmp As SIS.HRM.hrmOfficeLocation = CType(e.ReturnValue, SIS.HRM.hrmOfficeLocation)
    Editable = tmp.Editable
    Deleteable = tmp.Deleteable
    PrimaryKey = tmp.PrimaryKey
  End Sub
  Protected Sub FVhrmOfficeLocation_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVhrmOfficeLocation.Init
    DataClassName = "EhrmOfficeLocation"
    SetFormView = FVhrmOfficeLocation
  End Sub
  Protected Sub TBLhrmOfficeLocation_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLhrmOfficeLocation.Init
    SetToolBar = TBLhrmOfficeLocation
  End Sub
  Protected Sub FVhrmOfficeLocation_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVhrmOfficeLocation.PreRender
    TBLhrmOfficeLocation.EnableSave = Editable
    TBLhrmOfficeLocation.EnableDelete = Deleteable
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/HRM_Main/App_Edit") & "/EF_hrmOfficeLocation.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scripthrmOfficeLocation") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scripthrmOfficeLocation", mStr)
    End If
  End Sub

End Class
