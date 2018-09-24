Partial Class EF_costProjectInputFiles
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
  Protected Sub ODScostProjectInputFiles_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODScostProjectInputFiles.Selected
    Dim tmp As SIS.COST.costProjectInputFiles = CType(e.ReturnValue, SIS.COST.costProjectInputFiles)
    Editable = tmp.Editable
    Deleteable = tmp.Deleteable
    PrimaryKey = tmp.PrimaryKey
  End Sub
  Protected Sub FVcostProjectInputFiles_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVcostProjectInputFiles.Init
    DataClassName = "EcostProjectInputFiles"
    SetFormView = FVcostProjectInputFiles
  End Sub
  Protected Sub TBLcostProjectInputFiles_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLcostProjectInputFiles.Init
    SetToolBar = TBLcostProjectInputFiles
  End Sub
  Protected Sub FVcostProjectInputFiles_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVcostProjectInputFiles.PreRender
    TBLcostProjectInputFiles.EnableSave = Editable
    TBLcostProjectInputFiles.EnableDelete = Deleteable
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/COST_Main/App_Edit") & "/EF_costProjectInputFiles.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptcostProjectInputFiles") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptcostProjectInputFiles", mStr)
    End If
  End Sub

End Class
