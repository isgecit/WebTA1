Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Imports System.IO
Imports OfficeOpenXml
Imports System.Web.Script.Serialization

Partial Class AF_elogIRBL
  Inherits SIS.SYS.InsertBase
  Protected Sub FVelogIRBL_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVelogIRBL.Init
    DataClassName = "AelogIRBL"
    SetFormView = FVelogIRBL
  End Sub
  Protected Sub TBLelogIRBL_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLelogIRBL.Init
    SetToolBar = TBLelogIRBL
  End Sub
  Protected Sub ODSelogIRBL_Inserted(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODSelogIRBL.Inserted
    If e.Exception Is Nothing Then
      Dim oDC As SIS.ELOG.elogIRBL = CType(e.ReturnValue, SIS.ELOG.elogIRBL)
      Dim tmpURL As String = "?tmp=1"
      tmpURL &= "&IRNo=" & oDC.IRNo
      TBLelogIRBL.AfterInsertURL &= tmpURL
    End If
  End Sub
  Protected Sub FVelogIRBL_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVelogIRBL.DataBound
    SIS.ELOG.elogIRBL.SetDefaultValues(sender, e)
  End Sub
  Protected Sub FVelogIRBL_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVelogIRBL.PreRender
    'Dim oF_BLID_Display As Label = FVelogIRBL.FindControl("F_BLID_Display")
    'oF_BLID_Display.Text = String.Empty
    'If Not Session("F_BLID_Display") Is Nothing Then
    '  If Session("F_BLID_Display") <> String.Empty Then
    '    oF_BLID_Display.Text = Session("F_BLID_Display")
    '  End If
    'End If
    'Dim oF_BLID As TextBox = FVelogIRBL.FindControl("F_BLID")
    'oF_BLID.Enabled = True
    'oF_BLID.Text = String.Empty
    'If Not Session("F_BLID") Is Nothing Then
    '  If Session("F_BLID") <> String.Empty Then
    '    oF_BLID.Text = Session("F_BLID")
    '  End If
    'End If
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/ELOG_Main/App_Create") & "/AF_elogIRBL.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptelogIRBL") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptelogIRBL", mStr)
    End If
    If Request.QueryString("IRNo") IsNot Nothing Then
      CType(FVelogIRBL.FindControl("F_IRNo"), TextBox).Text = Request.QueryString("IRNo")
      CType(FVelogIRBL.FindControl("F_IRNo"), TextBox).Enabled = False
    End If
    RenderEntry(sta, act)
  End Sub
  Dim act As String = ""
  Dim sta As String = ""
  Private Sub RenderEntry(Optional ByVal State As String = "", Optional ByVal action As String = "")
    Dim st As HiddenField = CType(FVelogIRBL.FindControl("State"), HiddenField)
    Dim r1 As HtmlTableRow = CType(FVelogIRBL.FindControl("row1"), HtmlTableRow)
    Dim r2 As HtmlTableRow = CType(FVelogIRBL.FindControl("row2"), HtmlTableRow)
    Dim r3 As HtmlTableRow = CType(FVelogIRBL.FindControl("row3"), HtmlTableRow)
    Dim r4 As HtmlTableRow = CType(FVelogIRBL.FindControl("row4"), HtmlTableRow)
    Dim r5 As HtmlTableRow = CType(FVelogIRBL.FindControl("row5"), HtmlTableRow)
    Dim r6 As HtmlTableRow = CType(FVelogIRBL.FindControl("row6"), HtmlTableRow)
    Dim ShipmentMode As LC_elogShipmentModes = CType(FVelogIRBL.FindControl("F_ShipmentModeID"), LC_elogShipmentModes)
    Dim Carrier As LC_elogCarriers = CType(FVelogIRBL.FindControl("F_CarrierID"), LC_elogCarriers)
    Dim OtherCarrier As TextBox = CType(FVelogIRBL.FindControl("F_OtherCarrier"), TextBox)
    Dim LocationCountry As LC_elogLocationCountries = CType(FVelogIRBL.FindControl("F_LocationCountryID"), LC_elogLocationCountries)
    Dim OtherCountry As TextBox = CType(FVelogIRBL.FindControl("F_OtherCountry"), TextBox)
    Dim CargoType As LC_elogCargoTypes = CType(FVelogIRBL.FindControl("F_CargoTypeID"), LC_elogCargoTypes)
    Dim Port As LC_elogPorts = CType(FVelogIRBL.FindControl("F_PortID"), LC_elogPorts)
    Dim OtherPortLoadingOrigin As TextBox = CType(FVelogIRBL.FindControl("F_OtherPortLoadingOrigin"), TextBox)
    Dim cmdNext As Button = CType(FVelogIRBL.FindControl("cmdNext"), Button)
    Dim cmdBack As Button = CType(FVelogIRBL.FindControl("cmdBack"), Button)
    TBLelogIRBL.EnableSave = False

    If State = "" Then
      State = st.Value
    End If
    Select Case State
      Case "6" 'Non Edit
        ShipmentMode.Enabled = False
        Carrier.Enabled = False
        OtherCarrier.Enabled = False
        LocationCountry.Enabled = False
        OtherCountry.Enabled = False
        CargoType.Enabled = False
        Port.Enabled = False
        OtherPortLoadingOrigin.Enabled = False
        r5.BgColor = ""
        r6.BgColor = ""
        cmdBack.Enabled = True
        cmdNext.Enabled = False
        TBLelogIRBL.EnableSave = True
      Case "1" 'Initial
        ShipmentMode.Enabled = True
        Carrier.Enabled = False
        OtherCarrier.Enabled = False
        LocationCountry.Enabled = False
        OtherCountry.Enabled = False
        CargoType.Enabled = False
        Port.Enabled = False
        OtherPortLoadingOrigin.Enabled = False
        r1.BgColor = "yellow"
        r2.BgColor = ""
        cmdBack.Enabled = False
        cmdNext.Enabled = True
      Case "2"
        ShipmentMode.Enabled = False
        Carrier.Enabled = True
        OtherCarrier.Enabled = True
        LocationCountry.Enabled = False
        OtherCountry.Enabled = False
        CargoType.Enabled = False
        Port.Enabled = False
        OtherPortLoadingOrigin.Enabled = False
        r1.BgColor = ""
        r2.BgColor = "yellow"
        r3.BgColor = ""
        cmdBack.Enabled = True
        cmdNext.Enabled = True
      Case "3"
        ShipmentMode.Enabled = False
        Carrier.Enabled = False
        OtherCarrier.Enabled = False
        LocationCountry.Enabled = True
        OtherCountry.Enabled = True
        CargoType.Enabled = False
        Port.Enabled = False
        OtherPortLoadingOrigin.Enabled = False
        r2.BgColor = ""
        r3.BgColor = "yellow"
        r4.BgColor = ""
        cmdBack.Enabled = True
        cmdNext.Enabled = True
      Case "4"
        ShipmentMode.Enabled = False
        Carrier.Enabled = False
        OtherCarrier.Enabled = False
        LocationCountry.Enabled = False
        OtherCountry.Enabled = False
        CargoType.Enabled = True
        Port.Enabled = False
        OtherPortLoadingOrigin.Enabled = False
        r3.BgColor = ""
        r4.BgColor = "yellow"
        r5.BgColor = ""
        r6.BgColor = ""
        cmdBack.Enabled = True
        cmdNext.Enabled = True
      Case "5"
        ShipmentMode.Enabled = False
        Carrier.Enabled = False
        OtherCarrier.Enabled = False
        LocationCountry.Enabled = False
        OtherCountry.Enabled = False
        CargoType.Enabled = False
        Port.Enabled = False
        OtherPortLoadingOrigin.Enabled = False
        r4.BgColor = ""
        r5.BgColor = ""
        r6.BgColor = ""
        If ShipmentMode.SelectedValue = "1" And LocationCountry.SelectedValue = "1" And CargoType.SelectedValue = "2" Then
          Port.Enabled = True
          r5.BgColor = "yellow"
          OtherPortLoadingOrigin.Enabled = True
          r6.BgColor = "yellow"
        ElseIf ShipmentMode.SelectedValue = "1" And LocationCountry.SelectedValue = "2" Then
          OtherPortLoadingOrigin.Enabled = True
          r6.BgColor = "yellow"
        ElseIf ShipmentMode.SelectedValue = "2" Then
          OtherPortLoadingOrigin.Enabled = True
          r6.BgColor = "yellow"
        End If
        cmdBack.Enabled = True
        cmdNext.Enabled = True
    End Select
  End Sub
  <System.Web.Services.WebMethod()>
  <System.Web.Script.Services.ScriptMethod()>
  Public Shared Function BLIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.ELOG.elogBLHeader.SelectelogBLHeaderAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()>
  Public Shared Function validate_FK_ELOG_IRBL_BLID(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String = "0|" & aVal(0)
    Dim BLID As String = CType(aVal(1), String)
    Dim oVar As SIS.ELOG.elogBLHeader = SIS.ELOG.elogBLHeader.LG_elogBLHeaderGetByID(BLID)
    If oVar Is Nothing Then
      mRet = getBLData(value)
      If mRet.StartsWith("0") Then
        oVar = SIS.ELOG.elogBLHeader.LG_elogBLHeaderGetByID(BLID)
        mRet = "0|" & aVal(0) & "|" & oVar.DisplayField & "|" & oVar.BLID
      End If
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField & "|" & oVar.BLID
    End If
    Return mRet
  End Function
  <System.Web.Services.WebMethod()>
  Public Shared Function getIRData(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String = "0|" & aVal(0)
    Dim IRNo As Int32 = CType(aVal(1).Replace("_", ""), Int32)
    Dim tmp As SIS.ELOG.elogIRBL = SIS.ELOG.elogIRBL.elogIRBLGetByID(IRNo)
    If tmp IsNot Nothing Then
      mRet = "1|" & aVal(0) & "| IR Number already used."
      Return mRet
    End If
    Dim Sql As String = ""
    Sql = Sql & "select "
    Sql = Sql & "ir.t_ninv as IRNo,"
    Sql = Sql & "ir.t_refr as IRDescription,"
    Sql = Sql & "ir.t_cdf_pono as PONo,"
    Sql = Sql & "ir.t_cdf_irdt as IRDate,"
    Sql = Sql & "ir.t_cdf_cprj as ProjectID,"
    Sql = Sql & "ir.t_ifbp as SupplierID,"
    Sql = Sql & "ir.t_isup as SupplierBillNo,"
    Sql = Sql & "ir.t_invd as supplierBillDate,"
    Sql = Sql & "ir.t_amti as SupplierBillAmount  "
    Sql = Sql & "from ttfacp100200 as ir "
    Sql = Sql & "where ir.t_ninv = " & IRNo
    Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
      Using Cmd As SqlCommand = Con.CreateCommand()
        Cmd.CommandType = CommandType.Text
        Cmd.CommandText = Sql
        Con.Open()
        Dim Reader As SqlDataReader = Cmd.ExecuteReader()
        If Reader.Read() Then
          tmp = New SIS.ELOG.elogIRBL(Reader)
        End If
        Reader.Close()
      End Using
    End Using
    If tmp Is Nothing Then
      mRet = "1|" & aVal(0) & "| IR Number NOT Found."
    Else
      With tmp
        mRet &= "|" & .SupplierID
        mRet &= "|" & .ProjectID
        mRet &= "|" & .SupplierBillNo
        mRet &= "|" & .supplierBillDate
        mRet &= "|" & .SupplierBillAmount
        mRet &= "|" & .IRDate
        mRet &= "|" & .PONo
      End With

    End If
    Return mRet
  End Function
  <System.Web.Services.WebMethod()>
  Public Shared Function getBLData(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String = "0|" & aVal(0)
    Dim BLNo As String = aVal(1)
    Dim tmp As SIS.ELOG.elogBLHeader = SIS.ELOG.elogBLHeader.elogBLHeaderGetByID(BLNo)
    If tmp IsNot Nothing Then
      Return mRet
    End If
    Dim Sql As String = ""
    Sql = Sql & " select TOP 1 "
    Sql = Sql & " t_blno as BLID,"
    Sql = Sql & " t_biln as BLNumber,"
    Sql = Sql & " t_pddt as BLDate,"
    Sql = Sql & " t_plod as PortOfLoading,"
    Sql = Sql & " t_vfln as VesselOrFlightNo,"
    Sql = Sql & " t_voyg as VoyageNo,"
    Sql = Sql & " t_ptld as TransShipmentPortID,"
    Sql = Sql & " PrepaidFlight = case t_frgt when 2 then 'False' else 'True' end,"
    Sql = Sql & " t_shpl as ShippingLine,"
    Sql = Sql & " t_sobd as SOBDate,"
    Sql = Sql & " t_mbln as MBLNo,"
    Sql = Sql & " t_pcar as PreCarriageBy,"
    Sql = Sql & " t_plac as PlaceOfReceiptBy,"
    Sql = Sql & " t_fdet1 as Air1Freight,"
    Sql = Sql & " t_fdet2 as Air2Freight,"
    Sql = Sql & " t_fdet3 as Air3Freight,"
    Sql = Sql & " t_fdet4 as Air4Freight "
    Sql = Sql & " from ttdisg839200  "
    Sql = Sql & " where UPPER(t_blno) = UPPER('" & BLNo & "')"
    Sql = Sql & " OR UPPER(t_biln) = UPPER('" & BLNo & "')"
    Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
      Using Cmd As SqlCommand = Con.CreateCommand()
        Cmd.CommandType = CommandType.Text
        Cmd.CommandText = Sql
        Con.Open()
        Dim Reader As SqlDataReader = Cmd.ExecuteReader()
        If Reader.Read() Then
          tmp = New SIS.ELOG.elogBLHeader(Reader)
        End If
        Reader.Close()
      End Using
    End Using
    If tmp Is Nothing Then
      mRet = "1|" & aVal(0) & "| BL Number NOT Found in ERP."
    Else
      Try
        SIS.ELOG.elogBLHeader.InsertData(tmp)
      Catch ex As Exception
      End Try
      Dim tmps As New List(Of SIS.ELOG.elogBLDetails)
      Sql = ""
      Sql = Sql & " select "
      Sql = Sql & " t_rqno as BLID,"
      Sql = Sql & " t_srno as SerialNo,"
      Sql = Sql & " t_ctno as ContainerNumber,"
      Sql = Sql & " ltrim(t_size) +'-' + ltrim(t_type) as SizeAndTypeOfContainer,"
      Sql = Sql & " t_remk as Remarks "
      Sql = Sql & " from ttdisg830200  "
      Sql = Sql & " where t_rqno = '" & tmp.BLID & "'"
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            tmps.Add(New SIS.ELOG.elogBLDetails(Reader))
          End While
          Reader.Close()
        End Using
      End Using
      For Each tm As SIS.ELOG.elogBLDetails In tmps
        Try
          SIS.ELOG.elogBLDetails.InsertData(tm)
        Catch ex As Exception
        End Try
      Next
    End If
    Return mRet
  End Function

  Private Sub FVelogIRBL_ItemCommand(sender As Object, e As FormViewCommandEventArgs) Handles FVelogIRBL.ItemCommand
    Dim st As HiddenField = CType(FVelogIRBL.FindControl("State"), HiddenField)
    If e.CommandName = "lgBack" Then
      st.Value = Convert.ToInt32(st.Value) - 1
      If Convert.ToInt32(st.Value) <= 0 Then
        st.Value = "1"
      End If
    End If
    If e.CommandName = "lgNext" Then
      Dim Err As Boolean = False
      Dim msg As String = ""
      Select Case st.Value
        Case "1"
          Dim ShipmentMode As LC_elogShipmentModes = CType(FVelogIRBL.FindControl("F_ShipmentModeID"), LC_elogShipmentModes)
          Dim Carrier As LC_elogCarriers = CType(FVelogIRBL.FindControl("F_CarrierID"), LC_elogCarriers)
          If ShipmentMode.SelectedValue <> "" Then
            st.Value = Convert.ToInt32(st.Value) + 1
          Else
            Err = True
            msg = "Please Select Shipment Mode."
          End If
        Case "2"
          Dim Carrier As LC_elogCarriers = CType(FVelogIRBL.FindControl("F_CarrierID"), LC_elogCarriers)
          Dim OtherCarrier As TextBox = CType(FVelogIRBL.FindControl("F_OtherCarrier"), TextBox)
          If Carrier.SelectedValue <> "" Or OtherCarrier.Text <> "" Then
            st.Value = Convert.ToInt32(st.Value) + 1
          Else
            Err = True
            msg = "Please Select Carrier or Enter Other Carrier."
          End If
        Case "3"
          Dim ShipmentMode As LC_elogShipmentModes = CType(FVelogIRBL.FindControl("F_ShipmentModeID"), LC_elogShipmentModes)
          Dim LocationCountry As LC_elogLocationCountries = CType(FVelogIRBL.FindControl("F_LocationCountryID"), LC_elogLocationCountries)
          Dim OtherCountry As TextBox = CType(FVelogIRBL.FindControl("F_OtherCountry"), TextBox)
          If LocationCountry.SelectedValue <> "" Then
            If LocationCountry.SelectedValue = "2" And OtherCountry.Text = "" Then
              Err = True
              msg = "Please Enter Other Country Name."
            Else
              If ShipmentMode.SelectedValue = "2" Then
                st.Value = Convert.ToInt32(st.Value) + 2
              Else
                st.Value = Convert.ToInt32(st.Value) + 1
              End If
            End If
          Else
            Err = True
            msg = "Please Select Location Country"
          End If
        Case "4"
          Dim CargoType As LC_elogCargoTypes = CType(FVelogIRBL.FindControl("F_CargoTypeID"), LC_elogCargoTypes)
          If CargoType.SelectedValue <> "" Then
            st.Value = Convert.ToInt32(st.Value) + 1
          Else
            Err = True
            msg = "Please select Cargo Type."
          End If
        Case "5"
          Dim ShipmentMode As LC_elogShipmentModes = CType(FVelogIRBL.FindControl("F_ShipmentModeID"), LC_elogShipmentModes)
          Dim LocationCountry As LC_elogLocationCountries = CType(FVelogIRBL.FindControl("F_LocationCountryID"), LC_elogLocationCountries)
          Dim CargoType As LC_elogCargoTypes = CType(FVelogIRBL.FindControl("F_CargoTypeID"), LC_elogCargoTypes)
          Dim Port As LC_elogPorts = CType(FVelogIRBL.FindControl("F_PortID"), LC_elogPorts)
          Dim OtherPortLoadingOrigin As TextBox = CType(FVelogIRBL.FindControl("F_OtherPortLoadingOrigin"), TextBox)
          If ShipmentMode.SelectedValue = "1" And LocationCountry.SelectedValue = "1" And CargoType.SelectedValue = "1" Then
            st.Value = Convert.ToInt32(st.Value) + 1
          ElseIf ShipmentMode.SelectedValue = "1" And LocationCountry.SelectedValue = "1" And CargoType.SelectedValue = "2" Then
            If Port.SelectedValue <> "" Then
              st.Value = Convert.ToInt32(st.Value) + 1
            Else
              Err = True
              msg = "Please select Port."
            End If
          ElseIf ShipmentMode.SelectedValue = "1" And LocationCountry.SelectedValue = "2" Then
            If OtherPortLoadingOrigin.Text <> "" Then
              st.Value = Convert.ToInt32(st.Value) + 1
            Else
              Err = True
              msg = "Please Enter Port Of Loading Text."
            End If
          ElseIf ShipmentMode.SelectedValue = "2" Then
            If OtherPortLoadingOrigin.Text <> "" Then
              st.Value = Convert.ToInt32(st.Value) + 1
            Else
              Err = True
              msg = "Please Enter Origin Point Text."
            End If
          End If

      End Select
      If Err Then
        Dim message As String = New JavaScriptSerializer().Serialize(msg)
        Dim script As String = String.Format("alert({0});", message)
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", script, True)
      End If
    End If
  End Sub
  Private Sub AF_elogIRBL_Load(sender As Object, e As EventArgs) Handles Me.Load
    Dim st As HiddenField = CType(FVelogIRBL.FindControl("State"), HiddenField)
    If st.Value = "1" Then
      Dim ShipmentMode As LC_elogShipmentModes = CType(FVelogIRBL.FindControl("F_ShipmentModeID"), LC_elogShipmentModes)
      Dim Carrier As LC_elogCarriers = CType(FVelogIRBL.FindControl("F_CarrierID"), LC_elogCarriers)
      If ShipmentMode.SelectedValue <> "" Then
        Carrier.clear()
        Carrier.OrderBy = ShipmentMode.SelectedValue
        Carrier.DataBind()
      End If
    End If

  End Sub
End Class
