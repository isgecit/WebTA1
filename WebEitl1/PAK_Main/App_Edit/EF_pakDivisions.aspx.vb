Partial Class EF_pakDivisions
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
  Protected Sub ODSpakDivisions_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODSpakDivisions.Selected
    Dim tmp As SIS.PAK.pakDivisions = CType(e.ReturnValue, SIS.PAK.pakDivisions)
    Editable = tmp.Editable
    Deleteable = tmp.Deleteable
    PrimaryKey = tmp.PrimaryKey
  End Sub
  Protected Sub FVpakDivisions_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpakDivisions.Init
    DataClassName = "EpakDivisions"
    SetFormView = FVpakDivisions
  End Sub
  Protected Sub TBLpakDivisions_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLpakDivisions.Init
    SetToolBar = TBLpakDivisions
  End Sub
  Protected Sub FVpakDivisions_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpakDivisions.PreRender
    TBLpakDivisions.EnableSave = Editable
    TBLpakDivisions.EnableDelete = Deleteable
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/PAK_Main/App_Edit") & "/EF_pakDivisions.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptpakDivisions") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptpakDivisions", mStr)
    End If
  End Sub

End Class
