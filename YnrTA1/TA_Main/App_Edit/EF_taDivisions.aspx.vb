Partial Class EF_taDivisions
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
  Protected Sub ODStaDivisions_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODStaDivisions.Selected
    Dim tmp As SIS.TA.taDivisions = CType(e.ReturnValue, SIS.TA.taDivisions)
    Editable = tmp.Editable
    Deleteable = tmp.Deleteable
    PrimaryKey = tmp.PrimaryKey
  End Sub
  Protected Sub FVtaDivisions_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVtaDivisions.Init
    DataClassName = "EtaDivisions"
    SetFormView = FVtaDivisions
  End Sub
  Protected Sub TBLtaDivisions_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLtaDivisions.Init
    SetToolBar = TBLtaDivisions
  End Sub
  Protected Sub FVtaDivisions_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVtaDivisions.PreRender
    TBLtaDivisions.EnableSave = Editable
    TBLtaDivisions.EnableDelete = Deleteable
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/TA_Main/App_Edit") & "/EF_taDivisions.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scripttaDivisions") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scripttaDivisions", mStr)
    End If
  End Sub
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function DivisionHeadCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.TA.taEmployees.SelecttaEmployeesAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_HRM_Divisions_DivisionHead(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
    Dim DivisionHead As String = CType(aVal(1),String)
    Dim oVar As SIS.TA.taEmployees = SIS.TA.taEmployees.taEmployeesGetByID(DivisionHead)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found." 
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function

End Class
