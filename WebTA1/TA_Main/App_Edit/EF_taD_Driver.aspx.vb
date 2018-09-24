Partial Class EF_taD_Driver
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
  Protected Sub ODStaD_Driver_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODStaD_Driver.Selected
    Dim tmp As SIS.TA.taD_Driver = CType(e.ReturnValue, SIS.TA.taD_Driver)
    Editable = tmp.Editable
    Deleteable = tmp.Deleteable
    PrimaryKey = tmp.PrimaryKey
  End Sub
  Protected Sub FVtaD_Driver_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVtaD_Driver.Init
    DataClassName = "EtaD_Driver"
    SetFormView = FVtaD_Driver
  End Sub
  Protected Sub TBLtaD_Driver_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLtaD_Driver.Init
    SetToolBar = TBLtaD_Driver
  End Sub
  Protected Sub FVtaD_Driver_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVtaD_Driver.PreRender
    TBLtaD_Driver.EnableSave = Editable
    TBLtaD_Driver.EnableDelete = Deleteable
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/TA_Main/App_Edit") & "/EF_taD_Driver.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scripttaD_Driver") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scripttaD_Driver", mStr)
    End If
  End Sub

End Class
