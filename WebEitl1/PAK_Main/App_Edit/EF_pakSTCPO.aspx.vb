Imports System.Web.Script.Serialization
Partial Class EF_pakSTCPO
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
  Protected Sub ODSpakSTCPO_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODSpakSTCPO.Selected
    Dim tmp As SIS.PAK.pakSTCPO = CType(e.ReturnValue, SIS.PAK.pakSTCPO)
    Editable = tmp.Editable
    Deleteable = tmp.Deleteable
    PrimaryKey = tmp.PrimaryKey
  End Sub
  Protected Sub FVpakSTCPO_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpakSTCPO.Init
    DataClassName = "EpakSTCPO"
    SetFormView = FVpakSTCPO
  End Sub
  Protected Sub TBLpakSTCPO_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLpakSTCPO.Init
    SetToolBar = TBLpakSTCPO
  End Sub
  Protected Sub FVpakSTCPO_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpakSTCPO.PreRender
    TBLpakSTCPO.EnableSave = Editable
    TBLpakSTCPO.EnableDelete = Deleteable
    TBLpakSTCPO.PrintUrl &= Request.QueryString("SerialNo") & "|"
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/PAK_Main/App_Edit") & "/EF_pakSTCPO.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptpakSTCPO") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptpakSTCPO", mStr)
    End If
  End Sub
  Partial Class gvBase
    Inherits SIS.SYS.GridBase
  End Class
  Private WithEvents gvpakSTCPOLCC As New gvBase
  Protected Sub GVpakSTCPOL_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVpakSTCPOL.Init
    gvpakSTCPOLCC.DataClassName = "GpakSTCPOL"
    gvpakSTCPOLCC.SetGridView = GVpakSTCPOL
  End Sub
  Protected Sub TBLpakSTCPOL_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLpakSTCPOL.Init
    gvpakSTCPOLCC.SetToolBar = TBLpakSTCPOL
  End Sub
  Protected Sub GVpakSTCPOL_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVpakSTCPOL.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim SerialNo As Int32 = GVpakSTCPOL.DataKeys(e.CommandArgument).Values("SerialNo")  
        Dim ItemNo As Int32 = GVpakSTCPOL.DataKeys(e.CommandArgument).Values("ItemNo")  
        Dim RedirectUrl As String = TBLpakSTCPOL.EditUrl & "?SerialNo=" & SerialNo & "&ItemNo=" & ItemNo
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
      End Try
    End If
  End Sub
  Protected Sub TBLpakSTCPOL_AddClicked(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles TBLpakSTCPOL.AddClicked
    Dim SerialNo As Int32 = CType(FVpakSTCPO.FindControl("F_SerialNo"),TextBox).Text
    TBLpakSTCPOL.AddUrl &= "&SerialNo=" & SerialNo
  End Sub

End Class
