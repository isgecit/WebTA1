Imports System.IO
Imports OfficeOpenXml
Imports System.Web.Script.Serialization

Partial Class EF_eitlPOList
  Inherits SIS.SYS.UpdateBase
  Public Property Editable As Boolean
    Get
      If ViewState("Editable") IsNot Nothing Then
        Return Convert.ToBoolean(ViewState("Editable"))
      End If
      Return False
    End Get
    Set(value As Boolean)
      ViewState.Add("Editable", value)
    End Set
  End Property
  Protected Sub cmdFileUploadBulk_Command(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.CommandEventArgs) Handles cmdFileUploadBulk.Command
    Try
      Dim tmpPath As String = ConfigurationManager.AppSettings("eitlPODocumentFile_Path")
      Dim SerialNo As Int32 = CType(FVeitlPOList.FindControl("F_SerialNo"), TextBox).Text
      If Not IO.Directory.Exists(tmpPath) Then
        tmpPath = ConfigurationManager.AppSettings("eitlPODocumentFile_Path1")
      End If
      Dim oFiles As HttpFileCollection = Request.Files
      For i As Integer = 0 To Request.Files.Count - 1
        Dim pfile As HttpPostedFile
        pfile = Request.Files.Item(i)
        If pfile.ContentLength <= 0 Then Continue For
        Dim tmpName As String = IO.Path.GetRandomFileName()
        Dim tmpFile As String = tmpPath & "\\" & tmpName
        pfile.SaveAs(tmpFile)
        Dim oAtch As SIS.EITL.eitlPODocumentFile = Nothing
        oAtch = SIS.EITL.eitlPODocumentFile.GetByPOFileName(SerialNo, pfile.FileName)
        If oAtch IsNot Nothing Then
          oAtch.DiskFile = tmpFile
          oAtch = SIS.EITL.eitlPODocumentFile.UpdateData(oAtch)
        Else
          'Create document & attach file
          Dim oDoc As New SIS.EITL.eitlPODocumentList
          With oDoc
            .SerialNo = SerialNo
            .DocumentLineNo = 0
            .DocumentID = IO.Path.GetFileNameWithoutExtension(pfile.FileName)
            .Description = pfile.FileName
            .RevisionNo = "0"
            .ReadyToDespatch = True
          End With
          oDoc = SIS.EITL.eitlPODocumentList.InsertData(oDoc)
          Dim oFil As New SIS.EITL.eitlPODocumentFile
          With oFil
            .SerialNo = SerialNo
            .DocumentLineNo = oDoc.DocumentLineNo
            .FileNo = 0
            .Description = oDoc.DocumentID
            .FileName = oDoc.Description
            .DiskFile = tmpFile
          End With
          oFil = SIS.EITL.eitlPODocumentFile.InsertData(oFil)
        End If
      Next
      GVeitlPODocumentList.DataBind()
      Response.Redirect(Request.UrlReferrer.ToString)
    Catch ex As Exception
      Dim message As String = New JavaScriptSerializer().Serialize(ex.Message.ToString())
      Dim script As String = String.Format("alert({0});", message)
      ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", script, True)
    End Try

  End Sub
  Protected Sub cmdFileUpload_Command(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.CommandEventArgs) Handles cmdFileUpload.Command
    Try
      With F_FileUpload
        If .HasFile Then
          Dim tmpPath As String = Server.MapPath("~/../App_Temp")
          Dim tmpName As String = IO.Path.GetRandomFileName()
          Dim tmpFile As String = tmpPath & "\\" & tmpName
          .SaveAs(tmpFile)
          Dim SerialNo As Int32 = CType(FVeitlPOList.FindControl("F_SerialNo"), TextBox).Text
          Dim fi As FileInfo = New FileInfo(tmpFile)
          Using xlP As ExcelPackage = New ExcelPackage(fi)
            Dim wsD As ExcelWorksheet = Nothing
            Dim wsI As ExcelWorksheet = Nothing
            Try
              wsD = xlP.Workbook.Worksheets("Document")
              wsI = xlP.Workbook.Worksheets("Item")
            Catch ex As Exception
              wsD = Nothing
            End Try
            '1. Process Document
            If wsD Is Nothing Then
              errMsg.Text = "Invalid MS-EXCEL file."
              xlP.Dispose()
              Exit Sub
              '*******
            End If
            Dim DocumentID As String = ""
            Dim Rev As String = ""
            Dim Description As String = ""
            Dim dFiles As String = ""
            Dim ItemCode As String = ""
            Dim Quantity As Double = 0
            Dim Unit As String = ""
            Dim Weight As Double = 0
            For I As Integer = 3 To 5000
              DocumentID = wsD.Cells(I, 1).Text
              If DocumentID = String.Empty Then Exit For
              Rev = wsD.Cells(I, 2).Text
              Description = wsD.Cells(I, 3).Text
              dFiles = wsD.Cells(I, 4).Text
              Dim oDoc As SIS.EITL.eitlPODocumentList = Nothing
              oDoc = SIS.EITL.eitlPODocumentList.GetByPODocumentRev(SerialNo, DocumentID, Rev)
              If oDoc IsNot Nothing Then
                With oDoc
                  .Description = Description
                End With
                oDoc = SIS.EITL.eitlPODocumentList.UpdateData(oDoc)
              Else
                oDoc = New SIS.EITL.eitlPODocumentList
                With oDoc
                  .SerialNo = SerialNo
                  .DocumentLineNo = 0
                  .DocumentID = DocumentID
                  .RevisionNo = Rev
                  .Description = Description
                  .ReadyToDespatch = True
                End With
                oDoc = SIS.EITL.eitlPODocumentList.InsertData(oDoc)
              End If
              If dFiles <> String.Empty Then
                Dim aFiles As String() = dFiles.Split(",".ToCharArray)
                For Each dFile As String In aFiles
                  Dim oFile As SIS.EITL.eitlPODocumentFile = Nothing
                  oFile = SIS.EITL.eitlPODocumentFile.GetByPODocumentLineFileName(SerialNo, oDoc.DocumentLineNo, dFile)
                  If oFile Is Nothing Then
                    oFile = New SIS.EITL.eitlPODocumentFile
                    With oFile
                      .SerialNo = SerialNo
                      .DocumentLineNo = oDoc.DocumentLineNo
                      .FileNo = 0
                      .Description = dFile
                      .FileName = dFile
                      .DiskFile = ""
                    End With
                    oFile = SIS.EITL.eitlPODocumentFile.InsertData(oFile)
                  End If
                Next
              End If
            Next 'Document Line
            '2. Process Item
            For I As Integer = 3 To 5000
              ItemCode = wsI.Cells(I, 1).Text
              If ItemCode = String.Empty Then Exit For
              Description = wsI.Cells(I, 2).Text
              Quantity = wsI.Cells(I, 3).Text
              Unit = wsI.Cells(I, 4).Text
              Weight = wsI.Cells(I, 5).Text
              DocumentID = wsI.Cells(I, 6).Text
              Rev = wsI.Cells(I, 7).Text
              Dim oItm As SIS.EITL.eitlPOItemList = Nothing
              oItm = SIS.EITL.eitlPOItemList.GetByPOItem(SerialNo, ItemCode)
              If oItm IsNot Nothing Then
                Dim oDoc As SIS.EITL.eitlPODocumentList = Nothing
                If DocumentID <> String.Empty Then
                  oDoc = SIS.EITL.eitlPODocumentList.GetByPODocumentRev(SerialNo, DocumentID, Rev)
                End If
                With oItm
                  .Description = Description
                  .UOM = Unit
                  .Quantity = Quantity
                  .WeightInKG = Weight
                  Try
                    .DocumentLineNo = IIf(oDoc IsNot Nothing, oDoc.DocumentLineNo, "")
                  Catch ex As Exception

                  End Try
                End With
                oItm = SIS.EITL.eitlPOItemList.UpdateData(oItm)
              Else
                oItm = New SIS.EITL.eitlPOItemList
                Dim oDoc As SIS.EITL.eitlPODocumentList = Nothing
                If DocumentID <> String.Empty Then
                  oDoc = SIS.EITL.eitlPODocumentList.GetByPODocumentRev(SerialNo, DocumentID, Rev)
                End If
                With oItm
                  .SerialNo = SerialNo
                  .ItemCode = ItemCode
                  .Description = Description
                  .UOM = Unit
                  .Quantity = Quantity
                  .WeightInKG = Weight
                  Try
                    .DocumentLineNo = IIf(oDoc IsNot Nothing, oDoc.DocumentLineNo, "")
                  Catch ex As Exception

                  End Try
                  .ReadyToDespatch = True
                  .ItemStatusID = 1 'Manufactured
                End With
                oItm = SIS.EITL.eitlPOItemList.InsertData(oItm)
              End If
            Next 'Item Line
            xlP.Dispose()
            GVeitlPODocumentList.DataBind()
            GVeitlPOItemList.DataBind()
          End Using
        End If
      End With
    Catch ex As Exception
      Dim message As String = New JavaScriptSerializer().Serialize(ex.Message.ToString())
      Dim script As String = String.Format("alert({0});", message)
      ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", script, True)
    End Try
over:
  End Sub
  Protected Sub FVeitlPOList_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVeitlPOList.Init
    DataClassName = "EeitlPOList"
    SetFormView = FVeitlPOList
  End Sub
  Protected Sub TBLeitlPOList_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLeitlPOList.Init
    SetToolBar = TBLeitlPOList
  End Sub
  Protected Sub FVeitlPOList_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVeitlPOList.PreRender
    TBLeitlPOList.PrintUrl &= Request.QueryString("SerialNo") & "|"
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/EITL_Main/App_Edit") & "/EF_eitlPOList.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scripteitlPOList") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scripteitlPOList", mStr)
    End If
  End Sub
  Partial Class gvBase
    Inherits SIS.SYS.GridBase
  End Class
  Private WithEvents gveitlPOItemListCC As New gvBase
  Protected Sub GVeitlPOItemList_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVeitlPOItemList.Init
    gveitlPOItemListCC.DataClassName = "GeitlPOItemList"
    gveitlPOItemListCC.SetGridView = GVeitlPOItemList
  End Sub
  Protected Sub TBLeitlPOItemList_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLeitlPOItemList.Init
    gveitlPOItemListCC.SetToolBar = TBLeitlPOItemList
  End Sub
  Protected Sub GVeitlPOItemList_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVeitlPOItemList.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim SerialNo As Int32 = GVeitlPOItemList.DataKeys(e.CommandArgument).Values("SerialNo")
        Dim ItemLineNo As Int32 = GVeitlPOItemList.DataKeys(e.CommandArgument).Values("ItemLineNo")
        Dim RedirectUrl As String = TBLeitlPOItemList.EditUrl & "?SerialNo=" & SerialNo & "&ItemLineNo=" & ItemLineNo
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
      End Try
    End If
  End Sub
  Protected Sub TBLeitlPOItemList_AddClicked(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles TBLeitlPOItemList.AddClicked
    Dim SerialNo As Int32 = CType(FVeitlPOList.FindControl("F_SerialNo"), TextBox).Text
    TBLeitlPOItemList.AddUrl &= "?SerialNo=" & SerialNo
  End Sub
  Private WithEvents gveitlPODocumentListCC As New gvBase
  Protected Sub GVeitlPODocumentList_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVeitlPODocumentList.Init
    gveitlPODocumentListCC.DataClassName = "GeitlPODocumentList"
    gveitlPODocumentListCC.SetGridView = GVeitlPODocumentList
  End Sub
  Protected Sub TBLeitlPODocumentList_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLeitlPODocumentList.Init
    gveitlPODocumentListCC.SetToolBar = TBLeitlPODocumentList
  End Sub
  Protected Sub GVeitlPODocumentList_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVeitlPODocumentList.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim SerialNo As Int32 = GVeitlPODocumentList.DataKeys(e.CommandArgument).Values("SerialNo")
        Dim DocumentLineNo As Int32 = GVeitlPODocumentList.DataKeys(e.CommandArgument).Values("DocumentLineNo")
        Dim RedirectUrl As String = TBLeitlPODocumentList.EditUrl & "?SerialNo=" & SerialNo & "&DocumentLineNo=" & DocumentLineNo
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
      End Try
    End If
  End Sub
  Protected Sub TBLeitlPODocumentList_AddClicked(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles TBLeitlPODocumentList.AddClicked
    Dim SerialNo As Int32 = CType(FVeitlPOList.FindControl("F_SerialNo"), TextBox).Text
    TBLeitlPODocumentList.AddUrl &= "&SerialNo=" & SerialNo
  End Sub
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function SupplierIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.EITL.eitlSuppliers.SelecteitlSuppliersAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function ProjectIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.QCM.qcmProjects.SelectqcmProjectsAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function BuyerIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.QCM.qcmUsers.SelectqcmUsersAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function POStatusIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.EITL.eitlPOStatus.SelecteitlPOStatusAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function IssuedByCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.QCM.qcmUsers.SelectqcmUsersAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function ClosedByCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.QCM.qcmUsers.SelectqcmUsersAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_EITL_POList_BuyerID(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String = "0|" & aVal(0)
    Dim BuyerID As String = CType(aVal(1), String)
    Dim oVar As SIS.QCM.qcmUsers = SIS.QCM.qcmUsers.qcmUsersGetByID(BuyerID)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found."
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField
    End If
    Return mRet
  End Function
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_EITL_POList_ClosedBy(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String = "0|" & aVal(0)
    Dim ClosedBy As String = CType(aVal(1), String)
    Dim oVar As SIS.QCM.qcmUsers = SIS.QCM.qcmUsers.qcmUsersGetByID(ClosedBy)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found."
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField
    End If
    Return mRet
  End Function
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_EITL_POList_IssuedBy(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String = "0|" & aVal(0)
    Dim IssuedBy As String = CType(aVal(1), String)
    Dim oVar As SIS.QCM.qcmUsers = SIS.QCM.qcmUsers.qcmUsersGetByID(IssuedBy)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found."
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField
    End If
    Return mRet
  End Function
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_EITL_POList_POStatusID(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String = "0|" & aVal(0)
    Dim POStatusID As Int32 = CType(aVal(1), Int32)
    Dim oVar As SIS.EITL.eitlPOStatus = SIS.EITL.eitlPOStatus.eitlPOStatusGetByID(POStatusID)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found."
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField
    End If
    Return mRet
  End Function
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_EITL_POList_SupplierID(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String = "0|" & aVal(0)
    Dim SupplierID As String = CType(aVal(1), String)
    Dim oVar As SIS.EITL.eitlSuppliers = SIS.EITL.eitlSuppliers.eitlSuppliersGetByID(SupplierID)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found."
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField
    End If
    Return mRet
  End Function
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_EITL_POList_ProjectID(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String = "0|" & aVal(0)
    Dim ProjectID As String = CType(aVal(1), String)
    Dim oVar As SIS.QCM.qcmProjects = SIS.QCM.qcmProjects.qcmProjectsGetByID(ProjectID)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found."
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField
    End If
    Return mRet
  End Function

  Protected Sub Page_PreRender(sender As Object, e As System.EventArgs) Handles Me.PreRender
    CType(Me.Master, lgMasterPage).SetEncType = ""
  End Sub
  Protected Sub ODSeitlPOList_Selected(sender As Object, e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODSeitlPOList.Selected
    Dim oPO As SIS.EITL.eitlPOList = CType(e.ReturnValue, SIS.EITL.eitlPOList)
    If oPO.POStatusID = 4 Or oPO.POStatusID = 5 Then
      Me.Editable = False
    Else
      Me.Editable = True
    End If
  End Sub
End Class
