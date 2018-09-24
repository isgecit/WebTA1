Partial Class RP_taCH
  Inherits System.Web.UI.Page
  Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    Dim aVal() As String = Request.QueryString("pk").Split("|".ToCharArray)
    Dim TABillNo As Int32 = CType(aVal(0), Int32)
    Dim oVar As SIS.TA.taCH = SIS.TA.taCH.taCHGetByID(TABillNo)
    Dim oTbltaCH As New Table
    oTbltaCH.Width = 1000
    oTbltaCH.GridLines = GridLines.Both
    oTbltaCH.Style.Add("margin-top", "15px")
    oTbltaCH.Style.Add("margin-left", "10px")
    Dim oColtaCH As TableCell = Nothing
    Dim oRowtaCH As TableRow = Nothing
    oRowtaCH = New TableRow
    oColtaCH = New TableCell
    oColtaCH.Text = "TA Bill No"
    oColtaCH.Font.Bold = True
    oRowtaCH.Cells.Add(oColtaCH)
    oColtaCH = New TableCell
    oColtaCH.Text = oVar.TABillNo
    oColtaCH.Style.Add("text-align", "right")
    oColtaCH.ColumnSpan = "5"
    oRowtaCH.Cells.Add(oColtaCH)
    oTbltaCH.Rows.Add(oRowtaCH)
    oRowtaCH = New TableRow
    oColtaCH = New TableCell
    oColtaCH.Text = "Employee ID"
    oColtaCH.Font.Bold = True
    oRowtaCH.Cells.Add(oColtaCH)
    oColtaCH = New TableCell
    oColtaCH.Text = oVar.EmployeeID
    oColtaCH.Style.Add("text-align", "left")
    oRowtaCH.Cells.Add(oColtaCH)
    oColtaCH = New TableCell
    oColtaCH.Text = oVar.HRM_Employees5_EmployeeName
    oColtaCH.Style.Add("text-align", "left")
    oRowtaCH.Cells.Add(oColtaCH)
    oColtaCH = New TableCell
    oColtaCH.Text = "TA Category ID"
    oColtaCH.Font.Bold = True
    oRowtaCH.Cells.Add(oColtaCH)
    oColtaCH = New TableCell
    oColtaCH.Text = oVar.TA_Categories13_cmba
    oColtaCH.Style.Add("text-align", "right")
    oColtaCH.ColumnSpan = "2"
    oRowtaCH.Cells.Add(oColtaCH)
    oTbltaCH.Rows.Add(oRowtaCH)
    oRowtaCH = New TableRow
    oColtaCH = New TableCell
    oColtaCH.Text = "CostCenterID"
    oColtaCH.Font.Bold = True
    oRowtaCH.Cells.Add(oColtaCH)
    oColtaCH = New TableCell
    oColtaCH.Text = oVar.CostCenterID
    oColtaCH.Style.Add("text-align", "left")
    oRowtaCH.Cells.Add(oColtaCH)
    oColtaCH = New TableCell
    oColtaCH.Text = oVar.HRM_Departments1_Description
    oColtaCH.Style.Add("text-align", "left")
    oRowtaCH.Cells.Add(oColtaCH)
    oColtaCH = New TableCell
    oColtaCH.Text = "Project ID"
    oColtaCH.Font.Bold = True
    oRowtaCH.Cells.Add(oColtaCH)
    oColtaCH = New TableCell
    oColtaCH.Text = oVar.ProjectID
    oColtaCH.Style.Add("text-align", "left")
    oRowtaCH.Cells.Add(oColtaCH)
    oColtaCH = New TableCell
    oColtaCH.Text = oVar.IDM_Projects11_Description
    oColtaCH.Style.Add("text-align", "left")
    oRowtaCH.Cells.Add(oColtaCH)
    oTbltaCH.Rows.Add(oRowtaCH)
    oRowtaCH = New TableRow
    oColtaCH = New TableCell
    oColtaCH.Text = "Purpose Of Journey"
    oColtaCH.Font.Bold = True
    oRowtaCH.Cells.Add(oColtaCH)
    oColtaCH = New TableCell
    oColtaCH.Text = oVar.PurposeOfJourney
    oColtaCH.Style.Add("text-align", "left")
    oColtaCH.ColumnSpan = "2"
    oRowtaCH.Cells.Add(oColtaCH)
    oColtaCH = New TableCell
    oColtaCH.Text = "Brief Tour Report"
    oColtaCH.Font.Bold = True
    oRowtaCH.Cells.Add(oColtaCH)
    oColtaCH = New TableCell
    oColtaCH.Text = oVar.BriefTourReport
    oColtaCH.Style.Add("text-align", "left")
    oColtaCH.ColumnSpan = "2"
    oRowtaCH.Cells.Add(oColtaCH)
    oTbltaCH.Rows.Add(oRowtaCH)
    oRowtaCH = New TableRow
    oColtaCH = New TableCell
    oColtaCH.Text = "Total Claimed Amount"
    oColtaCH.Font.Bold = True
    oRowtaCH.Cells.Add(oColtaCH)
    oColtaCH = New TableCell
    oColtaCH.Text = oVar.TotalClaimedAmount
    oColtaCH.Style.Add("text-align", "right")
    oColtaCH.ColumnSpan = "2"
    oRowtaCH.Cells.Add(oColtaCH)
    oColtaCH = New TableCell
    oColtaCH.Text = "Total Passed Amount"
    oColtaCH.Font.Bold = True
    oRowtaCH.Cells.Add(oColtaCH)
    oColtaCH = New TableCell
    oColtaCH.Text = oVar.TotalPassedAmount
    oColtaCH.Style.Add("text-align", "right")
    oColtaCH.ColumnSpan = "2"
    oRowtaCH.Cells.Add(oColtaCH)
    oTbltaCH.Rows.Add(oRowtaCH)
    oRowtaCH = New TableRow
    oColtaCH = New TableCell
    oColtaCH.Text = "Total Financed Amount"
    oColtaCH.Font.Bold = True
    oRowtaCH.Cells.Add(oColtaCH)
    oColtaCH = New TableCell
    oColtaCH.Text = oVar.TotalFinancedAmount
    oColtaCH.Style.Add("text-align", "right")
    oColtaCH.ColumnSpan = "2"
    oRowtaCH.Cells.Add(oColtaCH)
    oColtaCH = New TableCell
    oColtaCH.Text = "Total Payable Amount"
    oColtaCH.Font.Bold = True
    oRowtaCH.Cells.Add(oColtaCH)
    oColtaCH = New TableCell
    oColtaCH.Text = oVar.TotalPayableAmount
    oColtaCH.Style.Add("text-align", "right")
    oColtaCH.ColumnSpan = "2"
    oRowtaCH.Cells.Add(oColtaCH)
    oTbltaCH.Rows.Add(oRowtaCH)
    oRowtaCH = New TableRow
    oColtaCH = New TableCell
    oColtaCH.Text = "Sanctioned DA [Per Day, If any]"
    oColtaCH.Font.Bold = True
    oRowtaCH.Cells.Add(oColtaCH)
    oColtaCH = New TableCell
    oColtaCH.Text = oVar.SanctionedDA
    oColtaCH.Style.Add("text-align", "right")
    oColtaCH.ColumnSpan = "2"
    oRowtaCH.Cells.Add(oColtaCH)
    oColtaCH = New TableCell
    oColtaCH.Text = "Sanctioned Lodging [Per Day, If any]"
    oColtaCH.Font.Bold = True
    oRowtaCH.Cells.Add(oColtaCH)
    oColtaCH = New TableCell
    oColtaCH.Text = oVar.SanctionedLodging
    oColtaCH.Style.Add("text-align", "right")
    oColtaCH.ColumnSpan = "2"
    oRowtaCH.Cells.Add(oColtaCH)
    oTbltaCH.Rows.Add(oRowtaCH)
    oRowtaCH = New TableRow
    oColtaCH = New TableCell
    oColtaCH.Text = "Verified By"
    oColtaCH.Font.Bold = True
    oRowtaCH.Cells.Add(oColtaCH)
    oColtaCH = New TableCell
    oColtaCH.Text = oVar.HRM_Employees7_EmployeeName
    oColtaCH.Style.Add("text-align", "left")
    oColtaCH.ColumnSpan = "2"
    oRowtaCH.Cells.Add(oColtaCH)
    oColtaCH = New TableCell
    oColtaCH.Text = "Approved By"
    oColtaCH.Font.Bold = True
    oRowtaCH.Cells.Add(oColtaCH)
    oColtaCH = New TableCell
    oColtaCH.Text = oVar.HRM_Employees8_EmployeeName
    oColtaCH.Style.Add("text-align", "left")
    oColtaCH.ColumnSpan = "2"
    oRowtaCH.Cells.Add(oColtaCH)
    oTbltaCH.Rows.Add(oRowtaCH)
    oRowtaCH = New TableRow
    oColtaCH = New TableCell
    oColtaCH.Text = "Verified On"
    oColtaCH.Font.Bold = True
    oRowtaCH.Cells.Add(oColtaCH)
    oColtaCH = New TableCell
    oColtaCH.Text = oVar.ApprovedOn
    oColtaCH.Style.Add("text-align", "center")
    oColtaCH.ColumnSpan = "2"
    oRowtaCH.Cells.Add(oColtaCH)
    oColtaCH = New TableCell
    oColtaCH.Text = "Approved On "
    oColtaCH.Font.Bold = True
    oRowtaCH.Cells.Add(oColtaCH)
    oColtaCH = New TableCell
    oColtaCH.Text = oVar.ApprovedByCCOn
    oColtaCH.Style.Add("text-align", "center")
    oColtaCH.ColumnSpan = "2"
    oRowtaCH.Cells.Add(oColtaCH)
    oTbltaCH.Rows.Add(oRowtaCH)
    oRowtaCH = New TableRow
    oColtaCH = New TableCell
    oColtaCH.Text = "Special Approval By MD/BH"
    oColtaCH.Font.Bold = True
    oRowtaCH.Cells.Add(oColtaCH)
    oColtaCH = New TableCell
    oColtaCH.Text = oVar.ApprovedBySA
    oColtaCH.Style.Add("text-align", "left")
    oRowtaCH.Cells.Add(oColtaCH)
    oColtaCH = New TableCell
    oColtaCH.Text = oVar.HRM_Employees9_EmployeeName
    oColtaCH.Style.Add("text-align", "left")
    oRowtaCH.Cells.Add(oColtaCH)
    oColtaCH = New TableCell
    oColtaCH.Text = "Special Approval On"
    oColtaCH.Font.Bold = True
    oRowtaCH.Cells.Add(oColtaCH)
    oColtaCH = New TableCell
    oColtaCH.Text = oVar.ApprovedBySAOn
    oColtaCH.Style.Add("text-align", "center")
    oColtaCH.ColumnSpan = "2"
    oRowtaCH.Cells.Add(oColtaCH)
    oTbltaCH.Rows.Add(oRowtaCH)
    oRowtaCH = New TableRow
    oColtaCH = New TableCell
    oColtaCH.Text = "Bill Status"
    oColtaCH.Font.Bold = True
    oRowtaCH.Cells.Add(oColtaCH)
    oColtaCH = New TableCell
    oColtaCH.Text = oVar.TA_BillStates16_Description
    oColtaCH.Style.Add("text-align", "right")
    oColtaCH.ColumnSpan = "2"
    oRowtaCH.Cells.Add(oColtaCH)
    oColtaCH = New TableCell
    oColtaCH.Text = "Approval WF Type ID"
    oColtaCH.Font.Bold = True
    oRowtaCH.Cells.Add(oColtaCH)
    oColtaCH = New TableCell
    oColtaCH.Text = oVar.TA_ApprovalWFTypes12_WFTypeDescription
    oColtaCH.Style.Add("text-align", "right")
    oColtaCH.ColumnSpan = "2"
    oRowtaCH.Cells.Add(oColtaCH)
    oTbltaCH.Rows.Add(oRowtaCH)
    oRowtaCH = New TableRow
    oColtaCH = New TableCell
    oColtaCH.Text = "OOE Remarks"
    oColtaCH.Font.Bold = True
    oRowtaCH.Cells.Add(oColtaCH)
    oColtaCH = New TableCell
    oColtaCH.Text = oVar.OOERemarks
    oColtaCH.Style.Add("text-align", "left")
    oColtaCH.ColumnSpan = "5"
    oRowtaCH.Cells.Add(oColtaCH)
    oTbltaCH.Rows.Add(oRowtaCH)
    form1.Controls.Add(oTbltaCH)

    Dim oTbl As Table
    Dim oCol As TableCell = Nothing
    Dim oRow As TableRow = Nothing

    ' Table For Foreign Travel 
    If oVar.TravelTypeID <> TATravelTypeValues.Domestic Then
      oTbl = New Table
      oTbl.Width = 1000
      oTbl.GridLines = GridLines.None
      oTbl.Style.Add("margin-top", "15px")
      oTbl.Style.Add("margin-left", "10px")
      oRow = New TableRow
      oCol = New TableCell
      oCol.Text = "DEPARTUE FROM INDIA:"
      oCol.Font.Bold = True
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = oVar.DepartureFromIndia
      oCol.Font.Bold = True
      oRow.Cells.Add(oCol)
      oTbl.Rows.Add(oRow)

      oRow = New TableRow
      oCol = New TableCell
      oCol.Text = "ARRIVAL IN INDIA:"
      oCol.Font.Bold = True
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = oVar.ArrivalToIndia
      oCol.Font.Bold = True
      oRow.Cells.Add(oCol)
      oTbl.Rows.Add(oRow)

      oRow = New TableRow
      oCol = New TableCell
      oCol.Text = "TOTAL DA DAYS:"
      oCol.Font.Bold = True
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = oVar.TotalTravelDays
      oCol.Font.Bold = True
      oRow.Cells.Add(oCol)
      oTbl.Rows.Add(oRow)

      form1.Controls.Add(oTbl)

    End If
    '---------


    Dim oTbltaBDFare As Table = Nothing
    Dim oRowtaBDFare As TableRow = Nothing
    Dim oColtaBDFare As TableCell = Nothing
    Dim otaBDFares As List(Of SIS.TA.taBDFare) = SIS.TA.taBDFare.UZ_taBDFareSelectList(0, 999, "", False, "", oVar.TABillNo)
    If otaBDFares.Count > 0 Then
      Dim oTblhtaBDFare As Table = New Table
      oTblhtaBDFare.Width = 1000
      oTblhtaBDFare.Style.Add("margin-top", "15px")
      oTblhtaBDFare.Style.Add("margin-left", "10px")
      oTblhtaBDFare.Style.Add("margin-right", "10px")
      Dim oRowhtaBDFare As TableRow = New TableRow
      Dim oColhtaBDFare As TableCell = New TableCell
      oColhtaBDFare.Font.Bold = True
      oColhtaBDFare.Font.Underline = True
      oColhtaBDFare.Font.Size = 10
      oColhtaBDFare.CssClass = "grpHD"
      oColhtaBDFare.Text = "Fare"
      oRowhtaBDFare.Cells.Add(oColhtaBDFare)
      oTblhtaBDFare.Rows.Add(oRowhtaBDFare)
      form1.Controls.Add(oTblhtaBDFare)
      oTbltaBDFare = New Table
      oTbltaBDFare.Width = 1000
      oTbltaBDFare.GridLines = GridLines.Both
      oTbltaBDFare.Style.Add("margin-left", "10px")
      oTbltaBDFare.Style.Add("margin-right", "10px")
      oRowtaBDFare = New TableRow
      oColtaBDFare = New TableCell
      oColtaBDFare.Text = "Serial No"
      oColtaBDFare.Font.Bold = True
      oColtaBDFare.CssClass = "colHD"
      oColtaBDFare.Style.Add("text-align", "right")
      oRowtaBDFare.Cells.Add(oColtaBDFare)
      oColtaBDFare = New TableCell
      oColtaBDFare.Text = "Component ID"
      oColtaBDFare.Font.Bold = True
      oColtaBDFare.CssClass = "colHD"
      oColtaBDFare.Style.Add("text-align", "right")
      oRowtaBDFare.Cells.Add(oColtaBDFare)
      oColtaBDFare = New TableCell
      oColtaBDFare.Text = "Description"
      oColtaBDFare.Font.Bold = True
      oColtaBDFare.CssClass = "colHD"
      oColtaBDFare.Style.Add("text-align", "left")
      oRowtaBDFare.Cells.Add(oColtaBDFare)
      oColtaBDFare = New TableCell
      oColtaBDFare.Text = "Claimed Amount"
      oColtaBDFare.Font.Bold = True
      oColtaBDFare.CssClass = "colHD"
      oColtaBDFare.Style.Add("text-align", "right")
      oRowtaBDFare.Cells.Add(oColtaBDFare)
      oColtaBDFare = New TableCell
      oColtaBDFare.Text = "Passed Amount"
      oColtaBDFare.Font.Bold = True
      oColtaBDFare.CssClass = "colHD"
      oColtaBDFare.Style.Add("text-align", "right")
      oRowtaBDFare.Cells.Add(oColtaBDFare)
      oColtaBDFare = New TableCell
      oColtaBDFare.Text = "Remarks"
      oColtaBDFare.Font.Bold = True
      oColtaBDFare.CssClass = "colHD"
      oColtaBDFare.Style.Add("text-align", "left")
      oRowtaBDFare.Cells.Add(oColtaBDFare)
      oTbltaBDFare.Rows.Add(oRowtaBDFare)
      For Each otaBDFare As SIS.TA.taBDFare In otaBDFares
        oRowtaBDFare = New TableRow
        oColtaBDFare = New TableCell
        oColtaBDFare.CssClass = "rowHD"
        oColtaBDFare.Text = otaBDFare.SerialNo
        oColtaBDFare.Style.Add("text-align", "right")
        oRowtaBDFare.Cells.Add(oColtaBDFare)
        oColtaBDFare = New TableCell
        oColtaBDFare.Text = otaBDFare.TA_Components9_Description
        oColtaBDFare.CssClass = "rowHD"
        oColtaBDFare.Style.Add("text-align", "right")
        oRowtaBDFare.Cells.Add(oColtaBDFare)
        oColtaBDFare = New TableCell
        oColtaBDFare.CssClass = "rowHD"
        oColtaBDFare.Text = otaBDFare.SystemText
        oColtaBDFare.Style.Add("text-align", "left")
        oRowtaBDFare.Cells.Add(oColtaBDFare)
        oColtaBDFare = New TableCell
        oColtaBDFare.CssClass = "rowHD"
        oColtaBDFare.Text = otaBDFare.AmountTotal
        oColtaBDFare.Style.Add("text-align", "right")
        oRowtaBDFare.Cells.Add(oColtaBDFare)
        oColtaBDFare = New TableCell
        oColtaBDFare.CssClass = "rowHD"
        oColtaBDFare.Text = otaBDFare.PassedAmountTotal
        oColtaBDFare.Style.Add("text-align", "right")
        oRowtaBDFare.Cells.Add(oColtaBDFare)
        oColtaBDFare = New TableCell
        oColtaBDFare.CssClass = "rowHD"
        oColtaBDFare.Text = otaBDFare.Remarks
        oColtaBDFare.Style.Add("text-align", "left")
        oRowtaBDFare.Cells.Add(oColtaBDFare)
        oTbltaBDFare.Rows.Add(oRowtaBDFare)
      Next
      form1.Controls.Add(oTbltaBDFare)
    End If
    Dim oTbltaBDLC As Table = Nothing
    Dim oRowtaBDLC As TableRow = Nothing
    Dim oColtaBDLC As TableCell = Nothing
    Dim otaBDLCs As List(Of SIS.TA.taBDLC) = SIS.TA.taBDLC.UZ_taBDLCSelectList(0, 999, "", False, "", oVar.TABillNo)
    If otaBDLCs.Count > 0 Then
      Dim oTblhtaBDLC As Table = New Table
      oTblhtaBDLC.Width = 1000
      oTblhtaBDLC.Style.Add("margin-top", "15px")
      oTblhtaBDLC.Style.Add("margin-left", "10px")
      oTblhtaBDLC.Style.Add("margin-right", "10px")
      Dim oRowhtaBDLC As TableRow = New TableRow
      Dim oColhtaBDLC As TableCell = New TableCell
      oColhtaBDLC.Font.Bold = True
      oColhtaBDLC.Font.Underline = True
      oColhtaBDLC.Font.Size = 10
      oColhtaBDLC.CssClass = "grpHD"
      oColhtaBDLC.Text = "Conveyance Expenses"
      oRowhtaBDLC.Cells.Add(oColhtaBDLC)
      oTblhtaBDLC.Rows.Add(oRowhtaBDLC)
      form1.Controls.Add(oTblhtaBDLC)
      oTbltaBDLC = New Table
      oTbltaBDLC.Width = 1000
      oTbltaBDLC.GridLines = GridLines.Both
      oTbltaBDLC.Style.Add("margin-left", "10px")
      oTbltaBDLC.Style.Add("margin-right", "10px")
      oRowtaBDLC = New TableRow
      oColtaBDLC = New TableCell
      oColtaBDLC.Text = "Serial No"
      oColtaBDLC.Font.Bold = True
      oColtaBDLC.CssClass = "colHD"
      oColtaBDLC.Style.Add("text-align", "right")
      oRowtaBDLC.Cells.Add(oColtaBDLC)
      oColtaBDLC = New TableCell
      oColtaBDLC.Text = "Component ID"
      oColtaBDLC.Font.Bold = True
      oColtaBDLC.CssClass = "colHD"
      oColtaBDLC.Style.Add("text-align", "right")
      oRowtaBDLC.Cells.Add(oColtaBDLC)
      oColtaBDLC = New TableCell
      oColtaBDLC.Text = "Description"
      oColtaBDLC.Font.Bold = True
      oColtaBDLC.CssClass = "colHD"
      oColtaBDLC.Style.Add("text-align", "left")
      oRowtaBDLC.Cells.Add(oColtaBDLC)
      oColtaBDLC = New TableCell
      oColtaBDLC.Text = "Claimed Amount"
      oColtaBDLC.Font.Bold = True
      oColtaBDLC.CssClass = "colHD"
      oColtaBDLC.Style.Add("text-align", "right")
      oRowtaBDLC.Cells.Add(oColtaBDLC)
      oColtaBDLC = New TableCell
      oColtaBDLC.Text = "Passed Amount"
      oColtaBDLC.Font.Bold = True
      oColtaBDLC.CssClass = "colHD"
      oColtaBDLC.Style.Add("text-align", "right")
      oRowtaBDLC.Cells.Add(oColtaBDLC)
      oColtaBDLC = New TableCell
      oColtaBDLC.Text = "Remarks"
      oColtaBDLC.Font.Bold = True
      oColtaBDLC.CssClass = "colHD"
      oColtaBDLC.Style.Add("text-align", "left")
      oRowtaBDLC.Cells.Add(oColtaBDLC)
      oTbltaBDLC.Rows.Add(oRowtaBDLC)
      For Each otaBDLC As SIS.TA.taBDLC In otaBDLCs
        oRowtaBDLC = New TableRow
        oColtaBDLC = New TableCell
        oColtaBDLC.CssClass = "rowHD"
        oColtaBDLC.Text = otaBDLC.SerialNo
        oColtaBDLC.Style.Add("text-align", "right")
        oRowtaBDLC.Cells.Add(oColtaBDLC)
        oColtaBDLC = New TableCell
        oColtaBDLC.Text = otaBDLC.TA_Components9_Description
        oColtaBDLC.CssClass = "rowHD"
        oColtaBDLC.Style.Add("text-align", "right")
        oRowtaBDLC.Cells.Add(oColtaBDLC)
        oColtaBDLC = New TableCell
        oColtaBDLC.CssClass = "rowHD"
        oColtaBDLC.Text = otaBDLC.SystemText
        oColtaBDLC.Style.Add("text-align", "left")
        oRowtaBDLC.Cells.Add(oColtaBDLC)
        oColtaBDLC = New TableCell
        oColtaBDLC.CssClass = "rowHD"
        oColtaBDLC.Text = otaBDLC.AmountTotal
        oColtaBDLC.Style.Add("text-align", "right")
        oRowtaBDLC.Cells.Add(oColtaBDLC)
        oColtaBDLC = New TableCell
        oColtaBDLC.CssClass = "rowHD"
        oColtaBDLC.Text = otaBDLC.PassedAmountTotal
        oColtaBDLC.Style.Add("text-align", "right")
        oRowtaBDLC.Cells.Add(oColtaBDLC)
        oColtaBDLC = New TableCell
        oColtaBDLC.CssClass = "rowHD"
        oColtaBDLC.Text = otaBDLC.Remarks
        oColtaBDLC.Style.Add("text-align", "left")
        oRowtaBDLC.Cells.Add(oColtaBDLC)
        oTbltaBDLC.Rows.Add(oRowtaBDLC)
      Next
      form1.Controls.Add(oTbltaBDLC)
    End If
    Dim oTbltaBDLodging As Table = Nothing
    Dim oRowtaBDLodging As TableRow = Nothing
    Dim oColtaBDLodging As TableCell = Nothing
    Dim otaBDLodgings As List(Of SIS.TA.taBDLodging) = SIS.TA.taBDLodging.UZ_taBDLodgingSelectList(0, 999, "", False, "", oVar.TABillNo)
    If otaBDLodgings.Count > 0 Then
      Dim oTblhtaBDLodging As Table = New Table
      oTblhtaBDLodging.Width = 1000
      oTblhtaBDLodging.Style.Add("margin-top", "15px")
      oTblhtaBDLodging.Style.Add("margin-left", "10px")
      oTblhtaBDLodging.Style.Add("margin-right", "10px")
      Dim oRowhtaBDLodging As TableRow = New TableRow
      Dim oColhtaBDLodging As TableCell = New TableCell
      oColhtaBDLodging.Font.Bold = True
      oColhtaBDLodging.Font.Underline = True
      oColhtaBDLodging.Font.Size = 10
      oColhtaBDLodging.CssClass = "grpHD"
      oColhtaBDLodging.Text = "Lodging Charges"
      oRowhtaBDLodging.Cells.Add(oColhtaBDLodging)
      oTblhtaBDLodging.Rows.Add(oRowhtaBDLodging)
      form1.Controls.Add(oTblhtaBDLodging)
      oTbltaBDLodging = New Table
      oTbltaBDLodging.Width = 1000
      oTbltaBDLodging.GridLines = GridLines.Both
      oTbltaBDLodging.Style.Add("margin-left", "10px")
      oTbltaBDLodging.Style.Add("margin-right", "10px")
      oRowtaBDLodging = New TableRow
      oColtaBDLodging = New TableCell
      oColtaBDLodging.Text = "Serial No"
      oColtaBDLodging.Font.Bold = True
      oColtaBDLodging.CssClass = "colHD"
      oColtaBDLodging.Style.Add("text-align", "right")
      oRowtaBDLodging.Cells.Add(oColtaBDLodging)
      oColtaBDLodging = New TableCell
      oColtaBDLodging.Text = "Component ID"
      oColtaBDLodging.Font.Bold = True
      oColtaBDLodging.CssClass = "colHD"
      oColtaBDLodging.Style.Add("text-align", "right")
      oRowtaBDLodging.Cells.Add(oColtaBDLodging)
      oColtaBDLodging = New TableCell
      oColtaBDLodging.Text = "Description"
      oColtaBDLodging.Font.Bold = True
      oColtaBDLodging.CssClass = "colHD"
      oColtaBDLodging.Style.Add("text-align", "left")
      oRowtaBDLodging.Cells.Add(oColtaBDLodging)
      oColtaBDLodging = New TableCell
      oColtaBDLodging.Text = "Claimed Amount"
      oColtaBDLodging.Font.Bold = True
      oColtaBDLodging.CssClass = "colHD"
      oColtaBDLodging.Style.Add("text-align", "right")
      oRowtaBDLodging.Cells.Add(oColtaBDLodging)
      oColtaBDLodging = New TableCell
      oColtaBDLodging.Text = "Passed Amount"
      oColtaBDLodging.Font.Bold = True
      oColtaBDLodging.CssClass = "colHD"
      oColtaBDLodging.Style.Add("text-align", "right")
      oRowtaBDLodging.Cells.Add(oColtaBDLodging)
      oColtaBDLodging = New TableCell
      oColtaBDLodging.Text = "Remarks"
      oColtaBDLodging.Font.Bold = True
      oColtaBDLodging.CssClass = "colHD"
      oColtaBDLodging.Style.Add("text-align", "left")
      oRowtaBDLodging.Cells.Add(oColtaBDLodging)
      oTbltaBDLodging.Rows.Add(oRowtaBDLodging)
      For Each otaBDLodging As SIS.TA.taBDLodging In otaBDLodgings
        oRowtaBDLodging = New TableRow
        oColtaBDLodging = New TableCell
        oColtaBDLodging.CssClass = "rowHD"
        Try
          If Convert.ToDecimal(otaBDLodging.AssessableValue) > 0 Then
            oColtaBDLodging.Text = otaBDLodging.SerialNo & "*" ' otaBDLodging.SerialNo
          End If
        Catch ex As Exception
          oColtaBDLodging.Text = otaBDLodging.SerialNo ' otaBDLodging.SerialNo
        End Try
        oColtaBDLodging.Style.Add("text-align", "right")
        oRowtaBDLodging.Cells.Add(oColtaBDLodging)
        oColtaBDLodging = New TableCell
        oColtaBDLodging.Text = otaBDLodging.TA_Components9_Description
        oColtaBDLodging.CssClass = "rowHD"
        oColtaBDLodging.Style.Add("text-align", "right")
        oRowtaBDLodging.Cells.Add(oColtaBDLodging)
        oColtaBDLodging = New TableCell
        oColtaBDLodging.CssClass = "rowHD"
        oColtaBDLodging.Text = otaBDLodging.SystemText
        oColtaBDLodging.Style.Add("text-align", "left")
        oRowtaBDLodging.Cells.Add(oColtaBDLodging)
        oColtaBDLodging = New TableCell
        oColtaBDLodging.CssClass = "rowHD"
        oColtaBDLodging.Text = otaBDLodging.AmountTotal
        oColtaBDLodging.Style.Add("text-align", "right")
        oRowtaBDLodging.Cells.Add(oColtaBDLodging)
        oColtaBDLodging = New TableCell
        oColtaBDLodging.CssClass = "rowHD"
        oColtaBDLodging.Text = otaBDLodging.PassedAmountTotal
        oColtaBDLodging.Style.Add("text-align", "right")
        oRowtaBDLodging.Cells.Add(oColtaBDLodging)
        oColtaBDLodging = New TableCell
        oColtaBDLodging.CssClass = "rowHD"
        oColtaBDLodging.Text = otaBDLodging.Remarks
        oColtaBDLodging.Style.Add("text-align", "left")
        oRowtaBDLodging.Cells.Add(oColtaBDLodging)
        oTbltaBDLodging.Rows.Add(oRowtaBDLodging)
      Next
      form1.Controls.Add(oTbltaBDLodging)
    End If
    Dim oTbltaBDExpense As Table = Nothing
    Dim oRowtaBDExpense As TableRow = Nothing
    Dim oColtaBDExpense As TableCell = Nothing
    Dim otaBDExpenses As List(Of SIS.TA.taBDExpense) = SIS.TA.taBDExpense.UZ_taBDExpenseSelectList(0, 999, "", False, "", oVar.TABillNo)
    If otaBDExpenses.Count > 0 Then
      Dim oTblhtaBDExpense As Table = New Table
      oTblhtaBDExpense.Width = 1000
      oTblhtaBDExpense.Style.Add("margin-top", "15px")
      oTblhtaBDExpense.Style.Add("margin-left", "10px")
      oTblhtaBDExpense.Style.Add("margin-right", "10px")
      Dim oRowhtaBDExpense As TableRow = New TableRow
      Dim oColhtaBDExpense As TableCell = New TableCell
      oColhtaBDExpense.Font.Bold = True
      oColhtaBDExpense.Font.Underline = True
      oColhtaBDExpense.Font.Size = 10
      oColhtaBDExpense.CssClass = "grpHD"
      oColhtaBDExpense.Text = "Other Expenses"
      oRowhtaBDExpense.Cells.Add(oColhtaBDExpense)
      oTblhtaBDExpense.Rows.Add(oRowhtaBDExpense)
      form1.Controls.Add(oTblhtaBDExpense)
      oTbltaBDExpense = New Table
      oTbltaBDExpense.Width = 1000
      oTbltaBDExpense.GridLines = GridLines.Both
      oTbltaBDExpense.Style.Add("margin-left", "10px")
      oTbltaBDExpense.Style.Add("margin-right", "10px")
      oRowtaBDExpense = New TableRow
      oColtaBDExpense = New TableCell
      oColtaBDExpense.Text = "Serial No"
      oColtaBDExpense.Font.Bold = True
      oColtaBDExpense.CssClass = "colHD"
      oColtaBDExpense.Style.Add("text-align", "right")
      oRowtaBDExpense.Cells.Add(oColtaBDExpense)
      oColtaBDExpense = New TableCell
      oColtaBDExpense.Text = "Component ID"
      oColtaBDExpense.Font.Bold = True
      oColtaBDExpense.CssClass = "colHD"
      oColtaBDExpense.Style.Add("text-align", "right")
      oRowtaBDExpense.Cells.Add(oColtaBDExpense)
      oColtaBDExpense = New TableCell
      oColtaBDExpense.Text = "Description"
      oColtaBDExpense.Font.Bold = True
      oColtaBDExpense.CssClass = "colHD"
      oColtaBDExpense.Style.Add("text-align", "left")
      oRowtaBDExpense.Cells.Add(oColtaBDExpense)
      oColtaBDExpense = New TableCell
      oColtaBDExpense.Text = "Claimed Amount"
      oColtaBDExpense.Font.Bold = True
      oColtaBDExpense.CssClass = "colHD"
      oColtaBDExpense.Style.Add("text-align", "right")
      oRowtaBDExpense.Cells.Add(oColtaBDExpense)
      oColtaBDExpense = New TableCell
      oColtaBDExpense.Text = "Passed Amount"
      oColtaBDExpense.Font.Bold = True
      oColtaBDExpense.CssClass = "colHD"
      oColtaBDExpense.Style.Add("text-align", "right")
      oRowtaBDExpense.Cells.Add(oColtaBDExpense)
      oColtaBDExpense = New TableCell
      oColtaBDExpense.Text = "Remarks"
      oColtaBDExpense.Font.Bold = True
      oColtaBDExpense.CssClass = "colHD"
      oColtaBDExpense.Style.Add("text-align", "left")
      oRowtaBDExpense.Cells.Add(oColtaBDExpense)
      oTbltaBDExpense.Rows.Add(oRowtaBDExpense)
      For Each otaBDExpense As SIS.TA.taBDExpense In otaBDExpenses
        oRowtaBDExpense = New TableRow
        oColtaBDExpense = New TableCell
        oColtaBDExpense.CssClass = "rowHD"
        oColtaBDExpense.Text = otaBDExpense.SerialNo
        oColtaBDExpense.Style.Add("text-align", "right")
        oRowtaBDExpense.Cells.Add(oColtaBDExpense)
        oColtaBDExpense = New TableCell
        oColtaBDExpense.Text = otaBDExpense.TA_Components9_Description
        oColtaBDExpense.CssClass = "rowHD"
        oColtaBDExpense.Style.Add("text-align", "right")
        oRowtaBDExpense.Cells.Add(oColtaBDExpense)
        oColtaBDExpense = New TableCell
        oColtaBDExpense.CssClass = "rowHD"
        oColtaBDExpense.Text = otaBDExpense.SystemText
        oColtaBDExpense.Style.Add("text-align", "left")
        oRowtaBDExpense.Cells.Add(oColtaBDExpense)
        oColtaBDExpense = New TableCell
        oColtaBDExpense.CssClass = "rowHD"
        oColtaBDExpense.Text = otaBDExpense.AmountTotal
        oColtaBDExpense.Style.Add("text-align", "right")
        oRowtaBDExpense.Cells.Add(oColtaBDExpense)
        oColtaBDExpense = New TableCell
        oColtaBDExpense.CssClass = "rowHD"
        oColtaBDExpense.Text = otaBDExpense.PassedAmountTotal
        oColtaBDExpense.Style.Add("text-align", "right")
        oRowtaBDExpense.Cells.Add(oColtaBDExpense)
        oColtaBDExpense = New TableCell
        oColtaBDExpense.CssClass = "rowHD"
        oColtaBDExpense.Text = otaBDExpense.Remarks
        oColtaBDExpense.Style.Add("text-align", "left")
        oRowtaBDExpense.Cells.Add(oColtaBDExpense)
        oTbltaBDExpense.Rows.Add(oRowtaBDExpense)
      Next
      form1.Controls.Add(oTbltaBDExpense)
    End If
    Dim oTbltaBDFinance As Table = Nothing
    Dim oRowtaBDFinance As TableRow = Nothing
    Dim oColtaBDFinance As TableCell = Nothing
    Dim otaBDFinances As List(Of SIS.TA.taBDFinance) = SIS.TA.taBDFinance.UZ_taBDFinanceSelectList(0, 999, "", False, "", oVar.TABillNo)
    If otaBDFinances.Count > 0 Then
      Dim oTblhtaBDFinance As Table = New Table
      oTblhtaBDFinance.Width = 1000
      oTblhtaBDFinance.Style.Add("margin-top", "15px")
      oTblhtaBDFinance.Style.Add("margin-left", "10px")
      oTblhtaBDFinance.Style.Add("margin-right", "10px")
      Dim oRowhtaBDFinance As TableRow = New TableRow
      Dim oColhtaBDFinance As TableCell = New TableCell
      oColhtaBDFinance.Font.Bold = True
      oColhtaBDFinance.Font.Underline = True
      oColhtaBDFinance.Font.Size = 10
      oColhtaBDFinance.CssClass = "grpHD"
      oColhtaBDFinance.Text = "Source of Finance"
      oRowhtaBDFinance.Cells.Add(oColhtaBDFinance)
      oTblhtaBDFinance.Rows.Add(oRowhtaBDFinance)
      form1.Controls.Add(oTblhtaBDFinance)
      oTbltaBDFinance = New Table
      oTbltaBDFinance.Width = 1000
      oTbltaBDFinance.GridLines = GridLines.Both
      oTbltaBDFinance.Style.Add("margin-left", "10px")
      oTbltaBDFinance.Style.Add("margin-right", "10px")
      oRowtaBDFinance = New TableRow
      oColtaBDFinance = New TableCell
      oColtaBDFinance.Text = "Serial No"
      oColtaBDFinance.Font.Bold = True
      oColtaBDFinance.CssClass = "colHD"
      oColtaBDFinance.Style.Add("text-align", "right")
      oRowtaBDFinance.Cells.Add(oColtaBDFinance)
      oColtaBDFinance = New TableCell
      oColtaBDFinance.Text = "Component ID"
      oColtaBDFinance.Font.Bold = True
      oColtaBDFinance.CssClass = "colHD"
      oColtaBDFinance.Style.Add("text-align", "right")
      oRowtaBDFinance.Cells.Add(oColtaBDFinance)
      oColtaBDFinance = New TableCell
      oColtaBDFinance.Text = "Description"
      oColtaBDFinance.Font.Bold = True
      oColtaBDFinance.CssClass = "colHD"
      oColtaBDFinance.Style.Add("text-align", "left")
      oRowtaBDFinance.Cells.Add(oColtaBDFinance)
      oColtaBDFinance = New TableCell
      oColtaBDFinance.Text = "Financed Amount"
      oColtaBDFinance.Font.Bold = True
      oColtaBDFinance.CssClass = "colHD"
      oColtaBDFinance.Style.Add("text-align", "right")
      oRowtaBDFinance.Cells.Add(oColtaBDFinance)
      oColtaBDFinance = New TableCell
      oColtaBDFinance.Text = "Acknowledged Amount"
      oColtaBDFinance.Font.Bold = True
      oColtaBDFinance.CssClass = "colHD"
      oColtaBDFinance.Style.Add("text-align", "right")
      oRowtaBDFinance.Cells.Add(oColtaBDFinance)
      oColtaBDFinance = New TableCell
      oColtaBDFinance.Text = "Remarks"
      oColtaBDFinance.Font.Bold = True
      oColtaBDFinance.CssClass = "colHD"
      oColtaBDFinance.Style.Add("text-align", "left")
      oRowtaBDFinance.Cells.Add(oColtaBDFinance)
      oTbltaBDFinance.Rows.Add(oRowtaBDFinance)
      For Each otaBDFinance As SIS.TA.taBDFinance In otaBDFinances
        oRowtaBDFinance = New TableRow
        oColtaBDFinance = New TableCell
        oColtaBDFinance.CssClass = "rowHD"
        oColtaBDFinance.Text = otaBDFinance.SerialNo
        oColtaBDFinance.Style.Add("text-align", "right")
        oRowtaBDFinance.Cells.Add(oColtaBDFinance)
        oColtaBDFinance = New TableCell
        oColtaBDFinance.Text = otaBDFinance.TA_Components9_Description
        oColtaBDFinance.CssClass = "rowHD"
        oColtaBDFinance.Style.Add("text-align", "right")
        oRowtaBDFinance.Cells.Add(oColtaBDFinance)
        oColtaBDFinance = New TableCell
        oColtaBDFinance.CssClass = "rowHD"
        oColtaBDFinance.Text = otaBDFinance.SystemText
        oColtaBDFinance.Style.Add("text-align", "left")
        oRowtaBDFinance.Cells.Add(oColtaBDFinance)
        oColtaBDFinance = New TableCell
        oColtaBDFinance.CssClass = "rowHD"
        oColtaBDFinance.Text = otaBDFinance.AmountTotal
        oColtaBDFinance.Style.Add("text-align", "right")
        oRowtaBDFinance.Cells.Add(oColtaBDFinance)
        oColtaBDFinance = New TableCell
        oColtaBDFinance.CssClass = "rowHD"
        oColtaBDFinance.Text = otaBDFinance.PassedAmountTotal
        oColtaBDFinance.Style.Add("text-align", "right")
        oRowtaBDFinance.Cells.Add(oColtaBDFinance)
        oColtaBDFinance = New TableCell
        oColtaBDFinance.CssClass = "rowHD"
        oColtaBDFinance.Text = otaBDFinance.Remarks
        oColtaBDFinance.Style.Add("text-align", "left")
        oRowtaBDFinance.Cells.Add(oColtaBDFinance)
        oTbltaBDFinance.Rows.Add(oRowtaBDFinance)
      Next
      form1.Controls.Add(oTbltaBDFinance)
    End If
    Dim oTbltaBDMileage As Table = Nothing
    Dim oRowtaBDMileage As TableRow = Nothing
    Dim oColtaBDMileage As TableCell = Nothing
    Dim otaBDMileages As List(Of SIS.TA.taBDMileage) = SIS.TA.taBDMileage.UZ_taBDMileageSelectList(0, 999, "", False, "", oVar.TABillNo)
    If otaBDMileages.Count > 0 Then
      Dim oTblhtaBDMileage As Table = New Table
      oTblhtaBDMileage.Width = 1000
      oTblhtaBDMileage.Style.Add("margin-top", "15px")
      oTblhtaBDMileage.Style.Add("margin-left", "10px")
      oTblhtaBDMileage.Style.Add("margin-right", "10px")
      Dim oRowhtaBDMileage As TableRow = New TableRow
      Dim oColhtaBDMileage As TableCell = New TableCell
      oColhtaBDMileage.Font.Bold = True
      oColhtaBDMileage.Font.Underline = True
      oColhtaBDMileage.Font.Size = 10
      oColhtaBDMileage.CssClass = "grpHD"
      oColhtaBDMileage.Text = "Mileage Claim"
      oRowhtaBDMileage.Cells.Add(oColhtaBDMileage)
      oTblhtaBDMileage.Rows.Add(oRowhtaBDMileage)
      form1.Controls.Add(oTblhtaBDMileage)
      oTbltaBDMileage = New Table
      oTbltaBDMileage.Width = 1000
      oTbltaBDMileage.GridLines = GridLines.Both
      oTbltaBDMileage.Style.Add("margin-left", "10px")
      oTbltaBDMileage.Style.Add("margin-right", "10px")
      oRowtaBDMileage = New TableRow
      oColtaBDMileage = New TableCell
      oColtaBDMileage.Text = "Serial No"
      oColtaBDMileage.Font.Bold = True
      oColtaBDMileage.CssClass = "colHD"
      oColtaBDMileage.Style.Add("text-align", "right")
      oRowtaBDMileage.Cells.Add(oColtaBDMileage)
      oColtaBDMileage = New TableCell
      oColtaBDMileage.Text = "Component ID"
      oColtaBDMileage.Font.Bold = True
      oColtaBDMileage.CssClass = "colHD"
      oColtaBDMileage.Style.Add("text-align", "right")
      oRowtaBDMileage.Cells.Add(oColtaBDMileage)
      oColtaBDMileage = New TableCell
      oColtaBDMileage.Text = "Description"
      oColtaBDMileage.Font.Bold = True
      oColtaBDMileage.CssClass = "colHD"
      oColtaBDMileage.Style.Add("text-align", "left")
      oRowtaBDMileage.Cells.Add(oColtaBDMileage)
      oColtaBDMileage = New TableCell
      oColtaBDMileage.Text = "Claimed Amount"
      oColtaBDMileage.Font.Bold = True
      oColtaBDMileage.CssClass = "colHD"
      oColtaBDMileage.Style.Add("text-align", "right")
      oRowtaBDMileage.Cells.Add(oColtaBDMileage)
      oColtaBDMileage = New TableCell
      oColtaBDMileage.Text = "Passed Amount"
      oColtaBDMileage.Font.Bold = True
      oColtaBDMileage.CssClass = "colHD"
      oColtaBDMileage.Style.Add("text-align", "right")
      oRowtaBDMileage.Cells.Add(oColtaBDMileage)
      oColtaBDMileage = New TableCell
      oColtaBDMileage.Text = "Remarks"
      oColtaBDMileage.Font.Bold = True
      oColtaBDMileage.CssClass = "colHD"
      oColtaBDMileage.Style.Add("text-align", "left")
      oRowtaBDMileage.Cells.Add(oColtaBDMileage)
      oTbltaBDMileage.Rows.Add(oRowtaBDMileage)
      For Each otaBDMileage As SIS.TA.taBDMileage In otaBDMileages
        oRowtaBDMileage = New TableRow
        oColtaBDMileage = New TableCell
        oColtaBDMileage.CssClass = "rowHD"
        oColtaBDMileage.Text = otaBDMileage.SerialNo
        oColtaBDMileage.Style.Add("text-align", "right")
        oRowtaBDMileage.Cells.Add(oColtaBDMileage)
        oColtaBDMileage = New TableCell
        oColtaBDMileage.Text = otaBDMileage.TA_Components9_Description
        oColtaBDMileage.CssClass = "rowHD"
        oColtaBDMileage.Style.Add("text-align", "right")
        oRowtaBDMileage.Cells.Add(oColtaBDMileage)
        oColtaBDMileage = New TableCell
        oColtaBDMileage.CssClass = "rowHD"
        oColtaBDMileage.Text = otaBDMileage.SystemText
        oColtaBDMileage.Style.Add("text-align", "left")
        oRowtaBDMileage.Cells.Add(oColtaBDMileage)
        oColtaBDMileage = New TableCell
        oColtaBDMileage.CssClass = "rowHD"
        oColtaBDMileage.Text = otaBDMileage.AmountTotal
        oColtaBDMileage.Style.Add("text-align", "right")
        oRowtaBDMileage.Cells.Add(oColtaBDMileage)
        oColtaBDMileage = New TableCell
        oColtaBDMileage.CssClass = "rowHD"
        oColtaBDMileage.Text = otaBDMileage.PassedAmountTotal
        oColtaBDMileage.Style.Add("text-align", "right")
        oRowtaBDMileage.Cells.Add(oColtaBDMileage)
        oColtaBDMileage = New TableCell
        oColtaBDMileage.CssClass = "rowHD"
        oColtaBDMileage.Text = otaBDMileage.Remarks
        oColtaBDMileage.Style.Add("text-align", "left")
        oRowtaBDMileage.Cells.Add(oColtaBDMileage)
        oTbltaBDMileage.Rows.Add(oRowtaBDMileage)
      Next
      form1.Controls.Add(oTbltaBDMileage)
    End If
    Dim oTbltaBDDriver As Table = Nothing
    Dim oRowtaBDDriver As TableRow = Nothing
    Dim oColtaBDDriver As TableCell = Nothing
    Dim otaBDDrivers As List(Of SIS.TA.taBDDriver) = SIS.TA.taBDDriver.UZ_taBDDriverSelectList(0, 999, "", False, "", oVar.TABillNo)
    If otaBDDrivers.Count > 0 Then
      Dim oTblhtaBDDriver As Table = New Table
      oTblhtaBDDriver.Width = 1000
      oTblhtaBDDriver.Style.Add("margin-top", "15px")
      oTblhtaBDDriver.Style.Add("margin-left", "10px")
      oTblhtaBDDriver.Style.Add("margin-right", "10px")
      Dim oRowhtaBDDriver As TableRow = New TableRow
      Dim oColhtaBDDriver As TableCell = New TableCell
      oColhtaBDDriver.Font.Bold = True
      oColhtaBDDriver.Font.Underline = True
      oColhtaBDDriver.Font.Size = 10
      oColhtaBDDriver.CssClass = "grpHD"
      oColhtaBDDriver.Text = "Driver Charges"
      oRowhtaBDDriver.Cells.Add(oColhtaBDDriver)
      oTblhtaBDDriver.Rows.Add(oRowhtaBDDriver)
      form1.Controls.Add(oTblhtaBDDriver)
      oTbltaBDDriver = New Table
      oTbltaBDDriver.Width = 1000
      oTbltaBDDriver.GridLines = GridLines.Both
      oTbltaBDDriver.Style.Add("margin-left", "10px")
      oTbltaBDDriver.Style.Add("margin-right", "10px")
      oRowtaBDDriver = New TableRow
      oColtaBDDriver = New TableCell
      oColtaBDDriver.Text = "Serial No"
      oColtaBDDriver.Font.Bold = True
      oColtaBDDriver.CssClass = "colHD"
      oColtaBDDriver.Style.Add("text-align", "right")
      oRowtaBDDriver.Cells.Add(oColtaBDDriver)
      oColtaBDDriver = New TableCell
      oColtaBDDriver.Text = "Component ID"
      oColtaBDDriver.Font.Bold = True
      oColtaBDDriver.CssClass = "colHD"
      oColtaBDDriver.Style.Add("text-align", "right")
      oRowtaBDDriver.Cells.Add(oColtaBDDriver)
      oColtaBDDriver = New TableCell
      oColtaBDDriver.Text = "Description"
      oColtaBDDriver.Font.Bold = True
      oColtaBDDriver.CssClass = "colHD"
      oColtaBDDriver.Style.Add("text-align", "left")
      oRowtaBDDriver.Cells.Add(oColtaBDDriver)
      oColtaBDDriver = New TableCell
      oColtaBDDriver.Text = "Claimed Amount"
      oColtaBDDriver.Font.Bold = True
      oColtaBDDriver.CssClass = "colHD"
      oColtaBDDriver.Style.Add("text-align", "right")
      oRowtaBDDriver.Cells.Add(oColtaBDDriver)
      oColtaBDDriver = New TableCell
      oColtaBDDriver.Text = "Passed Amount"
      oColtaBDDriver.Font.Bold = True
      oColtaBDDriver.CssClass = "colHD"
      oColtaBDDriver.Style.Add("text-align", "right")
      oRowtaBDDriver.Cells.Add(oColtaBDDriver)
      oColtaBDDriver = New TableCell
      oColtaBDDriver.Text = "Remarks"
      oColtaBDDriver.Font.Bold = True
      oColtaBDDriver.CssClass = "colHD"
      oColtaBDDriver.Style.Add("text-align", "left")
      oRowtaBDDriver.Cells.Add(oColtaBDDriver)
      oTbltaBDDriver.Rows.Add(oRowtaBDDriver)
      For Each otaBDDriver As SIS.TA.taBDDriver In otaBDDrivers
        oRowtaBDDriver = New TableRow
        oColtaBDDriver = New TableCell
        oColtaBDDriver.CssClass = "rowHD"
        oColtaBDDriver.Text = otaBDDriver.SerialNo
        oColtaBDDriver.Style.Add("text-align", "right")
        oRowtaBDDriver.Cells.Add(oColtaBDDriver)
        oColtaBDDriver = New TableCell
        oColtaBDDriver.Text = otaBDDriver.TA_Components9_Description
        oColtaBDDriver.CssClass = "rowHD"
        oColtaBDDriver.Style.Add("text-align", "right")
        oRowtaBDDriver.Cells.Add(oColtaBDDriver)
        oColtaBDDriver = New TableCell
        oColtaBDDriver.CssClass = "rowHD"
        oColtaBDDriver.Text = otaBDDriver.SystemText
        oColtaBDDriver.Style.Add("text-align", "left")
        oRowtaBDDriver.Cells.Add(oColtaBDDriver)
        oColtaBDDriver = New TableCell
        oColtaBDDriver.CssClass = "rowHD"
        oColtaBDDriver.Text = otaBDDriver.AmountTotal
        oColtaBDDriver.Style.Add("text-align", "right")
        oRowtaBDDriver.Cells.Add(oColtaBDDriver)
        oColtaBDDriver = New TableCell
        oColtaBDDriver.CssClass = "rowHD"
        oColtaBDDriver.Text = otaBDDriver.PassedAmountTotal
        oColtaBDDriver.Style.Add("text-align", "right")
        oRowtaBDDriver.Cells.Add(oColtaBDDriver)
        oColtaBDDriver = New TableCell
        oColtaBDDriver.CssClass = "rowHD"
        oColtaBDDriver.Text = otaBDDriver.Remarks
        oColtaBDDriver.Style.Add("text-align", "left")
        oRowtaBDDriver.Cells.Add(oColtaBDDriver)
        oTbltaBDDriver.Rows.Add(oRowtaBDDriver)
      Next
      form1.Controls.Add(oTbltaBDDriver)
    End If
    Dim oTbltaBDDA As Table = Nothing
    Dim oRowtaBDDA As TableRow = Nothing
    Dim oColtaBDDA As TableCell = Nothing
    Dim otaBDDAs As List(Of SIS.TA.taBDDA) = SIS.TA.taBDDA.UZ_taBDDASelectList(0, 999, "", False, "", oVar.TABillNo)
    If otaBDDAs.Count > 0 Then
      Dim oTblhtaBDDA As Table = New Table
      oTblhtaBDDA.Width = 1000
      oTblhtaBDDA.Style.Add("margin-top", "15px")
      oTblhtaBDDA.Style.Add("margin-left", "10px")
      oTblhtaBDDA.Style.Add("margin-right", "10px")
      Dim oRowhtaBDDA As TableRow = New TableRow
      Dim oColhtaBDDA As TableCell = New TableCell
      oColhtaBDDA.Font.Bold = True
      oColhtaBDDA.Font.Underline = True
      oColhtaBDDA.Font.Size = 10
      oColhtaBDDA.CssClass = "grpHD"
      oColhtaBDDA.Text = "Daily Allowance"
      oRowhtaBDDA.Cells.Add(oColhtaBDDA)
      oTblhtaBDDA.Rows.Add(oRowhtaBDDA)
      form1.Controls.Add(oTblhtaBDDA)
      oTbltaBDDA = New Table
      oTbltaBDDA.Width = 1000
      oTbltaBDDA.GridLines = GridLines.Both
      oTbltaBDDA.Style.Add("margin-left", "10px")
      oTbltaBDDA.Style.Add("margin-right", "10px")
      oRowtaBDDA = New TableRow
      oColtaBDDA = New TableCell
      oColtaBDDA.Text = "Serial No"
      oColtaBDDA.Font.Bold = True
      oColtaBDDA.CssClass = "colHD"
      oColtaBDDA.Style.Add("text-align", "right")
      oRowtaBDDA.Cells.Add(oColtaBDDA)
      oColtaBDDA = New TableCell
      oColtaBDDA.Text = "Component ID"
      oColtaBDDA.Font.Bold = True
      oColtaBDDA.CssClass = "colHD"
      oColtaBDDA.Style.Add("text-align", "right")
      oRowtaBDDA.Cells.Add(oColtaBDDA)
      oColtaBDDA = New TableCell
      oColtaBDDA.Text = "Description"
      oColtaBDDA.Font.Bold = True
      oColtaBDDA.CssClass = "colHD"
      oColtaBDDA.Style.Add("text-align", "left")
      oRowtaBDDA.Cells.Add(oColtaBDDA)
      oColtaBDDA = New TableCell
      oColtaBDDA.Text = "Claimed Amount"
      oColtaBDDA.Font.Bold = True
      oColtaBDDA.CssClass = "colHD"
      oColtaBDDA.Style.Add("text-align", "right")
      oRowtaBDDA.Cells.Add(oColtaBDDA)
      oColtaBDDA = New TableCell
      oColtaBDDA.Text = "Passed Amount"
      oColtaBDDA.Font.Bold = True
      oColtaBDDA.CssClass = "colHD"
      oColtaBDDA.Style.Add("text-align", "right")
      oRowtaBDDA.Cells.Add(oColtaBDDA)
      oColtaBDDA = New TableCell
      oColtaBDDA.Text = "Remarks"
      oColtaBDDA.Font.Bold = True
      oColtaBDDA.CssClass = "colHD"
      oColtaBDDA.Style.Add("text-align", "left")
      oRowtaBDDA.Cells.Add(oColtaBDDA)
      oTbltaBDDA.Rows.Add(oRowtaBDDA)
      For Each otaBDDA As SIS.TA.taBDDA In otaBDDAs
        oRowtaBDDA = New TableRow
        oColtaBDDA = New TableCell
        oColtaBDDA.CssClass = "rowHD"
        oColtaBDDA.Text = otaBDDA.SerialNo
        oColtaBDDA.Style.Add("text-align", "right")
        oRowtaBDDA.Cells.Add(oColtaBDDA)
        oColtaBDDA = New TableCell
        oColtaBDDA.Text = otaBDDA.TA_Components9_Description
        oColtaBDDA.CssClass = "rowHD"
        oColtaBDDA.Style.Add("text-align", "right")
        oRowtaBDDA.Cells.Add(oColtaBDDA)
        oColtaBDDA = New TableCell
        oColtaBDDA.CssClass = "rowHD"
        oColtaBDDA.Text = otaBDDA.SystemText
        oColtaBDDA.Style.Add("text-align", "left")
        oRowtaBDDA.Cells.Add(oColtaBDDA)
        oColtaBDDA = New TableCell
        oColtaBDDA.CssClass = "rowHD"
        oColtaBDDA.Text = otaBDDA.AmountTotal
        oColtaBDDA.Style.Add("text-align", "right")
        oRowtaBDDA.Cells.Add(oColtaBDDA)
        oColtaBDDA = New TableCell
        oColtaBDDA.CssClass = "rowHD"
        oColtaBDDA.Text = otaBDDA.PassedAmountTotal
        oColtaBDDA.Style.Add("text-align", "right")
        oRowtaBDDA.Cells.Add(oColtaBDDA)
        oColtaBDDA = New TableCell
        oColtaBDDA.CssClass = "rowHD"
        oColtaBDDA.Text = otaBDDA.Remarks
        oColtaBDDA.Style.Add("text-align", "left")
        oRowtaBDDA.Cells.Add(oColtaBDDA)
        oTbltaBDDA.Rows.Add(oRowtaBDDA)
      Next
      form1.Controls.Add(oTbltaBDDA)
    End If

    'Accounts
    Dim oTbltaCDAccounts As Table = Nothing
    Dim oRowtaCDAccounts As TableRow = Nothing
    Dim oColtaCDAccounts As TableCell = Nothing
    Dim otaCDAccountss As List(Of SIS.TA.taCDAccounts) = SIS.TA.taCDAccounts.UZ_taCDAccountsSelectList(0, 999, "", False, "", oVar.TABillNo)
    If otaCDAccountss.Count > 0 Then
      Dim oTblhtaCDAccounts As Table = New Table
      oTblhtaCDAccounts.Width = 1000
      oTblhtaCDAccounts.Style.Add("margin-top", "15px")
      oTblhtaCDAccounts.Style.Add("margin-left", "10px")
      oTblhtaCDAccounts.Style.Add("margin-right", "10px")
      Dim oRowhtaCDAccounts As TableRow = New TableRow
      Dim oColhtaCDAccounts As TableCell = New TableCell
      oColhtaCDAccounts.Font.Bold = True
      oColhtaCDAccounts.Font.Underline = True
      oColhtaCDAccounts.Font.Size = 10
      oColhtaCDAccounts.CssClass = "grpHD"
      oColhtaCDAccounts.Text = "Debit / Credit by Accounts"
      oRowhtaCDAccounts.Cells.Add(oColhtaCDAccounts)
      oTblhtaCDAccounts.Rows.Add(oRowhtaCDAccounts)
      form1.Controls.Add(oTblhtaCDAccounts)
      oTbltaCDAccounts = New Table
      oTbltaCDAccounts.Width = 1000
      oTbltaCDAccounts.GridLines = GridLines.Both
      oTbltaCDAccounts.Style.Add("margin-left", "10px")
      oTbltaCDAccounts.Style.Add("margin-right", "10px")
      oRowtaCDAccounts = New TableRow
      oColtaCDAccounts = New TableCell
      oColtaCDAccounts.Text = "S.N."
      oColtaCDAccounts.Width = 40
      oColtaCDAccounts.Font.Bold = True
      oColtaCDAccounts.CssClass = "colHD"
      oColtaCDAccounts.Style.Add("text-align", "center")
      oRowtaCDAccounts.Cells.Add(oColtaCDAccounts)
      oColtaCDAccounts = New TableCell
      oColtaCDAccounts.Text = "Description"
      oColtaCDAccounts.Font.Bold = True
      oColtaCDAccounts.CssClass = "colHD"
      oColtaCDAccounts.Width = 400
      oColtaCDAccounts.Style.Add("text-align", "left")
      oRowtaCDAccounts.Cells.Add(oColtaCDAccounts)
      If oVar.TravelTypeID <> TATravelTypeValues.Domestic Then
        oColtaCDAccounts = New TableCell
        oColtaCDAccounts.Text = "Currency"
        oColtaCDAccounts.Font.Bold = True
        oColtaCDAccounts.CssClass = "colHD"
        oColtaCDAccounts.Width = 60
        oColtaCDAccounts.Style.Add("text-align", "center")
        oRowtaCDAccounts.Cells.Add(oColtaCDAccounts)
      End If
      oColtaCDAccounts = New TableCell
      oColtaCDAccounts.Text = "Debit Amount"
      oColtaCDAccounts.Font.Bold = True
      oColtaCDAccounts.CssClass = "colHD"
      oColtaCDAccounts.Width = 100
      oColtaCDAccounts.Style.Add("text-align", "right")
      oRowtaCDAccounts.Cells.Add(oColtaCDAccounts)
      oColtaCDAccounts = New TableCell
      oColtaCDAccounts.Text = "Credit Amount"
      oColtaCDAccounts.Font.Bold = True
      oColtaCDAccounts.CssClass = "colHD"
      oColtaCDAccounts.Width = 100
      oColtaCDAccounts.Style.Add("text-align", "right")
      oRowtaCDAccounts.Cells.Add(oColtaCDAccounts)
      oColtaCDAccounts = New TableCell
      oColtaCDAccounts.Text = "Remarks"
      oColtaCDAccounts.Font.Bold = True
      oColtaCDAccounts.CssClass = "colHD"
      oColtaCDAccounts.Style.Add("text-align", "left")
      oRowtaCDAccounts.Cells.Add(oColtaCDAccounts)
      oTbltaCDAccounts.Rows.Add(oRowtaCDAccounts)
      For Each otaCDAccounts As SIS.TA.taCDAccounts In otaCDAccountss
        oRowtaCDAccounts = New TableRow
        oColtaCDAccounts = New TableCell
        oColtaCDAccounts.CssClass = "rowHD"
        oColtaCDAccounts.Text = otaCDAccounts.SerialNo
        oColtaCDAccounts.Style.Add("text-align", "center")
        oRowtaCDAccounts.Cells.Add(oColtaCDAccounts)
        oColtaCDAccounts = New TableCell
        oColtaCDAccounts.CssClass = "rowHD"
        oColtaCDAccounts.Text = otaCDAccounts.Remarks
        oColtaCDAccounts.Style.Add("text-align", "left")
        oRowtaCDAccounts.Cells.Add(oColtaCDAccounts)
        If oVar.TravelTypeID <> TATravelTypeValues.Domestic Then
          Dim cur As String = ""
          With otaCDAccounts
            Select Case .CurrencyID
              Case "INR", "USD", "EURO"
                cur = .CurrencyID
              Case Else
                cur = .CurrencyMain
            End Select
          End With
          oColtaCDAccounts = New TableCell
          oColtaCDAccounts.CssClass = "rowHD"
          oColtaCDAccounts.Text = cur
          oColtaCDAccounts.Style.Add("text-align", "center")
          oRowtaCDAccounts.Cells.Add(oColtaCDAccounts)
        End If
        oColtaCDAccounts = New TableCell
        oColtaCDAccounts.CssClass = "rowHD"
        oColtaCDAccounts.Text = IIf(otaCDAccounts.AmountTotal < 0, otaCDAccounts.AmountTotal, "")
        oColtaCDAccounts.Style.Add("text-align", "right")
        oRowtaCDAccounts.Cells.Add(oColtaCDAccounts)
        oColtaCDAccounts = New TableCell
        oColtaCDAccounts.CssClass = "rowHD"
        oColtaCDAccounts.Text = IIf(otaCDAccounts.AmountTotal > 0, otaCDAccounts.AmountTotal, "")
        oColtaCDAccounts.Style.Add("text-align", "right")
        oRowtaCDAccounts.Cells.Add(oColtaCDAccounts)
        oColtaCDAccounts = New TableCell
        oColtaCDAccounts.CssClass = "rowHD"
        Dim remTbl As New Table
        Dim remrow As New TableRow
        Dim remaRow As New TableRow
        Dim remcol As New TableCell
        remTbl.BorderStyle = BorderStyle.None
        remcol.Text = ""
        remrow.Cells.Add(remcol)
        remTbl.Rows.Add(remrow)
        remrow = New TableRow
        remcol = New TableCell
        remcol.Text = ""
        remcol.ForeColor = Drawing.Color.Red
        remrow.Cells.Add(remcol)
        remTbl.Rows.Add(remrow)
        oColtaCDAccounts.Controls.Add(remTbl)
        oColtaCDAccounts.Style.Add("text-align", "left")
        oRowtaCDAccounts.Cells.Add(oColtaCDAccounts)
        oTbltaCDAccounts.Rows.Add(oRowtaCDAccounts)
      Next
      form1.Controls.Add(oTbltaCDAccounts)
    End If



    Dim oTbltaBillPrjAmounts As Table = Nothing
    Dim oRowtaBillPrjAmounts As TableRow = Nothing
    Dim oColtaBillPrjAmounts As TableCell = Nothing
    Dim otaBillPrjAmountss As List(Of SIS.TA.taBillPrjAmounts) = SIS.TA.taBillPrjAmounts.UZ_taBillPrjAmountsSelectList(0, 999, "", False, "", oVar.TABillNo)
    If otaBillPrjAmountss.Count > 0 Then
      Dim oTblhtaBillPrjAmounts As Table = New Table
      oTblhtaBillPrjAmounts.Width = 1000
      oTblhtaBillPrjAmounts.Style.Add("margin-top", "15px")
      oTblhtaBillPrjAmounts.Style.Add("margin-left", "10px")
      oTblhtaBillPrjAmounts.Style.Add("margin-right", "10px")
      Dim oRowhtaBillPrjAmounts As TableRow = New TableRow
      Dim oColhtaBillPrjAmounts As TableCell = New TableCell
      oColhtaBillPrjAmounts.Font.Bold = True
      oColhtaBillPrjAmounts.Font.Underline = True
      oColhtaBillPrjAmounts.Font.Size = 10
      oColhtaBillPrjAmounts.CssClass = "grpHD"
      oColhtaBillPrjAmounts.Text = "Bill Project wise total"
      oRowhtaBillPrjAmounts.Cells.Add(oColhtaBillPrjAmounts)
      oTblhtaBillPrjAmounts.Rows.Add(oRowhtaBillPrjAmounts)
      form1.Controls.Add(oTblhtaBillPrjAmounts)
      oTbltaBillPrjAmounts = New Table
      oTbltaBillPrjAmounts.Width = 1000
      oTbltaBillPrjAmounts.GridLines = GridLines.Both
      oTbltaBillPrjAmounts.Style.Add("margin-left", "10px")
      oTbltaBillPrjAmounts.Style.Add("margin-right", "10px")
      oRowtaBillPrjAmounts = New TableRow
      oColtaBillPrjAmounts = New TableCell
      oColtaBillPrjAmounts.Text = "Project ID"
      oColtaBillPrjAmounts.Font.Bold = True
      oColtaBillPrjAmounts.CssClass = "colHD"
      oColtaBillPrjAmounts.Style.Add("text-align", "left")
      oRowtaBillPrjAmounts.Cells.Add(oColtaBillPrjAmounts)
      oColtaBillPrjAmounts = New TableCell
      oColtaBillPrjAmounts.Text = "Percentage"
      oColtaBillPrjAmounts.Font.Bold = True
      oColtaBillPrjAmounts.CssClass = "colHD"
      oColtaBillPrjAmounts.Style.Add("text-align", "right")
      oRowtaBillPrjAmounts.Cells.Add(oColtaBillPrjAmounts)
      oColtaBillPrjAmounts = New TableCell
      oColtaBillPrjAmounts.Text = "Total Amount [INR]"
      oColtaBillPrjAmounts.Font.Bold = True
      oColtaBillPrjAmounts.CssClass = "colHD"
      oColtaBillPrjAmounts.Style.Add("text-align", "right")
      oRowtaBillPrjAmounts.Cells.Add(oColtaBillPrjAmounts)
      oTbltaBillPrjAmounts.Rows.Add(oRowtaBillPrjAmounts)
      For Each otaBillPrjAmounts As SIS.TA.taBillPrjAmounts In otaBillPrjAmountss
        oRowtaBillPrjAmounts = New TableRow
        oColtaBillPrjAmounts = New TableCell
        oColtaBillPrjAmounts.Text = otaBillPrjAmounts.IDM_Projects1_Description
        oColtaBillPrjAmounts.CssClass = "rowHD"
        oColtaBillPrjAmounts.Style.Add("text-align", "left")
        oRowtaBillPrjAmounts.Cells.Add(oColtaBillPrjAmounts)
        oColtaBillPrjAmounts = New TableCell
        oColtaBillPrjAmounts.CssClass = "rowHD"
        oColtaBillPrjAmounts.Text = otaBillPrjAmounts.Percentage
        oColtaBillPrjAmounts.Style.Add("text-align", "right")
        oRowtaBillPrjAmounts.Cells.Add(oColtaBillPrjAmounts)
        oColtaBillPrjAmounts = New TableCell
        oColtaBillPrjAmounts.CssClass = "rowHD"
        oColtaBillPrjAmounts.Text = otaBillPrjAmounts.TotalAmountinINR
        oColtaBillPrjAmounts.Style.Add("text-align", "right")
        oRowtaBillPrjAmounts.Cells.Add(oColtaBillPrjAmounts)
        oTbltaBillPrjAmounts.Rows.Add(oRowtaBillPrjAmounts)
      Next
      form1.Controls.Add(oTbltaBillPrjAmounts)
    End If
    Dim oTbltaBillAmount As Table = Nothing
    Dim oRowtaBillAmount As TableRow = Nothing
    Dim oColtaBillAmount As TableCell = Nothing
    Dim otaBillAmounts As List(Of SIS.TA.taBillAmount) = SIS.TA.taBillAmount.UZ_taBillAmountSelectList(0, 999, "", False, "", oVar.TABillNo)
    If otaBillAmounts.Count > 0 Then
      Dim oTblhtaBillAmount As Table = New Table
      oTblhtaBillAmount.Width = 1000
      oTblhtaBillAmount.Style.Add("margin-top", "15px")
      oTblhtaBillAmount.Style.Add("margin-left", "10px")
      oTblhtaBillAmount.Style.Add("margin-right", "10px")
      Dim oRowhtaBillAmount As TableRow = New TableRow
      Dim oColhtaBillAmount As TableCell = New TableCell
      oColhtaBillAmount.Font.Bold = True
      oColhtaBillAmount.Font.Underline = True
      oColhtaBillAmount.Font.Size = 10
      oColhtaBillAmount.CssClass = "grpHD"
      oColhtaBillAmount.Text = "Bill Amounts"
      oRowhtaBillAmount.Cells.Add(oColhtaBillAmount)
      oTblhtaBillAmount.Rows.Add(oRowhtaBillAmount)
      form1.Controls.Add(oTblhtaBillAmount)
      oTbltaBillAmount = New Table
      oTbltaBillAmount.Width = 1000
      oTbltaBillAmount.GridLines = GridLines.Both
      oTbltaBillAmount.Style.Add("margin-left", "10px")
      oTbltaBillAmount.Style.Add("margin-right", "10px")
      oRowtaBillAmount = New TableRow
      oColtaBillAmount = New TableCell
      oColtaBillAmount.Text = "COMPONENT"
      oColtaBillAmount.Font.Bold = True
      oColtaBillAmount.CssClass = "colHD"
      oColtaBillAmount.Style.Add("text-align", "right")
      oRowtaBillAmount.Cells.Add(oColtaBillAmount)
      oColtaBillAmount = New TableCell
      oColtaBillAmount.Text = "CURRENCY"
      oColtaBillAmount.Font.Bold = True
      oColtaBillAmount.CssClass = "colHD"
      oColtaBillAmount.Style.Add("text-align", "left")
      oRowtaBillAmount.Cells.Add(oColtaBillAmount)
      oColtaBillAmount = New TableCell
      oColtaBillAmount.Text = "COST CENTER"
      oColtaBillAmount.Font.Bold = True
      oColtaBillAmount.CssClass = "colHD"
      oColtaBillAmount.Style.Add("text-align", "left")
      oRowtaBillAmount.Cells.Add(oColtaBillAmount)
      oColtaBillAmount = New TableCell
      oColtaBillAmount.Text = "TOTAL"
      oColtaBillAmount.Font.Bold = True
      oColtaBillAmount.CssClass = "colHD"
      oColtaBillAmount.Style.Add("text-align", "right")
      oRowtaBillAmount.Cells.Add(oColtaBillAmount)
      oColtaBillAmount = New TableCell
      oColtaBillAmount.Text = "Conversion Factor INR"
      oColtaBillAmount.Font.Bold = True
      oColtaBillAmount.CssClass = "colHD"
      oColtaBillAmount.Style.Add("text-align", "right")
      oRowtaBillAmount.Cells.Add(oColtaBillAmount)
      oColtaBillAmount = New TableCell
      oColtaBillAmount.Text = "TOTAL [INR]"
      oColtaBillAmount.Font.Bold = True
      oColtaBillAmount.CssClass = "colHD"
      oColtaBillAmount.Style.Add("text-align", "right")
      oRowtaBillAmount.Cells.Add(oColtaBillAmount)
      oTbltaBillAmount.Rows.Add(oRowtaBillAmount)
      For Each otaBillAmount As SIS.TA.taBillAmount In otaBillAmounts
        oRowtaBillAmount = New TableRow
        oColtaBillAmount = New TableCell
        oColtaBillAmount.Text = otaBillAmount.TA_Components4_Description
        oColtaBillAmount.CssClass = "rowHD"
        oColtaBillAmount.Style.Add("text-align", "right")
        oRowtaBillAmount.Cells.Add(oColtaBillAmount)
        oColtaBillAmount = New TableCell
        oColtaBillAmount.Text = otaBillAmount.TA_Currencies5_CurrencyName
        oColtaBillAmount.CssClass = "rowHD"
        oColtaBillAmount.Style.Add("text-align", "left")
        oRowtaBillAmount.Cells.Add(oColtaBillAmount)
        oColtaBillAmount = New TableCell
        oColtaBillAmount.Text = otaBillAmount.HRM_Departments1_Description
        oColtaBillAmount.CssClass = "rowHD"
        oColtaBillAmount.Style.Add("text-align", "left")
        oRowtaBillAmount.Cells.Add(oColtaBillAmount)
        oColtaBillAmount = New TableCell
        oColtaBillAmount.CssClass = "rowHD"
        oColtaBillAmount.Text = otaBillAmount.TotalInCurrency
        oColtaBillAmount.Style.Add("text-align", "right")
        oRowtaBillAmount.Cells.Add(oColtaBillAmount)
        oColtaBillAmount = New TableCell
        oColtaBillAmount.CssClass = "rowHD"
        oColtaBillAmount.Text = otaBillAmount.ConversionFactorINR
        oColtaBillAmount.Style.Add("text-align", "right")
        oRowtaBillAmount.Cells.Add(oColtaBillAmount)
        oColtaBillAmount = New TableCell
        oColtaBillAmount.CssClass = "rowHD"
        oColtaBillAmount.Text = otaBillAmount.TotalInINR
        oColtaBillAmount.Style.Add("text-align", "right")
        oRowtaBillAmount.Cells.Add(oColtaBillAmount)
        oTbltaBillAmount.Rows.Add(oRowtaBillAmount)
      Next
      form1.Controls.Add(oTbltaBillAmount)
    End If
  End Sub
End Class
