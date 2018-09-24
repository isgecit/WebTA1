Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.COST
  <DataObject()> _
  Partial Public Class costGLGroupGLs
    Private Shared _RecordCount As Integer
    Private _GLGroupID As Int32 = 0
    Private _GLCode As String = ""
    Private _EffectiveStartDate As String = ""
    Private _EffectiveEndDate As String = ""
    Private _COST_GLGroups1_GLGroupDescriptions As String = ""
    Private _COST_ERPGLCodes2_GLDescription As String = ""
    Private _FK_COST_GLGroupGLs_GLGroupID As SIS.COST.costGLGroups = Nothing
    Private _FK_COST_GLGroupGLs_GLCode As SIS.COST.costERPGLCodes = Nothing
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
    Public Property GLGroupID() As Int32
      Get
        Return _GLGroupID
      End Get
      Set(ByVal value As Int32)
        _GLGroupID = value
      End Set
    End Property
    Public Property GLCode() As String
      Get
        Return _GLCode
      End Get
      Set(ByVal value As String)
        _GLCode = value
      End Set
    End Property
    Public Property EffectiveStartDate() As String
      Get
        If Not _EffectiveStartDate = String.Empty Then
          Return Convert.ToDateTime(_EffectiveStartDate).ToString("dd/MM/yyyy")
        End If
        Return _EffectiveStartDate
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _EffectiveStartDate = ""
         Else
           _EffectiveStartDate = value
         End If
      End Set
    End Property
    Public Property EffectiveEndDate() As String
      Get
        If Not _EffectiveEndDate = String.Empty Then
          Return Convert.ToDateTime(_EffectiveEndDate).ToString("dd/MM/yyyy")
        End If
        Return _EffectiveEndDate
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _EffectiveEndDate = ""
         Else
           _EffectiveEndDate = value
         End If
      End Set
    End Property
    Public Property COST_GLGroups1_GLGroupDescriptions() As String
      Get
        Return _COST_GLGroups1_GLGroupDescriptions
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _COST_GLGroups1_GLGroupDescriptions = ""
         Else
           _COST_GLGroups1_GLGroupDescriptions = value
         End If
      End Set
    End Property
    Public Property COST_ERPGLCodes2_GLDescription() As String
      Get
        Return _COST_ERPGLCodes2_GLDescription
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _COST_ERPGLCodes2_GLDescription = ""
         Else
           _COST_ERPGLCodes2_GLDescription = value
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
        Return _GLGroupID & "|" & _GLCode
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
    Public Class PKcostGLGroupGLs
      Private _GLGroupID As Int32 = 0
      Private _GLCode As String = ""
      Public Property GLGroupID() As Int32
        Get
          Return _GLGroupID
        End Get
        Set(ByVal value As Int32)
          _GLGroupID = value
        End Set
      End Property
      Public Property GLCode() As String
        Get
          Return _GLCode
        End Get
        Set(ByVal value As String)
          _GLCode = value
        End Set
      End Property
    End Class
    Public ReadOnly Property FK_COST_GLGroupGLs_GLGroupID() As SIS.COST.costGLGroups
      Get
        If _FK_COST_GLGroupGLs_GLGroupID Is Nothing Then
          _FK_COST_GLGroupGLs_GLGroupID = SIS.COST.costGLGroups.costGLGroupsGetByID(_GLGroupID)
        End If
        Return _FK_COST_GLGroupGLs_GLGroupID
      End Get
    End Property
    Public ReadOnly Property FK_COST_GLGroupGLs_GLCode() As SIS.COST.costERPGLCodes
      Get
        If _FK_COST_GLGroupGLs_GLCode Is Nothing Then
          _FK_COST_GLGroupGLs_GLCode = SIS.COST.costERPGLCodes.costERPGLCodesGetByID(_GLCode)
        End If
        Return _FK_COST_GLGroupGLs_GLCode
      End Get
    End Property
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function costGLGroupGLsGetNewRecord() As SIS.COST.costGLGroupGLs
      Return New SIS.COST.costGLGroupGLs()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function costGLGroupGLsGetByID(ByVal GLGroupID As Int32, ByVal GLCode As String) As SIS.COST.costGLGroupGLs
      Dim Results As SIS.COST.costGLGroupGLs = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spcostGLGroupGLsSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@GLGroupID",SqlDbType.Int,GLGroupID.ToString.Length, GLGroupID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@GLCode",SqlDbType.NVarChar,GLCode.ToString.Length, GLCode)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.COST.costGLGroupGLs(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function GetByGLGroupID(ByVal GLGroupID As Int32, ByVal OrderBy as String) As List(Of SIS.COST.costGLGroupGLs)
      Dim Results As List(Of SIS.COST.costGLGroupGLs) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spcostGLGroupGLsSelectByGLGroupID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@GLGroupID",SqlDbType.Int,GLGroupID.ToString.Length, GLGroupID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.COST.costGLGroupGLs)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.COST.costGLGroupGLs(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function costGLGroupGLsSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal GLGroupID As Int32) As List(Of SIS.COST.costGLGroupGLs)
      Dim Results As List(Of SIS.COST.costGLGroupGLs) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "spcostGLGroupGLsSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "spcostGLGroupGLsSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_GLGroupID",SqlDbType.Int,10, IIf(GLGroupID = Nothing, 0,GLGroupID))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.COST.costGLGroupGLs)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.COST.costGLGroupGLs(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function costGLGroupGLsSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String, ByVal GLGroupID As Int32) As Integer
      Return _RecordCount
    End Function
      'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function costGLGroupGLsGetByID(ByVal GLGroupID As Int32, ByVal GLCode As String, ByVal Filter_GLGroupID As Int32) As SIS.COST.costGLGroupGLs
      Return costGLGroupGLsGetByID(GLGroupID, GLCode)
    End Function
    <DataObjectMethod(DataObjectMethodType.Insert, True)> _
    Public Shared Function costGLGroupGLsInsert(ByVal Record As SIS.COST.costGLGroupGLs) As SIS.COST.costGLGroupGLs
      Dim _Rec As SIS.COST.costGLGroupGLs = SIS.COST.costGLGroupGLs.costGLGroupGLsGetNewRecord()
      With _Rec
        .GLGroupID = Record.GLGroupID
        .GLCode = Record.GLCode
        .EffectiveStartDate = Record.EffectiveStartDate
        .EffectiveEndDate = Record.EffectiveEndDate
      End With
      Return SIS.COST.costGLGroupGLs.InsertData(_Rec)
    End Function
    Public Shared Function InsertData(ByVal Record As SIS.COST.costGLGroupGLs) As SIS.COST.costGLGroupGLs
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spcostGLGroupGLsInsert"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@GLGroupID",SqlDbType.Int,11, Record.GLGroupID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@GLCode",SqlDbType.NVarChar,11, Record.GLCode)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@EffectiveStartDate",SqlDbType.DateTime,21, Iif(Record.EffectiveStartDate= "" ,Convert.DBNull, Record.EffectiveStartDate))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@EffectiveEndDate",SqlDbType.DateTime,21, Iif(Record.EffectiveEndDate= "" ,Convert.DBNull, Record.EffectiveEndDate))
          Cmd.Parameters.Add("@Return_GLGroupID", SqlDbType.Int, 11)
          Cmd.Parameters("@Return_GLGroupID").Direction = ParameterDirection.Output
          Cmd.Parameters.Add("@Return_GLCode", SqlDbType.NVarChar, 11)
          Cmd.Parameters("@Return_GLCode").Direction = ParameterDirection.Output
          Con.Open()
          Cmd.ExecuteNonQuery()
          Record.GLGroupID = Cmd.Parameters("@Return_GLGroupID").Value
          Record.GLCode = Cmd.Parameters("@Return_GLCode").Value
        End Using
      End Using
      Return Record
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)> _
    Public Shared Function costGLGroupGLsUpdate(ByVal Record As SIS.COST.costGLGroupGLs) As SIS.COST.costGLGroupGLs
      Dim _Rec As SIS.COST.costGLGroupGLs = SIS.COST.costGLGroupGLs.costGLGroupGLsGetByID(Record.GLGroupID, Record.GLCode)
      With _Rec
        .EffectiveStartDate = Record.EffectiveStartDate
        .EffectiveEndDate = Record.EffectiveEndDate
      End With
      Return SIS.COST.costGLGroupGLs.UpdateData(_Rec)
    End Function
    Public Shared Function UpdateData(ByVal Record As SIS.COST.costGLGroupGLs) As SIS.COST.costGLGroupGLs
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spcostGLGroupGLsUpdate"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_GLGroupID",SqlDbType.Int,11, Record.GLGroupID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_GLCode",SqlDbType.NVarChar,11, Record.GLCode)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@GLGroupID",SqlDbType.Int,11, Record.GLGroupID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@GLCode",SqlDbType.NVarChar,11, Record.GLCode)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@EffectiveStartDate",SqlDbType.DateTime,21, Iif(Record.EffectiveStartDate= "" ,Convert.DBNull, Record.EffectiveStartDate))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@EffectiveEndDate",SqlDbType.DateTime,21, Iif(Record.EffectiveEndDate= "" ,Convert.DBNull, Record.EffectiveEndDate))
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
    Public Shared Function costGLGroupGLsDelete(ByVal Record As SIS.COST.costGLGroupGLs) As Int32
      Dim _Result as Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spcostGLGroupGLsDelete"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_GLGroupID",SqlDbType.Int,Record.GLGroupID.ToString.Length, Record.GLGroupID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_GLCode",SqlDbType.NVarChar,Record.GLCode.ToString.Length, Record.GLCode)
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
