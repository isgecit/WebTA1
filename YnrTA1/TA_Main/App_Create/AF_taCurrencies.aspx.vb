Partial Class AF_taCurrencies
  Inherits SIS.SYS.InsertBase
  Protected Sub FVtaCurrencies_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVtaCurrencies.Init
    DataClassName = "AtaCurrencies"
    SetFormView = FVtaCurrencies
  End Sub
  Protected Sub TBLtaCurrencies_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLtaCurrencies.Init
    SetToolBar = TBLtaCurrencies
  End Sub
  Protected Sub FVtaCurrencies_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVtaCurrencies.DataBound
    SIS.TA.taCurrencies.SetDefaultValues(sender, e) 
  End Sub
  Protected Sub FVtaCurrencies_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVtaCurrencies.PreRender
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/TA_Main/App_Create") & "/AF_taCurrencies.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scripttaCurrencies") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scripttaCurrencies", mStr)
    End If
    If Request.QueryString("CurrencyID") IsNot Nothing Then
      CType(FVtaCurrencies.FindControl("F_CurrencyID"), TextBox).Text = Request.QueryString("CurrencyID")
      CType(FVtaCurrencies.FindControl("F_CurrencyID"), TextBox).Enabled = False
    End If
  End Sub
  <System.Web.Services.WebMethod()> _
  Public Shared Function validatePK_taCurrencies(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
    Dim CurrencyID As String = CType(aVal(1),String)
    Dim oVar As SIS.TA.taCurrencies = SIS.TA.taCurrencies.taCurrenciesGetByID(CurrencyID)
    If Not oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record allready exists." 
    End If
    Return mRet
  End Function

End Class
