Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.TPISG
  <DataObject()> _
  Partial Public Class tpisg208
    Private Shared _RecordCount As Integer
    Private _t_idno As Int32 = 0
    Private _t_pono As String = ""
    Private _t_issu As Int32 = 0
    Private _t_issd As String = ""
    Private _t_isby As String = ""
    Private _t_accp As Int32 = 0
    Private _t_accd As String = ""
    Private _t_acby As String = ""
    Private _t_Refcntd As Int32 = 0
    Private _t_Refcntu As Int32 = 0
    Private _t_cprj As String = ""
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
    Public Property t_idno() As Int32
      Get
        Return _t_idno
      End Get
      Set(ByVal value As Int32)
        _t_idno = value
      End Set
    End Property
    Public Property t_pono() As String
      Get
        Return _t_pono
      End Get
      Set(ByVal value As String)
        _t_pono = value
      End Set
    End Property
    Public Property t_issu() As Int32
      Get
        Return _t_issu
      End Get
      Set(ByVal value As Int32)
        _t_issu = value
      End Set
    End Property
    Public Property t_issd() As String
      Get
        If Not _t_issd = String.Empty Then
          Return Convert.ToDateTime(_t_issd).ToString("dd/MM/yyyy")
        End If
        Return _t_issd
      End Get
      Set(ByVal value As String)
         _t_issd = value
      End Set
    End Property
    Public Property t_isby() As String
      Get
        Return _t_isby
      End Get
      Set(ByVal value As String)
        _t_isby = value
      End Set
    End Property
    Public Property t_accp() As Int32
      Get
        Return _t_accp
      End Get
      Set(ByVal value As Int32)
        _t_accp = value
      End Set
    End Property
    Public Property t_accd() As String
      Get
        If Not _t_accd = String.Empty Then
          Return Convert.ToDateTime(_t_accd).ToString("dd/MM/yyyy")
        End If
        Return _t_accd
      End Get
      Set(ByVal value As String)
         _t_accd = value
      End Set
    End Property
    Public Property t_acby() As String
      Get
        Return _t_acby
      End Get
      Set(ByVal value As String)
        _t_acby = value
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
    Public Property t_cprj() As String
      Get
        Return _t_cprj
      End Get
      Set(ByVal value As String)
        _t_cprj = value
      End Set
    End Property
    Public Readonly Property DisplayField() As String
      Get
        Return ""
      End Get
    End Property
    Public Readonly Property PrimaryKey() As String
      Get
        Return _t_idno
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
    Public Class PKtpisg208
      Private _t_idno As Int32 = 0
      Public Property t_idno() As Int32
        Get
          Return _t_idno
        End Get
        Set(ByVal value As Int32)
          _t_idno = value
        End Set
      End Property
    End Class
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function tpisg208GetNewRecord() As SIS.TPISG.tpisg208
      Return New SIS.TPISG.tpisg208()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function tpisg208GetByID(ByVal t_idno As Int32) As SIS.TPISG.tpisg208
      Dim Results As SIS.TPISG.tpisg208 = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
        Dim Comp As String = "200"
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sptpisg208" & Comp & "SelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_idno", SqlDbType.Int, t_idno.ToString.Length, t_idno)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.TPISG.tpisg208(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function tpisg208SelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String) As List(Of SIS.TPISG.tpisg208)
      Dim Results As List(Of SIS.TPISG.tpisg208) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "sptpisg208SelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "sptpisg208SelectListFilteres"
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.TPISG.tpisg208)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.TPISG.tpisg208(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function tpisg208SelectCount(ByVal SearchState As Boolean, ByVal SearchText As String) As Integer
      Return _RecordCount
    End Function
      'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Insert, True)> _
    Public Shared Function tpisg208Insert(ByVal Record As SIS.TPISG.tpisg208) As SIS.TPISG.tpisg208
      Dim _Rec As SIS.TPISG.tpisg208 = SIS.TPISG.tpisg208.tpisg208GetNewRecord()
      With _Rec
        .t_idno = Record.t_idno
        .t_pono = Record.t_pono
        .t_issu = Record.t_issu
        .t_issd = Record.t_issd
        .t_isby = Record.t_isby
        .t_accp = Record.t_accp
        .t_accd = Record.t_accd
        .t_acby = Record.t_acby
        .t_Refcntd = Record.t_Refcntd
        .t_Refcntu = Record.t_Refcntu
        .t_cprj = Record.t_cprj
      End With
      Return SIS.TPISG.tpisg208.InsertData(_Rec)
    End Function
    Public Shared Function InsertData(ByVal Record As SIS.TPISG.tpisg208) As SIS.TPISG.tpisg208
      Dim Comp As String = "200"
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sptpisg208" & Comp & "Insert"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_idno", SqlDbType.Int, 11, Record.t_idno)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_pono", SqlDbType.VarChar, 10, Record.t_pono)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_issu", SqlDbType.Int, 11, Record.t_issu)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_issd", SqlDbType.DateTime, 21, Record.t_issd)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_isby", SqlDbType.VarChar, 10, Record.t_isby)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_accp", SqlDbType.Int, 11, Record.t_accp)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_accd", SqlDbType.DateTime, 21, Record.t_accd)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_acby", SqlDbType.VarChar, 10, Record.t_acby)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_Refcntd", SqlDbType.Int, 11, Record.t_Refcntd)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_Refcntu", SqlDbType.Int, 11, Record.t_Refcntu)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_cprj", SqlDbType.VarChar, 10, Record.t_cprj)
          Cmd.Parameters.Add("@Return_t_idno", SqlDbType.Int, 11)
          Cmd.Parameters("@Return_t_idno").Direction = ParameterDirection.Output
          Con.Open()
          Cmd.ExecuteNonQuery()
          Record.t_idno = Cmd.Parameters("@Return_t_idno").Value
        End Using
      End Using
      Return Record
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)> _
    Public Shared Function tpisg208Update(ByVal Record As SIS.TPISG.tpisg208) As SIS.TPISG.tpisg208
      Dim _Rec As SIS.TPISG.tpisg208 = SIS.TPISG.tpisg208.tpisg208GetByID(Record.t_idno)
      With _Rec
        .t_pono = Record.t_pono
        .t_issu = Record.t_issu
        .t_issd = Record.t_issd
        .t_isby = Record.t_isby
        .t_accp = Record.t_accp
        .t_accd = Record.t_accd
        .t_acby = Record.t_acby
        .t_Refcntd = Record.t_Refcntd
        .t_Refcntu = Record.t_Refcntu
        .t_cprj = Record.t_cprj
      End With
      Return SIS.TPISG.tpisg208.UpdateData(_Rec)
    End Function
    Public Shared Function UpdateData(ByVal Record As SIS.TPISG.tpisg208) As SIS.TPISG.tpisg208
      Dim Comp As String = "200"
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sptpisg208" & Comp & "Update"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_t_idno", SqlDbType.Int, 11, Record.t_idno)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_idno", SqlDbType.Int, 11, Record.t_idno)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_pono", SqlDbType.VarChar, 10, Record.t_pono)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_issu", SqlDbType.Int, 11, Record.t_issu)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_issd", SqlDbType.DateTime, 21, Record.t_issd)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_isby", SqlDbType.VarChar, 10, Record.t_isby)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_accp", SqlDbType.Int, 11, Record.t_accp)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_accd", SqlDbType.DateTime, 21, Record.t_accd)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_acby", SqlDbType.VarChar, 10, Record.t_acby)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_Refcntd", SqlDbType.Int, 11, Record.t_Refcntd)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_Refcntu", SqlDbType.Int, 11, Record.t_Refcntu)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_cprj", SqlDbType.VarChar, 10, Record.t_cprj)
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
    Public Shared Function tpisg208Delete(ByVal Record As SIS.TPISG.tpisg208) As Int32
      Dim _Result as Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sptpisg208Delete"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_t_idno",SqlDbType.Int,Record.t_idno.ToString.Length, Record.t_idno)
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
      Try
        For Each pi As System.Reflection.PropertyInfo In Me.GetType.GetProperties
          If pi.MemberType = Reflection.MemberTypes.Property Then
            Try
              Dim Found As Boolean = False
              For I As Integer = 0 To Reader.FieldCount - 1
                If Reader.GetName(I).ToLower = pi.Name.ToLower Then
                  Found = True
                  Exit For
                End If
              Next
              If Found Then
                If Convert.IsDBNull(Reader(pi.Name)) Then
                  Select Case Reader.GetDataTypeName(Reader.GetOrdinal(pi.Name))
                    Case "decimal"
                      CallByName(Me, pi.Name, CallType.Let, "0.00")
                    Case "bit"
                      CallByName(Me, pi.Name, CallType.Let, Boolean.FalseString)
                    Case Else
                      CallByName(Me, pi.Name, CallType.Let, String.Empty)
                  End Select
                Else
                  CallByName(Me, pi.Name, CallType.Let, Reader(pi.Name))
                End If
              End If
            Catch ex As Exception
            End Try
          End If
        Next
      Catch ex As Exception
      End Try
    End Sub
    Public Sub New()
    End Sub
  End Class
End Namespace
