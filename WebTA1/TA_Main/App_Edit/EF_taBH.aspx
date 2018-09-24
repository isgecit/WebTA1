<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_taBH.aspx.vb" Inherits="EF_taBH" title="Edit: Travel Expense Statements" %>
<asp:Content ID="CPHtaBH" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabeltaBH" runat="server" Text="&nbsp;Edit: Travel Expense Statements"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLtaBH" runat="server" >
<ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLtaBH"
    ToolType = "lgNMEdit"
    UpdateAndStay = "False"
    EnablePrint = "True"
    PrintUrl = "../App_Print/RP_taBH.aspx?pk="
    ValidationGroup = "taBH"
    runat = "server" />
    <script type="text/javascript">
      var pcnt = 0;
      function print_report(o) {
        pcnt = pcnt + 1;
        var nam = 'wTask' + pcnt;
        window.open(o.alt, nam, 'left=20,top=20,width=1100,height=600,toolbar=1,resizable=1,scrollbars=1');
        return false;
      }
    </script>
<asp:FormView ID="FVtaBH"
  runat = "server"
  DataKeyNames = "TABillNo"
  DataSourceID = "ODStaBH"
  DefaultMode = "Edit" CssClass="sis_formview">
  <EditItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_TABillNo" runat="server" ForeColor="#CC6633" Text="TA Bill No :" /><span style="color:red">*</span></b>
        </td>
        <td>
          <asp:TextBox ID="F_TABillNo"
            Text='<%# Bind("TABillNo") %>'
            ToolTip="Value of TA Bill No."
            Enabled = "False"
            CssClass = "mypktxt"
            Width="88px"
            style="text-align: right"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_BillStatusID" runat="server" Text="Bill Status :" />&nbsp;
        </td>
        <td>
          <asp:TextBox
            ID = "F_BillStatusID"
            Width="88px"
            Text='<%# Bind("BillStatusID") %>'
            Enabled = "False"
            ToolTip="Value of Bill Status."
            CssClass = "dmyfktxt"
            Runat="Server" />
          <asp:Label
            ID = "F_BillStatusID_Display"
            Text='<%# Eval("TA_BillStates16_Description") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
      </tr>
      <tr >
        <td class="alignright">
          <asp:Label ID="Label1" runat="server" Text="TA Bill Verifier :" />&nbsp;
        </td>
        <td>
          <asp:TextBox
            ID = "F_TAVerifier"
            Width="88px"
            Text='<%# Eval("FK_TA_Bills_EmployeeID.TAVerifier") %>'
            Enabled = "False"
            CssClass = "dmyfktxt"
            Runat="Server" />
          <asp:Label
            ID = "Label2"
            Text='<%# Eval("FK_TA_Bills_EmployeeID.HRM_Employees6_EmployeeName") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
        <td class="alignright">
          <asp:Label ID="Label3" runat="server" Text="TA Bill Approver :" />&nbsp;
        </td>
        <td>
          <asp:TextBox
            ID = "F_TAApprover"
            Width="88px"
            Text='<%# Eval("FK_TA_Bills_EmployeeID.TAApprover") %>'
            Enabled = "False"
            CssClass = "dmyfktxt"
            Runat="Server" />
          <asp:Label
            ID = "Label4"
            Text='<%# Eval("FK_TA_Bills_EmployeeID.HRM_Employees7_EmployeeName") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
      </tr>
      <tr >
        <td class="alignright">
          <asp:Label ID="Label5" runat="server" Text="TA Bill Sanctioning Authority :" />&nbsp;
        </td>
        <td>
          <asp:TextBox
            ID = "F_TASanctioningAuthority"
            Width="88px"
            Text='<%# Eval("FK_TA_Bills_EmployeeID.TASanctioningAuthority") %>'
            Enabled = "False"
            CssClass = "dmyfktxt"
            Runat="Server" />
          <asp:Label
            ID = "Label6"
            Text='<%# Eval("FK_TA_Bills_EmployeeID.HRM_Employees9_EmployeeName") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
        <td class="alignright">
        </td>
        <td>
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr id="taBH_0"><td colspan="4" onclick="groupClicked(this);" class="groupHeader" >Employee Details</td></tr>
      <tr style="display:none">
        <td class="alignright">
          <asp:Label ID="L_EmployeeID" runat="server" Text="Employee ID :" />&nbsp;
        </td>
        <td>
          <asp:TextBox
            ID = "F_EmployeeID"
            Width="72px"
            Text='<%# Bind("EmployeeID") %>'
            Enabled = "False"
            ToolTip="Value of Employee ID."
            CssClass = "dmyfktxt"
            Runat="Server" />
          <asp:Label
            ID = "F_EmployeeID_Display"
            Text='<%# Eval("HRM_Employees5_EmployeeName") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_CompanyID" runat="server" Text="Company ID :" />&nbsp;
        </td>
        <td>
          <asp:TextBox
            ID = "F_CompanyID"
            Width="56px"
            Text='<%# Bind("CompanyID") %>'
            Enabled = "False"
            ToolTip="Value of Company ID."
            CssClass = "dmyfktxt"
            Runat="Server" />
          <asp:Label
            ID = "F_CompanyID_Display"
            Text='<%# Eval("HRM_Companies1_Description") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
      </tr>
      <tr  style="display:none">
        <td class="alignright">
          <asp:Label ID="L_DivisionID" runat="server" Text="Division ID :" />&nbsp;
        </td>
        <td>
          <asp:TextBox
            ID = "F_DivisionID"
            Width="56px"
            Text='<%# Bind("DivisionID") %>'
            Enabled = "False"
            ToolTip="Value of Division ID."
            CssClass = "dmyfktxt"
            Runat="Server" />
          <asp:Label
            ID = "F_DivisionID_Display"
            Text='<%# Eval("HRM_Divisions4_Description") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_DepartmentID" runat="server" Text="Department ID :" />&nbsp;
        </td>
        <td>
          <asp:TextBox
            ID = "F_DepartmentID"
            Width="56px"
            Text='<%# Bind("DepartmentID") %>'
            Enabled = "False"
            ToolTip="Value of Department ID."
            CssClass = "dmyfktxt"
            Runat="Server" />
          <asp:Label
            ID = "F_DepartmentID_Display"
            Text='<%# Eval("HRM_Departments2_Description") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
      </tr>
      <tr  style="display:none">
        <td class="alignright">
          <asp:Label ID="L_DesignationID" runat="server" Text="Designation ID :" />&nbsp;
        </td>
        <td>
          <asp:TextBox
            ID = "F_DesignationID"
            Width="88px"
            Text='<%# Bind("DesignationID") %>'
            Enabled = "False"
            ToolTip="Value of Designation ID."
            CssClass = "dmyfktxt"
            Runat="Server" />
          <asp:Label
            ID = "F_DesignationID_Display"
            Text='<%# Eval("HRM_Designations3_Description") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_TACategoryID" runat="server" Text="TA Category ID :" />&nbsp;
        </td>
        <td>
          <asp:TextBox
            ID = "F_TACategoryID"
            Width="88px"
            Text='<%# Bind("TACategoryID") %>'
            Enabled = "False"
            ToolTip="Value of TA Category ID."
            CssClass = "dmyfktxt"
            style="display:none"
            Runat="Server" />
          <asp:Label
            ID = "F_TACategoryID_Display"
            Text='<%# Eval("TA_Categories13_cmba") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
      </tr>
      <tr style="display:none">
        <td class="alignright">
          <asp:Label ID="L_Contractual" runat="server" Text="Contractual :" />&nbsp;
        </td>
        <td>
          <asp:CheckBox ID="F_Contractual"
            Checked='<%# Bind("Contractual") %>'
            Enabled = "False"
            CssClass = "dmychk"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_NonTechnical" runat="server" Text="Non Technical :" />&nbsp;
        </td>
        <td>
          <asp:CheckBox ID="F_NonTechnical"
            Checked='<%# Bind("NonTechnical") %>'
            Enabled = "False"
            CssClass = "dmychk"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr id="taBH_1"><td colspan="4" onclick="groupClicked(this);" class="groupHeader" >Travel Details</td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_TravelTypeID" runat="server" Text="Travel Type ID :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <LGM:LC_taTravelTypes
            ID="F_TravelTypeID"
            SelectedValue='<%# Bind("TravelTypeID") %>'
            OrderBy="DisplayField"
            DataTextField="DisplayField"
            DataValueField="PrimaryKey"
            IncludeDefault="true"
            DefaultText="-- Select --"
            Width="200px"
            CssClass="myddl"
            ValidationGroup = "taBH"
            RequiredFieldErrorMessage = "<div class='errorLG'>Required!</div>"
            Enabled='<%# Eval("HeaderEditable") %>'
            Runat="Server" />
          </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_CityOfOrigin" runat="server" Text="City Of Origin :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <asp:TextBox
            ID = "F_CityOfOrigin"
            CssClass = "myfktxt"
            Text='<%# Bind("CityOfOrigin") %>'
            AutoCompleteType = "None"
            Width="200px"
            onfocus = "return this.select();"
            ToolTip="Enter value for City Of Origin."
            ValidationGroup = "taBH"
            onblur= "script_taBH.validate_CityOfOrigin(this);"
            Runat="Server" />
          <asp:RequiredFieldValidator 
            ID = "RFVCityOfOrigin"
            runat = "server"
            ControlToValidate = "F_CityOfOrigin"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "taBH"
            SetFocusOnError="true" />
          <asp:Label
            ID = "F_CityOfOrigin_Display"
            Text='<%# Eval("TA_Cities1_CityName") %>'
            CssClass="myLbl"
            Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACECityOfOrigin"
            BehaviorID="B_ACECityOfOrigin"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="CityOfOriginCompletionList"
            TargetControlID="F_CityOfOrigin"
            EnableCaching="false"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="script_taBH.ACECityOfOrigin_Selected"
            OnClientPopulating="script_taBH.ACECityOfOrigin_Populating"
            OnClientPopulated="script_taBH.ACECityOfOrigin_Populated"
            CompletionSetCount="10"
            CompletionListCssClass = "autocomplete_completionListElement"
            CompletionListItemCssClass = "autocomplete_listItem"
            CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_DestinationCity" runat="server" Text="Destination City :" />&nbsp;
        </td>
        <td>
          <asp:TextBox
            ID = "F_DestinationCity"
            CssClass = "myfktxt"
            Text='<%# Bind("DestinationCity") %>'
            AutoCompleteType = "None"
            Width="200px"
            onfocus = "return this.select();"
            ToolTip="Enter value for Destination City."
            onblur= "script_taBH.validate_DestinationCity(this);"
            Runat="Server" />
          <asp:Label
            ID = "F_DestinationCity_Display"
            Text='<%# Eval("TA_Cities14_CityName") %>'
            CssClass="myLbl"
            Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACEDestinationCity"
            BehaviorID="B_ACEDestinationCity"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="DestinationCityCompletionList"
            TargetControlID="F_DestinationCity"
            EnableCaching="false"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="script_taBH.ACEDestinationCity_Selected"
            OnClientPopulating="script_taBH.ACEDestinationCity_Populating"
            OnClientPopulated="script_taBH.ACEDestinationCity_Populated"
            CompletionSetCount="10"
            CompletionListCssClass = "autocomplete_completionListElement"
            CompletionListItemCssClass = "autocomplete_listItem"
            CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_DestinationName" runat="server" Text="Other Destination :" />
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_DestinationName"
            Text='<%# Bind("DestinationName") %>'
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="taBH"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Destination Name."
            MaxLength="50"
            Width="200px"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_ProjectID" runat="server" Text="Project ID :" />&nbsp;
        </td>
        <td>
          <asp:TextBox
            ID = "F_ProjectID"
            CssClass = "myfktxt"
            Text='<%# Bind("ProjectID") %>'
            AutoCompleteType = "None"
            Width="56px"
            onfocus = "return this.select();"
            ToolTip="Enter value for Project ID."
            onblur= "script_taBH.validate_ProjectID(this);"
            Runat="Server" />
          <asp:Label
            ID = "F_ProjectID_Display"
            Text='<%# Eval("IDM_Projects11_Description") %>'
            CssClass="myLbl"
            Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACEProjectID"
            BehaviorID="B_ACEProjectID"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="ProjectIDCompletionList"
            TargetControlID="F_ProjectID"
            EnableCaching="false"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="script_taBH.ACEProjectID_Selected"
            OnClientPopulating="script_taBH.ACEProjectID_Populating"
            OnClientPopulated="script_taBH.ACEProjectID_Populated"
            CompletionSetCount="10"
            CompletionListCssClass = "autocomplete_completionListElement"
            CompletionListItemCssClass = "autocomplete_listItem"
            CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_CostCenterID" runat="server" Text="CostCenterID :" /><span style="color:red">*</span>
        </td>
        <td >
          <LGM:LC_taDepartments
            ID="F_CostCenterID"
            SelectedValue='<%# Bind("CostCenterID") %>'
            OrderBy="DisplayField"
            DataTextField="DisplayField"
            DataValueField="PrimaryKey"
            IncludeDefault="true"
            DefaultText="-- Select --"
            Width="200px"
            CssClass="myddl"
            ValidationGroup = "taBH"
            RequiredFieldErrorMessage = "<div class='errorLG'>Required!</div>"
            Runat="Server" />
          </td>
      </tr>
        <tr id="R_SiteName" runat="server" ClientIDMode="static" >
        <td class="alignright">
          <asp:Label ID="Label8" runat="server" Text="Posted at Site :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_SiteName"
            Text='<%# Bind("SiteName") %>'
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="taBH"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter Site Name."
            MaxLength="50"
            Width="350px"
            runat="server" />
          <asp:RequiredFieldValidator 
            ID = "RFVF_SiteName"
            runat = "server"
            ControlToValidate = "F_SiteName"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "taBH"
            SetFocusOnError="true" />
        </td>
        </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_BillCurrencyID" runat="server" Text="TA Bill Currency ID :" /><span style="color:red">*</span>
        </td>
        <td>
          <LGM:LC_taCurrencies
            ID="F_BillCurrencyID"
            SelectedValue='<%# Bind("BillCurrencyID") %>'
            OrderBy="DisplayField"
            DataTextField="DisplayField"
            DataValueField="PrimaryKey"
            IncludeDefault="true"
            DefaultText="-- Select --"
            Width="200px"
            CssClass="myddl"
            ValidationGroup = "taBH"
            RequiredFieldErrorMessage = "<div class='errorLG'>Required!</div>"
            Runat="Server" />
          </td>
        <td class="alignright">
          <asp:Label ID="L_ConversionFactorINR" runat="server" Text="Conversion Factor [INR] :" /><span style="color:red">*</span>
        </td>
        <td>
          <asp:TextBox ID="F_ConversionFactorINR"
            Text='<%# Bind("ConversionFactorINR") %>'
            style="text-align: right"
            Width="88px"
            CssClass = "mytxt"
            ValidationGroup= "taBH"
            MaxLength="13"
            onfocus = "return this.select();"
            onblur="return dc(this,6);"
            runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_PrjCalcType" runat="server" Text="Project Wise Distribution Method :" /><span style="color:red">*</span>
        </td>
        <td>
          <LGM:LC_taPrjCalcMethod
            ID="F_PrjCalcType"
            SelectedValue='<%# Bind("PrjCalcType") %>'
            OrderBy="DisplayField"
            DataTextField="DisplayField"
            DataValueField="PrimaryKey"
            IncludeDefault="true"
            DefaultText="-- Select --"
            Width="200px"
            CssClass="myddl"
            ValidationGroup = "taBH"
            RequiredFieldErrorMessage = "<div class='errorLG'>Required!</div>"
            Runat="Server" />
          </td>
      <td></td><td></td></tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_PurposeOfJourney" runat="server" Text="Purpose Of Journey :" /><span style="color:red">*</span>
        </td>
        <td>
          <asp:TextBox ID="F_PurposeOfJourney"
            Text='<%# Bind("PurposeOfJourney") %>'
            Width="350px" Height="40px" TextMode="MultiLine"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="taBH"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Purpose Of Journey."
            MaxLength="500"
            runat="server" />
          <asp:RequiredFieldValidator 
            ID = "RFVPurposeOfJourney"
            runat = "server"
            ControlToValidate = "F_PurposeOfJourney"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "taBH"
            SetFocusOnError="true" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_BriefTourReport" runat="server" Text="Brief Tour Report :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_BriefTourReport"
            Text='<%# Bind("BriefTourReport") %>'
            Width="350px" Height="40px" TextMode="MultiLine"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Brief Tour Report."
            MaxLength="500"
            runat="server" />
        </td>
      </tr>
      <tr>
        <td colspan="4">
          <table style="margin:auto;border: solid 1pt lightgrey">
            <tr>
              <td>
                <table style="border: solid 1pt lightgrey">
                  <tr>
                    <td colspan="4" style="padding-top:10px;">
                      <asp:Label ID="lbl1" runat="server" Font-Bold="true" Font-Underline="true" Text="Select, if applicable in DOMESTIC Travel" />
                    </td>
                  </tr>
                  <tr>
                    <td class="alignright">
                      <script type="text/javascript">
                        function chkChanged(a) {
                          switch (a.id) {
                            case 'F_TaxiHired':
                              if (a.checked) {
                                var t = $get('F_TrainingProgram');
                                t.disabled = true;
                              } else {
                                var t = $get('F_TrainingProgram');
                                t.disabled = false;
                              }
                              break;
                            case 'F_TrainingProgram':
                              if (a.checked) {
                                var t = $get('F_TaxiHired');
                                t.disabled = true;
                              } else {
                                var t = $get('F_TaxiHired');
                                t.disabled = false;
                              }
                              break;
                          }
                          return true;
                        }
                      </script>
                      <asp:Label ID="L_TaxiHired" runat="server" Text="Training Program [Residential] :" />&nbsp;
                    </td>
                    <td>
                      <asp:CheckBox ID="F_TaxiHired"
                        Checked='<%# Bind("TaxiHired") %>'
                        CssClass = "mychk"
                        ClientIDMode="Static"
                        onclick="return chkChanged(this);"
                        runat="server" />
                    </td>
                    <td class="alignright">
                      <asp:Label ID="L_TrainingProgram" runat="server" Text="Training Program [NON-Residential] :" />&nbsp;
                    </td>
                    <td>
                      <asp:CheckBox ID="F_TrainingProgram"
                        Checked='<%# Bind("TrainingProgram") %>'
                        CssClass = "mychk"
                        ClientIDMode="Static"
                        onclick="return chkChanged(this);"
                        runat="server" />
                    </td>
                  </tr>
<%--                  <tr>
                    <td class="alignright">
                      <asp:Label ID="L_Within25KM" runat="server" Text="Visit with in 25 KM :" />&nbsp;
                    </td>
                    <td>
                      <asp:CheckBox ID="F_Within25KM"
                        Checked='<%# Bind("Within25KM") %>'
                        CssClass = "mychk"
                        ClientIDMode="Static"
                        onclick="return chkChanged(this);"
                        runat="server" />
                    </td>
                    <td class="alignright">
                      <asp:Label ID="L_SameDayVisit" runat="server" Text="Same Day Visit :" />&nbsp;
                    </td>
                    <td>
                      <asp:CheckBox ID="F_SameDayVisit"
                        Checked='<%# Bind("SameDayVisit") %>'
                        CssClass = "mychk"
                        ClientIDMode="Static"
                        onclick="return chkChanged(this);"
                        runat="server" />
                    </td>
                  </tr>--%>
                  <tr>
                    <td class="alignright">
                      <asp:Label ID="L_SiteTransfer" runat="server" Text="Site To Site Visit/Transfer :" />&nbsp;
                    </td>
                    <td>
                      <asp:CheckBox ID="F_SiteTransfer"
                       Checked='<%# Bind("SiteTransfer") %>'
                       CssClass = "mychk"
                       runat="server" />
                    </td>
                    <td class="alignright">
                      <asp:Label ID="L_CalculateDriverCharges" runat="server" Text="Calculate Driver Charges :" />&nbsp;
                    </td>
                    <td>
                      <asp:CheckBox ID="F_CalculateDriverCharges"
                       Checked='<%# Bind("CalculateDriverCharges") %>'
                       CssClass = "mychk"
                       runat="server" />
                    </td>
                  </tr>
                </table>
              </td>
              <td style="vertical-align:top">
                <table style="border: solid 1pt lightgrey">
                  <tr>
                    <td colspan="4" style="padding-top:10px;">
                      <asp:Label ID="Label7" runat="server" Font-Bold="true" Font-Underline="true" Text="Select, if applicable in FOREIGN Travel/Site" />
                    </td>
                  </tr>
                  <tr id="opt3">
                    <td class="alignright">
                      <asp:Label ID="L_SiteToAnotherSite" runat="server" Text="Is it Partial TA Bill :" />&nbsp;
                    </td>
                    <td>
                      <asp:CheckBox ID="F_SiteToAnotherSite"
                        Checked='<%# Bind("SiteToAnotherSite") %>'
                        CssClass = "mychk"
                        runat="server" />
                    </td>
                    <td class="alignright">
                      <asp:Label ID="Label9" runat="server" Text="MD Sanction Attached :" />&nbsp;
                    </td>
                    <td>
                      <asp:CheckBox ID="F_SanctionAttached"
                        Checked='<%# Bind("SanctionAttached") %>'
                        CssClass = "mychk"
                        runat="server" />
                    </td>
                  </tr>
                  <tr>
                    <td class="alignright">
                    </td>
                    <td>
                    </td>
                    <td colspan="2">
                    <script type="text/javascript">
                      var pcnt = 0;
                      function show_attach(o) {
                        pcnt = pcnt + 1;
                        var nam = 'wTask' + pcnt;
                        var url = o.getAttribute('CommandValue');
                        window.open(url, nam, 'left=20,top=20,width=1100,height=600,toolbar=1,resizable=1,scrollbars=1');
                        return false;
                      }
                    </script>
                     <asp:Button ID="cmdAttach" runat="server" CommandValue='<%# Eval("GetAttachLink") %>' Text="Attach MD Approval" OnClientClick="return show_attach(this);" />
                    </td>
                  </tr>
                </table>
              </td>
            </tr>
          </table>
        </td>
      </tr>
      <tr id="opt5" runat="server" clientidmode="static"><td colspan="4"  style="border-top: solid 1pt LightGrey; font-weight:bold;text-align:center;background-color:lavender" >SPECIAL SANCTION OTHER THAN ENTITLEMENT</td></tr>
      <tr id="opt4" runat="server" clientidmode="static">
        <td class="alignright">
          <asp:Label ID="L_SanctionedLodging" runat="server" Text="Sanctioned Lodging [Per Day, If any] :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_SanctionedLodging"
            Text='<%# Bind("SanctionedLodging") %>'
            style="text-align: right"
            Width="88px"
            CssClass = "mytxt"
            MaxLength="10"
            onfocus = "return this.select();"
            onblur="return dc(this,2);"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_SanctionedDA" runat="server" Text="Sanctioned DA [Per Day, If any] :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_SanctionedDA"
            Text='<%# Bind("SanctionedDA") %>'
            style="text-align: right"
            Width="88px"
            CssClass = "mytxt"
            MaxLength="10"
            onfocus = "return this.select();"
            onblur="return dc(this,2);"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_OOERemarks" runat="server" Text="Accounts Remarks :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_OOERemarks"
            Text='<%# Bind("OOERemarks") %>'
            ToolTip="Value of OOE Remarks."
            Enabled = "False"
            Width="350px" 
            CssClass = "dmytxt"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr id="taBH_2"><td colspan="4" onclick="groupClicked(this);" class="groupHeader" >Accounts Details</td></tr>
      <tr style="display:none">
        <td class="alignright">
          <asp:Label ID="L_StartDateTime" runat="server" Text="Tour Start Date and Time :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_StartDateTime"
            Text='<%# Bind("StartDateTime") %>'
            ToolTip="Value of Tour Start Date and Time."
            Enabled = "False"
            Width="168px"
            CssClass = "dmytxt"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_EndDateTime" runat="server" Text="Tour End Date and Time :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_EndDateTime"
            Text='<%# Bind("EndDateTime") %>'
            ToolTip="Value of Tour End Date and Time."
            Enabled = "False"
            Width="168px"
            CssClass = "dmytxt"
            runat="server" />
        </td>
      </tr>
      <tr style="display:none">
        <td class="alignright">
          <asp:Label ID="L_TotalClaimedAmount" runat="server" Text="Total Claimed Amount :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_TotalClaimedAmount"
            Text='<%# Bind("TotalClaimedAmount") %>'
            ToolTip="Value of Total Claimed Amount."
            Enabled = "False"
            Width="168px"
            CssClass = "dmytxt"
            style="text-align: right"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_TotalPassedAmount" runat="server" Text="Total Passed Amount :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_TotalPassedAmount"
            Text='<%# Bind("TotalPassedAmount") %>'
            ToolTip="Value of Total Passed Amount."
            Enabled = "False"
            Width="168px"
            CssClass = "dmytxt"
            style="text-align: right"
            runat="server" />
        </td>
      </tr>
      <tr style="display:none">
        <td class="alignright">
          <asp:Label ID="L_TotalFinancedAmount" runat="server" Text="Total Financed Amount :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_TotalFinancedAmount"
            Text='<%# Bind("TotalFinancedAmount") %>'
            ToolTip="Value of Total Financed Amount."
            Enabled = "False"
            Width="168px"
            CssClass = "dmytxt"
            style="text-align: right"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_TotalPayableAmount" runat="server" Text="Total Payable Amount :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_TotalPayableAmount"
            Text='<%# Bind("TotalPayableAmount") %>'
            ToolTip="Value of Total Payable Amount."
            Enabled = "False"
            Width="168px"
            CssClass = "dmytxt"
            style="text-align: right"
            runat="server" />
        </td>
      </tr>
      <tr style="display:none">
        <td class="alignright">
          <asp:Label ID="L_OOEReasonID" runat="server" Text="OOE Reason ID :" />&nbsp;
        </td>
        <td>
          <asp:TextBox
            ID = "F_OOEReasonID"
            Width="88px"
            Text='<%# Bind("OOEReasonID") %>'
            Enabled = "False"
            ToolTip="Value of OOE Reason ID."
            CssClass = "dmyfktxt"
            Runat="Server" />
          <asp:Label
            ID = "F_OOEReasonID_Display"
            Text='<%# Eval("TA_OOEReasons18_Description") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_ApprovalWFTypeID" runat="server" Text="Approval WF Type ID :" />&nbsp;
        </td>
        <td>
          <asp:TextBox
            ID = "F_ApprovalWFTypeID"
            Width="88px"
            Text='<%# Bind("ApprovalWFTypeID") %>'
            Enabled = "False"
            ToolTip="Value of Approval WF Type ID."
            CssClass = "dmyfktxt"
            Runat="Server" />
          <asp:Label
            ID = "F_ApprovalWFTypeID_Display"
            Text='<%# Eval("TA_ApprovalWFTypes12_WFTypeDescription") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
      </tr>
      <tr style="display:none">
        <td class="alignright">
          <asp:Label ID="L_Setteled" runat="server" Text="Setteled :" />&nbsp;
        </td>
        <td>
          <asp:CheckBox ID="F_Setteled"
            Checked='<%# Bind("Setteled") %>'
            Enabled = "False"
            CssClass = "dmychk"
            runat="server" />
        </td>
      <td></td><td></td></tr>
      <tr ><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr style="display:none">
        <td class="alignright">
          <asp:Label ID="L_ForwardedOn" runat="server" Text="Forwarded To Accounts On :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_ForwardedOn"
            Text='<%# Bind("ForwardedOn") %>'
            ToolTip="Value of Forwarded To Accounts On."
            Enabled = "False"
            Width="168px"
            CssClass = "dmytxt"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_VerifiedBy" runat="server" Text="Received In Accounts By :" />&nbsp;
        </td>
        <td>
          <asp:TextBox
            ID = "F_VerifiedBy"
            Width="72px"
            Text='<%# Bind("VerifiedBy") %>'
            Enabled = "False"
            ToolTip="Value of Received In Accounts By."
            CssClass = "dmyfktxt"
            Runat="Server" />
          <asp:Label
            ID = "F_VerifiedBy_Display"
            Text='<%# Eval("HRM_Employees10_EmployeeName") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr style="display:none">
        <td class="alignright">
          <asp:Label ID="L_VerificationRemarks" runat="server" Text="Last Action  :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_VerificationRemarks"
            Text='<%# Bind("VerificationRemarks") %>'
            ToolTip="Value of Last Action ."
            Enabled = "False"
            Width="350px" 
            CssClass = "dmytxt"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_VerifiedOn" runat="server" Text="Last Action Date :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_VerifiedOn"
            Text='<%# Bind("VerifiedOn") %>'
            ToolTip="Value of Last Action Date."
            Enabled = "False"
            Width="168px"
            CssClass = "dmytxt"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr id="taBH_3"><td colspan="4" onclick="groupClicked(this);" class="groupHeader" >Approvals</td></tr>
      <tr style="display:none">
        <td class="alignright">
          <asp:Label ID="L_ApprovedBy" runat="server" Text="Verified By :" />&nbsp;
        </td>
        <td>
          <asp:TextBox
            ID = "F_ApprovedBy"
            Width="72px"
            Text='<%# Bind("ApprovedBy") %>'
            Enabled = "False"
            CssClass = "dmyfktxt"
            Runat="Server" />
          <asp:Label
            ID = "F_ApprovedBy_Display"
            Text='<%# Eval("HRM_Employees7_EmployeeName") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_ApprovedOn" runat="server" Text="Verified On :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_ApprovedOn"
            Text='<%# Bind("ApprovedOn") %>'
            Enabled = "False"
            Width="168px"
            CssClass = "dmytxt"
            runat="server" />
        </td>
      </tr>
      <tr style="display:none">
        <td class="alignright">
          <asp:Label ID="L_ApprovalRemarks" runat="server" Text="Remarks By Verifier :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_ApprovalRemarks"
            Text='<%# Bind("ApprovalRemarks") %>'
            Enabled = "False"
            Width="350px"
            CssClass = "dmytxt"
            runat="server" />
        </td>
      <td></td><td></td></tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr style="display:none">
        <td class="alignright">
          <asp:Label ID="L_ApprovedByCC" runat="server" Text="Approved By :" />&nbsp;
        </td>
        <td>
          <asp:TextBox
            ID = "F_ApprovedByCC"
            Width="72px"
            Text='<%# Bind("ApprovedByCC") %>'
            Enabled = "False"
            CssClass = "dmyfktxt"
            Runat="Server" />
          <asp:Label
            ID = "F_ApprovedByCC_Display"
            Text='<%# Eval("HRM_Employees8_EmployeeName") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_ApprovedByCCOn" runat="server" Text="Approved On  :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_ApprovedByCCOn"
            Text='<%# Bind("ApprovedByCCOn") %>'
            Enabled = "False"
            Width="168px"
            CssClass = "dmytxt"
            runat="server" />
        </td>
      </tr>
      <tr style="display:none">
        <td class="alignright">
          <asp:Label ID="L_CCRemarks" runat="server" Text="Remarks By Approver :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_CCRemarks"
            Text='<%# Bind("CCRemarks") %>'
            ToolTip="Value of Remarks By Approver."
            Enabled = "False"
            Width="350px"
            CssClass = "dmytxt"
            runat="server" />
        </td>
      <td></td><td></td></tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr style="display:none">
        <td class="alignright">
          <asp:Label ID="L_ApprovedBySA" runat="server" Text="Special Approved By Sanctioning Authority :" />&nbsp;
        </td>
        <td>
          <asp:TextBox
            ID = "F_ApprovedBySA"
            Width="72px"
            Text='<%# Bind("ApprovedBySA") %>'
            Enabled = "False"
            CssClass = "dmyfktxt"
            Runat="Server" />
          <asp:Label
            ID = "F_ApprovedBySA_Display"
            Text='<%# Eval("HRM_Employees9_EmployeeName") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_ApprovedBySAOn" runat="server" Text="Special Approval On :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_ApprovedBySAOn"
            Text='<%# Bind("ApprovedBySAOn") %>'
            Enabled = "False"
            Width="168px"
            CssClass = "dmytxt"
            runat="server" />
        </td>
      </tr>
      <tr style="display:none">
        <td class="alignright">
          <asp:Label ID="L_SARemarks" runat="server" Text="Special Approval Remarks :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_SARemarks"
            Text='<%# Eval("SARemarks") %>'
            Enabled = "False"
            Width="350px" 
            CssClass = "dmytxt"
            runat="server" />
        </td>
      <td></td><td></td></tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr id="taBH_4"><td colspan="4" onclick="groupClicked(this);" class="groupHeader" >ERP Ln Voucher Posting</td></tr>
      <tr style="display:none">
        <td class="alignright">
          <asp:Label ID="L_PostedBy" runat="server" Text="Posted By :" />&nbsp;
        </td>
        <td>
          <asp:TextBox
            ID = "F_PostedBy"
            Width="72px"
            Text='<%# Bind("PostedBy") %>'
            Enabled = "False"
            ToolTip="Value of Posted By."
            CssClass = "dmyfktxt"
            Runat="Server" />
          <asp:Label
            ID = "F_PostedBy_Display"
            Text='<%# Eval("HRM_Employees6_EmployeeName") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_PostedOn" runat="server" Text="Posted On :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_PostedOn"
            Text='<%# Bind("PostedOn") %>'
            ToolTip="Value of Posted On."
            Enabled = "False"
            Width="168px"
            CssClass = "dmytxt"
            runat="server" />
        </td>
      </tr>
      <tr style="display:none">
        <td class="alignright">
          <asp:Label ID="L_ERPBatchNo" runat="server" Text="ERP Batch No :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_ERPBatchNo"
            Text='<%# Bind("ERPBatchNo") %>'
            ToolTip="Value of ERP Batch No."
            Enabled = "False"
            Width="88px"
            CssClass = "dmytxt"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_ERPDocumentNo" runat="server" Text="ERP Document No :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_ERPDocumentNo"
            Text='<%# Bind("ERPDocumentNo") %>'
            ToolTip="Value of ERP Document No."
            Enabled = "False"
            Width="88px"
            CssClass = "dmytxt"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
    </table>
  </div>
  <div  id="FS_Fare" runat="server">
<fieldset class="ui-widget-content page">
<legend>
    <asp:Label ID="LabeltaBDFare" runat="server" Text="&nbsp;List: Fare"></asp:Label>
</legend>
<div class="pagedata">
<asp:UpdatePanel ID="UPNLtaBDFare" runat="server">
  <ContentTemplate>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLtaBDFare"
      ToolType = "lgNMGrid"
      EditUrl = "~/TA_Main/App_Edit/EF_taBDFare.aspx"
      AddUrl = "~/TA_Main/App_Create/AF_taBDFare.aspx"
      AddPostBack = "True"
      EnableExit = "false"
      ValidationGroup = "taBDFare"
      EnableAdd='<%# Eval("Editable") %>'
      runat = "server" />
    <asp:UpdateProgress ID="UPGStaBDFare" runat="server" AssociatedUpdatePanelID="UPNLtaBDFare" DisplayAfter="100">
      <ProgressTemplate>
        <span style="color: #ff0033">Loading...</span>
      </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:GridView ID="GVtaBDFare" SkinID="gv_silver" runat="server" DataSourceID="ODStaBDFare" DataKeyNames="TABillNo,SerialNo">
      <Columns>
        <asp:TemplateField HeaderText="EDIT">
          <ItemTemplate>
            <asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# Eval("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Serial No" SortExpression="SerialNo">
          <ItemTemplate>
            <asp:Label ID="LabelSerialNo" runat="server" ForeColor='<%# Eval("ForeColor") %>' Text='<%# Bind("SerialNo") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignright" />
          <HeaderStyle CssClass="alignright" Width="40px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Date" SortExpression="Date1Time">
          <ItemTemplate>
            <asp:Label ID="LabelDate1Time" runat="server" ForeColor='<%# Eval("ForeColor") %>' Text='<%# Bind("Date1Time") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="90px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Description" SortExpression="SystemText">
          <ItemTemplate>
            <asp:Label ID="LabelSystemText" runat="server" ForeColor='<%# Eval("ForeColor") %>' Text='<%# Bind("SystemText") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="" />
        <HeaderStyle CssClass="" Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Claimed Amount" SortExpression="AmountTotal">
          <ItemTemplate>
            <asp:Label ID="LabelAmountTotal" runat="server" ForeColor='<%# Eval("ForeColor") %>' Text='<%# Bind("AmountTotal") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignright" />
          <HeaderStyle CssClass="alignright" Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Passed Amount" SortExpression="PassedAmountTotal">
          <ItemTemplate>
            <asp:Label ID="LabelPassedAmountTotal" runat="server" ForeColor='<%# Eval("ForeColor") %>' Text='<%# Bind("PassedAmountTotal") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignright" />
          <HeaderStyle CssClass="alignright" Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="OOE Remarks" SortExpression="OOERemarks">
          <ItemTemplate>
            <asp:Label ID="LabelOOERemarks" runat="server" ForeColor='<%# Eval("ForeColor") %>' Text='<%# Bind("OOERemarks") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="" />
        <HeaderStyle CssClass="" Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Delete">
          <ItemTemplate>
            <asp:ImageButton ID="cmdDelete" ValidationGroup='<%# "Delete" & Container.DataItemIndex %>' CausesValidation="true" runat="server" Visible='<%# EVal("DeleteWFVisible") %>' Enabled='<%# EVal("DeleteWFEnable") %>' AlternateText='<%# EVal("PrimaryKey") %>' ToolTip="Delete" SkinID="Delete" OnClientClick='<%# "return Page_ClientValidate(""Delete" & Container.DataItemIndex & """) && confirm(""Delete record ?"");" %>' CommandName="DeleteWF" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
      </Columns>
      <EmptyDataTemplate>
        <asp:Label ID="LabelEmpty" runat="server" Font-Size="Small" ForeColor="Red" Text="No record found !!!"></asp:Label>
      </EmptyDataTemplate>
    </asp:GridView>
    <asp:ObjectDataSource 
      ID = "ODStaBDFare"
      runat = "server"
      DataObjectTypeName = "SIS.TA.taBDFare"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "UZ_taBDFareSelectList"
      TypeName = "SIS.TA.taBDFare"
      SelectCountMethod = "taBDFareSelectCount"
      SortParameterName="OrderBy" EnablePaging="True">
      <SelectParameters >
        <asp:ControlParameter ControlID="F_TABillNo" PropertyName="Text" Name="TABillNo" Type="Int32" Size="10" />
        <asp:Parameter Name="SearchState" Type="Boolean" Direction="Input" DefaultValue="false" />
        <asp:Parameter Name="SearchText" Type="String" Direction="Input" DefaultValue="" />
      </SelectParameters>
    </asp:ObjectDataSource>
    <br />
  </td></tr></table>
  </ContentTemplate>
  <Triggers>
    <asp:AsyncPostBackTrigger ControlID="GVtaBDFare" EventName="PageIndexChanged" />
  </Triggers>
</asp:UpdatePanel>
</div>
</fieldset>
    </div>
    <div  id="FS_Lodging" runat="server">
<fieldset class="ui-widget-content page">
<legend>
    <asp:Label ID="LabeltaBDLodging" runat="server" Text="&nbsp;List: Lodging Charges"></asp:Label>
</legend>
<div class="pagedata">
<asp:UpdatePanel ID="UPNLtaBDLodging" runat="server">
  <ContentTemplate>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLtaBDLodging"
      ToolType = "lgNMGrid"
      EditUrl = "~/TA_Main/App_Edit/EF_taBDLodging.aspx"
      AddUrl = "~/TA_Main/App_Create/AF_taBDLodging.aspx"
      AddPostBack = "True"
      EnableExit = "false"
      EnableAdd='<%# Eval("Editable") %>'
      ValidationGroup = "taBDLodging"
      runat = "server" />
    <asp:UpdateProgress ID="UPGStaBDLodging" runat="server" AssociatedUpdatePanelID="UPNLtaBDLodging" DisplayAfter="100">
      <ProgressTemplate>
        <span style="color: #ff0033">Loading...</span>
      </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:GridView ID="GVtaBDLodging" SkinID="gv_silver" runat="server" DataSourceID="ODStaBDLodging" DataKeyNames="TABillNo,SerialNo">
      <Columns>
        <asp:TemplateField HeaderText="EDIT">
          <ItemTemplate>
            <asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# Eval("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Serial No" SortExpression="SerialNo">
          <ItemTemplate>
            <asp:Label ID="LabelSerialNo" runat="server" ForeColor='<%# Eval("ForeColor") %>' Text='<%# Bind("SerialNo") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignright" />
          <HeaderStyle CssClass="alignright" Width="40px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Date" SortExpression="Date1Time">
          <ItemTemplate>
            <asp:Label ID="LabelDate1Time" runat="server" ForeColor='<%# Eval("ForeColor") %>' Text='<%# Bind("Date1Time") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="90px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Description" SortExpression="SystemText">
          <ItemTemplate>
            <asp:Label ID="LabelSystemText" runat="server" ForeColor='<%# Eval("ForeColor") %>' Text='<%# Bind("SystemText") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="" />
        <HeaderStyle CssClass="" Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Claimed Amount" SortExpression="AmountTotal">
          <ItemTemplate>
            <asp:Label ID="LabelAmountTotal" runat="server" ForeColor='<%# Eval("ForeColor") %>' Text='<%# Bind("AmountTotal") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignright" />
          <HeaderStyle CssClass="alignright" Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Passed Amount" SortExpression="PassedAmountTotal">
          <ItemTemplate>
            <asp:Label ID="LabelPassedAmountTotal" runat="server" ForeColor='<%# Eval("ForeColor") %>' Text='<%# Bind("PassedAmountTotal") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignright" />
          <HeaderStyle CssClass="alignright" Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="OOE Remarks" SortExpression="OOERemarks">
          <ItemTemplate>
            <asp:Label ID="LabelOOERemarks" runat="server" ForeColor='<%# Eval("ForeColor") %>' Text='<%# Bind("OOERemarks") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="" />
        <HeaderStyle CssClass="" Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Delete">
          <ItemTemplate>
            <asp:ImageButton ID="cmdDelete" ValidationGroup='<%# "Delete" & Container.DataItemIndex %>' CausesValidation="true" runat="server" Visible='<%# EVal("DeleteWFVisible") %>' Enabled='<%# EVal("DeleteWFEnable") %>' AlternateText='<%# EVal("PrimaryKey") %>' ToolTip="Delete" SkinID="Delete" OnClientClick='<%# "return Page_ClientValidate(""Delete" & Container.DataItemIndex & """) && confirm(""Delete record ?"");" %>' CommandName="DeleteWF" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
      </Columns>
      <EmptyDataTemplate>
        <asp:Label ID="LabelEmpty" runat="server" Font-Size="Small" ForeColor="Red" Text="No record found !!!"></asp:Label>
      </EmptyDataTemplate>
    </asp:GridView>
    <asp:ObjectDataSource 
      ID = "ODStaBDLodging"
      runat = "server"
      DataObjectTypeName = "SIS.TA.taBDLodging"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "UZ_taBDLodgingSelectList"
      TypeName = "SIS.TA.taBDLodging"
      SelectCountMethod = "taBDLodgingSelectCount"
      SortParameterName="OrderBy" EnablePaging="True">
      <SelectParameters >
        <asp:ControlParameter ControlID="F_TABillNo" PropertyName="Text" Name="TABillNo" Type="Int32" Size="10" />
        <asp:Parameter Name="SearchState" Type="Boolean" Direction="Input" DefaultValue="false" />
        <asp:Parameter Name="SearchText" Type="String" Direction="Input" DefaultValue="" />
      </SelectParameters>
    </asp:ObjectDataSource>
    <br />
  </td></tr></table>
  </ContentTemplate>
  <Triggers>
    <asp:AsyncPostBackTrigger ControlID="GVtaBDLodging" EventName="PageIndexChanged" />
  </Triggers>
</asp:UpdatePanel>
</div>
</fieldset>
    </div>
    <div  id="FS_LC" runat="server">
<fieldset class="ui-widget-content page">
<legend>
    <asp:Label ID="LabeltaBDLC" runat="server" Text="&nbsp;List: Local Conveyance"></asp:Label>
</legend>
<div class="pagedata">
<asp:UpdatePanel ID="UPNLtaBDLC" runat="server">
  <ContentTemplate>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLtaBDLC"
      ToolType = "lgNMGrid"
      EditUrl = "~/TA_Main/App_Edit/EF_taBDLC.aspx"
      AddUrl = "~/TA_Main/App_Create/AF_taBDLC.aspx"
      AddPostBack = "True"
      EnableExit = "false"
      EnableAdd='<%# Eval("Editable") %>'
      ValidationGroup = "taBDLC"
      runat = "server" />
    <asp:UpdateProgress ID="UPGStaBDLC" runat="server" AssociatedUpdatePanelID="UPNLtaBDLC" DisplayAfter="100">
      <ProgressTemplate>
        <span style="color: #ff0033">Loading...</span>
      </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:GridView ID="GVtaBDLC" SkinID="gv_silver" runat="server" DataSourceID="ODStaBDLC" DataKeyNames="TABillNo,SerialNo">
      <Columns>
        <asp:TemplateField HeaderText="EDIT">
          <ItemTemplate>
            <asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# Eval("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Serial No" SortExpression="SerialNo">
          <ItemTemplate>
            <asp:Label ID="LabelSerialNo" runat="server" ForeColor='<%# Eval("ForeColor") %>' Text='<%# Bind("SerialNo") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignright" />
          <HeaderStyle CssClass="alignright" Width="40px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Date" SortExpression="Date1Time">
          <ItemTemplate>
            <asp:Label ID="LabelDate1Time" runat="server" ForeColor='<%# Eval("ForeColor") %>' Text='<%# Bind("Date1Time") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="90px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Description" SortExpression="SystemText">
          <ItemTemplate>
            <asp:Label ID="LabelSystemText" runat="server" ForeColor='<%# Eval("ForeColor") %>' Text='<%# Bind("SystemText") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="" />
        <HeaderStyle CssClass="" Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Claimed Amount" SortExpression="AmountTotal">
          <ItemTemplate>
            <asp:Label ID="LabelAmountTotal" runat="server" ForeColor='<%# Eval("ForeColor") %>' Text='<%# Bind("AmountTotal") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignright" />
          <HeaderStyle CssClass="alignright" Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Passed Amount" SortExpression="PassedAmountTotal">
          <ItemTemplate>
            <asp:Label ID="LabelPassedAmountTotal" runat="server" ForeColor='<%# Eval("ForeColor") %>' Text='<%# Bind("PassedAmountTotal") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignright" />
          <HeaderStyle CssClass="alignright" Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="OOE Remarks" SortExpression="OOERemarks">
          <ItemTemplate>
            <asp:Label ID="LabelOOERemarks" runat="server" ForeColor='<%# Eval("ForeColor") %>' Text='<%# Bind("OOERemarks") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="" />
        <HeaderStyle CssClass="" Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Delete">
          <ItemTemplate>
            <asp:ImageButton ID="cmdDelete" ValidationGroup='<%# "Delete" & Container.DataItemIndex %>' CausesValidation="true" runat="server" Visible='<%# EVal("DeleteWFVisible") %>' Enabled='<%# EVal("DeleteWFEnable") %>' AlternateText='<%# EVal("PrimaryKey") %>' ToolTip="Delete" SkinID="Delete" OnClientClick='<%# "return Page_ClientValidate(""Delete" & Container.DataItemIndex & """) && confirm(""Delete record ?"");" %>' CommandName="DeleteWF" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
      </Columns>
      <EmptyDataTemplate>
        <asp:Label ID="LabelEmpty" runat="server" Font-Size="Small" ForeColor="Red" Text="No record found !!!"></asp:Label>
      </EmptyDataTemplate>
    </asp:GridView>
    <asp:ObjectDataSource 
      ID = "ODStaBDLC"
      runat = "server"
      DataObjectTypeName = "SIS.TA.taBDLC"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "UZ_taBDLCSelectList"
      TypeName = "SIS.TA.taBDLC"
      SelectCountMethod = "taBDLCSelectCount"
      SortParameterName="OrderBy" EnablePaging="True">
      <SelectParameters >
        <asp:ControlParameter ControlID="F_TABillNo" PropertyName="Text" Name="TABillNo" Type="Int32" Size="10" />
        <asp:Parameter Name="SearchState" Type="Boolean" Direction="Input" DefaultValue="false" />
        <asp:Parameter Name="SearchText" Type="String" Direction="Input" DefaultValue="" />
      </SelectParameters>
    </asp:ObjectDataSource>
    <br />
  </td></tr></table>
  </ContentTemplate>
  <Triggers>
    <asp:AsyncPostBackTrigger ControlID="GVtaBDLC" EventName="PageIndexChanged" />
  </Triggers>
</asp:UpdatePanel>
</div>
</fieldset>
    </div>
    <div  id="FS_DA" runat="server">
<fieldset class="ui-widget-content page">
<legend>
    <asp:Label ID="LabeltaBDDA" runat="server" Text="&nbsp;List: Daily Allowance"></asp:Label>
</legend>
<div class="pagedata">
<asp:UpdatePanel ID="UPNLtaBDDA" runat="server">
  <ContentTemplate>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLtaBDDA"
      ToolType = "lgNMGrid"
      EditUrl = "~/TA_Main/App_Edit/EF_taBDDA.aspx"
      AddUrl = "~/TA_Main/App_Create/AF_taBDDA.aspx"
      AddPostBack = "True"
      EnableExit = "false"
      EnableAdd="false"
      ValidationGroup = "taBDDA"
      runat = "server" />
    <asp:UpdateProgress ID="UPGStaBDDA" runat="server" AssociatedUpdatePanelID="UPNLtaBDDA" DisplayAfter="100">
      <ProgressTemplate>
        <span style="color: #ff0033">Loading...</span>
      </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:GridView ID="GVtaBDDA" SkinID="gv_silver" runat="server" DataSourceID="ODStaBDDA" DataKeyNames="TABillNo,SerialNo">
      <Columns>
        <asp:TemplateField HeaderText="EDIT">
          <ItemTemplate>
            <asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# Eval("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Serial No" SortExpression="SerialNo">
          <ItemTemplate>
            <asp:Label ID="LabelSerialNo" runat="server" ForeColor='<%# Eval("ForeColor") %>' Text='<%# Bind("SerialNo") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignright" />
          <HeaderStyle CssClass="alignright" Width="40px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Date" SortExpression="Date1Time">
          <ItemTemplate>
            <asp:Label ID="LabelDate1Time" runat="server" ForeColor='<%# Eval("ForeColor") %>' Text='<%# Bind("Date1Time") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="90px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Description" SortExpression="SystemText">
          <ItemTemplate>
            <asp:Label ID="LabelSystemText" runat="server" ForeColor='<%# Eval("ForeColor") %>' Text='<%# Bind("SystemText") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="" />
        <HeaderStyle CssClass="" Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Claimed Amount" SortExpression="AmountTotal">
          <ItemTemplate>
            <asp:Label ID="LabelAmountTotal" runat="server" ForeColor='<%# Eval("ForeColor") %>' Text='<%# Bind("AmountTotal") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignright" />
          <HeaderStyle CssClass="alignright" Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Passed Amount" SortExpression="PassedAmountTotal">
          <ItemTemplate>
            <asp:Label ID="LabelPassedAmountTotal" runat="server" ForeColor='<%# Eval("ForeColor") %>' Text='<%# Bind("PassedAmountTotal") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignright" />
          <HeaderStyle CssClass="alignright" Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="OOE Remarks" SortExpression="OOERemarks">
          <ItemTemplate>
            <asp:Label ID="LabelOOERemarks" runat="server" ForeColor='<%# Eval("ForeColor") %>' Text='<%# Bind("OOERemarks") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="" />
        <HeaderStyle CssClass="" Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Delete">
          <ItemTemplate>
            <asp:ImageButton ID="cmdDelete" ValidationGroup='<%# "Delete" & Container.DataItemIndex %>' CausesValidation="true" runat="server" Visible='<%# EVal("DeleteWFVisible") %>' Enabled='<%# EVal("DeleteWFEnable") %>' AlternateText='<%# EVal("PrimaryKey") %>' ToolTip="Delete" SkinID="Delete" OnClientClick='<%# "return Page_ClientValidate(""Delete" & Container.DataItemIndex & """) && confirm(""Delete record ?"");" %>' CommandName="DeleteWF" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
      </Columns>
      <EmptyDataTemplate>
        <asp:Label ID="LabelEmpty" runat="server" Font-Size="Small" ForeColor="Red" Text="No record found !!!"></asp:Label>
      </EmptyDataTemplate>
    </asp:GridView>
    <asp:ObjectDataSource 
      ID = "ODStaBDDA"
      runat = "server"
      DataObjectTypeName = "SIS.TA.taBDDA"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "UZ_taBDDASelectList"
      TypeName = "SIS.TA.taBDDA"
      SelectCountMethod = "taBDDASelectCount"
      SortParameterName="OrderBy" EnablePaging="True">
      <SelectParameters >
        <asp:ControlParameter ControlID="F_TABillNo" PropertyName="Text" Name="TABillNo" Type="Int32" Size="10" />
        <asp:Parameter Name="SearchState" Type="Boolean" Direction="Input" DefaultValue="false" />
        <asp:Parameter Name="SearchText" Type="String" Direction="Input" DefaultValue="" />
      </SelectParameters>
    </asp:ObjectDataSource>
    <br />
  </td></tr></table>
  </ContentTemplate>
  <Triggers>
    <asp:AsyncPostBackTrigger ControlID="GVtaBDDA" EventName="PageIndexChanged" />
  </Triggers>
</asp:UpdatePanel>
</div>
</fieldset>
    </div>
    <div  id="FS_Expense" runat="server">
<fieldset class="ui-widget-content page">
<legend>
    <asp:Label ID="LabeltaBDExpense" runat="server" Text="&nbsp;List: Other Expenses"></asp:Label>
</legend>
<div class="pagedata">
<asp:UpdatePanel ID="UPNLtaBDExpense" runat="server">
  <ContentTemplate>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLtaBDExpense"
      ToolType = "lgNMGrid"
      EditUrl = "~/TA_Main/App_Edit/EF_taBDExpense.aspx"
      AddUrl = "~/TA_Main/App_Create/AF_taBDExpense.aspx"
      AddPostBack = "True"
      EnableExit = "false"
      EnableAdd='<%# Eval("Editable") %>'
      ValidationGroup = "taBDExpense"
      runat = "server" />
    <asp:UpdateProgress ID="UPGStaBDExpense" runat="server" AssociatedUpdatePanelID="UPNLtaBDExpense" DisplayAfter="100">
      <ProgressTemplate>
        <span style="color: #ff0033">Loading...</span>
      </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:GridView ID="GVtaBDExpense" SkinID="gv_silver" runat="server" DataSourceID="ODStaBDExpense" DataKeyNames="TABillNo,SerialNo">
      <Columns>
        <asp:TemplateField HeaderText="EDIT">
          <ItemTemplate>
            <asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# Eval("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Serial No" SortExpression="SerialNo">
          <ItemTemplate>
            <asp:Label ID="LabelSerialNo" runat="server" ForeColor='<%# Eval("ForeColor") %>' Text='<%# Bind("SerialNo") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignright" />
          <HeaderStyle CssClass="alignright" Width="40px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Date" SortExpression="Date1Time">
          <ItemTemplate>
            <asp:Label ID="LabelDate1Time" runat="server" ForeColor='<%# Eval("ForeColor") %>' Text='<%# Bind("Date1Time") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="90px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Description" SortExpression="SystemText">
          <ItemTemplate>
            <asp:Label ID="LabelSystemText" runat="server" ForeColor='<%# Eval("ForeColor") %>' Text='<%# Bind("SystemText") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="" />
        <HeaderStyle CssClass="" Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Claimed Amount" SortExpression="AmountTotal">
          <ItemTemplate>
            <asp:Label ID="LabelAmountTotal" runat="server" ForeColor='<%# Eval("ForeColor") %>' Text='<%# Bind("AmountTotal") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignright" />
          <HeaderStyle CssClass="alignright" Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Passed Amount" SortExpression="PassedAmountTotal">
          <ItemTemplate>
            <asp:Label ID="LabelPassedAmountTotal" runat="server" ForeColor='<%# Eval("ForeColor") %>' Text='<%# Bind("PassedAmountTotal") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignright" />
          <HeaderStyle CssClass="alignright" Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="OOE Remarks" SortExpression="OOERemarks">
          <ItemTemplate>
            <asp:Label ID="LabelOOERemarks" runat="server" ForeColor='<%# Eval("ForeColor") %>' Text='<%# Bind("OOERemarks") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="" />
        <HeaderStyle CssClass="" Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Delete">
          <ItemTemplate>
            <asp:ImageButton ID="cmdDelete" ValidationGroup='<%# "Delete" & Container.DataItemIndex %>' CausesValidation="true" runat="server" Visible='<%# EVal("DeleteWFVisible") %>' Enabled='<%# EVal("DeleteWFEnable") %>' AlternateText='<%# EVal("PrimaryKey") %>' ToolTip="Delete" SkinID="Delete" OnClientClick='<%# "return Page_ClientValidate(""Delete" & Container.DataItemIndex & """) && confirm(""Delete record ?"");" %>' CommandName="DeleteWF" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
      </Columns>
      <EmptyDataTemplate>
        <asp:Label ID="LabelEmpty" runat="server" Font-Size="Small" ForeColor="Red" Text="No record found !!!"></asp:Label>
      </EmptyDataTemplate>
    </asp:GridView>
    <asp:ObjectDataSource 
      ID = "ODStaBDExpense"
      runat = "server"
      DataObjectTypeName = "SIS.TA.taBDExpense"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "UZ_taBDExpenseSelectList"
      TypeName = "SIS.TA.taBDExpense"
      SelectCountMethod = "taBDExpenseSelectCount"
      SortParameterName="OrderBy" EnablePaging="True">
      <SelectParameters >
        <asp:ControlParameter ControlID="F_TABillNo" PropertyName="Text" Name="TABillNo" Type="Int32" Size="10" />
        <asp:Parameter Name="SearchState" Type="Boolean" Direction="Input" DefaultValue="false" />
        <asp:Parameter Name="SearchText" Type="String" Direction="Input" DefaultValue="" />
      </SelectParameters>
    </asp:ObjectDataSource>
    <br />
  </td></tr></table>
  </ContentTemplate>
  <Triggers>
    <asp:AsyncPostBackTrigger ControlID="GVtaBDExpense" EventName="PageIndexChanged" />
  </Triggers>
</asp:UpdatePanel>
</div>
</fieldset>
    </div>
    <div  id="FS_Finance" runat="server">
<fieldset class="ui-widget-content page">
<legend>
    <asp:Label ID="LabeltaBDFinance" runat="server" Text="&nbsp;List: Source of Finance"></asp:Label>
</legend>
<div class="pagedata">
<asp:UpdatePanel ID="UPNLtaBDFinance" runat="server">
  <ContentTemplate>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLtaBDFinance"
      ToolType = "lgNMGrid"
      EditUrl = "~/TA_Main/App_Edit/EF_taBDFinance.aspx"
      AddUrl = "~/TA_Main/App_Create/AF_taBDFinance.aspx"
      AddPostBack = "True"
      EnableExit = "false"
      EnableAdd='<%# Eval("Editable") %>'
      ValidationGroup = "taBDFinance"
      runat = "server" />
    <asp:UpdateProgress ID="UPGStaBDFinance" runat="server" AssociatedUpdatePanelID="UPNLtaBDFinance" DisplayAfter="100">
      <ProgressTemplate>
        <span style="color: #ff0033">Loading...</span>
      </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:GridView ID="GVtaBDFinance" SkinID="gv_silver" runat="server" DataSourceID="ODStaBDFinance" DataKeyNames="TABillNo,SerialNo">
      <Columns>
        <asp:TemplateField HeaderText="EDIT">
          <ItemTemplate>
            <asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# Eval("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Serial No" SortExpression="SerialNo">
          <ItemTemplate>
            <asp:Label ID="LabelSerialNo" runat="server" ForeColor='<%# Eval("ForeColor") %>' Text='<%# Bind("SerialNo") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignright" />
          <HeaderStyle CssClass="alignright" Width="40px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Date" SortExpression="Date1Time">
          <ItemTemplate>
            <asp:Label ID="LabelDate1Time" runat="server" ForeColor='<%# Eval("ForeColor") %>' Text='<%# Bind("Date1Time") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="90px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Description" SortExpression="SystemText">
          <ItemTemplate>
            <asp:Label ID="LabelSystemText" runat="server" ForeColor='<%# Eval("ForeColor") %>' Text='<%# Bind("SystemText") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="" />
        <HeaderStyle CssClass="" Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Financed Amount" SortExpression="AmountTotal">
          <ItemTemplate>
            <asp:Label ID="LabelAmountTotal" runat="server" ForeColor='<%# Eval("ForeColor") %>' Text='<%# Bind("AmountTotal") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignright" />
          <HeaderStyle CssClass="alignright" Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Acknowledged Amount" SortExpression="PassedAmountTotal">
          <ItemTemplate>
            <asp:Label ID="LabelPassedAmountTotal" runat="server" ForeColor='<%# Eval("ForeColor") %>' Text='<%# Bind("PassedAmountTotal") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignright" />
          <HeaderStyle CssClass="alignright" Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="OOE Remarks" SortExpression="OOERemarks">
          <ItemTemplate>
            <asp:Label ID="LabelOOERemarks" runat="server" ForeColor='<%# Eval("ForeColor") %>' Text='<%# Bind("OOERemarks") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="" />
        <HeaderStyle CssClass="" Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Delete">
          <ItemTemplate>
            <asp:ImageButton ID="cmdDelete" ValidationGroup='<%# "Delete" & Container.DataItemIndex %>' CausesValidation="true" runat="server" Visible='<%# EVal("DeleteWFVisible") %>' Enabled='<%# EVal("DeleteWFEnable") %>' AlternateText='<%# EVal("PrimaryKey") %>' ToolTip="Delete" SkinID="Delete" OnClientClick='<%# "return Page_ClientValidate(""Delete" & Container.DataItemIndex & """) && confirm(""Delete record ?"");" %>' CommandName="DeleteWF" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
      </Columns>
      <EmptyDataTemplate>
        <asp:Label ID="LabelEmpty" runat="server" Font-Size="Small" ForeColor="Red" Text="No record found !!!"></asp:Label>
      </EmptyDataTemplate>
    </asp:GridView>
    <asp:ObjectDataSource 
      ID = "ODStaBDFinance"
      runat = "server"
      DataObjectTypeName = "SIS.TA.taBDFinance"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "UZ_taBDFinanceSelectList"
      TypeName = "SIS.TA.taBDFinance"
      SelectCountMethod = "taBDFinanceSelectCount"
      SortParameterName="OrderBy" EnablePaging="True">
      <SelectParameters >
        <asp:ControlParameter ControlID="F_TABillNo" PropertyName="Text" Name="TABillNo" Type="Int32" Size="10" />
        <asp:Parameter Name="SearchState" Type="Boolean" Direction="Input" DefaultValue="false" />
        <asp:Parameter Name="SearchText" Type="String" Direction="Input" DefaultValue="" />
      </SelectParameters>
    </asp:ObjectDataSource>
    <br />
  </td></tr></table>
  </ContentTemplate>
  <Triggers>
    <asp:AsyncPostBackTrigger ControlID="GVtaBDFinance" EventName="PageIndexChanged" />
  </Triggers>
</asp:UpdatePanel>
</div>
</fieldset>
    </div>
    <div  id="FS_Mileage" runat="server">
<fieldset class="ui-widget-content page">
<legend>
    <asp:Label ID="LabeltaBDMileage" runat="server" Text="&nbsp;List: Mileage Claim"></asp:Label>
</legend>
<div class="pagedata">
<asp:UpdatePanel ID="UPNLtaBDMileage" runat="server">
  <ContentTemplate>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLtaBDMileage"
      ToolType = "lgNMGrid"
      EditUrl = "~/TA_Main/App_Edit/EF_taBDMileage.aspx"
      AddUrl = "~/TA_Main/App_Create/AF_taBDMileage.aspx"
      AddPostBack = "True"
      EnableExit = "false"
      EnableAdd='<%# Eval("Editable") %>'
      ValidationGroup = "taBDMileage"
      runat = "server" />
    <asp:UpdateProgress ID="UPGStaBDMileage" runat="server" AssociatedUpdatePanelID="UPNLtaBDMileage" DisplayAfter="100">
      <ProgressTemplate>
        <span style="color: #ff0033">Loading...</span>
      </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:GridView ID="GVtaBDMileage" SkinID="gv_silver" runat="server" DataSourceID="ODStaBDMileage" DataKeyNames="TABillNo,SerialNo">
      <Columns>
        <asp:TemplateField HeaderText="EDIT">
          <ItemTemplate>
            <asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# Eval("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Serial No" SortExpression="SerialNo">
          <ItemTemplate>
            <asp:Label ID="LabelSerialNo" runat="server" ForeColor='<%# Eval("ForeColor") %>' Text='<%# Bind("SerialNo") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignright" />
          <HeaderStyle CssClass="alignright" Width="40px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Date" SortExpression="Date1Time">
          <ItemTemplate>
            <asp:Label ID="LabelDate1Time" runat="server" ForeColor='<%# Eval("ForeColor") %>' Text='<%# Bind("Date1Time") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="90px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Description" SortExpression="SystemText">
          <ItemTemplate>
            <asp:Label ID="LabelSystemText" runat="server" ForeColor='<%# Eval("ForeColor") %>' Text='<%# Bind("SystemText") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="" />
        <HeaderStyle CssClass="" Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Claimed Amount" SortExpression="AmountTotal">
          <ItemTemplate>
            <asp:Label ID="LabelAmountTotal" runat="server" ForeColor='<%# Eval("ForeColor") %>' Text='<%# Bind("AmountTotal") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignright" />
          <HeaderStyle CssClass="alignright" Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Passed Amount" SortExpression="PassedAmountTotal">
          <ItemTemplate>
            <asp:Label ID="LabelPassedAmountTotal" runat="server" ForeColor='<%# Eval("ForeColor") %>' Text='<%# Bind("PassedAmountTotal") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignright" />
          <HeaderStyle CssClass="alignright" Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="OOE Remarks" SortExpression="OOERemarks">
          <ItemTemplate>
            <asp:Label ID="LabelOOERemarks" runat="server" ForeColor='<%# Eval("ForeColor") %>' Text='<%# Bind("OOERemarks") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="" />
        <HeaderStyle CssClass="" Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Delete">
          <ItemTemplate>
            <asp:ImageButton ID="cmdDelete" ValidationGroup='<%# "Delete" & Container.DataItemIndex %>' CausesValidation="true" runat="server" Visible='<%# EVal("DeleteWFVisible") %>' Enabled='<%# EVal("DeleteWFEnable") %>' AlternateText='<%# EVal("PrimaryKey") %>' ToolTip="Delete" SkinID="Delete" OnClientClick='<%# "return Page_ClientValidate(""Delete" & Container.DataItemIndex & """) && confirm(""Delete record ?"");" %>' CommandName="DeleteWF" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
      </Columns>
      <EmptyDataTemplate>
        <asp:Label ID="LabelEmpty" runat="server" Font-Size="Small" ForeColor="Red" Text="No record found !!!"></asp:Label>
      </EmptyDataTemplate>
    </asp:GridView>
    <asp:ObjectDataSource 
      ID = "ODStaBDMileage"
      runat = "server"
      DataObjectTypeName = "SIS.TA.taBDMileage"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "UZ_taBDMileageSelectList"
      TypeName = "SIS.TA.taBDMileage"
      SelectCountMethod = "taBDMileageSelectCount"
      SortParameterName="OrderBy" EnablePaging="True">
      <SelectParameters >
        <asp:ControlParameter ControlID="F_TABillNo" PropertyName="Text" Name="TABillNo" Type="Int32" Size="10" />
        <asp:Parameter Name="SearchState" Type="Boolean" Direction="Input" DefaultValue="false" />
        <asp:Parameter Name="SearchText" Type="String" Direction="Input" DefaultValue="" />
      </SelectParameters>
    </asp:ObjectDataSource>
    <br />
  </td></tr></table>
  </ContentTemplate>
  <Triggers>
    <asp:AsyncPostBackTrigger ControlID="GVtaBDMileage" EventName="PageIndexChanged" />
  </Triggers>
</asp:UpdatePanel>
</div>
</fieldset>
    </div>
    <div  id="FS_Driver" runat="server">
<fieldset class="ui-widget-content page">
<legend>
    <asp:Label ID="LabeltaBDDriver" runat="server" Text="&nbsp;List: Driver Charges"></asp:Label>
</legend>
<div class="pagedata">
<asp:UpdatePanel ID="UPNLtaBDDriver" runat="server">
  <ContentTemplate>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLtaBDDriver"
      ToolType = "lgNMGrid"
      EditUrl = "~/TA_Main/App_Edit/EF_taBDDriver.aspx"
      AddUrl = "~/TA_Main/App_Create/AF_taBDDriver.aspx"
      AddPostBack = "True"
      EnableExit = "false"
      EnableAdd="false"
      ValidationGroup = "taBDDriver"
      runat = "server" />
    <asp:UpdateProgress ID="UPGStaBDDriver" runat="server" AssociatedUpdatePanelID="UPNLtaBDDriver" DisplayAfter="100">
      <ProgressTemplate>
        <span style="color: #ff0033">Loading...</span>
      </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:GridView ID="GVtaBDDriver" SkinID="gv_silver" runat="server" DataSourceID="ODStaBDDriver" DataKeyNames="TABillNo,SerialNo">
      <Columns>
        <asp:TemplateField HeaderText="EDIT">
          <ItemTemplate>
            <asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# Eval("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Serial No" SortExpression="SerialNo">
          <ItemTemplate>
            <asp:Label ID="LabelSerialNo" runat="server" ForeColor='<%# Eval("ForeColor") %>' Text='<%# Bind("SerialNo") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignright" />
          <HeaderStyle CssClass="alignright" Width="40px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Date" SortExpression="Date1Time">
          <ItemTemplate>
            <asp:Label ID="LabelDate1Time" runat="server" ForeColor='<%# Eval("ForeColor") %>' Text='<%# Bind("Date1Time") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="90px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Description" SortExpression="SystemText">
          <ItemTemplate>
            <asp:Label ID="LabelSystemText" runat="server" ForeColor='<%# Eval("ForeColor") %>' Text='<%# Bind("SystemText") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="" />
        <HeaderStyle CssClass="" Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Claimed Amount" SortExpression="AmountTotal">
          <ItemTemplate>
            <asp:Label ID="LabelAmountTotal" runat="server" ForeColor='<%# Eval("ForeColor") %>' Text='<%# Bind("AmountTotal") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignright" />
          <HeaderStyle CssClass="alignright" Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Passed Amount" SortExpression="PassedAmountTotal">
          <ItemTemplate>
            <asp:Label ID="LabelPassedAmountTotal" runat="server" ForeColor='<%# Eval("ForeColor") %>' Text='<%# Bind("PassedAmountTotal") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignright" />
          <HeaderStyle CssClass="alignright" Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="OOE Remarks" SortExpression="OOERemarks">
          <ItemTemplate>
            <asp:Label ID="LabelOOERemarks" runat="server" ForeColor='<%# Eval("ForeColor") %>' Text='<%# Bind("OOERemarks") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="" />
        <HeaderStyle CssClass="" Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Delete">
          <ItemTemplate>
            <asp:ImageButton ID="cmdDelete" ValidationGroup='<%# "Delete" & Container.DataItemIndex %>' CausesValidation="true" runat="server" Visible='<%# EVal("DeleteWFVisible") %>' Enabled='<%# EVal("DeleteWFEnable") %>' AlternateText='<%# EVal("PrimaryKey") %>' ToolTip="Delete" SkinID="Delete" OnClientClick='<%# "return Page_ClientValidate(""Delete" & Container.DataItemIndex & """) && confirm(""Delete record ?"");" %>' CommandName="DeleteWF" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
      </Columns>
      <EmptyDataTemplate>
        <asp:Label ID="LabelEmpty" runat="server" Font-Size="Small" ForeColor="Red" Text="No record found !!!"></asp:Label>
      </EmptyDataTemplate>
    </asp:GridView>
    <asp:ObjectDataSource 
      ID = "ODStaBDDriver"
      runat = "server"
      DataObjectTypeName = "SIS.TA.taBDDriver"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "UZ_taBDDriverSelectList"
      TypeName = "SIS.TA.taBDDriver"
      SelectCountMethod = "taBDDriverSelectCount"
      SortParameterName="OrderBy" EnablePaging="True">
      <SelectParameters >
        <asp:ControlParameter ControlID="F_TABillNo" PropertyName="Text" Name="TABillNo" Type="Int32" Size="10" />
        <asp:Parameter Name="SearchState" Type="Boolean" Direction="Input" DefaultValue="false" />
        <asp:Parameter Name="SearchText" Type="String" Direction="Input" DefaultValue="" />
      </SelectParameters>
    </asp:ObjectDataSource>
    <br />
  </td></tr></table>
  </ContentTemplate>
  <Triggers>
    <asp:AsyncPostBackTrigger ControlID="GVtaBDDriver" EventName="PageIndexChanged" />
  </Triggers>
</asp:UpdatePanel>
</div>
</fieldset>
    </div>
<fieldset class="ui-widget-content page">
<legend>
    <asp:Label ID="LabeltaBillPrjAmounts" runat="server" Text="&nbsp;List: Bill Project wise total"></asp:Label>
</legend>
<div class="pagedata">
<asp:UpdatePanel ID="UPNLtaBillPrjAmounts" runat="server">
  <ContentTemplate>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLtaBillPrjAmounts"
      ToolType = "lgNMGrid"
      EditUrl = "~/TA_Main/App_Edit/EF_taBillPrjAmounts.aspx"
      EnableAdd = "False"
      EnableExit = "false"
      ValidationGroup = "taBillPrjAmounts"
      runat = "server" />
    <asp:UpdateProgress ID="UPGStaBillPrjAmounts" runat="server" AssociatedUpdatePanelID="UPNLtaBillPrjAmounts" DisplayAfter="100">
      <ProgressTemplate>
        <span style="color: #ff0033">Loading...</span>
      </ProgressTemplate>
    </asp:UpdateProgress>
    <script type="text/javascript"> 
   var script_Percentage = {
    temp: function() {
    }
    }
    </script>

    <asp:GridView ID="GVtaBillPrjAmounts" SkinID="gv_silver" runat="server" DataSourceID="ODStaBillPrjAmounts" DataKeyNames="TABillNo,ProjectID">
      <Columns>
        <asp:TemplateField HeaderText="EDIT">
          <ItemTemplate>
            <asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# Eval("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Project ID" SortExpression="IDM_Projects1_Description">
          <ItemTemplate>
             <asp:Label ID="L_ProjectID" runat="server" ForeColor='<%# Eval("ForeColor") %>' Title='<%# EVal("ProjectID") %>' Text='<%# Eval("IDM_Projects1_Description") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Percentage" SortExpression="Percentage">
          <ItemTemplate>
          <asp:TextBox ID="F_Percentage"
            Text='<%# Bind("Percentage") %>'
            style="text-align: right"
            Width="72px"
            CssClass = "mytxt"
            ValidationGroup='<%# "taBillPrjAmounts" & Container.DataItemIndex %>'
            MaxLength="8"
            onfocus = "return this.select();"
            runat="server" />
          <AJX:MaskedEditExtender 
            ID = "MEEPercentage"
            runat = "server"
            mask = "999.99"
            AcceptNegative = "Left"
            MaskType="Number"
            MessageValidatorTip="true"
            InputDirection="RightToLeft"
            ErrorTooltipEnabled="true"
            TargetControlID="F_Percentage" />
          <AJX:MaskedEditValidator 
            ID = "MEVPercentage"
            runat = "server"
            ControlToValidate = "F_Percentage"
            ControlExtender = "MEEPercentage"
            EmptyValueBlurredText = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = '<%# "taBillPrjAmounts" & Container.DataItemIndex %>'
            IsValidEmpty = "false"
            MinimumValue = "0.01"
            SetFocusOnError="true" />

          </ItemTemplate>
          <ItemStyle CssClass="alignright" />
          <HeaderStyle CssClass="alignright" Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Total Amount [INR]" SortExpression="TotalAmountinINR">
          <ItemTemplate>
            <asp:Label ID="LabelTotalAmountinINR" runat="server" ForeColor='<%# Eval("ForeColor") %>' Text='<%# Bind("TotalAmountinINR") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignright" />
          <HeaderStyle CssClass="alignright" Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Save">
          <ItemTemplate>
            <asp:ImageButton ID="cmdCompleteWF" ValidationGroup='<%# "Complete" & Container.DataItemIndex %>' CausesValidation="true" runat="server" Visible='<%# EVal("CompleteWFVisible") %>' Enabled='<%# EVal("CompleteWFEnable") %>' AlternateText='<%# EVal("PrimaryKey") %>' ToolTip="Save" SkinID="complete" OnClientClick='<%# "return Page_ClientValidate(""Complete" & Container.DataItemIndex & """) && confirm(""Save record ?"");" %>' CommandName="CompleteWF" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
      </Columns>
      <EmptyDataTemplate>
        <asp:Label ID="LabelEmpty" runat="server" Font-Size="Small" ForeColor="Red" Text="No record found !!!"></asp:Label>
      </EmptyDataTemplate>
    </asp:GridView>
    <asp:ObjectDataSource 
      ID = "ODStaBillPrjAmounts"
      runat = "server"
      DataObjectTypeName = "SIS.TA.taBillPrjAmounts"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "UZ_taBillPrjAmountsSelectList"
      TypeName = "SIS.TA.taBillPrjAmounts"
      SelectCountMethod = "taBillPrjAmountsSelectCount"
      SortParameterName="OrderBy" EnablePaging="True">
      <SelectParameters >
        <asp:ControlParameter ControlID="F_TABillNo" PropertyName="Text" Name="TABillNo" Type="Int32" Size="10" />
        <asp:Parameter Name="SearchState" Type="Boolean" Direction="Input" DefaultValue="false" />
        <asp:Parameter Name="SearchText" Type="String" Direction="Input" DefaultValue="" />
      </SelectParameters>
    </asp:ObjectDataSource>
    <br />
  </td></tr></table>
  </ContentTemplate>
  <Triggers>
    <asp:AsyncPostBackTrigger ControlID="GVtaBillPrjAmounts" EventName="PageIndexChanged" />
  </Triggers>
</asp:UpdatePanel>
</div>
</fieldset>
<fieldset class="ui-widget-content page">
<legend>
    <asp:Label ID="LabeltaBillAmount" runat="server" Text="&nbsp;List: Bill Amounts"></asp:Label>
</legend>
<div class="pagedata">
<asp:UpdatePanel ID="UPNLtaBillAmount" runat="server">
  <ContentTemplate>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLtaBillAmount"
      ToolType = "lgNMGrid"
      EditUrl = "~/TA_Main/App_Edit/EF_taBillAmount.aspx"
      EnableAdd = "False"
      EnableExit = "false"
      ValidationGroup = "taBillAmount"
      runat = "server" />
    <asp:UpdateProgress ID="UPGStaBillAmount" runat="server" AssociatedUpdatePanelID="UPNLtaBillAmount" DisplayAfter="100">
      <ProgressTemplate>
        <span style="color: #ff0033">Loading...</span>
      </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:GridView ID="GVtaBillAmount" SkinID="gv_silver" runat="server" DataSourceID="ODStaBillAmount" DataKeyNames="TABillNo,ComponentID,CurrencyID,CostCenterID">
      <Columns>
        <asp:TemplateField HeaderText="EDIT">
          <ItemTemplate>
            <asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# Eval("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="COMPONENT" SortExpression="TA_Components4_Description">
          <ItemTemplate>
             <asp:Label ID="L_ComponentID" runat="server" ForeColor='<%# Eval("ForeColor") %>' Title='<%# EVal("ComponentID") %>' Text='<%# Eval("TA_Components4_Description") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="CURRENCY" SortExpression="TA_Currencies5_CurrencyName">
          <ItemTemplate>
             <asp:Label ID="L_CurrencyID" runat="server" ForeColor='<%# Eval("ForeColor") %>' Title='<%# EVal("CurrencyID") %>' Text='<%# Eval("TA_Currencies5_CurrencyName") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="COST CENTER" SortExpression="HRM_Departments1_Description">
          <ItemTemplate>
             <asp:Label ID="L_CostCenterID" runat="server" ForeColor='<%# Eval("ForeColor") %>' Title='<%# EVal("CostCenterID") %>' Text='<%# Eval("HRM_Departments1_Description") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="TOTAL" SortExpression="TotalInCurrency">
          <ItemTemplate>
            <asp:Label ID="LabelTotalInCurrency" runat="server" ForeColor='<%# Eval("ForeColor") %>' Text='<%# Bind("TotalInCurrency") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignright" />
          <HeaderStyle CssClass="alignright" Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="TOTAL [INR]" SortExpression="TotalInINR">
          <ItemTemplate>
            <asp:Label ID="LabelTotalInINR" runat="server" ForeColor='<%# Eval("ForeColor") %>' Text='<%# Bind("TotalInINR") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignright" />
          <HeaderStyle CssClass="alignright" Width="80px" />
        </asp:TemplateField>
      </Columns>
      <EmptyDataTemplate>
        <asp:Label ID="LabelEmpty" runat="server" Font-Size="Small" ForeColor="Red" Text="No record found !!!"></asp:Label>
      </EmptyDataTemplate>
    </asp:GridView>
    <asp:ObjectDataSource 
      ID = "ODStaBillAmount"
      runat = "server"
      DataObjectTypeName = "SIS.TA.taBillAmount"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "UZ_taBillAmountSelectList"
      TypeName = "SIS.TA.taBillAmount"
      SelectCountMethod = "taBillAmountSelectCount"
      SortParameterName="OrderBy" EnablePaging="True">
      <SelectParameters >
        <asp:ControlParameter ControlID="F_TABillNo" PropertyName="Text" Name="TABillNo" Type="Int32" Size="10" />
        <asp:Parameter Name="SearchState" Type="Boolean" Direction="Input" DefaultValue="false" />
        <asp:Parameter Name="SearchText" Type="String" Direction="Input" DefaultValue="" />
      </SelectParameters>
    </asp:ObjectDataSource>
    <br />
  </td></tr></table>
  </ContentTemplate>
  <Triggers>
    <asp:AsyncPostBackTrigger ControlID="GVtaBillAmount" EventName="PageIndexChanged" />
  </Triggers>
</asp:UpdatePanel>
</div>
</fieldset>
  </EditItemTemplate>
</asp:FormView>
  </ContentTemplate>
</asp:UpdatePanel>
<asp:ObjectDataSource 
  ID = "ODStaBH"
  DataObjectTypeName = "SIS.TA.taBH"
  SelectMethod = "taBHGetByID"
  UpdateMethod="UZ_taBHUpdate"
  DeleteMethod="UZ_taBHDelete"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.TA.taBH"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="TABillNo" Name="TABillNo" Type="Int32" />
</SelectParameters>
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
