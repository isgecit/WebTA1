Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.ELOG
  <DataObject()> _
  Partial Public Class elogChargeCodes
    Private Shared _RecordCount As Integer
    Private _ChargeCategoryID As Int32 = 0
    Private _ChargeCodeID As Int32 = 0
    Private _Description As String = ""
    Private _ELOG_ChargeCategories1_Description As String = ""
    Private _FK_ELOG_ChargeCodes_ChargeCategoryID As SIS.ELOG.elogChargeCategories = Nothing
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
    Public Property ChargeCategoryID() As Int32
      Get
        Return _ChargeCategoryID
      End Get
      Set(ByVal value As Int32)
        _ChargeCategoryID = value
      End Set
    End Property
    Public Property ChargeCodeID() As Int32
      Get
        Return _ChargeCodeID
      End Get
      Set(ByVal value As Int32)
        _ChargeCodeID = value
      End Set
    End Property
    Public Property Description() As String
      Get
        Return _Description
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _Description = ""
         Else
           _Description = value
         End If
      End Set
    End Property
    Public Property ELOG_ChargeCategories1_Description() As String
      Get
        Return _ELOG_ChargeCategories1_Description
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _ELOG_ChargeCategories1_Description = ""
         Else
           _ELOG_ChargeCategories1_Description = value
         End If
      End Set
    End Property
    Public Readonly Property DisplayField() As String
      Get
        Return "" & _Description.ToString.PadRight(100, " ")
      End Get
    End Property
    Public Readonly Property PrimaryKey() As String
      Get
        Return _ChargeCategoryID & "|" & _ChargeCodeID
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
    Public Class PKelogChargeCodes
      Private _ChargeCategoryID As Int32 = 0
      Private _ChargeCodeID As Int32 = 0
      Public Property ChargeCategoryID() As Int32
        Get
          Return _ChargeCategoryID
        End Get
        Set(ByVal value As Int32)
          _ChargeCategoryID = value
        End Set
      End Property
      Public Property ChargeCodeID() As Int32
        Get
          Return _ChargeCodeID
        End Get
        Set(ByVal value As Int32)
          _ChargeCodeID = value
        End Set
      End Property
    End Class
    Public ReadOnly Property FK_ELOG_ChargeCodes_ChargeCategoryID() As SIS.ELOG.elogChargeCategories
      Get
        If _FK_ELOG_ChargeCodes_ChargeCategoryID Is Nothing Then
          _FK_ELOG_ChargeCodes_ChargeCategoryID = SIS.ELOG.elogChargeCategories.elogChargeCategoriesGetByID(_ChargeCategoryID)
        End If
        Return _FK_ELOG_ChargeCodes_ChargeCategoryID
      End Get
    End Property
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function elogChargeCodesSelectList(ByVal OrderBy As String) As List(Of SIS.ELOG.elogChargeCodes)
      Dim Results As List(Of SIS.ELOG.elogChargeCodes) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spelogChargeCodesSelectList"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.ELOG.elogChargeCodes)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.ELOG.elogChargeCodes(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function elogChargeCodesGetNewRecord() As SIS.ELOG.elogChargeCodes
      Return New SIS.ELOG.elogChargeCodes()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function elogChargeCodesGetByID(ByVal ChargeCategoryID As Int32, ByVal ChargeCodeID As Int32) As SIS.ELOG.elogChargeCodes
      Dim Results As SIS.ELOG.elogChargeCodes = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spelogChargeCodesSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ChargeCategoryID",SqlDbType.Int,ChargeCategoryID.ToString.Length, ChargeCategoryID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ChargeCodeID",SqlDbType.Int,ChargeCodeID.ToString.Length, ChargeCodeID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.ELOG.elogChargeCodes(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function elogChargeCodesSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal ChargeCategoryID As Int32) As List(Of SIS.ELOG.elogChargeCodes)
      Dim Results As List(Of SIS.ELOG.elogChargeCodes) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "spelogChargeCodesSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "spelogChargeCodesSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_ChargeCategoryID",SqlDbType.Int,10, IIf(ChargeCategoryID = Nothing, 0,ChargeCategoryID))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.ELOG.elogChargeCodes)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.ELOG.elogChargeCodes(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function elogChargeCodesSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String, ByVal ChargeCategoryID As Int32) As Integer
      Return _RecordCount
    End Function
      'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function elogChargeCodesGetByID(ByVal ChargeCategoryID As Int32, ByVal ChargeCodeID As Int32, ByVal Filter_ChargeCategoryID As Int32) As SIS.ELOG.elogChargeCodes
      Return elogChargeCodesGetByID(ChargeCategoryID, ChargeCodeID)
    End Function
    <DataObjectMethod(DataObjectMethodType.Insert, True)> _
    Public Shared Function elogChargeCodesInsert(ByVal Record As SIS.ELOG.elogChargeCodes) As SIS.ELOG.elogChargeCodes
      Dim _Rec As SIS.ELOG.elogChargeCodes = SIS.ELOG.elogChargeCodes.elogChargeCodesGetNewRecord()
      With _Rec
        .ChargeCategoryID = Record.ChargeCategoryID
        .Description = Record.Description
      End With
      Return SIS.ELOG.elogChargeCodes.InsertData(_Rec)
    End Function
    Public Shared Function InsertData(ByVal Record As SIS.ELOG.elogChargeCodes) As SIS.ELOG.elogChargeCodes
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spelogChargeCodesInsert"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ChargeCategoryID",SqlDbType.Int,11, Record.ChargeCategoryID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Description",SqlDbType.NVarChar,101, Iif(Record.Description= "" ,Convert.DBNull, Record.Description))
          Cmd.Parameters.Add("@Return_ChargeCategoryID", SqlDbType.Int, 11)
          Cmd.Parameters("@Return_ChargeCategoryID").Direction = ParameterDirection.Output
          Cmd.Parameters.Add("@Return_ChargeCodeID", SqlDbType.Int, 11)
          Cmd.Parameters("@Return_ChargeCodeID").Direction = ParameterDirection.Output
          Con.Open()
          Cmd.ExecuteNonQuery()
          Record.ChargeCategoryID = Cmd.Parameters("@Return_ChargeCategoryID").Value
          Record.ChargeCodeID = Cmd.Parameters("@Return_ChargeCodeID").Value
        End Using
      End Using
      Return Record
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)> _
    Public Shared Function elogChargeCodesUpdate(ByVal Record As SIS.ELOG.elogChargeCodes) As SIS.ELOG.elogChargeCodes
      Dim _Rec As SIS.ELOG.elogChargeCodes = SIS.ELOG.elogChargeCodes.elogChargeCodesGetByID(Record.ChargeCategoryID, Record.ChargeCodeID)
      With _Rec
        .Description = Record.Description
      End With
      Return SIS.ELOG.elogChargeCodes.UpdateData(_Rec)
    End Function
    Public Shared Function UpdateData(ByVal Record As SIS.ELOG.elogChargeCodes) As SIS.ELOG.elogChargeCodes
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spelogChargeCodesUpdate"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_ChargeCategoryID",SqlDbType.Int,11, Record.ChargeCategoryID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_ChargeCodeID",SqlDbType.Int,11, Record.ChargeCodeID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ChargeCategoryID",SqlDbType.Int,11, Record.ChargeCategoryID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Description",SqlDbType.NVarChar,101, Iif(Record.Description= "" ,Convert.DBNull, Record.Description))
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
    Public Shared Function elogChargeCodesDelete(ByVal Record As SIS.ELOG.elogChargeCodes) As Int32
      Dim _Result as Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spelogChargeCodesDelete"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_ChargeCategoryID",SqlDbType.Int,Record.ChargeCategoryID.ToString.Length, Record.ChargeCategoryID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_ChargeCodeID",SqlDbType.Int,Record.ChargeCodeID.ToString.Length, Record.ChargeCodeID)
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
'    Autocomplete Method
    Public Shared Function SelectelogChargeCodesAutoCompleteList(ByVal Prefix As String, ByVal count As Integer, ByVal contextKey As String) As String()
      Dim Results As List(Of String) = Nothing
      Dim aVal() As String = contextKey.Split("|".ToCharArray)
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spelogChargeCodesAutoCompleteList"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@prefix", SqlDbType.NVarChar, 50, Prefix)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@records", SqlDbType.Int, -1, count)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@bycode", SqlDbType.Int, 1, IIf(IsNumeric(Prefix), 0, 1))
          Results = New List(Of String)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Not Reader.HasRows Then
            Results.Add(AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem("---Select Value---".PadRight(100, " "),"" & "|" & ""))
          End If
          While (Reader.Read())
            Dim Tmp As SIS.ELOG.elogChargeCodes = New SIS.ELOG.elogChargeCodes(Reader)
            Results.Add(AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem(Tmp.DisplayField, Tmp.PrimaryKey))
          End While
          Reader.Close()
        End Using
      End Using
      Return Results.ToArray
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
