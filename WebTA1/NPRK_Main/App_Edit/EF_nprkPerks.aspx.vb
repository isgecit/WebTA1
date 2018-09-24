Partial Class EF_nprkPerks
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
  Protected Sub ODSnprkPerks_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODSnprkPerks.Selected
    Dim tmp As SIS.NPRK.nprkPerks = CType(e.ReturnValue, SIS.NPRK.nprkPerks)
    Editable = tmp.Editable
    Deleteable = tmp.Deleteable
    PrimaryKey = tmp.PrimaryKey
  End Sub
  Protected Sub FVnprkPerks_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVnprkPerks.Init
    DataClassName = "EnprkPerks"
    SetFormView = FVnprkPerks
  End Sub
  Protected Sub TBLnprkPerks_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLnprkPerks.Init
    SetToolBar = TBLnprkPerks
  End Sub
  Protected Sub FVnprkPerks_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVnprkPerks.PreRender
    TBLnprkPerks.EnableSave = Editable
    TBLnprkPerks.EnableDelete = Deleteable
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/NPRK_Main/App_Edit") & "/EF_nprkPerks.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptnprkPerks") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptnprkPerks", mStr)
    End If
  End Sub

End Class
