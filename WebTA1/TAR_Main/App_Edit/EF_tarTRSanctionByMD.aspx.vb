Imports System.Web.Script.Serialization
Partial Class EF_tarTRSanctionByMD
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
  Protected Sub ODStarTRSanctionByMD_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODStarTRSanctionByMD.Selected
    Dim tmp As SIS.TAR.tarTRSanctionByMD = CType(e.ReturnValue, SIS.TAR.tarTRSanctionByMD)
    Editable = tmp.Editable
    Deleteable = tmp.Deleteable
    PrimaryKey = tmp.PrimaryKey
  End Sub
  Protected Sub FVtarTRSanctionByMD_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVtarTRSanctionByMD.Init
    DataClassName = "EtarTRSanctionByMD"
    SetFormView = FVtarTRSanctionByMD
  End Sub
  Protected Sub TBLtarTRSanctionByMD_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLtarTRSanctionByMD.Init
    SetToolBar = TBLtarTRSanctionByMD
  End Sub
  Protected Sub FVtarTRSanctionByMD_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVtarTRSanctionByMD.PreRender
    TBLtarTRSanctionByMD.EnableSave = Editable
    TBLtarTRSanctionByMD.EnableDelete = Deleteable
    TBLtarTRSanctionByMD.PrintUrl &= Request.QueryString("RequestID") & "|"
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/TAR_Main/App_Edit") & "/EF_tarTRSanctionByMD.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scripttarTRSanctionByMD") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scripttarTRSanctionByMD", mStr)
    End If
  End Sub

End Class
