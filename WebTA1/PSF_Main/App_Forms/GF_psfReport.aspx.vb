Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Imports OfficeOpenXml
Partial Class AF_psfReport
  Inherits SIS.SYS.InsertBase
  Protected Sub FVpsfReport_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpsfReport.Init
    DataClassName = "ApsfReport"
    SetFormView = FVpsfReport
  End Sub
  Protected Sub TBLpsfReport_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLpsfReport.Init
    SetToolBar = TBLpsfReport
  End Sub
  Protected Sub FVpsfReport_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpsfReport.DataBound
    SIS.PSF.psfReport.SetDefaultValues(sender, e)
  End Sub
  Protected Sub FVpsfReport_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpsfReport.PreRender
    Dim oF_FSupplierCode_Display As Label = FVpsfReport.FindControl("F_FSupplierCode_Display")
    Dim oF_FSupplierCode As TextBox = FVpsfReport.FindControl("F_FSupplierCode")
    Dim oF_TSupplierCode_Display As Label = FVpsfReport.FindControl("F_TSupplierCode_Display")
    Dim oF_TSupplierCode As TextBox = FVpsfReport.FindControl("F_TSupplierCode")
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/PSF_Main/App_Forms") & "/GF_psfReport.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptpsfReport") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptpsfReport", mStr)
    End If
    If Request.QueryString("SerialNo") IsNot Nothing Then
      CType(FVpsfReport.FindControl("F_SerialNo"), TextBox).Text = Request.QueryString("SerialNo")
      CType(FVpsfReport.FindControl("F_SerialNo"), TextBox).Enabled = False
    End If
  End Sub
  <System.Web.Services.WebMethod()>
  <System.Web.Script.Services.ScriptMethod()>
  Public Shared Function FSupplierCodeCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.PSF.psfSupplier.SelectpsfSupplierAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()>
  <System.Web.Script.Services.ScriptMethod()>
  Public Shared Function TSupplierCodeCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.PSF.psfSupplier.SelectpsfSupplierAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()>
  Public Shared Function validate_FK_PSF_HSBCMain_FSupplierID(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String = "0|" & aVal(0)
    Dim FSupplierCode As String = CType(aVal(1), String)
    Dim oVar As SIS.PSF.psfSupplier = SIS.PSF.psfSupplier.psfSupplierGetByID(FSupplierCode)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found."
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField
    End If
    Return mRet
  End Function
  <System.Web.Services.WebMethod()>
  Public Shared Function validate_FK_PSF_HSBCMain_TSupplierID(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String = "0|" & aVal(0)
    Dim TSupplierCode As String = CType(aVal(1), String)
    Dim oVar As SIS.PSF.psfSupplier = SIS.PSF.psfSupplier.psfSupplierGetByID(TSupplierCode)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found."
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField
    End If
    Return mRet
  End Function
  Private Sub FVpsfReport_ItemInserting(sender As Object, e As FormViewInsertEventArgs) Handles FVpsfReport.ItemInserting
    Dim o As New SIS.PSF.psfReport
    With o
      .FBankVoucherDate = e.Values("FBankVoucherDate")
      .FOurRefNo = e.Values("FOurRefNo")
      .FSupplierCode = e.Values("FSupplierCode")
      .FIRN = e.Values("FIRN")
      .FDueDate = e.Values("FDueDate")
      .FHSBCToVendor = e.Values("FHSBCToVendor")
      .FPaymentDateToBank = e.Values("FPaymentDateToBank")
      .TBankVoucherDate = e.Values("TBankVoucherDate")
      .TOurRefNo = e.Values("TOurRefNo")
      .TSupplierCode = e.Values("TSupplierCode")
      .TIRN = e.Values("TIRN")
      .TDueDate = e.Values("TDueDate")
      .THSBCToVendor = e.Values("THSBCToVendor")
      .TPaymentDateToBank = e.Values("TPaymentDateToBank")
    End With
    e.Cancel = True
    Dim DWFile As String = "PSFReport_" & Now.Minute & "_" & Now.Second
    Dim FilePath As String = CreateReport(o)
    Response.ClearContent()
    Response.AppendHeader("content-disposition", "attachment; filename=" & DWFile & ".xlsx")
    Response.ContentType = SIS.SYS.Utilities.ApplicationSpacific.ContentType(IO.Path.GetFileName(FilePath))
    Response.WriteFile(FilePath)
    Response.End()
  End Sub
  Private Function CreateReport(ByVal o As SIS.PSF.psfReport) As String
    Dim FileName As String = Server.MapPath("~/..") & "App_Temp\" & Guid.NewGuid().ToString()
    IO.File.Copy(Server.MapPath("~/App_Templates") & "\PSFReport_Template.xlsx", FileName)
    Dim FileInfo As IO.FileInfo = New IO.FileInfo(FileName)
    Dim xlPk As ExcelPackage = New ExcelPackage(FileInfo)
    Dim xlWS As ExcelWorksheet = xlPk.Workbook.Worksheets("Report")

    Dim r As Integer = 5
    Dim c As Integer = 1

    Dim aFld() As String
    ReDim aFld(0)
    Do While xlWS.Cells(r, c).Text <> String.Empty
      ReDim Preserve aFld(c - 1)
      aFld(c - 1) = xlWS.Cells(r, c).Text
      c += 1
    Loop
    Dim oDocs As List(Of SIS.PSF.psfCreation) = GetData(o)
    With xlWS
      .Cells(2, 2).Value = o.FOurRefNo
      .Cells(2, 4).Value = o.TOurRefNo

      For Each doc As SIS.PSF.psfCreation In oDocs
        If r > 5 Then xlWS.InsertRow(r, 1, r + 1)
        For c = 0 To aFld.Length
          Try
            Dim aTmp() As String = aFld(c).Split(".".ToCharArray)
            If aTmp.Length > 1 Then
              Dim oBj As Object = CallByName(doc, aTmp(0), CallType.Get)
              .Cells(r, c + 1).Value = CallByName(oBj, aTmp(1), CallType.Get)
            Else
              .Cells(r, c + 1).Value = CallByName(doc, aFld(c), CallType.Get)
            End If
          Catch ex As Exception
          End Try
        Next
        r += 1
      Next
    End With
    xlPk.Save()
    xlPk.Dispose()
    Return FileName
  End Function

  Private Function GetData(Record As SIS.PSF.psfReport) As List(Of SIS.PSF.psfCreation)
    'BankName
    'BranchAddress
    'BankAccountNo
    'IFSCCode

    Dim Sql As String = ""
    Sql &= " SELECT                                                               "
    Sql &= "    [PSF_HSBCMain].* ,                                                "
    Sql &= "    [HRM_Employees1].[EmployeeName] AS HRM_Employees1_EmployeeName,   "
    Sql &= "    [HRM_Employees2].[EmployeeName] AS HRM_Employees2_EmployeeName,   "
    Sql &= "    [HRM_Employees3].[EmployeeName] AS HRM_Employees3_EmployeeName,   "
    Sql &= "    [PSF_Status4].[Description] AS PSF_Status4_Description,           "
    Sql &= "    [PSF_Supplier5].[SupplierName] AS PSF_Supplier5_SupplierName       "
    'Sql &= "    [PSF_Supplier5].[BankName] AS BankName,      "
    'Sql &= "    [PSF_Supplier5].[BranchAddress] AS BranchAddress,      "
    'Sql &= "    [PSF_Supplier5].[BankAccountNo] AS BankAccountNo,      "
    'Sql &= "    [PSF_Supplier5].[IFSCCode] AS IFSCCode      "
    Sql &= "  FROM [PSF_HSBCMain]                                                 "
    Sql &= "  LEFT OUTER JOIN [HRM_Employees] AS [HRM_Employees1]                 "
    Sql &= "    ON [PSF_HSBCMain].[CreatedBy] = [HRM_Employees1].[CardNo]         "
    Sql &= "  LEFT OUTER JOIN [HRM_Employees] AS [HRM_Employees2]                 "
    Sql &= "    ON [PSF_HSBCMain].[ApprovedBy] = [HRM_Employees2].[CardNo]        "
    Sql &= "  LEFT OUTER JOIN [HRM_Employees] AS [HRM_Employees3]                 "
    Sql &= "    ON [PSF_HSBCMain].[ModifiedBy] = [HRM_Employees3].[CardNo]        "
    Sql &= "  INNER JOIN [PSF_Status] AS [PSF_Status4]                            "
    Sql &= "    ON [PSF_HSBCMain].[PSFStatus] = [PSF_Status4].[PSFStatus]         "
    Sql &= "  INNER JOIN [PSF_Supplier] AS [PSF_Supplier5]                        "
    Sql &= "    ON [PSF_HSBCMain].[SupplierCode] = [PSF_Supplier5].[SupplierID]   "
    Sql &= "  WHERE 1 = 1                                                         "
    If Record.FOurRefNo <> String.Empty And Record.TOurRefNo <> String.Empty Then
      Sql &= "  AND  [PSF_HSBCMain].[OurRefNo] BETWEEN '" & Record.FOurRefNo & "' AND '" & Record.TOurRefNo & "'"
    End If
    If Record.FSupplierCode <> String.Empty And Record.TSupplierCode <> String.Empty Then
      Sql &= "  AND  [PSF_HSBCMain].[SupplierCode] BETWEEN '" & Record.FSupplierCode & "' AND '" & Record.TSupplierCode & "'"
    End If
    If Record.FIRN <> String.Empty And Record.TIRN <> String.Empty Then
      Sql &= "  AND  [PSF_HSBCMain].[IRN] BETWEEN '" & Record.FIRN & "' AND '" & Record.TIRN & "'"
    End If
    If Record.FBankVoucherDate <> String.Empty And Record.TBankVoucherDate <> String.Empty Then
      Sql &= "  AND  [PSF_HSBCMain].[BankVoucherDate] BETWEEN convert(datetime,'" & Record.FBankVoucherDate & "',103) AND convert(datetime,'" & Record.TBankVoucherDate & "',103)"
    End If
    If Record.FDueDate <> String.Empty And Record.TDueDate <> String.Empty Then
      Sql &= "  AND  [PSF_HSBCMain].[DueDate] BETWEEN convert(datetime,'" & Record.FDueDate & "',103) AND convert(datetime,'" & Record.TDueDate & "',103)"
    End If
    If Record.FHSBCToVendor <> String.Empty And Record.THSBCToVendor <> String.Empty Then
      Sql &= "  AND  [PSF_HSBCMain].[HSBCToVendor] BETWEEN convert(datetime,'" & Record.FHSBCToVendor & "',103) AND convert(datetime,'" & Record.THSBCToVendor & "',103)"
    End If
    If Record.FPaymentDateToBank <> String.Empty And Record.TPaymentDateToBank <> String.Empty Then
      Sql &= "  AND  [PSF_HSBCMain].[PaymentDateToBank] BETWEEN convert(datetime,'" & Record.FPaymentDateToBank & "',103) AND convert(datetime,'" & Record.TPaymentDateToBank & "',103)"
    End If
    Dim Results As List(Of SIS.PSF.psfCreation) = Nothing
    Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
      Using Cmd As SqlCommand = Con.CreateCommand()
        Cmd.CommandType = CommandType.Text
        Cmd.CommandText = Sql
        Results = New List(Of SIS.PSF.psfCreation)()
        Con.Open()
        Dim Reader As SqlDataReader = Cmd.ExecuteReader()
        While (Reader.Read())
          Results.Add(New SIS.PSF.psfCreation(Reader))
        End While
        Reader.Close()
      End Using
    End Using
    Return Results
  End Function

End Class
