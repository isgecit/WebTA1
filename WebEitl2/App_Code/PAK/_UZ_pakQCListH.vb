Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.PAK
  Partial Public Class pakQCListH
    Public ReadOnly Property GetPkgLink As String
      Get
        Return "~/PAK_Main/App_Edit/EF_pakPkgListH.aspx?SerialNo=" & SerialNo & "&PkgNo=" & PkgNo
      End Get
    End Property
    Public ReadOnly Property GetPrintLink() As String
      Get
        Return "javascript:window.open('" & HttpContext.Current.Request.Url.Scheme & Uri.SchemeDelimiter & HttpContext.Current.Request.Url.Authority & HttpContext.Current.Request.ApplicationPath & "/PAK_Main/App_Downloads/qcldownload.aspx?qcl=" & PrimaryKey & "&typ=1" & "', 'win" & QCLNo & "', 'left=20,top=20,width=100,height=100,toolbar=1,resizable=1,scrollbars=1'); return false;"
      End Get
    End Property
    Public ReadOnly Property GetDownloadLink() As String
      Get
        Return "javascript:window.open('" & HttpContext.Current.Request.Url.Scheme & Uri.SchemeDelimiter & HttpContext.Current.Request.Url.Authority & HttpContext.Current.Request.ApplicationPath & "/PAK_Main/App_Downloads/qcldownload.aspx?qcl=" & PrimaryKey & "', 'win" & QCLNo & "', 'left=20,top=20,width=100,height=100,toolbar=1,resizable=1,scrollbars=1'); return false;"
      End Get
    End Property
    Public Function GetColor() As System.Drawing.Color
      Dim mRet As System.Drawing.Color = Drawing.Color.Black
      Select Case StatusID
        Case pakQCStates.Returned
          mRet = Drawing.Color.Red
        Case pakQCStates.UnderQualityInspection
          mRet = Drawing.Color.DarkGoldenrod
        Case pakQCStates.QCCompleted
          mRet = Drawing.Color.Green
        Case pakQCStates.PackingListCreated
          mRet = Drawing.Color.DarkMagenta
      End Select
      Return mRet
    End Function
    Public Function GetVisible() As Boolean
      Dim mRet As Boolean = True
      Return mRet
    End Function
    Public Function GetEnable() As Boolean
      Dim mRet As Boolean = True
      Return mRet
    End Function
    Public Function GetEditable() As Boolean
      Dim mRet As Boolean = False
      Select Case StatusID
        Case pakQCStates.Free, pakQCStates.Returned
          mRet = True
      End Select
      Return mRet
    End Function
    Public Function GetDeleteable() As Boolean
      Return GetEditable()
    End Function
    Public ReadOnly Property Editable() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetEditable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property Deleteable() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetDeleteable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property InitiateWFVisible() As Boolean
      Get
        Dim mRet As Boolean = False
        Try
          Select Case StatusID
            Case pakQCStates.Free, pakQCStates.Returned
              mRet = True
          End Select
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property InitiateWFEnable() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetEnable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property ConvertWFVisible() As Boolean
      Get
        Dim mRet As Boolean = False
        Try
          Select Case StatusID
            Case pakQCStates.QCCompleted
              mRet = True
          End Select
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property ConvertWFEnable() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetEnable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public Shared Function ConvertWF(ByVal SerialNo As Int32, ByVal QCLNo As Int32) As SIS.PAK.pakQCListH
      Dim qcH As SIS.PAK.pakQCListH = pakQCListHGetByID(SerialNo, QCLNo)
      '1. Create Pkg Header
      Dim pkgH As SIS.PAK.pakPkgListH = New SIS.PAK.pakPkgListH
      With pkgH
        .SerialNo = qcH.SerialNo
        .SupplierRefNo = qcH.SupplierRef
        .TransporterID = ""
        .TransporterName = ""
        .VehicleNo = ""
        .GRNo = ""
        .GRDate = ""
        .VRExecutionNo = ""
        .Remarks = ""
        .CreatedBy = Global.System.Web.HttpContext.Current.Session("LoginID")
        .UOMTotalWeight = qcH.UOMTotalWeight
        .Additional1Info = ""
        .Additional2Info = ""
        .CreatedOn = Now
        .TotalWeight = qcH.QualityClearedWt
        .StatusID = pakPkgStates.Free
      End With
      pkgH = SIS.PAK.pakPkgListH.InsertData(pkgH)
      qcH.PkgNo = pkgH.PkgNo
      qcH.StatusID = pakQCStates.PackingListCreated
      '2. Create Pkg Lines
      Dim qcDs As List(Of SIS.PAK.pakQCListD) = SIS.PAK.pakQCListD.pakQCListDSelectList(0, 99999, "", False, "", qcH.SerialNo, qcH.QCLNo)
      For Each qcd As SIS.PAK.pakQCListD In qcDs
        Dim pkgD As SIS.PAK.pakPkgListD = New SIS.PAK.pakPkgListD
        With pkgD
          .SerialNo = pkgH.SerialNo
          .PkgNo = pkgH.PkgNo
          .BOMNo = qcd.BOMNo
          .ItemNo = qcd.ItemNo
          .UOMQuantity = qcd.UOMQuantity
          .Quantity = qcd.QualityClearedQty
          .UOMWeight = qcd.UOMWeight
          .WeightPerUnit = qcd.WeightPerUnit
          .TotalWeight = qcd.QualityClearedWt
          .PackTypeID = ""
          .UOMPack = ""
          .PackHeight = 0.0000
          .PackWidth = 0.0000
          .PackLength = 0.0000
          .Remarks = qcd.Remarks
          .QuantityReceived = 0.0000
          .TotalWeightReceived = 0.0000
          .QuantityBalance = 0.0000
          .TotalWeightBalance = 0.0000
          .PackingMark = ""
          .DocumentNo = ""
          .DocumentRevision = ""
        End With
        pkgD = SIS.PAK.pakPkgListD.InsertData(pkgD)
      Next
      qcH = SIS.PAK.pakQCListH.UpdateData(qcH)
      Return qcH
    End Function

    Public Shared Function InitiateWF(ByVal SerialNo As Int32, ByVal QCLNo As Int32, ByVal QCRequestNo As String) As SIS.PAK.pakQCListH
      If QCRequestNo Is Nothing Then QCRequestNo = ""
      Dim Results As SIS.PAK.pakQCListH = pakQCListHGetByID(SerialNo, QCLNo)
      Dim qcItems As List(Of SIS.PAK.pakQCListD) = SIS.PAK.pakQCListD.pakQCListDSelectList(0, 99999, "", False, "", SerialNo, QCLNo)
      If qcItems.Count <= 0 Then
        Throw New Exception("No Item found for QC, can not forward.")
      End If
      Dim totWt As Decimal = 0
      For Each qcItm As SIS.PAK.pakQCListD In qcItems
        totWt += qcItm.TotalWeight
      Next
      With Results
        .TotalWeight = totWt
        .UOMTotalWeight = 6 '6=>Kg
        .QCRequestNo = QCRequestNo
        .StatusID = pakQCStates.UnderQualityInspection
        .CreatedBy = HttpContext.Current.Session("LoginID")
        .CreatedOn = Now
      End With
      Results = SIS.PAK.pakQCListH.UpdateData(Results)
      Try
        SIS.CT.ctUpdates.CT_QCOffered(Results)
      Catch ex As Exception
      End Try
      Return Results
    End Function
    Public Shared Function SetDefaultValues(ByVal sender As System.Web.UI.WebControls.FormView, ByVal e As System.EventArgs) As System.Web.UI.WebControls.FormView
      With sender
        Try
          CType(.FindControl("F_SerialNo"), TextBox).Text = ""
          CType(.FindControl("F_SerialNo_Display"), Label).Text = ""
          CType(.FindControl("F_QCLNo"), TextBox).Text = ""
          CType(.FindControl("F_SupplierRef"), TextBox).Text = ""
          CType(.FindControl("F_Remarks"), TextBox).Text = ""
        Catch ex As Exception
        End Try
      End With
      Return sender
    End Function
  End Class
End Namespace
