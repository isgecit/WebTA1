Partial Class EF_pakSPOBItems
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
  Protected Sub ODSpakSPOBItems_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODSpakSPOBItems.Selected
    Dim tmp As SIS.PAK.pakSPOBItems = CType(e.ReturnValue, SIS.PAK.pakSPOBItems)
    Editable = tmp.Editable
    Deleteable = tmp.Deleteable
    PrimaryKey = tmp.PrimaryKey
    Bottom = tmp.Bottom
  End Sub
  Protected Sub FVpakSPOBItems_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpakSPOBItems.Init
    DataClassName = "EpakSPOBItems"
    SetFormView = FVpakSPOBItems
  End Sub
  Protected Sub TBLpakSPOBItems_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLpakSPOBItems.Init
    SetToolBar = TBLpakSPOBItems
  End Sub
  Protected Sub FVpakSPOBItems_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpakSPOBItems.PreRender
    TBLpakSPOBItems.EnableSave = Editable
    TBLpakSPOBItems.EnableDelete = Deleteable
    CType(FVpakSPOBItems.FindControl("Opt1"), HtmlTableRow).Visible = Bottom
    CType(FVpakSPOBItems.FindControl("Opt2"), HtmlTableRow).Visible = Bottom
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/PAK_Main/App_Edit") & "/EF_pakSPOBItems.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptpakSPOBItems") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptpakSPOBItems", mStr)
    End If
  End Sub
  Partial Class gvBase
    Inherits SIS.SYS.GridBase
  End Class
  Private WithEvents gvpakSPOBIDocumentsCC As New gvBase
  Protected Sub GVpakSPOBIDocuments_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVpakSPOBIDocuments.Init
    gvpakSPOBIDocumentsCC.DataClassName = "GpakSPOBIDocuments"
    gvpakSPOBIDocumentsCC.SetGridView = GVpakSPOBIDocuments
  End Sub
  Protected Sub TBLpakSPOBIDocuments_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLpakSPOBIDocuments.Init
    gvpakSPOBIDocumentsCC.SetToolBar = TBLpakSPOBIDocuments
  End Sub
  Protected Sub GVpakSPOBIDocuments_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVpakSPOBIDocuments.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim SerialNo As Int32 = GVpakSPOBIDocuments.DataKeys(e.CommandArgument).Values("SerialNo")  
        Dim BOMNo As Int32 = GVpakSPOBIDocuments.DataKeys(e.CommandArgument).Values("BOMNo")  
        Dim ItemNo As Int32 = GVpakSPOBIDocuments.DataKeys(e.CommandArgument).Values("ItemNo")  
        Dim DocNo As Int32 = GVpakSPOBIDocuments.DataKeys(e.CommandArgument).Values("DocNo")  
        Dim RedirectUrl As String = TBLpakSPOBIDocuments.EditUrl & "?SerialNo=" & SerialNo & "&BOMNo=" & BOMNo & "&ItemNo=" & ItemNo & "&DocNo=" & DocNo
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
      End Try
    End If
    If e.CommandName.ToLower = "Deletewf".ToLower Then
      Try
        Dim SerialNo As Int32 = GVpakSPOBIDocuments.DataKeys(e.CommandArgument).Values("SerialNo")  
        Dim BOMNo As Int32 = GVpakSPOBIDocuments.DataKeys(e.CommandArgument).Values("BOMNo")  
        Dim ItemNo As Int32 = GVpakSPOBIDocuments.DataKeys(e.CommandArgument).Values("ItemNo")  
        Dim DocNo As Int32 = GVpakSPOBIDocuments.DataKeys(e.CommandArgument).Values("DocNo")  
        SIS.PAK.pakSPOBIDocuments.DeleteWF(SerialNo, BOMNo, ItemNo, DocNo)
        GVpakSPOBIDocuments.DataBind()
      Catch ex As Exception
      End Try
    End If
  End Sub
  Protected Sub TBLpakSPOBIDocuments_AddClicked(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles TBLpakSPOBIDocuments.AddClicked
    Dim SerialNo As Int32 = CType(FVpakSPOBItems.FindControl("F_SerialNo"),TextBox).Text
    Dim BOMNo As Int32 = CType(FVpakSPOBItems.FindControl("F_BOMNo"),TextBox).Text
    Dim ItemNo As Int32 = CType(FVpakSPOBItems.FindControl("F_ItemNo"),TextBox).Text
    TBLpakSPOBIDocuments.AddUrl &= "&SerialNo=" & SerialNo
    TBLpakSPOBIDocuments.AddUrl &= "&BOMNo=" & BOMNo
    TBLpakSPOBIDocuments.AddUrl &= "&ItemNo=" & ItemNo
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
