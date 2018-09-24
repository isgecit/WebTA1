Imports System
Imports System.Data
Imports System.Configuration
Imports System.Collections.Generic
Partial Class LC_PrkBalanceAsOn
  Inherits System.Web.UI.UserControl
  Private _EmployeeID As Int32 = -1
  Private _PerkID As Int32 = -1
  Private _EntitlementsCount As Integer = -1
  Private _LedgerCount As Integer = -1
  Private _PrintHeading As Boolean = True
  Private _Emp As SIS.NPRK.nprkEmployees = Nothing
  Public ReadOnly Property Emp As SIS.NPRK.nprkEmployees
    Get
      If _Emp Is Nothing Then
        _Emp = SIS.NPRK.nprkEmployees.nprkEmployeesGetByID(_EmployeeID)
      End If
      Return _Emp
    End Get
  End Property
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
  Public Property PrintHeading() As Boolean
    Get
      Return _PrintHeading
    End Get
    Set(ByVal value As Boolean)
      _PrintHeading = value
    End Set
  End Property
  Public Function GetHeader() As TableRow
    Dim oRow As TableRow
    Dim oCol As TableCell

    oRow = New TableRow
    oRow.Attributes.Add("style", "color: #000099; background-color: #999999")

    oCol = New TableCell
    oCol.Text = "Type"
    oCol.Width = 50
    oRow.Cells.Add(oCol)

    oCol = New TableCell
    oCol.Text = "Date"
    oCol.Width = 100
    oRow.Cells.Add(oCol)


    oCol = New TableCell
    oCol.Text = "Particulars"
    oCol.Width = 300
    oRow.Cells.Add(oCol)

    oCol = New TableCell
    oCol.Text = "Debit"
    oCol.Width = 100
    oCol.CssClass = "alignright"
    oRow.Cells.Add(oCol)


    oCol = New TableCell
    oCol.Text = "Credit"
    oCol.Width = 100
    oCol.CssClass = "alignright"
    oRow.Cells.Add(oCol)


    Return oRow
  End Function
  Private Function WriteEnt(ByVal oEnt As SIS.NPRK.nprkEntitlements) As TableRow
    Dim oRow As TableRow
    Dim oCol As TableCell

    oRow = New TableRow

    oCol = New TableCell
    oCol.Text = "ENT"
    oCol.Width = 50
    oRow.Cells.Add(oCol)

    oCol = New TableCell
    oCol.Text = Convert.ToDateTime(oEnt.EffectiveDate).ToString("MMM/yyyy")
    oCol.Width = 100
    oRow.Cells.Add(oCol)


    oCol = New TableCell
    oCol.Text = oEnt.Description
    oCol.Width = 300
    oRow.Cells.Add(oCol)

    oCol = New TableCell
    oCol.Text = IIf(oEnt.Value < 0, oEnt.Value, "-")
    oCol.CssClass = "alignright"
    oCol.Width = 100
    oRow.Cells.Add(oCol)

    oCol = New TableCell
    oCol.Text = IIf(oEnt.Value >= 0, oEnt.Value, "-")
    oCol.CssClass = "alignright"
    oCol.Width = 100
    oRow.Cells.Add(oCol)

    oRow.ForeColor = Drawing.Color.Green
    Return oRow

  End Function
  Private Function WriteLgr(ByVal oPmt As SIS.NPRK.nprkLedger) As TableRow
    Dim mTbl As Table = Nothing
    Dim mRow As TableRow = Nothing
    Dim mCol As TableCell = Nothing

    Dim oRow As TableRow
    Dim oCol As TableCell


    Select Case oPmt.PerkID
      Case prkPerk.Mobile, prkPerk.Telephone
        mTbl = New Table

        oRow = New TableRow

        oCol = New TableCell
        oCol.Text = oPmt.TranType
        oCol.Width = 50
        oRow.Cells.Add(oCol)

        oCol = New TableCell
        oCol.Text = oPmt.TranDate
        oCol.Width = 100
        oRow.Cells.Add(oCol)

        oCol = New TableCell
        oCol.Text = oPmt.Remarks
        oCol.Width = 300
        oRow.Cells.Add(oCol)

        oCol = New TableCell
        oCol.Text = IIf(oPmt.Value < 0, oPmt.Value, "-")
        oCol.CssClass = "alignright"
        oCol.Width = 100
        oRow.Cells.Add(oCol)

        oCol = New TableCell
        oCol.Text = IIf(oPmt.Value >= 0, oPmt.Value, "-")
        oCol.CssClass = "alignright"
        oCol.Width = 100
        oRow.Cells.Add(oCol)

        oRow.ForeColor = IIf(oPmt.Value < 0, Drawing.Color.Red, Drawing.Color.Green)

        mTbl.Rows.Add(oRow)

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

      Case Else

        oRow = New TableRow

        oCol = New TableCell
        oCol.Text = oPmt.TranType
        oCol.Width = 50
        oRow.Cells.Add(oCol)

        oCol = New TableCell
        oCol.Text = oPmt.TranDate
        oCol.Width = 100
        oRow.Cells.Add(oCol)

        oCol = New TableCell
        oCol.Text = oPmt.Remarks
        oCol.Width = 300
        oRow.Cells.Add(oCol)

        oCol = New TableCell
        oCol.Text = IIf(oPmt.Value < 0, oPmt.Value, "-")
        oCol.CssClass = "alignright"
        oCol.Width = 100
        oRow.Cells.Add(oCol)

        oCol = New TableCell
        oCol.Text = IIf(oPmt.Value >= 0, oPmt.Value, "-")
        oCol.CssClass = "alignright"
        oCol.Width = 100
        oRow.Cells.Add(oCol)

        oRow.ForeColor = IIf(oPmt.Value < 0, Drawing.Color.Red, Drawing.Color.Green)
    End Select


    Return oRow

  End Function
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

    tblEnt.Rows.Clear()

    Dim oEnts As List(Of SIS.NPRK.nprkEntitlements) = SIS.NPRK.nprkEntitlements.SelectListAsOn(_EmployeeID, _PerkID, Now)
    _EntitlementsCount = oEnts.Count
    Dim oPmts As List(Of SIS.NPRK.nprkLedger) = SIS.NPRK.nprkLedger.GetByEmployeeIDPerkID(_EmployeeID, _PerkID)
    _LedgerCount = oPmts.Count


    oRow = New TableRow
    oCol = New TableCell
    oCol.Text = oPrk.Description.ToUpper & ":"
    oCol.ColumnSpan = 5
    oCol.Width = 650
    oCol.Font.Bold = True
    oRow.Cells.Add(oCol)
    tblEnt.Rows.Add(oRow)
    Select Case oPrk.PerkID
      Case prkPerk.Mobile
        oRow = New TableRow
        oCol = New TableCell
        Try
          oCol.Text = "Maximum monthly Limit (Rs.): " & Emp.MobileLimit
        Catch ex As Exception
          oCol.Text = "Maximum monthly Limit (Rs.): "
        End Try
        oCol.ColumnSpan = 5
        oCol.Width = 650
        oCol.Font.Bold = True
        oRow.Cells.Add(oCol)
        tblEnt.Rows.Add(oRow)
      Case prkPerk.Telephone
        oRow = New TableRow
        oCol = New TableCell
        Try
          oCol.Text = "Maximum monthly Limit (Rs.): " & Emp.LandlineLimit
        Catch ex As Exception
          oCol.Text = "Maximum monthly Limit (Rs.): "
        End Try
        oCol.ColumnSpan = 5
        oCol.Width = 650
        oCol.Font.Bold = True
        oRow.Cells.Add(oCol)
        tblEnt.Rows.Add(oRow)
    End Select

    If oEnts.Count <= 0 And oPmts.Count <= 0 Then
      Return 0
    End If


    If _PrintHeading Then
      tblEnt.Rows.Add(GetHeader)
    End If


    Dim eCtr As Integer = 0
    Dim lCtr As Integer = 0

    Do While True
      If lCtr = oPmts.Count Then
        Exit Do
      End If
      If eCtr = oEnts.Count Then
        Exit Do
      End If
      Dim oLgr As SIS.NPRK.nprkLedger = oPmts(lCtr)
      Dim oEnt As SIS.NPRK.nprkEntitlements = oEnts(eCtr)

      If Convert.ToDateTime(oEnt.EffectiveDate) < Convert.ToDateTime(oLgr.TranDate) Then
        tblEnt.Rows.Add(WriteEnt(oEnt))
        totEnt += oEnt.Value
        eCtr += 1
      ElseIf Convert.ToDateTime(oEnt.EffectiveDate) > Convert.ToDateTime(oLgr.TranDate) Then
        tblEnt.Rows.Add(WriteLgr(oLgr))
        totPmt += oLgr.Value
        lCtr += 1
      ElseIf Convert.ToDateTime(oEnt.EffectiveDate) = Convert.ToDateTime(oLgr.TranDate) Then
        If oLgr.TranType = "OPB" Then
          tblEnt.Rows.Add(WriteLgr(oLgr))
          totPmt += oLgr.Value
          lCtr += 1
        Else
          tblEnt.Rows.Add(WriteEnt(oEnt))
          totEnt += oEnt.Value
          eCtr += 1
        End If
      End If

    Loop
    If lCtr < oPmts.Count Then
      For I As Integer = lCtr To oPmts.Count - 1
        Dim oLgr As SIS.NPRK.nprkLedger = oPmts(I)
        tblEnt.Rows.Add(WriteLgr(oLgr))
        totPmt += oLgr.Value
      Next
    End If
    If eCtr < oEnts.Count Then
      For I As Integer = eCtr To oEnts.Count - 1
        Dim oEnt As SIS.NPRK.nprkEntitlements = oEnts(I)
        tblEnt.Rows.Add(WriteEnt(oEnt))
        totEnt += oEnt.Value
      Next
    End If


    oRow = New TableRow
    oCol = New TableCell
    oCol.Text = ""
    oCol.ColumnSpan = 3
    oRow.Cells.Add(oCol)

    oCol = New TableCell
    oCol.Text = (totEnt + totPmt).ToString("n") & " " & oPrk.UOM
    oCol.ColumnSpan = 2
    oCol.Font.Bold = True
    oCol.CssClass = "alignright"
    oCol.ForeColor = IIf(totEnt + totPmt > 0, Drawing.Color.Green, Drawing.Color.Red)
    'oCol.BorderStyle = BorderStyle.Dashed
    'oCol.BorderWidth = 1
    oCol.Attributes.Add("style", "border-top: 1pt solid black; border-bottom: 1pt solid black")

    oRow.Cells.Add(oCol)
    tblEnt.Rows.Add(oRow)

    If Not _PrintHeading Then
      oRow = New TableRow
      oCol = New TableCell
      oCol.Text = "&nbsp;"
      oCol.ColumnSpan = 5
      oRow.Cells.Add(oCol)
      tblEnt.Rows.Add(oRow)
      oRow = New TableRow
      oCol = New TableCell
      oCol.Text = "&nbsp;"
      oCol.ColumnSpan = 5
      oRow.Cells.Add(oCol)
      tblEnt.Rows.Add(oRow)
    End If

    Return (totEnt + totPmt)
  End Function
End Class
