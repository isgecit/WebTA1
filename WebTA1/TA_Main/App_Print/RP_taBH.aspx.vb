Imports System.Web.Script.Serialization
Partial Class RP_taBH
  Inherits System.Web.UI.Page

  Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    Dim ShowWarning As Boolean = True
    Dim aVal() As String = Request.QueryString("pk").Split("|".ToCharArray)
    Dim TABillNo As Int32 = CType(aVal(0), Int32)
    If Request.QueryString("warn") IsNot Nothing Then
      ShowWarning = True
    End If
    form1.Controls.Add(SIS.TA.taBH.GetTABillPanel(TABillNo, ShowWarning))
  End Sub

  'Public Function GetTABillPanel(ByVal TABillNo As Integer, ByVal ShowWarning As Boolean) As Panel
  '  Dim pnl1 As New Panel
  '  Dim oVar As SIS.TA.taBH = SIS.TA.taBH.taBHGetByID(TABillNo)
  '  Dim sn As Integer = 0
  '  Dim tmpTbl As New Table
  '  With tmpTbl
  '    .Width = 1000
  '    .BorderStyle = BorderStyle.None
  '    .Style.Add("margin-top", "15px")
  '    .Style.Add("margin-left", "10px")
  '  End With
  '  Dim tmpRow As New TableRow
  '  Dim tmpCol As New TableCell
  '  With tmpCol
  '    Select Case oVar.TravelTypeID
  '      Case TATravelTypeValues.Domestic
  '        .Text = "TRAVEL EXPENSE STATEMENT"
  '      Case TATravelTypeValues.ForeignTravel
  '        .Text = "FOREIGN TRAVEL EXPENSE STATEMENT"
  '      Case TATravelTypeValues.ForeignSiteVisit
  '        .Text = "FOREIGN SITE VISIT EXPENSE STATEMENT"
  '      Case TATravelTypeValues.HomeVisit
  '        .Text = "HOME VISIT EXPENSE STATEMENT"
  '    End Select
  '    .Style.Add("text-align", "center")
  '    .Font.Size = FontUnit.Point(14)
  '    If Not oVar.FK_TA_Bills_EmployeeID.TASelfApproval Then
  '      Select Case oVar.BillStatusID
  '        Case 2, 3, 4, 5, 11, 12, 13, 15
  '        Case Else
  '          If oVar.OOEBySystem And oVar.ApprovedBySA = "" Then
  '            .Text = "PROVISIONAL BILL -Print it after Approval by Sanctioning Authority"
  '            .Font.Size = FontUnit.Point(12)
  '          ElseIf oVar.ApprovedByCC = "" Then
  '            .Text = "PROVISIONAL BILL -Print it after Approval."
  '            .Font.Size = FontUnit.Point(12)
  '          End If
  '      End Select
  '    End If
  '    .Font.Bold = True
  '  End With
  '  tmpRow.Cells.Add(tmpCol)
  '  tmpTbl.Rows.Add(tmpRow)
  '  pnl1.Controls.Add(tmpTbl)

  '  Dim oTbl As Table
  '  Dim oCol As TableCell = Nothing
  '  Dim oRow As TableRow = Nothing
  '  Dim ClaimTot As Decimal = 0
  '  Dim PassTot As Decimal = 0


  '  Dim oTbltaBH As New Table
  '  oTbltaBH.Width = 1000
  '  oTbltaBH.GridLines = GridLines.Both
  '  oTbltaBH.Style.Add("margin-top", "15px")
  '  oTbltaBH.Style.Add("margin-left", "10px")
  '  Dim oColtaBH As TableCell = Nothing
  '  Dim oRowtaBH As TableRow = Nothing
  '  oRowtaBH = New TableRow
  '  oColtaBH = New TableCell
  '  oColtaBH.Text = "TA Bill No"
  '  oColtaBH.Font.Bold = True
  '  oColtaBH.Width = 150
  '  oRowtaBH.Cells.Add(oColtaBH)
  '  oColtaBH = New TableCell
  '  oColtaBH.Text = oVar.TABillNo
  '  oColtaBH.Style.Add("text-align", "left")
  '  oColtaBH.ColumnSpan = "5"
  '  oColtaBH.Font.Size = "14"
  '  oColtaBH.Font.Bold = True
  '  oRowtaBH.Cells.Add(oColtaBH)
  '  oTbltaBH.Rows.Add(oRowtaBH)
  '  oRowtaBH = New TableRow
  '  oRowtaBH.BackColor = Drawing.Color.Gainsboro
  '  oColtaBH = New TableCell
  '  oColtaBH.Text = "Employee ID"
  '  oColtaBH.Font.Bold = True
  '  oColtaBH.Width = 150
  '  oRowtaBH.Cells.Add(oColtaBH)
  '  oColtaBH = New TableCell
  '  oColtaBH.Text = oVar.EmployeeID
  '  oColtaBH.Style.Add("text-align", "left")
  '  oColtaBH.Width = 100
  '  oRowtaBH.Cells.Add(oColtaBH)
  '  oColtaBH = New TableCell
  '  oColtaBH.Text = oVar.HRM_Employees5_EmployeeName
  '  oColtaBH.Style.Add("text-align", "left")
  '  oColtaBH.Width = 250
  '  oRowtaBH.Cells.Add(oColtaBH)
  '  oColtaBH = New TableCell
  '  oColtaBH.Text = "TA Category ID"
  '  oColtaBH.Font.Bold = True
  '  oColtaBH.Width = 150
  '  oRowtaBH.Cells.Add(oColtaBH)
  '  oColtaBH = New TableCell
  '  oColtaBH.Text = oVar.TA_Categories13_cmba
  '  oColtaBH.Style.Add("text-align", "right")
  '  oColtaBH.ColumnSpan = "2"
  '  oColtaBH.Width = 350
  '  oRowtaBH.Cells.Add(oColtaBH)
  '  oTbltaBH.Rows.Add(oRowtaBH)
  '  oRowtaBH = New TableRow
  '  oRowtaBH.BackColor = Drawing.Color.Gainsboro
  '  oColtaBH = New TableCell
  '  oColtaBH.Text = "CostCenterID"
  '  oColtaBH.Font.Bold = True
  '  oRowtaBH.Cells.Add(oColtaBH)
  '  oColtaBH = New TableCell
  '  oColtaBH.Text = oVar.CostCenterID
  '  oColtaBH.Style.Add("text-align", "left")
  '  oRowtaBH.Cells.Add(oColtaBH)
  '  oColtaBH = New TableCell
  '  oColtaBH.Text = oVar.HRM_Departments1_Description
  '  oColtaBH.Style.Add("text-align", "left")
  '  oRowtaBH.Cells.Add(oColtaBH)
  '  oColtaBH = New TableCell
  '  oColtaBH.Text = "Project ID"
  '  oColtaBH.Font.Bold = True
  '  oRowtaBH.Cells.Add(oColtaBH)
  '  oColtaBH = New TableCell
  '  oColtaBH.Text = oVar.ProjectID
  '  oColtaBH.Style.Add("text-align", "left")
  '  oRowtaBH.Cells.Add(oColtaBH)
  '  oColtaBH = New TableCell
  '  oColtaBH.Text = oVar.IDM_Projects11_Description
  '  oColtaBH.Style.Add("text-align", "left")
  '  oRowtaBH.Cells.Add(oColtaBH)
  '  oTbltaBH.Rows.Add(oRowtaBH)

  '  oRowtaBH = New TableRow
  '  oRowtaBH.BackColor = Drawing.Color.Gainsboro
  '  oColtaBH = New TableCell
  '  oColtaBH.Text = "Department"
  '  oColtaBH.Font.Bold = True
  '  oRowtaBH.Cells.Add(oColtaBH)
  '  oColtaBH = New TableCell
  '  Try
  '    oColtaBH.Text = oVar.FK_TA_Bills_DepartmentID.Description
  '  Catch ex As Exception
  '    oColtaBH.Text = ""
  '  End Try
  '  oColtaBH.Style.Add("text-align", "left")
  '  oColtaBH.ColumnSpan = "2"
  '  oRowtaBH.Cells.Add(oColtaBH)
  '  oColtaBH = New TableCell
  '  oColtaBH.Text = "Designation"
  '  oColtaBH.Font.Bold = True
  '  oRowtaBH.Cells.Add(oColtaBH)
  '  oColtaBH = New TableCell
  '  Try
  '    oColtaBH.Text = oVar.FK_TA_Bills_DesignationID.Description
  '  Catch ex As Exception
  '    oColtaBH.Text = ""
  '  End Try
  '  oColtaBH.ColumnSpan = "2"
  '  oColtaBH.Style.Add("text-align", "left")
  '  oRowtaBH.Cells.Add(oColtaBH)
  '  oTbltaBH.Rows.Add(oRowtaBH)

  '  oRowtaBH = New TableRow
  '  oRowtaBH.BackColor = Drawing.Color.Gainsboro
  '  oColtaBH = New TableCell
  '  oColtaBH.Text = "Purpose Of Journey"
  '  oColtaBH.Font.Bold = True
  '  oRowtaBH.Cells.Add(oColtaBH)
  '  oColtaBH = New TableCell
  '  oColtaBH.Text = oVar.PurposeOfJourney
  '  oColtaBH.Style.Add("text-align", "left")
  '  oColtaBH.ColumnSpan = "5"
  '  oRowtaBH.Cells.Add(oColtaBH)
  '  oTbltaBH.Rows.Add(oRowtaBH)
  '  oRowtaBH = New TableRow
  '  oColtaBH = New TableCell
  '  oColtaBH.Text = "Total Claimed Amount"
  '  oColtaBH.Font.Bold = True
  '  oRowtaBH.Cells.Add(oColtaBH)
  '  oColtaBH = New TableCell
  '  oColtaBH.Text = oVar.TotalClaimedAmount
  '  oColtaBH.Style.Add("text-align", "right")
  '  oColtaBH.ColumnSpan = "2"
  '  oColtaBH.ForeColor = Drawing.Color.Green
  '  oRowtaBH.Cells.Add(oColtaBH)
  '  oColtaBH = New TableCell
  '  oColtaBH.Text = "Total Passed Amount"
  '  oColtaBH.Font.Bold = True
  '  oRowtaBH.Cells.Add(oColtaBH)
  '  oColtaBH = New TableCell
  '  oColtaBH.Text = oVar.TotalPassedAmount
  '  oColtaBH.Style.Add("text-align", "right")
  '  oColtaBH.ColumnSpan = "2"
  '  oRowtaBH.Cells.Add(oColtaBH)
  '  oTbltaBH.Rows.Add(oRowtaBH)
  '  oRowtaBH = New TableRow
  '  oColtaBH = New TableCell
  '  oColtaBH.Text = "Total Financed Amount"
  '  oColtaBH.Font.Bold = True
  '  oRowtaBH.Cells.Add(oColtaBH)
  '  oColtaBH = New TableCell
  '  oColtaBH.Text = oVar.TotalFinancedAmount
  '  oColtaBH.Style.Add("text-align", "right")
  '  oColtaBH.ColumnSpan = "2"
  '  oRowtaBH.Cells.Add(oColtaBH)
  '  oColtaBH = New TableCell
  '  oColtaBH.Text = "Total Payable Amount"
  '  oColtaBH.Font.Bold = True
  '  oRowtaBH.Cells.Add(oColtaBH)
  '  oColtaBH = New TableCell
  '  oColtaBH.Text = oVar.TotalPayableAmount
  '  oColtaBH.Style.Add("text-align", "right")
  '  oColtaBH.ColumnSpan = "2"
  '  oColtaBH.ForeColor = Drawing.Color.Green
  '  oRowtaBH.Cells.Add(oColtaBH)
  '  oTbltaBH.Rows.Add(oRowtaBH)
  '  oRowtaBH = New TableRow
  '  oColtaBH = New TableCell
  '  oColtaBH.Text = "Sanctioned DA [Per Day, If any]"
  '  oColtaBH.Font.Bold = True
  '  oRowtaBH.Cells.Add(oColtaBH)
  '  oColtaBH = New TableCell
  '  oColtaBH.Text = oVar.SanctionedDA
  '  oColtaBH.Style.Add("text-align", "right")
  '  oColtaBH.ColumnSpan = "2"
  '  oRowtaBH.Cells.Add(oColtaBH)
  '  oColtaBH = New TableCell
  '  oColtaBH.Text = "Sanctioned Lodging [Per Day, If any]"
  '  oColtaBH.Font.Bold = True
  '  oRowtaBH.Cells.Add(oColtaBH)
  '  oColtaBH = New TableCell
  '  oColtaBH.Text = oVar.SanctionedLodging
  '  oColtaBH.Style.Add("text-align", "right")
  '  oColtaBH.ColumnSpan = "2"
  '  oRowtaBH.Cells.Add(oColtaBH)
  '  oTbltaBH.Rows.Add(oRowtaBH)
  '  oRowtaBH = New TableRow
  '  oRowtaBH.BackColor = Drawing.Color.Gainsboro
  '  oColtaBH = New TableCell
  '  oColtaBH.Text = "Verified By"
  '  oColtaBH.Font.Bold = True
  '  oRowtaBH.Cells.Add(oColtaBH)
  '  oColtaBH = New TableCell
  '  oColtaBH.Text = oVar.HRM_Employees7_EmployeeName
  '  oColtaBH.Style.Add("text-align", "left")
  '  oColtaBH.ColumnSpan = "2"
  '  oRowtaBH.Cells.Add(oColtaBH)
  '  oColtaBH = New TableCell
  '  oColtaBH.Text = "Approved By"
  '  oColtaBH.Font.Bold = True
  '  oRowtaBH.Cells.Add(oColtaBH)
  '  oColtaBH = New TableCell
  '  oColtaBH.Text = oVar.HRM_Employees8_EmployeeName
  '  oColtaBH.Style.Add("text-align", "left")
  '  oColtaBH.ColumnSpan = "2"
  '  oRowtaBH.Cells.Add(oColtaBH)
  '  oTbltaBH.Rows.Add(oRowtaBH)
  '  oRowtaBH = New TableRow
  '  oRowtaBH.BackColor = Drawing.Color.Gainsboro
  '  oColtaBH = New TableCell
  '  oColtaBH.Text = "Verified On"
  '  oColtaBH.Font.Bold = True
  '  oRowtaBH.Cells.Add(oColtaBH)
  '  oColtaBH = New TableCell
  '  oColtaBH.Text = oVar.ApprovedOn
  '  oColtaBH.Style.Add("text-align", "center")
  '  oColtaBH.ColumnSpan = "2"
  '  oRowtaBH.Cells.Add(oColtaBH)
  '  oColtaBH = New TableCell
  '  oColtaBH.Text = "Approved On "
  '  oColtaBH.Font.Bold = True
  '  oRowtaBH.Cells.Add(oColtaBH)
  '  oColtaBH = New TableCell
  '  oColtaBH.Text = oVar.ApprovedByCCOn
  '  oColtaBH.Style.Add("text-align", "center")
  '  oColtaBH.ColumnSpan = "2"
  '  oRowtaBH.Cells.Add(oColtaBH)
  '  oTbltaBH.Rows.Add(oRowtaBH)
  '  oRowtaBH = New TableRow
  '  oRowtaBH.BackColor = Drawing.Color.Gainsboro
  '  oColtaBH = New TableCell
  '  oColtaBH.Text = "Special Approval By Sanctioning Authority"
  '  oColtaBH.Font.Bold = True
  '  oRowtaBH.Cells.Add(oColtaBH)
  '  oColtaBH = New TableCell
  '  oColtaBH.Text = oVar.ApprovedBySA
  '  oColtaBH.Style.Add("text-align", "left")
  '  oRowtaBH.Cells.Add(oColtaBH)
  '  oColtaBH = New TableCell
  '  oColtaBH.Text = oVar.HRM_Employees9_EmployeeName
  '  oColtaBH.Style.Add("text-align", "left")
  '  oRowtaBH.Cells.Add(oColtaBH)
  '  oColtaBH = New TableCell
  '  oColtaBH.Text = "Special Approval On"
  '  oColtaBH.Font.Bold = True
  '  oRowtaBH.Cells.Add(oColtaBH)
  '  oColtaBH = New TableCell
  '  oColtaBH.Text = oVar.ApprovedBySAOn
  '  oColtaBH.Style.Add("text-align", "center")
  '  oColtaBH.ColumnSpan = "2"
  '  oRowtaBH.Cells.Add(oColtaBH)
  '  oTbltaBH.Rows.Add(oRowtaBH)
  '  oRowtaBH = New TableRow
  '  oRowtaBH.BackColor = Drawing.Color.Gainsboro
  '  oColtaBH = New TableCell
  '  oColtaBH.Text = "Bill Status"
  '  oColtaBH.Font.Bold = True
  '  oRowtaBH.Cells.Add(oColtaBH)
  '  oColtaBH = New TableCell
  '  oColtaBH.Text = oVar.TA_BillStates16_Description
  '  oColtaBH.Style.Add("text-align", "left")
  '  oColtaBH.ColumnSpan = "2"
  '  oRowtaBH.Cells.Add(oColtaBH)
  '  oColtaBH = New TableCell
  '  oColtaBH.Text = "Posted at Site"
  '  oColtaBH.Font.Bold = True
  '  oRowtaBH.Cells.Add(oColtaBH)
  '  oColtaBH = New TableCell
  '  Try
  '    oColtaBH.Text = oVar.SiteName
  '  Catch ex As Exception
  '    oColtaBH.Text = ""
  '  End Try
  '  oColtaBH.Style.Add("text-align", "right")
  '  oColtaBH.ColumnSpan = "2"
  '  oRowtaBH.Cells.Add(oColtaBH)
  '  oTbltaBH.Rows.Add(oRowtaBH)
  '  oRowtaBH = New TableRow
  '  oColtaBH = New TableCell
  '  oColtaBH.Text = "OOE Remarks"
  '  oColtaBH.Font.Bold = True
  '  oRowtaBH.Cells.Add(oColtaBH)
  '  oColtaBH = New TableCell
  '  oColtaBH.Text = oVar.OOERemarks
  '  oColtaBH.Style.Add("text-align", "left")
  '  oColtaBH.ColumnSpan = "2"
  '  oRowtaBH.Cells.Add(oColtaBH)
  '  oColtaBH = New TableCell
  '  oColtaBH.Text = "MD Sanction Attached"
  '  oColtaBH.Font.Bold = True
  '  oRowtaBH.Cells.Add(oColtaBH)
  '  oColtaBH = New TableCell
  '  oColtaBH.Text = IIf(oVar.SanctionAttached, "YES", "NO")
  '  oColtaBH.Style.Add("text-align", "left")
  '  oColtaBH.ColumnSpan = "2"
  '  oRowtaBH.Cells.Add(oColtaBH)
  '  oTbltaBH.Rows.Add(oRowtaBH)
  '  pnl1.Controls.Add(oTbltaBH)

  '  ' Table For Foreign Travel 
  '  If oVar.TravelTypeID <> TATravelTypeValues.Domestic Then
  '    oTbl = New Table
  '    oTbl.Width = 1000
  '    oTbl.GridLines = GridLines.None
  '    oTbl.Style.Add("margin-top", "15px")
  '    oTbl.Style.Add("margin-left", "10px")
  '    oRow = New TableRow
  '    oCol = New TableCell
  '    oCol.Text = "DEPARTUE FROM INDIA:"
  '    oCol.CssClass = "alignright"
  '    oCol.Font.Bold = True
  '    oRow.Cells.Add(oCol)
  '    oCol = New TableCell
  '    oCol.Text = oVar.DepartureFromIndia
  '    oCol.Font.Bold = True
  '    oCol.Width = Unit.Percentage(50)
  '    oRow.Cells.Add(oCol)
  '    oTbl.Rows.Add(oRow)

  '    oRow = New TableRow
  '    oCol = New TableCell
  '    oCol.Text = "ARRIVAL IN INDIA:"
  '    oCol.CssClass = "alignright"
  '    oCol.Font.Bold = True
  '    oRow.Cells.Add(oCol)
  '    oCol = New TableCell
  '    oCol.Text = oVar.ArrivalToIndia
  '    oCol.Font.Bold = True
  '    oRow.Cells.Add(oCol)
  '    oTbl.Rows.Add(oRow)

  '    oRow = New TableRow
  '    oCol = New TableCell
  '    oCol.Text = "TOTAL DA DAYS:"
  '    oCol.CssClass = "alignright"
  '    oCol.Font.Bold = True
  '    oRow.Cells.Add(oCol)
  '    oCol = New TableCell
  '    oCol.Text = oVar.TotalTravelDays
  '    oCol.Font.Bold = True
  '    oRow.Cells.Add(oCol)
  '    oTbl.Rows.Add(oRow)

  '    pnl1.Controls.Add(oTbl)

  '  End If
  '  '---------


  '  If ShowWarning Then

  '    Dim tblTmp As Table = Nothing
  '    Dim rowTmp As TableRow = Nothing
  '    Dim colTmp As TableCell = Nothing
  '    Dim tbDs As List(Of SIS.TA.taBillDetails) = SIS.TA.taBillDetails.UZ_taBillDetailsSelectList(0, 9999, "ComponentID", False, "", TABillNo)
  '    Dim Found As Boolean = False
  '    For Each tbd As SIS.TA.taBillDetails In tbDs
  '      If tbd.OOEBySystem = True Then
  '        Found = True
  '        Exit For
  '      End If
  '    Next
  '    If Found Then
  '      tblTmp = New Table
  '      With tblTmp
  '        .Width = 1000
  '        .Style.Add("margin-top", "15px")
  '        .Style.Add("margin-left", "10px")
  '        .Style.Add("margin-right", "10px")
  '      End With
  '      rowTmp = New TableRow
  '      colTmp = New TableCell
  '      With colTmp
  '        .Text = "Sanction required for the following expenses of TA Bill"
  '        .Font.Bold = True
  '        .ColumnSpan = 7
  '        .Style.Add("text-align", "left")
  '        .ForeColor = Drawing.Color.Red
  '      End With
  '      rowTmp.Cells.Add(colTmp)
  '      tblTmp.Rows.Add(rowTmp)

  '      rowTmp = New TableRow
  '      rowTmp.BackColor = Drawing.Color.LightPink
  '      colTmp = New TableCell
  '      With colTmp
  '        .Text = "S.N."
  '        .Font.Bold = True
  '        .CssClass = "colHD"
  '        .Width = 40
  '        .Style.Add("text-align", "center")
  '      End With
  '      rowTmp.Cells.Add(colTmp)
  '      colTmp = New TableCell
  '      With colTmp
  '        .Text = "Component ID"
  '        .Font.Bold = True
  '        .CssClass = "colHD"
  '        .Width = 100
  '        .Style.Add("text-align", "left")
  '      End With
  '      rowTmp.Cells.Add(colTmp)
  '      colTmp = New TableCell
  '      With colTmp
  '        .Text = "Description"
  '        .Font.Bold = True
  '        .CssClass = "colHD"
  '        .Width = 300
  '        .Style.Add("text-align", "left")
  '      End With
  '      rowTmp.Cells.Add(colTmp)
  '      colTmp = New TableCell
  '      With colTmp
  '        .Text = "Currency"
  '        .Font.Bold = True
  '        .CssClass = "colHD"
  '        .Width = 60
  '        .Style.Add("text-align", "center")
  '      End With
  '      rowTmp.Cells.Add(colTmp)
  '      colTmp = New TableCell
  '      With colTmp
  '        .Text = "Claimed Amount"
  '        .Font.Bold = True
  '        .CssClass = "colHD"
  '        .Width = 100
  '        .Style.Add("text-align", "right")
  '      End With
  '      rowTmp.Cells.Add(colTmp)
  '      colTmp = New TableCell
  '      With colTmp
  '        .Text = "Out of Entitlement"
  '        .Font.Bold = True
  '        .CssClass = "colHD"
  '        .Width = 200
  '        .Style.Add("text-align", "left")
  '      End With
  '      rowTmp.Cells.Add(colTmp)
  '      colTmp = New TableCell
  '      With colTmp
  '        .Text = "Remarks/Justification"
  '        .Font.Bold = True
  '        .CssClass = "colHD"
  '        .Width = 200
  '        .Style.Add("text-align", "left")
  '      End With
  '      rowTmp.Cells.Add(colTmp)
  '      tblTmp.Rows.Add(rowTmp)
  '      sn = 0
  '      For Each tbd As SIS.TA.taBillDetails In tbDs
  '        If Not tbd.OOEBySystem Then Continue For
  '        sn += 1
  '        rowTmp = New TableRow
  '        rowTmp.BackColor = Drawing.Color.LightPink
  '        colTmp = New TableCell
  '        With colTmp
  '          .CssClass = "rowHD"
  '          .Text = sn
  '          .Style.Add("text-align", "center")
  '        End With
  '        rowTmp.Cells.Add(colTmp)
  '        colTmp = New TableCell
  '        With colTmp
  '          .CssClass = "rowHD"
  '          .Text = tbd.TA_Components9_Description
  '          .Style.Add("text-align", "left")
  '        End With
  '        rowTmp.Cells.Add(colTmp)
  '        colTmp = New TableCell
  '        With colTmp
  '          .CssClass = "rowHD"
  '          .Text = tbd.SystemText
  '          .Style.Add("text-align", "left")
  '        End With
  '        rowTmp.Cells.Add(colTmp)
  '        colTmp = New TableCell
  '        Dim cur As String = ""
  '        Select Case tbd.CurrencyID
  '          Case "INR", "USD", "EURO"
  '            cur = tbd.CurrencyID
  '          Case Else
  '            cur = tbd.CurrencyMain
  '        End Select
  '        With colTmp
  '          .CssClass = "rowHD"
  '          .Text = cur
  '          .Style.Add("text-align", "center")
  '        End With
  '        rowTmp.Cells.Add(colTmp)
  '        colTmp = New TableCell
  '        With colTmp
  '          .CssClass = "rowHD"
  '          .Text = tbd.AmountTotal
  '          .Style.Add("text-align", "right")
  '        End With
  '        rowTmp.Cells.Add(colTmp)
  '        colTmp = New TableCell
  '        With colTmp
  '          .CssClass = "rowHD"
  '          .Text = tbd.OOERemarks
  '          .Style.Add("text-align", "left")
  '        End With
  '        rowTmp.Cells.Add(colTmp)
  '        colTmp = New TableCell
  '        With colTmp
  '          .CssClass = "rowHD"
  '          .Text = tbd.Remarks
  '          .Style.Add("text-align", "left")
  '        End With
  '        rowTmp.Cells.Add(colTmp)
  '        tblTmp.Rows.Add(rowTmp)
  '      Next
  '      pnl1.Controls.Add(tblTmp)
  '    End If
  '  End If
  '  'End of ShowWarning

  '  Dim oTbltaBDFare As Table = Nothing
  '  Dim oRowtaBDFare As TableRow = Nothing
  '  Dim oColtaBDFare As TableCell = Nothing
  '  Dim otaBDFares As List(Of SIS.TA.taBDFare) = SIS.TA.taBDFare.UZ_taBDFareSelectList(0, 999, "", False, "", oVar.TABillNo)
  '  If otaBDFares.Count > 0 Then
  '    Dim oTblhtaBDFare As Table = New Table
  '    oTblhtaBDFare.Width = 1000
  '    oTblhtaBDFare.Style.Add("margin-top", "15px")
  '    oTblhtaBDFare.Style.Add("margin-left", "10px")
  '    oTblhtaBDFare.Style.Add("margin-right", "10px")
  '    Dim oRowhtaBDFare As TableRow = New TableRow
  '    Dim oColhtaBDFare As TableCell = New TableCell
  '    oColhtaBDFare.Font.Bold = True
  '    oColhtaBDFare.Font.Underline = True
  '    oColhtaBDFare.Font.Size = 10
  '    oColhtaBDFare.CssClass = "grpHD"
  '    oColhtaBDFare.Text = "Fare"
  '    oRowhtaBDFare.Cells.Add(oColhtaBDFare)
  '    oTblhtaBDFare.Rows.Add(oRowhtaBDFare)
  '    pnl1.Controls.Add(oTblhtaBDFare)
  '    oTbltaBDFare = New Table
  '    oTbltaBDFare.Width = 1000
  '    oTbltaBDFare.GridLines = GridLines.Both
  '    oTbltaBDFare.Style.Add("margin-left", "10px")
  '    oTbltaBDFare.Style.Add("margin-right", "10px")
  '    oRowtaBDFare = New TableRow
  '    oColtaBDFare = New TableCell
  '    oColtaBDFare.Text = "S.N."
  '    oColtaBDFare.Width = 40
  '    oColtaBDFare.Font.Bold = True
  '    oColtaBDFare.CssClass = "colHD"
  '    oColtaBDFare.Style.Add("text-align", "center")
  '    oRowtaBDFare.Cells.Add(oColtaBDFare)
  '    oColtaBDFare = New TableCell
  '    oColtaBDFare.Text = "Description"
  '    oColtaBDFare.Font.Bold = True
  '    oColtaBDFare.CssClass = "colHD"
  '    oColtaBDFare.Width = 400
  '    oColtaBDFare.Style.Add("text-align", "left")
  '    oColtaBDFare.Width = 400
  '    oRowtaBDFare.Cells.Add(oColtaBDFare)
  '    If oVar.TravelTypeID <> TATravelTypeValues.Domestic Then
  '      oColtaBDFare = New TableCell
  '      oColtaBDFare.Text = "Currency"
  '      oColtaBDFare.Font.Bold = True
  '      oColtaBDFare.CssClass = "colHD"
  '      oColtaBDFare.Width = 60
  '      oColtaBDFare.Style.Add("text-align", "center")
  '      oRowtaBDFare.Cells.Add(oColtaBDFare)
  '    End If
  '    oColtaBDFare = New TableCell
  '    oColtaBDFare.Text = "Claimed Amount"
  '    oColtaBDFare.Font.Bold = True
  '    oColtaBDFare.CssClass = "colHD"
  '    oColtaBDFare.Width = 100
  '    oColtaBDFare.Style.Add("text-align", "right")
  '    oRowtaBDFare.Cells.Add(oColtaBDFare)
  '    oColtaBDFare = New TableCell
  '    oColtaBDFare.Text = "Passed Amount"
  '    oColtaBDFare.Font.Bold = True
  '    oColtaBDFare.CssClass = "colHD"
  '    oColtaBDFare.Width = 100
  '    oColtaBDFare.Style.Add("text-align", "right")
  '    oRowtaBDFare.Cells.Add(oColtaBDFare)
  '    oColtaBDFare = New TableCell
  '    oColtaBDFare.Text = "Remarks"
  '    oColtaBDFare.Font.Bold = True
  '    oColtaBDFare.CssClass = "colHD"
  '    oColtaBDFare.Style.Add("text-align", "left")
  '    oRowtaBDFare.Cells.Add(oColtaBDFare)
  '    oTbltaBDFare.Rows.Add(oRowtaBDFare)
  '    ClaimTot = 0
  '    PassTot = 0
  '    sn = 0
  '    For Each otaBDFare As SIS.TA.taBDFare In otaBDFares
  '      sn += 1
  '      oRowtaBDFare = New TableRow
  '      oColtaBDFare = New TableCell
  '      oColtaBDFare.CssClass = "rowHD"
  '      oColtaBDFare.Text = sn 'otaBDFare.SerialNo
  '      oColtaBDFare.Style.Add("text-align", "center")
  '      oRowtaBDFare.Cells.Add(oColtaBDFare)
  '      oColtaBDFare = New TableCell
  '      oColtaBDFare.CssClass = "rowHD"
  '      oColtaBDFare.Text = otaBDFare.SystemText
  '      oColtaBDFare.Style.Add("text-align", "left")
  '      oRowtaBDFare.Cells.Add(oColtaBDFare)
  '      If oVar.TravelTypeID <> TATravelTypeValues.Domestic Then
  '        Dim cur As String = ""
  '        With otaBDFare
  '          Select Case .CurrencyID
  '            Case "INR", "USD", "EURO"
  '              cur = .CurrencyID
  '            Case Else
  '              cur = .CurrencyMain
  '          End Select
  '        End With
  '        oColtaBDFare = New TableCell
  '        oColtaBDFare.CssClass = "rowHD"
  '        oColtaBDFare.Text = cur
  '        oColtaBDFare.Style.Add("text-align", "center")
  '        oRowtaBDFare.Cells.Add(oColtaBDFare)
  '      End If
  '      oColtaBDFare = New TableCell
  '      oColtaBDFare.CssClass = "rowHD"
  '      oColtaBDFare.Text = otaBDFare.AmountTotal
  '      oColtaBDFare.Style.Add("text-align", "right")
  '      If otaBDFare.OOEBySystem Then
  '        oColtaBDFare.ForeColor = Drawing.Color.Red
  '      End If
  '      oRowtaBDFare.Cells.Add(oColtaBDFare)
  '      oColtaBDFare = New TableCell
  '      oColtaBDFare.CssClass = "rowHD"
  '      oColtaBDFare.Text = otaBDFare.PassedAmountTotal
  '      oColtaBDFare.Style.Add("text-align", "right")
  '      oRowtaBDFare.Cells.Add(oColtaBDFare)
  '      oColtaBDFare = New TableCell
  '      oColtaBDFare.CssClass = "rowHD"
  '      Dim remTbl As New Table
  '      Dim remrow As New TableRow
  '      Dim remaRow As New TableRow
  '      Dim remcol As New TableCell
  '      remTbl.BorderStyle = BorderStyle.None
  '      remcol.Text = otaBDFare.Remarks
  '      remrow.Cells.Add(remcol)
  '      remTbl.Rows.Add(remrow)
  '      remrow = New TableRow
  '      remcol = New TableCell
  '      remcol.Text = otaBDFare.AccountsRemarks
  '      remcol.ForeColor = Drawing.Color.Red
  '      remrow.Cells.Add(remcol)
  '      remTbl.Rows.Add(remrow)
  '      oColtaBDFare.Controls.Add(remTbl)
  '      oColtaBDFare.Style.Add("text-align", "left")
  '      oRowtaBDFare.Cells.Add(oColtaBDFare)
  '      oTbltaBDFare.Rows.Add(oRowtaBDFare)

  '      ClaimTot += otaBDFare.AmountTotal
  '      PassTot += otaBDFare.PassedAmountTotal
  '    Next
  '    If sn > 1 Then
  '      oRow = New TableRow
  '      oCol = New TableCell
  '      With oCol
  '        If oVar.TravelTypeID <> TATravelTypeValues.Domestic Then
  '          .ColumnSpan = 3
  '        Else
  '          .ColumnSpan = 2
  '        End If
  '        .Text = "TOTAL"
  '        .Style.Add("text-align", "right")
  '      End With
  '      oRow.Cells.Add(oCol)
  '      oCol = New TableCell
  '      With oCol
  '        .Text = ClaimTot.ToString("n")
  '        .Style.Add("text-align", "right")
  '      End With
  '      oRow.Cells.Add(oCol)
  '      oCol = New TableCell
  '      With oCol
  '        .Text = PassTot.ToString("n")
  '        .Style.Add("text-align", "right")
  '      End With
  '      oRow.Cells.Add(oCol)
  '      oCol = New TableCell
  '      oRow.Cells.Add(oCol)
  '      oTbltaBDFare.Rows.Add(oRow)
  '    End If
  '    pnl1.Controls.Add(oTbltaBDFare)
  '  End If
  '  Dim oTbltaBDLC As Table = Nothing
  '  Dim oRowtaBDLC As TableRow = Nothing
  '  Dim oColtaBDLC As TableCell = Nothing
  '  Dim otaBDLCs As List(Of SIS.TA.taBDLC) = SIS.TA.taBDLC.UZ_taBDLCSelectList(0, 999, "", False, "", oVar.TABillNo)
  '  If otaBDLCs.Count > 0 Then
  '    Dim oTblhtaBDLC As Table = New Table
  '    oTblhtaBDLC.Width = 1000
  '    oTblhtaBDLC.Style.Add("margin-top", "15px")
  '    oTblhtaBDLC.Style.Add("margin-left", "10px")
  '    oTblhtaBDLC.Style.Add("margin-right", "10px")
  '    Dim oRowhtaBDLC As TableRow = New TableRow
  '    Dim oColhtaBDLC As TableCell = New TableCell
  '    oColhtaBDLC.Font.Bold = True
  '    oColhtaBDLC.Font.Underline = True
  '    oColhtaBDLC.Font.Size = 10
  '    oColhtaBDLC.CssClass = "grpHD"
  '    oColhtaBDLC.Text = "Conveyance Expenses"
  '    oRowhtaBDLC.Cells.Add(oColhtaBDLC)
  '    oTblhtaBDLC.Rows.Add(oRowhtaBDLC)
  '    pnl1.Controls.Add(oTblhtaBDLC)
  '    oTbltaBDLC = New Table
  '    oTbltaBDLC.Width = 1000
  '    oTbltaBDLC.GridLines = GridLines.Both
  '    oTbltaBDLC.Style.Add("margin-left", "10px")
  '    oTbltaBDLC.Style.Add("margin-right", "10px")
  '    oRowtaBDLC = New TableRow
  '    oColtaBDLC = New TableCell
  '    oColtaBDLC.Text = "S.N."
  '    oColtaBDLC.Width = 40
  '    oColtaBDLC.Font.Bold = True
  '    oColtaBDLC.CssClass = "colHD"
  '    oColtaBDLC.Style.Add("text-align", "center")
  '    oRowtaBDLC.Cells.Add(oColtaBDLC)
  '    oColtaBDLC = New TableCell
  '    oColtaBDLC.Text = "Description"
  '    oColtaBDLC.Font.Bold = True
  '    oColtaBDLC.CssClass = "colHD"
  '    oColtaBDLC.Width = 400
  '    oColtaBDLC.Style.Add("text-align", "left")
  '    oRowtaBDLC.Cells.Add(oColtaBDLC)
  '    If oVar.TravelTypeID <> TATravelTypeValues.Domestic Then
  '      oColtaBDLC = New TableCell
  '      oColtaBDLC.Text = "Currency"
  '      oColtaBDLC.Font.Bold = True
  '      oColtaBDLC.CssClass = "colHD"
  '      oColtaBDLC.Width = 60
  '      oColtaBDLC.Style.Add("text-align", "center")
  '      oRowtaBDLC.Cells.Add(oColtaBDLC)
  '    End If
  '    oColtaBDLC = New TableCell
  '    oColtaBDLC.Text = "Claimed Amount"
  '    oColtaBDLC.Font.Bold = True
  '    oColtaBDLC.CssClass = "colHD"
  '    oColtaBDLC.Width = 100
  '    oColtaBDLC.Style.Add("text-align", "right")
  '    oRowtaBDLC.Cells.Add(oColtaBDLC)
  '    oColtaBDLC = New TableCell
  '    oColtaBDLC.Text = "Passed Amount"
  '    oColtaBDLC.Font.Bold = True
  '    oColtaBDLC.CssClass = "colHD"
  '    oColtaBDLC.Width = 100
  '    oColtaBDLC.Style.Add("text-align", "right")
  '    oRowtaBDLC.Cells.Add(oColtaBDLC)
  '    oColtaBDLC = New TableCell
  '    oColtaBDLC.Text = "Remarks"
  '    oColtaBDLC.Font.Bold = True
  '    oColtaBDLC.CssClass = "colHD"
  '    oColtaBDLC.Style.Add("text-align", "left")
  '    oRowtaBDLC.Cells.Add(oColtaBDLC)
  '    oTbltaBDLC.Rows.Add(oRowtaBDLC)
  '    sn = 0
  '    ClaimTot = 0
  '    PassTot = 0
  '    For Each otaBDLC As SIS.TA.taBDLC In otaBDLCs
  '      sn = sn + 1
  '      oRowtaBDLC = New TableRow
  '      oColtaBDLC = New TableCell
  '      oColtaBDLC.CssClass = "rowHD"
  '      oColtaBDLC.Text = sn  ' otaBDLC.SerialNo
  '      oColtaBDLC.Style.Add("text-align", "center")
  '      oRowtaBDLC.Cells.Add(oColtaBDLC)
  '      oColtaBDLC = New TableCell
  '      oColtaBDLC.CssClass = "rowHD"
  '      oColtaBDLC.Text = otaBDLC.SystemText
  '      oColtaBDLC.Style.Add("text-align", "left")
  '      oRowtaBDLC.Cells.Add(oColtaBDLC)
  '      If oVar.TravelTypeID <> TATravelTypeValues.Domestic Then
  '        Dim cur As String = ""
  '        With otaBDLC
  '          Select Case .CurrencyID
  '            Case "INR", "USD", "EURO"
  '              cur = .CurrencyID
  '            Case Else
  '              cur = .CurrencyMain
  '          End Select
  '        End With
  '        oColtaBDLC = New TableCell
  '        oColtaBDLC.CssClass = "rowHD"
  '        oColtaBDLC.Text = cur
  '        oColtaBDLC.Style.Add("text-align", "center")
  '        oRowtaBDLC.Cells.Add(oColtaBDLC)
  '      End If
  '      oColtaBDLC = New TableCell
  '      oColtaBDLC.CssClass = "rowHD"
  '      oColtaBDLC.Text = otaBDLC.AmountTotal
  '      oColtaBDLC.Style.Add("text-align", "right")
  '      If otaBDLC.OOEBySystem Then
  '        oColtaBDLC.ForeColor = Drawing.Color.Red
  '      End If
  '      oRowtaBDLC.Cells.Add(oColtaBDLC)
  '      oColtaBDLC = New TableCell
  '      oColtaBDLC.CssClass = "rowHD"
  '      oColtaBDLC.Text = otaBDLC.PassedAmountTotal
  '      oColtaBDLC.Style.Add("text-align", "right")
  '      oRowtaBDLC.Cells.Add(oColtaBDLC)
  '      oColtaBDLC = New TableCell
  '      oColtaBDLC.CssClass = "rowHD"
  '      Dim remTbl As New Table
  '      Dim remrow As New TableRow
  '      Dim remaRow As New TableRow
  '      Dim remcol As New TableCell
  '      remTbl.BorderStyle = BorderStyle.None
  '      remcol.Text = otaBDLC.Remarks
  '      remrow.Cells.Add(remcol)
  '      remTbl.Rows.Add(remrow)
  '      remrow = New TableRow
  '      remcol = New TableCell
  '      remcol.Text = otaBDLC.AccountsRemarks
  '      remcol.ForeColor = Drawing.Color.Red
  '      remrow.Cells.Add(remcol)
  '      remTbl.Rows.Add(remrow)
  '      oColtaBDLC.Controls.Add(remTbl)
  '      oColtaBDLC.Style.Add("text-align", "left")
  '      oRowtaBDLC.Cells.Add(oColtaBDLC)
  '      oTbltaBDLC.Rows.Add(oRowtaBDLC)

  '      ClaimTot += otaBDLC.AmountTotal
  '      PassTot += otaBDLC.PassedAmountTotal
  '    Next
  '    If sn > 1 Then
  '      oRow = New TableRow
  '      oCol = New TableCell
  '      With oCol
  '        If oVar.TravelTypeID <> TATravelTypeValues.Domestic Then
  '          .ColumnSpan = 3
  '        Else
  '          .ColumnSpan = 2
  '        End If
  '        .Text = "TOTAL"
  '        .Style.Add("text-align", "right")
  '      End With
  '      oRow.Cells.Add(oCol)
  '      oCol = New TableCell
  '      With oCol
  '        .Text = ClaimTot.ToString("n")
  '        .Style.Add("text-align", "right")
  '      End With
  '      oRow.Cells.Add(oCol)
  '      oCol = New TableCell
  '      With oCol
  '        .Text = PassTot.ToString("n")
  '        .Style.Add("text-align", "right")
  '      End With
  '      oRow.Cells.Add(oCol)
  '      oCol = New TableCell
  '      oRow.Cells.Add(oCol)
  '      oTbltaBDLC.Rows.Add(oRow)
  '    End If
  '    pnl1.Controls.Add(oTbltaBDLC)
  '  End If
  '  Dim oTbltaBDLodging As Table = Nothing
  '  Dim oRowtaBDLodging As TableRow = Nothing
  '  Dim oColtaBDLodging As TableCell = Nothing
  '  Dim otaBDLodgings As List(Of SIS.TA.taBDLodging) = SIS.TA.taBDLodging.UZ_taBDLodgingSelectList(0, 999, "", False, "", oVar.TABillNo)
  '  If otaBDLodgings.Count > 0 Then
  '    Dim oTblhtaBDLodging As Table = New Table
  '    oTblhtaBDLodging.Width = 1000
  '    oTblhtaBDLodging.Style.Add("margin-top", "15px")
  '    oTblhtaBDLodging.Style.Add("margin-left", "10px")
  '    oTblhtaBDLodging.Style.Add("margin-right", "10px")
  '    Dim oRowhtaBDLodging As TableRow = New TableRow
  '    Dim oColhtaBDLodging As TableCell = New TableCell
  '    oColhtaBDLodging.Font.Bold = True
  '    oColhtaBDLodging.Font.Underline = True
  '    oColhtaBDLodging.Font.Size = 10
  '    oColhtaBDLodging.CssClass = "grpHD"
  '    oColhtaBDLodging.Text = "Lodging Charges"
  '    oRowhtaBDLodging.Cells.Add(oColhtaBDLodging)
  '    oTblhtaBDLodging.Rows.Add(oRowhtaBDLodging)
  '    pnl1.Controls.Add(oTblhtaBDLodging)
  '    oTbltaBDLodging = New Table
  '    oTbltaBDLodging.Width = 1000
  '    oTbltaBDLodging.GridLines = GridLines.Both
  '    oTbltaBDLodging.Style.Add("margin-left", "10px")
  '    oTbltaBDLodging.Style.Add("margin-right", "10px")
  '    oRowtaBDLodging = New TableRow
  '    oColtaBDLodging = New TableCell
  '    oColtaBDLodging.Text = "S.N."
  '    oColtaBDLodging.Width = 40
  '    oColtaBDLodging.Font.Bold = True
  '    oColtaBDLodging.CssClass = "colHD"
  '    oColtaBDLodging.Style.Add("text-align", "center")
  '    oRowtaBDLodging.Cells.Add(oColtaBDLodging)
  '    oColtaBDLodging = New TableCell
  '    oColtaBDLodging.Text = "Description"
  '    oColtaBDLodging.Font.Bold = True
  '    oColtaBDLodging.CssClass = "colHD"
  '    oColtaBDLodging.Width = 400
  '    oColtaBDLodging.Style.Add("text-align", "left")
  '    oRowtaBDLodging.Cells.Add(oColtaBDLodging)
  '    If oVar.TravelTypeID <> TATravelTypeValues.Domestic Then
  '      oColtaBDLodging = New TableCell
  '      oColtaBDLodging.Text = "Currency"
  '      oColtaBDLodging.Font.Bold = True
  '      oColtaBDLodging.CssClass = "colHD"
  '      oColtaBDLodging.Width = 60
  '      oColtaBDLodging.Style.Add("text-align", "center")
  '      oRowtaBDLodging.Cells.Add(oColtaBDLodging)
  '    End If
  '    oColtaBDLodging = New TableCell
  '    oColtaBDLodging.Text = "Claimed Amount"
  '    oColtaBDLodging.Font.Bold = True
  '    oColtaBDLodging.CssClass = "colHD"
  '    oColtaBDLodging.Width = 100
  '    oColtaBDLodging.Style.Add("text-align", "right")
  '    oRowtaBDLodging.Cells.Add(oColtaBDLodging)
  '    oColtaBDLodging = New TableCell
  '    oColtaBDLodging.Text = "Passed Amount"
  '    oColtaBDLodging.Font.Bold = True
  '    oColtaBDLodging.CssClass = "colHD"
  '    oColtaBDLodging.Width = 100
  '    oColtaBDLodging.Style.Add("text-align", "right")
  '    oRowtaBDLodging.Cells.Add(oColtaBDLodging)
  '    oColtaBDLodging = New TableCell
  '    oColtaBDLodging.Text = "Remarks"
  '    oColtaBDLodging.Font.Bold = True
  '    oColtaBDLodging.CssClass = "colHD"
  '    oColtaBDLodging.Style.Add("text-align", "left")
  '    oRowtaBDLodging.Cells.Add(oColtaBDLodging)
  '    oTbltaBDLodging.Rows.Add(oRowtaBDLodging)
  '    sn = 0
  '    ClaimTot = 0
  '    PassTot = 0
  '    For Each otaBDLodging As SIS.TA.taBDLodging In otaBDLodgings
  '      sn += 1
  '      oRowtaBDLodging = New TableRow
  '      oColtaBDLodging = New TableCell
  '      oColtaBDLodging.CssClass = "rowHD"
  '      Try
  '        If Convert.ToDecimal(otaBDLodging.AssessableValue) > 0 Then
  '          oColtaBDLodging.Text = sn & "*" ' otaBDLodging.SerialNo
  '        End If
  '      Catch ex As Exception
  '        oColtaBDLodging.Text = sn ' otaBDLodging.SerialNo
  '      End Try
  '      oColtaBDLodging.Style.Add("text-align", "center")
  '      oRowtaBDLodging.Cells.Add(oColtaBDLodging)
  '      oColtaBDLodging = New TableCell
  '      oColtaBDLodging.CssClass = "rowHD"
  '      oColtaBDLodging.Text = otaBDLodging.SystemText
  '      oColtaBDLodging.Style.Add("text-align", "left")
  '      oRowtaBDLodging.Cells.Add(oColtaBDLodging)
  '      If oVar.TravelTypeID <> TATravelTypeValues.Domestic Then
  '        Dim cur As String = ""
  '        With otaBDLodging
  '          Select Case .CurrencyID
  '            Case "INR", "USD", "EURO"
  '              cur = .CurrencyID
  '            Case Else
  '              cur = .CurrencyMain
  '          End Select
  '        End With
  '        oColtaBDLodging = New TableCell
  '        oColtaBDLodging.CssClass = "rowHD"
  '        oColtaBDLodging.Text = cur
  '        oColtaBDLodging.Style.Add("text-align", "center")
  '        oRowtaBDLodging.Cells.Add(oColtaBDLodging)
  '      End If
  '      oColtaBDLodging = New TableCell
  '      oColtaBDLodging.CssClass = "rowHD"
  '      oColtaBDLodging.Text = otaBDLodging.AmountTotal
  '      oColtaBDLodging.Style.Add("text-align", "right")
  '      If otaBDLodging.OOEBySystem Then
  '        oColtaBDLodging.ForeColor = Drawing.Color.Red
  '      End If
  '      oRowtaBDLodging.Cells.Add(oColtaBDLodging)
  '      oColtaBDLodging = New TableCell
  '      oColtaBDLodging.CssClass = "rowHD"
  '      oColtaBDLodging.Text = otaBDLodging.PassedAmountTotal
  '      oColtaBDLodging.Style.Add("text-align", "right")
  '      oRowtaBDLodging.Cells.Add(oColtaBDLodging)
  '      oColtaBDLodging = New TableCell
  '      oColtaBDLodging.CssClass = "rowHD"
  '      Dim remTbl As New Table
  '      Dim remrow As New TableRow
  '      Dim remaRow As New TableRow
  '      Dim remcol As New TableCell
  '      remTbl.BorderStyle = BorderStyle.None
  '      remcol.Text = otaBDLodging.Remarks
  '      remrow.Cells.Add(remcol)
  '      remTbl.Rows.Add(remrow)
  '      remrow = New TableRow
  '      remcol = New TableCell
  '      remcol.Text = otaBDLodging.AccountsRemarks
  '      remcol.ForeColor = Drawing.Color.Red
  '      remrow.Cells.Add(remcol)
  '      remTbl.Rows.Add(remrow)
  '      oColtaBDLodging.Controls.Add(remTbl)
  '      oColtaBDLodging.Style.Add("text-align", "left")
  '      oRowtaBDLodging.Cells.Add(oColtaBDLodging)
  '      oTbltaBDLodging.Rows.Add(oRowtaBDLodging)
  '      'GST Details
  '      If oVar.TravelTypeID = TATravelTypeValues.Domestic Then
  '        If otaBDLodging.StayedInHotel Then
  '          otaBDLodging = SIS.TA.taBDLodging.UpdateGSTDataInBDL(otaBDLodging)
  '          oTbl = New Table
  '          oTbl.Width = 945
  '          oTbl.GridLines = GridLines.None
  '          oTbl.Style.Add("margin-top", "2px")
  '          oTbl.Style.Add("margin-left", "2px")

  '          oRow = New TableRow
  '          oCol = New TableCell
  '          oCol.Text = "Hotel Name:"
  '          oCol.Font.Bold = True
  '          oRow.Cells.Add(oCol)
  '          oCol = New TableCell
  '          oCol.Text = otaBDLodging.ModeText
  '          oRow.Cells.Add(oCol)
  '          oCol = New TableCell
  '          oCol.Text = "Type:"
  '          oCol.Font.Bold = True
  '          oRow.Cells.Add(oCol)
  '          oCol = New TableCell
  '          oCol.Text = otaBDLodging.PurchaseType
  '          oRow.Cells.Add(oCol)
  '          oCol = New TableCell
  '          oCol.Text = "Isgec GSTIN:"
  '          oCol.Font.Bold = True
  '          oRow.Cells.Add(oCol)
  '          oCol = New TableCell
  '          oCol.Text = otaBDLodging.SPMT_IsgecGSTIN4_Description
  '          oRow.Cells.Add(oCol)
  '          oTbl.Rows.Add(oRow)

  '          oRow = New TableRow
  '          oCol = New TableCell
  '          oCol.Text = "Hotel GSTIN:"
  '          oCol.Font.Bold = True
  '          oRow.Cells.Add(oCol)
  '          oCol = New TableCell
  '          oCol.Text = IIf(otaBDLodging.VR_BPGSTIN7_Description = "", otaBDLodging.SupplierGSTINNo, otaBDLodging.VR_BPGSTIN7_Description)
  '          oRow.Cells.Add(oCol)
  '          oCol = New TableCell
  '          oCol.Text = "Bill Number:"
  '          oCol.Font.Bold = True
  '          oRow.Cells.Add(oCol)
  '          oCol = New TableCell
  '          oCol.Text = otaBDLodging.BillNumber
  '          oRow.Cells.Add(oCol)
  '          oCol = New TableCell
  '          oCol.Text = "Bill Date:"
  '          oCol.Font.Bold = True
  '          oRow.Cells.Add(oCol)
  '          oCol = New TableCell
  '          oCol.Text = otaBDLodging.BillDate
  '          oRow.Cells.Add(oCol)
  '          oTbl.Rows.Add(oRow)

  '          oRow = New TableRow
  '          oCol = New TableCell
  '          oCol.Text = "Assessable Value:"
  '          oCol.Font.Bold = True
  '          oRow.Cells.Add(oCol)
  '          oCol = New TableCell
  '          oCol.Text = otaBDLodging.AssessableValue
  '          oRow.Cells.Add(oCol)
  '          oCol = New TableCell
  '          oCol.Text = "Total GST:"
  '          oCol.Font.Bold = True
  '          oRow.Cells.Add(oCol)
  '          oCol = New TableCell
  '          oCol.Text = otaBDLodging.TotalGST
  '          oRow.Cells.Add(oCol)
  '          oCol = New TableCell
  '          oCol.Text = "Total Amount:"
  '          oCol.Font.Bold = True
  '          oRow.Cells.Add(oCol)
  '          oCol = New TableCell
  '          oCol.Text = otaBDLodging.TotalAmount
  '          oRow.Cells.Add(oCol)
  '          oTbl.Rows.Add(oRow)


  '          oRowtaBDLodging = New TableRow
  '          oColtaBDLodging = New TableCell
  '          oRowtaBDLodging.Cells.Add(oColtaBDLodging)
  '          oColtaBDLodging = New TableCell
  '          oColtaBDLodging.ColumnSpan = "4"
  '          oColtaBDLodging.Controls.Add(oTbl)
  '          oRowtaBDLodging.Cells.Add(oColtaBDLodging)
  '          oTbltaBDLodging.Rows.Add(oRowtaBDLodging)
  '        End If
  '      End If
  '      'End GST Details
  '      ClaimTot += otaBDLodging.AmountTotal
  '      PassTot += otaBDLodging.PassedAmountTotal
  '    Next
  '    If sn > 1 Then
  '      oRow = New TableRow
  '      oCol = New TableCell
  '      With oCol
  '        If oVar.TravelTypeID <> TATravelTypeValues.Domestic Then
  '          .ColumnSpan = 3
  '        Else
  '          .ColumnSpan = 2
  '        End If
  '        .Text = "TOTAL"
  '        .Style.Add("text-align", "right")
  '      End With
  '      oRow.Cells.Add(oCol)
  '      oCol = New TableCell
  '      With oCol
  '        .Text = ClaimTot.ToString("n")
  '        .Style.Add("text-align", "right")
  '      End With
  '      oRow.Cells.Add(oCol)
  '      oCol = New TableCell
  '      With oCol
  '        .Text = PassTot.ToString("n")
  '        .Style.Add("text-align", "right")
  '      End With
  '      oRow.Cells.Add(oCol)
  '      oCol = New TableCell
  '      oRow.Cells.Add(oCol)
  '      oTbltaBDLodging.Rows.Add(oRow)
  '    End If
  '    pnl1.Controls.Add(oTbltaBDLodging)
  '  End If
  '  Dim oTbltaBDExpense As Table = Nothing
  '  Dim oRowtaBDExpense As TableRow = Nothing
  '  Dim oColtaBDExpense As TableCell = Nothing
  '  Dim otaBDExpenses As List(Of SIS.TA.taBDExpense) = SIS.TA.taBDExpense.UZ_taBDExpenseSelectList(0, 999, "", False, "", oVar.TABillNo)
  '  If otaBDExpenses.Count > 0 Then
  '    Dim oTblhtaBDExpense As Table = New Table
  '    oTblhtaBDExpense.Width = 1000
  '    oTblhtaBDExpense.Style.Add("margin-top", "15px")
  '    oTblhtaBDExpense.Style.Add("margin-left", "10px")
  '    oTblhtaBDExpense.Style.Add("margin-right", "10px")
  '    Dim oRowhtaBDExpense As TableRow = New TableRow
  '    Dim oColhtaBDExpense As TableCell = New TableCell
  '    oColhtaBDExpense.Font.Bold = True
  '    oColhtaBDExpense.Font.Underline = True
  '    oColhtaBDExpense.Font.Size = 10
  '    oColhtaBDExpense.CssClass = "grpHD"
  '    If oVar.TravelTypeID = TATravelTypeValues.Domestic Then
  '      oColhtaBDExpense.Text = "Other Expenses"
  '    Else
  '      oColhtaBDExpense.Text = "Other Expenses [Only with MD Sanction]"
  '    End If
  '    oRowhtaBDExpense.Cells.Add(oColhtaBDExpense)
  '    oTblhtaBDExpense.Rows.Add(oRowhtaBDExpense)
  '    pnl1.Controls.Add(oTblhtaBDExpense)
  '    oTbltaBDExpense = New Table
  '    oTbltaBDExpense.Width = 1000
  '    oTbltaBDExpense.GridLines = GridLines.Both
  '    oTbltaBDExpense.Style.Add("margin-left", "10px")
  '    oTbltaBDExpense.Style.Add("margin-right", "10px")
  '    oRowtaBDExpense = New TableRow
  '    oColtaBDExpense = New TableCell
  '    oColtaBDExpense.Text = "S.N."
  '    oColtaBDExpense.Width = 40
  '    oColtaBDExpense.Font.Bold = True
  '    oColtaBDExpense.CssClass = "colHD"
  '    oColtaBDExpense.Style.Add("text-align", "center")
  '    oRowtaBDExpense.Cells.Add(oColtaBDExpense)
  '    oColtaBDExpense = New TableCell
  '    oColtaBDExpense.Text = "Description"
  '    oColtaBDExpense.Font.Bold = True
  '    oColtaBDExpense.CssClass = "colHD"
  '    oColtaBDExpense.Width = 400
  '    oColtaBDExpense.Style.Add("text-align", "left")
  '    oRowtaBDExpense.Cells.Add(oColtaBDExpense)
  '    If oVar.TravelTypeID <> TATravelTypeValues.Domestic Then
  '      oColtaBDExpense = New TableCell
  '      oColtaBDExpense.Text = "Currency"
  '      oColtaBDExpense.Font.Bold = True
  '      oColtaBDExpense.CssClass = "colHD"
  '      oColtaBDExpense.Width = 60
  '      oColtaBDExpense.Style.Add("text-align", "center")
  '      oRowtaBDExpense.Cells.Add(oColtaBDExpense)
  '    End If
  '    oColtaBDExpense = New TableCell
  '    oColtaBDExpense.Text = "Claimed Amount"
  '    oColtaBDExpense.Font.Bold = True
  '    oColtaBDExpense.CssClass = "colHD"
  '    oColtaBDExpense.Width = 100
  '    oColtaBDExpense.Style.Add("text-align", "right")
  '    oRowtaBDExpense.Cells.Add(oColtaBDExpense)
  '    oColtaBDExpense = New TableCell
  '    oColtaBDExpense.Text = "Passed Amount"
  '    oColtaBDExpense.Font.Bold = True
  '    oColtaBDExpense.CssClass = "colHD"
  '    oColtaBDExpense.Width = 100
  '    oColtaBDExpense.Style.Add("text-align", "right")
  '    oRowtaBDExpense.Cells.Add(oColtaBDExpense)
  '    oColtaBDExpense = New TableCell
  '    oColtaBDExpense.Text = "Remarks"
  '    oColtaBDExpense.Font.Bold = True
  '    oColtaBDExpense.CssClass = "colHD"
  '    oColtaBDExpense.Style.Add("text-align", "left")
  '    oRowtaBDExpense.Cells.Add(oColtaBDExpense)
  '    oTbltaBDExpense.Rows.Add(oRowtaBDExpense)
  '    sn = 0
  '    ClaimTot = 0
  '    PassTot = 0
  '    For Each otaBDExpense As SIS.TA.taBDExpense In otaBDExpenses
  '      sn += 1
  '      oRowtaBDExpense = New TableRow
  '      oColtaBDExpense = New TableCell
  '      oColtaBDExpense.CssClass = "rowHD"
  '      oColtaBDExpense.Text = sn ' otaBDExpense.SerialNo
  '      oColtaBDExpense.Style.Add("text-align", "center")
  '      oRowtaBDExpense.Cells.Add(oColtaBDExpense)
  '      oColtaBDExpense = New TableCell
  '      oColtaBDExpense.CssClass = "rowHD"
  '      oColtaBDExpense.Text = otaBDExpense.SystemText
  '      oColtaBDExpense.Style.Add("text-align", "left")
  '      oRowtaBDExpense.Cells.Add(oColtaBDExpense)
  '      If oVar.TravelTypeID <> TATravelTypeValues.Domestic Then
  '        Dim cur As String = ""
  '        With otaBDExpense
  '          Select Case .CurrencyID
  '            Case "INR", "USD", "EURO"
  '              cur = .CurrencyID
  '            Case Else
  '              cur = .CurrencyMain
  '          End Select
  '        End With
  '        oColtaBDExpense = New TableCell
  '        oColtaBDExpense.CssClass = "rowHD"
  '        oColtaBDExpense.Text = cur
  '        oColtaBDExpense.Style.Add("text-align", "center")
  '        oRowtaBDExpense.Cells.Add(oColtaBDExpense)
  '      End If
  '      oColtaBDExpense = New TableCell
  '      oColtaBDExpense.CssClass = "rowHD"
  '      oColtaBDExpense.Text = otaBDExpense.AmountTotal
  '      oColtaBDExpense.Style.Add("text-align", "right")
  '      If otaBDExpense.OOEBySystem Then
  '        oColtaBDExpense.ForeColor = Drawing.Color.Red
  '      End If
  '      oRowtaBDExpense.Cells.Add(oColtaBDExpense)
  '      oColtaBDExpense = New TableCell
  '      oColtaBDExpense.CssClass = "rowHD"
  '      oColtaBDExpense.Text = otaBDExpense.PassedAmountTotal
  '      oColtaBDExpense.Style.Add("text-align", "right")
  '      oRowtaBDExpense.Cells.Add(oColtaBDExpense)
  '      oColtaBDExpense = New TableCell
  '      oColtaBDExpense.CssClass = "rowHD"
  '      Dim remTbl As New Table
  '      Dim remrow As New TableRow
  '      Dim remaRow As New TableRow
  '      Dim remcol As New TableCell
  '      remTbl.BorderStyle = BorderStyle.None
  '      remcol.Text = otaBDExpense.Remarks
  '      remrow.Cells.Add(remcol)
  '      remTbl.Rows.Add(remrow)
  '      remrow = New TableRow
  '      remcol = New TableCell
  '      remcol.Text = otaBDExpense.AccountsRemarks
  '      remcol.ForeColor = Drawing.Color.Red
  '      remrow.Cells.Add(remcol)
  '      remTbl.Rows.Add(remrow)
  '      oColtaBDExpense.Controls.Add(remTbl)
  '      oColtaBDExpense.Style.Add("text-align", "left")
  '      oRowtaBDExpense.Cells.Add(oColtaBDExpense)
  '      oTbltaBDExpense.Rows.Add(oRowtaBDExpense)
  '      ClaimTot += otaBDExpense.AmountTotal
  '      PassTot += otaBDExpense.PassedAmountTotal
  '    Next
  '    If sn > 1 Then
  '      oRow = New TableRow
  '      oCol = New TableCell
  '      With oCol
  '        If oVar.TravelTypeID <> TATravelTypeValues.Domestic Then
  '          .ColumnSpan = 3
  '        Else
  '          .ColumnSpan = 2
  '        End If
  '        .Text = "TOTAL"
  '        .Style.Add("text-align", "right")
  '      End With
  '      oRow.Cells.Add(oCol)
  '      oCol = New TableCell
  '      With oCol
  '        .Text = ClaimTot.ToString("n")
  '        .Style.Add("text-align", "right")
  '      End With
  '      oRow.Cells.Add(oCol)
  '      oCol = New TableCell
  '      With oCol
  '        .Text = PassTot.ToString("n")
  '        .Style.Add("text-align", "right")
  '      End With
  '      oRow.Cells.Add(oCol)
  '      oCol = New TableCell
  '      oRow.Cells.Add(oCol)
  '      oTbltaBDExpense.Rows.Add(oRow)
  '    End If
  '    pnl1.Controls.Add(oTbltaBDExpense)
  '  End If
  '  Dim oTbltaBDFinance As Table = Nothing
  '  Dim oRowtaBDFinance As TableRow = Nothing
  '  Dim oColtaBDFinance As TableCell = Nothing
  '  Dim otaBDFinances As List(Of SIS.TA.taBDFinance) = SIS.TA.taBDFinance.UZ_taBDFinanceSelectList(0, 999, "", False, "", oVar.TABillNo)
  '  If otaBDFinances.Count > 0 Then
  '    Dim oTblhtaBDFinance As Table = New Table
  '    oTblhtaBDFinance.Width = 1000
  '    oTblhtaBDFinance.Style.Add("margin-top", "15px")
  '    oTblhtaBDFinance.Style.Add("margin-left", "10px")
  '    oTblhtaBDFinance.Style.Add("margin-right", "10px")
  '    Dim oRowhtaBDFinance As TableRow = New TableRow
  '    Dim oColhtaBDFinance As TableCell = New TableCell
  '    oColhtaBDFinance.Font.Bold = True
  '    oColhtaBDFinance.Font.Underline = True
  '    oColhtaBDFinance.Font.Size = 10
  '    oColhtaBDFinance.CssClass = "grpHD"
  '    oColhtaBDFinance.Text = "Source of Finance"
  '    oRowhtaBDFinance.Cells.Add(oColhtaBDFinance)
  '    oTblhtaBDFinance.Rows.Add(oRowhtaBDFinance)
  '    pnl1.Controls.Add(oTblhtaBDFinance)
  '    oTbltaBDFinance = New Table
  '    oTbltaBDFinance.Width = 1000
  '    oTbltaBDFinance.GridLines = GridLines.Both
  '    oTbltaBDFinance.Style.Add("margin-left", "10px")
  '    oTbltaBDFinance.Style.Add("margin-right", "10px")
  '    oRowtaBDFinance = New TableRow
  '    oColtaBDFinance = New TableCell
  '    oColtaBDFinance.Text = "S.N."
  '    oColtaBDFinance.Width = 40
  '    oColtaBDFinance.Font.Bold = True
  '    oColtaBDFinance.CssClass = "colHD"
  '    oColtaBDFinance.Style.Add("text-align", "center")
  '    oRowtaBDFinance.Cells.Add(oColtaBDFinance)
  '    oColtaBDFinance = New TableCell
  '    oColtaBDFinance.Text = "Description"
  '    oColtaBDFinance.Font.Bold = True
  '    oColtaBDFinance.CssClass = "colHD"
  '    oColtaBDFinance.Width = 400
  '    oColtaBDFinance.Style.Add("text-align", "left")
  '    oRowtaBDFinance.Cells.Add(oColtaBDFinance)
  '    If oVar.TravelTypeID <> TATravelTypeValues.Domestic Then
  '      oColtaBDFinance = New TableCell
  '      oColtaBDFinance.Text = "Currency"
  '      oColtaBDFinance.Font.Bold = True
  '      oColtaBDFinance.CssClass = "colHD"
  '      oColtaBDFinance.Width = 60
  '      oColtaBDFinance.Style.Add("text-align", "center")
  '      oRowtaBDFinance.Cells.Add(oColtaBDFinance)
  '    End If
  '    oColtaBDFinance = New TableCell
  '    oColtaBDFinance.Text = "Financed Amount"
  '    oColtaBDFinance.Font.Bold = True
  '    oColtaBDFinance.CssClass = "colHD"
  '    oColtaBDFinance.Width = 100
  '    oColtaBDFinance.Style.Add("text-align", "right")
  '    oRowtaBDFinance.Cells.Add(oColtaBDFinance)
  '    oColtaBDFinance = New TableCell
  '    oColtaBDFinance.Text = "Acknowledged Amount"
  '    oColtaBDFinance.Font.Bold = True
  '    oColtaBDFinance.CssClass = "colHD"
  '    oColtaBDFinance.Width = 100
  '    oColtaBDFinance.Style.Add("text-align", "right")
  '    oRowtaBDFinance.Cells.Add(oColtaBDFinance)
  '    oColtaBDFinance = New TableCell
  '    oColtaBDFinance.Text = "Remarks"
  '    oColtaBDFinance.Font.Bold = True
  '    oColtaBDFinance.CssClass = "colHD"
  '    oColtaBDFinance.Style.Add("text-align", "left")
  '    oRowtaBDFinance.Cells.Add(oColtaBDFinance)
  '    oTbltaBDFinance.Rows.Add(oRowtaBDFinance)
  '    sn = 0
  '    ClaimTot = 0
  '    PassTot = 0
  '    For Each otaBDFinance As SIS.TA.taBDFinance In otaBDFinances
  '      sn += 1
  '      oRowtaBDFinance = New TableRow
  '      oColtaBDFinance = New TableCell
  '      oColtaBDFinance.CssClass = "rowHD"
  '      oColtaBDFinance.Text = sn 'otaBDFinance.SerialNo
  '      oColtaBDFinance.Style.Add("text-align", "center")
  '      oRowtaBDFinance.Cells.Add(oColtaBDFinance)
  '      oColtaBDFinance = New TableCell
  '      oColtaBDFinance.CssClass = "rowHD"
  '      oColtaBDFinance.Text = otaBDFinance.SystemText
  '      oColtaBDFinance.Style.Add("text-align", "left")
  '      oRowtaBDFinance.Cells.Add(oColtaBDFinance)
  '      If oVar.TravelTypeID <> TATravelTypeValues.Domestic Then
  '        Dim cur As String = ""
  '        With otaBDFinance
  '          Select Case .CurrencyID
  '            Case "INR", "USD", "EURO"
  '              cur = .CurrencyID
  '            Case Else
  '              cur = .CurrencyMain
  '          End Select
  '        End With
  '        oColtaBDFinance = New TableCell
  '        oColtaBDFinance.CssClass = "rowHD"
  '        oColtaBDFinance.Text = cur
  '        oColtaBDFinance.Style.Add("text-align", "center")
  '        oRowtaBDFinance.Cells.Add(oColtaBDFinance)
  '      End If
  '      oColtaBDFinance = New TableCell
  '      oColtaBDFinance.CssClass = "rowHD"
  '      oColtaBDFinance.Text = otaBDFinance.AmountTotal
  '      oColtaBDFinance.Style.Add("text-align", "right")
  '      If otaBDFinance.OOEBySystem Then
  '        oColtaBDFinance.ForeColor = Drawing.Color.Red
  '      End If
  '      oRowtaBDFinance.Cells.Add(oColtaBDFinance)
  '      oColtaBDFinance = New TableCell
  '      oColtaBDFinance.CssClass = "rowHD"
  '      oColtaBDFinance.Text = otaBDFinance.PassedAmountTotal
  '      oColtaBDFinance.Style.Add("text-align", "right")
  '      oRowtaBDFinance.Cells.Add(oColtaBDFinance)
  '      oColtaBDFinance = New TableCell
  '      oColtaBDFinance.CssClass = "rowHD"
  '      Dim remTbl As New Table
  '      Dim remrow As New TableRow
  '      Dim remaRow As New TableRow
  '      Dim remcol As New TableCell
  '      remTbl.BorderStyle = BorderStyle.None
  '      remcol.Text = otaBDFinance.Remarks
  '      remrow.Cells.Add(remcol)
  '      remTbl.Rows.Add(remrow)
  '      remrow = New TableRow
  '      remcol = New TableCell
  '      remcol.Text = otaBDFinance.AccountsRemarks
  '      remcol.ForeColor = Drawing.Color.Red
  '      remrow.Cells.Add(remcol)
  '      remTbl.Rows.Add(remrow)
  '      oColtaBDFinance.Controls.Add(remTbl)
  '      oColtaBDFinance.Style.Add("text-align", "left")
  '      oRowtaBDFinance.Cells.Add(oColtaBDFinance)
  '      oTbltaBDFinance.Rows.Add(oRowtaBDFinance)
  '      ClaimTot += otaBDFinance.AmountTotal
  '      PassTot += otaBDFinance.PassedAmountTotal
  '    Next
  '    If sn > 1 Then
  '      oRow = New TableRow
  '      oCol = New TableCell
  '      With oCol
  '        If oVar.TravelTypeID <> TATravelTypeValues.Domestic Then
  '          .ColumnSpan = 3
  '        Else
  '          .ColumnSpan = 2
  '        End If
  '        .Text = "TOTAL"
  '        .Style.Add("text-align", "right")
  '      End With
  '      oRow.Cells.Add(oCol)
  '      oCol = New TableCell
  '      With oCol
  '        .Text = ClaimTot.ToString("n")
  '        .Style.Add("text-align", "right")
  '      End With
  '      oRow.Cells.Add(oCol)
  '      oCol = New TableCell
  '      With oCol
  '        .Text = PassTot.ToString("n")
  '        .Style.Add("text-align", "right")
  '      End With
  '      oRow.Cells.Add(oCol)
  '      oCol = New TableCell
  '      oRow.Cells.Add(oCol)
  '      oTbltaBDFinance.Rows.Add(oRow)
  '    End If
  '    pnl1.Controls.Add(oTbltaBDFinance)
  '  End If
  '  Dim oTbltaBDMileage As Table = Nothing
  '  Dim oRowtaBDMileage As TableRow = Nothing
  '  Dim oColtaBDMileage As TableCell = Nothing
  '  Dim otaBDMileages As List(Of SIS.TA.taBDMileage) = SIS.TA.taBDMileage.UZ_taBDMileageSelectList(0, 999, "", False, "", oVar.TABillNo)
  '  If otaBDMileages.Count > 0 Then
  '    Dim oTblhtaBDMileage As Table = New Table
  '    oTblhtaBDMileage.Width = 1000
  '    oTblhtaBDMileage.Style.Add("margin-top", "15px")
  '    oTblhtaBDMileage.Style.Add("margin-left", "10px")
  '    oTblhtaBDMileage.Style.Add("margin-right", "10px")
  '    Dim oRowhtaBDMileage As TableRow = New TableRow
  '    Dim oColhtaBDMileage As TableCell = New TableCell
  '    oColhtaBDMileage.Font.Bold = True
  '    oColhtaBDMileage.Font.Underline = True
  '    oColhtaBDMileage.Font.Size = 10
  '    oColhtaBDMileage.CssClass = "grpHD"
  '    oColhtaBDMileage.Text = "Mileage Claim"
  '    oRowhtaBDMileage.Cells.Add(oColhtaBDMileage)
  '    oTblhtaBDMileage.Rows.Add(oRowhtaBDMileage)
  '    pnl1.Controls.Add(oTblhtaBDMileage)
  '    oTbltaBDMileage = New Table
  '    oTbltaBDMileage.Width = 1000
  '    oTbltaBDMileage.GridLines = GridLines.Both
  '    oTbltaBDMileage.Style.Add("margin-left", "10px")
  '    oTbltaBDMileage.Style.Add("margin-right", "10px")
  '    oRowtaBDMileage = New TableRow
  '    oColtaBDMileage = New TableCell
  '    oColtaBDMileage.Text = "S.N."
  '    oColtaBDMileage.Width = 40
  '    oColtaBDMileage.Font.Bold = True
  '    oColtaBDMileage.CssClass = "colHD"
  '    oColtaBDMileage.Style.Add("text-align", "center")
  '    oRowtaBDMileage.Cells.Add(oColtaBDMileage)
  '    oColtaBDMileage = New TableCell
  '    oColtaBDMileage.Text = "Description"
  '    oColtaBDMileage.Font.Bold = True
  '    oColtaBDMileage.CssClass = "colHD"
  '    oColtaBDMileage.Width = 400
  '    oColtaBDMileage.Style.Add("text-align", "left")
  '    oRowtaBDMileage.Cells.Add(oColtaBDMileage)
  '    oColtaBDMileage = New TableCell
  '    oColtaBDMileage.Text = "Claimed Amount"
  '    oColtaBDMileage.Font.Bold = True
  '    oColtaBDMileage.CssClass = "colHD"
  '    oColtaBDMileage.Width = 100
  '    oColtaBDMileage.Style.Add("text-align", "right")
  '    oRowtaBDMileage.Cells.Add(oColtaBDMileage)
  '    oColtaBDMileage = New TableCell
  '    oColtaBDMileage.Text = "Passed Amount"
  '    oColtaBDMileage.Font.Bold = True
  '    oColtaBDMileage.CssClass = "colHD"
  '    oColtaBDMileage.Width = 100
  '    oColtaBDMileage.Style.Add("text-align", "right")
  '    oRowtaBDMileage.Cells.Add(oColtaBDMileage)
  '    oColtaBDMileage = New TableCell
  '    oColtaBDMileage.Text = "Remarks"
  '    oColtaBDMileage.Font.Bold = True
  '    oColtaBDMileage.CssClass = "colHD"
  '    oColtaBDMileage.Style.Add("text-align", "left")
  '    oRowtaBDMileage.Cells.Add(oColtaBDMileage)
  '    oTbltaBDMileage.Rows.Add(oRowtaBDMileage)
  '    sn = 0
  '    ClaimTot = 0
  '    PassTot = 0
  '    For Each otaBDMileage As SIS.TA.taBDMileage In otaBDMileages
  '      sn += 1
  '      oRowtaBDMileage = New TableRow
  '      oColtaBDMileage = New TableCell
  '      oColtaBDMileage.CssClass = "rowHD"
  '      oColtaBDMileage.Text = sn ' otaBDMileage.SerialNo
  '      oColtaBDMileage.Style.Add("text-align", "center")
  '      oRowtaBDMileage.Cells.Add(oColtaBDMileage)
  '      oColtaBDMileage = New TableCell
  '      oColtaBDMileage.CssClass = "rowHD"
  '      oColtaBDMileage.Text = otaBDMileage.SystemText
  '      oColtaBDMileage.Style.Add("text-align", "left")
  '      oRowtaBDMileage.Cells.Add(oColtaBDMileage)
  '      oColtaBDMileage = New TableCell
  '      oColtaBDMileage.CssClass = "rowHD"
  '      oColtaBDMileage.Text = otaBDMileage.AmountTotal
  '      oColtaBDMileage.Style.Add("text-align", "right")
  '      If otaBDMileage.OOEBySystem Then
  '        oColtaBDMileage.ForeColor = Drawing.Color.Red
  '      End If
  '      oRowtaBDMileage.Cells.Add(oColtaBDMileage)
  '      oColtaBDMileage = New TableCell
  '      oColtaBDMileage.CssClass = "rowHD"
  '      oColtaBDMileage.Text = otaBDMileage.PassedAmountTotal
  '      oColtaBDMileage.Style.Add("text-align", "right")
  '      oRowtaBDMileage.Cells.Add(oColtaBDMileage)
  '      oColtaBDMileage = New TableCell
  '      oColtaBDMileage.CssClass = "rowHD"
  '      Dim remTbl As New Table
  '      Dim remrow As New TableRow
  '      Dim remaRow As New TableRow
  '      Dim remcol As New TableCell
  '      remTbl.BorderStyle = BorderStyle.None
  '      remcol.Text = otaBDMileage.Remarks
  '      remrow.Cells.Add(remcol)
  '      remTbl.Rows.Add(remrow)
  '      remrow = New TableRow
  '      remcol = New TableCell
  '      remcol.Text = otaBDMileage.AccountsRemarks
  '      remcol.ForeColor = Drawing.Color.Red
  '      remrow.Cells.Add(remcol)
  '      remTbl.Rows.Add(remrow)
  '      oColtaBDMileage.Controls.Add(remTbl)
  '      oColtaBDMileage.Style.Add("text-align", "left")
  '      oRowtaBDMileage.Cells.Add(oColtaBDMileage)
  '      oTbltaBDMileage.Rows.Add(oRowtaBDMileage)
  '      ClaimTot += otaBDMileage.AmountTotal
  '      PassTot += otaBDMileage.PassedAmountTotal
  '    Next
  '    If sn > 1 Then
  '      oRow = New TableRow
  '      oCol = New TableCell
  '      With oCol
  '        If oVar.TravelTypeID <> TATravelTypeValues.Domestic Then
  '          .ColumnSpan = 3
  '        Else
  '          .ColumnSpan = 2
  '        End If
  '        .Text = "TOTAL"
  '        .Style.Add("text-align", "right")
  '      End With
  '      oRow.Cells.Add(oCol)
  '      oCol = New TableCell
  '      With oCol
  '        .Text = ClaimTot.ToString("n")
  '        .Style.Add("text-align", "right")
  '      End With
  '      oRow.Cells.Add(oCol)
  '      oCol = New TableCell
  '      With oCol
  '        .Text = PassTot.ToString("n")
  '        .Style.Add("text-align", "right")
  '      End With
  '      oRow.Cells.Add(oCol)
  '      oCol = New TableCell
  '      oRow.Cells.Add(oCol)
  '      oTbltaBDMileage.Rows.Add(oRow)
  '    End If
  '    pnl1.Controls.Add(oTbltaBDMileage)
  '  End If
  '  Dim oTbltaBDDriver As Table = Nothing
  '  Dim oRowtaBDDriver As TableRow = Nothing
  '  Dim oColtaBDDriver As TableCell = Nothing
  '  Dim otaBDDrivers As List(Of SIS.TA.taBDDriver) = SIS.TA.taBDDriver.UZ_taBDDriverSelectList(0, 999, "", False, "", oVar.TABillNo)
  '  If otaBDDrivers.Count > 0 Then
  '    Dim oTblhtaBDDriver As Table = New Table
  '    oTblhtaBDDriver.Width = 1000
  '    oTblhtaBDDriver.Style.Add("margin-top", "15px")
  '    oTblhtaBDDriver.Style.Add("margin-left", "10px")
  '    oTblhtaBDDriver.Style.Add("margin-right", "10px")
  '    Dim oRowhtaBDDriver As TableRow = New TableRow
  '    Dim oColhtaBDDriver As TableCell = New TableCell
  '    oColhtaBDDriver.Font.Bold = True
  '    oColhtaBDDriver.Font.Underline = True
  '    oColhtaBDDriver.Font.Size = 10
  '    oColhtaBDDriver.CssClass = "grpHD"
  '    oColhtaBDDriver.Text = "Driver Charges"
  '    oRowhtaBDDriver.Cells.Add(oColhtaBDDriver)
  '    oTblhtaBDDriver.Rows.Add(oRowhtaBDDriver)
  '    pnl1.Controls.Add(oTblhtaBDDriver)
  '    oTbltaBDDriver = New Table
  '    oTbltaBDDriver.Width = 1000
  '    oTbltaBDDriver.GridLines = GridLines.Both
  '    oTbltaBDDriver.Style.Add("margin-left", "10px")
  '    oTbltaBDDriver.Style.Add("margin-right", "10px")
  '    oRowtaBDDriver = New TableRow
  '    oColtaBDDriver = New TableCell
  '    oColtaBDDriver.Text = "S.N."
  '    oColhtaBDDriver.Width = 40
  '    oColtaBDDriver.Font.Bold = True
  '    oColtaBDDriver.CssClass = "colHD"
  '    oColtaBDDriver.Style.Add("text-align", "center")
  '    oRowtaBDDriver.Cells.Add(oColtaBDDriver)
  '    oColtaBDDriver = New TableCell
  '    oColtaBDDriver.Text = "Description"
  '    oColtaBDDriver.Font.Bold = True
  '    oColtaBDDriver.CssClass = "colHD"
  '    oColtaBDDriver.Width = 400
  '    oColtaBDDriver.Style.Add("text-align", "left")
  '    oRowtaBDDriver.Cells.Add(oColtaBDDriver)
  '    oColtaBDDriver = New TableCell
  '    oColtaBDDriver.Text = "Claimed Amount"
  '    oColtaBDDriver.Font.Bold = True
  '    oColtaBDDriver.CssClass = "colHD"
  '    oColtaBDDriver.Width = 100
  '    oColtaBDDriver.Style.Add("text-align", "right")
  '    oRowtaBDDriver.Cells.Add(oColtaBDDriver)
  '    oColtaBDDriver = New TableCell
  '    oColtaBDDriver.Text = "Passed Amount"
  '    oColtaBDDriver.Font.Bold = True
  '    oColtaBDDriver.CssClass = "colHD"
  '    oColtaBDDriver.Width = 100
  '    oColtaBDDriver.Style.Add("text-align", "right")
  '    oRowtaBDDriver.Cells.Add(oColtaBDDriver)
  '    oColtaBDDriver = New TableCell
  '    oColtaBDDriver.Text = "Remarks"
  '    oColtaBDDriver.Font.Bold = True
  '    oColtaBDDriver.CssClass = "colHD"
  '    oColtaBDDriver.Style.Add("text-align", "left")
  '    oRowtaBDDriver.Cells.Add(oColtaBDDriver)
  '    oTbltaBDDriver.Rows.Add(oRowtaBDDriver)
  '    sn = 0
  '    ClaimTot = 0
  '    PassTot = 0
  '    For Each otaBDDriver As SIS.TA.taBDDriver In otaBDDrivers
  '      sn += 1
  '      oRowtaBDDriver = New TableRow
  '      oColtaBDDriver = New TableCell
  '      oColtaBDDriver.CssClass = "rowHD"
  '      oColtaBDDriver.Text = sn 'otaBDDriver.SerialNo
  '      oColtaBDDriver.Style.Add("text-align", "center")
  '      oRowtaBDDriver.Cells.Add(oColtaBDDriver)
  '      oColtaBDDriver = New TableCell
  '      oColtaBDDriver.CssClass = "rowHD"
  '      oColtaBDDriver.Text = otaBDDriver.SystemText
  '      oColtaBDDriver.Style.Add("text-align", "left")
  '      oRowtaBDDriver.Cells.Add(oColtaBDDriver)
  '      oColtaBDDriver = New TableCell
  '      oColtaBDDriver.CssClass = "rowHD"
  '      oColtaBDDriver.Text = otaBDDriver.AmountTotal
  '      oColtaBDDriver.Style.Add("text-align", "right")
  '      If otaBDDriver.OOEBySystem Then
  '        oColtaBDDriver.ForeColor = Drawing.Color.Red
  '      End If
  '      oRowtaBDDriver.Cells.Add(oColtaBDDriver)
  '      oColtaBDDriver = New TableCell
  '      oColtaBDDriver.CssClass = "rowHD"
  '      oColtaBDDriver.Text = otaBDDriver.PassedAmountTotal
  '      oColtaBDDriver.Style.Add("text-align", "right")
  '      oRowtaBDDriver.Cells.Add(oColtaBDDriver)
  '      oColtaBDDriver = New TableCell
  '      oColtaBDDriver.CssClass = "rowHD"
  '      Dim remTbl As New Table
  '      Dim remrow As New TableRow
  '      Dim remaRow As New TableRow
  '      Dim remcol As New TableCell
  '      remTbl.BorderStyle = BorderStyle.None
  '      remcol.Text = otaBDDriver.Remarks
  '      remrow.Cells.Add(remcol)
  '      remTbl.Rows.Add(remrow)
  '      remrow = New TableRow
  '      remcol = New TableCell
  '      remcol.Text = otaBDDriver.AccountsRemarks
  '      remcol.ForeColor = Drawing.Color.Red
  '      remrow.Cells.Add(remcol)
  '      remTbl.Rows.Add(remrow)
  '      oColtaBDDriver.Controls.Add(remTbl)
  '      oColtaBDDriver.Style.Add("text-align", "left")
  '      oRowtaBDDriver.Cells.Add(oColtaBDDriver)
  '      oTbltaBDDriver.Rows.Add(oRowtaBDDriver)
  '      ClaimTot += otaBDDriver.AmountTotal
  '      PassTot += otaBDDriver.PassedAmountTotal
  '    Next
  '    If sn > 1 Then
  '      oRow = New TableRow
  '      oCol = New TableCell
  '      With oCol
  '        If oVar.TravelTypeID <> TATravelTypeValues.Domestic Then
  '          .ColumnSpan = 3
  '        Else
  '          .ColumnSpan = 2
  '        End If
  '        .Text = "TOTAL"
  '        .Style.Add("text-align", "right")
  '      End With
  '      oRow.Cells.Add(oCol)
  '      oCol = New TableCell
  '      With oCol
  '        .Text = ClaimTot.ToString("n")
  '        .Style.Add("text-align", "right")
  '      End With
  '      oRow.Cells.Add(oCol)
  '      oCol = New TableCell
  '      With oCol
  '        .Text = PassTot.ToString("n")
  '        .Style.Add("text-align", "right")
  '      End With
  '      oRow.Cells.Add(oCol)
  '      oCol = New TableCell
  '      oRow.Cells.Add(oCol)
  '      oTbltaBDDriver.Rows.Add(oRow)
  '    End If
  '    pnl1.Controls.Add(oTbltaBDDriver)
  '  End If
  '  Dim oTbltaBDDA As Table = Nothing
  '  Dim oRowtaBDDA As TableRow = Nothing
  '  Dim oColtaBDDA As TableCell = Nothing
  '  Dim otaBDDAs As List(Of SIS.TA.taBDDA) = SIS.TA.taBDDA.UZ_taBDDASelectList(0, 999, "", False, "", oVar.TABillNo)
  '  If otaBDDAs.Count > 0 Then
  '    Dim oTblhtaBDDA As Table = New Table
  '    oTblhtaBDDA.Width = 1000
  '    oTblhtaBDDA.Style.Add("margin-top", "15px")
  '    oTblhtaBDDA.Style.Add("margin-left", "10px")
  '    oTblhtaBDDA.Style.Add("margin-right", "10px")
  '    Dim oRowhtaBDDA As TableRow = New TableRow
  '    Dim oColhtaBDDA As TableCell = New TableCell
  '    oColhtaBDDA.Font.Bold = True
  '    oColhtaBDDA.Font.Underline = True
  '    oColhtaBDDA.Font.Size = 10
  '    oColhtaBDDA.CssClass = "grpHD"
  '    oColhtaBDDA.Text = "Daily Allowance"
  '    oRowhtaBDDA.Cells.Add(oColhtaBDDA)
  '    oTblhtaBDDA.Rows.Add(oRowhtaBDDA)
  '    pnl1.Controls.Add(oTblhtaBDDA)
  '    oTbltaBDDA = New Table
  '    oTbltaBDDA.Width = 1000
  '    oTbltaBDDA.GridLines = GridLines.Both
  '    oTbltaBDDA.Style.Add("margin-left", "10px")
  '    oTbltaBDDA.Style.Add("margin-right", "10px")
  '    oRowtaBDDA = New TableRow
  '    oColtaBDDA = New TableCell
  '    oColtaBDDA.Text = "S.N."
  '    oColtaBDDA.Width = 40
  '    oColtaBDDA.Font.Bold = True
  '    oColtaBDDA.CssClass = "colHD"
  '    oColtaBDDA.Style.Add("text-align", "center")
  '    oRowtaBDDA.Cells.Add(oColtaBDDA)
  '    oColtaBDDA = New TableCell
  '    oColtaBDDA.Text = "Description"
  '    oColtaBDDA.Font.Bold = True
  '    oColtaBDDA.CssClass = "colHD"
  '    oColtaBDDA.Width = 400
  '    oColtaBDDA.Style.Add("text-align", "left")
  '    oRowtaBDDA.Cells.Add(oColtaBDDA)
  '    If oVar.TravelTypeID <> TATravelTypeValues.Domestic Then
  '      oColtaBDDA = New TableCell
  '      oColtaBDDA.Text = "Currency"
  '      oColtaBDDA.Font.Bold = True
  '      oColtaBDDA.CssClass = "colHD"
  '      oColtaBDDA.Width = 60
  '      oColtaBDDA.Style.Add("text-align", "center")
  '      oRowtaBDDA.Cells.Add(oColtaBDDA)
  '    End If
  '    oColtaBDDA = New TableCell
  '    oColtaBDDA.Text = "Claimed Amount"
  '    oColtaBDDA.Font.Bold = True
  '    oColtaBDDA.CssClass = "colHD"
  '    oColtaBDDA.Width = 100
  '    oColtaBDDA.Style.Add("text-align", "right")
  '    oRowtaBDDA.Cells.Add(oColtaBDDA)
  '    oColtaBDDA = New TableCell
  '    oColtaBDDA.Text = "Passed Amount"
  '    oColtaBDDA.Font.Bold = True
  '    oColtaBDDA.CssClass = "colHD"
  '    oColtaBDDA.Width = 100
  '    oColtaBDDA.Style.Add("text-align", "right")
  '    oRowtaBDDA.Cells.Add(oColtaBDDA)
  '    oColtaBDDA = New TableCell
  '    oColtaBDDA.Text = "Remarks"
  '    oColtaBDDA.Font.Bold = True
  '    oColtaBDDA.CssClass = "colHD"
  '    oColtaBDDA.Style.Add("text-align", "left")
  '    oRowtaBDDA.Cells.Add(oColtaBDDA)
  '    oTbltaBDDA.Rows.Add(oRowtaBDDA)
  '    sn = 0
  '    ClaimTot = 0
  '    PassTot = 0
  '    For Each otaBDDA As SIS.TA.taBDDA In otaBDDAs
  '      sn += 1
  '      oRowtaBDDA = New TableRow
  '      oColtaBDDA = New TableCell
  '      oColtaBDDA.CssClass = "rowHD"
  '      oColtaBDDA.Text = sn 'otaBDDA.SerialNo
  '      oColtaBDDA.Style.Add("text-align", "center")
  '      oRowtaBDDA.Cells.Add(oColtaBDDA)
  '      oColtaBDDA = New TableCell
  '      oColtaBDDA.CssClass = "rowHD"
  '      oColtaBDDA.Text = otaBDDA.SystemText
  '      oColtaBDDA.Style.Add("text-align", "left")
  '      oRowtaBDDA.Cells.Add(oColtaBDDA)
  '      If oVar.TravelTypeID <> TATravelTypeValues.Domestic Then
  '        oColtaBDDA = New TableCell
  '        oColtaBDDA.CssClass = "rowHD"
  '        oColtaBDDA.Text = otaBDDA.CurrencyID
  '        oColtaBDDA.Style.Add("text-align", "center")
  '        oRowtaBDDA.Cells.Add(oColtaBDDA)
  '      End If
  '      oColtaBDDA = New TableCell
  '      oColtaBDDA.CssClass = "rowHD"
  '      oColtaBDDA.Text = otaBDDA.AmountTotal
  '      oColtaBDDA.Style.Add("text-align", "right")
  '      If otaBDDA.OOEBySystem Then
  '        oColtaBDDA.ForeColor = Drawing.Color.Red
  '      End If
  '      oRowtaBDDA.Cells.Add(oColtaBDDA)
  '      oColtaBDDA = New TableCell
  '      oColtaBDDA.CssClass = "rowHD"
  '      oColtaBDDA.Text = otaBDDA.PassedAmountTotal
  '      oColtaBDDA.Style.Add("text-align", "right")
  '      oRowtaBDDA.Cells.Add(oColtaBDDA)
  '      oColtaBDDA = New TableCell
  '      oColtaBDDA.CssClass = "rowHD"
  '      Dim remTbl As New Table
  '      Dim remrow As New TableRow
  '      Dim remaRow As New TableRow
  '      Dim remcol As New TableCell
  '      remTbl.BorderStyle = BorderStyle.None
  '      remcol.Text = otaBDDA.Remarks
  '      remrow.Cells.Add(remcol)
  '      remTbl.Rows.Add(remrow)
  '      remrow = New TableRow
  '      remcol = New TableCell
  '      remcol.Text = otaBDDA.AccountsRemarks
  '      remcol.ForeColor = Drawing.Color.Red
  '      remrow.Cells.Add(remcol)
  '      remTbl.Rows.Add(remrow)
  '      oColtaBDDA.Controls.Add(remTbl)
  '      oColtaBDDA.Style.Add("text-align", "left")
  '      oRowtaBDDA.Cells.Add(oColtaBDDA)
  '      oTbltaBDDA.Rows.Add(oRowtaBDDA)
  '      ClaimTot += otaBDDA.AmountTotal
  '      PassTot += otaBDDA.PassedAmountTotal
  '    Next
  '    If sn > 1 Then
  '      oRow = New TableRow
  '      oCol = New TableCell
  '      With oCol
  '        If oVar.TravelTypeID <> TATravelTypeValues.Domestic Then
  '          .ColumnSpan = 3
  '        Else
  '          .ColumnSpan = 2
  '        End If
  '        .Text = "TOTAL"
  '        .Style.Add("text-align", "right")
  '      End With
  '      oRow.Cells.Add(oCol)
  '      oCol = New TableCell
  '      With oCol
  '        .Text = ClaimTot.ToString("n")
  '        .Style.Add("text-align", "right")
  '      End With
  '      oRow.Cells.Add(oCol)
  '      oCol = New TableCell
  '      With oCol
  '        .Text = PassTot.ToString("n")
  '        .Style.Add("text-align", "right")
  '      End With
  '      oRow.Cells.Add(oCol)
  '      oCol = New TableCell
  '      oRow.Cells.Add(oCol)
  '      oTbltaBDDA.Rows.Add(oRow)
  '    End If
  '    pnl1.Controls.Add(oTbltaBDDA)
  '  End If

  '  'Accounts
  '  Dim oTbltaCDAccounts As Table = Nothing
  '  Dim oRowtaCDAccounts As TableRow = Nothing
  '  Dim oColtaCDAccounts As TableCell = Nothing
  '  Dim otaCDAccountss As List(Of SIS.TA.taCDAccounts) = SIS.TA.taCDAccounts.UZ_taCDAccountsSelectList(0, 999, "", False, "", oVar.TABillNo)
  '  If otaCDAccountss.Count > 0 Then
  '    Dim oTblhtaCDAccounts As Table = New Table
  '    oTblhtaCDAccounts.Width = 1000
  '    oTblhtaCDAccounts.Style.Add("margin-top", "15px")
  '    oTblhtaCDAccounts.Style.Add("margin-left", "10px")
  '    oTblhtaCDAccounts.Style.Add("margin-right", "10px")
  '    Dim oRowhtaCDAccounts As TableRow = New TableRow
  '    Dim oColhtaCDAccounts As TableCell = New TableCell
  '    oColhtaCDAccounts.Font.Bold = True
  '    oColhtaCDAccounts.Font.Underline = True
  '    oColhtaCDAccounts.Font.Size = 10
  '    oColhtaCDAccounts.CssClass = "grpHD"
  '    oColhtaCDAccounts.Text = "Debit / Credit by Accounts"
  '    oRowhtaCDAccounts.Cells.Add(oColhtaCDAccounts)
  '    oTblhtaCDAccounts.Rows.Add(oRowhtaCDAccounts)
  '    pnl1.Controls.Add(oTblhtaCDAccounts)
  '    oTbltaCDAccounts = New Table
  '    oTbltaCDAccounts.Width = 1000
  '    oTbltaCDAccounts.GridLines = GridLines.Both
  '    oTbltaCDAccounts.Style.Add("margin-left", "10px")
  '    oTbltaCDAccounts.Style.Add("margin-right", "10px")
  '    oRowtaCDAccounts = New TableRow
  '    oColtaCDAccounts = New TableCell
  '    oColtaCDAccounts.Text = "S.N."
  '    oColtaCDAccounts.Width = 40
  '    oColtaCDAccounts.Font.Bold = True
  '    oColtaCDAccounts.CssClass = "colHD"
  '    oColtaCDAccounts.Style.Add("text-align", "center")
  '    oRowtaCDAccounts.Cells.Add(oColtaCDAccounts)
  '    oColtaCDAccounts = New TableCell
  '    oColtaCDAccounts.Text = "Description"
  '    oColtaCDAccounts.Font.Bold = True
  '    oColtaCDAccounts.CssClass = "colHD"
  '    oColtaCDAccounts.Width = 400
  '    oColtaCDAccounts.Style.Add("text-align", "left")
  '    oRowtaCDAccounts.Cells.Add(oColtaCDAccounts)
  '    If oVar.TravelTypeID <> TATravelTypeValues.Domestic Then
  '      oColtaCDAccounts = New TableCell
  '      oColtaCDAccounts.Text = "Currency"
  '      oColtaCDAccounts.Font.Bold = True
  '      oColtaCDAccounts.CssClass = "colHD"
  '      oColtaCDAccounts.Width = 60
  '      oColtaCDAccounts.Style.Add("text-align", "center")
  '      oRowtaCDAccounts.Cells.Add(oColtaCDAccounts)
  '    End If
  '    oColtaCDAccounts = New TableCell
  '    oColtaCDAccounts.Text = "Debit Amount"
  '    oColtaCDAccounts.Font.Bold = True
  '    oColtaCDAccounts.CssClass = "colHD"
  '    oColtaCDAccounts.Width = 100
  '    oColtaCDAccounts.Style.Add("text-align", "right")
  '    oRowtaCDAccounts.Cells.Add(oColtaCDAccounts)
  '    oColtaCDAccounts = New TableCell
  '    oColtaCDAccounts.Text = "Credit Amount"
  '    oColtaCDAccounts.Font.Bold = True
  '    oColtaCDAccounts.CssClass = "colHD"
  '    oColtaCDAccounts.Width = 100
  '    oColtaCDAccounts.Style.Add("text-align", "right")
  '    oRowtaCDAccounts.Cells.Add(oColtaCDAccounts)
  '    oColtaCDAccounts = New TableCell
  '    oColtaCDAccounts.Text = "Remarks"
  '    oColtaCDAccounts.Font.Bold = True
  '    oColtaCDAccounts.CssClass = "colHD"
  '    oColtaCDAccounts.Style.Add("text-align", "left")
  '    oRowtaCDAccounts.Cells.Add(oColtaCDAccounts)
  '    oTbltaCDAccounts.Rows.Add(oRowtaCDAccounts)
  '    sn = 0
  '    ClaimTot = 0
  '    PassTot = 0
  '    For Each otaCDAccounts As SIS.TA.taCDAccounts In otaCDAccountss
  '      sn += 1
  '      oRowtaCDAccounts = New TableRow
  '      oColtaCDAccounts = New TableCell
  '      oColtaCDAccounts.CssClass = "rowHD"
  '      oColtaCDAccounts.Text = sn
  '      oColtaCDAccounts.Style.Add("text-align", "center")
  '      oRowtaCDAccounts.Cells.Add(oColtaCDAccounts)
  '      oColtaCDAccounts = New TableCell
  '      oColtaCDAccounts.CssClass = "rowHD"
  '      oColtaCDAccounts.Text = otaCDAccounts.Remarks
  '      oColtaCDAccounts.Style.Add("text-align", "left")
  '      oRowtaCDAccounts.Cells.Add(oColtaCDAccounts)
  '      If oVar.TravelTypeID <> TATravelTypeValues.Domestic Then
  '        Dim cur As String = ""
  '        With otaCDAccounts
  '          Select Case .CurrencyID
  '            Case "INR", "USD", "EURO"
  '              cur = .CurrencyID
  '            Case Else
  '              cur = .CurrencyMain
  '          End Select
  '        End With
  '        oColtaCDAccounts = New TableCell
  '        oColtaCDAccounts.CssClass = "rowHD"
  '        oColtaCDAccounts.Text = cur
  '        oColtaCDAccounts.Style.Add("text-align", "center")
  '        oRowtaCDAccounts.Cells.Add(oColtaCDAccounts)
  '      End If
  '      oColtaCDAccounts = New TableCell
  '      oColtaCDAccounts.CssClass = "rowHD"
  '      oColtaCDAccounts.Text = IIf(otaCDAccounts.AmountTotal < 0, otaCDAccounts.AmountTotal, "")
  '      oColtaCDAccounts.Style.Add("text-align", "right")
  '      oRowtaCDAccounts.Cells.Add(oColtaCDAccounts)
  '      oColtaCDAccounts = New TableCell
  '      oColtaCDAccounts.CssClass = "rowHD"
  '      oColtaCDAccounts.Text = IIf(otaCDAccounts.AmountTotal > 0, otaCDAccounts.AmountTotal, "")
  '      oColtaCDAccounts.Style.Add("text-align", "right")
  '      oRowtaCDAccounts.Cells.Add(oColtaCDAccounts)
  '      oColtaCDAccounts = New TableCell
  '      oColtaCDAccounts.CssClass = "rowHD"
  '      Dim remTbl As New Table
  '      Dim remrow As New TableRow
  '      Dim remaRow As New TableRow
  '      Dim remcol As New TableCell
  '      remTbl.BorderStyle = BorderStyle.None
  '      remcol.Text = ""
  '      remrow.Cells.Add(remcol)
  '      remTbl.Rows.Add(remrow)
  '      remrow = New TableRow
  '      remcol = New TableCell
  '      remcol.Text = ""
  '      remcol.ForeColor = Drawing.Color.Red
  '      remrow.Cells.Add(remcol)
  '      remTbl.Rows.Add(remrow)
  '      oColtaCDAccounts.Controls.Add(remTbl)
  '      oColtaCDAccounts.Style.Add("text-align", "left")
  '      oRowtaCDAccounts.Cells.Add(oColtaCDAccounts)
  '      oTbltaCDAccounts.Rows.Add(oRowtaCDAccounts)
  '      ClaimTot += otaCDAccounts.AmountTotal
  '      PassTot += otaCDAccounts.PassedAmountTotal
  '    Next
  '    If sn > 1 Then
  '      oRow = New TableRow
  '      oCol = New TableCell
  '      With oCol
  '        If oVar.TravelTypeID <> TATravelTypeValues.Domestic Then
  '          .ColumnSpan = 3
  '        Else
  '          .ColumnSpan = 2
  '        End If
  '        .Text = "TOTAL"
  '        .Style.Add("text-align", "right")
  '      End With
  '      oRow.Cells.Add(oCol)
  '      oCol = New TableCell
  '      With oCol
  '        .Text = ClaimTot.ToString("n")
  '        .Style.Add("text-align", "right")
  '      End With
  '      oRow.Cells.Add(oCol)
  '      oCol = New TableCell
  '      With oCol
  '        .Text = PassTot.ToString("n")
  '        .Style.Add("text-align", "right")
  '      End With
  '      oRow.Cells.Add(oCol)
  '      oCol = New TableCell
  '      oRow.Cells.Add(oCol)
  '      oTbltaCDAccounts.Rows.Add(oRow)
  '    End If
  '    pnl1.Controls.Add(oTbltaCDAccounts)
  '  End If
  '  '========End Accounts============
  '  Dim oTbltaBillPrjAmounts As Table = Nothing
  '  Dim oRowtaBillPrjAmounts As TableRow = Nothing
  '  Dim oColtaBillPrjAmounts As TableCell = Nothing
  '  Dim otaBillPrjAmountss As List(Of SIS.TA.taBillPrjAmounts) = SIS.TA.taBillPrjAmounts.UZ_taBillPrjAmountsSelectList(0, 999, "", False, "", oVar.TABillNo)
  '  If otaBillPrjAmountss.Count > 0 Then
  '    Dim oTblhtaBillPrjAmounts As Table = New Table
  '    oTblhtaBillPrjAmounts.Width = 1000
  '    oTblhtaBillPrjAmounts.Style.Add("margin-top", "15px")
  '    oTblhtaBillPrjAmounts.Style.Add("margin-left", "10px")
  '    oTblhtaBillPrjAmounts.Style.Add("margin-right", "10px")
  '    Dim oRowhtaBillPrjAmounts As TableRow = New TableRow
  '    Dim oColhtaBillPrjAmounts As TableCell = New TableCell
  '    oColhtaBillPrjAmounts.Font.Bold = True
  '    oColhtaBillPrjAmounts.Font.Underline = True
  '    oColhtaBillPrjAmounts.Font.Size = 10
  '    oColhtaBillPrjAmounts.CssClass = "grpHD"
  '    oColhtaBillPrjAmounts.Text = "Bill Project wise total"
  '    oRowhtaBillPrjAmounts.Cells.Add(oColhtaBillPrjAmounts)
  '    oTblhtaBillPrjAmounts.Rows.Add(oRowhtaBillPrjAmounts)
  '    pnl1.Controls.Add(oTblhtaBillPrjAmounts)
  '    oTbltaBillPrjAmounts = New Table
  '    oTbltaBillPrjAmounts.Width = 1000
  '    oTbltaBillPrjAmounts.GridLines = GridLines.Both
  '    oTbltaBillPrjAmounts.Style.Add("margin-left", "10px")
  '    oTbltaBillPrjAmounts.Style.Add("margin-right", "10px")
  '    oRowtaBillPrjAmounts = New TableRow
  '    oColtaBillPrjAmounts = New TableCell
  '    oColtaBillPrjAmounts.Text = "Project ID"
  '    oColtaBillPrjAmounts.Font.Bold = True
  '    oColtaBillPrjAmounts.CssClass = "colHD"
  '    oColtaBillPrjAmounts.Style.Add("text-align", "left")
  '    oRowtaBillPrjAmounts.Cells.Add(oColtaBillPrjAmounts)
  '    oColtaBillPrjAmounts = New TableCell
  '    oColtaBillPrjAmounts.Text = "Project Description"
  '    oColtaBillPrjAmounts.Font.Bold = True
  '    oColtaBillPrjAmounts.CssClass = "colHD"
  '    oColtaBillPrjAmounts.Style.Add("text-align", "left")
  '    oRowtaBillPrjAmounts.Cells.Add(oColtaBillPrjAmounts)
  '    oColtaBillPrjAmounts = New TableCell
  '    oColtaBillPrjAmounts.Text = "Percentage"
  '    oColtaBillPrjAmounts.Font.Bold = True
  '    oColtaBillPrjAmounts.CssClass = "colHD"
  '    oColtaBillPrjAmounts.Style.Add("text-align", "right")
  '    oRowtaBillPrjAmounts.Cells.Add(oColtaBillPrjAmounts)
  '    oColtaBillPrjAmounts = New TableCell
  '    oColtaBillPrjAmounts.Text = "Total Amount [INR]"
  '    oColtaBillPrjAmounts.Font.Bold = True
  '    oColtaBillPrjAmounts.CssClass = "colHD"
  '    oColtaBillPrjAmounts.Style.Add("text-align", "right")
  '    oRowtaBillPrjAmounts.Cells.Add(oColtaBillPrjAmounts)
  '    oTbltaBillPrjAmounts.Rows.Add(oRowtaBillPrjAmounts)
  '    For Each otaBillPrjAmounts As SIS.TA.taBillPrjAmounts In otaBillPrjAmountss
  '      oRowtaBillPrjAmounts = New TableRow
  '      oColtaBillPrjAmounts = New TableCell
  '      oColtaBillPrjAmounts.Text = otaBillPrjAmounts.ProjectID
  '      oColtaBillPrjAmounts.CssClass = "rowHD"
  '      oColtaBillPrjAmounts.Style.Add("text-align", "left")
  '      oRowtaBillPrjAmounts.Cells.Add(oColtaBillPrjAmounts)
  '      oColtaBillPrjAmounts = New TableCell
  '      oColtaBillPrjAmounts.Text = otaBillPrjAmounts.IDM_Projects1_Description
  '      oColtaBillPrjAmounts.CssClass = "rowHD"
  '      oColtaBillPrjAmounts.Style.Add("text-align", "left")
  '      oRowtaBillPrjAmounts.Cells.Add(oColtaBillPrjAmounts)
  '      oColtaBillPrjAmounts = New TableCell
  '      oColtaBillPrjAmounts.CssClass = "rowHD"
  '      oColtaBillPrjAmounts.Text = otaBillPrjAmounts.Percentage
  '      oColtaBillPrjAmounts.Style.Add("text-align", "right")
  '      oRowtaBillPrjAmounts.Cells.Add(oColtaBillPrjAmounts)
  '      oColtaBillPrjAmounts = New TableCell
  '      oColtaBillPrjAmounts.CssClass = "rowHD"
  '      oColtaBillPrjAmounts.Text = otaBillPrjAmounts.TotalAmountinINR
  '      oColtaBillPrjAmounts.Style.Add("text-align", "right")
  '      oRowtaBillPrjAmounts.Cells.Add(oColtaBillPrjAmounts)
  '      oTbltaBillPrjAmounts.Rows.Add(oRowtaBillPrjAmounts)
  '    Next
  '    pnl1.Controls.Add(oTbltaBillPrjAmounts)
  '  End If
  '  Dim oTbltaBillAmount As Table = Nothing
  '  Dim oRowtaBillAmount As TableRow = Nothing
  '  Dim oColtaBillAmount As TableCell = Nothing
  '  Dim otaBillAmounts As List(Of SIS.TA.taBillAmount) = SIS.TA.taBillAmount.UZ_taBillAmountSelectList(0, 999, "", False, "", oVar.TABillNo)
  '  If otaBillAmounts.Count > 0 Then
  '    Dim oTblhtaBillAmount As Table = New Table
  '    oTblhtaBillAmount.Width = 1000
  '    oTblhtaBillAmount.Style.Add("margin-top", "15px")
  '    oTblhtaBillAmount.Style.Add("margin-left", "10px")
  '    oTblhtaBillAmount.Style.Add("margin-right", "10px")
  '    Dim oRowhtaBillAmount As TableRow = New TableRow
  '    Dim oColhtaBillAmount As TableCell = New TableCell
  '    oColhtaBillAmount.Font.Bold = True
  '    oColhtaBillAmount.Font.Underline = True
  '    oColhtaBillAmount.Font.Size = 10
  '    oColhtaBillAmount.CssClass = "grpHD"
  '    oColhtaBillAmount.Text = "Bill Amounts"
  '    oRowhtaBillAmount.Cells.Add(oColhtaBillAmount)
  '    oTblhtaBillAmount.Rows.Add(oRowhtaBillAmount)
  '    pnl1.Controls.Add(oTblhtaBillAmount)
  '    oTbltaBillAmount = New Table
  '    oTbltaBillAmount.Width = 1000
  '    oTbltaBillAmount.GridLines = GridLines.Both
  '    oTbltaBillAmount.Style.Add("margin-left", "10px")
  '    oTbltaBillAmount.Style.Add("margin-right", "10px")
  '    oRowtaBillAmount = New TableRow
  '    oColtaBillAmount = New TableCell
  '    oColtaBillAmount.Text = "COMPONENT"
  '    oColtaBillAmount.Font.Bold = True
  '    oColtaBillAmount.CssClass = "colHD"
  '    oColtaBillAmount.Style.Add("text-align", "left")
  '    oRowtaBillAmount.Cells.Add(oColtaBillAmount)
  '    oColtaBillAmount = New TableCell
  '    oColtaBillAmount.Text = "CURRENCY"
  '    oColtaBillAmount.Font.Bold = True
  '    oColtaBillAmount.CssClass = "colHD"
  '    oColtaBillAmount.Style.Add("text-align", "center")
  '    oRowtaBillAmount.Cells.Add(oColtaBillAmount)
  '    oColtaBillAmount = New TableCell
  '    oColtaBillAmount.Text = "COST CENTER"
  '    oColtaBillAmount.Font.Bold = True
  '    oColtaBillAmount.CssClass = "colHD"
  '    oColtaBillAmount.Style.Add("text-align", "left")
  '    oRowtaBillAmount.Cells.Add(oColtaBillAmount)
  '    oColtaBillAmount = New TableCell
  '    oColtaBillAmount.Text = "TOTAL"
  '    oColtaBillAmount.Font.Bold = True
  '    oColtaBillAmount.CssClass = "colHD"
  '    oColtaBillAmount.Style.Add("text-align", "right")
  '    oRowtaBillAmount.Cells.Add(oColtaBillAmount)
  '    oColtaBillAmount = New TableCell
  '    oColtaBillAmount.Text = "Avg. C.F. INR"
  '    oColtaBillAmount.Font.Bold = True
  '    oColtaBillAmount.CssClass = "colHD"
  '    oColtaBillAmount.Style.Add("text-align", "center")
  '    oRowtaBillAmount.Cells.Add(oColtaBillAmount)
  '    oColtaBillAmount = New TableCell
  '    oColtaBillAmount.Text = "TOTAL [INR]"
  '    oColtaBillAmount.Font.Bold = True
  '    oColtaBillAmount.CssClass = "colHD"
  '    oColtaBillAmount.Style.Add("text-align", "right")
  '    oRowtaBillAmount.Cells.Add(oColtaBillAmount)
  '    oTbltaBillAmount.Rows.Add(oRowtaBillAmount)
  '    Dim gTot As Decimal = 0
  '    For Each otaBillAmount As SIS.TA.taBillAmount In otaBillAmounts
  '      Dim cur As String = ""
  '      With otaBillAmount
  '        Select Case .CurrencyID
  '          Case "INR", "USD", "EURO"
  '            cur = .CurrencyID
  '          Case Else
  '            cur = oVar.BillCurrencyID
  '        End Select
  '      End With
  '      If otaBillAmount.ComponentID = TAComponentTypes.Total Then
  '        gTot += otaBillAmount.TotalInINR
  '      End If
  '      oRowtaBillAmount = New TableRow
  '      oColtaBillAmount = New TableCell
  '      oColtaBillAmount.Text = otaBillAmount.TA_Components4_Description
  '      oColtaBillAmount.CssClass = "rowHD"
  '      oColtaBillAmount.Style.Add("text-align", "left")
  '      oRowtaBillAmount.Cells.Add(oColtaBillAmount)
  '      oColtaBillAmount = New TableCell
  '      oColtaBillAmount.Text = cur   'otaBillAmount.TA_Currencies5_CurrencyName
  '      oColtaBillAmount.CssClass = "rowHD"
  '      oColtaBillAmount.Style.Add("text-align", "center")
  '      oRowtaBillAmount.Cells.Add(oColtaBillAmount)
  '      oColtaBillAmount = New TableCell
  '      oColtaBillAmount.Text = otaBillAmount.HRM_Departments1_Description
  '      oColtaBillAmount.CssClass = "rowHD"
  '      oColtaBillAmount.Style.Add("text-align", "left")
  '      oRowtaBillAmount.Cells.Add(oColtaBillAmount)
  '      oColtaBillAmount = New TableCell
  '      oColtaBillAmount.CssClass = "rowHD"
  '      oColtaBillAmount.Text = otaBillAmount.TotalInCurrency
  '      oColtaBillAmount.Style.Add("text-align", "right")
  '      oRowtaBillAmount.Cells.Add(oColtaBillAmount)
  '      oColtaBillAmount = New TableCell
  '      oColtaBillAmount.CssClass = "rowHD"
  '      Try
  '        oColtaBillAmount.Text = (otaBillAmount.TotalInINR / otaBillAmount.TotalInCurrency).ToString("n")
  '      Catch ex As Exception
  '        oColtaBillAmount.Text = "1.00"
  '      End Try
  '      oColtaBillAmount.Style.Add("text-align", "center")
  '      oRowtaBillAmount.Cells.Add(oColtaBillAmount)
  '      oColtaBillAmount = New TableCell
  '      oColtaBillAmount.CssClass = "rowHD"
  '      oColtaBillAmount.Text = otaBillAmount.TotalInINR
  '      oColtaBillAmount.Style.Add("text-align", "right")
  '      oRowtaBillAmount.Cells.Add(oColtaBillAmount)
  '      oTbltaBillAmount.Rows.Add(oRowtaBillAmount)
  '    Next
  '    oRowtaBillAmount = New TableRow
  '    oColtaBillAmount = New TableCell
  '    oColtaBillAmount.Text = "GRAND TOTAL IN INR"
  '    oColtaBillAmount.Font.Bold = True
  '    oColtaBillAmount.CssClass = "colHD"
  '    oColtaBillAmount.Style.Add("text-align", "center")
  '    oColtaBillAmount.ColumnSpan = 5
  '    oRowtaBillAmount.Cells.Add(oColtaBillAmount)
  '    oColtaBillAmount = New TableCell
  '    oColtaBillAmount.Text = gTot
  '    oColtaBillAmount.Font.Bold = True
  '    oColtaBillAmount.CssClass = "colHD"
  '    oColtaBillAmount.Style.Add("text-align", "right")
  '    oRowtaBillAmount.Cells.Add(oColtaBillAmount)
  '    oTbltaBillAmount.Rows.Add(oRowtaBillAmount)

  '    pnl1.Controls.Add(oTbltaBillAmount)
  '  End If
  '  'Brief Tour Report
  '  Dim oTblbtr As Table = Nothing
  '  Dim oRowbtr As TableRow = Nothing
  '  Dim oColbtr As TableCell = Nothing
  '  Dim oTblhbtr As Table = New Table
  '  oTblhbtr.Width = 1000
  '  oTblhbtr.Style.Add("margin-top", "15px")
  '  oTblhbtr.Style.Add("margin-left", "10px")
  '  oTblhbtr.Style.Add("margin-right", "10px")
  '  Dim oRowhbtr As TableRow = New TableRow
  '  Dim oColhbtr As TableCell = New TableCell
  '  oColhbtr.Font.Bold = True
  '  oColhbtr.Font.Underline = True
  '  oColhbtr.Font.Size = 10
  '  oColhbtr.CssClass = "grpHD"
  '  oColhbtr.Text = "Brief Tour Report"
  '  oRowhbtr.Cells.Add(oColhbtr)
  '  oTblhbtr.Rows.Add(oRowhbtr)
  '  pnl1.Controls.Add(oTblhbtr)
  '  oTblbtr = New Table
  '  oTblbtr.Width = 1000
  '  oTblbtr.GridLines = GridLines.Both
  '  oTblbtr.Style.Add("margin-left", "10px")
  '  oTblbtr.Style.Add("margin-right", "10px")
  '  oRowbtr = New TableRow
  '  oColbtr = New TableCell
  '  oColbtr.Text = oVar.BriefTourReport
  '  oColbtr.CssClass = "rowHD"
  '  oColbtr.Style.Add("text-align", "left")
  '  oRowbtr.Cells.Add(oColbtr)
  '  oTblbtr.Rows.Add(oRowbtr)
  '  pnl1.Controls.Add(oTblbtr)
  '  '=================
  '  oTbl = New Table
  '  oTbl.Width = 1000
  '  oTbl.GridLines = GridLines.None
  '  oTbl.BorderStyle = BorderStyle.None
  '  oTbl.Style.Add("margin-top", "15px")
  '  oTbl.Style.Add("margin-left", "10px")

  '  oRow = New TableRow
  '  oCol = New TableCell
  '  oCol.HorizontalAlign = HorizontalAlign.Right
  '  oCol.Text = "&nbsp;"
  '  oCol.Font.Bold = True
  '  oRow.Cells.Add(oCol)
  '  oTbl.Rows.Add(oRow)
  '  oRow = New TableRow
  '  oCol = New TableCell
  '  oCol.HorizontalAlign = HorizontalAlign.Right
  '  oCol.Text = "&nbsp;"
  '  oCol.Font.Bold = True
  '  oRow.Cells.Add(oCol)
  '  oTbl.Rows.Add(oRow)


  '  oRow = New TableRow
  '  oCol = New TableCell
  '  oCol.HorizontalAlign = HorizontalAlign.Right
  '  oCol.Text = "&nbsp;"
  '  oCol.Font.Bold = True
  '  oRow.Cells.Add(oCol)
  '  oTbl.Rows.Add(oRow)
  '  oRow = New TableRow
  '  oCol = New TableCell
  '  oCol.CssClass = "alignright"
  '  oCol.Text = "Signature"
  '  oCol.Font.Bold = True
  '  oRow.Cells.Add(oCol)
  '  oTbl.Rows.Add(oRow)

  '  oRow = New TableRow
  '  oCol = New TableCell
  '  oCol.CssClass = "alignright"
  '  oCol.Text = "(" & oVar.FK_TA_Bills_EmployeeID.EmployeeName & ")"
  '  oCol.Font.Bold = True
  '  oRow.Cells.Add(oCol)
  '  oTbl.Rows.Add(oRow)

  '  pnl1.Controls.Add(oTbl)
  '  '=================
  '  oTbl = New Table
  '  oTbl.Width = 1000
  '  oTbl.GridLines = GridLines.None
  '  oTbl.BorderStyle = BorderStyle.None
  '  oTbl.Style.Add("margin-top", "15px")
  '  oTbl.Style.Add("margin-left", "10px")
  '  oRow = New TableRow
  '  oCol = New TableCell
  '  oCol.Text = "=>THIS CARRIES ELECTRONIC APPROVAL OF TRAVEL EXPENSE BY REQUISITE AUTHORITY."
  '  oCol.Font.Bold = True
  '  oCol.Font.Italic = True
  '  oRow.Cells.Add(oCol)
  '  oTbl.Rows.Add(oRow)
  '  pnl1.Controls.Add(oTbl)


  '  Return pnl1
  'End Function

End Class
