Imports System.Web.Script.Serialization
Partial Class EF_pakSPOBOM
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
  Protected Sub ODSpakSPOBOM_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODSpakSPOBOM.Selected
    Dim tmp As SIS.PAK.pakSPOBOM = CType(e.ReturnValue, SIS.PAK.pakSPOBOM)
    Editable = tmp.Editable
    Deleteable = tmp.Deleteable
    PrimaryKey = tmp.PrimaryKey
  End Sub
  Protected Sub FVpakSPOBOM_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpakSPOBOM.Init
    DataClassName = "EpakSPOBOM"
    SetFormView = FVpakSPOBOM
  End Sub
  Protected Sub TBLpakSPOBOM_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLpakSPOBOM.Init
    SetToolBar = TBLpakSPOBOM
  End Sub
  Protected Sub FVpakSPOBOM_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpakSPOBOM.PreRender
    TBLpakSPOBOM.EnableSave = Editable
    TBLpakSPOBOM.EnableDelete = Deleteable
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/PAK_Main/App_Edit") & "/EF_pakSPOBOM.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptpakSPOBOM") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptpakSPOBOM", mStr)
    End If
  End Sub
  Partial Class gvBase
    Inherits SIS.SYS.GridBase
  End Class
  Private WithEvents gvpakSPOBItemsCC As New gvBase
  Protected Sub GVpakSPOBItems_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVpakSPOBItems.Init
    gvpakSPOBItemsCC.DataClassName = "GpakSPOBItems"
    gvpakSPOBItemsCC.SetGridView = GVpakSPOBItems
  End Sub
  Protected Sub TBLpakSPOBItems_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLpakSPOBItems.Init
    gvpakSPOBItemsCC.SetToolBar = TBLpakSPOBItems
  End Sub
  Protected Sub GVpakSPOBItems_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVpakSPOBItems.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim SerialNo As Int32 = GVpakSPOBItems.DataKeys(e.CommandArgument).Values("SerialNo")
        Dim BOMNo As Int32 = GVpakSPOBItems.DataKeys(e.CommandArgument).Values("BOMNo")
        Dim ItemNo As Int32 = GVpakSPOBItems.DataKeys(e.CommandArgument).Values("ItemNo")
        Dim RedirectUrl As String = TBLpakSPOBItems.EditUrl & "?SerialNo=" & SerialNo & "&BOMNo=" & BOMNo & "&ItemNo=" & ItemNo
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
      End Try
    End If
    If e.CommandName.ToLower = "initiatewf".ToLower Then
      Try
        Dim SerialNo As Int32 = GVpakSPOBItems.DataKeys(e.CommandArgument).Values("SerialNo")
        Dim BOMNo As Int32 = GVpakSPOBItems.DataKeys(e.CommandArgument).Values("BOMNo")
        Dim ItemNo As Int32 = GVpakSPOBItems.DataKeys(e.CommandArgument).Values("ItemNo")
        SIS.PAK.pakSPOBItems.InitiateWF(SerialNo, BOMNo, ItemNo)
        GVpakSPOBItems.DataBind()
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
      End Try
    End If
    If e.CommandName.ToLower = "approvewf".ToLower Then
      Try
        Dim SerialNo As Int32 = GVpakSPOBItems.DataKeys(e.CommandArgument).Values("SerialNo")
        Dim BOMNo As Int32 = GVpakSPOBItems.DataKeys(e.CommandArgument).Values("BOMNo")
        Dim ItemNo As Int32 = GVpakSPOBItems.DataKeys(e.CommandArgument).Values("ItemNo")
        SIS.PAK.pakSPOBItems.ApproveWF(SerialNo, BOMNo, ItemNo)
        GVpakSPOBItems.DataBind()
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
      End Try
    End If
    If e.CommandName.ToLower = "rejectwf".ToLower Then
      Try
        Dim SerialNo As Int32 = GVpakSPOBItems.DataKeys(e.CommandArgument).Values("SerialNo")
        Dim BOMNo As Int32 = GVpakSPOBItems.DataKeys(e.CommandArgument).Values("BOMNo")
        Dim ItemNo As Int32 = GVpakSPOBItems.DataKeys(e.CommandArgument).Values("ItemNo")
        SIS.PAK.pakSPOBItems.RejectWF(SerialNo, BOMNo, ItemNo)
        GVpakSPOBItems.DataBind()
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
      End Try
    End If
    If e.CommandName.ToLower = "completewf".ToLower Then
      Try
        Dim SerialNo As Int32 = GVpakSPOBItems.DataKeys(e.CommandArgument).Values("SerialNo")
        Dim BOMNo As Int32 = GVpakSPOBItems.DataKeys(e.CommandArgument).Values("BOMNo")
        Dim ItemNo As Int32 = GVpakSPOBItems.DataKeys(e.CommandArgument).Values("ItemNo")
        SIS.PAK.pakSPOBItems.CompleteWF(SerialNo, BOMNo, ItemNo)
        GVpakSPOBItems.DataBind()
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
      End Try
    End If
  End Sub

End Class
