Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.PSF
  <DataObject()> _
  Partial Public Class psfSupplier
    Private Shared _RecordCount As Integer
    Private _SupplierID As String = ""
    Private _SupplierName As String = ""
    Private _BankName As String = ""
    Private _BranchAddress As String = ""
    Private _BankAccountNo As String = ""
    Private _IFSCCode As String = ""
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
    Public Property SupplierID() As String
      Get
        Return _SupplierID
      End Get
      Set(ByVal value As String)
        _SupplierID = value
      End Set
    End Property
    Public Property SupplierName() As String
      Get
        Return _SupplierName
      End Get
      Set(ByVal value As String)
        _SupplierName = value
      End Set
    End Property
    Public Property BankName() As String
      Get
        Return _BankName
      End Get
      Set(ByVal value As String)
        _BankName = value
      End Set
    End Property
    Public Property BranchAddress() As String
      Get
        Return _BranchAddress
      End Get
      Set(ByVal value As String)
        _BranchAddress = value
      End Set
    End Property
    Public Property BankAccountNo() As String
      Get
        Return _BankAccountNo
      End Get
      Set(ByVal value As String)
        _BankAccountNo = value
      End Set
    End Property
    Public Property IFSCCode() As String
      Get
        Return _IFSCCode
      End Get
      Set(ByVal value As String)
        _IFSCCode = value
      End Set
    End Property
    Public Readonly Property DisplayField() As String
      Get
        Return "" & _SupplierName.ToString.PadRight(100, " ")
      End Get
    End Property
    Public Readonly Property PrimaryKey() As String
      Get
        Return _SupplierID
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
    Public Class PKpsfSupplier
      Private _SupplierID As String = ""
      Public Property SupplierID() As String
        Get
          Return _SupplierID
        End Get
        Set(ByVal value As String)
          _SupplierID = value
        End Set
      End Property
    End Class
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function psfSupplierSelectList(ByVal OrderBy As String) As List(Of SIS.PSF.psfSupplier)
      Dim Results As List(Of SIS.PSF.psfSupplier) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppsfSupplierSelectList"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.PSF.psfSupplier)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.PSF.psfSupplier(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function psfSupplierGetNewRecord() As SIS.PSF.psfSupplier
      Return New SIS.PSF.psfSupplier()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function psfSupplierGetByID(ByVal SupplierID As String) As SIS.PSF.psfSupplier
      Dim Results As SIS.PSF.psfSupplier = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppsfSupplierSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SupplierID",SqlDbType.NVarChar,SupplierID.ToString.Length, SupplierID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.PSF.psfSupplier(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function psfSupplierSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal SupplierID As String) As List(Of SIS.PSF.psfSupplier)
      Dim Results As List(Of SIS.PSF.psfSupplier) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "sppsfSupplierSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "sppsfSupplierSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_SupplierID",SqlDbType.NVarChar,9, IIf(SupplierID Is Nothing, String.Empty,SupplierID))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.PSF.psfSupplier)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.PSF.psfSupplier(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function psfSupplierSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String, ByVal SupplierID As String) As Integer
      Return _RecordCount
    End Function
      'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function psfSupplierGetByID(ByVal SupplierID As String, ByVal Filter_SupplierID As String) As SIS.PSF.psfSupplier
      Return psfSupplierGetByID(SupplierID)
    End Function
    <DataObjectMethod(DataObjectMethodType.Insert, True)> _
    Public Shared Function psfSupplierInsert(ByVal Record As SIS.PSF.psfSupplier) As SIS.PSF.psfSupplier
      Dim _Rec As SIS.PSF.psfSupplier = SIS.PSF.psfSupplier.psfSupplierGetNewRecord()
      With _Rec
        .SupplierID = Record.SupplierID
        .SupplierName = Record.SupplierName
        .BankName = Record.BankName
        .BranchAddress = Record.BranchAddress
        .BankAccountNo = Record.BankAccountNo
        .IFSCCode = Record.IFSCCode
      End With
      Return SIS.PSF.psfSupplier.InsertData(_Rec)
    End Function
    Public Shared Function InsertData(ByVal Record As SIS.PSF.psfSupplier) As SIS.PSF.psfSupplier
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppsfSupplierInsert"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SupplierID",SqlDbType.NVarChar,10, Record.SupplierID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SupplierName",SqlDbType.NVarChar,101, Record.SupplierName)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@BankName",SqlDbType.NVarChar,51, Record.BankName)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@BranchAddress",SqlDbType.NVarChar,201, Record.BranchAddress)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@BankAccountNo",SqlDbType.NVarChar,16, Record.BankAccountNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@IFSCCode",SqlDbType.NVarChar,16, Record.IFSCCode)
          Cmd.Parameters.Add("@Return_SupplierID", SqlDbType.NVarChar, 10)
          Cmd.Parameters("@Return_SupplierID").Direction = ParameterDirection.Output
          Con.Open()
          Cmd.ExecuteNonQuery()
          Record.SupplierID = Cmd.Parameters("@Return_SupplierID").Value
        End Using
      End Using
      Return Record
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)> _
    Public Shared Function psfSupplierUpdate(ByVal Record As SIS.PSF.psfSupplier) As SIS.PSF.psfSupplier
      Dim _Rec As SIS.PSF.psfSupplier = SIS.PSF.psfSupplier.psfSupplierGetByID(Record.SupplierID)
      With _Rec
        .SupplierName = Record.SupplierName
        .BankName = Record.BankName
        .BranchAddress = Record.BranchAddress
        .BankAccountNo = Record.BankAccountNo
        .IFSCCode = Record.IFSCCode
      End With
      Return SIS.PSF.psfSupplier.UpdateData(_Rec)
    End Function
    Public Shared Function UpdateData(ByVal Record As SIS.PSF.psfSupplier) As SIS.PSF.psfSupplier
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppsfSupplierUpdate"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_SupplierID",SqlDbType.NVarChar,10, Record.SupplierID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SupplierID",SqlDbType.NVarChar,10, Record.SupplierID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SupplierName",SqlDbType.NVarChar,101, Record.SupplierName)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@BankName",SqlDbType.NVarChar,51, Record.BankName)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@BranchAddress",SqlDbType.NVarChar,201, Record.BranchAddress)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@BankAccountNo",SqlDbType.NVarChar,16, Record.BankAccountNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@IFSCCode",SqlDbType.NVarChar,16, Record.IFSCCode)
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
    Public Shared Function psfSupplierDelete(ByVal Record As SIS.PSF.psfSupplier) As Int32
      Dim _Result as Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppsfSupplierDelete"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_SupplierID",SqlDbType.NVarChar,Record.SupplierID.ToString.Length, Record.SupplierID)
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
    Public Shared Function SelectpsfSupplierAutoCompleteList(ByVal Prefix As String, ByVal count As Integer, ByVal contextKey As String) As String()
      Dim Results As List(Of String) = Nothing
      Dim aVal() As String = contextKey.Split("|".ToCharArray)
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppsfSupplierAutoCompleteList"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@prefix", SqlDbType.NVarChar, 50, Prefix)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@records", SqlDbType.Int, -1, count)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@bycode", SqlDbType.Int, 1, IIf(IsNumeric(Prefix),0,IIf(Prefix.ToLower=Prefix, 0, 1)))
          Results = New List(Of String)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Not Reader.HasRows Then
            Results.Add(AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem("---Select Value---".PadRight(100, " "),""))
          End If
          While (Reader.Read())
            Dim Tmp As SIS.PSF.psfSupplier = New SIS.PSF.psfSupplier(Reader)
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
