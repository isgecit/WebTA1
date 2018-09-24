Partial Class EF_elogChargeCategories
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
  Protected Sub ODSelogChargeCategories_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODSelogChargeCategories.Selected
    Dim tmp As SIS.ELOG.elogChargeCategories = CType(e.ReturnValue, SIS.ELOG.elogChargeCategories)
    Editable = tmp.Editable
    Deleteable = tmp.Deleteable
    PrimaryKey = tmp.PrimaryKey
  End Sub
  Protected Sub FVelogChargeCategories_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVelogChargeCategories.Init
    DataClassName = "EelogChargeCategories"
    SetFormView = FVelogChargeCategories
  End Sub
  Protected Sub TBLelogChargeCategories_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLelogChargeCategories.Init
    SetToolBar = TBLelogChargeCategories
  End Sub
  Protected Sub FVelogChargeCategories_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVelogChargeCategories.PreRender
    TBLelogChargeCategories.EnableSave = Editable
    TBLelogChargeCategories.EnableDelete = Deleteable
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/ELOG_Main/App_Edit") & "/EF_elogChargeCategories.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptelogChargeCategories") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptelogChargeCategories", mStr)
    End If
  End Sub
  Partial Class gvBase
    Inherits SIS.SYS.GridBase
  End Class
  Private WithEvents gvelogChargeCodesCC As New gvBase
  Protected Sub GVelogChargeCodes_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVelogChargeCodes.Init
    gvelogChargeCodesCC.DataClassName = "GelogChargeCodes"
    gvelogChargeCodesCC.SetGridView = GVelogChargeCodes
  End Sub
  Protected Sub TBLelogChargeCodes_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLelogChargeCodes.Init
    gvelogChargeCodesCC.SetToolBar = TBLelogChargeCodes
  End Sub
  Protected Sub GVelogChargeCodes_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVelogChargeCodes.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim ChargeCategoryID As Int32 = GVelogChargeCodes.DataKeys(e.CommandArgument).Values("ChargeCategoryID")  
        Dim ChargeCodeID As Int32 = GVelogChargeCodes.DataKeys(e.CommandArgument).Values("ChargeCodeID")  
        Dim RedirectUrl As String = TBLelogChargeCodes.EditUrl & "?ChargeCategoryID=" & ChargeCategoryID & "&ChargeCodeID=" & ChargeCodeID
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
      End Try
    End If
  End Sub
  Protected Sub TBLelogChargeCodes_AddClicked(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles TBLelogChargeCodes.AddClicked
    Dim ChargeCategoryID As Int32 = CType(FVelogChargeCategories.FindControl("F_ChargeCategoryID"),TextBox).Text
    TBLelogChargeCodes.AddUrl &= "?ChargeCategoryID=" & ChargeCategoryID
  End Sub

End Class
