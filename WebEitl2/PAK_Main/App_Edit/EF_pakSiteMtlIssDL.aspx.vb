Imports System.Web.Script.Serialization
Partial Class EF_pakSiteMtlIssDL
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
  Protected Sub ODSpakSiteMtlIssDL_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODSpakSiteMtlIssDL.Selected
    Dim tmp As SIS.PAK.pakSiteMtlIssDL = CType(e.ReturnValue, SIS.PAK.pakSiteMtlIssDL)
    Editable = tmp.Editable
    Deleteable = tmp.Deleteable
    PrimaryKey = tmp.PrimaryKey
  End Sub
  Protected Sub FVpakSiteMtlIssDL_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpakSiteMtlIssDL.Init
    DataClassName = "EpakSiteMtlIssDL"
    SetFormView = FVpakSiteMtlIssDL
  End Sub
  Protected Sub TBLpakSiteMtlIssDL_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLpakSiteMtlIssDL.Init
    SetToolBar = TBLpakSiteMtlIssDL
  End Sub
  Protected Sub FVpakSiteMtlIssDL_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpakSiteMtlIssDL.PreRender
    TBLpakSiteMtlIssDL.EnableSave = Editable
    TBLpakSiteMtlIssDL.EnableDelete = Deleteable
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/PAK_Main/App_Edit") & "/EF_pakSiteMtlIssDL.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptpakSiteMtlIssDL") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptpakSiteMtlIssDL", mStr)
    End If
  End Sub
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function SiteMarkNoCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.PAK.pakSiteItemMaster.SelectpakSiteItemMasterAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_PAK_SiteIssueDLocation_SiteMarkNo(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
    Dim ProjectID As String = CType(aVal(1),String)
    Dim SiteMarkNo As String = CType(aVal(2),String)
    Dim oVar As SIS.PAK.pakSiteItemMaster = SIS.PAK.pakSiteItemMaster.pakSiteItemMasterGetByID(ProjectID,SiteMarkNo)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found." 
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function

End Class
