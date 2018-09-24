Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.ELOG
  <DataObject()> _
  Partial Public Class elogBLDetails
    Private Shared _RecordCount As Integer
    Private _BLID As String = ""
    Private _SerialNo As Int32 = 0
    Private _SizeAndTypeOfContainer As String = ""
    Private _ContainerNumber As String = ""
    Private _Remarks As String = ""
    Private _ELOG_BLHeader1_BLNumber As String = ""
    Private _FK_ELOG_BLDetails_BLID As SIS.ELOG.elogBLHeader = Nothing
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
    Public Property BLID() As String
      Get
        Return _BLID
      End Get
      Set(ByVal value As String)
        _BLID = value
      End Set
    End Property
    Public Property SerialNo() As Int32
      Get
        Return _SerialNo
      End Get
      Set(ByVal value As Int32)
        _SerialNo = value
      End Set
    End Property
    Public Property SizeAndTypeOfContainer() As String
      Get
        Return _SizeAndTypeOfContainer
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _SizeAndTypeOfContainer = ""
         Else
           _SizeAndTypeOfContainer = value
         End If
      End Set
    End Property
    Public Property ContainerNumber() As String
      Get
        Return _ContainerNumber
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _ContainerNumber = ""
         Else
           _ContainerNumber = value
         End If
      End Set
    End Property
    Public Property Remarks() As String
      Get
        Return _Remarks
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _Remarks = ""
         Else
           _Remarks = value
         End If
      End Set
    End Property
    Public Property ELOG_BLHeader1_BLNumber() As String
      Get
        Return _ELOG_BLHeader1_BLNumber
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _ELOG_BLHeader1_BLNumber = ""
         Else
           _ELOG_BLHeader1_BLNumber = value
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
        Return _BLID & "|" & _SerialNo
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
    Public Class PKelogBLDetails
      Private _BLID As String = ""
      Private _SerialNo As Int32 = 0
      Public Property BLID() As String
        Get
          Return _BLID
        End Get
        Set(ByVal value As String)
          _BLID = value
        End Set
      End Property
      Public Property SerialNo() As Int32
        Get
          Return _SerialNo
        End Get
        Set(ByVal value As Int32)
          _SerialNo = value
        End Set
      End Property
    End Class
    Public ReadOnly Property FK_ELOG_BLDetails_BLID() As SIS.ELOG.elogBLHeader
      Get
        If _FK_ELOG_BLDetails_BLID Is Nothing Then
          _FK_ELOG_BLDetails_BLID = SIS.ELOG.elogBLHeader.elogBLHeaderGetByID(_BLID)
        End If
        Return _FK_ELOG_BLDetails_BLID
      End Get
    End Property
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function elogBLDetailsGetNewRecord() As SIS.ELOG.elogBLDetails
      Return New SIS.ELOG.elogBLDetails()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function elogBLDetailsGetByID(ByVal BLID As String, ByVal SerialNo As Int32) As SIS.ELOG.elogBLDetails
      Dim Results As SIS.ELOG.elogBLDetails = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spelogBLDetailsSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@BLID",SqlDbType.NVarChar,BLID.ToString.Length, BLID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SerialNo",SqlDbType.Int,SerialNo.ToString.Length, SerialNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.ELOG.elogBLDetails(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function elogBLDetailsSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal BLID As String) As List(Of SIS.ELOG.elogBLDetails)
      Dim Results As List(Of SIS.ELOG.elogBLDetails) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "spelogBLDetailsSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "spelogBLDetailsSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_BLID",SqlDbType.NVarChar,9, IIf(BLID Is Nothing, String.Empty,BLID))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.ELOG.elogBLDetails)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.ELOG.elogBLDetails(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function elogBLDetailsSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String, ByVal BLID As String) As Integer
      Return _RecordCount
    End Function
      'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function elogBLDetailsGetByID(ByVal BLID As String, ByVal SerialNo As Int32, ByVal Filter_BLID As String) As SIS.ELOG.elogBLDetails
      Return elogBLDetailsGetByID(BLID, SerialNo)
    End Function
    <DataObjectMethod(DataObjectMethodType.Insert, True)> _
    Public Shared Function elogBLDetailsInsert(ByVal Record As SIS.ELOG.elogBLDetails) As SIS.ELOG.elogBLDetails
      Dim _Rec As SIS.ELOG.elogBLDetails = SIS.ELOG.elogBLDetails.elogBLDetailsGetNewRecord()
      With _Rec
        .BLID = Record.BLID
        .SerialNo = Record.SerialNo
        .SizeAndTypeOfContainer = Record.SizeAndTypeOfContainer
        .ContainerNumber = Record.ContainerNumber
        .Remarks = Record.Remarks
      End With
      Return SIS.ELOG.elogBLDetails.InsertData(_Rec)
    End Function
    Public Shared Function InsertData(ByVal Record As SIS.ELOG.elogBLDetails) As SIS.ELOG.elogBLDetails
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spelogBLDetailsInsert"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@BLID",SqlDbType.NVarChar,10, Record.BLID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SerialNo",SqlDbType.Int,11, Record.SerialNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SizeAndTypeOfContainer",SqlDbType.NVarChar,51, Iif(Record.SizeAndTypeOfContainer= "" ,Convert.DBNull, Record.SizeAndTypeOfContainer))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ContainerNumber",SqlDbType.NVarChar,51, Iif(Record.ContainerNumber= "" ,Convert.DBNull, Record.ContainerNumber))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Remarks",SqlDbType.NVarChar,101, Iif(Record.Remarks= "" ,Convert.DBNull, Record.Remarks))
          Cmd.Parameters.Add("@Return_BLID", SqlDbType.NVarChar, 10)
          Cmd.Parameters("@Return_BLID").Direction = ParameterDirection.Output
          Cmd.Parameters.Add("@Return_SerialNo", SqlDbType.Int, 11)
          Cmd.Parameters("@Return_SerialNo").Direction = ParameterDirection.Output
          Con.Open()
          Cmd.ExecuteNonQuery()
          Record.BLID = Cmd.Parameters("@Return_BLID").Value
          Record.SerialNo = Cmd.Parameters("@Return_SerialNo").Value
        End Using
      End Using
      Return Record
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)> _
    Public Shared Function elogBLDetailsUpdate(ByVal Record As SIS.ELOG.elogBLDetails) As SIS.ELOG.elogBLDetails
      Dim _Rec As SIS.ELOG.elogBLDetails = SIS.ELOG.elogBLDetails.elogBLDetailsGetByID(Record.BLID, Record.SerialNo)
      With _Rec
        .SizeAndTypeOfContainer = Record.SizeAndTypeOfContainer
        .ContainerNumber = Record.ContainerNumber
        .Remarks = Record.Remarks
      End With
      Return SIS.ELOG.elogBLDetails.UpdateData(_Rec)
    End Function
    Public Shared Function UpdateData(ByVal Record As SIS.ELOG.elogBLDetails) As SIS.ELOG.elogBLDetails
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spelogBLDetailsUpdate"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_BLID",SqlDbType.NVarChar,10, Record.BLID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_SerialNo",SqlDbType.Int,11, Record.SerialNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@BLID",SqlDbType.NVarChar,10, Record.BLID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SerialNo",SqlDbType.Int,11, Record.SerialNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SizeAndTypeOfContainer",SqlDbType.NVarChar,51, Iif(Record.SizeAndTypeOfContainer= "" ,Convert.DBNull, Record.SizeAndTypeOfContainer))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ContainerNumber",SqlDbType.NVarChar,51, Iif(Record.ContainerNumber= "" ,Convert.DBNull, Record.ContainerNumber))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Remarks",SqlDbType.NVarChar,101, Iif(Record.Remarks= "" ,Convert.DBNull, Record.Remarks))
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
    Public Shared Function elogBLDetailsDelete(ByVal Record As SIS.ELOG.elogBLDetails) As Int32
      Dim _Result as Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spelogBLDetailsDelete"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_BLID",SqlDbType.NVarChar,Record.BLID.ToString.Length, Record.BLID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_SerialNo",SqlDbType.Int,Record.SerialNo.ToString.Length, Record.SerialNo)
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
              If Convert.IsDBNull(Reader(pi.Name)) Then
                CallByName(Me, pi.Name, CallType.Let, String.Empty)
              Else
                CallByName(Me, pi.Name, CallType.Let, Reader(pi.Name))
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
