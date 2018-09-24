Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.TA
  Partial Public Class taBillLast
    Public Function GetColor() As System.Drawing.Color
      Dim mRet As System.Drawing.Color = Drawing.Color.Blue
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
      Dim mRet As Boolean = True
      Return mRet
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
          mRet = GetEditable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public Shared Function SetDefaultValues(ByVal sender As System.Web.UI.WebControls.FormView, ByVal e As System.EventArgs) As System.Web.UI.WebControls.FormView
      With sender
        Try
        CType(.FindControl("F_TABillNo"), TextBox).Text = 0
        CType(.FindControl("F_EmployeeID"), TextBox).Text = ""
        CType(.FindControl("F_EmployeeID_Display"), Label).Text = ""
        CType(.FindControl("F_CompanyID"), TextBox).Text = ""
        CType(.FindControl("F_CompanyID_Display"), Label).Text = ""
        CType(.FindControl("F_DivisionID"), TextBox).Text = ""
        CType(.FindControl("F_DivisionID_Display"), Label).Text = ""
        CType(.FindControl("F_DepartmentID"), TextBox).Text = ""
        CType(.FindControl("F_DepartmentID_Display"), Label).Text = ""
        CType(.FindControl("F_DesignationID"), TextBox).Text = ""
        CType(.FindControl("F_DesignationID_Display"), Label).Text = ""
        CType(.FindControl("F_TACategoryID"), TextBox).Text = ""
        CType(.FindControl("F_TACategoryID_Display"), Label).Text = ""
        CType(.FindControl("F_Contractual"), CheckBox).Checked = False
        CType(.FindControl("F_NonTechnical"), CheckBox).Checked = False
        CType(.FindControl("F_TravelTypeID"), TextBox).Text = ""
        CType(.FindControl("F_TravelTypeID_Display"), Label).Text = ""
        CType(.FindControl("F_PurposeOfJourney"), TextBox).Text = ""
        CType(.FindControl("F_CityOfOrigin"), TextBox).Text = ""
        CType(.FindControl("F_CityOfOrigin_Display"), Label).Text = ""
        CType(.FindControl("F_DestinationCity"), TextBox).Text = ""
        CType(.FindControl("F_DestinationCity_Display"), Label).Text = ""
        CType(.FindControl("F_CostCenterID"), TextBox).Text = ""
        CType(.FindControl("F_CostCenterID_Display"), Label).Text = ""
        CType(.FindControl("F_BillCurrencyID"), TextBox).Text = ""
        CType(.FindControl("F_BillCurrencyID_Display"), Label).Text = ""
        CType(.FindControl("F_ProjectID"), TextBox).Text = ""
        CType(.FindControl("F_ProjectID_Display"), Label).Text = ""
        CType(.FindControl("F_TrainingProgram"), CheckBox).Checked = False
        CType(.FindControl("F_SameDayVisit"), CheckBox).Checked = False
        CType(.FindControl("F_Within25KM"), CheckBox).Checked = False
        CType(.FindControl("F_SiteToAnotherSite"), CheckBox).Checked = False
        CType(.FindControl("F_TaxiHired"), CheckBox).Checked = False
        CType(.FindControl("F_OwnVehicleUsed"), CheckBox).Checked = False
        CType(.FindControl("F_BillStatusID"), TextBox).Text = ""
        CType(.FindControl("F_BillStatusID_Display"), Label).Text = ""
        CType(.FindControl("F_StartDateTime"), TextBox).Text = ""
        CType(.FindControl("F_EndDateTime"), TextBox).Text = ""
        CType(.FindControl("F_SanctionedDA"), TextBox).Text = 0
        CType(.FindControl("F_SanctionedLodging"), TextBox).Text = 0
        CType(.FindControl("F_TotalClaimedAmount"), TextBox).Text = 0
        CType(.FindControl("F_TotalPassedAmount"), TextBox).Text = 0
        CType(.FindControl("F_TotalFinancedAmount"), TextBox).Text = 0
        CType(.FindControl("F_TotalPayableAmount"), TextBox).Text = 0
        CType(.FindControl("F_ConversionFactorINR"), TextBox).Text = 0
        CType(.FindControl("F_OOEBySystem"), CheckBox).Checked = False
        CType(.FindControl("F_OOEByAccounts"), CheckBox).Checked = False
        CType(.FindControl("F_OOEReasonID"), TextBox).Text = ""
        CType(.FindControl("F_OOEReasonID_Display"), Label).Text = ""
        CType(.FindControl("F_OOERemarks"), TextBox).Text = ""
        CType(.FindControl("F_ApprovalWFTypeID"), TextBox).Text = ""
        CType(.FindControl("F_ApprovalWFTypeID_Display"), Label).Text = ""
        CType(.FindControl("F_ApprovedBy"), TextBox).Text = ""
        CType(.FindControl("F_ApprovedBy_Display"), Label).Text = ""
        CType(.FindControl("F_ApprovedOn"), TextBox).Text = ""
        CType(.FindControl("F_ApprovalRemarks"), TextBox).Text = ""
        CType(.FindControl("F_Setteled"), CheckBox).Checked = False
        CType(.FindControl("F_BriefTourReport"), TextBox).Text = ""
        CType(.FindControl("F_ApprovedByCC"), TextBox).Text = ""
        CType(.FindControl("F_ApprovedByCC_Display"), Label).Text = ""
        CType(.FindControl("F_ApprovedByCCOn"), TextBox).Text = ""
        CType(.FindControl("F_CCRemarks"), TextBox).Text = ""
        CType(.FindControl("F_ApprovedBySA"), TextBox).Text = ""
        CType(.FindControl("F_ApprovedBySA_Display"), Label).Text = ""
        CType(.FindControl("F_ApprovedBySAOn"), TextBox).Text = ""
        CType(.FindControl("F_SARemarks"), TextBox).Text = ""
        CType(.FindControl("F_VerifiedBy"), TextBox).Text = ""
        CType(.FindControl("F_VerifiedBy_Display"), Label).Text = ""
        CType(.FindControl("F_VerifiedOn"), TextBox).Text = ""
        CType(.FindControl("F_VerificationRemarks"), TextBox).Text = ""
        CType(.FindControl("F_PostedBy"), TextBox).Text = ""
        CType(.FindControl("F_PostedBy_Display"), Label).Text = ""
        CType(.FindControl("F_PostedOn"), TextBox).Text = ""
        CType(.FindControl("F_ERPBatchNo"), TextBox).Text = ""
        CType(.FindControl("F_ERPDocumentNo"), TextBox).Text = ""
        CType(.FindControl("F_ReportAttached"), CheckBox).Checked = False
        CType(.FindControl("F_SanctionAttached"), CheckBox).Checked = False
        CType(.FindControl("F_ApprovalAttached"), CheckBox).Checked = False
        CType(.FindControl("F_ReportFileName"), TextBox).Text = ""
        CType(.FindControl("F_SanctionFileName"), TextBox).Text = ""
        CType(.FindControl("F_ApprovalFileName"), TextBox).Text = ""
        CType(.FindControl("F_ReportDiskFile"), TextBox).Text = ""
        CType(.FindControl("F_SanctionDiskFile"), TextBox).Text = ""
        CType(.FindControl("F_ApprovalDiskFile"), TextBox).Text = ""
        CType(.FindControl("F_ForwardedOn"), TextBox).Text = ""
        CType(.FindControl("F_ReceivedOn"), TextBox).Text = ""
        CType(.FindControl("F_ComponentID"), TextBox).Text = ""
        CType(.FindControl("F_ComponentID_Display"), Label).Text = ""
        CType(.FindControl("F_CalculationTypeID"), TextBox).Text = ""
        CType(.FindControl("F_CalculationTypeID_Display"), Label).Text = ""
        CType(.FindControl("F_PrjCalcType"), TextBox).Text = ""
        CType(.FindControl("F_PrjCalcType_Display"), Label).Text = ""
        Catch ex As Exception
        End Try
      End With
      Return sender
    End Function
    Public Sub New(ByVal Reader As SqlDataReader)
      Try
        For Each pi As System.Reflection.PropertyInfo In Me.GetType.GetProperties
          If pi.MemberType = Reflection.MemberTypes.Property Then
            Try
              If Convert.IsDBNull(Reader(pi.Name)) Then
                CallByName(Me, pi.Name, CallType.Let, String.Empty)
              Else
                CallByName(Me, pi.Name, CallType.Let, Reader(pi.Name))
              End If
            Catch ex As Exception
            End Try
          End If
        Next
      Catch ex As Exception
      End Try
    End Sub
    Public Sub New(ByVal TaBill As SIS.TA.taBH)
      Try
        For Each pi As System.Reflection.PropertyInfo In Me.GetType.GetProperties
          If pi.MemberType = Reflection.MemberTypes.Property Then
            Try
              CallByName(Me, pi.Name, CallType.Let, CallByName(TaBill, pi.Name, CallType.Get))
            Catch ex As Exception
            End Try
          End If
        Next
      Catch ex As Exception
      End Try
    End Sub
  End Class
End Namespace
