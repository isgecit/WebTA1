Imports System
Imports System.Data
Imports System.Configuration
Imports System.Collections.Generic
Partial Class LC_PrkBalance
  Inherits System.Web.UI.UserControl
  Private _EmployeeID As Int32 = -1
  Private _PerkID As Int32 = -1
  Private _EntitlementsCount As Integer = -1
  Private _LedgerCount As Integer = -1
  Public Property LedgerCount() As Integer
    Get
      Return _LedgerCount
    End Get
    Set(ByVal value As Integer)
      _LedgerCount = value
    End Set
  End Property
  Public Property EntitlementsCount() As Integer
    Get
      Return _EntitlementsCount
    End Get
    Set(ByVal value As Integer)
      _EntitlementsCount = value
    End Set
  End Property
  Public Property EmployeeID() As Integer
    Get
      Return ViewState("_EmployeeID")
    End Get
    Set(ByVal value As Integer)
      _EmployeeID = value
      ViewState.Add("_EmployeeID", value)
    End Set
  End Property
  Public Property PerkID() As Integer
    Get
      Return ViewState("_PerkID")
    End Get
    Set(ByVal value As Integer)
      _PerkID = value
      ViewState.Add("_PerkID", value)
    End Set
  End Property
  Public Function LoadData() As Double
    Dim totEnt As Double = 0
    Dim totPmt As Double = 0
    Dim netBal As Double = 0

    Dim oRow As TableRow = Nothing
    Dim oCol As TableCell = Nothing

    Dim oPrk As SIS.NPRK.nprkPerks = SIS.NPRK.nprkPerks.nprkPerksGetByID(PerkID)
    If oPrk Is Nothing Then
      oPrk = New SIS.NPRK.nprkPerks
      oPrk.UOM = "N/A"
      oPrk.Description = "***Not Selected***"
    End If
    LabelUOM.Text = oPrk.UOM

    '*-*-*-*-*-*-*-*
    'Entitlements
    '*-*-*-*-*-*-*-*
    tblEnt.Rows.Clear()
    oRow = New TableRow
    oRow.BackColor = Drawing.Color.DarkGray

    oCol = New TableCell
    oCol.Text = "ENTITLEMENTS: " & oPrk.Description.ToUpper
    oCol.ColumnSpan = 6
    oCol.Width = 430
    oCol.Font.Bold = True
    oRow.Cells.Add(oCol)

    tblEnt.Rows.Add(oRow)
    Dim oEnts As List(Of SIS.NPRK.nprkEntitlements) = SIS.NPRK.nprkEntitlements.GetByEmployeeIDPerkID(_EmployeeID, _PerkID)
    _EntitlementsCount = oEnts.Count
    If oEnts.Count <= 0 Then
      'No Data Found
      oRow = New TableRow

      oCol = New TableCell
      oCol.Text = "NO Entitlement Found"
      oCol.ColumnSpan = 6
      oCol.Width = 430
      oCol.ForeColor = Drawing.Color.Red
      oRow.Cells.Add(oCol)

      tblEnt.Rows.Add(oRow)
    Else
      'Heading of Ent Table

      oRow = New TableRow
      oRow.Attributes.Add("style", "color: #000099; background-color: #999999")

      oCol = New TableCell
      oCol.Text = "From Dt."
      oCol.Width = 80
      oRow.Cells.Add(oCol)

      oCol = New TableCell
      oCol.Text = "Cate."
      oCol.Width = 50
      oRow.Cells.Add(oCol)


      oCol = New TableCell
      oCol.Text = "Basic"
      oCol.Width = 100
      oCol.CssClass = "alignright"
      oRow.Cells.Add(oCol)

      oCol = New TableCell
      oCol.Text = "Loca."
      oCol.Width = 50
      oRow.Cells.Add(oCol)

      oCol = New TableCell
      oCol.Text = "Vehicle"
      oCol.Width = 50
      oRow.Cells.Add(oCol)

      oCol = New TableCell
      oCol.Text = "Value [" & oPrk.UOM & "]"
      oCol.Width = 100
      oCol.CssClass = "alignright"
      oRow.Cells.Add(oCol)

      tblEnt.Rows.Add(oRow)

      'Entitlement Records
      For Each oEnt As SIS.NPRK.nprkEntitlements In oEnts

        oRow = New TableRow
        oRow.BackColor = Drawing.Color.Lavender

        oCol = New TableCell
        oCol.Text = oEnt.EffectiveDate
        oRow.Cells.Add(oCol)

        oCol = New TableCell
        oCol.Text = oEnt.FK_PRK_Entitlements_PRK_Categories.CategoryCode
        oRow.Cells.Add(oCol)

        oCol = New TableCell
        oCol.Text = oEnt.Basic
        oCol.CssClass = "alignright"
        oRow.Cells.Add(oCol)

        oCol = New TableCell
        oCol.Text = oEnt.PostedAt
        oRow.Cells.Add(oCol)

        oCol = New TableCell
        oCol.Text = oEnt.VehicleType
        oRow.Cells.Add(oCol)

        oCol = New TableCell
        oCol.Text = oEnt.Value
        oCol.CssClass = "alignright"
        oRow.Cells.Add(oCol)

        tblEnt.Rows.Add(oRow)
        totEnt += oEnt.Value
      Next
      'Entitlement Total
      oRow = New TableRow
      oRow.ForeColor = Drawing.Color.DarkGreen

      oCol = New TableCell
      oCol.Text = "TOTAL Entitlements [" & oPrk.UOM & "]"
      oCol.ColumnSpan = 5
      oCol.CssClass = "alignright"
      oRow.Cells.Add(oCol)


      oCol = New TableCell
      oCol.Text = totEnt
      oCol.CssClass = "alignright"
      oRow.Cells.Add(oCol)

      tblEnt.Rows.Add(oRow)
    End If


    '*-*-*-*-*-*-*-*-*
    'Ledger
    '*-*-*-*-*-*-*-*-*
    tblLgr.Rows.Clear()
    oRow = New TableRow
    oRow.BackColor = Drawing.Color.DarkGray

    oCol = New TableCell
    oCol.Text = "LEDGER"
    oCol.ColumnSpan = 5
    oCol.Font.Bold = True
    oCol.Width = 420
    oRow.Cells.Add(oCol)

		tblLgr.Rows.Add(oRow)
    'To Execute Faster
    'Dim oPmts As List(Of SIS.PRK.PrkLedger) = SIS.PRK.PrkLedger.SelectList(0, 1000, "TranDate", _EmployeeID, _PerkID)
    Dim oPmts As List(Of SIS.NPRK.nprkLedger) = SIS.NPRK.nprkLedger.GetByEmployeeIDPerkID(_EmployeeID, _PerkID)
    _LedgerCount = oPmts.Count
    If oPmts.Count <= 0 Then
      'No data Found
      oRow = New TableRow

      oCol = New TableCell
      oCol.Text = "NO Ledger Record Found"
      oCol.ForeColor = Drawing.Color.Red
      oCol.ColumnSpan = 5
      oCol.Width = 420
      oRow.Cells.Add(oCol)

      tblLgr.Rows.Add(oRow)
    Else
      'Ledger Header

      oRow = New TableRow
      oRow.Attributes.Add("style", "color: #000099; background-color: #999999")

      oCol = New TableCell
      oCol.Text = "Type"
      oCol.Width = 60
      oRow.Cells.Add(oCol)

      oCol = New TableCell
      oCol.Text = "Tran Dt"
      oCol.Width = 60
      oRow.Cells.Add(oCol)

      oCol = New TableCell
      oCol.Text = "Bill Dt/Mon"
      oCol.Width = 100
      oRow.Cells.Add(oCol)


      oCol = New TableCell
      oCol.Text = "Debit [" & oPrk.UOM & "]"
      oCol.Width = 100
      oCol.CssClass = "alignright"
      oRow.Cells.Add(oCol)

      oCol = New TableCell
      oCol.Text = "Credit [" & oPrk.UOM & "]"
      oCol.Width = 100
      oCol.CssClass = "alignright"
      oRow.Cells.Add(oCol)

      tblLgr.Rows.Add(oRow)
      'Ledger Records
      For Each oPmt As SIS.NPRK.nprkLedger In oPmts

        oRow = New TableRow
        oRow.BackColor = Drawing.Color.Lavender

        oCol = New TableCell
        oCol.Text = oPmt.TranType
        oRow.Cells.Add(oCol)

        oCol = New TableCell
        oCol.Text = oPmt.TranDate
        oRow.Cells.Add(oCol)

        oCol = New TableCell
        oCol.Text = oPmt.Remarks
        oRow.Cells.Add(oCol)

        oCol = New TableCell
        oCol.Text = IIf(oPmt.Value < 0, oPmt.Value, "-")
        oCol.CssClass = "alignright"
        oRow.Cells.Add(oCol)

        oCol = New TableCell
        oCol.Text = IIf(oPmt.Value >= 0, oPmt.Value, "-")
        oCol.CssClass = "alignright"
        oRow.Cells.Add(oCol)

        tblLgr.Rows.Add(oRow)
        totPmt += oPmt.Value

        Dim mTbl As Table = Nothing
        Dim mRow As TableRow = Nothing
        Dim mCol As TableCell = Nothing

        Select Case oPmt.PerkID
          Case prkPerk.Mobile, prkPerk.Telephone
            mTbl = New Table

            Dim oBDs As List(Of SIS.NPRK.nprkBillDetails) = SIS.NPRK.nprkBillDetails.nprkBillDetailsSelectList(0, 99999, "", False, "", oPmt.ApplicationID, 0)
            For Each bd As SIS.NPRK.nprkBillDetails In oBDs
              mRow = New TableRow

              mCol = New TableCell
              mCol.Text = bd.BillNo
              mCol.Width = 50
              mRow.Cells.Add(mCol)

              mCol = New TableCell
              mCol.Text = bd.BillDate
              mCol.Width = 100
              mRow.Cells.Add(mCol)

              mCol = New TableCell
              mCol.Text = bd.Particulars
              mCol.Width = 300
              mRow.Cells.Add(mCol)

              mCol = New TableCell
              mCol.Text = bd.Quantity
              mCol.CssClass = "alignright"
              mCol.Width = 100
              mRow.Cells.Add(mCol)

              mCol = New TableCell
              mCol.Text = bd.Amount
              mCol.CssClass = "alignright"
              mCol.Width = 100
              mRow.Cells.Add(mCol)

              mRow.ForeColor = Drawing.Color.SteelBlue
              mTbl.Rows.Add(mRow)
            Next
            oRow = New TableRow
            oCol = New TableCell
            oCol.ColumnSpan = 5
            oCol.Controls.Add(mTbl)
            oRow.Cells.Add(oCol)
            tblLgr.Rows.Add(oRow)
        End Select

      Next
      'Ledger Total

      oRow = New TableRow
      oRow.ForeColor = Drawing.Color.DarkGreen

      oCol = New TableCell
      oCol.Text = "TOTAL Ledger [" & oPrk.UOM & "]"
      oCol.ColumnSpan = 3
      oCol.CssClass = "alignright"
      oRow.Cells.Add(oCol)


      oCol = New TableCell
      oCol.Text = totPmt
      oCol.ColumnSpan = 2
      oCol.CssClass = "alignright"
      oRow.Cells.Add(oCol)

      tblLgr.Rows.Add(oRow)


    End If
    'Net Balance
    NetBalance.Text = (totEnt + totPmt).ToString

    Return (totEnt + totPmt)
  End Function
End Class
