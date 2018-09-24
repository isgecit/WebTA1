Partial Class EF_nprkSiteAllowanceClaims
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
  Protected Sub ODSnprkSiteAllowanceClaims_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODSnprkSiteAllowanceClaims.Selected
    Dim tmp As SIS.NPRK.nprkSiteAllowanceClaims = CType(e.ReturnValue, SIS.NPRK.nprkSiteAllowanceClaims)
    Editable = tmp.Editable
    Deleteable = tmp.Deleteable
    PrimaryKey = tmp.PrimaryKey
  End Sub
  Protected Sub FVnprkSiteAllowanceClaims_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVnprkSiteAllowanceClaims.Init
    DataClassName = "EnprkSiteAllowanceClaims"
    SetFormView = FVnprkSiteAllowanceClaims
  End Sub
  Protected Sub TBLnprkSiteAllowanceClaims_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLnprkSiteAllowanceClaims.Init
    SetToolBar = TBLnprkSiteAllowanceClaims
  End Sub
  Protected Sub FVnprkSiteAllowanceClaims_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVnprkSiteAllowanceClaims.PreRender
    TBLnprkSiteAllowanceClaims.EnableSave = Editable
    TBLnprkSiteAllowanceClaims.EnableDelete = Deleteable
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/NPRK_Main/App_Edit") & "/EF_nprkSiteAllowanceClaims.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptnprkSiteAllowanceClaims") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptnprkSiteAllowanceClaims", mStr)
    End If
  End Sub

End Class
