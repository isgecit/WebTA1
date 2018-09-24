Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.PAK
  <DataObject()> _
  Partial Public Class pakItems
    Private Shared _RecordCount As Integer
    Private _RootItem As String = ""
    Private _ItemNo As Int32 = 0
    Private _ItemCode As String = ""
    Private _ItemDescription As String = ""
    Private _ElementID As String = ""
    Private _Active As Boolean = False
    Private _DivisionID As String = ""
    Private _Middle As Boolean = False
    Private _DocumentNo As String = ""
    Private _Prefix As String = ""
    Private _ItemLevel As Int32 = 0
    Private _Free As Boolean = False
    Private _Root As Boolean = False
    Private _UOMWeight As String = ""
    Private _Quantity As Decimal = 0
    Private _UOMQuantity As String = ""
    Private _Bottom As Boolean = False
    Private _WeightPerUnit As Decimal = 0
    Private _ParentItemNo As String = ""
    Private _PAK_Divisions1_Description As String = ""
    Private _PAK_Documents2_cmba As String = ""
    Private _PAK_Elements3_Description As String = ""
    Private _PAK_Items4_ItemDescription As String = ""
    Private _PAK_Units5_Description As String = ""
    Private _PAK_Units6_Description As String = ""
    Private _PAK_Items7_ItemDescription As String = ""
    Private _FK_PAK_Items_DivisionID As SIS.PAK.pakDivisions = Nothing
    Private _FK_PAK_Items_DocumentNo As SIS.PAK.pakDocuments = Nothing
    Private _FK_PAK_Items_ElementID As SIS.PAK.pakElements = Nothing
    Private _FK_PAK_Items_ParentItemNo As SIS.PAK.pakItems = Nothing
    Private _FK_PAK_Items_UOMQuantity As SIS.PAK.pakUnits = Nothing
    Private _FK_PAK_Items_UOMWeight As SIS.PAK.pakUnits = Nothing
    Private _FK_PAK_Items_RootItem As SIS.PAK.pakItems = Nothing
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
    Public Property RootItem() As String
      Get
        Return _RootItem
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _RootItem = ""
         Else
           _RootItem = value
         End If
      End Set
    End Property
    Public Property ItemNo() As Int32
      Get
        Return _ItemNo
      End Get
      Set(ByVal value As Int32)
        _ItemNo = value
      End Set
    End Property
    Public Property ItemCode() As String
      Get
        Return _ItemCode
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _ItemCode = ""
         Else
           _ItemCode = value
         End If
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
    Public Property ElementID() As String
      Get
        Return _ElementID
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _ElementID = ""
         Else
           _ElementID = value
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
    Public Property DivisionID() As String
      Get
        Return _DivisionID
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _DivisionID = ""
         Else
           _DivisionID = value
         End If
      End Set
    End Property
    Public Property Middle() As Boolean
      Get
        Return _Middle
      End Get
      Set(ByVal value As Boolean)
        _Middle = value
      End Set
    End Property
    Public Property DocumentNo() As String
      Get
        Return _DocumentNo
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _DocumentNo = ""
         Else
           _DocumentNo = value
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
    Public Property ItemLevel() As Int32
      Get
        Return _ItemLevel
      End Get
      Set(ByVal value As Int32)
        _ItemLevel = value
      End Set
    End Property
    Public Property Free() As Boolean
      Get
        Return _Free
      End Get
      Set(ByVal value As Boolean)
        _Free = value
      End Set
    End Property
    Public Property Root() As Boolean
      Get
        Return _Root
      End Get
      Set(ByVal value As Boolean)
        _Root = value
      End Set
    End Property
    Public Property UOMWeight() As String
      Get
        Return _UOMWeight
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _UOMWeight = ""
         Else
           _UOMWeight = value
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
    Public Property Bottom() As Boolean
      Get
        Return _Bottom
      End Get
      Set(ByVal value As Boolean)
        _Bottom = value
      End Set
    End Property
    Public Property WeightPerUnit() As Decimal
      Get
        Return _WeightPerUnit
      End Get
      Set(ByVal value As Decimal)
        _WeightPerUnit = value
      End Set
    End Property
    Public Property ParentItemNo() As String
      Get
        Return _ParentItemNo
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _ParentItemNo = ""
         Else
           _ParentItemNo = value
         End If
      End Set
    End Property
    Public Property PAK_Divisions1_Description() As String
      Get
        Return _PAK_Divisions1_Description
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _PAK_Divisions1_Description = ""
         Else
           _PAK_Divisions1_Description = value
         End If
      End Set
    End Property
    Public Property PAK_Documents2_cmba() As String
      Get
        Return _PAK_Documents2_cmba
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _PAK_Documents2_cmba = ""
         Else
           _PAK_Documents2_cmba = value
         End If
      End Set
    End Property
    Public Property PAK_Elements3_Description() As String
      Get
        Return _PAK_Elements3_Description
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _PAK_Elements3_Description = ""
         Else
           _PAK_Elements3_Description = value
         End If
      End Set
    End Property
    Public Property PAK_Items4_ItemDescription() As String
      Get
        Return _PAK_Items4_ItemDescription
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _PAK_Items4_ItemDescription = ""
         Else
           _PAK_Items4_ItemDescription = value
         End If
      End Set
    End Property
    Public Property PAK_Units5_Description() As String
      Get
        Return _PAK_Units5_Description
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _PAK_Units5_Description = ""
         Else
           _PAK_Units5_Description = value
         End If
      End Set
    End Property
    Public Property PAK_Units6_Description() As String
      Get
        Return _PAK_Units6_Description
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _PAK_Units6_Description = ""
         Else
           _PAK_Units6_Description = value
         End If
      End Set
    End Property
    Public Property PAK_Items7_ItemDescription() As String
      Get
        Return _PAK_Items7_ItemDescription
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _PAK_Items7_ItemDescription = ""
         Else
           _PAK_Items7_ItemDescription = value
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
        Return _ItemNo
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
    Public Class PKpakItems
      Private _ItemNo As Int32 = 0
      Public Property ItemNo() As Int32
        Get
          Return _ItemNo
        End Get
        Set(ByVal value As Int32)
          _ItemNo = value
        End Set
      End Property
    End Class
    Public ReadOnly Property FK_PAK_Items_DivisionID() As SIS.PAK.pakDivisions
      Get
        If _FK_PAK_Items_DivisionID Is Nothing Then
          _FK_PAK_Items_DivisionID = SIS.PAK.pakDivisions.pakDivisionsGetByID(_DivisionID)
        End If
        Return _FK_PAK_Items_DivisionID
      End Get
    End Property
    Public ReadOnly Property FK_PAK_Items_DocumentNo() As SIS.PAK.pakDocuments
      Get
        If _FK_PAK_Items_DocumentNo Is Nothing Then
          _FK_PAK_Items_DocumentNo = SIS.PAK.pakDocuments.pakDocumentsGetByID(_DocumentNo)
        End If
        Return _FK_PAK_Items_DocumentNo
      End Get
    End Property
    Public ReadOnly Property FK_PAK_Items_ElementID() As SIS.PAK.pakElements
      Get
        If _FK_PAK_Items_ElementID Is Nothing Then
          _FK_PAK_Items_ElementID = SIS.PAK.pakElements.pakElementsGetByID(_ElementID)
        End If
        Return _FK_PAK_Items_ElementID
      End Get
    End Property
    Public ReadOnly Property FK_PAK_Items_ParentItemNo() As SIS.PAK.pakItems
      Get
        If _FK_PAK_Items_ParentItemNo Is Nothing Then
          _FK_PAK_Items_ParentItemNo = SIS.PAK.pakItems.pakItemsGetByID(_ParentItemNo)
        End If
        Return _FK_PAK_Items_ParentItemNo
      End Get
    End Property
    Public ReadOnly Property FK_PAK_Items_UOMQuantity() As SIS.PAK.pakUnits
      Get
        If _FK_PAK_Items_UOMQuantity Is Nothing Then
          _FK_PAK_Items_UOMQuantity = SIS.PAK.pakUnits.pakUnitsGetByID(_UOMQuantity)
        End If
        Return _FK_PAK_Items_UOMQuantity
      End Get
    End Property
    Public ReadOnly Property FK_PAK_Items_UOMWeight() As SIS.PAK.pakUnits
      Get
        If _FK_PAK_Items_UOMWeight Is Nothing Then
          _FK_PAK_Items_UOMWeight = SIS.PAK.pakUnits.pakUnitsGetByID(_UOMWeight)
        End If
        Return _FK_PAK_Items_UOMWeight
      End Get
    End Property
    Public ReadOnly Property FK_PAK_Items_RootItem() As SIS.PAK.pakItems
      Get
        If _FK_PAK_Items_RootItem Is Nothing Then
          _FK_PAK_Items_RootItem = SIS.PAK.pakItems.pakItemsGetByID(_RootItem)
        End If
        Return _FK_PAK_Items_RootItem
      End Get
    End Property
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function pakItemsSelectList(ByVal OrderBy As String) As List(Of SIS.PAK.pakItems)
      Dim Results As List(Of SIS.PAK.pakItems) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppakItemsSelectList"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DivisionID",SqlDbType.Int,10, Global.System.Web.HttpContext.Current.Session("DivisionID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Root",SqlDbType.Bit,2, True)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.PAK.pakItems)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.PAK.pakItems(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function pakItemsGetNewRecord() As SIS.PAK.pakItems
      Return New SIS.PAK.pakItems()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function pakItemsGetByID(ByVal ItemNo As Int32) As SIS.PAK.pakItems
      Dim Results As SIS.PAK.pakItems = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppakItemsSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ItemNo",SqlDbType.Int,ItemNo.ToString.Length, ItemNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.PAK.pakItems(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function GetByRootItem(ByVal RootItem As Int32, ByVal OrderBy as String) As List(Of SIS.PAK.pakItems)
      Dim Results As List(Of SIS.PAK.pakItems) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppakItemsSelectByRootItem"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@RootItem",SqlDbType.Int,RootItem.ToString.Length, RootItem)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DivisionID",SqlDbType.Int,10, Global.System.Web.HttpContext.Current.Session("DivisionID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Root",SqlDbType.Bit,2, True)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.PAK.pakItems)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.PAK.pakItems(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function GetByParentItemNo(ByVal ParentItemNo As Int32, ByVal OrderBy as String) As List(Of SIS.PAK.pakItems)
      Dim Results As List(Of SIS.PAK.pakItems) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppakItemsSelectByParentItemNo"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ParentItemNo",SqlDbType.Int,ParentItemNo.ToString.Length, ParentItemNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DivisionID",SqlDbType.Int,10, Global.System.Web.HttpContext.Current.Session("DivisionID"))
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.PAK.pakItems)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.PAK.pakItems(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function pakItemsSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal RootItem As Int32) As List(Of SIS.PAK.pakItems)
      Dim Results As List(Of SIS.PAK.pakItems) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "sppakItemsSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "sppakItemsSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_RootItem",SqlDbType.Int,10, IIf(RootItem = Nothing, 0,RootItem))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DivisionID",SqlDbType.Int,10, Global.System.Web.HttpContext.Current.Session("DivisionID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Root",SqlDbType.Bit,2, True)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.PAK.pakItems)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.PAK.pakItems(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function pakItemsSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String, ByVal RootItem As Int32) As Integer
      Return _RecordCount
    End Function
      'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function pakItemsGetByID(ByVal ItemNo As Int32, ByVal Filter_RootItem As Int32) As SIS.PAK.pakItems
      Return pakItemsGetByID(ItemNo)
    End Function
    <DataObjectMethod(DataObjectMethodType.Insert, True)> _
    Public Shared Function pakItemsInsert(ByVal Record As SIS.PAK.pakItems) As SIS.PAK.pakItems
      Dim _Rec As SIS.PAK.pakItems = SIS.PAK.pakItems.pakItemsGetNewRecord()
      With _Rec
        .RootItem = Record.RootItem
        .ItemCode = Record.ItemCode
        .ItemDescription = Record.ItemDescription
        .ElementID = Record.ElementID
        .Active = Record.Active
        .DivisionID =  Global.System.Web.HttpContext.Current.Session("DivisionID")
        .Middle = Record.Middle
        .DocumentNo = Record.DocumentNo
        .Prefix = Record.Prefix
        .ItemLevel = Record.ItemLevel
        .Free = Record.Free
        .Root = True
        .UOMWeight = Record.UOMWeight
        .Quantity = Record.Quantity
        .UOMQuantity = Record.UOMQuantity
        .Bottom = Record.Bottom
        .WeightPerUnit = Record.WeightPerUnit
        .ParentItemNo = Record.ParentItemNo
      End With
      Return SIS.PAK.pakItems.InsertData(_Rec)
    End Function
    Public Shared Function InsertData(ByVal Record As SIS.PAK.pakItems) As SIS.PAK.pakItems
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppakItemsInsert"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@RootItem",SqlDbType.Int,11, Iif(Record.RootItem= "" ,Convert.DBNull, Record.RootItem))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ItemCode",SqlDbType.NVarChar,51, Iif(Record.ItemCode= "" ,Convert.DBNull, Record.ItemCode))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ItemDescription",SqlDbType.NVarChar,101, Iif(Record.ItemDescription= "" ,Convert.DBNull, Record.ItemDescription))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ElementID",SqlDbType.NVarChar,9, Iif(Record.ElementID= "" ,Convert.DBNull, Record.ElementID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Active",SqlDbType.Bit,3, Record.Active)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DivisionID",SqlDbType.Int,11, Iif(Record.DivisionID= "" ,Convert.DBNull, Record.DivisionID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Middle",SqlDbType.Bit,3, Record.Middle)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DocumentNo",SqlDbType.Int,11, Iif(Record.DocumentNo= "" ,Convert.DBNull, Record.DocumentNo))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Prefix",SqlDbType.NVarChar,1001, Iif(Record.Prefix= "" ,Convert.DBNull, Record.Prefix))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ItemLevel",SqlDbType.Int,11, Record.ItemLevel)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Free",SqlDbType.Bit,3, Record.Free)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Root",SqlDbType.Bit,3, Record.Root)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@UOMWeight",SqlDbType.Int,11, Iif(Record.UOMWeight= "" ,Convert.DBNull, Record.UOMWeight))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Quantity",SqlDbType.Decimal,21, Record.Quantity)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@UOMQuantity",SqlDbType.Int,11, Iif(Record.UOMQuantity= "" ,Convert.DBNull, Record.UOMQuantity))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Bottom",SqlDbType.Bit,3, Record.Bottom)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@WeightPerUnit",SqlDbType.Decimal,21, Record.WeightPerUnit)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ParentItemNo",SqlDbType.Int,11, Iif(Record.ParentItemNo= "" ,Convert.DBNull, Record.ParentItemNo))
          Cmd.Parameters.Add("@Return_ItemNo", SqlDbType.Int, 11)
          Cmd.Parameters("@Return_ItemNo").Direction = ParameterDirection.Output
          Con.Open()
          Cmd.ExecuteNonQuery()
          Record.ItemNo = Cmd.Parameters("@Return_ItemNo").Value
        End Using
      End Using
      Return Record
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)> _
    Public Shared Function pakItemsUpdate(ByVal Record As SIS.PAK.pakItems) As SIS.PAK.pakItems
      Dim _Rec As SIS.PAK.pakItems = SIS.PAK.pakItems.pakItemsGetByID(Record.ItemNo)
      With _Rec
        .RootItem = Record.RootItem
        .ItemCode = Record.ItemCode
        .ItemDescription = Record.ItemDescription
        .ElementID = Record.ElementID
        .Active = Record.Active
        .DivisionID = Global.System.Web.HttpContext.Current.Session("DivisionID")
        .Middle = Record.Middle
        .DocumentNo = Record.DocumentNo
        .Prefix = Record.Prefix
        .ItemLevel = Record.ItemLevel
        .Free = Record.Free
        .Root = True
        .UOMWeight = Record.UOMWeight
        .Quantity = Record.Quantity
        .UOMQuantity = Record.UOMQuantity
        .Bottom = Record.Bottom
        .WeightPerUnit = Record.WeightPerUnit
        .ParentItemNo = Record.ParentItemNo
      End With
      Return SIS.PAK.pakItems.UpdateData(_Rec)
    End Function
    Public Shared Function UpdateData(ByVal Record As SIS.PAK.pakItems) As SIS.PAK.pakItems
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppakItemsUpdate"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_ItemNo",SqlDbType.Int,11, Record.ItemNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@RootItem",SqlDbType.Int,11, Iif(Record.RootItem= "" ,Convert.DBNull, Record.RootItem))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ItemCode",SqlDbType.NVarChar,51, Iif(Record.ItemCode= "" ,Convert.DBNull, Record.ItemCode))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ItemDescription",SqlDbType.NVarChar,101, Iif(Record.ItemDescription= "" ,Convert.DBNull, Record.ItemDescription))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ElementID",SqlDbType.NVarChar,9, Iif(Record.ElementID= "" ,Convert.DBNull, Record.ElementID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Active",SqlDbType.Bit,3, Record.Active)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DivisionID",SqlDbType.Int,11, Iif(Record.DivisionID= "" ,Convert.DBNull, Record.DivisionID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Middle",SqlDbType.Bit,3, Record.Middle)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DocumentNo",SqlDbType.Int,11, Iif(Record.DocumentNo= "" ,Convert.DBNull, Record.DocumentNo))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Prefix",SqlDbType.NVarChar,1001, Iif(Record.Prefix= "" ,Convert.DBNull, Record.Prefix))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ItemLevel",SqlDbType.Int,11, Record.ItemLevel)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Free",SqlDbType.Bit,3, Record.Free)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Root",SqlDbType.Bit,3, Record.Root)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@UOMWeight",SqlDbType.Int,11, Iif(Record.UOMWeight= "" ,Convert.DBNull, Record.UOMWeight))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Quantity",SqlDbType.Decimal,21, Record.Quantity)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@UOMQuantity",SqlDbType.Int,11, Iif(Record.UOMQuantity= "" ,Convert.DBNull, Record.UOMQuantity))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Bottom",SqlDbType.Bit,3, Record.Bottom)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@WeightPerUnit",SqlDbType.Decimal,21, Record.WeightPerUnit)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ParentItemNo",SqlDbType.Int,11, Iif(Record.ParentItemNo= "" ,Convert.DBNull, Record.ParentItemNo))
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
    Public Shared Function pakItemsDelete(ByVal Record As SIS.PAK.pakItems) As Int32
      Dim _Result as Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppakItemsDelete"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_ItemNo",SqlDbType.Int,Record.ItemNo.ToString.Length, Record.ItemNo)
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
    Public Shared Function SelectpakItemsAutoCompleteList(ByVal Prefix As String, ByVal count As Integer, ByVal contextKey As String) As String()
      Dim Results As List(Of String) = Nothing
      Dim aVal() As String = contextKey.Split("|".ToCharArray)
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppakItemsAutoCompleteList"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DivisionID",SqlDbType.Int,10, Global.System.Web.HttpContext.Current.Session("DivisionID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Root",SqlDbType.Bit,2, True)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@prefix", SqlDbType.NVarChar, 50, Prefix)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@records", SqlDbType.Int, -1, count)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@bycode", SqlDbType.Int, 1, IIf(IsNumeric(Prefix), 0, 1))
          Results = New List(Of String)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Not Reader.HasRows Then
            Results.Add(AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem("---Select Value---".PadRight(100, " "),""))
          End If
          While (Reader.Read())
            Dim Tmp As SIS.PAK.pakItems = New SIS.PAK.pakItems(Reader)
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
