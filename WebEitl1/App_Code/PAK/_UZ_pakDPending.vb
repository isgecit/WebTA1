Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.PAK
  Partial Public Class pakDPending
    Public Shadows Function GetEditable() As Boolean
      Dim mRet As Boolean = False
      Return mRet
    End Function
    Public Shadows Function GetDeleteable() As Boolean
      Dim mRet As Boolean = False
      Return mRet
    End Function
    Public Shadows ReadOnly Property Editable() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetEditable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public Shadows ReadOnly Property Deleteable() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetDeleteable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public Shared Function UZ_pakDPendingSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal PkgNo As Int32, ByVal SerialNo As Int32) As List(Of SIS.PAK.pakDPending)
      Dim Results As List(Of SIS.PAK.pakDPending) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "sppak_LG_DPendingSelectListSearch"
            Cmd.CommandText = "sppakDPendingSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "sppak_LG_DPendingSelectListFilteres"
            Cmd.CommandText = "sppakDPendingSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_PkgNo",SqlDbType.Int,10, IIf(PkgNo = Nothing, 0,PkgNo))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_SerialNo",SqlDbType.Int,10, IIf(SerialNo = Nothing, 0,SerialNo))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          RecordCount = -1
          Results = New List(Of SIS.PAK.pakDPending)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.PAK.pakDPending(Reader))
          End While
          Reader.Close()
          RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function UZ_pakDPendingUpdate(ByVal Record As SIS.PAK.pakDPending) As SIS.PAK.pakDPending
      Dim _Result As SIS.PAK.pakDPending = pakDPendingUpdate(Record)
      Return _Result
    End Function
    Public Shared Function GetSitePkgD(ByVal tmpRecD As SIS.PAK.pakDPending) As SIS.PAK.pakSitePkgD
      Dim tmp As New SIS.PAK.pakSitePkgD
      With tmp
        .ProjectID = tmpRecD.FK_PAK_PkgListD_SerialNo.ProjectID
        .RecNo = 0 'Will be assigned from Header after return
        .RecSrNo = 0
        .SerialNo = tmpRecD.SerialNo
        .PkgNo = tmpRecD.PkgNo
        .BOMNo = tmpRecD.BOMNo
        .ItemNo = tmpRecD.ItemNo
        .SiteMarkNo = tmpRecD.ItemNo
        .UOMQuantity = tmpRecD.UOMQuantity
        .Quantity = tmpRecD.Quantity
        '.DocumentNo = tmpRecD.DocumentNo
        '.DocumentRevision = tmpRecD.DocumentRevision
        .PackTypeID = tmpRecD.PackTypeID
        .PackWidth = tmpRecD.PackWidth
        .PackHeight = tmpRecD.PackHeight
        .PackingMark = tmpRecD.PackingMark
        .PackLength = tmpRecD.PackLength
        .UOMPack = tmpRecD.UOMPack
        .Remarks = tmpRecD.Remarks
        .MaterialStatusID = 1
        .OnlyPackageReceived = False
        .InventoryStatusID = siteInventoryStates.Free
        .DocumentReceived = True
        .NotFromPackingList = False
        .InventoryUpdatedOn = Now
        .InventoryUpdatedBy = HttpContext.Current.Session("LoginID")
      End With
      Return tmp
    End Function

  End Class
End Namespace
