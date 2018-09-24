Imports System.Web.Script.Serialization
Partial Class EF_tarTRBudgetedByPM
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
  Protected Sub ODStarTRBudgetedByPM_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODStarTRBudgetedByPM.Selected
    Dim tmp As SIS.TAR.tarTRBudgetedByPM = CType(e.ReturnValue, SIS.TAR.tarTRBudgetedByPM)
    Editable = tmp.Editable
    Deleteable = tmp.Deleteable
    PrimaryKey = tmp.PrimaryKey
  End Sub
  Protected Sub FVtarTRBudgetedByPM_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVtarTRBudgetedByPM.Init
    DataClassName = "EtarTRBudgetedByPM"
    SetFormView = FVtarTRBudgetedByPM
  End Sub
  Protected Sub TBLtarTRBudgetedByPM_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLtarTRBudgetedByPM.Init
    SetToolBar = TBLtarTRBudgetedByPM
  End Sub
  Protected Sub FVtarTRBudgetedByPM_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVtarTRBudgetedByPM.PreRender
    TBLtarTRBudgetedByPM.EnableSave = Editable
    TBLtarTRBudgetedByPM.EnableDelete = Deleteable
    TBLtarTRBudgetedByPM.PrintUrl &= Request.QueryString("RequestID") & "|"
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/TAR_Main/App_Edit") & "/EF_tarTRBudgetedByPM.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scripttarTRBudgetedByPM") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scripttarTRBudgetedByPM", mStr)
    End If
  End Sub

End Class
