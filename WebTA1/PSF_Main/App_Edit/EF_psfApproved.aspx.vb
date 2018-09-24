Partial Class EF_psfApproved
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
  Protected Sub ODSpsfApproved_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODSpsfApproved.Selected
    Dim tmp As SIS.PSF.psfApproved = CType(e.ReturnValue, SIS.PSF.psfApproved)
    Editable = tmp.Editable
    Deleteable = tmp.Deleteable
    PrimaryKey = tmp.PrimaryKey
  End Sub
  Protected Sub FVpsfApproved_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpsfApproved.Init
    DataClassName = "EpsfApproved"
    SetFormView = FVpsfApproved
  End Sub
  Protected Sub TBLpsfApproved_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLpsfApproved.Init
    SetToolBar = TBLpsfApproved
  End Sub
  Protected Sub FVpsfApproved_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpsfApproved.PreRender
    TBLpsfApproved.EnableSave = Editable
    TBLpsfApproved.EnableDelete = Deleteable
    TBLpsfApproved.PrintUrl &= Request.QueryString("SerialNo") & "|"
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/PSF_Main/App_Edit") & "/EF_psfApproved.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptpsfApproved") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptpsfApproved", mStr)
    End If
  End Sub

End Class
