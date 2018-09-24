Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.COST
  Partial Public Class costProjectsInput
    Public Function GetColor() As System.Drawing.Color
      Dim mRet As System.Drawing.Color = Drawing.Color.Black
      Select Case StatusID
        Case InputStates.Returned
          mRet = Drawing.Color.Red
        Case InputStates.UnderApproval
          mRet = Drawing.Color.Green
        Case InputStates.SubmittedToAccounts
          mRet = Drawing.Color.DarkGoldenrod
        Case InputStates.FreezedForCostSheet
          mRet = Drawing.Color.DarkOrchid
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
      Select Case StatusID
        Case InputStates.free, InputStates.Returned
          mRet = True
      End Select
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
    Public ReadOnly Property InitiateWFVisible() As Boolean
      Get
        Dim mRet As Boolean = False
        Select Case StatusID
          Case InputStates.free, InputStates.Returned
            mRet = True
        End Select
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
    Public Shared Function InitiateWF(ByVal ProjectGroupID As Int32, ByVal FinYear As Int32, ByVal Quarter As Int32) As SIS.COST.costProjectsInput
      Dim Results As SIS.COST.costProjectsInput = costProjectsInputGetByID(ProjectGroupID, FinYear, Quarter)
      With Results
        .CreatedBy = HttpContext.Current.Session("LoginID")
        .CreatedOn = Now
        .StatusID = InputStates.UnderApproval
      End With
      Results = SIS.COST.costProjectsInput.UpdateData(Results)
      Return Results
    End Function
    Public Shared Function UZ_costProjectsInputSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal ProjectGroupID As Int32, ByVal FinYear As Int32, ByVal Quarter As Int32) As List(Of SIS.COST.costProjectsInput)
      Dim Results As List(Of SIS.COST.costProjectsInput) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "spcost_LG_ProjectsInputSelectListSearch"
            Cmd.CommandText = "spcostProjectsInputSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "spcost_LG_ProjectsInputSelectListFilteres"
            Cmd.CommandText = "spcostProjectsInputSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_ProjectGroupID",SqlDbType.Int,10, IIf(ProjectGroupID = Nothing, 0,ProjectGroupID))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_FinYear",SqlDbType.Int,10, IIf(FinYear = Nothing, 0,FinYear))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_Quarter",SqlDbType.Int,10, IIf(Quarter = Nothing, 0,Quarter))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.COST.costProjectsInput)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.COST.costProjectsInput(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function UZ_costProjectsInputInsert(ByVal Record As SIS.COST.costProjectsInput) As SIS.COST.costProjectsInput
      With Record
        .GroupOrderValue = .FK_COST_ProjectsInput_ProjectGroupID.GroupOrderValue
        .GroupOrderValueINR = .FK_COST_ProjectsInput_ProjectGroupID.GroupOrderValueINR
        .CurrencyGOV = .FK_COST_ProjectsInput_ProjectGroupID.GroupCurrencyID
        .CFforGOV = .FK_COST_ProjectsInput_ProjectGroupID.GroupConversionFactor
        .ProjectRevenueINR = .ProjectRevenue * .CFforPR
        .ProjectMarginINR = .ProjectMargin * .CFforPR
        .ExportIncentiveINR = .ExportIncentive * .CFforPR
        .CurrencyPRByAC = .CurrencyPR
        .ProjectMarginByAC = .ProjectMargin
        .ProjectRevenueByAC = .ProjectRevenue
        .ExportIncentiveByAC = .ExportIncentive
        .CFforPRByAC = .CFforPR
        .ProjectMarginByACINR = .ProjectMarginINR
        .ProjectRevenueByACINR = .ProjectRevenueINR
        .ExportIncentiveByACINR = .ExportIncentiveINR
      End With
      Dim _Result As SIS.COST.costProjectsInput = costProjectsInputInsert(Record)
      Return _Result
    End Function
    Public Shared Function UZ_costProjectsInputUpdate(ByVal Record As SIS.COST.costProjectsInput) As SIS.COST.costProjectsInput
      With Record
        .GroupOrderValue = .FK_COST_ProjectsInput_ProjectGroupID.GroupOrderValue
        .GroupOrderValueINR = .FK_COST_ProjectsInput_ProjectGroupID.GroupOrderValueINR
        .CurrencyGOV = .FK_COST_ProjectsInput_ProjectGroupID.GroupCurrencyID
        .CFforGOV = .FK_COST_ProjectsInput_ProjectGroupID.GroupConversionFactor
        .ProjectRevenueINR = .ProjectRevenue * .CFforPR
        .ProjectMarginINR = .ProjectMargin * .CFforPR
        .ExportIncentiveINR = .ExportIncentive * .CFforPR
        .CurrencyPRByAC = .CurrencyPR
        .ProjectMarginByAC = .ProjectMargin
        .ProjectRevenueByAC = .ProjectRevenue
        .ExportIncentiveByAC = .ExportIncentive
        .CFforPRByAC = .CFforPR
        .ProjectMarginByACINR = .ProjectMarginINR
        .ProjectRevenueByACINR = .ProjectRevenueINR
        .ExportIncentiveByACINR = .ExportIncentiveINR
      End With
      Dim _Result As SIS.COST.costProjectsInput = costProjectsInputUpdate(Record)
      Return _Result
    End Function
    Public Shared Function UZ_costProjectsInputDelete(ByVal Record As SIS.COST.costProjectsInput) As Integer
      Dim _Result as Integer = costProjectsInputDelete(Record)
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
          CType(.FindControl("F_CurrencyPR"), Object).SelectedValue = "INR"
          CType(.FindControl("F_CFforPR"), TextBox).Text = "1.00"
          CType(.FindControl("F_ProjectRevenue"), TextBox).Text = 0
          CType(.FindControl("F_ProjectMargin"), TextBox).Text = 0
          CType(.FindControl("F_ExportIncentive"), TextBox).Text = 0
          CType(.FindControl("F_Remarks"), TextBox).Text = ""
        Catch ex As Exception
        End Try
      End With
      Return sender
    End Function
  End Class
End Namespace
