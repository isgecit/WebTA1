Imports System.Web.Script.Serialization
Partial Class EF_tarTRApproval
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
  Protected Sub ODStarTRApproval_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODStarTRApproval.Selected
    Dim tmp As SIS.TAR.tarTRApproval = CType(e.ReturnValue, SIS.TAR.tarTRApproval)
    Editable = tmp.Editable
    Deleteable = tmp.Deleteable
    PrimaryKey = tmp.PrimaryKey
  End Sub
  Protected Sub FVtarTRApproval_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVtarTRApproval.Init
    DataClassName = "EtarTRApproval"
    SetFormView = FVtarTRApproval
  End Sub
  Protected Sub TBLtarTRApproval_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLtarTRApproval.Init
    SetToolBar = TBLtarTRApproval
  End Sub
  Protected Sub FVtarTRApproval_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVtarTRApproval.PreRender
    TBLtarTRApproval.EnableSave = Editable
    TBLtarTRApproval.EnableDelete = Deleteable
    TBLtarTRApproval.PrintUrl &= Request.QueryString("RequestID") & "|"
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/TAR_Main/App_Edit") & "/EF_tarTRApproval.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scripttarTRApproval") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scripttarTRApproval", mStr)
    End If
  End Sub

End Class
