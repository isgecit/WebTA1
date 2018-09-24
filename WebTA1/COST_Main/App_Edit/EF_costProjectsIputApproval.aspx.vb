Partial Class EF_costProjectsIputApproval
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
  Protected Sub ODScostProjectsIputApproval_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODScostProjectsIputApproval.Selected
    Dim tmp As SIS.COST.costProjectsIputApproval = CType(e.ReturnValue, SIS.COST.costProjectsIputApproval)
    Editable = tmp.Editable
    Deleteable = tmp.Deleteable
    PrimaryKey = tmp.PrimaryKey
  End Sub
  Protected Sub FVcostProjectsIputApproval_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVcostProjectsIputApproval.Init
    DataClassName = "EcostProjectsIputApproval"
    SetFormView = FVcostProjectsIputApproval
  End Sub
  Protected Sub TBLcostProjectsIputApproval_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLcostProjectsIputApproval.Init
    SetToolBar = TBLcostProjectsIputApproval
  End Sub
  Protected Sub FVcostProjectsIputApproval_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVcostProjectsIputApproval.PreRender
    TBLcostProjectsIputApproval.EnableSave = Editable
    TBLcostProjectsIputApproval.EnableDelete = Deleteable
    TBLcostProjectsIputApproval.PrintUrl &= Request.QueryString("ProjectGroupID") & "|"
    TBLcostProjectsIputApproval.PrintUrl &= Request.QueryString("FinYear") & "|"
    TBLcostProjectsIputApproval.PrintUrl &= Request.QueryString("Quarter") & "|"
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/COST_Main/App_Edit") & "/EF_costProjectsIputApproval.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptcostProjectsIputApproval") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptcostProjectsIputApproval", mStr)
    End If
  End Sub

End Class
