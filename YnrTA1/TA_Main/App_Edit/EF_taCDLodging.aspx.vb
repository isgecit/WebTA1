Partial Class EF_taCDLodging
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
  Protected Sub ODStaCDLodging_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODStaCDLodging.Selected
    Dim tmp As SIS.TA.taCDLodging = CType(e.ReturnValue, SIS.TA.taCDLodging)
    Editable = tmp.Editable
    Deleteable = False
    PrimaryKey = tmp.PrimaryKey
  End Sub
  Protected Sub FVtaCDLodging_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVtaCDLodging.Init
    DataClassName = "EtaCDLodging"
    SetFormView = FVtaCDLodging
  End Sub
  Protected Sub TBLtaCDLodging_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLtaCDLodging.Init
    SetToolBar = TBLtaCDLodging
  End Sub
  Protected Sub FVtaCDLodging_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVtaCDLodging.PreRender
    TBLtaCDLodging.EnableSave = Editable
    TBLtaCDLodging.EnableDelete = Deleteable
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/TA_Main/App_Edit") & "/EF_taCDLodging.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scripttaCDLodging") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scripttaCDLodging", mStr)
    End If
  End Sub
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function ProjectIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.QCM.qcmProjects.SelectqcmProjectsAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_TA_BillDetails_ProjectID(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
    Dim ProjectID As String = CType(aVal(1),String)
    Dim oVar As SIS.QCM.qcmProjects = SIS.QCM.qcmProjects.qcmProjectsGetByID(ProjectID)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found." 
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function

End Class
