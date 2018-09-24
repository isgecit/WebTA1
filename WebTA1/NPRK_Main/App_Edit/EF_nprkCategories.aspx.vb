Partial Class EF_nprkCategories
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
  Protected Sub ODSnprkCategories_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODSnprkCategories.Selected
    Dim tmp As SIS.NPRK.nprkCategories = CType(e.ReturnValue, SIS.NPRK.nprkCategories)
    Editable = tmp.Editable
    Deleteable = tmp.Deleteable
    PrimaryKey = tmp.PrimaryKey
  End Sub
  Protected Sub FVnprkCategories_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVnprkCategories.Init
    DataClassName = "EnprkCategories"
    SetFormView = FVnprkCategories
  End Sub
  Protected Sub TBLnprkCategories_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLnprkCategories.Init
    SetToolBar = TBLnprkCategories
  End Sub
  Protected Sub FVnprkCategories_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVnprkCategories.PreRender
    TBLnprkCategories.EnableSave = Editable
    TBLnprkCategories.EnableDelete = Deleteable
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/NPRK_Main/App_Edit") & "/EF_nprkCategories.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptnprkCategories") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptnprkCategories", mStr)
    End If
  End Sub

End Class
