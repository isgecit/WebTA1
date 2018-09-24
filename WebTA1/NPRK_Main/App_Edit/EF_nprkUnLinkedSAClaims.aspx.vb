Partial Class EF_nprkUnLinkedSAClaims
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
  Protected Sub ODSnprkUnLinkedSAClaims_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODSnprkUnLinkedSAClaims.Selected
    Dim tmp As SIS.NPRK.nprkUnLinkedSAClaims = CType(e.ReturnValue, SIS.NPRK.nprkUnLinkedSAClaims)
    Editable = tmp.Editable
    Deleteable = tmp.Deleteable
    PrimaryKey = tmp.PrimaryKey
  End Sub
  Protected Sub FVnprkUnLinkedSAClaims_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVnprkUnLinkedSAClaims.Init
    DataClassName = "EnprkUnLinkedSAClaims"
    SetFormView = FVnprkUnLinkedSAClaims
  End Sub
  Protected Sub TBLnprkUnLinkedSAClaims_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLnprkUnLinkedSAClaims.Init
    SetToolBar = TBLnprkUnLinkedSAClaims
  End Sub
  Protected Sub FVnprkUnLinkedSAClaims_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVnprkUnLinkedSAClaims.PreRender
    TBLnprkUnLinkedSAClaims.EnableSave = Editable
    TBLnprkUnLinkedSAClaims.EnableDelete = Deleteable
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/NPRK_Main/App_Edit") & "/EF_nprkUnLinkedSAClaims.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptnprkUnLinkedSAClaims") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptnprkUnLinkedSAClaims", mStr)
    End If
  End Sub
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_PRK_SiteAllowanceClaims_AdviceNo(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
    Dim FinYear As Int32 = CType(aVal(1),Int32)
    Dim Quarter As Int32 = CType(aVal(2),Int32)
    Dim AdviceNo As Int32 = CType(aVal(3),Int32)
    Dim oVar As SIS.NPRK.nprkSiteAllowanceAdvice = SIS.NPRK.nprkSiteAllowanceAdvice.nprkSiteAllowanceAdviceGetByID(FinYear,Quarter,AdviceNo)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found." 
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function

End Class
