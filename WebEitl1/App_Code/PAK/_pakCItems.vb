Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.PAK
  <DataObject()> _
  Partial Public Class pakCItems
    Inherits SIS.PAK.pakItems
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function pakCItemsGetNewRecord() As SIS.PAK.pakCItems
      Return New SIS.PAK.pakCItems()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function pakCItemsSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal RootItem As Int32) As List(Of SIS.PAK.pakCItems)
      Dim Results As List(Of SIS.PAK.pakCItems) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "sppakCItemsSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "sppakCItemsSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_RootItem",SqlDbType.Int,10, IIf(RootItem = Nothing, 0,RootItem))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
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
    Public Shared Function pakCItemsSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String, ByVal RootItem As Int32) As Integer
      Return RecordCount
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function pakCItemsGetByID(ByVal RootItem As Int32, ByVal ItemNo As Int32) As SIS.PAK.pakCItems
      Dim Results As SIS.PAK.pakCItems = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppakItemsSelectByID"
          'SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@RootItem",SqlDbType.Int,RootItem.ToString.Length, RootItem)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ItemNo",SqlDbType.Int,ItemNo.ToString.Length, ItemNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
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
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function pakCItemsGetByID(ByVal RootItem As Int32, ByVal ItemNo As Int32, ByVal Filter_RootItem As Int32) As SIS.PAK.pakCItems
      Dim Results As SIS.PAK.pakCItems = SIS.PAK.pakCItems.UZ_pakCItemsGetByID(RootItem, ItemNo)
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Insert, True)> _
    Public Shared Function pakCItemsInsert(ByVal Record As SIS.PAK.pakCItems) As SIS.PAK.pakCItems
      Dim _Rec As SIS.PAK.pakCItems = SIS.PAK.pakCItems.pakCItemsGetNewRecord()
      With _Rec
        .ItemCode = Record.ItemCode
        .ItemDescription = Record.ItemDescription
        .ElementID = Record.ElementID
        .Quantity = Record.Quantity
        .UOMWeight = Record.UOMWeight
        .ParentItemNo = Record.ParentItemNo
        .Free = Record.Free
        .DivisionID =  Global.System.Web.HttpContext.Current.Session("DivisionID")
        .Prefix = Record.Prefix
        .Middle = Record.Middle
        .ItemLevel = Record.ItemLevel
        .Active = Record.Active
        .WeightPerUnit = Record.WeightPerUnit
        .UOMQuantity = Record.UOMQuantity
        .RootItem = Record.RootItem
        .Root = Record.Root
        .Bottom = Record.Bottom
        .DocumentNo = Record.DocumentNo
      End With
      _Rec = SIS.PAK.pakCItems.InsertData(_Rec)
      Dim tmpP As SIS.PAK.pakCItems = SIS.PAK.pakCItems.pakCItemsGetByID(_Rec.ParentItemNo, _Rec.ParentItemNo)
      If tmpP IsNot Nothing Then
        If Not tmpP.Root Then
          tmpP.Middle = True
          tmpP.Bottom = False
          tmpP = UpdateData(tmpP)
        End If
      End If
      Return _Rec
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)> _
    Public Shared Function pakCItemsUpdate(ByVal Record As SIS.PAK.pakCItems) As SIS.PAK.pakCItems
      Dim _Rec As SIS.PAK.pakCItems = SIS.PAK.pakCItems.UZ_pakCItemsGetByID(Record.RootItem, Record.ItemNo)
      Dim ParentChanged As Boolean = IIf(_Rec.ParentItemNo = Record.ParentItemNo, False, True)
      If ParentChanged Then
        Dim tmpP As SIS.PAK.pakCItems = SIS.PAK.pakCItems.pakCItemsGetByID(_Rec.ParentItemNo, _Rec.ParentItemNo)
        If tmpP IsNot Nothing Then
          If Not tmpP.Root Then
            Dim tmpPs As List(Of SIS.PAK.pakCItems) = SIS.PAK.pakCItems.GetByParentCItemNo(_Rec.ParentItemNo, "")
            If tmpPs.Count <= 1 Then
              tmpP.Middle = False
              tmpP.Bottom = True
              tmpP = UpdateData(tmpP)
            End If
          End If
        End If
      End If
      With _Rec
        .ItemCode = Record.ItemCode
        .ItemDescription = Record.ItemDescription
        .ElementID = Record.ElementID
        .Quantity = Record.Quantity
        .UOMWeight = Record.UOMWeight
        .ParentItemNo = Record.ParentItemNo
        .Free = Record.Free
        .DivisionID = Global.System.Web.HttpContext.Current.Session("DivisionID")
        .Prefix = Record.Prefix
        .Middle = Record.Middle
        .ItemLevel = Record.ItemLevel
        .Active = Record.Active
        .WeightPerUnit = Record.WeightPerUnit
        .UOMQuantity = Record.UOMQuantity
        .Root = Record.Root
        .Bottom = Record.Bottom
        .DocumentNo = Record.DocumentNo
      End With
      _Rec = SIS.PAK.pakCItems.UpdateData(_Rec)
      If ParentChanged Then
        Dim tmpP As SIS.PAK.pakCItems = SIS.PAK.pakCItems.pakCItemsGetByID(Record.ParentItemNo, Record.ParentItemNo)
        If tmpP IsNot Nothing Then
          If Not tmpP.Root Then
            tmpP.Middle = True
            tmpP.Bottom = False
            tmpP = UpdateData(tmpP)
          End If
        End If
      End If
      Return _Rec
    End Function
    Public Sub New(ByVal Reader As SqlDataReader)
      MyBase.New(Reader)
    End Sub
    Public Sub New()
    End Sub
  End Class
End Namespace
