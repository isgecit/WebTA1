Partial Class EF_hrmLocations
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
  Protected Sub ODShrmLocations_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODShrmLocations.Selected
    Dim tmp As SIS.HRM.hrmLocations = CType(e.ReturnValue, SIS.HRM.hrmLocations)
    Editable = tmp.Editable
    Deleteable = tmp.Deleteable
    PrimaryKey = tmp.PrimaryKey
  End Sub
  Protected Sub FVhrmLocations_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVhrmLocations.Init
    DataClassName = "EhrmLocations"
    SetFormView = FVhrmLocations
  End Sub
  Protected Sub TBLhrmLocations_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLhrmLocations.Init
    SetToolBar = TBLhrmLocations
  End Sub
  Protected Sub FVhrmLocations_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVhrmLocations.PreRender
    TBLhrmLocations.EnableSave = Editable
    TBLhrmLocations.EnableDelete = Deleteable
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/HRM_Main/App_Edit") & "/EF_hrmLocations.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scripthrmLocations") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scripthrmLocations", mStr)
    End If
  End Sub
  Partial Class gvBase
    Inherits SIS.SYS.GridBase
  End Class
  Private WithEvents gvhrmOfficeLocationCC As New gvBase
  Protected Sub GVhrmOfficeLocation_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVhrmOfficeLocation.Init
    gvhrmOfficeLocationCC.DataClassName = "GhrmOfficeLocation"
    gvhrmOfficeLocationCC.SetGridView = GVhrmOfficeLocation
  End Sub
  Protected Sub TBLhrmOfficeLocation_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLhrmOfficeLocation.Init
    gvhrmOfficeLocationCC.SetToolBar = TBLhrmOfficeLocation
  End Sub
  Protected Sub GVhrmOfficeLocation_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVhrmOfficeLocation.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim LocationID As Int32 = GVhrmOfficeLocation.DataKeys(e.CommandArgument).Values("LocationID")  
        Dim OfficeID As Int32 = GVhrmOfficeLocation.DataKeys(e.CommandArgument).Values("OfficeID")  
        Dim RedirectUrl As String = TBLhrmOfficeLocation.EditUrl & "?LocationID=" & LocationID & "&OfficeID=" & OfficeID
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
      End Try
    End If
  End Sub
  Protected Sub TBLhrmOfficeLocation_AddClicked(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles TBLhrmOfficeLocation.AddClicked
    Dim LocationID As Int32 = CType(FVhrmLocations.FindControl("F_LocationID"),TextBox).Text
    TBLhrmOfficeLocation.AddUrl &= "?LocationID=" & LocationID
  End Sub

End Class
