Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.LG
  <DataObject()> _
  Partial Public Class lgDMisg
    Private Shared _RecordCount As Integer
    Private _t_docn As String = ""
    Private _t_revn As String = ""
    Private _t_dttl As String = ""
    Private _t_cspa As String = ""
    Private _t_cprj As String = ""
    Private _t_year As String = ""
    Private _t_stat As Int32 = 0
    Private _t_wfst As Int32 = 0
    Private _t_dsca As String = ""
    Private _t_sorc As String = ""
		Private _t_name As String = ""
		Private _t_drdt As String = ""
		Private _t_erec As String = ""
		Private _t_prod As String = ""
		Private _t_appr As String = ""
		Private _t_adat As String = ""
		Private _LG_Projects1_ProjectDescription As String = ""
		Private _FK_tdmisg001200_t_cprj As SIS.LG.lgProjects = Nothing
		Public Property t_adat() As String
			Get
				Return _t_adat
			End Get
			Set(ByVal value As String)
				_t_adat = value
			End Set
		End Property
		Public Property t_erec() As String
			Get
				Return _t_erec
			End Get
			Set(ByVal value As String)
				_t_erec = value
			End Set
		End Property
		Public Property t_prod() As String
			Get
				Return _t_prod
			End Get
			Set(ByVal value As String)
				_t_prod = value
			End Set
		End Property
		Public Property t_appr() As String
			Get
				Return _t_appr
			End Get
			Set(ByVal value As String)
				_t_appr = value
			End Set
		End Property
		Public Property t_drdt() As String
			Get
				Return _t_drdt
			End Get
			Set(ByVal value As String)
				_t_drdt = value
			End Set
		End Property
		Public ReadOnly Property ForeColor() As System.Drawing.Color
			Get
				Dim mRet As System.Drawing.Color = Drawing.Color.Blue
				Try
					mRet = GetColor()
				Catch ex As Exception
				End Try
				Return mRet
			End Get
		End Property
    Public ReadOnly Property Visible() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
					mRet = GetVisible()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property Enable() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
					mRet = GetEnable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public Property t_docn() As String
      Get
        Return _t_docn
      End Get
      Set(ByVal value As String)
        _t_docn = value
      End Set
    End Property
    Public Property t_revn() As String
      Get
        Return _t_revn
      End Get
      Set(ByVal value As String)
        _t_revn = value
      End Set
    End Property
    Public Property t_dttl() As String
      Get
        Return _t_dttl
      End Get
      Set(ByVal value As String)
        _t_dttl = value
      End Set
    End Property
    Public Property t_cspa() As String
      Get
        Return _t_cspa
      End Get
      Set(ByVal value As String)
        _t_cspa = value
      End Set
    End Property
    Public Property t_cprj() As String
      Get
        Return _t_cprj
      End Get
      Set(ByVal value As String)
        _t_cprj = value
      End Set
    End Property
    Public Property t_year() As String
      Get
        Return _t_year
      End Get
      Set(ByVal value As String)
        _t_year = value
      End Set
    End Property
    Public Property t_stat() As Int32
      Get
        Return _t_stat
      End Get
      Set(ByVal value As Int32)
        _t_stat = value
      End Set
    End Property
    Public Property t_wfst() As Int32
      Get
        Return _t_wfst
      End Get
      Set(ByVal value As Int32)
        _t_wfst = value
      End Set
    End Property
    Public Property t_dsca() As String
      Get
        Return _t_dsca
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _t_dsca = ""
				 Else
					 _t_dsca = value
			   End If
      End Set
    End Property
    Public Property t_sorc() As String
      Get
        Return _t_sorc
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _t_sorc = ""
				 Else
					 _t_sorc = value
			   End If
      End Set
    End Property
    Public Property t_name() As String
      Get
        Return _t_name
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _t_name = ""
				 Else
					 _t_name = value
			   End If
      End Set
    End Property
    Public Property LG_Projects1_ProjectDescription() As String
      Get
        Return _LG_Projects1_ProjectDescription
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _LG_Projects1_ProjectDescription = ""
				 Else
					 _LG_Projects1_ProjectDescription = value
			   End If
      End Set
    End Property
    Public Readonly Property DisplayField() As String
      Get
        Return ""
      End Get
    End Property
    Public Readonly Property PrimaryKey() As String
      Get
        Return _t_docn & "|" & _t_revn
      End Get
    End Property
    Public Shared Property RecordCount() As Integer
      Get
        Return _RecordCount
      End Get
      Set(ByVal value As Integer)
        _RecordCount = value
      End Set
    End Property
    Public Class PKlgDMisg
			Private _t_docn As String = ""
			Private _t_revn As String = ""
			Public Property t_docn() As String
				Get
					Return _t_docn
				End Get
				Set(ByVal value As String)
					_t_docn = value
				End Set
			End Property
			Public Property t_revn() As String
				Get
					Return _t_revn
				End Get
				Set(ByVal value As String)
					_t_revn = value
				End Set
			End Property
    End Class
    Public ReadOnly Property FK_tdmisg001200_t_cprj() As SIS.LG.lgProjects
      Get
        If _FK_tdmisg001200_t_cprj Is Nothing Then
          _FK_tdmisg001200_t_cprj = SIS.LG.lgProjects.lgProjectsGetByID(_t_cprj)
        End If
        Return _FK_tdmisg001200_t_cprj
      End Get
    End Property
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function lgDMisgGetNewRecord() As SIS.LG.lgDMisg
      Return New SIS.LG.lgDMisg()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function lgDMisgGetByID(ByVal t_docn As String, ByVal t_revn As String) As SIS.LG.lgDMisg
      Dim Results As SIS.LG.lgDMisg = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "splgDMisgSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_docn",SqlDbType.VarChar,t_docn.ToString.Length, t_docn)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_revn",SqlDbType.VarChar,t_revn.ToString.Length, t_revn)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
					If Reader.Read() Then
						Results = New SIS.LG.lgDMisg(Reader)
					End If
					Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function GetByt_cprj(ByVal t_cprj As String, ByVal OrderBy as String) As List(Of SIS.LG.lgDMisg)
      Dim Results As List(Of SIS.LG.lgDMisg) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "splgDMisgSelectByt_cprj"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_cprj",SqlDbType.NVarChar,t_cprj.ToString.Length, t_cprj)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
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
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function lgDMisgSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal t_cprj As String) As List(Of SIS.LG.lgDMisg)
      Dim Results As List(Of SIS.LG.lgDMisg) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
					If SearchState Then
						Cmd.CommandText = "splgDMisgSelectListSearch"
						SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
					Else
						Cmd.CommandText = "splgDMisgSelectListFilteres"
						SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_t_cprj",SqlDbType.NVarChar,20, IIf(t_cprj Is Nothing, String.Empty,t_cprj))
					End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
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
    Public Shared Function lgDMisgSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String, ByVal t_cprj As String) As Integer
      Return _RecordCount
    End Function
      'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function lgDMisgGetByID(ByVal t_docn As String, ByVal t_revn As String, ByVal Filter_t_cprj As String) As SIS.LG.lgDMisg
      Return lgDMisgGetByID(t_docn, t_revn)
    End Function
    Public Sub New(ByVal Reader As SqlDataReader)
      On Error Resume Next
      _t_docn = Ctype(Reader("t_docn"),String)
      _t_revn = Ctype(Reader("t_revn"),String)
      _t_dttl = Ctype(Reader("t_dttl"),String)
      _t_cspa = Ctype(Reader("t_cspa"),String)
      _t_cprj = Ctype(Reader("t_cprj"),String)
      _t_year = Ctype(Reader("t_year"),String)
      _t_stat = Ctype(Reader("t_stat"),Int32)
      _t_wfst = Ctype(Reader("t_wfst"),Int32)
      If Convert.IsDBNull(Reader("t_dsca")) Then
        _t_dsca = String.Empty
      Else
        _t_dsca = Ctype(Reader("t_dsca"), String)
      End If
      If Convert.IsDBNull(Reader("t_sorc")) Then
        _t_sorc = String.Empty
      Else
        _t_sorc = Ctype(Reader("t_sorc"), String)
      End If
      If Convert.IsDBNull(Reader("t_name")) Then
        _t_name = String.Empty
      Else
        _t_name = Ctype(Reader("t_name"), String)
      End If
			If Convert.IsDBNull(Reader("t_drdt")) Then
				_t_drdt = String.Empty
			Else
				_t_drdt = CType(Reader("t_drdt"), String)
			End If
			If Convert.IsDBNull(Reader("t_adat")) Then
				_t_adat = String.Empty
			Else
				_t_adat = CType(Reader("t_adat"), String)
			End If
			If Convert.IsDBNull(Reader("t_erec")) Then
				_t_erec = String.Empty
			Else
				_t_erec = CType(Reader("t_erec"), String)
			End If
			If Convert.IsDBNull(Reader("t_prod")) Then
				_t_prod = String.Empty
			Else
				_t_prod = CType(Reader("t_prod"), String)
			End If
			If Convert.IsDBNull(Reader("t_appr")) Then
				_t_appr = String.Empty
			Else
				_t_appr = CType(Reader("t_appr"), String)
			End If
			If Convert.IsDBNull(Reader("LG_Projects1_ProjectDescription")) Then
				_LG_Projects1_ProjectDescription = String.Empty
			Else
				_LG_Projects1_ProjectDescription = CType(Reader("LG_Projects1_ProjectDescription"), String)
			End If
    End Sub
    Public Sub New()
    End Sub
  End Class
End Namespace
