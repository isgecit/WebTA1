Partial Class EF_taBH
  Inherits SIS.SYS.UpdateBase
  Public Property SiteEmployee As Boolean
    Get
      If ViewState("SiteEmployee") IsNot Nothing Then
        Return Convert.ToBoolean(ViewState("SiteEmployee"))
      End If
      Return False
    End Get
    Set(value As Boolean)
      ViewState.Add("SiteEmployee", value)
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
  Public Property TravelTypeID() As String
    Get
      If ViewState("TravelTypeID") IsNot Nothing Then
        Return CType(ViewState("TravelTypeID"), String)
      End If
      Return "1"
    End Get
    Set(ByVal value As String)
      ViewState.Add("TravelTypeID", value)
    End Set
  End Property
  Protected Sub ODStaBH_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODStaBH.Selected
    Dim tmp As SIS.TA.taBH = CType(e.ReturnValue, SIS.TA.taBH)
    Editable = tmp.Editable
    Deleteable = tmp.Deleteable
    PrimaryKey = tmp.PrimaryKey
    TravelTypeID = tmp.TravelTypeID
    SiteEmployee = IIf(tmp.FK_TA_Bills_EmployeeID.C_OfficeID = "6", True, False)
  End Sub
  Protected Sub FVtaBH_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVtaBH.Init
    DataClassName = "EtaBH"
    SetFormView = FVtaBH
  End Sub
  Protected Sub TBLtaBH_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLtaBH.Init
    SetToolBar = TBLtaBH
  End Sub
  Protected Sub FVtaBH_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVtaBH.PreRender
    TBLtaBH.EnableSave = Editable
    TBLtaBH.EnableDelete = Deleteable
    TBLtaBH.PrintUrl &= Request.QueryString("TABillNo") & "|"
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/TA_Main/App_Edit") & "/EF_taBH.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scripttaBH") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scripttaBH", mStr)
    End If
    Dim tmp As HtmlControl = Nothing
    Try
      If TravelTypeID = TATravelTypeValues.Domestic Then
        CType(FVtaBH.FindControl("opt1"), HtmlTableRow).Style("display") = ""
        CType(FVtaBH.FindControl("opt2"), HtmlTableRow).Style("display") = ""
        CType(FVtaBH.FindControl("opt3"), HtmlTableRow).Style("display") = "none"
        CType(FVtaBH.FindControl("opt4"), HtmlTableRow).Style("display") = "none"
        CType(FVtaBH.FindControl("opt5"), HtmlTableRow).Style("display") = "none"
      Else
        CType(FVtaBH.FindControl("opt1"), HtmlTableRow).Style("display") = "none"
        CType(FVtaBH.FindControl("opt2"), HtmlTableRow).Style("display") = "none"
        CType(FVtaBH.FindControl("opt3"), HtmlTableRow).Style("display") = ""
        CType(FVtaBH.FindControl("opt4"), HtmlTableRow).Style("display") = ""
        CType(FVtaBH.FindControl("opt5"), HtmlTableRow).Style("display") = ""
      End If
    Catch ex As Exception

    End Try
    Select Case TravelTypeID
      Case TATravelTypeValues.ForeignSiteVisit, TATravelTypeValues.ForeignTravel
        tmp = FVtaBH.FindControl("FS_Mileage")
        tmp.Style.Add("display", "none")
        tmp = FVtaBH.FindControl("FS_Driver")
        tmp.Style.Add("display", "none")
    End Select
    Try
      'Site Employee
      CType(FVtaBH.FindControl("R_SiteName"), HtmlTableRow).Visible = SiteEmployee
    Catch ex As Exception

    End Try
  End Sub
  Partial Class gvBase
    Inherits SIS.SYS.GridBase
  End Class
  Private WithEvents gvtaBDFareCC As New gvBase
  Protected Sub GVtaBDFare_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVtaBDFare.Init
    gvtaBDFareCC.DataClassName = "GtaBDFare"
    gvtaBDFareCC.SetGridView = GVtaBDFare
  End Sub
  Protected Sub TBLtaBDFare_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLtaBDFare.Init
    gvtaBDFareCC.SetToolBar = TBLtaBDFare
  End Sub
  Protected Sub GVtaBDFare_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVtaBDFare.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim TABillNo As Int32 = GVtaBDFare.DataKeys(e.CommandArgument).Values("TABillNo")  
        Dim SerialNo As Int32 = GVtaBDFare.DataKeys(e.CommandArgument).Values("SerialNo")  
        Dim RedirectUrl As String = TBLtaBDFare.EditUrl & "?TABillNo=" & TABillNo & "&SerialNo=" & SerialNo
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
      End Try
    End If
    If e.CommandName.ToLower = "Deletewf".ToLower Then
      Try
        Dim TABillNo As Int32 = GVtaBDFare.DataKeys(e.CommandArgument).Values("TABillNo")  
        Dim SerialNo As Int32 = GVtaBDFare.DataKeys(e.CommandArgument).Values("SerialNo")  
        SIS.TA.taBDFare.DeleteWF(TABillNo, SerialNo)
        GVtaBDFare.DataBind()
        GVtaBillAmount.DataBind()
        GVtaBillPrjAmounts.DataBind()
      Catch ex As Exception
      End Try
    End If
  End Sub
  Protected Sub TBLtaBDFare_AddClicked(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles TBLtaBDFare.AddClicked
    Dim TABillNo As Int32 = CType(FVtaBH.FindControl("F_TABillNo"),TextBox).Text
    TBLtaBDFare.AddUrl &= "?TABillNo=" & TABillNo
  End Sub
  Private WithEvents gvtaBDLCCC As New gvBase
  Protected Sub GVtaBDLC_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVtaBDLC.Init
    gvtaBDLCCC.DataClassName = "GtaBDLC"
    gvtaBDLCCC.SetGridView = GVtaBDLC
  End Sub
  Protected Sub TBLtaBDLC_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLtaBDLC.Init
    gvtaBDLCCC.SetToolBar = TBLtaBDLC
  End Sub
  Protected Sub GVtaBDLC_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVtaBDLC.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim TABillNo As Int32 = GVtaBDLC.DataKeys(e.CommandArgument).Values("TABillNo")  
        Dim SerialNo As Int32 = GVtaBDLC.DataKeys(e.CommandArgument).Values("SerialNo")  
        Dim RedirectUrl As String = TBLtaBDLC.EditUrl & "?TABillNo=" & TABillNo & "&SerialNo=" & SerialNo
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
      End Try
    End If
    If e.CommandName.ToLower = "Deletewf".ToLower Then
      Try
        Dim TABillNo As Int32 = GVtaBDLC.DataKeys(e.CommandArgument).Values("TABillNo")  
        Dim SerialNo As Int32 = GVtaBDLC.DataKeys(e.CommandArgument).Values("SerialNo")  
        SIS.TA.taBDLC.DeleteWF(TABillNo, SerialNo)
        GVtaBDLC.DataBind()
        GVtaBillAmount.DataBind()
        GVtaBillPrjAmounts.DataBind()
      Catch ex As Exception
      End Try
    End If
  End Sub
  Protected Sub TBLtaBDLC_AddClicked(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles TBLtaBDLC.AddClicked
    Dim TABillNo As Int32 = CType(FVtaBH.FindControl("F_TABillNo"),TextBox).Text
    TBLtaBDLC.AddUrl &= "?TABillNo=" & TABillNo
  End Sub
  Private WithEvents gvtaBDLodgingCC As New gvBase
  Protected Sub GVtaBDLodging_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVtaBDLodging.Init
    gvtaBDLodgingCC.DataClassName = "GtaBDLodging"
    gvtaBDLodgingCC.SetGridView = GVtaBDLodging
  End Sub
  Protected Sub TBLtaBDLodging_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLtaBDLodging.Init
    gvtaBDLodgingCC.SetToolBar = TBLtaBDLodging
  End Sub
  Protected Sub GVtaBDLodging_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVtaBDLodging.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim TABillNo As Int32 = GVtaBDLodging.DataKeys(e.CommandArgument).Values("TABillNo")  
        Dim SerialNo As Int32 = GVtaBDLodging.DataKeys(e.CommandArgument).Values("SerialNo")  
        Dim RedirectUrl As String = TBLtaBDLodging.EditUrl & "?TABillNo=" & TABillNo & "&SerialNo=" & SerialNo
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
      End Try
    End If
    If e.CommandName.ToLower = "Deletewf".ToLower Then
      Try
        Dim TABillNo As Int32 = GVtaBDLodging.DataKeys(e.CommandArgument).Values("TABillNo")  
        Dim SerialNo As Int32 = GVtaBDLodging.DataKeys(e.CommandArgument).Values("SerialNo")  
        SIS.TA.taBDLodging.DeleteWF(TABillNo, SerialNo)
        GVtaBDLodging.DataBind()
        GVtaBillAmount.DataBind()
        GVtaBillPrjAmounts.DataBind()
      Catch ex As Exception
      End Try
    End If
  End Sub
  Protected Sub TBLtaBDLodging_AddClicked(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles TBLtaBDLodging.AddClicked
    Dim TABillNo As Int32 = CType(FVtaBH.FindControl("F_TABillNo"),TextBox).Text
    TBLtaBDLodging.AddUrl &= "?TABillNo=" & TABillNo
  End Sub
  Private WithEvents gvtaBDExpenseCC As New gvBase
  Protected Sub GVtaBDExpense_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVtaBDExpense.Init
    gvtaBDExpenseCC.DataClassName = "GtaBDExpense"
    gvtaBDExpenseCC.SetGridView = GVtaBDExpense
  End Sub
  Protected Sub TBLtaBDExpense_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLtaBDExpense.Init
    gvtaBDExpenseCC.SetToolBar = TBLtaBDExpense
  End Sub
  Protected Sub GVtaBDExpense_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVtaBDExpense.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim TABillNo As Int32 = GVtaBDExpense.DataKeys(e.CommandArgument).Values("TABillNo")  
        Dim SerialNo As Int32 = GVtaBDExpense.DataKeys(e.CommandArgument).Values("SerialNo")  
        Dim RedirectUrl As String = TBLtaBDExpense.EditUrl & "?TABillNo=" & TABillNo & "&SerialNo=" & SerialNo
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
      End Try
    End If
    If e.CommandName.ToLower = "Deletewf".ToLower Then
      Try
        Dim TABillNo As Int32 = GVtaBDExpense.DataKeys(e.CommandArgument).Values("TABillNo")  
        Dim SerialNo As Int32 = GVtaBDExpense.DataKeys(e.CommandArgument).Values("SerialNo")  
        SIS.TA.taBDExpense.DeleteWF(TABillNo, SerialNo)
        GVtaBDExpense.DataBind()
        GVtaBillAmount.DataBind()
        GVtaBillPrjAmounts.DataBind()
      Catch ex As Exception
      End Try
    End If
  End Sub
  Protected Sub TBLtaBDExpense_AddClicked(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles TBLtaBDExpense.AddClicked
    Dim TABillNo As Int32 = CType(FVtaBH.FindControl("F_TABillNo"),TextBox).Text
    TBLtaBDExpense.AddUrl &= "?TABillNo=" & TABillNo
  End Sub
  Private WithEvents gvtaBDFinanceCC As New gvBase
  Protected Sub GVtaBDFinance_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVtaBDFinance.Init
    gvtaBDFinanceCC.DataClassName = "GtaBDFinance"
    gvtaBDFinanceCC.SetGridView = GVtaBDFinance
  End Sub
  Protected Sub TBLtaBDFinance_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLtaBDFinance.Init
    gvtaBDFinanceCC.SetToolBar = TBLtaBDFinance
  End Sub
  Protected Sub GVtaBDFinance_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVtaBDFinance.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim TABillNo As Int32 = GVtaBDFinance.DataKeys(e.CommandArgument).Values("TABillNo")  
        Dim SerialNo As Int32 = GVtaBDFinance.DataKeys(e.CommandArgument).Values("SerialNo")  
        Dim RedirectUrl As String = TBLtaBDFinance.EditUrl & "?TABillNo=" & TABillNo & "&SerialNo=" & SerialNo
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
      End Try
    End If
    If e.CommandName.ToLower = "Deletewf".ToLower Then
      Try
        Dim TABillNo As Int32 = GVtaBDFinance.DataKeys(e.CommandArgument).Values("TABillNo")  
        Dim SerialNo As Int32 = GVtaBDFinance.DataKeys(e.CommandArgument).Values("SerialNo")  
        SIS.TA.taBDFinance.DeleteWF(TABillNo, SerialNo)
        GVtaBDFinance.DataBind()
        GVtaBillAmount.DataBind()
        GVtaBillPrjAmounts.DataBind()
      Catch ex As Exception
      End Try
    End If
  End Sub
  Protected Sub TBLtaBDFinance_AddClicked(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles TBLtaBDFinance.AddClicked
    Dim TABillNo As Int32 = CType(FVtaBH.FindControl("F_TABillNo"),TextBox).Text
    TBLtaBDFinance.AddUrl &= "?TABillNo=" & TABillNo
  End Sub
  Private WithEvents gvtaBDMileageCC As New gvBase
  Protected Sub GVtaBDMileage_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVtaBDMileage.Init
    gvtaBDMileageCC.DataClassName = "GtaBDMileage"
    gvtaBDMileageCC.SetGridView = GVtaBDMileage
  End Sub
  Protected Sub TBLtaBDMileage_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLtaBDMileage.Init
    gvtaBDMileageCC.SetToolBar = TBLtaBDMileage
  End Sub
  Protected Sub GVtaBDMileage_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVtaBDMileage.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim TABillNo As Int32 = GVtaBDMileage.DataKeys(e.CommandArgument).Values("TABillNo")  
        Dim SerialNo As Int32 = GVtaBDMileage.DataKeys(e.CommandArgument).Values("SerialNo")  
        Dim RedirectUrl As String = TBLtaBDMileage.EditUrl & "?TABillNo=" & TABillNo & "&SerialNo=" & SerialNo
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
      End Try
    End If
    If e.CommandName.ToLower = "Deletewf".ToLower Then
      Try
        Dim TABillNo As Int32 = GVtaBDMileage.DataKeys(e.CommandArgument).Values("TABillNo")  
        Dim SerialNo As Int32 = GVtaBDMileage.DataKeys(e.CommandArgument).Values("SerialNo")  
        SIS.TA.taBDMileage.DeleteWF(TABillNo, SerialNo)
        GVtaBDMileage.DataBind()
        GVtaBillAmount.DataBind()
        GVtaBillPrjAmounts.DataBind()
      Catch ex As Exception
      End Try
    End If
  End Sub
  Protected Sub TBLtaBDMileage_AddClicked(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles TBLtaBDMileage.AddClicked
    Dim TABillNo As Int32 = CType(FVtaBH.FindControl("F_TABillNo"),TextBox).Text
    TBLtaBDMileage.AddUrl &= "?TABillNo=" & TABillNo
  End Sub
  Private WithEvents gvtaBDDriverCC As New gvBase
  Protected Sub GVtaBDDriver_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVtaBDDriver.Init
    gvtaBDDriverCC.DataClassName = "GtaBDDriver"
    gvtaBDDriverCC.SetGridView = GVtaBDDriver
  End Sub
  Protected Sub TBLtaBDDriver_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLtaBDDriver.Init
    gvtaBDDriverCC.SetToolBar = TBLtaBDDriver
  End Sub
  Protected Sub GVtaBDDriver_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVtaBDDriver.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim TABillNo As Int32 = GVtaBDDriver.DataKeys(e.CommandArgument).Values("TABillNo")  
        Dim SerialNo As Int32 = GVtaBDDriver.DataKeys(e.CommandArgument).Values("SerialNo")  
        Dim RedirectUrl As String = TBLtaBDDriver.EditUrl & "?TABillNo=" & TABillNo & "&SerialNo=" & SerialNo
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
      End Try
    End If
    If e.CommandName.ToLower = "Deletewf".ToLower Then
      Try
        Dim TABillNo As Int32 = GVtaBDDriver.DataKeys(e.CommandArgument).Values("TABillNo")  
        Dim SerialNo As Int32 = GVtaBDDriver.DataKeys(e.CommandArgument).Values("SerialNo")  
        SIS.TA.taBDDriver.DeleteWF(TABillNo, SerialNo)
        GVtaBDDriver.DataBind()
        GVtaBillAmount.DataBind()
        GVtaBillPrjAmounts.DataBind()
      Catch ex As Exception
      End Try
    End If
  End Sub
  Protected Sub TBLtaBDDriver_AddClicked(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles TBLtaBDDriver.AddClicked
    Dim TABillNo As Int32 = CType(FVtaBH.FindControl("F_TABillNo"),TextBox).Text
    TBLtaBDDriver.AddUrl &= "?TABillNo=" & TABillNo
  End Sub
  Private WithEvents gvtaBDDACC As New gvBase
  Protected Sub GVtaBDDA_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVtaBDDA.Init
    gvtaBDDACC.DataClassName = "GtaBDDA"
    gvtaBDDACC.SetGridView = GVtaBDDA
  End Sub
  Protected Sub TBLtaBDDA_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLtaBDDA.Init
    gvtaBDDACC.SetToolBar = TBLtaBDDA
  End Sub
  Protected Sub GVtaBDDA_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVtaBDDA.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim TABillNo As Int32 = GVtaBDDA.DataKeys(e.CommandArgument).Values("TABillNo")  
        Dim SerialNo As Int32 = GVtaBDDA.DataKeys(e.CommandArgument).Values("SerialNo")  
        Dim RedirectUrl As String = TBLtaBDDA.EditUrl & "?TABillNo=" & TABillNo & "&SerialNo=" & SerialNo
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
      End Try
    End If
    If e.CommandName.ToLower = "Deletewf".ToLower Then
      Try
        Dim TABillNo As Int32 = GVtaBDDA.DataKeys(e.CommandArgument).Values("TABillNo")  
        Dim SerialNo As Int32 = GVtaBDDA.DataKeys(e.CommandArgument).Values("SerialNo")  
        SIS.TA.taBDDA.DeleteWF(TABillNo, SerialNo)
        GVtaBDDA.DataBind()
        GVtaBillAmount.DataBind()
        GVtaBillPrjAmounts.DataBind()
      Catch ex As Exception
      End Try
    End If
  End Sub
  Protected Sub TBLtaBDDA_AddClicked(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles TBLtaBDDA.AddClicked
    Dim TABillNo As Int32 = CType(FVtaBH.FindControl("F_TABillNo"),TextBox).Text
    TBLtaBDDA.AddUrl &= "?TABillNo=" & TABillNo
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
        Dim Percentage As Decimal = CType(GVtaBillPrjAmounts.Rows(e.CommandArgument).FindControl("F_Percentage"), TextBox).Text
        Dim TABillNo As Int32 = GVtaBillPrjAmounts.DataKeys(e.CommandArgument).Values("TABillNo")
        Dim ProjectID As String = GVtaBillPrjAmounts.DataKeys(e.CommandArgument).Values("ProjectID")
        SIS.TA.taBillPrjAmounts.CompleteWF(TABillNo, ProjectID, Percentage)
        GVtaBillPrjAmounts.DataBind()
      Catch ex As Exception
      End Try
    End If
  End Sub
  Protected Sub TBLtaBillPrjAmounts_AddClicked(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles TBLtaBillPrjAmounts.AddClicked
    Dim TABillNo As Int32 = CType(FVtaBH.FindControl("F_TABillNo"),TextBox).Text
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
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function CityOfOriginCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.TA.taCities.SelecttaCitiesAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function DestinationCityCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.TA.taCities.SelecttaCitiesAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
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
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_TA_Bills_DestinationCity(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
    Dim DestinationCity As String = CType(aVal(1),String)
    Dim oVar As SIS.TA.taCities = SIS.TA.taCities.taCitiesGetByID(DestinationCity)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found." 
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_TA_Bills_CityOfOrigin(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
    Dim CityOfOrigin As String = CType(aVal(1),String)
    Dim oVar As SIS.TA.taCities = SIS.TA.taCities.taCitiesGetByID(CityOfOrigin)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found." 
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function

End Class
