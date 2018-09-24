Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.NPRK
  <DataObject()> _
  Partial Public Class nprkPerks
    Private Shared _RecordCount As Integer
    Private _PerkID As Int32 = 0
    Private _PerkCode As String = ""
    Private _Description As String = ""
    Private _AdvanceApplicable As Boolean = False
    Private _AdvanceMonths As Int32 = 0
    Private _LockedMonths As Int32 = 0
    Private _NoOfPayments As Int32 = 0
    Private _CarryForward As Boolean = False
    Private _UOM As String = ""
    Private _Active As Boolean = False
    Private _BaaNGL As String = ""
    Private _BaaNReference As String = ""
    Private _CreditGLForCheque As String = ""
    Private _CreditGLForCash24 As String = ""
    Private _CreditGLForImprest As String = ""
    Private _CreditGLForCash63 As String = ""
    Private _cmba As String = ""
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
    Public Property PerkID() As Int32
      Get
        Return _PerkID
      End Get
      Set(ByVal value As Int32)
        _PerkID = value
      End Set
    End Property
    Public Property PerkCode() As String
      Get
        Return _PerkCode
      End Get
      Set(ByVal value As String)
        _PerkCode = value
      End Set
    End Property
    Public Property Description() As String
      Get
        Return _Description
      End Get
      Set(ByVal value As String)
        _Description = value
      End Set
    End Property
    Public Property AdvanceApplicable() As Boolean
      Get
        Return _AdvanceApplicable
      End Get
      Set(ByVal value As Boolean)
        _AdvanceApplicable = value
      End Set
    End Property
    Public Property AdvanceMonths() As Int32
      Get
        Return _AdvanceMonths
      End Get
      Set(ByVal value As Int32)
        _AdvanceMonths = value
      End Set
    End Property
    Public Property LockedMonths() As Int32
      Get
        Return _LockedMonths
      End Get
      Set(ByVal value As Int32)
        _LockedMonths = value
      End Set
    End Property
    Public Property NoOfPayments() As Int32
      Get
        Return _NoOfPayments
      End Get
      Set(ByVal value As Int32)
        _NoOfPayments = value
      End Set
    End Property
    Public Property CarryForward() As Boolean
      Get
        Return _CarryForward
      End Get
      Set(ByVal value As Boolean)
        _CarryForward = value
      End Set
    End Property
    Public Property UOM() As String
      Get
        Return _UOM
      End Get
      Set(ByVal value As String)
        _UOM = value
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
    Public Property BaaNGL() As String
      Get
        Return _BaaNGL
      End Get
      Set(ByVal value As String)
        _BaaNGL = value
      End Set
    End Property
    Public Property BaaNReference() As String
      Get
        Return _BaaNReference
      End Get
      Set(ByVal value As String)
        _BaaNReference = value
      End Set
    End Property
    Public Property CreditGLForCheque() As String
      Get
        Return _CreditGLForCheque
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _CreditGLForCheque = ""
         Else
           _CreditGLForCheque = value
         End If
      End Set
    End Property
    Public Property CreditGLForCash24() As String
      Get
        Return _CreditGLForCash24
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _CreditGLForCash24 = ""
         Else
           _CreditGLForCash24 = value
         End If
      End Set
    End Property
    Public Property CreditGLForImprest() As String
      Get
        Return _CreditGLForImprest
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _CreditGLForImprest = ""
         Else
           _CreditGLForImprest = value
         End If
      End Set
    End Property
    Public Property CreditGLForCash63() As String
      Get
        Return _CreditGLForCash63
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _CreditGLForCash63 = ""
         Else
           _CreditGLForCash63 = value
         End If
      End Set
    End Property
    Public Property cmba() As String
      Get
        Return _cmba
      End Get
      Set(ByVal value As String)
        _cmba = value
      End Set
    End Property
    Public Readonly Property DisplayField() As String
      Get
        Return "" & _Description.ToString.PadRight(50, " ")
      End Get
    End Property
    Public Readonly Property PrimaryKey() As String
      Get
        Return _PerkID
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
    Public Class PKnprkPerks
      Private _PerkID As Int32 = 0
      Public Property PerkID() As Int32
        Get
          Return _PerkID
        End Get
        Set(ByVal value As Int32)
          _PerkID = value
        End Set
      End Property
    End Class
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function nprkPerksSelectList(ByVal OrderBy As String) As List(Of SIS.NPRK.nprkPerks)
      Dim Results As List(Of SIS.NPRK.nprkPerks) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spnprkPerksSelectList"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.NPRK.nprkPerks)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.NPRK.nprkPerks(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function nprkPerksGetNewRecord() As SIS.NPRK.nprkPerks
      Return New SIS.NPRK.nprkPerks()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function nprkPerksGetByID(ByVal PerkID As Int32) As SIS.NPRK.nprkPerks
      Dim Results As SIS.NPRK.nprkPerks = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spnprkPerksSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PerkID",SqlDbType.Int,PerkID.ToString.Length, PerkID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.NPRK.nprkPerks(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function nprkPerksSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String) As List(Of SIS.NPRK.nprkPerks)
      Dim Results As List(Of SIS.NPRK.nprkPerks) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "spnprkPerksSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "spnprkPerksSelectListFilteres"
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.NPRK.nprkPerks)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.NPRK.nprkPerks(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function nprkPerksSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String) As Integer
      Return _RecordCount
    End Function
      'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Insert, True)> _
    Public Shared Function nprkPerksInsert(ByVal Record As SIS.NPRK.nprkPerks) As SIS.NPRK.nprkPerks
      Dim _Rec As SIS.NPRK.nprkPerks = SIS.NPRK.nprkPerks.nprkPerksGetNewRecord()
      With _Rec
        .PerkCode = Record.PerkCode
        .Description = Record.Description
        .AdvanceApplicable = Record.AdvanceApplicable
        .AdvanceMonths = Record.AdvanceMonths
        .LockedMonths = Record.LockedMonths
        .NoOfPayments = Record.NoOfPayments
        .CarryForward = Record.CarryForward
        .UOM = Record.UOM
        .Active = Record.Active
        .BaaNGL = Record.BaaNGL
        .BaaNReference = Record.BaaNReference
        .CreditGLForCheque = Record.CreditGLForCheque
        .CreditGLForCash24 = Record.CreditGLForCash24
        .CreditGLForImprest = Record.CreditGLForImprest
        .CreditGLForCash63 = Record.CreditGLForCash63
      End With
      Return SIS.NPRK.nprkPerks.InsertData(_Rec)
    End Function
    Public Shared Function InsertData(ByVal Record As SIS.NPRK.nprkPerks) As SIS.NPRK.nprkPerks
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spnprkPerksInsert"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PerkCode",SqlDbType.NVarChar,4, Record.PerkCode)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Description",SqlDbType.NVarChar,51, Record.Description)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@AdvanceApplicable",SqlDbType.Bit,3, Record.AdvanceApplicable)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@AdvanceMonths",SqlDbType.Int,11, Record.AdvanceMonths)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LockedMonths",SqlDbType.Int,11, Record.LockedMonths)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@NoOfPayments",SqlDbType.Int,11, Record.NoOfPayments)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CarryForward",SqlDbType.Bit,3, Record.CarryForward)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@UOM",SqlDbType.NVarChar,6, Record.UOM)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Active",SqlDbType.Bit,3, Record.Active)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@BaaNGL",SqlDbType.NVarChar,8, Record.BaaNGL)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@BaaNReference",SqlDbType.NVarChar,31, Record.BaaNReference)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CreditGLForCheque",SqlDbType.NVarChar,8, Iif(Record.CreditGLForCheque= "" ,Convert.DBNull, Record.CreditGLForCheque))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CreditGLForCash24",SqlDbType.NVarChar,8, Iif(Record.CreditGLForCash24= "" ,Convert.DBNull, Record.CreditGLForCash24))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CreditGLForImprest",SqlDbType.NVarChar,8, Iif(Record.CreditGLForImprest= "" ,Convert.DBNull, Record.CreditGLForImprest))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CreditGLForCash63",SqlDbType.NVarChar,8, Iif(Record.CreditGLForCash63= "" ,Convert.DBNull, Record.CreditGLForCash63))
          Cmd.Parameters.Add("@Return_PerkID", SqlDbType.Int, 11)
          Cmd.Parameters("@Return_PerkID").Direction = ParameterDirection.Output
          Con.Open()
          Cmd.ExecuteNonQuery()
          Record.PerkID = Cmd.Parameters("@Return_PerkID").Value
        End Using
      End Using
      Return Record
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)> _
    Public Shared Function nprkPerksUpdate(ByVal Record As SIS.NPRK.nprkPerks) As SIS.NPRK.nprkPerks
      Dim _Rec As SIS.NPRK.nprkPerks = SIS.NPRK.nprkPerks.nprkPerksGetByID(Record.PerkID)
      With _Rec
        .PerkCode = Record.PerkCode
        .Description = Record.Description
        .AdvanceApplicable = Record.AdvanceApplicable
        .AdvanceMonths = Record.AdvanceMonths
        .LockedMonths = Record.LockedMonths
        .NoOfPayments = Record.NoOfPayments
        .CarryForward = Record.CarryForward
        .UOM = Record.UOM
        .Active = Record.Active
        .BaaNGL = Record.BaaNGL
        .BaaNReference = Record.BaaNReference
        .CreditGLForCheque = Record.CreditGLForCheque
        .CreditGLForCash24 = Record.CreditGLForCash24
        .CreditGLForImprest = Record.CreditGLForImprest
        .CreditGLForCash63 = Record.CreditGLForCash63
      End With
      Return SIS.NPRK.nprkPerks.UpdateData(_Rec)
    End Function
    Public Shared Function UpdateData(ByVal Record As SIS.NPRK.nprkPerks) As SIS.NPRK.nprkPerks
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spnprkPerksUpdate"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_PerkID",SqlDbType.Int,11, Record.PerkID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PerkCode",SqlDbType.NVarChar,4, Record.PerkCode)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Description",SqlDbType.NVarChar,51, Record.Description)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@AdvanceApplicable",SqlDbType.Bit,3, Record.AdvanceApplicable)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@AdvanceMonths",SqlDbType.Int,11, Record.AdvanceMonths)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LockedMonths",SqlDbType.Int,11, Record.LockedMonths)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@NoOfPayments",SqlDbType.Int,11, Record.NoOfPayments)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CarryForward",SqlDbType.Bit,3, Record.CarryForward)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@UOM",SqlDbType.NVarChar,6, Record.UOM)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Active",SqlDbType.Bit,3, Record.Active)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@BaaNGL",SqlDbType.NVarChar,8, Record.BaaNGL)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@BaaNReference",SqlDbType.NVarChar,31, Record.BaaNReference)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CreditGLForCheque",SqlDbType.NVarChar,8, Iif(Record.CreditGLForCheque= "" ,Convert.DBNull, Record.CreditGLForCheque))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CreditGLForCash24",SqlDbType.NVarChar,8, Iif(Record.CreditGLForCash24= "" ,Convert.DBNull, Record.CreditGLForCash24))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CreditGLForImprest",SqlDbType.NVarChar,8, Iif(Record.CreditGLForImprest= "" ,Convert.DBNull, Record.CreditGLForImprest))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CreditGLForCash63",SqlDbType.NVarChar,8, Iif(Record.CreditGLForCash63= "" ,Convert.DBNull, Record.CreditGLForCash63))
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
    Public Shared Function nprkPerksDelete(ByVal Record As SIS.NPRK.nprkPerks) As Int32
      Dim _Result as Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spnprkPerksDelete"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_PerkID",SqlDbType.Int,Record.PerkID.ToString.Length, Record.PerkID)
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
    Public Shared Function SelectnprkPerksAutoCompleteList(ByVal Prefix As String, ByVal count As Integer, ByVal contextKey As String) As String()
      Dim Results As List(Of String) = Nothing
      Dim aVal() As String = contextKey.Split("|".ToCharArray)
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spnprkPerksAutoCompleteList"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@prefix", SqlDbType.NVarChar, 50, Prefix)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@records", SqlDbType.Int, -1, count)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@bycode", SqlDbType.Int, 1, IIf(IsNumeric(Prefix), 0, 1))
          Results = New List(Of String)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Not Reader.HasRows Then
            Results.Add(AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem("---Select Value---".PadRight(50, " "),""))
          End If
          While (Reader.Read())
            Dim Tmp As SIS.NPRK.nprkPerks = New SIS.NPRK.nprkPerks(Reader)
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
