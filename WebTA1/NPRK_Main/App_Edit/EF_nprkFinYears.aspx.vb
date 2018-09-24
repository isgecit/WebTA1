Partial Class EF_nprkFinYears
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
  Protected Sub ODSnprkFinYears_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODSnprkFinYears.Selected
    Dim tmp As SIS.NPRK.nprkFinYears = CType(e.ReturnValue, SIS.NPRK.nprkFinYears)
    Editable = tmp.Editable
    Deleteable = tmp.Deleteable
    PrimaryKey = tmp.PrimaryKey
  End Sub
  Protected Sub FVnprkFinYears_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVnprkFinYears.Init
    DataClassName = "EnprkFinYears"
    SetFormView = FVnprkFinYears
  End Sub
  Protected Sub TBLnprkFinYears_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLnprkFinYears.Init
    SetToolBar = TBLnprkFinYears
  End Sub
  Protected Sub FVnprkFinYears_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVnprkFinYears.PreRender
    TBLnprkFinYears.EnableSave = Editable
    TBLnprkFinYears.EnableDelete = Deleteable
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/NPRK_Main/App_Edit") & "/EF_nprkFinYears.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptnprkFinYears") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptnprkFinYears", mStr)
    End If
  End Sub

End Class
