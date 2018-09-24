Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.COST
  Partial Public Class costAdjustmentEntry
    Public Function GetColor() As System.Drawing.Color
      Dim mRet As System.Drawing.Color = Drawing.Color.Blue
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
      If Not FK_COST_AdjustmentEntry_CostSheet.LockAdjustmentEntry Then
        mRet = True
      End If
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
    Public Shared Function UZ_costAdjustmentEntrySelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal FinYear As Int32, ByVal ProjectGroupID As Int32, ByVal Revision As Int32, ByVal Quarter As Int32) As List(Of SIS.COST.costAdjustmentEntry)
      Dim Results As List(Of SIS.COST.costAdjustmentEntry) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "spcost_LG_AdjustmentEntrySelectListSearch"
            Cmd.CommandText = "spcostAdjustmentEntrySelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "spcost_LG_AdjustmentEntrySelectListFilteres"
            Cmd.CommandText = "spcostAdjustmentEntrySelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_FinYear", SqlDbType.Int, 10, IIf(FinYear = Nothing, 0, FinYear))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_ProjectGroupID", SqlDbType.Int, 10, IIf(ProjectGroupID = Nothing, 0, ProjectGroupID))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_Revision", SqlDbType.Int, 10, IIf(Revision = Nothing, 0, Revision))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_Quarter", SqlDbType.Int, 10, IIf(Quarter = Nothing, 0, Quarter))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.COST.costAdjustmentEntry)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.COST.costAdjustmentEntry(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function costAdjustmentInsertUpdate(ByVal Record As SIS.COST.costAdjustmentEntry) As SIS.COST.costAdjustmentEntry
      With Record
        Dim tmps As List(Of SIS.COST.costCostSheetData) = SIS.COST.costCostSheetData.GetByAdjustmentSerialNo(Record.AdjustmentSerialNo, "")
        For Each tmp As SIS.COST.costCostSheetData In tmps
          SIS.COST.costCostSheetData.costCostSheetDataDelete(tmp)
        Next
        If .Active = True Then
          Dim tmp As SIS.COST.costCostSheetData = New SIS.COST.costCostSheetData
          tmp.ProjectGroupID = .ProjectGroupID
          tmp.FinYear = .FinYear
          tmp.Quarter = .Quarter
          tmp.Revision = .Revision
          tmp.ProjectID = .ProjectID
          tmp.GLCode = .DrGLCode
          tmp.AdjustmentSerialNo = .AdjustmentSerialNo
          tmp.AdjustmentCredit = 0
          tmp.CrAmount = 0
          tmp.DrAmount = .Amount
          tmp.Amount = .Amount
          tmp.AdjustmentEntry = True
          SIS.COST.costCostSheetData.InsertData(tmp)
          tmp = New SIS.COST.costCostSheetData
          tmp.ProjectGroupID = .ProjectGroupID
          tmp.FinYear = .FinYear
          tmp.Quarter = .Quarter
          tmp.Revision = .Revision
          tmp.ProjectID = .ProjectID
          tmp.GLCode = .CrGLCode
          tmp.AdjustmentSerialNo = .AdjustmentSerialNo
          tmp.AdjustmentCredit = 1
          tmp.CrAmount = .Amount
          tmp.DrAmount = 0
          tmp.Amount = .Amount
          tmp.AdjustmentEntry = True
          SIS.COST.costCostSheetData.InsertData(tmp)
          SIS.COST.costCostSheetData.UpdateCSDataWOnGLGroup(.ProjectGroupID, .FinYear, .Quarter, .Revision)
        End If
      End With
      Return Record
    End Function

    Public Shared Function UZ_costAdjustmentEntryInsert(ByVal Record As SIS.COST.costAdjustmentEntry) As SIS.COST.costAdjustmentEntry
      Dim _Result As SIS.COST.costAdjustmentEntry = costAdjustmentEntryInsert(Record)
      Return costAdjustmentInsertUpdate(_Result)
    End Function
    Public Shared Function UZ_costAdjustmentEntryUpdate(ByVal Record As SIS.COST.costAdjustmentEntry) As SIS.COST.costAdjustmentEntry
      Dim _Result As SIS.COST.costAdjustmentEntry = costAdjustmentEntryUpdate(Record)
      Return costAdjustmentInsertUpdate(_Result)
    End Function
    Public Shared Function UZ_costAdjustmentEntryDelete(ByVal Record As SIS.COST.costAdjustmentEntry) As Integer
      Record.Active = False
      Record = costAdjustmentInsertUpdate(Record)
      Dim _Result As Integer = costAdjustmentEntryDelete(Record)
      Return _Result
    End Function
    Public Shared Function SetDefaultValues(ByVal sender As System.Web.UI.WebControls.FormView, ByVal e As System.EventArgs) As System.Web.UI.WebControls.FormView
      With sender
        Try
        CType(.FindControl("F_AdjustmentSerialNo"), TextBox).Text = ""
        CType(.FindControl("F_ProjectID"), TextBox).Text = ""
        CType(.FindControl("F_ProjectID_Display"), Label).Text = ""
        CType(.FindControl("F_CrGLCode"), TextBox).Text = ""
        CType(.FindControl("F_CrGLCode_Display"), Label).Text = ""
        CType(.FindControl("F_DrGLCode"), TextBox).Text = ""
        CType(.FindControl("F_DrGLCode_Display"), Label).Text = ""
        CType(.FindControl("F_Amount"), TextBox).Text = 0
        CType(.FindControl("F_Active"), CheckBox).Checked = False
        CType(.FindControl("F_Remarks"), TextBox).Text = ""
        CType(.FindControl("F_FinYear"), TextBox).Text = ""
        CType(.FindControl("F_FinYear_Display"), Label).Text = ""
        CType(.FindControl("F_ProjectGroupID"), TextBox).Text = ""
        CType(.FindControl("F_ProjectGroupID_Display"), Label).Text = ""
        CType(.FindControl("F_Revision"), TextBox).Text = ""
        CType(.FindControl("F_Revision_Display"), Label).Text = ""
        CType(.FindControl("F_Quarter"), TextBox).Text = ""
        CType(.FindControl("F_Quarter_Display"), Label).Text = ""
        Catch ex As Exception
        End Try
      End With
      Return sender
    End Function
  End Class
End Namespace
