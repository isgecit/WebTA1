Partial Class EF_elogIRBL
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
  Protected Sub ODSelogIRBL_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODSelogIRBL.Selected
    Dim tmp As SIS.ELOG.elogIRBL = CType(e.ReturnValue, SIS.ELOG.elogIRBL)
    Editable = tmp.Editable
    Deleteable = tmp.Deleteable
    PrimaryKey = tmp.PrimaryKey
  End Sub
  Protected Sub FVelogIRBL_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVelogIRBL.Init
    DataClassName = "EelogIRBL"
    SetFormView = FVelogIRBL
  End Sub
  Protected Sub TBLelogIRBL_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLelogIRBL.Init
    SetToolBar = TBLelogIRBL
  End Sub
  Protected Sub FVelogIRBL_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVelogIRBL.PreRender
    TBLelogIRBL.EnableSave = Editable
    TBLelogIRBL.EnableDelete = Deleteable
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/ELOG_Main/App_Edit") & "/EF_elogIRBL.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptelogIRBL") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptelogIRBL", mStr)
    End If
  End Sub
  Partial Class gvBase
    Inherits SIS.SYS.GridBase
  End Class
  Private WithEvents gvelogIRBLDetailsCC As New gvBase
  Protected Sub GVelogIRBLDetails_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVelogIRBLDetails.Init
    gvelogIRBLDetailsCC.DataClassName = "GelogIRBLDetails"
    gvelogIRBLDetailsCC.SetGridView = GVelogIRBLDetails
  End Sub
  Protected Sub TBLelogIRBLDetails_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLelogIRBLDetails.Init
    gvelogIRBLDetailsCC.SetToolBar = TBLelogIRBLDetails
  End Sub
  Protected Sub GVelogIRBLDetails_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVelogIRBLDetails.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim IRNo As Int32 = GVelogIRBLDetails.DataKeys(e.CommandArgument).Values("IRNo")  
        Dim SerialNo As Int32 = GVelogIRBLDetails.DataKeys(e.CommandArgument).Values("SerialNo")  
        Dim RedirectUrl As String = TBLelogIRBLDetails.EditUrl & "?IRNo=" & IRNo & "&SerialNo=" & SerialNo
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
      End Try
    End If
    If e.CommandName.ToLower = "lgCopy".ToLower Then
      Try
        Dim IRNo As Int32 = GVelogIRBLDetails.DataKeys(e.CommandArgument).Values("IRNo")
        Dim SerialNo As Int32 = GVelogIRBLDetails.DataKeys(e.CommandArgument).Values("SerialNo")
        Dim RedirectUrl As String = TBLelogIRBLDetails.AddUrl & "?IRNo=" & IRNo & "&SerialNo=" & SerialNo
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
      End Try
    End If
  End Sub
  Protected Sub TBLelogIRBLDetails_AddClicked(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles TBLelogIRBLDetails.AddClicked
    Dim IRNo As Int32 = CType(FVelogIRBL.FindControl("F_IRNo"),TextBox).Text
    TBLelogIRBLDetails.AddUrl &= "?IRNo=" & IRNo
  End Sub

End Class
