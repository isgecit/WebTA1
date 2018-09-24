Partial Class EF_pakPOBOMItem
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
  Protected Sub ODSpakPOBOM_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODSpakPOBOM.Selected
    Dim tmp As SIS.PAK.pakPOBOM = CType(e.ReturnValue, SIS.PAK.pakPOBOM)
    Editable = tmp.Editable
    Deleteable = tmp.Deleteable
    PrimaryKey = tmp.PrimaryKey
  End Sub
  Protected Sub FVpakPOBOM_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpakPOBOM.Init
    DataClassName = "EpakPOBOM"
    SetFormView = FVpakPOBOM
  End Sub
  Protected Sub TBLpakPOBOM_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLpakPOBOM.Init
    SetToolBar = TBLpakPOBOM
  End Sub
  Protected Sub FVpakPOBOM_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpakPOBOM.PreRender
    TBLpakPOBOM.EnableSave = Editable
    TBLpakPOBOM.EnableDelete = Deleteable
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/PAK_Main/App_Edit") & "/EF_pakPOBOM.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptpakPOBOM") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptpakPOBOM", mStr)
    End If
  End Sub
  Partial Class gvBase
    Inherits SIS.SYS.GridBase
  End Class
  Private WithEvents gvpakPOBItemsCC As New gvBase
  Protected Sub GVpakPOBItems_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVpakPOBItems.Init
    gvpakPOBItemsCC.DataClassName = "GpakPOBItems"
    gvpakPOBItemsCC.SetGridView = GVpakPOBItems
  End Sub
  Protected Sub TBLpakPOBItems_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLpakPOBItems.Init
    gvpakPOBItemsCC.SetToolBar = TBLpakPOBItems
  End Sub
  Protected Sub GVpakPOBItems_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVpakPOBItems.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim SerialNo As Int32 = GVpakPOBItems.DataKeys(e.CommandArgument).Values("SerialNo")
        Dim BOMNo As Int32 = GVpakPOBItems.DataKeys(e.CommandArgument).Values("BOMNo")
        Dim ItemNo As Int32 = GVpakPOBItems.DataKeys(e.CommandArgument).Values("ItemNo")
        Dim RedirectUrl As String = TBLpakPOBItems.EditUrl & "?SerialNo=" & SerialNo & "&BOMNo=" & BOMNo & "&ItemNo=" & ItemNo
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
      End Try
    End If
    If e.CommandName.ToLower = "CopyWF".ToLower Then
      Try
        Dim SerialNo As Int32 = GVpakPOBItems.DataKeys(e.CommandArgument).Values("SerialNo")
        Dim BOMNo As Int32 = GVpakPOBItems.DataKeys(e.CommandArgument).Values("BOMNo")
        Dim ItemNo As Int32 = GVpakPOBItems.DataKeys(e.CommandArgument).Values("ItemNo")
        SIS.PAK.pakPOBItems.CopyCWF(SerialNo, BOMNo, ItemNo)
        GVpakPOBItems.DataBind()
      Catch ex As Exception
      End Try
    End If
    If e.CommandName.ToLower = "DeleteWF".ToLower Then
      Try
        Dim SerialNo As Int32 = GVpakPOBItems.DataKeys(e.CommandArgument).Values("SerialNo")
        Dim BOMNo As Int32 = GVpakPOBItems.DataKeys(e.CommandArgument).Values("BOMNo")
        Dim ItemNo As Int32 = GVpakPOBItems.DataKeys(e.CommandArgument).Values("ItemNo")
        SIS.PAK.pakPOBItems.DeleteWF(SerialNo, BOMNo, ItemNo)
        GVpakPOBItems.DataBind()
      Catch ex As Exception
      End Try
    End If
    If e.CommandName.ToLower = "initiatewf".ToLower Then
      Try
        Dim SerialNo As Int32 = GVpakPOBItems.DataKeys(e.CommandArgument).Values("SerialNo")
        Dim BOMNo As Int32 = GVpakPOBItems.DataKeys(e.CommandArgument).Values("BOMNo")
        Dim ItemNo As Int32 = GVpakPOBItems.DataKeys(e.CommandArgument).Values("ItemNo")
        SIS.PAK.pakPOBItems.InitiateWF(SerialNo, BOMNo, ItemNo)
        GVpakPOBItems.DataBind()
      Catch ex As Exception
      End Try
    End If
    If e.CommandName.ToLower = "approvewf".ToLower Then
      Try
        Dim SerialNo As Int32 = GVpakPOBItems.DataKeys(e.CommandArgument).Values("SerialNo")
        Dim BOMNo As Int32 = GVpakPOBItems.DataKeys(e.CommandArgument).Values("BOMNo")
        Dim ItemNo As Int32 = GVpakPOBItems.DataKeys(e.CommandArgument).Values("ItemNo")
        SIS.PAK.pakPOBItems.ApproveWF(SerialNo, BOMNo, ItemNo)
        GVpakPOBItems.DataBind()
      Catch ex As Exception
      End Try
    End If
    If e.CommandName.ToLower = "rejectwf".ToLower Then
      Try
        Dim SerialNo As Int32 = GVpakPOBItems.DataKeys(e.CommandArgument).Values("SerialNo")
        Dim BOMNo As Int32 = GVpakPOBItems.DataKeys(e.CommandArgument).Values("BOMNo")
        Dim ItemNo As Int32 = GVpakPOBItems.DataKeys(e.CommandArgument).Values("ItemNo")
        SIS.PAK.pakPOBItems.RejectWF(SerialNo, BOMNo, ItemNo)
        GVpakPOBItems.DataBind()
      Catch ex As Exception
      End Try
    End If
    If e.CommandName.ToLower = "completewf".ToLower Then
      Try
        Dim SerialNo As Int32 = GVpakPOBItems.DataKeys(e.CommandArgument).Values("SerialNo")
        Dim BOMNo As Int32 = GVpakPOBItems.DataKeys(e.CommandArgument).Values("BOMNo")
        Dim ItemNo As Int32 = GVpakPOBItems.DataKeys(e.CommandArgument).Values("ItemNo")
        SIS.PAK.pakPOBItems.CompleteWF(SerialNo, BOMNo, ItemNo)
        GVpakPOBItems.DataBind()
      Catch ex As Exception
      End Try
    End If
  End Sub

End Class
