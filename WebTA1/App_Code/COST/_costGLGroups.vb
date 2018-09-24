Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.COST
  <DataObject()> _
  Partial Public Class costGLGroups
    Private Shared _RecordCount As Integer
    Private _GLGroupID As Int32 = 0
    Private _GLNatureID As String = ""
    Private _GLGroupDescriptions As String = ""
    Private _CostGLGroupID As String = ""
    Private _Sequence As Int32 = 0
    Private _COST_GLNatures1_GLNatureDescription As String = ""
    Private _COST_vGLGroups2_GLGroupDescriptions As String = ""
    Private _FK_COST_GLGroups_GLNatureID As SIS.COST.costGLNatures = Nothing
    Private _FK_COST_GLGroups_CostGLGroupID As SIS.COST.costvGLGroups = Nothing
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
    Public Property GLNatureID() As String
      Get
        Return _GLNatureID
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _GLNatureID = ""
         Else
           _GLNatureID = value
         End If
      End Set
    End Property
    Public Property GLGroupDescriptions() As String
      Get
        Return _GLGroupDescriptions
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _GLGroupDescriptions = ""
         Else
           _GLGroupDescriptions = value
         End If
      End Set
    End Property
    Public Property CostGLGroupID() As String
      Get
        Return _CostGLGroupID
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _CostGLGroupID = ""
         Else
           _CostGLGroupID = value
         End If
      End Set
    End Property
    Public Property Sequence() As Int32
      Get
        Return _Sequence
      End Get
      Set(ByVal value As Int32)
        _Sequence = value
      End Set
    End Property
    Public Property COST_GLNatures1_GLNatureDescription() As String
      Get
        Return _COST_GLNatures1_GLNatureDescription
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _COST_GLNatures1_GLNatureDescription = ""
         Else
           _COST_GLNatures1_GLNatureDescription = value
         End If
      End Set
    End Property
    Public Property COST_vGLGroups2_GLGroupDescriptions() As String
      Get
        Return _COST_vGLGroups2_GLGroupDescriptions
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _COST_vGLGroups2_GLGroupDescriptions = ""
         Else
           _COST_vGLGroups2_GLGroupDescriptions = value
         End If
      End Set
    End Property
    Public Readonly Property DisplayField() As String
      Get
        Return "" & _GLGroupDescriptions.ToString.PadRight(50, " ")
      End Get
    End Property
    Public Readonly Property PrimaryKey() As String
      Get
        Return _GLGroupID
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
    Public Class PKcostGLGroups
      Private _GLGroupID As Int32 = 0
      Public Property GLGroupID() As Int32
        Get
          Return _GLGroupID
        End Get
        Set(ByVal value As Int32)
          _GLGroupID = value
        End Set
      End Property
    End Class
    Public ReadOnly Property FK_COST_GLGroups_GLNatureID() As SIS.COST.costGLNatures
      Get
        If _FK_COST_GLGroups_GLNatureID Is Nothing Then
          _FK_COST_GLGroups_GLNatureID = SIS.COST.costGLNatures.costGLNaturesGetByID(_GLNatureID)
        End If
        Return _FK_COST_GLGroups_GLNatureID
      End Get
    End Property
    Public ReadOnly Property FK_COST_GLGroups_CostGLGroupID() As SIS.COST.costvGLGroups
      Get
        If _FK_COST_GLGroups_CostGLGroupID Is Nothing Then
          _FK_COST_GLGroups_CostGLGroupID = SIS.COST.costvGLGroups.costvGLGroupsGetByID(_CostGLGroupID)
        End If
        Return _FK_COST_GLGroups_CostGLGroupID
      End Get
    End Property
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function costGLGroupsSelectList(ByVal OrderBy As String) As List(Of SIS.COST.costGLGroups)
      Dim Results As List(Of SIS.COST.costGLGroups) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spcostGLGroupsSelectList"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.COST.costGLGroups)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.COST.costGLGroups(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function costGLGroupsGetNewRecord() As SIS.COST.costGLGroups
      Return New SIS.COST.costGLGroups()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function costGLGroupsGetByID(ByVal GLGroupID As Int32) As SIS.COST.costGLGroups
      Dim Results As SIS.COST.costGLGroups = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spcostGLGroupsSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@GLGroupID",SqlDbType.Int,GLGroupID.ToString.Length, GLGroupID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.COST.costGLGroups(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function GetByGLNatureID(ByVal GLNatureID As Int32, ByVal OrderBy as String) As List(Of SIS.COST.costGLGroups)
      Dim Results As List(Of SIS.COST.costGLGroups) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spcostGLGroupsSelectByGLNatureID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@GLNatureID",SqlDbType.Int,GLNatureID.ToString.Length, GLNatureID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.COST.costGLGroups)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.COST.costGLGroups(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function costGLGroupsSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal GLGroupID As Int32, ByVal GLNatureID As Int32) As List(Of SIS.COST.costGLGroups)
      Dim Results As List(Of SIS.COST.costGLGroups) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "spcostGLGroupsSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "spcostGLGroupsSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_GLGroupID",SqlDbType.Int,10, IIf(GLGroupID = Nothing, 0,GLGroupID))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_GLNatureID",SqlDbType.Int,10, IIf(GLNatureID = Nothing, 0,GLNatureID))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.COST.costGLGroups)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.COST.costGLGroups(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function costGLGroupsSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String, ByVal GLGroupID As Int32, ByVal GLNatureID As Int32) As Integer
      Return _RecordCount
    End Function
      'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function costGLGroupsGetByID(ByVal GLGroupID As Int32, ByVal Filter_GLGroupID As Int32, ByVal Filter_GLNatureID As Int32) As SIS.COST.costGLGroups
      Return costGLGroupsGetByID(GLGroupID)
    End Function
    <DataObjectMethod(DataObjectMethodType.Insert, True)> _
    Public Shared Function costGLGroupsInsert(ByVal Record As SIS.COST.costGLGroups) As SIS.COST.costGLGroups
      Dim _Rec As SIS.COST.costGLGroups = SIS.COST.costGLGroups.costGLGroupsGetNewRecord()
      With _Rec
        .GLNatureID = Record.GLNatureID
        .GLGroupDescriptions = Record.GLGroupDescriptions
        .CostGLGroupID = Record.CostGLGroupID
        .Sequence = Record.Sequence
      End With
      Return SIS.COST.costGLGroups.InsertData(_Rec)
    End Function
    Public Shared Function InsertData(ByVal Record As SIS.COST.costGLGroups) As SIS.COST.costGLGroups
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spcostGLGroupsInsert"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@GLNatureID",SqlDbType.Int,11, Iif(Record.GLNatureID= "" ,Convert.DBNull, Record.GLNatureID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@GLGroupDescriptions",SqlDbType.NVarChar,51, Iif(Record.GLGroupDescriptions= "" ,Convert.DBNull, Record.GLGroupDescriptions))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CostGLGroupID",SqlDbType.Int,11, Iif(Record.CostGLGroupID= "" ,Convert.DBNull, Record.CostGLGroupID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Sequence",SqlDbType.Int,11, Record.Sequence)
          Cmd.Parameters.Add("@Return_GLGroupID", SqlDbType.Int, 11)
          Cmd.Parameters("@Return_GLGroupID").Direction = ParameterDirection.Output
          Con.Open()
          Cmd.ExecuteNonQuery()
          Record.GLGroupID = Cmd.Parameters("@Return_GLGroupID").Value
        End Using
      End Using
      Return Record
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)> _
    Public Shared Function costGLGroupsUpdate(ByVal Record As SIS.COST.costGLGroups) As SIS.COST.costGLGroups
      Dim _Rec As SIS.COST.costGLGroups = SIS.COST.costGLGroups.costGLGroupsGetByID(Record.GLGroupID)
      With _Rec
        .GLNatureID = Record.GLNatureID
        .GLGroupDescriptions = Record.GLGroupDescriptions
        .CostGLGroupID = Record.CostGLGroupID
        .Sequence = Record.Sequence
      End With
      Return SIS.COST.costGLGroups.UpdateData(_Rec)
    End Function
    Public Shared Function UpdateData(ByVal Record As SIS.COST.costGLGroups) As SIS.COST.costGLGroups
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spcostGLGroupsUpdate"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_GLGroupID",SqlDbType.Int,11, Record.GLGroupID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@GLNatureID",SqlDbType.Int,11, Iif(Record.GLNatureID= "" ,Convert.DBNull, Record.GLNatureID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@GLGroupDescriptions",SqlDbType.NVarChar,51, Iif(Record.GLGroupDescriptions= "" ,Convert.DBNull, Record.GLGroupDescriptions))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CostGLGroupID",SqlDbType.Int,11, Iif(Record.CostGLGroupID= "" ,Convert.DBNull, Record.CostGLGroupID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Sequence",SqlDbType.Int,11, Record.Sequence)
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
    Public Shared Function costGLGroupsDelete(ByVal Record As SIS.COST.costGLGroups) As Int32
      Dim _Result as Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spcostGLGroupsDelete"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_GLGroupID",SqlDbType.Int,Record.GLGroupID.ToString.Length, Record.GLGroupID)
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
    Public Shared Function SelectcostGLGroupsAutoCompleteList(ByVal Prefix As String, ByVal count As Integer, ByVal contextKey As String) As String()
      Dim Results As List(Of String) = Nothing
      Dim aVal() As String = contextKey.Split("|".ToCharArray)
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spcostGLGroupsAutoCompleteList"
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
            Dim Tmp As SIS.COST.costGLGroups = New SIS.COST.costGLGroups(Reader)
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
