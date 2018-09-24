Partial Class EF_elogIRBLDetails
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
  Protected Sub ODSelogIRBLDetails_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODSelogIRBLDetails.Selected
    Dim tmp As SIS.ELOG.elogIRBLDetails = CType(e.ReturnValue, SIS.ELOG.elogIRBLDetails)
    Editable = tmp.Editable
    Deleteable = tmp.Deleteable
    PrimaryKey = tmp.PrimaryKey
  End Sub
  Protected Sub FVelogIRBLDetails_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVelogIRBLDetails.Init
    DataClassName = "EelogIRBLDetails"
    SetFormView = FVelogIRBLDetails
  End Sub
  Protected Sub TBLelogIRBLDetails_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLelogIRBLDetails.Init
    SetToolBar = TBLelogIRBLDetails
  End Sub
  Protected Sub FVelogIRBLDetails_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVelogIRBLDetails.PreRender
    TBLelogIRBLDetails.EnableSave = Editable
    TBLelogIRBLDetails.EnableDelete = Deleteable
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/ELOG_Main/App_Edit") & "/EF_elogIRBLDetails.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptelogIRBLDetails") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptelogIRBLDetails", mStr)
    End If
  End Sub

End Class
