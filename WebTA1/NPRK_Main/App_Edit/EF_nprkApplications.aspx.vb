Imports System.IO
Imports OfficeOpenXml
Imports System.Web.Script.Serialization

Partial Class EF_nprkApplications
  Inherits SIS.SYS.UpdateBase
  Public Property ChildAddable() As Boolean
    Get
      If ViewState("ChildAddable") IsNot Nothing Then
        Return CType(ViewState("ChildAddable"), Boolean)
      End If
      Return True
    End Get
    Set(ByVal value As Boolean)
      ViewState.Add("ChildAddable", value)
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
  Public Property PerkID As Integer
    Get
      If ViewState("PerkID") IsNot Nothing Then
        Return CType(ViewState("PerkID"), Integer)
      End If
      Return 0
    End Get
    Set(value As Integer)
      ViewState.Add("PerkID", value)
    End Set
  End Property
  Protected Sub ODSnprkApplications_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODSnprkApplications.Selected
    Dim tmp As SIS.NPRK.nprkApplications = CType(e.ReturnValue, SIS.NPRK.nprkApplications)
    Editable = tmp.Editable
    Deleteable = tmp.Deleteable
    ChildAddable = tmp.ChildAddable
    PrimaryKey = tmp.PrimaryKey
    PerkID = tmp.PerkID
  End Sub
  Protected Sub FVnprkApplications_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVnprkApplications.Init
    DataClassName = "EnprkApplications"
    SetFormView = FVnprkApplications
  End Sub
  Protected Sub TBLnprkApplications_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLnprkApplications.Init
    SetToolBar = TBLnprkApplications
  End Sub
  Protected Sub FVnprkApplications_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVnprkApplications.PreRender
    TBLnprkApplications.EnableSave = Editable
    TBLnprkApplications.EnableDelete = Deleteable
    TBLnprkBillDetails.EnableAdd = ChildAddable
    Select Case PerkID
      Case prkPerk.DriverCharges
        TBLnprkBillDetails.EnableAdd = False
    End Select
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/NPRK_Main/App_Edit") & "/EF_nprkApplications.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptnprkApplications") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptnprkApplications", mStr)
    End If
    mStr = "<script type = 'text/javascript' >"
    mStr &= "setTimeout(function() {"
    mStr &= "try {"
    mStr &= "groupClicked($get('nprkApplications_0').firstElementChild);"
    mStr &= "   }catch(e){}"
    mStr &= "}, 1);"
    mStr &= "</script>"
    If Not Page.ClientScript.IsClientScriptBlockRegistered("abcd") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "abcd", mStr)
    End If
  End Sub
  Partial Class gvBase
    Inherits SIS.SYS.GridBase
  End Class
  Private WithEvents gvnprkBillDetailsCC As New gvBase
  Protected Sub GVnprkBillDetails_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVnprkBillDetails.Init
    gvnprkBillDetailsCC.DataClassName = "GnprkBillDetails"
    gvnprkBillDetailsCC.SetGridView = GVnprkBillDetails
  End Sub
  Protected Sub TBLnprkBillDetails_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLnprkBillDetails.Init
    gvnprkBillDetailsCC.SetToolBar = TBLnprkBillDetails
  End Sub
  Protected Sub GVnprkBillDetails_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVnprkBillDetails.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim ClaimID As Int32 = GVnprkBillDetails.DataKeys(e.CommandArgument).Values("ClaimID")
        Dim ApplicationID As Int32 = GVnprkBillDetails.DataKeys(e.CommandArgument).Values("ApplicationID")
        Dim AttachmentID As Int32 = GVnprkBillDetails.DataKeys(e.CommandArgument).Values("AttachmentID")
        Dim RedirectUrl As String = TBLnprkBillDetails.EditUrl & "?ClaimID=" & ClaimID & "&ApplicationID=" & ApplicationID & "&AttachmentID=" & AttachmentID
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
      End Try
    End If
  End Sub
  Protected Sub TBLnprkBillDetails_AddClicked(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles TBLnprkBillDetails.AddClicked
    Dim ApplicationID As Int32 = CType(FVnprkApplications.FindControl("F_ApplicationID"), TextBox).Text
    Dim ClaimID As Int32 = CType(FVnprkApplications.FindControl("F_ClaimID"), TextBox).Text
    TBLnprkBillDetails.AddUrl &= "?tmp=1&ApplicationID=" & ApplicationID
    TBLnprkBillDetails.AddUrl &= "&ClaimID=" & ClaimID & "&skip=1"
  End Sub
  Protected Sub ShowBalance(ByVal sender As Object, ByVal e As System.EventArgs)
    Dim Bal As LC_PrkBalanceAsOn = FVnprkApplications.FindControl("LC_PrkBalance1")
    Dim Prk As LC_nprkPerksClaimable = FVnprkApplications.FindControl("F_PerkID")
    Dim Err As Label = FVnprkApplications.FindControl("L_ErrorMsg")
    Dim Crn As Label = FVnprkApplications.FindControl("L_crn")
    Dim AplID As TextBox = CType(FVnprkApplications.FindControl("F_ApplicationID"), TextBox)
    Err.Visible = False
    Crn.Visible = False
    Dim Amt As Decimal = 0
    Bal.Visible = True
    'TBLnprkApplications.EnableSave = True
    If Prk.SelectedValue <> String.Empty Then
      Dim tmpRow As HtmlTableRow = FVnprkApplications.FindControl("uploadRow")
      tmpRow.Visible = False
      If Prk.SelectedValue = prkPerk.VehicleRepairAndRunningExpense Then
        tmpRow.Visible = True
      End If
      Dim Applied As Integer = SIS.NPRK.nprkApplications.CanApply(HttpContext.Current.Session("LoginID"), Prk.SelectedValue, AplID.Text)
      If Applied = 0 Then
        With Bal
          .PerkID = Prk.SelectedValue
          .EmployeeID = HttpContext.Current.Session("LoginID")
          Amt = .LoadData()
        End With
        Select Case Convert.ToInt32(Prk.SelectedValue)
          Case prkPerk.Mobile, prkPerk.Telephone
          Case Else
            If Amt <= 0 Then
              TBLnprkApplications.EnableSave = False
              Editable = False
              ChildAddable = False
            End If
        End Select
        'Bal.Visible = False
      Else
        TBLnprkApplications.EnableSave = False
        Editable = False
        ChildAddable = False
        Err.Visible = True
        Crn.Visible = True
        Dim oApl As SIS.NPRK.nprkApplications = SIS.NPRK.nprkApplications.UZ_nprkApplicationsGetByID(Applied)
        Crn.Text = "Claim Ref.No: " & oApl.ClaimRefNo & ", Claimed Amount: " & oApl.Value & ", Status: " & oApl.FK_PRK_Applications_ClaimID.PRK_ClaimStatus4_Description
      End If
    Else
      Bal.Visible = False
    End If
    Dim lbl As Label = FVnprkApplications.FindControl("L_Balance")
    lbl.Text = Math.Round(Amt, 2)
  End Sub

  Private Sub FVnprkApplications_ItemCommand(sender As Object, e As FormViewCommandEventArgs) Handles FVnprkApplications.ItemCommand
    Try
      If e.CommandName.ToLower = "lgtemplate" Then
        Dim tmpFile As String = Server.MapPath("~/App_Templates/LOGBOOK.xlsx")
        If IO.File.Exists(tmpFile) Then
          Response.Clear()
          Response.AppendHeader("content-disposition", "attachment; filename=" & tmpFile)
          Response.ContentType = SIS.SYS.Utilities.ApplicationSpacific.ContentType(tmpFile)
          Response.WriteFile(tmpFile)
          Response.End()
        End If
      End If
      If e.CommandName.ToLower = "lgdownload" Then
        Dim aVal() As String = e.CommandArgument.ToString.Split("|".ToCharArray)
        Dim ClaimID As String = aVal(0)
        Dim ApplicationID As String = aVal(1)
        Dim tmpApl As SIS.NPRK.nprkApplications = SIS.NPRK.nprkApplications.nprkApplicationsGetByID(ClaimID, ApplicationID)
        If IO.File.Exists(tmpApl.ReportDiskFile) Then
          Response.Clear()
          Response.AppendHeader("content-disposition", "attachment; filename=" & tmpApl.ReportFileName)
          Response.ContentType = SIS.SYS.Utilities.ApplicationSpacific.ContentType(tmpApl.ReportFileName)
          Response.WriteFile(tmpApl.ReportDiskFile)
          Response.End()
        End If
      End If
      If e.CommandName.ToLower = "lgupload" Then
        Dim ReportFile As FileUpload = CType(FVnprkApplications.FindControl("F_ReportFile"), FileUpload)
        If ReportFile.HasFile Then
          Dim tmpPath As String = ConfigurationManager.AppSettings("LogBookVault")
          If Not IO.Directory.Exists(tmpPath) Then
            tmpPath = ConfigurationManager.AppSettings("LogBookVault1")
          End If
          Dim tmpName As String = IO.Path.GetRandomFileName()
          Dim tmpFile As String = tmpPath & "\\" & tmpName
          ReportFile.SaveAs(tmpFile)
          Dim aVal() As String = e.CommandArgument.ToString.Split("|".ToCharArray)
          Dim ClaimID As String = aVal(0)
          Dim ApplicationID As String = aVal(1)
          Dim tmpApl As SIS.NPRK.nprkApplications = SIS.NPRK.nprkApplications.nprkApplicationsGetByID(ClaimID, ApplicationID)
          If tmpApl.ReportAttached Then
            'Delete Old File
            If IO.File.Exists(tmpApl.ReportDiskFile) Then
              IO.File.Delete(tmpApl.ReportDiskFile)
            End If
          End If
          With tmpApl
            .ReportAttached = True
            .ReportDiskFile = tmpFile
            .ReportFileName = ReportFile.FileName
          End With
          SIS.NPRK.nprkApplications.UpdateData(tmpApl)
          FVnprkApplications.DataBind()
        End If
      End If
      If e.CommandName.ToLower = "lgdelete" Then
        Dim aVal() As String = e.CommandArgument.ToString.Split("|".ToCharArray)
        Dim ClaimID As String = aVal(0)
        Dim ApplicationID As String = aVal(1)
        Dim tmpApl As SIS.NPRK.nprkApplications = SIS.NPRK.nprkApplications.nprkApplicationsGetByID(ClaimID, ApplicationID)
        If IO.File.Exists(tmpApl.ReportDiskFile) Then
          IO.File.Delete(tmpApl.ReportDiskFile)
        End If
        With tmpApl
          .ReportAttached = False
          .ReportDiskFile = ""
          .ReportFileName = ""
        End With
        SIS.NPRK.nprkApplications.UpdateData(tmpApl)
        FVnprkApplications.DataBind()
      End If

    Catch ex As Exception
      Dim message As String = New JavaScriptSerializer().Serialize(ex.Message)
      Dim script As String = String.Format("alert({0});", message)
      ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", script, True)
    End Try

  End Sub

  Private Sub GVnprkBillDetails_PreRender(sender As Object, e As EventArgs) Handles GVnprkBillDetails.PreRender
    SIS.NPRK.nprkBillDetails.FormatGrid(GVnprkBillDetails, PerkID)
  End Sub
  ''  Protected Sub cmdDownload_Click(sender As Object, e As System.EventArgs) Handles cmdDownload.Click
  ''    Dim st As Long = HttpContext.Current.Server.ScriptTimeout
  ''    HttpContext.Current.Server.ScriptTimeout = Integer.MaxValue
  ''    Dim oVal() As String = CType(sender, Button).CommandArgument.Split("|".ToCharArray)
  ''    Dim ClmID As Integer = 0
  ''    Dim AplID As Integer = 0
  ''    Try
  ''      ClmID = oVal(0)
  ''      AplID = oVal(1)
  ''    Catch ex As Exception
  ''      Dim message As String = New JavaScriptSerializer().Serialize("Inalid values received for Template download.")
  ''      Dim script As String = String.Format("alert({0});", message)
  ''      ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", script, True)
  ''      Exit Sub
  ''    End Try
  ''    Dim TemplateName As String = "PrkBill_Template.xlsx"
  ''    Dim tmpFile As String = Server.MapPath("~/App_Templates/" & TemplateName)
  ''    If IO.File.Exists(tmpFile) Then
  ''      Dim FileName As String = Server.MapPath("~/..") & "App_Temp/" & Guid.NewGuid().ToString()
  ''      IO.File.Copy(tmpFile, FileName)
  ''      Dim FileInfo As IO.FileInfo = New IO.FileInfo(FileName)
  ''      Dim xlPk As ExcelPackage = New ExcelPackage(FileInfo)

  ''      '1.
  ''      Dim r As Integer = 5
  ''      Dim c As Integer = 1
  ''      Dim xlWS As ExcelWorksheet = xlPk.Workbook.Worksheets("Bill_Details")

  ''      Dim oApl As SIS.NPRK.nprkApplications = SIS.NPRK.nprkApplications.nprkApplicationsGetByID(ClmID, AplID)
  ''      Dim oBDs As List(Of SIS.NPRK.nprkBillDetails) = SIS.NPRK.nprkBillDetails.UZ_nprkBillDetailsSelectList(0, 999, "", False, "", ClmID, AplID)

  ''      With xlWS
  ''        .Cells(1, 3).Value = oApl.ClaimID
  ''        .Cells(2, 3).Value = oApl.ApplicationID
  ''        .Cells(3, 3).Value = oApl.PRK_Perks7_Description
  ''        For Each cs As SIS.NPRK.nprkBillDetails In oBDs
  ''          .Cells(r, 1).Value = cs.AttachmentID
  ''          .Cells(r, 2).Value = cs.BillNo
  ''          .Cells(r, 3).Value = cs.BillDate
  ''          .Cells(r, 4).Value = cs.Particulars
  ''          .Cells(r, 5).Value = cs.FromDate
  ''          .Cells(r, 6).Value = cs.ToDate
  ''          .Cells(r, 7).Value = cs.Quantity
  ''          .Cells(r, 8).Value = cs.Amount
  ''          r += 1
  ''        Next
  ''      End With
  ''      xlPk.Save()
  ''      xlPk.Dispose()

  ''      Response.Clear()
  ''      Response.AppendHeader("content-disposition", "attachment; filename=BillList_" & ClmID & "_" & AplID & "_Template.xlsx")
  ''      Response.ContentType = SIS.SYS.Utilities.ApplicationSpacific.ContentType(TemplateName)
  ''      Response.WriteFile(FileName)
  ''      HttpContext.Current.Server.ScriptTimeout = st
  ''      Response.End()
  ''    End If

  ''  End Sub
  ''  Private Sub cmdFileUpdate_Click(sender As Object, e As EventArgs) Handles cmdFileUpload.Click
  ''    Dim st As Long = HttpContext.Current.Server.ScriptTimeout
  ''    HttpContext.Current.Server.ScriptTimeout = Integer.MaxValue
  ''    Try
  ''      With F_FileUpload
  ''        If .HasFile Then
  ''          Dim tmpPath As String = Server.MapPath("~/../App_Temp")
  ''          Dim tmpName As String = IO.Path.GetRandomFileName()
  ''          Dim tmpFile As String = tmpPath & "\\" & tmpName
  ''          .SaveAs(tmpFile)
  ''          Dim fi As FileInfo = New FileInfo(tmpFile)
  ''          Using xlP As ExcelPackage = New ExcelPackage(fi)
  ''            Dim wsD As ExcelWorksheet = Nothing
  ''            Try
  ''              wsD = xlP.Workbook.Worksheets("Bill_Details")
  ''              Dim clmID As Integer = 0
  ''              Dim aplID As Integer = 0
  ''              Try
  ''                clmID = wsD.Cells(1, 3).Text
  ''                aplID = wsD.Cells(2, 3).Text
  ''              Catch ex As Exception
  ''                Dim message As String = New JavaScriptSerializer().Serialize("Inalid values found in uploaded Excel.")
  ''                Dim script As String = String.Format("alert({0});", message)
  ''                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", script, True)
  ''                Exit Sub
  ''              End Try
  ''              Dim userID As String = HttpContext.Current.Session("LoginID")
  ''              Dim oClm As SIS.NPRK.nprkUserClaims = SIS.NPRK.nprkUserClaims.nprkUserClaimsGetByID(clmID)
  ''              Dim oApl As SIS.NPRK.nprkApplications = SIS.NPRK.nprkApplications.nprkApplicationsGetByID(clmID, aplID)
  ''              Dim Err As Boolean = False
  ''              '1. 
  ''              If oClm.CardNo <> userID Then
  ''                Err = True
  ''                wsD.Cells(1, 5).Value = "Claim does not belongs to logged in user."
  ''              End If
  ''              '2. 
  ''              Select Case oClm.ClaimStatusID
  ''                Case prkClaimStates.Free, prkClaimStates.ReturnedByAccounts
  ''                Case Else
  ''                  Err = True
  ''                  wsD.Cells(2, 5).Value = "Claim is submitted for processing."
  ''              End Select
  ''              If Not Err Then
  ''                Dim r As Integer = 5
  ''                Dim ClaimedAmt As Decimal = 0
  ''                Try
  ''                  ClaimedAmt = wsD.Cells(r, 8).Text
  ''                Catch ex As Exception
  ''                  ClaimedAmt = 0
  ''                End Try
  ''                Do While ClaimedAmt > 0
  ''                  Dim athID As String = ""
  ''                  athID = wsD.Cells(r, 1).Text
  ''                  Dim oAth As SIS.NPRK.nprkBillDetails = Nothing
  ''                  Dim Found As Boolean = False
  ''                  If athID <> String.Empty Then
  ''                    Try
  ''                      oAth = SIS.NPRK.nprkBillDetails.nprkBillDetailsGetByID(clmID, aplID, athID)
  ''                    Catch ex As Exception
  ''                    End Try
  ''                  End If
  ''                  If oAth IsNot Nothing Then
  ''                    Found = True
  ''                  Else
  ''                    oAth = New SIS.NPRK.nprkBillDetails
  ''                  End If
  ''                  With oAth
  ''                    .ClaimID = clmID
  ''                    .ApplicationID = aplID
  ''                    Try
  ''                      .BillNo = wsD.Cells(r, 2).Text
  ''                    Catch ex As Exception
  ''                    End Try
  ''                    Try
  ''                      .BillDate = wsD.Cells(r, 3).Text
  ''                    Catch ex As Exception
  ''                    End Try
  ''                    Try
  ''                      .Particulars = wsD.Cells(r, 4).Text
  ''                    Catch ex As Exception
  ''                    End Try
  ''                    Try
  ''                      .FromDate = wsD.Cells(r, 5).Text
  ''                    Catch ex As Exception
  ''                    End Try
  ''                    Try
  ''                      .ToDate = wsD.Cells(r, 6).Text
  ''                    Catch ex As Exception
  ''                    End Try
  ''                    Try
  ''                      .Quantity = wsD.Cells(r, 7).Text
  ''                    Catch ex As Exception
  ''                    End Try
  ''                    .Amount = ClaimedAmt
  ''                  End With
  ''                  Try
  ''                    If Found Then
  ''                      SIS.NPRK.nprkBillDetails.UZ_nprkBillDetailsUpdate(oAth)
  ''                    Else
  ''                      oAth = SIS.NPRK.nprkBillDetails.UZ_nprkBillDetailsInsert(oAth)
  ''                      wsD.Cells(r, 1).Value = oAth.AttachmentID
  ''                    End If
  ''                  Catch ex As Exception
  ''                    wsD.Cells(r, 9).Value = ex.Message
  ''                  End Try
  ''                  r += 1
  ''                  Try
  ''                    ClaimedAmt = wsD.Cells(r, 8).Text
  ''                  Catch ex As Exception
  ''                    ClaimedAmt = 0
  ''                  End Try
  ''                Loop
  ''              End If
  ''            Catch en As Exception
  ''              Dim message As String = New JavaScriptSerializer().Serialize(en.Message)
  ''              Dim script As String = String.Format("alert({0});", message)
  ''              ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", script, True)
  ''              Exit Sub
  ''            End Try
  ''            xlP.Save()
  ''            xlP.Dispose()
  ''          End Using
  ''          Dim FileNameForUser As String = F_FileUpload.FileName
  ''          If IO.File.Exists(tmpFile) Then
  ''            Response.Clear()
  ''            Response.AppendHeader("content-disposition", "attachment; filename=" & FileNameForUser)
  ''            Response.ContentType = SIS.SYS.Utilities.ApplicationSpacific.ContentType(FileNameForUser)
  ''            Response.WriteFile(tmpFile)
  ''            HttpContext.Current.Server.ScriptTimeout = st
  ''            Response.End()
  ''          End If
  ''        End If
  ''      End With
  ''    Catch ex As Exception
  ''      HttpContext.Current.Server.ScriptTimeout = st
  ''      Dim message As String = New JavaScriptSerializer().Serialize(ex.Message.ToString())
  ''      Dim script As String = String.Format("alert({0});", message)
  ''      ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", script, True)
  ''    End Try
  ''over:

  ''  End Sub

End Class
