Partial Class EF_taEmployees
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
  Protected Sub ODStaEmployees_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODStaEmployees.Selected
    Dim tmp As SIS.TA.taEmployees = CType(e.ReturnValue, SIS.TA.taEmployees)
    Editable = tmp.Editable
    Deleteable = False
    PrimaryKey = tmp.PrimaryKey
  End Sub
  Protected Sub FVtaEmployees_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVtaEmployees.Init
    DataClassName = "EtaEmployees"
    SetFormView = FVtaEmployees
  End Sub
  Protected Sub TBLtaEmployees_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLtaEmployees.Init
    SetToolBar = TBLtaEmployees
  End Sub
  Protected Sub FVtaEmployees_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVtaEmployees.PreRender
    TBLtaEmployees.EnableSave = Editable
    TBLtaEmployees.EnableDelete = Deleteable
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/TA_Main/App_Edit") & "/EF_taEmployees.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scripttaEmployees") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scripttaEmployees", mStr)
    End If
  End Sub

  Private Sub FVtaEmployees_ItemUpdating(sender As Object, e As FormViewUpdateEventArgs) Handles FVtaEmployees.ItemUpdating
    If Request.QueryString("TABillNo") IsNot Nothing Then
      Dim TABillNo As String = Request.QueryString("TABillNo")
      Dim TACate As String = e.NewValues.Item("CategoryID")
      If TACate <> String.Empty Then
        Dim oTA As SIS.TA.taBH = SIS.TA.taBH.taBHGetByID(TABillNo)
        If oTA IsNot Nothing Then
          oTA.TACategoryID = TACate
          SIS.TA.taBH.UpdateData(oTA)
          SIS.TA.taBH.ValidateTABill(oTA.TABillNo)
        End If
      End If
    End If
  End Sub
End Class
