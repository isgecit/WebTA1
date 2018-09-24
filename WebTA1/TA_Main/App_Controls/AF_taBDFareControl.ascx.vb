Imports System
Imports System.Data
Imports System.Configuration
Imports System.Collections
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls
<ValidationProperty("SelectedValue")>
Partial Class AF_taBDFareControl
  Inherits SIS.SYS.InsertBaseControl
  Public Event lgInserted()
  Public Event lgError(ByVal Message As String)
  Public Property SelectedValue As String = ""
  Public Sub Show()
    Me.pPopup.Show()
  End Sub
  Public Sub Hide()
    Me.pPopup.Hide()
  End Sub
  Protected Sub FVtaBDFare_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVtaBDFare.Init
    DataClassName = "AtaBDFare"
    SetFormView = FVtaBDFare
  End Sub
  Protected Sub TBLtaBDFare_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLtaBDFare.Init
    SetToolBar = TBLtaBDFare
  End Sub
  Protected Sub FVtaBDFare_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVtaBDFare.DataBound
    SIS.TA.taBDFare.SetDefaultValues(sender, e)
  End Sub
  Protected Sub FVtaBDFare_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVtaBDFare.PreRender
    Dim oF_TABillNo_Display As Label = FVtaBDFare.FindControl("F_TABillNo_Display")
    oF_TABillNo_Display.Text = String.Empty
    If Not HttpContext.Current.Session("F_TABillNo_Display") Is Nothing Then
      If HttpContext.Current.Session("F_TABillNo_Display") <> String.Empty Then
        oF_TABillNo_Display.Text = HttpContext.Current.Session("F_TABillNo_Display")
      End If
    End If
    Dim oF_TABillNo As TextBox = FVtaBDFare.FindControl("F_TABillNo")
    oF_TABillNo.Enabled = True
    oF_TABillNo.Text = String.Empty
    If Not HttpContext.Current.Session("F_TABillNo") Is Nothing Then
      If HttpContext.Current.Session("F_TABillNo") <> String.Empty Then
        oF_TABillNo.Text = HttpContext.Current.Session("F_TABillNo")
      End If
    End If
    Dim oF_City1ID_Display As Label = FVtaBDFare.FindControl("F_City1ID_Display")
    Dim oF_City1ID As TextBox = FVtaBDFare.FindControl("F_City1ID")
    Dim oF_City2ID_Display As Label = FVtaBDFare.FindControl("F_City2ID_Display")
    Dim oF_City2ID As TextBox = FVtaBDFare.FindControl("F_City2ID")
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/TA_Main/App_Create") & "/AF_taBDFare.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scripttaBDFare") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scripttaBDFare", mStr)
    End If
    If HttpContext.Current.Request.QueryString("TABillNo") IsNot Nothing Then
      CType(FVtaBDFare.FindControl("F_TABillNo"), TextBox).Text = HttpContext.Current.Request.QueryString("TABillNo")
      CType(FVtaBDFare.FindControl("F_TABillNo"), TextBox).Enabled = False
    End If
    If HttpContext.Current.Request.QueryString("SerialNo") IsNot Nothing Then
      CType(FVtaBDFare.FindControl("F_SerialNo"), TextBox).Text = HttpContext.Current.Request.QueryString("SerialNo")
      CType(FVtaBDFare.FindControl("F_SerialNo"), TextBox).Enabled = False
    End If
  End Sub
  <System.Web.Services.WebMethod()>
  <System.Web.Script.Services.ScriptMethod()>
  Public Shared Function TABillNoCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.TA.taBH.SelecttaBHAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()>
  <System.Web.Script.Services.ScriptMethod()>
  Public Shared Function City1IDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.TA.taCities.SelecttaCitiesAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()>
  <System.Web.Script.Services.ScriptMethod()>
  Public Shared Function City2IDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.TA.taCities.SelecttaCitiesAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()>
  Public Shared Function validate_FK_TA_BillDetails_TABillNo(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String = "0|" & aVal(0)
    Dim TABillNo As Int32 = CType(aVal(1), Int32)
    Dim oVar As SIS.TA.taBH = SIS.TA.taBH.taBHGetByID(TABillNo)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found."
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField
    End If
    Return mRet
  End Function
  <System.Web.Services.WebMethod()>
  Public Shared Function validate_FK_TA_BillDetails_City1ID(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String = "0|" & aVal(0)
    Dim City1ID As String = CType(aVal(1), String)
    Dim oVar As SIS.TA.taCities = SIS.TA.taCities.taCitiesGetByID(City1ID)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found."
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField
    End If
    Return mRet
  End Function
  <System.Web.Services.WebMethod()>
  Public Shared Function validate_FK_TA_BillDetails_City2ID(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String = "0|" & aVal(0)
    Dim City2ID As String = CType(aVal(1), String)
    Dim oVar As SIS.TA.taCities = SIS.TA.taCities.taCitiesGetByID(City2ID)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found."
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField
    End If
    Return mRet
  End Function

  Private Sub AF_taBDFareControl_DataInserted() Handles Me.DataInserted
    RaiseEvent lgInserted()
  End Sub

  Private Sub AF_taBDFareControl_InsertError(Message As String) Handles Me.InsertError
    RaiseEvent lgError(Message)
  End Sub
End Class
