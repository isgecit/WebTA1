Partial Class EF_taRegions
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
  Protected Sub ODStaRegions_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODStaRegions.Selected
    Dim tmp As SIS.TA.taRegions = CType(e.ReturnValue, SIS.TA.taRegions)
    Editable = tmp.Editable
    Deleteable = tmp.Deleteable
    PrimaryKey = tmp.PrimaryKey
  End Sub
  Protected Sub FVtaRegions_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVtaRegions.Init
    DataClassName = "EtaRegions"
    SetFormView = FVtaRegions
  End Sub
  Protected Sub TBLtaRegions_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLtaRegions.Init
    SetToolBar = TBLtaRegions
  End Sub
  Protected Sub FVtaRegions_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVtaRegions.PreRender
    TBLtaRegions.EnableSave = Editable
    TBLtaRegions.EnableDelete = Deleteable
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/TA_Main/App_Edit") & "/EF_taRegions.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scripttaRegions") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scripttaRegions", mStr)
    End If
  End Sub

End Class
