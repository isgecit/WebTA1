Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.TA
  <DataObject()> _
  Partial Public Class taD_SwrDA
    Private Shared _RecordCount As Integer
    Private _SerialNo As Int32 = 0
    Private _CategoryID As Int32 = 0
    Private _CityTypeID As String = ""
    Private _HotelStayDA As String = "0.00"
    Private _SwrDA As String = "0.00"
    Private _FromDate As String = ""
    Private _TillDate As String = ""
    Private _Active As Boolean = False
    Private _TA_Categories1_cmba As String = ""
    Private _TA_CityTypes2_CityTypeName As String = ""
    Private _FK_TA_D_SwrDA_CategoryID As SIS.TA.taCategories = Nothing
    Private _FK_TA_D_SwrDA_CityTypeID As SIS.TA.taCityTypes = Nothing
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
    Public Property SerialNo() As Int32
      Get
        Return _SerialNo
      End Get
      Set(ByVal value As Int32)
        _SerialNo = value
      End Set
    End Property
    Public Property CategoryID() As Int32
      Get
        Return _CategoryID
      End Get
      Set(ByVal value As Int32)
        _CategoryID = value
      End Set
    End Property
    Public Property CityTypeID() As String
      Get
        Return _CityTypeID
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _CityTypeID = ""
         Else
           _CityTypeID = value
         End If
      End Set
    End Property
    Public Property HotelStayDA() As String
      Get
        Return _HotelStayDA
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _HotelStayDA = "0.00"
         Else
           _HotelStayDA = value
         End If
      End Set
    End Property
    Public Property SwrDA() As String
      Get
        Return _SwrDA
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _SwrDA = "0.00"
         Else
           _SwrDA = value
         End If
      End Set
    End Property
    Public Property FromDate() As String
      Get
        If Not _FromDate = String.Empty Then
          Return Convert.ToDateTime(_FromDate).ToString("dd/MM/yyyy")
        End If
        Return _FromDate
      End Get
      Set(ByVal value As String)
         _FromDate = value
      End Set
    End Property
    Public Property TillDate() As String
      Get
        If Not _TillDate = String.Empty Then
          Return Convert.ToDateTime(_TillDate).ToString("dd/MM/yyyy")
        End If
        Return _TillDate
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _TillDate = ""
         Else
           _TillDate = value
         End If
      End Set
    End Property
    Public Property Active() As Boolean
      Get
        Return _Active
      End Get
      Set(ByVal value As Boolean)
        _Active = value
      End Set
    End Property
    Public Property TA_Categories1_cmba() As String
      Get
        Return _TA_Categories1_cmba
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _TA_Categories1_cmba = ""
         Else
           _TA_Categories1_cmba = value
         End If
      End Set
    End Property
    Public Property TA_CityTypes2_CityTypeName() As String
      Get
        Return _TA_CityTypes2_CityTypeName
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _TA_CityTypes2_CityTypeName = ""
         Else
           _TA_CityTypes2_CityTypeName = value
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
        Return _SerialNo
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
    Public Class PKtaD_SwrDA
      Private _SerialNo As Int32 = 0
      Public Property SerialNo() As Int32
        Get
          Return _SerialNo
        End Get
        Set(ByVal value As Int32)
          _SerialNo = value
        End Set
      End Property
    End Class
    Public ReadOnly Property FK_TA_D_SwrDA_CategoryID() As SIS.TA.taCategories
      Get
        If _FK_TA_D_SwrDA_CategoryID Is Nothing Then
          _FK_TA_D_SwrDA_CategoryID = SIS.TA.taCategories.taCategoriesGetByID(_CategoryID)
        End If
        Return _FK_TA_D_SwrDA_CategoryID
      End Get
    End Property
    Public ReadOnly Property FK_TA_D_SwrDA_CityTypeID() As SIS.TA.taCityTypes
      Get
        If _FK_TA_D_SwrDA_CityTypeID Is Nothing Then
          _FK_TA_D_SwrDA_CityTypeID = SIS.TA.taCityTypes.taCityTypesGetByID(_CityTypeID)
        End If
        Return _FK_TA_D_SwrDA_CityTypeID
      End Get
    End Property
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function taD_SwrDAGetNewRecord() As SIS.TA.taD_SwrDA
      Return New SIS.TA.taD_SwrDA()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function taD_SwrDAGetByID(ByVal SerialNo As Int32) As SIS.TA.taD_SwrDA
      Dim Results As SIS.TA.taD_SwrDA = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sptaD_SwrDASelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SerialNo",SqlDbType.Int,SerialNo.ToString.Length, SerialNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.TA.taD_SwrDA(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function GetByCategoryID(ByVal CategoryID As Int32, ByVal OrderBy as String) As List(Of SIS.TA.taD_SwrDA)
      Dim Results As List(Of SIS.TA.taD_SwrDA) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          If OrderBy = String.Empty Then OrderBy = "SerialNo DESC"
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sptaD_SwrDASelectByCategoryID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CategoryID",SqlDbType.Int,CategoryID.ToString.Length, CategoryID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.TA.taD_SwrDA)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.TA.taD_SwrDA(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function taD_SwrDASelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal CategoryID As Int32, ByVal CityTypeID As String) As List(Of SIS.TA.taD_SwrDA)
      Dim Results As List(Of SIS.TA.taD_SwrDA) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          If OrderBy = String.Empty Then OrderBy = "SerialNo DESC"
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "sptaD_SwrDASelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "sptaD_SwrDASelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_CategoryID",SqlDbType.Int,10, IIf(CategoryID = Nothing, 0,CategoryID))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_CityTypeID",SqlDbType.NVarChar,6, IIf(CityTypeID Is Nothing, String.Empty,CityTypeID))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.TA.taD_SwrDA)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.TA.taD_SwrDA(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function taD_SwrDASelectCount(ByVal SearchState As Boolean, ByVal SearchText As String, ByVal CategoryID As Int32, ByVal CityTypeID As String) As Integer
      Return _RecordCount
    End Function
      'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function taD_SwrDAGetByID(ByVal SerialNo As Int32, ByVal Filter_CategoryID As Int32, ByVal Filter_CityTypeID As String) As SIS.TA.taD_SwrDA
      Return taD_SwrDAGetByID(SerialNo)
    End Function
    <DataObjectMethod(DataObjectMethodType.Insert, True)> _
    Public Shared Function taD_SwrDAInsert(ByVal Record As SIS.TA.taD_SwrDA) As SIS.TA.taD_SwrDA
      Dim _Rec As SIS.TA.taD_SwrDA = SIS.TA.taD_SwrDA.taD_SwrDAGetNewRecord()
      With _Rec
        .CategoryID = Record.CategoryID
        .CityTypeID = Record.CityTypeID
        .HotelStayDA = Record.HotelStayDA
        .SwrDA = Record.SwrDA
        .FromDate = Record.FromDate
        .TillDate = Record.TillDate
        .Active = Record.Active
      End With
      Return SIS.TA.taD_SwrDA.InsertData(_Rec)
    End Function
    Public Shared Function InsertData(ByVal Record As SIS.TA.taD_SwrDA) As SIS.TA.taD_SwrDA
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sptaD_SwrDAInsert"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CategoryID",SqlDbType.Int,11, Record.CategoryID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CityTypeID",SqlDbType.NVarChar,7, Iif(Record.CityTypeID= "" ,Convert.DBNull, Record.CityTypeID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@HotelStayDA",SqlDbType.Decimal,13, Iif(Record.HotelStayDA= "" ,Convert.DBNull, Record.HotelStayDA))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SwrDA",SqlDbType.Decimal,13, Iif(Record.SwrDA= "" ,Convert.DBNull, Record.SwrDA))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FromDate",SqlDbType.DateTime,21, Record.FromDate)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TillDate",SqlDbType.DateTime,21, Iif(Record.TillDate= "" ,Convert.DBNull, Record.TillDate))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Active",SqlDbType.Bit,3, Record.Active)
          Cmd.Parameters.Add("@Return_SerialNo", SqlDbType.Int, 11)
          Cmd.Parameters("@Return_SerialNo").Direction = ParameterDirection.Output
          Con.Open()
          Cmd.ExecuteNonQuery()
          Record.SerialNo = Cmd.Parameters("@Return_SerialNo").Value
        End Using
      End Using
      Return Record
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)> _
    Public Shared Function taD_SwrDAUpdate(ByVal Record As SIS.TA.taD_SwrDA) As SIS.TA.taD_SwrDA
      Dim _Rec As SIS.TA.taD_SwrDA = SIS.TA.taD_SwrDA.taD_SwrDAGetByID(Record.SerialNo)
      With _Rec
        .CategoryID = Record.CategoryID
        .CityTypeID = Record.CityTypeID
        .HotelStayDA = Record.HotelStayDA
        .SwrDA = Record.SwrDA
        .FromDate = Record.FromDate
        .TillDate = Record.TillDate
        .Active = Record.Active
      End With
      Return SIS.TA.taD_SwrDA.UpdateData(_Rec)
    End Function
    Public Shared Function UpdateData(ByVal Record As SIS.TA.taD_SwrDA) As SIS.TA.taD_SwrDA
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sptaD_SwrDAUpdate"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_SerialNo",SqlDbType.Int,11, Record.SerialNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CategoryID",SqlDbType.Int,11, Record.CategoryID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CityTypeID",SqlDbType.NVarChar,7, Iif(Record.CityTypeID= "" ,Convert.DBNull, Record.CityTypeID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@HotelStayDA",SqlDbType.Decimal,13, Iif(Record.HotelStayDA= "" ,Convert.DBNull, Record.HotelStayDA))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SwrDA",SqlDbType.Decimal,13, Iif(Record.SwrDA= "" ,Convert.DBNull, Record.SwrDA))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FromDate",SqlDbType.DateTime,21, Record.FromDate)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TillDate",SqlDbType.DateTime,21, Iif(Record.TillDate= "" ,Convert.DBNull, Record.TillDate))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Active",SqlDbType.Bit,3, Record.Active)
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
    Public Shared Function taD_SwrDADelete(ByVal Record As SIS.TA.taD_SwrDA) As Int32
      Dim _Result as Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sptaD_SwrDADelete"
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
      On Error Resume Next
      _SerialNo = Ctype(Reader("SerialNo"),Int32)
      _CategoryID = Ctype(Reader("CategoryID"),Int32)
      If Convert.IsDBNull(Reader("CityTypeID")) Then
        _CityTypeID = String.Empty
      Else
        _CityTypeID = Ctype(Reader("CityTypeID"), String)
      End If
      If Convert.IsDBNull(Reader("HotelStayDA")) Then
        _HotelStayDA = 0.00
      Else
        _HotelStayDA = Ctype(Reader("HotelStayDA"), String)
      End If
      If Convert.IsDBNull(Reader("SwrDA")) Then
        _SwrDA = 0.00
      Else
        _SwrDA = Ctype(Reader("SwrDA"), String)
      End If
      _FromDate = Ctype(Reader("FromDate"),DateTime)
      If Convert.IsDBNull(Reader("TillDate")) Then
        _TillDate = String.Empty
      Else
        _TillDate = Ctype(Reader("TillDate"), String)
      End If
      _Active = Ctype(Reader("Active"),Boolean)
      If Convert.IsDBNull(Reader("TA_Categories1_cmba")) Then
        _TA_Categories1_cmba = String.Empty
      Else
        _TA_Categories1_cmba = Ctype(Reader("TA_Categories1_cmba"), String)
      End If
      If Convert.IsDBNull(Reader("TA_CityTypes2_CityTypeName")) Then
        _TA_CityTypes2_CityTypeName = String.Empty
      Else
        _TA_CityTypes2_CityTypeName = Ctype(Reader("TA_CityTypes2_CityTypeName"), String)
      End If
    End Sub
    Public Sub New()
    End Sub
  End Class
End Namespace
