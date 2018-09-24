Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.NPRK
  <DataObject()> _
  Partial Public Class nprkSiteAllowanceEntitlement
    Private Shared _RecordCount As Integer
    Private _SerialNo As Int32 = 0
    Private _TACategoryID As String = ""
    Private _EntitlementAmount As String = "0.00"
    Private _FromDate As String = ""
    Private _TillDate As String = ""
    Private _TA_Categories1_cmba As String = ""
    Private _FK_PRK_SiteAllowanceEntitlement_TACategoryID As SIS.TA.taCategories = Nothing
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
    Public Property TACategoryID() As String
      Get
        Return _TACategoryID
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _TACategoryID = ""
         Else
           _TACategoryID = value
         End If
      End Set
    End Property
    Public Property EntitlementAmount() As String
      Get
        Return _EntitlementAmount
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _EntitlementAmount = "0.00"
         Else
           _EntitlementAmount = value
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
         If Convert.IsDBNull(Value) Then
           _FromDate = ""
         Else
           _FromDate = value
         End If
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
    Public Class PKnprkSiteAllowanceEntitlement
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
    Public ReadOnly Property FK_PRK_SiteAllowanceEntitlement_TACategoryID() As SIS.TA.taCategories
      Get
        If _FK_PRK_SiteAllowanceEntitlement_TACategoryID Is Nothing Then
          _FK_PRK_SiteAllowanceEntitlement_TACategoryID = SIS.TA.taCategories.taCategoriesGetByID(_TACategoryID)
        End If
        Return _FK_PRK_SiteAllowanceEntitlement_TACategoryID
      End Get
    End Property
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function nprkSiteAllowanceEntitlementGetNewRecord() As SIS.NPRK.nprkSiteAllowanceEntitlement
      Return New SIS.NPRK.nprkSiteAllowanceEntitlement()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function nprkSiteAllowanceEntitlementGetByID(ByVal SerialNo As Int32) As SIS.NPRK.nprkSiteAllowanceEntitlement
      Dim Results As SIS.NPRK.nprkSiteAllowanceEntitlement = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spnprkSiteAllowanceEntitlementSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SerialNo",SqlDbType.Int,SerialNo.ToString.Length, SerialNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.NPRK.nprkSiteAllowanceEntitlement(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function nprkSiteAllowanceEntitlementSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal TACategoryID As Int32) As List(Of SIS.NPRK.nprkSiteAllowanceEntitlement)
      Dim Results As List(Of SIS.NPRK.nprkSiteAllowanceEntitlement) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "spnprkSiteAllowanceEntitlementSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "spnprkSiteAllowanceEntitlementSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_TACategoryID",SqlDbType.Int,10, IIf(TACategoryID = Nothing, 0,TACategoryID))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.NPRK.nprkSiteAllowanceEntitlement)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.NPRK.nprkSiteAllowanceEntitlement(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function nprkSiteAllowanceEntitlementSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String, ByVal TACategoryID As Int32) As Integer
      Return _RecordCount
    End Function
      'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function nprkSiteAllowanceEntitlementGetByID(ByVal SerialNo As Int32, ByVal Filter_TACategoryID As Int32) As SIS.NPRK.nprkSiteAllowanceEntitlement
      Return nprkSiteAllowanceEntitlementGetByID(SerialNo)
    End Function
    <DataObjectMethod(DataObjectMethodType.Insert, True)> _
    Public Shared Function nprkSiteAllowanceEntitlementInsert(ByVal Record As SIS.NPRK.nprkSiteAllowanceEntitlement) As SIS.NPRK.nprkSiteAllowanceEntitlement
      Dim _Rec As SIS.NPRK.nprkSiteAllowanceEntitlement = SIS.NPRK.nprkSiteAllowanceEntitlement.nprkSiteAllowanceEntitlementGetNewRecord()
      With _Rec
        .TACategoryID = Record.TACategoryID
        .EntitlementAmount = Record.EntitlementAmount
        .FromDate = Record.FromDate
        .TillDate = Record.TillDate
      End With
      Return SIS.NPRK.nprkSiteAllowanceEntitlement.InsertData(_Rec)
    End Function
    Public Shared Function InsertData(ByVal Record As SIS.NPRK.nprkSiteAllowanceEntitlement) As SIS.NPRK.nprkSiteAllowanceEntitlement
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spnprkSiteAllowanceEntitlementInsert"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TACategoryID",SqlDbType.Int,11, Iif(Record.TACategoryID= "" ,Convert.DBNull, Record.TACategoryID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@EntitlementAmount",SqlDbType.Decimal,21, Iif(Record.EntitlementAmount= "" ,Convert.DBNull, Record.EntitlementAmount))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FromDate",SqlDbType.DateTime,21, Iif(Record.FromDate= "" ,Convert.DBNull, Record.FromDate))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TillDate",SqlDbType.DateTime,21, Iif(Record.TillDate= "" ,Convert.DBNull, Record.TillDate))
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
    Public Shared Function nprkSiteAllowanceEntitlementUpdate(ByVal Record As SIS.NPRK.nprkSiteAllowanceEntitlement) As SIS.NPRK.nprkSiteAllowanceEntitlement
      Dim _Rec As SIS.NPRK.nprkSiteAllowanceEntitlement = SIS.NPRK.nprkSiteAllowanceEntitlement.nprkSiteAllowanceEntitlementGetByID(Record.SerialNo)
      With _Rec
        .TACategoryID = Record.TACategoryID
        .EntitlementAmount = Record.EntitlementAmount
        .FromDate = Record.FromDate
        .TillDate = Record.TillDate
      End With
      Return SIS.NPRK.nprkSiteAllowanceEntitlement.UpdateData(_Rec)
    End Function
    Public Shared Function UpdateData(ByVal Record As SIS.NPRK.nprkSiteAllowanceEntitlement) As SIS.NPRK.nprkSiteAllowanceEntitlement
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spnprkSiteAllowanceEntitlementUpdate"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_SerialNo",SqlDbType.Int,11, Record.SerialNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TACategoryID",SqlDbType.Int,11, Iif(Record.TACategoryID= "" ,Convert.DBNull, Record.TACategoryID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@EntitlementAmount",SqlDbType.Decimal,21, Iif(Record.EntitlementAmount= "" ,Convert.DBNull, Record.EntitlementAmount))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FromDate",SqlDbType.DateTime,21, Iif(Record.FromDate= "" ,Convert.DBNull, Record.FromDate))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TillDate",SqlDbType.DateTime,21, Iif(Record.TillDate= "" ,Convert.DBNull, Record.TillDate))
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
    Public Shared Function nprkSiteAllowanceEntitlementDelete(ByVal Record As SIS.NPRK.nprkSiteAllowanceEntitlement) As Int32
      Dim _Result as Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spnprkSiteAllowanceEntitlementDelete"
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
