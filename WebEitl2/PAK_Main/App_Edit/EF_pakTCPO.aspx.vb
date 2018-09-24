Imports System.Web.Script.Serialization
Partial Class EF_pakTCPO
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
  Protected Sub ODSpakTCPO_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODSpakTCPO.Selected
    Dim tmp As SIS.PAK.pakTCPO = CType(e.ReturnValue, SIS.PAK.pakTCPO)
    Editable = tmp.Editable
    Deleteable = tmp.Deleteable
    PrimaryKey = tmp.PrimaryKey
  End Sub
  Protected Sub FVpakTCPO_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpakTCPO.Init
    DataClassName = "EpakTCPO"
    SetFormView = FVpakTCPO
  End Sub
  Protected Sub TBLpakTCPO_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLpakTCPO.Init
    SetToolBar = TBLpakTCPO
  End Sub
  Protected Sub FVpakTCPO_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpakTCPO.PreRender
    TBLpakTCPO.EnableSave = Editable
    TBLpakTCPO.EnableDelete = Deleteable
    TBLpakTCPO.PrintUrl &= Request.QueryString("SerialNo") & "|"
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/PAK_Main/App_Edit") & "/EF_pakTCPO.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptpakTCPO") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptpakTCPO", mStr)
    End If
  End Sub
  Partial Class gvBase
    Inherits SIS.SYS.GridBase
  End Class
  Private WithEvents gvpakTCPOLCC As New gvBase
  Protected Sub GVpakTCPOL_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVpakTCPOL.Init
    gvpakTCPOLCC.DataClassName = "GpakTCPOL"
    gvpakTCPOLCC.SetGridView = GVpakTCPOL
  End Sub
  Protected Sub TBLpakTCPOL_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLpakTCPOL.Init
    gvpakTCPOLCC.SetToolBar = TBLpakTCPOL
  End Sub
  Protected Sub GVpakTCPOL_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVpakTCPOL.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim SerialNo As Int32 = GVpakTCPOL.DataKeys(e.CommandArgument).Values("SerialNo")  
        Dim ItemNo As Int32 = GVpakTCPOL.DataKeys(e.CommandArgument).Values("ItemNo")  
        Dim RedirectUrl As String = TBLpakTCPOL.EditUrl & "?SerialNo=" & SerialNo & "&ItemNo=" & ItemNo
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
      End Try
    End If
  End Sub

End Class
