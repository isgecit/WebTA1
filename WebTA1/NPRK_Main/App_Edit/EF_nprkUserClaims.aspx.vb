Partial Class EF_nprkUserClaims
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
  Protected Sub ODSnprkUserClaims_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODSnprkUserClaims.Selected
    Dim tmp As SIS.NPRK.nprkUserClaims = CType(e.ReturnValue, SIS.NPRK.nprkUserClaims)
    Editable = tmp.Editable
    Deleteable = tmp.Deleteable
    PrimaryKey = tmp.PrimaryKey
  End Sub
  Protected Sub FVnprkUserClaims_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVnprkUserClaims.Init
    DataClassName = "EnprkUserClaims"
    SetFormView = FVnprkUserClaims
  End Sub
  Protected Sub TBLnprkUserClaims_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLnprkUserClaims.Init
    SetToolBar = TBLnprkUserClaims
  End Sub
  Protected Sub FVnprkUserClaims_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVnprkUserClaims.PreRender
    TBLnprkUserClaims.EnableSave = Editable
    TBLnprkUserClaims.EnableDelete = Deleteable
    TBLnprkApplications.EnableAdd = Editable
    TBLnprkUserClaims.PrintUrl &= Request.QueryString("ClaimID") & "|"
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/NPRK_Main/App_Edit") & "/EF_nprkUserClaims.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptnprkUserClaims") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptnprkUserClaims", mStr)
    End If
    mStr = "<script type = 'text/javascript' >"
    mStr &= "setTimeout(function() {"
    mStr &= "try {"
    mStr &= "groupClicked($get('nprkUserClaims_0').firstElementChild);"
    mStr &= "   }catch(e){}"
    mStr &= "}, 1);"
    mStr &= "</script>"
    If Not Page.ClientScript.IsClientScriptBlockRegistered("abcd") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "abcd", mStr)
    End If
  End Sub
  Partial Class gvBase
    Inherits SIS.SYS.GridBase
  End Class
  Private WithEvents gvnprkApplicationsCC As New gvBase
  Protected Sub GVnprkApplications_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVnprkApplications.Init
    gvnprkApplicationsCC.DataClassName = "GnprkApplications"
    gvnprkApplicationsCC.SetGridView = GVnprkApplications
  End Sub
  Protected Sub TBLnprkApplications_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLnprkApplications.Init
    gvnprkApplicationsCC.SetToolBar = TBLnprkApplications
  End Sub
  Protected Sub GVnprkApplications_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVnprkApplications.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim ClaimID As Int32 = GVnprkApplications.DataKeys(e.CommandArgument).Values("ClaimID")  
        Dim ApplicationID As Int32 = GVnprkApplications.DataKeys(e.CommandArgument).Values("ApplicationID")  
        Dim RedirectUrl As String = TBLnprkApplications.EditUrl & "?ClaimID=" & ClaimID & "&ApplicationID=" & ApplicationID
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
      End Try
    End If
  End Sub
  Protected Sub TBLnprkApplications_AddClicked(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles TBLnprkApplications.AddClicked
    Dim ClaimID As Int32 = CType(FVnprkUserClaims.FindControl("F_ClaimID"),TextBox).Text
    Dim RedirectURL As String = TBLnprkApplications.AddUrl & "&ClaimID=" & ClaimID
    Response.Redirect(RedirectURL)
  End Sub

End Class
