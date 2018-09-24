Partial Class EF_nprkStatus
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
  Protected Sub ODSnprkStatus_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODSnprkStatus.Selected
    Dim tmp As SIS.NPRK.nprkStatus = CType(e.ReturnValue, SIS.NPRK.nprkStatus)
    Editable = tmp.Editable
    Deleteable = tmp.Deleteable
    PrimaryKey = tmp.PrimaryKey
  End Sub
  Protected Sub FVnprkStatus_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVnprkStatus.Init
    DataClassName = "EnprkStatus"
    SetFormView = FVnprkStatus
  End Sub
  Protected Sub TBLnprkStatus_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLnprkStatus.Init
    SetToolBar = TBLnprkStatus
  End Sub
  Protected Sub FVnprkStatus_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVnprkStatus.PreRender
    TBLnprkStatus.EnableSave = Editable
    TBLnprkStatus.EnableDelete = Deleteable
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/NPRK_Main/App_Edit") & "/EF_nprkStatus.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptnprkStatus") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptnprkStatus", mStr)
    End If
  End Sub

End Class
