Partial Class EF_pakPOBItems
  Inherits SIS.SYS.UpdateBase
  Public Property Bottom() As Boolean
    Get
      If ViewState("Bottom") IsNot Nothing Then
        Return CType(ViewState("Bottom"), Boolean)
      End If
      Return True
    End Get
    Set(ByVal value As Boolean)
      ViewState.Add("Bottom", value)
    End Set
  End Property
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
  Protected Sub ODSpakPOBItems_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODSpakPOBItems.Selected
    Dim tmp As SIS.PAK.pakPOBItems = CType(e.ReturnValue, SIS.PAK.pakPOBItems)
    Editable = tmp.Editable
    Deleteable = tmp.Deleteable
    PrimaryKey = tmp.PrimaryKey
    Bottom = tmp.Bottom
  End Sub
  Protected Sub FVpakPOBItems_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpakPOBItems.Init
    DataClassName = "EpakPOBItems"
    SetFormView = FVpakPOBItems
  End Sub
  Protected Sub TBLpakPOBItems_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLpakPOBItems.Init
    SetToolBar = TBLpakPOBItems
  End Sub
  Protected Sub FVpakPOBItems_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpakPOBItems.PreRender
    TBLpakPOBItems.EnableSave = Editable
    TBLpakPOBItems.EnableDelete = Deleteable
    TBLpakPOBIDocuments.EnableAdd = Editable

    CType(FVpakPOBItems.FindControl("Opt1"), HtmlTableRow).Visible = Bottom
    CType(FVpakPOBItems.FindControl("Opt2"), HtmlTableRow).Visible = Bottom
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/PAK_Main/App_Edit") & "/EF_pakPOBItems.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptpakPOBItems") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptpakPOBItems", mStr)
    End If
  End Sub
  Partial Class gvBase
    Inherits SIS.SYS.GridBase
  End Class
  Private WithEvents gvpakPOBIDocumentsCC As New gvBase
  Protected Sub GVpakPOBIDocuments_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVpakPOBIDocuments.Init
    gvpakPOBIDocumentsCC.DataClassName = "GpakPOBIDocuments"
    gvpakPOBIDocumentsCC.SetGridView = GVpakPOBIDocuments
  End Sub
  Protected Sub TBLpakPOBIDocuments_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLpakPOBIDocuments.Init
    gvpakPOBIDocumentsCC.SetToolBar = TBLpakPOBIDocuments
  End Sub
  Protected Sub GVpakPOBIDocuments_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVpakPOBIDocuments.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim SerialNo As Int32 = GVpakPOBIDocuments.DataKeys(e.CommandArgument).Values("SerialNo")  
        Dim BOMNo As Int32 = GVpakPOBIDocuments.DataKeys(e.CommandArgument).Values("BOMNo")  
        Dim ItemNo As Int32 = GVpakPOBIDocuments.DataKeys(e.CommandArgument).Values("ItemNo")  
        Dim DocNo As Int32 = GVpakPOBIDocuments.DataKeys(e.CommandArgument).Values("DocNo")  
        Dim RedirectUrl As String = TBLpakPOBIDocuments.EditUrl & "?SerialNo=" & SerialNo & "&BOMNo=" & BOMNo & "&ItemNo=" & ItemNo & "&DocNo=" & DocNo
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
      End Try
    End If
    If e.CommandName.ToLower = "Deletewf".ToLower Then
      Try
        Dim SerialNo As Int32 = GVpakPOBIDocuments.DataKeys(e.CommandArgument).Values("SerialNo")  
        Dim BOMNo As Int32 = GVpakPOBIDocuments.DataKeys(e.CommandArgument).Values("BOMNo")  
        Dim ItemNo As Int32 = GVpakPOBIDocuments.DataKeys(e.CommandArgument).Values("ItemNo")  
        Dim DocNo As Int32 = GVpakPOBIDocuments.DataKeys(e.CommandArgument).Values("DocNo")  
        SIS.PAK.pakPOBIDocuments.DeleteWF(SerialNo, BOMNo, ItemNo, DocNo)
        GVpakPOBIDocuments.DataBind()
      Catch ex As Exception
      End Try
    End If
  End Sub
  Protected Sub TBLpakPOBIDocuments_AddClicked(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles TBLpakPOBIDocuments.AddClicked
    Dim SerialNo As Int32 = CType(FVpakPOBItems.FindControl("F_SerialNo"),TextBox).Text
    Dim BOMNo As Int32 = CType(FVpakPOBItems.FindControl("F_BOMNo"),TextBox).Text
    Dim ItemNo As Int32 = CType(FVpakPOBItems.FindControl("F_ItemNo"),TextBox).Text
    TBLpakPOBIDocuments.AddUrl &= "&SerialNo=" & SerialNo
    TBLpakPOBIDocuments.AddUrl &= "&BOMNo=" & BOMNo
    TBLpakPOBIDocuments.AddUrl &= "&ItemNo=" & ItemNo
  End Sub
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_PAK_POBItems_ParentItemNo(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
    Dim SerialNo As Int32 = CType(aVal(1),Int32)
    Dim BOMNo As Int32 = CType(aVal(2),Int32)
    Dim ParentItemNo As Int32 = CType(aVal(3),Int32)
    Dim oVar As SIS.PAK.pakPOBItems = SIS.PAK.pakPOBItems.pakPOBItemsGetByID(SerialNo,BOMNo,ParentItemNo)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found." 
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function

End Class
