Imports System.Web.Script.Serialization
Partial Class EF_pakIQCListH
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
  Protected Sub ODSpakIQCListH_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODSpakIQCListH.Selected
    Dim tmp As SIS.PAK.pakIQCListH = CType(e.ReturnValue, SIS.PAK.pakIQCListH)
    Editable = tmp.Editable
    Deleteable = tmp.Deleteable
    PrimaryKey = tmp.PrimaryKey
  End Sub
  Protected Sub FVpakIQCListH_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpakIQCListH.Init
    DataClassName = "EpakIQCListH"
    SetFormView = FVpakIQCListH
  End Sub
  Protected Sub TBLpakIQCListH_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLpakIQCListH.Init
    SetToolBar = TBLpakIQCListH
  End Sub
  Protected Sub FVpakIQCListH_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpakIQCListH.PreRender
    TBLpakIQCListH.EnableSave = Editable
    TBLpakIQCListH.EnableDelete = Deleteable
    TBLpakIQCListH.PrintUrl &= Request.QueryString("SerialNo") & "|"
    TBLpakIQCListH.PrintUrl &= Request.QueryString("QCLNo") & "|"
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/PAK_Main/App_Edit") & "/EF_pakIQCListH.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptpakIQCListH") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptpakIQCListH", mStr)
    End If
  End Sub
  Partial Class gvBase
    Inherits SIS.SYS.GridBase
  End Class
  Private WithEvents gvpakIQCListDCC As New gvBase
  Protected Sub GVpakIQCListD_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVpakIQCListD.Init
    gvpakIQCListDCC.DataClassName = "GpakIQCListD"
    gvpakIQCListDCC.SetGridView = GVpakIQCListD
  End Sub
  Protected Sub TBLpakIQCListD_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLpakIQCListD.Init
    gvpakIQCListDCC.SetToolBar = TBLpakIQCListD
  End Sub
  Protected Sub GVpakIQCListD_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVpakIQCListD.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim SerialNo As Int32 = GVpakIQCListD.DataKeys(e.CommandArgument).Values("SerialNo")  
        Dim QCLNo As Int32 = GVpakIQCListD.DataKeys(e.CommandArgument).Values("QCLNo")  
        Dim BOMNo As Int32 = GVpakIQCListD.DataKeys(e.CommandArgument).Values("BOMNo")  
        Dim ItemNo As Int32 = GVpakIQCListD.DataKeys(e.CommandArgument).Values("ItemNo")  
        Dim RedirectUrl As String = TBLpakIQCListD.EditUrl & "?SerialNo=" & SerialNo & "&QCLNo=" & QCLNo & "&BOMNo=" & BOMNo & "&ItemNo=" & ItemNo
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
      End Try
    End If
  End Sub

End Class
