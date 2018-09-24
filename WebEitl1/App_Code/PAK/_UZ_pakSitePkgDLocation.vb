Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.PAK
  Partial Public Class pakSitePkgDLocation
    Public Function GetColor() As System.Drawing.Color
      Dim mRet As System.Drawing.Color = Drawing.Color.Black
      If Support Then
        mRet = Drawing.Color.Red
      End If
      Return mRet
    End Function
    Public Function GetVisible() As Boolean
      Dim mRet As Boolean = True
      Return mRet
    End Function
    Public Function GetEnable() As Boolean
      Dim mRet As Boolean = True
      If Support Then
        mRet = False
      End If
      Return mRet
    End Function
    Public Function GetEditable() As Boolean
      Dim mRet As Boolean = True
      If Support Then
        mRet = False
      Else
        If FK_PAK_SitePkgDLocation_RecSrNo.InventoryStatusID = siteInventoryStates.Closed Then
          mRet = False
        End If
      End If
      Return mRet
    End Function
    Public Function GetDeleteable() As Boolean
      Dim mRet As Boolean = True
      If Support Then
        mRet = False
      Else
        If FK_PAK_SitePkgDLocation_RecSrNo.InventoryStatusID = siteInventoryStates.Closed Then
          mRet = False
        End If
      End If
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
    Public ReadOnly Property ApproveWFVisible() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          If Support Then
            mRet = False
          Else
            If FK_PAK_SitePkgDLocation_RecSrNo.InventoryStatusID = siteInventoryStates.Closed Then
              mRet = False
            End If
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
    Public Shared Function ApproveWF(ByVal ProjectID As String, ByVal RecNo As Int32, ByVal RecSrNo As Int32, ByVal RecSrLNo As Int32, ByVal Quantity As Decimal, ByVal LocationID As Int32) As SIS.PAK.pakSitePkgDLocation
      Dim Results As SIS.PAK.pakSitePkgDLocation = pakSitePkgDLocationGetByID(ProjectID, RecNo, RecSrNo, RecSrLNo)
      'Check Quantity
      Dim tmpS As List(Of SIS.PAK.pakSitePkgDLocation) = SIS.PAK.pakSitePkgDLocation.UZ_pakSitePkgDLocationSelectList(0, 99999, "", False, "", RecSrNo, RecNo, ProjectID)
      Dim tmpQty As Decimal = 0
      For Each tmp As SIS.PAK.pakSitePkgDLocation In tmpS
        If Not tmp.Support Then
          If tmp.RecSrLNo = Results.RecSrLNo Then
            tmpQty += Quantity
          Else
            tmpQty += tmp.Quantity
          End If
        End If
      Next
      Dim tmpPkgD As SIS.PAK.pakSitePkgD = Results.FK_PAK_SitePkgDLocation_RecSrNo
      If tmpPkgD.Quantity < tmpQty Then
        Throw New Exception("Location wise distributed quantity is greater than received quantity.")
      End If
      Results.Quantity = Quantity
      Results.LocationID = LocationID
      Results = SIS.PAK.pakSitePkgDLocation.UpdateData(Results)
      'Update Item Status to Received
      tmpPkgD.InventoryStatusID = siteInventoryStates.Received
      SIS.PAK.pakSitePkgD.UpdateData(tmpPkgD)
      Return Results
    End Function
    Public Shared Function UZ_pakSitePkgDLocationSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal RecSrNo As Int32, ByVal RecNo As Int32, ByVal ProjectID As String) As List(Of SIS.PAK.pakSitePkgDLocation)
      Dim Results As List(Of SIS.PAK.pakSitePkgDLocation) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "sppak_LG_SitePkgDLocationSelectListSearch"
            Cmd.CommandText = "sppakSitePkgDLocationSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "sppak_LG_SitePkgDLocationSelectListFilteres"
            Cmd.CommandText = "sppakSitePkgDLocationSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_RecSrNo",SqlDbType.Int,10, IIf(RecSrNo = Nothing, 0,RecSrNo))
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
          Results = New List(Of SIS.PAK.pakSitePkgDLocation)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.PAK.pakSitePkgDLocation(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function UZ_pakSitePkgDLocationInsert(ByVal Record As SIS.PAK.pakSitePkgDLocation) As SIS.PAK.pakSitePkgDLocation
      'Check Quantity
      Dim tmpS As List(Of SIS.PAK.pakSitePkgDLocation) = SIS.PAK.pakSitePkgDLocation.UZ_pakSitePkgDLocationSelectList(0, 99999, "", False, "", Record.RecSrNo, Record.RecNo, Record.ProjectID)
      Dim tmpQty As Decimal = 0
      For Each tmp As SIS.PAK.pakSitePkgDLocation In tmpS
        If Not tmp.Support Then
          tmpQty += tmp.Quantity
        End If
      Next
      tmpQty += Record.Quantity
      Dim tmpPkgD As SIS.PAK.pakSitePkgD = Record.FK_PAK_SitePkgDLocation_RecSrNo
      If tmpPkgD.Quantity < tmpQty Then
        Throw New Exception("Location wise distributed quantity is greater than received quantity.")
      End If
      Record = pakSitePkgDLocationInsert(Record)
      'Update Item Status to Received
      tmpPkgD.InventoryStatusID = siteInventoryStates.Received
      SIS.PAK.pakSitePkgD.UpdateData(tmpPkgD)
      Return Record
    End Function
    Public Shared Function UZ_pakSitePkgDLocationUpdate(ByVal Record As SIS.PAK.pakSitePkgDLocation) As SIS.PAK.pakSitePkgDLocation
      'Check Quantity
      Dim tmpS As List(Of SIS.PAK.pakSitePkgDLocation) = SIS.PAK.pakSitePkgDLocation.UZ_pakSitePkgDLocationSelectList(0, 99999, "", False, "", Record.RecSrNo, Record.RecNo, Record.ProjectID)
      Dim tmpQty As Decimal = 0
      For Each tmp As SIS.PAK.pakSitePkgDLocation In tmpS
        If Not tmp.Support Then
          If tmp.RecSrLNo = Record.RecSrLNo Then
            tmpQty += Record.Quantity
          Else
            tmpQty += tmp.Quantity
          End If
        End If
      Next
      Dim tmpPkgD As SIS.PAK.pakSitePkgD = Record.FK_PAK_SitePkgDLocation_RecSrNo
      If tmpPkgD.Quantity < tmpQty Then
        Throw New Exception("Location wise distributed quantity is greater than received quantity.")
      End If
      Record = pakSitePkgDLocationUpdate(Record)
      'Update Item Status to Received
      tmpPkgD.InventoryStatusID = siteInventoryStates.Received
      SIS.PAK.pakSitePkgD.UpdateData(tmpPkgD)
      Return Record
    End Function
    Public Shared Function UZ_pakSitePkgDLocationDelete(ByVal Record As SIS.PAK.pakSitePkgDLocation) As Integer
      Dim _Result as Integer = pakSitePkgDLocationDelete(Record)
      Return _Result
    End Function
    Public Shared Function SetDefaultValues(ByVal sender As System.Web.UI.WebControls.FormView, ByVal e As System.EventArgs) As System.Web.UI.WebControls.FormView
      With sender
        Try
        CType(.FindControl("F_RecSrLNo"), TextBox).Text = ""
        CType(.FindControl("F_ItemNo"), TextBox).Text = ""
        CType(.FindControl("F_ItemNo_Display"), Label).Text = ""
        CType(.FindControl("F_SiteMarkNo"), TextBox).Text = ""
        CType(.FindControl("F_SiteMarkNo_Display"), Label).Text = ""
        CType(.FindControl("F_UOMQuantity"), TextBox).Text = ""
        CType(.FindControl("F_UOMQuantity_Display"), Label).Text = ""
        CType(.FindControl("F_Quantity"), TextBox).Text = 0
        CType(.FindControl("F_LocationID"),Object).SelectedValue = ""
        CType(.FindControl("F_Remarks"), TextBox).Text = ""
        CType(.FindControl("F_RecSrNo"), TextBox).Text = ""
        CType(.FindControl("F_RecSrNo_Display"), Label).Text = ""
        CType(.FindControl("F_RecNo"), TextBox).Text = ""
        CType(.FindControl("F_RecNo_Display"), Label).Text = ""
        CType(.FindControl("F_ProjectID"), TextBox).Text = ""
        CType(.FindControl("F_ProjectID_Display"), Label).Text = ""
        CType(.FindControl("F_BOMNo"), TextBox).Text = ""
        CType(.FindControl("F_BOMNo_Display"), Label).Text = ""
        CType(.FindControl("F_PkgNo"), TextBox).Text = ""
        CType(.FindControl("F_PkgNo_Display"), Label).Text = ""
        CType(.FindControl("F_SerialNo"), TextBox).Text = ""
        CType(.FindControl("F_SerialNo_Display"), Label).Text = ""
        Catch ex As Exception
        End Try
      End With
      Return sender
    End Function
  End Class
End Namespace
