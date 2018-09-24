Partial Class EF_taCH
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
  Protected Sub ODStaCH_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODStaCH.Selected
    Dim tmp As SIS.TA.taCH = CType(e.ReturnValue, SIS.TA.taCH)
    Editable = tmp.Editable
    Deleteable = tmp.Deleteable
    PrimaryKey = tmp.PrimaryKey
  End Sub
  Protected Sub FVtaCH_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVtaCH.Init
    DataClassName = "EtaCH"
    SetFormView = FVtaCH
  End Sub
  Protected Sub TBLtaCH_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLtaCH.Init
    SetToolBar = TBLtaCH
  End Sub
  Protected Sub FVtaCH_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVtaCH.PreRender
    TBLtaCH.EnableSave = Editable
    TBLtaCH.EnableDelete = Deleteable
    TBLtaCH.PrintUrl &= Request.QueryString("TABillNo") & "|"
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/TA_Main/App_Edit") & "/EF_taCH.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scripttaCH") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scripttaCH", mStr)
    End If
  End Sub
  Partial Class gvBase
    Inherits SIS.SYS.GridBase
  End Class
  Private WithEvents gvtaCDFareCC As New gvBase
  Protected Sub GVtaCDFare_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVtaCDFare.Init
    gvtaCDFareCC.DataClassName = "GtaCDFare"
    gvtaCDFareCC.SetGridView = GVtaCDFare
  End Sub
  Protected Sub TBLtaCDFare_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLtaCDFare.Init
    gvtaCDFareCC.SetToolBar = TBLtaCDFare
  End Sub
  Protected Sub GVtaCDFare_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVtaCDFare.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim TABillNo As Int32 = GVtaCDFare.DataKeys(e.CommandArgument).Values("TABillNo")  
        Dim SerialNo As Int32 = GVtaCDFare.DataKeys(e.CommandArgument).Values("SerialNo")  
        Dim RedirectUrl As String = TBLtaCDFare.EditUrl & "?TABillNo=" & TABillNo & "&SerialNo=" & SerialNo
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
      End Try
    End If
  End Sub
  Private WithEvents gvtaCDLCCC As New gvBase
  Protected Sub GVtaCDLC_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVtaCDLC.Init
    gvtaCDLCCC.DataClassName = "GtaCDLC"
    gvtaCDLCCC.SetGridView = GVtaCDLC
  End Sub
  Protected Sub TBLtaCDLC_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLtaCDLC.Init
    gvtaCDLCCC.SetToolBar = TBLtaCDLC
  End Sub
  Protected Sub GVtaCDLC_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVtaCDLC.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim TABillNo As Int32 = GVtaCDLC.DataKeys(e.CommandArgument).Values("TABillNo")  
        Dim SerialNo As Int32 = GVtaCDLC.DataKeys(e.CommandArgument).Values("SerialNo")  
        Dim RedirectUrl As String = TBLtaCDLC.EditUrl & "?TABillNo=" & TABillNo & "&SerialNo=" & SerialNo
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
      End Try
    End If
  End Sub
  Private WithEvents gvtaCDLodgingCC As New gvBase
  Protected Sub GVtaCDLodging_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVtaCDLodging.Init
    gvtaCDLodgingCC.DataClassName = "GtaCDLodging"
    gvtaCDLodgingCC.SetGridView = GVtaCDLodging
  End Sub
  Protected Sub TBLtaCDLodging_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLtaCDLodging.Init
    gvtaCDLodgingCC.SetToolBar = TBLtaCDLodging
  End Sub
  Protected Sub GVtaCDLodging_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVtaCDLodging.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim TABillNo As Int32 = GVtaCDLodging.DataKeys(e.CommandArgument).Values("TABillNo")  
        Dim SerialNo As Int32 = GVtaCDLodging.DataKeys(e.CommandArgument).Values("SerialNo")  
        Dim RedirectUrl As String = TBLtaCDLodging.EditUrl & "?TABillNo=" & TABillNo & "&SerialNo=" & SerialNo
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
      End Try
    End If
  End Sub
  Private WithEvents gvtaCDExpenseCC As New gvBase
  Protected Sub GVtaCDExpense_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVtaCDExpense.Init
    gvtaCDExpenseCC.DataClassName = "GtaCDExpense"
    gvtaCDExpenseCC.SetGridView = GVtaCDExpense
  End Sub
  Protected Sub TBLtaCDExpense_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLtaCDExpense.Init
    gvtaCDExpenseCC.SetToolBar = TBLtaCDExpense
  End Sub
  Protected Sub GVtaCDExpense_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVtaCDExpense.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim TABillNo As Int32 = GVtaCDExpense.DataKeys(e.CommandArgument).Values("TABillNo")  
        Dim SerialNo As Int32 = GVtaCDExpense.DataKeys(e.CommandArgument).Values("SerialNo")  
        Dim RedirectUrl As String = TBLtaCDExpense.EditUrl & "?TABillNo=" & TABillNo & "&SerialNo=" & SerialNo
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
      End Try
    End If
    If e.CommandName.ToLower = "Deletewf".ToLower Then
      Try
        Dim TABillNo As Int32 = GVtaCDExpense.DataKeys(e.CommandArgument).Values("TABillNo")  
        Dim SerialNo As Int32 = GVtaCDExpense.DataKeys(e.CommandArgument).Values("SerialNo")  
        SIS.TA.taCDExpense.DeleteWF(TABillNo, SerialNo)
        GVtaCDExpense.DataBind()
      Catch ex As Exception
      End Try
    End If
  End Sub
  Protected Sub TBLtaCDExpense_AddClicked(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles TBLtaCDExpense.AddClicked
    Dim TABillNo As Int32 = CType(FVtaCH.FindControl("F_TABillNo"),TextBox).Text
    TBLtaCDExpense.AddUrl &= "?TABillNo=" & TABillNo
  End Sub
  Private WithEvents gvtaCDFinanceCC As New gvBase
  Protected Sub GVtaCDFinance_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVtaCDFinance.Init
    gvtaCDFinanceCC.DataClassName = "GtaCDFinance"
    gvtaCDFinanceCC.SetGridView = GVtaCDFinance
  End Sub
  Protected Sub TBLtaCDFinance_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLtaCDFinance.Init
    gvtaCDFinanceCC.SetToolBar = TBLtaCDFinance
  End Sub
  Protected Sub GVtaCDFinance_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVtaCDFinance.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim TABillNo As Int32 = GVtaCDFinance.DataKeys(e.CommandArgument).Values("TABillNo")  
        Dim SerialNo As Int32 = GVtaCDFinance.DataKeys(e.CommandArgument).Values("SerialNo")  
        Dim RedirectUrl As String = TBLtaCDFinance.EditUrl & "?TABillNo=" & TABillNo & "&SerialNo=" & SerialNo
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
      End Try
    End If
    If e.CommandName.ToLower = "Deletewf".ToLower Then
      Try
        Dim TABillNo As Int32 = GVtaCDFinance.DataKeys(e.CommandArgument).Values("TABillNo")  
        Dim SerialNo As Int32 = GVtaCDFinance.DataKeys(e.CommandArgument).Values("SerialNo")  
        SIS.TA.taCDFinance.DeleteWF(TABillNo, SerialNo)
        GVtaCDFinance.DataBind()
      Catch ex As Exception
      End Try
    End If
  End Sub
  Protected Sub TBLtaCDFinance_AddClicked(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles TBLtaCDFinance.AddClicked
    Dim TABillNo As Int32 = CType(FVtaCH.FindControl("F_TABillNo"),TextBox).Text
    TBLtaCDFinance.AddUrl &= "?TABillNo=" & TABillNo
  End Sub
  Private WithEvents gvtaCDMileageCC As New gvBase
  Protected Sub GVtaCDMileage_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVtaCDMileage.Init
    gvtaCDMileageCC.DataClassName = "GtaCDMileage"
    gvtaCDMileageCC.SetGridView = GVtaCDMileage
  End Sub
  Protected Sub TBLtaCDMileage_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLtaCDMileage.Init
    gvtaCDMileageCC.SetToolBar = TBLtaCDMileage
  End Sub
  Protected Sub GVtaCDMileage_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVtaCDMileage.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim TABillNo As Int32 = GVtaCDMileage.DataKeys(e.CommandArgument).Values("TABillNo")  
        Dim SerialNo As Int32 = GVtaCDMileage.DataKeys(e.CommandArgument).Values("SerialNo")  
        Dim RedirectUrl As String = TBLtaCDMileage.EditUrl & "?TABillNo=" & TABillNo & "&SerialNo=" & SerialNo
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
      End Try
    End If
  End Sub
  Private WithEvents gvtaCDDriverCC As New gvBase
  Protected Sub GVtaCDDriver_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVtaCDDriver.Init
    gvtaCDDriverCC.DataClassName = "GtaCDDriver"
    gvtaCDDriverCC.SetGridView = GVtaCDDriver
  End Sub
  Protected Sub TBLtaCDDriver_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLtaCDDriver.Init
    gvtaCDDriverCC.SetToolBar = TBLtaCDDriver
  End Sub
  Protected Sub GVtaCDDriver_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVtaCDDriver.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim TABillNo As Int32 = GVtaCDDriver.DataKeys(e.CommandArgument).Values("TABillNo")  
        Dim SerialNo As Int32 = GVtaCDDriver.DataKeys(e.CommandArgument).Values("SerialNo")  
        Dim RedirectUrl As String = TBLtaCDDriver.EditUrl & "?TABillNo=" & TABillNo & "&SerialNo=" & SerialNo
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
      End Try
    End If
  End Sub
  Private WithEvents gvtaCDDACC As New gvBase
  Protected Sub GVtaCDDA_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVtaCDDA.Init
    gvtaCDDACC.DataClassName = "GtaCDDA"
    gvtaCDDACC.SetGridView = GVtaCDDA
  End Sub
  Protected Sub TBLtaCDDA_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLtaCDDA.Init
    gvtaCDDACC.SetToolBar = TBLtaCDDA
  End Sub
  Protected Sub GVtaCDDA_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVtaCDDA.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim TABillNo As Int32 = GVtaCDDA.DataKeys(e.CommandArgument).Values("TABillNo")  
        Dim SerialNo As Int32 = GVtaCDDA.DataKeys(e.CommandArgument).Values("SerialNo")  
        Dim RedirectUrl As String = TBLtaCDDA.EditUrl & "?TABillNo=" & TABillNo & "&SerialNo=" & SerialNo
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
      End Try
    End If
  End Sub
  Private WithEvents gvtaBillPrjAmountsCC As New gvBase
  Protected Sub GVtaBillPrjAmounts_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVtaBillPrjAmounts.Init
    gvtaBillPrjAmountsCC.DataClassName = "GtaBillPrjAmounts"
    gvtaBillPrjAmountsCC.SetGridView = GVtaBillPrjAmounts
  End Sub
  Protected Sub TBLtaBillPrjAmounts_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLtaBillPrjAmounts.Init
    gvtaBillPrjAmountsCC.SetToolBar = TBLtaBillPrjAmounts
  End Sub
  Protected Sub GVtaBillPrjAmounts_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVtaBillPrjAmounts.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim TABillNo As Int32 = GVtaBillPrjAmounts.DataKeys(e.CommandArgument).Values("TABillNo")  
        Dim ProjectID As String = GVtaBillPrjAmounts.DataKeys(e.CommandArgument).Values("ProjectID")  
        Dim RedirectUrl As String = TBLtaBillPrjAmounts.EditUrl & "?TABillNo=" & TABillNo & "&ProjectID=" & ProjectID
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
      End Try
    End If
    If e.CommandName.ToLower = "completewf".ToLower Then
      Try
        Dim Percentage As Decimal = CType(GVtaBillPrjAmounts.Rows(e.CommandArgument).FindControl("F_Percentage"),TextBox).Text
        Dim TABillNo As Int32 = GVtaBillPrjAmounts.DataKeys(e.CommandArgument).Values("TABillNo")  
        Dim ProjectID As String = GVtaBillPrjAmounts.DataKeys(e.CommandArgument).Values("ProjectID")  
        SIS.TA.taBillPrjAmounts.CompleteWF(TABillNo, ProjectID, Percentage)
        GVtaBillPrjAmounts.DataBind()
      Catch ex As Exception
      End Try
    End If
  End Sub
  Protected Sub TBLtaBillPrjAmounts_AddClicked(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles TBLtaBillPrjAmounts.AddClicked
    Dim TABillNo As Int32 = CType(FVtaCH.FindControl("F_TABillNo"),TextBox).Text
    TBLtaBillPrjAmounts.AddUrl &= "?TABillNo=" & TABillNo
  End Sub
  Private WithEvents gvtaBillAmountCC As New gvBase
  Protected Sub GVtaBillAmount_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVtaBillAmount.Init
    gvtaBillAmountCC.DataClassName = "GtaBillAmount"
    gvtaBillAmountCC.SetGridView = GVtaBillAmount
  End Sub
  Protected Sub TBLtaBillAmount_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLtaBillAmount.Init
    gvtaBillAmountCC.SetToolBar = TBLtaBillAmount
  End Sub
  Protected Sub GVtaBillAmount_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVtaBillAmount.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim TABillNo As Int32 = GVtaBillAmount.DataKeys(e.CommandArgument).Values("TABillNo")  
        Dim ComponentID As Int32 = GVtaBillAmount.DataKeys(e.CommandArgument).Values("ComponentID")  
        Dim CurrencyID As String = GVtaBillAmount.DataKeys(e.CommandArgument).Values("CurrencyID")  
        Dim CostCenterID As String = GVtaBillAmount.DataKeys(e.CommandArgument).Values("CostCenterID")  
        Dim RedirectUrl As String = TBLtaBillAmount.EditUrl & "?TABillNo=" & TABillNo & "&ComponentID=" & ComponentID & "&CurrencyID=" & CurrencyID & "&CostCenterID=" & CostCenterID
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
      End Try
    End If
  End Sub
  Private WithEvents gvtaCDAccountsCC As New gvBase
  Protected Sub GVtaCDAccounts_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVtaCDAccounts.Init
    gvtaCDAccountsCC.DataClassName = "GtaCDAccounts"
    gvtaCDAccountsCC.SetGridView = GVtaCDAccounts
  End Sub
  Protected Sub TBLtaCDAccounts_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLtaCDAccounts.Init
    gvtaCDAccountsCC.SetToolBar = TBLtaCDAccounts
  End Sub
  Protected Sub GVtaCDAccounts_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVtaCDAccounts.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim TABillNo As Int32 = GVtaCDAccounts.DataKeys(e.CommandArgument).Values("TABillNo")
        Dim SerialNo As Int32 = GVtaCDAccounts.DataKeys(e.CommandArgument).Values("SerialNo")
        Dim RedirectUrl As String = TBLtaCDAccounts.EditUrl & "?TABillNo=" & TABillNo & "&SerialNo=" & SerialNo
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
      End Try
    End If
    If e.CommandName.ToLower = "Deletewf".ToLower Then
      Try
        Dim TABillNo As Int32 = GVtaCDAccounts.DataKeys(e.CommandArgument).Values("TABillNo")
        Dim SerialNo As Int32 = GVtaCDAccounts.DataKeys(e.CommandArgument).Values("SerialNo")
        SIS.TA.taCDAccounts.DeleteWF(TABillNo, SerialNo)
        GVtaCDAccounts.DataBind()
        GVtaBillAmount.DataBind()
        GVtaBillPrjAmounts.DataBind()
      Catch ex As Exception
      End Try
    End If
  End Sub
  Protected Sub TBLtaCDAccounts_AddClicked(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles TBLtaCDAccounts.AddClicked
    Dim TABillNo As Int32 = CType(FVtaCH.FindControl("F_TABillNo"), TextBox).Text
    TBLtaCDAccounts.AddUrl &= "?TABillNo=" & TABillNo
  End Sub
  <System.Web.Services.WebMethod()>
  <System.Web.Script.Services.ScriptMethod()>
  Public Shared Function ProjectIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.QCM.qcmProjects.SelectqcmProjectsAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_TA_Bills_ProjectID(ByVal value As String) As String
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

  Private Sub FVtaCH_ItemCommand(sender As Object, e As FormViewCommandEventArgs) Handles FVtaCH.ItemCommand
    If e.CommandName.ToUpper = "CMDAPPLY" Then
      Dim ConversionRate As Decimal = CType(FVtaCH.FindControl("F_ConversionFactorINR"), TextBox).Text
      Dim TABillNo As Integer = CType(FVtaCH.FindControl("F_TABillNo"), TextBox).Text
      Dim sBill As SIS.TA.taBH = SIS.TA.taBH.taBHGetByID(TABillNo)
      sBill.ConversionFactorINR = ConversionRate
      SIS.TA.taBH.UpdateData(sBill)
      Dim sTmps As List(Of SIS.TA.taBillDetails) = SIS.TA.taBillDetails.UZ_taBillDetailsSelectList(0, 999, "", False, "", TABillNo)
      For Each sTmp As SIS.TA.taBillDetails In sTmps
        If sTmp.CurrencyID <> "INR" Then
          sTmp.ConversionFactorINR = ConversionRate
          SIS.TA.taBillDetails.UpdateData(sTmp)
        End If
      Next
      SIS.TA.taBH.ValidateTABill(TABillNo)
      FVtaCH.DataBind()
    End If
  End Sub
End Class
