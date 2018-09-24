Imports System.Web.Script.Serialization
Partial Class EF_tarTRSanction
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
  Protected Sub ODStarTRSanction_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODStarTRSanction.Selected
    Dim tmp As SIS.TAR.tarTRSanction = CType(e.ReturnValue, SIS.TAR.tarTRSanction)
    Editable = tmp.Editable
    Deleteable = tmp.Deleteable
    PrimaryKey = tmp.PrimaryKey
  End Sub
  Protected Sub FVtarTRSanction_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVtarTRSanction.Init
    DataClassName = "EtarTRSanction"
    SetFormView = FVtarTRSanction
  End Sub
  Protected Sub TBLtarTRSanction_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLtarTRSanction.Init
    SetToolBar = TBLtarTRSanction
  End Sub
  Protected Sub FVtarTRSanction_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVtarTRSanction.PreRender
    TBLtarTRSanction.EnableSave = Editable
    TBLtarTRSanction.EnableDelete = Deleteable
    TBLtarTRSanction.PrintUrl &= Request.QueryString("RequestID") & "|"
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/TAR_Main/App_Edit") & "/EF_tarTRSanction.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scripttarTRSanction") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scripttarTRSanction", mStr)
    End If
  End Sub

End Class
