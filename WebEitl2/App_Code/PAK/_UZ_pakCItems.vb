Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.PAK
  Partial Public Class pakCItems
    Public ReadOnly Property DeleteWFVisible() As Boolean
      Get
        Dim mRet As Boolean = False
        Try
          If Not Root Then
            mRet = True
          End If
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property DeleteWFEnable() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetEnable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public Shared Function DeleteWF(ByVal RootItem As Int32, ByVal ItemNo As Int32) As SIS.PAK.pakCItems
      Dim Results As SIS.PAK.pakCItems = pakCItemsGetByID(ItemNo, ItemNo)
      rDeleteWF(Results)
      Dim tmpP As SIS.PAK.pakCItems = SIS.PAK.pakCItems.pakCItemsGetByID(Results.ParentItemNo, Results.ParentItemNo)
      If tmpP IsNot Nothing Then
        If Not tmpP.Root Then
          Dim tmpPs As List(Of SIS.PAK.pakCItems) = SIS.PAK.pakCItems.GetByParentCItemNo(Results.ParentItemNo, "")
          If tmpPs.Count <= 0 Then
            tmpP.Middle = False
            tmpP.Bottom = True
            tmpP = UpdateData(tmpP)
          End If
        End If
      End If
      Return Results
    End Function
    Private Shared Sub rDeleteWF(ByVal pItm As SIS.PAK.pakCItems)
      Dim Items As List(Of SIS.PAK.pakCItems) = SIS.PAK.pakCItems.GetByParentCItemNo(pItm.ItemNo, "")
      If Items.Count > 0 Then
        For Each Itm As SIS.PAK.pakCItems In Items
          rDeleteWF(Itm)
        Next
        SIS.PAK.pakCItems.pakItemsDelete(pItm)
      Else
        SIS.PAK.pakCItems.pakItemsDelete(pItm)
      End If
    End Sub
    Private Shared Sub getpakHCItems(ByVal pItem As SIS.PAK.pakCItems, ByRef cList As List(Of SIS.PAK.pakCItems))
      cList.Add(pItem)
      Dim Results As List(Of SIS.PAK.pakCItems) = SIS.PAK.pakCItems.GetByParentCItemNo(pItem.ItemNo, "")
      For Each tmp As SIS.PAK.pakCItems In Results
        getpakHCItems(tmp, cList)
      Next
    End Sub
    Public Shared Function UZ_pakHCItemsSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal RootItem As Int32) As List(Of SIS.PAK.pakCItems)
      Dim Results As New List(Of SIS.PAK.pakCItems)
      Dim rItm As SIS.PAK.pakCItems = SIS.PAK.pakCItems.pakCItemsGetByID(RootItem, RootItem)
      getpakHCItems(rItm, Results)
      RecordCount = Results.Count
      Return Results
    End Function

    Public Shared Function UZ_pakCItemsSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal RootItem As Int32) As List(Of SIS.PAK.pakCItems)
      Dim Results As List(Of SIS.PAK.pakCItems) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "sppak_LG_CItemsSelectListSearch"
            Cmd.CommandText = "sppakCItemsSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "sppak_LG_CItemsSelectListFilteres"
            Cmd.CommandText = "sppakCItemsSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_RootItem", SqlDbType.Int, 10, IIf(RootItem = Nothing, 0, RootItem))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          RecordCount = -1
          Results = New List(Of SIS.PAK.pakCItems)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.PAK.pakCItems(Reader))
          End While
          Reader.Close()
          RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Shadows Function GetByParentItemNo(ByVal ParentItemNo As Int32, ByVal OrderBy As String) As List(Of SIS.PAK.pakItems)
      Dim Results As List(Of SIS.PAK.pakItems) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppakItemsSelectByParentItemNo"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ParentItemNo", SqlDbType.Int, ParentItemNo.ToString.Length, ParentItemNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DivisionID", SqlDbType.Int, 10, Global.System.Web.HttpContext.Current.Session("DivisionID"))
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          RecordCount = -1
          Results = New List(Of SIS.PAK.pakItems)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.PAK.pakItems(Reader))
          End While
          Reader.Close()
          RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function GetByParentCItemNo(ByVal ParentItemNo As Int32, ByVal OrderBy As String) As List(Of SIS.PAK.pakCItems)
      Dim Results As List(Of SIS.PAK.pakCItems) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppakItemsSelectByParentItemNo"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ParentItemNo", SqlDbType.Int, ParentItemNo.ToString.Length, ParentItemNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DivisionID", SqlDbType.Int, 10, Global.System.Web.HttpContext.Current.Session("DivisionID"))
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          RecordCount = -1
          Results = New List(Of SIS.PAK.pakCItems)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.PAK.pakCItems(Reader))
          End While
          Reader.Close()
          RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Private Shared Function CyclicK(ByVal Item As String, ByVal PItem As String, ByRef Lvl As Integer) As Boolean
      If PItem = String.Empty Then Return False
      If Item = PItem Then
        Throw New Exception("Can NOT assign Cyclick Parent Child Relation.")
        Return True
      End If
      Lvl += 1
      Return CyclicK(Item, SIS.PAK.pakItems.pakItemsGetByID(PItem).ParentItemNo, Lvl)
    End Function
    Public Shared Function UZ_pakCItemsInsert(ByVal Record As SIS.PAK.pakCItems) As SIS.PAK.pakCItems
      Record = pakCItemsInsert(Record)
      With Record
        .Root = False
        .Bottom = False
        .Middle = False
        .Free = False
        .ItemLevel = 0
        .Prefix = ""
        If .ParentItemNo <> String.Empty Then
          If Not CyclicK(.ItemNo, .ParentItemNo, .ItemLevel) Then
            .Prefix = .Prefix.PadLeft(.ItemLevel, Chr(187))
            .Bottom = True
          End If
        End If
      End With
      Record = pakCItemsUpdate(Record)
      Return Record
    End Function
    Public Shared Function UZ_pakCItemsUpdate(ByVal Record As SIS.PAK.pakCItems) As SIS.PAK.pakCItems
      With Record
        .Root = False
        .Bottom = False
        .Middle = False
        .Free = False
        .ItemLevel = 0
        .Prefix = ""
        If .ParentItemNo <> String.Empty Then
          If Not CyclicK(.ItemNo, .ParentItemNo, .ItemLevel) Then
            .Prefix = .Prefix.PadLeft(.ItemLevel, Chr(187))
            Dim oPIs As List(Of SIS.PAK.pakItems) = SIS.PAK.pakItems.GetByParentItemNo(.ItemNo, "")
            If oPIs.Count > 0 Then
              .Middle = True
            Else
              .Bottom = True
            End If
          End If
        End If
      End With
      Record = pakCItemsUpdate(Record)
      Return Record
    End Function
    Public Shared Function UZ_pakCItemsDelete(ByVal Record As SIS.PAK.pakCItems) As Int32
      Dim _Result As Integer = pakItemsDelete(Record)
      Return _Result
    End Function
    Public Shared Function UZ_pakCItemsGetByID(ByVal RootItem As Int32, ByVal ItemNo As Int32) As SIS.PAK.pakCItems
      Dim Results As SIS.PAK.pakCItems = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppakItemsSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ItemNo", SqlDbType.Int, ItemNo.ToString.Length, ItemNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.PAK.pakCItems(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    'Select By ID One Record Filtered Overloaded GetByID
    Public Shared Function UZ_pakCItemsGetByID(ByVal RootItem As Int32, ByVal ItemNo As Int32, ByVal Filter_RootItem As Int32) As SIS.PAK.pakCItems
      Return UZ_pakCItemsGetByID(RootItem, ItemNo)
    End Function
    Public Shared Function SelectpakCItemsAutoCompleteList(ByVal Prefix As String, ByVal count As Integer, ByVal contextKey As String) As String()
      Dim Results As List(Of String) = Nothing
      Dim aVal() As String = contextKey.Split("|".ToCharArray)
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppak_LG_CItemsAutoCompleteList"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DivisionID", SqlDbType.Int, 10, Global.System.Web.HttpContext.Current.Session("DivisionID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@prefix", SqlDbType.NVarChar, 50, Prefix)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@records", SqlDbType.Int, -1, count)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@bycode", SqlDbType.Int, 1, IIf(IsNumeric(Prefix), 0, 1))
          Results = New List(Of String)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Not Reader.HasRows Then
            Results.Add(AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem("---Select Value---".PadRight(100, " "), ""))
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
    Public Shared Function pakcItemsGetByDescription(ByVal ItemDescription As String) As SIS.PAK.pakCItems
      Dim Results As SIS.PAK.pakCItems = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppak_LG_ItemsSelectByDescription"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ItemDescription", SqlDbType.NVarChar, ItemDescription.ToString.Length, ItemDescription)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.PAK.pakCItems(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
  End Class
End Namespace
