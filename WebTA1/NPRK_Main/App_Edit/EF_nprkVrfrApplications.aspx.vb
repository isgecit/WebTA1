Imports System.Web.Script.Serialization
Partial Class EF_nprkVrfrApplications
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
  Protected Sub ODSnprkVrfrApplications_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODSnprkVrfrApplications.Selected
    Dim tmp As SIS.NPRK.nprkVrfrApplications = CType(e.ReturnValue, SIS.NPRK.nprkVrfrApplications)
    Editable = tmp.Editable
    Deleteable = tmp.Deleteable
    PrimaryKey = tmp.PrimaryKey
  End Sub
  Protected Sub FVnprkVrfrApplications_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVnprkVrfrApplications.Init
    DataClassName = "EnprkVrfrApplications"
    SetFormView = FVnprkVrfrApplications
  End Sub
  Protected Sub TBLnprkVrfrApplications_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLnprkVrfrApplications.Init
    SetToolBar = TBLnprkVrfrApplications
  End Sub
  Protected Sub FVnprkVrfrApplications_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVnprkVrfrApplications.PreRender
    TBLnprkVrfrApplications.EnableSave = True
    TBLnprkVrfrApplications.EnableDelete = False
    TBLnprkBillDetails.EnableAdd = False
    TBLnprkVrfrApplications.PrintUrl &= Request.QueryString("ClaimID") & "|"
    TBLnprkVrfrApplications.PrintUrl &= Request.QueryString("ApplicationID") & "|"
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/NPRK_Main/App_Edit") & "/EF_nprkVrfrApplications.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptnprkVrfrApplications") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptnprkVrfrApplications", mStr)
    End If
  End Sub
  Partial Class gvBase
    Inherits SIS.SYS.GridBase
  End Class
  Private WithEvents gvnprkBillDetailsCC As New gvBase
  Protected Sub GVnprkBillDetails_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVnprkBillDetails.Init
    gvnprkBillDetailsCC.DataClassName = "GnprkBillDetails"
    gvnprkBillDetailsCC.SetGridView = GVnprkBillDetails
  End Sub
  Protected Sub TBLnprkBillDetails_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLnprkBillDetails.Init
    gvnprkBillDetailsCC.SetToolBar = TBLnprkBillDetails
  End Sub
  Protected Sub GVnprkBillDetails_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVnprkBillDetails.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim ClaimID As Int32 = GVnprkBillDetails.DataKeys(e.CommandArgument).Values("ClaimID")
        Dim ApplicationID As Int32 = GVnprkBillDetails.DataKeys(e.CommandArgument).Values("ApplicationID")
        Dim AttachmentID As Int32 = GVnprkBillDetails.DataKeys(e.CommandArgument).Values("AttachmentID")
        Dim RedirectUrl As String = TBLnprkBillDetails.EditUrl & "?ClaimID=" & ClaimID & "&ApplicationID=" & ApplicationID & "&AttachmentID=" & AttachmentID
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
      End Try
    End If
  End Sub
  Protected Sub TBLnprkBillDetails_AddClicked(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles TBLnprkBillDetails.AddClicked
    Dim ClaimID As Int32 = CType(FVnprkVrfrApplications.FindControl("F_ClaimID"), TextBox).Text
    Dim ApplicationID As Int32 = CType(FVnprkVrfrApplications.FindControl("F_ApplicationID"), TextBox).Text
    TBLnprkBillDetails.AddUrl &= "?ClaimID=" & ClaimID
    TBLnprkBillDetails.AddUrl &= "&ApplicationID=" & ApplicationID
  End Sub

  Private Sub FVnprkVrfrApplications_DataBound(sender As Object, e As EventArgs) Handles FVnprkVrfrApplications.DataBound
    Dim oBal As LC_PrkBalance = FVnprkVrfrApplications.FindControl("LC_PrkBalance1")
    If Not oBal Is Nothing Then
      oBal.LoadData()
    End If
  End Sub

  Private Sub FVnprkVrfrApplications_ItemCommand(sender As Object, e As FormViewCommandEventArgs) Handles FVnprkVrfrApplications.ItemCommand
    If e.CommandName.ToLower = "svnfd".ToLower Then
      Try
        Dim ClaimID As Int32 = CType(FVnprkVrfrApplications.FindControl("F_ClaimID"), TextBox).Text
        Dim ApplicationID As Int32 = CType(FVnprkVrfrApplications.FindControl("F_ApplicationID"), TextBox).Text
        Dim Verified As Boolean = CType(FVnprkVrfrApplications.FindControl("F_Verified"), DropDownList).SelectedValue
        Dim Documents As Boolean = CType(FVnprkVrfrApplications.FindControl("F_Documents"), DropDownList).SelectedValue
        Dim PaymentMethod As String = CType(FVnprkVrfrApplications.FindControl("F_PaymentMethod"), DropDownList).SelectedValue
        Dim VerifiedAmt As Decimal = CType(FVnprkVrfrApplications.FindControl("F_VerifiedAmt"), TextBox).Text
        Dim VerifierRemark As String = CType(FVnprkVrfrApplications.FindControl("F_VerifierRemark"), TextBox).Text
        SIS.NPRK.nprkVrfrApplications.ApproveWF(ClaimID, ApplicationID, Documents, Verified, PaymentMethod, VerifiedAmt, VerifierRemark)
        Response.Redirect(SIS.SYS.Utilities.SessionManager.PopNavBar())
      Catch ex As Exception
        Dim message As String = New JavaScriptSerializer().Serialize(ex.Message)
        Dim script As String = String.Format("alert({0});", message)
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", script, True)
        Exit Sub
      End Try
    End If
    If e.CommandName.ToLower = "lgdownload" Then
      Dim aVal() As String = e.CommandArgument.ToString.Split("|".ToCharArray)
      Dim ClaimID As String = aVal(0)
      Dim ApplicationID As String = aVal(1)
      Dim tmpApl As SIS.NPRK.nprkApplications = SIS.NPRK.nprkApplications.nprkApplicationsGetByID(ClaimID, ApplicationID)
      If IO.File.Exists(tmpApl.ReportDiskFile) Then
        Response.Clear()
        Response.AppendHeader("content-disposition", "attachment; filename=" & tmpApl.ReportFileName)
        Response.ContentType = SIS.SYS.Utilities.ApplicationSpacific.ContentType(tmpApl.ReportFileName)
        Response.WriteFile(tmpApl.ReportDiskFile)
        Response.End()
      End If
    End If
  End Sub
End Class
