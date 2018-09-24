Partial Class EF_psfCreation
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
  Protected Sub ODSpsfCreation_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODSpsfCreation.Selected
    Dim tmp As SIS.PSF.psfCreation = CType(e.ReturnValue, SIS.PSF.psfCreation)
    Editable = tmp.Editable
    Deleteable = tmp.Deleteable
    PrimaryKey = tmp.PrimaryKey
  End Sub
  Protected Sub FVpsfCreation_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpsfCreation.Init
    DataClassName = "EpsfCreation"
    SetFormView = FVpsfCreation
  End Sub
  Protected Sub TBLpsfCreation_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLpsfCreation.Init
    SetToolBar = TBLpsfCreation
  End Sub
  Protected Sub FVpsfCreation_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpsfCreation.PreRender
    TBLpsfCreation.EnableSave = Editable
    TBLpsfCreation.EnableDelete = Deleteable
    TBLpsfCreation.PrintUrl &= Request.QueryString("SerialNo") & "|"
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/PSF_Main/App_Edit") & "/EF_psfCreation.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptpsfCreation") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptpsfCreation", mStr)
    End If
  End Sub
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function SupplierCodeCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.PSF.psfSupplier.SelectpsfSupplierAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_PSF_HSBCMain_SupplierID(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
    Dim SupplierCode As String = CType(aVal(1),String)
    Dim oVar As SIS.PSF.psfSupplier = SIS.PSF.psfSupplier.psfSupplierGetByID(SupplierCode)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found." 
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function
  <System.Web.Services.WebMethod()>
  Public Shared Function getIRData(ByVal value As String) As String
    Return SIS.PSF.psfCreation.getIRData(value)
  End Function
  <System.Web.Services.WebMethod()>
  Public Shared Function getCqData(ByVal value As String) As String
    Return SIS.PSF.psfCreation.getCqData(value)
  End Function

End Class
