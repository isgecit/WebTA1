Partial Class EF_nprkSAAdviceStatus
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
  Protected Sub ODSnprkSAAdviceStatus_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODSnprkSAAdviceStatus.Selected
    Dim tmp As SIS.NPRK.nprkSAAdviceStatus = CType(e.ReturnValue, SIS.NPRK.nprkSAAdviceStatus)
    Editable = tmp.Editable
    Deleteable = tmp.Deleteable
    PrimaryKey = tmp.PrimaryKey
  End Sub
  Protected Sub FVnprkSAAdviceStatus_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVnprkSAAdviceStatus.Init
    DataClassName = "EnprkSAAdviceStatus"
    SetFormView = FVnprkSAAdviceStatus
  End Sub
  Protected Sub TBLnprkSAAdviceStatus_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLnprkSAAdviceStatus.Init
    SetToolBar = TBLnprkSAAdviceStatus
  End Sub
  Protected Sub FVnprkSAAdviceStatus_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVnprkSAAdviceStatus.PreRender
    TBLnprkSAAdviceStatus.EnableSave = Editable
    TBLnprkSAAdviceStatus.EnableDelete = Deleteable
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/NPRK_Main/App_Edit") & "/EF_nprkSAAdviceStatus.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptnprkSAAdviceStatus") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptnprkSAAdviceStatus", mStr)
    End If
  End Sub

End Class
