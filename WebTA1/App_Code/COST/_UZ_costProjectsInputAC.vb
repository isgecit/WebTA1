Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.COST
  Partial Public Class costProjectsInputAC
    Public Shadows Function GetEditable() As Boolean
      Dim mRet As Boolean = False
      Select Case StatusID
        Case InputStates.SubmittedToAccounts, InputStates.FreezedForCostSheet
          mRet = True
      End Select
      Return mRet
    End Function
    Public Shadows ReadOnly Property Deleteable() As Boolean
      Get
        Return False
      End Get
    End Property

    Public Shared Function UZ_costProjectsInputACSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal ProjectGroupID As Int32, ByVal FinYear As Int32, ByVal Quarter As Int32, Optional ByVal RevisionNo As Int32 = 0) As List(Of SIS.COST.costProjectsInputAC)
      Return UZ_costProjectsInputACSelectList(StartRowIndex, MaximumRows, OrderBy, SearchState, SearchText, ProjectGroupID, FinYear, Quarter)
    End Function
    Public Shared Function UZ_costProjectsInputACSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal ProjectGroupID As Int32, ByVal FinYear As Int32, ByVal Quarter As Int32) As List(Of SIS.COST.costProjectsInputAC)
      Dim Results As List(Of SIS.COST.costProjectsInputAC) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "spcost_LG_ProjectsInputACSelectListSearch"
            'Cmd.CommandText = "spcostProjectsInputACSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "spcost_LG_ProjectsInputACSelectListFilteres"
            'Cmd.CommandText = "spcostProjectsInputACSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_ProjectGroupID", SqlDbType.Int, 10, IIf(ProjectGroupID = Nothing, 0, ProjectGroupID))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_FinYear", SqlDbType.Int, 10, IIf(FinYear = Nothing, 0, FinYear))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_Quarter", SqlDbType.Int, 10, IIf(Quarter = Nothing, 0, Quarter))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          RecordCount = -1
          Results = New List(Of SIS.COST.costProjectsInputAC)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.COST.costProjectsInputAC(Reader))
          End While
          Reader.Close()
          RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function UZ_costProjectsInputACUpdate(ByVal Record As SIS.COST.costProjectsInputAC) As SIS.COST.costProjectsInputAC
      With Record
        .ProjectMarginByACINR = .ProjectMarginByAC * .CFforPRByAC
        .ProjectRevenueByACINR = .ProjectRevenueByAC * .CFforPRByAC
        .ExportIncentiveByACINR = .ExportIncentiveByAC * .CFforPRByAC
      End With
      Dim _Result As SIS.COST.costProjectsInputAC = costProjectsInputACUpdate(Record)
      Return _Result
    End Function
  End Class
End Namespace
