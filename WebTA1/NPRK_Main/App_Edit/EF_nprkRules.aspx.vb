Partial Class EF_nprkRules
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
  Protected Sub ODSnprkRules_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODSnprkRules.Selected
    Dim tmp As SIS.NPRK.nprkRules = CType(e.ReturnValue, SIS.NPRK.nprkRules)
    Editable = tmp.Editable
    Deleteable = tmp.Deleteable
    PrimaryKey = tmp.PrimaryKey
  End Sub
  Protected Sub FVnprkRules_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVnprkRules.Init
    DataClassName = "EnprkRules"
    SetFormView = FVnprkRules
  End Sub
  Protected Sub TBLnprkRules_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLnprkRules.Init
    SetToolBar = TBLnprkRules
  End Sub
  Protected Sub FVnprkRules_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVnprkRules.PreRender
    TBLnprkRules.EnableSave = Editable
    TBLnprkRules.EnableDelete = Deleteable
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/NPRK_Main/App_Edit") & "/EF_nprkRules.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptnprkRules") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptnprkRules", mStr)
    End If
  End Sub

End Class
