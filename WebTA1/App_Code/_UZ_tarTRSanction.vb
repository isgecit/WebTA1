Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.TAR
  Partial Public Class tarTRSanction
    Public Shadows Function GetEditable() As Boolean
      Dim mRet As Boolean = False
      Select Case StatusID
        Case TARequestStates.UnderApprovalByBH
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
    Public Shared Function BudgetWF(ByVal RequestID As Int32, ByVal BHRemarks As String) As SIS.TAR.tarTRSanction
      Dim Results As SIS.TAR.tarTRSanction = tarTRSanctionGetByID(RequestID)
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
    Public Shared Shadows Function ApproveWF(ByVal RequestID As Int32, ByVal BHRemarks As String) As SIS.TAR.tarTRSanction
      Dim Results As SIS.TAR.tarTRSanction = tarTRSanctionGetByID(RequestID)
      With Results
        .BHApprovalBy = HttpContext.Current.Session("LoginID")
        .BHApprovalOn = Now
        .BHRemarks = BHRemarks
        Select Case .TravelTypeID
          Case TATravelTypeValues.Domestic, TATravelTypeValues.HomeVisit
            .StatusID = TARequestStates.Approved
          Case Else
            .StatusID = TARequestStates.UnderMDApproval
        End Select
      End With
      Results = SIS.TAR.tarTravelRequest.UpdateData(Results)
      Return Results
    End Function
    Public Shared Function RejectWF(ByVal RequestID As Int32, ByVal BHRemarks As String) As SIS.TAR.tarTRSanction
      Dim Results As SIS.TAR.tarTRSanction = tarTRSanctionGetByID(RequestID)
      With Results
        .BHApprovalBy = HttpContext.Current.Session("LoginID")
        .BHApprovalOn = Now
        .BHRemarks = BHRemarks
        .StatusID = TARequestStates.ReturnedFromBH
      End With
      Results = SIS.TAR.tarTravelRequest.UpdateData(Results)
      Return Results
    End Function
    Public Shared Function UZ_tarTRSanctionSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal ProjectID As String, ByVal CreatedBy As String) As List(Of SIS.TAR.tarTRSanction)
      Dim Results As List(Of SIS.TAR.tarTRSanction) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          If OrderBy = String.Empty Then OrderBy = "RequestID DESC"
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "sptar_LG_TRSanctionSelectListSearch"
            Cmd.CommandText = "sptarTRSanctionSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "sptar_LG_TRSanctionSelectListFilteres"
            Cmd.CommandText = "sptarTRSanctionSelectListFilteres"
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
          Results = New List(Of SIS.TAR.tarTRSanction)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.TAR.tarTRSanction(Reader))
          End While
          Reader.Close()
          RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function UZ_tarTRSanctionUpdate(ByVal Record As SIS.TAR.tarTRSanction) As SIS.TAR.tarTRSanction
      Dim _Result As SIS.TAR.tarTRSanction = tarTRSanctionUpdate(Record)
      Return _Result
    End Function
  End Class
End Namespace
