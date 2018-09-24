Imports System.Web.Script.Serialization
Partial Class EF_nprkSiteAllowanceAdvice
  Inherits SIS.SYS.UpdateBase
  Public Property UnLinkedVisible As Boolean
    Get
      If ViewState("UnLinkedVisible") IsNot Nothing Then
        Return CType(ViewState("UnLinkedVisible"), Boolean)
      End If
      Return True
    End Get
    Set(ByVal value As Boolean)
      ViewState.Add("UnLinkedVisible", value)
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
  Protected Sub ODSnprkSiteAllowanceAdvice_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODSnprkSiteAllowanceAdvice.Selected
    Dim tmp As SIS.NPRK.nprkSiteAllowanceAdvice = CType(e.ReturnValue, SIS.NPRK.nprkSiteAllowanceAdvice)
    Editable = tmp.Editable
    Deleteable = tmp.Deleteable
    PrimaryKey = tmp.PrimaryKey
    UnLinkedVisible = True
  End Sub
  Protected Sub FVnprkSiteAllowanceAdvice_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVnprkSiteAllowanceAdvice.Init
    DataClassName = "EnprkSiteAllowanceAdvice"
    SetFormView = FVnprkSiteAllowanceAdvice
  End Sub
  Protected Sub TBLnprkSiteAllowanceAdvice_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLnprkSiteAllowanceAdvice.Init
    SetToolBar = TBLnprkSiteAllowanceAdvice
  End Sub
  Protected Sub FVnprkSiteAllowanceAdvice_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVnprkSiteAllowanceAdvice.PreRender
    TBLnprkSiteAllowanceAdvice.EnableSave = Editable
    TBLnprkSiteAllowanceAdvice.EnableDelete = Deleteable
    CType(FVnprkSiteAllowanceAdvice.FindControl("plnUnlinked"), Panel).Visible = UnLinkedVisible
    TBLnprkSiteAllowanceAdvice.PrintUrl &= Request.QueryString("FinYear") & "|"
    TBLnprkSiteAllowanceAdvice.PrintUrl &= Request.QueryString("Quarter") & "|"
    TBLnprkSiteAllowanceAdvice.PrintUrl &= Request.QueryString("AdviceNo") & "|"
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/NPRK_Main/App_Edit") & "/EF_nprkSiteAllowanceAdvice.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptnprkSiteAllowanceAdvice") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptnprkSiteAllowanceAdvice", mStr)
    End If
  End Sub
  Partial Class gvBase
    Inherits SIS.SYS.GridBase
  End Class
  Private WithEvents gvnprkLinkedSAClaimsCC As New gvBase
  Protected Sub GVnprkLinkedSAClaims_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVnprkLinkedSAClaims.Init
    gvnprkLinkedSAClaimsCC.DataClassName = "GnprkLinkedSAClaims"
    gvnprkLinkedSAClaimsCC.SetGridView = GVnprkLinkedSAClaims
  End Sub
  Protected Sub TBLnprkLinkedSAClaims_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLnprkLinkedSAClaims.Init
    gvnprkLinkedSAClaimsCC.SetToolBar = TBLnprkLinkedSAClaims
  End Sub
  Protected Sub GVnprkLinkedSAClaims_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVnprkLinkedSAClaims.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim FinYear As Int32 = GVnprkLinkedSAClaims.DataKeys(e.CommandArgument).Values("FinYear")
        Dim Quarter As Int32 = GVnprkLinkedSAClaims.DataKeys(e.CommandArgument).Values("Quarter")
        Dim EmployeeID As String = GVnprkLinkedSAClaims.DataKeys(e.CommandArgument).Values("EmployeeID")
        Dim RedirectUrl As String = TBLnprkLinkedSAClaims.EditUrl & "?FinYear=" & FinYear & "&Quarter=" & Quarter & "&EmployeeID=" & EmployeeID
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
      End Try
    End If
    If e.CommandName.ToLower = "rejectwf".ToLower Then
      Try
        Dim FinYear As Int32 = GVnprkLinkedSAClaims.DataKeys(e.CommandArgument).Values("FinYear")
        Dim Quarter As Int32 = GVnprkLinkedSAClaims.DataKeys(e.CommandArgument).Values("Quarter")
        Dim EmployeeID As String = GVnprkLinkedSAClaims.DataKeys(e.CommandArgument).Values("EmployeeID")
        SIS.NPRK.nprkLinkedSAClaims.RejectWF(FinYear, Quarter, EmployeeID, PrimaryKey)
        GVnprkUnLinkedSAClaims.DataBind()
        GVnprkLinkedSAClaims.DataBind()
        FVnprkSiteAllowanceAdvice.DataBind()
      Catch ex As Exception
        Dim str As String = New JavaScriptSerializer().Serialize(ex.Message)
        Dim script As String = String.Format("alert({0});", str)
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", script, True)
      End Try
    End If
  End Sub
  Protected Sub TBLnprkLinkedSAClaims_AddClicked(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles TBLnprkLinkedSAClaims.AddClicked
    Dim FinYear As Int32 = CType(FVnprkSiteAllowanceAdvice.FindControl("F_FinYear"), TextBox).Text
    Dim Quarter As Int32 = CType(FVnprkSiteAllowanceAdvice.FindControl("F_Quarter"), TextBox).Text
    Dim AdviceNo As Int32 = CType(FVnprkSiteAllowanceAdvice.FindControl("F_AdviceNo"), TextBox).Text
    TBLnprkLinkedSAClaims.AddUrl &= "?FinYear=" & FinYear
    TBLnprkLinkedSAClaims.AddUrl &= "&Quarter=" & Quarter
    TBLnprkLinkedSAClaims.AddUrl &= "&AdviceNo=" & AdviceNo
  End Sub
  Private WithEvents gvnprkUnLinkedSAClaimsCC As New gvBase
  Protected Sub GVnprkUnLinkedSAClaims_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVnprkUnLinkedSAClaims.Init
    gvnprkUnLinkedSAClaimsCC.DataClassName = "GnprkUnLinkedSAClaims"
    gvnprkUnLinkedSAClaimsCC.SetGridView = GVnprkUnLinkedSAClaims
  End Sub
  Protected Sub TBLnprkUnLinkedSAClaims_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLnprkUnLinkedSAClaims.Init
    gvnprkUnLinkedSAClaimsCC.SetToolBar = TBLnprkUnLinkedSAClaims
  End Sub
  Protected Sub GVnprkUnLinkedSAClaims_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVnprkUnLinkedSAClaims.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim FinYear As Int32 = GVnprkUnLinkedSAClaims.DataKeys(e.CommandArgument).Values("FinYear")
        Dim Quarter As Int32 = GVnprkUnLinkedSAClaims.DataKeys(e.CommandArgument).Values("Quarter")
        Dim EmployeeID As String = GVnprkUnLinkedSAClaims.DataKeys(e.CommandArgument).Values("EmployeeID")
        Dim RedirectUrl As String = TBLnprkUnLinkedSAClaims.EditUrl & "?FinYear=" & FinYear & "&Quarter=" & Quarter & "&EmployeeID=" & EmployeeID
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
      End Try
    End If
    If e.CommandName.ToLower = "approvewf".ToLower Then
      Try
        Dim FinYear As Int32 = GVnprkUnLinkedSAClaims.DataKeys(e.CommandArgument).Values("FinYear")
        Dim Quarter As Int32 = GVnprkUnLinkedSAClaims.DataKeys(e.CommandArgument).Values("Quarter")
        Dim EmployeeID As String = GVnprkUnLinkedSAClaims.DataKeys(e.CommandArgument).Values("EmployeeID")
        SIS.NPRK.nprkUnLinkedSAClaims.ApproveWF(FinYear, Quarter, EmployeeID, PrimaryKey)
        GVnprkUnLinkedSAClaims.DataBind()
        GVnprkLinkedSAClaims.DataBind()
        FVnprkSiteAllowanceAdvice.DataBind()
      Catch ex As Exception
        Dim str As String = New JavaScriptSerializer().Serialize(ex.Message)
        Dim script As String = String.Format("alert({0});", str)
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", script, True)
      End Try
    End If
  End Sub

  Private Sub FVnprkSiteAllowanceAdvice_ItemCommand(sender As Object, e As FormViewCommandEventArgs) Handles FVnprkSiteAllowanceAdvice.ItemCommand
    If e.CommandName = "lgClaims" Then
      Try
        Dim FinYear As Integer = FVnprkSiteAllowanceAdvice.DataKey.Values("FinYear")
        Dim Quarter As Integer = FVnprkSiteAllowanceAdvice.DataKey.Values("Quarter")
        Dim AdviceNo As Integer = FVnprkSiteAllowanceAdvice.DataKey.Values("AdviceNo")
        Dim tmp As SIS.NPRK.nprkSiteAllowanceAdvice = SIS.NPRK.nprkSiteAllowanceAdvice.nprkSiteAllowanceAdviceGetByID(FinYear, Quarter, AdviceNo)
        SIS.NPRK.nprkSiteAllowanceAdvice.GetAndLinkSiteAllowanceClaims(tmp)
        GVnprkLinkedSAClaims.DataBind()
        FVnprkSiteAllowanceAdvice.DataBind()
      Catch ex As Exception
        Dim str As String = New JavaScriptSerializer().Serialize(ex.Message)
        Dim script As String = String.Format("alert({0});", str)
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", script, True)
      End Try
    End If
  End Sub
End Class
