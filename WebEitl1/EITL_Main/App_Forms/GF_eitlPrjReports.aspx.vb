Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Imports OfficeOpenXml
Partial Class GF_eitlPrjReports
  Inherits SIS.SYS.GridBase
  Protected Sub TBLeitlPrjReports_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLeitlPrjReports.Init
    SetToolBar = TBLeitlPrjReports
  End Sub
  <System.Web.Services.WebMethod()> _
 <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function ProjectIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.QCM.qcmProjects.SelectqcmProjectsAutoCompleteList(prefixText, count, contextKey)
  End Function
  Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
    F_ProjectID_Display.Text = String.Empty
    If Not Session("F_ProjectID_Display") Is Nothing Then
      If Session("F_ProjectID_Display") <> String.Empty Then
        F_ProjectID_Display.Text = Session("F_ProjectID_Display")
      End If
    End If
    F_ProjectID.Text = String.Empty
    If Not Session("F_ProjectID") Is Nothing Then
      If Session("F_ProjectID") <> String.Empty Then
        F_ProjectID.Text = Session("F_ProjectID")
      End If
    End If
    Dim strScriptProjectID As String = "<script type=""text/javascript""> " & _
     "function ACEProjectID_Selected(sender, e) {" & _
     "  var F_ProjectID = $get('" & F_ProjectID.ClientID & "');" & _
     "  var F_ProjectID_Display = $get('" & F_ProjectID_Display.ClientID & "');" & _
     "  var retval = e.get_value();" & _
     "  var p = retval.split('|');" & _
     "  F_ProjectID.value = p[0];" & _
     "  F_ProjectID_Display.innerHTML = e.get_text();" & _
     "}" & _
     "</script>"
    If Not Page.ClientScript.IsClientScriptBlockRegistered("F_ProjectID") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_ProjectID", strScriptProjectID)
    End If
    Dim strScriptPopulatingProjectID As String = "<script type=""text/javascript""> " & _
     "function ACEProjectID_Populating(o,e) {" & _
     "  var p = $get('" & F_ProjectID.ClientID & "');" & _
     "  p.style.backgroundImage  = 'url(../../images/loader.gif)';" & _
     "  p.style.backgroundRepeat= 'no-repeat';" & _
     "  p.style.backgroundPosition = 'right';" & _
     "  o._contextKey = '';" & _
     "}" & _
     "function ACEProjectID_Populated(o,e) {" & _
     "  var p = $get('" & F_ProjectID.ClientID & "');" & _
     "  p.style.backgroundImage  = 'none';" & _
     "}" & _
     "</script>"
    If Not Page.ClientScript.IsClientScriptBlockRegistered("F_ProjectIDPopulating") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_ProjectIDPopulating", strScriptPopulatingProjectID)
    End If

    Dim validateScriptProjectID As String = "<script type=""text/javascript"">" & _
     "  function validate_ProjectID(o) {" & _
     "    validated_FK_EITL_POList_ProjectID_main = true;" & _
     "    validate_FK_EITL_POList_ProjectID(o);" & _
     "  }" & _
      "</script>"
    If Not Page.ClientScript.IsClientScriptBlockRegistered("validateProjectID") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateProjectID", validateScriptProjectID)
    End If

    Dim validateScriptFK_EITL_POList_ProjectID As String = "<script type=""text/javascript"">" & _
     "  function validate_FK_EITL_POList_ProjectID(o) {" & _
     "    var value = o.id;" & _
     "    var ProjectID = $get('" & F_ProjectID.ClientID & "');" & _
     "    try{" & _
     "    if(ProjectID.value==''){" & _
     "      if(validated_FK_EITL_POList_ProjectID.main){" & _
     "        var o_d = $get(o.id +'_Display');" & _
     "        try{o_d.innerHTML = '';}catch(ex){}" & _
     "      }" & _
     "    }" & _
     "    value = value + ',' + ProjectID.value ;" & _
     "    }catch(ex){}" & _
     "    o.style.backgroundImage  = 'url(../../images/pkloader.gif)';" & _
     "    o.style.backgroundRepeat= 'no-repeat';" & _
     "    o.style.backgroundPosition = 'right';" & _
     "    PageMethods.validate_FK_EITL_POList_ProjectID(value, validated_FK_EITL_POList_ProjectID);" & _
     "  }" & _
     "  validated_FK_EITL_POList_ProjectID_main = false;" & _
     "  function validated_FK_EITL_POList_ProjectID(result) {" & _
     "    var p = result.split('|');" & _
     "    var o = $get(p[1]);" & _
     "    var o_d = $get(p[1]+'_Display');" & _
     "    try{o_d.innerHTML = p[2];}catch(ex){}" & _
     "    o.style.backgroundImage  = 'none';" & _
     "    if(p[0]=='1'){" & _
     "      o.value='';" & _
     "      try{o_d.innerHTML = '';}catch(ex){}" & _
     "      //__doPostBack(o.id, o.value);" & _
     "    }" & _
     "    else" & _
     "      //__doPostBack(o.id, o.value);" & _
     "  }" & _
      "</script>"
    If Not Page.ClientScript.IsClientScriptBlockRegistered("validateFK_EITL_POList_ProjectID") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateFK_EITL_POList_ProjectID", validateScriptFK_EITL_POList_ProjectID)
    End If
  End Sub
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

  Protected Sub cmdGenerateDocument_Click(sender As Object, e As System.EventArgs) Handles cmdGenerateDocument.Click
    Dim fPrj As String = F_ProjectID.Text
    If fPrj = "" Then Exit Sub

    Dim FilePath As String = CreateDocumentFile(fPrj)
    Dim FileNameForUser As String = "ErectionDocument_" & fPrj & "_" & Now.ToString("dd-MM-yyyy") & ".xlsx"
    If IO.File.Exists(FilePath) Then
      Response.Clear()
      Response.AppendHeader("content-disposition", "attachment; filename=" & FileNameForUser & """")
      Response.ContentType = SIS.SYS.Utilities.ApplicationSpacific.ContentType(FileNameForUser)
      Response.WriteFile(FilePath)
      Response.End()
      Try
        IO.File.Delete(FilePath)
      Catch ex As Exception
      End Try
    End If
  End Sub
  Private Function CreateDocumentFile(ByVal fprj As String) As String
    Dim FileName As String = Server.MapPath("~/..") & "App_Temp\" & Guid.NewGuid().ToString()
    IO.File.Copy(Server.MapPath("~/App_Templates") & "\ErectionDocumentList_Template.xlsx", FileName)
    Dim FileInfo As IO.FileInfo = New IO.FileInfo(FileName)
    Dim xlPk As ExcelPackage = New ExcelPackage(FileInfo)
    Dim xlWS As ExcelWorksheet = xlPk.Workbook.Worksheets("ErectionDocumentList")

    Dim oRqs As List(Of SIS.EITL.eitlPODocumentList) = SIS.EITL.eitlPODocumentList.eitlDocumentsByProjectID(fprj)
    Dim oPrj As SIS.EITL.eitlProjects = SIS.EITL.eitlProjects.eitlProjectsGetByID(oRqs(0).FK_EITL_PODocumentList_SerialNo.ProjectID)
    Dim r As Integer = 9
    Dim c As Integer = 1
    Dim cnt As Integer = 1
    With xlWS
      'HEADINGS
      .Cells(4, 3).Value = oPrj.EITL_Suppliers1_SupplierName
      .Cells(5, 3).Value = oRqs(0).FK_EITL_PODocumentList_SerialNo.IDM_Projects6_Description & " " & oRqs(0).FK_EITL_PODocumentList_SerialNo.ProjectID
      .Cells(6, 3).Value = "Document ID"
      .Cells(2, 5).Value = "Prepared By"
      .Cells(3, 5).Value = "Checked By"
      .Cells(4, 5).Value = "revision"
      .Cells(5, 5).Value = Now.ToString("dd/MM/yyyy")
      For Each rq As SIS.EITL.eitlPODocumentList In oRqs
        On Error Resume Next
        If r > 9 Then xlWS.InsertRow(r, 1, r + 1)
        c = 1
        .Cells(r, c).Value = cnt
        c += 1
        .Cells(r, c).Value = rq.DocumentID
        c += 1
        .Cells(r, c).Value = rq.Description
        c += 1
        .Cells(r, c).Value = rq.RevisionNo
        r += 1
        cnt += 1
      Next
    End With
    xlPk.Save()
    xlPk.Dispose()
    Return FileName
  End Function
  Protected Sub cmdGenerateItem_Click(sender As Object, e As System.EventArgs) Handles cmdGenerateItem.Click
    Dim fPrj As String = F_ProjectID.Text
    If fPrj = "" Then Exit Sub

    Dim FilePath As String = CreateItemFile(fPrj)
    Dim FileNameForUser As String = "ErectionItem_" & fPrj & "_" & Now.ToString("dd-MM-yyyy") & ".xlsx"
    If IO.File.Exists(FilePath) Then
      Response.Clear()
      Response.AppendHeader("content-disposition", "attachment; filename=" & FileNameForUser & """")
      Response.ContentType = SIS.SYS.Utilities.ApplicationSpacific.ContentType(FileNameForUser)
      Response.WriteFile(FilePath)
      Response.End()
      Try
        IO.File.Delete(FilePath)
      Catch ex As Exception
      End Try
    End If
  End Sub
  Private Function CreateItemFile(ByVal fprj As String) As String
    Dim FileName As String = Server.MapPath("~/..") & "App_Temp\" & Guid.NewGuid().ToString()
    IO.File.Copy(Server.MapPath("~/App_Templates") & "\ErectionItemList_Template.xlsx", FileName)
    Dim FileInfo As IO.FileInfo = New IO.FileInfo(FileName)
    Dim xlPk As ExcelPackage = New ExcelPackage(FileInfo)
    Dim xlWS As ExcelWorksheet = xlPk.Workbook.Worksheets("ErectionItemList")

    Dim oRqs As List(Of SIS.EITL.eitlPOItemList) = SIS.EITL.eitlPOItemList.eitlPOItemByProjectID(fprj)
    Dim oPrj As SIS.EITL.eitlProjects = SIS.EITL.eitlProjects.eitlProjectsGetByID(oRqs(0).FK_EITL_POItemList_SerialNo.ProjectID)

    Dim r As Integer = 9
    Dim c As Integer = 1
    Dim cnt As Integer = 1
    With xlWS
      'HEADINGS
      .Cells(4, 3).Value = oPrj.EITL_Suppliers1_SupplierName
      .Cells(5, 3).Value = oRqs(0).FK_EITL_POItemList_SerialNo.IDM_Projects6_Description
      .Cells(6, 3).Value = "Document ID"
      .Cells(2, 8).Value = "Prepared By"
      .Cells(3, 8).Value = "Checked By"
      .Cells(4, 8).Value = "revision"
      .Cells(5, 8).Value = Now.ToString("dd/MM/yyyy")
      For Each rq As SIS.EITL.eitlPOItemList In oRqs
        On Error Resume Next
        If r > 9 Then xlWS.InsertRow(r, 1, r + 1)
        c = 1
        .Cells(r, c).Value = cnt
        c += 1
        .Cells(r, c).Value = rq.ItemCode
        c += 1
        .Cells(r, c).Value = rq.Description
        c += 1
        .Cells(r, c).Value = rq.UOM
        c += 1
        .Cells(r, c).Value = rq.Quantity

        c += 1
        .Cells(r, c).Value = rq.WeightInKG

        c += 1
        If rq.DocumentLineNo <> String.Empty Then
          .Cells(r, c).Value = rq.FK_EITL_POItemList_DocumentLineNo.DocumentID
        End If

        'Remarks
        c += 1

        c += 1
        .Cells(r, c).Value = rq.FK_EITL_POItemList_SerialNo.PONumber

        c += 1
        .Cells(r, c).Value = rq.FK_EITL_POItemList_SerialNo.EITL_Suppliers5_SupplierName

        r += 1
        cnt += 1
      Next
    End With
    xlPk.Save()
    xlPk.Dispose()
    Return FileName
  End Function
End Class
