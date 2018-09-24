Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.TA
  <DataObject()> _
  Partial Public Class taF_SiteDA
    Private Shared _RecordCount As Integer
    Private _Perm_Bord_DA As String = "0.00"
    Private _Cont_NonT_Bord_DA As String = "0.00"
    Private _Cont_Tech_Bord_DA As String = "0.00"
    Private _SerialNo As Int32 = 0
    Private _CategoryID As Int32 = 0
    Private _Cont_Tech_DA As String = "0.00"
    Private _Cont_NonT_DA As String = "0.00"
    Private _Perm_DA As String = "0.00"
    Private _FromDate As String = ""
    Private _TillDate As String = ""
    Private _Active As Boolean = False
    Private _TA_Categories1_cmba As String = ""
    Private _FK_TA_F_SiteDA_CategoryID As SIS.TA.taCategories = Nothing
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
    Public Property Perm_Bord_DA() As String
      Get
        Return _Perm_Bord_DA
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _Perm_Bord_DA = "0.00"
         Else
           _Perm_Bord_DA = value
         End If
      End Set
    End Property
    Public Property Cont_NonT_Bord_DA() As String
      Get
        Return _Cont_NonT_Bord_DA
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _Cont_NonT_Bord_DA = "0.00"
         Else
           _Cont_NonT_Bord_DA = value
         End If
      End Set
    End Property
    Public Property Cont_Tech_Bord_DA() As String
      Get
        Return _Cont_Tech_Bord_DA
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _Cont_Tech_Bord_DA = "0.00"
         Else
           _Cont_Tech_Bord_DA = value
         End If
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
    Public Property CategoryID() As Int32
      Get
        Return _CategoryID
      End Get
      Set(ByVal value As Int32)
        _CategoryID = value
      End Set
    End Property
    Public Property Cont_Tech_DA() As String
      Get
        Return _Cont_Tech_DA
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _Cont_Tech_DA = "0.00"
         Else
           _Cont_Tech_DA = value
         End If
      End Set
    End Property
    Public Property Cont_NonT_DA() As String
      Get
        Return _Cont_NonT_DA
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _Cont_NonT_DA = "0.00"
         Else
           _Cont_NonT_DA = value
         End If
      End Set
    End Property
    Public Property Perm_DA() As String
      Get
        Return _Perm_DA
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _Perm_DA = "0.00"
         Else
           _Perm_DA = value
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
    Public Class PKtaF_SiteDA
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
    Public ReadOnly Property FK_TA_F_SiteDA_CategoryID() As SIS.TA.taCategories
      Get
        If _FK_TA_F_SiteDA_CategoryID Is Nothing Then
          _FK_TA_F_SiteDA_CategoryID = SIS.TA.taCategories.taCategoriesGetByID(_CategoryID)
        End If
        Return _FK_TA_F_SiteDA_CategoryID
      End Get
    End Property
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function taF_SiteDAGetNewRecord() As SIS.TA.taF_SiteDA
      Return New SIS.TA.taF_SiteDA()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function taF_SiteDAGetByID(ByVal SerialNo As Int32) As SIS.TA.taF_SiteDA
      Dim Results As SIS.TA.taF_SiteDA = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sptaF_SiteDASelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SerialNo",SqlDbType.Int,SerialNo.ToString.Length, SerialNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.TA.taF_SiteDA(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function GetByCategoryID(ByVal CategoryID As Int32, ByVal OrderBy as String) As List(Of SIS.TA.taF_SiteDA)
      Dim Results As List(Of SIS.TA.taF_SiteDA) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          If OrderBy = String.Empty Then OrderBy = "SerialNo DESC"
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sptaF_SiteDASelectByCategoryID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CategoryID",SqlDbType.Int,CategoryID.ToString.Length, CategoryID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.TA.taF_SiteDA)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.TA.taF_SiteDA(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function taF_SiteDASelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal CategoryID As Int32) As List(Of SIS.TA.taF_SiteDA)
      Dim Results As List(Of SIS.TA.taF_SiteDA) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          If OrderBy = String.Empty Then OrderBy = "SerialNo DESC"
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "sptaF_SiteDASelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "sptaF_SiteDASelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_CategoryID",SqlDbType.Int,10, IIf(CategoryID = Nothing, 0,CategoryID))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.TA.taF_SiteDA)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.TA.taF_SiteDA(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function taF_SiteDASelectCount(ByVal SearchState As Boolean, ByVal SearchText As String, ByVal CategoryID As Int32) As Integer
      Return _RecordCount
    End Function
      'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function taF_SiteDAGetByID(ByVal SerialNo As Int32, ByVal Filter_CategoryID As Int32) As SIS.TA.taF_SiteDA
      Return taF_SiteDAGetByID(SerialNo)
    End Function
    <DataObjectMethod(DataObjectMethodType.Insert, True)> _
    Public Shared Function taF_SiteDAInsert(ByVal Record As SIS.TA.taF_SiteDA) As SIS.TA.taF_SiteDA
      Dim _Rec As SIS.TA.taF_SiteDA = SIS.TA.taF_SiteDA.taF_SiteDAGetNewRecord()
      With _Rec
        .Perm_Bord_DA = Record.Perm_Bord_DA
        .Cont_NonT_Bord_DA = Record.Cont_NonT_Bord_DA
        .Cont_Tech_Bord_DA = Record.Cont_Tech_Bord_DA
        .CategoryID = Record.CategoryID
        .Cont_Tech_DA = Record.Cont_Tech_DA
        .Cont_NonT_DA = Record.Cont_NonT_DA
        .Perm_DA = Record.Perm_DA
        .FromDate = Record.FromDate
        .TillDate = Record.TillDate
        .Active = Record.Active
      End With
      Return SIS.TA.taF_SiteDA.InsertData(_Rec)
    End Function
    Public Shared Function InsertData(ByVal Record As SIS.TA.taF_SiteDA) As SIS.TA.taF_SiteDA
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sptaF_SiteDAInsert"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Perm_Bord_DA",SqlDbType.Decimal,13, Iif(Record.Perm_Bord_DA= "" ,Convert.DBNull, Record.Perm_Bord_DA))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Cont_NonT_Bord_DA",SqlDbType.Decimal,13, Iif(Record.Cont_NonT_Bord_DA= "" ,Convert.DBNull, Record.Cont_NonT_Bord_DA))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Cont_Tech_Bord_DA",SqlDbType.Decimal,13, Iif(Record.Cont_Tech_Bord_DA= "" ,Convert.DBNull, Record.Cont_Tech_Bord_DA))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CategoryID",SqlDbType.Int,11, Record.CategoryID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Cont_Tech_DA",SqlDbType.Decimal,13, Iif(Record.Cont_Tech_DA= "" ,Convert.DBNull, Record.Cont_Tech_DA))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Cont_NonT_DA",SqlDbType.Decimal,13, Iif(Record.Cont_NonT_DA= "" ,Convert.DBNull, Record.Cont_NonT_DA))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Perm_DA",SqlDbType.Decimal,13, Iif(Record.Perm_DA= "" ,Convert.DBNull, Record.Perm_DA))
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
    Public Shared Function taF_SiteDAUpdate(ByVal Record As SIS.TA.taF_SiteDA) As SIS.TA.taF_SiteDA
      Dim _Rec As SIS.TA.taF_SiteDA = SIS.TA.taF_SiteDA.taF_SiteDAGetByID(Record.SerialNo)
      With _Rec
        .Perm_Bord_DA = Record.Perm_Bord_DA
        .Cont_NonT_Bord_DA = Record.Cont_NonT_Bord_DA
        .Cont_Tech_Bord_DA = Record.Cont_Tech_Bord_DA
        .CategoryID = Record.CategoryID
        .Cont_Tech_DA = Record.Cont_Tech_DA
        .Cont_NonT_DA = Record.Cont_NonT_DA
        .Perm_DA = Record.Perm_DA
        .FromDate = Record.FromDate
        .TillDate = Record.TillDate
        .Active = Record.Active
      End With
      Return SIS.TA.taF_SiteDA.UpdateData(_Rec)
    End Function
    Public Shared Function UpdateData(ByVal Record As SIS.TA.taF_SiteDA) As SIS.TA.taF_SiteDA
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sptaF_SiteDAUpdate"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_SerialNo",SqlDbType.Int,11, Record.SerialNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Perm_Bord_DA",SqlDbType.Decimal,13, Iif(Record.Perm_Bord_DA= "" ,Convert.DBNull, Record.Perm_Bord_DA))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Cont_NonT_Bord_DA",SqlDbType.Decimal,13, Iif(Record.Cont_NonT_Bord_DA= "" ,Convert.DBNull, Record.Cont_NonT_Bord_DA))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Cont_Tech_Bord_DA",SqlDbType.Decimal,13, Iif(Record.Cont_Tech_Bord_DA= "" ,Convert.DBNull, Record.Cont_Tech_Bord_DA))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CategoryID",SqlDbType.Int,11, Record.CategoryID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Cont_Tech_DA",SqlDbType.Decimal,13, Iif(Record.Cont_Tech_DA= "" ,Convert.DBNull, Record.Cont_Tech_DA))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Cont_NonT_DA",SqlDbType.Decimal,13, Iif(Record.Cont_NonT_DA= "" ,Convert.DBNull, Record.Cont_NonT_DA))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Perm_DA",SqlDbType.Decimal,13, Iif(Record.Perm_DA= "" ,Convert.DBNull, Record.Perm_DA))
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
    Public Shared Function taF_SiteDADelete(ByVal Record As SIS.TA.taF_SiteDA) As Int32
      Dim _Result as Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sptaF_SiteDADelete"
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
      If Convert.IsDBNull(Reader("Perm_Bord_DA")) Then
        _Perm_Bord_DA = 0.00
      Else
        _Perm_Bord_DA = Ctype(Reader("Perm_Bord_DA"), String)
      End If
      If Convert.IsDBNull(Reader("Cont_NonT_Bord_DA")) Then
        _Cont_NonT_Bord_DA = 0.00
      Else
        _Cont_NonT_Bord_DA = Ctype(Reader("Cont_NonT_Bord_DA"), String)
      End If
      If Convert.IsDBNull(Reader("Cont_Tech_Bord_DA")) Then
        _Cont_Tech_Bord_DA = 0.00
      Else
        _Cont_Tech_Bord_DA = Ctype(Reader("Cont_Tech_Bord_DA"), String)
      End If
      _SerialNo = Ctype(Reader("SerialNo"),Int32)
      _CategoryID = Ctype(Reader("CategoryID"),Int32)
      If Convert.IsDBNull(Reader("Cont_Tech_DA")) Then
        _Cont_Tech_DA = 0.00
      Else
        _Cont_Tech_DA = Ctype(Reader("Cont_Tech_DA"), String)
      End If
      If Convert.IsDBNull(Reader("Cont_NonT_DA")) Then
        _Cont_NonT_DA = 0.00
      Else
        _Cont_NonT_DA = Ctype(Reader("Cont_NonT_DA"), String)
      End If
      If Convert.IsDBNull(Reader("Perm_DA")) Then
        _Perm_DA = 0.00
      Else
        _Perm_DA = Ctype(Reader("Perm_DA"), String)
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
    End Sub
    Public Sub New()
    End Sub
  End Class
End Namespace
