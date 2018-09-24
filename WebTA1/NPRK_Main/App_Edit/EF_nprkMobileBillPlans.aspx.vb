Partial Class EF_nprkMobileBillPlans
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
  Protected Sub ODSnprkMobileBillPlans_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODSnprkMobileBillPlans.Selected
    Dim tmp As SIS.NPRK.nprkMobileBillPlans = CType(e.ReturnValue, SIS.NPRK.nprkMobileBillPlans)
    Editable = tmp.Editable
    Deleteable = tmp.Deleteable
    PrimaryKey = tmp.PrimaryKey
  End Sub
  Protected Sub FVnprkMobileBillPlans_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVnprkMobileBillPlans.Init
    DataClassName = "EnprkMobileBillPlans"
    SetFormView = FVnprkMobileBillPlans
  End Sub
  Protected Sub TBLnprkMobileBillPlans_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLnprkMobileBillPlans.Init
    SetToolBar = TBLnprkMobileBillPlans
  End Sub
  Protected Sub FVnprkMobileBillPlans_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVnprkMobileBillPlans.PreRender
    TBLnprkMobileBillPlans.EnableSave = Editable
    TBLnprkMobileBillPlans.EnableDelete = Deleteable
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/NPRK_Main/App_Edit") & "/EF_nprkMobileBillPlans.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptnprkMobileBillPlans") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptnprkMobileBillPlans", mStr)
    End If
  End Sub

End Class
