Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.COST
  '<asp:Button ID = "cmdGetERPData" runat="server" Text="Get ERP LN Data" OnClick="GetERPData" />
  'Protected Sub GetERPData()
  '  SIS.COST.costCostSheetLiability.costCostSheetLiabilityFromERPLN(Request.QueryString("ProjectGroupID"), Request.QueryString("FinYear"), Request.QueryString("Quarter"), Request.QueryString("Revision"))
  'End Sub

  Partial Public Class costCostSheetLiability
    Public Function GetColor() As System.Drawing.Color
      Dim mRet As System.Drawing.Color = Drawing.Color.Blue
      If AdjustmentEntry Then
        If AdjustmentCredit Then
          mRet = Drawing.Color.Green
        Else
          mRet = Drawing.Color.Red
        End If
      End If
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
      Dim mRet As Boolean = True
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
    Public Shared Function UZ_costCostSheetLiabilitySelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal ProjectGroupID As Int32, ByVal FinYear As Int32, ByVal Quarter As Int32, ByVal Revision As Int32) As List(Of SIS.COST.costCostSheetLiability)
      Dim Results As List(Of SIS.COST.costCostSheetLiability) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "spcost_LG_CostSheetLiabilitySelectListSearch"
            Cmd.CommandText = "spcostCostSheetLiabilitySelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "spcost_LG_CostSheetLiabilitySelectListFilteres"
            Cmd.CommandText = "spcostCostSheetLiabilitySelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_Quarter", SqlDbType.Int, 10, IIf(Quarter = Nothing, 0, Quarter))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_FinYear", SqlDbType.Int, 10, IIf(FinYear = Nothing, 0, FinYear))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_ProjectGroupID", SqlDbType.Int, 10, IIf(ProjectGroupID = Nothing, 0, ProjectGroupID))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_Revision", SqlDbType.Int, 10, IIf(Revision = Nothing, 0, Revision))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.COST.costCostSheetLiability)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.COST.costCostSheetLiability(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function UZ_costCostSheetLiabilityInsert(ByVal Record As SIS.COST.costCostSheetLiability) As SIS.COST.costCostSheetLiability
      Dim _Result As SIS.COST.costCostSheetLiability = costCostSheetLiabilityInsert(Record)
      Return _Result
    End Function
    Public Shared Function UZ_costCostSheetLiabilityUpdate(ByVal Record As SIS.COST.costCostSheetLiability) As SIS.COST.costCostSheetLiability
      Dim _Result As SIS.COST.costCostSheetLiability = costCostSheetLiabilityUpdate(Record)
      Return _Result
    End Function
    Public Shared Function UZ_costCostSheetLiabilityDelete(ByVal Record As SIS.COST.costCostSheetLiability) As Integer
      Dim _Result As Integer = costCostSheetLiabilityDelete(Record)
      Return _Result
    End Function
    Public Shared Function SetDefaultValues(ByVal sender As System.Web.UI.WebControls.FormView, ByVal e As System.EventArgs) As System.Web.UI.WebControls.FormView
      With sender
        Try
          CType(.FindControl("F_AdjustmentSerialNo"), TextBox).Text = 0
          CType(.FindControl("F_ProjectID"), TextBox).Text = ""
          CType(.FindControl("F_ProjectID_Display"), Label).Text = ""
          CType(.FindControl("F_GLCode"), TextBox).Text = ""
          CType(.FindControl("F_GLCode_Display"), Label).Text = ""
          CType(.FindControl("F_CrAmount"), TextBox).Text = 0
          CType(.FindControl("F_DrAmount"), TextBox).Text = 0
          CType(.FindControl("F_Amount"), TextBox).Text = 0
          CType(.FindControl("F_AdjustmentEntry"), CheckBox).Checked = False
          CType(.FindControl("F_AdjustmentCredit"), CheckBox).Checked = False
          CType(.FindControl("F_Quarter"), TextBox).Text = ""
          CType(.FindControl("F_Quarter_Display"), Label).Text = ""
          CType(.FindControl("F_FinYear"), TextBox).Text = ""
          CType(.FindControl("F_FinYear_Display"), Label).Text = ""
          CType(.FindControl("F_ProjectGroupID"), TextBox).Text = ""
          CType(.FindControl("F_ProjectGroupID_Display"), Label).Text = ""
          CType(.FindControl("F_Revision"), TextBox).Text = ""
          CType(.FindControl("F_Revision_Display"), Label).Text = ""
        Catch ex As Exception
        End Try
      End With
      Return sender
    End Function
    Public Shared Function costCostSheetLiabilityFromERPLN(ByVal ProjectGroupID As Int32, ByVal FinYear As Int32, ByVal Quarter As Int32, ByVal Revision As Int32) As List(Of SIS.COST.costCostSheetLiability)
      Dim Results As List(Of SIS.COST.costCostSheetLiability) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString)
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = "DELETE COST_CostSheetLiability WHERE AdjustmentEntry = 0 AND ProjectGroupID=" & ProjectGroupID & " AND FinYear=" & FinYear & " AND Quarter=" & Quarter & " AND Revision=" & Revision
          Con.Open()
          Cmd.ExecuteNonQuery()
        End Using
      End Using
      Dim ProjectsList As String = SIS.COST.costProjectGroups.GetProjectsOfGroup(ProjectGroupID)
      Dim PeriodList As String = SIS.COST.costQuarters.GetPeriodsForQuarter(Quarter)
      Dim Sql As String = ""
      Sql &= " Select "
      Sql &= " Dimension1 As ProjectID, "
      Sql &= " Ledger as GLCode, "
      Sql &= " sum(CreditAmount) As CrAmount, "
      Sql &= " sum(DebitAmount) As DrAmount, "
      Sql &= " sum(CreditFC) As CrFC, "
      Sql &= " sum(DebitFC) As DrFC, "
      Sql &= " FC As FC "
      Sql &= " From LN_csCostSalesLiability "
      Sql &= " Where 1 = 1 "
      Sql &= " And ((FinancialYear =  " & FinYear & " AND FInancialPeriod In " & PeriodList & ") OR (FinancialYear < " & FinYear & ")) "
      Sql &= " And Dimension1 In " & ProjectsList
      Sql &= " And TransactionType <> 'OPB'"
      Sql &= " Group BY Dimension1, Ledger, FC"
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString)
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          Results = New List(Of SIS.COST.costCostSheetLiability)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.COST.costCostSheetLiability(Reader, ProjectGroupID, FinYear, Quarter, Revision))
          End While
          Reader.Close()
        End Using
      End Using
      '===============
      Sql = " Select "
      Sql &= " Dimension1 As ProjectID, "
      Sql &= " Ledger as GLCode, "
      Sql &= " sum(CreditAmount) As CrAmount, "
      Sql &= " sum(DebitAmount) As DrAmount, "
      Sql &= " sum(CreditFC) As CrFC, "
      Sql &= " sum(DebitFC) As DrFC, "
      Sql &= " FC As FC "
      Sql &= " From LN_csWarrantyLD "
      Sql &= " Where 1 = 1 "
      Sql &= " And ((FinancialYear =  " & FinYear & " AND FInancialPeriod In " & PeriodList & ") ) "
      Sql &= " And Dimension1 In " & ProjectsList
      Sql &= " And TransactionType <> 'OPB'"
      Sql &= " Group BY Dimension1, Ledger, FC"
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString)
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.COST.costCostSheetLiability(Reader, ProjectGroupID, FinYear, Quarter, Revision))
          End While
          Reader.Close()
        End Using
      End Using
      For Each tmp As SIS.COST.costCostSheetLiability In Results
        Try
          If tmp.FC = "INR" Then
            tmp.CrFC = "0.00"
            tmp.DrFC = "0.00"
            tmp.NetFC = "0.00"
          End If
          SIS.COST.costCostSheetLiability.InsertData(tmp)
        Catch ex As Exception
          'On Violation of PK, Sum Values in existing Record
          Dim ttmp As SIS.COST.costCostSheetLiability = SIS.COST.costCostSheetLiability.costCostSheetLiabilityGetByID(tmp.ProjectGroupID, tmp.FinYear, tmp.Quarter, tmp.Revision, tmp.ProjectID, tmp.GLCode, tmp.AdjustmentSerialNo, tmp.AdjustmentCredit)
          If ttmp IsNot Nothing Then
            With ttmp
              .CrAmount = Convert.ToDecimal(.CrAmount) + Convert.ToDecimal(tmp.CrAmount)
              .DrAmount = Convert.ToDecimal(.DrAmount) + Convert.ToDecimal(tmp.DrAmount)
              .Amount = Convert.ToDecimal(.DrAmount) - Convert.ToDecimal(.CrAmount)
              .CrFC = Convert.ToDecimal(.CrFC) + Convert.ToDecimal(tmp.CrFC)
              .DrFC = Convert.ToDecimal(.DrFC) + Convert.ToDecimal(tmp.DrFC)
              .NetFC = Convert.ToDecimal(.DrFC) - Convert.ToDecimal(.CrFC)
              If ttmp.FC = "INR" Then
                ttmp.FC = tmp.FC
              End If
            End With
            SIS.COST.costCostSheetLiability.UpdateData(ttmp)
          End If
        End Try
      Next
      Return Results
    End Function
    Public Sub New(ByVal Reader As SqlDataReader, ByVal ProjectGroupID As Int32, ByVal FinYear As Int32, ByVal Quarter As Int32, ByVal Revision As Int32)
      Try
        For Each pi As System.Reflection.PropertyInfo In Me.GetType.GetProperties
          If pi.MemberType = Reflection.MemberTypes.Property Then
            Try
              If Convert.IsDBNull(Reader(pi.Name)) Then
                CallByName(Me, pi.Name, CallType.Let, String.Empty)
              Else
                CallByName(Me, pi.Name, CallType.Let, Reader(pi.Name))
              End If
            Catch ex As Exception
            End Try
          End If
        Next
        Me.ProjectGroupID = ProjectGroupID
        Me.FinYear = FinYear
        Me.Quarter = Quarter
        Me.Revision = Revision
        Me.AdjustmentSerialNo = 0
        Me.AdjustmentCredit = 0
        Me.AdjustmentEntry = False
        Try
          Me.Amount = Convert.ToDecimal(Me.DrAmount) - Convert.ToDecimal(Me.CrAmount)
        Catch ex As Exception
          Me.Amount = 0
        End Try
        Try
          Me.NetFC = Convert.ToDecimal(Me.DrFC) - Convert.ToDecimal(Me.CrFC)
        Catch ex As Exception
          Me.NetFC = 0
        End Try
      Catch ex As Exception
      End Try
    End Sub

  End Class

End Namespace
