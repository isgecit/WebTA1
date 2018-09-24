Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.COST
  '<asp:Button ID = "cmdSync" runat="server" Text=" Update from ERP-LN " />


  'Private Sub cmdSync_Click(sender As Object, e As EventArgs) Handles cmdSync.Click
  '  Dim st As Long = HttpContext.Current.Server.ScriptTimeout
  '  HttpContext.Current.Server.ScriptTimeout = Integer.MaxValue
  '  Dim FinYear As String = F_FinYear.Text
  '  Dim Quarter As String = F_Quarter.SelectedValue
  '  If FinYear <> String.Empty And Quarter <> String.Empty Then
  '    SIS.COST.costFinYearProjects.UpdateFromERP(FinYear, Quarter)
  '    GVcostFinYearProjects.DataBind()
  '  End If
  '  HttpContext.Current.Server.ScriptTimeout = st
  'End Sub

  Partial Public Class costFinYearProjects
    Public Function GetColor() As System.Drawing.Color
      Dim mRet As System.Drawing.Color = Drawing.Color.Black
      If Blocked Then
        mRet = Drawing.Color.Red
      ElseIf EntryConfirmed Then
        mRet = Drawing.Color.Green
      ElseIf IndividualGroup AndAlso CombinedGroup Then
        mRet = Drawing.Color.DarkGoldenrod
      ElseIf IndividualGroup Then
        mRet = Drawing.Color.DarkMagenta
      ElseIf CombinedGroup Then
        mRet = Drawing.Color.DarkOrchid
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
          mRet = False
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property InitiateWFVisible() As Boolean
      Get
        Dim mRet As Boolean = False
        Try
          If Not Blocked Then
            If Not EntryConfirmed Then
              If Not IndividualGroup Then
                mRet = True
              End If
            End If
          End If
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
    Public ReadOnly Property ApproveWFVisible() As Boolean
      Get
        Dim mRet As Boolean = False
        Try
          If Not Blocked Then
            If Not EntryConfirmed Then
              If Not CombinedGroup Then
                mRet = True
              End If
            End If
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
          If Not Blocked Then
            If Not IndividualGroup And Not CombinedGroup Then
              mRet = True
            End If
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
    Public ReadOnly Property CompleteWFVisible() As Boolean
      Get
        Dim mRet As Boolean = False
        Try
          If Not Blocked Then
            If Not EntryConfirmed Then
              If IndividualGroup Or CombinedGroup Then
                mRet = True
              End If
            End If
          End If
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property CompleteWFEnable() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetEnable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property

    Public Shared Function InitiateWF(ByVal FinYear As Int32, ByVal Quarter As Int32, ByVal ProjectID As String, ByVal CombinedGroupID As String) As SIS.COST.costFinYearProjects
      Dim Results As SIS.COST.costFinYearProjects = costFinYearProjectsGetByID(FinYear, Quarter, ProjectID)
      Dim pg As New SIS.COST.costProjectGroups
      With pg
        .ProjectGroupDescription = Results.FK_COST_FinYearProjects_ProjectID.Description
      End With
      pg = SIS.COST.costProjectGroups.InsertData(pg)
      Dim pgp As New SIS.COST.costProjectGroupProjects
      With pgp
        .ProjectGroupID = pg.ProjectGroupID
        .ProjectID = Results.ProjectID
      End With
      pgp = SIS.COST.costProjectGroupProjects.InsertData(pgp)
      With Results
        .IndividualGroup = True
        .IndividualGroupID = pg.ProjectGroupID
      End With
      SIS.COST.costFinYearProjects.UpdateData(Results)
      'Create CostSheet
      Dim cs As New SIS.COST.costCostSheet
      With cs
        .ProjectGroupID = pg.ProjectGroupID
        .FinYear = FinYear
        .Quarter = Quarter
        .Revision = 1
        .Remarks = "*"
        .StatusID = 2
        .CreatedBy = HttpContext.Current.Session("LoginID")
        .CreatedOn = Now
      End With
      cs = SIS.COST.costCostSheet.InsertData(cs)
      'Import Data From ERPLN
      Try
        SIS.COST.costCostSheetData.costCostSheetDataFromERPLN(pg.ProjectGroupID, FinYear, Quarter, 1)
      Catch ex As Exception

      End Try
      Return Results
    End Function
    Public Shared Function ApproveWF(ByVal FinYear As Int32, ByVal Quarter As Int32, ByVal ProjectID As String, ByVal CombinedGroupID As String) As SIS.COST.costFinYearProjects
      Dim Results As SIS.COST.costFinYearProjects = costFinYearProjectsGetByID(FinYear, Quarter, ProjectID)
      Dim pg As SIS.COST.costProjectGroups = SIS.COST.costProjectGroups.costProjectGroupsGetByID(CombinedGroupID)
      Dim pgp As New SIS.COST.costProjectGroupProjects
      With pgp
        .ProjectGroupID = pg.ProjectGroupID
        .ProjectID = Results.ProjectID
      End With
      pgp = SIS.COST.costProjectGroupProjects.InsertData(pgp)
      With Results
        .CombinedGroup = True
        .CombinedGroupID = pg.ProjectGroupID
      End With
      SIS.COST.costFinYearProjects.UpdateData(Results)
      'Create CostSheet
      Dim cs As SIS.COST.costCostSheet = SIS.COST.costCostSheet.costCostSheetGetByID(pg.ProjectGroupID, FinYear, Quarter, 1)
      If cs Is Nothing Then
        cs = New SIS.COST.costCostSheet
        With cs
          .ProjectGroupID = pg.ProjectGroupID
          .FinYear = FinYear
          .Quarter = Quarter
          .Revision = 1
          .Remarks = "*"
          .StatusID = 2
          .CreatedBy = HttpContext.Current.Session("LoginID")
          .CreatedOn = Now
        End With
        cs = SIS.COST.costCostSheet.InsertData(cs)
      End If
      'Import Data From ERPLN
      Try
        SIS.COST.costCostSheetData.costCostSheetDataFromERPLN(pg.ProjectGroupID, FinYear, Quarter, 1)
      Catch ex As Exception
      End Try
      Return Results
    End Function
    Public Shared Function RejectWF(ByVal FinYear As Int32, ByVal Quarter As Int32, ByVal ProjectID As String, ByVal CombinedGroupID As String) As SIS.COST.costFinYearProjects
      Dim Results As SIS.COST.costFinYearProjects = costFinYearProjectsGetByID(FinYear, Quarter, ProjectID)
      With Results
        .Blocked = True
      End With
      SIS.COST.costFinYearProjects.UpdateData(Results)
      Return Results
    End Function
    Public Shared Function CompleteWF(ByVal FinYear As Int32, ByVal Quarter As Int32, ByVal ProjectID As String, ByVal CombinedGroupID As String) As SIS.COST.costFinYearProjects
      Dim Results As SIS.COST.costFinYearProjects = costFinYearProjectsGetByID(FinYear, Quarter, ProjectID)
      With Results
        .EntryConfirmed = True
      End With
      SIS.COST.costFinYearProjects.UpdateData(Results)
      Return Results
    End Function
    Public Shared Function UZ_costFinYearProjectsSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal FinYear As Int32, ByVal Quarter As Int32, ByVal ProjectID As String) As List(Of SIS.COST.costFinYearProjects)
      Dim Results As List(Of SIS.COST.costFinYearProjects) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "spcost_LG_FinYearProjectsSelectListSearch"
            Cmd.CommandText = "spcostFinYearProjectsSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "spcost_LG_FinYearProjectsSelectListFilteres"
            Cmd.CommandText = "spcostFinYearProjectsSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_FinYear", SqlDbType.Int, 10, IIf(FinYear = Nothing, 0, FinYear))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_Quarter", SqlDbType.Int, 10, IIf(Quarter = Nothing, 0, Quarter))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_ProjectID", SqlDbType.NVarChar, 6, IIf(ProjectID Is Nothing, String.Empty, ProjectID))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.COST.costFinYearProjects)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.COST.costFinYearProjects(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function UZ_costFinYearProjectsInsert(ByVal Record As SIS.COST.costFinYearProjects) As SIS.COST.costFinYearProjects
      Dim tmp As SIS.COST.costFinYearProjects = SIS.COST.costFinYearProjects.costFinYearProjectsGetByID(Record.FinYear, Record.Quarter, Record.ProjectID)
      If tmp Is Nothing Then
        'Check IDM Projects
        Dim tmpP As SIS.QCM.qcmProjects = SIS.QCM.qcmProjects.qcmProjectsGetByID(Record.ProjectID)
        If tmpP Is Nothing Then
          tmpP = New SIS.QCM.qcmProjects
          tmpP.ProjectID = Record.ProjectID
          tmpP.Description = Record.Descpription
          SIS.QCM.qcmProjects.InsertData(tmpP)
        Else
          'If tmpP.Description = String.Empty Then
          '  tmpP.Description = Record.Descpription
          '  SIS.QCM.qcmProjects.UpdateData(tmpP)
          'End If
        End If
        costFinYearProjectsInsert(Record)
      End If
      Return Record
    End Function
    Public Shared Function UZ_costFinYearProjectsUpdate(ByVal Record As SIS.COST.costFinYearProjects) As SIS.COST.costFinYearProjects
      Dim _Result As SIS.COST.costFinYearProjects = costFinYearProjectsUpdate(Record)
      Return _Result
    End Function
    Public Shared Function SetDefaultValues(ByVal sender As System.Web.UI.WebControls.FormView, ByVal e As System.EventArgs) As System.Web.UI.WebControls.FormView
      With sender
        Try
          CType(.FindControl("F_FinYear"), Object).SelectedValue = ""
          CType(.FindControl("F_Quarter"), Object).SelectedValue = ""
          CType(.FindControl("F_ProjectID"), TextBox).Text = ""
          CType(.FindControl("F_ProjectID_Display"), Label).Text = ""
          CType(.FindControl("F_Descpription"), TextBox).Text = ""
          CType(.FindControl("F_IndividualGroup"), CheckBox).Checked = False
          CType(.FindControl("F_CombinedGroup"), CheckBox).Checked = False
          CType(.FindControl("F_IndividualGroupID"), TextBox).Text = ""
          CType(.FindControl("F_IndividualGroupID_Display"), Label).Text = ""
          CType(.FindControl("F_CombinedGroupID"), TextBox).Text = ""
          CType(.FindControl("F_CombinedGroupID_Display"), Label).Text = ""
          CType(.FindControl("F_Blocked"), CheckBox).Checked = False
          CType(.FindControl("F_BlockingRemarks"), TextBox).Text = ""
        Catch ex As Exception
        End Try
      End With
      Return sender
    End Function
    Public Shared Sub UpdateFromERP(ByVal FinYear As String, ByVal Quarter As String)
      Dim Results As List(Of SIS.COST.costFinYearProjects) = Nothing
      Dim PeriodList As String = SIS.COST.costQuarters.GetPeriodsForQuarter(Quarter)
      Dim Sql As String = ""
      Sql &= " Select Distinct "
      Sql &= " aa.Dimension1 As ProjectID, bb.t_dsca as Description "
      Sql &= " From LN_CostSalesLedger as aa inner join ttcmcs052200 as bb on aa.Dimension1=bb.t_cprj  "
      Sql &= " Where aa.Dimension1 <> '' "
      Sql &= " And ((aa.FinancialYear =  " & FinYear & " AND aa.FInancialPeriod In " & PeriodList & ") ) "
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString)
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          Results = New List(Of SIS.COST.costFinYearProjects)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.COST.costFinYearProjects(Reader, FinYear, Quarter))
          End While
          Reader.Close()
        End Using
      End Using
      Sql = " Select Distinct "
      Sql &= " aa.Dimension1 As ProjectID, bb.t_dsca as Description "
      Sql &= " From LN_CostSalesLiability as aa inner join ttcmcs052200 as bb on aa.Dimension1=bb.t_cprj  "
      Sql &= " Where aa.Dimension1 <> '' "
      Sql &= " And ((aa.FinancialYear =  " & FinYear & " AND aa.FInancialPeriod In " & PeriodList & ") ) "
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString)
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.COST.costFinYearProjects(Reader, FinYear, Quarter))
          End While
          Reader.Close()
        End Using
      End Using
      Sql = " Select Distinct "
      Sql &= " aa.Dimension1 As ProjectID, bb.t_dsca as Description "
      Sql &= " From LN_WarrantyLD as aa inner join ttcmcs052200 as bb on aa.Dimension1=bb.t_cprj  "
      Sql &= " Where aa.Dimension1 <> '' "
      Sql &= " And ((aa.FinancialYear =  " & FinYear & " AND aa.FInancialPeriod In " & PeriodList & ") ) "
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString)
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.COST.costFinYearProjects(Reader, FinYear, Quarter))
          End While
          Reader.Close()
        End Using
      End Using
      For Each tmp As SIS.COST.costFinYearProjects In Results
        If tmp.ProjectID <> String.Empty Then
          SIS.COST.costFinYearProjects.UZ_costFinYearProjectsInsert(tmp)
        End If
      Next
    End Sub

    Public Sub New(ByVal Reader As SqlDataReader, ByVal FinYear As Int32, ByVal Quarter As Int32)
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
        Me.FinYear = FinYear
        Me.Quarter = Quarter
      Catch ex As Exception
      End Try
    End Sub
  End Class
End Namespace
