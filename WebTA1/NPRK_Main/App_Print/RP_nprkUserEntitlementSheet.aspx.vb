Partial Class RP_nprkUserEntitlementSheet
  Inherits System.Web.UI.Page
  Protected Sub ShowPerkBalance(ByVal sender As Object, ByVal e As System.EventArgs)
    Dim oBal As LC_PrkBalanceAsOn = CType(sender, LC_PrkBalanceAsOn)
    If Not oBal Is Nothing Then
      oBal.EmployeeID = System.Web.HttpContext.Current.Session("LoginID")
      oBal.LoadData()
      If oBal.LedgerCount <= 0 And oBal.EntitlementsCount <= 0 Then
        oBal.Visible = False
      End If
    End If
  End Sub

End Class
