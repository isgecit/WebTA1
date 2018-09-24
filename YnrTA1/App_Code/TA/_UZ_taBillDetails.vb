Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.TA
  Partial Public Class taBillDetails
    Implements ICloneable
    Public Function Clone() As Object Implements System.ICloneable.Clone
      Return MyBase.MemberwiseClone()
    End Function
    Private _Saved As Boolean = False
    Public Property Saved As Boolean
      Get
        Return _Saved
      End Get
      Set(value As Boolean)
        _Saved = value
      End Set
    End Property
    Public ReadOnly Property IsDomestic As Boolean
      Get
        Dim mRet As Boolean = True
        If FK_TA_BillDetails_City1ID IsNot Nothing Then
          If FK_TA_BillDetails_City1ID.RegionTypeID.ToLower = "domestic" Then
            mRet = True
          Else
            mRet = False
          End If
        Else
          If FK_TA_BillDetails_TABillNo IsNot Nothing Then
            If FK_TA_BillDetails_TABillNo.TravelTypeID = TATravelTypeValues.Domestic Then
              mRet = True
            Else
              mRet = False
            End If
          Else
            mRet = True
          End If
        End If
        Return mRet
      End Get
    End Property
    Public Sub New(ByVal TABillNo As Integer, ByVal SerialNo As Integer)
      _TABillNo = TABillNo
      _SerialNo = SerialNo
    End Sub
    Public Function GetColor() As System.Drawing.Color
      Dim mRet As System.Drawing.Color = Drawing.Color.Black
      Select Case ComponentID
        Case TAComponentTypes.DA
          mRet = Drawing.Color.DarkOrchid
          If AmountRate < 0 Then
            mRet = Drawing.Color.DarkOrange
          End If
        Case TAComponentTypes.LC
          If FK_TA_BillDetails_TABillNo.TravelTypeID <> TATravelTypeValues.Domestic Then
            If Not AirportToClientLocation And Not HotelToAirport And Not AirportToHotel Then
              mRet = Drawing.Color.Red
            End If
          End If
      End Select
      Return mRet
    End Function
    Public Function GetVisible() As Boolean
      Dim mRet As Boolean = True
      Return mRet
    End Function
    Public Function GetEnable() As Boolean
      Dim mRet As Boolean = True
      Return mRet
    End Function
    Public Function GetEditable() As Boolean
      Dim mRet As Boolean = True
      Return mRet
    End Function
    Public ReadOnly Property Editable() As Boolean
      Get
        Dim mRet As Boolean = False
        Try
          If _AutoCalculated Then
          Else
            Select Case FK_TA_BillDetails_TABillNo.BillStatusID
              Case TAStates.Free, TAStates.ReturnedByAccounts, TAStates.ReturnedByApprover, TAStates.ReturnedByVerifier, TAStates.ReturnedBySanctioningAuthority
                mRet = True
            End Select
          End If
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property Deleteable() As Boolean
      Get
        Dim mRet As Boolean = False
        Try
          If _AutoCalculated Then
          Else
            Select Case FK_TA_BillDetails_TABillNo.BillStatusID
              Case TAStates.Free, TAStates.ReturnedByAccounts, TAStates.ReturnedByApprover, TAStates.ReturnedByVerifier, TAStates.ReturnedBySanctioningAuthority
                mRet = True
            End Select
          End If
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property DeleteWFVisible() As Boolean
      Get
        Dim mRet As Boolean = False
        Try
          mRet = Deleteable
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property DeleteWFEnable() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetEnable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public Shared Function DeleteWF(ByVal TABillNo As Int32, ByVal SerialNo As Int32, ByVal ComponentID As Int32, ByVal Date1Time As DateTime) As SIS.TA.taBillDetails
      Dim Results As SIS.TA.taBillDetails = taBillDetailsGetByID(TABillNo, SerialNo)
      Try
        SIS.TA.taBillDetails.taBillDetailsDelete(Results)
      Catch ex As Exception
      End Try
      SIS.TA.taBH.ValidateTABill(TABillNo)
      Return Results
    End Function
    Public Shared Function DeleteWF(ByVal TABillNo As Int32, ByVal SerialNo As Int32) As SIS.TA.taBillDetails
      Dim Results As SIS.TA.taBillDetails = taBillDetailsGetByID(TABillNo, SerialNo)
      Try
        SIS.TA.taBillDetails.taBillDetailsDelete(Results)
      Catch ex As Exception
      End Try
      SIS.TA.taBH.ValidateTABill(TABillNo)
      Return Results
    End Function
    Public ReadOnly Property InitiateWFVisible() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetVisible()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property InitiateWFEnable() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetEnable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public Shared Function InitiateWF(ByVal TABillNo As Int32, ByVal SerialNo As Int32, ByVal ComponentID As Int32, ByVal Date1Time As DateTime) As SIS.TA.taBillDetails
      Dim Results As SIS.TA.taBillDetails = taBillDetailsGetByID(TABillNo, SerialNo)
      taBH.ValidateTABill(Results.TABillNo)
      Return Results
    End Function
    Public Shared Function UZ_taBillDetailsSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal TABillNo As Int32) As List(Of SIS.TA.taBillDetails)
      Dim Results As List(Of SIS.TA.taBillDetails) = Nothing
      MaximumRows = MaximumRows - 1
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          If OrderBy = String.Empty Then OrderBy = "Date1Time DESC"
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "spta_LG_BillDetailsSelectListSearch"
            Cmd.CommandText = "sptaBillDetailsSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "spta_LG_BillDetailsSelectListFilteres"
            Cmd.CommandText = "sptaBillDetailsSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_TABillNo", SqlDbType.Int, 10, IIf(TABillNo = Nothing, 0, TABillNo))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.TA.taBillDetails)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.TA.taBillDetails(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
          'For I As Integer = MaximumRows + 1 To MaximumRows - _RecordCount - 1 Step -1
          Results.Insert(0, New SIS.TA.taBillDetails(TABillNo, 0))
          'Next
          _RecordCount = _RecordCount + 1
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function UZ_taBillDetailsInsert(ByVal Record As SIS.TA.taBillDetails) As SIS.TA.taBillDetails
      With Record
        .AmountBasic = (.AmountFactor * .AmountRate)
        .AmountTotal = (.AmountBasic + .AmountTax)
        .AmountInINR = .AmountTotal * .ConversionFactorINR
        .PassedAmountFactor = .AmountFactor
        .PassedAmountRate = .AmountRate
        .PassedAmountBasic = .AmountBasic
        .PassedAmountTax = .AmountTax
        .PassedAmountTotal = .AmountTotal
        .PassedAmountInINR = .AmountInINR
      End With
      Dim _Result As SIS.TA.taBillDetails = taBillDetailsInsert(Record)
      Return _Result
    End Function
    Public Shared Function UZ_taBillDetailsUpdate(ByVal Record As SIS.TA.taBillDetails) As SIS.TA.taBillDetails
      With Record
        .AmountBasic = (.AmountFactor * .AmountRate)
        .AmountTotal = (.AmountBasic + .AmountTax)
        .AmountInINR = .AmountTotal * .ConversionFactorINR
        .PassedAmountFactor = .AmountFactor
        .PassedAmountRate = .AmountRate
        .PassedAmountBasic = .AmountBasic
        .PassedAmountTax = .AmountTax
        .PassedAmountTotal = .AmountTotal
        .PassedAmountInINR = .AmountInINR
      End With
      Dim _Result As SIS.TA.taBillDetails = taBillDetailsUpdate(Record)
      Return _Result
    End Function
    Public Shared Function UZ_taBillDetailsDelete(ByVal Record As SIS.TA.taBillDetails) As Integer
      Dim _Result As Integer = taBillDetailsDelete(Record)
      Return _Result
    End Function
    Public Shared Function SetDefaultValues(ByVal sender As System.Web.UI.WebControls.FormView, ByVal e As System.EventArgs) As System.Web.UI.WebControls.FormView
      On Error Resume Next
      With sender
        CType(.FindControl("F_AmountRateOU"), TextBox).Text = "0.00"
        CType(.FindControl("F_AmountRate"), TextBox).Text = "0.00"
        CType(.FindControl("F_AmountFactor"), TextBox).Text = "0.00"
        CType(.FindControl("F_AmountBasic"), TextBox).Text = "0.00"
        CType(.FindControl("F_AmountTaxOU"), TextBox).Text = "0.00"
        CType(.FindControl("F_ConversionFactorOU"), TextBox).Text = "1.000000"
        CType(.FindControl("F_TABillNo"), TextBox).Text = ""
        CType(.FindControl("F_TABillNo_Display"), Label).Text = ""
        CType(.FindControl("F_SerialNo"), TextBox).Text = ""
        CType(.FindControl("F_ComponentID"), Object).SelectedValue = ""
        CType(.FindControl("F_AutoCalculated"), CheckBox).Checked = False
        CType(.FindControl("F_TourExtended"), CheckBox).Checked = False
        CType(.FindControl("F_ProjectID"), TextBox).Text = ""
        CType(.FindControl("F_ProjectID_Display"), Label).Text = ""
        CType(.FindControl("F_CostCenterID"), Object).SelectedValue = ""
        CType(.FindControl("F_CurrencyID"), Object).SelectedValue = ""
        CType(.FindControl("F_ConversionFactorINR"), TextBox).Text = "1.000000"
        CType(.FindControl("F_City1ID"), TextBox).Text = ""
        CType(.FindControl("F_City1ID_Display"), Label).Text = ""
        CType(.FindControl("F_City1Text"), TextBox).Text = ""
        CType(.FindControl("F_City2ID"), TextBox).Text = ""
        CType(.FindControl("F_City2ID_Display"), Label).Text = ""
        CType(.FindControl("F_City2Text"), TextBox).Text = ""
        CType(.FindControl("F_Date1Time"), TextBox).Text = ""
        CType(.FindControl("F_Date2Time"), TextBox).Text = ""
        CType(.FindControl("F_ModeTravelID"), Object).SelectedValue = ""
        CType(.FindControl("F_ModeLCID"), Object).SelectedValue = ""
        CType(.FindControl("F_ModeExpenseID"), Object).SelectedValue = ""
        CType(.FindControl("F_ModeFinanceID"), Object).SelectedValue = ""
        CType(.FindControl("F_CityTypeID"), Object).SelectedValue = ""
        CType(.FindControl("F_ModeText"), TextBox).Text = ""
        CType(.FindControl("F_BoardingProvided"), CheckBox).Checked = False
        CType(.FindControl("F_LodgingProvided"), CheckBox).Checked = False
        CType(.FindControl("F_StayedWithRelative"), CheckBox).Checked = False
        CType(.FindControl("F_StayedInGuestHouse"), CheckBox).Checked = False
        CType(.FindControl("F_StayedAtSite"), CheckBox).Checked = False
        CType(.FindControl("F_StayedInHotel"), CheckBox).Checked = False
        CType(.FindControl("F_NotStayedAnyWhere"), CheckBox).Checked = False
        CType(.FindControl("F_AirportToHotel"), CheckBox).Checked = False
        CType(.FindControl("F_HotelToAirport"), CheckBox).Checked = False
        CType(.FindControl("F_AirportToClientLocation"), CheckBox).Checked = False
        CType(.FindControl("F_AmountFactor"), TextBox).Text = "0.00"
        CType(.FindControl("F_AmountRate"), TextBox).Text = "0.00"
        CType(.FindControl("F_AmountBasic"), TextBox).Text = "0.00"
        CType(.FindControl("F_AmountTax"), TextBox).Text = "0.00"
        CType(.FindControl("F_AmountTotal"), TextBox).Text = "0.00"
        CType(.FindControl("F_AmountInINR"), TextBox).Text = "0.00"
        CType(.FindControl("F_Remarks"), TextBox).Text = ""
        CType(.FindControl("F_PassedAmountFactor"), TextBox).Text = "0.00"
        CType(.FindControl("F_PassedAmountRate"), TextBox).Text = "0.00"
        CType(.FindControl("F_PassedAmountBasic"), TextBox).Text = "0.00"
        CType(.FindControl("F_PassedAmountTax"), TextBox).Text = "0.00"
        CType(.FindControl("F_PassedAmountTotal"), TextBox).Text = "0.00"
        CType(.FindControl("F_PassedAmountInINR"), TextBox).Text = "0.00"
        CType(.FindControl("F_AccountsRemarks"), TextBox).Text = ""
        CType(.FindControl("F_OOEBySystem"), CheckBox).Checked = False
        CType(.FindControl("F_OOEByAccounts"), CheckBox).Checked = False
        CType(.FindControl("F_OOEReasonID"), Object).SelectedValue = ""
        CType(.FindControl("F_OOERemarks"), TextBox).Text = ""
        CType(.FindControl("F_ApprovalWFTypeID"), Object).SelectedValue = ""
        CType(.FindControl("F_ApprovedBy"), TextBox).Text = ""
        CType(.FindControl("F_ApprovedBy_Display"), Label).Text = ""
        CType(.FindControl("F_ApprovedOn"), TextBox).Text = ""
        CType(.FindControl("F_ApprovalRemarks"), TextBox).Text = ""
        CType(.FindControl("F_Setteled"), CheckBox).Checked = False
        CType(.FindControl("F_BillAttached"), CheckBox).Checked = False
        CType(.FindControl("F_BillFileName"), TextBox).Text = ""
        CType(.FindControl("F_BillDiskFile"), TextBox).Text = ""
        CType(.FindControl("F_SanctionAttached"), CheckBox).Checked = False
        CType(.FindControl("F_SanctionFileName"), TextBox).Text = ""
        CType(.FindControl("F_SanctionDiskFile"), TextBox).Text = ""
        CType(.FindControl("F_SystemText"), TextBox).Text = ""
      End With
      Return sender
    End Function
  End Class
End Namespace
