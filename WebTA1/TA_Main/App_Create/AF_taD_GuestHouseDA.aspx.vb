Partial Class AF_taD_GuestHouseDA
  Inherits SIS.SYS.InsertBase
  Protected Sub FVtaD_GuestHouseDA_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVtaD_GuestHouseDA.Init
    DataClassName = "AtaD_GuestHouseDA"
    SetFormView = FVtaD_GuestHouseDA
  End Sub
  Protected Sub TBLtaD_GuestHouseDA_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLtaD_GuestHouseDA.Init
    SetToolBar = TBLtaD_GuestHouseDA
  End Sub
  Protected Sub FVtaD_GuestHouseDA_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVtaD_GuestHouseDA.DataBound
    SIS.TA.taD_GuestHouseDA.SetDefaultValues(sender, e) 
  End Sub
  Protected Sub FVtaD_GuestHouseDA_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVtaD_GuestHouseDA.PreRender
    Dim oF_CategoryID As LC_taCategories = FVtaD_GuestHouseDA.FindControl("F_CategoryID")
    oF_CategoryID.Enabled = True
    oF_CategoryID.SelectedValue = String.Empty
    If Not Session("F_CategoryID") Is Nothing Then
      If Session("F_CategoryID") <> String.Empty Then
        oF_CategoryID.SelectedValue = Session("F_CategoryID")
      End If
    End If
    Dim oF_CityID_Display As Label  = FVtaD_GuestHouseDA.FindControl("F_CityID_Display")
    oF_CityID_Display.Text = String.Empty
    If Not Session("F_CityID_Display") Is Nothing Then
      If Session("F_CityID_Display") <> String.Empty Then
        oF_CityID_Display.Text = Session("F_CityID_Display")
      End If
    End If
    Dim oF_CityID As TextBox  = FVtaD_GuestHouseDA.FindControl("F_CityID")
    oF_CityID.Enabled = True
    oF_CityID.Text = String.Empty
    If Not Session("F_CityID") Is Nothing Then
      If Session("F_CityID") <> String.Empty Then
        oF_CityID.Text = Session("F_CityID")
      End If
    End If
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/TA_Main/App_Create") & "/AF_taD_GuestHouseDA.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scripttaD_GuestHouseDA") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scripttaD_GuestHouseDA", mStr)
    End If
    If Request.QueryString("SerialNo") IsNot Nothing Then
      CType(FVtaD_GuestHouseDA.FindControl("F_SerialNo"), TextBox).Text = Request.QueryString("SerialNo")
      CType(FVtaD_GuestHouseDA.FindControl("F_SerialNo"), TextBox).Enabled = False
    End If
  End Sub
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function CityIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.TA.taCities.SelecttaCitiesAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_TA_D_GuestHouseDA_CityID(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
    Dim CityID As String = CType(aVal(1),String)
    Dim oVar As SIS.TA.taCities = SIS.TA.taCities.taCitiesGetByID(CityID)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found." 
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function

End Class
