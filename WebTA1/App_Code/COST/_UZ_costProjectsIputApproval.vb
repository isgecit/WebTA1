Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.COST
  Partial Public Class costProjectsIputApproval
    Public ReadOnly Property ApproveWFVisible() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetVisible()
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
        Dim mRet As Boolean = True
        Try
          mRet = GetVisible()
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
    Public Shared Function ApproveWF(ByVal ProjectGroupID As Int32, ByVal FinYear As Int32, ByVal Quarter As Int32, ByVal ApproverRemarks As String) As SIS.COST.costProjectsIputApproval
      Dim Results As SIS.COST.costProjectsIputApproval = costProjectsIputApprovalGetByID(ProjectGroupID, FinYear, Quarter)
      With Results
        .ApprovedBy = HttpContext.Current.Session("LoginID")
        .ApprovedOn = Now
        .StatusID = InputStates.SubmittedToAccounts
        .ApproverRemarks = ApproverRemarks
      End With
      Results = SIS.COST.costProjectsIputApproval.UpdateData(Results)
      Return Results
    End Function
    Public Shared Function RejectWF(ByVal ProjectGroupID As Int32, ByVal FinYear As Int32, ByVal Quarter As Int32, ByVal ApproverRemarks As String) As SIS.COST.costProjectsIputApproval
      Dim Results As SIS.COST.costProjectsIputApproval = costProjectsIputApprovalGetByID(ProjectGroupID, FinYear, Quarter)
      With Results
        .ApprovedBy = HttpContext.Current.Session("LoginID")
        .ApprovedOn = Now
        .StatusID = InputStates.Returned
        .ApproverRemarks = ApproverRemarks
      End With
      Results = SIS.COST.costProjectsIputApproval.UpdateData(Results)
      Return Results
    End Function
    Public Shared Function UZ_costProjectsIputApprovalSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal ProjectGroupID As Int32, ByVal FinYear As Int32, ByVal Quarter As Int32) As List(Of SIS.COST.costProjectsIputApproval)
      Dim Results As List(Of SIS.COST.costProjectsIputApproval) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "spcost_LG_ProjectsIputApprovalSelectListSearch"
            Cmd.CommandText = "spcostProjectsIputApprovalSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "spcost_LG_ProjectsIputApprovalSelectListFilteres"
            Cmd.CommandText = "spcostProjectsIputApprovalSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_ProjectGroupID",SqlDbType.Int,10, IIf(ProjectGroupID = Nothing, 0,ProjectGroupID))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_FinYear",SqlDbType.Int,10, IIf(FinYear = Nothing, 0,FinYear))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_Quarter",SqlDbType.Int,10, IIf(Quarter = Nothing, 0,Quarter))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StatusID",SqlDbType.Int,10, "2")
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          RecordCount = -1
          Results = New List(Of SIS.COST.costProjectsIputApproval)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.COST.costProjectsIputApproval(Reader))
          End While
          Reader.Close()
          RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
  End Class
End Namespace
