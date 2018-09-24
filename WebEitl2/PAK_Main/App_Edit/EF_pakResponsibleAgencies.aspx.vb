Partial Class EF_pakResponsibleAgencies
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
  Protected Sub ODSpakResponsibleAgencies_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODSpakResponsibleAgencies.Selected
    Dim tmp As SIS.PAK.pakResponsibleAgencies = CType(e.ReturnValue, SIS.PAK.pakResponsibleAgencies)
    Editable = tmp.Editable
    Deleteable = tmp.Deleteable
    PrimaryKey = tmp.PrimaryKey
  End Sub
  Protected Sub FVpakResponsibleAgencies_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpakResponsibleAgencies.Init
    DataClassName = "EpakResponsibleAgencies"
    SetFormView = FVpakResponsibleAgencies
  End Sub
  Protected Sub TBLpakResponsibleAgencies_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLpakResponsibleAgencies.Init
    SetToolBar = TBLpakResponsibleAgencies
  End Sub
  Protected Sub FVpakResponsibleAgencies_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpakResponsibleAgencies.PreRender
    TBLpakResponsibleAgencies.EnableSave = Editable
    TBLpakResponsibleAgencies.EnableDelete = Deleteable
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/PAK_Main/App_Edit") & "/EF_pakResponsibleAgencies.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptpakResponsibleAgencies") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptpakResponsibleAgencies", mStr)
    End If
  End Sub

End Class
