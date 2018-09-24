Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports OfficeOpenXml
Imports System.Web.Script.Serialization
Partial Class GF_pakItems
  Inherits SIS.SYS.GridBase
  Protected Sub GVpakItems_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVpakItems.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim ItemNo As Int32 = GVpakItems.DataKeys(e.CommandArgument).Values("ItemNo")
        Dim RedirectUrl As String = TBLpakItems.EditUrl & "?ItemNo=" & ItemNo
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
      End Try
    End If
  End Sub
  Protected Sub GVpakItems_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVpakItems.Init
    DataClassName = "GpakItems"
    SetGridView = GVpakItems
  End Sub
  Protected Sub TBLpakItems_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLpakItems.Init
    SetToolBar = TBLpakItems
  End Sub
  Protected Sub F_RootItem_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_RootItem.TextChanged
    Session("F_RootItem") = F_RootItem.Text
    Session("F_RootItem_Display") = F_RootItem_Display.Text
    InitGridPage()
  End Sub
  <System.Web.Services.WebMethod()>
  <System.Web.Script.Services.ScriptMethod()>
  Public Shared Function RootItemCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.PAK.pakItems.SelectpakItemsAutoCompleteList(prefixText, count, contextKey)
  End Function
  Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
    F_RootItem_Display.Text = String.Empty
    If Not Session("F_RootItem_Display") Is Nothing Then
      If Session("F_RootItem_Display") <> String.Empty Then
        F_RootItem_Display.Text = Session("F_RootItem_Display")
      End If
    End If
    F_RootItem.Text = String.Empty
    If Not Session("F_RootItem") Is Nothing Then
      If Session("F_RootItem") <> String.Empty Then
        F_RootItem.Text = Session("F_RootItem")
      End If
    End If
    Dim strScriptRootItem As String = "<script type=""text/javascript""> " &
      "function ACERootItem_Selected(sender, e) {" &
      "  var F_RootItem = $get('" & F_RootItem.ClientID & "');" &
      "  var F_RootItem_Display = $get('" & F_RootItem_Display.ClientID & "');" &
      "  var retval = e.get_value();" &
      "  var p = retval.split('|');" &
      "  F_RootItem.value = p[0];" &
      "  F_RootItem_Display.innerHTML = e.get_text();" &
      "}" &
      "</script>"
    If Not Page.ClientScript.IsClientScriptBlockRegistered("F_RootItem") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_RootItem", strScriptRootItem)
    End If
    Dim strScriptPopulatingRootItem As String = "<script type=""text/javascript""> " &
      "function ACERootItem_Populating(o,e) {" &
      "  var p = $get('" & F_RootItem.ClientID & "');" &
      "  p.style.backgroundImage  = 'url(../../images/loader.gif)';" &
      "  p.style.backgroundRepeat= 'no-repeat';" &
      "  p.style.backgroundPosition = 'right';" &
      "  o._contextKey = '';" &
      "}" &
      "function ACERootItem_Populated(o,e) {" &
      "  var p = $get('" & F_RootItem.ClientID & "');" &
      "  p.style.backgroundImage  = 'none';" &
      "}" &
      "</script>"
    If Not Page.ClientScript.IsClientScriptBlockRegistered("F_RootItemPopulating") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_RootItemPopulating", strScriptPopulatingRootItem)
    End If
    Dim validateScriptRootItem As String = "<script type=""text/javascript"">" &
      "  function validate_RootItem(o) {" &
      "    validated_FK_PAK_Items_RootItem_main = true;" &
      "    validate_FK_PAK_Items_RootItem(o);" &
      "  }" &
      "</script>"
    If Not Page.ClientScript.IsClientScriptBlockRegistered("validateRootItem") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateRootItem", validateScriptRootItem)
    End If
    Dim validateScriptFK_PAK_Items_RootItem As String = "<script type=""text/javascript"">" &
      "  function validate_FK_PAK_Items_RootItem(o) {" &
      "    var value = o.id;" &
      "    var RootItem = $get('" & F_RootItem.ClientID & "');" &
      "    try{" &
      "    if(RootItem.value==''){" &
      "      if(validated_FK_PAK_Items_RootItem.main){" &
      "        var o_d = $get(o.id +'_Display');" &
      "        try{o_d.innerHTML = '';}catch(ex){}" &
      "      }" &
      "    }" &
      "    value = value + ',' + RootItem.value ;" &
      "    }catch(ex){}" &
      "    o.style.backgroundImage  = 'url(../../images/pkloader.gif)';" &
      "    o.style.backgroundRepeat= 'no-repeat';" &
      "    o.style.backgroundPosition = 'right';" &
      "    PageMethods.validate_FK_PAK_Items_RootItem(value, validated_FK_PAK_Items_RootItem);" &
      "  }" &
      "  validated_FK_PAK_Items_RootItem_main = false;" &
      "  function validated_FK_PAK_Items_RootItem(result) {" &
      "    var p = result.split('|');" &
      "    var o = $get(p[1]);" &
      "    var o_d = $get(p[1]+'_Display');" &
      "    try{o_d.innerHTML = p[2];}catch(ex){}" &
      "    o.style.backgroundImage  = 'none';" &
      "    if(p[0]=='1'){" &
      "      o.value='';" &
      "      try{o_d.innerHTML = '';}catch(ex){}" &
      "      __doPostBack(o.id, o.value);" &
      "    }" &
      "    else" &
      "      __doPostBack(o.id, o.value);" &
      "  }" &
      "</script>"
    If Not Page.ClientScript.IsClientScriptBlockRegistered("validateFK_PAK_Items_RootItem") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateFK_PAK_Items_RootItem", validateScriptFK_PAK_Items_RootItem)
    End If
  End Sub
  <System.Web.Services.WebMethod()>
  Public Shared Function validate_FK_PAK_Items_RootItem(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String = "0|" & aVal(0)
    Dim RootItem As String = CType(aVal(1), String)
    Dim oVar As SIS.PAK.pakItems = Nothing
    If RootItem <> String.Empty Then
      oVar = SIS.PAK.pakItems.pakItemsGetByID(RootItem)
    End If
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found."
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField
    End If
    Return mRet
  End Function

  Private Class clsPItems
    Implements IDisposable
    Public Class clsPStac
      Public Property HLevel As String = ""
      Public Property ItemNo As String = ""
      Public Property ItemDesc As String = ""
      Public Sub New(ByVal ID As String, ByVal Desc As String, ByVal HL As String)
        HLevel = HL
        ItemNo = ID
        ItemDesc = Desc
      End Sub
      Sub New()
        'dummy
      End Sub
    End Class
    Public pStac As List(Of clsPStac) = Nothing
    Public Sub PAdd(ByVal ps As clsPStac)
      If ps.HLevel = "I" Then Exit Sub
      For I = pStac.Count - 1 To 0 Step -1
        Dim tmp As clsPStac = pStac(I)
        If tmp.HLevel >= ps.HLevel Then
          pStac.Remove(tmp)
        End If
      Next
      pStac.Add(ps)
    End Sub
    Public Function PGet(ByVal HLevel As String) As clsPStac
      If HLevel = "I" Then
        Dim Last As clsPStac = Nothing
        For Each tmp As clsPStac In pStac
          If Last Is Nothing Then
            Last = tmp
          Else
            If Last.HLevel < tmp.HLevel Then
              Last = tmp
            End If
          End If
        Next
        Return Last
      Else
        Dim x As Integer = CType(HLevel.Substring(1), Integer)
        HLevel = "H" & (x - 1).ToString
        For Each tmp As clsPStac In pStac
          If tmp.HLevel = HLevel Then
            Return tmp
          End If
        Next
      End If
      Return Nothing
    End Function
    Sub New()
      pStac = New List(Of clsPStac)
    End Sub

#Region "IDisposable Support"
    Private disposedValue As Boolean ' To detect redundant calls

    ' IDisposable
    Protected Overridable Sub Dispose(disposing As Boolean)
      If Not disposedValue Then
        If disposing Then
          ' TODO: dispose managed state (managed objects).
          pStac = Nothing
        End If

        ' TODO: free unmanaged resources (unmanaged objects) and override Finalize() below.
        ' TODO: set large fields to null.
      End If
      disposedValue = True
    End Sub

    ' TODO: override Finalize() only if Dispose(disposing As Boolean) above has code to free unmanaged resources.
    'Protected Overrides Sub Finalize()
    '    ' Do not change this code.  Put cleanup code in Dispose(disposing As Boolean) above.
    '    Dispose(False)
    '    MyBase.Finalize()
    'End Sub

    ' This code added by Visual Basic to correctly implement the disposable pattern.
    Public Sub Dispose() Implements IDisposable.Dispose
      ' Do not change this code.  Put cleanup code in Dispose(disposing As Boolean) above.
      Dispose(True)
      ' TODO: uncomment the following line if Finalize() is overridden above.
      ' GC.SuppressFinalize(Me)
    End Sub
#End Region
  End Class
  Protected Sub cmdFileUpload_Command(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.CommandEventArgs) Handles cmdFileUpload.Command
    Dim st As Long = HttpContext.Current.Server.ScriptTimeout
    HttpContext.Current.Server.ScriptTimeout = Integer.MaxValue
    Try
      With F_FileUpload
        If .HasFile Then
          Dim tmpPath As String = Server.MapPath("~/../App_Temp")
          Dim tmpName As String = IO.Path.GetRandomFileName()
          Dim tmpFile As String = tmpPath & "\\" & tmpName
          .SaveAs(tmpFile)
          Dim fi As FileInfo = New FileInfo(tmpFile)
          Using xlP As ExcelPackage = New ExcelPackage(fi)
            Dim wsD As ExcelWorksheet = Nothing
            Try
              Try
                wsD = xlP.Workbook.Worksheets("Data")
              Catch ex As Exception
                wsD = Nothing
              End Try
              If wsD Is Nothing Then
                errMsg.Text = "XL File does not have DATA sheet, Invalid MS-EXCEL file."
                xlP.Dispose()
                Exit Sub
              End If
              Dim pList As New clsPItems
              Dim RootItem As String = wsD.Cells(1, 2).Text
              Dim RootDesc As String = wsD.Cells(2, 2).Text
              Dim ps As clsPItems.clsPStac = New clsPItems.clsPStac(RootItem, RootDesc, "H1")
              pList.PAdd(ps)
              Dim oRoot As SIS.PAK.pakItems = SIS.PAK.pakItems.pakItemsGetByID(RootItem)
              If oRoot Is Nothing Then
                errMsg.Text = "Main Item NOT Found, CAN NOT process MS-EXCEL file."
                xlP.Dispose()
                Exit Sub
              End If
              Dim ItemNo As String = ""
              Dim ItemDesc As String = ""
              Dim pItemNo As String = ""
              Dim pItemDesc As String = ""
              For I As Integer = 6 To 99000
                ItemDesc = wsD.Cells(I, 7).Text
                pItemDesc = wsD.Cells(I, 3).Text
                If ItemDesc = String.Empty Then Exit For
                ItemNo = wsD.Cells(I, 1).Text
                pItemNo = wsD.Cells(I, 2).Text
                Dim Found As Boolean = False
                Dim pFound As Boolean = False
                Dim Itm As SIS.PAK.pakCItems = Nothing
                Dim pItm As SIS.PAK.pakCItems = Nothing
                Dim HL As String = wsD.Cells(I, 4).Text
                If HL = String.Empty Then
                  wsD.Cells(I, 13).Value = "Item Can NOT be created without Header Level."
                  Continue For
                End If
                If ItemNo <> String.Empty Then
                  Itm = SIS.PAK.pakCItems.pakCItemsGetByID(ItemNo, ItemNo)
                End If
                'If Itm Is Nothing Then
                '  Itm = SIS.PAK.pakCItems.pakcItemsGetByDescription(ItemDesc)
                'End If
                If Itm Is Nothing Then
                  Found = False
                  Itm = New SIS.PAK.pakCItems
                End If
                If pItemNo <> String.Empty Then
                  pItm = SIS.PAK.pakCItems.pakCItemsGetByID(pItemNo, pItemNo)
                End If
                'If pItm Is Nothing Then
                '  pItm = SIS.PAK.pakCItems.pakcItemsGetByDescription(pItemDesc)
                'End If
                If pItm Is Nothing Then
                  pFound = False
                  pItm = New SIS.PAK.pakCItems
                End If
                If Not pFound Then
                  ps = pList.PGet(HL)
                  With pItm
                    .ItemDescription = ps.ItemDesc
                    .ItemNo = ps.ItemNo
                  End With
                  wsD.Cells(I, 2).Value = ps.ItemNo
                  wsD.Cells(I, 3).Value = ps.ItemDesc
                End If
                With Itm
                  .RootItem = oRoot.ItemNo
                  .ParentItemNo = pItm.ItemNo
                  .Active = True
                  .DivisionID = oRoot.DivisionID
                  .DocumentNo = wsD.Cells(I, 12).Text
                  If .DocumentNo <> String.Empty Then
                    Dim tmp As SIS.PAK.pakDocuments = SIS.PAK.pakDocuments.pakDocumentsGetByID(.DocumentNo)
                    If tmp Is Nothing Then
                      .DocumentNo = ""
                      wsD.Cells(I, 12).AddComment("Document ID NOT Found.", "Error")
                    End If
                  End If
                  .ElementID = wsD.Cells(I, 5).Text
                  If .ElementID <> String.Empty Then
                    Dim tmp As SIS.PAK.pakElements = SIS.PAK.pakElements.pakElementsGetByID(.ElementID)
                    If tmp Is Nothing Then
                      .ElementID = ""
                      wsD.Cells(I, 5).AddComment("Element ID NOT Found.", "Error")
                    End If
                  End If
                  .ItemCode = wsD.Cells(I, 6).Text
                  .ItemDescription = ItemDesc
                  Dim sUnit As String = wsD.Cells(I, 8).Text
                  Dim vUnit As String = ""
                  If sUnit <> "" Then
                    Dim tmpUnit As SIS.PAK.pakUnits = SIS.PAK.pakUnits.pakUnitsGetByDescription(sUnit)
                    If tmpUnit IsNot Nothing Then
                      vUnit = tmpUnit.UnitID
                    End If
                  End If
                  .UOMQuantity = vUnit
                  .Quantity = IIf(wsD.Cells(I, 9).Text = "", 0, wsD.Cells(I, 9).Text)
                  sUnit = wsD.Cells(I, 10).Text
                  vUnit = ""
                  If sUnit <> "" Then
                    Dim tmpUnit As SIS.PAK.pakUnits = SIS.PAK.pakUnits.pakUnitsGetByDescription(sUnit)
                    If tmpUnit IsNot Nothing Then
                      vUnit = tmpUnit.UnitID
                    End If
                  End If
                  .UOMWeight = vUnit
                  .WeightPerUnit = IIf(wsD.Cells(I, 11).Text = "", 0, wsD.Cells(I, 11).Text)
                End With
                If Found Then
                  Itm = SIS.PAK.pakCItems.UZ_pakCItemsUpdate(Itm)
                Else
                  Itm = SIS.PAK.pakCItems.UZ_pakCItemsInsert(Itm)
                  wsD.Cells(I, 1).Value = Itm.ItemNo
                End If
                pList.PAdd(New clsPItems.clsPStac(Itm.ItemNo, Itm.ItemDescription, HL))
              Next
            Catch ex As Exception
              Dim message As String = New JavaScriptSerializer().Serialize(ex.Message.ToString())
              Dim script As String = String.Format("alert({0});", message)
              ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", script, True)
            End Try
            xlP.Save()
            wsD.Dispose()
            xlP.Dispose()
          End Using
          Dim FileNameForUser As String = F_FileUpload.FileName
          '======================
          Response.Clear()
          Response.AppendHeader("content-disposition", "attachment; filename=" & FileNameForUser)
          Response.ContentType = SIS.SYS.Utilities.ApplicationSpacific.ContentType(FileNameForUser)
          Response.WriteFile(tmpFile)
          HttpContext.Current.Server.ScriptTimeout = st
          Response.End()
        End If
      End With
    Catch ex As Exception
      Dim message As String = New JavaScriptSerializer().Serialize(ex.Message.ToString())
      Dim script As String = String.Format("alert({0});", message)
      ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", script, True)
    End Try
over:
  End Sub

End Class
