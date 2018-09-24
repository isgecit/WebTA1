Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Imports System.Net.Mail
Imports System.Web.Mail

Namespace SIS.QCM
  <DataObject()>
  Public Class POList
    Public Property PONo As String = ""
    Public Property Selected As Boolean = False
    Public Property IsClosed As Boolean = False
    Public Property ProjectID As String = ""
    Public ReadOnly Property Editable As Boolean
      Get
        Return Not IsClosed
      End Get
    End Property
    Public Shared Function GetSelected(ByVal Objs As List(Of SIS.QCM.POList)) As String
      Dim str As String = ""
      For Each obj As SIS.QCM.POList In Objs
        If obj.Selected Then
          If str = "" Then
            str = obj.PONo
          Else
            str &= "," & obj.PONo
          End If
        End If
      Next
      Return str
    End Function
    Public Shared Function UpdateSelected(ByVal POs As String, ByVal Objs As List(Of SIS.QCM.POList)) As List(Of SIS.QCM.POList)
      'Initialize
      For Each obj As SIS.QCM.POList In Objs
        obj.Selected = False
      Next
      Dim aPOs() As String = POs.Split(",".ToCharArray)
      For Each po As String In aPOs
        If po <> "" Then
          Dim Found As Boolean = False
          For Each obj As SIS.QCM.POList In Objs
            If obj.PONo = po Then
              obj.Selected = True
              Found = True
              Exit For
            End If
          Next
          If Not Found Then
            Dim tmp As New SIS.QCM.POList
            tmp.PONo = po
            tmp.Selected = True
            tmp.IsClosed = True
            Objs.Add(tmp)
          End If
        End If
      Next
      Return Objs
    End Function
    Public Shared Function GetIssuedOPENPoToSupplier(ByVal SupplierID As String) As List(Of SIS.QCM.POList)
      Dim tmpPakPOs As New List(Of SIS.PAK.pakPO)
      If SupplierID <> "" Then
        tmpPakPOs = SIS.PAK.pakPO.UZ_pakPOSelectList(0, 99999, "", False, "", 0, SupplierID, "", "", 0, "")
      End If
      Dim xs As New List(Of SIS.QCM.POList)
      For Each tmp As SIS.PAK.pakPO In tmpPakPOs
        Dim x As New SIS.QCM.POList
        x.PONo = tmp.PONumber
        x.ProjectID = tmp.ProjectID
        xs.Add(x)
      Next
      Return xs
    End Function
    Public Shared Function POListDatasource(ByVal SupplierID As String, ByVal POs As String) As List(Of SIS.QCM.POList)
      If POs Is Nothing Then POs = ""
      Dim tmp As New List(Of SIS.QCM.POList)
      tmp = SIS.QCM.POList.GetIssuedOPENPoToSupplier(SupplierID)
      tmp = SIS.QCM.POList.UpdateSelected(POs, tmp)
      Return tmp
    End Function
    Sub New()
      'Dummy
    End Sub
  End Class
  Partial Public Class qcmRequests
    Public Shared Function qcmSRequestsToBeAttended(ByVal SupplierID As String) As List(Of SIS.QCM.qcmRequests)
      Dim Results As List(Of SIS.QCM.qcmRequests) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spqcm_LG_SRequestsToBeAttended"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SupplierID", SqlDbType.NVarChar, 9, SupplierID)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.QCM.qcmRequests)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.QCM.qcmRequests(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function

    Public Shared Function qcmRequestsToBeAttended(ByVal SupplierID As String) As List(Of SIS.QCM.qcmRequests)
      Dim Results As List(Of SIS.QCM.qcmRequests) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spqcm_LG_RequestsToBeAttended"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SupplierID", SqlDbType.NVarChar, 9, SupplierID)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.QCM.qcmRequests)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.QCM.qcmRequests(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function

    Public Shared Function GetLastRequest(ByVal SupplierID As String) As SIS.QCM.qcmRequests
      Dim Results As SIS.QCM.qcmRequests = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spqcm_LG_GetLastRequest"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SupplierID", SqlDbType.NVarChar, 9, SupplierID)
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.QCM.qcmRequests(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function

    Public ReadOnly Property NewTotalQuantity As String
      Get
        Dim mRet As String = "0.00"
        If IsNumeric(TotalRequestedQuantity) Then
          If IsNumeric(LotSize) Then
            mRet = Convert.ToDecimal(TotalRequestedQuantity) + Convert.ToDecimal(LotSize)
          Else
            mRet = Convert.ToDecimal(TotalRequestedQuantity)
          End If
        Else
          mRet = TotalRequestedQuantity
        End If
        Return mRet
      End Get
    End Property
    Public Function GetColor() As System.Drawing.Color
      Dim mRet As System.Drawing.Color = Drawing.Color.Blue
      Select Case _RequestStateID
        Case "OPEN"
          mRet = Drawing.Color.Blue
        Case "UNDERALLOT"
          mRet = Drawing.Color.Red
        Case "ALLOTED", "REALLOTED"
          mRet = Drawing.Color.Green
        Case "INSPECTED"
          mRet = Drawing.Color.BlueViolet
        Case "CLOSED"
          mRet = Drawing.Color.Orange
        Case "CANCELLED"
          mRet = Drawing.Color.Brown
        Case "RETURNED"
          mRet = Drawing.Color.Black
      End Select
      Return mRet
    End Function
    Public ReadOnly Property AllotmentDetails As String
      Get
        Dim mRet As String = ""
        Select Case _RequestStateID
          Case "ALLOTED", "REALLOTED", "INSPECTED", "CLOSED"
            mRet = "<b>Alloted To: </b>" & Me.HRM_Employees2_EmployeeName & ", <b>From : </b>" & Me.AllotedStartDate & " <b>To : </b>" & Me.AllotedFinishDate
        End Select
        Return mRet
      End Get
    End Property
    Public ReadOnly Property ReturnDetails As String
      Get
        Dim mRet As String = ""
        Select Case _RequestStateID
          Case "RETURNED"
            mRet = "<img alt='warning' src='../../images/Error.gif' style='height:14px; width:14px' /><b>" & Me.ReturnRemarks & "</b>"
        End Select
        Return mRet
      End Get
    End Property
    Public Function GetVisible() As Boolean
      Dim mRet As Boolean = True
      Return mRet
    End Function
    Public Function GetEnable() As Boolean
      Dim mRet As Boolean = True
      Return mRet
    End Function
    Public Shared Function UZ_qcmRequestsInsert(ByVal Record As SIS.QCM.qcmRequests) As SIS.QCM.qcmRequests
      Dim _Result As SIS.QCM.qcmRequests = qcmRequestsInsert(Record)
      Return _Result
    End Function
    Public Shared Function UZ_qcmRequestsUpdate(ByVal Record As SIS.QCM.qcmRequests) As SIS.QCM.qcmRequests
      Dim aPOs() As String = Record.OrderNo.Split(",".ToCharArray)
      If aPOs.Length > 0 Then
        Dim x As SIS.PAK.pakPO = SIS.PAK.pakPO.pakPOGetByPONo(aPOs(0))
        Record.ProjectID = x.ProjectID
      End If
      Dim _Result As SIS.QCM.qcmRequests = qcmRequestsUpdate(Record)
      Return _Result
    End Function
    Public Shared Function UZ_qcmRequestsDelete(ByVal Record As SIS.QCM.qcmRequests) As Integer
      Dim _Result As Integer = qcmRequests.qcmRequestsDelete(Record)
      Return _Result
    End Function
    Public ReadOnly Property ForwardVisible() As Boolean
      Get
        Select Case RequestStateID
          Case "OPEN", "RETURNED"
            Return True
        End Select
        Return False
      End Get
    End Property
    Public Shared Function ForwardForAllotment(ByVal RequestID As Integer) As Boolean
      Dim oReq As SIS.QCM.qcmRequests = SIS.QCM.qcmRequests.qcmRequestsGetByID(RequestID)
      With oReq
        If Convert.ToDateTime(oReq.RequestedInspectionStartDate).Date <= Now.Date Then
          Throw New Exception("Can NOT forward Inspenction request for today or earlier date. Pl. change requested date, then forward")
        ElseIf Now.Hour > 11 Then
          If Convert.ToDateTime(oReq.RequestedInspectionStartDate).Date <= Now.AddDays(1).Date Then
            Throw New Exception("After 11 AM, you can raise Inspection request for day after tomorrow only. Pl. change requested date, then forward.")
          End If
        End If
        .ReturnRemarks = ""
        .CreatedOn = Now
        .RequestStateID = "UNDERALLOT"
      End With
      Try
        SIS.QCM.qcmRequests.UpdateData(oReq)
      Catch ex As Exception
        Return False
      End Try
      Return True
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)>
    Public Shared Function UZ_qcmRequestsBySupplierSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal ProjectID As String) As List(Of SIS.QCM.qcmRequests)
      Dim Results As List(Of SIS.QCM.qcmRequests) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          If OrderBy = String.Empty Then OrderBy = "RequestID DESC"
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spqcm_LG_RequestsBySupplierSelectList"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SearchState", SqlDbType.Bit, 3, SearchState)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ProjectID", SqlDbType.NVarChar, 6, IIf(ProjectID Is Nothing, String.Empty, ProjectID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.QCM.qcmRequests)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.QCM.qcmRequests(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function UZ_qcmRequestsBySupplierSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String, ByVal ProjectID As String) As Integer
      Return _RecordCount
    End Function

  End Class
End Namespace
