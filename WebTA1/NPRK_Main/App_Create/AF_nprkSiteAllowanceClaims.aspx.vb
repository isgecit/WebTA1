Imports System.Web.Script.Serialization
Partial Class AF_nprkSiteAllowanceClaims
  Inherits SIS.SYS.InsertBase
  Protected Sub FVnprkSiteAllowanceClaims_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVnprkSiteAllowanceClaims.Init
    DataClassName = "AnprkSiteAllowanceClaims"
    SetFormView = FVnprkSiteAllowanceClaims
  End Sub
  Protected Sub TBLnprkSiteAllowanceClaims_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLnprkSiteAllowanceClaims.Init
    SetToolBar = TBLnprkSiteAllowanceClaims
  End Sub
  Protected Sub FVnprkSiteAllowanceClaims_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVnprkSiteAllowanceClaims.DataBound
    Dim Quarter As Integer = 1
    Select Case Now.Month
      Case 1, 2, 3
        Quarter = 4
      Case 4, 5, 6
        Quarter = 1
      Case 7, 8, 9
        Quarter = 2
      Case 10, 11, 12
        Quarter = 3
    End Select
    CType(FVnprkSiteAllowanceClaims.FindControl("F_FinYear"), LC_costFinYear).SelectedValue = SIS.SYS.Utilities.ApplicationSpacific.ActivePRKYear
    CType(FVnprkSiteAllowanceClaims.FindControl("F_Quarter"), LC_costQuarters).SelectedValue = Quarter
  End Sub
  Protected Sub FVnprkSiteAllowanceClaims_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVnprkSiteAllowanceClaims.PreRender
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/NPRK_Main/App_Create") & "/AF_nprkSiteAllowanceClaims.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptnprkSiteAllowanceClaims") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptnprkSiteAllowanceClaims", mStr)
    End If
    If Request.QueryString("FinYear") IsNot Nothing Then
      CType(FVnprkSiteAllowanceClaims.FindControl("F_FinYear"), TextBox).Text = Request.QueryString("FinYear")
      CType(FVnprkSiteAllowanceClaims.FindControl("F_FinYear"), TextBox).Enabled = False
    End If
    If Request.QueryString("Quarter") IsNot Nothing Then
      CType(FVnprkSiteAllowanceClaims.FindControl("F_Quarter"), TextBox).Text = Request.QueryString("Quarter")
      CType(FVnprkSiteAllowanceClaims.FindControl("F_Quarter"), TextBox).Enabled = False
    End If
    If Request.QueryString("EmployeeID") IsNot Nothing Then
      CType(FVnprkSiteAllowanceClaims.FindControl("F_EmployeeID"), TextBox).Text = Request.QueryString("EmployeeID")
      CType(FVnprkSiteAllowanceClaims.FindControl("F_EmployeeID"), TextBox).Enabled = False
    End If
  End Sub
  <System.Web.Services.WebMethod()>
  Public Shared Function validatePK_nprkSiteAllowanceClaims(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String = "0|" & aVal(0)
    Dim FinYear As Int32 = CType(aVal(1), Int32)
    Dim Quarter As Int32 = CType(aVal(2), Int32)
    Dim EmployeeID As String = CType(aVal(3), String)
    Dim oVar As SIS.NPRK.nprkSiteAllowanceClaims = SIS.NPRK.nprkSiteAllowanceClaims.nprkSiteAllowanceClaimsGetByID(FinYear, Quarter, EmployeeID)
    If Not oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record allready exists."
    End If
    Return mRet
  End Function

  Private Sub FVnprkSiteAllowanceClaims_ItemCommand(sender As Object, e As FormViewCommandEventArgs) Handles FVnprkSiteAllowanceClaims.ItemCommand
    If e.CommandName = "lgEntitlement" Then
      Try
        Dim tmp As New SIS.NPRK.nprkSiteAllowanceClaims
        With tmp
          .FinYear = CType(FVnprkSiteAllowanceClaims.FindControl("F_FinYear"), LC_costFinYear).SelectedValue
          .Quarter = CType(FVnprkSiteAllowanceClaims.FindControl("F_Quarter"), LC_costQuarters).SelectedValue
        End With
        tmp = SIS.NPRK.nprkSiteAllowanceClaims.UpdateEntitlementDaysAndAmounts(tmp)
        With FVnprkSiteAllowanceClaims
          CType(.FindControl("F_FinYear"), LC_costFinYear).SelectedValue = tmp.FinYear
          CType(.FindControl("F_Quarter"), LC_costQuarters).SelectedValue = tmp.Quarter
          CType(.FindControl("F_Entitled1Amount"), TextBox).Text = tmp.Entitled1Amount
          CType(.FindControl("F_Entitled2Amount"), TextBox).Text = tmp.Entitled2Amount
          CType(.FindControl("F_Entitled3Amount"), TextBox).Text = tmp.Entitled3Amount
          CType(.FindControl("F_TotalEntitledAmount"), TextBox).Text = tmp.TotalEntitledAmount
        End With
      Catch ex As Exception
        Dim str As String = New JavaScriptSerializer().Serialize(ex.Message)
        Dim script As String = String.Format("alert({0});", str)
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", script, True)
      End Try
    End If
  End Sub

  Private Sub FVnprkSiteAllowanceClaims_ItemInserting(sender As Object, e As FormViewInsertEventArgs) Handles FVnprkSiteAllowanceClaims.ItemInserting
    Dim FinYear As String = e.Values("FinYear").ToString
    Dim Quarter As String = e.Values("Quarter").ToString
    Dim CardNo As String = HttpContext.Current.Session("LoginID")
    Dim tmp As SIS.NPRK.nprkSiteAllowanceClaims = SIS.NPRK.nprkSiteAllowanceClaims.nprkSiteAllowanceClaimsGetByID(FinYear, Quarter, CardNo)
    If tmp IsNot Nothing Then
      Dim str As String = New JavaScriptSerializer().Serialize("Claim for Fin. Year and Quarter is already created.")
      Dim script As String = String.Format("alert({0});", str)
      ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", script, True)
      e.Cancel = True
      Exit Sub
    End If
    If Convert.ToDecimal(e.Values("TotalEntitledAmount")) <= 0 Then
      Dim str As String = New JavaScriptSerializer().Serialize("Total Entitled Amount is Zero.")
      Dim script As String = String.Format("alert({0});", str)
      ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", script, True)
      e.Cancel = True
    End If
  End Sub
End Class
