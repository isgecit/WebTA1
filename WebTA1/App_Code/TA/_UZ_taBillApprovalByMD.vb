Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.TA
  Partial Public Class taBillApprovalByMD
    Public ReadOnly Property ApproveWFVisible() As Boolean
      Get
        Dim mRet As Boolean = False
        Try
          Select Case BillStatusID
            Case TAStates.UnderSpecialSanction
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
          Select Case BillStatusID
            Case TAStates.UnderSpecialSanction
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
    Public Shared Function ApproveWF(ByVal TABillNo As Int32, ByVal SARemarks As String) As SIS.TA.taBillApprovalByMD
      Dim Results As SIS.TA.taBillApprovalByMD = taBillApprovalByMDGetByID(TABillNo)
      With Results
        .ApprovedBySA = HttpContext.Current.Session("LoginID")
        .ApprovedBySAOn = Now
        .SARemarks = SARemarks
        .BillStatusID = TAStates.UnderReceiveByAccounts
      End With
      Results = SIS.TA.taBH.UpdateData(Results)
      Return Results
      Try
        SendEMail(Results)
      Catch ex As Exception
      End Try
    End Function
    Public Shared Function RejectWF(ByVal TABillNo As Int32, ByVal SARemarks As String) As SIS.TA.taBillApprovalByMD
      Dim Results As SIS.TA.taBillApprovalByMD = taBillApprovalByMDGetByID(TABillNo)
      With Results
        .ApprovedBySA = HttpContext.Current.Session("LoginID")
        .ApprovedBySAOn = Now
        .SARemarks = SARemarks
        .BillStatusID = TAStates.ReturnedBySanctioningAuthority
      End With
      Results = SIS.TA.taBH.UpdateData(Results)
      Return Results
    End Function
    Public Shared Function UZ_taBillApprovalByMDSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal TABillNo As Int32, ByVal TravelTypeID As Int32, ByVal DestinationCity As String, ByVal ProjectID As String, ByVal EmployeeID As String, ByVal BillStatusID As Int32) As List(Of SIS.TA.taBillApprovalByMD)
      Dim Results As List(Of SIS.TA.taBillApprovalByMD) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          If OrderBy = String.Empty Then OrderBy = "TABillNo DESC"
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "spta_LG_BillApprovalByMDSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "spta_LG_BillApprovalByMDSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_TABillNo",SqlDbType.Int,10, IIf(TABillNo = Nothing, 0,TABillNo))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_TravelTypeID",SqlDbType.Int,10, IIf(TravelTypeID = Nothing, 0,TravelTypeID))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_DestinationCity",SqlDbType.NVarChar,30, IIf(DestinationCity Is Nothing, String.Empty,DestinationCity))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_ProjectID",SqlDbType.NVarChar,6, IIf(ProjectID Is Nothing, String.Empty,ProjectID))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_EmployeeID",SqlDbType.NVarChar,8, IIf(EmployeeID Is Nothing, String.Empty,EmployeeID))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_BillStatusID",SqlDbType.Int,10, IIf(BillStatusID = Nothing, 0,BillStatusID))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          RecordCount = -1
          Results = New List(Of SIS.TA.taBillApprovalByMD)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.TA.taBillApprovalByMD(Reader))
          End While
          Reader.Close()
          RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function UZ_taBillApprovalByMDUpdate(ByVal Record As SIS.TA.taBillApprovalByMD) As SIS.TA.taBillApprovalByMD
      Dim _Result As SIS.TA.taBillApprovalByMD = taBillApprovalByMDUpdate(Record)
      Return _Result
    End Function
  End Class
End Namespace
