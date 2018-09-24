Partial Class EF_nprkSAClaimStatus
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
  Protected Sub ODSnprkSAClaimStatus_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODSnprkSAClaimStatus.Selected
    Dim tmp As SIS.NPRK.nprkSAClaimStatus = CType(e.ReturnValue, SIS.NPRK.nprkSAClaimStatus)
    Editable = tmp.Editable
    Deleteable = tmp.Deleteable
    PrimaryKey = tmp.PrimaryKey
  End Sub
  Protected Sub FVnprkSAClaimStatus_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVnprkSAClaimStatus.Init
    DataClassName = "EnprkSAClaimStatus"
    SetFormView = FVnprkSAClaimStatus
  End Sub
  Protected Sub TBLnprkSAClaimStatus_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLnprkSAClaimStatus.Init
    SetToolBar = TBLnprkSAClaimStatus
  End Sub
  Protected Sub FVnprkSAClaimStatus_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVnprkSAClaimStatus.PreRender
    TBLnprkSAClaimStatus.EnableSave = Editable
    TBLnprkSAClaimStatus.EnableDelete = Deleteable
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/NPRK_Main/App_Edit") & "/EF_nprkSAClaimStatus.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptnprkSAClaimStatus") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptnprkSAClaimStatus", mStr)
    End If
  End Sub

End Class
