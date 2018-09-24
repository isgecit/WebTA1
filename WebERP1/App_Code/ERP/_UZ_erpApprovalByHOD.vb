Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.ERP
  Partial Public Class erpApprovalByHOD
		Public ReadOnly Property ApproveWFVisible() As Boolean
			Get
				Dim mRet As Boolean = False
				Try
					If StatusID = 4 Then
						mRet = True
					End If
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
					If StatusID = 4 Then
						mRet = True
					End If
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
		Public Shared Function ApproveWF(ByVal ApplID As Int32, ByVal RequestID As Int32, ByVal ReturnRemarks As String) As SIS.ERP.erpApprovalByHOD
			Dim Results As SIS.ERP.erpApprovalByHOD = erpApprovalByHODGetByID(ApplID, RequestID)
			Results.ReturnRemarks = ReturnRemarks
			Results.StatusID = 5
			Results.ApprovedOn = Now
			Results = SIS.ERP.erpChaneRequest.UpdateData(Results)
			SendEMail(Results, 3)
			Return Results
		End Function
		Public Shared Function RejectWF(ByVal ApplID As Int32, ByVal RequestID As Int32, ByVal ReturnRemarks As String) As SIS.ERP.erpApprovalByHOD
			Dim Results As SIS.ERP.erpApprovalByHOD = erpApprovalByHODGetByID(ApplID, RequestID)
			Results.ReturnRemarks = ReturnRemarks
			Results.StatusID = 2
			Results.ApprovedOn = Now
			Results = SIS.ERP.erpChaneRequest.UpdateData(Results)
			SendEMail(Results, 2)
			Return Results
		End Function
		Public Shared Function UZ_erpApprovalByHODSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal ApplID As Int32, ByVal RequestedBy As String, ByVal RequestTypeID As Int32, ByVal StatusID As Int32, ByVal PriorityID As Int32) As List(Of SIS.ERP.erpApprovalByHOD)
			Dim Results As List(Of SIS.ERP.erpApprovalByHOD) = Nothing
			Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
				Using Cmd As SqlCommand = Con.CreateCommand()
					If OrderBy = String.Empty Then OrderBy = "RequestID DESC"
					Cmd.CommandType = CommandType.StoredProcedure
					If SearchState Then
						Cmd.CommandText = "sperpApprovalByHODSelectListSearch"
						SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
					Else
						Cmd.CommandText = "sperpApprovalByHODSelectListFilteres"
						SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_ApplID", SqlDbType.Int, 10, IIf(ApplID = Nothing, 0, ApplID))
						SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_RequestedBy", SqlDbType.NVarChar, 8, IIf(RequestedBy Is Nothing, String.Empty, RequestedBy))
						SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_RequestTypeID", SqlDbType.Int, 10, IIf(RequestTypeID = Nothing, 0, RequestTypeID))
						SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_StatusID", SqlDbType.Int, 10, IIf(StatusID = Nothing, 0, StatusID))
						SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_PriorityID", SqlDbType.Int, 10, IIf(PriorityID = Nothing, 0, PriorityID))
					End If
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, HttpContext.Current.Session("LoginID"))
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StatusID", SqlDbType.Int, 10, 4)
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ApprovedBy", SqlDbType.NVarChar, 8, Global.System.Web.HttpContext.Current.Session("LoginID"))
					Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
					Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
					RecordCount = -1
					Results = New List(Of SIS.ERP.erpApprovalByHOD)()
					Con.Open()
					Dim Reader As SqlDataReader = Cmd.ExecuteReader()
					While (Reader.Read())
						Results.Add(New SIS.ERP.erpApprovalByHOD(Reader))
					End While
					Reader.Close()
					RecordCount = Cmd.Parameters("@RecordCount").Value
				End Using
			End Using
			Return Results
		End Function
  End Class
End Namespace
