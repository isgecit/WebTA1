Imports System.Web.Script.Serialization
Partial Class EF_qcmRequests
  Inherits SIS.SYS.UpdateBase
  Public Property Editable() As Boolean
    Get
      If ViewState("Editable") IsNot Nothing Then
        Return CType(ViewState("Editable"), Boolean)
      End If
      Return False
    End Get
    Set(ByVal value As Boolean)
      ViewState.Add("Editable", value)
    End Set
  End Property
  Public Property RequestID() As Integer
    Get
      If ViewState("RequestID") IsNot Nothing Then
        Return CType(ViewState("RequestID"), Integer)
      End If
      Return 0
    End Get
    Set(ByVal value As Integer)
      ViewState.Add("RequestID", value)
    End Set
  End Property
  Dim oRequest As SIS.QCM.qcmRequests = Nothing
  Protected Sub ODSqcmRequests_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODSqcmRequests.Selected
    oRequest = CType(e.ReturnValue, SIS.QCM.qcmRequests)
    Editable = False
    Select Case oRequest.RequestStateID
      Case "OPEN", "RETURNED"
        Editable = True
    End Select
  End Sub
  Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    If Not Page.IsCallback And Not Page.IsPostBack Then
      RequestID = Request.QueryString("REquestID")
    End If
  End Sub
  Protected Sub cmdFileUpload_Command(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.CommandEventArgs) Handles cmdFileUpload.Command
    With F_FileUpload
      If .HasFile Then
        Dim oAT As SIS.QCM.qcmRequestFiles = New SIS.QCM.qcmRequestFiles
        Dim oRm As Random = New Random
        oAT.RequestID = RequestID
        oAT.FileName = .FileName
        oAT.DiskFIleName = oAT.RequestID & oRm.Next(1000, 99999999)
        Dim tPath As String = ""
        Try
          If IO.Directory.Exists(ConfigurationManager.AppSettings("RequestDir")) Then
            tPath = ConfigurationManager.AppSettings("RequestDir")
          ElseIf IO.Directory.Exists(ConfigurationManager.AppSettings("RequestDir1")) Then
            tPath = ConfigurationManager.AppSettings("RequestDir1")
          End If
        Catch ex As Exception
        End Try
        If tPath = "" Then
          ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", String.Format("alert({0});", "File repository not defined."), True)
          Exit Sub
        End If
        .SaveAs(tPath & "\" & oAT.DiskFIleName)
        oAT = SIS.QCM.qcmRequestFiles.InsertData(oAT)
        GVqcmRequestFiles.DataBind()
      End If
    End With
  End Sub
  Protected Sub GVqcmRequestFiles_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVqcmRequestFiles.RowCommand
    If e.CommandName.ToLower = "remove" Then
      Try
        Dim RequestID As Int32 = GVqcmRequestFiles.DataKeys(e.CommandArgument).Values("RequestID")
        Dim SerialNo As Int32 = GVqcmRequestFiles.DataKeys(e.CommandArgument).Values("SerialNo")
        Dim oAT As SIS.QCM.qcmRequestFiles = SIS.QCM.qcmRequestFiles.qcmRequestFilesGetByID(RequestID, SerialNo)
        Try
          Dim tPath As String = ""
          Try
            If IO.Directory.Exists(ConfigurationManager.AppSettings("RequestDir")) Then
              tPath = ConfigurationManager.AppSettings("RequestDir")
            ElseIf IO.Directory.Exists(ConfigurationManager.AppSettings("RequestDir1")) Then
              tPath = ConfigurationManager.AppSettings("RequestDir1")
            End If
          Catch ex As Exception
          End Try
          IO.File.Delete(tPath & "\" & oAT.DiskFIleName)
        Catch ex As Exception
        End Try
        SIS.QCM.qcmRequestFiles.Delete(oAT)
        GVqcmRequestFiles.DataBind()
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", String.Format("alert({0});", "File repository not defined."), True)
      End Try
    End If
  End Sub

  Protected Sub FVqcmRequests_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVqcmRequests.Init
    DataClassName = "EqcmRequests"
    SetFormView = FVqcmRequests
  End Sub
  Protected Sub TBLqcmRequests_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLqcmRequests.Init
    SetToolBar = TBLqcmRequests
  End Sub
  <System.Web.Services.WebMethod()>
  <System.Web.Script.Services.ScriptMethod()>
  Public Shared Function ProjectIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.QCM.qcmProjects.SelectqcmProjectsAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()>
  <System.Web.Script.Services.ScriptMethod()>
  Public Shared Function SupplierIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.QCM.qcmVendors.SelectqcmVendorsAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()>
  <System.Web.Script.Services.ScriptMethod()>
  Public Shared Function ReceivedByCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.QCM.qcmEmployees.SelectqcmEmployeesAutoCompleteList(prefixText, count, contextKey)
  End Function
  Protected Sub FVqcmRequests_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVqcmRequests.PreRender
    Dim IsAdmin As Boolean = SIS.SYS.Utilities.SessionManager.IsAdmin
    If Not IsAdmin Then
      Dim r As HtmlTableRow = FVqcmRequests.FindControl("r_supplier")
      r.Attributes.Add("display", "none")
    End If
    If Not Editable Then
      TBLqcmRequests.EnableSave = False
      TBLqcmRequests.EnableDelete = False
    End If
    Dim omevSdt As AjaxControlToolkit.MaskedEditValidator = FVqcmRequests.FindControl("MEVRequestedInspectionStartDate")
    If Now.Hour >= 11 Then
      With omevSdt
        .MinimumValue = Now.AddDays(1).ToString("dd/MM/yyyy")
        .MinimumValueMessage = "After 11:00 AM, Requested start date can not be less than day after tomorrow's Date"
        .MinimumValueBlurredText = "Invalid Start Date."
      End With
    Else
      With omevSdt
        .MinimumValue = Now.ToString("dd/MM/yyyy")
        .MinimumValueMessage = "Requested start date can not be less than tomorrow's date"
        .MinimumValueBlurredText = "Invalid Start Date."
      End With
    End If
    If oRequest IsNot Nothing Then
      Dim a As TextBox = FVqcmRequests.FindControl("F_TotalRequestedQuantity")
      Dim b As TextBox = FVqcmRequests.FindControl("F_LotSize")
      Dim c As RequiredFieldValidator = FVqcmRequests.FindControl("RFVTotalRequestedQuantity")
      Dim d As RequiredFieldValidator = FVqcmRequests.FindControl("RFVLotSize")
      If oRequest.InspectionStageiD = "1" Then
        a.Enabled = True
        a.CssClass = "mytxt"
        c.Enabled = True
        b.Enabled = False
        b.CssClass = "dmytxt"
        d.Enabled = False
      ElseIf oRequest.InspectionStageiD = "2" Then
        b.Enabled = True
        b.CssClass = "mytxt"
        d.Enabled = True
        a.Enabled = False
        a.CssClass = "dmytxt"
        c.Enabled = False
      Else
        a.Enabled = True
        a.CssClass = "mytxt"
        b.Enabled = True
        b.CssClass = "mytxt"
        c.Enabled = True
        d.Enabled = True
      End If
    End If
    Dim mStr As String = "<script type=""text/javascript""> "
    mStr = mStr & vbCrLf & " var script_qcmRequests = {"
    Dim oF_SupplierID_Display As Label = FVqcmRequests.FindControl("F_SupplierID_Display")
    Dim oF_SupplierID As TextBox = FVqcmRequests.FindControl("F_SupplierID")
    mStr = mStr & vbCrLf & "ACESupplierID_Selected: function(sender, e) {"
    mStr = mStr & vbCrLf & "  var F_SupplierID = $get('" & oF_SupplierID.ClientID & "');"
    mStr = mStr & vbCrLf & "  var F_SupplierID_Display = $get('" & oF_SupplierID_Display.ClientID & "');"
    mStr = mStr & vbCrLf & "  var retval = e.get_value();"
    mStr = mStr & vbCrLf & "  var p = retval.split('|');"
    mStr = mStr & vbCrLf & "  F_SupplierID.value = p[0];"
    mStr = mStr & vbCrLf & "  F_SupplierID_Display.innerHTML = e.get_text();"
    mStr = mStr & vbCrLf & "},"
    mStr = mStr & vbCrLf & "ACESupplierID_Populating: function(o,e) {"
    mStr = mStr & vbCrLf & "  var p = o.get_element();"
    mStr = mStr & vbCrLf & "  p.style.backgroundImage  = 'url(../../images/loader.gif)';"
    mStr = mStr & vbCrLf & "  p.style.backgroundRepeat= 'no-repeat';"
    mStr = mStr & vbCrLf & "  p.style.backgroundPosition = 'right';"
    mStr = mStr & vbCrLf & "  o._contextKey = '';"
    mStr = mStr & vbCrLf & "},"
    mStr = mStr & vbCrLf & "ACESupplierID_Populated: function(o,e) {"
    mStr = mStr & vbCrLf & "  var p = o.get_element();"
    mStr = mStr & vbCrLf & "  p.style.backgroundImage  = 'none';"
    mStr = mStr & vbCrLf & "},"
    mStr = mStr & vbCrLf & "validate_SupplierID: function(o) {"
    mStr = mStr & vbCrLf & "  this.validated_FK_QCM_Requests_SupplierID_main = true;"
    mStr = mStr & vbCrLf & "  this.validate_FK_QCM_Requests_SupplierID(o);"
    mStr = mStr & vbCrLf & "  },"
    mStr = mStr & vbCrLf & "validate_ReceivedBy: function(o) {"
    mStr = mStr & vbCrLf & "  this.validated_FK_QCM_Requests_ReceivedBy_main = true;"
    mStr = mStr & vbCrLf & "  this.validate_FK_QCM_Requests_ReceivedBy(o);"
    mStr = mStr & vbCrLf & "  },"
    Dim FK_QCM_Requests_SupplierIDSupplierID As TextBox = FVqcmRequests.FindControl("F_SupplierID")
    mStr = mStr & vbCrLf & "validate_FK_QCM_Requests_SupplierID: function(o) {"
    mStr = mStr & vbCrLf & "  var value = o.id;"
    mStr = mStr & vbCrLf & "  var SupplierID = $get('" & FK_QCM_Requests_SupplierIDSupplierID.ClientID & "');"
    mStr = mStr & vbCrLf & "  if(SupplierID.value==''){"
    mStr = mStr & vbCrLf & "    if(this.validated_FK_QCM_Requests_SupplierID_main){"
    mStr = mStr & vbCrLf & "      var o_d = $get(o.id +'_Display');"
    mStr = mStr & vbCrLf & "      try{o_d.innerHTML = '';}catch(ex){}"
    mStr = mStr & vbCrLf & "    }"
    mStr = mStr & vbCrLf & "    return true;"
    mStr = mStr & vbCrLf & "  }"
    mStr = mStr & vbCrLf & "  value = value + ',' + SupplierID.value ;"
    mStr = mStr & vbCrLf & "    o.style.backgroundImage  = 'url(../../images/pkloader.gif)';"
    mStr = mStr & vbCrLf & "    o.style.backgroundRepeat= 'no-repeat';"
    mStr = mStr & vbCrLf & "    o.style.backgroundPosition = 'right';"
    mStr = mStr & vbCrLf & "    PageMethods.validate_FK_QCM_Requests_SupplierID(value, this.validated_FK_QCM_Requests_SupplierID);"
    mStr = mStr & vbCrLf & "  },"
    mStr = mStr & vbCrLf & "validated_FK_QCM_Requests_SupplierID_main: false,"
    Dim oF_CreationRemarks As TextBox = FVqcmRequests.FindControl("F_CreationRemarks")
    mStr = mStr & vbCrLf & "validated_FK_QCM_Requests_SupplierID: function(result) {"
    mStr = mStr & vbCrLf & "  var p = result.split('|');"
    mStr = mStr & vbCrLf & "  var o = $get(p[1]);"
    mStr = mStr & vbCrLf & "  var q = $get('" & oF_CreationRemarks.ClientID & "');"
    mStr = mStr & vbCrLf & "  if(script_qcmRequests.validated_FK_QCM_Requests_SupplierID_main){"
    mStr = mStr & vbCrLf & "    var o_d = $get(p[1]+'_Display');"
    mStr = mStr & vbCrLf & "    try{o_d.innerHTML = p[2];}catch(ex){}"
    mStr = mStr & vbCrLf & "    q.value=p[3];"
    mStr = mStr & vbCrLf & "  }"
    mStr = mStr & vbCrLf & "  o.style.backgroundImage  = 'none';"
    mStr = mStr & vbCrLf & "  if(p[0]=='1'){"
    mStr = mStr & vbCrLf & "    q.value='';"
    mStr = mStr & vbCrLf & "    o.value='';"
    mStr = mStr & vbCrLf & "    o.focus();"
    mStr = mStr & vbCrLf & "  }"
    mStr = mStr & vbCrLf & "},"
    mStr = mStr & vbCrLf & "		ACERegionID_Selected: function(sender, e) {"
    mStr = mStr & vbCrLf & "		  var Prefix = sender._element.id.replace('RegionID','');"
    mStr = mStr & vbCrLf & "		  var F_RegionID = $get(sender._element.id);"
    mStr = mStr & vbCrLf & "		  var F_RegionID_Display = $get(sender._element.id + '_Display');"
    mStr = mStr & vbCrLf & "		  var retval = e.get_value();"
    mStr = mStr & vbCrLf & "		  var p = retval.split('|');"
    mStr = mStr & vbCrLf & "		  F_RegionID.value = p[0];"
    mStr = mStr & vbCrLf & "		  F_RegionID_Display.innerHTML = e.get_text();"
    mStr = mStr & vbCrLf & "		},"
    mStr = mStr & vbCrLf & "		ACERegionID_Populating: function(sender,e) {"
    mStr = mStr & vbCrLf & "		  var p = sender.get_element();"
    mStr = mStr & vbCrLf & "		  var Prefix = sender._element.id.replace('RegionID','');"
    mStr = mStr & vbCrLf & "		  p.style.backgroundImage  = 'url(../../images/loader.gif)';"
    mStr = mStr & vbCrLf & "		  p.style.backgroundRepeat= 'no-repeat';"
    mStr = mStr & vbCrLf & "		  p.style.backgroundPosition = 'right';"
    mStr = mStr & vbCrLf & "		  sender._contextKey = '';"
    mStr = mStr & vbCrLf & "		},"
    mStr = mStr & vbCrLf & "		ACERegionID_Populated: function(sender,e) {"
    mStr = mStr & vbCrLf & "		  var p = sender.get_element();"
    mStr = mStr & vbCrLf & "		  p.style.backgroundImage  = 'none';"
    mStr = mStr & vbCrLf & "		},"
    mStr = mStr & vbCrLf & "		validate_RegionID: function(sender) {"
    mStr = mStr & vbCrLf & "		  var Prefix = sender.id.replace('RegionID','');"
    mStr = mStr & vbCrLf & "		  this.validated_FK_QCM_Requests_RegionID_main = true;"
    mStr = mStr & vbCrLf & "		  this.validate_FK_QCM_Requests_RegionID(sender,Prefix);"
    mStr = mStr & vbCrLf & "		  },"
    mStr = mStr & vbCrLf & "		validate_FK_QCM_Requests_RegionID: function(o,Prefix) {"
    mStr = mStr & vbCrLf & "		  var value = o.id;"
    mStr = mStr & vbCrLf & "		  var RegionID = $get(Prefix + 'RegionID');"
    mStr = mStr & vbCrLf & "		  if(RegionID.value==''){"
    mStr = mStr & vbCrLf & "		    if(this.validated_FK_QCM_Requests_RegionID_main){"
    mStr = mStr & vbCrLf & "		      var o_d = $get(Prefix + 'RegionID' + '_Display');"
    mStr = mStr & vbCrLf & "		      try{o_d.innerHTML = '';}catch(ex){}"
    mStr = mStr & vbCrLf & "		    }"
    mStr = mStr & vbCrLf & "		    return true;"
    mStr = mStr & vbCrLf & "		  }"
    mStr = mStr & vbCrLf & "		  value = value + ',' + RegionID.value ;"
    mStr = mStr & vbCrLf & "		    o.style.backgroundImage  = 'url(../../images/pkloader.gif)';"
    mStr = mStr & vbCrLf & "		    o.style.backgroundRepeat= 'no-repeat';"
    mStr = mStr & vbCrLf & "		    o.style.backgroundPosition = 'right';"
    mStr = mStr & vbCrLf & "		    PageMethods.validate_FK_QCM_Requests_RegionID(value, this.validated_FK_QCM_Requests_RegionID);"
    mStr = mStr & vbCrLf & "		  },"
    mStr = mStr & vbCrLf & "		validated_FK_QCM_Requests_RegionID_main: false,"
    mStr = mStr & vbCrLf & "		validated_FK_QCM_Requests_RegionID: function(result) {"
    mStr = mStr & vbCrLf & "		  var p = result.split('|');"
    mStr = mStr & vbCrLf & "		  var o = $get(p[1]);"
    mStr = mStr & vbCrLf & "		  if(script_qcmRequests.validated_FK_QCM_Requests_RegionID_main){"
    mStr = mStr & vbCrLf & "		    var o_d = $get(p[1]+'_Display');"
    mStr = mStr & vbCrLf & "		    try{o_d.innerHTML = p[2];}catch(ex){}"
    mStr = mStr & vbCrLf & "		  }"
    mStr = mStr & vbCrLf & "		  o.style.backgroundImage  = 'none';"
    mStr = mStr & vbCrLf & "		  if(p[0]=='1'){"
    mStr = mStr & vbCrLf & "		    o.value='';"
    mStr = mStr & vbCrLf & "		    o.focus();"
    mStr = mStr & vbCrLf & "		  }"
    mStr = mStr & vbCrLf & "		},"
    mStr = mStr & vbCrLf & "temp: function() {"
    mStr = mStr & vbCrLf & "}"
    mStr = mStr & vbCrLf & "}"
    mStr = mStr & vbCrLf & "</script>"
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptqcmRequests") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptqcmRequests", mStr)
    End If
  End Sub
  <System.Web.Services.WebMethod()>
  Public Shared Function validate_FK_QCM_Requests_SupplierID(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String = "0|" & aVal(0)
    Dim SupplierID As String = CType(aVal(1), String)
    Dim oVar As SIS.QCM.qcmVendors = SIS.QCM.qcmVendors.qcmVendorsGetByID(SupplierID)
    Dim PlaceToVisit As String = ""
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found." & "|" & PlaceToVisit
    Else
      PlaceToVisit = " " & oVar.Description.Trim & vbCrLf & " " & oVar.Address1.Trim & vbCrLf & " " & oVar.Address2.Trim & vbCrLf & " " & oVar.Address3.Trim & vbCrLf & " " & oVar.Address4.Trim
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField & "|" & PlaceToVisit
    End If
    Return mRet
  End Function
  <System.Web.Services.WebMethod()>
  <System.Web.Script.Services.ScriptMethod()>
  Public Shared Function RegionIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.QCM.qcmRegions.SelectqcmRegionsAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()>
  Public Shared Function validate_FK_QCM_Requests_RegionID(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String = "0|" & aVal(0)
    Dim RegionID As Int32 = CType(aVal(1), Int32)
    Dim oVar As SIS.QCM.qcmRegions = SIS.QCM.qcmRegions.qcmRegionsGetByID(RegionID)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found."
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField
    End If
    Return mRet
  End Function

  Private Sub FVqcmRequests_ItemUpdating(sender As Object, e As FormViewUpdateEventArgs) Handles FVqcmRequests.ItemUpdating
    Dim tmpDate As String = e.NewValues("RequestedInspectionStartDate")
    Try
      If Convert.ToDateTime(tmpDate).DayOfWeek = DayOfWeek.Sunday Then
        Dim message As String = New JavaScriptSerializer().Serialize("You can not request for Sunday. Pl. request for week days.")
        Dim script As String = String.Format("alert({0});", message)
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", script, True)
        e.Cancel = True
      End If
    Catch ex As Exception

    End Try
  End Sub
  Protected Sub POSelected(s As Object, e As EventArgs)
    Dim x As CheckBox = CType(s, CheckBox)
    Dim P As TextBox = CType(FVqcmRequests.FindControl("F_OrderNo"), TextBox)
    If x.Checked Then
      If P.Text.IndexOf(x.Text) < 0 Then
        If P.Text = "" Then P.Text = x.Text Else P.Text = P.Text & "," & x.Text
      End If
    Else
      Dim found As Boolean = False
      If P.Text.IndexOf(x.Text) >= 0 Then
        Dim aPOs() As String = P.Text.Split(",".ToCharArray)
        For I As Integer = 0 To aPOs.Length - 1
          If x.Text = aPOs(I) Then
            aPOs(I) = ""
            Exit For
          End If
        Next
        P.Text = ""
        For Each po As String In aPOs
          If po <> "" Then
            If P.Text = "" Then P.Text = po Else P.Text = P.Text & "," & po
          End If
        Next
      End If
    End If
  End Sub

  Private Sub FVqcmRequests_ItemCommand(sender As Object, e As FormViewCommandEventArgs) Handles FVqcmRequests.ItemCommand
    If e.CommandName.ToLower = "GetSupplierPO".ToLower Then
      Dim x As Repeater = CType(FVqcmRequests.FindControl("POCheckBoxList"), Repeater)
      x.DataBind()
    End If
  End Sub
End Class
