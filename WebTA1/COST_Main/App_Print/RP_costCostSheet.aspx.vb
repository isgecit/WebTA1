Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Imports System.IO
Imports OfficeOpenXml
Imports System.Web.Script.Serialization

Partial Class RP_costCostSheetXL
  Inherits System.Web.UI.Page

  Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    Try
      Dim aVal() As String = Request.QueryString("pk").Split("|".ToCharArray)
      Dim ProjectGroupID As Int32 = CType(aVal(0), Int32)
      Dim FinYear As Int32 = CType(aVal(1), Int32)
      Dim Quarter As Int32 = CType(aVal(2), Int32)
      Dim Revision As Int32 = CType(aVal(3), Int32)

      Dim FileName As String = Server.MapPath("~/..") & "App_Temp\" & Guid.NewGuid().ToString()
      IO.File.Copy(Server.MapPath("~/App_Templates") & "\cs_Template.xlsx", FileName)

      Dim FilePath As String = csGLMain.CreateFile(FileName, ProjectGroupID, FinYear, Quarter, Revision)
      'File Name Prj Group
      Dim tmp As SIS.COST.costProjectGroups = SIS.COST.costProjectGroups.costProjectGroupsGetByID(ProjectGroupID)
      Dim FileNameForUser As String = tmp.ProjectGroupDescription & "_" & FinYear & "_Q_" & Quarter & ".xlsx"
      If IO.File.Exists(FilePath) Then
        Response.Clear()
        Response.AppendHeader("content-disposition", "attachment; filename=" & FileNameForUser)
        Response.ContentType = SIS.SYS.Utilities.ApplicationSpacific.ContentType(FileNameForUser)
        Response.WriteFile(FilePath)
        Response.End()
        Try
          IO.File.Delete(FilePath)
        Catch ex As Exception
        End Try
      End If
    Catch ex As Exception
      Dim message As String = New JavaScriptSerializer().Serialize(ex.Message.ToString())
      Dim script As String = String.Format("alert({0});", message)
      ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", script, True)
      'Response.Write(message)
      'Response.End()
    End Try
  End Sub
End Class


Public Class csGLMain
  Implements IDisposable

  Public Property xlStartRow As Integer = 6
  Public Property xlStartCol As Integer = 1
  Public Property xlGapRow As Integer = 2
  Public ReadOnly Property xlStartDataCol As Integer
    Get
      Return xlStartCol + 2
    End Get
  End Property
  Public ReadOnly Property xlSalesHeadingtRow As Integer
    Get
      Return xlStartRow + 3
    End Get
  End Property
  Public Property xlCostHeadingRow As Integer = 1
  Public Property xlSalesTotalRow As Integer = 1
  Public Property xlCostTotalRow As Integer = 1
  Public Property xlGrossMarginRow As Integer = 1
  Public Property xlProjectInputStartRow As Integer = 1
  Public Property xlProjectInputStartCol As Integer = 1
  Public Property xlLastDataCol As Integer = 0
  Public Property ProjectGroupID As Integer = 0
  Public Property FinYear As Integer = 0
  Public Property Quarter As Integer = 0
  Public Property Revision As Integer = 0
  Public Property ListGLGroups As List(Of csGLGroup) = New List(Of csGLGroup)
  Public Property LowestYear As Integer = 0
  Public Property YTDFormula As String = ""
  Public Property GroupMarginCurrentYearINR As Decimal = 0

  Public Shared Function getGLMain(ByVal ProjectGroupID As Int32, ByVal FinYear As Int32, ByVal Quarter As Int32, ByVal Revision As Int32, Optional ByVal Erection As Boolean = False, Optional ByVal Supply As Boolean = False) As csGLMain
    Dim glMain As New csGLMain
    glMain.FinYear = FinYear
    Dim costSheetAll As List(Of SIS.COST.costCostSheet) = SIS.COST.costCostSheet.getcsLastYears(ProjectGroupID, FinYear, Quarter, Revision)
    costSheetAll.Sort(Function(x, y) x.FinYear.CompareTo(y.FinYear))
    For Each costSheetTmp As SIS.COST.costCostSheet In costSheetAll
      If glMain.LowestYear = 0 Then
        glMain.LowestYear = costSheetTmp.FinYear
      Else
        If costSheetTmp.FinYear < glMain.LowestYear Then
          glMain.LowestYear = costSheetTmp.FinYear
        End If
      End If
    Next
    For Each costSheetTmp As SIS.COST.costCostSheet In costSheetAll
      Dim ListTmpData As List(Of SIS.COST.costCSDWOnGLGr) = SIS.COST.costCSDWOnGLGr.UZ_costCSDWOnGLGrSelectList(0, 99999, "", False, "", costSheetTmp.ProjectGroupID, costSheetTmp.FinYear, costSheetTmp.Quarter, costSheetTmp.Revision, Erection, Supply)
      For Each tmpData As SIS.COST.costCSDWOnGLGr In ListTmpData
        Dim findGLGroupID As Integer = IIf(tmpData.FK_COST_CSDataWOnGLGroup_GLGroupID.GLNatureID = 3, tmpData.FK_COST_CSDataWOnGLGroup_GLGroupID.CostGLGroupID, tmpData.GLGroupID)
        Dim tmpGLGroup As csGLGroup = glMain.getGLGroupByID(findGLGroupID)
        If tmpGLGroup Is Nothing Then
          tmpGLGroup = New csGLGroup(glMain)
          With tmpGLGroup
            If tmpData.FK_COST_CSDataWOnGLGroup_GLGroupID.GLNatureID = 3 Then 'Liability
              .glGroupDescription = tmpData.FK_COST_CSDataWOnGLGroup_GLGroupID.FK_COST_GLGroups_CostGLGroupID.GLGroupDescriptions
              .glNatureDescription = "COST"
              .glNatureID = 1
              .glGroupID = tmpData.FK_COST_CSDataWOnGLGroup_GLGroupID.CostGLGroupID
              .Sequence = tmpData.FK_COST_CSDataWOnGLGroup_GLGroupID.FK_COST_GLGroups_CostGLGroupID.Sequence
            Else
              .glGroupDescription = tmpData.COST_GLGroups3_GLGroupDescriptions
              .glNatureDescription = tmpData.FK_COST_CSDataWOnGLGroup_GLGroupID.FK_COST_GLGroups_GLNatureID.GLNatureDescription
              .glNatureID = tmpData.FK_COST_CSDataWOnGLGroup_GLGroupID.GLNatureID
              .glGroupID = tmpData.GLGroupID
              .Sequence = tmpData.FK_COST_CSDataWOnGLGroup_GLGroupID.Sequence
            End If
          End With
          glMain.ListGLGroups.Add(tmpGLGroup)
        End If
        Dim yrData As csGLGroup.csYearAmount = tmpGLGroup.getYearAmountByYear(tmpData.FinYear)
        With yrData
          If tmpData.FK_COST_CSDataWOnGLGroup_GLGroupID.GLNatureID = 3 Then 'Liability
            .Provision += tmpData.Amount
            .ProvisionFC += tmpData.NetFC
          Else
            .AfterProvision += tmpData.Amount
            .AfterProvisionFC += tmpData.NetFC
          End If
        End With
      Next
      If costSheetTmp.FinYear = FinYear And Not Erection Then
        'Added On 01-04-2017, on request of Anuj
        glMain.GroupMarginCurrentYearINR = costSheetTmp.FK_COST_CostSheet_ProjectGroupID.GroupMarginCurrentYearINR
        '---------------------------------------
        Dim ListTmpLiability As List(Of SIS.COST.costCostSheetLiability) = SIS.COST.costCostSheetLiability.UZ_costCostSheetLiabilitySelectList(0, 99999, "", False, "", costSheetTmp.ProjectGroupID, costSheetTmp.FinYear, costSheetTmp.Quarter, costSheetTmp.Revision)
        For Each tmpData As SIS.COST.costCostSheetLiability In ListTmpLiability
          '==========================
          Dim ttmp As SIS.COST.costCostSheetLiability = tmpData
          Dim tf As String = ""
          If ttmp.GLCode = "2510210" Then
            tf = "13"
          ElseIf ttmp.GLCode = "2510213" Then
            tf = "8"
          ElseIf ttmp.GLCode = "2510214" Then
            tf = "21"
          ElseIf ttmp.GLCode = "2510215" Then
            tf = "15"
          ElseIf ttmp.GLCode = "2510216" Then
            tf = "14"
          ElseIf ttmp.GLCode = "2510217" Then
            tf = "3"
          ElseIf ttmp.GLCode = "2510225" Then
            tf = "22"
          ElseIf ttmp.GLCode = "2510226" Then
            tf = "5"
          ElseIf ttmp.GLCode = "2510227" Then
            tf = "10"
          ElseIf ttmp.GLCode = "2530211" Then
            tf = "47"
          End If
          Dim tmpGLGroup As csGLGroup = glMain.getGLGroupByID(tf)
          If tmpGLGroup Is Nothing Then
            tmpGLGroup = New csGLGroup(glMain)
            Dim tmpGlg As SIS.COST.costGLGroups = SIS.COST.costGLGroups.costGLGroupsGetByID(tf)
            If tmpGlg Is Nothing Then
              Throw New Exception("GL Group Code: " & tf & " Not found in Table GLGroups")
            End If
            With tmpGLGroup
              .glGroupDescription = tmpGlg.GLGroupDescriptions
              .glNatureDescription = tmpGlg.FK_COST_GLGroups_GLNatureID.GLNatureDescription
              .glNatureID = tmpGlg.GLNatureID
              .glGroupID = tmpGlg.GLGroupID
              .Sequence = tmpGlg.Sequence
            End With
            glMain.ListGLGroups.Add(tmpGLGroup)
          End If
          Dim yrData As csGLGroup.csYearAmount = tmpGLGroup.objLiability  '.getYearAmountByYear(tmpData.FinYear + 2) ' + 2 For Liability Year
          With yrData
            .AfterProvision += tmpData.Amount
            .AfterProvisionFC += tmpData.NetFC
          End With
        Next
      End If
    Next
    'Update Row values
    'cost=1
    'sales=2
    glMain.ListGLGroups.Sort(Function(x, y) x.Sequence.CompareTo(y.Sequence))
    Dim L_glNatureID As Integer = 0
    Dim tmpCount As Integer = 0
    For Each tmp As csGLGroup In glMain.ListGLGroups
      If L_glNatureID <> tmp.glNatureID Then
        If L_glNatureID = 0 Then
          tmpCount = glMain.xlSalesHeadingtRow + glMain.xlGapRow
          'If there is no sale, cost row must be initialized
          glMain.xlSalesTotalRow = tmpCount
          tmpCount += glMain.xlGapRow
          glMain.xlCostHeadingRow = tmpCount
          tmpCount += glMain.xlGapRow
          '-----------------END-----------------------
        Else
          glMain.xlSalesTotalRow = tmpCount
          tmpCount += glMain.xlGapRow
          glMain.xlCostHeadingRow = tmpCount
          tmpCount += glMain.xlGapRow
        End If
        L_glNatureID = tmp.glNatureID
      End If
      tmp.xlRow = tmpCount
      tmpCount += glMain.xlGapRow
    Next
    glMain.xlCostTotalRow = tmpCount
    tmpCount += 1
    glMain.xlGrossMarginRow = tmpCount
    'End Update Row Values
    Return glMain
  End Function

  Public Function getGLGroupByID(ByVal glGroupID As Integer) As csGLGroup
    Dim mRet As csGLGroup = Nothing
    For Each tmp In ListGLGroups
      If tmp.glGroupID = glGroupID Then
        mRet = tmp
        Exit For
      End If
    Next
    Return mRet
  End Function
  Public ReadOnly Property GrossMarginCurrentYear As Decimal
    Get
      Dim mRet As Decimal = 0
      Dim sale As Decimal = 0
      Dim cost As Decimal = 0
      For Each tmpGl As csGLGroup In ListGLGroups
        For Each tmpYr As csGLGroup.csYearAmount In tmpGl.ListYearAmounts
          If tmpYr.FinYear = FinYear Then
            If tmpGl.glNatureID = 1 Then 'Cost
              If tmpGl.glGroupID = 47 Then ' Warranty
                cost += tmpYr.AfterProvision * -1
              Else
                cost += tmpYr.AfterProvision
              End If
            Else
              sale += tmpYr.AfterProvision * -1
            End If
            Exit For
          End If
        Next
      Next
      mRet = sale - cost
      Return mRet
    End Get
  End Property

  Public ReadOnly Property GrossMarginLastYear As Decimal
    Get
      Dim mRet As Decimal = 0
      Dim sale As Decimal = 0
      Dim cost As Decimal = 0
      For Each tmpGl As csGLGroup In ListGLGroups
        For Each tmpYr As csGLGroup.csYearAmount In tmpGl.ListYearAmounts
          If tmpYr.FinYear <= FinYear - 1 Then
            If tmpGl.glNatureID = 1 Then 'Cost
              If tmpGl.glGroupID = 47 Then ' Warranty
                cost += tmpYr.AfterProvision * -1
              Else
                cost += tmpYr.AfterProvision
              End If
            Else
              sale += tmpYr.AfterProvision * -1
            End If
          End If
        Next
      Next
      mRet = sale - cost
      Return mRet
    End Get
  End Property
  Public Class csGLGroup
    Implements IDisposable
    Public Property glMain As csGLMain = Nothing

    Public Property glNatureID As Integer = 0
    Public Property glNatureDescription As String = ""
    Public Property glGroupID As Integer = 0
    Public Property glGroupDescription As String = ""
    Public Property Sequence As Integer = 0
    Public Property ListYearAmounts As List(Of csYearAmount) = New List(Of csYearAmount)
    Public Property xlGLGroupLastCol As Integer = 1
    Public Property xlRow As Integer = 1
    Public Function getYearAmountByYear(ByVal FinYear As Integer) As csYearAmount
      Dim tmp As csYearAmount = Nothing
      For Each tmp In ListYearAmounts
        If tmp.FinYear = FinYear Then
          Exit For
        End If
      Next
      Return tmp
    End Function

    Public ReadOnly Property objYTD As csYearAmount
      Get
        For Each tmp As csYearAmount In ListYearAmounts
          If tmp.IsYtd Then
            Return tmp
          End If
        Next
        Return Nothing
      End Get
    End Property
    Public ReadOnly Property YTDValue As Decimal
      Get
        Dim mRet As Decimal = 0
        For Each tmp As csYearAmount In ListYearAmounts
          If tmp.IsYtd Then Continue For
          If tmp.IsLiability Then Continue For
          mRet += tmp.AfterProvision
        Next
        Return mRet
      End Get
    End Property
    Public ReadOnly Property YTDFormula As String
      Get
        Dim mRet As String = ""
        For Each tmp As csYearAmount In ListYearAmounts
          If tmp.IsYtd Then Continue For
          If tmp.IsLiability Then Continue For
          mRet &= (IIf(mRet = "", "", "+") & tmp.xlACell & Me.xlRow)
        Next
        Return mRet
      End Get
    End Property

    Public ReadOnly Property objLiability As csYearAmount
      Get
        For Each tmp As csYearAmount In ListYearAmounts
          If tmp.IsLiability Then
            Return tmp
          End If
        Next
        Return Nothing
      End Get
    End Property
    Public Function AfterProvisionForWaranty(ByVal FinYear As Integer) As Decimal
      Dim mRet As Decimal = 0
      For Each tmp As csYearAmount In ListYearAmounts
        If tmp.FinYear < FinYear Then
          mRet -= tmp.AfterProvision
        ElseIf tmp.FinYear = FinYear Then
          mRet += tmp.AfterProvision
        End If
      Next
      Return mRet * -1
    End Function
    Public Function AfterProvisionForWarantyFC(ByVal FinYear As Integer) As Decimal
      Dim mRet As Decimal = 0
      For Each tmp As csYearAmount In ListYearAmounts
        If tmp.FinYear < FinYear Then
          mRet -= tmp.AfterProvisionFC
        ElseIf tmp.FinYear = FinYear Then
          mRet += tmp.AfterProvisionFC
        End If
      Next
      Return mRet * -1
    End Function
    Public Sub New()
      'dummy
    End Sub
    Public Sub New(ByVal glM As csGLMain)
      Dim I As Integer = glM.xlStartDataCol
      Dim lY As Integer = glM.LowestYear
      Dim fY As Integer = glM.FinYear
      Do While lY <= fY
        If lY = fY Then
          ListYearAmounts.Add(New csYearAmount(lY, True, I + 2, False, False, Me))
          I += 3
        Else
          ListYearAmounts.Add(New csYearAmount(lY, False, I, False, False, Me))
          I += 1
        End If
        lY += 1
      Loop
      ListYearAmounts.Add(New csYearAmount(lY, False, I, True, False, Me)) 'YTD
      lY += 1
      I += 1
      ListYearAmounts.Add(New csYearAmount(lY, False, I, False, True, Me)) 'Liability
      If glM.xlLastDataCol < I Then
        glM.xlLastDataCol = I
      End If
      ListYearAmounts.Sort(Function(x, y) x.FinYear.CompareTo(y.FinYear))
      Me.glMain = glM
    End Sub
    Public Class csYearAmount
      Implements IDisposable
      Public Property glGroup As csGLGroup = Nothing
      Public Property FinYear As Integer = 0
      Public Property IsLiability As Boolean = False
      Public Property IsCurrent As Boolean = False
      Public Property IsYtd As Boolean = False
      Public Property Provision As Decimal = 0
      Public Property AfterProvision As Decimal = 0
      Public Property ProvisionFC As Decimal = 0
      Public Property AfterProvisionFC As Decimal = 0

      Public Property xlACol As Integer = 1
      Public ReadOnly Property xlPCol As Integer
        Get
          Return xlACol - 1
        End Get
      End Property
      Public ReadOnly Property xlBCol As Integer
        Get
          Return xlACol - 2
        End Get
      End Property
      Public ReadOnly Property xlPCell As String
        Get
          Return Chr(xlPCol + 64)
        End Get
      End Property
      Public ReadOnly Property xlBCell As String
        Get
          Return Chr(xlBCol + 64)
        End Get
      End Property

      Public ReadOnly Property xlACell As String
        Get
          Return Chr(xlACol + 64)
        End Get
      End Property
      Public ReadOnly Property BeforeProvision As Decimal
        Get
          Dim mRet As Decimal = 0
          If glGroup.glGroupID = 47 Then 'Waranty
            mRet = AfterProvision - Provision
          Else
            mRet = AfterProvision - (Provision * IIf(glGroup.glNatureDescription = "COST", -1, 1))
          End If
          Return mRet
        End Get
      End Property
      Public ReadOnly Property BeforeProvisionFC As Decimal
        Get
          Dim mRet As Decimal = 0
          If glGroup.glGroupID = 47 Then 'Waranty
            mRet = AfterProvisionFC - ProvisionFC
          Else
            mRet = AfterProvisionFC - (ProvisionFC * IIf(glGroup.glNatureDescription = "COST", -1, 1))
          End If
          Return mRet
        End Get
      End Property

      Public Sub New()
        'dummy
      End Sub
      Public Sub New(ByVal Yr As Integer, ByVal iCY As Boolean, ByVal xCol As Integer, ByVal iYD As Boolean, ByVal iLI As Boolean, ByVal glGr As csGLGroup)
        FinYear = Yr
        IsCurrent = iCY
        xlACol = xCol
        IsYtd = iYD
        IsLiability = iLI
        Me.glGroup = glGr
      End Sub

#Region "IDisposable Support"
      Private disposedValue As Boolean ' To detect redundant calls

      ' IDisposable
      Protected Overridable Sub Dispose(disposing As Boolean)
        If Not disposedValue Then
          If disposing Then
            ' TODO: dispose managed state (managed objects).
            glGroup = Nothing
          End If

          ' TODO: free unmanaged resources (unmanaged objects) and override Finalize() below.
          ' TODO: set large fields to null.
        End If
        disposedValue = True
      End Sub

      ' TODO: override Finalize() only if Dispose(disposing As Boolean) above has code to free unmanaged resources.
      'Protected Overrides Sub Finalize()
      '    ' Do not change this code.  Put cleanup code in Dispose(disposing As Boolean) above.
      '    Dispose(False)
      '    MyBase.Finalize()
      'End Sub

      ' This code added by Visual Basic to correctly implement the disposable pattern.
      Public Sub Dispose() Implements IDisposable.Dispose
        ' Do not change this code.  Put cleanup code in Dispose(disposing As Boolean) above.
        Dispose(True)
        ' TODO: uncomment the following line if Finalize() is overridden above.
        ' GC.SuppressFinalize(Me)
      End Sub
#End Region
    End Class

#Region "IDisposable Support"
    Private disposedValue As Boolean ' To detect redundant calls

    ' IDisposable
    Protected Overridable Sub Dispose(disposing As Boolean)
      If Not disposedValue Then
        If disposing Then
          ' TODO: dispose managed state (managed objects).
          glMain = Nothing
          ListYearAmounts = Nothing
        End If

        ' TODO: free unmanaged resources (unmanaged objects) and override Finalize() below.
        ' TODO: set large fields to null.
      End If
      disposedValue = True
    End Sub

    ' TODO: override Finalize() only if Dispose(disposing As Boolean) above has code to free unmanaged resources.
    'Protected Overrides Sub Finalize()
    '    ' Do not change this code.  Put cleanup code in Dispose(disposing As Boolean) above.
    '    Dispose(False)
    '    MyBase.Finalize()
    'End Sub

    ' This code added by Visual Basic to correctly implement the disposable pattern.
    Public Sub Dispose() Implements IDisposable.Dispose
      ' Do not change this code.  Put cleanup code in Dispose(disposing As Boolean) above.
      Dispose(True)
      ' TODO: uncomment the following line if Finalize() is overridden above.
      ' GC.SuppressFinalize(Me)
    End Sub
#End Region
  End Class
  Public Shared Function RenderMainTable(ByVal xlWS As ExcelWorksheet, ByVal glMain As csGLMain, ByVal StartRow As Integer) As Integer
    If glMain.ListGLGroups.Count <= 0 Then Return StartRow
    Dim r As Integer = StartRow
    Dim c As Integer = 3
    glMain.xlStartRow = StartRow
    Dim L_glNatureID As Integer = 0
    Dim tmpCount As Integer = glMain.xlStartRow
    Dim completed As Boolean = False
    For Each tmp As csGLGroup In glMain.ListGLGroups
      If L_glNatureID <> tmp.glNatureID Then
        If L_glNatureID = 0 Then
          tmpCount = glMain.xlSalesHeadingtRow + glMain.xlGapRow
        Else
          glMain.xlSalesTotalRow = tmpCount
          tmpCount += glMain.xlGapRow
          glMain.xlCostHeadingRow = tmpCount
          tmpCount += glMain.xlGapRow
          completed = True
        End If
        L_glNatureID = tmp.glNatureID
      End If
      tmp.xlRow = tmpCount
      tmpCount += glMain.xlGapRow
    Next
    If Not completed Then
      glMain.xlSalesTotalRow = tmpCount
      tmpCount += glMain.xlGapRow
      glMain.xlCostHeadingRow = tmpCount
      tmpCount += glMain.xlGapRow
    End If
    glMain.xlCostTotalRow = tmpCount
    tmpCount += 1
    glMain.xlGrossMarginRow = tmpCount
    With xlWS

      For Each htmp As csGLGroup.csYearAmount In glMain.ListGLGroups(0).ListYearAmounts
        If Not htmp.IsCurrent Then
          If htmp.IsYtd Then
            .Cells(r, htmp.xlACol).Value = "Total"
            .Cells(r + 1, htmp.xlACol).Value = "YTD"
          ElseIf htmp.IsLiability Then
            .Cells(r, htmp.xlACol).Value = "Provision"
          Else
            .Cells(r, htmp.xlACol).Value = "Total"
            .Cells(r + 1, htmp.xlACol).Value = "'" & htmp.FinYear
          End If
          .Cells(r, htmp.xlACol, r + 1, htmp.xlACol).Style.Font.Bold = True
          .Cells(r, htmp.xlACol, r + 1, htmp.xlACol).Style.HorizontalAlignment = HorizontalAlign.Center
          .Cells(r, htmp.xlACol, r + 1, htmp.xlACol).Style.Border.BorderAround(Style.ExcelBorderStyle.Medium)
        Else
          .Cells(r, htmp.xlBCol, r, htmp.xlACol).Merge = True
          .Cells(r, htmp.xlBCol).Value = "Quarter " & glMain.Quarter & " Year " & htmp.FinYear
          .Cells(r + 1, htmp.xlBCol).Value = "Before Provision"
          .Cells(r + 1, htmp.xlPCol).Value = "Provision"
          .Cells(r + 1, htmp.xlACol).Value = "After Provision"
          .Cells(r, htmp.xlBCol, r + 1, htmp.xlACol).Style.Font.Bold = True
          .Cells(r, htmp.xlBCol, r + 1, htmp.xlACol).Style.HorizontalAlignment = HorizontalAlign.Center
          .Cells(r, htmp.xlBCol, r, htmp.xlACol).Style.Border.BorderAround(Style.ExcelBorderStyle.Medium)
          .Cells(r + 1, htmp.xlBCol).Style.Border.BorderAround(Style.ExcelBorderStyle.Medium)
          .Cells(r + 1, htmp.xlPCol).Style.Border.BorderAround(Style.ExcelBorderStyle.Medium)
          .Cells(r + 1, htmp.xlACol).Style.Border.BorderAround(Style.ExcelBorderStyle.Medium)
        End If
      Next
      'Write Data
      Dim lNature As String = ""
      Dim idx As Integer = 0

      lNature = "SALES"
      r = glMain.xlSalesHeadingtRow
      .Cells(r, 1).Value = """A"""
      .Cells(r, 2).Value = "SALES"
      .Cells(r, 1, r, 2).Style.Font.Bold = True
      .Cells(r, 1, r, 2).Style.HorizontalAlignment = HorizontalAlign.Center

      Dim tmp As csGLGroup = Nothing
      For Each tmp In glMain.ListGLGroups
        If lNature <> tmp.glNatureDescription Then
          .Cells(glMain.xlSalesTotalRow, 2).Value = "Total of ""A"""
          'print Total
          For Each tmpAmt As csGLGroup.csYearAmount In tmp.ListYearAmounts
            r = glMain.xlSalesTotalRow
            If tmpAmt.IsCurrent Then
              .Cells(r, tmpAmt.xlACol).Formula = "sum(" & tmpAmt.xlACell & glMain.xlSalesHeadingtRow + 1 & ":" & tmpAmt.xlACell & glMain.xlSalesTotalRow - 1 & ")"
              .Cells(r, tmpAmt.xlPCol).Formula = "sum(" & tmpAmt.xlPCell & glMain.xlSalesHeadingtRow + 1 & ":" & tmpAmt.xlPCell & glMain.xlSalesTotalRow - 1 & ")"
              .Cells(r, tmpAmt.xlBCol).Formula = "sum(" & tmpAmt.xlBCell & glMain.xlSalesHeadingtRow + 1 & ":" & tmpAmt.xlBCell & glMain.xlSalesTotalRow - 1 & ")"
            Else
              .Cells(r, tmpAmt.xlACol).Formula = "sum(" & tmpAmt.xlACell & glMain.xlSalesHeadingtRow + 1 & ":" & tmpAmt.xlACell & glMain.xlSalesTotalRow - 1 & ")"
            End If
          Next
          .Cells(r, 2, r, glMain.xlLastDataCol - 1).Style.Font.Bold = True
          .Cells(r, 2, r, glMain.xlLastDataCol - 1).Style.HorizontalAlignment = HorizontalAlign.Center
          .Cells(r, 2, r, glMain.xlLastDataCol - 1).Style.Border.BorderAround(Style.ExcelBorderStyle.Thin)
          idx = 0
          lNature = "COST"
          r = glMain.xlCostHeadingRow
          .Cells(r, 1).Value = """B"""
          .Cells(r, 2).Value = "COST"
          .Cells(r, 1, r, 2).Style.Font.Bold = True
          .Cells(r, 1, r, 2).Style.HorizontalAlignment = HorizontalAlign.Center
        End If
        idx += 1
        .Cells(tmp.xlRow, 1).Value = idx
        .Cells(tmp.xlRow, 2).Value = tmp.glGroupDescription
        For Each tm As csGLGroup.csYearAmount In tmp.ListYearAmounts
          If tm.IsCurrent Then
            If tmp.glGroupID = "47" Then 'WARANTY
              .Cells(tmp.xlRow, tm.xlBCol).Value = tm.BeforeProvision * -1
              .Cells(tmp.xlRow, tm.xlPCol).Value = tm.Provision * -1
            Else
              .Cells(tmp.xlRow, tm.xlBCol).Value = tm.BeforeProvision * IIf(lNature = "SALES", -1, 1)
              .Cells(tmp.xlRow, tm.xlPCol).Value = tm.Provision * IIf(lNature = "COST", -1, 1)
            End If
            .Cells(tmp.xlRow, tm.xlACol).Formula = tm.xlBCell & tmp.xlRow & "+" & tm.xlPCell & tmp.xlRow
            'Formula in Next Blank Line
            .Cells(tmp.xlRow + 1, tm.xlACol).Formula = tm.xlBCell & (tmp.xlRow + 1) & "+" & tm.xlPCell & (tmp.xlRow + 1)
            .Cells(tmp.xlRow + 1, tm.xlACol).Style.Font.Color.SetColor(System.Drawing.Color.Red)
          Else
            If tmp.glGroupID = "47" Then
              .Cells(tmp.xlRow, tm.xlACol).Value = tm.AfterProvision * -1
            Else
              .Cells(tmp.xlRow, tm.xlACol).Value = tm.AfterProvision * IIf(lNature = "SALES", -1, 1)
            End If
          End If
        Next
        'YTD Column
        .Cells(tmp.xlRow, tmp.objYTD.xlACol).Formula = tmp.YTDFormula
        'Total Liability Column
        .Cells(tmp.xlRow, tmp.objLiability.xlACol).Value = tmp.objLiability.AfterProvision * -1
        'Formula in Next Blank Line
        .Cells(tmp.xlRow + 1, tmp.objYTD.xlACol).Formula = tmp.YTDFormula.Replace(tmp.xlRow, tmp.xlRow + 1)
        .Cells(tmp.xlRow + 1, tmp.objYTD.xlACol).Style.Font.Color.SetColor(System.Drawing.Color.Red)
      Next
      'Print COST Total Row 
      r = glMain.xlCostTotalRow
      .Cells(r, 2).Value = "Total of ""B"""
      .Cells(r, 2).Style.HorizontalAlignment = HorizontalAlign.Center
      .Cells(r, 2).Style.Border.BorderAround(Style.ExcelBorderStyle.Thin)
      For Each tm As csGLGroup.csYearAmount In tmp.ListYearAmounts
        If tm.IsCurrent Then
          .Cells(r, tm.xlBCol).Formula = "sum(" & tm.xlBCell & glMain.xlCostHeadingRow + 1 & ":" & tm.xlBCell & r - 1 & ")"
          .Cells(r, tm.xlBCol).Style.Border.BorderAround(Style.ExcelBorderStyle.Thin)
          .Cells(r, tm.xlPCol).Formula = "sum(" & tm.xlPCell & glMain.xlCostHeadingRow + 1 & ":" & tm.xlPCell & r - 1 & ")"
          .Cells(r, tm.xlPCol).Style.Border.BorderAround(Style.ExcelBorderStyle.Thin)
          .Cells(r, tm.xlACol).Formula = "sum(" & tm.xlACell & glMain.xlCostHeadingRow + 1 & ":" & tm.xlACell & r - 1 & ")"
          .Cells(r, tm.xlACol).Style.Border.BorderAround(Style.ExcelBorderStyle.Thin)
        Else
          .Cells(r, tm.xlACol).Formula = "sum(" & tm.xlACell & glMain.xlCostHeadingRow + 1 & ":" & tm.xlACell & r - 1 & ")"
          .Cells(r, tm.xlACol).Style.Border.BorderAround(Style.ExcelBorderStyle.Thin)
        End If
      Next
      .Cells(r, 2, r, glMain.xlLastDataCol).Style.Font.Bold = True
      'Print Gross Margin Row
      r = glMain.xlGrossMarginRow
      .Cells(r, 1).Value = """C"""
      .Cells(r, 2).Value = "Gross Margin (A-B)"
      .Cells(r, 1, r, 2).Style.Font.Bold = True
      .Cells(r, 1, r, 2).Style.HorizontalAlignment = HorizontalAlign.Center
      .Cells(r, 2).Style.Border.BorderAround(Style.ExcelBorderStyle.Thin)
      For Each tm As csGLGroup.csYearAmount In tmp.ListYearAmounts
        If tm.IsLiability Then Continue For
        If tm.IsCurrent Then
          .Cells(r, tm.xlBCol).Formula = tm.xlBCell & glMain.xlSalesTotalRow & "-" & tm.xlBCell & glMain.xlCostTotalRow
          .Cells(r, tm.xlBCol).Style.Border.BorderAround(Style.ExcelBorderStyle.Thin)
          .Cells(r, tm.xlPCol).Formula = tm.xlPCell & glMain.xlSalesTotalRow & "-" & tm.xlPCell & glMain.xlCostTotalRow
          .Cells(r, tm.xlPCol).Style.Border.BorderAround(Style.ExcelBorderStyle.Thin)
          .Cells(r, tm.xlACol).Formula = tm.xlACell & glMain.xlSalesTotalRow & "-" & tm.xlACell & glMain.xlCostTotalRow
          .Cells(r, tm.xlACol).Style.Border.BorderAround(Style.ExcelBorderStyle.Thin)
        Else
          .Cells(r, tm.xlACol).Formula = tm.xlACell & glMain.xlSalesTotalRow & "-" & tm.xlACell & glMain.xlCostTotalRow
          .Cells(r, tm.xlACol).Style.Border.BorderAround(Style.ExcelBorderStyle.Thin)
        End If
      Next
      .Cells(r, 2, r, glMain.xlLastDataCol).Style.Font.Bold = True
      'Vertical Line Upto Gross margin row
      For i As Integer = 1 To glMain.xlLastDataCol
        .Cells(glMain.xlStartRow + 3, i, r, i).Style.Border.BorderAround(Style.ExcelBorderStyle.Thin)
      Next

    End With
    Return r
  End Function
  Public Shared Function CreateFile(ByVal FileName As String, ByVal ProjectGroupID As Int32, ByVal FinYear As Int32, ByVal Quarter As Int32, ByVal Revision As Int32) As String
    Dim glMain As csGLMain = csGLMain.getGLMain(ProjectGroupID, FinYear, Quarter, Revision)
    If glMain.ListGLGroups.Count <= 0 Then
      Throw New Exception("ERP-LN Data NOT Found")
    End If
    Dim FileInfo As IO.FileInfo = New IO.FileInfo(FileName)
    Dim xlPk As ExcelPackage = New ExcelPackage(FileInfo)
    'One Try Block from Here
    Dim xlWS As ExcelWorksheet = xlPk.Workbook.Worksheets("CS")


    Dim r As Integer = 6
    Dim c As Integer = 3
    With xlWS
      'Page Headings
      Dim oPG As SIS.COST.costProjectGroups = SIS.COST.costProjectGroups.costProjectGroupsGetByID(ProjectGroupID)
      .Cells(2, 3).Value = oPG.ProjectGroupDescription
      .Cells(2, 7).Value = oPG.ProjectTypeID
      .Cells(2, 8).Value = Now.ToString("dd/MM/yyyy")

      Dim oPGrP As List(Of SIS.COST.costProjectGroupProjects) = SIS.COST.costProjectGroupProjects.costProjectGroupProjectsSelectList(0, 999, "", False, "", ProjectGroupID)
      For Each xtmp As SIS.COST.costProjectGroupProjects In oPGrP
        .Cells(3, c).Value = xtmp.ProjectID
        .Cells(4, c).Value = SIS.COST.costQProjects.costQProjectsGetByID(xtmp.ProjectID, FinYear, Quarter).FK_COST_Projects_DivisionID.DivisionName
        c += 1
      Next
      'End Page Heading
      'Write Column Heading
      r = glMain.xlStartRow


      For Each htmp As csGLGroup.csYearAmount In glMain.ListGLGroups(0).ListYearAmounts
        If Not htmp.IsCurrent Then
          If htmp.IsYtd Then
            .Cells(r, htmp.xlACol).Value = "Total"
            .Cells(r + 1, htmp.xlACol).Value = "YTD"
          ElseIf htmp.IsLiability Then
            .Cells(r, htmp.xlACol).Value = "Provision"
          Else
            .Cells(r, htmp.xlACol).Value = "Total"
            .Cells(r + 1, htmp.xlACol).Value = "'" & htmp.FinYear
          End If
          .Cells(r, htmp.xlACol, r + 1, htmp.xlACol).Style.Font.Bold = True
          .Cells(r, htmp.xlACol, r + 1, htmp.xlACol).Style.HorizontalAlignment = HorizontalAlign.Center
          .Cells(r, htmp.xlACol, r + 1, htmp.xlACol).Style.Border.BorderAround(Style.ExcelBorderStyle.Medium)
        Else
          .Cells(r, htmp.xlBCol, r, htmp.xlACol).Merge = True
          .Cells(r, htmp.xlBCol).Value = "Quarter " & Quarter & " Year " & htmp.FinYear
          .Cells(r + 1, htmp.xlBCol).Value = "Before Provision"
          .Cells(r + 1, htmp.xlPCol).Value = "Provision"
          .Cells(r + 1, htmp.xlACol).Value = "After Provision"
          .Cells(r, htmp.xlBCol, r + 1, htmp.xlACol).Style.Font.Bold = True
          .Cells(r, htmp.xlBCol, r + 1, htmp.xlACol).Style.HorizontalAlignment = HorizontalAlign.Center
          .Cells(r, htmp.xlBCol, r, htmp.xlACol).Style.Border.BorderAround(Style.ExcelBorderStyle.Medium)
          .Cells(r + 1, htmp.xlBCol).Style.Border.BorderAround(Style.ExcelBorderStyle.Medium)
          .Cells(r + 1, htmp.xlPCol).Style.Border.BorderAround(Style.ExcelBorderStyle.Medium)
          .Cells(r + 1, htmp.xlACol).Style.Border.BorderAround(Style.ExcelBorderStyle.Medium)
        End If
      Next
      'Write Data
      Dim lNature As String = ""
      Dim idx As Integer = 0

      lNature = "SALES"
      r = glMain.xlSalesHeadingtRow
      .Cells(r, 1).Value = """A"""
      .Cells(r, 2).Value = "SALES"
      .Cells(r, 1, r, 2).Style.Font.Bold = True
      .Cells(r, 1, r, 2).Style.HorizontalAlignment = HorizontalAlign.Center

      Dim tmp As csGLGroup = Nothing
      For Each tmp In glMain.ListGLGroups
        If lNature <> tmp.glNatureDescription Then
          .Cells(glMain.xlSalesTotalRow, 2).Value = "Total of ""A"""
          'print Total
          For Each tmpAmt As csGLGroup.csYearAmount In tmp.ListYearAmounts
            r = glMain.xlSalesTotalRow
            If tmpAmt.IsCurrent Then
              .Cells(r, tmpAmt.xlACol).Formula = "sum(" & tmpAmt.xlACell & glMain.xlSalesHeadingtRow + 1 & ":" & tmpAmt.xlACell & glMain.xlSalesTotalRow - 1 & ")"
              .Cells(r, tmpAmt.xlPCol).Formula = "sum(" & tmpAmt.xlPCell & glMain.xlSalesHeadingtRow + 1 & ":" & tmpAmt.xlPCell & glMain.xlSalesTotalRow - 1 & ")"
              .Cells(r, tmpAmt.xlBCol).Formula = "sum(" & tmpAmt.xlBCell & glMain.xlSalesHeadingtRow + 1 & ":" & tmpAmt.xlBCell & glMain.xlSalesTotalRow - 1 & ")"
            Else
              .Cells(r, tmpAmt.xlACol).Formula = "sum(" & tmpAmt.xlACell & glMain.xlSalesHeadingtRow + 1 & ":" & tmpAmt.xlACell & glMain.xlSalesTotalRow - 1 & ")"
            End If
          Next
          .Cells(r, 2, r, glMain.xlLastDataCol - 1).Style.Font.Bold = True
          .Cells(r, 2, r, glMain.xlLastDataCol - 1).Style.HorizontalAlignment = HorizontalAlign.Center
          .Cells(r, 2, r, glMain.xlLastDataCol - 1).Style.Border.BorderAround(Style.ExcelBorderStyle.Thin)
          idx = 0
          lNature = "COST"
          r = glMain.xlCostHeadingRow
          .Cells(r, 1).Value = """B"""
          .Cells(r, 2).Value = "COST"
          .Cells(r, 1, r, 2).Style.Font.Bold = True
          .Cells(r, 1, r, 2).Style.HorizontalAlignment = HorizontalAlign.Center
        End If
        idx += 1
        .Cells(tmp.xlRow, 1).Value = idx
        .Cells(tmp.xlRow, 2).Value = tmp.glGroupDescription
        For Each tm As csGLGroup.csYearAmount In tmp.ListYearAmounts
          If tm.IsCurrent Then
            If tmp.glGroupID = "47" Then 'WARANTY
              .Cells(tmp.xlRow, tm.xlBCol).Value = tm.BeforeProvision * -1
              .Cells(tmp.xlRow, tm.xlPCol).Value = tm.Provision * -1
            Else
              .Cells(tmp.xlRow, tm.xlBCol).Value = tm.BeforeProvision * IIf(lNature = "SALES", -1, 1)
              .Cells(tmp.xlRow, tm.xlPCol).Value = tm.Provision * IIf(lNature = "COST", -1, 1)
            End If
            .Cells(tmp.xlRow, tm.xlACol).Formula = tm.xlBCell & tmp.xlRow & "+" & tm.xlPCell & tmp.xlRow
            'Formula in Next Blank Line
            .Cells(tmp.xlRow + 1, tm.xlACol).Formula = tm.xlBCell & (tmp.xlRow + 1) & "+" & tm.xlPCell & (tmp.xlRow + 1)
            .Cells(tmp.xlRow + 1, tm.xlACol).Style.Font.Color.SetColor(System.Drawing.Color.Red)
          Else
            If tmp.glGroupID = "47" Then
              .Cells(tmp.xlRow, tm.xlACol).Value = tm.AfterProvision * -1
              '.Cells(tmp.xlRow, tm.xlACol).Value = tm.glGroup.AfterProvisionForWaranty(tm.FinYear)
            Else
              .Cells(tmp.xlRow, tm.xlACol).Value = tm.AfterProvision * IIf(lNature = "SALES", -1, 1)
            End If
          End If
        Next
        'YTD Column
        .Cells(tmp.xlRow, tmp.objYTD.xlACol).Formula = tmp.YTDFormula
        'Total Liability Column
        .Cells(tmp.xlRow, tmp.objLiability.xlACol).Value = tmp.objLiability.AfterProvision * -1
        'Formula in Next Blank Line
        .Cells(tmp.xlRow + 1, tmp.objYTD.xlACol).Formula = tmp.YTDFormula.Replace(tmp.xlRow, tmp.xlRow + 1)
        .Cells(tmp.xlRow + 1, tmp.objYTD.xlACol).Style.Font.Color.SetColor(System.Drawing.Color.Red)
      Next
      'Print COST Total Row 
      r = glMain.xlCostTotalRow
      .Cells(r, 2).Value = "Total of ""B"""
      .Cells(r, 2).Style.HorizontalAlignment = HorizontalAlign.Center
      .Cells(r, 2).Style.Border.BorderAround(Style.ExcelBorderStyle.Thin)
      For Each tm As csGLGroup.csYearAmount In tmp.ListYearAmounts
        If tm.IsCurrent Then
          .Cells(r, tm.xlBCol).Formula = "sum(" & tm.xlBCell & glMain.xlCostHeadingRow + 1 & ":" & tm.xlBCell & r - 1 & ")"
          .Cells(r, tm.xlBCol).Style.Border.BorderAround(Style.ExcelBorderStyle.Thin)
          .Cells(r, tm.xlPCol).Formula = "sum(" & tm.xlPCell & glMain.xlCostHeadingRow + 1 & ":" & tm.xlPCell & r - 1 & ")"
          .Cells(r, tm.xlPCol).Style.Border.BorderAround(Style.ExcelBorderStyle.Thin)
          .Cells(r, tm.xlACol).Formula = "sum(" & tm.xlACell & glMain.xlCostHeadingRow + 1 & ":" & tm.xlACell & r - 1 & ")"
          .Cells(r, tm.xlACol).Style.Border.BorderAround(Style.ExcelBorderStyle.Thin)
        Else
          .Cells(r, tm.xlACol).Formula = "sum(" & tm.xlACell & glMain.xlCostHeadingRow + 1 & ":" & tm.xlACell & r - 1 & ")"
          .Cells(r, tm.xlACol).Style.Border.BorderAround(Style.ExcelBorderStyle.Thin)
        End If
      Next
      .Cells(r, 2, r, glMain.xlLastDataCol).Style.Font.Bold = True
      'Print Gross Margin Row
      r = glMain.xlGrossMarginRow
      .Cells(r, 1).Value = """C"""
      .Cells(r, 2).Value = "Gross Margin (A-B)"
      .Cells(r, 1, r, 2).Style.Font.Bold = True
      .Cells(r, 1, r, 2).Style.HorizontalAlignment = HorizontalAlign.Center
      .Cells(r, 2).Style.Border.BorderAround(Style.ExcelBorderStyle.Thin)
      For Each tm As csGLGroup.csYearAmount In tmp.ListYearAmounts
        If tm.IsLiability Then Continue For
        If tm.IsCurrent Then
          .Cells(r, tm.xlBCol).Formula = tm.xlBCell & glMain.xlSalesTotalRow & "-" & tm.xlBCell & glMain.xlCostTotalRow
          .Cells(r, tm.xlBCol).Style.Border.BorderAround(Style.ExcelBorderStyle.Thin)
          .Cells(r, tm.xlPCol).Formula = tm.xlPCell & glMain.xlSalesTotalRow & "-" & tm.xlPCell & glMain.xlCostTotalRow
          .Cells(r, tm.xlPCol).Style.Border.BorderAround(Style.ExcelBorderStyle.Thin)
          .Cells(r, tm.xlACol).Formula = tm.xlACell & glMain.xlSalesTotalRow & "-" & tm.xlACell & glMain.xlCostTotalRow
          .Cells(r, tm.xlACol).Style.Border.BorderAround(Style.ExcelBorderStyle.Thin)
        Else
          .Cells(r, tm.xlACol).Formula = tm.xlACell & glMain.xlSalesTotalRow & "-" & tm.xlACell & glMain.xlCostTotalRow
          .Cells(r, tm.xlACol).Style.Border.BorderAround(Style.ExcelBorderStyle.Thin)
        End If
      Next
      .Cells(r, 2, r, glMain.xlLastDataCol).Style.Font.Bold = True
      'Vertical Line Upto Gross margin row
      For i As Integer = 1 To glMain.xlLastDataCol
        .Cells(glMain.xlStartRow + 3, i, r, i).Style.Border.BorderAround(Style.ExcelBorderStyle.Thin)
      Next
      'Print Cost Table
      Dim r_ct As Integer = glMain.xlGrossMarginRow + 2
      Dim c_ct As Integer = glMain.xlStartDataCol - 1
      'Immediate Last Year
      Dim LastYear As Integer = FinYear - 1
      Dim bkdTot As Decimal = 0
      Dim exITot As Decimal = 0
      Dim bkdTotc As Decimal = 0
      Dim exITotc As Decimal = 0
      Dim bkdYTD As Decimal = 0
      Dim bkdTotFC As Decimal = 0
      Dim bkdTotcFC As Decimal = 0
      Dim bkdYTDFC As Decimal = 0
      Dim ordVal As Decimal = 0
      Dim avgCon As Decimal = 0
      Dim bkdBillFC As Decimal = 0
      Dim bkdBill As Decimal = 0
      Dim prRevn As Decimal = 0
      Dim marPr As Decimal = 0
      Dim marLYr As Decimal = 0
      Dim bkdBal As Decimal = 0
      Dim marBal As Decimal = 0
      Dim bkdMarc As Decimal = 0
      Dim expIPI As Decimal = 0
      Dim expIBal As Decimal = 0
      Dim expToBkd As Decimal = 0
      Dim marCalc As Decimal = 0
      Dim toAdj As Decimal = 0
      Dim gMarLyr As Decimal = 0
      Dim gMarCyr As Decimal = 0

      Dim oPI As SIS.COST.costProjectsInput = SIS.COST.costProjectsInput.costProjectsInputGetByID(ProjectGroupID, FinYear, Quarter)
      For Each tmpPr As SIS.COST.costProjectGroupProjects In oPGrP
        ordVal += SIS.COST.costQProjects.costQProjectsGetByID(tmpPr.ProjectID, FinYear, Quarter).ProjectOrderValue
        avgCon += SIS.COST.costQProjects.costQProjectsGetByID(tmpPr.ProjectID, FinYear, Quarter).CFforPOV
      Next
      Try
        avgCon = avgCon / oPGrP.Count
      Catch ex As Exception
        avgCon = 1
      End Try
      For Each tmpGL As csGLGroup In glMain.ListGLGroups
        If tmpGL.glNatureID = 2 Then
          Select Case tmpGL.glGroupID
            Case 28, 33, 35, 51, 53, 55  'Erection sales:, Material:, Service Charges:, Unbilled Revenue,Composit Supply of Works Contr, Export Sale-Forex Fluct. -ADV
              For Each tmpYr As csGLGroup.csYearAmount In tmpGL.ListYearAmounts
                If tmpYr.FinYear <= LastYear Then
                  bkdTot += (tmpYr.AfterProvision * 1)
                  bkdTotFC += (tmpYr.AfterProvisionFC * 1)
                ElseIf tmpYr.FinYear = FinYear Then
                  bkdTotc += (tmpYr.AfterProvision * 1)
                  bkdTotcFC += (tmpYr.AfterProvisionFC * 1)
                End If
              Next
            Case 30 'Export Incentive:
              For Each tmpYr As csGLGroup.csYearAmount In tmpGL.ListYearAmounts
                If tmpYr.FinYear <= LastYear Then
                  exITot += (tmpYr.AfterProvision * -1)
                ElseIf tmpYr.FinYear = FinYear Then
                  exITotc += (tmpYr.AfterProvision * -1)
                End If
              Next
          End Select
        End If
      Next
      '===============================
      bkdTot = Math.Round(bkdTot / 100000, 2)
      bkdTotc = Math.Round(bkdTotc / 100000, 2)
      exITot = Math.Round(exITot / 100000, 2)
      exITotc = Math.Round(exITotc / 100000, 2)
      oPI.ProjectMarginByACINR = Math.Round(oPI.ProjectMarginByACINR / 100000, 2)
      oPI.ExportIncentiveByACINR = Math.Round(oPI.ExportIncentiveByACINR / 100000, 2)
      gMarLyr = Math.Round(glMain.GrossMarginLastYear / 100000, 2)
      gMarCyr = Math.Round(glMain.GrossMarginCurrentYear / 100000, 2)
      '===============================
      expIPI = oPI.ExportIncentiveByACINR
      bkdYTD = bkdTot + bkdTotc
      bkdYTDFC = bkdTotFC + bkdTotcFC

      bkdBillFC = ordVal - (bkdYTDFC * -1)

      bkdBill = Math.Round(bkdBillFC * avgCon / 100000, 2)
      '==============
      Dim bkdYTDFCinINR As Decimal = Math.Round(bkdYTDFC * avgCon / 100000, 2)
      Dim TotalBooked As Decimal = (bkdYTD + bkdYTDFCinINR) * -1
      Dim OrderValueInINR As Decimal = Math.Round(ordVal * avgCon / 100000, 2)
      '==============
      If oPG.ProjectTypeID = "DOMESTIC" Then
        prRevn = OrderValueInINR
      Else
        prRevn = (bkdYTD * -1) + bkdBill
      End If
      '==============


      marPr = oPI.ProjectMarginByACINR - oPI.ExportIncentiveByACINR

      marLYr = gMarLyr - exITot

      bkdBal = prRevn - (bkdTot * -1)
      marBal = marPr - marLYr
      '1. First Formula for Margin Current Year
      Try
        If bkdBal = 0 And bkdTotc = 0 Then
          bkdMarc = marBal
        Else
          bkdMarc = (bkdTotc * -1) * marBal / bkdBal
        End If
      Catch ex As Exception
        bkdMarc = 0
      End Try
      '2. Second Formula 
      If marBal < 0 Then
        bkdMarc = marBal
      End If
      '3. Third Formula
      'Margin Current Year: Changed on 01-04-2017 as required by Anuj
      If glMain.GroupMarginCurrentYearINR <> 0 Then
        bkdMarc = Math.Round(glMain.GroupMarginCurrentYearINR / 100000, 2) - exITotc
      End If
      '-----------------------


      expIBal = expIPI - exITot
      expToBkd = expIBal - exITotc

      marCalc = bkdMarc + exITotc

      toAdj = gMarCyr - marCalc

      .Cells(r_ct, c_ct, r_ct, c_ct + 5).Style.Font.Bold = True
      .Cells(r_ct, c_ct, r_ct + 4, c_ct).Style.Font.Bold = True
      .Cells(r_ct, c_ct, r_ct + 4, c_ct + 5).Style.Border.BorderAround(Style.ExcelBorderStyle.Medium)
      .Cells(r_ct + 1, c_ct + 1, r_ct + 4, c_ct + 5).Style.HorizontalAlignment = HorizontalAlign.Center


      'write table
      .Cells(r_ct, c_ct + 1).Value = "Total"
      .Cells(r_ct, c_ct + 2).Value = "Bkd. upto F " & LastYear
      .Cells(r_ct, c_ct + 3).Value = "Bal. on Apr'" & LastYear
      .Cells(r_ct, c_ct + 4).Value = "Bkd. F " & FinYear
      .Cells(r_ct, c_ct + 5).Value = "Yet to Book"
      .Cells(r_ct + 1, c_ct).Value = "Sales"
      .Cells(r_ct + 2, c_ct).Value = "Margin"
      .Cells(r_ct + 3, c_ct).Value = "Export Incentive"
      .Cells(r_ct + 4, c_ct).Value = "Total"

      Try
        Dim tmpToAdd As Decimal = 0
        If expToBkd < 0 Then
          tmpToAdd = expToBkd * -1
        End If
        .Cells(r_ct + 1, c_ct + 1).Value = prRevn
        .Cells(r_ct + 2, c_ct + 1).Formula = marPr & "-" & tmpToAdd
        .Cells(r_ct + 3, c_ct + 1).Formula = expIPI & "+" & tmpToAdd
        .Cells(r_ct + 4, c_ct + 1).Formula = Chr(c_ct + 1 + 64) & r_ct + 2 & "+" & Chr(c_ct + 1 + 64) & r_ct + 3

        .Cells(r_ct + 1, c_ct + 2).Value = (-1 * bkdTot)
        .Cells(r_ct + 2, c_ct + 2).Value = marLYr
        .Cells(r_ct + 3, c_ct + 2).Value = exITot
        .Cells(r_ct + 4, c_ct + 2).Value = gMarLyr

        .Cells(r_ct + 1, c_ct + 3).Formula = Chr(c_ct + 1 + 64) & r_ct + 1 & "-" & Chr(c_ct + 2 + 64) & r_ct + 1
        .Cells(r_ct + 2, c_ct + 3).Formula = Chr(c_ct + 1 + 64) & r_ct + 2 & "-" & Chr(c_ct + 2 + 64) & r_ct + 2
        .Cells(r_ct + 3, c_ct + 3).Formula = Chr(c_ct + 1 + 64) & r_ct + 3 & "-" & Chr(c_ct + 2 + 64) & r_ct + 3
        .Cells(r_ct + 4, c_ct + 3).Formula = Chr(c_ct + 1 + 64) & r_ct + 4 & "-" & Chr(c_ct + 2 + 64) & r_ct + 4


        .Cells(r_ct + 1, c_ct + 4).Value = -1 * bkdTotc
        .Cells(r_ct + 2, c_ct + 4).Value = bkdMarc
        .Cells(r_ct + 3, c_ct + 4).Value = exITotc
        .Cells(r_ct + 4, c_ct + 4).Formula = Chr(c_ct + 4 + 64) & r_ct + 2 & "+" & Chr(c_ct + 4 + 64) & r_ct + 3


        .Cells(r_ct + 1, c_ct + 1, r_ct + 4, c_ct + 4).Style.HorizontalAlignment = HorizontalAlign.Center

        '===============Adjustment====================
        .Cells(r_ct + 5, c_ct + 4).Value = toAdj
        .Cells(r_ct + 5, c_ct + 4).Style.HorizontalAlignment = HorizontalAlign.Center
        .Cells(r_ct + 5, c_ct + 4).Style.Font.Bold = True
        .Cells(r_ct + 5, c_ct + 4).Style.Border.BorderAround(Style.ExcelBorderStyle.Medium)
        .Cells(r_ct + 5, c_ct + 4).Style.Font.Bold = True
        .Cells(r_ct + 5, c_ct + 4).Style.Fill.PatternType = Style.ExcelFillStyle.Solid
        .Cells(r_ct + 5, c_ct + 4).Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.Coral)



        .Cells(r_ct + 1, c_ct + 5).Formula = Chr(c_ct + 3 + 64) & r_ct + 1 & "-" & Chr(c_ct + 4 + 64) & r_ct + 1
        .Cells(r_ct + 2, c_ct + 5).Formula = Chr(c_ct + 3 + 64) & r_ct + 2 & "-" & Chr(c_ct + 4 + 64) & r_ct + 2
        .Cells(r_ct + 3, c_ct + 5).Formula = Chr(c_ct + 3 + 64) & r_ct + 3 & "-" & Chr(c_ct + 4 + 64) & r_ct + 3
        .Cells(r_ct + 4, c_ct + 5).Formula = Chr(c_ct + 3 + 64) & r_ct + 4 & "-" & Chr(c_ct + 4 + 64) & r_ct + 4

        Dim tmpR As Integer = 7
        .Cells(r_ct + tmpR, c_ct + 0, r_ct + tmpR, c_ct + 4).Merge = True
        .Cells(r_ct + tmpR, c_ct + 0).Value = "Adjustment Entries"
        .Cells(r_ct + tmpR, c_ct + 0, r_ct + tmpR, c_ct + 4).Style.Font.Bold = True
        .Cells(r_ct + tmpR, c_ct + 0, r_ct + tmpR, c_ct + 4).Style.Border.BorderAround(Style.ExcelBorderStyle.Medium)
        .Cells(r_ct + tmpR, c_ct + 0, r_ct + tmpR, c_ct + 4).Style.Fill.PatternType = Style.ExcelFillStyle.Solid
        .Cells(r_ct + tmpR, c_ct + 0, r_ct + tmpR, c_ct + 4).Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.Gold)
        tmpR += 1
        Dim oAEs As List(Of SIS.COST.costAdjustmentEntry) = SIS.COST.costAdjustmentEntry.UZ_costAdjustmentEntrySelectList(0, 99999, "", False, "", FinYear, ProjectGroupID, Revision, Quarter)
        If oAEs.Count > 0 Then
          .Cells(r_ct + tmpR, c_ct + 0).Value = "Remarks"
          .Cells(r_ct + tmpR, c_ct + 1).Value = "DR GL Code"
          .Cells(r_ct + tmpR, c_ct + 2).Value = "CR GL Code"
          .Cells(r_ct + tmpR, c_ct + 3).Value = "Amount"
          .Cells(r_ct + tmpR, c_ct + 4).Value = "Active"
          .Cells(r_ct + tmpR, c_ct + 0, r_ct + tmpR, c_ct + 4).Style.Font.Bold = True
          .Cells(r_ct + tmpR, c_ct + 0, r_ct + tmpR, c_ct + 4).Style.Border.BorderAround(Style.ExcelBorderStyle.Thin)
          tmpR += 1
        End If
        For Each tmpAE As SIS.COST.costAdjustmentEntry In oAEs
          .Cells(r_ct + tmpR, c_ct + 0).Value = tmpAE.Remarks
          .Cells(r_ct + tmpR, c_ct + 1).Value = tmpAE.DrGLCode & "-" & tmpAE.FK_COST_AdjustmentEntry_DrGLCode.GLDescription
          .Cells(r_ct + tmpR, c_ct + 2).Value = tmpAE.CrGLCode & "-" & tmpAE.FK_COST_AdjustmentEntry_CrGLCode.GLDescription
          .Cells(r_ct + tmpR, c_ct + 3).Value = tmpAE.Amount
          .Cells(r_ct + tmpR, c_ct + 4).Value = tmpAE.Active
          .Cells(r_ct + tmpR, c_ct + 0, r_ct + tmpR, c_ct + 4).Style.Border.BorderAround(Style.ExcelBorderStyle.Thin)
          tmpR += 1
        Next

        tmpR += 5
        'Row for Calculation Of Order Value Table
        Dim r_ov As Integer = r_ct + tmpR
        Dim c_ov As Integer = c_ct + 3
        '------------------------------
        .Cells(r_ct + tmpR, c_ct + 0).Value = "Booked Last Year"
        .Cells(r_ct + tmpR, c_ct + 1).Value = bkdTot
        tmpR += 1
        .Cells(r_ct + tmpR, c_ct + 0).Value = "Booked Curr Year"
        .Cells(r_ct + tmpR, c_ct + 1).Value = bkdTotc
        tmpR += 1
        .Cells(r_ct + tmpR, c_ct + 0).Value = "Booked YTD"
        .Cells(r_ct + tmpR, c_ct + 1).Value = bkdYTD
        tmpR += 1
        .Cells(r_ct + tmpR, c_ct + 0).Value = "Booked Last Year FC"
        .Cells(r_ct + tmpR, c_ct + 1).Value = bkdTotFC
        tmpR += 1
        .Cells(r_ct + tmpR, c_ct + 0).Value = "Booked Curr Year FC"
        .Cells(r_ct + tmpR, c_ct + 1).Value = bkdTotcFC
        tmpR += 1
        .Cells(r_ct + tmpR, c_ct + 0).Value = "Booked YTD FC"
        .Cells(r_ct + tmpR, c_ct + 1).Value = bkdYTDFC
        tmpR += 1
        .Cells(r_ct + tmpR, c_ct + 0).Value = "Order Val FC"
        .Cells(r_ct + tmpR, c_ct + 1).Value = ordVal
        tmpR += 1
        .Cells(r_ct + tmpR, c_ct + 0).Value = "Avg. Conversion Factor"
        .Cells(r_ct + tmpR, c_ct + 1).Value = avgCon
        tmpR += 1
        .Cells(r_ct + tmpR, c_ct + 0).Value = "Booked to Bill FC"
        .Cells(r_ct + tmpR, c_ct + 1).Value = bkdBillFC
        tmpR += 1
        .Cells(r_ct + tmpR, c_ct + 0).Value = "Booked to Bill INR"
        .Cells(r_ct + tmpR, c_ct + 1).Value = bkdBill
        tmpR += 1
        .Cells(r_ct + tmpR, c_ct + 0).Value = "Project Revenue INR"
        .Cells(r_ct + tmpR, c_ct + 1).Value = prRevn
        tmpR += 1
        .Cells(r_ct + tmpR, c_ct + 0).Value = "Margin Project INR"
        .Cells(r_ct + tmpR, c_ct + 1).Value = marPr
        tmpR += 1
        .Cells(r_ct + tmpR, c_ct + 0).Value = "Margin Last Year INR"
        .Cells(r_ct + tmpR, c_ct + 1).Value = marLYr
        tmpR += 1
        .Cells(r_ct + tmpR, c_ct + 0).Value = "Booked Balance INR"
        .Cells(r_ct + tmpR, c_ct + 1).Value = bkdBal
        tmpR += 1
        .Cells(r_ct + tmpR, c_ct + 0).Value = "Margin Balance INR"
        .Cells(r_ct + tmpR, c_ct + 1).Value = marBal
        tmpR += 1
        .Cells(r_ct + tmpR, c_ct + 0).Value = "Booked Margin Current Year"
        .Cells(r_ct + tmpR, c_ct + 1).Value = bkdMarc
        tmpR += 1
        .Cells(r_ct + tmpR, c_ct + 0).Value = "Export Incentive Project Input"
        .Cells(r_ct + tmpR, c_ct + 1).Value = expIPI
        tmpR += 1
        .Cells(r_ct + tmpR, c_ct + 0).Value = "Export Incentive Last Year"
        .Cells(r_ct + tmpR, c_ct + 1).Value = exITot
        tmpR += 1
        .Cells(r_ct + tmpR, c_ct + 0).Value = "Balance Export Inventive"
        .Cells(r_ct + tmpR, c_ct + 1).Value = expIBal
        tmpR += 1
        .Cells(r_ct + tmpR, c_ct + 0).Value = "Export Incentive Current Year"
        .Cells(r_ct + tmpR, c_ct + 1).Value = exITotc
        tmpR += 1
        .Cells(r_ct + tmpR, c_ct + 0).Value = "Export Incentive To Be Booked"
        .Cells(r_ct + tmpR, c_ct + 1).Value = expToBkd
        tmpR += 1
        'Print Calculation of Order Value Table
        '======================================
        If oPG.ProjectTypeID <> "DOMESTIC" Then
          Try
            Dim tmp_supplyToBill As Decimal = 0
            Dim tmp_serviceToBill As Decimal = 0
            Dim tmp_supplyToBillFC As Decimal = 0
            Dim tmp_serviceToBillFC As Decimal = 0
            For Each z As SIS.COST.costProjectGroupProjects In oPGrP
              Select Case SIS.COST.costQProjects.costQProjectsGetByID(z.ProjectID, FinYear, Quarter).WorkOrderTypeID
                Case 2, 3
                  tmp_serviceToBill += SIS.COST.costQProjects.costQProjectsGetByID(z.ProjectID, FinYear, Quarter).ProjectOrderValueINR
                  tmp_serviceToBillFC += SIS.COST.costQProjects.costQProjectsGetByID(z.ProjectID, FinYear, Quarter).ProjectOrderValue
                Case Else
                  tmp_supplyToBill += SIS.COST.costQProjects.costQProjectsGetByID(z.ProjectID, FinYear, Quarter).ProjectOrderValueINR
                  tmp_supplyToBillFC += SIS.COST.costQProjects.costQProjectsGetByID(z.ProjectID, FinYear, Quarter).ProjectOrderValue
              End Select
            Next
            Dim tmp_supplyBilledYTDFC As Decimal = 0
            Dim tmp_supplyBilledYTD As Decimal = 0
            Dim tmp_supglMain As csGLMain = csGLMain.getGLMain(ProjectGroupID, FinYear, Quarter, Revision, False, True)
            For Each tmpGL As csGLGroup In tmp_supglMain.ListGLGroups
              If tmpGL.glNatureID = 2 Then
                Select Case tmpGL.glGroupID
                  Case 33  'Material:
                    For Each tmpYr As csGLGroup.csYearAmount In tmpGL.ListYearAmounts
                      tmp_supplyBilledYTDFC += (tmpYr.AfterProvisionFC * 1)
                      tmp_supplyBilledYTD += (tmpYr.AfterProvision * 1)
                    Next
                End Select
              End If
            Next
            Dim tmp_tmp As Decimal = 0
            tmp_supplyBilledYTDFC *= -1
            tmp_supplyBilledYTD *= -1

            .Cells(r_ov + 0, c_ov + 0).Value = "Calculation of order value in FC"
            .Cells(r_ov + 1, c_ov + 1).Value = "USD"
            .Cells(r_ov + 1, c_ov + 2).Value = "INR"

            Try
              tmp_tmp = Math.Round(tmp_supplyBilledYTD / tmp_supplyBilledYTDFC, 2)
            Catch ex As Exception
            End Try
            .Cells(r_ov + 2, c_ov + 0).Value = "Supply-billed"
            .Cells(r_ov + 2, c_ov + 1).Value = tmp_supplyBilledYTDFC
            .Cells(r_ov + 2, c_ov + 2).Value = tmp_supplyBilledYTD
            .Cells(r_ov + 2, c_ov + 3).Value = tmp_tmp

            .Cells(r_ov + 3, c_ov + 0).Value = "Supply-To bill"
            .Cells(r_ov + 3, c_ov + 1).Formula = "+" & tmp_supplyToBillFC & "-" & Chr(c_ov + 1 + 64) & r_ov + 2
            .Cells(r_ov + 3, c_ov + 2).Formula = "+" & Chr(c_ov + 1 + 64) & r_ov + 3 & "*" & Chr(c_ov + 3 + 64) & r_ov + 3
            .Cells(r_ov + 3, c_ov + 3).Value = avgCon
            'Blank Row
            .Cells(r_ov + 5, c_ov + 0).Value = "Service chgs-billed"
            .Cells(r_ov + 5, c_ov + 1).Formula = "+" & bkdYTDFC * -1 & "-" & Chr(c_ov + 1 + 64) & r_ov + 2
            Try
              .Cells(r_ov + 5, c_ov + 2).Formula = "+" & glMain.getGLGroupByID(35).YTDFormula '35=>Service Charges
            Catch ex As Exception
              .Cells(r_ov + 5, c_ov + 2).Value = 0
            End Try
            Try
              .Cells(r_ov + 5, c_ov + 3).Formula = "+" & Chr(c_ov + 2 + 64) & r_ov + 5 & "/" & Chr(c_ov + 1 + 64) & r_ov + 5
            Catch ex As Exception
              .Cells(r_ov + 5, c_ov + 3).Value = 0
            End Try
            .Cells(r_ov + 6, c_ov + 0).Value = "Service chgs-To bill"
            .Cells(r_ov + 6, c_ov + 1).Formula = "+" & tmp_serviceToBillFC & "-" & Chr(c_ov + 1 + 64) & r_ov + 5
            .Cells(r_ov + 6, c_ov + 2).Formula = "+" & Chr(c_ov + 1 + 64) & r_ov + 6 & "*" & Chr(c_ov + 3 + 64) & r_ov + 6
            .Cells(r_ov + 6, c_ov + 3).Value = avgCon

            .Cells(r_ov + 7, c_ov + 0).Value = "Subtotal"
            .Cells(r_ov + 7, c_ov + 1).Formula = "SUM(" & Chr(c_ov + 1 + 64) & r_ov + 1 & ":" & Chr(c_ov + 1 + 64) & r_ov + 6 & ")"
            .Cells(r_ov + 7, c_ov + 2).Formula = "SUM(" & Chr(c_ov + 2 + 64) & r_ov + 1 & ":" & Chr(c_ov + 2 + 64) & r_ov + 6 & ")"
            Try
              .Cells(r_ov + 7, c_ov + 3).Formula = "+" & Chr(c_ov + 2 + 64) & r_ov + 7 & "/" & Chr(c_ov + 1 + 64) & r_ov + 7
            Catch ex As Exception
              .Cells(r_ov + 7, c_ov + 3).Value = 0
            End Try
            .Cells(r_ov + 8, c_ov + 0).Value = "Forex Variance"
            Try
              .Cells(r_ov + 8, c_ov + 2).Formula = "-1 * (" & glMain.getGLGroupByID(7).YTDFormula & ")" '7=>Forex Fluctuation
            Catch ex As Exception
            End Try
            .Cells(r_ov + 9, c_ov + 1).Formula = "SUM(" & Chr(c_ov + 1 + 64) & r_ov + 7 & ":" & Chr(c_ov + 1 + 64) & r_ov + 8 & ")"
            .Cells(r_ov + 9, c_ov + 2).Formula = "SUM(" & Chr(c_ov + 2 + 64) & r_ov + 7 & ":" & Chr(c_ov + 2 + 64) & r_ov + 8 & ")"
            Try
              .Cells(r_ov + 10, c_ov + 2).Formula = "+" & Chr(c_ov + 2 + 64) & r_ov + 9 & "/" & Chr(c_ov + 1 + 64) & r_ov + 9
            Catch ex As Exception
              .Cells(r_ov + 10, c_ov + 2).Value = 0
            End Try
            Try
              .Cells(r_ov + 11, c_ov + 2).Formula = "+" & prRevn & "-(" & Chr(c_ov + 2 + 64) & r_ov + 7 & "/100000)"
            Catch ex As Exception
              .Cells(r_ov + 11, c_ov + 2).Value = 0
            End Try
          Catch ex As Exception
          End Try
          .Cells(r_ov + 0, c_ov + 0).Style.Font.Bold = True
          .Cells(r_ov + 1, c_ov + 1, r_ov + 1, c_ov + 2).Style.Font.Bold = True
          .Cells(r_ov + 0, c_ov + 0).Style.Font.UnderLine = True
          .Cells(r_ov + 0, c_ov + 0, r_ov + 11, c_ov + 3).Style.Border.BorderAround(Style.ExcelBorderStyle.Medium)
          .Cells(r_ov + 0, c_ov + 0, r_ov + 11, c_ov + 3).Style.Fill.PatternType = Style.ExcelFillStyle.Solid
          .Cells(r_ov + 0, c_ov + 0, r_ov + 11, c_ov + 3).Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.Lime)

          .Cells(r_ov + 7, c_ov + 1, r_ov + 7, c_ov + 2).Style.Border.BorderAround(Style.ExcelBorderStyle.Thin)
          .Cells(r_ov + 9, c_ov + 1, r_ov + 9, c_ov + 2).Style.Border.BorderAround(Style.ExcelBorderStyle.Thin)

        End If



        '===============End Order Value Table===================


        'Erection & Commissioning Table
        'Get GLMail For Erection Projects Only
        Dim ecGlMain As csGLMain = csGLMain.getGLMain(ProjectGroupID, FinYear, Quarter, Revision, True)
        tmpR += 2

        .Cells(tmpR + r_ct, 2).Value = "Project Group:"
        .Cells(tmpR + r_ct, 3).Value = oPG.ProjectGroupDescription
        .Cells(tmpR + r_ct, 7).Value = oPG.ProjectTypeID
        .Cells(tmpR + r_ct, 8).Value = Now.ToString("dd/MM/yyyy")

        .Cells(tmpR + 1 + r_ct, 2).Value = "Project List:"
        .Cells(tmpR + 2 + r_ct, 1).Value = "Delails of Erection Sale & Cost"
        c = 3
        For Each xtmp As SIS.COST.costProjectGroupProjects In oPGrP
          .Cells(tmpR + 1 + r_ct, c).Value = xtmp.ProjectID
          c += 1
        Next

        .Cells(tmpR + r_ct, 1, tmpR + 2 + r_ct, 8).Style.Font.Bold = True
        .Cells(tmpR + 2 + r_ct, 1).Style.Font.UnderLine = True
        .Cells(tmpR + 2 + r_ct, 1).Style.HorizontalAlignment = Style.ExcelHorizontalAlignment.Left
        tmpR += 3

        tmpR = RenderMainTable(xlWS, ecGlMain, r_ct + tmpR)

        tmpR += 2

        Dim ErectionSale As String = "0"
        Dim ErectionCost As String = "0"
        Dim ErectionSaleVal As Decimal = 0
        Dim ErectionCostVal As Decimal = 0

        For Each tmpGL As csGLGroup In ecGlMain.ListGLGroups
          For Each tmpYr As csGLGroup.csYearAmount In tmpGL.ListYearAmounts
            If tmpYr.IsYtd Then
              If tmpGL.glNatureID = 1 Then 'COST
                Select Case tmpGL.glGroupID
                  '5-Civil & Erection Cost,10-Hiring Charges,17-Power and Fuel
                  'Material cost, Excise Duty,Sales Tax, Service Tax,Freight, Service Charges
                  Case "5", "6", "8", "10", "13", "17", "20", "22", "23"
                    If ErectionCost = "" Then
                      ErectionCost = tmpYr.glGroup.YTDFormula
                    Else
                      ErectionCost &= "+" & tmpYr.glGroup.YTDFormula
                    End If
                    ErectionCostVal += tmpYr.glGroup.YTDValue
                End Select
              ElseIf tmpGL.glNatureID = 2 Then 'SALE
                Select Case tmpGL.glGroupID
                  Case "28", "35" 'Erection sale, Service Charges
                    If ErectionSale = "" Then
                      ErectionSale = tmpYr.glGroup.YTDFormula
                    Else
                      ErectionSale &= "+" & tmpYr.glGroup.YTDFormula
                    End If
                    ErectionSaleVal += tmpYr.glGroup.YTDValue
                End Select
              End If
            End If
          Next
        Next
        'Total Sale=Sum of Order Value of 2 & 3 WorkOrder Type Project
        'Total Cost=Sum of Cost of 2 & 3 WorkOrder Type Project
        Dim TotalSale As Decimal = 0
        Dim TotalCost As Decimal = 0
        For Each z As SIS.COST.costProjectGroupProjects In oPGrP
          Select Case SIS.COST.costQProjects.costQProjectsGetByID(z.ProjectID, FinYear, Quarter).WorkOrderTypeID
            Case 2, 3
              TotalSale += SIS.COST.costQProjects.costQProjectsGetByID(z.ProjectID, FinYear, Quarter).ProjectOrderValueINR
              TotalCost += SIS.COST.costQProjects.costQProjectsGetByID(z.ProjectID, FinYear, Quarter).ProjectCostINR
          End Select
        Next
        r_ct = 0

        .Cells(r_ct + tmpR, c_ct + 0, r_ct + tmpR + 10, c_ct + 1).Style.Border.BorderAround(Style.ExcelBorderStyle.Medium)
        .Cells(r_ct + tmpR, c_ct + 0, r_ct + tmpR + 10, c_ct + 1).Style.Fill.PatternType = Style.ExcelFillStyle.Solid
        .Cells(r_ct + tmpR, c_ct + 0, r_ct + tmpR + 10, c_ct + 1).Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.Gold)
        .Cells(r_ct + tmpR, c_ct + 0).Value = "E&C"
        tmpR += 2
        .Cells(r_ct + tmpR, c_ct + 0).Value = "Total Sale(B)"
        .Cells(r_ct + tmpR, c_ct + 1).Value = Math.Round(TotalSale / 100000, 2)
        tmpR += 1
        .Cells(r_ct + tmpR, c_ct + 0).Value = "Total Cost"
        .Cells(r_ct + tmpR, c_ct + 1).Value = Math.Round(TotalCost / 100000, 2)
        tmpR += 1
        .Cells(r_ct + tmpR, c_ct + 0).Value = "Ratio"
        .Cells(r_ct + tmpR, c_ct + 1).Formula = Chr(c_ct + 1 + 64) & r_ct + tmpR - 1 & "/" & Chr(c_ct + 1 + 64) & r_ct + tmpR - 2
        tmpR += 2
        .Cells(r_ct + tmpR, c_ct + 0).Value = "Act. Sale"
        '.Cells(r_ct + tmpR, c_ct + 1).Formula = Math.Round(-1 * ErectionSaleVal / 100000, 2)   '"(" & ErectionSale & " /100000)"  '
        .Cells(r_ct + tmpR, c_ct + 1).Formula = "((" & ErectionSale & ")/100000)"  '
        tmpR += 1
        .Cells(r_ct + tmpR, c_ct + 0).Value = "Prop. Cost"
        .Cells(r_ct + tmpR, c_ct + 1).Formula = Chr(c_ct + 1 + 64) & r_ct + tmpR - 1 & "*" & Chr(c_ct + 1 + 64) & r_ct + tmpR - 3
        tmpR += 1
        .Cells(r_ct + tmpR, c_ct + 0).Value = "Act. Cost"
        '.Cells(r_ct + tmpR, c_ct + 1).Formula = Math.Round(ErectionCostVal / 100000, 2) '"(" & ErectionCost & "/100000)" '
        .Cells(r_ct + tmpR, c_ct + 1).Formula = "((" & ErectionCost & ")/100000)"
        tmpR += 1
        'Prop. Cost - Actual cost
        .Cells(r_ct + tmpR, c_ct + 0).Value = "Short/Exc(-)"
        .Cells(r_ct + tmpR, c_ct + 1).Formula = Chr(c_ct + 1 + 64) & r_ct + tmpR - 2 & "-" & Chr(c_ct + 1 + 64) & r_ct + tmpR - 1
        tmpR += 1


        'Store Provision To be adjusted in Remarks
        Dim oCS As SIS.COST.costCostSheet = SIS.COST.costCostSheet.costCostSheetGetByID(ProjectGroupID, FinYear, Quarter, Revision)
        oCS.Remarks = (toAdj * 100000)
        SIS.COST.costCostSheet.UpdateData(oCS)

      Catch ex As Exception
        .Cells(r_ct + 5, c_ct).Value = ex.Message
      End Try



    End With


    xlPk.Save()
    xlPk.Dispose()
    Return FileName
  End Function

#Region "IDisposable Support"
  Private disposedValue As Boolean ' To detect redundant calls

  ' IDisposable
  Protected Overridable Sub Dispose(disposing As Boolean)
    If Not disposedValue Then
      If disposing Then
        ' TODO: dispose managed state (managed objects).
        ListGLGroups = Nothing
      End If

      ' TODO: free unmanaged resources (unmanaged objects) and override Finalize() below.
      ' TODO: set large fields to null.
    End If
    disposedValue = True
  End Sub

  ' TODO: override Finalize() only if Dispose(disposing As Boolean) above has code to free unmanaged resources.
  'Protected Overrides Sub Finalize()
  '    ' Do not change this code.  Put cleanup code in Dispose(disposing As Boolean) above.
  '    Dispose(False)
  '    MyBase.Finalize()
  'End Sub

  ' This code added by Visual Basic to correctly implement the disposable pattern.
  Public Sub Dispose() Implements IDisposable.Dispose
    ' Do not change this code.  Put cleanup code in Dispose(disposing As Boolean) above.
    Dispose(True)
    ' TODO: uncomment the following line if Finalize() is overridden above.
    ' GC.SuppressFinalize(Me)
  End Sub
#End Region

End Class

#Region "  OLD CODE  "
Public Class prCostSheet
  Public Property prSeq As Integer = 0
  Public Property glGrNature As String = ""
  Public Property glGroupID As String = ""
  Public Property glGrDescription As String = ""
  Public Property LowestYear As String = ""
  Public Property TotLiability As Decimal = 0
  Public Property prCSData As List(Of prCostSheetData) = New List(Of prCostSheetData)
  Private _ytdAmount As Decimal = 0
  Public ReadOnly Property ytdAmount As Decimal
    Get
      If _ytdAmount = 0 Then
        For Each tmp As prCostSheetData In prCSData
          _ytdAmount += tmp.IncludingProvision
        Next
      End If
      Return _ytdAmount
    End Get
  End Property

End Class
Public Class prCostSheetData
  Public Property FinYear As Integer = 0

  Public ReadOnly Property BeforeProvision As Decimal
    Get
      Return IncludingProvision + Provision
    End Get
  End Property
  Public Property Provision As Decimal = 0
  Public Property IncludingProvision As Decimal = 0
End Class
Public Class yearXLCol
  Public Property prYear As String = ""
  Public Property IsCurrent As Boolean = False
  Public Property YTD As Boolean = False
  Public YearCol As Integer = 0
  Public Property sTotB As Decimal = 0
  Public Property sTotP As Decimal = 0
  Public Property sTotA As Decimal = 0
  Public Property gTotB As Decimal = 0
  Public Property gTotP As Decimal = 0
  Public Property gTotA As Decimal = 0
  Public ReadOnly Property Cell As String
    Get
      Return Chr(64 + YearCol)
    End Get
  End Property
  Public Sub New(ByVal y As String, ByVal c As Boolean, ByVal x As Integer, ByVal t As Boolean)
    prYear = y
    IsCurrent = c
    YearCol = x
    YTD = t
  End Sub
  Public Shared Function hSum(ByVal r As Integer, ByVal yXLCols As List(Of yearXLCol)) As String
    Dim mRet As String = ""
    For Each tmp As yearXLCol In yXLCols
      If mRet = "" Then
        mRet = Chr(tmp.YearCol + 64) & r
      Else
        If tmp.IsCurrent Then
          mRet &= "+" & Chr(tmp.YearCol + 2 + 64) & r
        Else
          If Not tmp.YTD Then
            mRet &= "+" & Chr(tmp.YearCol + 64) & r
          End If
        End If
      End If
    Next
    Return mRet
  End Function
  Public Shared Function xlCol(ByVal FinYear As String, ByVal yXLCols As List(Of yearXLCol)) As yearXLCol
    For Each tmp As yearXLCol In yXLCols
      If tmp.prYear = FinYear Then
        Return tmp
      End If
    Next
    Return Nothing
  End Function
  Public Shared Function ytdCol(ByVal yXLCols As List(Of yearXLCol)) As yearXLCol
    For Each tmp As yearXLCol In yXLCols
      If tmp.YTD Then
        Return tmp
      End If
    Next
    Return Nothing
  End Function
  Public Shared Function GetList(ByVal LowestYear As String, ByVal CurrentYear As String) As List(Of yearXLCol)
    Dim tmp As New List(Of yearXLCol)
    Dim I As Integer = 3
    Do While LowestYear <= CurrentYear
      If LowestYear = CurrentYear Then
        tmp.Add(New yearXLCol(LowestYear, True, I, False))
        I += 3
      Else
        tmp.Add(New yearXLCol(LowestYear, False, I, False))
        I += 1
      End If
      LowestYear = (Convert.ToInt32(LowestYear) + 1).ToString
    Loop
    Dim x As New yearXLCol(LowestYear, False, I, True)
    x.YTD = True
    tmp.Add(x)
    Return tmp
  End Function
End Class


#End Region
'Private Function CreateFile_Value(ByVal ProjectGroupID As Int32, ByVal FinYear As Int32, ByVal Quarter As Int32, ByVal Revision As Int32) As String
'  Dim FileName As String = Server.MapPath("~/..") & "App_Temp\" & Guid.NewGuid().ToString()
'  IO.File.Copy(Server.MapPath("~/App_Templates") & "\cs_Template.xlsx", FileName)
'  Dim FileInfo As IO.FileInfo = New IO.FileInfo(FileName)
'  Dim xlPk As ExcelPackage = New ExcelPackage(FileInfo)


'  Dim xlWS As ExcelWorksheet = xlPk.Workbook.Worksheets("CS")

'  Dim csLastYears As List(Of SIS.COST.costCostSheet) = SIS.COST.costCostSheet.getcsLastYears(ProjectGroupID, FinYear, Quarter, Revision)

'  Dim aPRC As List(Of prCostSheet) = getPRCS(ProjectGroupID, FinYear, Quarter, Revision, csLastYears)
'  aPRC.Sort(Function(x, y) x.prSeq.CompareTo(y.prSeq))

'  Dim LowestYear As String = ""
'  'Get Lowest Year
'  For Each tmp As prCostSheet In aPRC
'    If LowestYear = "" Then
'      LowestYear = tmp.LowestYear
'    Else
'      If tmp.LowestYear < LowestYear Then
'        LowestYear = tmp.LowestYear
'      End If
'    End If
'  Next
'  ' Get Year Array
'  Dim yXLc As List(Of yearXLCol) = yearXLCol.GetList(LowestYear, FinYear)
'  yXLc.Sort(Function(x, y) x.prYear.CompareTo(y.prYear))
'  Dim r As Integer = 6
'  Dim c As Integer = 3
'  With xlWS
'    'Page Headings
'    Dim _tmp As SIS.COST.costProjectGroups = SIS.COST.costProjectGroups.costProjectGroupsGetByID(ProjectGroupID)
'    .Cells(2, 3).Value = _tmp.ProjectGroupDescription
'    Dim _ttmp As List(Of SIS.COST.costProjectGroupProjects) = SIS.COST.costProjectGroupProjects.costProjectGroupProjectsSelectList(0, 999, "", False, "", ProjectGroupID)
'    For Each xtmp As SIS.COST.costProjectGroupProjects In _ttmp
'      .Cells(3, c).Value = xtmp.ProjectID
'      c += 1
'    Next
'    'End Page Heading

'    'Write Column Heading
'    For Each tmp As yearXLCol In yXLc
'      If Not tmp.IsCurrent Then
'        If tmp.YTD Then
'          .Cells(r, tmp.YearCol).Value = "Total"
'          .Cells(r, tmp.YearCol).Style.Font.Bold = True
'          .Cells(r, tmp.YearCol).Style.HorizontalAlignment = HorizontalAlign.Center
'          .Cells(r + 1, tmp.YearCol).Value = "YTD"
'          .Cells(r + 1, tmp.YearCol).Style.Font.Bold = True
'          .Cells(r + 1, tmp.YearCol).Style.HorizontalAlignment = HorizontalAlign.Center
'          .Cells(r, tmp.YearCol, r + 1, tmp.YearCol).Style.Border.BorderAround(Style.ExcelBorderStyle.Medium)
'        Else
'          .Cells(r, tmp.YearCol).Value = "Total"
'          .Cells(r, tmp.YearCol).Style.Font.Bold = True
'          .Cells(r, tmp.YearCol).Style.HorizontalAlignment = HorizontalAlign.Center
'          .Cells(r + 1, tmp.YearCol).Value = tmp.prYear
'          .Cells(r + 1, tmp.YearCol).Style.Font.Bold = True
'          .Cells(r + 1, tmp.YearCol).Style.HorizontalAlignment = HorizontalAlign.Center
'          .Cells(r, tmp.YearCol, r + 1, tmp.YearCol).Style.Border.BorderAround(Style.ExcelBorderStyle.Medium)
'        End If
'      Else
'        .Cells(r, tmp.YearCol, r, tmp.YearCol + 2).Merge = True
'        .Cells(r, tmp.YearCol).Value = "Quarter " & Quarter & " Year " & tmp.prYear
'        .Cells(r, tmp.YearCol).Style.Font.Bold = True
'        .Cells(r, tmp.YearCol).Style.HorizontalAlignment = HorizontalAlign.Center
'        .Cells(r, tmp.YearCol, r, tmp.YearCol + 2).Style.Border.BorderAround(Style.ExcelBorderStyle.Medium)
'        .Cells(r + 1, tmp.YearCol).Value = "Before Provision"
'        .Cells(r + 1, tmp.YearCol).Style.Font.Bold = True
'        .Cells(r + 1, tmp.YearCol).Style.HorizontalAlignment = HorizontalAlign.Center
'        .Cells(r + 1, tmp.YearCol).Style.Border.BorderAround(Style.ExcelBorderStyle.Medium)

'        .Cells(r + 1, tmp.YearCol + 1).Value = "Provision"
'        .Cells(r + 1, tmp.YearCol + 1).Style.Font.Bold = True
'        .Cells(r + 1, tmp.YearCol + 1).Style.HorizontalAlignment = HorizontalAlign.Center
'        .Cells(r + 1, tmp.YearCol + 1).Style.Border.BorderAround(Style.ExcelBorderStyle.Medium)

'        .Cells(r + 1, tmp.YearCol + 2).Value = "After Provision"
'        .Cells(r + 1, tmp.YearCol + 2).Style.Font.Bold = True
'        .Cells(r + 1, tmp.YearCol + 2).Style.HorizontalAlignment = HorizontalAlign.Center
'        .Cells(r + 1, tmp.YearCol + 2).Style.Border.BorderAround(Style.ExcelBorderStyle.Medium)
'      End If
'    Next
'    r = 9
'    'Write Data
'    Dim lNature As String = ""
'    Dim cnt As Integer = 64
'    Dim idx As Integer = 0
'    Dim c_currentYear As Integer = 0
'    For Each tmp As prCostSheet In aPRC
'      If lNature <> tmp.glGrNature Then
'        If lNature <> "" Then
'          .Cells(r, 2).Value = "Total of """ & Chr(cnt) & """"
'          .Cells(r, 2).Style.Font.Bold = True
'          .Cells(r, 2).Style.HorizontalAlignment = HorizontalAlign.Center
'          .Cells(r, 2).Style.Border.BorderAround(Style.ExcelBorderStyle.Thin)
'          'print Total
'          For Each xlv As yearXLCol In yXLc
'            If xlv.IsCurrent Then
'              .Cells(r, xlv.YearCol).Value = xlv.sTotB * IIf(lNature = "SALES", -1, 1)
'              .Cells(r, xlv.YearCol).Style.Font.Bold = True
'              .Cells(r, xlv.YearCol).Style.Border.BorderAround(Style.ExcelBorderStyle.Thin)

'              .Cells(r, xlv.YearCol + 1).Value = xlv.sTotP * IIf(lNature = "SALES", -1, 1)
'              .Cells(r, xlv.YearCol + 1).Style.Font.Bold = True
'              .Cells(r, xlv.YearCol + 1).Style.Border.BorderAround(Style.ExcelBorderStyle.Thin)
'              .Cells(r, xlv.YearCol + 2).Value = xlv.sTotA * IIf(lNature = "SALES", -1, 1)
'              .Cells(r, xlv.YearCol + 2).Style.Font.Bold = True
'              .Cells(r, xlv.YearCol + 2).Style.Border.BorderAround(Style.ExcelBorderStyle.Thin)
'              xlv.sTotB = 0
'              xlv.sTotP = 0
'              xlv.sTotA = 0
'            Else
'              .Cells(r, xlv.YearCol).Value = xlv.sTotA * IIf(lNature = "SALES", -1, 1)
'              .Cells(r, xlv.YearCol).Style.Font.Bold = True
'              .Cells(r, xlv.YearCol).Style.Border.BorderAround(Style.ExcelBorderStyle.Thin)
'              xlv.sTotA = 0
'            End If
'          Next
'          r += 2
'        End If
'        idx = 0
'        lNature = tmp.glGrNature
'        cnt = cnt + 1
'        .Cells(r, 1).Value = """" & Chr(cnt) & """"
'        .Cells(r, 1).Style.Font.Bold = True
'        .Cells(r, 1).Style.HorizontalAlignment = HorizontalAlign.Center
'        .Cells(r, 2).Value = tmp.glGrNature
'        .Cells(r, 2).Style.Font.Bold = True
'        .Cells(r, 2).Style.HorizontalAlignment = HorizontalAlign.Center
'        r += 2
'      End If
'      idx += 1
'      .Cells(r, 1).Value = idx
'      .Cells(r, 2).Value = tmp.glGrDescription
'      For Each tm As prCostSheetData In tmp.prCSData
'        Dim xlv As yearXLCol = yearXLCol.xlCol(tm.FinYear, yXLc)
'        If xlv.IsCurrent Then
'          .Cells(r, xlv.YearCol).Value = tm.BeforeProvision * IIf(lNature = "SALES", -1, 1)
'          .Cells(r, xlv.YearCol + 1).Value = tm.Provision * IIf(lNature = "COST", -1, 1)
'          .Cells(r, xlv.YearCol + 2).Value = tm.IncludingProvision * IIf(lNature = "SALES", -1, 1)
'          xlv.sTotB += tm.BeforeProvision
'          xlv.sTotP += tm.Provision
'          xlv.sTotA += tm.IncludingProvision
'          xlv.gTotB += tm.BeforeProvision
'          xlv.gTotP += tm.Provision
'          xlv.gTotA += tm.IncludingProvision
'        Else
'          .Cells(r, xlv.YearCol).Value = tm.IncludingProvision * IIf(lNature = "SALES", -1, 1)
'          xlv.sTotA += tm.IncludingProvision
'          xlv.gTotA += tm.IncludingProvision
'        End If
'      Next
'      .Cells(r, yearXLCol.ytdCol(yXLc).YearCol).Value = tmp.ytdAmount * IIf(lNature = "SALES", -1, 1)
'      yearXLCol.ytdCol(yXLc).sTotA += tmp.ytdAmount
'      yearXLCol.ytdCol(yXLc).gTotA += tmp.ytdAmount
'      r += 2
'    Next
'    'Print Sub Total 
'    .Cells(r, 2).Value = "Total of """ & Chr(cnt) & """"
'    .Cells(r, 2).Style.Font.Bold = True
'    .Cells(r, 2).Style.HorizontalAlignment = HorizontalAlign.Center
'    .Cells(r, 2).Style.Border.BorderAround(Style.ExcelBorderStyle.Thin)
'    'print Total
'    For Each xlv As yearXLCol In yXLc
'      If xlv.IsCurrent Then
'        .Cells(r, xlv.YearCol).Value = xlv.sTotB
'        .Cells(r, xlv.YearCol).Style.Font.Bold = True
'        .Cells(r, xlv.YearCol).Style.Border.BorderAround(Style.ExcelBorderStyle.Thin)
'        .Cells(r, xlv.YearCol + 1).Value = xlv.sTotP * IIf(lNature = "COST", -1, 1)
'        .Cells(r, xlv.YearCol + 1).Style.Font.Bold = True
'        .Cells(r, xlv.YearCol + 1).Style.Border.BorderAround(Style.ExcelBorderStyle.Thin)
'        .Cells(r, xlv.YearCol + 2).Value = xlv.sTotA
'        .Cells(r, xlv.YearCol + 2).Style.Font.Bold = True
'        .Cells(r, xlv.YearCol + 2).Style.Border.BorderAround(Style.ExcelBorderStyle.Thin)
'        xlv.sTotB = 0
'        xlv.sTotP = 0
'        xlv.sTotA = 0
'      Else
'        .Cells(r, xlv.YearCol).Value = xlv.sTotA
'        .Cells(r, xlv.YearCol).Style.Font.Bold = True
'        .Cells(r, xlv.YearCol).Style.Border.BorderAround(Style.ExcelBorderStyle.Thin)
'        xlv.sTotA = 0
'      End If
'    Next
'    r += 1
'    'Print Gross Total
'    cnt = cnt + 1
'    .Cells(r, 1).Value = """" & Chr(cnt) & """"
'    .Cells(r, 1).Style.Font.Bold = True
'    .Cells(r, 1).Style.HorizontalAlignment = HorizontalAlign.Center
'    .Cells(r, 2).Value = "Gross Margin (A-B)"
'    .Cells(r, 2).Style.Font.Bold = True
'    .Cells(r, 2).Style.HorizontalAlignment = HorizontalAlign.Center
'    .Cells(r, 2).Style.Border.BorderAround(Style.ExcelBorderStyle.Thin)
'    Dim lCol As Integer = 0
'    Dim gMarginLastYear As Decimal = 0
'    Dim gMarginCurrentYear As Decimal = 0
'    For Each xlv As yearXLCol In yXLc
'      If xlv.IsCurrent Then
'        c_currentYear = xlv.YearCol
'        gMarginCurrentYear = xlv.gTotA
'        .Cells(r, xlv.YearCol).Value = xlv.gTotB * -1
'        .Cells(r, xlv.YearCol).Style.Font.Bold = True
'        .Cells(r, xlv.YearCol).Style.Border.BorderAround(Style.ExcelBorderStyle.Thin)
'        .Cells(r, xlv.YearCol + 1).Value = xlv.gTotP * -1
'        .Cells(r, xlv.YearCol + 1).Style.Font.Bold = True
'        .Cells(r, xlv.YearCol + 1).Style.Border.BorderAround(Style.ExcelBorderStyle.Thin)
'        .Cells(r, xlv.YearCol + 2).Value = xlv.gTotA * -1
'        .Cells(r, xlv.YearCol + 2).Style.Font.Bold = True
'        .Cells(r, xlv.YearCol + 2).Style.Border.BorderAround(Style.ExcelBorderStyle.Thin)
'        xlv.gTotB = 0
'        xlv.gTotP = 0
'        xlv.gTotA = 0
'      Else
'        If xlv.prYear = (FinYear - 1).ToString Then
'          gMarginLastYear = xlv.gTotA
'        End If
'        .Cells(r, xlv.YearCol).Value = xlv.gTotA * -1
'        .Cells(r, xlv.YearCol).Style.Font.Bold = True
'        .Cells(r, xlv.YearCol).Style.Border.BorderAround(Style.ExcelBorderStyle.Thin)
'        xlv.gTotA = 0
'      End If
'      lCol = xlv.YearCol
'    Next
'    For i As Integer = 1 To lCol
'      .Cells(6, 1, r, i).Style.Border.BorderAround(Style.ExcelBorderStyle.Thin)
'    Next
'    'Cost Table
'    Dim r_ct As Integer = r + 2
'    Dim c_ct As Integer = c_currentYear - 1
'    'Immediate Last Year
'    Dim LastYear As Integer = FinYear - 1
'    Dim bkdTot As Decimal = 0
'    Dim exITot As Decimal = 0
'    Dim bkdTotc As Decimal = 0
'    Dim exITotc As Decimal = 0

'    Dim oPI As SIS.COST.costProjectsInput = SIS.COST.costProjectsInput.costProjectsInputGetByID(ProjectGroupID, FinYear, Quarter)

'    For Each tmp As prCostSheet In aPRC
'      If tmp.glGrNature = "SALES" Then
'        Select Case tmp.glGroupID
'          Case 28, 33, 35
'            For Each ttmp As prCostSheetData In tmp.prCSData
'              If ttmp.FinYear = LastYear Then
'                bkdTot += ttmp.IncludingProvision
'              ElseIf ttmp.FinYear = FinYear Then
'                bkdTotc += ttmp.IncludingProvision
'              End If
'            Next
'          Case 30
'            For Each ttmp As prCostSheetData In tmp.prCSData
'              If ttmp.FinYear = LastYear Then
'                exITot += ttmp.IncludingProvision
'              ElseIf ttmp.FinYear = FinYear Then
'                exITotc += ttmp.IncludingProvision
'              End If
'            Next
'        End Select
'      End If
'    Next
'    .Cells(r_ct, c_ct, r_ct, c_ct + 5).Style.Font.Bold = True
'    .Cells(r_ct, c_ct, r_ct + 4, c_ct).Style.Font.Bold = True
'    .Cells(r_ct, c_ct, r_ct + 4, c_ct + 5).Style.Border.BorderAround(Style.ExcelBorderStyle.Medium)
'    .Cells(r_ct + 1, c_ct + 1, r_ct + 4, c_ct + 5).Style.HorizontalAlignment = HorizontalAlign.Center


'    'write table
'    .Cells(r_ct, c_ct + 1).Value = "Total"
'    .Cells(r_ct, c_ct + 2).Value = "Bkd. upto F" & LastYear
'    .Cells(r_ct, c_ct + 3).Value = "Bal. on Apr'" & LastYear
'    .Cells(r_ct, c_ct + 4).Value = "Bkd. F" & FinYear
'    .Cells(r_ct, c_ct + 5).Value = "Yet to Book"
'    .Cells(r_ct + 1, c_ct).Value = "Sales"
'    .Cells(r_ct + 2, c_ct).Value = "Margin"
'    .Cells(r_ct + 3, c_ct).Value = "Export Incentive"
'    .Cells(r_ct + 4, c_ct).Value = "Total"

'    Try
'      .Cells(r_ct + 1, c_ct + 1).Value = (oPI.ProjectRevenueByACINR / 100000).ToString("n")
'      .Cells(r_ct + 2, c_ct + 1).Value = (oPI.ProjectMarginByACINR / 100000).ToString("n")
'      .Cells(r_ct + 3, c_ct + 1).Value = (oPI.ExportIncentiveByACINR / 100000).ToString("n")
'      .Cells(r_ct + 4, c_ct + 1).Value = ((Convert.ToDecimal(oPI.ProjectMarginByACINR) + Convert.ToDecimal(oPI.ExportIncentiveByACINR)) / 100000).ToString("n")

'      .Cells(r_ct + 1, c_ct + 2).Value = (-1 * bkdTot / 100000).ToString("n")
'      .Cells(r_ct + 2, c_ct + 2).Value = (-1 * (gMarginLastYear - exITot) / 100000).ToString("n")
'      .Cells(r_ct + 3, c_ct + 2).Value = (-1 * exITot / 100000).ToString("n")
'      .Cells(r_ct + 4, c_ct + 2).Value = (-1 * (gMarginLastYear) / 100000).ToString("n")

'      .Cells(r_ct + 1, c_ct + 3).Value = (Convert.ToDecimal(.Cells(r_ct + 1, c_ct + 1).Text) - Convert.ToDecimal(.Cells(r_ct + 1, c_ct + 2).Text)).ToString("n")
'      .Cells(r_ct + 2, c_ct + 3).Value = (Convert.ToDecimal(.Cells(r_ct + 2, c_ct + 1).Text) - Convert.ToDecimal(.Cells(r_ct + 2, c_ct + 2).Text)).ToString("n")
'      .Cells(r_ct + 3, c_ct + 3).Value = (Convert.ToDecimal(.Cells(r_ct + 3, c_ct + 1).Text) - Convert.ToDecimal(.Cells(r_ct + 3, c_ct + 2).Text)).ToString("n")
'      .Cells(r_ct + 4, c_ct + 3).Value = (Convert.ToDecimal(.Cells(r_ct + 4, c_ct + 1).Text) - Convert.ToDecimal(.Cells(r_ct + 4, c_ct + 2).Text)).ToString("n")


'      .Cells(r_ct + 1, c_ct + 4).Value = (-1 * bkdTotc / 100000).ToString("n")
'      .Cells(r_ct + 2, c_ct + 4).Value = (-1 * (gMarginCurrentYear - exITotc) / 100000).ToString("n")
'      .Cells(r_ct + 3, c_ct + 4).Value = (-1 * exITotc / 100000).ToString("n")
'      .Cells(r_ct + 4, c_ct + 4).Value = (-1 * (gMarginCurrentYear) / 100000).ToString("n")

'      .Cells(r_ct + 1, c_ct + 5).Value = (Convert.ToDecimal(.Cells(r_ct + 1, c_ct + 3).Text) - Convert.ToDecimal(.Cells(r_ct + 1, c_ct + 4).Text)).ToString("n")
'      .Cells(r_ct + 2, c_ct + 5).Value = (Convert.ToDecimal(.Cells(r_ct + 2, c_ct + 3).Text) - Convert.ToDecimal(.Cells(r_ct + 2, c_ct + 4).Text)).ToString("n")
'      .Cells(r_ct + 3, c_ct + 5).Value = (Convert.ToDecimal(.Cells(r_ct + 3, c_ct + 3).Text) - Convert.ToDecimal(.Cells(r_ct + 3, c_ct + 4).Text)).ToString("n")
'      .Cells(r_ct + 4, c_ct + 5).Value = (Convert.ToDecimal(.Cells(r_ct + 4, c_ct + 3).Text) - Convert.ToDecimal(.Cells(r_ct + 4, c_ct + 4).Text)).ToString("n")


'    Catch ex As Exception
'      .Cells(r_ct + 5, c_ct).Value = ex.Message
'    End Try



'  End With


'  xlPk.Save()
'  xlPk.Dispose()
'  Return FileName
'End Function
