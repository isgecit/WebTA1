Imports System.Web.Script.Serialization
Imports System.Data
Imports System.Data.SqlClient
Partial Class AF_taBH
  Inherits SIS.SYS.InsertBase
  Public Property SiteEmployee As Boolean
    Get
      If ViewState("SiteEmployee") IsNot Nothing Then
        Return Convert.ToBoolean(ViewState("SiteEmployee"))
      End If
      Return False
    End Get
    Set(value As Boolean)
      ViewState.Add("SiteEmployee", value)
    End Set
  End Property
  Protected Sub cmdRequest_Click(sender As Object, e As EventArgs)
    SIS.TA.taBH.SendRequestEMail()
  End Sub
  Protected Sub FVtaBH_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVtaBH.Init
    DataClassName = "AtaBH"
    SetFormView = FVtaBH
  End Sub
  Protected Sub TBLtaBH_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLtaBH.Init
    SetToolBar = TBLtaBH
  End Sub
  Protected Sub ODStaBH_Inserted(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODStaBH.Inserted
    If e.Exception Is Nothing Then
      Dim oDC As SIS.TA.taBH = CType(e.ReturnValue, SIS.TA.taBH)
      Dim tmpURL As String = "?tmp=1"
      tmpURL &= "&TABillNo=" & oDC.TABillNo
      TBLtaBH.AfterInsertURL &= tmpURL
    End If
  End Sub
  Protected Sub FVtaBH_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVtaBH.DataBound
    SIS.TA.taBH.SetDefaultValues(sender, e)
  End Sub
  Protected Sub FVtaBH_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVtaBH.PreRender
    Try
      Dim oF_TravelTypeID As LC_taTravelTypes = FVtaBH.FindControl("F_TravelTypeID")
      oF_TravelTypeID.Enabled = True
      oF_TravelTypeID.SelectedValue = String.Empty
      If Not Session("F_TravelTypeID") Is Nothing Then
        If Session("F_TravelTypeID") <> String.Empty Then
          oF_TravelTypeID.SelectedValue = Session("F_TravelTypeID")
        End If
      End If
      Dim oF_CityOfOrigin_Display As Label = FVtaBH.FindControl("F_CityOfOrigin_Display")
      Dim oF_CityOfOrigin As TextBox = FVtaBH.FindControl("F_CityOfOrigin")
      Dim oF_DestinationCity_Display As Label = FVtaBH.FindControl("F_DestinationCity_Display")
      oF_DestinationCity_Display.Text = String.Empty
      If Not Session("F_DestinationCity_Display") Is Nothing Then
        If Session("F_DestinationCity_Display") <> String.Empty Then
          oF_DestinationCity_Display.Text = Session("F_DestinationCity_Display")
        End If
      End If
      Dim oF_DestinationCity As TextBox = FVtaBH.FindControl("F_DestinationCity")
      oF_DestinationCity.Enabled = True
      oF_DestinationCity.Text = String.Empty
      If Not Session("F_DestinationCity") Is Nothing Then
        If Session("F_DestinationCity") <> String.Empty Then
          oF_DestinationCity.Text = Session("F_DestinationCity")
        End If
      End If
      Dim oF_ProjectID_Display As Label = FVtaBH.FindControl("F_ProjectID_Display")
      oF_ProjectID_Display.Text = String.Empty
      If Not Session("F_ProjectID_Display") Is Nothing Then
        If Session("F_ProjectID_Display") <> String.Empty Then
          oF_ProjectID_Display.Text = Session("F_ProjectID_Display")
        End If
      End If
      Dim oF_ProjectID As TextBox = FVtaBH.FindControl("F_ProjectID")
      oF_ProjectID.Enabled = True
      oF_ProjectID.Text = String.Empty
      If Not Session("F_ProjectID") Is Nothing Then
        If Session("F_ProjectID") <> String.Empty Then
          oF_ProjectID.Text = Session("F_ProjectID")
        End If
      End If

    Catch ex As Exception

    End Try
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/TA_Main/App_Create") & "/AF_taBH.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scripttaBH") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scripttaBH", mStr)
    End If
    If Request.QueryString("TABillNo") IsNot Nothing Then
      CType(FVtaBH.FindControl("F_TABillNo"), TextBox).Text = Request.QueryString("TABillNo")
      CType(FVtaBH.FindControl("F_TABillNo"), TextBox).Enabled = False
    End If
    Dim oEmp As SIS.TA.taEmployees = SIS.TA.taEmployees.taEmployeesGetByID(HttpContext.Current.Session("LoginID"))
    Try
      CType(FVtaBH.FindControl("L_TACategory"), Label).Text = oEmp.FK_HRM_Employees_CategoryID.CategoryDescription
    Catch ex As Exception
    End Try
    Try
      CType(FVtaBH.FindControl("L_Verifier"), Label).Text = oEmp.TAVerifier & " " & oEmp.FK_HRM_Employees_TAVerifier.EmployeeName
    Catch ex As Exception
    End Try
    Try
      CType(FVtaBH.FindControl("L_Approver"), Label).Text = oEmp.TAApprover & " " & oEmp.FK_HRM_Employees_TAApprover.EmployeeName
    Catch ex As Exception
    End Try
    Try
      CType(FVtaBH.FindControl("L_SanctioningAuthority"), Label).Text = oEmp.TASanctioningAuthority & " " & oEmp.FK_HRM_Employees_TASanctioningAuthority.EmployeeName
    Catch ex As Exception
    End Try
    Try
      'Site Employee
      If oEmp.C_OfficeID = "6" Then
        SiteEmployee = True
      Else
        SiteEmployee = False
      End If
      CType(FVtaBH.FindControl("R_SiteName"), HtmlTableRow).Visible = SiteEmployee
    Catch ex As Exception

    End Try
  End Sub
  <System.Web.Services.WebMethod()>
  <System.Web.Script.Services.ScriptMethod()>
  Public Shared Function CityOfOriginCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.TA.taCities.SelecttaCitiesAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()>
  <System.Web.Script.Services.ScriptMethod()>
  Public Shared Function DestinationCityCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.TA.taCities.SelecttaCitiesAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()>
  <System.Web.Script.Services.ScriptMethod()>
  Public Shared Function ProjectIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.QCM.qcmProjects.SelectqcmProjectsAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()>
  Public Shared Function validate_FK_TA_Bills_ProjectID(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String = "0|" & aVal(0)
    Dim ProjectID As String = CType(aVal(1), String)
    Dim oVar As SIS.QCM.qcmProjects = SIS.QCM.qcmProjects.qcmProjectsGetByID(ProjectID)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found."
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField
    End If
    Return mRet
  End Function
  <System.Web.Services.WebMethod()>
  Public Shared Function validate_FK_TA_Bills_DestinationCity(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String = "0|" & aVal(0)
    Dim DestinationCity As String = CType(aVal(1), String)
    Dim oVar As SIS.TA.taCities = SIS.TA.taCities.taCitiesGetByID(DestinationCity)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found."
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField
    End If
    Return mRet
  End Function
  <System.Web.Services.WebMethod()>
  Public Shared Function validate_FK_TA_Bills_CityOfOrigin(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String = "0|" & aVal(0)
    Dim CityOfOrigin As String = CType(aVal(1), String)
    Dim oVar As SIS.TA.taCities = SIS.TA.taCities.taCitiesGetByID(CityOfOrigin)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found."
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField
    End If
    Return mRet
  End Function

  Private Sub FVtaBH_ItemInserting(sender As Object, e As FormViewInsertEventArgs) Handles FVtaBH.ItemInserting
    Dim TravelTypeID As String = e.Values("TravelTypeID")
    If TravelTypeID = TATravelTypeValues.HomeVisit Then
      Dim oEmp As SIS.TA.taEmployees = SIS.TA.taEmployees.taEmployeesGetByID(HttpContext.Current.Session("LoginID"))
      If oEmp.C_OfficeID <> "6" Then
        Dim mStr As String = "Only Site Employees can Claim HOME VISIT."
        Dim str As String = New JavaScriptSerializer().Serialize(mStr)
        Dim script As String = String.Format("alert({0});", str)
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", script, True)
        e.Cancel = True
      Else
        Dim cnt As Integer = 0
        Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
          Using Cmd As SqlCommand = Con.CreateCommand()
            Cmd.CommandType = CommandType.Text
            Cmd.CommandText = "select ISNULL(Count(TABillNo),0) as CNT from TA_Bills where TravelTypeID = 4 and year(StartDateTime) = " & Now.Year & " and EmployeeID = '" & oEmp.CardNo & "'"
            Con.Open()
            cnt = Cmd.ExecuteScalar
          End Using
        End Using
        If cnt >= 2 Then
          Dim mStr As String = "Only Two HOME VISIT can be claimed in a Year."
          Dim str As String = New JavaScriptSerializer().Serialize(mStr)
          Dim script As String = String.Format("alert({0});", str)
          ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", script, True)
          e.Cancel = True
        End If
      End If
    End If
  End Sub
End Class
