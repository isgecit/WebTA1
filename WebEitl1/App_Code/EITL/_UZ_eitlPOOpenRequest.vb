Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.EITL
  Partial Public Class eitlPOOpenRequest
		Public Function GetColor() As System.Drawing.Color
      Dim mRet As System.Drawing.Color = Drawing.Color.Black
      If ExecutedBy <> String.Empty Then
        If ExecutedToOpen Then
          mRet = Drawing.Color.Green
        Else
          mRet = Drawing.Color.Red
        End If
      End If
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
    Public ReadOnly Property ApproveWFVisible() As Boolean
      Get
        Dim mRet As Boolean = False
        Try
          If ExecutedBy = String.Empty Then
            mRet = True
          End If
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property ApproveWFEnable() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
					mRet = GetEnable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property RejectWFVisible() As Boolean
      Get
        Dim mRet As Boolean = False
        Try
          If ExecutedBy = String.Empty Then
            mRet = True
          End If
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property RejectWFEnable() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
					mRet = GetEnable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public Shared Function ApproveWF(ByVal RequestNo As Int32, ByVal ExecuterRemarks As String) As SIS.EITL.eitlPOOpenRequest
      Dim Results As SIS.EITL.eitlPOOpenRequest = eitlPOOpenRequestGetByID(RequestNo)
      With Results
        .ExecuterRemarks = ExecuterRemarks
        .ExecutedBy = HttpContext.Current.Session("LoginID")
        .ExecutedOn = Now
        .ExecutedToOpen = True
      End With
      Results = SIS.EITL.eitlPOOpenRequest.UpdateData(Results)
      Dim oPO As SIS.EITL.eitlPOList = SIS.EITL.eitlPOList.eitlPOListGetByID(Results.SerialNo)
      With oPO
        .POStatusID = 3
        .ClosedBy = ""
        .ClosedOn = ""
      End With
      oPO = SIS.EITL.eitlPOList.UpdateData(oPO)
      'Send E-Mail
      SIS.EITL.Alerts.Alert(Results.RequestNo, AlertEvents.OpenPORequestExecuted)
      Return Results
    End Function
    Public Shared Function RejectWF(ByVal RequestNo As Int32, ByVal ExecuterRemarks As String) As SIS.EITL.eitlPOOpenRequest
      Dim Results As SIS.EITL.eitlPOOpenRequest = eitlPOOpenRequestGetByID(RequestNo)
      With Results
        .ExecuterRemarks = ExecuterRemarks
        .ExecutedBy = HttpContext.Current.Session("LoginID")
        .ExecutedOn = Now
        .ExecutedToOpen = False
      End With
      Results = SIS.EITL.eitlPOOpenRequest.UpdateData(Results)
      Dim oPO As SIS.EITL.eitlPOList = SIS.EITL.eitlPOList.eitlPOListGetByID(Results.SerialNo)
      With oPO
        .POStatusID = 4
      End With
      oPO = SIS.EITL.eitlPOList.UpdateData(oPO)
      'Send E-Mail
      SIS.EITL.Alerts.Alert(Results.RequestNo, AlertEvents.OpenPORequestExecuted)
      Return Results
    End Function
  End Class
End Namespace
