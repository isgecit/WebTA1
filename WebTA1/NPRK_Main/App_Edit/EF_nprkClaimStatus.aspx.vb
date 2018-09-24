Partial Class EF_nprkClaimStatus
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
  Protected Sub ODSnprkClaimStatus_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODSnprkClaimStatus.Selected
    Dim tmp As SIS.NPRK.nprkClaimStatus = CType(e.ReturnValue, SIS.NPRK.nprkClaimStatus)
    Editable = tmp.Editable
    Deleteable = tmp.Deleteable
    PrimaryKey = tmp.PrimaryKey
  End Sub
  Protected Sub FVnprkClaimStatus_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVnprkClaimStatus.Init
    DataClassName = "EnprkClaimStatus"
    SetFormView = FVnprkClaimStatus
  End Sub
  Protected Sub TBLnprkClaimStatus_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLnprkClaimStatus.Init
    SetToolBar = TBLnprkClaimStatus
  End Sub
  Protected Sub FVnprkClaimStatus_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVnprkClaimStatus.PreRender
    TBLnprkClaimStatus.EnableSave = Editable
    TBLnprkClaimStatus.EnableDelete = Deleteable
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/NPRK_Main/App_Edit") & "/EF_nprkClaimStatus.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptnprkClaimStatus") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptnprkClaimStatus", mStr)
    End If
  End Sub

End Class
