Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.COST
  Partial Public Class costProjectGroups
    Private _GroupCurrencyID As String = ""
    Private _GroupOrderValueINR As Decimal = 0
    Private _GroupOrderValue As Decimal = 0
    Private _GroupConversionFactor As Decimal = 0
    Private _GroupMarginCurrentYear As Decimal = 0
    Private _GroupMarginCurrentYearINR As Decimal = 0
    Private Sub UpdateGroupValues()
      Dim tmps As List(Of SIS.COST.costProjectGroupProjects) = SIS.COST.costProjectGroupProjects.GetByProjectGroupID(ProjectGroupID, "")
      _GroupCurrencyID = "INR"
      _GroupOrderValueINR = "1.00"
      _GroupOrderValue = 0
      For Each tmp As SIS.COST.costProjectGroupProjects In tmps
        Try
          If tmp.FK_COST_ProjectGroupProjects_ProjectID.CurrencyID <> String.Empty Then
            _GroupCurrencyID = tmp.FK_COST_ProjectGroupProjects_ProjectID.CurrencyID
          End If
        Catch ex As Exception
        End Try
        Try
          _GroupOrderValueINR += tmp.FK_COST_ProjectGroupProjects_ProjectID.ProjectOrderValueINR
        Catch ex As Exception
        End Try
        Try
          _GroupOrderValue += tmp.FK_COST_ProjectGroupProjects_ProjectID.ProjectOrderValue
        Catch ex As Exception
        End Try
        Try
          _GroupMarginCurrentYear += tmp.FK_COST_ProjectGroupProjects_ProjectID.MarginCurrentYear
        Catch ex As Exception
        End Try
        Try
          _GroupMarginCurrentYearINR += tmp.FK_COST_ProjectGroupProjects_ProjectID.MarginCurrentYearINR
        Catch ex As Exception
        End Try
      Next
      Try
        _GroupConversionFactor = _GroupOrderValueINR / _GroupOrderValue
      Catch ex As Exception
        _GroupConversionFactor = "1.00"
      End Try
    End Sub
    Public ReadOnly Property GroupConversionFactor As Decimal
      Get
        If _GroupCurrencyID = "" Then
          UpdateGroupValues()
        End If
        Return _GroupConversionFactor
      End Get
    End Property
    Public ReadOnly Property GroupOrderValueINR As Decimal
      Get
        If _GroupCurrencyID = "" Then
          UpdateGroupValues()
        End If
        Return _GroupOrderValueINR
      End Get
    End Property

    Public ReadOnly Property GroupCurrencyID As String
      Get
        If _GroupCurrencyID = "" Then
          UpdateGroupValues()
        End If
        Return _GroupCurrencyID
      End Get
    End Property
    Public ReadOnly Property GroupOrderValue As Decimal
      Get
        If _GroupCurrencyID = "" Then
          UpdateGroupValues()
        End If
        Return _GroupOrderValue
      End Get
    End Property
    Public ReadOnly Property GroupMarginCurrentYear As Decimal
      Get
        If _GroupCurrencyID = "" Then
          UpdateGroupValues()
        End If
        Return _GroupMarginCurrentYear
      End Get
    End Property
    Public ReadOnly Property GroupMarginCurrentYearINR As Decimal
      Get
        If _GroupCurrencyID = "" Then
          UpdateGroupValues()
        End If
        Return _GroupMarginCurrentYearINR
      End Get
    End Property
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
    Public Shared Function SetDefaultValues(ByVal sender As System.Web.UI.WebControls.FormView, ByVal e As System.EventArgs) As System.Web.UI.WebControls.FormView
      With sender
        Try
          CType(.FindControl("F_ProjectGroupID"), TextBox).Text = ""
          CType(.FindControl("F_ProjectGroupDescription"), TextBox).Text = ""
          CType(.FindControl("F_ProjectTypeID"), Object).SelectedValue = ""
        Catch ex As Exception
        End Try
      End With
      Return sender
    End Function
    Public Shared Function GetProjectsOfGroup(ByVal ProjectGroupID As Int32) As String
      Dim tmps As List(Of SIS.COST.costProjectGroupProjects) = SIS.COST.costProjectGroupProjects.GetByProjectGroupID(ProjectGroupID, "")
      Dim mRet As String = ""
      For Each tmp As SIS.COST.costProjectGroupProjects In tmps
        If mRet = String.Empty Then
          mRet = "'" & tmp.ProjectID & "'"
        Else
          mRet &= "," & "'" & tmp.ProjectID & "'"
        End If
      Next
      Return "(" & mRet & ")"
    End Function
    Public Shared Function costProjectGroupsGetByName(ByVal ProjectGroupName As String) As SIS.COST.costProjectGroups
      Dim Results As SIS.COST.costProjectGroups = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spcostProjectGroupsSelectByGroupName"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ProjectGroupName", SqlDbType.NVarChar, 50, ProjectGroupName)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.COST.costProjectGroups(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
  End Class
End Namespace
