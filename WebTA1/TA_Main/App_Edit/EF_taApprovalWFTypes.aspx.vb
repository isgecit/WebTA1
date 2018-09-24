Partial Class EF_taApprovalWFTypes
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
  Protected Sub ODStaApprovalWFTypes_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODStaApprovalWFTypes.Selected
    Dim tmp As SIS.TA.taApprovalWFTypes = CType(e.ReturnValue, SIS.TA.taApprovalWFTypes)
    Editable = tmp.Editable
    Deleteable = tmp.Deleteable
    PrimaryKey = tmp.PrimaryKey
  End Sub
  Protected Sub FVtaApprovalWFTypes_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVtaApprovalWFTypes.Init
    DataClassName = "EtaApprovalWFTypes"
    SetFormView = FVtaApprovalWFTypes
  End Sub
  Protected Sub TBLtaApprovalWFTypes_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLtaApprovalWFTypes.Init
    SetToolBar = TBLtaApprovalWFTypes
  End Sub
  Protected Sub FVtaApprovalWFTypes_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVtaApprovalWFTypes.PreRender
    TBLtaApprovalWFTypes.EnableSave = Editable
    TBLtaApprovalWFTypes.EnableDelete = Deleteable
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/TA_Main/App_Edit") & "/EF_taApprovalWFTypes.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scripttaApprovalWFTypes") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scripttaApprovalWFTypes", mStr)
    End If
  End Sub

End Class
