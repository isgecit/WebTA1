Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.TAR
  Partial Public Class tarTRSanctionByMD
    Public Shadows Function GetEditable() As Boolean
      Dim mRet As Boolean = False
      Select Case StatusID
        Case TARequestStates.UnderMDApproval
          mRet = True
      End Select
      Return mRet
    End Function
    Public Shadows Function GetDeleteable() As Boolean
      Dim mRet As Boolean = False
      Return mRet
    End Function
    Public Shadows ReadOnly Property Editable() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetEditable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public Shadows ReadOnly Property Deleteable() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetDeleteable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property BudgetWFVisible() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetVisible()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property BudgetWFEnable() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetEnable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public Shared Function BudgetWF(ByVal RequestID As Int32, ByVal MDRemarks As String) As SIS.TAR.tarTRSanctionByMD
      Dim Results As SIS.TAR.tarTRSanctionByMD = tarTRSanctionByMDGetByID(RequestID)
      Return Results
    End Function
    Public Shadows ReadOnly Property ApproveWFVisible() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetEditable()
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
    Public ReadOnly Property RejectWFVisible() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetEditable()
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
    Public Shared Shadows Function ApproveWF(ByVal RequestID As Int32, ByVal MDRemarks As String) As SIS.TAR.tarTRSanctionByMD
      Dim Results As SIS.TAR.tarTRSanctionByMD = tarTRSanctionByMDGetByID(RequestID)
      With Results
        .MDApprovalBy = HttpContext.Current.Session("LoginID")
        .MDApprovalOn = Now
        .MDRemarks = MDRemarks
        .StatusID = TARequestStates.Approved
      End With
      Results = SIS.TAR.tarTravelRequest.UpdateData(Results)
      Return Results
    End Function
    Public Shared Function RejectWF(ByVal RequestID As Int32, ByVal MDRemarks As String) As SIS.TAR.tarTRSanctionByMD
      Dim Results As SIS.TAR.tarTRSanctionByMD = tarTRSanctionByMDGetByID(RequestID)
      With Results
        .MDApprovalBy = HttpContext.Current.Session("LoginID")
        .MDApprovalOn = Now
        .MDRemarks = MDRemarks
        .StatusID = TARequestStates.ReturnedFromMD
      End With
      Results = SIS.TAR.tarTravelRequest.UpdateData(Results)
      Return Results
    End Function
    Public Shared Function UZ_tarTRSanctionByMDSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal ProjectID As String, ByVal CreatedBy As String) As List(Of SIS.TAR.tarTRSanctionByMD)
      Dim Results As List(Of SIS.TAR.tarTRSanctionByMD) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          If OrderBy = String.Empty Then OrderBy = "RequestID DESC"
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "sptar_LG_TRSanctionByMDSelectListSearch"
            Cmd.CommandText = "sptarTRSanctionByMDSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "sptar_LG_TRSanctionByMDSelectListFilteres"
            Cmd.CommandText = "sptarTRSanctionByMDSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_ProjectID",SqlDbType.NVarChar,6, IIf(ProjectID Is Nothing, String.Empty,ProjectID))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_CreatedBy",SqlDbType.NVarChar,8, IIf(CreatedBy Is Nothing, String.Empty,CreatedBy))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          RecordCount = -1
          Results = New List(Of SIS.TAR.tarTRSanctionByMD)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.TAR.tarTRSanctionByMD(Reader))
          End While
          Reader.Close()
          RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function UZ_tarTRSanctionByMDUpdate(ByVal Record As SIS.TAR.tarTRSanctionByMD) As SIS.TAR.tarTRSanctionByMD
      Dim _Result As SIS.TAR.tarTRSanctionByMD = tarTRSanctionByMDUpdate(Record)
      Return _Result
    End Function
  End Class
End Namespace
