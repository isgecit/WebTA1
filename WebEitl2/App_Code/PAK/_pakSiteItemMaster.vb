Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.PAK
  <DataObject()> _
  Partial Public Class pakSiteItemMaster
    Private Shared _RecordCount As Integer
    Private _ProjectID As String = ""
    Private _SiteMarkNo As String = ""
    Private _ItemDescription As String = ""
    Private _UOMQuantity As String = ""
    Private _Quantity As Decimal = 0
    Private _IDM_Projects1_Description As String = ""
    Private _PAK_Units2_Description As String = ""
    Private _FK_PAK_SiteItemMaster_ProjectID As SIS.QCM.qcmProjects = Nothing
    Private _FK_PAK_SiteItemMaster_UOMQuantity As SIS.PAK.pakUnits = Nothing
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
    Public Property ProjectID() As String
      Get
        Return _ProjectID
      End Get
      Set(ByVal value As String)
        _ProjectID = value
      End Set
    End Property
    Public Property SiteMarkNo() As String
      Get
        Return _SiteMarkNo
      End Get
      Set(ByVal value As String)
        _SiteMarkNo = value
      End Set
    End Property
    Public Property ItemDescription() As String
      Get
        Return _ItemDescription
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _ItemDescription = ""
         Else
           _ItemDescription = value
         End If
      End Set
    End Property
    Public Property UOMQuantity() As String
      Get
        Return _UOMQuantity
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _UOMQuantity = ""
         Else
           _UOMQuantity = value
         End If
      End Set
    End Property
    Public Property Quantity() As Decimal
      Get
        Return _Quantity
      End Get
      Set(ByVal value As Decimal)
        _Quantity = value
      End Set
    End Property
    Public Property IDM_Projects1_Description() As String
      Get
        Return _IDM_Projects1_Description
      End Get
      Set(ByVal value As String)
        _IDM_Projects1_Description = value
      End Set
    End Property
    Public Property PAK_Units2_Description() As String
      Get
        Return _PAK_Units2_Description
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _PAK_Units2_Description = ""
         Else
           _PAK_Units2_Description = value
         End If
      End Set
    End Property
    Public Readonly Property DisplayField() As String
      Get
        Return "" & _ItemDescription.ToString.PadRight(100, " ")
      End Get
    End Property
    Public Readonly Property PrimaryKey() As String
      Get
        Return _ProjectID & "|" & _SiteMarkNo
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
    Public Class PKpakSiteItemMaster
      Private _ProjectID As String = ""
      Private _SiteMarkNo As String = ""
      Public Property ProjectID() As String
        Get
          Return _ProjectID
        End Get
        Set(ByVal value As String)
          _ProjectID = value
        End Set
      End Property
      Public Property SiteMarkNo() As String
        Get
          Return _SiteMarkNo
        End Get
        Set(ByVal value As String)
          _SiteMarkNo = value
        End Set
      End Property
    End Class
    Public ReadOnly Property FK_PAK_SiteItemMaster_ProjectID() As SIS.QCM.qcmProjects
      Get
        If _FK_PAK_SiteItemMaster_ProjectID Is Nothing Then
          _FK_PAK_SiteItemMaster_ProjectID = SIS.QCM.qcmProjects.qcmProjectsGetByID(_ProjectID)
        End If
        Return _FK_PAK_SiteItemMaster_ProjectID
      End Get
    End Property
    Public ReadOnly Property FK_PAK_SiteItemMaster_UOMQuantity() As SIS.PAK.pakUnits
      Get
        If _FK_PAK_SiteItemMaster_UOMQuantity Is Nothing Then
          _FK_PAK_SiteItemMaster_UOMQuantity = SIS.PAK.pakUnits.pakUnitsGetByID(_UOMQuantity)
        End If
        Return _FK_PAK_SiteItemMaster_UOMQuantity
      End Get
    End Property
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function pakSiteItemMasterSelectList(ByVal OrderBy As String) As List(Of SIS.PAK.pakSiteItemMaster)
      Dim Results As List(Of SIS.PAK.pakSiteItemMaster) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppakSiteItemMasterSelectList"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.PAK.pakSiteItemMaster)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.PAK.pakSiteItemMaster(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function pakSiteItemMasterGetNewRecord() As SIS.PAK.pakSiteItemMaster
      Return New SIS.PAK.pakSiteItemMaster()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function pakSiteItemMasterGetByID(ByVal ProjectID As String, ByVal SiteMarkNo As String) As SIS.PAK.pakSiteItemMaster
      Dim Results As SIS.PAK.pakSiteItemMaster = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppakSiteItemMasterSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ProjectID",SqlDbType.NVarChar,ProjectID.ToString.Length, ProjectID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SiteMarkNo",SqlDbType.NVarChar,SiteMarkNo.ToString.Length, SiteMarkNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.PAK.pakSiteItemMaster(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function pakSiteItemMasterSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal ProjectID As String) As List(Of SIS.PAK.pakSiteItemMaster)
      Dim Results As List(Of SIS.PAK.pakSiteItemMaster) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "sppakSiteItemMasterSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "sppakSiteItemMasterSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_ProjectID",SqlDbType.NVarChar,6, IIf(ProjectID Is Nothing, String.Empty,ProjectID))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.PAK.pakSiteItemMaster)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.PAK.pakSiteItemMaster(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function pakSiteItemMasterSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String, ByVal ProjectID As String) As Integer
      Return _RecordCount
    End Function
      'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function pakSiteItemMasterGetByID(ByVal ProjectID As String, ByVal SiteMarkNo As String, ByVal Filter_ProjectID As String) As SIS.PAK.pakSiteItemMaster
      Return pakSiteItemMasterGetByID(ProjectID, SiteMarkNo)
    End Function
    <DataObjectMethod(DataObjectMethodType.Insert, True)> _
    Public Shared Function pakSiteItemMasterInsert(ByVal Record As SIS.PAK.pakSiteItemMaster) As SIS.PAK.pakSiteItemMaster
      Dim _Rec As SIS.PAK.pakSiteItemMaster = SIS.PAK.pakSiteItemMaster.pakSiteItemMasterGetNewRecord()
      With _Rec
        .ProjectID = Record.ProjectID
        .SiteMarkNo = Record.SiteMarkNo
        .ItemDescription = Record.ItemDescription
        .UOMQuantity = Record.UOMQuantity
        .Quantity = Record.Quantity
      End With
      Return SIS.PAK.pakSiteItemMaster.InsertData(_Rec)
    End Function
    Public Shared Function InsertData(ByVal Record As SIS.PAK.pakSiteItemMaster) As SIS.PAK.pakSiteItemMaster
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppakSiteItemMasterInsert"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ProjectID",SqlDbType.NVarChar,7, Record.ProjectID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SiteMarkNo",SqlDbType.NVarChar,31, Record.SiteMarkNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ItemDescription",SqlDbType.NVarChar,101, Iif(Record.ItemDescription= "" ,Convert.DBNull, Record.ItemDescription))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@UOMQuantity",SqlDbType.Int,11, Iif(Record.UOMQuantity= "" ,Convert.DBNull, Record.UOMQuantity))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Quantity",SqlDbType.Decimal,21, Record.Quantity)
          Cmd.Parameters.Add("@Return_ProjectID", SqlDbType.NVarChar, 7)
          Cmd.Parameters("@Return_ProjectID").Direction = ParameterDirection.Output
          Cmd.Parameters.Add("@Return_SiteMarkNo", SqlDbType.NVarChar, 31)
          Cmd.Parameters("@Return_SiteMarkNo").Direction = ParameterDirection.Output
          Con.Open()
          Cmd.ExecuteNonQuery()
          Record.ProjectID = Cmd.Parameters("@Return_ProjectID").Value
          Record.SiteMarkNo = Cmd.Parameters("@Return_SiteMarkNo").Value
        End Using
      End Using
      Return Record
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)> _
    Public Shared Function pakSiteItemMasterUpdate(ByVal Record As SIS.PAK.pakSiteItemMaster) As SIS.PAK.pakSiteItemMaster
      Dim _Rec As SIS.PAK.pakSiteItemMaster = SIS.PAK.pakSiteItemMaster.pakSiteItemMasterGetByID(Record.ProjectID, Record.SiteMarkNo)
      With _Rec
        .ItemDescription = Record.ItemDescription
        .UOMQuantity = Record.UOMQuantity
        .Quantity = Record.Quantity
      End With
      Return SIS.PAK.pakSiteItemMaster.UpdateData(_Rec)
    End Function
    Public Shared Function UpdateData(ByVal Record As SIS.PAK.pakSiteItemMaster) As SIS.PAK.pakSiteItemMaster
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppakSiteItemMasterUpdate"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_ProjectID",SqlDbType.NVarChar,7, Record.ProjectID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_SiteMarkNo",SqlDbType.NVarChar,31, Record.SiteMarkNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ProjectID",SqlDbType.NVarChar,7, Record.ProjectID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SiteMarkNo",SqlDbType.NVarChar,31, Record.SiteMarkNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ItemDescription",SqlDbType.NVarChar,101, Iif(Record.ItemDescription= "" ,Convert.DBNull, Record.ItemDescription))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@UOMQuantity",SqlDbType.Int,11, Iif(Record.UOMQuantity= "" ,Convert.DBNull, Record.UOMQuantity))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Quantity",SqlDbType.Decimal,21, Record.Quantity)
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
    Public Shared Function pakSiteItemMasterDelete(ByVal Record As SIS.PAK.pakSiteItemMaster) As Int32
      Dim _Result as Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppakSiteItemMasterDelete"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_ProjectID",SqlDbType.NVarChar,Record.ProjectID.ToString.Length, Record.ProjectID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_SiteMarkNo",SqlDbType.NVarChar,Record.SiteMarkNo.ToString.Length, Record.SiteMarkNo)
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
    Public Shared Function SelectpakSiteItemMasterAutoCompleteList(ByVal Prefix As String, ByVal count As Integer, ByVal contextKey As String) As String()
      Dim Results As List(Of String) = Nothing
      Dim aVal() As String = contextKey.Split("|".ToCharArray)
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppak_LG_SiteItemMasterAutoCompleteList"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@prefix", SqlDbType.NVarChar, 50, Prefix)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ContextKey", SqlDbType.NVarChar, 50, contextKey)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@records", SqlDbType.Int, -1, count)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@bycode", SqlDbType.Int, 1, IIf(IsNumeric(Prefix),0,IIf(Prefix.ToLower=Prefix, 0, 1)))
          Results = New List(Of String)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Not Reader.HasRows Then
            Results.Add(AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem("---Select Value---".PadRight(100, " "),"" & "|" & ""))
          End If
          While (Reader.Read())
            Dim Tmp As SIS.PAK.pakSiteItemMaster = New SIS.PAK.pakSiteItemMaster(Reader)
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
