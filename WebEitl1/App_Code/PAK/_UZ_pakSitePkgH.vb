Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.PAK
  Partial Public Class pakSitePkgH
    Public Function GetColor() As System.Drawing.Color
      Dim mRet As System.Drawing.Color = Drawing.Color.Black
      Select Case ReceiveStatusID
        Case siteReceiveStates.PackagePending
          mRet = Drawing.Color.DarkViolet
        Case siteReceiveStates.Received
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
      Select Case ReceiveStatusID
        Case siteReceiveStates.Free, siteReceiveStates.PackagePending
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
        Dim mRet As Boolean = False
        Try
          Select Case ReceiveStatusID
            Case siteReceiveStates.Free, siteReceiveStates.PackagePending
              mRet = True
          End Select
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
          mRet = GetVisible()
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
    Public Shared Function InitiateWF(ByVal ProjectID As String, ByVal RecNo As Int32) As SIS.PAK.pakSitePkgH
      Dim CompletelyReceived As Boolean = True
      Dim CloseStatusFound As Boolean = False
      Dim pkgH As SIS.PAK.pakSitePkgH = pakSitePkgHGetByID(ProjectID, RecNo)
      Dim pkgDs As List(Of SIS.PAK.pakSitePkgD) = SIS.PAK.pakSitePkgD.pakSitePkgDSelectList(0, 99999, "", False, "", RecNo, ProjectID)
      For Each tmpD As SIS.PAK.pakSitePkgD In pkgDs
        Select Case tmpD.InventoryStatusID
          Case siteInventoryStates.Free, siteInventoryStates.PackagePending
            CompletelyReceived = False
          Case siteInventoryStates.Closed
            CloseStatusFound = True
          Case siteInventoryStates.Received
            'Get All Child Location
            'Check distributed quantity
            Dim pkgDLs As List(Of SIS.PAK.pakSitePkgDLocation) = SIS.PAK.pakSitePkgDLocation.UZ_pakSitePkgDLocationSelectList(0, 99999, "", False, "", tmpD.RecSrNo, tmpD.RecNo, tmpD.ProjectID)
            Dim tmpQty As Decimal = 0
            For Each tmpDL As SIS.PAK.pakSitePkgDLocation In pkgDLs
              If Not tmpDL.Support Then
                tmpQty += tmpDL.Quantity
              End If
            Next
            If tmpD.Quantity <> tmpQty Then
              Throw New Exception("Location wise Quantity not same as received quantity for Line No: " & tmpD.RecSrNo)
            End If
            'Delete support Items
            For Each tmpDL As SIS.PAK.pakSitePkgDLocation In pkgDLs
              If tmpDL.Support Then
                SIS.PAK.pakSitePkgDLocation.pakSitePkgDLocationDelete(tmpDL)
              End If
            Next
            'Update Site Item Master
            Dim ItmFound As Boolean = True
            Dim itmH As SIS.PAK.pakSiteItemMaster = SIS.PAK.pakSiteItemMaster.pakSiteItemMasterGetByID(tmpD.ProjectID, tmpD.SiteMarkNo)
            If itmH Is Nothing Then
              ItmFound = False
              itmH = New SIS.PAK.pakSiteItemMaster
              With itmH
                .ProjectID = tmpD.ProjectID
                .SiteMarkNo = tmpD.SiteMarkNo
                .ItemDescription = tmpD.FK_PAK_SitePkgD_ItemNo.FK_PAK_PkgListD_ItemNo.ItemDescription
                .UOMQuantity = tmpD.UOMQuantity
              End With
            End If
            itmH.Quantity += tmpD.Quantity
            If Not ItmFound Then
              itmH = SIS.PAK.pakSiteItemMaster.InsertData(itmH)
            Else
              itmH = SIS.PAK.pakSiteItemMaster.UpdateData(itmH)
            End If
            'Update Site ItemMaster Location
            For Each tmpDL As SIS.PAK.pakSitePkgDLocation In pkgDLs
              If Not tmpDL.Support Then
                Dim Found As Boolean = True
                Dim itmHL As SIS.PAK.pakSiteItemMasterLocation = SIS.PAK.pakSiteItemMasterLocation.pakSiteItemMasterLocationGetByID(tmpDL.ProjectID, tmpDL.SiteMarkNo, tmpDL.LocationID)
                If itmHL Is Nothing Then
                  Found = False
                  itmHL = New SIS.PAK.pakSiteItemMasterLocation
                  With itmHL
                    .ProjectID = tmpDL.ProjectID
                    .SiteMarkNo = tmpDL.SiteMarkNo
                    .LocationID = tmpDL.LocationID
                    .UOMQuantity = tmpDL.UOMQuantity
                  End With
                End If
                itmHL.Quantity += tmpDL.Quantity
                If Not Found Then
                  itmHL = SIS.PAK.pakSiteItemMasterLocation.InsertData(itmHL)
                Else
                  itmHL = SIS.PAK.pakSiteItemMasterLocation.UpdateData(itmHL)
                End If
              End If
            Next
            'Update Line Status
            tmpD.InventoryStatusID = siteInventoryStates.Closed
            tmpD.InventoryUpdatedBy = HttpContext.Current.Session("LoginID")
            tmpD.InventoryUpdatedOn = Now
            tmpD = SIS.PAK.pakSitePkgD.UpdateData(tmpD)
            CloseStatusFound = True
        End Select
      Next
      If CompletelyReceived Then
        pkgH.ReceiveStatusID = siteReceiveStates.Received
      ElseIf CloseStatusFound Then
        pkgH.ReceiveStatusID = siteReceiveStates.PackagePending
      End If
      pkgH.CreatedBy = HttpContext.Current.Session("LoginID")
      pkgH.CreatedOn = Now
      pkgH = SIS.PAK.pakSitePkgH.UpdateData(pkgH)
      Return pkgH
    End Function
    Public Shared Function ApproveWF(ByVal ProjectID As String, ByVal RecNo As Int32) As SIS.PAK.pakSitePkgH
      Dim Results As SIS.PAK.pakSitePkgH = pakSitePkgHGetByID(ProjectID, RecNo)
      Return Results
    End Function
    Public Shared Function UZ_pakSitePkgHSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal ProjectID As String, ByVal SerialNo As Int32, ByVal PkgNo As Int32, ByVal SupplierID As String) As List(Of SIS.PAK.pakSitePkgH)
      Dim Results As List(Of SIS.PAK.pakSitePkgH) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "sppak_LG_SitePkgHSelectListSearch"
            Cmd.CommandText = "sppakSitePkgHSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "sppak_LG_SitePkgHSelectListFilteres"
            Cmd.CommandText = "sppakSitePkgHSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_ProjectID",SqlDbType.NVarChar,6, IIf(ProjectID Is Nothing, String.Empty,ProjectID))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_SerialNo",SqlDbType.Int,10, IIf(SerialNo = Nothing, 0,SerialNo))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_PkgNo",SqlDbType.Int,10, IIf(PkgNo = Nothing, 0,PkgNo))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_SupplierID",SqlDbType.NVarChar,9, IIf(SupplierID Is Nothing, String.Empty,SupplierID))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.PAK.pakSitePkgH)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.PAK.pakSitePkgH(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function UZ_pakSitePkgHUpdate(ByVal Record As SIS.PAK.pakSitePkgH) As SIS.PAK.pakSitePkgH
      Dim _Result As SIS.PAK.pakSitePkgH = pakSitePkgHUpdate(Record)
      Return _Result
    End Function
    Public Shared Function SetDefaultValues(ByVal sender As System.Web.UI.WebControls.FormView, ByVal e As System.EventArgs) As System.Web.UI.WebControls.FormView
      With sender
        Try
        CType(.FindControl("F_ProjectID"), TextBox).Text = ""
        CType(.FindControl("F_ProjectID_Display"), Label).Text = ""
        CType(.FindControl("F_RecNo"), TextBox).Text = ""
        CType(.FindControl("F_SerialNo"), TextBox).Text = ""
        CType(.FindControl("F_SerialNo_Display"), Label).Text = ""
        CType(.FindControl("F_PkgNo"), TextBox).Text = ""
        CType(.FindControl("F_PkgNo_Display"), Label).Text = ""
        CType(.FindControl("F_MRNNo"), TextBox).Text = ""
        CType(.FindControl("F_MRNNo_Display"), Label).Text = ""
        CType(.FindControl("F_SupplierID"), TextBox).Text = ""
        CType(.FindControl("F_SupplierID_Display"), Label).Text = ""
        CType(.FindControl("F_SupplierName"), TextBox).Text = ""
        CType(.FindControl("F_SupplierRefNo"), TextBox).Text = ""
        CType(.FindControl("F_TransporterID"), TextBox).Text = ""
        CType(.FindControl("F_TransporterID_Display"), Label).Text = ""
        CType(.FindControl("F_TransporterName"), TextBox).Text = ""
        CType(.FindControl("F_VehicleNo"), TextBox).Text = ""
        CType(.FindControl("F_GRNo"), TextBox).Text = ""
        CType(.FindControl("F_GRDate"), TextBox).Text = ""
        CType(.FindControl("F_UOMTotalWeight"), TextBox).Text = ""
        CType(.FindControl("F_UOMTotalWeight_Display"), Label).Text = ""
        CType(.FindControl("F_TotalWeight"), TextBox).Text = 0
        CType(.FindControl("F_ODC"), CheckBox).Checked = False
        CType(.FindControl("F_MaterialStatusID"),Object).SelectedValue = ""
        CType(.FindControl("F_Remarks"), TextBox).Text = ""
        Catch ex As Exception
        End Try
      End With
      Return sender
    End Function
  End Class
End Namespace
