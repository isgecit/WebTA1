Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.PAK
  <DataObject()> _
  Partial Public Class pakTCPOL
    Private Shared _RecordCount As Integer
    Private _ItemNo As Int32 = 0
    Private _ItemCode As String = ""
    Private _ItemDescription As String = ""
    Private _ItemQuantity As String = "0.00"
    Private _ItemElement As String = ""
    Private _ItemStatusID As String = ""
    Private _SerialNo As Int32 = 0
    Private _ItemUnit As String = ""
    Private _ItemPrice As String = "0.00"
    Private _ItemAmount As String = "0.00"
    Private _IDM_WBS1_Description As String = ""
    Private _PAK_PO2_PODescription As String = ""
    Private _PAK_POLineStatus3_Description As String = ""
    Private _FK_PAK_POLine_ItemElement As SIS.PAK.pakWBS = Nothing
    Private _FK_PAK_POLine_SerialNo As SIS.PAK.pakPO = Nothing
    Private _FK_PAK_POLine_ItemStatusID As SIS.PAK.pakTCPOLStatus = Nothing
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
    Public Property ItemQuantity() As String
      Get
        Return _ItemQuantity
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _ItemQuantity = "0.00"
         Else
           _ItemQuantity = value
         End If
      End Set
    End Property
    Public Property ItemElement() As String
      Get
        Return _ItemElement
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _ItemElement = ""
         Else
           _ItemElement = value
         End If
      End Set
    End Property
    Public Property ItemStatusID() As String
      Get
        Return _ItemStatusID
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _ItemStatusID = ""
         Else
           _ItemStatusID = value
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
    Public Property ItemUnit() As String
      Get
        Return _ItemUnit
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _ItemUnit = ""
         Else
           _ItemUnit = value
         End If
      End Set
    End Property
    Public Property ItemPrice() As String
      Get
        Return _ItemPrice
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _ItemPrice = "0.00"
         Else
           _ItemPrice = value
         End If
      End Set
    End Property
    Public Property ItemAmount() As String
      Get
        Return _ItemAmount
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _ItemAmount = "0.00"
         Else
           _ItemAmount = value
         End If
      End Set
    End Property
    Public Property IDM_WBS1_Description() As String
      Get
        Return _IDM_WBS1_Description
      End Get
      Set(ByVal value As String)
        _IDM_WBS1_Description = value
      End Set
    End Property
    Public Property PAK_PO2_PODescription() As String
      Get
        Return _PAK_PO2_PODescription
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _PAK_PO2_PODescription = ""
         Else
           _PAK_PO2_PODescription = value
         End If
      End Set
    End Property
    Public Property PAK_POLineStatus3_Description() As String
      Get
        Return _PAK_POLineStatus3_Description
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _PAK_POLineStatus3_Description = ""
         Else
           _PAK_POLineStatus3_Description = value
         End If
      End Set
    End Property
    Public Readonly Property DisplayField() As String
      Get
        Return "" & _ItemCode.ToString.PadRight(47, " ")
      End Get
    End Property
    Public Readonly Property PrimaryKey() As String
      Get
        Return _SerialNo & "|" & _ItemNo
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
    Public Class PKpakTCPOL
      Private _SerialNo As Int32 = 0
      Private _ItemNo As Int32 = 0
      Public Property SerialNo() As Int32
        Get
          Return _SerialNo
        End Get
        Set(ByVal value As Int32)
          _SerialNo = value
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
    End Class
    Public ReadOnly Property FK_PAK_POLine_ItemElement() As SIS.PAK.pakWBS
      Get
        If _FK_PAK_POLine_ItemElement Is Nothing Then
          _FK_PAK_POLine_ItemElement = SIS.PAK.pakWBS.pakWBSGetByID(_ItemElement)
        End If
        Return _FK_PAK_POLine_ItemElement
      End Get
    End Property
    Public ReadOnly Property FK_PAK_POLine_SerialNo() As SIS.PAK.pakPO
      Get
        If _FK_PAK_POLine_SerialNo Is Nothing Then
          _FK_PAK_POLine_SerialNo = SIS.PAK.pakPO.pakPOGetByID(_SerialNo)
        End If
        Return _FK_PAK_POLine_SerialNo
      End Get
    End Property
    Public ReadOnly Property FK_PAK_POLine_ItemStatusID() As SIS.PAK.pakTCPOLStatus
      Get
        If _FK_PAK_POLine_ItemStatusID Is Nothing Then
          _FK_PAK_POLine_ItemStatusID = SIS.PAK.pakTCPOLStatus.pakTCPOLStatusGetByID(_ItemStatusID)
        End If
        Return _FK_PAK_POLine_ItemStatusID
      End Get
    End Property
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function pakTCPOLSelectList(ByVal OrderBy As String) As List(Of SIS.PAK.pakTCPOL)
      Dim Results As List(Of SIS.PAK.pakTCPOL) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppakTCPOLSelectList"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.PAK.pakTCPOL)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.PAK.pakTCPOL(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function pakTCPOLGetNewRecord() As SIS.PAK.pakTCPOL
      Return New SIS.PAK.pakTCPOL()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function pakTCPOLGetByID(ByVal SerialNo As Int32, ByVal ItemNo As Int32) As SIS.PAK.pakTCPOL
      Dim Results As SIS.PAK.pakTCPOL = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppakTCPOLSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SerialNo",SqlDbType.Int,SerialNo.ToString.Length, SerialNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ItemNo",SqlDbType.Int,ItemNo.ToString.Length, ItemNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.PAK.pakTCPOL(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function pakTCPOLSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal SerialNo As Int32) As List(Of SIS.PAK.pakTCPOL)
      Dim Results As List(Of SIS.PAK.pakTCPOL) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "sppakTCPOLSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "sppakTCPOLSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_SerialNo",SqlDbType.Int,10, IIf(SerialNo = Nothing, 0,SerialNo))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.PAK.pakTCPOL)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.PAK.pakTCPOL(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function pakTCPOLSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String, ByVal SerialNo As Int32) As Integer
      Return _RecordCount
    End Function
      'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function pakTCPOLGetByID(ByVal SerialNo As Int32, ByVal ItemNo As Int32, ByVal Filter_SerialNo As Int32) As SIS.PAK.pakTCPOL
      Return pakTCPOLGetByID(SerialNo, ItemNo)
    End Function
    <DataObjectMethod(DataObjectMethodType.Insert, True)> _
    Public Shared Function pakTCPOLInsert(ByVal Record As SIS.PAK.pakTCPOL) As SIS.PAK.pakTCPOL
      Dim _Rec As SIS.PAK.pakTCPOL = SIS.PAK.pakTCPOL.pakTCPOLGetNewRecord()
      With _Rec
        .ItemNo = Record.ItemNo
        .ItemCode = Record.ItemCode
        .ItemDescription = Record.ItemDescription
        .ItemQuantity = Record.ItemQuantity
        .ItemElement = Record.ItemElement
        .ItemStatusID = Record.ItemStatusID
        .SerialNo = Record.SerialNo
        .ItemUnit = Record.ItemUnit
        .ItemPrice = Record.ItemPrice
        .ItemAmount = Record.ItemAmount
      End With
      Return SIS.PAK.pakTCPOL.InsertData(_Rec)
    End Function
    Public Shared Function InsertData(ByVal Record As SIS.PAK.pakTCPOL) As SIS.PAK.pakTCPOL
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppakTCPOLInsert"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ItemNo",SqlDbType.Int,11, Record.ItemNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ItemCode",SqlDbType.NVarChar,48, Iif(Record.ItemCode= "" ,Convert.DBNull, Record.ItemCode))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ItemDescription",SqlDbType.NVarChar,101, Iif(Record.ItemDescription= "" ,Convert.DBNull, Record.ItemDescription))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ItemQuantity",SqlDbType.Decimal,21, Iif(Record.ItemQuantity= "" ,Convert.DBNull, Record.ItemQuantity))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ItemElement",SqlDbType.NVarChar,9, Iif(Record.ItemElement= "" ,Convert.DBNull, Record.ItemElement))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ItemStatusID",SqlDbType.Int,11, Iif(Record.ItemStatusID= "" ,Convert.DBNull, Record.ItemStatusID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SerialNo",SqlDbType.Int,11, Record.SerialNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ItemUnit",SqlDbType.NVarChar,4, Iif(Record.ItemUnit= "" ,Convert.DBNull, Record.ItemUnit))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ItemPrice",SqlDbType.Decimal,22, Iif(Record.ItemPrice= "" ,Convert.DBNull, Record.ItemPrice))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ItemAmount",SqlDbType.Decimal,22, Iif(Record.ItemAmount= "" ,Convert.DBNull, Record.ItemAmount))
          Cmd.Parameters.Add("@Return_SerialNo", SqlDbType.Int, 11)
          Cmd.Parameters("@Return_SerialNo").Direction = ParameterDirection.Output
          Cmd.Parameters.Add("@Return_ItemNo", SqlDbType.Int, 11)
          Cmd.Parameters("@Return_ItemNo").Direction = ParameterDirection.Output
          Con.Open()
          Cmd.ExecuteNonQuery()
          Record.SerialNo = Cmd.Parameters("@Return_SerialNo").Value
          Record.ItemNo = Cmd.Parameters("@Return_ItemNo").Value
        End Using
      End Using
      Return Record
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)> _
    Public Shared Function pakTCPOLUpdate(ByVal Record As SIS.PAK.pakTCPOL) As SIS.PAK.pakTCPOL
      Dim _Rec As SIS.PAK.pakTCPOL = SIS.PAK.pakTCPOL.pakTCPOLGetByID(Record.SerialNo, Record.ItemNo)
      With _Rec
        .ItemCode = Record.ItemCode
        .ItemDescription = Record.ItemDescription
        .ItemQuantity = Record.ItemQuantity
        .ItemElement = Record.ItemElement
        .ItemStatusID = Record.ItemStatusID
        .ItemUnit = Record.ItemUnit
        .ItemPrice = Record.ItemPrice
        .ItemAmount = Record.ItemAmount
      End With
      Return SIS.PAK.pakTCPOL.UpdateData(_Rec)
    End Function
    Public Shared Function UpdateData(ByVal Record As SIS.PAK.pakTCPOL) As SIS.PAK.pakTCPOL
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppakTCPOLUpdate"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_ItemNo",SqlDbType.Int,11, Record.ItemNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_SerialNo",SqlDbType.Int,11, Record.SerialNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ItemNo",SqlDbType.Int,11, Record.ItemNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ItemCode",SqlDbType.NVarChar,48, Iif(Record.ItemCode= "" ,Convert.DBNull, Record.ItemCode))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ItemDescription",SqlDbType.NVarChar,101, Iif(Record.ItemDescription= "" ,Convert.DBNull, Record.ItemDescription))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ItemQuantity",SqlDbType.Decimal,21, Iif(Record.ItemQuantity= "" ,Convert.DBNull, Record.ItemQuantity))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ItemElement",SqlDbType.NVarChar,9, Iif(Record.ItemElement= "" ,Convert.DBNull, Record.ItemElement))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ItemStatusID",SqlDbType.Int,11, Iif(Record.ItemStatusID= "" ,Convert.DBNull, Record.ItemStatusID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SerialNo",SqlDbType.Int,11, Record.SerialNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ItemUnit",SqlDbType.NVarChar,4, Iif(Record.ItemUnit= "" ,Convert.DBNull, Record.ItemUnit))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ItemPrice",SqlDbType.Decimal,22, Iif(Record.ItemPrice= "" ,Convert.DBNull, Record.ItemPrice))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ItemAmount",SqlDbType.Decimal,22, Iif(Record.ItemAmount= "" ,Convert.DBNull, Record.ItemAmount))
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
    Public Shared Function pakTCPOLDelete(ByVal Record As SIS.PAK.pakTCPOL) As Int32
      Dim _Result as Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppakTCPOLDelete"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_SerialNo",SqlDbType.Int,Record.SerialNo.ToString.Length, Record.SerialNo)
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
    Public Shared Function SelectpakTCPOLAutoCompleteList(ByVal Prefix As String, ByVal count As Integer, ByVal contextKey As String) As String()
      Dim Results As List(Of String) = Nothing
      Dim aVal() As String = contextKey.Split("|".ToCharArray)
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppakTCPOLAutoCompleteList"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@prefix", SqlDbType.NVarChar, 50, Prefix)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@records", SqlDbType.Int, -1, count)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@bycode", SqlDbType.Int, 1, IIf(IsNumeric(Prefix),0,IIf(Prefix.ToLower=Prefix, 0, 1)))
          Results = New List(Of String)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Not Reader.HasRows Then
            Results.Add(AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem("---Select Value---".PadRight(47, " "),"" & "|" & ""))
          End If
          While (Reader.Read())
            Dim Tmp As SIS.PAK.pakTCPOL = New SIS.PAK.pakTCPOL(Reader)
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
