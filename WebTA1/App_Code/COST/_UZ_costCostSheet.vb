Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.COST
  Partial Public Class costCostSheet
    Public Function GetColor() As System.Drawing.Color
      Dim mRet As System.Drawing.Color = Drawing.Color.Black
      Select Case StatusID
        Case CostSheetStates.Returned
          mRet = Drawing.Color.Red
        Case CostSheetStates.Checked
          mRet = Drawing.Color.Green
        Case CostSheetStates.UnderApproval
          mRet = Drawing.Color.DarkOrchid
        Case CostSheetStates.Released
          mRet = Drawing.Color.Gold
        Case CostSheetStates.Superseded
          mRet = Drawing.Color.Coral
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
      Dim mRet As Boolean = False
      Try
        Select Case _StatusID
          Case CostSheetStates.Free, CostSheetStates.Returned, CostSheetStates.Checked
            mRet = True
        End Select
      Catch ex As Exception
      End Try
      Return mRet
    End Function
    Public ReadOnly Property Editable() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetEditable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property Deleteable() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetEditable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property DownloadWFVisible() As Boolean
      Get
        Dim mRet As Boolean = False
        Try
          Select Case _StatusID
            Case CostSheetStates.Free, CostSheetStates.Returned
              mRet = True
          End Select
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property DownloadWFEnable() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetEnable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public Shared Function DownloadWF(ByVal ProjectGroupID As Int32, ByVal FinYear As Int32, ByVal Quarter As Int32, ByVal Revision As Int32) As SIS.COST.costCostSheet
      Dim Results As SIS.COST.costCostSheet = costCostSheetGetByID(ProjectGroupID, FinYear, Quarter, Revision)
      If Not Results.LockERPData Then
        SIS.COST.costCostSheetData.costCostSheetDataFromERPLN(ProjectGroupID, FinYear, Quarter, Revision)
        SIS.COST.costCostSheetLiability.costCostSheetLiabilityFromERPLN(ProjectGroupID, FinYear, Quarter, Revision)
      End If
      Return Results
    End Function
    Public ReadOnly Property UpdateWFVisible() As Boolean
      Get
        Dim mRet As Boolean = False
        Try
          Select Case _StatusID
            Case CostSheetStates.Free, CostSheetStates.Returned
              mRet = True
          End Select
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property UpdateWFEnable() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetEnable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public Shared Function UpdateWF(ByVal ProjectGroupID As Int32, ByVal FinYear As Int32, ByVal Quarter As Int32, ByVal Revision As Int32) As SIS.COST.costCostSheet
      Dim Results As SIS.COST.costCostSheet = costCostSheetGetByID(ProjectGroupID, FinYear, Quarter, Revision)
      Results.LockERPData = True
      Results = SIS.COST.costCostSheet.UZ_costCostSheetUpdate(Results)
      Return Results
    End Function
    Public ReadOnly Property InitiateWFVisible() As Boolean
      Get
        Dim mRet As Boolean = False
        Try
          Select Case _StatusID
            Case CostSheetStates.Checked
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
    Public Shared Function InitiateWF(ByVal ProjectGroupID As Int32, ByVal FinYear As Int32, ByVal Quarter As Int32, ByVal Revision As Int32) As SIS.COST.costCostSheet
      Dim Results As SIS.COST.costCostSheet = costCostSheetGetByID(ProjectGroupID, FinYear, Quarter, Revision)
      With Results
        .StatusID = CostSheetStates.UnderApproval
      End With
      SIS.COST.costCostSheet.UpdateData(Results)
      Return Results
    End Function
    Public Shared Function UZ_costCostSheetSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal ProjectGroupID As Int32) As List(Of SIS.COST.costCostSheet)
      Dim Results As List(Of SIS.COST.costCostSheet) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "spcost_LG_CostSheetSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "spcost_LG_CostSheetSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_ProjectGroupID", SqlDbType.Int, 10, IIf(ProjectGroupID = Nothing, 0, ProjectGroupID))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.COST.costCostSheet)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.COST.costCostSheet(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function costCostSheetSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String, ByVal ProjectGroupID As Int32) As Integer
      Return _RecordCount
    End Function
    Public Shared Function UZ_costCostSheetSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal ProjectGroupID As Int32, ByVal FinYear As Int32, ByVal Quarter As Int32, ByVal StatusID As Int32, ByVal CreatedBy As String) As List(Of SIS.COST.costCostSheet)
      Dim Results As List(Of SIS.COST.costCostSheet) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "spcost_LG_CostSheetSelectListSearch"
            Cmd.CommandText = "spcostCostSheetSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "spcost_LG_CostSheetSelectListFilteres"
            Cmd.CommandText = "spcostCostSheetSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_ProjectGroupID", SqlDbType.Int, 10, IIf(ProjectGroupID = Nothing, 0, ProjectGroupID))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_FinYear", SqlDbType.Int, 10, IIf(FinYear = Nothing, 0, FinYear))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_Quarter", SqlDbType.Int, 10, IIf(Quarter = Nothing, 0, Quarter))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_StatusID", SqlDbType.Int, 10, IIf(StatusID = Nothing, 0, StatusID))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_CreatedBy", SqlDbType.NVarChar, 8, IIf(CreatedBy Is Nothing, String.Empty, CreatedBy))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.COST.costCostSheet)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.COST.costCostSheet(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function UZ_costCostSheetInsert(ByVal Record As SIS.COST.costCostSheet) As SIS.COST.costCostSheet
      Dim _Result As SIS.COST.costCostSheet = costCostSheetInsert(Record)
      Return _Result
    End Function
    Public Shared Function UZ_costCostSheetUpdate(ByVal Record As SIS.COST.costCostSheet) As SIS.COST.costCostSheet
      If Not Record.LockERPData Then
        If Record.StatusID = CostSheetStates.Checked Then
          Record.StatusID = CostSheetStates.Free
        End If
      Else
        Record.StatusID = CostSheetStates.Checked
        Record.ApproverRemarks = "Checked By: " & HttpContext.Current.Session("LoginID") & " On: " & Now
      End If
      Dim _Result As SIS.COST.costCostSheet = costCostSheetUpdate(Record)
      Return _Result
    End Function
    Public Shared Function UZ_costCostSheetDelete(ByVal Record As SIS.COST.costCostSheet) As Integer
      Dim _Result as Integer = costCostSheetDelete(Record)
      Return _Result
    End Function
    Public Shared Function SetDefaultValues(ByVal sender As System.Web.UI.WebControls.FormView, ByVal e As System.EventArgs) As System.Web.UI.WebControls.FormView
      With sender
        Try
        CType(.FindControl("F_ProjectGroupID"), TextBox).Text = ""
        CType(.FindControl("F_ProjectGroupID_Display"), Label).Text = ""
        CType(.FindControl("F_FinYear"), TextBox).Text = ""
        CType(.FindControl("F_FinYear_Display"), Label).Text = ""
        CType(.FindControl("F_Quarter"), TextBox).Text = ""
        CType(.FindControl("F_Quarter_Display"), Label).Text = ""
        CType(.FindControl("F_Revision"), TextBox).Text = 0
        CType(.FindControl("F_AutoUpdateERPData"), CheckBox).Checked = False
        CType(.FindControl("F_LockERPData"), CheckBox).Checked = False
        CType(.FindControl("F_LockAdjustmentEntry"), CheckBox).Checked = False
        CType(.FindControl("F_Remarks"), TextBox).Text = ""
        Catch ex As Exception
        End Try
      End With
      Return sender
    End Function
    Public Shared Function getcsLastYears(ByVal ProjectGroupID As Int32, ByVal FinYear As Int32, ByVal Quarter As Int32, ByVal Revision As Int32) As List(Of SIS.COST.costCostSheet)
      Dim Results As List(Of SIS.COST.costCostSheet) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spcost_LG_getcsLastYears"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ProjectGroupID", SqlDbType.Int, 10, IIf(ProjectGroupID = Nothing, 0, ProjectGroupID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FinYear", SqlDbType.Int, 10, IIf(FinYear = Nothing, 0, FinYear))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Quarter", SqlDbType.Int, 10, IIf(FinYear = Nothing, 0, Quarter))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Revision", SqlDbType.Int, 10, IIf(FinYear = Nothing, 0, Revision))
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.COST.costCostSheet)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.COST.costCostSheet(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
  End Class
End Namespace
