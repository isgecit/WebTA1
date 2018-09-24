Partial Class EF_nprkPetrolRate
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
  Protected Sub ODSnprkPetrolRate_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODSnprkPetrolRate.Selected
    Dim tmp As SIS.NPRK.nprkPetrolRate = CType(e.ReturnValue, SIS.NPRK.nprkPetrolRate)
    Editable = tmp.Editable
    Deleteable = tmp.Deleteable
    PrimaryKey = tmp.PrimaryKey
  End Sub
  Protected Sub FVnprkPetrolRate_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVnprkPetrolRate.Init
    DataClassName = "EnprkPetrolRate"
    SetFormView = FVnprkPetrolRate
  End Sub
  Protected Sub TBLnprkPetrolRate_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLnprkPetrolRate.Init
    SetToolBar = TBLnprkPetrolRate
  End Sub
  Protected Sub FVnprkPetrolRate_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVnprkPetrolRate.PreRender
    TBLnprkPetrolRate.EnableSave = Editable
    TBLnprkPetrolRate.EnableDelete = Deleteable
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/NPRK_Main/App_Edit") & "/EF_nprkPetrolRate.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptnprkPetrolRate") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptnprkPetrolRate", mStr)
    End If
  End Sub

End Class
