Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports OfficeOpenXml
Imports System.Web.Script.Serialization
Partial Class EF_pakItems
  Inherits SIS.SYS.UpdateBase
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
  Protected Sub ODSpakItems_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODSpakItems.Selected
    Dim tmp As SIS.PAK.pakItems = CType(e.ReturnValue, SIS.PAK.pakItems)
    Editable = tmp.Editable
    Deleteable = tmp.Deleteable
    PrimaryKey = tmp.PrimaryKey
  End Sub
  Protected Sub FVpakItems_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpakItems.Init
    DataClassName = "EpakItems"
    SetFormView = FVpakItems
  End Sub
  Protected Sub TBLpakItems_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLpakItems.Init
    SetToolBar = TBLpakItems
  End Sub
  Protected Sub FVpakItems_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpakItems.PreRender
    TBLpakItems.EnableSave = Editable
    TBLpakItems.EnableDelete = Deleteable
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/PAK_Main/App_Edit") & "/EF_pakItems.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptpakItems") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptpakItems", mStr)
    End If
  End Sub
  Partial Class gvBase
    Inherits SIS.SYS.GridBase
  End Class
  Private WithEvents gvpakCItemsCC As New gvBase
  Protected Sub GVpakCItems_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVpakCItems.Init
    gvpakCItemsCC.DataClassName = "GpakCItems"
    gvpakCItemsCC.SetGridView = GVpakCItems
    'With GVpakCItems
    '  .PageIndex = 1
    '  .PageSize = 10000
    'End With
  End Sub
  Protected Sub TBLpakCItems_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLpakCItems.Init
    'With TBLpakCItems
    '  .CurrentPage = 1
    '  .RecordsPerPage = 10000
    'End With
    gvpakCItemsCC.SetToolBar = TBLpakCItems
  End Sub
  Protected Sub GVpakCItems_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVpakCItems.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim RootItem As Int32 = GVpakCItems.DataKeys(e.CommandArgument).Values("RootItem")
        Dim ItemNo As Int32 = GVpakCItems.DataKeys(e.CommandArgument).Values("ItemNo")
        Dim RedirectUrl As String = TBLpakCItems.EditUrl & "?RootItem=" & RootItem & "&ItemNo=" & ItemNo
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
      End Try
    End If
    If e.CommandName.ToLower = "Deletewf".ToLower Then
      Try
        Dim RootItem As Int32 = GVpakCItems.DataKeys(e.CommandArgument).Values("RootItem")
        Dim ItemNo As Int32 = GVpakCItems.DataKeys(e.CommandArgument).Values("ItemNo")
        SIS.PAK.pakCItems.DeleteWF(RootItem, ItemNo)
        GVpakCItems.DataBind()
      Catch ex As Exception
        Dim message As String = New JavaScriptSerializer().Serialize(ex.Message)
        Dim script As String = String.Format("alert({0});", message)
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", script, True)
      End Try
    End If
  End Sub
  Protected Sub TBLpakCItems_AddClicked(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles TBLpakCItems.AddClicked
    Dim ItemNo As Int32 = CType(FVpakItems.FindControl("F_RootItem"), TextBox).Text
    TBLpakCItems.AddUrl &= "?RootItem=" & ItemNo
  End Sub
  <System.Web.Services.WebMethod()>
  <System.Web.Script.Services.ScriptMethod()>
  Public Shared Function ElementIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.PAK.pakElements.SelectpakElementsAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()>
  Public Shared Function validate_FK_PAK_Items_ElementID(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String = "0|" & aVal(0)
    Dim ElementID As String = CType(aVal(1), String)
    Dim oVar As SIS.PAK.pakElements = SIS.PAK.pakElements.pakElementsGetByID(ElementID)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found."
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField
    End If
    Return mRet
  End Function



  'Protected Sub cmdDownload_Click(sender As Object, e As System.EventArgs) Handles cmdDownload.Click
  '  Dim st As Long = HttpContext.Current.Server.ScriptTimeout
  '  HttpContext.Current.Server.ScriptTimeout = Integer.MaxValue

  '  Dim ProjectID As String = F_DownloadPrjID.Text
  '  If ProjectID = String.Empty Then
  '    Dim message As String = New JavaScriptSerializer().Serialize("Project ID is required for Template download.")
  '    Dim script As String = String.Format("alert({0});", message)
  '    ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", script, True)
  '    Exit Sub
  '  End If
  '  Dim TemplateName As String = "MRN_Template.xlsm"
  '  Dim tmpFile As String = Server.MapPath("~/App_Templates/" & TemplateName)
  '  If IO.File.Exists(tmpFile) Then
  '    Dim FileName As String = Server.MapPath("~/..") & "App_Temp/" & Guid.NewGuid().ToString()
  '    IO.File.Copy(tmpFile, FileName)
  '    Dim FileInfo As IO.FileInfo = New IO.FileInfo(FileName)
  '    Dim xlPk As ExcelPackage = New ExcelPackage(FileInfo)

  '    '1.
  '    Dim xlWS As ExcelWorksheet = xlPk.Workbook.Worksheets("SUP")
  '    Dim oBPs As List(Of lgBP) = lgBP.GetDataFromBaaN("SUP")
  '    Dim r As Integer = 1
  '    Dim c As Integer = 1
  '    Dim cnt As Integer = 1
  '    With xlWS
  '      .Cells.Clear()
  '      .Cells(r, 2).Value = ""
  '      .Cells(r, 1).Value = "---NOT IN LIST---"
  '      r += 1
  '      For Each bp As lgBP In oBPs
  '        On Error Resume Next
  '        .Cells(r, 2).Value = bp.t_bpid
  '        .Cells(r, 1).Value = bp.t_nama
  '        r += 1
  '      Next
  '    End With

  '    '3. Only one Project and Customer
  '    xlWS = xlPk.Workbook.Worksheets("PRJ")
  '    oBPs = lgBP.GetDataFromBaaN("PRJ", ProjectID)
  '    r = 1
  '    c = 1
  '    With xlWS
  '      .Cells.Clear()
  '      For Each bp As lgBP In oBPs
  '        On Error Resume Next
  '        .Cells(r, 2).Value = bp.t_bpid
  '        .Cells(r, 1).Value = bp.t_nama
  '        .Cells(r, 3).Value = bp.CustomerName
  '        .Cells(r, 4).Value = bp.CustomerID
  '        r += 1
  '      Next
  '    End With
  '    '4.
  '    xlWS = xlPk.Workbook.Worksheets("VType")
  '    Dim oVTyps As List(Of SIS.VR.vrVehicleTypes) = SIS.VR.vrVehicleTypes.vrVehicleTypesSelectList("")
  '    r = 1
  '    c = 1
  '    With xlWS
  '      .Cells.Clear()
  '      .Cells(r, 2).Value = ""
  '      .Cells(r, 1).Value = "---NOT IN LIST---"
  '      .Cells(r, 3).Value = 0
  '      .Cells(r, 4).Value = 0
  '      .Cells(r, 5).Value = 0
  '      r = r + 1
  '      For Each vt As SIS.VR.vrVehicleTypes In oVTyps
  '        On Error Resume Next
  '        .Cells(r, 1).Value = vt.cmba
  '        .Cells(r, 2).Value = vt.VehicleTypeID
  '        .Cells(r, 3).Value = vt.LengthInFt
  '        .Cells(r, 4).Value = vt.WidthInFt
  '        .Cells(r, 5).Value = vt.HeightInFt
  '        r += 1
  '      Next
  '    End With
  '    '5.
  '    xlWS = xlPk.Workbook.Worksheets("MatState")
  '    Dim omSts As List(Of SIS.VR.vrMaterialStates) = SIS.VR.vrMaterialStates.vrMaterialStatesSelectList("")
  '    r = 1
  '    c = 1
  '    With xlWS
  '      .Cells.Clear()
  '      For Each mt As SIS.VR.vrMaterialStates In omSts
  '        On Error Resume Next
  '        .Cells(r, 1).Value = mt.Description
  '        .Cells(r, 2).Value = mt.MaterialStateID
  '        r += 1
  '      Next
  '    End With
  '    '6 MRN Header & MRN Details
  '    Dim aFld() As String
  '    Dim aFldd() As String
  '    Dim xlWSd As ExcelWorksheet = xlPk.Workbook.Worksheets("GRDetails")
  '    xlWS = xlPk.Workbook.Worksheets("MRN")
  '    r = 3
  '    c = 1
  '    ReDim aFld(0)
  '    Do While xlWS.Cells(r, c).Text <> String.Empty
  '      ReDim Preserve aFld(c - 1)
  '      aFld(c - 1) = xlWS.Cells(r, c).Text
  '      xlWS.Cells(r, c).Value = ""
  '      c += 1
  '    Loop
  '    Dim rd As Integer = 3
  '    c = 1
  '    ReDim aFldd(0)
  '    Do While xlWSd.Cells(rd, c).Text <> String.Empty
  '      ReDim Preserve aFldd(c - 1)
  '      aFldd(c - 1) = xlWSd.Cells(rd, c).Text
  '      xlWSd.Cells(rd, c).Value = ""
  '      c += 1
  '    Loop
  '    Dim oMrns As List(Of SIS.VR.vrLorryReceipts) = SIS.VR.vrLorryReceipts.GetByProjectID(ProjectID, "MRNNo")
  '    With xlWS
  '      On Error Resume Next
  '      For Each doc As SIS.VR.vrLorryReceipts In oMrns
  '        If r > 3 Then xlWS.InsertRow(r, 1, r + 1)
  '        For c = 0 To aFld.Length
  '          Dim aTmp() As String = aFld(c).Split(".".ToCharArray)
  '          If aTmp.Length > 1 Then
  '            Dim oBj As Object = CallByName(doc, aTmp(0), CallType.Get)
  '            .Cells(r, c + 1).Value = CallByName(oBj, aTmp(1), CallType.Get)
  '          Else
  '            .Cells(r, c + 1).Value = CallByName(doc, aFld(c), CallType.Get)
  '          End If
  '        Next
  '        Dim oMrnds As List(Of SIS.VR.vrLorryReceiptDetails) = SIS.VR.vrLorryReceiptDetails.vrLorryReceiptDetailsSelectList(0, 999, "SerialNo", False, "", doc.ProjectID, doc.MRNNo)
  '        With xlWSd
  '          For Each docd As SIS.VR.vrLorryReceiptDetails In oMrnds
  '            If rd > 3 Then xlWSd.InsertRow(rd, 1, rd + 1)
  '            For c = 0 To aFldd.Length
  '              Dim aTmp() As String = aFldd(c).Split(".".ToCharArray)
  '              If aTmp.Length > 1 Then
  '                Dim oBj As Object = CallByName(docd, aTmp(0), CallType.Get)
  '                .Cells(rd, c + 1).Value = CallByName(oBj, aTmp(1), CallType.Get)
  '              Else
  '                .Cells(rd, c + 1).Value = CallByName(docd, aFldd(c), CallType.Get)
  '              End If
  '            Next
  '            rd += 1
  '          Next
  '        End With
  '        r += 1
  '      Next
  '    End With
  '    xlPk.Save()
  '    xlPk.Dispose()

  '    Response.Clear()
  '    Response.AppendHeader("content-disposition", "attachment; filename=" & ProjectID & "_Template.xlsm")
  '    Response.ContentType = SIS.SYS.Utilities.ApplicationSpacific.ContentType(TemplateName)
  '    Response.WriteFile(FileName)
  '    HttpContext.Current.Server.ScriptTimeout = st
  '    Response.End()
  '  End If

  'End Sub
End Class
