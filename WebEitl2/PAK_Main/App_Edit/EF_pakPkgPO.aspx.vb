Imports OfficeOpenXml
Imports System.Web.Script.Serialization
Imports System.IO
Partial Class EF_pakPkgPO
  Inherits SIS.SYS.UpdateBase
  Public Property ChildCreatable() As Boolean
    Get
      If ViewState("ChildCreatable") IsNot Nothing Then
        Return CType(ViewState("ChildCreatable"), Boolean)
      End If
      Return True
    End Get
    Set(ByVal value As Boolean)
      ViewState.Add("ChildCreatable", value)
    End Set
  End Property
  Public Property Editable() As Boolean
    Get
      If ViewState("Editable") IsNot Nothing Then
        Return CType(ViewState("Editable"), Boolean)
      End If
      Return True
    End Get
    Set(ByVal value As Boolean)
      ViewState.Add("Editable", value)
    End Set
  End Property
  Public Property Deleteable() As Boolean
    Get
      If ViewState("Deleteable") IsNot Nothing Then
        Return CType(ViewState("Deleteable"), Boolean)
      End If
      Return True
    End Get
    Set(ByVal value As Boolean)
      ViewState.Add("Deleteable", value)
    End Set
  End Property
  Public Property PrimaryKey() As String
    Get
      If ViewState("PrimaryKey") IsNot Nothing Then
        Return CType(ViewState("PrimaryKey"), String)
      End If
      Return True
    End Get
    Set(ByVal value As String)
      ViewState.Add("PrimaryKey", value)
    End Set
  End Property
  Protected Sub ODSpakPkgPO_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODSpakPkgPO.Selected
    Dim tmp As SIS.PAK.pakPkgPO = CType(e.ReturnValue, SIS.PAK.pakPkgPO)
    Editable = tmp.Editable
    Deleteable = tmp.Deleteable
    PrimaryKey = tmp.PrimaryKey
    ChildCreatable = tmp.ChildCreatable
  End Sub
  Protected Sub FVpakPkgPO_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpakPkgPO.Init
    DataClassName = "EpakPkgPO"
    SetFormView = FVpakPkgPO
  End Sub
  Protected Sub TBLpakPkgPO_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLpakPkgPO.Init
    SetToolBar = TBLpakPkgPO
  End Sub
  Protected Sub FVpakPkgPO_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpakPkgPO.PreRender
    TBLpakPkgPO.EnableSave = Editable
    TBLpakPkgPO.EnableDelete = Deleteable
    TBLpakPkgListH.EnableAdd = ChildCreatable
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/PAK_Main/App_Edit") & "/EF_pakPkgPO.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptpakPkgPO") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptpakPkgPO", mStr)
    End If
  End Sub
  Partial Class gvBase
    Inherits SIS.SYS.GridBase
  End Class
  Private WithEvents gvpakPkgListHCC As New gvBase
  Protected Sub GVpakPkgListH_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVpakPkgListH.Init
    gvpakPkgListHCC.DataClassName = "GpakPkgListH"
    gvpakPkgListHCC.SetGridView = GVpakPkgListH
  End Sub
  Protected Sub TBLpakPkgListH_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLpakPkgListH.Init
    gvpakPkgListHCC.SetToolBar = TBLpakPkgListH
  End Sub
  Protected Sub GVpakPkgListH_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVpakPkgListH.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim SerialNo As Int32 = GVpakPkgListH.DataKeys(e.CommandArgument).Values("SerialNo")
        Dim PkgNo As Int32 = GVpakPkgListH.DataKeys(e.CommandArgument).Values("PkgNo")
        Dim RedirectUrl As String = TBLpakPkgListH.EditUrl & "?SerialNo=" & SerialNo & "&PkgNo=" & PkgNo
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
      End Try
    End If
    If e.CommandName.ToLower = "initiatewf".ToLower Then
      Try
        Dim SerialNo As Int32 = GVpakPkgListH.DataKeys(e.CommandArgument).Values("SerialNo")
        Dim PkgNo As Int32 = GVpakPkgListH.DataKeys(e.CommandArgument).Values("PkgNo")
        SIS.PAK.pakPkgListH.InitiateWF(SerialNo, PkgNo)
        GVpakPkgListH.DataBind()
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
      End Try
    End If
    If e.CommandName.ToLower = "rejectwf".ToLower Then
      Try
        Dim SerialNo As Int32 = GVpakPkgListH.DataKeys(e.CommandArgument).Values("SerialNo")
        Dim PkgNo As Int32 = GVpakPkgListH.DataKeys(e.CommandArgument).Values("PkgNo")
        Dim UnProtected As Boolean = CType(GVpakPkgListH.Rows(e.CommandArgument).FindControl("F_UnProtected"), CheckBox).Checked
        SIS.PAK.pakPkgListH.RejectWF(SerialNo, PkgNo, UnProtected)
        GVpakPkgListH.DataBind()
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
      End Try
    End If
    If e.CommandName.ToLower = "approvewf".ToLower Then
      Try
        Dim SerialNo As Int32 = GVpakPkgListH.DataKeys(e.CommandArgument).Values("SerialNo")
        Dim PkgNo As Int32 = GVpakPkgListH.DataKeys(e.CommandArgument).Values("PkgNo")
        SIS.PAK.pakPkgListH.ApproveWF(SerialNo, PkgNo)
        GVpakPkgListH.DataBind()
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
      End Try
    End If
  End Sub
  Protected Sub TBLpakPkgListH_AddClicked(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles TBLpakPkgListH.AddClicked
    Dim SerialNo As Int32 = CType(FVpakPkgPO.FindControl("F_SerialNo"), TextBox).Text
    TBLpakPkgListH.AddUrl &= "?SerialNo=" & SerialNo
  End Sub
  Private st As Long = HttpContext.Current.Server.ScriptTimeout

  Private Sub FVpakPkgPO_ItemCommand(sender As Object, e As FormViewCommandEventArgs) Handles FVpakPkgPO.ItemCommand
    HttpContext.Current.Server.ScriptTimeout = Integer.MaxValue
    If e.CommandName.ToLower = "tmplupload" Then
      Try
        Dim aVal() As String = e.CommandArgument.ToString.Split("|".ToCharArray)
        Dim SerialNo As String = ""
        Dim PkgNo As String = ""
        Dim BOMNo As String = ""
        Try
          SerialNo = aVal(0)
          PkgNo = aVal(1)
          BOMNo = aVal(2)
        Catch ex As Exception

        End Try
        With F_FileUpload
          If .HasFile Then
            Dim tmpPath As String = Server.MapPath("~/../App_Temp")
            Dim tmpName As String = IO.Path.GetRandomFileName()
            Dim tmpFile As String = tmpPath & "\\" & tmpName
            .SaveAs(tmpFile)
            Dim fi As FileInfo = New FileInfo(tmpFile)
            Dim IsError As Boolean = False
            Dim ErrMsg As String = ""
            Using xlP As ExcelPackage = New ExcelPackage(fi)
              Dim wsD As ExcelWorksheet = Nothing
              Try
                wsD = xlP.Workbook.Worksheets("Data")
              Catch ex As Exception
                wsD = Nothing
              End Try
              '1. Process Document
              If wsD Is Nothing Then
                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize("Invalid XL File") & "');", True)
                xlP.Dispose()
                HttpContext.Current.Server.ScriptTimeout = st
                Exit Sub
              End If

              Dim tmpSerialNo As String = wsD.Cells(1, 3).Text
              Dim tmpPkgNo As String = wsD.Cells(2, 3).Text
              Dim tmpBomNo As String = wsD.Cells(3, 3).Text

              If SerialNo <> tmpSerialNo Then
                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize("Wrong SerialNo Uploaded.") & "');", True)
                xlP.Dispose()
                HttpContext.Current.Server.ScriptTimeout = st
                Exit Sub
              End If
              If PkgNo <> String.Empty AndAlso PkgNo <> tmpPkgNo Then
                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize("Wrong Packing List Uploaded.") & "');", True)
                xlP.Dispose()
                HttpContext.Current.Server.ScriptTimeout = st
                Exit Sub
              End If
              If BOMNo <> String.Empty AndAlso BOMNo <> tmpBomNo Then
                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize("Wrong Packing List/BOM No Uploaded.") & "');", True)
                xlP.Dispose()
                HttpContext.Current.Server.ScriptTimeout = st
                Exit Sub
              End If
              'Check the status of PO & Packing List Before Update
              'PO
              Dim tmpPO As SIS.PAK.pakPkgPO = SIS.PAK.pakPkgPO.pakPkgPOGetByID(SerialNo)
              If tmpPO.POStatusID <> pakPOStates.UnderDespatch Then
                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize("PO status is not UNDER DESPATCH, cannot update packing list.") & "');", True)
                xlP.Dispose()
                HttpContext.Current.Server.ScriptTimeout = st
                Exit Sub
              End If
              'Packing List
              Dim tmpPkg As SIS.PAK.pakPkgListH = SIS.PAK.pakPkgListH.pakPkgListHGetByID(SerialNo, tmpPkgNo)
              If tmpPkg.StatusID <> pakPkgStates.Free Then
                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize("Packing List status is not FREE, cannot update packing list.") & "');", True)
                xlP.Dispose()
                HttpContext.Current.Server.ScriptTimeout = st
                Exit Sub
              End If
              'End of status Checking
              Dim tmpPkgHWt As Decimal = 0
              Dim tmpItemNo As String = ""
              Dim Updatable As Boolean = False
              Dim tmpQuantity As String = ""
              Dim tmpWeightPerUnit As String = ""

              Dim tmpDocumentNo As String = ""
              Dim tmpDocumentRevision As String = ""
              Dim tmpPackageType As String = ""
              Dim tmpPackageMark As String = ""
              Dim tmpPackUOM As String = ""
              Dim tmpPackLength As String = ""
              Dim tmpPackWidth As String = ""
              Dim tmpPackHeight As String = ""
              Dim tmpRemarks As String = ""
              For I As Integer = 9 To 99999
                tmpBomNo = wsD.Cells(I, 2).Text
                If tmpBomNo = String.Empty Then Exit For
                tmpItemNo = wsD.Cells(I, 3).Text
                Updatable = IIf(wsD.Cells(I, 6).Text <> String.Empty, True, False)
                If Not Updatable Then Continue For
                tmpQuantity = wsD.Cells(I, 14).Text.Trim
                '====================================
                If tmpQuantity = String.Empty Then Continue For
                If Not IsNumeric(tmpQuantity) Then Continue For
                '====================================
                tmpWeightPerUnit = wsD.Cells(I, 15).Text
                tmpDocumentNo = wsD.Cells(I, 16).Text
                tmpDocumentRevision = wsD.Cells(I, 17).Text
                tmpPackageType = wsD.Cells(I, 18).Text
                tmpPackageMark = wsD.Cells(I, 19).Text
                tmpPackUOM = wsD.Cells(I, 20).Text
                tmpPackLength = wsD.Cells(I, 21).Text
                tmpPackWidth = wsD.Cells(I, 22).Text
                tmpPackHeight = wsD.Cells(I, 23).Text
                tmpRemarks = wsD.Cells(I, 24).Text

                If Not IsNumeric(tmpWeightPerUnit) Then
                  tmpWeightPerUnit = "0.00"
                End If

                If tmpPackUOM <> "" Then
                  Dim mst As SIS.PAK.pakUnits = SIS.PAK.pakUnits.pakUnitsGetByDescription(tmpPackUOM)
                  If mst Is Nothing Then
                    ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize("Invalid Package UOM at ItemNo : " & tmpItemNo) & "');", True)
                    xlP.Dispose()
                    HttpContext.Current.Server.ScriptTimeout = st
                    Exit Sub
                  Else
                    tmpPackUOM = mst.UnitID
                  End If
                End If
                If tmpPackageType <> "" Then
                  Dim mst As SIS.PAK.pakPakTypes = SIS.PAK.pakPakTypes.pakPakTypesGetByDescription(tmpPackageType)
                  If mst Is Nothing Then
                    ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize("Invalid Package Type at ItemNo : " & tmpItemNo) & "');", True)
                    xlP.Dispose()
                    HttpContext.Current.Server.ScriptTimeout = st
                    Exit Sub
                  Else
                    tmpPackageType = mst.PackTypeID
                  End If
                End If

                Dim Found As Boolean = True
                Dim tmpListD As SIS.PAK.pakPkgListD = Nothing
                tmpListD = SIS.PAK.pakPkgListD.pakPkgListDGetByID(SerialNo, tmpPkgNo, tmpBomNo, tmpItemNo)
                If tmpListD Is Nothing Then
                  Dim tmpPOBItem As SIS.PAK.pakPOBItems = SIS.PAK.pakPOBItems.pakPOBItemsGetByID(tmpSerialNo, tmpBomNo, tmpItemNo)
                  Found = False
                  tmpListD = New SIS.PAK.pakPkgListD
                  With tmpListD
                    .SerialNo = tmpSerialNo
                    .PkgNo = tmpPkgNo
                    .BOMNo = tmpBomNo
                    .ItemNo = tmpItemNo
                    .UOMQuantity = tmpPOBItem.UOMQuantity
                    .UOMWeight = tmpPOBItem.UOMWeight
                    .WeightPerUnit = tmpPOBItem.WeightPerUnit
                    '.DocumentNo = tmpPOBItem.DocumentNo
                    '.DocumentRevision = tmpPOBItem.FK_PAK_POBItems_DocumentNo.DocumentRevision
                  End With
                End If
                With tmpListD
                  .Quantity = IIf(tmpQuantity = "", 0, tmpQuantity)
                  'Suppliered Entered Wt is Ignored
                  '.WeightPerUnit = IIf(Convert.ToDecimal(tmpWeightPerUnit) <= 0.00, .WeightPerUnit, tmpWeightPerUnit)
                  .DocumentNo = tmpDocumentNo
                  .DocumentRevision = tmpDocumentRevision
                  .UOMPack = tmpPackUOM
                  .PackingMark = tmpPackageMark
                  .PackTypeID = tmpPackageType
                  .PackLength = IIf(tmpPackLength = "", 0, tmpPackLength)
                  .PackWidth = IIf(tmpPackWidth = "", 0, tmpPackWidth)
                  .PackHeight = IIf(tmpPackHeight = "", 0, tmpPackHeight)
                  .Remarks = tmpRemarks
                End With
                '=============================
                'Total Weight of Packed Item
                Dim tmpPkgDwt As Decimal = 0
                tmpPkgDwt = SIS.PAK.pakPO.GetTotalWeight(tmpListD.Quantity, tmpListD.WeightPerUnit, tmpListD.UOMQuantity, tmpListD.UOMWeight)
                tmpListD.TotalWeight = tmpPkgDwt
                '======================
                If Found Then
                  If tmpListD.Quantity <= 0 Then
                    Try
                      SIS.PAK.pakPkgListD.pakPkgListDDelete(tmpListD)
                    Catch ex As Exception
                      IsError = True
                      ErrMsg = ErrMsg & IIf(ErrMsg = "", "", ", ") & tmpItemNo & "-D"
                    End Try
                  Else
                    Try
                      tmpListD = SIS.PAK.pakPkgListD.UpdateData(tmpListD)
                      tmpPkgHWt += tmpPkgDwt
                    Catch ex As Exception
                      IsError = True
                      ErrMsg = ErrMsg & IIf(ErrMsg = "", "", ", ") & tmpItemNo & "-U"
                    End Try

                  End If
                Else
                  If tmpListD.Quantity > 0 Then
                    Try
                      tmpListD = SIS.PAK.pakPkgListD.InsertData(tmpListD)
                      tmpPkgHWt += tmpPkgDwt
                    Catch ex As Exception
                      IsError = True
                      ErrMsg = ErrMsg & IIf(ErrMsg = "", "", ", ") & tmpItemNo & "-I"
                    End Try
                  End If
                End If
              Next 'Document Line
              'Update Total Wt if Pkg Items in Header
              Dim tmpH As SIS.PAK.pakPkgListH = SIS.PAK.pakPkgListH.pakPkgListHGetByID(SerialNo, tmpPkgNo)
              tmpH.TotalWeight = tmpPkgHWt
              tmpH = SIS.PAK.pakPkgListH.UpdateData(tmpH)
              '======================================
              xlP.Dispose()
              If IsError Then
                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize("ITEMS NOT INSERTED/UPDATED: " & ErrMsg) & "');", True)
              Else
                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize("Updated") & "');", True)
              End If
            End Using
          End If
        End With
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
      End Try
    End If
    HttpContext.Current.Server.ScriptTimeout = st
  End Sub
End Class
