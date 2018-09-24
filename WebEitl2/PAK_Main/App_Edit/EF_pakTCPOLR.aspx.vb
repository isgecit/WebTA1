Imports System.Web.Script.Serialization
Partial Class EF_pakTCPOLR
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
  Protected Sub ODSpakTCPOLR_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODSpakTCPOLR.Selected
    Dim tmp As SIS.PAK.pakTCPOLR = CType(e.ReturnValue, SIS.PAK.pakTCPOLR)
    Editable = tmp.Editable
    Deleteable = tmp.Deleteable
    PrimaryKey = tmp.PrimaryKey
  End Sub
  Protected Sub FVpakTCPOLR_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpakTCPOLR.Init
    DataClassName = "EpakTCPOLR"
    SetFormView = FVpakTCPOLR
  End Sub
  Protected Sub TBLpakTCPOLR_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLpakTCPOLR.Init
    SetToolBar = TBLpakTCPOLR
  End Sub
  Protected Sub FVpakTCPOLR_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpakTCPOLR.PreRender
    TBLpakTCPOLR.EnableSave = Editable
    TBLpakTCPOLR.EnableDelete = Deleteable
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/PAK_Main/App_Edit") & "/EF_pakTCPOLR.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptpakTCPOLR") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptpakTCPOLR", mStr)
    End If
  End Sub
  Partial Class gvBase
    Inherits SIS.SYS.GridBase
  End Class
  Private WithEvents gvpakTCPOLRDCC As New gvBase
  Protected Sub GVpakTCPOLRD_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVpakTCPOLRD.Init
    gvpakTCPOLRDCC.DataClassName = "GpakTCPOLRD"
    gvpakTCPOLRDCC.SetGridView = GVpakTCPOLRD
  End Sub
  Protected Sub TBLpakTCPOLRD_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLpakTCPOLRD.Init
    gvpakTCPOLRDCC.SetToolBar = TBLpakTCPOLRD
  End Sub
  Protected Sub GVpakTCPOLRD_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVpakTCPOLRD.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim SerialNo As Int32 = GVpakTCPOLRD.DataKeys(e.CommandArgument).Values("SerialNo")  
        Dim ItemNo As Int32 = GVpakTCPOLRD.DataKeys(e.CommandArgument).Values("ItemNo")  
        Dim UploadNo As Int32 = GVpakTCPOLRD.DataKeys(e.CommandArgument).Values("UploadNo")  
        Dim DocSerialNo As Int32 = GVpakTCPOLRD.DataKeys(e.CommandArgument).Values("DocSerialNo")  
        Dim RedirectUrl As String = TBLpakTCPOLRD.EditUrl & "?SerialNo=" & SerialNo & "&ItemNo=" & ItemNo & "&UploadNo=" & UploadNo & "&DocSerialNo=" & DocSerialNo
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
      End Try
    End If
  End Sub

End Class
