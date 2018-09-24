Partial Class EF_nprkEmployees
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
  Protected Sub ODSnprkEmployees_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODSnprkEmployees.Selected
    Dim tmp As SIS.NPRK.nprkEmployees = CType(e.ReturnValue, SIS.NPRK.nprkEmployees)
    Editable = tmp.Editable
    Deleteable = tmp.Deleteable
    PrimaryKey = tmp.PrimaryKey
  End Sub
  Protected Sub FVnprkEmployees_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVnprkEmployees.Init
    DataClassName = "EnprkEmployees"
    SetFormView = FVnprkEmployees
  End Sub
  Protected Sub TBLnprkEmployees_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLnprkEmployees.Init
    SetToolBar = TBLnprkEmployees
  End Sub
  Protected Sub FVnprkEmployees_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVnprkEmployees.PreRender
    TBLnprkEmployees.EnableSave = Editable
    TBLnprkEmployees.EnableDelete = Deleteable
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/NPRK_Main/App_Edit") & "/EF_nprkEmployees.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptnprkEmployees") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptnprkEmployees", mStr)
    End If
  End Sub

End Class
