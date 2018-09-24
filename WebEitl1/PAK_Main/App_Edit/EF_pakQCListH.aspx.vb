Imports System.Web.Script.Serialization
Partial Class EF_pakQCListH
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
  Protected Sub ODSpakQCListH_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODSpakQCListH.Selected
    Dim tmp As SIS.PAK.pakQCListH = CType(e.ReturnValue, SIS.PAK.pakQCListH)
    Editable = tmp.Editable
    Deleteable = tmp.Deleteable
    PrimaryKey = tmp.PrimaryKey
  End Sub
  Protected Sub FVpakQCListH_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpakQCListH.Init
    DataClassName = "EpakQCListH"
    SetFormView = FVpakQCListH
  End Sub
  Protected Sub TBLpakQCListH_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLpakQCListH.Init
    SetToolBar = TBLpakQCListH
  End Sub
  Protected Sub FVpakQCListH_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpakQCListH.PreRender
    TBLpakQCListH.EnableSave = Editable
    TBLpakQCListH.EnableDelete = Deleteable
    TBLpakQCListH.PrintUrl &= Request.QueryString("SerialNo") & "|"
    TBLpakQCListH.PrintUrl &= Request.QueryString("QCLNo") & "|"
    TBLpakQCListD.EnableAdd = False
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/PAK_Main/App_Edit") & "/EF_pakQCListH.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptpakQCListH") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptpakQCListH", mStr)
    End If
  End Sub
  Partial Class gvBase
    Inherits SIS.SYS.GridBase
  End Class
  Private WithEvents gvpakQCListDCC As New gvBase
  Protected Sub GVpakQCListD_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVpakQCListD.Init
    gvpakQCListDCC.DataClassName = "GpakQCListD"
    gvpakQCListDCC.SetGridView = GVpakQCListD
  End Sub
  Protected Sub TBLpakQCListD_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLpakQCListD.Init
    gvpakQCListDCC.SetToolBar = TBLpakQCListD
  End Sub
  Protected Sub GVpakQCListD_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVpakQCListD.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim SerialNo As Int32 = GVpakQCListD.DataKeys(e.CommandArgument).Values("SerialNo")  
        Dim QCLNo As Int32 = GVpakQCListD.DataKeys(e.CommandArgument).Values("QCLNo")  
        Dim BOMNo As Int32 = GVpakQCListD.DataKeys(e.CommandArgument).Values("BOMNo")  
        Dim ItemNo As Int32 = GVpakQCListD.DataKeys(e.CommandArgument).Values("ItemNo")  
        Dim RedirectUrl As String = TBLpakQCListD.EditUrl & "?SerialNo=" & SerialNo & "&QCLNo=" & QCLNo & "&BOMNo=" & BOMNo & "&ItemNo=" & ItemNo
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
      End Try
    End If
  End Sub
  Protected Sub TBLpakQCListD_AddClicked(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles TBLpakQCListD.AddClicked
    Dim SerialNo As Int32 = CType(FVpakQCListH.FindControl("F_SerialNo"),TextBox).Text
    Dim QCLNo As Int32 = CType(FVpakQCListH.FindControl("F_QCLNo"),TextBox).Text
    TBLpakQCListD.AddUrl &= "?SerialNo=" & SerialNo
    TBLpakQCListD.AddUrl &= "&QCLNo=" & QCLNo
  End Sub

End Class
