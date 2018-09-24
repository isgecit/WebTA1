Imports System.Web.Script.Serialization
Partial Class EF_pakPkgListH
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
  Protected Sub ODSpakPkgListH_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODSpakPkgListH.Selected
    Dim tmp As SIS.PAK.pakPkgListH = CType(e.ReturnValue, SIS.PAK.pakPkgListH)
    Editable = tmp.Editable
    Deleteable = tmp.Deleteable
    PrimaryKey = tmp.PrimaryKey
  End Sub
  Protected Sub FVpakPkgListH_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpakPkgListH.Init
    DataClassName = "EpakPkgListH"
    SetFormView = FVpakPkgListH
  End Sub
  Protected Sub TBLpakPkgListH_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLpakPkgListH.Init
    SetToolBar = TBLpakPkgListH
  End Sub
  Protected Sub FVpakPkgListH_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpakPkgListH.PreRender
    TBLpakPkgListH.EnableSave = Editable
    TBLpakPkgListH.EnableDelete = Deleteable
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/PAK_Main/App_Edit") & "/EF_pakPkgListH.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptpakPkgListH") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptpakPkgListH", mStr)
    End If
  End Sub
  Partial Class gvBase
    Inherits SIS.SYS.GridBase
  End Class
  Private WithEvents gvpakPkgListDCC As New gvBase
  Protected Sub GVpakPkgListD_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVpakPkgListD.Init
    gvpakPkgListDCC.DataClassName = "GpakPkgListD"
    gvpakPkgListDCC.SetGridView = GVpakPkgListD
  End Sub
  Protected Sub TBLpakPkgListD_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLpakPkgListD.Init
    gvpakPkgListDCC.SetToolBar = TBLpakPkgListD
  End Sub
  Protected Sub GVpakPkgListD_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVpakPkgListD.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim SerialNo As Int32 = GVpakPkgListD.DataKeys(e.CommandArgument).Values("SerialNo")  
        Dim PkgNo As Int32 = GVpakPkgListD.DataKeys(e.CommandArgument).Values("PkgNo")  
        Dim BOMNo As Int32 = GVpakPkgListD.DataKeys(e.CommandArgument).Values("BOMNo")  
        Dim ItemNo As Int32 = GVpakPkgListD.DataKeys(e.CommandArgument).Values("ItemNo")  
        Dim RedirectUrl As String = TBLpakPkgListD.EditUrl & "?SerialNo=" & SerialNo & "&PkgNo=" & PkgNo & "&BOMNo=" & BOMNo & "&ItemNo=" & ItemNo
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
      End Try
    End If
  End Sub
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function TransporterIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.PAK.pakBusinessPartner.SelectpakBusinessPartnerAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function VRExecutionNoCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.VR.vrRequestExecution.SelectvrRequestExecutionAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_PAK_PkgListH_TransporterID(ByVal value As String) As String
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
  Public Shared Function validate_FK_PAK_PkgListH_VRExecutionNo(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
    Dim VRExecutionNo As Int32 = 0
    Try
      VRExecutionNo = CType(aVal(1), Int32)
    Catch ex As Exception
      VRExecutionNo = 0
    End Try
    Dim oVar As SIS.VR.vrRequestExecution = SIS.VR.vrRequestExecution.vrRequestExecutionGetByID(VRExecutionNo)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found.|"
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField & "|" & oVar.TransporterID
    End If
    Return mRet
  End Function

End Class
