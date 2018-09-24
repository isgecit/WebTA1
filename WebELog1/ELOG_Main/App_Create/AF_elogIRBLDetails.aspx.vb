Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Imports System.IO
Imports OfficeOpenXml
Imports System.Web.Script.Serialization
Partial Class AF_elogIRBLDetails
  Inherits SIS.SYS.InsertBase
  Protected Sub FVelogIRBLDetails_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVelogIRBLDetails.Init
    DataClassName = "AelogIRBLDetails"
    SetFormView = FVelogIRBLDetails
  End Sub
  Protected Sub TBLelogIRBLDetails_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLelogIRBLDetails.Init
    SetToolBar = TBLelogIRBLDetails
  End Sub
  Protected Sub FVelogIRBLDetails_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVelogIRBLDetails.DataBound
    SIS.ELOG.elogIRBLDetails.SetDefaultValues(sender, e)
  End Sub
  Protected Sub FVelogIRBLDetails_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVelogIRBLDetails.PreRender
    Dim oF_IRNo_Display As Label = FVelogIRBLDetails.FindControl("F_IRNo_Display")
    oF_IRNo_Display.Text = String.Empty
    If Not Session("F_IRNo_Display") Is Nothing Then
      If Session("F_IRNo_Display") <> String.Empty Then
        oF_IRNo_Display.Text = Session("F_IRNo_Display")
      End If
    End If
    Dim oF_IRNo As TextBox = FVelogIRBLDetails.FindControl("F_IRNo")
    oF_IRNo.Enabled = True
    oF_IRNo.Text = String.Empty
    If Not Session("F_IRNo") Is Nothing Then
      If Session("F_IRNo") <> String.Empty Then
        oF_IRNo.Text = Session("F_IRNo")
      End If
    End If
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/ELOG_Main/App_Create") & "/AF_elogIRBLDetails.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptelogIRBLDetails") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptelogIRBLDetails", mStr)
    End If
    If Request.QueryString("IRNo") IsNot Nothing Then
      CType(FVelogIRBLDetails.FindControl("F_IRNo"), TextBox).Text = Request.QueryString("IRNo")
      CType(FVelogIRBLDetails.FindControl("F_IRNo"), TextBox).Enabled = False
    End If
    If Request.QueryString("SerialNo") IsNot Nothing Then
      If Not Page.IsCallback And Not Page.IsPostBack Then

        Dim IRNo As String = Request.QueryString("IRNo")
        Dim oIR As SIS.ELOG.elogIRBL = SIS.ELOG.elogIRBL.elogIRBLGetByID(IRNo)
        Dim tmp As New lgIRBL
        With tmp
          .BLID = oIR.BLID
          .ShipmentModeID = oIR.ShipmentModeID
          .LocationCountryID = oIR.LocationCountryID
          .CargoTypeID = oIR.CargoTypeID
        End With
        IRBL = tmp
        Dim SerialNo As String = Request.QueryString("SerialNo")
        Dim oIRBLDetail As SIS.ELOG.elogIRBLDetails = SIS.ELOG.elogIRBLDetails.elogIRBLDetailsGetByID(IRNo, SerialNo)

        Dim StuffingType As LC_elogStuffingTypes = CType(FVelogIRBLDetails.FindControl("F_StuffingTypeID"), LC_elogStuffingTypes)
        Dim StuffingPoint As LC_elogStuffingPoints = CType(FVelogIRBLDetails.FindControl("F_StuffingpointID"), LC_elogStuffingPoints)
        Dim ICDCFS As LC_elogICDCFSs = CType(FVelogIRBLDetails.FindControl("F_ICDCFSID"), LC_elogICDCFSs)
        Dim OtherICDCFS As TextBox = CType(FVelogIRBLDetails.FindControl("F_OtherICDCFS"), TextBox)
        Dim BreakBulk As LC_elogBreakbulkTypes = CType(FVelogIRBLDetails.FindControl("F_BreakBulkID"), LC_elogBreakbulkTypes)
        Dim ChargeType As LC_elogChargeTypes = CType(FVelogIRBLDetails.FindControl("F_ChargeTypeID"), LC_elogChargeTypes)
        Dim ChargeCategory As LC_elogChargeCategories = CType(FVelogIRBLDetails.FindControl("F_ChargeCategoryID"), LC_elogChargeCategories)
        Dim ChargeCode As LC_elogChargeCodes = CType(FVelogIRBLDetails.FindControl("F_ChargeCodeID"), LC_elogChargeCodes)
        Dim x As FormViewCommandEventArgs = New FormViewCommandEventArgs(Nothing, New CommandEventArgs("Next", Nothing))

        StuffingType.SelectedValue = oIRBLDetail.StuffingTypeID
        FVelogIRBLDetails_ItemCommand(Nothing, x)
        Try
          StuffingPoint.SelectedValue = oIRBLDetail.StuffingPointID
          FVelogIRBLDetails_ItemCommand(Nothing, x)
        Catch ex As Exception
        End Try
        Try
          If StuffingPoint.SelectedValue <> "" Then
            ICDCFS.Clear()
            ICDCFS.OrderBy = StuffingPoint.SelectedValue
            ICDCFS.DataBind()
          End If
          ICDCFS.SelectedValue = oIRBLDetail.ICDCFSID
          OtherICDCFS.Text = oIRBLDetail.OtherICDCFS
          FVelogIRBLDetails_ItemCommand(Nothing, x)
        Catch ex As Exception
        End Try
        Try
          BreakBulk.SelectedValue = oIRBLDetail.BreakBulkID
          FVelogIRBLDetails_ItemCommand(Nothing, x)
        Catch ex As Exception
        End Try
        Try
          ChargeType.SelectedValue = oIRBLDetail.ChargeTypeID
          FVelogIRBLDetails_ItemCommand(Nothing, x)
        Catch ex As Exception
          Dim message As String = New JavaScriptSerializer().Serialize("Type : " & ex.Message)
          Dim script As String = String.Format("alert({0});", message)
          ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", script, True)
        End Try
        Try
          With ChargeCategory
            .Clear()
            .OrderBy = IRBL.ShipmentModeID & "|" & IRBL.LocationCountryID & "|" & IRBL.CargoTypeID & "|" & StuffingType.SelectedValue & "|" & StuffingPoint.SelectedValue & "|" & BreakBulk.SelectedValue & "|" & ChargeType.SelectedValue
            .DataBind()
          End With
          ChargeCategory.SelectedValue = oIRBLDetail.ChargeCategoryID
          FVelogIRBLDetails_ItemCommand(Nothing, x)
        Catch ex As Exception
          Dim message As String = New JavaScriptSerializer().Serialize("Cate: " & ex.Message)
          Dim script As String = String.Format("alert({0});", message)
          ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", script, True)
        End Try
        Try
          With ChargeCode
            .Clear()
            .OrderBy = ChargeCategory.SelectedValue
            .DataBind()
          End With
          ChargeCode.SelectedValue = oIRBLDetail.ChargeCodeID
          FVelogIRBLDetails_ItemCommand(Nothing, x)
        Catch ex As Exception
        End Try
        Dim st As HiddenField = CType(FVelogIRBLDetails.FindControl("State"), HiddenField)
        st.Value = 7
      End If
    End If
    RenderEntry()
  End Sub
  Private Sub RenderEntry()
    Dim st As HiddenField = CType(FVelogIRBLDetails.FindControl("State"), HiddenField)
    Dim r1 As HtmlTableRow = CType(FVelogIRBLDetails.FindControl("row1"), HtmlTableRow)
    Dim r2 As HtmlTableRow = CType(FVelogIRBLDetails.FindControl("row2"), HtmlTableRow)
    Dim r3 As HtmlTableRow = CType(FVelogIRBLDetails.FindControl("row3"), HtmlTableRow)
    Dim r4 As HtmlTableRow = CType(FVelogIRBLDetails.FindControl("row4"), HtmlTableRow)
    Dim r5 As HtmlTableRow = CType(FVelogIRBLDetails.FindControl("row5"), HtmlTableRow)
    Dim r6 As HtmlTableRow = CType(FVelogIRBLDetails.FindControl("row6"), HtmlTableRow)
    Dim r7 As HtmlTableRow = CType(FVelogIRBLDetails.FindControl("row7"), HtmlTableRow)
    Dim r8 As HtmlTableRow = CType(FVelogIRBLDetails.FindControl("row8"), HtmlTableRow)
    Dim StuffingType As LC_elogStuffingTypes = CType(FVelogIRBLDetails.FindControl("F_StuffingTypeID"), LC_elogStuffingTypes)
    Dim StuffingPoint As LC_elogStuffingPoints = CType(FVelogIRBLDetails.FindControl("F_StuffingpointID"), LC_elogStuffingPoints)
    Dim ICDCFS As LC_elogICDCFSs = CType(FVelogIRBLDetails.FindControl("F_ICDCFSID"), LC_elogICDCFSs)
    Dim OtherICDCFS As TextBox = CType(FVelogIRBLDetails.FindControl("F_OtherICDCFS"), TextBox)
    Dim BreakBulk As LC_elogBreakbulkTypes = CType(FVelogIRBLDetails.FindControl("F_BreakBulkID"), LC_elogBreakbulkTypes)
    Dim ChargeType As LC_elogChargeTypes = CType(FVelogIRBLDetails.FindControl("F_ChargeTypeID"), LC_elogChargeTypes)
    Dim ChargeCategory As LC_elogChargeCategories = CType(FVelogIRBLDetails.FindControl("F_ChargeCategoryID"), LC_elogChargeCategories)
    Dim ChargeCode As LC_elogChargeCodes = CType(FVelogIRBLDetails.FindControl("F_ChargeCodeID"), LC_elogChargeCodes)
    Dim Amount As TextBox = CType(FVelogIRBLDetails.FindControl("F_Amount"), TextBox)
    Dim cmdNext As Button = CType(FVelogIRBLDetails.FindControl("cmdNext"), Button)
    Dim cmdBack As Button = CType(FVelogIRBLDetails.FindControl("cmdBack"), Button)
    TBLelogIRBLDetails.EnableSave = False

    Select Case st.Value
      Case "9" 'Non Edit
        StuffingType.Enabled = False
        StuffingPoint.Enabled = False
        ICDCFS.Enabled = False
        OtherICDCFS.Enabled = False
        BreakBulk.Enabled = False
        ChargeType.Enabled = False
        ChargeCategory.Enabled = False
        ChargeCode.Enabled = False
        Amount.Enabled = False
        r8.BgColor = ""
        cmdBack.Enabled = True
        cmdNext.Enabled = False
        TBLelogIRBLDetails.EnableSave = True
      Case "1" 'Initial
        StuffingType.Enabled = True
        StuffingPoint.Enabled = False
        ICDCFS.Enabled = False
        OtherICDCFS.Enabled = False
        BreakBulk.Enabled = False
        ChargeType.Enabled = False
        ChargeCategory.Enabled = False
        ChargeCode.Enabled = False
        Amount.Enabled = False
        r1.Disabled = False
        r1.BgColor = "yellow"
        r2.BgColor = ""
        cmdBack.Enabled = False
        cmdNext.Enabled = True
      Case "2"
        StuffingType.Enabled = False
        StuffingPoint.Enabled = True
        ICDCFS.Enabled = False
        OtherICDCFS.Enabled = False
        BreakBulk.Enabled = False
        ChargeType.Enabled = False
        ChargeCategory.Enabled = False
        ChargeCode.Enabled = False
        Amount.Enabled = False
        r1.BgColor = ""
        r2.BgColor = "yellow"
        r3.BgColor = ""
        cmdBack.Enabled = True
        cmdNext.Enabled = True
      Case "3"
        StuffingType.Enabled = False
        StuffingPoint.Enabled = False
        ICDCFS.Enabled = True
        OtherICDCFS.Enabled = True
        BreakBulk.Enabled = False
        ChargeType.Enabled = False
        ChargeCategory.Enabled = False
        ChargeCode.Enabled = False
        Amount.Enabled = False
        r2.BgColor = ""
        r3.BgColor = "yellow"
        r4.BgColor = ""
        cmdBack.Enabled = True
        cmdNext.Enabled = True
      Case "4"
        StuffingType.Enabled = False
        StuffingPoint.Enabled = False
        ICDCFS.Enabled = False
        OtherICDCFS.Enabled = False
        BreakBulk.Enabled = True
        ChargeType.Enabled = False
        ChargeCategory.Enabled = False
        ChargeCode.Enabled = False
        Amount.Enabled = False
        r3.BgColor = ""
        r4.Disabled = False
        r4.BgColor = "yellow"
        r5.BgColor = ""
        cmdBack.Enabled = True
        cmdNext.Enabled = True
      Case "5"
        StuffingType.Enabled = False
        StuffingPoint.Enabled = False
        ICDCFS.Enabled = False
        OtherICDCFS.Enabled = False
        BreakBulk.Enabled = False
        ChargeType.Enabled = True
        ChargeCategory.Enabled = False
        ChargeCode.Enabled = False
        Amount.Enabled = False
        r4.BgColor = ""
        r5.Disabled = False
        r5.BgColor = "yellow"
        r6.BgColor = ""
        cmdBack.Enabled = True
        cmdNext.Enabled = True
      Case "6"
        StuffingType.Enabled = False
        StuffingPoint.Enabled = False
        ICDCFS.Enabled = False
        OtherICDCFS.Enabled = False
        BreakBulk.Enabled = False
        ChargeType.Enabled = False
        ChargeCategory.Enabled = True
        ChargeCode.Enabled = False
        Amount.Enabled = False
        r5.BgColor = ""
        r6.BgColor = "yellow"
        r7.BgColor = ""
        cmdBack.Enabled = True
        cmdNext.Enabled = True
      Case "7"
        StuffingType.Enabled = False
        StuffingPoint.Enabled = False
        ICDCFS.Enabled = False
        OtherICDCFS.Enabled = False
        BreakBulk.Enabled = False
        ChargeType.Enabled = False
        ChargeCategory.Enabled = False
        ChargeCode.Enabled = True
        Amount.Enabled = False
        r6.BgColor = ""
        r7.BgColor = "yellow"
        r8.BgColor = ""
        cmdBack.Enabled = True
        cmdNext.Enabled = True
      Case "8"
        StuffingType.Enabled = False
        StuffingPoint.Enabled = False
        ICDCFS.Enabled = False
        OtherICDCFS.Enabled = False
        BreakBulk.Enabled = False
        ChargeType.Enabled = False
        ChargeCategory.Enabled = False
        ChargeCode.Enabled = False
        Amount.Enabled = True
        r7.BgColor = ""
        r8.BgColor = "yellow"
        cmdBack.Enabled = True
        cmdNext.Enabled = True
        Try
          Dim IRNo As String = CType(FVelogIRBLDetails.FindControl("F_IRNo"), TextBox).Text
          Dim tm As SIS.ELOG.elogIRBL = SIS.ELOG.elogIRBL.elogIRBLGetByID(IRNo)
          Dim tAmt As Decimal = tm.SupplierBillAmount
          Dim dAmt As Decimal = SIS.ELOG.elogIRBLDetails.getUsedAmount(IRNo)
          Amount.Text = tAmt - dAmt
        Catch ex As Exception
        End Try
    End Select
  End Sub

  Private Sub FVelogIRBLDetails_ItemCommand(sender As Object, e As FormViewCommandEventArgs) Handles FVelogIRBLDetails.ItemCommand
    Dim sr As HiddenField = CType(FVelogIRBLDetails.FindControl("StartRow"), HiddenField)
    Dim st As HiddenField = CType(FVelogIRBLDetails.FindControl("State"), HiddenField)
    If e.CommandName = "lgBack" Then
      If sr.Value = "1" Then
        If st.Value = "5" Then
          st.Value = Convert.ToInt32(st.Value) - 2
        Else
          st.Value = Convert.ToInt32(st.Value) - 1
        End If
      Else
        st.Value = Convert.ToInt32(st.Value) - 1
      End If
      If Convert.ToInt32(st.Value) < SR.value Then
        st.Value = SR.value
      End If
    End If
    If e.CommandName = "lgNext" Then
      Dim Err As Boolean = False
      Dim msg As String = ""
      Select Case st.Value
        Case "1"
          Dim StuffingType As LC_elogStuffingTypes = CType(FVelogIRBLDetails.FindControl("F_StuffingTypeID"), LC_elogStuffingTypes)
          If StuffingType.SelectedValue <> "" Then
            st.Value = Convert.ToInt32(st.Value) + 1
          Else
            Err = True
            msg = "Please Select Stuffing Type."
          End If
        Case "2"
          Dim StuffingPoint As LC_elogStuffingPoints = CType(FVelogIRBLDetails.FindControl("F_StuffingpointID"), LC_elogStuffingPoints)
          If StuffingPoint.SelectedValue <> "" Then
            st.Value = Convert.ToInt32(st.Value) + 1
          Else
            Err = True
            msg = "Please Select Stuffing Point."
          End If
        Case "3"
          Dim ICDCFS As LC_elogICDCFSs = CType(FVelogIRBLDetails.FindControl("F_ICDCFSID"), LC_elogICDCFSs)
          Dim OtherICDCFS As TextBox = CType(FVelogIRBLDetails.FindControl("F_OtherICDCFS"), TextBox)
          If ICDCFS.SelectedValue = "" And OtherICDCFS.Text = "" Then
            Err = True
            msg = "Please Select ICD / CFS or Enter ICD/CFS Name"
          Else
            st.Value = Convert.ToInt32(st.Value) + 2
          End If
        Case "4"
          Dim BreakBulk As LC_elogBreakbulkTypes = CType(FVelogIRBLDetails.FindControl("F_BreakBulkID"), LC_elogBreakbulkTypes)
          If BreakBulk.SelectedValue <> "" Then
            st.Value = Convert.ToInt32(st.Value) + 1
          Else
            Err = True
            msg = "Please select Breakbulk Type."
          End If
        Case "5"
          Dim ChargeType As LC_elogChargeTypes = CType(FVelogIRBLDetails.FindControl("F_ChargeTypeID"), LC_elogChargeTypes)
          If ChargeType.SelectedValue <> "" Then
            st.Value = Convert.ToInt32(st.Value) + 1
          Else
            Err = True
            msg = "Please select Charge Type."
          End If
        Case "6"
          Dim ChargeCategory As LC_elogChargeCategories = CType(FVelogIRBLDetails.FindControl("F_ChargeCategoryID"), LC_elogChargeCategories)
          If ChargeCategory.SelectedValue <> "" Then
            st.Value = Convert.ToInt32(st.Value) + 1
          Else
            Err = True
            msg = "Please select Charge Category."
          End If
        Case "7"
          Dim ChargeCode As LC_elogChargeCodes = CType(FVelogIRBLDetails.FindControl("F_ChargeCodeID"), LC_elogChargeCodes)
          If ChargeCode.SelectedValue <> "" Then
            Dim BLID As String = IRBL.BLID
            Dim ChargeCodeID As Integer = ChargeCode.SelectedValue.Split("|".ToCharArray)(1)
            Dim ChargeCategory As LC_elogChargeCategories = CType(FVelogIRBLDetails.FindControl("F_ChargeCategoryID"), LC_elogChargeCategories)
            Dim oChargeCode As SIS.ELOG.elogChargeCodes = SIS.ELOG.elogChargeCodes.elogChargeCodesGetByID(ChargeCategory.SelectedValue, ChargeCodeID)
            If oChargeCode.Description <> "Gst Charges" Then
              Dim Used As Integer = SIS.ELOG.elogIRBLDetails.getUsedChargeCode(BLID, ChargeCodeID)
              If Used > 0 Then
                Err = True
                msg = "Charge Code is already used in BL."
              Else
                st.Value = Convert.ToInt32(st.Value) + 1
              End If
            Else
              st.Value = Convert.ToInt32(st.Value) + 1
            End If
          Else
            Err = True
            msg = "Please select Charge Code."
          End If
        Case "8"
          Dim Amount As TextBox = CType(FVelogIRBLDetails.FindControl("F_Amount"), TextBox)
          If Amount.Text <> "" Then
            Try
              Dim IRNo As String = CType(FVelogIRBLDetails.FindControl("F_IRNo"), TextBox).Text
              Dim tm As SIS.ELOG.elogIRBL = SIS.ELOG.elogIRBL.elogIRBLGetByID(IRNo)
              Dim tAmt As Decimal = tm.SupplierBillAmount
              Dim dAmt As Decimal = SIS.ELOG.elogIRBLDetails.getUsedAmount(IRNo)
              If dAmt + Convert.ToDecimal(Amount.Text) > tAmt Then
                Err = True
                msg = "Amount ig greater than balance =" & tAmt - dAmt
              Else
                st.Value = Convert.ToInt32(st.Value) + 1
              End If
            Catch ex As Exception
            End Try
          Else
            Err = True
            msg = "Please Enter Amount."
          End If
      End Select
      If Err Then
        Dim message As String = New JavaScriptSerializer().Serialize(msg)
        Dim script As String = String.Format("alert({0});", message)
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", script, True)
      End If
    End If
  End Sub
  Public Property IRBL As lgIRBL
    Get
      If ViewState("IRBL") IsNot Nothing Then
        Return CType(ViewState("IRBL"), lgIRBL)
      End If
      Return Nothing
    End Get
    Set(value As lgIRBL)
      ViewState.Add("IRBL", value)
    End Set
  End Property
  Private Sub AF_elogIRBLDetails_Load(sender As Object, e As EventArgs) Handles Me.Load
    Dim st As HiddenField = CType(FVelogIRBLDetails.FindControl("State"), HiddenField)
    Dim sr As HiddenField = CType(FVelogIRBLDetails.FindControl("StartRow"), HiddenField)
    If Not Page.IsPostBack And Not Page.IsCallback Then
      Dim IRNo As String = Request.QueryString("IRNo")
      Dim oIR As SIS.ELOG.elogIRBL = SIS.ELOG.elogIRBL.elogIRBLGetByID(IRNo)
      Dim tmp As New lgIRBL
      With tmp
        .BLID = oIR.BLID
        .ShipmentModeID = oIR.ShipmentModeID
        .LocationCountryID = oIR.LocationCountryID
        .CargoTypeID = oIR.CargoTypeID
      End With
      IRBL = tmp
      If oIR.ShipmentModeID = "1" And oIR.CargoTypeID = "2" Then
        st.Value = "4"
        sr.Value = "4"
      ElseIf oIR.ShipmentModeID = "1" And oIR.LocationCountryID = 2 Then
        st.Value = "5"
        sr.Value = "5"
      ElseIf oIR.ShipmentModeID = "2" Then
        st.Value = "5"
        sr.Value = "5"
      End If

    End If
    If st.Value = "2" Then
      Dim StuffingPoint As LC_elogStuffingPoints = CType(FVelogIRBLDetails.FindControl("F_StuffingpointID"), LC_elogStuffingPoints)
      Dim ICDCFS As LC_elogICDCFSs = CType(FVelogIRBLDetails.FindControl("F_ICDCFSID"), LC_elogICDCFSs)
      If StuffingPoint.SelectedValue <> "" Then
        ICDCFS.Clear()
        ICDCFS.OrderBy = StuffingPoint.SelectedValue
        ICDCFS.DataBind()
      End If
    End If
    If st.Value = "5" Then
      Dim StuffingType As LC_elogStuffingTypes = CType(FVelogIRBLDetails.FindControl("F_StuffingTypeID"), LC_elogStuffingTypes)
      Dim StuffingPoint As LC_elogStuffingPoints = CType(FVelogIRBLDetails.FindControl("F_StuffingpointID"), LC_elogStuffingPoints)
      Dim BreakBulk As LC_elogBreakbulkTypes = CType(FVelogIRBLDetails.FindControl("F_BreakBulkID"), LC_elogBreakbulkTypes)
      Dim ChargeType As LC_elogChargeTypes = CType(FVelogIRBLDetails.FindControl("F_ChargeTypeID"), LC_elogChargeTypes)
      Dim ChargeCategory As LC_elogChargeCategories = CType(FVelogIRBLDetails.FindControl("F_ChargeCategoryID"), LC_elogChargeCategories)
      If ChargeType.SelectedValue <> "" Then
        With ChargeCategory
          .Clear()
          .OrderBy = IRBL.ShipmentModeID & "|" & IRBL.LocationCountryID & "|" & IRBL.CargoTypeID & "|" & StuffingType.SelectedValue & "|" & StuffingPoint.SelectedValue & "|" & BreakBulk.SelectedValue & "|" & ChargeType.SelectedValue
          .DataBind()
        End With
      End If
    End If
    If st.Value = "6" Then
      Dim ChargeCategory As LC_elogChargeCategories = CType(FVelogIRBLDetails.FindControl("F_ChargeCategoryID"), LC_elogChargeCategories)
      Dim ChargeCode As LC_elogChargeCodes = CType(FVelogIRBLDetails.FindControl("F_ChargeCodeID"), LC_elogChargeCodes)
      If ChargeCategory.SelectedValue <> "" Then
        With ChargeCode
          .Clear()
          .OrderBy = ChargeCategory.SelectedValue
          .DataBind()
        End With
      End If
    End If

  End Sub
  <Serializable()>
  Public Class lgIRBL
    Public Property BLID As String = ""
    Public Property ShipmentModeID As String = ""
    Public Property LocationCountryID As String = ""
    Public Property CargoTypeID As String = ""
    Public Sub New()
      'Dummy
    End Sub
  End Class
End Class
