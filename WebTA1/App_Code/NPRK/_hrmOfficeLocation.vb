Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.HRM
  <DataObject()> _
  Partial Public Class hrmOfficeLocation
    Private Shared _RecordCount As Integer
    Private _LocationID As Int32 = 0
    Private _OfficeID As Int32 = 0
    Private _Description As String = ""
    Private _HRM_Locations1_Description As String = ""
    Private _HRM_Offices2_Description As String = ""
    Private _FK_HRM_OfficeLocation_LocationID As SIS.HRM.hrmLocations = Nothing
    Private _FK_HRM_OfficeLocation_OfficeID As SIS.QCM.qcmOffices = Nothing
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
    Public Property LocationID() As Int32
      Get
        Return _LocationID
      End Get
      Set(ByVal value As Int32)
        _LocationID = value
      End Set
    End Property
    Public Property OfficeID() As Int32
      Get
        Return _OfficeID
      End Get
      Set(ByVal value As Int32)
        _OfficeID = value
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
    Public Property HRM_Locations1_Description() As String
      Get
        Return _HRM_Locations1_Description
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _HRM_Locations1_Description = ""
         Else
           _HRM_Locations1_Description = value
         End If
      End Set
    End Property
    Public Property HRM_Offices2_Description() As String
      Get
        Return _HRM_Offices2_Description
      End Get
      Set(ByVal value As String)
        _HRM_Offices2_Description = value
      End Set
    End Property
    Public Readonly Property DisplayField() As String
      Get
        Return "" & _Description.ToString.PadRight(50, " ")
      End Get
    End Property
    Public Readonly Property PrimaryKey() As String
      Get
        Return _LocationID & "|" & _OfficeID
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
    Public Class PKhrmOfficeLocation
      Private _LocationID As Int32 = 0
      Private _OfficeID As Int32 = 0
      Public Property LocationID() As Int32
        Get
          Return _LocationID
        End Get
        Set(ByVal value As Int32)
          _LocationID = value
        End Set
      End Property
      Public Property OfficeID() As Int32
        Get
          Return _OfficeID
        End Get
        Set(ByVal value As Int32)
          _OfficeID = value
        End Set
      End Property
    End Class
    Public ReadOnly Property FK_HRM_OfficeLocation_LocationID() As SIS.HRM.hrmLocations
      Get
        If _FK_HRM_OfficeLocation_LocationID Is Nothing Then
          _FK_HRM_OfficeLocation_LocationID = SIS.HRM.hrmLocations.hrmLocationsGetByID(_LocationID)
        End If
        Return _FK_HRM_OfficeLocation_LocationID
      End Get
    End Property
    Public ReadOnly Property FK_HRM_OfficeLocation_OfficeID() As SIS.QCM.qcmOffices
      Get
        If _FK_HRM_OfficeLocation_OfficeID Is Nothing Then
          _FK_HRM_OfficeLocation_OfficeID = SIS.QCM.qcmOffices.qcmOfficesGetByID(_OfficeID)
        End If
        Return _FK_HRM_OfficeLocation_OfficeID
      End Get
    End Property
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function hrmOfficeLocationSelectList(ByVal OrderBy As String) As List(Of SIS.HRM.hrmOfficeLocation)
      Dim Results As List(Of SIS.HRM.hrmOfficeLocation) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sphrmOfficeLocationSelectList"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.HRM.hrmOfficeLocation)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.HRM.hrmOfficeLocation(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function hrmOfficeLocationGetNewRecord() As SIS.HRM.hrmOfficeLocation
      Return New SIS.HRM.hrmOfficeLocation()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function hrmOfficeLocationGetByID(ByVal LocationID As Int32, ByVal OfficeID As Int32) As SIS.HRM.hrmOfficeLocation
      Dim Results As SIS.HRM.hrmOfficeLocation = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sphrmOfficeLocationSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LocationID",SqlDbType.Int,LocationID.ToString.Length, LocationID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OfficeID",SqlDbType.Int,OfficeID.ToString.Length, OfficeID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.HRM.hrmOfficeLocation(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function hrmOfficeLocationSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal LocationID As Int32) As List(Of SIS.HRM.hrmOfficeLocation)
      Dim Results As List(Of SIS.HRM.hrmOfficeLocation) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "sphrmOfficeLocationSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "sphrmOfficeLocationSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_LocationID",SqlDbType.Int,10, IIf(LocationID = Nothing, 0,LocationID))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.HRM.hrmOfficeLocation)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.HRM.hrmOfficeLocation(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function hrmOfficeLocationSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String, ByVal LocationID As Int32) As Integer
      Return _RecordCount
    End Function
      'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function hrmOfficeLocationGetByID(ByVal LocationID As Int32, ByVal OfficeID As Int32, ByVal Filter_LocationID As Int32) As SIS.HRM.hrmOfficeLocation
      Return hrmOfficeLocationGetByID(LocationID, OfficeID)
    End Function
    <DataObjectMethod(DataObjectMethodType.Insert, True)> _
    Public Shared Function hrmOfficeLocationInsert(ByVal Record As SIS.HRM.hrmOfficeLocation) As SIS.HRM.hrmOfficeLocation
      Dim _Rec As SIS.HRM.hrmOfficeLocation = SIS.HRM.hrmOfficeLocation.hrmOfficeLocationGetNewRecord()
      With _Rec
        .LocationID = Record.LocationID
        .OfficeID = Record.OfficeID
        .Description = Record.Description
      End With
      Return SIS.HRM.hrmOfficeLocation.InsertData(_Rec)
    End Function
    Public Shared Function InsertData(ByVal Record As SIS.HRM.hrmOfficeLocation) As SIS.HRM.hrmOfficeLocation
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sphrmOfficeLocationInsert"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LocationID",SqlDbType.Int,11, Record.LocationID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OfficeID",SqlDbType.Int,11, Record.OfficeID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Description",SqlDbType.NVarChar,51, Iif(Record.Description= "" ,Convert.DBNull, Record.Description))
          Cmd.Parameters.Add("@Return_LocationID", SqlDbType.Int, 11)
          Cmd.Parameters("@Return_LocationID").Direction = ParameterDirection.Output
          Cmd.Parameters.Add("@Return_OfficeID", SqlDbType.Int, 11)
          Cmd.Parameters("@Return_OfficeID").Direction = ParameterDirection.Output
          Con.Open()
          Cmd.ExecuteNonQuery()
          Record.LocationID = Cmd.Parameters("@Return_LocationID").Value
          Record.OfficeID = Cmd.Parameters("@Return_OfficeID").Value
        End Using
      End Using
      Return Record
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)> _
    Public Shared Function hrmOfficeLocationUpdate(ByVal Record As SIS.HRM.hrmOfficeLocation) As SIS.HRM.hrmOfficeLocation
      Dim _Rec As SIS.HRM.hrmOfficeLocation = SIS.HRM.hrmOfficeLocation.hrmOfficeLocationGetByID(Record.LocationID, Record.OfficeID)
      With _Rec
        .Description = Record.Description
      End With
      Return SIS.HRM.hrmOfficeLocation.UpdateData(_Rec)
    End Function
    Public Shared Function UpdateData(ByVal Record As SIS.HRM.hrmOfficeLocation) As SIS.HRM.hrmOfficeLocation
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sphrmOfficeLocationUpdate"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_LocationID",SqlDbType.Int,11, Record.LocationID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_OfficeID",SqlDbType.Int,11, Record.OfficeID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LocationID",SqlDbType.Int,11, Record.LocationID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OfficeID",SqlDbType.Int,11, Record.OfficeID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Description",SqlDbType.NVarChar,51, Iif(Record.Description= "" ,Convert.DBNull, Record.Description))
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
    Public Shared Function hrmOfficeLocationDelete(ByVal Record As SIS.HRM.hrmOfficeLocation) As Int32
      Dim _Result as Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sphrmOfficeLocationDelete"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_LocationID",SqlDbType.Int,Record.LocationID.ToString.Length, Record.LocationID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_OfficeID",SqlDbType.Int,Record.OfficeID.ToString.Length, Record.OfficeID)
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
    Public Shared Function SelecthrmOfficeLocationAutoCompleteList(ByVal Prefix As String, ByVal count As Integer, ByVal contextKey As String) As String()
      Dim Results As List(Of String) = Nothing
      Dim aVal() As String = contextKey.Split("|".ToCharArray)
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sphrmOfficeLocationAutoCompleteList"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@prefix", SqlDbType.NVarChar, 50, Prefix)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@records", SqlDbType.Int, -1, count)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@bycode", SqlDbType.Int, 1, IIf(IsNumeric(Prefix),0,IIf(Prefix.ToLower=Prefix, 0, 1)))
          Results = New List(Of String)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Not Reader.HasRows Then
            Results.Add(AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem("---Select Value---".PadRight(50, " "),"" & "|" & ""))
          End If
          While (Reader.Read())
            Dim Tmp As SIS.HRM.hrmOfficeLocation = New SIS.HRM.hrmOfficeLocation(Reader)
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
