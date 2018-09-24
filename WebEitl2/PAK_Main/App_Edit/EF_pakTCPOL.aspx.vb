Imports System.Web.Script.Serialization
Partial Class EF_pakTCPOL
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
  Protected Sub ODSpakTCPOL_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODSpakTCPOL.Selected
    Dim tmp As SIS.PAK.pakTCPOL = CType(e.ReturnValue, SIS.PAK.pakTCPOL)
    Editable = tmp.Editable
    Deleteable = tmp.Deleteable
    PrimaryKey = tmp.PrimaryKey
  End Sub
  Protected Sub FVpakTCPOL_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpakTCPOL.Init
    DataClassName = "EpakTCPOL"
    SetFormView = FVpakTCPOL
  End Sub
  Protected Sub TBLpakTCPOL_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLpakTCPOL.Init
    SetToolBar = TBLpakTCPOL
  End Sub
  Protected Sub FVpakTCPOL_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpakTCPOL.PreRender
    TBLpakTCPOL.EnableSave = Editable
    TBLpakTCPOL.EnableDelete = Deleteable
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/PAK_Main/App_Edit") & "/EF_pakTCPOL.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptpakTCPOL") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptpakTCPOL", mStr)
    End If
  End Sub
  Partial Class gvBase
    Inherits SIS.SYS.GridBase
  End Class
  Private WithEvents gvpakTCPOLRCC As New gvBase
  Protected Sub GVpakTCPOLR_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVpakTCPOLR.Init
    gvpakTCPOLRCC.DataClassName = "GpakTCPOLR"
    gvpakTCPOLRCC.SetGridView = GVpakTCPOLR
  End Sub
  Protected Sub TBLpakTCPOLR_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLpakTCPOLR.Init
    gvpakTCPOLRCC.SetToolBar = TBLpakTCPOLR
  End Sub
  Protected Sub GVpakTCPOLR_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVpakTCPOLR.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim SerialNo As Int32 = GVpakTCPOLR.DataKeys(e.CommandArgument).Values("SerialNo")  
        Dim ItemNo As Int32 = GVpakTCPOLR.DataKeys(e.CommandArgument).Values("ItemNo")  
        Dim UploadNo As Int32 = GVpakTCPOLR.DataKeys(e.CommandArgument).Values("UploadNo")  
        Dim RedirectUrl As String = TBLpakTCPOLR.EditUrl & "?SerialNo=" & SerialNo & "&ItemNo=" & ItemNo & "&UploadNo=" & UploadNo
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
      End Try
    End If
  End Sub

End Class
