Partial Class EF_psfSupplier
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
  Protected Sub ODSpsfSupplier_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODSpsfSupplier.Selected
    Dim tmp As SIS.PSF.psfSupplier = CType(e.ReturnValue, SIS.PSF.psfSupplier)
    Editable = tmp.Editable
    Deleteable = tmp.Deleteable
    PrimaryKey = tmp.PrimaryKey
  End Sub
  Protected Sub FVpsfSupplier_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpsfSupplier.Init
    DataClassName = "EpsfSupplier"
    SetFormView = FVpsfSupplier
  End Sub
  Protected Sub TBLpsfSupplier_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLpsfSupplier.Init
    SetToolBar = TBLpsfSupplier
  End Sub
  Protected Sub FVpsfSupplier_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpsfSupplier.PreRender
    TBLpsfSupplier.EnableSave = Editable
    TBLpsfSupplier.EnableDelete = Deleteable
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/PSF_Main/App_Edit") & "/EF_psfSupplier.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptpsfSupplier") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptpsfSupplier", mStr)
    End If
  End Sub

End Class
