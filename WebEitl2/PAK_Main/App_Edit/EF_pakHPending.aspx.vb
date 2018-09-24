Imports System.Web.Script.Serialization
Partial Class EF_pakHPending
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
  Protected Sub ODSpakHPending_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODSpakHPending.Selected
    Dim tmp As SIS.PAK.pakHPending = CType(e.ReturnValue, SIS.PAK.pakHPending)
    Editable = tmp.Editable
    Deleteable = tmp.Deleteable
    PrimaryKey = tmp.PrimaryKey
  End Sub
  Protected Sub FVpakHPending_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpakHPending.Init
    DataClassName = "EpakHPending"
    SetFormView = FVpakHPending
  End Sub
  Protected Sub TBLpakHPending_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLpakHPending.Init
    SetToolBar = TBLpakHPending
  End Sub
  Protected Sub FVpakHPending_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpakHPending.PreRender
    TBLpakHPending.EnableSave = Editable
    TBLpakHPending.EnableDelete = Deleteable
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/PAK_Main/App_Edit") & "/EF_pakHPending.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptpakHPending") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptpakHPending", mStr)
    End If
  End Sub
  Partial Class gvBase
    Inherits SIS.SYS.GridBase
  End Class
  Private WithEvents gvpakDPendingCC As New gvBase
  Protected Sub GVpakDPending_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVpakDPending.Init
    gvpakDPendingCC.DataClassName = "GpakDPending"
    gvpakDPendingCC.SetGridView = GVpakDPending
  End Sub
  Protected Sub TBLpakDPending_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLpakDPending.Init
    gvpakDPendingCC.SetToolBar = TBLpakDPending
  End Sub
  Protected Sub GVpakDPending_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVpakDPending.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim SerialNo As Int32 = GVpakDPending.DataKeys(e.CommandArgument).Values("SerialNo")  
        Dim PkgNo As Int32 = GVpakDPending.DataKeys(e.CommandArgument).Values("PkgNo")  
        Dim BOMNo As Int32 = GVpakDPending.DataKeys(e.CommandArgument).Values("BOMNo")  
        Dim ItemNo As Int32 = GVpakDPending.DataKeys(e.CommandArgument).Values("ItemNo")  
        Dim RedirectUrl As String = TBLpakDPending.EditUrl & "?SerialNo=" & SerialNo & "&PkgNo=" & PkgNo & "&BOMNo=" & BOMNo & "&ItemNo=" & ItemNo
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
      End Try
    End If
  End Sub

End Class
