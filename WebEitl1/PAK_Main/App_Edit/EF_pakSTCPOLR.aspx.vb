Imports OfficeOpenXml
Imports System.Web.Script.Serialization
Imports System.IO
Partial Class EF_pakSTCPOLR
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
  Protected Sub ODSpakSTCPOLR_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODSpakSTCPOLR.Selected
    Dim tmp As SIS.PAK.pakSTCPOLR = CType(e.ReturnValue, SIS.PAK.pakSTCPOLR)
    Editable = tmp.Editable
    Deleteable = tmp.Deleteable
    PrimaryKey = tmp.PrimaryKey
  End Sub
  Protected Sub FVpakSTCPOLR_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpakSTCPOLR.Init
    DataClassName = "EpakSTCPOLR"
    SetFormView = FVpakSTCPOLR
  End Sub
  Protected Sub TBLpakSTCPOLR_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLpakSTCPOLR.Init
    SetToolBar = TBLpakSTCPOLR
  End Sub
  Protected Sub FVpakSTCPOLR_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpakSTCPOLR.PreRender
    TBLpakSTCPOLR.EnableSave = Editable
    TBLpakSTCPOLR.EnableDelete = Deleteable
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/PAK_Main/App_Edit") & "/EF_pakSTCPOLR.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptpakSTCPOLR") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptpakSTCPOLR", mStr)
    End If
  End Sub
  Partial Class gvBase
    Inherits SIS.SYS.GridBase
  End Class
  Private WithEvents gvpakSTCPOLRDCC As New gvBase
  Protected Sub GVpakSTCPOLRD_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVpakSTCPOLRD.Init
    gvpakSTCPOLRDCC.DataClassName = "GpakSTCPOLRD"
    gvpakSTCPOLRDCC.SetGridView = GVpakSTCPOLRD
  End Sub
  Protected Sub TBLpakSTCPOLRD_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLpakSTCPOLRD.Init
    gvpakSTCPOLRDCC.SetToolBar = TBLpakSTCPOLRD
  End Sub
  Protected Sub GVpakSTCPOLRD_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVpakSTCPOLRD.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim SerialNo As Int32 = GVpakSTCPOLRD.DataKeys(e.CommandArgument).Values("SerialNo")
        Dim ItemNo As Int32 = GVpakSTCPOLRD.DataKeys(e.CommandArgument).Values("ItemNo")
        Dim UploadNo As Int32 = GVpakSTCPOLRD.DataKeys(e.CommandArgument).Values("UploadNo")
        Dim DocSerialNo As Int32 = GVpakSTCPOLRD.DataKeys(e.CommandArgument).Values("DocSerialNo")
        Dim RedirectUrl As String = TBLpakSTCPOLRD.EditUrl & "?SerialNo=" & SerialNo & "&ItemNo=" & ItemNo & "&UploadNo=" & UploadNo & "&DocSerialNo=" & DocSerialNo
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
      End Try
    End If
  End Sub
  Protected Sub TBLpakSTCPOLRD_AddClicked(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles TBLpakSTCPOLRD.AddClicked
    Dim SerialNo As Int32 = CType(FVpakSTCPOLR.FindControl("F_SerialNo"), TextBox).Text
    Dim ItemNo As Int32 = CType(FVpakSTCPOLR.FindControl("F_ItemNo"), TextBox).Text
    Dim UploadNo As Int32 = CType(FVpakSTCPOLR.FindControl("F_UploadNo"), TextBox).Text
    TBLpakSTCPOLRD.AddUrl &= "?SerialNo=" & SerialNo
    TBLpakSTCPOLRD.AddUrl &= "&ItemNo=" & ItemNo
    TBLpakSTCPOLRD.AddUrl &= "&UploadNo=" & UploadNo
  End Sub

  'Private Sub FVpakSTCPOLR_ItemCommand(sender As Object, e As FormViewCommandEventArgs) Handles FVpakSTCPOLR.ItemCommand
  '  If e.CommandName.ToLower = "tmplupload" Then
  '    Try
  '      Dim aVal() As String = e.CommandArgument.ToString.Split("|".ToCharArray)
  '      Dim SerialNo As String = aVal(0)
  '      Dim ItemNo As String = aVal(1)
  '      Dim UploadNo As String = aVal(2)
  '      With F_FileUpload
  '        If .HasFile Then
  '          Dim tmpPath As String = Server.MapPath("~/../App_Temp")
  '          Dim tmpName As String = IO.Path.GetRandomFileName()
  '          Dim tmpFile As String = tmpPath & "\\" & tmpName
  '          .SaveAs(tmpFile)
  '          Dim fi As FileInfo = New FileInfo(tmpFile)
  '          Dim IsError As Boolean = False
  '          Using xlP As ExcelPackage = New ExcelPackage(fi)
  '            Dim wsD As ExcelWorksheet = Nothing
  '            Try
  '              wsD = xlP.Workbook.Worksheets("Data")
  '            Catch ex As Exception
  '              wsD = Nothing
  '            End Try
  '            '1. Process Document
  '            If wsD Is Nothing Then
  '              ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize("Invalid XL File") & "');", True)
  '              xlP.Dispose()
  '              Exit Sub
  '              '*******
  '            End If
  '            Dim tmpSerialNo As String = wsD.Cells(1, 2).Text
  '            Dim tmpItemNo As String = wsD.Cells(2, 2).Text
  '            Dim tmpUploadNo As String = wsD.Cells(3, 2).Text

  '            If SerialNo <> tmpSerialNo OrElse ItemNo <> tmpItemNo OrElse UploadNo <> tmpUploadNo Then
  '              ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize("Wrong SerialNo/ItemNo/Upload No.") & "');", True)
  '              xlP.Dispose()
  '              Exit Sub
  '              '*******
  '            End If
  '            Dim DocSerialNo As String = ""
  '            Dim DocumentID As String = ""
  '            Dim Rev As String = ""
  '            Dim Description As String = ""
  '            Dim FileName As String = ""
  '            For I As Integer = 7 To 5000
  '              DocSerialNo = wsD.Cells(I, 1).Text
  '              DocumentID = wsD.Cells(I, 2).Text
  '              Rev = wsD.Cells(I, 3).Text
  '              Description = wsD.Cells(I, 4).Text
  '              FileName = wsD.Cells(I, 5).Text
  '              If DocumentID = String.Empty Then Exit For
  '              If Rev = String.Empty Then
  '                IsError = True
  '                wsD.Cells(I, 6).Value = "Rev. No is required."
  '                Continue For
  '              End If
  '              If FileName = String.Empty Then
  '                IsError = True
  '                wsD.Cells(I, 6).Value = "File Name is required."
  '                Continue For
  '              End If
  '              Dim oDoc As SIS.PAK.pakSTCPOLRD = Nothing
  '              If DocSerialNo = "" Then DocSerialNo = 0
  '              oDoc = SIS.PAK.pakSTCPOLRD.pakSTCPOLRDGetByID(SerialNo, ItemNo, UploadNo, DocSerialNo)
  '              If oDoc IsNot Nothing Then
  '                With oDoc
  '                  .DocumentID = DocumentID
  '                  .DocumentRev = Rev
  '                  .DocumentDescription = Description
  '                  .FileName = FileName
  '                End With
  '                oDoc = SIS.PAK.pakSTCPOLRD.UpdateData(oDoc)
  '              Else
  '                oDoc = New SIS.PAK.pakSTCPOLRD
  '                With oDoc
  '                  .SerialNo = SerialNo
  '                  .ItemNo = ItemNo
  '                  .UploadNo = UploadNo
  '                  .DocSerialNo = 0
  '                  .DocumentID = DocumentID
  '                  .DocumentRev = Rev
  '                  .DocumentDescription = Description
  '                  .FileName = FileName
  '                End With
  '                oDoc = SIS.PAK.pakSTCPOLRD.InsertData(oDoc)
  '              End If
  '            Next 'Document Line
  '            xlP.Dispose()
  '            If IsError Then
  '              ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize("Rev.No / File Name are mandatory, records with blank fields are not updated.") & "');", True)
  '            Else
  '              ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize("Updated") & "');", True)
  '            End If
  '            GVpakSTCPOLRD.DataBind()
  '          End Using
  '        End If
  '      End With
  '    Catch ex As Exception
  '      ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
  '    End Try
  '  End If
  '  If e.CommandName.ToLower = "filesupload" Then
  '    Try
  '      If SIS.PAK.pakSTCPOLR.AddRequestFiles(Request, e.CommandArgument.ToString) Then
  '        GVpakSTCPOLRD.DataBind()
  '        Response.Redirect(Request.UrlReferrer.ToString)
  '      End If
  '    Catch ex As Exception
  '      ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
  '    End Try
  '  End If
  'End Sub
End Class
