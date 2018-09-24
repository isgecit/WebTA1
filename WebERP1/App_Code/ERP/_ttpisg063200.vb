Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.DM
  <DataObject()> _
  Partial Public Class ttpisg063200
    Private Shared _RecordCount As Integer
    Private _t_cprj As String = ""
    Private _t_cspa As String = ""
    Private _t_appl As Int32 = 0
    Private _t_engs As Int32 = 0
    Private _t_Refcntd As Int32 = 0
    Private _t_Refcntu As Int32 = 0
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
    Public Property t_cprj() As String
      Get
        Return _t_cprj
      End Get
      Set(ByVal value As String)
        _t_cprj = value
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
    Public Property t_appl() As Int32
      Get
        Return _t_appl
      End Get
      Set(ByVal value As Int32)
        _t_appl = value
      End Set
    End Property
    Public Property t_engs() As Int32
      Get
        Return _t_engs
      End Get
      Set(ByVal value As Int32)
        _t_engs = value
      End Set
    End Property
    Public Property t_Refcntd() As Int32
      Get
        Return _t_Refcntd
      End Get
      Set(ByVal value As Int32)
        _t_Refcntd = value
      End Set
    End Property
    Public Property t_Refcntu() As Int32
      Get
        Return _t_Refcntu
      End Get
      Set(ByVal value As Int32)
        _t_Refcntu = value
      End Set
    End Property
    Public Readonly Property DisplayField() As String
      Get
        Return ""
      End Get
    End Property
    Public Readonly Property PrimaryKey() As String
      Get
        Return _t_cprj & "|" & _t_cspa
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
    Public Class PKttpisg063200
			Private _t_cprj As String = ""
			Private _t_cspa As String = ""
			Public Property t_cprj() As String
				Get
					Return _t_cprj
				End Get
				Set(ByVal value As String)
					_t_cprj = value
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
    End Class
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function ttpisg063200GetNewRecord() As SIS.DM.ttpisg063200
      Return New SIS.DM.ttpisg063200()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function ttpisg063200GetByID(ByVal t_cprj As String, ByVal t_cspa As String) As SIS.DM.ttpisg063200
      Dim Results As SIS.DM.ttpisg063200 = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spttpisg063200SelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_cprj",SqlDbType.VarChar,t_cprj.ToString.Length, t_cprj)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_cspa",SqlDbType.VarChar,t_cspa.ToString.Length, t_cspa)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
					If Reader.Read() Then
						Results = New SIS.DM.ttpisg063200(Reader)
					End If
					Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function ttpisg063200SelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String) As List(Of SIS.DM.ttpisg063200)
      Dim Results As List(Of SIS.DM.ttpisg063200) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
					If SearchState Then
						Cmd.CommandText = "spttpisg063200SelectListSearch"
						SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
					Else
						Cmd.CommandText = "spttpisg063200SelectListFilteres"
					End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.DM.ttpisg063200)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.DM.ttpisg063200(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function ttpisg063200SelectCount(ByVal SearchState As Boolean, ByVal SearchText As String) As Integer
      Return _RecordCount
    End Function
      'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Insert, True)> _
    Public Shared Function ttpisg063200Insert(ByVal Record As SIS.DM.ttpisg063200) As SIS.DM.ttpisg063200
      Dim _Rec As SIS.DM.ttpisg063200 = SIS.DM.ttpisg063200.ttpisg063200GetNewRecord()
      With _Rec
        .t_cprj = Record.t_cprj
        .t_cspa = Record.t_cspa
        .t_appl = Record.t_appl
        .t_engs = Record.t_engs
        .t_Refcntd = Record.t_Refcntd
        .t_Refcntu = Record.t_Refcntu
      End With
      Return SIS.DM.ttpisg063200.InsertData(_Rec)
    End Function
    Public Shared Function InsertData(ByVal Record As SIS.DM.ttpisg063200) As SIS.DM.ttpisg063200
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spttpisg063200Insert"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_cprj",SqlDbType.VarChar,10, Record.t_cprj)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_cspa",SqlDbType.VarChar,9, Record.t_cspa)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_appl",SqlDbType.Int,11, Record.t_appl)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_engs",SqlDbType.Int,11, Record.t_engs)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_Refcntd",SqlDbType.Int,11, Record.t_Refcntd)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_Refcntu",SqlDbType.Int,11, Record.t_Refcntu)
          Cmd.Parameters.Add("@Return_t_cprj", SqlDbType.VarChar, 10)
          Cmd.Parameters("@Return_t_cprj").Direction = ParameterDirection.Output
          Cmd.Parameters.Add("@Return_t_cspa", SqlDbType.VarChar, 9)
          Cmd.Parameters("@Return_t_cspa").Direction = ParameterDirection.Output
          Con.Open()
          Cmd.ExecuteNonQuery()
          Record.t_cprj = Cmd.Parameters("@Return_t_cprj").Value
          Record.t_cspa = Cmd.Parameters("@Return_t_cspa").Value
        End Using
      End Using
      Return Record
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)> _
    Public Shared Function ttpisg063200Update(ByVal Record As SIS.DM.ttpisg063200) As SIS.DM.ttpisg063200
      Dim _Rec As SIS.DM.ttpisg063200 = SIS.DM.ttpisg063200.ttpisg063200GetByID(Record.t_cprj, Record.t_cspa)
      With _Rec
        .t_appl = Record.t_appl
        .t_engs = Record.t_engs
        .t_Refcntd = Record.t_Refcntd
        .t_Refcntu = Record.t_Refcntu
      End With
      Return SIS.DM.ttpisg063200.UpdateData(_Rec)
    End Function
    Public Shared Function UpdateData(ByVal Record As SIS.DM.ttpisg063200) As SIS.DM.ttpisg063200
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spttpisg063200Update"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_t_cprj",SqlDbType.VarChar,10, Record.t_cprj)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_t_cspa",SqlDbType.VarChar,9, Record.t_cspa)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_cprj",SqlDbType.VarChar,10, Record.t_cprj)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_cspa",SqlDbType.VarChar,9, Record.t_cspa)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_appl",SqlDbType.Int,11, Record.t_appl)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_engs",SqlDbType.Int,11, Record.t_engs)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_Refcntd",SqlDbType.Int,11, Record.t_Refcntd)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_Refcntu",SqlDbType.Int,11, Record.t_Refcntu)
          Cmd.Parameters.Add("@RowCount", SqlDbType.Int)
          Cmd.Parameters("@RowCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Con.Open()
          Cmd.ExecuteNonQuery()
          _RecordCount = Cmd.Parameters("@RowCount").Value
        End Using
      End Using
      Return Record
    End Function
    <DataObjectMethod(DataObjectMethodType.Delete, True)> _
    Public Shared Function ttpisg063200Delete(ByVal Record As SIS.DM.ttpisg063200) As Int32
      Dim _Result as Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spttpisg063200Delete"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_t_cprj",SqlDbType.VarChar,Record.t_cprj.ToString.Length, Record.t_cprj)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_t_cspa",SqlDbType.VarChar,Record.t_cspa.ToString.Length, Record.t_cspa)
          Cmd.Parameters.Add("@RowCount", SqlDbType.Int)
          Cmd.Parameters("@RowCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Con.Open()
          Cmd.ExecuteNonQuery()
          _RecordCount = Cmd.Parameters("@RowCount").Value
        End Using
      End Using
      Return _RecordCount
    End Function
    Public Sub New(ByVal Reader As SqlDataReader)
      On Error Resume Next
      _t_cprj = Ctype(Reader("t_cprj"),String)
      _t_cspa = Ctype(Reader("t_cspa"),String)
      _t_appl = Ctype(Reader("t_appl"),Int32)
      _t_engs = Ctype(Reader("t_engs"),Int32)
      _t_Refcntd = Ctype(Reader("t_Refcntd"),Int32)
      _t_Refcntu = Ctype(Reader("t_Refcntu"),Int32)
    End Sub
    Public Sub New()
    End Sub
  End Class
End Namespace
