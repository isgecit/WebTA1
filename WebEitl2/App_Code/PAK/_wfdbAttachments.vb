Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.WFDB
  <DataObject()> _
  Partial Public Class wfdbAttachments
    Private Shared _RecordCount As Integer
    Private _t_drid As String = ""
    Private _t_dcid As String = ""
    Private _t_indx As String = ""
    Private _t_prcd As String = ""
    Private _t_fnam As String = ""
    Private _t_lbcd As String = ""
    Private _t_atby As String = ""
    Private _t_Refcntd As Int32 = 0
    Private _t_Refcntu As Int32 = 0
    Private _t_hndl As String = ""
    Private _t_aton As String = ""
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
    Public Property t_drid() As String
      Get
        Return _t_drid
      End Get
      Set(ByVal value As String)
        _t_drid = value
      End Set
    End Property
    Public Property t_dcid() As String
      Get
        Return _t_dcid
      End Get
      Set(ByVal value As String)
        _t_dcid = value
      End Set
    End Property
    Public Property t_indx() As String
      Get
        Return _t_indx
      End Get
      Set(ByVal value As String)
        _t_indx = value
      End Set
    End Property
    Public Property t_prcd() As String
      Get
        Return _t_prcd
      End Get
      Set(ByVal value As String)
        _t_prcd = value
      End Set
    End Property
    Public Property t_fnam() As String
      Get
        Return _t_fnam
      End Get
      Set(ByVal value As String)
        _t_fnam = value
      End Set
    End Property
    Public Property t_lbcd() As String
      Get
        Return _t_lbcd
      End Get
      Set(ByVal value As String)
        _t_lbcd = value
      End Set
    End Property
    Public Property t_atby() As String
      Get
        Return _t_atby
      End Get
      Set(ByVal value As String)
        _t_atby = value
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
    Public Property t_hndl() As String
      Get
        Return _t_hndl
      End Get
      Set(ByVal value As String)
        _t_hndl = value
      End Set
    End Property
    Public Property t_aton() As String
      Get
        If Not _t_aton = String.Empty Then
          Return Convert.ToDateTime(_t_aton).ToString("dd/MM/yyyy")
        End If
        Return _t_aton
      End Get
      Set(ByVal value As String)
         _t_aton = value
      End Set
    End Property
    Public Readonly Property DisplayField() As String
      Get
        Return ""
      End Get
    End Property
    Public Readonly Property PrimaryKey() As String
      Get
        Return _t_indx & "|" & _t_dcid
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
    Public Class PKwfdbAttachments
      Private _t_indx As String = ""
      Private _t_dcid As String = ""
      Public Property t_indx() As String
        Get
          Return _t_indx
        End Get
        Set(ByVal value As String)
          _t_indx = value
        End Set
      End Property
      Public Property t_dcid() As String
        Get
          Return _t_dcid
        End Get
        Set(ByVal value As String)
          _t_dcid = value
        End Set
      End Property
    End Class
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function wfdbAttachmentsGetNewRecord() As SIS.WFDB.wfdbAttachments
      Return New SIS.WFDB.wfdbAttachments()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function wfdbAttachmentsGetByID(ByVal t_indx As String, ByVal t_dcid As String) As SIS.WFDB.wfdbAttachments
      Dim Results As SIS.WFDB.wfdbAttachments = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spwfdbAttachmentsSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_indx", SqlDbType.VarChar, t_indx.ToString.Length, t_indx)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_dcid", SqlDbType.VarChar, t_dcid.ToString.Length, t_dcid)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.WFDB.wfdbAttachments(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function wfdbAttachmentsSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String) As List(Of SIS.WFDB.wfdbAttachments)
      Dim Results As List(Of SIS.WFDB.wfdbAttachments) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "spwfdbAttachmentsSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "spwfdbAttachmentsSelectListFilteres"
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.WFDB.wfdbAttachments)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.WFDB.wfdbAttachments(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function wfdbAttachmentsSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String) As Integer
      Return _RecordCount
    End Function
    'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Insert, True)>
    Public Shared Function wfdbAttachmentsInsert(ByVal Record As SIS.WFDB.wfdbAttachments) As SIS.WFDB.wfdbAttachments
      Dim _Rec As SIS.WFDB.wfdbAttachments = SIS.WFDB.wfdbAttachments.wfdbAttachmentsGetNewRecord()
      With _Rec
        .t_drid = Record.t_drid
        .t_dcid = Record.t_dcid
        .t_indx = Record.t_indx
        .t_prcd = Record.t_prcd
        .t_fnam = Record.t_fnam
        .t_lbcd = Record.t_lbcd
        .t_atby = Record.t_atby
        .t_Refcntd = Record.t_Refcntd
        .t_Refcntu = Record.t_Refcntu
        .t_hndl = Record.t_hndl
        .t_aton = Record.t_aton
      End With
      Return SIS.WFDB.wfdbAttachments.InsertData(_Rec)
    End Function
    Public Shared Function InsertData(ByVal Record As SIS.WFDB.wfdbAttachments) As SIS.WFDB.wfdbAttachments
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spwfdbAttachmentsInsert"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_drid", SqlDbType.VarChar, 51, Record.t_drid)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_dcid", SqlDbType.VarChar, 201, Record.t_dcid)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_indx", SqlDbType.VarChar, 51, Record.t_indx)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_prcd", SqlDbType.VarChar, 51, Record.t_prcd)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_fnam", SqlDbType.VarChar, 251, Record.t_fnam)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_lbcd", SqlDbType.VarChar, 51, Record.t_lbcd)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_atby", SqlDbType.VarChar, 51, Record.t_atby)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_Refcntd", SqlDbType.Int, 11, Record.t_Refcntd)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_Refcntu", SqlDbType.Int, 11, Record.t_Refcntu)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_hndl", SqlDbType.VarChar, 201, Record.t_hndl)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_aton", SqlDbType.DateTime, 21, Record.t_aton)
          Cmd.Parameters.Add("@Return_t_indx", SqlDbType.VarChar, 51)
          Cmd.Parameters("@Return_t_indx").Direction = ParameterDirection.Output
          Cmd.Parameters.Add("@Return_t_dcid", SqlDbType.VarChar, 201)
          Cmd.Parameters("@Return_t_dcid").Direction = ParameterDirection.Output
          Con.Open()
          Cmd.ExecuteNonQuery()
          Record.t_indx = Cmd.Parameters("@Return_t_indx").Value
          Record.t_dcid = Cmd.Parameters("@Return_t_dcid").Value
        End Using
      End Using
      Return Record
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)>
    Public Shared Function wfdbAttachmentsUpdate(ByVal Record As SIS.WFDB.wfdbAttachments) As SIS.WFDB.wfdbAttachments
      Dim _Rec As SIS.WFDB.wfdbAttachments = SIS.WFDB.wfdbAttachments.UZ_wfdbAttachmentsGetByID(Record.t_indx, Record.t_dcid)
      With _Rec
        .t_drid = Record.t_drid
        .t_prcd = Record.t_prcd
        .t_fnam = Record.t_fnam
        .t_lbcd = Record.t_lbcd
        .t_atby = Record.t_atby
        .t_Refcntd = Record.t_Refcntd
        .t_Refcntu = Record.t_Refcntu
        .t_hndl = Record.t_hndl
        .t_aton = Record.t_aton
      End With
      Return SIS.WFDB.wfdbAttachments.UpdateData(_Rec)
    End Function
    Public Shared Function UpdateData(ByVal Record As SIS.WFDB.wfdbAttachments) As SIS.WFDB.wfdbAttachments
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spwfdbAttachmentsUpdate"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_t_dcid", SqlDbType.VarChar, 201, Record.t_dcid)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_t_indx", SqlDbType.VarChar, 51, Record.t_indx)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_drid", SqlDbType.VarChar, 51, Record.t_drid)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_dcid", SqlDbType.VarChar, 201, Record.t_dcid)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_indx", SqlDbType.VarChar, 51, Record.t_indx)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_prcd", SqlDbType.VarChar, 51, Record.t_prcd)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_fnam", SqlDbType.VarChar, 251, Record.t_fnam)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_lbcd", SqlDbType.VarChar, 51, Record.t_lbcd)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_atby", SqlDbType.VarChar, 51, Record.t_atby)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_Refcntd", SqlDbType.Int, 11, Record.t_Refcntd)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_Refcntu", SqlDbType.Int, 11, Record.t_Refcntu)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_hndl", SqlDbType.VarChar, 201, Record.t_hndl)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_aton", SqlDbType.DateTime, 21, Record.t_aton)
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
    <DataObjectMethod(DataObjectMethodType.Delete, True)>
    Public Shared Function wfdbAttachmentsDelete(ByVal Record As SIS.WFDB.wfdbAttachments) As Int32
      Dim _Result As Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spwfdbAttachmentsDelete"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_t_indx", SqlDbType.VarChar, Record.t_indx.ToString.Length, Record.t_indx)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_t_dcid", SqlDbType.VarChar, Record.t_dcid.ToString.Length, Record.t_dcid)
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
