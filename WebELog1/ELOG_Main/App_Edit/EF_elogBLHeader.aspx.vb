Partial Class EF_elogBLHeader
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
  Protected Sub ODSelogBLHeader_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODSelogBLHeader.Selected
    Dim tmp As SIS.ELOG.elogBLHeader = CType(e.ReturnValue, SIS.ELOG.elogBLHeader)
    Editable = tmp.Editable
    Deleteable = tmp.Deleteable
    PrimaryKey = tmp.PrimaryKey
  End Sub
  Protected Sub FVelogBLHeader_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVelogBLHeader.Init
    DataClassName = "EelogBLHeader"
    SetFormView = FVelogBLHeader
  End Sub
  Protected Sub TBLelogBLHeader_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLelogBLHeader.Init
    SetToolBar = TBLelogBLHeader
  End Sub
  Protected Sub FVelogBLHeader_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVelogBLHeader.PreRender
    TBLelogBLHeader.EnableSave = Editable
    TBLelogBLHeader.EnableDelete = Deleteable
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/ELOG_Main/App_Edit") & "/EF_elogBLHeader.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptelogBLHeader") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptelogBLHeader", mStr)
    End If
  End Sub
  Partial Class gvBase
    Inherits SIS.SYS.GridBase
  End Class
  Private WithEvents gvelogBLDetailsCC As New gvBase
  Protected Sub GVelogBLDetails_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVelogBLDetails.Init
    gvelogBLDetailsCC.DataClassName = "GelogBLDetails"
    gvelogBLDetailsCC.SetGridView = GVelogBLDetails
  End Sub
  Protected Sub TBLelogBLDetails_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLelogBLDetails.Init
    gvelogBLDetailsCC.SetToolBar = TBLelogBLDetails
  End Sub
  Protected Sub GVelogBLDetails_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVelogBLDetails.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim BLID As String = GVelogBLDetails.DataKeys(e.CommandArgument).Values("BLID")  
        Dim SerialNo As Int32 = GVelogBLDetails.DataKeys(e.CommandArgument).Values("SerialNo")  
        Dim RedirectUrl As String = TBLelogBLDetails.EditUrl & "?BLID=" & BLID & "&SerialNo=" & SerialNo
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
      End Try
    End If
  End Sub
  Protected Sub TBLelogBLDetails_AddClicked(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles TBLelogBLDetails.AddClicked
    Dim BLID As String = CType(FVelogBLHeader.FindControl("F_BLID"),TextBox).Text
    TBLelogBLDetails.AddUrl &= "?BLID=" & BLID
  End Sub

End Class
