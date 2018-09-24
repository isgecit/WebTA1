Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.LG
	Partial Public Class lgDMisg
		Public ReadOnly Property Stat() As String
			Get
				Dim mRet As String = ""
				Select Case _t_stat
					Case 1
						mRet = "Submitted"
					Case 2
						mRet = "Item Released"
					Case 3
						mRet = "Drawing Released"
					Case 4
						mRet = "Expired"
				End Select
				Return mRet
			End Get
		End Property
		Public ReadOnly Property WFStat() As String
			Get
				Dim mRet As String = ""
				Select Case _t_wfst
					Case 1
						mRet = "Under Design"
					Case 2
						mRet = "Submitted"
					Case 3
						mRet = "Under Review"
					Case 4
						mRet = "Under Approval"
					Case 5
						mRet = "Released"
					Case 6
						mRet = "Withdrawn"
					Case 7
						mRet = "Under Revision"
					Case 8
						mRet = "Superseded"
					Case 9
						mRet = "Under DCR"
				End Select
				Return mRet
			End Get
		End Property
		Public ReadOnly Property DocStatus() As String
			Get
				Dim mRet As String = ""
				Select Case _t_wfst
					Case 1, 2, 3, 4
						mRet = "NOT Released"
					Case 5
						mRet = "Released"
					Case 6
						mRet = "Withdrawn"
					Case 7, 8, 9
						mRet = "Under Revision"
				End Select
				Return mRet
			End Get
		End Property
		Public Shared Function lgDMisgSelectLatest(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal t_cprj As String) As List(Of SIS.LG.lgDMisg)
			Dim Results As List(Of SIS.LG.lgDMisg) = Nothing
			Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
				Using Cmd As SqlCommand = Con.CreateCommand()
					Cmd.CommandType = CommandType.StoredProcedure
					If SearchState Then
						Cmd.CommandText = "splg_LG_DMisgSelectLatestSearch"
						SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
					Else
						Cmd.CommandText = "splg_LG_DMisgSelectLatestFilteres"
						SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_t_cprj", SqlDbType.NVarChar, 20, IIf(t_cprj Is Nothing, String.Empty, t_cprj))
					End If
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, "")
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
					Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
					Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
					_RecordCount = -1
					Results = New List(Of SIS.LG.lgDMisg)()
					Con.Open()
					Dim Reader As SqlDataReader = Cmd.ExecuteReader()
					While (Reader.Read())
						Results.Add(New SIS.LG.lgDMisg(Reader))
					End While
					Reader.Close()
					_RecordCount = Cmd.Parameters("@RecordCount").Value
				End Using
			End Using
			Return Results
		End Function
		Public Shared Function GetErectionDrawingListFromBaaN(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal t_cprj As String) As List(Of SIS.LG.lgDMisg)
			Dim Results As List(Of SIS.LG.lgDMisg) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "splg_LG_GetErectionDrawing"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "splg_LG_GetErectionDrawing"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_t_cprj", SqlDbType.NVarChar, 20, IIf(t_cprj Is Nothing, String.Empty, t_cprj))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, "")
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.LG.lgDMisg)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.LG.lgDMisg(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function GetErectionDrawingListFromBaaN_New(ByVal LastDays As Integer, ByVal t_cprj As String) As List(Of SIS.LG.lgDMisg)
      Dim Results As List(Of SIS.LG.lgDMisg) = Nothing
      Dim Sql As String = ""
      Sql = Sql & "		SELECT"
      Sql = Sql & "     datediff(d,docM.t_drdt,getdate()) as Rele,"
      Sql = Sql & "     datediff(d,dcrH.t_appt,getdate()) as UD, "
      Sql = Sql & "     dcrH.t_dcrn ,"
      Sql = Sql & "			docM.t_docn ,"
      Sql = Sql & "			docM.t_revn ,"
      Sql = Sql & "			docM.t_dttl ,"
      Sql = Sql & "			docM.t_cspa ,"
      Sql = Sql & "			docM.t_cprj ,"
      Sql = Sql & "			docM.t_year ,"
      Sql = Sql & "			docM.t_stat ,"
      Sql = Sql & "			docM.t_wfst ,"
      Sql = Sql & "			docM.t_dsca ,"
      Sql = Sql & "			docM.t_sorc ,"
      Sql = Sql & "			(case when docM.t_wfst = 5 then docM.t_drdt else dcrH.t_appt end) as t_drdt ,"
      Sql = Sql & "			docM.t_name ,"
      Sql = Sql & "			docM.t_erec ,"
      Sql = Sql & "			docM.t_prod ,"
      Sql = Sql & "			docM.t_appr  "
      Sql = Sql & "		FROM tdmisg001200 as docM "
      Sql = Sql & "			left outer join tdmisg115200 as dcrL on (docM.t_docn = dcrL.t_docd and docM.t_revn = dcrL.t_revn)  "
      Sql = Sql & "			left outer join tdmisg114200 as dcrH on dcrL.t_dcrn = dcrH.t_dcrn "
      Sql = Sql & "		WHERE docM.t_revn = (SELECT MAX(tmp.t_revn) FROM tdmisg001200 as tmp WHERE tmp.t_docn= docM.t_docn) "
      Sql = Sql & "			AND docM.t_cprj = '" & t_cprj & "'"
      Sql = Sql & "			AND (docM.t_wfst = 5 OR docM.t_wfst = 7) "
      Sql = Sql & "			AND ((docM.t_wfst = 5 and datediff(d,docM.t_drdt,getdate()) <= " & LastDays & ") or (docM.t_wfst=7 and datediff(d,dcrH.t_appt,getdate()) <=" & LastDays & ")  )"

      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          Results = New List(Of SIS.LG.lgDMisg)
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.LG.lgDMisg(Reader))
          End While
          Reader.Close()
        End Using
      End Using
      Return Results
		End Function
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
	End Class
End Namespace
