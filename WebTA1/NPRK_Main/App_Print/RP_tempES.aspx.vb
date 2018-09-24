Partial Class RP_tempES
  Inherits System.Web.UI.Page
  Protected Sub ShowPerkBalanceSep(ByVal sender As Object, ByVal e As System.EventArgs)
    Dim oBal As LC_PrkBalanceSep = CType(sender, LC_PrkBalanceSep)
    If Not oBal Is Nothing Then
      oBal.EmployeeID = System.Web.HttpContext.Current.Session("LoginID")
      oBal.LoadData()
      If oBal.LedgerCount <= 0 And oBal.EntitlementsCount <= 0 Then
        oBal.Visible = False
      End If
    End If
  End Sub

End Class
