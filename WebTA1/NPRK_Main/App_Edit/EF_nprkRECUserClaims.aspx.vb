Partial Class EF_nprkRECUserClaims
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
  Protected Sub ODSnprkRECUserClaims_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODSnprkRECUserClaims.Selected
    Dim tmp As SIS.NPRK.nprkRECUserClaims = CType(e.ReturnValue, SIS.NPRK.nprkRECUserClaims)
    Editable = tmp.Editable
    Deleteable = tmp.Deleteable
    PrimaryKey = tmp.PrimaryKey
  End Sub
  Protected Sub FVnprkRECUserClaims_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVnprkRECUserClaims.Init
    DataClassName = "EnprkRECUserClaims"
    SetFormView = FVnprkRECUserClaims
  End Sub
  Protected Sub TBLnprkRECUserClaims_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLnprkRECUserClaims.Init
    SetToolBar = TBLnprkRECUserClaims
  End Sub
  Protected Sub FVnprkRECUserClaims_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVnprkRECUserClaims.PreRender
    TBLnprkRECUserClaims.EnableSave = Editable
    TBLnprkRECUserClaims.EnableDelete = Deleteable
    TBLnprkRECUserClaims.PrintUrl &= Request.QueryString("ClaimID") & "|"
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/NPRK_Main/App_Edit") & "/EF_nprkRECUserClaims.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptnprkRECUserClaims") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptnprkRECUserClaims", mStr)
    End If
  End Sub

End Class
