Imports System.Web.Script.Serialization
Partial Class EF_pakSitePkgH
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
  Protected Sub ODSpakSitePkgH_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODSpakSitePkgH.Selected
    Dim tmp As SIS.PAK.pakSitePkgH = CType(e.ReturnValue, SIS.PAK.pakSitePkgH)
    Editable = tmp.Editable
    Deleteable = tmp.Deleteable
    PrimaryKey = tmp.PrimaryKey
  End Sub
  Protected Sub FVpakSitePkgH_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpakSitePkgH.Init
    DataClassName = "EpakSitePkgH"
    SetFormView = FVpakSitePkgH
  End Sub
  Protected Sub TBLpakSitePkgH_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLpakSitePkgH.Init
    SetToolBar = TBLpakSitePkgH
  End Sub
  Protected Sub FVpakSitePkgH_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpakSitePkgH.PreRender
    TBLpakSitePkgH.EnableSave = Editable
    TBLpakSitePkgH.EnableDelete = Deleteable
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/PAK_Main/App_Edit") & "/EF_pakSitePkgH.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptpakSitePkgH") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptpakSitePkgH", mStr)
    End If
  End Sub
  Partial Class gvBase
    Inherits SIS.SYS.GridBase
  End Class
  Private WithEvents gvpakSitePkgDCC As New gvBase
  Protected Sub GVpakSitePkgD_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVpakSitePkgD.Init
    gvpakSitePkgDCC.DataClassName = "GpakSitePkgD"
    gvpakSitePkgDCC.SetGridView = GVpakSitePkgD
  End Sub
  Protected Sub TBLpakSitePkgD_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLpakSitePkgD.Init
    gvpakSitePkgDCC.SetToolBar = TBLpakSitePkgD
  End Sub
  Protected Sub GVpakSitePkgD_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVpakSitePkgD.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim ProjectID As String = GVpakSitePkgD.DataKeys(e.CommandArgument).Values("ProjectID")  
        Dim RecNo As Int32 = GVpakSitePkgD.DataKeys(e.CommandArgument).Values("RecNo")  
        Dim RecSrNo As Int32 = GVpakSitePkgD.DataKeys(e.CommandArgument).Values("RecSrNo")  
        Dim RedirectUrl As String = TBLpakSitePkgD.EditUrl & "?ProjectID=" & ProjectID & "&RecNo=" & RecNo & "&RecSrNo=" & RecSrNo
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
      End Try
    End If
    If e.CommandName.ToLower = "initiatewf".ToLower Then
      Try
        Dim LocationID As Int32 = CType(GVpakSitePkgD.Rows(e.CommandArgument).FindControl("F_LocationID"), LC_pakSiteLocations).SelectedValue
        Dim Quantity As Decimal = CType(GVpakSitePkgD.Rows(e.CommandArgument).FindControl("F_Quantity"), TextBox).Text
        Dim ProjectID As String = GVpakSitePkgD.DataKeys(e.CommandArgument).Values("ProjectID")
        Dim RecNo As Int32 = GVpakSitePkgD.DataKeys(e.CommandArgument).Values("RecNo")  
        Dim RecSrNo As Int32 = GVpakSitePkgD.DataKeys(e.CommandArgument).Values("RecSrNo")
        SIS.PAK.pakSitePkgD.InitiateWF(ProjectID, RecNo, RecSrNo, Quantity, LocationID)
        GVpakSitePkgD.DataBind()
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
      End Try
    End If
    If e.CommandName.ToLower = "approvewf".ToLower Then
      Try
        Dim LocationID As Int32 = CType(GVpakSitePkgD.Rows(e.CommandArgument).FindControl("F_LocationID"), LC_pakSiteLocations).SelectedValue
        Dim Quantity As Decimal = CType(GVpakSitePkgD.Rows(e.CommandArgument).FindControl("F_Quantity"), TextBox).Text
        Dim ProjectID As String = GVpakSitePkgD.DataKeys(e.CommandArgument).Values("ProjectID")
        Dim RecNo As Int32 = GVpakSitePkgD.DataKeys(e.CommandArgument).Values("RecNo")  
        Dim RecSrNo As Int32 = GVpakSitePkgD.DataKeys(e.CommandArgument).Values("RecSrNo")
        SIS.PAK.pakSitePkgD.ApproveWF(ProjectID, RecNo, RecSrNo, Quantity, LocationID)
        GVpakSitePkgD.DataBind()
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
      End Try
    End If
  End Sub
  Protected Sub TBLpakSitePkgD_AddClicked(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles TBLpakSitePkgD.AddClicked
    Dim ProjectID As String = CType(FVpakSitePkgH.FindControl("F_ProjectID"),TextBox).Text
    Dim RecNo As Int32 = CType(FVpakSitePkgH.FindControl("F_RecNo"),TextBox).Text
    TBLpakSitePkgD.AddUrl &= "&ProjectID=" & ProjectID
    TBLpakSitePkgD.AddUrl &= "&RecNo=" & RecNo
  End Sub
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function MRNNoCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.PAK.pakLorryReceipts.SelectpakLorryReceiptsAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function TransporterIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.PAK.pakBusinessPartner.SelectpakBusinessPartnerAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function UOMTotalWeightCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.PAK.pakUnits.SelectpakUnitsAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_PAK_SitePkgH_UOMTotalWeight(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
    Dim UOMTotalWeight As Int32 = CType(aVal(1),Int32)
    Dim oVar As SIS.PAK.pakUnits = SIS.PAK.pakUnits.pakUnitsGetByID(UOMTotalWeight)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found." 
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_PAK_SitePkgH_TransporterID(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
    Dim TransporterID As String = CType(aVal(1),String)
    Dim oVar As SIS.PAK.pakBusinessPartner = SIS.PAK.pakBusinessPartner.pakBusinessPartnerGetByID(TransporterID)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found." 
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_PAK_SitePkgH_MRNNo(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
    Dim ProjectID As String = CType(aVal(1),String)
    Dim MRNNo As Int32 = CType(aVal(2),Int32)
    Dim oVar As SIS.PAK.pakLorryReceipts = SIS.PAK.pakLorryReceipts.pakLorryReceiptsGetByID(ProjectID,MRNNo)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found." 
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function

End Class
