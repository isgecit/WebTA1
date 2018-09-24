Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.PAK
  Partial Public Class pakSitePkgD
    Public Function GetColor() As System.Drawing.Color
      Dim mRet As System.Drawing.Color = Drawing.Color.Black
      Select Case InventoryStatusID
        Case siteInventoryStates.PackagePending
          mRet = Drawing.Color.Red
        Case siteInventoryStates.Received
          mRet = Drawing.Color.Goldenrod
        Case siteInventoryStates.Closed
          mRet = Drawing.Color.Green
      End Select
      Return mRet
    End Function
    Public Function GetVisible() As Boolean
      Dim mRet As Boolean = True
      Return mRet
    End Function
    Public Function GetEnable() As Boolean
      Dim mRet As Boolean = True
      Return mRet
    End Function
    Public Function GetEditable() As Boolean
      Dim mRet As Boolean = False
      Select Case InventoryStatusID
        Case siteInventoryStates.Free, siteInventoryStates.PackagePending, siteInventoryStates.Received
          mRet = True
      End Select
      Return mRet
    End Function
    Public Function GetDeleteable() As Boolean
      Dim mRet As Boolean = False
      Return mRet
    End Function
    Public ReadOnly Property Editable() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetEditable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property Deleteable() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetDeleteable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property InitiateWFVisible() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          If InventoryStatusID = siteInventoryStates.Closed Then
            mRet = False
          ElseIf InventoryStatusID = siteInventoryStates.PackagePending Then
            mRet = False
          End If
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property InitiateWFEnable() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetEnable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property ApproveWFVisible() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          If InventoryStatusID = siteInventoryStates.Closed Then
            mRet = False
          ElseIf InventoryStatusID = siteInventoryStates.Received Then
            mRet = False
          End If
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property ApproveWFEnable() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetEnable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public Shared Function InitiateWF(ByVal ProjectID As String, ByVal RecNo As Int32, ByVal RecSrNo As Int32, ByVal Quantity As Decimal, ByVal LocationID As String) As SIS.PAK.pakSitePkgD
      Dim Results As SIS.PAK.pakSitePkgD = pakSitePkgDGetByID(ProjectID, RecNo, RecSrNo)
      Dim PackingMark As String = Results.PackingMark
      If PackingMark <> String.Empty Then
        Dim tmpPkgD As List(Of SIS.PAK.pakSitePkgD) = SIS.PAK.pakSitePkgD.GetByPackingMark(ProjectID, RecNo, PackingMark)
        For Each tmp As SIS.PAK.pakSitePkgD In tmpPkgD
          tmp.OnlyPackageReceived = True
          tmp.InventoryStatusID = siteInventoryStates.PackagePending
          tmp.InventoryUpdatedBy = HttpContext.Current.Session("LoginID")
          tmp.InventoryUpdatedOn = Now
          tmp = SIS.PAK.pakSitePkgD.UpdateData(tmp)
        Next
      End If
      Return Results
    End Function
    Public Shared Function ApproveWF(ByVal ProjectID As String, ByVal RecNo As Int32, ByVal RecSrNo As Int32, ByVal Quantity As Decimal, ByVal LocationID As Integer) As SIS.PAK.pakSitePkgD
      Dim Results As SIS.PAK.pakSitePkgD = pakSitePkgDGetByID(ProjectID, RecNo, RecSrNo)
      With Results
        .OnlyPackageReceived = False
        .InventoryStatusID = siteInventoryStates.Received
        .Quantity = Quantity
        .InventoryUpdatedBy = HttpContext.Current.Session("LoginID")
        .InventoryUpdatedOn = Now
      End With
      Results = SIS.PAK.pakSitePkgD.UpdateData(Results)
      Dim tmpLs As List(Of SIS.PAK.pakSitePkgDLocation) = SIS.PAK.pakSitePkgDLocation.UZ_pakSitePkgDLocationSelectList(0, 99999, "", False, "", RecSrNo, RecNo, ProjectID)
      For Each tmp As SIS.PAK.pakSitePkgDLocation In tmpLs
        If Not tmp.Support Then
          tmp.LocationID = LocationID
          tmp = SIS.PAK.pakSitePkgDLocation.UpdateData(tmp)
        End If
      Next
      Return Results
    End Function
    Public Shared Function UZ_pakSitePkgDSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal RecNo As Int32, ByVal ProjectID As String) As List(Of SIS.PAK.pakSitePkgD)
      Dim Results As List(Of SIS.PAK.pakSitePkgD) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "sppak_LG_SitePkgDSelectListSearch"
            Cmd.CommandText = "sppakSitePkgDSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "sppak_LG_SitePkgDSelectListFilteres"
            Cmd.CommandText = "sppakSitePkgDSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_RecNo",SqlDbType.Int,10, IIf(RecNo = Nothing, 0,RecNo))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_ProjectID",SqlDbType.NVarChar,6, IIf(ProjectID Is Nothing, String.Empty,ProjectID))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.PAK.pakSitePkgD)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.PAK.pakSitePkgD(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function UZ_pakSitePkgDInsert(ByVal Record As SIS.PAK.pakSitePkgD) As SIS.PAK.pakSitePkgD
      Dim _Result As SIS.PAK.pakSitePkgD = pakSitePkgDInsert(Record)
      Return _Result
    End Function
    Public Shared Function UZ_pakSitePkgDUpdate(ByVal Record As SIS.PAK.pakSitePkgD) As SIS.PAK.pakSitePkgD
      Dim _Result As SIS.PAK.pakSitePkgD = pakSitePkgDUpdate(Record)
      Return _Result
    End Function
    Public Shared Function UZ_pakSitePkgDDelete(ByVal Record As SIS.PAK.pakSitePkgD) As Integer
      Dim _Result as Integer = pakSitePkgDDelete(Record)
      Return _Result
    End Function
    Public Shared Function SetDefaultValues(ByVal sender As System.Web.UI.WebControls.FormView, ByVal e As System.EventArgs) As System.Web.UI.WebControls.FormView
      With sender
        Try
          CType(.FindControl("F_RecSrNo"), TextBox).Text = ""
          CType(.FindControl("F_ItemNo"), TextBox).Text = ""
          CType(.FindControl("F_ItemNo_Display"), Label).Text = ""
          CType(.FindControl("F_SiteMarkNo"), TextBox).Text = ""
          CType(.FindControl("F_SiteMarkNo_Display"), Label).Text = ""
          CType(.FindControl("F_UOMQuantity"), TextBox).Text = ""
          CType(.FindControl("F_UOMQuantity_Display"), Label).Text = ""
          CType(.FindControl("F_Quantity"), TextBox).Text = 0
          CType(.FindControl("F_PackTypeID"), TextBox).Text = ""
          CType(.FindControl("F_PackTypeID_Display"), Label).Text = ""
          CType(.FindControl("F_OnlyPackageReceived"), CheckBox).Checked = False
          CType(.FindControl("F_Remarks"), TextBox).Text = ""
          CType(.FindControl("F_DocumentReceived"), CheckBox).Checked = False
          CType(.FindControl("F_PackHeight"), TextBox).Text = 0
          CType(.FindControl("F_UOMPack"), TextBox).Text = ""
          CType(.FindControl("F_UOMPack_Display"), Label).Text = ""
          CType(.FindControl("F_NotFromPackingList"), CheckBox).Checked = False
          CType(.FindControl("F_MaterialStatusID"), Object).SelectedValue = ""
          CType(.FindControl("F_BOMNo"), TextBox).Text = ""
          CType(.FindControl("F_BOMNo_Display"), Label).Text = ""
          CType(.FindControl("F_DocumentNo"), TextBox).Text = ""
          CType(.FindControl("F_DocumentNo_Display"), Label).Text = ""
          CType(.FindControl("F_PkgNo"), TextBox).Text = ""
          CType(.FindControl("F_PkgNo_Display"), Label).Text = ""
          CType(.FindControl("F_RecNo"), TextBox).Text = ""
          CType(.FindControl("F_RecNo_Display"), Label).Text = ""
          CType(.FindControl("F_SerialNo"), TextBox).Text = ""
          CType(.FindControl("F_SerialNo_Display"), Label).Text = ""
          CType(.FindControl("F_PackLength"), TextBox).Text = 0
          CType(.FindControl("F_PackWidth"), TextBox).Text = 0
          CType(.FindControl("F_PackingMark"), TextBox).Text = ""
          CType(.FindControl("F_DocumentRevision"), TextBox).Text = ""
          CType(.FindControl("F_ProjectID"), TextBox).Text = ""
          CType(.FindControl("F_ProjectID_Display"), Label).Text = ""
        Catch ex As Exception
        End Try
      End With
      Return sender
    End Function
    Public Shared Function GetSitePkgDLocation(ByVal tmpRecD As SIS.PAK.pakSitePkgD) As SIS.PAK.pakSitePkgDLocation
      Dim tmp As New SIS.PAK.pakSitePkgDLocation
      With tmp
        .ProjectID = tmpRecD.ProjectID
        .RecNo = tmpRecD.RecNo
        .RecSrNo = tmpRecD.RecSrNo
        .RecSrLNo = 0
        .SerialNo = tmpRecD.SerialNo
        .PkgNo = tmpRecD.PkgNo
        .BOMNo = tmpRecD.BOMNo
        .ItemNo = tmpRecD.ItemNo
        .SiteMarkNo = tmpRecD.SiteMarkNo
        .UOMQuantity = tmpRecD.UOMQuantity
        .Quantity = tmpRecD.Quantity
        .Support = False
        .LocationID = ""
        .Remarks = ""
      End With
      Return tmp
    End Function
    Public Shared Function GetByPackingMark(ByVal ProjectID As String, ByVal RecNo As Int32, ByVal PackingMark As String) As List(Of SIS.PAK.pakSitePkgD)
      Dim Results As List(Of SIS.PAK.pakSitePkgD) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppak_LG_SitePkgDGetByPackingMark"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_RecNo", SqlDbType.Int, 10, IIf(RecNo = Nothing, 0, RecNo))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_ProjectID", SqlDbType.NVarChar, 6, IIf(ProjectID Is Nothing, String.Empty, ProjectID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PackingMark", SqlDbType.NVarChar, 50, PackingMark)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.PAK.pakSitePkgD)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.PAK.pakSitePkgD(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
  End Class
End Namespace
