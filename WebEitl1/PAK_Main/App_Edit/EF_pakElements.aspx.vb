Partial Class EF_pakElements
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
  Protected Sub ODSpakElements_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODSpakElements.Selected
    Dim tmp As SIS.PAK.pakElements = CType(e.ReturnValue, SIS.PAK.pakElements)
    Editable = tmp.Editable
    Deleteable = tmp.Deleteable
    PrimaryKey = tmp.PrimaryKey
  End Sub
  Protected Sub FVpakElements_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpakElements.Init
    DataClassName = "EpakElements"
    SetFormView = FVpakElements
  End Sub
  Protected Sub TBLpakElements_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLpakElements.Init
    SetToolBar = TBLpakElements
  End Sub
  Protected Sub FVpakElements_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpakElements.PreRender
    TBLpakElements.EnableSave = Editable
    TBLpakElements.EnableDelete = Deleteable
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/PAK_Main/App_Edit") & "/EF_pakElements.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptpakElements") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptpakElements", mStr)
    End If
  End Sub
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function ParentElementIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.PAK.pakElements.SelectpakElementsAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_PAK_Elements_ParentElementID(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
    Dim ParentElementID As String = CType(aVal(1),String)
    Dim oVar As SIS.PAK.pakElements = SIS.PAK.pakElements.pakElementsGetByID(ParentElementID)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found." 
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function

End Class
