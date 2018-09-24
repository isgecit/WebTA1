Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.PAK
  <DataObject()> _
  Partial Public Class pakElements
    Private Shared _RecordCount As Integer
    Private _ElementID As String = ""
    Private _Description As String = ""
    Private _ResponsibleAgencyID As String = ""
    Private _ParentElementID As String = ""
    Private _ElementLevel As String = ""
    Private _Prefix As String = ""
    Private _PAK_Elements1_Description As String = ""
    Private _PAK_ResponsibleAgencies2_Description As String = ""
    Private _FK_PAK_Elements_ParentElementID As SIS.PAK.pakElements = Nothing
    Private _FK_PAK_Elements_ResponsibleAgemcyID As SIS.PAK.pakResponsibleAgencies = Nothing
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
    Public Property ElementID() As String
      Get
        Return _ElementID
      End Get
      Set(ByVal value As String)
        _ElementID = value
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
    Public Property ResponsibleAgencyID() As String
      Get
        Return _ResponsibleAgencyID
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _ResponsibleAgencyID = ""
         Else
           _ResponsibleAgencyID = value
         End If
      End Set
    End Property
    Public Property ParentElementID() As String
      Get
        Return _ParentElementID
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _ParentElementID = ""
         Else
           _ParentElementID = value
         End If
      End Set
    End Property
    Public Property ElementLevel() As String
      Get
        Return _ElementLevel
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _ElementLevel = ""
         Else
           _ElementLevel = value
         End If
      End Set
    End Property
    Public Property Prefix() As String
      Get
        Return _Prefix
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _Prefix = ""
         Else
           _Prefix = value
         End If
      End Set
    End Property
    Public Property PAK_Elements1_Description() As String
      Get
        Return _PAK_Elements1_Description
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _PAK_Elements1_Description = ""
         Else
           _PAK_Elements1_Description = value
         End If
      End Set
    End Property
    Public Property PAK_ResponsibleAgencies2_Description() As String
      Get
        Return _PAK_ResponsibleAgencies2_Description
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _PAK_ResponsibleAgencies2_Description = ""
         Else
           _PAK_ResponsibleAgencies2_Description = value
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
        Return _ElementID
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
    Public Class PKpakElements
      Private _ElementID As String = ""
      Public Property ElementID() As String
        Get
          Return _ElementID
        End Get
        Set(ByVal value As String)
          _ElementID = value
        End Set
      End Property
    End Class
    Public ReadOnly Property FK_PAK_Elements_ParentElementID() As SIS.PAK.pakElements
      Get
        If _FK_PAK_Elements_ParentElementID Is Nothing Then
          _FK_PAK_Elements_ParentElementID = SIS.PAK.pakElements.pakElementsGetByID(_ParentElementID)
        End If
        Return _FK_PAK_Elements_ParentElementID
      End Get
    End Property
    Public ReadOnly Property FK_PAK_Elements_ResponsibleAgemcyID() As SIS.PAK.pakResponsibleAgencies
      Get
        If _FK_PAK_Elements_ResponsibleAgemcyID Is Nothing Then
          _FK_PAK_Elements_ResponsibleAgemcyID = SIS.PAK.pakResponsibleAgencies.pakResponsibleAgenciesGetByID(_ResponsibleAgencyID)
        End If
        Return _FK_PAK_Elements_ResponsibleAgemcyID
      End Get
    End Property
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function pakElementsSelectList(ByVal OrderBy As String) As List(Of SIS.PAK.pakElements)
      Dim Results As List(Of SIS.PAK.pakElements) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppakElementsSelectList"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.PAK.pakElements)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.PAK.pakElements(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function pakElementsGetNewRecord() As SIS.PAK.pakElements
      Return New SIS.PAK.pakElements()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function pakElementsGetByID(ByVal ElementID As String) As SIS.PAK.pakElements
      Dim Results As SIS.PAK.pakElements = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppakElementsSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ElementID",SqlDbType.NVarChar,ElementID.ToString.Length, ElementID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.PAK.pakElements(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function GetByParentElementID(ByVal ParentElementID As String, ByVal OrderBy as String) As List(Of SIS.PAK.pakElements)
      Dim Results As List(Of SIS.PAK.pakElements) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppakElementsSelectByParentElementID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ParentElementID",SqlDbType.NVarChar,ParentElementID.ToString.Length, ParentElementID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.PAK.pakElements)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.PAK.pakElements(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function pakElementsSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal ElementID As String, ByVal ResponsibleAgencyID As Int32) As List(Of SIS.PAK.pakElements)
      Dim Results As List(Of SIS.PAK.pakElements) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "sppakElementsSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "sppakElementsSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_ElementID",SqlDbType.NVarChar,8, IIf(ElementID Is Nothing, String.Empty,ElementID))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_ResponsibleAgencyID",SqlDbType.Int,10, IIf(ResponsibleAgencyID = Nothing, 0,ResponsibleAgencyID))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.PAK.pakElements)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.PAK.pakElements(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function pakElementsSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String, ByVal ElementID As String, ByVal ResponsibleAgencyID As Int32) As Integer
      Return _RecordCount
    End Function
      'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function pakElementsGetByID(ByVal ElementID As String, ByVal Filter_ElementID As String, ByVal Filter_ResponsibleAgencyID As Int32) As SIS.PAK.pakElements
      Return pakElementsGetByID(ElementID)
    End Function
    <DataObjectMethod(DataObjectMethodType.Insert, True)> _
    Public Shared Function pakElementsInsert(ByVal Record As SIS.PAK.pakElements) As SIS.PAK.pakElements
      Dim _Rec As SIS.PAK.pakElements = SIS.PAK.pakElements.pakElementsGetNewRecord()
      With _Rec
        .ElementID = Record.ElementID
        .Description = Record.Description
        .ResponsibleAgencyID = Record.ResponsibleAgencyID
        .ParentElementID = Record.ParentElementID
        .ElementLevel = Record.ElementLevel
        .Prefix = Record.Prefix
      End With
      Return SIS.PAK.pakElements.InsertData(_Rec)
    End Function
    Public Shared Function InsertData(ByVal Record As SIS.PAK.pakElements) As SIS.PAK.pakElements
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppakElementsInsert"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ElementID",SqlDbType.NVarChar,9, Record.ElementID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Description",SqlDbType.NVarChar,101, Iif(Record.Description= "" ,Convert.DBNull, Record.Description))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ResponsibleAgencyID",SqlDbType.Int,11, Iif(Record.ResponsibleAgencyID= "" ,Convert.DBNull, Record.ResponsibleAgencyID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ParentElementID",SqlDbType.NVarChar,9, Iif(Record.ParentElementID= "" ,Convert.DBNull, Record.ParentElementID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ElementLevel",SqlDbType.Int,11, Iif(Record.ElementLevel= "" ,Convert.DBNull, Record.ElementLevel))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Prefix",SqlDbType.NVarChar,1001, Iif(Record.Prefix= "" ,Convert.DBNull, Record.Prefix))
          Cmd.Parameters.Add("@Return_ElementID", SqlDbType.NVarChar, 9)
          Cmd.Parameters("@Return_ElementID").Direction = ParameterDirection.Output
          Con.Open()
          Cmd.ExecuteNonQuery()
          Record.ElementID = Cmd.Parameters("@Return_ElementID").Value
        End Using
      End Using
      Return Record
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)> _
    Public Shared Function pakElementsUpdate(ByVal Record As SIS.PAK.pakElements) As SIS.PAK.pakElements
      Dim _Rec As SIS.PAK.pakElements = SIS.PAK.pakElements.pakElementsGetByID(Record.ElementID)
      With _Rec
        .Description = Record.Description
        .ResponsibleAgencyID = Record.ResponsibleAgencyID
        .ParentElementID = Record.ParentElementID
        .ElementLevel = Record.ElementLevel
        .Prefix = Record.Prefix
      End With
      Return SIS.PAK.pakElements.UpdateData(_Rec)
    End Function
    Public Shared Function UpdateData(ByVal Record As SIS.PAK.pakElements) As SIS.PAK.pakElements
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppakElementsUpdate"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_ElementID",SqlDbType.NVarChar,9, Record.ElementID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ElementID",SqlDbType.NVarChar,9, Record.ElementID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Description",SqlDbType.NVarChar,101, Iif(Record.Description= "" ,Convert.DBNull, Record.Description))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ResponsibleAgencyID",SqlDbType.Int,11, Iif(Record.ResponsibleAgencyID= "" ,Convert.DBNull, Record.ResponsibleAgencyID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ParentElementID",SqlDbType.NVarChar,9, Iif(Record.ParentElementID= "" ,Convert.DBNull, Record.ParentElementID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ElementLevel",SqlDbType.Int,11, Iif(Record.ElementLevel= "" ,Convert.DBNull, Record.ElementLevel))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Prefix",SqlDbType.NVarChar,1001, Iif(Record.Prefix= "" ,Convert.DBNull, Record.Prefix))
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
    Public Shared Function pakElementsDelete(ByVal Record As SIS.PAK.pakElements) As Int32
      Dim _Result as Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppakElementsDelete"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_ElementID",SqlDbType.NVarChar,Record.ElementID.ToString.Length, Record.ElementID)
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
    Public Shared Function SelectpakElementsAutoCompleteList(ByVal Prefix As String, ByVal count As Integer, ByVal contextKey As String) As String()
      Dim Results As List(Of String) = Nothing
      Dim aVal() As String = contextKey.Split("|".ToCharArray)
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppakElementsAutoCompleteList"
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
            Dim Tmp As SIS.PAK.pakElements = New SIS.PAK.pakElements(Reader)
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
