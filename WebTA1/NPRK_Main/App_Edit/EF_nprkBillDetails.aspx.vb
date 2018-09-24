Partial Class EF_nprkBillDetails
  Inherits SIS.SYS.UpdateBase
  Public ReadOnly Property CssClass As String
    Get
      If Enabled Then
        Return "mytxt"
      Else
        Return "dmytxt"
      End If
    End Get
  End Property
  Public Property Enabled As Boolean
    Get
      If ViewState("Enabled") IsNot Nothing Then
        Return CType(ViewState("Enabled"), Boolean)
      End If
      Return False
    End Get
    Set(value As Boolean)
      ViewState.Add("Enabled", value)
    End Set
  End Property
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
  Protected Sub ODSnprkBillDetails_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODSnprkBillDetails.Selected
    Dim tmp As SIS.NPRK.nprkBillDetails = CType(e.ReturnValue, SIS.NPRK.nprkBillDetails)
    Editable = tmp.Editable
    Deleteable = tmp.Deleteable
    PrimaryKey = tmp.PrimaryKey
    If tmp.FK_PRK_BillDetails_PRK_Applications.PerkID = prkPerk.DriverCharges Then
      If tmp.EntitlementID <> String.Empty Then
        Enabled = False
      Else
        Enabled = True
      End If
    Else
      Enabled = True
    End If
  End Sub
  Protected Sub FVnprkBillDetails_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVnprkBillDetails.Init
    DataClassName = "EnprkBillDetails"
    SetFormView = FVnprkBillDetails
  End Sub
  Protected Sub TBLnprkBillDetails_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLnprkBillDetails.Init
    SetToolBar = TBLnprkBillDetails
  End Sub
  Protected Sub FVnprkBillDetails_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVnprkBillDetails.PreRender
    TBLnprkBillDetails.EnableSave = Editable
    TBLnprkBillDetails.EnableDelete = Deleteable
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/NPRK_Main/App_Edit") & "/EF_nprkBillDetails.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptnprkBillDetails") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptnprkBillDetails", mStr)
    End If
    '========Customization==================
    Dim ClaimID As Integer = CType(Request.QueryString("ClaimID"), Integer)
    Dim ApplicationID As Integer = CType(Request.QueryString("ApplicationID"), Integer)
    SIS.NPRK.nprkBillDetails.CustomizeView(FVnprkBillDetails, ClaimID, ApplicationID)
    '======End Customization================
  End Sub
  Protected Sub DateChanged(ByVal sender As Object, ByVal e As System.EventArgs)
    SIS.NPRK.nprkBillDetails.ValidateData(FVnprkBillDetails, sender)
  End Sub
  Private Sub ODSnprkBillDetails_Updating(sender As Object, e As ObjectDataSourceMethodEventArgs) Handles ODSnprkBillDetails.Updating
    SIS.NPRK.nprkBillDetails.ValidateData(FVnprkBillDetails, FVnprkBillDetails.FindControl("F_FromDate"))
  End Sub
End Class
