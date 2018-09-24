Partial Class EF_psfApproval
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
  Protected Sub ODSpsfApproval_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODSpsfApproval.Selected
    Dim tmp As SIS.PSF.psfApproval = CType(e.ReturnValue, SIS.PSF.psfApproval)
    Editable = tmp.Editable
    Deleteable = tmp.Deleteable
    PrimaryKey = tmp.PrimaryKey
  End Sub
  Protected Sub FVpsfApproval_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpsfApproval.Init
    DataClassName = "EpsfApproval"
    SetFormView = FVpsfApproval
  End Sub
  Protected Sub TBLpsfApproval_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLpsfApproval.Init
    SetToolBar = TBLpsfApproval
  End Sub
  Protected Sub FVpsfApproval_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpsfApproval.PreRender
    TBLpsfApproval.EnableSave = Editable
    TBLpsfApproval.EnableDelete = Deleteable
    TBLpsfApproval.PrintUrl &= Request.QueryString("SerialNo") & "|"
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/PSF_Main/App_Edit") & "/EF_psfApproval.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptpsfApproval") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptpsfApproval", mStr)
    End If
  End Sub

End Class
