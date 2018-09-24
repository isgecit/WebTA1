Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.COST
  Partial Public Class costCSDataWOnGLGroup
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
    Public Shared Function UZ_costCSDataWOnGLGroupSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal ProjectGroupID As Int32, ByVal FinYear As Int32, ByVal Quarter As Int32, ByVal Revision As Int32) As List(Of SIS.COST.costCSDataWOnGLGroup)
      Dim Results As List(Of SIS.COST.costCSDataWOnGLGroup) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "spcost_LG_CSDataWOnGLGroupSelectListSearch"
            Cmd.CommandText = "spcostCSDataWOnGLGroupSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "spcost_LG_CSDataWOnGLGroupSelectListFilteres"
            Cmd.CommandText = "spcostCSDataWOnGLGroupSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_ProjectGroupID",SqlDbType.Int,10, IIf(ProjectGroupID = Nothing, 0,ProjectGroupID))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_FinYear",SqlDbType.Int,10, IIf(FinYear = Nothing, 0,FinYear))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_Quarter",SqlDbType.Int,10, IIf(Quarter = Nothing, 0,Quarter))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_Revision",SqlDbType.Int,10, IIf(Revision = Nothing, 0,Revision))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.COST.costCSDataWOnGLGroup)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.COST.costCSDataWOnGLGroup(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function UZ_costCSDataWOnGLGroupInsert(ByVal Record As SIS.COST.costCSDataWOnGLGroup) As SIS.COST.costCSDataWOnGLGroup
      Dim _Result As SIS.COST.costCSDataWOnGLGroup = costCSDataWOnGLGroupInsert(Record)
      Return _Result
    End Function
    Public Shared Function UZ_costCSDataWOnGLGroupUpdate(ByVal Record As SIS.COST.costCSDataWOnGLGroup) As SIS.COST.costCSDataWOnGLGroup
      Dim _Result As SIS.COST.costCSDataWOnGLGroup = costCSDataWOnGLGroupUpdate(Record)
      Return _Result
    End Function
    Public Shared Function UZ_costCSDataWOnGLGroupDelete(ByVal Record As SIS.COST.costCSDataWOnGLGroup) As Integer
      Dim _Result as Integer = costCSDataWOnGLGroupDelete(Record)
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
        CType(.FindControl("F_WorkOrderTypeID"),Object).SelectedValue = ""
        CType(.FindControl("F_GLGroupID"), TextBox).Text = ""
        CType(.FindControl("F_GLGroupID_Display"), Label).Text = ""
        CType(.FindControl("F_CrAmount"), TextBox).Text = 0
        CType(.FindControl("F_DrAmount"), TextBox).Text = 0
        CType(.FindControl("F_Amount"), TextBox).Text = 0
        Catch ex As Exception
        End Try
      End With
      Return sender
    End Function
  End Class
End Namespace
