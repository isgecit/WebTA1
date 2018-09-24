Imports System.IO
Imports OfficeOpenXml
Imports System.Web.Script.Serialization
Partial Class LGDefault
  Inherits System.Web.UI.Page

  '  Private Sub cmdUpdatePrg_Click(sender As Object, e As EventArgs) Handles cmdUpdatePrg.Click
  '    Try
  '      With F_ProjectGroup
  '        If .HasFile Then
  '          Dim tmpPath As String = Server.MapPath("~/../App_Temp")
  '          Dim tmpName As String = IO.Path.GetRandomFileName()
  '          Dim tmpFile As String = tmpPath & "\\" & tmpName
  '          .SaveAs(tmpFile)
  '          Dim fi As FileInfo = New FileInfo(tmpFile)
  '          Using xlP As ExcelPackage = New ExcelPackage(fi)
  '            Dim wsD As ExcelWorksheet = Nothing
  '            Dim r As Integer = 2
  '            Try
  '              wsD = xlP.Workbook.Worksheets("CS_Data")
  '              Dim Last_GroupID As String = ""
  '              Dim Last_ProjectGroupName As String = ""
  '              Dim ProjectID As String = ""
  '              ProjectID = wsD.Cells(r, 1).Text
  '              Do While ProjectID <> String.Empty
  '                '1. Check and Create Project
  '                Dim tmp As SIS.QCM.qcmProjects = SIS.QCM.qcmProjects.qcmProjectsGetByID(ProjectID)
  '                If tmp Is Nothing Then
  '                  tmp = New SIS.QCM.qcmProjects
  '                  With tmp
  '                    .ProjectID = ProjectID
  '                    .Description = wsD.Cells(r, 5).Text
  '                  End With
  '                  Try
  '                    SIS.QCM.qcmProjects.InsertData(tmp)
  '                  Catch ex As Exception
  '                    wsD.Cells(r, 3).Value = "Err: Create Prj."
  '                  End Try
  '                End If
  '                '2. Update COST Data for Project
  '                Dim oP As SIS.COST.costProjects = SIS.COST.costProjects.costProjectsGetByID(ProjectID)
  '                If oP IsNot Nothing Then
  '                  With oP
  '                    .ProjectID = ProjectID
  '                    .Description = wsD.Cells(r, 5).Text
  '                    .DivisionID = wsD.Cells(r, 7).Text
  '                    .ProjectOrderValue = wsD.Cells(r, 8).Text
  '                    .ProjectTypeID = wsD.Cells(r, 6).Text
  '                    .WarrantyPercentage = wsD.Cells(r, 12).Text
  '                    .CurrencyID = wsD.Cells(r, 13).Text
  '                    .WorkOrderTypeID = wsD.Cells(r, 14).Text
  '                    .CFforPOV = wsD.Cells(r, 15).Text
  '                  End With
  '                  Try
  '                    SIS.COST.costProjects.UZ_costProjectsUpdate(oP)
  '                  Catch ex As Exception
  '                    wsD.Cells(r, 3).Value = "Err: Update COST Data for Prj."
  '                  End Try
  '                End If
  '                '3. Create/Update Project Group From First Line ONLY
  '                Dim oPG As SIS.COST.costProjectGroups = Nothing
  '                Dim GroupName As String = wsD.Cells(r, 4).Text
  '                If Last_ProjectGroupName <> GroupName Then
  '                  Last_ProjectGroupName = GroupName
  '                  Dim GroupID As String = wsD.Cells(r, 2).Text
  '                  Dim Found As Boolean = True
  '                  If GroupID <> String.Empty Then
  '                    oPG = SIS.COST.costProjectGroups.costProjectGroupsGetByID(GroupID)
  '                    If oPG Is Nothing Then
  '                      oPG = SIS.COST.costProjectGroups.costProjectGroupsGetByName(GroupName)
  '                    End If
  '                  Else
  '                    oPG = SIS.COST.costProjectGroups.costProjectGroupsGetByName(GroupName)
  '                  End If
  '                  If oPG Is Nothing Then
  '                    Found = False
  '                    oPG = New SIS.COST.costProjectGroups
  '                  End If
  '                  With oPG
  '                    .ProjectGroupDescription = GroupName
  '                    .ProjectTypeID = wsD.Cells(r, 6).Text
  '                    Try
  '                      If Found Then
  '                        Last_GroupID = oPG.ProjectGroupID
  '                        wsD.Cells(r, 2).Value = oPG.ProjectGroupID
  '                        oPG = SIS.COST.costProjectGroups.UpdateData(oPG)
  '                      Else
  '                        oPG = SIS.COST.costProjectGroups.InsertData(oPG)
  '                        wsD.Cells(r, 2).Value = oPG.ProjectGroupID
  '                        Last_GroupID = oPG.ProjectGroupID
  '                      End If
  '                    Catch ex As Exception
  '                      If Found Then
  '                        wsD.Cells(r, 3).Value = "Err: Update Prj.Gr"
  '                      Else
  '                        wsD.Cells(r, 3).Value = "Err: Create Prj.Gr"
  '                        oPG = Nothing
  '                      End If
  '                    End Try
  '                  End With
  '                Else
  '                  wsD.Cells(r, 2).Value = Last_GroupID
  '                End If
  '                '4. Create Project Group Project if oPG is Not Nothing and Not Found
  '                If oPG IsNot Nothing Then
  '                  Dim oPGP As SIS.COST.costProjectGroupProjects = SIS.COST.costProjectGroupProjects.costProjectGroupProjectsGetByID(oPG.ProjectGroupID, ProjectID)
  '                  If oPGP Is Nothing Then
  '                    oPGP = New SIS.COST.costProjectGroupProjects
  '                    With oPGP
  '                      .ProjectGroupID = oPG.ProjectGroupID
  '                      .ProjectID = ProjectID
  '                    End With
  '                    Try
  '                      oPGP = SIS.COST.costProjectGroupProjects.InsertData(oPGP)
  '                    Catch ex As Exception
  '                      wsD.Cells(r, 3).Value = "Err: Create Prj.Gr.Prj."
  '                    End Try
  '                  End If
  '                End If
  '                '5. CostSheet(s) For FYr/Qtr, L_Yr if oPG is Not Nothing
  '                If oPG IsNot Nothing Then
  '                  Dim ProjectGroupID As Integer = oPG.ProjectGroupID
  '                  Dim Finyear As String = wsD.Cells(r, 16).Text
  '                  Dim Quarter As Integer = wsD.Cells(r, 17).Text
  '                  Dim LastYearCol As Integer = 17
  '                  Do While Finyear <> String.Empty
  '                    Dim Found As Boolean = True
  '                    Dim oCS As SIS.COST.costCostSheet = SIS.COST.costCostSheet.costCostSheetGetByID(ProjectGroupID, Finyear, Quarter, 1)
  '                    If oCS Is Nothing Then
  '                      Found = False
  '                      oCS = New SIS.COST.costCostSheet
  '                      oCS.Revision = 1
  '                      oCS.StatusID = 2
  '                    End If
  '                    With oCS
  '                      .ProjectGroupID = ProjectGroupID
  '                      .FinYear = Finyear
  '                      .Quarter = Quarter
  '                      .CreatedBy = HttpContext.Current.Session("LoginID")
  '                      .CreatedOn = Now
  '                      .Remarks = "By Excel Import"
  '                    End With
  '                    Try
  '                      If Found Then
  '                        SIS.COST.costCostSheet.UpdateData(oCS)
  '                      Else
  '                        SIS.COST.costCostSheet.InsertData(oCS)
  '                      End If
  '                    Catch ex As Exception
  '                      If Found Then
  '                        wsD.Cells(r, 3).Value = "Err: Update Costsheet"
  '                      Else
  '                        wsD.Cells(r, 3).Value = "Err: Create Costsheet"
  '                      End If
  '                    End Try
  '                    LastYearCol += 1
  '                    Finyear = wsD.Cells(r, LastYearCol).Text
  '                    Quarter = 4
  '                  Loop
  '                End If
  '                '6. Project Input(s) For FYr/Qtr, L_Yr if oPG is Not Nothing
  '                If oPG IsNot Nothing Then
  '                  Dim ProjectGroupID As Integer = oPG.ProjectGroupID
  '                  Dim Finyear As String = wsD.Cells(r, 16).Text
  '                  Dim Quarter As Integer = wsD.Cells(r, 17).Text
  '                  Dim LastYearCol As Integer = 17
  '                  Do While Finyear <> String.Empty
  '                    Dim Found As Boolean = True
  '                    Dim oPI As SIS.COST.costProjectsInput = SIS.COST.costProjectsInput.costProjectsInputGetByID(ProjectGroupID, Finyear, Quarter)
  '                    If oPI Is Nothing Then
  '                      Found = False
  '                      oPI = New SIS.COST.costProjectsInput
  '                      oPI.StatusID = 2
  '                    End If
  '                    With oPI
  '                      .ProjectGroupID = ProjectGroupID
  '                      .FinYear = Finyear
  '                      .Quarter = Quarter
  '                      .ProjectRevenue = wsD.Cells(r, 9).Text
  '                      .ProjectMargin = wsD.Cells(r, 10).Text
  '                      .ExportIncentive = wsD.Cells(r, 11).Text
  '                      .CurrencyPR = wsD.Cells(r, 13).Text
  '                      .CFforPR = wsD.Cells(r, 15).Text
  '                      .CreatedBy = HttpContext.Current.Session("LoginID")
  '                      .CreatedOn = Now
  '                      .ApprovedBy = HttpContext.Current.Session("LoginID")
  '                      .ApprovedOn = Now
  '                      .Remarks = "By Excel Import"
  '                    End With
  '                    Try
  '                      If Found Then
  '                        SIS.COST.costProjectsInput.UZ_costProjectsInputUpdate(oPI)
  '                      Else
  '                        oPI = SIS.COST.costProjectsInput.UZ_costProjectsInputInsert(oPI)
  '                        SIS.COST.costProjectsIputApproval.ApproveWF(oPI.ProjectGroupID, oPI.FinYear, oPI.Quarter, "Auto approved by Excel Import")
  '                      End If
  '                    Catch ex As Exception
  '                      If Found Then
  '                        wsD.Cells(r, 3).Value = "Err: Update Project Input"
  '                      Else
  '                        wsD.Cells(r, 3).Value = "Err: Create Project Input"
  '                      End If
  '                    End Try
  '                    LastYearCol += 1
  '                    Finyear = wsD.Cells(r, LastYearCol).Text
  '                    Quarter = 4
  '                  Loop
  '                End If
  '                '7. Read NEXT EXCEL Line
  '                r += 1
  '                ProjectID = wsD.Cells(r, 1).Text
  '              Loop
  '            Catch ex As Exception
  '              wsD.Cells(r, 3).Value = ex.Message
  '            End Try
  '            xlP.Save()
  '            xlP.Dispose()
  '          End Using
  '          Dim FileNameForUser As String = F_ProjectGroup.FileName
  '          If IO.File.Exists(tmpFile) Then
  '            Response.Clear()
  '            Response.AppendHeader("content-disposition", "attachment; filename=" & FileNameForUser )
  '            Response.ContentType = SIS.SYS.Utilities.ApplicationSpacific.ContentType(FileNameForUser)
  '            Response.WriteFile(tmpFile)
  '            Response.End()
  '          End If
  '        End If
  '      End With
  '    Catch ex As Exception
  '      Dim message As String = New JavaScriptSerializer().Serialize(ex.Message.ToString())
  '      Dim script As String = String.Format("alert({0});", message)
  '      ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", script, True)
  '    End Try
  'over:

  '  End Sub

  Public Property abcd As String = ""


  Private Sub LGDefault_PreRender(sender As Object, e As EventArgs) Handles Me.PreRender
    If Page.User.Identity.IsAuthenticated Then

      Dim str As String = ""
      str &= "|~/TA Bill Entry Process Ver_1.pdf|TA Bill Entry HELP"
      str &= "|~/TA_Main/App_Forms/GF_taBH.aspx|TA Claim Form"
      str &= "|~/Perks Claim Process Ver_1.pdf|Perks Claim HELP"
      str &= "|~/NPRK_Main/App_Forms/GF_nprkUserClaims.aspx|Perks Claim Form"
      'str &= "|~/NPRK_Main/App_Print/RP_nprkUserEntitlementSheet.aspx'|Entitlement Sheet"
      'str &= "|#alert('hi');return false;|Entitlement Sheet"
      str &= "|#show_entitlement();|Entitlement Sheet"
      str &= "|#show_perkref();|PERK OPENING BALANCE REFERENCE"
      str &= "|#show_imprest('" & HttpContext.Current.Session("LoginID") & "');|Imprest Detail"
      'str &= "|~/ATN_Main/App_Forms/GT_atnRegularizeTSAttendance.aspx|Regularize TS"
      'str &= "|~/ATN_Main/App_View/GD_atnTimeShort.aspx|Time Short"
      'str &= "|~/ATN_Main/App_View/GD_atnAppliedApplications.aspx|My Application"
      'str &= "|~/ATN_Main/App_Forms/GF_atnApproverChangeRequest.aspx|Change Approver"
      'str &= "|~/ATN_Main/App_Reports/GP_atnPrintLeavecard.aspx|Leave Card"
      'str &= "|~/ATN_Main/App_View/GD_atnRules.aspx|Leave Rules"
      'str &= "|~/TA_Main/App_Forms/GF_taTPUserInvoicing.aspx|Travel Invoice"

      str = str.Replace("~", HttpContext.Current.Request.Url.Scheme & Uri.SchemeDelimiter & HttpContext.Current.Request.Url.Authority & HttpContext.Current.Request.ApplicationPath)
      Dim astr() As String = str.Split("|".ToCharArray)

      abcd &= "<ul class='dashboardIcons'>"
      For i As Integer = 1 To astr.Length - 1 Step 2
        abcd &= "<fieldset id='fs" & i & "' class='ui-widget-content wp_page'>"
        'abcd &= "<legend>"
        'abcd &= "    <span>&nbsp;" & astr(i + 1) & "</span>"
        'abcd &= "</legend>"
        abcd &= "<div class='wp_pagedata'>"
        abcd &= "  <li title='" & astr(i + 1) & "'>"
        abcd &= "    <div class='frame'>"
        If astr(i).StartsWith("#") Then
          abcd &= "      <div onclick=""" & astr(i).Substring(1) & """>"
          abcd &= "        <img src='Images/mnu_" & i & ".jpg' width='50' height='50' alt=''>"
          abcd &= "        <span>" & astr(i + 1) & "</span>"
          abcd &= "      </div>"
        Else
          abcd &= "      <a href='" & astr(i) & "'>"
          abcd &= "        <img src='Images/mnu_" & i & ".jpg' width='50' height='50' alt=''>"
          abcd &= "        <span>" & astr(i + 1) & "</span>"
          abcd &= "      </a>"
        End If
        abcd &= "     </div>"
        abcd &= "  </li>"
        abcd &= "</div>"
        abcd &= "</fieldset>"
      Next
      abcd &= "</ul>"
    End If

  End Sub
End Class
