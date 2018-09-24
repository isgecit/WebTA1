Partial Class EF_nprkSiteAllowanceEntitlement
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
  Protected Sub ODSnprkSiteAllowanceEntitlement_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODSnprkSiteAllowanceEntitlement.Selected
    Dim tmp As SIS.NPRK.nprkSiteAllowanceEntitlement = CType(e.ReturnValue, SIS.NPRK.nprkSiteAllowanceEntitlement)
    Editable = tmp.Editable
    Deleteable = tmp.Deleteable
    PrimaryKey = tmp.PrimaryKey
  End Sub
  Protected Sub FVnprkSiteAllowanceEntitlement_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVnprkSiteAllowanceEntitlement.Init
    DataClassName = "EnprkSiteAllowanceEntitlement"
    SetFormView = FVnprkSiteAllowanceEntitlement
  End Sub
  Protected Sub TBLnprkSiteAllowanceEntitlement_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLnprkSiteAllowanceEntitlement.Init
    SetToolBar = TBLnprkSiteAllowanceEntitlement
  End Sub
  Protected Sub FVnprkSiteAllowanceEntitlement_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVnprkSiteAllowanceEntitlement.PreRender
    TBLnprkSiteAllowanceEntitlement.EnableSave = Editable
    TBLnprkSiteAllowanceEntitlement.EnableDelete = Deleteable
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/NPRK_Main/App_Edit") & "/EF_nprkSiteAllowanceEntitlement.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptnprkSiteAllowanceEntitlement") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptnprkSiteAllowanceEntitlement", mStr)
    End If
  End Sub

End Class
