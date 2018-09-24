Partial Class EF_psfStatus
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
  Protected Sub ODSpsfStatus_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODSpsfStatus.Selected
    Dim tmp As SIS.PSF.psfStatus = CType(e.ReturnValue, SIS.PSF.psfStatus)
    Editable = tmp.Editable
    Deleteable = tmp.Deleteable
    PrimaryKey = tmp.PrimaryKey
  End Sub
  Protected Sub FVpsfStatus_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpsfStatus.Init
    DataClassName = "EpsfStatus"
    SetFormView = FVpsfStatus
  End Sub
  Protected Sub TBLpsfStatus_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLpsfStatus.Init
    SetToolBar = TBLpsfStatus
  End Sub
  Protected Sub FVpsfStatus_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpsfStatus.PreRender
    TBLpsfStatus.EnableSave = Editable
    TBLpsfStatus.EnableDelete = Deleteable
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/PSF_Main/App_Edit") & "/EF_psfStatus.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptpsfStatus") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptpsfStatus", mStr)
    End If
  End Sub

End Class
