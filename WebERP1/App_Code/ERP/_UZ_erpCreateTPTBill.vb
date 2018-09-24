Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.ERP
	Partial Public Class erpCreateTPTBill
		Private _IRNumber As String = ""
		Private _ReasonID As String = ""
		Private _NewBillStatus As String = ""

		Private _BackToTownCharges As String = 0
		Private _TarpaulinCharges As String = 0
		Private _WoodenSleeperCharges As String = 0
		Private _DetentionatDaysULP As String = 0
		Private _ULPisICDCFSPort As Boolean = False
		Private _DetentionatDaysLP As String = 0
		Private _LPisISGECWorks As Boolean = False
		Public Property BackToTownCharges() As String
			Get
				Return _BackToTownCharges
			End Get
			Set(ByVal value As String)
				If Not Convert.IsDBNull(value) Then
					_BackToTownCharges = value
				Else
					_BackToTownCharges = 0
				End If
			End Set
		End Property
		Public Property TarpaulinCharges() As String
			Get
				Return _TarpaulinCharges
			End Get
			Set(ByVal value As String)
				If Not Convert.IsDBNull(value) Then
					_TarpaulinCharges = value
				Else
					_TarpaulinCharges = 0
				End If

			End Set
		End Property
		Public Property WoodenSleeperCharges() As String
			Get
				Return _WoodenSleeperCharges
			End Get
			Set(ByVal value As String)
				If Not Convert.IsDBNull(value) Then
					_WoodenSleeperCharges = value
				Else
					_WoodenSleeperCharges = 0
				End If

			End Set
		End Property
		Public Property DetentionatDaysULP() As String
			Get
				Return _DetentionatDaysULP
			End Get
			Set(ByVal value As String)
				If Not Convert.IsDBNull(value) Then
					_DetentionatDaysULP = value
				Else
					_DetentionatDaysULP = 0
				End If

			End Set
		End Property
		Public Property ULPisICDCFSPort() As Boolean
			Get
				Return _ULPisICDCFSPort
			End Get
			Set(ByVal value As Boolean)
				_ULPisICDCFSPort = value
			End Set
		End Property
		Public Property DetentionatDaysLP() As String
			Get
				Return _DetentionatDaysLP
			End Get
			Set(ByVal value As String)
				If Not Convert.IsDBNull(value) Then
					_DetentionatDaysLP = value
				Else
					_DetentionatDaysLP = 0
				End If
			End Set
		End Property
		Public Property LPisISGECWorks() As Boolean
			Get
				Return _LPisISGECWorks
			End Get
			Set(ByVal value As Boolean)
				_LPisISGECWorks = value
			End Set
		End Property



		Public Property NewBillStatus() As String
			Get
				Return _NewBillStatus
			End Get
			Set(ByVal value As String)
				_NewBillStatus = value
			End Set
		End Property
		Public Property ReasonID() As String
			Get
				Return _ReasonID
			End Get
			Set(ByVal value As String)
				If Convert.IsDBNull(value) Then
					_ReasonID = ""
				Else
					_ReasonID = value
				End If
			End Set
		End Property
		Public Property IRNumber() As String
			Get
				Return _IRNumber
			End Get
			Set(ByVal value As String)
				If Convert.IsDBNull(value) Then
					_IRNumber = ""
				Else
					_IRNumber = value
				End If
			End Set
		End Property
		Public Shared Function erpCreateTPTBillGetByIRNumber(ByVal IRNumber As String) As SIS.ERP.erpCreateTPTBill
			Dim Results As SIS.ERP.erpCreateTPTBill = Nothing
			Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
				Using Cmd As SqlCommand = Con.CreateCommand()
					Cmd.CommandType = CommandType.StoredProcedure
					Cmd.CommandText = "sperp_LG_CreateTPTBillSelectByIRNumber"
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@IRNumber", SqlDbType.NVarChar, 11, IRNumber)
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, HttpContext.Current.Session("LoginID"))
					Con.Open()
					Dim Reader As SqlDataReader = Cmd.ExecuteReader()
					If Reader.Read() Then
						Results = New SIS.ERP.erpCreateTPTBill(Reader)
					End If
					Reader.Close()
				End Using
			End Using
			Return Results
		End Function
		Public Function GetColor() As System.Drawing.Color
			Dim mRet As System.Drawing.Color = Drawing.Color.Blue
			Select Case _BillStatus
				Case TptBillStatus.Cancelled
				Case TptBillStatus.Free
					mRet = Drawing.Color.Black
				Case TptBillStatus.UnderReceiveByAccounts
					mRet = Drawing.Color.DarkOrange
				Case TptBillStatus.UnderPaymentProcessing
					mRet = Drawing.Color.Green
				Case TptBillStatus.UnderReceiveByLogistics
					mRet = Drawing.Color.Red
				Case TptBillStatus.UnderReSubmitbyLogistics
					mRet = Drawing.Color.DarkOrchid
				Case TptBillStatus.PaymentProcessed
					mRet = Drawing.Color.DarkMagenta
				Case TptBillStatus.Closed
					mRet = Drawing.Color.DarkGoldenrod
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
		Public ReadOnly Property InitiateWFVisible() As Boolean
			Get
				Dim mRet As Boolean = False
				Try
					Select Case _BillStatus
						Case TptBillStatus.Free
							mRet = True
					End Select
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
		Public ReadOnly Property ApproveWFVisible() As Boolean
			Get
				Dim mRet As Boolean = False
				Try
					Select Case _BillStatus
						Case TptBillStatus.UnderReceiveByLogistics
							mRet = True
					End Select
				Catch ex As Exception
				End Try
				Return mRet
			End Get
		End Property
		Public ReadOnly Property ApproveWFEnable() As Boolean
			Get
				Dim mRet As Boolean = True
				Try
					mRet = GetEnable()
				Catch ex As Exception
				End Try
				Return mRet
			End Get
		End Property
		Public ReadOnly Property RejectWFVisible() As Boolean
			Get
				Dim mRet As Boolean = False
				Try
					Select Case _BillStatus
						Case TptBillStatus.UnderReSubmitbyLogistics
							mRet = True
					End Select
				Catch ex As Exception
				End Try
				Return mRet
			End Get
		End Property
		Public ReadOnly Property RejectWFEnable() As Boolean
			Get
				Dim mRet As Boolean = True
				Try
					mRet = GetEnable()
				Catch ex As Exception
				End Try
				Return mRet
			End Get
		End Property
		Public ReadOnly Property CompleteWFVisible() As Boolean
			Get
				Dim mRet As Boolean = False
				Try
					Select Case _BillStatus
						Case TptBillStatus.PaymentProcessed
							mRet = True
					End Select
				Catch ex As Exception
				End Try
				Return mRet
			End Get
		End Property
		Public ReadOnly Property CompleteWFEnable() As Boolean
			Get
				Dim mRet As Boolean = True
				Try
					mRet = GetEnable()
				Catch ex As Exception
				End Try
				Return mRet
			End Get
		End Property
		Public Shared Function InitiateWF(ByVal SerialNo As Int32) As SIS.ERP.erpCreateTPTBill
			Dim Results As SIS.ERP.erpCreateTPTBill = erpCreateTPTBillGetByID(SerialNo)
			With Results
				.FWDToAccountsBy = HttpContext.Current.Session("LoginID")
				.FWDToAccountsOn = Now
				.BillStatus = TptBillStatus.UnderReceiveByAccounts
			End With
			SIS.ERP.erpCreateTPTBill.UpdateData(Results)
			Return Results
		End Function
		Public Shared Function ApproveWF(ByVal SerialNo As Int32) As SIS.ERP.erpCreateTPTBill
			Dim Results As SIS.ERP.erpCreateTPTBill = erpCreateTPTBillGetByID(SerialNo)
			With Results
				.DiscRecdInLgstBy = HttpContext.Current.Session("LoginID")
				.DiscRecdInLgstOn = Now
				.BillStatus = TptBillStatus.UnderReSubmitbyLogistics
			End With
			SIS.ERP.erpCreateTPTBill.UpdateData(Results)
			Return Results
		End Function
		Public Shared Function RejectWF(ByVal SerialNo As Int32) As SIS.ERP.erpCreateTPTBill
			Dim Results As SIS.ERP.erpCreateTPTBill = erpCreateTPTBillGetByID(SerialNo)
			With Results
				.ReFwdToAcBy = HttpContext.Current.Session("LoginID")
				.ReFwdToACOn = Now
				.BillStatus = TptBillStatus.UnderReceiveByAccounts
			End With
			SIS.ERP.erpCreateTPTBill.UpdateData(Results)
			Return Results
		End Function
		Public Shared Function CompleteWF(ByVal SerialNo As Int32) As SIS.ERP.erpCreateTPTBill
			Dim Results As SIS.ERP.erpCreateTPTBill = erpCreateTPTBillGetByID(SerialNo)
			If Results.ChequeNo = String.Empty Then
				Throw New Exception("Cheque No. NOT Entered.")
			End If
			Results.BillStatus = TptBillStatus.Closed
			SIS.ERP.erpCreateTPTBill.UpdateData(Results)
			Return Results
		End Function
		Public Shared Function UZ_erpCreateTPTBillSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal TPTCode As String, ByVal ProjectID As String, ByVal BillStatus As Int32) As List(Of SIS.ERP.erpCreateTPTBill)
			Dim Results As List(Of SIS.ERP.erpCreateTPTBill) = Nothing
			Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
				Using Cmd As SqlCommand = Con.CreateCommand()
					If OrderBy = String.Empty Then OrderBy = "SerialNo DESC"
					Cmd.CommandType = CommandType.StoredProcedure
					If SearchState Then
						Cmd.CommandText = "sperp_LG_CreateTPTBillSelectListSearch"
						Cmd.CommandText = "sperpCreateTPTBillSelectListSearch"
						SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
					Else
						Cmd.CommandText = "sperp_LG_CreateTPTBillSelectListFilteres"
						Cmd.CommandText = "sperpCreateTPTBillSelectListFilteres"
						SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_TPTCode", SqlDbType.NVarChar, 9, IIf(TPTCode Is Nothing, String.Empty, TPTCode))
						SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_ProjectID", SqlDbType.NVarChar, 6, IIf(ProjectID Is Nothing, String.Empty, ProjectID))
						SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_BillStatus", SqlDbType.Int, 10, IIf(BillStatus = Nothing, 0, BillStatus))
					End If
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, HttpContext.Current.Session("LoginID"))
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
					Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
					Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
					_RecordCount = -1
					Results = New List(Of SIS.ERP.erpCreateTPTBill)()
					Con.Open()
					Dim Reader As SqlDataReader = Cmd.ExecuteReader()
					While (Reader.Read())
						Results.Add(New SIS.ERP.erpCreateTPTBill(Reader))
					End While
					Reader.Close()
					_RecordCount = Cmd.Parameters("@RecordCount").Value
				End Using
			End Using
			Return Results
		End Function
		Public Shared Function UZ_erpCreateTPTBillInsert(ByVal Record As SIS.ERP.erpCreateTPTBill) As SIS.ERP.erpCreateTPTBill
			Record.BillStatus = 2
			Dim _Result As SIS.ERP.erpCreateTPTBill = erpCreateTPTBillInsert(Record)
			Return _Result
		End Function
		Public Shared Function UZ_erpCreateTPTBillUpdate(ByVal Record As SIS.ERP.erpCreateTPTBill) As SIS.ERP.erpCreateTPTBill
			Dim _Result As SIS.ERP.erpCreateTPTBill = erpCreateTPTBillUpdate(Record)
			Return _Result
		End Function
		Public Shared Function UZ_erpCreateTPTBillDelete(ByVal Record As SIS.ERP.erpCreateTPTBill) As Integer
			Dim _Result As Integer = erpCreateTPTBillDelete(Record)
			Return _Result
		End Function
		Public Shared Function getIRData(ByVal value As String) As String
			Dim aVal() As String = value.Split(",".ToCharArray)
			Dim mRet As String = "0|" & aVal(0)
			Dim IRNo As Int32 = CType(aVal(1).Replace("_", ""), Int32)
			Dim oTptBill As SIS.ERP.erpCreateTPTBill = SIS.ERP.erpCreateTPTBill.erpCreateTPTBillGetByIRNumber(IRNo)
			If oTptBill IsNot Nothing Then
				mRet = "1|" & aVal(0) & "| IR Number already used."
				Return mRet
			End If
			Dim Results As SIS.ERP.erpCreateTPTBill = Nothing
			Dim Sql As String = ""
			Sql = Sql & "select "
			Sql = Sql & "ir.t_ninv as IRNo,"
			Sql = Sql & "ir.t_refr as IRDescription,"
			Sql = Sql & "ir.t_cdf_pono as PONumber,"
			Sql = Sql & "ir.t_cdf_irdt as TPTBillReceivedOn,"
			Sql = Sql & "ir.t_cdf_cprj as ProjectID,"
			Sql = Sql & "ir.t_amti as POAmount,"
			Sql = Sql & "ir.t_ifbp as TPTCode,"
			Sql = Sql & "ir.t_isup as TPTBillNo,"
			Sql = Sql & "ir.t_invd as TPTBillDate,"
			Sql = Sql & "ir.t_amti as TPTBillAmount, "
			Sql = Sql & "gr.t_grno as GRNOs "
			Sql = Sql & "from ttfacp100200 as ir "
			Sql = Sql & "left outer join ttfisg002200 as gr on ir.t_ninv = gr.t_irno "
			Sql = Sql & "where ir.t_ninv = " & IRNo
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.ERP.erpCreateTPTBill(Reader)
            While (Reader.Read())
              Results.GRNos = Results.GRNos & ", " & Reader("GRNos")
            End While
          End If
          Reader.Close()
        End Using
      End Using
      mRet &= "|" & Results.TPTBillNo
			mRet &= "|" & Results.TPTBillDate
			mRet &= "|" & Results.GRNos
			mRet &= "|" & Results.TPTCode
			mRet &= "|" & Results.PONumber
			mRet &= "|" & Results.ProjectID
			mRet &= "|" & Results.TPTBillAmount
			mRet &= "|" & Results.TPTBillReceivedOn
			Return mRet
		End Function
		Public Shared Function GetByReceiptDate(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal FromDate As String, ByVal ToDate As String, ByVal StatusID As String) As List(Of SIS.ERP.erpCreateTPTBill)
			Dim Results As List(Of SIS.ERP.erpCreateTPTBill) = Nothing
			Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
				Using Cmd As SqlCommand = Con.CreateCommand()
					Cmd.CommandType = CommandType.StoredProcedure
					Cmd.CommandText = "sperp_LG_CreateTPTBillGetByReceiptDate"
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FromDate", SqlDbType.DateTime, 20, FromDate)
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ToDate", SqlDbType.DateTime, 20, ToDate)
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StatusID", SqlDbType.NVarChar, 9, StatusID)
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, HttpContext.Current.Session("LoginID"))
					Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
					Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
					_RecordCount = -1
					Results = New List(Of SIS.ERP.erpCreateTPTBill)()
					Con.Open()
					Dim Reader As SqlDataReader = Cmd.ExecuteReader()
					While (Reader.Read())
						Results.Add(New SIS.ERP.erpCreateTPTBill(Reader))
					End While
					Reader.Close()
					_RecordCount = Cmd.Parameters("@RecordCount").Value
				End Using
			End Using
			Return Results
		End Function
		Public Shared Function getPaymentData(ByVal value As String) As String
			Dim aVal() As String = value.Split(",".ToCharArray)
			Dim mRet As String = "0|" & aVal(0)
			Dim IRNo As Int32 = CType(aVal(1).Replace("_", ""), Int32)
			Dim Results As List(Of SIS.VR.vrPaymentProcess) = SIS.VR.vrPaymentProcess.PaymentInBaaNByIRNo(IRNo)
			If Results.Count > 0 Then
				With Results(0)
					mRet &= "|" & .PTRNo
					mRet &= "|" & .PTRDate
					mRet &= "|" & .PTRAmount
					mRet &= "|" & .ChequeNo

				End With
			End If
			Return mRet
		End Function
	End Class
End Namespace
