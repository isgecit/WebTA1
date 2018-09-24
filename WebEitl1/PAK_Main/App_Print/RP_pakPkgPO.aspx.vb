Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports OfficeOpenXml
Imports System.Web.Script.Serialization
Partial Class RP_pakPkgPO
  Inherits System.Web.UI.Page
  Private st As Long = HttpContext.Current.Server.ScriptTimeout
  Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    HttpContext.Current.Server.ScriptTimeout = Integer.MaxValue
    Dim Value As String = ""
    If Request.QueryString("pkg") IsNot Nothing Then
      Value = Request.QueryString("pkg")
      'DownloadTmplForPkg(Value)
      Dim SerialNo As String = ""
      Dim PkgNo As String = ""
      Dim aVal() As String = Value.Split("|".ToCharArray)

      Try
        SerialNo = aVal(0)
        PkgNo = aVal(1)
      Catch ex As Exception
      End Try

      Dim FileName As String = SIS.PAK.pakPkgPO.DownloadTmplForPkg(Value)
      Response.Clear()
      Response.AppendHeader("content-disposition", "attachment; filename=PrintPkg_" & SerialNo & "_" & PkgNo & ".xlsx")
      Response.ContentType = SIS.SYS.Utilities.ApplicationSpacific.ContentType("abcd.xlsx")
      Response.WriteFile(FileName)
      HttpContext.Current.Server.ScriptTimeout = st
      Response.End()
    End If
  End Sub

  '#Region " TMPL FOR PKG "

  '  Private Sub DownloadTmplForPkg(ByVal Value As String)

  '    Dim aVal() As String = Value.Split("|".ToCharArray)

  '    Dim SerialNo As String = ""
  '    Dim PkgNo As String = ""

  '    Try
  '      SerialNo = aVal(0)
  '      PkgNo = aVal(1)
  '    Catch ex As Exception
  '    End Try

  '    If PkgNo = String.Empty Then
  '      ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize("Package No is required for Template download.") & "');", True)
  '      HttpContext.Current.Server.ScriptTimeout = st
  '      Exit Sub
  '    End If

  '    Dim TemplateName As String = "PackingList_TEMPLATE.xlsx"

  '    Dim tmpFile As String = Server.MapPath("~/App_Templates/" & TemplateName)
  '    If IO.File.Exists(tmpFile) Then
  '      Dim FileName As String = Server.MapPath("~/..") & "App_Temp/" & Guid.NewGuid().ToString()
  '      IO.File.Copy(tmpFile, FileName)
  '      Dim FileInfo As IO.FileInfo = New IO.FileInfo(FileName)
  '      Dim xlPk As ExcelPackage = New ExcelPackage(FileInfo)

  '      '1.
  '      Dim xlWS As ExcelWorksheet = xlPk.Workbook.Worksheets("Packing List")
  '      Dim r As Integer = 1
  '      Dim c As Integer = 1
  '      Dim cnt As Integer = 1

  '      '1. Header
  '      Dim tmpPO As SIS.PAK.pakPkgPO = SIS.PAK.pakPkgPO.pakPkgPOGetByID(SerialNo)
  '      Dim tmpPkg As SIS.PAK.pakPkgListH = SIS.PAK.pakPkgListH.pakPkgListHGetByID(SerialNo, PkgNo)
  '      With xlWS
  '        .Cells(2, 4).Value = SerialNo
  '        .Cells(3, 4).Value = PkgNo
  '        .Cells(4, 4).Value = "'" & Convert.ToDateTime(tmpPkg.CreatedOn).ToString("dd/MM/yyyy")
  '        .Cells(5, 4).Value = tmpPO.ProjectID & " - " & tmpPO.IDM_Projects4_Description
  '        .Cells(6, 4).Value = tmpPO.PONumber
  '        .Cells(7, 4).Value = tmpPkg.TotalWeight

  '        .Cells(2, 12).Value = tmpPO.SupplierID & " - " & tmpPO.VR_BusinessPartner9_BPName
  '        .Cells(3, 12).Value = tmpPkg.SupplierRefNo
  '        .Cells(4, 12).Value = IIf(tmpPkg.TransporterID <> "", tmpPkg.VR_BusinessPartner4_BPName, tmpPkg.TransporterName)
  '        .Cells(5, 12).Value = tmpPkg.VehicleNo
  '        .Cells(6, 12).Value = tmpPkg.GRNo
  '        .Cells(7, 12).Value = "'" & Convert.ToDateTime(tmpPkg.GRDate).ToString("dd/MM/yyyy")
  '      End With

  '      '2. Data
  '      r = 11
  '      c = 1

  '      Dim PkgItems As List(Of SIS.PAK.pakPkgListD) = SIS.PAK.pakPkgListD.pakPkgListDSelectList(0, 99999, "", False, "", PkgNo, SerialNo)

  '      For Each tmp As SIS.PAK.pakPkgListD In PkgItems
  '        With xlWS
  '          c = 1
  '          .Cells(r, c).Value = cnt
  '          c += 1
  '          .Cells(r, c).Value = tmp.ItemNo
  '          c += 1
  '          .Cells(r, c).Value = tmp.FK_PAK_PkgListD_ItemNo.ItemCode
  '          c += 1
  '          .Cells(r, c).Value = tmp.FK_PAK_PkgListD_ItemNo.ItemDescription
  '          c += 1
  '          If tmp.UOMQuantity <> "" Then .Cells(r, c).Value = tmp.FK_PAK_PkgListD_UOMQuantity.Description
  '          c += 1
  '          .Cells(r, c).Value = tmp.Quantity
  '          c += 1
  '          If tmp.UOMWeight <> "" Then .Cells(r, c).Value = tmp.FK_PAK_PkgListD_UOMWeight.Description
  '          c += 1
  '          .Cells(r, c).Value = tmp.WeightPerUnit
  '          c += 1
  '          .Cells(r, c).Value = (tmp.Quantity * tmp.WeightPerUnit).ToString("n")
  '          c += 1
  '          .Cells(r, c).Value = tmp.DocumentNo
  '          c += 1
  '          .Cells(r, c).Value = tmp.DocumentRevision
  '          c += 1
  '          .Cells(r, c).Value = tmp.PAK_PakTypes1_Description
  '          c += 1
  '          .Cells(r, c).Value = tmp.PackingMark
  '          c += 1
  '          .Cells(r, c).Value = tmp.PackLength
  '          c += 1
  '          .Cells(r, c).Value = tmp.PackWidth
  '          c += 1
  '          .Cells(r, c).Value = tmp.PackHeight
  '          c += 1
  '          .Cells(r, c).Value = tmp.PAK_Units8_Description
  '          c += 1

  '          cnt += 1
  '          r += 1
  '        End With
  '      Next

  '      xlPk.Save()
  '      xlPk.Dispose()

  '      Response.Clear()
  '      Response.AppendHeader("content-disposition", "attachment; filename=PrintPkg_" & SerialNo & "_" & PkgNo & ".xlsx")
  '      Response.ContentType = SIS.SYS.Utilities.ApplicationSpacific.ContentType(TemplateName)
  '      Response.WriteFile(FileName)
  '      HttpContext.Current.Server.ScriptTimeout = st
  '      Response.End()
  '    End If
  '  End Sub

  '#End Region
End Class