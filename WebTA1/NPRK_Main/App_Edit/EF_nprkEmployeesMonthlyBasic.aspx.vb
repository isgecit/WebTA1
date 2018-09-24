Partial Class EF_nprkEmployeesMonthlyBasic
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
  Protected Sub ODSnprkEmployeesMonthlyBasic_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODSnprkEmployeesMonthlyBasic.Selected
    Dim tmp As SIS.NPRK.nprkEmployeesMonthlyBasic = CType(e.ReturnValue, SIS.NPRK.nprkEmployeesMonthlyBasic)
    Editable = tmp.Editable
    Deleteable = tmp.Deleteable
    PrimaryKey = tmp.PrimaryKey
  End Sub
  Protected Sub FVnprkEmployeesMonthlyBasic_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVnprkEmployeesMonthlyBasic.Init
    DataClassName = "EnprkEmployeesMonthlyBasic"
    SetFormView = FVnprkEmployeesMonthlyBasic
  End Sub
  Protected Sub TBLnprkEmployeesMonthlyBasic_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLnprkEmployeesMonthlyBasic.Init
    SetToolBar = TBLnprkEmployeesMonthlyBasic
  End Sub
  Protected Sub FVnprkEmployeesMonthlyBasic_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVnprkEmployeesMonthlyBasic.PreRender
    TBLnprkEmployeesMonthlyBasic.EnableSave = Editable
    TBLnprkEmployeesMonthlyBasic.EnableDelete = Deleteable
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/NPRK_Main/App_Edit") & "/EF_nprkEmployeesMonthlyBasic.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptnprkEmployeesMonthlyBasic") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptnprkEmployeesMonthlyBasic", mStr)
    End If
  End Sub

End Class
