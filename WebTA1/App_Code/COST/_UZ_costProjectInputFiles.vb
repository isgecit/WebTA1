Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.COST
  Partial Public Class costProjectInputFiles
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
    Public Shared Function UZ_costProjectInputFilesSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal ProjectGroupID As Int32, ByVal FinYear As Int32, ByVal Quarter As Int32) As List(Of SIS.COST.costProjectInputFiles)
      Dim Results As List(Of SIS.COST.costProjectInputFiles) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "spcost_LG_ProjectInputFilesSelectListSearch"
            Cmd.CommandText = "spcostProjectInputFilesSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "spcost_LG_ProjectInputFilesSelectListFilteres"
            Cmd.CommandText = "spcostProjectInputFilesSelectListFilteres"
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
          Results = New List(Of SIS.COST.costProjectInputFiles)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.COST.costProjectInputFiles(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function UZ_costProjectInputFilesInsert(ByVal Record As SIS.COST.costProjectInputFiles) As SIS.COST.costProjectInputFiles
      Dim _Result As SIS.COST.costProjectInputFiles = costProjectInputFilesInsert(Record)
      Return _Result
    End Function
    Public Shared Function UZ_costProjectInputFilesUpdate(ByVal Record As SIS.COST.costProjectInputFiles) As SIS.COST.costProjectInputFiles
      Dim _Result As SIS.COST.costProjectInputFiles = costProjectInputFilesUpdate(Record)
      Return _Result
    End Function
    Public Shared Function UZ_costProjectInputFilesDelete(ByVal Record As SIS.COST.costProjectInputFiles) As Integer
      Dim _Result as Integer = costProjectInputFilesDelete(Record)
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
        CType(.FindControl("F_SerialNo"), TextBox).Text = 0
        CType(.FindControl("F_Description"), TextBox).Text = ""
        CType(.FindControl("F_FileName"), TextBox).Text = ""
        CType(.FindControl("F_DiskFile"), TextBox).Text = ""
        Catch ex As Exception
        End Try
      End With
      Return sender
    End Function
  End Class
End Namespace
