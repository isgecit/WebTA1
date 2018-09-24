Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.ERP
  Partial Public Class erpProcessTPTBill
    Public Shadows ReadOnly Property ApproveWFVisible() As Boolean
      Get
				Dim mRet As Boolean = False
        Try
					Select Case BillStatus
						Case TptBillStatus.UnderReceiveByAccounts
							mRet = True
					End Select
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public Shadows ReadOnly Property ApproveWFEnable() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
					mRet = GetEnable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public Shadows ReadOnly Property RejectWFVisible() As Boolean
      Get
				Dim mRet As Boolean = False
				Try
					Select Case BillStatus
						Case TptBillStatus.UnderPaymentProcessing, TptBillStatus.PTRCreated
							mRet = True
					End Select
				Catch ex As Exception
				End Try
        Return mRet
      End Get
    End Property
    Public Shadows ReadOnly Property RejectWFEnable() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
					mRet = GetEnable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public Shadows ReadOnly Property CompleteWFVisible() As Boolean
      Get
				Dim mRet As Boolean = False
				Try
					Select Case BillStatus
						Case TptBillStatus.UnderPaymentProcessing, TptBillStatus.PTRCreated
							mRet = True
					End Select
				Catch ex As Exception
				End Try
        Return mRet
      End Get
    End Property
    Public Shadows ReadOnly Property CompleteWFEnable() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
					mRet = GetEnable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public Shared Shadows Function ApproveWF(ByVal SerialNo As Int32) As SIS.ERP.erpProcessTPTBill
			Dim Results As SIS.ERP.erpProcessTPTBill = erpProcessTPTBillGetByID(SerialNo)
			With Results
				.RECDByAccountsOn = Now
				.RECDinAccountsBy = HttpContext.Current.Session("LoginID")
				.BillStatus = TptBillStatus.UnderPaymentProcessing
			End With
			SIS.ERP.erpCreateTPTBill.UpdateData(Results)
      Return Results
    End Function
		Public Shared Shadows Function RejectWF(ByVal SerialNo As Int32, Optional ByVal Remarks As String = "") As SIS.ERP.erpProcessTPTBill
			Dim Results As SIS.ERP.erpProcessTPTBill = erpProcessTPTBillGetByID(SerialNo)
			If Remarks = String.Empty Then
				If Results.AccountsRemarks = String.Empty Then Throw New Exception("Remarks is required when returning document.")
			End If
			With Results
				If Remarks <> String.Empty Then .AccountsRemarks = Remarks
				.DiscReturnedByACOn = Now
				.DiscReturnedinAcBy = HttpContext.Current.Session("LoginID")
				.BillStatus = TptBillStatus.UnderReceiveByLogistics
			End With
			SIS.ERP.erpCreateTPTBill.UpdateData(Results)
			Return Results
		End Function
    Public Shared Shadows Function CompleteWF(ByVal SerialNo As Int32) As SIS.ERP.erpProcessTPTBill
      Dim Results As SIS.ERP.erpProcessTPTBill = erpProcessTPTBillGetByID(SerialNo)
			With Results
				If .PTRAmount = String.Empty Or .PTRNo = String.Empty Or .PTRDate = String.Empty Or .BankVCHAmount = String.Empty Or .BankVCHDate = String.Empty Or .BankVCHNo = String.Empty Then
					Throw New Exception("All Payemnt Data NOT entered.")
				End If
				.BillStatus = TptBillStatus.PaymentProcessed
			End With
			SIS.ERP.erpCreateTPTBill.UpdateData(Results)
			Return Results
    End Function
    Public Shared Function UZ_erpProcessTPTBillSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal TPTCode As String, ByVal ProjectID As String, ByVal BillStatus As Int32) As List(Of SIS.ERP.erpProcessTPTBill)
      Dim Results As List(Of SIS.ERP.erpProcessTPTBill) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          If OrderBy = String.Empty Then OrderBy = "SerialNo DESC"
          Cmd.CommandType = CommandType.StoredProcedure
					If SearchState Then
						Cmd.CommandText = "sperp_LG_ProcessTPTBillSelectListSearch"
						Cmd.CommandText = "sperpProcessTPTBillSelectListSearch"
						SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
					Else
						Cmd.CommandText = "sperp_LG_ProcessTPTBillSelectListFilteres"
						Cmd.CommandText = "sperpProcessTPTBillSelectListFilteres"
						SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_TPTCode", SqlDbType.NVarChar, 9, IIf(TPTCode Is Nothing, String.Empty, TPTCode))
						SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_ProjectID",SqlDbType.NVarChar,6, IIf(ProjectID Is Nothing, String.Empty,ProjectID))
						SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_BillStatus",SqlDbType.Int,10, IIf(BillStatus = Nothing, 0,BillStatus))
					End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          RecordCount = -1
          Results = New List(Of SIS.ERP.erpProcessTPTBill)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.ERP.erpProcessTPTBill(Reader))
          End While
          Reader.Close()
          RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
		Public Shared Function UZ_erpProcessTPTBillUpdate(ByVal Record As SIS.ERP.erpProcessTPTBill) As SIS.ERP.erpProcessTPTBill
			Try
				If Record.NewBillStatus = TptBillStatus.Closed Then Record.BillStatus = TptBillStatus.Closed
			Catch ex As Exception
			End Try
			Dim _Result As SIS.ERP.erpProcessTPTBill = erpProcessTPTBillUpdate(Record)
			Return _Result
		End Function
  End Class
End Namespace
